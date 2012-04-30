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
package gov.nist.javax.sip;

import java.io.IOException;
import java.net.InetAddress;
import java.text.ParseException;

import javax.sip.*;
import javax.sip.address.SipURI;
import javax.sip.header.ContactHeader;
import javax.sip.header.ViaHeader;

import gov.nist.core.Host;
import gov.nist.core.HostPort;
import gov.nist.core.InternalErrorHandler;
import gov.nist.javax.sip.address.AddressImpl;
import gov.nist.javax.sip.address.SipUri;
import gov.nist.javax.sip.header.Contact;
import gov.nist.javax.sip.header.Via;
import gov.nist.javax.sip.message.SIPRequest;
import gov.nist.javax.sip.stack.*;

/**
 * Implementation of the ListeningPoint interface
 *
 * @version 1.2 $Revision: 1.15 $ $Date: 2009/11/19 05:26:58 $
 *
 * @author M. Ranganathan   <br/>
 *
 *
 *
 */
public class ListeningPointImpl implements javax.sip.ListeningPoint, gov.nist.javax.sip.ListeningPointExt {


    protected String transport;

    /** My port. (same thing as in the message processor) */

    int port;

    /**
     * Pointer to the imbedded mesage processor.
     */
    protected MessageProcessor messageProcessor;

    /**
     * Provider back pointer
     */
    protected SipProviderImpl sipProvider;

    /**
     * Our stack
     */
    protected SipStackImpl sipStack;




    /**
     * Construct a key to refer to this structure from the SIP stack
     * @param host host string
     * @param port port
     * @param transport transport
     * @return a string that is used as a key
     */
    public static String makeKey(String host, int port, String transport) {
        return new StringBuffer(host)
            .append(":")
            .append(port)
            .append("/")
            .append(transport)
            .toString()
            .toLowerCase();
    }

    /**
     * Get the key for this strucut
     * @return  get the host
     */
    protected String getKey() {
        return makeKey(this.getIPAddress(), port, transport);
    }

    /**
     * Set the sip provider for this structure.
     * @param sipProvider provider to set
     */
    protected void setSipProvider(SipProviderImpl sipProviderImpl) {
        this.sipProvider = sipProviderImpl;
    }

    /**
     * Remove the sip provider from this listening point.
     */
    protected void removeSipProvider() {
        this.sipProvider = null;
    }

    /**
     * Constructor
     * @param sipStack Our sip stack
     */
    protected ListeningPointImpl(
        SipStack sipStack,
        int port,
        String transport) {
        this.sipStack = (SipStackImpl) sipStack;

        this.port = port;
        this.transport = transport;

    }

    /**
     * Clone this listening point. Note that a message Processor is not
     * started. The transport is set to null.
     * @return cloned listening point.
     */
    public Object clone() {
        ListeningPointImpl lip =
            new ListeningPointImpl(this.sipStack, this.port, null);
        lip.sipStack = this.sipStack;
        return lip;
    }



    /**
     * Gets the port of the ListeningPoint. The default port of a ListeningPoint
     * is dependent on the scheme and transport.  For example:
     * <ul>
     * <li>The default port is 5060 if the transport UDP the scheme is <i>sip:</i>.
     * <li>The default port is 5060 if the transport is TCP the scheme is <i>sip:</i>.
     * <li>The default port is 5060 if the transport is SCTP the scheme is <i>sip:</i>.
     * <li>The default port is 5061 if the transport is TLS over TCP the scheme is <i>sip:</i>.
     * <li>The default port is 5061 if the transport is TCP the scheme is <i>sips:</i>.
     * </ul>
     *
     * @return port of ListeningPoint
     */
    public int getPort() {
        return messageProcessor.getPort();
    }

    /**
     * Gets transport of the ListeningPoint.
     *
     * @return transport of ListeningPoint
     */
    public String getTransport() {
        return messageProcessor.getTransport();
    }

    /**
     * Get the provider.
     *
     * @return the provider.
     */
    public SipProviderImpl getProvider() {
        return this.sipProvider;
    }

    /* (non-Javadoc)
     * @see javax.sip.ListeningPoint#getIPAddress()
     */
    public String getIPAddress() {

        return this.messageProcessor.getIpAddress().getHostAddress();
    }



    /* (non-Javadoc)
     * @see javax.sip.ListeningPoint#setSentBy(java.lang.String)
     */
    public void setSentBy(String sentBy) throws ParseException {
        this.messageProcessor.setSentBy(sentBy);

    }

    /* (non-Javadoc)
     * @see javax.sip.ListeningPoint#getSentBy()
     */
    public String getSentBy() {

        return this.messageProcessor.getSentBy();
    }

    public boolean isSentBySet() {
        return this.messageProcessor.isSentBySet();
    }
    public Via getViaHeader() {
        return this.messageProcessor.getViaHeader();
     }

    public MessageProcessor getMessageProcessor() {
        return this.messageProcessor;
    }

    public ContactHeader createContactHeader() {
        try {
            String ipAddress = this.getIPAddress();
            int port = this.getPort();
            SipURI sipURI = new SipUri();
            sipURI.setHost(ipAddress);
            sipURI.setPort(port);
            sipURI.setTransportParam(this.transport);
            Contact contact = new Contact();
            AddressImpl address = new AddressImpl();
            address.setURI(sipURI);
            contact.setAddress(address);
            
            return contact;
        } catch (Exception ex) {
            InternalErrorHandler.handleException("Unexpected exception",sipStack.getStackLogger());
            return null;
        }
    }


    public void sendHeartbeat(String ipAddress, int port) throws IOException {

        HostPort targetHostPort  = new HostPort();
        targetHostPort.setHost(new Host( ipAddress));
        targetHostPort.setPort(port);
        MessageChannel messageChannel = this.messageProcessor.createMessageChannel(targetHostPort);
        SIPRequest siprequest = new SIPRequest();
        siprequest.setNullRequest();
        messageChannel.sendMessage(siprequest);

    }

    
    public ViaHeader createViaHeader() {
           return this.getViaHeader();
    }

}
