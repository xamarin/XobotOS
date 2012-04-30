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
 * Parser for RetryAfter header.
 *
 * @version 1.2
 *
 * @author Olivier Deruelle
 * @author M. Ranganathan
 *
 *
 * @version 1.2 $Revision: 1.10 $ $Date: 2009/11/04 17:23:00 $
 */
public class RetryAfterParser extends HeaderParser {

    /**
     * Creates a new instance of RetryAfterParser
     * @param retryAfter the header to parse
     */
    public RetryAfterParser(String retryAfter) {
        super(retryAfter);
    }

    /**
     * Constructor
     * @param lexer the lexer to use to parse the header
     */
    protected RetryAfterParser(Lexer lexer) {
        super(lexer);
    }

    /**
     * parse the String message
     * @return SIPHeader (RetryAfter object)
     * @throws SIPParseException if the message does not respect the spec.
     */
    public SIPHeader parse() throws ParseException {

        if (debug)
            dbg_enter("RetryAfterParser.parse");

        RetryAfter retryAfter = new RetryAfter();
        try {
            headerName(TokenTypes.RETRY_AFTER);

            // mandatory delatseconds:
            String value = lexer.number();
            try {
                int ds = Integer.parseInt(value);
                retryAfter.setRetryAfter(ds);
            } catch (NumberFormatException ex) {
                throw createParseException(ex.getMessage());
            } catch (InvalidArgumentException ex) {
                throw createParseException(ex.getMessage());
            }

            this.lexer.SPorHT();
            if (lexer.lookAhead(0) == '(') {
                String comment = this.lexer.comment();
                retryAfter.setComment(comment);
            }
            this.lexer.SPorHT();

            while (lexer.lookAhead(0) == ';') {
                this.lexer.match(';');
                this.lexer.SPorHT();
                lexer.match(TokenTypes.ID);
                Token token = lexer.getNextToken();
                value = token.getTokenValue();
                if (value.equalsIgnoreCase("duration")) {
                    this.lexer.match('=');
                    this.lexer.SPorHT();
                    value = lexer.number();
                    try {
                        int duration = Integer.parseInt(value);
                        retryAfter.setDuration(duration);
                    } catch (NumberFormatException ex) {
                        throw createParseException(ex.getMessage());
                    } catch (InvalidArgumentException ex) {
                        throw createParseException(ex.getMessage());
                    }
                } else {
                    this.lexer.SPorHT();
                    this.lexer.match('=');
                    this.lexer.SPorHT();
                    lexer.match(TokenTypes.ID);
                    Token secondToken = lexer.getNextToken();
                    String secondValue = secondToken.getTokenValue();
                    retryAfter.setParameter(value, secondValue);
                }
                this.lexer.SPorHT();
            }
        } finally {
            if (debug)
                dbg_leave("RetryAfterParser.parse");
        }

        return retryAfter;
    }

}
