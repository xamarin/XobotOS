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
package gov.nist.javax.sip.stack;

import gov.nist.core.Host;
import gov.nist.core.HostPort;
import gov.nist.core.InternalErrorHandler;
import gov.nist.javax.sip.ListeningPointImpl;
import gov.nist.javax.sip.header.Via;

import java.io.IOException;
import java.net.InetAddress;
import java.text.ParseException;

import javax.sip.InvalidArgumentException;

/**
 * This is the Stack abstraction for the active object that waits for messages
 * to appear on the wire and processes these messages by calling the
 * MessageFactory interface to create a ServerRequest or ServerResponse object.
 * The main job of the message processor is to instantiate message channels for
 * the given transport.
 *
 * @version 1.2 $Revision: 1.18 $ $Date: 2009/10/16 22:58:41 $
 *
 * @author M. Ranganathan <br/>
 *
 */
public abstract class MessageProcessor implements Runnable {
    /**
     * A string containing the 0.0.0.0 IPv4 ANY address.
     */
    protected static final String IN_ADDR_ANY = "0.0.0.0";

    /**
     * A string containing the ::0 IPv6 ANY address.
     */
    protected static final String IN6_ADDR_ANY = "::0";
    /**
     * My Sent by string ( which I use to set the outgoing via header)
     */
    private  String sentBy;

    private HostPort sentByHostPort;

    /*
     * The IP Address that was originally assigned ( Can be ANY )
     */

    private String savedIpAddress;

    /**
     * The IP address where I am listening.
     */
    private InetAddress ipAddress;

    /**
     * The port where I am listening
     */
    private int port;

    /**
     * The transport where I am listening
     */
    protected String transport;

    /**
     * The Listening Point to which I am assigned.
     */
    private ListeningPointImpl listeningPoint;

    private boolean sentBySet;

    /**
     * Our stack (that created us).
     */
    protected SIPTransactionStack sipStack;
    
    protected MessageProcessor( String transport ) {
    	this.transport = transport;
    }
    
    /**
     * Constructor
     *
     * @param ipAddress -- ip address where I am listening for incoming requests.
     * @param port -- port where i am listening for incoming requests.
     * @param transport -- transport to use for the message processor (UDP/TCP/TLS).
     */
    protected MessageProcessor( InetAddress ipAddress, int port, String transport,
    							SIPTransactionStack transactionStack ) {
    	this( transport );
    	this.initialize(ipAddress, port, transactionStack);
    }

    /**
     * Initializes this MessageProcessor. Needed for extensions
     * that use classloading
     * 
     * @param ipAddress2
     * @param transactionStack
     * @param port2
     */
	public final void initialize( InetAddress ipAddress, int port,
			SIPTransactionStack transactionStack ) {
		
		this.sipStack = transactionStack;
        this.savedIpAddress = ipAddress.getHostAddress();
        this.ipAddress = ipAddress;
        this.port = port;
        this.sentByHostPort = new HostPort();
        this.sentByHostPort.setHost(new Host(ipAddress.getHostAddress()));
        this.sentByHostPort.setPort(port);		
	}
    
    /**
     * Get the transport string.
     *
     * @return A string that indicates the transport. (i.e. "tcp" or "udp")
     */
    public String getTransport() {
        return this.transport;
    }

    /**
     * Get the port identifier.
     *
     * @return the port for this message processor. This is where you receive
     *         messages.
     */
    public int getPort() {
        return this.port;
    }

    /**
     * Get the Via header to assign for this message processor. The topmost via
     * header of the outoging messages use this.
     *
     * @return the ViaHeader to be used by the messages sent via this message processor.
     */
    public Via getViaHeader() {
        try {
            Via via = new Via();
            if (this.sentByHostPort != null) {
                via.setSentBy(sentByHostPort);
                via.setTransport(this.getTransport());
            } else {
                Host host = new Host();
                host.setHostname(this.getIpAddress().getHostAddress());
                via.setHost(host);
                via.setPort(this.getPort());
                via.setTransport(this.getTransport());
            }
            return via;
        } catch (ParseException ex) {
            ex.printStackTrace();
            return null;
        } catch (InvalidArgumentException ex) {
            ex.printStackTrace();
            return null;
        }
    }
    public ListeningPointImpl getListeningPoint() {
        if ( listeningPoint == null )  {
            if ( this.getSIPStack().isLoggingEnabled()) {
                this.getSIPStack().getStackLogger().logError("getListeningPoint" + this +
                        " returning null listeningpoint");

            }
        }
        return listeningPoint;
    }

    public void setListeningPoint(ListeningPointImpl lp) {
        if ( this.getSIPStack().isLoggingEnabled()) {
            this.getSIPStack().getStackLogger().logDebug("setListeningPoint" + this +
                    " listeningPoint = " + lp);

        }
        if ( lp.getPort() != this.getPort())
            InternalErrorHandler.handleException
            ("lp mismatch with provider",getSIPStack().getStackLogger());
        this.listeningPoint = lp;

    }

    /**
     * Get the saved IP Address.
     */
    public String getSavedIpAddress() {
        return this.savedIpAddress;
    }
    /**
     * @return the ip address for this message processor.
     */
    public InetAddress getIpAddress() {
          return this.ipAddress;
    }
    /**
     * @param ipAddress the ipAddress to set
     */
    protected void setIpAddress(InetAddress ipAddress) {
        this.sentByHostPort.setHost( new Host(ipAddress.getHostAddress()));
        this.ipAddress = ipAddress;
    }

    /**
     * Set the sentby string. This is used for stamping outgoing messages sent
     * from this listening point.
     *
     * @param sentBy
     */
    public void setSentBy(String sentBy) throws ParseException {

        int ind = sentBy.indexOf(":");
        if (ind == -1) {
            this.sentByHostPort = new HostPort();
            this.sentByHostPort.setHost(new Host(sentBy));
        } else {
            this.sentByHostPort = new HostPort();
            this.sentByHostPort.setHost(new Host(sentBy.substring(0, ind)));
            String portStr = sentBy.substring(ind + 1);
            try {
                int port = Integer.parseInt(portStr);
                this.sentByHostPort.setPort(port);
            } catch (NumberFormatException ex) {
                throw new ParseException("Bad format encountered at ", ind);
            }
        }
        this.sentBySet = true;
        this.sentBy = sentBy;

    }

    /**
     * Get the sentby string.
     *
     */
    public String getSentBy() {
        if ( this.sentBy == null && this.sentByHostPort != null) {
            this.sentBy = this.sentByHostPort.toString();
        }
        return this.sentBy;
    }

    ////////////////////////////////////////////////////////////////////////////////////////
    // Abstract methods
    ///////////////////////////////////////////////////////////////////////////////////////
    /**
     * Get the SIP Stack.
     *
     * @return the sip stack.
     */
    public abstract SIPTransactionStack getSIPStack();

    /**
     * Create a message channel for the specified host/port.
     *
     * @return New MessageChannel for this processor.
     */
    public abstract MessageChannel createMessageChannel(HostPort targetHostPort)
            throws IOException;

    /**
     * Create a message channel for the specified host/port.
     *
     * @return New MessageChannel for this processor.
     */
    public abstract MessageChannel createMessageChannel(InetAddress targetHost,
            int port) throws IOException;


    /**
     * Start our thread.
     */
    public abstract void start() throws IOException;

    /**
     * Stop method.
     */
    public abstract void stop();

    /**
     * Default target port used by this processor. This is 5060 for TCP / UDP
     */
    public abstract int getDefaultTargetPort();

    /**
     * Flags whether this processor is secure or not.
     */
    public abstract boolean isSecure();

    /**
     * Maximum number of bytes that this processor can handle.
     */
    public abstract int getMaximumMessageSize();

    /**
     * Return true if there are pending messages to be processed (which prevents
     * the message channel from being closed).
     */
    public abstract boolean inUse();



    /**
     * Run method.
     */
    public abstract void run();

    /**
     * @return Returns the sentBySet.
     */
    public boolean isSentBySet() {
        return sentBySet;
    }


    /**
     * Get the defalt port for the message processor.
     *
     * @param transport
     * @return -- the default port for the message processor.
     */

    public static int getDefaultPort(String transport) {

        return transport.equalsIgnoreCase("TLS")?5061:5060;
    }



}
