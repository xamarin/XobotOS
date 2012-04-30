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
import java.util.*;
import java.text.ParseException;

/**
 * Parser for SIP Date field. Converts from SIP Date to the
 * internal storage (Calendar)
 *
 * @version 1.2 $Revision: 1.11 $ $Date: 2009/07/17 18:57:59 $
 */
public class DateParser extends HeaderParser {

    /**
     * Constructor
     * @param date message to parse to set
     */
    public DateParser(String date) {
        super(date);
    }

    protected DateParser(Lexer lexer) {
        super(lexer);
    }

    /**
     * Parse method.
     * @throws ParseException
     * @return  the parsed Date header/
     */
    public SIPHeader parse() throws ParseException {
        if (debug)
            dbg_enter("DateParser.parse");
        try {
            headerName(TokenTypes.DATE);
            wkday();
            lexer.match(',');
            lexer.match(' ');
            Calendar cal = date();
            lexer.match(' ');
            time(cal);
            lexer.match(' ');
            String tzone = this.lexer.ttoken().toLowerCase();
            if (!"gmt".equals(tzone))
                throw createParseException("Bad Time Zone " + tzone);
            this.lexer.match('\n');
            SIPDateHeader retval = new SIPDateHeader();
            retval.setDate(cal);
            return retval;
        } finally {
            if (debug)
                dbg_leave("DateParser.parse");

        }

    }


}
