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

import java.text.ParseException;

import javax.sip.InvalidArgumentException;

import gov.nist.javax.sip.header.ims.PMediaAuthorizationList;
import gov.nist.javax.sip.header.ims.PMediaAuthorization;
import gov.nist.javax.sip.header.ims.SIPHeaderNamesIms;
import gov.nist.core.Token;
import gov.nist.javax.sip.header.SIPHeader;
import gov.nist.javax.sip.parser.HeaderParser;
import gov.nist.javax.sip.parser.Lexer;
import gov.nist.javax.sip.parser.TokenTypes;


/**
 * P-Media-Authorization header parser.
 *
 * @author Miguel Freitas (IT) PT-Inovacao
 */

public class PMediaAuthorizationParser
    extends HeaderParser
    implements TokenTypes
{

    public PMediaAuthorizationParser(String mediaAuthorization)
    {
        super(mediaAuthorization);

    }

    public PMediaAuthorizationParser(Lexer lexer)
    {
        super(lexer);

    }





    public SIPHeader parse() throws ParseException
    {
        PMediaAuthorizationList mediaAuthorizationList = new PMediaAuthorizationList();

        if (debug)
            dbg_enter("MediaAuthorizationParser.parse");


        try
        {
            headerName(TokenTypes.P_MEDIA_AUTHORIZATION);

            PMediaAuthorization mediaAuthorization = new PMediaAuthorization();
            mediaAuthorization.setHeaderName(SIPHeaderNamesIms.P_MEDIA_AUTHORIZATION);

            while (lexer.lookAhead(0) != '\n')
            {
                this.lexer.match(TokenTypes.ID);
                Token token = lexer.getNextToken();
                try {
                    mediaAuthorization.setMediaAuthorizationToken(token.getTokenValue());
                } catch (InvalidArgumentException e) {
                    throw createParseException(e.getMessage());
                }
                mediaAuthorizationList.add(mediaAuthorization);

                this.lexer.SPorHT();
                if (lexer.lookAhead(0) == ',')
                {
                    this.lexer.match(',');
                    mediaAuthorization = new PMediaAuthorization();
                }
                this.lexer.SPorHT();
            }

            return mediaAuthorizationList;

        }
        finally
        {
            if (debug)
                dbg_leave("MediaAuthorizationParser.parse");
        }

    }




    /*
     * test
     *
    public static void main(String args[]) throws ParseException
    {
        String pHeader[] = {
            "P-Media-Authorization: 0123456789 \n",
            "P-Media-Authorization: 0123456789, ABCDEF\n"
            };

        for (int i = 0; i < pHeader.length; i++ )
        {
            PMediaAuthorizationParser mParser =
                new PMediaAuthorizationParser(pHeader[i]);

            PMediaAuthorizationList mList= (PMediaAuthorizationList) mParser.parse();
            System.out.println("encoded = " + mList.encode());
        }
    }
     */



}
