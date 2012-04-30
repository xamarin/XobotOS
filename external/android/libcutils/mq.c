/*
 * Copyright (C) 2007 The Android Open Source Project
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

#define LOG_TAG "mq"

#include <assert.h>
#include <errno.h>
#include <fcntl.h>
#include <pthread.h>
#include <stdlib.h>
#include <string.h>
#include <unistd.h>

#include <sys/socket.h>
#include <sys/types.h>
#include <sys/un.h>
#include <sys/uio.h>

#include <cutils/array.h>
#include <cutils/hashmap.h>
#include <cutils/selector.h>

#include "loghack.h"
#include "buffer.h"

/** Number of dead peers to remember. */
#define PEER_HISTORY (16)

typedef struct sockaddr SocketAddress;
typedef struct sockaddr_un UnixAddress;

/** 
 * Process/user/group ID. We don't use ucred directly because it's only 
 * available on Linux.
 */
typedef struct {
    pid_t pid;
    uid_t uid;
    gid_t gid;
} Credentials;

/** Listens for bytes coming from remote peers. */
typedef void BytesListener(Credentials credentials, char* bytes, size_t size);

/** Listens for the deaths of remote peers. */
typedef void DeathListener(pid_t pid);

/** Types of packets. */
typedef enum {
    /** Request for a connection to another peer. */
    CONNECTION_REQUEST, 

    /** A connection to another peer. */
    CONNECTION, 

    /** Reports a failed connection attempt. */
    CONNECTION_ERROR, 

    /** A generic packet of bytes. */
    BYTES,
} PacketType;

typedef enum {
    /** Reading a packet header. */
    READING_HEADER,

    /** Waiting for a connection from the master. */
    ACCEPTING_CONNECTION,

    /** Reading bytes. */
    READING_BYTES,
} InputState;

/** A packet header. */
// TODO: Use custom headers for master->peer, peer->master, peer->peer.
typedef struct {
    PacketType type;
    union {
        /** Packet size. Used for BYTES. */
        size_t size;

        /** Credentials. Used for CONNECTION and CONNECTION_REQUEST. */
        Credentials credentials; 
    };
} Header;

/** A packet which will be sent to a peer. */
typedef struct OutgoingPacket OutgoingPacket;
struct OutgoingPacket {
    /** Packet header. */
    Header header; 
    
    union {
        /** Connection to peer. Used with CONNECTION. */
        int socket;
        
        /** Buffer of bytes. Used with BYTES. */
        Buffer* bytes;
    };

    /** Frees all resources associated with this packet. */
    void (*free)(OutgoingPacket* packet);
   
    /** Optional context. */
    void* context;
    
    /** Next packet in the queue. */
    OutgoingPacket* nextPacket;
};

/** Represents a remote peer. */
typedef struct PeerProxy PeerProxy;

/** Local peer state. You typically have one peer per process. */
typedef struct {
    /** This peer's PID. */
    pid_t pid;
    
    /** 
     * Map from pid to peer proxy. The peer has a peer proxy for each remote
     * peer it's connected to. 
     *
     * Acquire mutex before use.
     */
    Hashmap* peerProxies;

    /** Manages I/O. */
    Selector* selector;
   
    /** Used to synchronize operations with the selector thread. */
    pthread_mutex_t mutex; 

    /** Is this peer the master? */
    bool master;

    /** Peer proxy for the master. */
    PeerProxy* masterProxy;
    
    /** Listens for packets from remote peers. */
    BytesListener* onBytes;
    
    /** Listens for deaths of remote peers. */
    DeathListener* onDeath;
    
    /** Keeps track of recently dead peers. Requires mutex. */
    pid_t deadPeers[PEER_HISTORY];
    size_t deadPeerCursor;
} Peer;

struct PeerProxy {
    /** Credentials of the remote process. */
    Credentials credentials;

    /** Keeps track of data coming in from the remote peer. */
    InputState inputState;
    Buffer* inputBuffer;
    PeerProxy* connecting;

    /** File descriptor for this peer. */
    SelectableFd* fd;

    /** 
     * Queue of packets to be written out to the remote peer.
     *
     * Requires mutex.
     */
    // TODO: Limit queue length.
    OutgoingPacket* currentPacket;
    OutgoingPacket* lastPacket;
    
    /** Used to write outgoing header. */
    Buffer outgoingHeader;
    
    /** True if this is the master's proxy. */
    bool master;

    /** Reference back to the local peer. */
    Peer* peer;

    /**
     * Used in master only. Maps this peer proxy to other peer proxies to
     * which the peer has been connected to. Maps pid to PeerProxy. Helps
     * keep track of which connections we've sent to whom.
     */
    Hashmap* connections;
};

/** Server socket path. */
static const char* MASTER_PATH = "/master.peer";

/** Credentials of the master peer. */
static const Credentials MASTER_CREDENTIALS = {0, 0, 0};

/** Creates a peer proxy and adds it to the peer proxy map. */
static PeerProxy* peerProxyCreate(Peer* peer, Credentials credentials);

/** Sets the non-blocking flag on a descriptor. */
static void setNonBlocking(int fd) {
    int flags;
    if ((flags = fcntl(fd, F_GETFL, 0)) < 0) { 
        LOG_ALWAYS_FATAL("fcntl() error: %s", strerror(errno));
    } 
    if (fcntl(fd, F_SETFL, flags | O_NONBLOCK) < 0) { 
        LOG_ALWAYS_FATAL("fcntl() error: %s", strerror(errno));
    } 
}

/** Closes a fd and logs a warning if the close fails. */
static void closeWithWarning(int fd) {
    int result = close(fd);
    if (result == -1) {
        LOGW("close() error: %s", strerror(errno));
    }
}

/** Hashes pid_t keys. */
static int pidHash(void* key) {
    pid_t* pid = (pid_t*) key;
    return (int) (*pid);
}

/** Compares pid_t keys. */
static bool pidEquals(void* keyA, void* keyB) {
    pid_t* a = (pid_t*) keyA;
    pid_t* b = (pid_t*) keyB;
    return *a == *b;
}

/** Gets the master address. Not thread safe. */
static UnixAddress* getMasterAddress() {
    static UnixAddress masterAddress;
    static bool initialized = false;
    if (initialized == false) {
        masterAddress.sun_family = AF_LOCAL;
        strcpy(masterAddress.sun_path, MASTER_PATH); 
        initialized = true;
    }
    return &masterAddress;
}

/** Gets exclusive access to the peer for this thread. */
static void peerLock(Peer* peer) {
    pthread_mutex_lock(&peer->mutex);
}

/** Releases exclusive access to the peer. */
static void peerUnlock(Peer* peer) {
    pthread_mutex_unlock(&peer->mutex);
}

/** Frees a simple, i.e. header-only, outgoing packet. */
static void outgoingPacketFree(OutgoingPacket* packet) {
    LOGD("Freeing outgoing packet.");
	free(packet);
}

/**
 * Prepare to read a new packet from the peer.
 */
static void peerProxyExpectHeader(PeerProxy* peerProxy) {
    peerProxy->inputState = READING_HEADER;
    bufferPrepareForRead(peerProxy->inputBuffer, sizeof(Header));
}

/** Sets up the buffer for the outgoing header. */
static void peerProxyPrepareOutgoingHeader(PeerProxy* peerProxy) {
    peerProxy->outgoingHeader.data 
        = (char*) &(peerProxy->currentPacket->header);
    peerProxy->outgoingHeader.size = sizeof(Header);
    bufferPrepareForWrite(&peerProxy->outgoingHeader);
}

/** Adds a packet to the end of the queue. Callers must have the mutex. */
static void peerProxyEnqueueOutgoingPacket(PeerProxy* peerProxy,
        OutgoingPacket* newPacket) {
    newPacket->nextPacket = NULL; // Just in case.
    if (peerProxy->currentPacket == NULL) {
        // The queue is empty.
        peerProxy->currentPacket = newPacket;
        peerProxy->lastPacket = newPacket;
        
        peerProxyPrepareOutgoingHeader(peerProxy); 
    } else {
        peerProxy->lastPacket->nextPacket = newPacket;
    }
}

/** Takes the peer lock and enqueues the given packet. */
static void peerProxyLockAndEnqueueOutgoingPacket(PeerProxy* peerProxy,
        OutgoingPacket* newPacket) {
    Peer* peer = peerProxy->peer;
    peerLock(peer);
    peerProxyEnqueueOutgoingPacket(peerProxy, newPacket);
    peerUnlock(peer);
}

/** 
 * Frees current packet and moves to the next one. Returns true if there is
 * a next packet or false if the queue is empty.
 */
static bool peerProxyNextPacket(PeerProxy* peerProxy) {
    Peer* peer = peerProxy->peer;
    peerLock(peer);
    
    OutgoingPacket* current = peerProxy->currentPacket;
    
    if (current == NULL) {
    	// The queue is already empty.
        peerUnlock(peer);
        return false;
    }
    
    OutgoingPacket* next = current->nextPacket;
    peerProxy->currentPacket = next;
    current->nextPacket = NULL;
    current->free(current);
    if (next == NULL) {
        // The queue is empty.
        peerProxy->lastPacket = NULL;
        peerUnlock(peer);
        return false;
    } else {
        peerUnlock(peer);
        peerProxyPrepareOutgoingHeader(peerProxy); 

        // TODO: Start writing next packet? It would reduce the number of
        // system calls, but we could also starve other peers.
        return true;
    }
}

/**
 * Checks whether a peer died recently.
 */
static bool peerIsDead(Peer* peer, pid_t pid) {
    size_t i;
    for (i = 0; i < PEER_HISTORY; i++) {
        pid_t deadPeer = peer->deadPeers[i];
        if (deadPeer == 0) {
            return false;
        }
        if (deadPeer == pid) {
            return true;
        }
    }
    return false;
}

/**
 * Cleans up connection information.
 */
static bool peerProxyRemoveConnection(void* key, void* value, void* context) {
    PeerProxy* deadPeer = (PeerProxy*) context;
    PeerProxy* otherPeer = (PeerProxy*) value;
    hashmapRemove(otherPeer->connections, &(deadPeer->credentials.pid));
    return true;
}

/**
 * Called when the peer dies.
 */
static void peerProxyKill(PeerProxy* peerProxy, bool errnoIsSet) {
    if (errnoIsSet) {
        LOGI("Peer %d died. errno: %s", peerProxy->credentials.pid, 
                strerror(errno));
    } else {
        LOGI("Peer %d died.", peerProxy->credentials.pid);
    }
    
    // If we lost the master, we're up a creek. We can't let this happen.
    if (peerProxy->master) {    
        LOG_ALWAYS_FATAL("Lost connection to master.");
    }

    Peer* localPeer = peerProxy->peer;
    pid_t pid = peerProxy->credentials.pid;
    
    peerLock(localPeer);
    
    // Remember for awhile that the peer died.
    localPeer->deadPeers[localPeer->deadPeerCursor] 
        = peerProxy->credentials.pid;
    localPeer->deadPeerCursor++;
    if (localPeer->deadPeerCursor == PEER_HISTORY) {
        localPeer->deadPeerCursor = 0;
    }
  
    // Remove from peer map.
    hashmapRemove(localPeer->peerProxies, &pid);
    
    // External threads can no longer get to this peer proxy, so we don't 
    // need the lock anymore.
    peerUnlock(localPeer);
    
    // Remove the fd from the selector.
    if (peerProxy->fd != NULL) {
        peerProxy->fd->remove = true;
    }

    // Clear outgoing packet queue.
    while (peerProxyNextPacket(peerProxy)) {}

    bufferFree(peerProxy->inputBuffer);

    // This only applies to the master.
    if (peerProxy->connections != NULL) {
        // We can't leave these other maps pointing to freed memory.
        hashmapForEach(peerProxy->connections, &peerProxyRemoveConnection, 
                peerProxy);
        hashmapFree(peerProxy->connections);
    }

    // Invoke death listener.
    localPeer->onDeath(pid);

    // Free the peer proxy itself.
    free(peerProxy);
}

static void peerProxyHandleError(PeerProxy* peerProxy, char* functionName) {
    if (errno == EINTR) {
        // Log interruptions but otherwise ignore them.
        LOGW("%s() interrupted.", functionName);
    } else if (errno == EAGAIN) {
    	LOGD("EWOULDBLOCK");
        // Ignore.
    } else {
        LOGW("Error returned by %s().", functionName);
        peerProxyKill(peerProxy, true);
    }
}

/**
 * Buffers output sent to a peer. May be called multiple times until the entire
 * buffer is filled. Returns true when the buffer is empty.
 */
static bool peerProxyWriteFromBuffer(PeerProxy* peerProxy, Buffer* outgoing) {
    ssize_t size = bufferWrite(outgoing, peerProxy->fd->fd);
    if (size < 0) {
        peerProxyHandleError(peerProxy, "write");
        return false;
    } else {
        return bufferWriteComplete(outgoing);
    }
}

/** Writes packet bytes to peer. */
static void peerProxyWriteBytes(PeerProxy* peerProxy) {	
	Buffer* buffer = peerProxy->currentPacket->bytes;
	if (peerProxyWriteFromBuffer(peerProxy, buffer)) {
        LOGD("Bytes written.");
        peerProxyNextPacket(peerProxy);
    }    
}

/** Sends a socket to the peer. */
static void peerProxyWriteConnection(PeerProxy* peerProxy) {
    int socket = peerProxy->currentPacket->socket;

    // Why does sending and receiving fds have to be such a PITA?
    struct msghdr msg;
    struct iovec iov[1];
    
    union {
        struct cmsghdr cm;
        char control[CMSG_SPACE(sizeof(int))];
    } control_un;
   
    struct cmsghdr *cmptr;
    
    msg.msg_control = control_un.control;
    msg.msg_controllen = sizeof(control_un.control);
    cmptr = CMSG_FIRSTHDR(&msg);
    cmptr->cmsg_len = CMSG_LEN(sizeof(int));
    cmptr->cmsg_level = SOL_SOCKET;
    cmptr->cmsg_type = SCM_RIGHTS;
   
    // Store the socket in the message.
    *((int *) CMSG_DATA(cmptr)) = peerProxy->currentPacket->socket;

    msg.msg_name = NULL;
    msg.msg_namelen = 0;
    iov[0].iov_base = "";
    iov[0].iov_len = 1;
    msg.msg_iov = iov;
    msg.msg_iovlen = 1;

    ssize_t result = sendmsg(peerProxy->fd->fd, &msg, 0);
    
    if (result < 0) {
        peerProxyHandleError(peerProxy, "sendmsg");
    } else {
        // Success. Queue up the next packet.
        peerProxyNextPacket(peerProxy);
        
    }
}

/**
 * Writes some outgoing data.
 */
static void peerProxyWrite(SelectableFd* fd) {
    // TODO: Try to write header and body with one system call.

    PeerProxy* peerProxy = (PeerProxy*) fd->data;
    OutgoingPacket* current = peerProxy->currentPacket;
    
    if (current == NULL) {
        // We have nothing left to write.
        return;
    }

    // Write the header.
    Buffer* outgoingHeader = &peerProxy->outgoingHeader;
    bool headerWritten = bufferWriteComplete(outgoingHeader);
    if (!headerWritten) {
        LOGD("Writing header...");
        headerWritten = peerProxyWriteFromBuffer(peerProxy, outgoingHeader);
        if (headerWritten) {
            LOGD("Header written.");
        }
    }    

    // Write body.
    if (headerWritten) {
        PacketType type = current->header.type;
        switch (type) {
            case CONNECTION:
                peerProxyWriteConnection(peerProxy);
                break;
            case BYTES:
                peerProxyWriteBytes(peerProxy);
                break;
            case CONNECTION_REQUEST:
            case CONNECTION_ERROR:
                // These packets consist solely of a header.
                peerProxyNextPacket(peerProxy);
                break;
            default:
                LOG_ALWAYS_FATAL("Unknown packet type: %d", type); 
        }
    }
}

/**
 * Sets up a peer proxy's fd before we try to select() it.
 */
static void peerProxyBeforeSelect(SelectableFd* fd) {
    LOGD("Before select...");

    PeerProxy* peerProxy = (PeerProxy*) fd->data;
  
    peerLock(peerProxy->peer);
    bool hasPackets = peerProxy->currentPacket != NULL;
    peerUnlock(peerProxy->peer);
    
    if (hasPackets) {
        LOGD("Packets found. Setting onWritable().");
            
        fd->onWritable = &peerProxyWrite;
    } else {
        // We have nothing to write.
        fd->onWritable = NULL;
    }
}

/** Prepare to read bytes from the peer. */
static void peerProxyExpectBytes(PeerProxy* peerProxy, Header* header) {
	LOGD("Expecting %d bytes.", header->size);
	
	peerProxy->inputState = READING_BYTES;
    if (bufferPrepareForRead(peerProxy->inputBuffer, header->size) == -1) {
        LOGW("Couldn't allocate memory for incoming data. Size: %u",
                (unsigned int) header->size);    
        
        // TODO: Ignore the packet and log a warning?
        peerProxyKill(peerProxy, false);
    }
}

/**
 * Gets a peer proxy for the given ID. Creates a peer proxy if necessary.
 * Sends a connection request to the master if desired.
 *
 * Returns NULL if an error occurs. Sets errno to EHOSTDOWN if the peer died
 * or ENOMEM if memory couldn't be allocated.
 */
static PeerProxy* peerProxyGetOrCreate(Peer* peer, pid_t pid, 
        bool requestConnection) {
    if (pid == peer->pid) {
        errno = EINVAL;
        return NULL;
    }
    
    if (peerIsDead(peer, pid)) {
        errno = EHOSTDOWN;
        return NULL;
    }
    
    PeerProxy* peerProxy = hashmapGet(peer->peerProxies, &pid);
    if (peerProxy != NULL) {
        return peerProxy;
    }

    // If this is the master peer, we already know about all peers.
    if (peer->master) {
        errno = EHOSTDOWN;
        return NULL;
    }

    // Try to create a peer proxy.
    Credentials credentials;
    credentials.pid = pid;

    // Fake gid and uid until we have the real thing. The real creds are
    // filled in by masterProxyExpectConnection(). These fake creds will
    // never be exposed to the user.
    credentials.uid = 0;
    credentials.gid = 0;

    // Make sure we can allocate the connection request packet.
    OutgoingPacket* packet = NULL;
    if (requestConnection) {
        packet = calloc(1, sizeof(OutgoingPacket));
        if (packet == NULL) {
            errno = ENOMEM;
            return NULL;
        }

        packet->header.type = CONNECTION_REQUEST;
        packet->header.credentials = credentials;
        packet->free = &outgoingPacketFree;
    }
    
    peerProxy = peerProxyCreate(peer, credentials);
    if (peerProxy == NULL) {
        free(packet);
        errno = ENOMEM;
        return NULL;
    } else {
        // Send a connection request to the master.
        if (requestConnection) {
            PeerProxy* masterProxy = peer->masterProxy;
            peerProxyEnqueueOutgoingPacket(masterProxy, packet);
        }
        
        return peerProxy;
    }
}

/**
 * Switches the master peer proxy into a state where it's waiting for a
 * connection from the master.
 */
static void masterProxyExpectConnection(PeerProxy* masterProxy,
        Header* header) {
    // TODO: Restructure things so we don't need this check.
    // Verify that this really is the master.
    if (!masterProxy->master) {
        LOGW("Non-master process %d tried to send us a connection.", 
            masterProxy->credentials.pid);
        // Kill off the evil peer.
        peerProxyKill(masterProxy, false);
        return;
    }
    
    masterProxy->inputState = ACCEPTING_CONNECTION;
    Peer* localPeer = masterProxy->peer;
   
    // Create a peer proxy so we have somewhere to stash the creds.
    // See if we already have a proxy set up.
    pid_t pid = header->credentials.pid;
    peerLock(localPeer);
    PeerProxy* peerProxy = peerProxyGetOrCreate(localPeer, pid, false);
    if (peerProxy == NULL) {
        LOGW("Peer proxy creation failed: %s", strerror(errno));
    } else {
        // Fill in full credentials.
        peerProxy->credentials = header->credentials;
    }
    peerUnlock(localPeer);
    
    // Keep track of which peer proxy we're accepting a connection for.
    masterProxy->connecting = peerProxy;
}

/**
 * Reads input from a peer process.
 */
static void peerProxyRead(SelectableFd* fd);

/** Sets up fd callbacks. */
static void peerProxySetFd(PeerProxy* peerProxy, SelectableFd* fd) {
    peerProxy->fd = fd;
    fd->data = peerProxy;
    fd->onReadable = &peerProxyRead;
    fd->beforeSelect = &peerProxyBeforeSelect;
    
    // Make the socket non-blocking.
    setNonBlocking(fd->fd);
}

/**
 * Accepts a connection sent by the master proxy.
 */
static void masterProxyAcceptConnection(PeerProxy* masterProxy) {
    struct msghdr msg;
    struct iovec iov[1];
    ssize_t size;
    char ignored;
    int incomingFd;
    
    // TODO: Reuse code which writes the connection. Who the heck designed
    // this API anyway?
    union {
        struct cmsghdr cm;
        char control[CMSG_SPACE(sizeof(int))];
    } control_un;
    struct cmsghdr *cmptr;
    msg.msg_control = control_un.control;
    msg.msg_controllen = sizeof(control_un.control);

    msg.msg_name = NULL;
    msg.msg_namelen = 0;

    // We sent 1 byte of data so we can detect EOF.
    iov[0].iov_base = &ignored;
    iov[0].iov_len = 1;
    msg.msg_iov = iov;
    msg.msg_iovlen = 1;

    size = recvmsg(masterProxy->fd->fd, &msg, 0);
    if (size < 0) {
        if (errno == EINTR) {
            // Log interruptions but otherwise ignore them.
            LOGW("recvmsg() interrupted.");
            return;
        } else if (errno == EAGAIN) {
            // Keep waiting for the connection.
            return;
        } else {
            LOG_ALWAYS_FATAL("Error reading connection from master: %s",
                    strerror(errno));
        }
    } else if (size == 0) {
        // EOF.
        LOG_ALWAYS_FATAL("Received EOF from master.");
    }

    // Extract fd from message.
    if ((cmptr = CMSG_FIRSTHDR(&msg)) != NULL 
            && cmptr->cmsg_len == CMSG_LEN(sizeof(int))) {
        if (cmptr->cmsg_level != SOL_SOCKET) {
            LOG_ALWAYS_FATAL("Expected SOL_SOCKET.");
        }
        if (cmptr->cmsg_type != SCM_RIGHTS) {
            LOG_ALWAYS_FATAL("Expected SCM_RIGHTS.");
        }
        incomingFd = *((int*) CMSG_DATA(cmptr));
    } else {
        LOG_ALWAYS_FATAL("Expected fd.");
    }
    
    // The peer proxy this connection is for.
    PeerProxy* peerProxy = masterProxy->connecting;
    if (peerProxy == NULL) {
        LOGW("Received connection for unknown peer.");
        closeWithWarning(incomingFd);
    } else {
        Peer* peer = masterProxy->peer;
        
        SelectableFd* selectableFd = selectorAdd(peer->selector, incomingFd);
        if (selectableFd == NULL) {
            LOGW("Error adding fd to selector for %d.",
                    peerProxy->credentials.pid);
            closeWithWarning(incomingFd);
            peerProxyKill(peerProxy, false);
        }

        peerProxySetFd(peerProxy, selectableFd);
    }
    
    peerProxyExpectHeader(masterProxy);
}

/**
 * Frees an outgoing packet containing a connection.
 */
static void outgoingPacketFreeSocket(OutgoingPacket* packet) {
    closeWithWarning(packet->socket);
    outgoingPacketFree(packet);
}

/**
 * Connects two known peers.
 */
static void masterConnectPeers(PeerProxy* peerA, PeerProxy* peerB) {
    int sockets[2];
    int result = socketpair(AF_LOCAL, SOCK_STREAM, 0, sockets);
    if (result == -1) {
        LOGW("socketpair() error: %s", strerror(errno));
        // TODO: Send CONNECTION_FAILED packets to peers.
        return;
    }

    OutgoingPacket* packetA = calloc(1, sizeof(OutgoingPacket));
    OutgoingPacket* packetB = calloc(1, sizeof(OutgoingPacket));
    if (packetA == NULL || packetB == NULL) {
        free(packetA);
        free(packetB);
        LOGW("malloc() error. Failed to tell process %d that process %d is"
                " dead.", peerA->credentials.pid, peerB->credentials.pid);
        return;
    }
   
    packetA->header.type = CONNECTION;
    packetB->header.type = CONNECTION;
    
    packetA->header.credentials = peerB->credentials;
    packetB->header.credentials = peerA->credentials;

    packetA->socket = sockets[0];
    packetB->socket = sockets[1];

    packetA->free = &outgoingPacketFreeSocket;
    packetB->free = &outgoingPacketFreeSocket;
   
    peerLock(peerA->peer);
    peerProxyEnqueueOutgoingPacket(peerA, packetA);   
    peerProxyEnqueueOutgoingPacket(peerB, packetB);   
    peerUnlock(peerA->peer);
}

/**
 * Informs a peer that the peer they're trying to connect to couldn't be
 * found.
 */
static void masterReportConnectionError(PeerProxy* peerProxy,
        Credentials credentials) {
    OutgoingPacket* packet = calloc(1, sizeof(OutgoingPacket));
    if (packet == NULL) {
        LOGW("malloc() error. Failed to tell process %d that process %d is"
                " dead.", peerProxy->credentials.pid, credentials.pid);
        return;
    }
   
    packet->header.type = CONNECTION_ERROR;
    packet->header.credentials = credentials;
    packet->free = &outgoingPacketFree;
    
    peerProxyLockAndEnqueueOutgoingPacket(peerProxy, packet);   
}

/**
 * Handles a request to be connected to another peer.
 */
static void masterHandleConnectionRequest(PeerProxy* peerProxy, 
        Header* header) {
    Peer* master = peerProxy->peer;
    pid_t targetPid = header->credentials.pid;
    if (!hashmapContainsKey(peerProxy->connections, &targetPid)) {
        // We haven't connected these peers yet.
        PeerProxy* targetPeer 
            = (PeerProxy*) hashmapGet(master->peerProxies, &targetPid);
        if (targetPeer == NULL) {
            // Unknown process.
            masterReportConnectionError(peerProxy, header->credentials);
        } else {
            masterConnectPeers(peerProxy, targetPeer);
        }
    }
    
    // This packet is complete. Get ready for the next one.
    peerProxyExpectHeader(peerProxy);
}

/**
 * The master told us this peer is dead.
 */
static void masterProxyHandleConnectionError(PeerProxy* masterProxy,
        Header* header) {
    Peer* peer = masterProxy->peer;
    
    // Look up the peer proxy.
    pid_t pid = header->credentials.pid;
    PeerProxy* peerProxy = NULL;
    peerLock(peer);
    peerProxy = hashmapGet(peer->peerProxies, &pid);
    peerUnlock(peer);

    if (peerProxy != NULL) {
        LOGI("Couldn't connect to %d.", pid);
        peerProxyKill(peerProxy, false);
    } else {
        LOGW("Peer proxy for %d not found. This shouldn't happen.", pid);
    }
    
    peerProxyExpectHeader(masterProxy);
}

/**
 * Handles a packet header.
 */
static void peerProxyHandleHeader(PeerProxy* peerProxy, Header* header) {
    switch (header->type) {
        case CONNECTION_REQUEST:
            masterHandleConnectionRequest(peerProxy, header);
            break;
        case CONNECTION:
            masterProxyExpectConnection(peerProxy, header);
            break;
        case CONNECTION_ERROR:
            masterProxyHandleConnectionError(peerProxy, header);
            break;
        case BYTES:    
            peerProxyExpectBytes(peerProxy, header);
            break;
        default:
            LOGW("Invalid packet type from %d: %d", peerProxy->credentials.pid, 
                    header->type);
            peerProxyKill(peerProxy, false);
    }
}

/**
 * Buffers input sent by peer. May be called multiple times until the entire
 * buffer is filled. Returns true when the buffer is full.
 */
static bool peerProxyBufferInput(PeerProxy* peerProxy) {
    Buffer* in = peerProxy->inputBuffer;
    ssize_t size = bufferRead(in, peerProxy->fd->fd);
    if (size < 0) {
        peerProxyHandleError(peerProxy, "read");
        return false;
    } else if (size == 0) {
        // EOF.
    	LOGI("EOF");
        peerProxyKill(peerProxy, false);
        return false;
    } else if (bufferReadComplete(in)) {
        // We're done!
        return true;
    } else {
        // Continue reading.
        return false;
    }
}

/**
 * Reads input from a peer process.
 */
static void peerProxyRead(SelectableFd* fd) {
    LOGD("Reading...");
    PeerProxy* peerProxy = (PeerProxy*) fd->data;
    int state = peerProxy->inputState;
    Buffer* in = peerProxy->inputBuffer;
    switch (state) {
        case READING_HEADER:
            if (peerProxyBufferInput(peerProxy)) {
                LOGD("Header read.");
                // We've read the complete header.
                Header* header = (Header*) in->data;
                peerProxyHandleHeader(peerProxy, header);
            }
            break;
        case READING_BYTES:
            LOGD("Reading bytes...");
            if (peerProxyBufferInput(peerProxy)) {
                LOGD("Bytes read.");
                // We have the complete packet. Notify bytes listener.
                peerProxy->peer->onBytes(peerProxy->credentials,
                    in->data, in->size);
                        
                // Get ready for the next packet.
                peerProxyExpectHeader(peerProxy);
            }
            break;
        case ACCEPTING_CONNECTION:
            masterProxyAcceptConnection(peerProxy);
            break;
        default:
            LOG_ALWAYS_FATAL("Unknown state: %d", state);
    }
}

static PeerProxy* peerProxyCreate(Peer* peer, Credentials credentials) {
    PeerProxy* peerProxy = calloc(1, sizeof(PeerProxy));
    if (peerProxy == NULL) {
        return NULL;
    }
   
    peerProxy->inputBuffer = bufferCreate(sizeof(Header));
    if (peerProxy->inputBuffer == NULL) {
        free(peerProxy);
        return NULL;
    }

    peerProxy->peer = peer;
    peerProxy->credentials = credentials;

    // Initial state == expecting a header.
    peerProxyExpectHeader(peerProxy); 
  
    // Add this proxy to the map. Make sure the key points to the stable memory
    // inside of the peer proxy itself.
    pid_t* pid = &(peerProxy->credentials.pid);
    hashmapPut(peer->peerProxies, pid, peerProxy);
    return peerProxy;
}

/** Accepts a connection to the master peer. */
static void masterAcceptConnection(SelectableFd* listenerFd) {
    // Accept connection.
    int socket = accept(listenerFd->fd, NULL, NULL);
    if (socket == -1) {
        LOGW("accept() error: %s", strerror(errno));
        return;
    }
    
    LOGD("Accepted connection as fd %d.", socket);
    
    // Get credentials.
    Credentials credentials;
    struct ucred ucredentials;
    socklen_t credentialsSize = sizeof(struct ucred);
    int result = getsockopt(socket, SOL_SOCKET, SO_PEERCRED, 
                &ucredentials, &credentialsSize);
    // We might want to verify credentialsSize.
    if (result == -1) {
        LOGW("getsockopt() error: %s", strerror(errno));
        closeWithWarning(socket);
        return;
    }

    // Copy values into our own structure so we know we have the types right.
    credentials.pid = ucredentials.pid;
    credentials.uid = ucredentials.uid;
    credentials.gid = ucredentials.gid;
    
    LOGI("Accepted connection from process %d.", credentials.pid);
   
    Peer* masterPeer = (Peer*) listenerFd->data;
    
    peerLock(masterPeer);
    
    // Make sure we don't already have a connection from that process.
    PeerProxy* peerProxy 
        = hashmapGet(masterPeer->peerProxies, &credentials.pid);
    if (peerProxy != NULL) {
        peerUnlock(masterPeer);
        LOGW("Alread connected to process %d.", credentials.pid);
        closeWithWarning(socket);
        return;
    }
   
    // Add connection to the selector.
    SelectableFd* socketFd = selectorAdd(masterPeer->selector, socket);
    if (socketFd == NULL) {
        peerUnlock(masterPeer);
        LOGW("malloc() failed.");
        closeWithWarning(socket);
        return;
    }

    // Create a peer proxy.
    peerProxy = peerProxyCreate(masterPeer, credentials);
    peerUnlock(masterPeer);
    if (peerProxy == NULL) {
        LOGW("malloc() failed.");
        socketFd->remove = true;
        closeWithWarning(socket);
    }
    peerProxy->connections = hashmapCreate(10, &pidHash, &pidEquals);
    peerProxySetFd(peerProxy, socketFd);
}

/**
 * Creates the local peer.
 */
static Peer* peerCreate() {
    Peer* peer = calloc(1, sizeof(Peer));
    if (peer == NULL) {
        LOG_ALWAYS_FATAL("malloc() error.");
    }
    peer->peerProxies = hashmapCreate(10, &pidHash, &pidEquals);
    peer->selector = selectorCreate();
    
    pthread_mutexattr_t attributes;
    if (pthread_mutexattr_init(&attributes) != 0) {
        LOG_ALWAYS_FATAL("pthread_mutexattr_init() error.");
    }
    if (pthread_mutexattr_settype(&attributes, PTHREAD_MUTEX_RECURSIVE) != 0) {
        LOG_ALWAYS_FATAL("pthread_mutexattr_settype() error.");
    }
    if (pthread_mutex_init(&peer->mutex, &attributes) != 0) {
        LOG_ALWAYS_FATAL("pthread_mutex_init() error.");
    }
    
    peer->pid = getpid();
    return peer;
}

/** The local peer. */
static Peer* localPeer;

/** Frees a packet of bytes. */
static void outgoingPacketFreeBytes(OutgoingPacket* packet) {
    LOGD("Freeing outgoing packet.");
    bufferFree(packet->bytes);
    free(packet);
}

/**
 * Sends a packet of bytes to a remote peer. Returns 0 on success.
 *
 * Returns -1 if an error occurs. Sets errno to ENOMEM if memory couldn't be
 * allocated. Sets errno to EHOSTDOWN if the peer died recently. Sets errno
 * to EINVAL if pid is the same as the local pid.
 */
int peerSendBytes(pid_t pid, const char* bytes, size_t size) {
	Peer* peer = localPeer;
    assert(peer != NULL);

    OutgoingPacket* packet = calloc(1, sizeof(OutgoingPacket));
    if (packet == NULL) {
        errno = ENOMEM;
        return -1;
    }

    Buffer* copy = bufferCreate(size); 
    if (copy == NULL) {
        free(packet);
        errno = ENOMEM;
        return -1;
    }

    // Copy data.
    memcpy(copy->data, bytes, size);
    copy->size = size;
    
    packet->bytes = copy;
    packet->header.type = BYTES;
    packet->header.size = size;
    packet->free = outgoingPacketFreeBytes;
    bufferPrepareForWrite(packet->bytes);
    
    peerLock(peer);
    
    PeerProxy* peerProxy = peerProxyGetOrCreate(peer, pid, true);
    if (peerProxy == NULL) {
        // The peer is already dead or we couldn't alloc memory. Either way,
        // errno is set.
        peerUnlock(peer);
        packet->free(packet); 
        return -1;
    } else {
        peerProxyEnqueueOutgoingPacket(peerProxy, packet);
        peerUnlock(peer);
        selectorWakeUp(peer->selector);
        return 0; 
    }
}

/** Keeps track of how to free shared bytes. */
typedef struct {
    void (*free)(void* context);
    void* context;
} SharedBytesFreer;

/** Frees shared bytes. */
static void outgoingPacketFreeSharedBytes(OutgoingPacket* packet) {
    SharedBytesFreer* sharedBytesFreer 
        = (SharedBytesFreer*) packet->context;
    sharedBytesFreer->free(sharedBytesFreer->context);
    free(sharedBytesFreer);
    free(packet);
}

/**
 * Sends a packet of bytes to a remote peer without copying the bytes. Calls
 * free() with context after the bytes have been sent.
 *
 * Returns -1 if an error occurs. Sets errno to ENOMEM if memory couldn't be
 * allocated. Sets errno to EHOSTDOWN if the peer died recently. Sets errno
 * to EINVAL if pid is the same as the local pid.
 */
int peerSendSharedBytes(pid_t pid, char* bytes, size_t size,
        void (*free)(void* context), void* context) {
    Peer* peer = localPeer;
    assert(peer != NULL);

    OutgoingPacket* packet = calloc(1, sizeof(OutgoingPacket));
    if (packet == NULL) {
        errno = ENOMEM;
        return -1;
    }

    Buffer* wrapper = bufferWrap(bytes, size, size);
    if (wrapper == NULL) {
        free(packet);
        errno = ENOMEM;
        return -1;
    }

    SharedBytesFreer* sharedBytesFreer = malloc(sizeof(SharedBytesFreer));
    if (sharedBytesFreer == NULL) {
        free(packet);
        free(wrapper);
        errno = ENOMEM;
        return -1;
    }
    sharedBytesFreer->free = free;
    sharedBytesFreer->context = context;
    
    packet->bytes = wrapper;
    packet->context = sharedBytesFreer;
    packet->header.type = BYTES;
    packet->header.size = size;
    packet->free = &outgoingPacketFreeSharedBytes;
    bufferPrepareForWrite(packet->bytes);
    
    peerLock(peer);
    
    PeerProxy* peerProxy = peerProxyGetOrCreate(peer, pid, true);
    if (peerProxy == NULL) {
        // The peer is already dead or we couldn't alloc memory. Either way,
        // errno is set.
        peerUnlock(peer);
        packet->free(packet); 
        return -1;
    } else {
        peerProxyEnqueueOutgoingPacket(peerProxy, packet);
        peerUnlock(peer);
        selectorWakeUp(peer->selector);
        return 0; 
    }
}

/**
 * Starts the master peer. The master peer differs from other peers in that
 * it is responsible for connecting the other peers. You can only have one
 * master peer.
 *
 * Goes into an I/O loop and does not return.
 */
void masterPeerInitialize(BytesListener* bytesListener, 
        DeathListener* deathListener) {
    // Create and bind socket.
    int listenerSocket = socket(AF_LOCAL, SOCK_STREAM, 0);
    if (listenerSocket == -1) {
        LOG_ALWAYS_FATAL("socket() error: %s", strerror(errno));
    }
    unlink(MASTER_PATH);
    int result = bind(listenerSocket, (SocketAddress*) getMasterAddress(), 
            sizeof(UnixAddress));
    if (result == -1) {
        LOG_ALWAYS_FATAL("bind() error: %s", strerror(errno));
    }

    LOGD("Listener socket: %d",  listenerSocket);   
    
    // Queue up to 16 connections.
    result = listen(listenerSocket, 16);
    if (result != 0) {
        LOG_ALWAYS_FATAL("listen() error: %s", strerror(errno));
    }

    // Make socket non-blocking.
    setNonBlocking(listenerSocket);

    // Create the peer for this process. Fail if we already have one.
    if (localPeer != NULL) {
        LOG_ALWAYS_FATAL("Peer is already initialized.");
    }
    localPeer = peerCreate();
    if (localPeer == NULL) {
        LOG_ALWAYS_FATAL("malloc() failed.");
    }
    localPeer->master = true;
    localPeer->onBytes = bytesListener;
    localPeer->onDeath = deathListener;
    
    // Make listener socket selectable.
    SelectableFd* listenerFd = selectorAdd(localPeer->selector, listenerSocket);
    if (listenerFd == NULL) {
        LOG_ALWAYS_FATAL("malloc() error.");
    }
    listenerFd->data = localPeer;
    listenerFd->onReadable = &masterAcceptConnection;
}

/**
 * Starts a local peer.
 *
 * Goes into an I/O loop and does not return.
 */
void peerInitialize(BytesListener* bytesListener, 
        DeathListener* deathListener) {
    // Connect to master peer.
    int masterSocket = socket(AF_LOCAL, SOCK_STREAM, 0);
    if (masterSocket == -1) {
        LOG_ALWAYS_FATAL("socket() error: %s", strerror(errno));
    }
    int result = connect(masterSocket, (SocketAddress*) getMasterAddress(),
            sizeof(UnixAddress));
    if (result != 0) {
        LOG_ALWAYS_FATAL("connect() error: %s", strerror(errno));
    }

    // Create the peer for this process. Fail if we already have one.
    if (localPeer != NULL) {
        LOG_ALWAYS_FATAL("Peer is already initialized.");
    }
    localPeer = peerCreate();
    if (localPeer == NULL) {
        LOG_ALWAYS_FATAL("malloc() failed.");
    }
    localPeer->onBytes = bytesListener;
    localPeer->onDeath = deathListener;
    
    // Make connection selectable.
    SelectableFd* masterFd = selectorAdd(localPeer->selector, masterSocket);
    if (masterFd == NULL) {
        LOG_ALWAYS_FATAL("malloc() error.");
    }

    // Create a peer proxy for the master peer.
    PeerProxy* masterProxy = peerProxyCreate(localPeer, MASTER_CREDENTIALS);
    if (masterProxy == NULL) {
        LOG_ALWAYS_FATAL("malloc() error.");
    }
    peerProxySetFd(masterProxy, masterFd);
    masterProxy->master = true;
    localPeer->masterProxy = masterProxy;
}

/** Starts the master peer I/O loop. Doesn't return. */
void peerLoop() {
    assert(localPeer != NULL);
    
    // Start selector.
    selectorLoop(localPeer->selector);
}

