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
import javax.sip.header.*;
import java.text.ParseException;
import javax.sip.InvalidArgumentException;

/**
 * the WarningValue SIPObject.
 *
 * @author M. Ranganathan   <br/>
 * @author Olivier Deruelle <br/>
 * @version 1.2 $Revision: 1.8 $ $Date: 2009/10/18 13:46:33 $
 *
 *
 *
 * @see WarningList SIPHeader which strings these together.
 */
public class Warning extends SIPHeader implements WarningHeader {

    /**
     * Comment for <code>serialVersionUID</code>
     */
    private static final long serialVersionUID = -3433328864230783899L;

    /** warn code field, the warn code consists of three digits.
     */
    protected int code;

    /** the name or pseudonym of the server adding
     * the Warning header, for use in debugging
     */
    protected String agent;

    /** warn-text field
     */
    protected String text;

    /**
     * constructor.
     */
    public Warning() {
        super(WARNING);
    }

    /** Encode the body of the header (return the stuff following name:).
     *@return the string encoding of the header value.
     */
    public String encodeBody() {
        return text != null
            ? Integer.toString(code)
                + SP
                + agent
                + SP
                + DOUBLE_QUOTE
                + text
                + DOUBLE_QUOTE
            : Integer.toString(code) + SP + agent;
    }

    /**
    * Gets code of WarningHeader
    * @return code of WarningHeader
    */
    public int getCode() {
        return code;
    }

    /**
    * Gets agent host of WarningHeader
    * @return agent host of WarningHeader
    */
    public String getAgent() {
        return agent;
    }

    /**
    * Gets text of WarningHeader
    * @return text of WarningHeader
    */
    public String getText() {
        return text;
    }

    /**
     * Sets code of WarningHeader
     * @param code int to set
     * @throws SipParseException if code is not accepted by implementation
     */
    public void setCode(int code) throws InvalidArgumentException {
        if (code >99  && code < 1000) { // check this is a 3DIGIT code
            this.code = code;
        } else
            throw new InvalidArgumentException(
                "Code parameter in the Warning header is invalid: code="
                    + code);
    }

    /**
     * Sets host of WarningHeader
     * @param host String to set
     * @throws ParseException if host is not accepted by implementation
     */
    public void setAgent(String host) throws ParseException {
        if (host == null)
            throw new NullPointerException("the host parameter in the Warning header is null");
        else {
            this.agent = host;
        }
    }

    /**
     * Sets text of WarningHeader
     * @param text String to set
     * @throws ParseException if text is not accepted by implementation
     */
    public void setText(String text) throws ParseException {
        if (text == null) {
            throw new ParseException(
                "The text parameter in the Warning header is null",
                0);
        } else
            this.text = text;
    }
}
/*
 * $Log: Warning.java,v $
 * Revision 1.8  2009/10/18 13:46:33  deruelle_jean
 * FindBugs Fixes (Category Performance Warnings)
 *
 * Issue number:
 * Obtained from:
 * Submitted by: Jean Deruelle
 * Reviewed by:
 *
 * Revision 1.7  2009/07/17 18:57:41  emcho
 * Converts indentation tabs to spaces so that we have a uniform indentation policy in the whole project.
 *
 * Revision 1.6  2006/07/13 09:01:44  mranga
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
 * Revision 1.4  2004/04/22 22:51:16  mranga
 * Submitted by:  Thomas Froment
 * Reviewed by:   mranga
 *
 * Fixed corner cases.
 *
 * Revision 1.2  2004/01/22 13:26:30  sverker
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
