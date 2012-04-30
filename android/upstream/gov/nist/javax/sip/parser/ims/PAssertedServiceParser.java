package gov.nist.javax.sip.parser.ims;
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
import java.text.ParseException;
import javax.sip.InvalidArgumentException;
import gov.nist.javax.sip.header.SIPHeader;
import gov.nist.javax.sip.header.ims.PAssertedService;
import gov.nist.javax.sip.header.ims.ParameterNamesIms;
import gov.nist.javax.sip.parser.HeaderParser;
import gov.nist.javax.sip.parser.Lexer;
import gov.nist.javax.sip.parser.TokenTypes;

/**
 *
 * @author aayush.bhatnagar
 * Rancore Technologies Pvt Ltd, Mumbai India.
 *
 * Parse this:
 * P-Asserted-Service: urn:urn-7:3gpp-service.exampletelephony.version1
 *
 */
public class PAssertedServiceParser extends HeaderParser implements TokenTypes{

    protected PAssertedServiceParser(Lexer lexer) {
        super(lexer);
    }

    public PAssertedServiceParser(String pas)
    {
        super(pas);
    }

    public SIPHeader parse() throws ParseException {
        if(debug)
            dbg_enter("PAssertedServiceParser.parse");
        try
        {
        this.lexer.match(TokenTypes.P_ASSERTED_SERVICE);
        this.lexer.SPorHT();
        this.lexer.match(':');
        this.lexer.SPorHT();

        PAssertedService pps = new PAssertedService();
        String urn = this.lexer.getBuffer();
        if(urn.contains(ParameterNamesIms.SERVICE_ID)){

           if(urn.contains(ParameterNamesIms.SERVICE_ID_LABEL))
                   {
                    String serviceID = urn.split(ParameterNamesIms.SERVICE_ID_LABEL+".")[1];

                     if(serviceID.trim().equals(""))
                        try {
                            throw new InvalidArgumentException("URN should atleast have one sub-service");
                        } catch (InvalidArgumentException e) {

                            e.printStackTrace();
                        }
                        else
                    pps.setSubserviceIdentifiers(urn.split(ParameterNamesIms.SERVICE_ID_LABEL)[1]);
                   }
           else if(urn.contains(ParameterNamesIms.APPLICATION_ID_LABEL))
              {
               String appID = urn.split(ParameterNamesIms.APPLICATION_ID_LABEL+".")[1];
               if(appID.trim().equals(""))
                    try {
                        throw new InvalidArgumentException("URN should atleast have one sub-application");
                    } catch (InvalidArgumentException e) {
                        e.printStackTrace();
                    }
                    else
                  pps.setApplicationIdentifiers(urn.split(ParameterNamesIms.APPLICATION_ID_LABEL)[1]);
              }
           else
           {
               try {
                throw new InvalidArgumentException("URN is not well formed");

            } catch (InvalidArgumentException e) {
                e.printStackTrace();
                    }
                  }
          }

            super.parse();
            return pps;
        }
        finally{
            if(debug)
                dbg_enter("PAssertedServiceParser.parse");
        }

    }
}
