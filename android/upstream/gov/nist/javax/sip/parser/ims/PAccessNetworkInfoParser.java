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

import gov.nist.javax.sip.header.ims.PAccessNetworkInfo;
import gov.nist.javax.sip.header.ims.SIPHeaderNamesIms;
import gov.nist.core.Token;
import gov.nist.core.NameValue;
import gov.nist.javax.sip.header.SIPHeader;
import gov.nist.javax.sip.parser.HeaderParser;
import gov.nist.javax.sip.parser.Lexer;
import gov.nist.javax.sip.parser.ParametersParser;
import gov.nist.javax.sip.parser.TokenTypes;


/**
 * P-Access-Network-Info header parser.
 *
 * <p>RFC 3455 - Private Header (P-Header) Extensions to the Session Initiation
 *   Protocol (SIP) for the 3rd-Generation Partnership Project (3GPP) </p>
 *
 * <p>Sintax (RFC 3455):</p>
 * <pre>
 * P-Access-Network-Info  = "P-Access-Network-Info" HCOLON access-net-spec
 * access-net-spec        = access-type *(SEMI access-info)
 * access-type            = "IEEE-802.11a" / "IEEE-802.11b" /
 *                          "3GPP-GERAN" / "3GPP-UTRAN-FDD" /
 *                          "3GPP-UTRAN-TDD" / "3GPP-CDMA2000" / token
 * access-info            = cgi-3gpp / utran-cell-id-3gpp / extension-access-info
 * extension-access-info  = gen-value
 * cgi-3gpp               = "cgi-3gpp" EQUAL (token / quoted-string)
 * utran-cell-id-3gpp     = "utran-cell-id-3gpp" EQUAL (token / quoted-string)
 * </pre>
 *
 * @author Miguel Freitas (IT) PT-Inovacao
 */


public class PAccessNetworkInfoParser
    extends HeaderParser
    implements TokenTypes
{

    public PAccessNetworkInfoParser(String accessNetwork) {

        super(accessNetwork);

    }


    protected PAccessNetworkInfoParser(Lexer lexer) {
        super(lexer);

    }


    public SIPHeader parse() throws ParseException
    {

        if (debug)
            dbg_enter("AccessNetworkInfoParser.parse");
        try {
            headerName(TokenTypes.P_ACCESS_NETWORK_INFO);
            PAccessNetworkInfo accessNetworkInfo = new PAccessNetworkInfo();
            accessNetworkInfo.setHeaderName(SIPHeaderNamesIms.P_ACCESS_NETWORK_INFO);

            this.lexer.SPorHT();
            lexer.match(TokenTypes.ID);
            Token token = lexer.getNextToken();
            accessNetworkInfo.setAccessType(token.getTokenValue());

            this.lexer.SPorHT();
            while (lexer.lookAhead(0) == ';') {
                this.lexer.match(';');
                this.lexer.SPorHT();

                NameValue nv = super.nameValue('=');
                accessNetworkInfo.setParameter(nv);
                this.lexer.SPorHT();
            }
            this.lexer.SPorHT();
            this.lexer.match('\n');


            return accessNetworkInfo;
        } finally {
            if (debug)
                dbg_leave("AccessNetworkInfoParser.parse");
        }

    }




}
