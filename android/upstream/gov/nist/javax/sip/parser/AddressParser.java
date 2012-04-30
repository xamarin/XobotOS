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

import gov.nist.javax.sip.address.*;
import java.text.ParseException;

/** Parser for addresses.
 *
 * @version 1.2 $Revision: 1.11 $ $Date: 2009/10/22 10:26:27 $
 * @author M. Ranganathan
 *
 *
 */
public class AddressParser extends Parser {

    public AddressParser(Lexer lexer) {
        this.lexer = lexer;
        this.lexer.selectLexer("charLexer");
    }

    public AddressParser(String address) {
        this.lexer = new Lexer("charLexer", address);
    }

    protected AddressImpl nameAddr() throws ParseException {
        if (debug)
            dbg_enter("nameAddr");
        try {
            if (this.lexer.lookAhead(0) == '<') {
                this.lexer.consume(1);
                this.lexer.selectLexer("sip_urlLexer");
                this.lexer.SPorHT();
                URLParser uriParser = new URLParser((Lexer) lexer);
                GenericURI uri = uriParser.uriReference( true );
                AddressImpl retval = new AddressImpl();
                retval.setAddressType(AddressImpl.NAME_ADDR);
                retval.setURI(uri);
                this.lexer.SPorHT();
                this.lexer.match('>');
                return retval;
            } else {
                AddressImpl addr = new AddressImpl();
                addr.setAddressType(AddressImpl.NAME_ADDR);
                String name = null;
                if (this.lexer.lookAhead(0) == '\"') {
                    name = this.lexer.quotedString();
                    this.lexer.SPorHT();
                } else
                    name = this.lexer.getNextToken('<');
                addr.setDisplayName(name.trim());
                this.lexer.match('<');
                this.lexer.SPorHT();
                URLParser uriParser = new URLParser((Lexer) lexer);
                GenericURI uri = uriParser.uriReference( true );
                AddressImpl retval = new AddressImpl();
                addr.setAddressType(AddressImpl.NAME_ADDR);
                addr.setURI(uri);
                this.lexer.SPorHT();
                this.lexer.match('>');
                return addr;
            }
        } finally {
            if (debug)
                dbg_leave("nameAddr");
        }
    }

    public AddressImpl address( boolean inclParams ) throws ParseException {
        if (debug)
            dbg_enter("address");
        AddressImpl retval = null;
        try {
            int k = 0;
            while (lexer.hasMoreChars()) {
                char la = lexer.lookAhead(k);
                if (la == '<'
                    || la == '\"'
                    || la == ':'
                    || la == '/')
                    break;
                else if (la == '\0')
                    throw createParseException("unexpected EOL");
                else
                    k++;
            }
            char la = lexer.lookAhead(k);
            if (la == '<' || la == '\"') {
                retval = nameAddr();
            } else if (la == ':' || la == '/') {
                retval = new AddressImpl();
                URLParser uriParser = new URLParser((Lexer) lexer);
                GenericURI uri = uriParser.uriReference( inclParams );
                retval.setAddressType(AddressImpl.ADDRESS_SPEC);
                retval.setURI(uri);
            } else {
                throw createParseException("Bad address spec");
            }
            return retval;
        } finally {
            if (debug)
                dbg_leave("address");
        }

    }

    /*

    */
}
/*
 * $Log: AddressParser.java,v $
 * Revision 1.11  2009/10/22 10:26:27  jbemmel
 * Fix for issue #230, restructured the code such that parsing for any address appearing without '<' '>'
 * stops at ';', then parameters are assigned to the header as expected
 *
 * Revision 1.10  2009/07/17 18:57:57  emcho
 * Converts indentation tabs to spaces so that we have a uniform indentation policy in the whole project.
 *
 * Revision 1.9  2007/02/12 15:19:26  belangery
 * Changed the encode() and encodeBody() methods of SIP headers and basic classes to make them use the same StringBuffer instance during the encoding phase.
 *
 * Revision 1.8  2007/02/06 16:40:02  belangery
 * Introduced simple code optimizations.
 *
 * Revision 1.7  2006/07/13 09:01:57  mranga
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
 * Revision 1.4  2006/06/19 06:47:27  mranga
 * javadoc fixups
 *
 * Revision 1.3  2006/06/16 15:26:28  mranga
 * Added NIST disclaimer to all public domain files. Clean up some javadoc. Fixed a leak
 *
 * Revision 1.2  2006/03/08 23:32:54  mranga
 * *** empty log message ***
 *
 * Revision 1.1.1.1  2005/10/04 17:12:35  mranga
 *
 * Import
 *
 *
 * Revision 1.5  2004/07/28 14:13:54  mranga
 * Submitted by:  mranga
 *
 * Move out the test code to a separate test/unit class.
 * Fixed some encode methods.
 *
 * Revision 1.4  2004/01/22 13:26:31  sverker
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
