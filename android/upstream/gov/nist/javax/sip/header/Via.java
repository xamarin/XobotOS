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
/*******************************************************************************
* Product of NIST/ITL Advanced Networking Technologies Division (ANTD).        *
*******************************************************************************/
package gov.nist.javax.sip.header;

import gov.nist.core.Host;
import gov.nist.core.HostPort;
import gov.nist.core.NameValue;
import gov.nist.core.NameValueList;
import gov.nist.javax.sip.stack.HopImpl;

import javax.sip.InvalidArgumentException;
import javax.sip.address.Hop;
import javax.sip.header.ViaHeader;
import java.text.ParseException;

/**
 * Via SIPHeader (these are strung together in a ViaList).
 *
 * @see ViaList
 *
 * @version 1.2 $Revision: 1.17 $ $Date: 2009/10/18 13:46:33 $
 *
 * @author M. Ranganathan   <br/>
 *
 *
 *
 */
public class Via
    extends ParametersHeader
    implements javax.sip.header.ViaHeader, ViaHeaderExt {

    /**
     * Comment for <code>serialVersionUID</code>
     */
    private static final long serialVersionUID = 5281728373401351378L;

    /** The branch parameter is included by every forking proxy.
    */
    public static final String BRANCH = ParameterNames.BRANCH;

    /** The "received" parameter is added only for receiver-added Via Fields.
     */
    public static final String RECEIVED = ParameterNames.RECEIVED;

    /** The "maddr" paramter is designating the multicast address.
     */
    public static final String MADDR = ParameterNames.MADDR;

    /** The "TTL" parameter is designating the time-to-live value.
     */
    public static final String TTL = ParameterNames.TTL;

    /** The RPORT parameter.
    */
    public static final String RPORT = ParameterNames.RPORT;

    /** sentProtocol field.
     */
    protected Protocol sentProtocol;

    /** sentBy field.
     */
    protected HostPort sentBy;

    /**
     * comment field
     *
     * JvB note: RFC3261 does not allow a comment to appear in Via headers, and this
     * is not accessible through the API. Suggest removal
     */
    protected String comment;

    private boolean rPortFlag = false;

    /** Default constructor
    */
    public Via() {
        super(NAME);
        sentProtocol = new Protocol();
    }

    public boolean equals(Object other) {

        if (other==this) return true;

        if (other instanceof ViaHeader) {
            final ViaHeader o = (ViaHeader) other;
            return getProtocol().equalsIgnoreCase( o.getProtocol() )
                && getTransport().equalsIgnoreCase( o.getTransport() )
                && getHost().equalsIgnoreCase( o.getHost() )
                && getPort() == o.getPort()
                && equalParameters( o );
        }
        return false;
    }


    /** get the Protocol Version
     * @return String
     */
    public String getProtocolVersion() {
        if (sentProtocol == null)
            return null;
        else
            return sentProtocol.getProtocolVersion();
    }

    /**
     * Accessor for the sentProtocol field.
     * @return Protocol field
     */
    public Protocol getSentProtocol() {

        return sentProtocol;
    }

    /**
     * Accessor for the sentBy field
     *@return SentBy field
     */
    public HostPort getSentBy() {
        return sentBy;
    }

    /**
     * Get the host, port and transport as a Hop. This is
     * useful for the stack to avoid duplication of code.
     *
     */
    public Hop getHop() {
        HopImpl hop = new HopImpl(sentBy.getHost().getHostname(),
                sentBy.getPort(),sentProtocol.getTransport());
        return hop;
    }

    /**
     * Accessor for the parameters field
     * @return parameters field
     */
    public NameValueList getViaParms() {
        return parameters;
    }

    /**
     * Accessor for the comment field.
     * @return comment field.
     * @deprecated RFC 2543 support feature.
     */
    public String getComment() {
        return comment;
    }



    /** port of the Via Header.
     * @return true if Port exists.
     */
    public boolean hasPort() {
        return (getSentBy()).hasPort();
    }

    /** comment of the Via Header.
     *
     * @return false if comment does not exist and true otherwise.
     */
    public boolean hasComment() {
        return comment != null;
    }

    /** remove the port.
     */
    public void removePort() {
        sentBy.removePort();
    }

    /** remove the comment field.
     */
    public void removeComment() {
        comment = null;
    }

    /** set the Protocol Version
     * @param protocolVersion String to set
     */
    public void setProtocolVersion(String protocolVersion) {
        if (sentProtocol == null)
            sentProtocol = new Protocol();
        sentProtocol.setProtocolVersion(protocolVersion);
    }

    /** set the Host of the Via Header
         * @param host String to set
         */
    public void setHost(Host host) {
        if (sentBy == null) {
            sentBy = new HostPort();
        }
        sentBy.setHost(host);
    }

    /**
     * Set the sentProtocol member
     * @param s Protocol to set.
     */
    public void setSentProtocol(Protocol s) {
        sentProtocol = s;
    }

    /**
     * Set the sentBy member
     * @param s HostPort to set.
     */
    public void setSentBy(HostPort s) {
        sentBy = s;
    }

    /**
     * Set the comment member
     * @param c String to set.
     * @deprecated This is an RFC 2543 feature.
     */
    public void setComment(String c) {
        comment = c;
    }

    /** Encode the body of this header (the stuff that follows headerName).
     * A.K.A headerValue.
     */
    protected String encodeBody() {
        return encodeBody(new StringBuffer()).toString();
    }

    protected StringBuffer encodeBody(StringBuffer buffer) {
        sentProtocol.encode(buffer);
        buffer.append(SP);
        sentBy.encode(buffer);
        if (!parameters.isEmpty()) {
            buffer.append(SEMICOLON);
            parameters.encode(buffer);
        }
        if (comment != null) {
            buffer.append(SP).append(LPAREN).append(comment).append(RPAREN);
        }
        if (rPortFlag) buffer.append(";rport");
        return buffer;
    }

    /**
     * Set the host part of this ViaHeader to the newly supplied <code>host</code>
     * parameter.
     *
     * @throws ParseException which signals that an error has been reached
     * unexpectedly while parsing the host value.
     */
    public void setHost(String host) throws ParseException {
        if (sentBy == null)
            sentBy = new HostPort();
        try {
            Host h = new Host(host);
            sentBy.setHost(h);
        } catch (Exception e) {
            throw new NullPointerException(" host parameter is null");
        }
    }

    /**
    * Returns the host part of this ViaHeader.
    *
    * @return  the string value of the host
    */
    public String getHost() {
        if (sentBy == null)
            return null;
        else {
            Host host = sentBy.getHost();
            if (host == null)
                return null;
            else
                return host.getHostname();
        }
    }

    /**
     * Set the port part of this ViaHeader to the newly supplied <code>port</code>
     * parameter.
     *
     * @param port - the Integer.valueOf value of the port of this ViaHeader
     */
    public void setPort(int port) throws InvalidArgumentException {

        if ( port!=-1 && (port<1 || port>65535)) {
            throw new InvalidArgumentException( "Port value out of range -1, [1..65535]" );
        }

        if (sentBy == null)
            sentBy = new HostPort();
        sentBy.setPort(port);
    }

    /**
     * Set the RPort flag parameter
     */
    public void setRPort(){
        rPortFlag = true;
    }

    /**
     * Returns the port part of this ViaHeader.
     *
     * @return the integer value of the port
     */
    public int getPort() {
        if (sentBy == null)
            return -1;
        return sentBy.getPort();
    }


    /**
    * Return the rport parameter.
    *
    *@return the rport parameter or -1.
    */
       public int getRPort() {
         String strRport = getParameter(ParameterNames.RPORT);
         if (strRport != null && ! strRport.equals(""))
            return Integer.valueOf(strRport).intValue();
         else
            return -1;
         }


    /**
     * Returns the value of the transport parameter.
     *
     * @return the string value of the transport paramter of the ViaHeader
     */
    public String getTransport() {
        if (sentProtocol == null)
            return null;
        return sentProtocol.getTransport();
    }

    /**
     * Sets the value of the transport. This parameter specifies
     * which transport protocol to use for sending requests and responses to
     * this entity. The following values are defined: "udp", "tcp", "sctp",
     * "tls", but other values may be used also.
     *
     * @param transport - new value for the transport parameter
     * @throws ParseException which signals that an error has been reached
     * unexpectedly while parsing the transport value.
     */
    public void setTransport(String transport) throws ParseException {
        if (transport == null)
            throw new NullPointerException(
                "JAIN-SIP Exception, "
                    + "Via, setTransport(), the transport parameter is null.");
        if (sentProtocol == null)
            sentProtocol = new Protocol();
        sentProtocol.setTransport(transport);
    }

    /**
     * Returns the value of the protocol used.
     *
     * @return the string value of the protocol paramter of the ViaHeader
     */
    public String getProtocol() {
        if (sentProtocol == null)
            return null;
        return sentProtocol.getProtocol();// JvB: Return name ~and~ version
    }

    /**
     * Sets the value of the protocol parameter. This parameter specifies
     * which protocol is used, for example "SIP/2.0".
     *
     * @param protocol - new value for the protocol parameter
     * @throws ParseException which signals that an error has been reached
     * unexpectedly while parsing the protocol value.
     */
    public void setProtocol(String protocol) throws ParseException {
        if (protocol == null)
            throw new NullPointerException(
                "JAIN-SIP Exception, "
                    + "Via, setProtocol(), the protocol parameter is null.");

        if (sentProtocol == null)
            sentProtocol = new Protocol();

        sentProtocol.setProtocol(protocol);
    }

    /**
     * Returns the value of the ttl parameter, or -1 if this is not set.
     *
     * @return the integer value of the <code>ttl</code> parameter
     */
    public int getTTL() {
        int ttl = getParameterAsInt(ParameterNames.TTL);
        return ttl;
    }

    /**
     * Sets the value of the ttl parameter. The ttl parameter specifies the
     * time-to-live value when packets are sent using UDP multicast.
     *
     * @param ttl - new value of the ttl parameter
     * @throws InvalidArgumentException if supplied value is less than zero or
     * greater than 255, excluding -1 the default not set value.
     */
    public void setTTL(int ttl) throws InvalidArgumentException {
        if (ttl < 0 && ttl != -1)
            throw new InvalidArgumentException(
                "JAIN-SIP Exception"
                    + ", Via, setTTL(), the ttl parameter is < 0");
        setParameter(new NameValue(ParameterNames.TTL, Integer.valueOf(ttl)));
    }

    /**
     * Returns the value of the <code>maddr</code> parameter, or null if this
     * is not set.
     *
     * @return the string value of the maddr parameter
     */
    public String getMAddr() {
        return getParameter(ParameterNames.MADDR);
    }

    /**
     * Sets the value of the <code>maddr</code> parameter of this ViaHeader. The
     * maddr parameter indicates the server address to be contacted for this
     * user, overriding any address derived from the host field.
     *
     * @param  mAddr new value of the <code>maddr</code> parameter
     * @throws ParseException which signals that an error has been reached
     * unexpectedly while parsing the mAddr value.
     */
    public void setMAddr(String mAddr) throws ParseException {
        if (mAddr == null)
            throw new NullPointerException(
                "JAIN-SIP Exception, "
                    + "Via, setMAddr(), the mAddr parameter is null.");

        Host host = new Host();
        host.setAddress(mAddr);
        NameValue nameValue = new NameValue(ParameterNames.MADDR, host);
        setParameter(nameValue);

    }

    /**
     * Gets the received paramater of the ViaHeader. Returns null if received
     * does not exist.
     *
     * @return the string received value of ViaHeader
     */
    public String getReceived() {
        return getParameter(ParameterNames.RECEIVED);
    }

    /**
     * Sets the received parameter of ViaHeader.
     *
     * @param received - the newly supplied received parameter.
     * @throws ParseException which signals that an error has been reached
     * unexpectedly while parsing the received value.
     */
    public void setReceived(String received) throws ParseException {
        if (received == null)
            throw new NullPointerException(
                "JAIN-SIP Exception, "
                    + "Via, setReceived(), the received parameter is null.");

        setParameter(ParameterNames.RECEIVED, received);

    }

    /**
     * Gets the branch paramater of the ViaHeader. Returns null if branch
     * does not exist.
     *
     * @return the string branch value of ViaHeader
     */
    public String getBranch() {
        return getParameter(ParameterNames.BRANCH);
    }

    /**
     * Sets the branch parameter of the ViaHeader to the newly supplied
     * branch value.
     *
     * @param branch - the new string branch parmameter of the ViaHeader.
     * @throws ParseException which signals that an error has been reached
     * unexpectedly while parsing the branch value.
     */
    public void setBranch(String branch) throws ParseException {
        if (branch == null || branch.length()==0)
            throw new NullPointerException(
                "JAIN-SIP Exception, "
                    + "Via, setBranch(), the branch parameter is null or length 0.");

        setParameter(ParameterNames.BRANCH, branch);
    }

    public Object clone() {
        Via retval = (Via) super.clone();
        if (this.sentProtocol != null)
            retval.sentProtocol = (Protocol) this.sentProtocol.clone();
        if (this.sentBy != null)
            retval.sentBy = (HostPort) this.sentBy.clone();
        if ( this.getRPort() != -1)
            retval.setParameter(RPORT,this.getRPort());
        return retval;
    }

    /*
     * (non-Javadoc)
     * @see gov.nist.javax.sip.header.ViaHeaderExt#getSentByField()
     */
    public String getSentByField() {
        if(sentBy != null)
            return sentBy.encode();
        return null;
    }
    /*
     * (non-Javadoc)
     * @see gov.nist.javax.sip.header.ViaHeaderExt#getSentProtocolField()
     */
    public String getSentProtocolField() {
        if(sentProtocol != null)
            return sentProtocol.encode();
        return null;
    }

}
