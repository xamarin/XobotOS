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

import javax.sip.InvalidArgumentException;
import javax.sip.header.SubscriptionStateHeader;
import java.text.ParseException;

/**
 *SubscriptionState header
 *
 * @version 1.2 $Revision: 1.7 $ $Date: 2009/07/17 18:57:39 $
 *
 * @author Olivier Deruelle <br/>
 *
 *
 */
public class SubscriptionState
    extends ParametersHeader
    implements SubscriptionStateHeader {

    /**
     * Comment for <code>serialVersionUID</code>
     */
    private static final long serialVersionUID = -6673833053927258745L;
    protected int expires;
    protected int retryAfter;
    protected String reasonCode;
    protected String state;

    /** Creates a new instance of SubscriptionState */
    public SubscriptionState() {
        super(SIPHeaderNames.SUBSCRIPTION_STATE);
        expires = -1;
        retryAfter = -1;
    }

    /**
    * Sets the relative expires value of the SubscriptionStateHeader. The
    * expires value MUST be greater than zero and MUST be less than 2**31.
    *
    * @param expires - the new expires value of this SubscriptionStateHeader.
    * @throws InvalidArgumentException if supplied value is less than zero.
    */
    public void setExpires(int expires) throws InvalidArgumentException {
        if (expires < 0)
            throw new InvalidArgumentException(
                "JAIN-SIP "
                    + "Exception, SubscriptionState, setExpires(), the expires parameter is  < 0");
        this.expires = expires;
    }

    /**
     * Gets the expires value of the SubscriptionStateHeader. This expires value is
     * relative time.
     *
     * @return the expires value of the SubscriptionStateHeader.
     */
    public int getExpires() {
        return expires;
    }

    /**
     * Sets the retry after value of the SubscriptionStateHeader. The retry after value
     * MUST be greater than zero and MUST be less than 2**31.
     *
     * @param retryAfter - the new retry after value of this SubscriptionStateHeader
     * @throws InvalidArgumentException if supplied value is less than zero.
     */
    public void setRetryAfter(int retryAfter) throws InvalidArgumentException {
        if (retryAfter <= 0)
            throw new InvalidArgumentException(
                "JAIN-SIP "
                    + "Exception, SubscriptionState, setRetryAfter(), the retryAfter parameter is <=0");
        this.retryAfter = retryAfter;
    }

    /**
     * Gets the retry after value of the SubscriptionStateHeader. This retry after
     * value is relative time.
     *
     * @return the retry after value of the SubscriptionStateHeader.
     */
    public int getRetryAfter() {
        return retryAfter;
    }

    /**
     * Gets the reason code of SubscriptionStateHeader.
     *
     * @return the comment of this SubscriptionStateHeader, return null if no reason code
     * is available.
     */
    public String getReasonCode() {
        return reasonCode;
    }

    /**
     * Sets the reason code value of the SubscriptionStateHeader.
     *
     * @param reasonCode - the new reason code string value of the SubscriptionStateHeader.
     * @throws ParseException which signals that an error has been reached
     * unexpectedly while parsing the reason code.
     */
    public void setReasonCode(String reasonCode) throws ParseException {
        if (reasonCode == null)
            throw new NullPointerException(
                "JAIN-SIP "
                    + "Exception, SubscriptionState, setReasonCode(), the reasonCode parameter is null");
        this.reasonCode = reasonCode;
    }

    /**
     * Gets the state of SubscriptionStateHeader.
     *
     * @return the state of this SubscriptionStateHeader.
     */
    public String getState() {
        return state;
    }

    /**
     * Sets the state value of the SubscriptionStateHeader.
     *
     * @param state - the new state string value of the SubscriptionStateHeader.
     * @throws ParseException which signals that an error has been reached
     * unexpectedly while parsing the state.
     */
    public void setState(String state) throws ParseException {
        if (state == null)
            throw new NullPointerException(
                "JAIN-SIP "
                    + "Exception, SubscriptionState, setState(), the state parameter is null");
        this.state = state;
    }

    /** Just the encoded body of the header.
     * @return the string encoded header body.
     */
    public String encodeBody() {
        return encodeBody(new StringBuffer()).toString();
    }

    protected StringBuffer encodeBody(StringBuffer buffer) {
        if (state != null)
            buffer.append(state);
        if (reasonCode != null)
            buffer.append(";reason=").append(reasonCode);
        if (expires != -1)
            buffer.append(";expires=").append(expires);
        if (retryAfter != -1)
            buffer.append(";retry-after=").append(retryAfter);

        if (!parameters.isEmpty()) {
            buffer.append(SEMICOLON);
            parameters.encode(buffer);
        }
        return buffer;
    }
}

