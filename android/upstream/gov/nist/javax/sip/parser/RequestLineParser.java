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
import gov.nist.javax.sip.header.*;

/**
 * Parser for the SIP request line.
 *
 * @version 1.2
 *
 * @author M. Ranganathan   <br/>
 *
 *
 */
public class RequestLineParser extends Parser {
    public RequestLineParser(String requestLine) {
        this.lexer = new Lexer("method_keywordLexer", requestLine);
    }
    public RequestLineParser(Lexer lexer) {
        this.lexer = lexer;
        this.lexer.selectLexer("method_keywordLexer");
    }

    public RequestLine parse() throws ParseException {
        if (debug)
            dbg_enter("parse");
        try {
            RequestLine retval = new RequestLine();
            String m = method();
            lexer.SPorHT();
            retval.setMethod(m);
            this.lexer.selectLexer("sip_urlLexer");
            URLParser urlParser = new URLParser(this.getLexer());
            GenericURI url = urlParser.uriReference(true);
            lexer.SPorHT();
            retval.setUri(url);
            this.lexer.selectLexer("request_lineLexer");
            String v = sipVersion();
            retval.setSipVersion(v);
            lexer.SPorHT();
            lexer.match('\n');
            return retval;
        } finally {
            if (debug)
                dbg_leave("parse");
        }
    }

            public static void main(String args[]) throws ParseException {
            String requestLines[] = {
                "REGISTER sip:192.168.0.68 SIP/2.0\n",
                "REGISTER sip:company.com SIP/2.0\n",
                "INVITE sip:3660@166.35.231.140 SIP/2.0\n",
                "INVITE sip:user@company.com SIP/2.0\n",
                "REGISTER sip:[2001::1]:5060;transport=tcp SIP/2.0\n", // Added by Daniel J. Martinez Manzano <dani@dif.um.es>
                "REGISTER sip:[2002:800:700:600:30:4:6:1]:5060;transport=udp SIP/2.0\n", // Added by Daniel J. Martinez Manzano <dani@dif.um.es>
                "REGISTER sip:[3ffe:800:700::30:4:6:1]:5060;transport=tls SIP/2.0\n", // Added by Daniel J. Martinez Manzano <dani@dif.um.es>
                "REGISTER sip:[2001:720:1710:0:201:29ff:fe21:f403]:5060;transport=udp SIP/2.0\n",
                "OPTIONS sip:135.180.130.133 SIP/2.0\n" };
            for (int i = 0; i < requestLines.length; i++ ) {
                RequestLineParser rlp =
                  new RequestLineParser(requestLines[i]);
                RequestLine rl = rlp.parse();
                System.out.println("encoded = " + rl.encode());
            }

        }

}
/*
 * $Log: RequestLineParser.java,v $
 * Revision 1.11  2009/10/22 10:27:38  jbemmel
 * Fix for issue #230, restructured the code such that parsing for any address appearing without '<' '>'
 * stops at ';', then parameters are assigned to the header as expected
 *
 * Revision 1.10  2009/09/15 02:55:27  mranga
 * Issue number:  222
 * Add HeaderFactoryExt.createStatusLine(String) and HeaderFactoryExt.createRequestLine(String)
 * Allows users to easily parse SipFrag bodies (for example NOTIFY bodies
 * during call transfer).
 *
 * Revision 1.9  2009/07/17 18:58:03  emcho
 * Converts indentation tabs to spaces so that we have a uniform indentation policy in the whole project.
 *
 * Revision 1.8  2006/07/13 09:02:14  mranga
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
 * Revision 1.6  2004/10/28 19:02:50  mranga
 * Submitted by:  Daniel Martinez
 * Reviewed by:   M. Ranganathan
 *
 * Added changes for TLS support contributed by Daniel Martinez
 *
 * Revision 1.5  2004/06/27 00:41:51  mranga
 * Submitted by:  Thomas Froment and Pierre De Rop
 * Reviewed by:   mranga
 * Performance improvements
 * (auxiliary data structure for fast lookup of transactions).
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
