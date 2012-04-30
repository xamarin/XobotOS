package gov.nist.javax.sip.parser.extensions;

import gov.nist.javax.sip.header.*;
import gov.nist.javax.sip.header.extensions.*;
import gov.nist.javax.sip.parser.*;

import java.text.ParseException;
import javax.sip.*;

/**
 * Parser for SIP MinSE Parser.
 *
 *    Min-SE  =  "Min-SE" HCOLON delta-seconds *(SEMI generic-param)
 *
 * @author P. Musgrave <pmusgrave@newheights.com>
 *
 * <a href="{@docRoot}/uncopyright.html">This code is in the public domain.</a>
 */
public class MinSEParser extends ParametersParser {

    /**
     * protected constructor.
     * @param text is the text of the header to parse
     */
    public MinSEParser(String text) {
        super(text);
    }

    /**
     * constructor.
     * @param lexer is the lexer passed in from the enclosing parser.
     */
    protected MinSEParser(Lexer lexer) {
        super(lexer);
    }

    /**
     * Parse the header.
     */
    public SIPHeader parse() throws ParseException {
        MinSE minse = new MinSE();
        if (debug)
            dbg_enter("parse");
        try {
            headerName(TokenTypes.MINSE_TO);

            String nextId = lexer.getNextId();
            try {
                int delta = Integer.parseInt(nextId);
                minse.setExpires(delta);
            } catch (NumberFormatException ex) {
                throw createParseException("bad integer format");
            } catch (InvalidArgumentException ex) {
                throw createParseException(ex.getMessage());
            }
            this.lexer.SPorHT();
            super.parse(minse);
            return minse;

        } finally {
            if (debug)
                dbg_leave("parse");
        }

    }

    public static void main(String args[]) throws ParseException {
        String to[] =
            {   "Min-SE: 30\n",
                "Min-SE: 45;some-param=somevalue\n",
            };

        for (int i = 0; i < to.length; i++) {
            MinSEParser tp = new MinSEParser(to[i]);
            MinSE t = (MinSE) tp.parse();
            System.out.println("encoded = " + t.encode());
            System.out.println("\ntime=" + t.getExpires() );
            if ( t.getParameter("some-param") != null)
                System.out.println("some-param=" + t.getParameter("some-param") );

        }
    }




}
