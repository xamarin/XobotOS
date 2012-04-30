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
 * Replaces SIPHeader.
 * ToDo: add support for early-only flag.
 *
 * @author P, Musgrave <pmusgrave@mkcnetworks.com>  <br/>
 *
 * @version JAIN-SIP-1.2
 *
 *
 */

public class Replaces
    extends ParametersHeader implements ExtensionHeader, ReplacesHeader {

    // TODO: Need a unique UID
    private static final long serialVersionUID = 8765762413224043300L;

    // TODO: When the MinSEHeader is added to javax - move this there...pmusgrave
    public static final String NAME = "Replaces";

    /**
     * callIdentifier field
     */
    public CallIdentifier callIdentifier;
    public String callId;

    /**
     * Default constructor
     */
    public Replaces() {
        super(NAME);
    }

    /** Constructor given the call Identifier.
     *@param callId string call identifier (should be localid@host)
     *@throws IllegalArgumentException if call identifier is bad.
     */
    public Replaces(String callId) throws IllegalArgumentException {
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
//          retval.setCallIdentifier( (CallIdentifier) this.callIdentifier.clone() );
//      return retval;
//  }
}
/*
 * $Log: Replaces.java,v $
 * Revision 1.3  2009/07/17 18:57:42  emcho
 * Converts indentation tabs to spaces so that we have a uniform indentation policy in the whole project.
 *
 * Revision 1.2  2006/10/27 20:58:31  mranga
 * Issue number:
 * Obtained from:
 * Submitted by:
 * Reviewed by:   mranga
 * doc fixups
 * CVS: ----------------------------------------------------------------------
 * CVS: Issue number:
 * CVS:   If this change addresses one or more issues,
 * CVS:   then enter the issue number(s) here.
 * CVS: Obtained from:
 * CVS:   If this change has been taken from another system,
 * CVS:   then name the system in this line, otherwise delete it.
 * CVS: Submitted by:
 * CVS:   If this code has been contributed to the project by someone else; i.e.,
 * CVS:   they sent us a patch or a set of diffs, then include their name/email
 * CVS:   address here. If this is your work then delete this line.
 * CVS: Reviewed by:
 * CVS:   If we are doing pre-commit code reviews and someone else has
 * CVS:   reviewed your changes, include their name(s) here.
 * CVS:   If you have not had it reviewed then delete this line.
 *
 * Revision 1.1  2006/10/12 11:57:51  pmusgrave
 * Issue number:  79, 80
 * Submitted by:  pmusgrave@newheights.com
 * Reviewed by:   mranga
 *
 * Revision 1.3  2006/07/19 15:05:20  pmusgrave
 * Modify encodeBody so it uses callId and not CallIdentifier
 *
 * Revision 1.2  2006/04/17 23:41:31  pmusgrave
 * Add Session Timer and Replaces headers
 *
 * Revision 1.1.1.1  2006/03/15 16:00:07  pmusgrave
 * Source with additions
 *
 * Revision 1.3  2005/04/16 20:38:48  dmuresan
 * Canonical clone() implementations for the GenericObject and GenericObjectList hierarchies
 *
 * Revision 1.2  2004/01/22 13:26:29  sverker
 * Issue number:
 * Obtained from:
 * Submitted by:  sverker
 * Reviewed by:   mranga
 *
 * Major reformat of code to conform with style guide. Resolved compiler and javadoc warnings. Added CVS tags.
 *
 * CVS: ----------------------------------------------------------------------
 * CVS: Issue number:
 * CVS:   If this change addresses one or more issues,
 * CVS:   then enter the issue number(s) here.
 * CVS: Obtained from:
 * CVS:   If this change has been taken from another system,
 * CVS:   then name the system in this line, otherwise delete it.
 * CVS: Submitted by:
 * CVS:   If this code has been contributed to the project by someone else; i.e.,
 * CVS:   they sent us a patch or a set of diffs, then include their name/email
 * CVS:   address here. If this is your work then delete this line.
 * CVS: Reviewed by:
 * CVS:   If we are doing pre-commit code reviews and someone else has
 * CVS:   reviewed your changes, include their name(s) here.
 * CVS:   If you have not had it reviewed then delete this line.
 *
 */

