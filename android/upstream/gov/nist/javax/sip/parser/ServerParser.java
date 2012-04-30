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

import gov.nist.javax.sip.header.*;
import java.text.ParseException;

/**
 * Parser for Server header.
 *
 * @version 1.2 $Revision: 1.9 $ $Date: 2009/07/17 18:58:05 $
 *
 * @author Olivier Deruelle   <br/>
 * @author M. Ranganathan   <br/>
 *
 *
 */
public class ServerParser extends HeaderParser {

    /**
     * Creates a new instance of ServerParser
     * @param server the header to parse
     */
    public ServerParser(String server) {
        super(server);
    }

    /**
     * Constructor
     * @param lexer the lexer to use to parse the header
     */
    protected ServerParser(Lexer lexer) {
        super(lexer);
    }

    /**
     * parse the String server
     * @return SIPHeader (Server object)
     * @throws SIPParseException if the message does not respect the spec.
     */
    public SIPHeader parse() throws ParseException {

        if (debug)
            dbg_enter("ServerParser.parse");
        Server server = new Server();
        try {
            headerName(TokenTypes.SERVER);
            if (this.lexer.lookAhead(0) == '\n')
                throw createParseException("empty header");

            //  mandatory token: product[/product-version] | (comment)
            while (this.lexer.lookAhead(0) != '\n'
                && this.lexer.lookAhead(0) != '\0') {
                if (this.lexer.lookAhead(0) == '(') {
                    String comment = this.lexer.comment();
                    server.addProductToken('(' + comment + ')');
                } else {
                    String tok;
                    int marker = 0;
                    try {
                        marker = this.lexer.markInputPosition();
                        tok = this.lexer.getString('/');

                        if (tok.charAt(tok.length() - 1) == '\n')
                            tok = tok.trim();
                        server.addProductToken(tok);
                    } catch (ParseException ex) {
                        this.lexer.rewindInputPosition(marker);
                        tok = this.lexer.getRest().trim();
                        server.addProductToken(tok);
                        break;
                    }
                }
            }

        } finally {
            if (debug)
                dbg_leave("ServerParser.parse");
        }

        return server;
    }

/*
    public static void main(String args[]) throws ParseException {
    String server[] = {
            "Server: Softphone/Beta1.5 \n",
            "Server: HomeServer v2\n",
            "Server: Nist/Beta1 (beta version) \n",
            "Server: Nist proxy (beta version)\n",
            "Server: Nist1.0/Beta2 UbiServer/vers.1.0 (new stuff) (Cool) \n",
        "Server: Sip EXpress router (0.8.11 (sparc64/solaris))\n"
            };

    for (int i = 0; i < server.length; i++ ) {
        ServerParser parser =
          new ServerParser(server[i]);
        Server s= (Server) parser.parse();
        System.out.println("encoded = " + s.encode());
    }

    }
*/

}
/*
 * $Log: ServerParser.java,v $
 * Revision 1.9  2009/07/17 18:58:05  emcho
 * Converts indentation tabs to spaces so that we have a uniform indentation policy in the whole project.
 *
 * Revision 1.8  2006/07/13 09:02:16  mranga
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
 * Revision 1.3  2006/06/17 10:18:14  mranga
 * Added some synchronization to the sequence number checking.
 * Small javadoc fixups
 *
 * Revision 1.2  2006/06/16 15:26:28  mranga
 * Added NIST disclaimer to all public domain files. Clean up some javadoc. Fixed a leak
 *
 * Revision 1.1.1.1  2005/10/04 17:12:36  mranga
 *
 * Import
 *
 *
 * Revision 1.6  2004/01/30 17:10:47  mranga
 * Reviewed by:   mranga
 * Server and user agent parser leave an extra Linefeed at the end of token.
 *
 * Revision 1.5  2004/01/27 13:52:11  mranga
 * Reviewed by:   mranga
 * Fixed server/user-agent parser.
 * suppress sending ack to TU when retransFilter is enabled and ack is retransmitted.
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
