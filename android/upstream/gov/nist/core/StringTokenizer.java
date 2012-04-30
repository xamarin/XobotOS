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

import java.util.*;
import java.text.ParseException;

/** Base string token splitter.
*
*@version 1.2
*
*@author M. Ranganathan   <br/>
*
*
*
*/

public class StringTokenizer {

    protected String buffer;
    protected int bufferLen;
    protected int ptr;
    protected int savedPtr;

    protected StringTokenizer() {
    }

    public StringTokenizer(String buffer) {
        this.buffer = buffer;
        bufferLen = buffer.length();
        ptr = 0;
    }

    public String nextToken() {
        int startIdx = ptr;

        while (ptr < bufferLen) {
            char c = buffer.charAt(ptr);
            ptr++;
            if (c == '\n') {
                break;
            }
        }

        return buffer.substring(startIdx, ptr);
    }

    public boolean hasMoreChars() {
        return ptr < bufferLen;
    }

    public static boolean isHexDigit(char ch) {
        return (ch >= 'A' && ch <= 'F') ||
               (ch >= 'a' && ch <= 'f') ||
               isDigit(ch);
    }

    public static boolean isAlpha(char ch) {
        if (ch <= 127) {
            return ((ch >= 'a' && ch <= 'z') || (ch >= 'A' && ch <= 'Z'));
        }
        else {
            return Character.isLowerCase(ch) || Character.isUpperCase(ch);
        }
    }

    public static boolean isDigit(char ch) {
        if (ch <= 127) {
            return (ch <= '9' && ch >= '0');
        }
        else {
            return Character.isDigit(ch);
        }
    }

    public static boolean isAlphaDigit(char ch) {
        if (ch <= 127) {
            return (ch >= 'a' && ch <= 'z') ||
                (ch >= 'A' && ch <= 'Z') ||
                (ch <= '9' && ch >= '0');
        }
        else {
            return Character.isLowerCase(ch) ||
                Character.isUpperCase(ch) ||
                Character.isDigit(ch);
        }
    }

    public String getLine() {
        int startIdx = ptr;
        while (ptr < bufferLen && buffer.charAt(ptr) != '\n') {
            ptr++;
        }
        if (ptr < bufferLen && buffer.charAt(ptr) == '\n') {
            ptr++;
        }
        return buffer.substring(startIdx, ptr);
    }

    public String peekLine() {
        int curPos = ptr;
        String retval = this.getLine();
        ptr = curPos;
        return retval;
    }

    public char lookAhead() throws ParseException {
        return lookAhead(0);
    }

    public char lookAhead(int k) throws ParseException {
        // Debug.out.println("ptr = " + ptr);
        try {
            return buffer.charAt(ptr + k);
        }
        catch (IndexOutOfBoundsException e) {
            return '\0';
        }
    }

    public char getNextChar() throws ParseException {
        if (ptr >= bufferLen)
            throw new ParseException(
                buffer + " getNextChar: End of buffer",
                ptr);
        else
            return buffer.charAt(ptr++);
    }

    public void consume() {
        ptr = savedPtr;
    }

    public void consume(int k) {
        ptr += k;
    }

    /** Get a Vector of the buffer tokenized by lines
     */
    public Vector<String> getLines() {
        Vector<String> result = new Vector<String>();
        while (hasMoreChars()) {
            String line = getLine();
            result.addElement(line);
        }
        return result;
    }

    /** Get the next token from the buffer.
    */
    public String getNextToken(char delim) throws ParseException {
        int startIdx = ptr;
        while (true) {
            char la = lookAhead(0);
            if (la == delim)
                break;
            else if (la == '\0')
                throw new ParseException("EOL reached", 0);
            consume(1);
        }
        return buffer.substring(startIdx, ptr);
    }

    /** get the SDP field name of the line
     *  @return String
     */
    public static String getSDPFieldName(String line) {
        if (line == null)
            return null;
        String fieldName = null;
        try {
            int begin = line.indexOf("=");
            fieldName = line.substring(0, begin);
        } catch (IndexOutOfBoundsException e) {
            return null;
        }
        return fieldName;
    }

}

