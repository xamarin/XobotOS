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
/*
 * ContentTypeParser.java
 *
 * Created on February 26, 2002, 2:42 PM
 */

package gov.nist.javax.sip.parser;
import gov.nist.core.*;
import gov.nist.javax.sip.header.*;
import java.text.ParseException;

/**
 * Parser for content type header.
 *
 * @version 1.2 $Revision: 1.9 $ $Date: 2009/07/17 18:57:59 $
 *
 * @author M. Ranganathan   <br/>
 *
 *
 */
public class ContentTypeParser extends ParametersParser {

    public ContentTypeParser(String contentType) {
        super(contentType);
    }

    protected ContentTypeParser(Lexer lexer) {
        super(lexer);
    }

    public SIPHeader parse() throws ParseException {

        ContentType contentType = new ContentType();
        if (debug)
            dbg_enter("ContentTypeParser.parse");

        try {
            this.headerName(TokenTypes.CONTENT_TYPE);

            // The type:
            lexer.match(TokenTypes.ID);
            Token type = lexer.getNextToken();
            this.lexer.SPorHT();
            contentType.setContentType(type.getTokenValue());

            // The sub-type:
            lexer.match('/');
            lexer.match(TokenTypes.ID);
            Token subType = lexer.getNextToken();
            this.lexer.SPorHT();
            contentType.setContentSubType(subType.getTokenValue());
            super.parse(contentType);
            this.lexer.match('\n');
        } finally {
            if (debug)
                dbg_leave("ContentTypeParser.parse");
        }
        return contentType;

    }


}

