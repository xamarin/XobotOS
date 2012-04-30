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
 * Product of NIST/ITL Advanced Networking Technologies Division (ANTD).       *
 *******************************************************************************/
package gov.nist.javax.sip.header;

import gov.nist.javax.sip.SIPConstants;

/**
 * Status Line (for SIPReply) messages.
 *
 * @version 1.2 $Revision: 1.7 $ $Date: 2009/10/18 13:46:34 $
 *
 * @author M. Ranganathan   <br/>
 *
 *
 */
public final class StatusLine extends SIPObject implements SipStatusLine {

    /**
     * Comment for <code>serialVersionUID</code>
     */
    private static final long serialVersionUID = -4738092215519950414L;

    protected boolean matchStatusClass;

    /** sipVersion field
     */
    protected String sipVersion;

    /** status code field
     */
    protected int statusCode;

    /** reasonPhrase field
     */
    protected String reasonPhrase;

    /** Match with a template.
     * Match only the response class if the last two digits of the
     * match templates are 0's
     */

    public boolean match(Object matchObj) {
        if (!(matchObj instanceof StatusLine))
            return false;
        StatusLine sl = (StatusLine) matchObj;
        // A pattern matcher has been registered.
        if (sl.matchExpression != null)
            return sl.matchExpression.match(this.encode());
        // no patter matcher has been registered..
        if (sl.sipVersion != null && !sl.sipVersion.equals(sipVersion))
            return false;
        if (sl.statusCode != 0) {
            if (matchStatusClass) {
                int hiscode = sl.statusCode;
                String codeString = Integer.toString(sl.statusCode);
                String mycode = Integer.toString(statusCode);
                if (codeString.charAt(0) != mycode.charAt(0))
                    return false;
            } else {
                if (statusCode != sl.statusCode)
                    return false;
            }
        }
        if (sl.reasonPhrase == null || reasonPhrase == sl.reasonPhrase)
            return true;
        return reasonPhrase.equals(sl.reasonPhrase);

    }

    /** set the flag on a match template.
     *If this set to true, then the whole status code is matched (default
     * behavior) else only the class of the response is matched.
     */
    public void setMatchStatusClass(boolean flag) {
        matchStatusClass = flag;
    }

    /** Default Constructor
     */
    public StatusLine() {
        reasonPhrase = null;
        sipVersion = SIPConstants.SIP_VERSION_STRING;
    }

    /**
     * Encode into a canonical form.
     * @return String
     */
    public String encode() {
        String encoding = SIPConstants.SIP_VERSION_STRING + SP + statusCode;
        if (reasonPhrase != null)
            encoding += SP + reasonPhrase;
        encoding += NEWLINE;
        return encoding;
    }

    /* (non-Javadoc)
     * @see gov.nist.javax.sip.header.SipStatusLine#getSipVersion()
     */
    public String getSipVersion() {
        return sipVersion;
    }

    /* (non-Javadoc)
     * @see gov.nist.javax.sip.header.SipStatusLine#getStatusCode()
     */
    public int getStatusCode() {
        return statusCode;
    }

    /* (non-Javadoc)
     * @see gov.nist.javax.sip.header.SipStatusLine#getReasonPhrase()
     */
    public String getReasonPhrase() {
        return reasonPhrase;
    }

    /* (non-Javadoc)
     * @see gov.nist.javax.sip.header.SipStatusLine#setSipVersion(java.lang.String)
     */
    public void setSipVersion(String s) {
        sipVersion = s;
    }

    /* (non-Javadoc)
     * @see gov.nist.javax.sip.header.SipStatusLine#setStatusCode(int)
     */
    public void setStatusCode(int statusCode) {
        this.statusCode = statusCode;
    }

    /* (non-Javadoc)
     * @see gov.nist.javax.sip.header.SipStatusLine#setReasonPhrase(java.lang.String)
     */
    public void setReasonPhrase(String reasonPhrase) {
        this.reasonPhrase = reasonPhrase;
    }

    /* (non-Javadoc)
     * @see gov.nist.javax.sip.header.SipStatusLine#getVersionMajor()
     */
    public String getVersionMajor() {
        if (sipVersion == null)
            return null;
        String major = null;
        boolean slash = false;
        for (int i = 0; i < sipVersion.length(); i++) {
            if (sipVersion.charAt(i) == '.')
                slash = false;
            if (slash) {
                if (major == null)
                    major = "" + sipVersion.charAt(i);
                else
                    major += sipVersion.charAt(i);
            }
            if (sipVersion.charAt(i) == '/')
                slash = true;
        }
        return major;
    }

    /* (non-Javadoc)
     * @see gov.nist.javax.sip.header.SipStatusLine#getVersionMinor()
     */
    public String getVersionMinor() {
        if (sipVersion == null)
            return null;
        String minor = null;
        boolean dot = false;
        for (int i = 0; i < sipVersion.length(); i++) {
            if (dot) {
                if (minor == null)
                    minor = "" + sipVersion.charAt(i);
                else
                    minor += sipVersion.charAt(i);
            }
            if (sipVersion.charAt(i) == '.')
                dot = true;
        }
        return minor;
    }
}
/*
 * $Log: StatusLine.java,v $
 * Revision 1.7  2009/10/18 13:46:34  deruelle_jean
 * FindBugs Fixes (Category Performance Warnings)
 *
 * Issue number:
 * Obtained from:
 * Submitted by: Jean Deruelle
 * Reviewed by:
 *
 * Revision 1.6  2009/09/15 02:55:26  mranga
 * Issue number:  222
 * Add HeaderFactoryExt.createStatusLine(String) and HeaderFactoryExt.createRequestLine(String)
 * Allows users to easily parse SipFrag bodies (for example NOTIFY bodies
 * during call transfer).
 *
 * Revision 1.5  2009/07/17 18:57:38  emcho
 * Converts indentation tabs to spaces so that we have a uniform indentation policy in the whole project.
 *
 * Revision 1.4  2006/07/13 09:01:48  mranga
 * Issue number:
 * Obtained from:
 * Submitted by:  jeroen van bemmel
 * Reviewed by:   mranga
 * Moved some changes from jain-sip-1.2 to java.net
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
 * Revision 1.3  2006/06/19 06:47:27  mranga
 * javadoc fixups
 *
 * Revision 1.2  2006/06/16 15:26:28  mranga
 * Added NIST disclaimer to all public domain files. Clean up some javadoc. Fixed a leak
 *
 * Revision 1.1.1.1  2005/10/04 17:12:35  mranga
 *
 * Import
 *
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
