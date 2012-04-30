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
import gov.nist.core.HostNameParser;
import gov.nist.core.HostPort;
import gov.nist.core.NameValue;
import gov.nist.core.NameValueList;
import gov.nist.core.Token;
import gov.nist.javax.sip.address.GenericURI;
import gov.nist.javax.sip.address.SipUri;
import gov.nist.javax.sip.address.TelURLImpl;
import gov.nist.javax.sip.address.TelephoneNumber;
import java.text.ParseException;

/**
 * Parser For SIP and Tel URLs. Other kinds of URL's are handled by the
 * J2SE 1.4 URL class.
 * @version 1.2 $Revision: 1.27 $ $Date: 2009/10/22 10:27:39 $
 *
 * @author M. Ranganathan   <br/>
 *
 *
 */
public class URLParser extends Parser {

    public URLParser(String url) {
        this.lexer = new Lexer("sip_urlLexer", url);
    }

    // public tag added - issued by Miguel Freitas
    public URLParser(Lexer lexer) {
        this.lexer = lexer;
        this.lexer.selectLexer("sip_urlLexer");
    }
    protected static boolean isMark(char next) {
        switch (next) {
            case '-':
            case '_':
            case '.':
            case '!':
            case '~':
            case '*':
            case '\'':
            case '(':
            case ')':
                return true;
            default:
                return false;
        }
    }

    protected static boolean isUnreserved(char next) {
        return Lexer.isAlphaDigit(next) || isMark(next);
    }

    protected static boolean isReservedNoSlash(char next) {
        switch (next) {
            case ';':
            case '?':
            case ':':
            case '@':
            case '&':
            case '+':
            case '$':
            case ',':
                return true;
            default:
                return false;
        }
    }

    // Missing '=' bug in character set - discovered by interop testing
    // at SIPIT 13 by Bob Johnson and Scott Holben.
    // change . to ; by Bruno Konik
    protected static boolean isUserUnreserved(char la) {
        switch (la) {
            case '&':
            case '?':
            case '+':
            case '$':
            case '#':
            case '/':
            case ',':
            case ';':
            case '=':
                return true;
            default:
                return false;
        }
    }

    protected String unreserved() throws ParseException {
        char next = lexer.lookAhead(0);
        if (isUnreserved(next)) {
            lexer.consume(1);
            return String.valueOf(next);
        } else
            throw createParseException("unreserved");

    }

    /** Name or value of a parameter.
     */
    protected String paramNameOrValue() throws ParseException {
        int startIdx = lexer.getPtr();
        while (lexer.hasMoreChars()) {
            char next = lexer.lookAhead(0);
            boolean isValidChar = false;
            switch (next) {
                case '[':
                case ']':// JvB: fixed this one
                case '/':
                case ':':
                case '&':
                case '+':
                case '$':
                    isValidChar = true;
            }
            if (isValidChar || isUnreserved(next)) {
                lexer.consume(1);
            } else if (isEscaped()) {
                lexer.consume(3);
            } else
                break;
        }
        return lexer.getBuffer().substring(startIdx, lexer.getPtr());
    }

    private NameValue uriParam() throws ParseException {
        if (debug)
            dbg_enter("uriParam");
        try {
            String pvalue = "";
            String pname = paramNameOrValue();
            char next = lexer.lookAhead(0);
            boolean isFlagParam = true;
            if (next == '=') {
                lexer.consume(1);
                pvalue = paramNameOrValue();
                isFlagParam = false;
            }
            if (pname.length() == 0 &&
                ( pvalue == null ||
                pvalue.length() == 0))
                return null;
            else return new NameValue(pname, pvalue, isFlagParam);
        } finally {
            if (debug)
                dbg_leave("uriParam");
        }
    }

    protected static boolean isReserved(char next) {
        switch (next) {
            case ';':
            case '/':
            case '?':
            case ':':
            case '=': // Bug fix by Bruno Konik
            case '@':
            case '&':
            case '+':
            case '$':
            case ',':
                return true;
            default:
                return false;
        }
    }

    protected String reserved() throws ParseException {
        char next = lexer.lookAhead(0);
        if (isReserved(next)) {
            lexer.consume(1);
            return new StringBuffer().append(next).toString();
        } else
            throw createParseException("reserved");
    }

    protected boolean isEscaped() {
        try {
            return lexer.lookAhead(0) == '%' &&
                Lexer.isHexDigit(lexer.lookAhead(1)) &&
                Lexer.isHexDigit(lexer.lookAhead(2));
        } catch (Exception ex) {
            return false;
        }
    }

    protected String escaped() throws ParseException {
        if (debug)
            dbg_enter("escaped");
        try {
            StringBuffer retval = new StringBuffer();
            char next = lexer.lookAhead(0);
            char next1 = lexer.lookAhead(1);
            char next2 = lexer.lookAhead(2);
            if (next == '%'
                && Lexer.isHexDigit(next1)
                && Lexer.isHexDigit(next2)) {
                lexer.consume(3);
                retval.append(next);
                retval.append(next1);
                retval.append(next2);
            } else
                throw createParseException("escaped");
            return retval.toString();
        } finally {
            if (debug)
                dbg_leave("escaped");
        }
    }

    protected String mark() throws ParseException {
        if (debug)
            dbg_enter("mark");
        try {
            char next = lexer.lookAhead(0);
            if (isMark(next)) {
                lexer.consume(1);
                return new String( new char[]{next} );
            } else
                throw createParseException("mark");
        } finally {
            if (debug)
                dbg_leave("mark");
        }
    }

    protected String uric() {
        if (debug)
            dbg_enter("uric");
        try {
            try {
                char la = lexer.lookAhead(0);
                if (isUnreserved(la)) {
                    lexer.consume(1);
                    return Lexer.charAsString(la);
                } else if (isReserved(la)) {
                    lexer.consume(1);
                    return Lexer.charAsString(la);
                } else if (isEscaped()) {
                    String retval = lexer.charAsString(3);
                    lexer.consume(3);
                    return retval;
                } else
                    return null;
            } catch (Exception ex) {
                return null;
            }
        } finally {
            if (debug)
                dbg_leave("uric");
        }

    }

    protected String uricNoSlash() {
        if (debug)
            dbg_enter("uricNoSlash");
        try {
            try {
                char la = lexer.lookAhead(0);
                if (isEscaped()) {
                    String retval = lexer.charAsString(3);
                    lexer.consume(3);
                    return retval;
                } else if (isUnreserved(la)) {
                    lexer.consume(1);
                    return Lexer.charAsString(la);
                } else if (isReservedNoSlash(la)) {
                    lexer.consume(1);
                    return Lexer.charAsString(la);
                } else
                    return null;
            } catch (ParseException ex) {
                return null;
            }
        } finally {
            if (debug)
                dbg_leave("uricNoSlash");
        }
    }

    protected String uricString() throws ParseException {
        StringBuffer retval = new StringBuffer();
        while (true) {
            String next = uric();
            if (next == null) {
                char la = lexer.lookAhead(0);
                // JvB: allow IPv6 addresses in generic URI strings
                // e.g. http://[::1]
                if ( la == '[' ) {
                    HostNameParser hnp = new HostNameParser(this.getLexer());
                    HostPort hp = hnp.hostPort( false );
                    retval.append(hp.toString());
                    continue;
                }
                break;
            }
            retval.append(next);
        }
        return retval.toString();
    }

    /**
     * Parse and return a structure for a generic URL.
     * Note that non SIP URLs are just stored as a string (not parsed).
     * @return URI is a URL structure for a SIP url.
     * @throws ParseException if there was a problem parsing.
     */
    public GenericURI uriReference( boolean inBrackets ) throws ParseException {
        if (debug)
            dbg_enter("uriReference");
        GenericURI retval = null;
        Token[] tokens = lexer.peekNextToken(2);
        Token t1 = (Token) tokens[0];
        Token t2 = (Token) tokens[1];
        try {

            if (t1.getTokenType() == TokenTypes.SIP ||
                    t1.getTokenType() == TokenTypes.SIPS) {
                if (t2.getTokenType() == ':')
                    retval = sipURL( inBrackets );
                else
                    throw createParseException("Expecting \':\'");
            } else if (t1.getTokenType() == TokenTypes.TEL) {
                if (t2.getTokenType() == ':') {
                    retval = telURL( inBrackets );
                } else
                    throw createParseException("Expecting \':\'");
            } else {
                String urlString = uricString();
                try {
                    retval = new GenericURI(urlString);
                } catch (ParseException ex) {
                    throw createParseException(ex.getMessage());
                }
            }
        } finally {
            if (debug)
                dbg_leave("uriReference");
        }
        return retval;
    }

    /**
     * Parser for the base phone number.
     */
    private String base_phone_number() throws ParseException {
        StringBuffer s = new StringBuffer();

        if (debug)
            dbg_enter("base_phone_number");
        try {
            int lc = 0;
            while (lexer.hasMoreChars()) {
                char w = lexer.lookAhead(0);
                if (Lexer.isDigit(w)
                    || w == '-'
                    || w == '.'
                    || w == '('
                    || w == ')') {
                    lexer.consume(1);
                    s.append(w);
                    lc++;
                } else if (lc > 0)
                    break;
                else
                    throw createParseException("unexpected " + w);
            }
            return s.toString();
        } finally {
            if (debug)
                dbg_leave("base_phone_number");
        }

    }

    /**
     * Parser for the local phone #.
     */
    private String local_number() throws ParseException {
        StringBuffer s = new StringBuffer();
        if (debug)
            dbg_enter("local_number");
        try {
            int lc = 0;
            while (lexer.hasMoreChars()) {
                char la = lexer.lookAhead(0);
                if (la == '*'
                    || la == '#'
                    || la == '-'
                    || la == '.'
                    || la == '('
                    || la == ')'
                        // JvB: allow 'A'..'F', should be uppercase
                    || Lexer.isHexDigit(la)) {
                    lexer.consume(1);
                    s.append(la);
                    lc++;
                } else if (lc > 0)
                    break;
                else
                    throw createParseException("unexepcted " + la);
            }
            return s.toString();
        } finally {
            if (debug)
                dbg_leave("local_number");
        }

    }

    /**
     * Parser for telephone subscriber.
     *
     * @return the parsed telephone number.
     */
    public final TelephoneNumber parseTelephoneNumber( boolean inBrackets ) 
    	throws ParseException {
        TelephoneNumber tn;

        if (debug)
            dbg_enter("telephone_subscriber");
        lexer.selectLexer("charLexer");
        try {
            char c = lexer.lookAhead(0);
            if (c == '+')
                tn = global_phone_number( inBrackets );
            else if (
                Lexer.isHexDigit(c)// see RFC3966
                    || c == '#'
                    || c == '*'
                    || c == '-'
                    || c == '.'
                    || c == '('
                    || c == ')' ) {
                tn = local_phone_number( inBrackets );
            } else
                throw createParseException("unexpected char " + c);
            return tn;
        } finally {
            if (debug)
                dbg_leave("telephone_subscriber");
        }

    }

    private final TelephoneNumber global_phone_number( boolean inBrackets ) throws ParseException {
        if (debug)
            dbg_enter("global_phone_number");
        try {
            TelephoneNumber tn = new TelephoneNumber();
            tn.setGlobal(true);
            NameValueList nv = null;
            this.lexer.match(PLUS);
            String b = base_phone_number();
            tn.setPhoneNumber(b);
            if (lexer.hasMoreChars()) {
                char tok = lexer.lookAhead(0);
                if (tok == ';' && inBrackets) {
                    this.lexer.consume(1);
                    nv = tel_parameters();
                    tn.setParameters(nv);
                }
            }
            return tn;
        } finally {
            if (debug)
                dbg_leave("global_phone_number");
        }
    }

    private TelephoneNumber local_phone_number( boolean inBrackets ) throws ParseException {
        if (debug)
            dbg_enter("local_phone_number");
        TelephoneNumber tn = new TelephoneNumber();
        tn.setGlobal(false);
        NameValueList nv = null;
        String b = null;
        try {
            b = local_number();
            tn.setPhoneNumber(b);
            if (lexer.hasMoreChars()) {
                Token tok = this.lexer.peekNextToken();
                switch (tok.getTokenType()) {
                    case SEMICOLON:
                        {
                        	if (inBrackets) {
                        		this.lexer.consume(1);
                        		nv = tel_parameters();
                        		tn.setParameters(nv);
                        	}
                            break;
                        }
                    default :
                        {
                            break;
                        }
                }
            }
        } finally {
            if (debug)
                dbg_leave("local_phone_number");
        }
        return tn;
    }

    private NameValueList tel_parameters() throws ParseException {
        NameValueList nvList = new NameValueList();

        // JvB: Need to handle 'phone-context' specially
        // 'isub' (or 'ext') MUST appear first, but we accept any order here
        NameValue nv;
        while ( true ) {
            String pname = paramNameOrValue();

            // Handle 'phone-context' specially, it may start with '+'
            if ( pname.equalsIgnoreCase("phone-context")) {
                nv = phone_context();
            } else {
                if (lexer.lookAhead(0) == '=') {
                    lexer.consume(1);
                    String value = paramNameOrValue();
                    nv = new NameValue( pname, value, false );
                } else {
                    nv = new NameValue( pname, "", true );// flag param
                }
            }
            nvList.set( nv );

            if ( lexer.lookAhead(0) == ';' ) {
                lexer.consume(1);
            } else {
                return nvList;
            }
        }

    }

    /**
     * Parses the 'phone-context' parameter in tel: URLs
     * @throws ParseException
     */
    private NameValue phone_context() throws ParseException {
        lexer.match('=');

        char la = lexer.lookAhead(0);
        Object value;
        if (la=='+') {// global-number-digits
            lexer.consume(1);// skip '+'
            value = "+" + base_phone_number();
        } else if ( Lexer.isAlphaDigit(la) ) {
            Token t = lexer.match( Lexer.ID );// more broad than allowed
            value = t.getTokenValue();
        } else {
            throw new ParseException( "Invalid phone-context:" + la , -1 );
        }
        return new NameValue( "phone-context", value, false );
    }

    /**
     * Parse and return a structure for a Tel URL.
     * @return a parsed tel url structure.
     */
    public TelURLImpl telURL( boolean inBrackets ) throws ParseException {
        lexer.match(TokenTypes.TEL);
        lexer.match(':');
        TelephoneNumber tn = this.parseTelephoneNumber(inBrackets);
        TelURLImpl telUrl = new TelURLImpl();
        telUrl.setTelephoneNumber(tn);
        return telUrl;

    }

    /**
     * Parse and return a structure for a SIP URL.
     * @return a URL structure for a SIP url.
     * @throws ParseException if there was a problem parsing.
     */
    public SipUri sipURL( boolean inBrackets ) throws ParseException {
        if (debug)
            dbg_enter("sipURL");
        SipUri retval = new SipUri();
        // pmusgrave - handle sips case
        Token nextToken = lexer.peekNextToken();
        int sipOrSips = TokenTypes.SIP;
        String scheme = TokenNames.SIP;
        if ( nextToken.getTokenType() == TokenTypes.SIPS)
        {
            sipOrSips = TokenTypes.SIPS;
            scheme = TokenNames.SIPS;
        }

        try {
            lexer.match(sipOrSips);
            lexer.match(':');
            retval.setScheme(scheme);
            int startOfUser = lexer.markInputPosition();
            String userOrHost = user();// Note: user may contain ';', host may not...
            String passOrPort = null;

            // name:password or host:port
            if ( lexer.lookAhead() == ':' ) {
                lexer.consume(1);
                passOrPort = password();
            }

            // name@hostPort
            if ( lexer.lookAhead() == '@' ) {
                lexer.consume(1);
                retval.setUser( userOrHost );
                if (passOrPort!=null) retval.setUserPassword( passOrPort );
            } else {
                // then userOrHost was a host, backtrack just in case a ';' was eaten...
                lexer.rewindInputPosition( startOfUser );
            }

            HostNameParser hnp = new HostNameParser(this.getLexer());
            HostPort hp = hnp.hostPort( false );
            retval.setHostPort(hp);

            lexer.selectLexer("charLexer");
            while (lexer.hasMoreChars()) {
            	// If the URI is not enclosed in brackets, parameters belong to header
                if (lexer.lookAhead(0) != ';' || !inBrackets)
                    break;
                lexer.consume(1);
                NameValue parms = uriParam();
                if (parms != null) retval.setUriParameter(parms);
            }

            if (lexer.hasMoreChars() && lexer.lookAhead(0) == '?') {
                lexer.consume(1);
                while (lexer.hasMoreChars()) {
                    NameValue parms = qheader();
                    retval.setQHeader(parms);
                    if (lexer.hasMoreChars() && lexer.lookAhead(0) != '&')
                        break;
                    else
                        lexer.consume(1);
                }
            }
            return retval;
        } finally {
            if (debug)
                dbg_leave("sipURL");
        }
    }

    public String peekScheme() throws ParseException {
        Token[] tokens = lexer.peekNextToken(1);
        if (tokens.length == 0)
            return null;
        String scheme = ((Token) tokens[0]).getTokenValue();
        return scheme;
    }

    /**
     * Get a name value for a given query header (ie one that comes
     * after the ?).
     */
    protected NameValue qheader() throws ParseException {
        String name = lexer.getNextToken('=');
        lexer.consume(1);
        String value = hvalue();
        return new NameValue(name, value, false);

    }

    protected String hvalue() throws ParseException {
        StringBuffer retval = new StringBuffer();
        while (lexer.hasMoreChars()) {
            char la = lexer.lookAhead(0);
            // Look for a character that can terminate a URL.
            boolean isValidChar = false;
            switch (la) {
                case '+':
                case '?':
                case ':':
                case '[':
                case ']':
                case '/':
                case '$':
                case '_':
                case '-':
                case '"':
                case '!':
                case '~':
                case '*':
                case '.':
                case '(':
                case ')':
                    isValidChar = true;
            }
            if (isValidChar || Lexer.isAlphaDigit(la)) {
                lexer.consume(1);
                retval.append(la);
            } else if (la == '%') {
                retval.append(escaped());
            } else
                break;
        }
        return retval.toString();
    }

    /**
     * Scan forward until you hit a terminating character for a URL.
     * We do not handle non sip urls in this implementation.
     * @return the string that takes us to the end of this URL (i.e. to
     * the next delimiter).
     */
    protected String urlString() throws ParseException {
        StringBuffer retval = new StringBuffer();
        lexer.selectLexer("charLexer");

        while (lexer.hasMoreChars()) {
            char la = lexer.lookAhead(0);
            // Look for a character that can terminate a URL.
            if (la == ' '
                || la == '\t'
                || la == '\n'
                || la == '>'
                || la == '<')
                break;
            lexer.consume(0);
            retval.append(la);
        }
        return retval.toString();
    }

    protected String user() throws ParseException {
        if (debug)
            dbg_enter("user");
        try {
            int startIdx = lexer.getPtr();
            while (lexer.hasMoreChars()) {
                char la = lexer.lookAhead(0);
                if (isUnreserved(la) || isUserUnreserved(la)) {
                    lexer.consume(1);
                } else if (isEscaped()) {
                    lexer.consume(3);
                } else
                    break;
            }
            return lexer.getBuffer().substring(startIdx, lexer.getPtr());
        } finally {
            if (debug)
                dbg_leave("user");
        }

    }

    protected String password() throws ParseException {
        int startIdx = lexer.getPtr();
        while (true) {
            char la = lexer.lookAhead(0);
            boolean isValidChar = false;
            switch (la) {
                case '&':
                case '=':
                case '+':
                case '$':
                case ',':
                    isValidChar = true;
            }
            if (isValidChar || isUnreserved(la)) {
                lexer.consume(1);
            } else if (isEscaped()) {
                lexer.consume(3); // bug reported by
                                // Jeff Haynie
            } else
                break;

        }
        return lexer.getBuffer().substring(startIdx, lexer.getPtr());
    }

    /**
     * Default parse method. This method just calls uriReference.
     */
    public GenericURI parse() throws ParseException {
        return uriReference( true );
    }

    // quick test routine for debugging type assignment
    public static void main(String[] args) throws ParseException
    {
        // quick test for sips parsing
        String[] test = { "sip:alice@example.com",
                    "sips:alice@examples.com" ,
                    "sip:3Zqkv5dajqaaas0tCjCxT0xH2ZEuEMsFl0xoasip%3A%2B3519116786244%40siplab.domain.com@213.0.115.163:7070"};

        for ( int i = 0; i < test.length; i++)
        {
            URLParser p  = new URLParser(test[i]);

                GenericURI uri = p.parse();
                System.out.println("uri type returned " + uri.getClass().getName());
                System.out.println(test[i] + " is SipUri? " + uri.isSipURI()
                        + ">" + uri.encode());
        }
    }

    /**

    **/
}

