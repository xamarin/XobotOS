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
import gov.nist.core.*;
import java.text.ParseException;
import javax.sip.*;

/**
 * Parser for Warning header.
 *
 * @version 1.2
 *
 * @author Olivier Deruelle
 * @author M. Ranganathan
 *
 *
 *
 * @version 1.0
 */
public class WarningParser extends HeaderParser {

    /**
     * Constructor
     *
     * @param warning -
     *            Warning header to parse
     */
    public WarningParser(String warning) {
        super(warning);
    }

    /**
     * Cosntructor
     *
     * @param lexer -
     *            the lexer to use.
     */
    protected WarningParser(Lexer lexer) {
        super(lexer);
    }

    /**
     * parse the String message
     *
     * @return SIPHeader (WarningList object)
     * @throws SIPParseException
     *             if the message does not respect the spec.
     */
    public SIPHeader parse() throws ParseException {
        WarningList warningList = new WarningList();
        if (debug)
            dbg_enter("WarningParser.parse");

        try {
            headerName(TokenTypes.WARNING);

            while (lexer.lookAhead(0) != '\n') {
                Warning warning = new Warning();
                warning.setHeaderName(SIPHeaderNames.WARNING);

                // Parsing the 3digits code
                this.lexer.match(TokenTypes.ID);
                Token token = lexer.getNextToken();
                try {
                    int code = Integer.parseInt(token.getTokenValue());
                    warning.setCode(code);
                } catch (NumberFormatException ex) {
                    throw createParseException(ex.getMessage());
                } catch (InvalidArgumentException ex) {
                    throw createParseException(ex.getMessage());
                }
                this.lexer.SPorHT();

                // Parsing the agent
                this.lexer.match(TokenTypes.ID);
                token = lexer.getNextToken();
                // Bug reported by zvali@dev.java.net
                if (lexer.lookAhead(0) == ':') {
                    this.lexer.match(':');
                    this.lexer.match(TokenTypes.ID);
                    Token token2 = lexer.getNextToken();
                    warning.setAgent(token.getTokenValue() + ":"
                            + token2.getTokenValue());
                } else {
                    warning.setAgent(token.getTokenValue());
                }

                this.lexer.SPorHT();

                // Parsing the text
                String text = this.lexer.quotedString();
                warning.setText(text);
                this.lexer.SPorHT();

                warningList.add(warning);

                while (lexer.lookAhead(0) == ',') {
                    this.lexer.match(',');
                    this.lexer.SPorHT();

                    warning = new Warning();

                    // Parsing the 3digits code
                    this.lexer.match(TokenTypes.ID);
                    Token tok = lexer.getNextToken();
                    try {
                        int code = Integer.parseInt(tok.getTokenValue());
                        warning.setCode(code);
                    } catch (NumberFormatException ex) {
                        throw createParseException(ex.getMessage());
                    } catch (InvalidArgumentException ex) {
                        throw createParseException(ex.getMessage());
                    }
                    this.lexer.SPorHT();

                    // Parsing the agent
                    this.lexer.match(TokenTypes.ID);
                    tok = lexer.getNextToken();

                    // Bug reported by zvali@dev.java.net

                    if (lexer.lookAhead(0) == ':') {
                        this.lexer.match(':');
                        this.lexer.match(TokenTypes.ID);
                        Token token2 = lexer.getNextToken();
                        warning.setAgent(tok.getTokenValue() + ":"
                                + token2.getTokenValue());
                    } else {
                        warning.setAgent(tok.getTokenValue());
                    }

                    this.lexer.SPorHT();

                    // Parsing the text
                    text = this.lexer.quotedString();
                    warning.setText(text);
                    this.lexer.SPorHT();

                    warningList.add(warning);
                }

            }
        } finally {
            if (debug)
                dbg_leave("WarningParser.parse");
        }

        return warningList;
    }

    /**
     * public static void main(String args[]) throws ParseException { String
     * warning[] = { "Warning: 307 isi.edu \"Session parameter 'foo' not
     * understood\"\n", "Warning: 301 isi.edu \"Incompatible network address
     * type 'E.164'\"\n", "Warning: 312 ii.edu \"Soda\", "+ " 351 i.edu \"I
     * network address 'E.164'\" , 323 ii.edu \"Sodwea\"\n", "Warning: 392
     * 192.168.89.71:5060 \"Noisy feedback tells: pid=936
     * req_src_ip=192.168.89.20 in_uri=sip:xxx@yyyy.org:5061
     * out_uri=sip:xxx@yyyy.org:5061 via_cnt==1\"\n" };
     *
     * for (int i = 0; i < warning.length; i++ ) { WarningParser parser = new
     * WarningParser(warning[i]); WarningList warningList= (WarningList)
     * parser.parse(); System.out.println("encoded = " + warningList.encode()); }
     *  }
     */

}
