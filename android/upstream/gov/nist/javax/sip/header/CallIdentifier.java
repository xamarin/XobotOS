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

/**
 * The call identifer that goes into a callID header and a in-reply-to header.
 *
 * @author M. Ranganathan   <br/>
 * @version 1.2 $Revision: 1.7 $ $Date: 2009/12/16 02:38:35 $
 * @see CallID
 * @see InReplyTo
 * @since 1.1
 */
public final class CallIdentifier extends SIPObject {

    /**
     * Comment for <code>serialVersionUID</code>
     */
    private static final long serialVersionUID = 7314773655675451377L;

    /**
     * localId field
     */
    protected String localId;

    /**
     * host field
     */
    protected String host;

    /**
     * Default constructor
     */
    public CallIdentifier() {
    }

    /**
     * Constructor
     * @param localId id is the local id.
     * @param host is the host.
     */
    public CallIdentifier(String localId, String host) {
        this.localId = localId;
        this.host = host;
    }

    /**
     * constructor
     * @param cid String to set
     * @throws IllegalArgumentException if cid is null or is not a token,
     * or token@token
     */
    public CallIdentifier(String cid) throws IllegalArgumentException {
        setCallID(cid);
    }

    /**
     * Get the encoded version of this id.
     * @return String to set
     */
    public String encode() {
        return encode(new StringBuffer()).toString();
    }

    public StringBuffer encode(StringBuffer buffer) {
        buffer.append(localId);
        if (host != null) {
            buffer.append(AT).append(host);
        }
        return buffer;
    }

    /**
     * Compare two call identifiers for equality.
     * @param other Object to set
     * @return true if the two call identifiers are equals, false
     * otherwise
     */
    public boolean equals(Object other) {
        if (other == null ) return false;
        if (!other.getClass().equals(this.getClass())) {
            return false;
        }
        CallIdentifier that = (CallIdentifier) other;
        if (this.localId.compareTo(that.localId) != 0) {
            return false;
        }
        if (this.host == that.host)
            return true;
        if ((this.host == null && that.host != null)
            || (this.host != null && that.host == null))
            return false;
        if (host.compareToIgnoreCase(that.host) != 0) {
            return false;
        }
        return true;
    }
    
    @Override
    public int hashCode() {
        if (this.localId  == null ) {
             throw new UnsupportedOperationException("Hash code called before id is set");
        }
        return this.localId.hashCode();
    }

    /** get the LocalId field
     * @return String
     */
    public String getLocalId() {
        return localId;
    }

    /** get the host field
     * @return host member String
     */
    public String getHost() {
        return host;
    }

    /**
     * Set the localId member
     * @param localId String to set
     */
    public void setLocalId(String localId) {
        this.localId = localId;
    }

    /** set the callId field
     * @param cid Strimg to set
     * @throws IllegalArgumentException if cid is null or is not a token or
     * token@token
     */
    public void setCallID(String cid) throws IllegalArgumentException {
        if (cid == null)
            throw new IllegalArgumentException("NULL!");
        int index = cid.indexOf('@');
        if (index == -1) {
            localId = cid;
            host = null;
        } else {
            localId = cid.substring(0, index);
            host = cid.substring(index + 1, cid.length());
            if (localId == null || host == null) {
                throw new IllegalArgumentException("CallID  must be token@token or token");
            }
        }
    }

    /**
     * Set the host member
     * @param host String to set
     */
    public void setHost(String host) {
        this.host = host;
    }
}
