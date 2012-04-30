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
package gov.nist.core;

import java.text.ParseException;

/** Generic parser class.
* All parsers inherit this class.
*
*@version 1.2
*
*@author M. Ranganathan   <br/>
*
*
*
*/
public abstract class ParserCore {
    public static final boolean debug = Debug.parserDebug;

    static int nesting_level;

    protected LexerCore lexer;


    protected NameValue nameValue(char separator) throws ParseException  {
        if (debug) dbg_enter("nameValue");
        try {

        lexer.match(LexerCore.ID);
        Token name = lexer.getNextToken();
        // eat white space.
        lexer.SPorHT();
        try {


                boolean quoted = false;

            char la = lexer.lookAhead(0);

            if (la == separator ) {
                lexer.consume(1);
                lexer.SPorHT();
                String str = null;
                boolean isFlag = false;
                if (lexer.lookAhead(0) == '\"')  {
                     str = lexer.quotedString();
                     quoted = true;
                } else {
                   lexer.match(LexerCore.ID);
                   Token value = lexer.getNextToken();
                   str = value.tokenValue;

                   // JvB: flag parameters must be empty string!
                   if (str==null) {
                       str = "";
                       isFlag = true;
                   }
                }
                NameValue nv = new NameValue(name.tokenValue,str,isFlag);
                if (quoted) nv.setQuotedValue();
                return nv;
            }  else {
                // JvB: flag parameters must be empty string!
                return new NameValue(name.tokenValue,"",true);
            }
        } catch (ParseException ex) {
            return new NameValue(name.tokenValue,null,false);
        }

        } finally {
            if (debug) dbg_leave("nameValue");
        }


    }

    protected  void dbg_enter(String rule) {
        StringBuffer stringBuffer = new StringBuffer();
        for (int i = 0; i < nesting_level ; i++)
            stringBuffer.append(">");

        if (debug)  {
            System.out.println(
                stringBuffer + rule +
                "\nlexer buffer = \n" +
                lexer.getRest());
        }
        nesting_level++;
    }

    protected void dbg_leave(String rule) {
        StringBuffer stringBuffer = new StringBuffer();
        for (int i = 0; i < nesting_level ; i++)
            stringBuffer.append("<");

        if (debug)  {
            System.out.println(
                stringBuffer +
                rule +
                "\nlexer buffer = \n" +
                lexer.getRest());
        }
        nesting_level --;
    }

    protected NameValue nameValue() throws ParseException  {
        return nameValue('=');
    }



    protected void peekLine(String rule) {
        if (debug) {
            Debug.println(rule +" " + lexer.peekLine());
        }
    }
}


