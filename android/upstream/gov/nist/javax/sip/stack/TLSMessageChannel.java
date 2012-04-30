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
/* This class is entirely derived from TCPMessageChannel,
 * by making some minor changes. Daniel J. Martinez Manzano <dani@dif.um.es>
 * made these changes. Ahmet Uyar
 * <auyar@csit.fsu.edu>sent in a bug report for TCP operation of the
 * JAIN sipStack. Niklas Uhrberg suggested that a mechanism be added to
 * limit the number of simultaneous open connections. The TLS
 * Adaptations were contributed by Daniel Martinez. Hagai Sela
 * contributed a bug fix for symmetric nat. Jeroen van Bemmel
 * added compensation for buggy clients ( Microsoft RTC clients ).
 * Bug fixes by viswashanti.kadiyala@antepo.com, Joost Yervante Damand
 * Lamine Brahimi (IBM Zurich) sent in a bug fix - a thread was being uncessarily created.
 */

/******************************************************************************
 * Product of NIST/ITL Advanced Networking Technologies Division (ANTD).      *
 ******************************************************************************/
package gov.nist.javax.sip.stack;

import gov.nist.javax.sip.header.*;
import gov.nist.javax.sip.message.*;
import gov.nist.javax.sip.parser.*;
import gov.nist.core.*;
import java.net.*;
import java.io.*;
import java.text.ParseException;

import javax.net.ssl.HandshakeCompletedListener;
import javax.net.ssl.SSLSocket;
import javax.sip.address.Hop;
import javax.sip.message.Response;

/**
 * This is sipStack for TLS connections. This abstracts a stream of parsed messages. The SIP
 * sipStack starts this from the main SIPStack class for each connection that it accepts. It
 * starts a message parser in its own thread and talks to the message parser via a pipe. The
 * message parser calls back via the parseError or processMessage functions that are defined as
 * part of the SIPMessageListener interface.
 *
 * @see gov.nist.javax.sip.parser.PipelinedMsgParser
 *
 *
 * @author M. Ranganathan
 *
 *
 * @version 1.2 $Revision: 1.27 $ $Date: 2010/01/10 00:13:14 $
 */
public final class TLSMessageChannel extends MessageChannel implements SIPMessageListener,
        Runnable, RawMessageChannel {

    private Socket mySock;

    private PipelinedMsgParser myParser;

    private InputStream myClientInputStream; // just to pass to thread.

    private String key;

    protected boolean isCached;

    protected boolean isRunning;

    private Thread mythread;

    private String myAddress;

    private int myPort;

    private InetAddress peerAddress;

    private int peerPort;

    private String peerProtocol;

    // Incremented whenever a transaction gets assigned
    // to the message channel and decremented when
    // a transaction gets freed from the message channel.
    // protected int useCount = 0;

    private TLSMessageProcessor tlsMessageProcessor;

    private SIPTransactionStack sipStack;

    private HandshakeCompletedListener handshakeCompletedListener;

    /**
     * Constructor - gets called from the SIPStack class with a socket on accepting a new client.
     * All the processing of the message is done here with the sipStack being freed up to handle
     * new connections. The sock input is the socket that is returned from the accept. Global data
     * that is shared by all threads is accessible in the Server structure.
     *
     * @param sock Socket from which to read and write messages. The socket is already connected
     *        (was created as a result of an accept).
     *
     * @param sipStack Ptr to SIP Stack
     *
     * @param msgProcessor -- the message processor that created us.
     */

    protected TLSMessageChannel(Socket sock, SIPTransactionStack sipStack,
            TLSMessageProcessor msgProcessor) throws IOException {
        if (sipStack.isLoggingEnabled()) {
            sipStack.getStackLogger().logDebug("creating new TLSMessageChannel (incoming)");
            sipStack.getStackLogger().logStackTrace();
        }

        mySock = (SSLSocket) sock;
        if ( sock instanceof SSLSocket ) {
            
            SSLSocket sslSock = (SSLSocket) sock;
            sslSock.setNeedClientAuth(true);
            this.handshakeCompletedListener = new HandshakeCompletedListenerImpl(this);
            sslSock.addHandshakeCompletedListener(this.handshakeCompletedListener);
            sslSock.startHandshake();
       
        }
        
        peerAddress = mySock.getInetAddress();
        myAddress = msgProcessor.getIpAddress().getHostAddress();
        myClientInputStream = mySock.getInputStream();

        mythread = new Thread(this);
        mythread.setDaemon(true);
        mythread.setName("TLSMessageChannelThread");
        // Stash away a pointer to our sipStack structure.
        this.sipStack = sipStack;

        this.tlsMessageProcessor = msgProcessor;
        this.myPort = this.tlsMessageProcessor.getPort();
        this.peerPort = mySock.getPort();
        // Bug report by Vishwashanti Raj Kadiayl
        super.messageProcessor = msgProcessor;
        // Can drop this after response is sent potentially.
        mythread.start();
    }

    /**
     * Constructor - connects to the given inet address.
     *
     * @param inetAddr inet address to connect to.
     * @param sipStack is the sip sipStack from which we are created.
     * @param messageProcessor -- the message processor that created us.
     * @throws IOException if we cannot connect.
     */
    protected TLSMessageChannel(InetAddress inetAddr, int port, SIPTransactionStack sipStack,
            TLSMessageProcessor messageProcessor) throws IOException {
        if (sipStack.isLoggingEnabled()) {
            sipStack.getStackLogger().logDebug("creating new TLSMessageChannel (outgoing)");
            sipStack.getStackLogger().logStackTrace();
        }
        this.peerAddress = inetAddr;
        this.peerPort = port;
        this.myPort = messageProcessor.getPort();
        this.peerProtocol = "TLS";
        this.sipStack = sipStack;
        this.tlsMessageProcessor = messageProcessor;
        this.myAddress = messageProcessor.getIpAddress().getHostAddress();
        this.key = MessageChannel.getKey(peerAddress, peerPort, "TLS");
        super.messageProcessor = messageProcessor;

    }

    /**
     * Returns "true" as this is a reliable transport.
     */
    public boolean isReliable() {
        return true;
    }

    /**
     * Close the message channel.
     */
    public void close() {
        try {
            if (mySock != null)
                mySock.close();
            if (sipStack.isLoggingEnabled())
                sipStack.getStackLogger().logDebug("Closing message Channel " + this);
        } catch (IOException ex) {
            if (sipStack.isLoggingEnabled())
                sipStack.getStackLogger().logDebug("Error closing socket " + ex);
        }
    }

    /**
     * Get my SIP Stack.
     *
     * @return The SIP Stack for this message channel.
     */
    public SIPTransactionStack getSIPStack() {
        return sipStack;
    }

    /**
     * get the transport string.
     *
     * @return "tcp" in this case.
     */
    public String getTransport() {
        return "tls";
    }

    /**
     * get the address of the client that sent the data to us.
     *
     * @return Address of the client that sent us data that resulted in this channel being
     *         created.
     */
    public String getPeerAddress() {
        if (peerAddress != null) {
            return peerAddress.getHostAddress();
        } else
            return getHost();
    }

    protected InetAddress getPeerInetAddress() {
        return peerAddress;
    }

    public String getPeerProtocol() {
        return this.peerProtocol;
    }

    /**
     * Send message to whoever is connected to us. Uses the topmost via address to send to.
     *
     * @param msg is the message to send.
     * @param retry
     */
    private void sendMessage(byte[] msg, boolean retry) throws IOException {
        Socket sock = this.sipStack.ioHandler.sendBytes(
                this.getMessageProcessor().getIpAddress(), this.peerAddress, this.peerPort,
                this.peerProtocol, msg, retry,this);
        // Created a new socket so close the old one and stick the new
        // one in its place but dont do this if it is a datagram socket.
        // (could have replied via udp but received via tcp!).
        if (sock != mySock && sock != null) {
            try {
                if (mySock != null)
                    mySock.close();
            } catch (IOException ex) {
            }
            mySock = sock;
            this.myClientInputStream = mySock.getInputStream();

            Thread thread = new Thread(this);
            thread.setDaemon(true);
            thread.setName("TLSMessageChannelThread");
            thread.start();
        }

    }

    /**
     * Return a formatted message to the client. We try to re-connect with the peer on the other
     * end if possible.
     *
     * @param sipMessage Message to send.
     * @throws IOException If there is an error sending the message
     */
    public void sendMessage(SIPMessage sipMessage) throws IOException {
        byte[] msg = sipMessage.encodeAsBytes(this.getTransport());

        long time = System.currentTimeMillis();

        this.sendMessage(msg, sipMessage instanceof SIPRequest);

        if (this.sipStack.getStackLogger().isLoggingEnabled(ServerLogger.TRACE_MESSAGES))
            logMessage(sipMessage, peerAddress, peerPort, time);
    }

    /**
     * Send a message to a specified address.
     *
     * @param message Pre-formatted message to send.
     * @param receiverAddress Address to send it to.
     * @param receiverPort Receiver port.
     * @throws IOException If there is a problem connecting or sending.
     */
    public void sendMessage(byte message[], InetAddress receiverAddress, int receiverPort,
            boolean retry) throws IOException {
        if (message == null || receiverAddress == null)
            throw new IllegalArgumentException("Null argument");
        Socket sock = this.sipStack.ioHandler.sendBytes(this.messageProcessor.getIpAddress(),
                receiverAddress, receiverPort, "TLS", message, retry, this);
        //
        // Created a new socket so close the old one and s
        // Check for null (bug fix sent in by Christophe)
        if (sock != mySock && sock != null) {
            try {
                if (mySock != null)
                    mySock.close();
            } catch (IOException ex) {
                /* ignore */
            }
            mySock = sock;
            this.myClientInputStream = mySock.getInputStream();

            // start a new reader on this end of the pipe.
            Thread mythread = new Thread(this);
            mythread.setDaemon(true);
            mythread.setName("TLSMessageChannelThread");
            mythread.start();
        }

    }

    /**
     * Exception processor for exceptions detected from the parser. (This is invoked by the parser
     * when an error is detected).
     *
     * @param sipMessage -- the message that incurred the error.
     * @param ex -- parse exception detected by the parser.
     * @param header -- header that caused the error.
     * @throws ParseException Thrown if we want to reject the message.
     */
    public void handleException(ParseException ex, SIPMessage sipMessage, Class hdrClass,
            String header, String message) throws ParseException {
        if (sipStack.isLoggingEnabled())
            sipStack.getStackLogger().logException(ex);
        // Log the bad message for later reference.
        if ((hdrClass != null)
                && (hdrClass.equals(From.class) || hdrClass.equals(To.class)
                        || hdrClass.equals(CSeq.class) || hdrClass.equals(Via.class)
                        || hdrClass.equals(CallID.class) || hdrClass.equals(RequestLine.class) || hdrClass
                        .equals(StatusLine.class))) {
        	if (sipStack.isLoggingEnabled())
        		sipStack.getStackLogger().logDebug("Encountered bad message \n" + message);
            // JvB: send a 400 response for requests (except ACK)
            String msgString = sipMessage.toString();
            if (!msgString.startsWith("SIP/") && !msgString.startsWith("ACK ")) {

                String badReqRes = createBadReqRes(msgString, ex);
                if (badReqRes != null) {
                    if (sipStack.isLoggingEnabled()) {
                        sipStack.getStackLogger().logDebug("Sending automatic 400 Bad Request:");
                        sipStack.getStackLogger().logDebug(badReqRes);
                    }
                    try {
                        this.sendMessage(badReqRes.getBytes(), this.getPeerInetAddress(), this
                                .getPeerPort(), false);
                    } catch (IOException e) {
                        this.sipStack.getStackLogger().logException(e);
                    }
                } else {
                    if (sipStack.isLoggingEnabled()) {
                        sipStack.getStackLogger().logDebug(
                                "Could not formulate automatic 400 Bad Request");
                    }
                }
            }
            throw ex;
        } else {
            sipMessage.addUnparsed(header);
        }
    }

    /**
     * Gets invoked by the parser as a callback on successful message parsing (i.e. no parser
     * errors).
     *
     * @param sipMessage Message to process (this calls the application for processing the
     *        message).
     *
     * Jvb: note that this code is identical to TCPMessageChannel, refactor some day
     */
    public void processMessage(SIPMessage sipMessage) throws Exception {
        try {
            if (sipMessage.getFrom() == null || sipMessage.getTo() == null
                    || sipMessage.getCallId() == null || sipMessage.getCSeq() == null
                    || sipMessage.getViaHeaders() == null) {
                String badmsg = sipMessage.encode();
                if (sipStack.isLoggingEnabled()) {
                    sipStack.getStackLogger().logError("bad message " + badmsg);
                    sipStack.getStackLogger().logError(">>> Dropped Bad Msg");
                }
                return;
            }

            ViaList viaList = sipMessage.getViaHeaders();
            // For a request
            // first via header tells where the message is coming from.
            // For response, this has already been recorded in the outgoing
            // message.

            if (sipMessage instanceof SIPRequest) {
                Via v = (Via) viaList.getFirst();
                // the peer address and tag it appropriately.
                Hop hop = sipStack.addressResolver.resolveAddress(v.getHop());
                this.peerProtocol = v.getTransport();
                try {
                    this.peerAddress = mySock.getInetAddress();
                    // Check to see if the received parameter matches
                    // JvB: dont do this. It is both costly and incorrect
                    // Must set received also when it is a FQDN, regardless whether
                    // it resolves to the correct IP address
                    // InetAddress sentByAddress = InetAddress.getByName(hop.getHost());
                    // JvB: if sender added 'rport', must always set received
                    if (v.hasParameter(Via.RPORT)
                            || !hop.getHost().equals(this.peerAddress.getHostAddress())) {
                        v.setParameter(Via.RECEIVED, this.peerAddress.getHostAddress());
                    }
                    // @@@ hagai
                    // JvB: technically, may only do this when Via already contains
                    // rport
                    v.setParameter(Via.RPORT, Integer.toString(this.peerPort));
                } catch (java.text.ParseException ex) {
                    InternalErrorHandler.handleException(ex);
                }
                // Use this for outgoing messages as well.
                if (!this.isCached) {
                    ((TLSMessageProcessor) this.messageProcessor).cacheMessageChannel(this);
                    this.isCached = true;
                    String key = IOHandler.makeKey(mySock.getInetAddress(), this.peerPort);
                    sipStack.ioHandler.putSocket(key, mySock);
                }
            }

            // Foreach part of the request header, fetch it and process it

            long receptionTime = System.currentTimeMillis();
            //

            if (sipMessage instanceof SIPRequest) {
                // This is a request - process the request.
                SIPRequest sipRequest = (SIPRequest) sipMessage;
                // Create a new sever side request processor for this
                // message and let it handle the rest.

                if (sipStack.isLoggingEnabled()) {
                    sipStack.getStackLogger().logDebug("----Processing Message---");
                }
                if (this.sipStack.getStackLogger().isLoggingEnabled(ServerLogger.TRACE_MESSAGES)) {

                    sipStack.serverLogger.logMessage(sipMessage, this.getPeerHostPort().toString(),
                            this.messageProcessor.getIpAddress().getHostAddress() + ":"
                                    + this.messageProcessor.getPort(), false, receptionTime);

                }
                // Check for reasonable size - reject message
                // if it is too long.
                if (sipStack.getMaxMessageSize() > 0
                        && sipRequest.getSize()
                                + (sipRequest.getContentLength() == null ? 0 : sipRequest
                                        .getContentLength().getContentLength()) > sipStack
                                .getMaxMessageSize()) {
                    SIPResponse sipResponse = sipRequest
                            .createResponse(SIPResponse.MESSAGE_TOO_LARGE);
                    byte[] resp = sipResponse.encodeAsBytes(this.getTransport());
                    this.sendMessage(resp, false);
                    throw new Exception("Message size exceeded");
                }

                // Stack could not create a new server request interface.
                // maybe not enough resources.
                ServerRequestInterface sipServerRequest = sipStack.newSIPServerRequest(
                        sipRequest, this);
                if (sipServerRequest != null) {
                    try {
                        sipServerRequest.processRequest(sipRequest, this);
                    } finally {
                        if (sipServerRequest instanceof SIPTransaction) {
                            SIPServerTransaction sipServerTx = (SIPServerTransaction) sipServerRequest;
                            if (!sipServerTx.passToListener())
                                ((SIPTransaction) sipServerRequest).releaseSem();
                        }
                    }
                } else {
                    SIPResponse response = sipRequest
                            .createResponse(Response.SERVICE_UNAVAILABLE);

                    RetryAfter retryAfter = new RetryAfter();

                    // Be a good citizen and send a decent response code back.
                    try {
                        retryAfter.setRetryAfter((int) (10 * (Math.random())));
                        response.setHeader(retryAfter);
                        this.sendMessage(response);
                    } catch (Exception e) {
                        // IGNore
                    }
                    if (sipStack.isLoggingEnabled())
                    	sipStack.getStackLogger()
                            .logWarning("Dropping message -- could not acquire semaphore");
                }
            } else {
                SIPResponse sipResponse = (SIPResponse) sipMessage;
                try {
                    sipResponse.checkHeaders();
                } catch (ParseException ex) {
                    if (sipStack.isLoggingEnabled())
                        sipStack.getStackLogger()
                                .logError("Dropping Badly formatted response message >>> "
                                        + sipResponse);
                    return;
                }
                // This is a response message - process it.
                // Check the size of the response.
                // If it is too large dump it silently.
                if (sipStack.getMaxMessageSize() > 0
                        && sipResponse.getSize()
                                + (sipResponse.getContentLength() == null ? 0 : sipResponse
                                        .getContentLength().getContentLength()) > sipStack
                                .getMaxMessageSize()) {
                    if (sipStack.isLoggingEnabled())
                        this.sipStack.getStackLogger().logDebug("Message size exceeded");
                    return;

                }
                ServerResponseInterface sipServerResponse = sipStack.newSIPServerResponse(
                        sipResponse, this);
                if (sipServerResponse != null) {
                    try {
                        if (sipServerResponse instanceof SIPClientTransaction
                                && !((SIPClientTransaction) sipServerResponse)
                                        .checkFromTag(sipResponse)) {
                            if (sipStack.isLoggingEnabled())
                                sipStack.getStackLogger()
                                        .logError("Dropping response message with invalid tag >>> "
                                                + sipResponse);
                            return;
                        }

                        sipServerResponse.processResponse(sipResponse, this);
                    } finally {
                        if (sipServerResponse instanceof SIPTransaction
                                && !((SIPTransaction) sipServerResponse).passToListener()) {
                            // Note that the semaphore is released in event
                            // scanner if the
                            // request is actually processed by the Listener.
                            ((SIPTransaction) sipServerResponse).releaseSem();
                        }
                    }
                } else {
                    sipStack.getStackLogger().logWarning("Could not get semaphore... dropping response");
                }
            }
        } finally {
        }
    }

    /**
     * This gets invoked when thread.start is called from the constructor. Implements a message
     * loop - reading the tcp connection and processing messages until we are done or the other
     * end has closed.
     */
    public void run() {
        Pipeline hispipe = null;
        // Create a pipeline to connect to our message parser.
        hispipe = new Pipeline(myClientInputStream, sipStack.readTimeout,
                ((SIPTransactionStack) sipStack).getTimer());
        // Create a pipelined message parser to read and parse
        // messages that we write out to him.
        myParser = new PipelinedMsgParser(this, hispipe, this.sipStack.getMaxMessageSize());
        // Start running the parser thread.
        myParser.processInput();
        // bug fix by Emmanuel Proulx
        int bufferSize = 4096;
        this.tlsMessageProcessor.useCount++;
        this.isRunning = true;
        try {
            while (true) {
                try {
                    byte[] msg = new byte[bufferSize];
                    int nbytes = myClientInputStream.read(msg, 0, bufferSize);
                    // no more bytes to read...
                    if (nbytes == -1) {
                        hispipe.write("\r\n\r\n".getBytes("UTF-8"));
                        try {
                            if (sipStack.maxConnections != -1) {
                                synchronized (tlsMessageProcessor) {
                                    tlsMessageProcessor.nConnections--;
                                    tlsMessageProcessor.notify();
                                }
                            }
                            hispipe.close();
                            mySock.close();
                        } catch (IOException ioex) {
                        }
                        return;
                    }
                    hispipe.write(msg, 0, nbytes);

                } catch (IOException ex) {
                    // Terminate the message.
                    try {
                        hispipe.write("\r\n\r\n".getBytes("UTF-8"));
                    } catch (Exception e) {
                        // InternalErrorHandler.handleException(e);
                    }

                    try {
                        if (sipStack.isLoggingEnabled())
                            sipStack.getStackLogger().logDebug("IOException  closing sock " + ex);
                        try {
                            if (sipStack.maxConnections != -1) {
                                synchronized (tlsMessageProcessor) {
                                    tlsMessageProcessor.nConnections--;
                                    tlsMessageProcessor.notify();
                                }
                            }
                            mySock.close();
                            hispipe.close();
                        } catch (IOException ioex) {
                        }
                    } catch (Exception ex1) {
                        // Do nothing.
                    }
                    return;
                } catch (Exception ex) {
                    InternalErrorHandler.handleException(ex);
                }
            }
        } finally {
            this.isRunning = false;
            this.tlsMessageProcessor.remove(this);
            this.tlsMessageProcessor.useCount--;
            this.myParser.close();
        }

    }

    protected void uncache() {
    	if (isCached && !isRunning) {    	
    		this.tlsMessageProcessor.remove(this);
    	}
    }

    /**
     * Equals predicate.
     *
     * @param other is the other object to compare ourselves to for equals
     */

    public boolean equals(Object other) {

        if (!this.getClass().equals(other.getClass()))
            return false;
        else {
            TLSMessageChannel that = (TLSMessageChannel) other;
            if (this.mySock != that.mySock)
                return false;
            else
                return true;
        }
    }

    /**
     * Get an identifying key. This key is used to cache the connection and re-use it if
     * necessary.
     */
    public String getKey() {
        if (this.key != null) {
            return this.key;
        } else {
            this.key = MessageChannel.getKey(this.peerAddress, this.peerPort, "TLS");
            return this.key;
        }
    }

    /**
     * Get the host to assign to outgoing messages.
     *
     * @return the host to assign to the via header.
     */
    public String getViaHost() {
        return myAddress;
    }

    /**
     * Get the port for outgoing messages sent from the channel.
     *
     * @return the port to assign to the via header.
     */
    public int getViaPort() {
        return myPort;
    }

    /**
     * Get the port of the peer to whom we are sending messages.
     *
     * @return the peer port.
     */
    public int getPeerPort() {
        return peerPort;
    }

    public int getPeerPacketSourcePort() {
        return this.peerPort;
    }

    public InetAddress getPeerPacketSourceAddress() {
        return this.peerAddress;
    }

    /**
     * TLS Is a secure protocol.
     */
    public boolean isSecure() {
        return true;
    }

    public void setHandshakeCompletedListener(
            HandshakeCompletedListener handshakeCompletedListenerImpl) {
        this.handshakeCompletedListener = handshakeCompletedListenerImpl;
    }

    /**
     * @return the handshakeCompletedListener
     */
    public HandshakeCompletedListenerImpl getHandshakeCompletedListener() {
        return (HandshakeCompletedListenerImpl) handshakeCompletedListener;
    }
}
