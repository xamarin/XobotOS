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
 * of the terms of this agreement.
 *
 */
package gov.nist.javax.sip.parser;

import gov.nist.javax.sip.address.AddressImpl;
import gov.nist.javax.sip.address.SipUri;
import gov.nist.javax.sip.header.Contact;
import gov.nist.javax.sip.header.ContactList;
import gov.nist.javax.sip.header.SIPHeader;

import javax.sip.address.URI;
import java.text.ParseException;
import java.util.HashSet;
import java.util.Iterator;

/**
 * A parser for The SIP contact header.
 *
 * @version 1.2 $Revision: 1.13 $ $Date: 2009/10/22 10:27:37 $
 * @since 1.1
 */
public class ContactParser extends AddressParametersParser {

    public ContactParser(String contact) {
        super(contact);
    }

    protected ContactParser(Lexer lexer) {
        super(lexer);
        this.lexer = lexer;
    }

    public SIPHeader parse() throws ParseException {
        // past the header name and the colon.
        headerName(TokenTypes.CONTACT);
        ContactList retval = new ContactList();
        while (true) {
            Contact contact = new Contact();
            if (lexer.lookAhead(0) == '*') {
                final char next = lexer.lookAhead(1);
                if (next == ' ' || next == '\t' || next == '\r' || next == '\n') {
                    this.lexer.match('*');
                    contact.setWildCardFlag(true);
                } else {
                    super.parse(contact);
                }
            } else {
                super.parse(contact);
            }
            retval.add(contact);
            this.lexer.SPorHT();
            char la = lexer.lookAhead(0);
            if (la == ',') {
                this.lexer.match(',');
                this.lexer.SPorHT();
            } else if (la == '\n' || la == '\0')
                break;
            else
                throw createParseException("unexpected char");
        }
        return retval;
    }

}
