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
/************************************************************************************************
 * PRODUCT OF PT INOVACAO - EST DEPARTMENT and Telecommunications Institute (Aveiro, Portugal)  *
 ************************************************************************************************/


package gov.nist.javax.sip.parser.ims;

/**
 * Privacy header parser.
 *
 * @author Miguel Freitas (IT) PT-Inovacao
 */

/*
 * Privacy-hdr  =  "Privacy" HCOLON priv-value *(";" priv-value)
 * priv-value   =   "header" / "session" / "user" / "none" / "critical" / token
 */

import gov.nist.core.*;
import gov.nist.javax.sip.header.SIPHeader;
import gov.nist.javax.sip.parser.Lexer;
import gov.nist.javax.sip.parser.TokenTypes;
import gov.nist.javax.sip.parser.HeaderParser;

import java.text.ParseException;

import gov.nist.javax.sip.header.ims.Privacy;
import gov.nist.javax.sip.header.ims.PrivacyList;
import gov.nist.javax.sip.header.ims.SIPHeaderNamesIms;



public class PrivacyParser
    extends HeaderParser
    implements TokenTypes
{


    public PrivacyParser(String privacyType) {

        super(privacyType);
    }

    protected PrivacyParser(Lexer lexer) {

        super(lexer);
    }


    public SIPHeader parse() throws ParseException
    {
        if (debug)
            dbg_enter("PrivacyParser.parse");

        PrivacyList privacyList = new PrivacyList();

        try
        {
            this.headerName(TokenTypes.PRIVACY);

            while (lexer.lookAhead(0) != '\n') {
                this.lexer.SPorHT();

                Privacy privacy = new Privacy();
                privacy.setHeaderName(SIPHeaderNamesIms.PRIVACY);

                this.lexer.match(TokenTypes.ID);
                Token token = lexer.getNextToken();
                privacy.setPrivacy(token.getTokenValue());
                this.lexer.SPorHT();
                privacyList.add(privacy);

                // Parsing others option-tags
                while (lexer.lookAhead(0) == ';')
                {
                    this.lexer.match(';');
                    this.lexer.SPorHT();
                    privacy = new Privacy();
                    this.lexer.match(TokenTypes.ID);
                    token = lexer.getNextToken();
                    privacy.setPrivacy(token.getTokenValue());
                    this.lexer.SPorHT();

                    privacyList.add(privacy);
                }
            }

            return privacyList;

        }
        finally {
            if (debug)
                dbg_leave("PrivacyParser.parse");
        }

    }


    /** Test program */
    public static void main(String args[]) throws ParseException
    {
        String rou[] = {

                "Privacy: none\n",
                "Privacy: none;id;user\n"
            };

        for (int i = 0; i < rou.length; i++ ) {
            PrivacyParser rp =
              new PrivacyParser(rou[i]);
            PrivacyList list = (PrivacyList) rp.parse();
            System.out.println("encoded = " +list.encode());
        }
    }



}

