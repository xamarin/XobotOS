/*******************************************************************************
* Product of NIST/ITL Advanced Networking Technologies Division (ANTD).        *
*******************************************************************************/
package gov.nist.javax.sip.header.extensions;
import java.text.ParseException;
import gov.nist.javax.sip.header.*;

import javax.sip.header.ExtensionHeader;
/*
* This code is in the public domain.
*/

/**
 * Join SIPHeader.
 *
 * @author jean.deruelle@gmail.com  <br/>
 *
 * @version JAIN-SIP-1.2
 *
 *
 */

public class Join
    extends ParametersHeader implements ExtensionHeader, JoinHeader {

    /**
     *
     */
    private static final long serialVersionUID = -840116548918120056L;

    public static final String NAME = "Join";

    /**
     * callIdentifier field
     */
    public CallIdentifier callIdentifier;
    public String callId;

    /**
     * Default constructor
     */
    public Join() {
        super(NAME);
    }

    /** Constructor given the call Identifier.
     *@param callId string call identifier (should be localid@host)
     *@throws IllegalArgumentException if call identifier is bad.
     */
    public Join(String callId) throws IllegalArgumentException {
        super(NAME);
        this.callIdentifier = new CallIdentifier(callId);
    }

    /**
     * Encode the body part of this header (i.e. leave out the hdrName).
     * @return String encoded body part of the header.
     */
    public String encodeBody() {
        if (callId == null)
            return null;
        else {
            String retVal = callId;
            if (!parameters.isEmpty()) {
                retVal += SEMICOLON + parameters.encode();
            }
            return retVal;
        }
    }

    /**
     * get the CallId field. This does the same thing as encodeBody
     *
     * @return String the encoded body part of the
     */
    public String getCallId() {
        return callId;
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
    public void setCallId(String cid) {
        callId = cid;
    }

    /**
     * Set the callIdentifier member.
     * @param cid CallIdentifier to set (localId@host).
     */
    public void setCallIdentifier(CallIdentifier cid) {
        callIdentifier = cid;
    }

    /**
     * Get the to-tag parameter from the address parm list.
     * @return tag field
     */
    public String getToTag() {
        if (parameters == null)
            return null;
        return getParameter(ParameterNames.TO_TAG);
    }
    /**
     * Set the to-tag member
     * @param t tag to set. From tags are mandatory.
     */
    public void setToTag(String t) throws ParseException {
        if (t == null)
            throw new NullPointerException("null tag ");
        else if (t.trim().equals(""))
            throw new ParseException("bad tag", 0);
        this.setParameter(ParameterNames.TO_TAG, t);
    }
    /** Boolean function
     * @return true if the Tag exist
     */
    public boolean hasToTag() {
        return hasParameter(ParameterNames.TO_TAG);
    }

    /** remove Tag member
     */
    public void removeToTag() {
        parameters.delete(ParameterNames.TO_TAG);
    }
    /**
     * Get the from-tag parameter from the address parm list.
     * @return tag field
     */
    public String getFromTag() {
        if (parameters == null)
            return null;
        return getParameter(ParameterNames.FROM_TAG);
    }
    /**
     * Set the to-tag member
     * @param t tag to set. From tags are mandatory.
     */
    public void setFromTag(String t) throws ParseException {
        if (t == null)
            throw new NullPointerException("null tag ");
        else if (t.trim().equals(""))
            throw new ParseException("bad tag", 0);
        this.setParameter(ParameterNames.FROM_TAG, t);
    }
    /** Boolean function
     * @return true if the Tag exist
     */
    public boolean hasFromTag() {
        return hasParameter(ParameterNames.FROM_TAG);
    }

    /** remove Tag member
     */
    public void removeFromTag() {
        parameters.delete(ParameterNames.FROM_TAG);
    }



    public void setValue(String value) throws ParseException {
        // not implemented.
        throw new ParseException(value,0);

    }

//  public Object clone() {
//      CallID retval = (CallID) super.clone();
//      if (this.callIdentifier != null)
//      retval.setCallIdentifier( (CallIdentifier) this.callIdentifier.clone() );
//      return retval;
//  }
}

