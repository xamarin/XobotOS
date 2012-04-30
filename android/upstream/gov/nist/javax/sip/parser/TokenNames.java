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
package gov.nist.javax.sip.parser;
import javax.sip.message.Request;
import gov.nist.javax.sip.address.*;
import gov.nist.javax.sip.header.*;

/**
 * A grab bag of SIP Token names.
 *
 * @version 1.2 $Revision: 1.10 $ $Date: 2009/07/27 20:35:02 $
 *
 * @author M. Ranganathan   <br/>
 *
 *
 */
public interface TokenNames
    extends
        gov.nist.javax.sip.header.ParameterNames,
        gov.nist.javax.sip.address.ParameterNames {
    // And now dreaded short forms....
    public static final String INVITE = Request.INVITE;
    public static final String ACK = Request.ACK;
    public static final String BYE = Request.BYE;
    public static final String SUBSCRIBE = Request.SUBSCRIBE;
    public static final String NOTIFY = Request.NOTIFY;
    public static final String OPTIONS = Request.OPTIONS;
    public static final String REGISTER = Request.REGISTER;
    public static final String MESSAGE = Request.MESSAGE;
    public static final String PUBLISH = Request.PUBLISH;

    public static final String SIP = GenericURI.SIP;
    public static final String SIPS = GenericURI.SIPS;
    public static final String TEL = GenericURI.TEL;
    public static final String GMT = SIPDate.GMT;
    public static final String MON = SIPDate.MON;
    public static final String TUE = SIPDate.TUE;
    public static final String WED = SIPDate.WED;
    public static final String THU = SIPDate.THU;
    public static final String FRI = SIPDate.FRI;
    public static final String SAT = SIPDate.SAT;
    public static final String SUN = SIPDate.SUN;
    public static final String JAN = SIPDate.JAN;
    public static final String FEB = SIPDate.FEB;
    public static final String MAR = SIPDate.MAR;
    public static final String APR = SIPDate.APR;
    public static final String MAY = SIPDate.MAY;
    public static final String JUN = SIPDate.JUN;
    public static final String JUL = SIPDate.JUL;
    public static final String AUG = SIPDate.AUG;
    public static final String SEP = SIPDate.SEP;
    public static final String OCT = SIPDate.OCT;
    public static final String NOV = SIPDate.NOV;
    public static final String DEC = SIPDate.DEC;
    public static final String K = "K";
    public static final String C = "C";
    public static final String E = "E";
    public static final String F = "F";
    public static final String I = "I";
    public static final String M = "M";
    public static final String L = "L";
    public static final String S = "S";
    public static final String T = "T";
    public static final String U = "U";// JvB: added
    public static final String V = "V";
    public static final String R = "R";
    public static final String O = "O";
    public static final String X = "X"; //Jozef Saniga added
}
/*
 * $Log: TokenNames.java,v $
 * Revision 1.10  2009/07/27 20:35:02  deruelle_jean
 * Fix for the compact form of SessionExpires Header from RFC 4028
 *
 * Issue number:
 * Obtained from: Jozef Saniga
 * Submitted by:  Jean Deruelle
 * Reviewed by:
 *
 * Revision 1.9  2009/07/17 18:58:06  emcho
 * Converts indentation tabs to spaces so that we have a uniform indentation policy in the whole project.
 *
 * Revision 1.8  2006/07/13 09:02:13  mranga
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
 * Revision 1.5  2006/06/19 06:47:27  mranga
 * javadoc fixups
 *
 * Revision 1.4  2006/06/16 15:26:28  mranga
 * Added NIST disclaimer to all public domain files. Clean up some javadoc. Fixed a leak
 *
 * Revision 1.3  2005/10/27 20:49:00  jeroen
 * added support for RFC3903 PUBLISH
 *
 * Revision 1.2  2005/10/08 23:13:56  jeroen
 * added short form for Allow-Events
 *
 * Revision 1.1.1.1  2005/10/04 17:12:36  mranga
 *
 * Import
 *
 *
 * Revision 1.5  2005/04/27 14:12:05  mranga
 * Submitted by:  Mario Mantak
 * Reviewed by:   mranga
 *
 * Added a missing "short form" for event header.
 *
 * Revision 1.4  2004/01/22 13:26:32  sverker
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
