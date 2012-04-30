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
import javax.sip.header.*;
import java.text.ParseException;

/**
 * Accept-Encoding SIP (HTTP) Header.
 *
 * @author M. Ranganathan
 * @author Olivier Deruelle <br/>
 * @version 1.2 $Revision: 1.7 $ $Date: 2009/07/17 18:57:24 $
 * @since 1.1
 *
 * <pre>
 *  From HTTP RFC 2616
 *
 *
 *    The Accept-Encoding request-header field is similar to Accept, but
 *    restricts the content-codings (section 3.5) that are acceptable in
 *    the response.
 *
 *
 *        Accept-Encoding  = &quot;Accept-Encoding&quot; &quot;:&quot;
 *
 *
 *                           1#( codings [ &quot;;&quot; &quot;q&quot; &quot;=&quot; qvalue ] )
 *        codings          = ( content-coding | &quot;*&quot; )
 *
 *    Examples of its use are:
 *
 *        Accept-Encoding: compress, gzip
 *        Accept-Encoding:
 *        Accept-Encoding: *
 *        Accept-Encoding: compress;q=0.5, gzip;q=1.0
 *        Accept-Encoding: gzip;q=1.0, identity; q=0.5, *;q=0
 * </pre>
 *
 */
public final class AcceptEncoding extends ParametersHeader implements
        AcceptEncodingHeader {

    /**
     * Comment for <code>serialVersionUID</code>
     */
    private static final long serialVersionUID = -1476807565552873525L;

    /**
     * contentEncoding field
     */
    protected String contentCoding;

    /**
     * default constructor
     */
    public AcceptEncoding() {
        super(NAME);
    }

    /**
     * Encode the value of this header.
     *
     * @return the value of this header encoded into a string.
     */
    protected String encodeBody() {
        return encode(new StringBuffer()).toString();
    }

    protected StringBuffer encodeBody(StringBuffer buffer) {
        if (contentCoding != null) {
            buffer.append(contentCoding);
        }
        if (parameters != null && !parameters.isEmpty()) {
            buffer.append(SEMICOLON).append(parameters.encode());
        }
        return buffer;
    }

    /**
     * get QValue field
     *
     * @return float
     */
    public float getQValue() {
        return getParameterAsFloat("q");
    }

    /**
     * get ContentEncoding field
     *
     * @return String
     */
    public String getEncoding() {
        return contentCoding;
    }

    /**
     * Set the qvalue member
     *
     * @param q
     *            double to set
     */
    public void setQValue(float q) throws InvalidArgumentException {
        if (q < 0.0 || q > 1.0)
            throw new InvalidArgumentException("qvalue out of range!");
        super.setParameter("q", q);
    }

    /**
     * Sets the encoding of an EncodingHeader.
     *
     * @param encoding -
     *            the new string value defining the encoding.
     * @throws ParseException
     *             which signals that an error has been reached unexpectedly
     *             while parsing the encoding value.
     */

    public void setEncoding(String encoding) throws ParseException {
        if (encoding == null)
            throw new NullPointerException(" encoding parameter is null");
        contentCoding = encoding;
    }

}
