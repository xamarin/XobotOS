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
/*******************************************************************************
* Product of NIST/ITL Advanced Networking Technologies Division (ANTD).        *
*******************************************************************************/

package gov.nist.javax.sip.header;

import javax.sip.*;
import java.text.ParseException;
import javax.sip.header.*;

/**
 * Retry-After SIP Header.
 *
 * @version 1.2 $Revision: 1.9 $ $Date: 2009/11/04 17:35:55 $
 *
 * @author M. Ranganathan   <br/>
 * @author Olivier Deruelle <br/>
 *
 *
 */
public class RetryAfter extends ParametersHeader implements RetryAfterHeader {

    /**
     * Comment for <code>serialVersionUID</code>
     */
    private static final long serialVersionUID = -1029458515616146140L;

    /** constant DURATION parameter.
     */
    public static final String DURATION = ParameterNames.DURATION;

    /** duration field
     */
    protected Integer retryAfter = new Integer(0);

    /** comment field
     */
    protected String comment;

    /** Default constructor
     */
    public RetryAfter() {
        super(NAME);
    }

    /** Encode body of this into cannonical form.
     * @return encoded body
     */
    public String encodeBody() {
        StringBuffer s = new StringBuffer();
        
        if (retryAfter != null)
            s.append(retryAfter);

        if (comment != null)
            s.append(SP + LPAREN + comment + RPAREN);

        if (!parameters.isEmpty()) {
            s.append(SEMICOLON + parameters.encode());
        }

        return s.toString();
    }

    /** Boolean function
     * @return true if comment exist, false otherwise
     */
    public boolean hasComment() {
        return comment != null;
    }

    /** remove comment field
     */
    public void removeComment() {
        comment = null;
    }

    /** remove duration field
     */
    public void removeDuration() {
        super.removeParameter(DURATION);
    }

    /**
     * Sets the retry after value of the RetryAfterHeader.
     * The retry after value MUST be greater than zero and
     * MUST be less than 2**31.
     *
     * @param retryAfter - the new retry after value of this RetryAfterHeader
     * @throws InvalidArgumentException if supplied value is less than zero.
     *
     */

    public void setRetryAfter(int retryAfter) throws InvalidArgumentException {
        if (retryAfter < 0)
            throw new InvalidArgumentException(
                "invalid parameter " + retryAfter);
        this.retryAfter = Integer.valueOf(retryAfter);
    }

    /**
     * Gets the retry after value of the RetryAfterHeader. This retry after
     * value is relative time.
     *
     * @return the retry after value of the RetryAfterHeader.
     *
     */

    public int getRetryAfter() {
        return retryAfter.intValue();
    }

    /**
     * Gets the comment of RetryAfterHeader.
     *
     * @return the comment of this RetryAfterHeader, return null if no comment
     * is available.
     */

    public String getComment() {
        return comment;
    }

    /**
     * Sets the comment value of the RetryAfterHeader.
     *
     * @param comment - the new comment string value of the RetryAfterHeader.
     * @throws ParseException which signals that an error has been reached
     * unexpectedly while parsing the comment.
     */

    public void setComment(String comment) throws ParseException {
        if (comment == null)
            throw new NullPointerException("the comment parameter is null");
        this.comment = comment;
    }

    /**
     * Sets the duration value of the RetryAfterHeader. The retry after value
     * MUST be greater than zero and MUST be less than 2**31.
     *
     * @param duration - the new duration value of this RetryAfterHeader
     * @throws InvalidArgumentException if supplied value is less than zero.
     *
     */

    public void setDuration(int duration) throws InvalidArgumentException {
        if (duration < 0)
            throw new InvalidArgumentException("the duration parameter is <0");
        this.setParameter(DURATION, duration);
    }

    /**
     * Gets the duration value of the RetryAfterHeader. This duration value
     * is relative time.
     *
     * @return the duration value of the RetryAfterHeader, return zero if not
     * set.
     *
     */

    public int getDuration() {
      if (this.getParameter(DURATION) == null) return -1;
      else return super.getParameterAsInt(DURATION);
    }
}
