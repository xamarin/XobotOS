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
/*******************************************
 * PRODUCT OF PT INOVACAO - EST DEPARTMENT *
 *******************************************/

package gov.nist.javax.sip.parser.ims;

import gov.nist.core.Token;
import gov.nist.javax.sip.header.SIPHeader;
import gov.nist.javax.sip.header.ims.PVisitedNetworkID;
import gov.nist.javax.sip.header.ims.PVisitedNetworkIDList;
import gov.nist.javax.sip.parser.Lexer;
import gov.nist.javax.sip.parser.ParametersParser;
import gov.nist.javax.sip.parser.TokenTypes;

import java.text.ParseException;

/**
 * P-Visited-Network-ID header parser.
 *
 * <pre>
 * P-Visited-Network-ID   = "P-Visited-Network-ID" HCOLON
 *                          vnetwork-spec
 *                          *(COMMA vnetwork-spec)
 * vnetwork-spec          = (token / quoted-string)
 *                          *(SEMI vnetwork-param)
 * vnetwork-param         = generic-param
 * </pre>
 *
 * @author ALEXANDRE MIGUEL SILVA SANTOS
 */

/*

 */

public class PVisitedNetworkIDParser extends ParametersParser implements TokenTypes {

    /**
     * Constructor
     */
    public PVisitedNetworkIDParser(String networkID) {
        super(networkID);

    }

    protected PVisitedNetworkIDParser(Lexer lexer) {
        super(lexer);

    }




    public SIPHeader parse() throws ParseException {

        PVisitedNetworkIDList visitedNetworkIDList = new PVisitedNetworkIDList();

        if (debug)
            dbg_enter("VisitedNetworkIDParser.parse");

        try {
            this.lexer.match(TokenTypes.P_VISITED_NETWORK_ID);
            this.lexer.SPorHT();
            this.lexer.match(':');
            this.lexer.SPorHT();

            while (true) {

                PVisitedNetworkID visitedNetworkID = new PVisitedNetworkID();

                if (this.lexer.lookAhead(0) == '\"')
                    parseQuotedString(visitedNetworkID);
                else
                    parseToken(visitedNetworkID);

                visitedNetworkIDList.add(visitedNetworkID);

                this.lexer.SPorHT();
                char la = lexer.lookAhead(0);
                if (la == ',') {
                    this.lexer.match(',');
                    this.lexer.SPorHT();
                } else if (la == '\n')
                    break;
                else
                    throw createParseException("unexpected char = " + la);
            }
            return visitedNetworkIDList;
        } finally {
            if (debug)
                dbg_leave("VisitedNetworkIDParser.parse");
        }

    }

    protected void parseQuotedString(PVisitedNetworkID visitedNetworkID) throws ParseException {

        if (debug)
            dbg_enter("parseQuotedString");

        try {

            StringBuffer retval = new StringBuffer();

            if (this.lexer.lookAhead(0) != '\"')
                throw createParseException("unexpected char");
            this.lexer.consume(1);

            while (true) {
                char next = this.lexer.getNextChar();
                if (next == '\"') {
                    // Got to the terminating quote.
                    break;
                } else if (next == '\0') {
                    throw new ParseException("unexpected EOL", 1);
                } else if (next == '\\') {
                    retval.append(next);
                    next = this.lexer.getNextChar();
                    retval.append(next);
                } else {
                    retval.append(next);
                }
            }

            visitedNetworkID.setVisitedNetworkID(retval.toString());
            super.parse(visitedNetworkID);



        }finally {
            if (debug)
                dbg_leave("parseQuotedString.parse");
        }

    }

    protected void parseToken(PVisitedNetworkID visitedNetworkID) throws ParseException
    {
        // issued by Miguel Freitas

        lexer.match(TokenTypes.ID);
        Token token = lexer.getNextToken();
        //String value = token.getTokenValue();
        visitedNetworkID.setVisitedNetworkID(token);
        super.parse(visitedNetworkID);

    }


}
