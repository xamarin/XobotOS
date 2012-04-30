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

import gov.nist.javax.sip.address.GenericURI;
import gov.nist.javax.sip.header.AlertInfo;
import gov.nist.javax.sip.header.AlertInfoList;
import gov.nist.javax.sip.header.SIPHeader;
import gov.nist.javax.sip.header.SIPHeaderNames;

import java.text.ParseException;

/**
 * Parser for AlertInfo header.
 *
 * @version 1.2 $Revision: 1.10 $ $Date: 2009/11/07 23:35:49 $
 *
 * @author Olivier Deruelle
 * @author M. Ranganathan
 *
 */
public class AlertInfoParser extends ParametersParser {

    /**
     * Creates a new instance of AlertInfo Parser
     * @param alertInfo  the header to parse
     */
    public AlertInfoParser(String alertInfo) {
        super(alertInfo);
    }

    /**
     * Constructor
     * @param lexer the lexer to use to parse the header
     */
    protected AlertInfoParser(Lexer lexer) {
        super(lexer);
    }

    /**
     * parse the AlertInfo  String header
     * @return SIPHeader (AlertInfoList  object)
     * @throws SIPParseException if the message does not respect the spec.
     */
    public SIPHeader parse() throws ParseException {

        if (debug)
            dbg_enter("AlertInfoParser.parse");
        AlertInfoList list = new AlertInfoList();

        try {
            headerName(TokenTypes.ALERT_INFO);

            while (lexer.lookAhead(0) != '\n') {
                AlertInfo alertInfo = new AlertInfo();
                alertInfo.setHeaderName(SIPHeaderNames.ALERT_INFO);
                URLParser urlParser;
                GenericURI uri;

                do {
	                this.lexer.SPorHT();
	                if (this.lexer.lookAhead(0) == '<') {
	                    this.lexer.match('<');
	                    urlParser = new URLParser((Lexer) this.lexer);
	                    uri = urlParser.uriReference( true );
	                    alertInfo.setAlertInfo(uri);
	                    this.lexer.match('>');
	                } else {
	                	/* This is non standard for Polycom support. 
	                	 * I know it is bad grammar but please do not remove. mranga 
	                	 */
	                	String alertInfoStr = this.lexer.byteStringNoSemicolon();
	                	alertInfo.setAlertInfo(alertInfoStr);
	                }
	                	
	                this.lexer.SPorHT();
	
	                super.parse(alertInfo);
	                list.add(alertInfo);
	                
	                if ( lexer.lookAhead(0) == ',' ) {
	                	this.lexer.match(',');
	                } else break;
                } while (true);
            }
            return list;
        } finally {
            if (debug)
                dbg_leave("AlertInfoParser.parse");
        }
    }
}
/*
 * $Log: AlertInfoParser.java,v $
 * Revision 1.10  2009/11/07 23:35:49  mranga
 * Fix Alert-Info ( loosen up parsing). Define AUTOMATIC_DIALOG_ERROR_HANDLING flag.
 *
 * Revision 1.9  2009/10/22 10:27:36  jbemmel
 * Fix for issue #230, restructured the code such that parsing for any address appearing without '<' '>'
 * stops at ';', then parameters are assigned to the header as expected
 *
 * Revision 1.8  2009/07/17 18:57:57  emcho
 * Converts indentation tabs to spaces so that we have a uniform indentation policy in the whole project.
 *
 * Revision 1.7  2007/10/18 17:48:09  mranga
 * Issue number:
 * Obtained from:
 * Submitted by:  mardy
 * Reviewed by:   mranga
 * Alert info patch to accept non standard alert info headers.
 *
 * Revision 1.6  2006/07/13 09:02:19  mranga
 * Issue number:
 * Obtained from:
 * Submitted by:  jeroen van bemmel
 * Reviewed by:   mranga
 * Moved some changes from jain-sip-1.2 to java.net
 *
 * CVS: ----------------------------------------------------------------------
 * CVS: Issue number:
 * CVS:   If this change addresses one or more issues,
 * CVS:   then enter the issue number(s) here.
 * CVS: Obtained from:
 * CVS:   If this change has been taken from another system,
 * CVS:   then name the system in this line, otherwise delete it.
 * CVS: Submitted by:
 * CVS:   If this code has been contributed to the project by someone else; i.e.,
 * CVS:   they sent us a patch or a set of diffs, then include their name/email
 * CVS:   address here. If this is your work then delete this line.
 * CVS: Reviewed by:
 * CVS:   If we are doing pre-commit code reviews and someone else has
 * CVS:   reviewed your changes, include their name(s) here.
 * CVS:   If you have not had it reviewed then delete this line.
 *
 * Revision 1.3  2006/06/19 06:47:27  mranga
 * javadoc fixups
 *
 * Revision 1.2  2006/06/16 15:26:28  mranga
 * Added NIST disclaimer to all public domain files. Clean up some javadoc. Fixed a leak
 *
 * Revision 1.1.1.1  2005/10/04 17:12:35  mranga
 *
 * Import
 *
 *
 * Revision 1.4  2004/01/22 13:26:31  sverker
 * Issue number:
 * Obtained from:
 * Submitted by:  sverker
 * Reviewed by:   mranga
 *
 * Major reformat of code to conform with style guide. Resolved compiler and javadoc warnings. Added CVS tags.
 *
 * CVS: ----------------------------------------------------------------------
 * CVS: Issue number:
 * CVS:   If this change addresses one or more issues,
 * CVS:   then enter the issue number(s) here.
 * CVS: Obtained from:
 * CVS:   If this change has been taken from another system,
 * CVS:   then name the system in this line, otherwise delete it.
 * CVS: Submitted by:
 * CVS:   If this code has been contributed to the project by someone else; i.e.,
 * CVS:   they sent us a patch or a set of diffs, then include their name/email
 * CVS:   address here. If this is your work then delete this line.
 * CVS: Reviewed by:
 * CVS:   If we are doing pre-commit code reviews and someone else has
 * CVS:   reviewed your changes, include their name(s) here.
 * CVS:   If you have not had it reviewed then delete this line.
 *
 */
