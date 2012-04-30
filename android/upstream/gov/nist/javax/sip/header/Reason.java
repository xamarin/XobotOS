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
/*
 * Reason.java
 * Reason            =  "Reason" HCOLON reason-value *(COMMA reason-value)
 * reason-value      =  protocol *(SEMI reason-params)
 * protocol          =  "SIP" / "Q.850" / token
 * reason-params     =  protocol-cause / reason-text
 *                     / reason-extension
 * protocol-cause    =  "cause" EQUAL cause
 * cause             =  1*DIGIT
 * reason-text       =  "text" EQUAL quoted-string
 * reason-extension  =  generic-param
 */

package gov.nist.javax.sip.header;

import gov.nist.javax.sip.Utils;

import java.text.ParseException;

/**
 * Definition of the Reason SIP Header.
 *
 * @version 1.2 $Revision: 1.8 $ $Date: 2009/10/18 13:46:34 $
 *
 * @author M. Ranganathan   <br/>
 *
 *
 */
public class Reason
    extends ParametersHeader
    implements javax.sip.header.ReasonHeader {

    /**
     * Comment for <code>serialVersionUID</code>
     */
    private static final long serialVersionUID = -8903376965568297388L;
    public final String TEXT = ParameterNames.TEXT;
    public final String CAUSE = ParameterNames.CAUSE;

    protected String protocol;

    /** Get the cause token.
     *@return the cause code.
     */
    public int getCause() {
        return getParameterAsInt(CAUSE);
    }

    /**
     * Set the cause.
     *
     *@param cause - cause to set.
     */
    public void setCause(int cause) throws javax.sip.InvalidArgumentException {
        this.parameters.set("cause", Integer.valueOf(cause));
    }

    /** Set the protocol
     *
     *@param protocol - protocol to set.
     */

    public void setProtocol(String protocol) throws ParseException {
        this.protocol = protocol;
    }

    /** Return the protocol.
     *
     *@return the protocol.
     */
    public String getProtocol() {
        return this.protocol;
    }

    /** Set the text.
     *
     *@param text -- string text to set.
     */
    public void setText(String text) throws ParseException {
        // JvB: MUST be quoted
        if ( text.charAt(0) != '"' ) {
            text = Utils.getQuotedString(text);
        }
        this.parameters.set("text", text);
    }

    /** Get the text.
     *
     *@return text parameter.
     *
     */
    public String getText() {
        return this.parameters.getParameter("text");
    }

    /** Set the cause.

    /** Creates a new instance of Reason */
    public Reason() {
        super(NAME);
    }

    /** Gets the unique string name of this Header. A name constant is defined in
     * each individual Header identifying each Header.
     *
     * @return the name of this specific Header
     */
    public String getName() {
        return NAME;

    }

    /**
     * Encode the body of this header (the stuff that follows headerName).
     * A.K.A headerValue.
     */
    protected String encodeBody() {
        StringBuffer s = new StringBuffer();
        s.append(protocol);
        if (parameters != null && !parameters.isEmpty())
            s.append(SEMICOLON).append(parameters.encode());
        return s.toString();
    }

}
/*
 * $Log: Reason.java,v $
 * Revision 1.8  2009/10/18 13:46:34  deruelle_jean
 * FindBugs Fixes (Category Performance Warnings)
 *
 * Issue number:
 * Obtained from:
 * Submitted by: Jean Deruelle
 * Reviewed by:
 *
 * Revision 1.7  2009/07/17 18:57:35  emcho
 * Converts indentation tabs to spaces so that we have a uniform indentation policy in the whole project.
 *
 * Revision 1.6  2008/11/19 10:56:27  jbemmel
 * Ensure that reason text is quoted
 *
 * Revision 1.5  2006/11/01 02:22:56  mranga
 * Issue number:  83
 * Obtained from:
 * Submitted by:
 * Reviewed by:   mranga
 * fix thread safety issue in NameValueList and clean up some mess.
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
 * Revision 1.4  2006/07/13 09:01:19  mranga
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
 * Revision 1.3  2006/06/19 06:47:26  mranga
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
