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
/****************************************************************************
 * PRODUCT OF PT INOVACAO - EST DEPARTMENT and Aveiro University (Portugal) *
 ****************************************************************************/

package gov.nist.javax.sip.parser.ims;

import java.text.ParseException;

import gov.nist.javax.sip.header.ims.PCalledPartyID;
import gov.nist.javax.sip.header.SIPHeader;
import gov.nist.javax.sip.parser.Lexer;
import gov.nist.javax.sip.parser.TokenTypes;
import gov.nist.javax.sip.parser.AddressParametersParser;

/**
 * P-Called-Party-ID header parser
 *
 * @author Miguel Freitas (IT) PT-Inovacao
 */

public class PCalledPartyIDParser
    extends AddressParametersParser
{


    /**
     * Constructor
     * @param calledPartyID content to set
     */
    public PCalledPartyIDParser(String calledPartyID)
    {
        super(calledPartyID);
    }

    protected PCalledPartyIDParser(Lexer lexer)
    {
        super(lexer);
    }


    public SIPHeader parse() throws ParseException
    {

        if (debug)
            dbg_enter("PCalledPartyIDParser.parse");

        try {
            this.lexer.match(TokenTypes.P_CALLED_PARTY_ID);
            this.lexer.SPorHT();
            this.lexer.match(':');
            this.lexer.SPorHT();

            PCalledPartyID calledPartyID = new PCalledPartyID();
            super.parse(calledPartyID);

            return calledPartyID;

        } finally {
            if (debug)
                dbg_leave("PCalledPartyIDParser.parse");
        }

    }




    /** Test program
    public static void main(String args[]) throws ParseException
    {
        String rou[] = {
                    "P-Associated-URI: <sip:testes1@ptinovacao.pt>,  " +
                                    "<sip:testes2@ptinovacao.pt> \n"
                    };

        for (int i = 0; i < rou.length; i++ ) {
            RecordRouteParser rp =
              new RecordRouteParser(rou[i]);
            RecordRouteList recordRouteList = (RecordRouteList) rp.parse();
            System.out.println("encoded = " +recordRouteList.encode());
        }
    }
    */


}
