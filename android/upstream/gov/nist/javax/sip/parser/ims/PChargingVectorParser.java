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

import gov.nist.core.NameValue;
import gov.nist.javax.sip.header.SIPHeader;
import gov.nist.javax.sip.header.ims.PChargingVector;
import gov.nist.javax.sip.header.ims.ParameterNamesIms;
import gov.nist.javax.sip.parser.Lexer;
import gov.nist.javax.sip.parser.ParametersParser;
import gov.nist.javax.sip.parser.TokenTypes;

import java.text.ParseException;

/**
 * P-Charging-Vector header parser.
 *
 * @author ALEXANDRE MIGUEL SILVA SANTOS
 */

public class PChargingVectorParser
extends ParametersParser implements TokenTypes {

    public PChargingVectorParser(String chargingVector) {

        super(chargingVector);

    }

    protected PChargingVectorParser(Lexer lexer) {

        super(lexer);

    }



    public SIPHeader parse() throws ParseException {


        if (debug)
            dbg_enter("parse");
        try {
            headerName(TokenTypes.P_VECTOR_CHARGING);
            PChargingVector chargingVector = new PChargingVector();

            try {
                while (lexer.lookAhead(0) != '\n') {
                    this.parseParameter(chargingVector);
                    this.lexer.SPorHT();
                    char la = lexer.lookAhead(0);
                    if (la == '\n' || la == '\0')
                        break;
                    this.lexer.match(';');
                    this.lexer.SPorHT();
                }

            } catch (ParseException ex) {
                throw ex;
            }


            super.parse(chargingVector);
            if ( chargingVector.getParameter(ParameterNamesIms.ICID_VALUE) == null )
                throw new ParseException("Missing a required Parameter : " + ParameterNamesIms.ICID_VALUE, 0);
            return chargingVector;
        } finally {
            if (debug)
                dbg_leave("parse");
        }
    }

    protected void parseParameter(PChargingVector chargingVector) throws ParseException {

        if (debug)
            dbg_enter("parseParameter");
        try {
            NameValue nv = this.nameValue('=');
            chargingVector.setParameter(nv);
        } finally {
            if (debug)
                dbg_leave("parseParameter");
        }



    }



}
