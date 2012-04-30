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
 * Product of NIST/ITL Advanced Networking Technologies Division (ANTD).       *
 ******************************************************************************/

package gov.nist.javax.sip.stack;

import gov.nist.core.Host;
import gov.nist.core.HostPort;
import gov.nist.core.InternalErrorHandler;
import gov.nist.core.ServerLogger;
import gov.nist.javax.sip.address.AddressImpl;
import gov.nist.javax.sip.header.ContentLength;
import gov.nist.javax.sip.header.ContentType;
import gov.nist.javax.sip.header.Via;
import gov.nist.javax.sip.message.MessageFactoryImpl;
import gov.nist.javax.sip.message.SIPMessage;
import gov.nist.javax.sip.message.SIPRequest;
import gov.nist.javax.sip.message.SIPResponse;

import java.io.IOException;
import java.net.InetAddress;
import java.text.ParseException;

import javax.sip.address.Hop;
import javax.sip.header.CSeqHeader;
import javax.sip.header.CallIdHeader;
import javax.sip.header.ContactHeader;
import javax.sip.header.ContentLengthHeader;
import javax.sip.header.ContentTypeHeader;
import javax.sip.header.FromHeader;
import javax.sip.header.ServerHeader;
import javax.sip.header.ToHeader;
import javax.sip.header.ViaHeader;

/**
 * Message channel abstraction for the SIP stack.
 * 
 * @author M. Ranganathan <br/> Contains additions for support of symmetric NAT contributed by
 *         Hagai.
 * 
 * @version 1.2 $Revision: 1.28 $ $Date: 2009/11/14 20:06:18 $
 * 
 * 
 */
public abstract class MessageChannel {

    // Incremented whenever a transaction gets assigned
    // to the message channel and decremented when
    // a transaction gets freed from the message channel.
	protected int useCount;
	
	/**
	 * Hook method, overridden by subclasses
	 */
	protected void uncache() {}
	
    /**
     * Message processor to whom I belong (if set).
     */
    protected transient MessageProcessor messageProcessor;

    /**
     * Close the message channel.
     */
    public abstract void close();

    /**
     * Get the SIPStack object from this message channel.
     * 
     * @return SIPStack object of this message channel
     */
    public abstract SIPTransactionStack getSIPStack();

    /**
     * Get transport string of this message channel.
     * 
     * @return Transport string of this message channel.
     */
    public abstract String getTransport();

    /**
     * Get whether this channel is reliable or not.
     * 
     * @return True if reliable, false if not.
     */
    public abstract boolean isReliable();

    /**
     * Return true if this is a secure channel.
     */
    public abstract boolean isSecure();

    /**
     * Send the message (after it has been formatted)
     * 
     * @param sipMessage Message to send.
     */
    public abstract void sendMessage(SIPMessage sipMessage) throws IOException;

    /**
     * Get the peer address of the machine that sent us this message.
     * 
     * @return a string contianing the ip address or host name of the sender of the message.
     */
    public abstract String getPeerAddress();

    protected abstract InetAddress getPeerInetAddress();

    protected abstract String getPeerProtocol();

    /**
     * Get the sender port ( the port of the other end that sent me the message).
     */
    public abstract int getPeerPort();

    public abstract int getPeerPacketSourcePort();

    public abstract InetAddress getPeerPacketSourceAddress();

    /**
     * Generate a key which identifies the message channel. This allows us to cache the message
     * channel.
     */
    public abstract String getKey();

    /**
     * Get the host to assign for an outgoing Request via header.
     */
    public abstract String getViaHost();

    /**
     * Get the port to assign for the via header of an outgoing message.
     */
    public abstract int getViaPort();

    /**
     * Send the message (after it has been formatted), to a specified address and a specified port
     * 
     * @param message Message to send.
     * @param receiverAddress Address of the receiver.
     * @param receiverPort Port of the receiver.
     */
    protected abstract void sendMessage(byte[] message, InetAddress receiverAddress,
            int receiverPort, boolean reconnectFlag) throws IOException;

    /**
     * Get the host of this message channel.
     * 
     * @return host of this messsage channel.
     */
    public String getHost() {
        return this.getMessageProcessor().getIpAddress().getHostAddress();
    }

    /**
     * Get port of this message channel.
     * 
     * @return Port of this message channel.
     */
    public int getPort() {
        if (this.messageProcessor != null)
            return messageProcessor.getPort();
        else
            return -1;
    }

    /**
     * Send a formatted message to the specified target.
     * 
     * @param sipMessage Message to send.
     * @param hop hop to send it to.
     * @throws IOException If there is an error sending the message
     */
    public void sendMessage(SIPMessage sipMessage, Hop hop) throws IOException {
        long time = System.currentTimeMillis();
        InetAddress hopAddr = InetAddress.getByName(hop.getHost());

        try {

            for (MessageProcessor messageProcessor : getSIPStack().getMessageProcessors()) {
                if (messageProcessor.getIpAddress().equals(hopAddr)
                        && messageProcessor.getPort() == hop.getPort()
                        && messageProcessor.getTransport().equals(hop.getTransport())) {
                    MessageChannel messageChannel = messageProcessor.createMessageChannel(
                            hopAddr, hop.getPort());
                    if (messageChannel instanceof RawMessageChannel) {
                        ((RawMessageChannel) messageChannel).processMessage(sipMessage);
                        if (getSIPStack().isLoggingEnabled())
                        	getSIPStack().getStackLogger().logDebug("Self routing message");
                        return;
                    }

                }
            }
            byte[] msg = sipMessage.encodeAsBytes(this.getTransport());

            this.sendMessage(msg, hopAddr, hop.getPort(), sipMessage instanceof SIPRequest);

        } catch (IOException ioe) {
            throw ioe;
        } catch (Exception ex) {
        	if (this.getSIPStack().getStackLogger().isLoggingEnabled(ServerLogger.TRACE_ERROR)) {
        		this.getSIPStack().getStackLogger().logError("Error self routing message cause by: ", ex);
        	}
        	// TODO: When moving to Java 6, use the IOExcpetion(message, exception) constructor
            throw new IOException("Error self routing message");
        } finally {

            if (this.getSIPStack().getStackLogger().isLoggingEnabled(ServerLogger.TRACE_MESSAGES))
                logMessage(sipMessage, hopAddr, hop.getPort(), time);
        }
    }

    /**
     * Send a message given SIP message.
     * 
     * @param sipMessage is the messge to send.
     * @param receiverAddress is the address to which we want to send
     * @param receiverPort is the port to which we want to send
     */
    public void sendMessage(SIPMessage sipMessage, InetAddress receiverAddress, int receiverPort)
            throws IOException {
        long time = System.currentTimeMillis();
        byte[] bytes = sipMessage.encodeAsBytes(this.getTransport());
        sendMessage(bytes, receiverAddress, receiverPort, sipMessage instanceof SIPRequest);
        logMessage(sipMessage, receiverAddress, receiverPort, time);
    }

    /**
     * Convenience function to get the raw IP source address of a SIP message as a String.
     */
    public String getRawIpSourceAddress() {
        String sourceAddress = getPeerAddress();
        String rawIpSourceAddress = null;
        try {
            InetAddress sourceInetAddress = InetAddress.getByName(sourceAddress);
            rawIpSourceAddress = sourceInetAddress.getHostAddress();
        } catch (Exception ex) {
            InternalErrorHandler.handleException(ex);
        }
        return rawIpSourceAddress;
    }

    /**
     * generate a key given the inet address port and transport.
     */
    public static String getKey(InetAddress inetAddr, int port, String transport) {
        return (transport + ":" + inetAddr.getHostAddress() + ":" + port).toLowerCase();
    }

    /**
     * Generate a key given host and port.
     */
    public static String getKey(HostPort hostPort, String transport) {
        return (transport + ":" + hostPort.getHost().getHostname() + ":" + hostPort.getPort())
                .toLowerCase();
    }

    /**
     * Get the hostport structure of this message channel.
     */
    public HostPort getHostPort() {
        HostPort retval = new HostPort();
        retval.setHost(new Host(this.getHost()));
        retval.setPort(this.getPort());
        return retval;
    }

    /**
     * Get the peer host and port.
     * 
     * @return a HostPort structure for the peer.
     */
    public HostPort getPeerHostPort() {
        HostPort retval = new HostPort();
        retval.setHost(new Host(this.getPeerAddress()));
        retval.setPort(this.getPeerPort());
        return retval;
    }

    /**
     * Get the Via header for this transport. Note that this does not set a branch identifier.
     * 
     * @return a via header for outgoing messages sent from this channel.
     */
    public Via getViaHeader() {
        Via channelViaHeader;

        channelViaHeader = new Via();
        try {
            channelViaHeader.setTransport(getTransport());
        } catch (ParseException ex) {
        }
        channelViaHeader.setSentBy(getHostPort());
        return channelViaHeader;
    }

    /**
     * Get the via header host:port structure. This is extracted from the topmost via header of
     * the request.
     * 
     * @return a host:port structure
     */
    public HostPort getViaHostPort() {
        HostPort retval = new HostPort();
        retval.setHost(new Host(this.getViaHost()));
        retval.setPort(this.getViaPort());
        return retval;
    }

    /**
     * Log a message sent to an address and port via the default interface.
     * 
     * @param sipMessage is the message to log.
     * @param address is the inet address to which the message is sent.
     * @param port is the port to which the message is directed.
     */
    protected void logMessage(SIPMessage sipMessage, InetAddress address, int port, long time) {
        if (!getSIPStack().getStackLogger().isLoggingEnabled(ServerLogger.TRACE_MESSAGES))
            return;

        // Default port.
        if (port == -1)
            port = 5060;
        getSIPStack().serverLogger.logMessage(sipMessage, this.getHost() + ":" + this.getPort(),
                address.getHostAddress().toString() + ":" + port, true, time);
    }

    /**
     * Log a response received at this message channel. This is used for processing incoming
     * responses to a client transaction.
     * 
     * @param receptionTime is the time at which the response was received.
     * @param status is the processing status of the message.
     * 
     */
    public void logResponse(SIPResponse sipResponse, long receptionTime, String status) {
        int peerport = getPeerPort();
        if (peerport == 0 && sipResponse.getContactHeaders() != null) {
            ContactHeader contact = (ContactHeader) sipResponse.getContactHeaders().getFirst();
            peerport = ((AddressImpl) contact.getAddress()).getPort();

        }
        String from = getPeerAddress().toString() + ":" + peerport;
        String to = this.getHost() + ":" + getPort();
        this.getSIPStack().serverLogger.logMessage(sipResponse, from, to, status, false,
                receptionTime);
    }

    /**
     * Creates a response to a bad request (ie one that causes a ParseException)
     * 
     * @param badReq
     * @return message bytes, null if unable to formulate response
     */
    protected final String createBadReqRes(String badReq, ParseException pe) {

        StringBuffer buf = new StringBuffer(512);
        buf.append("SIP/2.0 400 Bad Request (" + pe.getLocalizedMessage() + ')');

        // We need the following headers: all Vias, CSeq, Call-ID, From, To
        if (!copyViaHeaders(badReq, buf))
            return null;
        if (!copyHeader(CSeqHeader.NAME, badReq, buf))
            return null;
        if (!copyHeader(CallIdHeader.NAME, badReq, buf))
            return null;
        if (!copyHeader(FromHeader.NAME, badReq, buf))
            return null;
        if (!copyHeader(ToHeader.NAME, badReq, buf))
            return null;

        // Should add a to-tag if not already present...
        int toStart = buf.indexOf(ToHeader.NAME);
        if (toStart != -1 && buf.indexOf("tag", toStart) == -1) {
            buf.append(";tag=badreq");
        }

        // Let's add a Server header too..
        ServerHeader s = MessageFactoryImpl.getDefaultServerHeader();
        if ( s != null ) {
            buf.append("\r\n" + s.toString());
        }
        int clength = badReq.length();
        if (! (this instanceof UDPMessageChannel) ||
                clength + buf.length() + ContentTypeHeader.NAME.length()
                + ": message/sipfrag\r\n".length() +
                ContentLengthHeader.NAME.length()  < 1300) { 
            
            /*
             * Check to see we are within one UDP packet.
             */
            ContentTypeHeader cth = new ContentType("message", "sipfrag");
            buf.append("\r\n" + cth.toString());
            ContentLength clengthHeader = new ContentLength(clength);
            buf.append("\r\n" + clengthHeader.toString());
            buf.append("\r\n\r\n" + badReq);
        } else {
            ContentLength clengthHeader = new ContentLength(0);
            buf.append("\r\n" + clengthHeader.toString());
        }
        
        return buf.toString();
    }

    /**
     * Copies a header from a request
     * 
     * @param name
     * @param fromReq
     * @param buf
     * @return
     * 
     * Note: some limitations here: does not work for short forms of headers, or continuations;
     * problems when header names appear in other parts of the request
     */
    private static final boolean copyHeader(String name, String fromReq, StringBuffer buf) {
        int start = fromReq.indexOf(name);
        if (start != -1) {
            int end = fromReq.indexOf("\r\n", start);
            if (end != -1) {
                // XX Assumes no continuation here...
                buf.append(fromReq.subSequence(start - 2, end)); // incl CRLF
                // in front
                return true;
            }
        }
        return false;
    }

    /**
     * Copies all via headers from a request
     * 
     * @param fromReq
     * @param buf
     * @return
     * 
     * Note: some limitations here: does not work for short forms of headers, or continuations
     */
    private static final boolean copyViaHeaders(String fromReq, StringBuffer buf) {
        int start = fromReq.indexOf(ViaHeader.NAME);
        boolean found = false;
        while (start != -1) {
            int end = fromReq.indexOf("\r\n", start);
            if (end != -1) {
                // XX Assumes no continuation here...
                buf.append(fromReq.subSequence(start - 2, end)); // incl CRLF
                // in front
                found = true;
                start = fromReq.indexOf(ViaHeader.NAME, end);
            } else {
                return false;
            }
        }
        return found;
    }

    /**
     * Get the message processor.
     */
    public MessageProcessor getMessageProcessor() {
        return this.messageProcessor;
    }
}
