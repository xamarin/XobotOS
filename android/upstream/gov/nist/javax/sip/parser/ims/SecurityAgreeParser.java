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
 * Security Agreement for SIP.
 * <p>headers: Security-Client, Security-Server and Security-Verify</p>
 *
 * @author Miguel Freitas (IT) PT-Inovacao
 */


import gov.nist.core.NameValue;
import gov.nist.core.Token;
import gov.nist.javax.sip.header.SIPHeaderList;
import gov.nist.javax.sip.header.ims.*;
import gov.nist.javax.sip.parser.HeaderParser;
import gov.nist.javax.sip.parser.Lexer;
import gov.nist.javax.sip.parser.TokenTypes;

import java.text.ParseException;



public class SecurityAgreeParser extends HeaderParser
{

    public SecurityAgreeParser(String security) {
        super(security);
    }


    protected SecurityAgreeParser(Lexer lexer) {
        super(lexer);
    }


    protected void parseParameter(SecurityAgree header)
        throws ParseException
    {
        if (debug)
            dbg_enter("parseParameter");
        try {
            NameValue nv = this.nameValue('=');
            header.setParameter(nv);
        } finally {
            if (debug)
                dbg_leave("parseParameter");
        }
    }


    public SIPHeaderList parse(SecurityAgree header) throws ParseException
    {

        SIPHeaderList list;

        if (header.getClass().isInstance(new SecurityClient())) {
            list = new SecurityClientList();
        } else if (header.getClass().isInstance(new SecurityServer())) {
            list = new SecurityServerList();
        } else if (header.getClass().isInstance(new SecurityVerify())) {
            list = new SecurityVerifyList();
        }
        else
            return null;


        // the security-mechanism:
        this.lexer.SPorHT();
        lexer.match(TokenTypes.ID);
        Token type = lexer.getNextToken();
        header.setSecurityMechanism(type.getTokenValue());
        this.lexer.SPorHT();

        char la = lexer.lookAhead(0);
        if (la == '\n')
        {
            list.add(header);
            return list;
        }
        else if (la == ';')
            this.lexer.match(';');

        this.lexer.SPorHT();

        // The parameters:
        try {
            while (lexer.lookAhead(0) != '\n') {

                this.parseParameter(header);
                this.lexer.SPorHT();
                char laInLoop = lexer.lookAhead(0);
                if (laInLoop == '\n' || laInLoop == '\0')
                    break;
                else if (laInLoop == ',')
                {
                    list.add(header);
                    if (header.getClass().isInstance(new SecurityClient())) {
                        header = new SecurityClient();
                    } else if (header.getClass().isInstance(new SecurityServer())) {
                        header = new SecurityServer();
                    } else if (header.getClass().isInstance(new SecurityVerify())) {
                        header = new SecurityVerify();
                    }

                    this.lexer.match(',');
                    // the security-mechanism:
                    this.lexer.SPorHT();
                    lexer.match(TokenTypes.ID);
                    type = lexer.getNextToken();
                    header.setSecurityMechanism(type.getTokenValue());

                }
                this.lexer.SPorHT();

                if (lexer.lookAhead(0) == ';')
                    this.lexer.match(';');

                this.lexer.SPorHT();

            }
            list.add(header);

            return list;

        } catch (ParseException ex) {
            throw ex;
        }


    }




}


