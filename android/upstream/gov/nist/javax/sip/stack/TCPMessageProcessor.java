/*
 * Conditions Of Use 
 * 
 * This software was developed by employees of the National Institute of
 * Standards and Technology (NIST), an agency of the Federal Government.
 * Pursuant to title 15 Untied States Code Section 105, works of NIST
 * employees are not subject to copyright protection in the United States
 * and are considered to be in the public domain.  As a result, a formal
 * license is not needed to use the software.
 * 
 * This software is provided by NIST as a service and is expressly
 * provided "AS IS."  NIST MAKES NO WARRANTY OF ANY KIND, EXPRESS, IMPLIED
 * OR STATUTORY, INCLUDING, WITHOUT LIMITATION, THE IMPLIED WARRANTY OF
 * MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE, NON-INFRINGEMENT
 * AND DATA ACCURACY.  NIST does not warrant or make any representations
 * regarding the use of the software or the results thereof, including but
 * not limited to the correctness, accuracy, reliability or usefulness of
 * the software.
 * 
 * Permission to use this software is contingent upon your acceptance
 * of the terms of this agreement
 *  
 * .
 * 
 */
/******************************************************************************
 * Product of NIST/ITL Advanced Networking Technologies Division (ANTD).      *
 ******************************************************************************/
package gov.nist.javax.sip.stack;

import java.net.Socket;
import java.net.ServerSocket;
import java.io.IOException;
import java.net.SocketException;
import gov.nist.core.*;
import java.net.*;
import java.util.*;

/*
 * Acknowledgement: Jeff Keyser suggested that a Stop mechanism be added to this. Niklas Uhrberg
 * suggested that a means to limit the number of simultaneous active connections should be added.
 * Mike Andrews suggested that the thread be accessible so as to implement clean stop using
 * Thread.join(). Roger M. Persson contributed a bug fix for cleanup on stop().
 * 
 */

/**
 * Sit in a loop waiting for incoming tcp connections and start a new thread to handle each new
 * connection. This is the active object that creates new TCP MessageChannels (one for each new
 * accept socket).
 * 
 * @version 1.2 $Revision: 1.31 $ $Date: 2009/08/31 16:18:00 $
 * 
 * @author M. Ranganathan <br/>
 * 
 * 
 */
public class TCPMessageProcessor extends MessageProcessor {

    protected int nConnections;

    private boolean isRunning;

    private Hashtable tcpMessageChannels;

    private ArrayList<TCPMessageChannel> incomingTcpMessageChannels;

    private ServerSocket sock;

    protected int useCount;

    /**
     * Constructor.
     * 
     * @param sipStack SIPStack structure.
     * @param port port where this message processor listens.
     */
    protected TCPMessageProcessor(InetAddress ipAddress, SIPTransactionStack sipStack, int port) {
        super(ipAddress, port, "tcp",sipStack);

        this.sipStack = sipStack;

        this.tcpMessageChannels = new Hashtable();
        this.incomingTcpMessageChannels = new ArrayList<TCPMessageChannel>();
    }

    /**
     * Start the processor.
     */
    public void start() throws IOException {
        Thread thread = new Thread(this);
        thread.setName("TCPMessageProcessorThread");
        thread.setPriority(Thread.MAX_PRIORITY);
        thread.setDaemon(true);
        this.sock = sipStack.getNetworkLayer().createServerSocket(getPort(), 0, getIpAddress());
        if (getIpAddress().getHostAddress().equals(IN_ADDR_ANY)
                || getIpAddress().getHostAddress().equals(IN6_ADDR_ANY)) {
            // Store the address to which we are actually bound
            super.setIpAddress(sock.getInetAddress());

        }
        this.isRunning = true;
        thread.start();

    }

    /**
     * Run method for the thread that gets created for each accept socket.
     */
    public void run() {
        // Accept new connectins on our socket.
        while (this.isRunning) {
            try {
                synchronized (this) {
                    // sipStack.maxConnections == -1 means we are
                    // willing to handle an "infinite" number of
                    // simultaneous connections (no resource limitation).
                    // This is the default behavior.
                    while (sipStack.maxConnections != -1
                            && this.nConnections >= sipStack.maxConnections) {
                        try {
                            this.wait();

                            if (!this.isRunning)
                                return;
                        } catch (InterruptedException ex) {
                            break;
                        }
                    }
                    this.nConnections++;
                }

                Socket newsock = sock.accept();
                if (sipStack.isLoggingEnabled()) {
                    getSIPStack().getStackLogger().logDebug("Accepting new connection!");
                }
                // Note that for an incoming message channel, the
                // thread is already running
               
                incomingTcpMessageChannels.add(new TCPMessageChannel(newsock, sipStack, this));
            } catch (SocketException ex) {
                this.isRunning = false;
            } catch (IOException ex) {
                // Problem accepting connection.
                if (sipStack.isLoggingEnabled())
                    getSIPStack().getStackLogger().logException(ex);
                continue;
            } catch (Exception ex) {
                InternalErrorHandler.handleException(ex);
            }
        }
    }

    /**
     * Return the transport string.
     * 
     * @return the transport string
     */
    public String getTransport() {
        return "tcp";
    }

    /**
     * Returns the stack.
     * 
     * @return my sip stack.
     */
    public SIPTransactionStack getSIPStack() {
        return sipStack;
    }

    /**
     * Stop the message processor. Feature suggested by Jeff Keyser.
     */
    public synchronized void stop() {
        isRunning = false;
        // this.listeningPoint = null;
        try {
            sock.close();
        } catch (IOException e) {
            e.printStackTrace();
        }

        Collection en = tcpMessageChannels.values();
        for (Iterator it = en.iterator(); it.hasNext();) {
            TCPMessageChannel next = (TCPMessageChannel) it.next();
            next.close();
        }
        // RRPN: fix
        for (Iterator incomingMCIterator = incomingTcpMessageChannels.iterator(); incomingMCIterator
                .hasNext();) {
            TCPMessageChannel next = (TCPMessageChannel) incomingMCIterator.next();
            next.close();
        }

        this.notify();
    }

    protected synchronized void remove(TCPMessageChannel tcpMessageChannel) {

        String key = tcpMessageChannel.getKey();
        if (sipStack.isLoggingEnabled()) {
            sipStack.getStackLogger().logDebug(Thread.currentThread() + " removing " + key);
        }

        /** May have been removed already */
        if (tcpMessageChannels.get(key) == tcpMessageChannel) {
            this.tcpMessageChannels.remove(key);
        }

        incomingTcpMessageChannels.remove(tcpMessageChannel);
    }

    public synchronized MessageChannel createMessageChannel(HostPort targetHostPort)
            throws IOException {
        String key = MessageChannel.getKey(targetHostPort, "TCP");
        if (tcpMessageChannels.get(key) != null) {
            return (TCPMessageChannel) this.tcpMessageChannels.get(key);
        } else {
            TCPMessageChannel retval = new TCPMessageChannel(targetHostPort.getInetAddress(),
                    targetHostPort.getPort(), sipStack, this);
            this.tcpMessageChannels.put(key, retval);
            retval.isCached = true;
            if (sipStack.isLoggingEnabled()) {
                sipStack.getStackLogger().logDebug("key " + key);
                sipStack.getStackLogger().logDebug("Creating " + retval);
            }
            return retval;
        }
    }

    protected synchronized void cacheMessageChannel(TCPMessageChannel messageChannel) {
        String key = messageChannel.getKey();
        TCPMessageChannel currentChannel = (TCPMessageChannel) tcpMessageChannels.get(key);
        if (currentChannel != null) {
            if (sipStack.isLoggingEnabled())
                sipStack.getStackLogger().logDebug("Closing " + key);
            currentChannel.close();
        }
        if (sipStack.isLoggingEnabled())
            sipStack.getStackLogger().logDebug("Caching " + key);
        this.tcpMessageChannels.put(key, messageChannel);

    }

    public synchronized MessageChannel createMessageChannel(InetAddress host, int port)
            throws IOException {
        try {
            String key = MessageChannel.getKey(host, port, "TCP");
            if (tcpMessageChannels.get(key) != null) {
                return (TCPMessageChannel) this.tcpMessageChannels.get(key);
            } else {
                TCPMessageChannel retval = new TCPMessageChannel(host, port, sipStack, this);
                this.tcpMessageChannels.put(key, retval);
                retval.isCached = true;
                if (sipStack.isLoggingEnabled()) {
                    sipStack.getStackLogger().logDebug("key " + key);
                    sipStack.getStackLogger().logDebug("Creating " + retval);
                }
                return retval;
            }
        } catch (UnknownHostException ex) {
            throw new IOException(ex.getMessage());
        }
    }

    /**
     * TCP can handle an unlimited number of bytes.
     */
    public int getMaximumMessageSize() {
        return Integer.MAX_VALUE;
    }

    public boolean inUse() {
        return this.useCount != 0;
    }

    /**
     * Default target port for TCP
     */
    public int getDefaultTargetPort() {
        return 5060;
    }

    /**
     * TCP is not a secure protocol.
     */
    public boolean isSecure() {
        return false;
    }
}
