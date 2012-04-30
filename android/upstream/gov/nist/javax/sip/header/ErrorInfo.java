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

import gov.nist.javax.sip.address.*;
import javax.sip.header.*;
import javax.sip.address.*;
import java.text.ParseException;

/**
 * ErrorInfo SIP Header.
 *
 * @version 1.2 $Revision: 1.6 $ $Date: 2009/07/17 18:57:30 $
 * @since 1.1
 *
 * @author M. Ranganathan   <br/>
 * @author Olivier Deruelle <br/>
 *
 */
public final class ErrorInfo
    extends ParametersHeader
    implements ErrorInfoHeader {

    /**
     * Comment for <code>serialVersionUID</code>
     */
    private static final long serialVersionUID = -6347702901964436362L;

    protected GenericURI errorInfo;

    /**
     * Default constructor.
     */
    public ErrorInfo() {
        super(NAME);
    }

    /**
     * Constructor given the error info
     * @param errorInfo -- the error information to set.
     */
    public ErrorInfo(GenericURI errorInfo) {
        this();
        this.errorInfo = errorInfo;
    }

    /**
     * Encode into canonical form.
     * @return String
     */
    public String encodeBody() {
        StringBuffer retval =
            new StringBuffer(LESS_THAN).append(errorInfo.toString()).append(
                GREATER_THAN);
        if (!parameters.isEmpty()) {
            retval.append(SEMICOLON).append(parameters.encode());
        }
        return retval.toString();
    }

    /**
     * Sets the ErrorInfo of the ErrorInfoHeader to the <var>errorInfo</var>
     * parameter value.
     *
     * @param errorInfo the new ErrorInfo of this ErrorInfoHeader.
     */
    public void setErrorInfo(javax.sip.address.URI errorInfo) {
        this.errorInfo = (GenericURI) errorInfo;

    }

    /**
     * Returns the ErrorInfo value of this ErrorInfoHeader. This message
     * may return null if a String message identifies the ErrorInfo.
     *
     * @return the URI representing the ErrorInfo.
     */
    public URI getErrorInfo() {
        return errorInfo;
    }

    /**
     * Sets the Error information message to the new <var>message</var> value
     * supplied to this method.
     *
     * @param message - the new string value that represents the error message.
     * @throws ParseException which signals that an error has been reached
     * unexpectedly while parsing the error message.
     */
    public void setErrorMessage(String message) throws ParseException {
        if (message == null)
            throw new NullPointerException(
                "JAIN-SIP Exception "
                    + ", ErrorInfoHeader, setErrorMessage(), the message parameter is null");
        setParameter("message", message);
    }

    /**
     * Get the Error information message of this ErrorInfoHeader.
     *
     * @return the stringified version of the ErrorInfo header.
     */
    public String getErrorMessage() {
        return getParameter("message");
    }

    public Object clone() {
        ErrorInfo retval = (ErrorInfo) super.clone();
        if (this.errorInfo != null)
            retval.errorInfo = (GenericURI) this.errorInfo.clone();
        return retval;
    }
}

