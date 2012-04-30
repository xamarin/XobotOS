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

/** parameters parser header.
 *
 * @version 1.2 $Revision: 1.10 $ $Date: 2009/07/17 18:58:01 $
 *
 * @author M. Ranganathan   <br/>
 *
 *
 *
 */
public abstract class ParametersParser extends HeaderParser {

    protected ParametersParser(Lexer lexer) {
        super((Lexer) lexer);
    }

    protected ParametersParser(String buffer) {
        super(buffer);
    }

    protected void parse(ParametersHeader parametersHeader)
        throws ParseException {
        this.lexer.SPorHT();
        while (lexer.lookAhead(0) == ';') {
            this.lexer.consume(1);
            // eat white space
            this.lexer.SPorHT();
            NameValue nv = nameValue();
            parametersHeader.setParameter(nv);
            // eat white space
            this.lexer.SPorHT();
        }
    }



    protected void parseNameValueList(ParametersHeader parametersHeader)
        throws ParseException{
        parametersHeader.removeParameters();
        while (true) {
                this.lexer.SPorHT();
            NameValue nv = nameValue();
            parametersHeader.setParameter(nv.getName(), (String) nv.getValueAsObject());
            // eat white space
            this.lexer.SPorHT();
            if (lexer.lookAhead(0) != ';')  break;
            else lexer.consume(1);
        }
    }
}
