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
import java.text.ParseException;
import gov.nist.javax.sip.address.*;
import gov.nist.javax.sip.header.*;
import gov.nist.core.*;

/**
 * To Header parser.
 *
 * @version 1.2 $Revision: 1.11 $ $Date: 2009/10/22 10:27:38 $
 *
 * @author Olivier Deruelle   <br/>
 *
 *
 */
public class ToParser extends AddressParametersParser {

    /**
     * Creates new ToParser
     * @param to String to set
     */
    public ToParser(String to) {
        super(to);
    }

    protected ToParser(Lexer lexer) {
        super(lexer);
    }

    public SIPHeader parse() throws ParseException {

        headerName(TokenTypes.TO);
        To to = new To();
        super.parse(to);
        this.lexer.match('\n');        
        return to;
    }

    /**

        public static void main(String args[]) throws ParseException {
            String to[] = {
               "To: <sip:+1-650-555-2222@ss1.wcom.com;user=phone>;tag=5617\n",
               "To: T. A. Watson <sip:watson@bell-telephone.com;param=something>\n",
               "To: LittleGuy <sip:UserB@there.com;tag=foo>;tag=bar\n",
               "To: sip:mranga@120.6.55.9\n",
               "To: sip:mranga@129.6.55.9;tag=696928473514.129.6.55.9\n",
               "To: sip:mranga@129.6.55.9; tag=696928473514.129.6.55.9\n",
               "To: sip:mranga@129.6.55.9 ;tag=696928473514.129.6.55.9\n",
               "To: sip:mranga@129.6.55.9 ; tag=696928473514.129.6.55.9\n"
            };

            for (int i = 0; i < to.length; i++ ) {
            System.out.println("toParse = " + to[i]);
                ToParser tp =
                new ToParser(to[i]);
                To t = (To) tp.parse();
                System.out.println("encoded = " + t.encode());
            }

        }
    **/
}
/*
 * $Log: ToParser.java,v $
 * Revision 1.11  2009/10/22 10:27:38  jbemmel
 * Fix for issue #230, restructured the code such that parsing for any address appearing without '<' '>'
 * stops at ';', then parameters are assigned to the header as expected
 *
 * Revision 1.10  2009/07/17 18:58:06  emcho
 * Converts indentation tabs to spaces so that we have a uniform indentation policy in the whole project.
 *
 * Revision 1.9  2007/10/23 17:34:55  mranga
 * Issue number:
 * Obtained from:
 * Submitted by:  mranga
 * Reviewed by:   mranga
 *
 * Refactored header collections.
 *
 * Revision 1.8  2006/07/13 09:02:00  mranga
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
 * Revision 1.1.1.1  2005/10/04 17:12:36  mranga
 *
 * Import
 *
 *
 * Revision 1.6  2004/04/22 22:51:18  mranga
 * Submitted by:  Thomas Froment
 * Reviewed by:   mranga
 *
 * Fixed corner cases.
 *
 * Revision 1.5  2004/01/22 13:26:32  sverker
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
