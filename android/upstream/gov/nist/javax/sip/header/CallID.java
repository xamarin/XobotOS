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
import javax.sip.header.CallIdHeader;
import java.text.ParseException;

/**
 * Call ID SIPHeader.
 *
 * @author M. Ranganathan   <br/>
 * @version 1.2 $Revision: 1.7 $ $Date: 2009/07/17 18:57:27 $
 * @since 1.1
 */
public class CallID
    extends SIPHeader
    implements javax.sip.header.CallIdHeader {

    /**
     * Comment for <code>serialVersionUID</code>
     */
    private static final long serialVersionUID = -6463630258703731156L;
    /**
     * callIdentifier field
     */
    protected CallIdentifier callIdentifier;

    /**
     * Default constructor
     */
    public CallID() {
        super(NAME);
    }

    /* (non-Javadoc)
     * @see java.lang.Object#equals(java.lang.Object)
     *
     * CallIDs are compared case-insensitively
     */
    public boolean equals( Object other ) {

        if (this==other) return true;

        if (other instanceof CallIdHeader) {
            final CallIdHeader o = (CallIdHeader) other;
            return this.getCallId().equalsIgnoreCase( o.getCallId() );
        }
        return false;
    }


    /**
     * Encode the body part of this header (i.e. leave out the hdrName).
     *@return String encoded body part of the header.
     */
    public String encodeBody() {
        return encodeBody(new StringBuffer()).toString();
    }

    protected StringBuffer encodeBody(StringBuffer buffer) {
        if (callIdentifier != null)
            callIdentifier.encode(buffer);

        return buffer;
    }

    /**
     * get the CallId field. This does the same thing as
     * encodeBody
     * @return String the encoded body part of the
     */
    public String getCallId() {
        return encodeBody();
    }

    /**
     * get the call Identifer member.
     * @return CallIdentifier
     */
    public CallIdentifier getCallIdentifer() {
        return callIdentifier;
    }

    /**
     * set the CallId field
     * @param cid String to set. This is the body part of the Call-Id
     *  header. It must have the form localId@host or localId.
     * @throws IllegalArgumentException if cid is null, not a token, or is
     * not a token@token.
     */
    public void setCallId(String cid) throws ParseException {
        try {
            callIdentifier = new CallIdentifier(cid);
        } catch (IllegalArgumentException ex) {
            throw new ParseException(cid, 0);
        }
    }

    /**
     * Set the callIdentifier member.
     * @param cid CallIdentifier to set (localId@host).
     */
    public void setCallIdentifier(CallIdentifier cid) {
        callIdentifier = cid;
    }

    /** Constructor given the call Identifier.
     *@param callId string call identifier (should be localid@host)
     *@throws IllegalArgumentException if call identifier is bad.
     */
    public CallID(String callId) throws IllegalArgumentException {
        super(NAME);
        this.callIdentifier = new CallIdentifier(callId);
    }

    public Object clone() {
        CallID retval = (CallID) super.clone();
        if (this.callIdentifier != null)
            retval.callIdentifier = (CallIdentifier) this.callIdentifier.clone();
        return retval;
    }
}
