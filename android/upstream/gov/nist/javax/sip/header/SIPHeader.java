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

/**
 * Root class from which all SIPHeader objects are subclassed.
 *
 * @author M. Ranganathan   <br/>
 * @version 1.2 $Revision: 1.7 $ $Date: 2009/07/17 18:57:37 $
 *
 *
 */
public abstract class SIPHeader
    extends SIPObject
    implements SIPHeaderNames, javax.sip.header.Header, HeaderExt {

    /** name of this header
     */
    protected String headerName;

    /** Value of the header.
    */

    /** Constructor
     * @param hname String to set
     */
    protected SIPHeader(String hname) {
        headerName = hname;
    }

    /** Default constructor
     */
    public SIPHeader() {
    }

    /**
     * Name of the SIPHeader
     * @return String
     */
    public String getHeaderName() {
        return headerName;
    }

    /** Alias for getHaderName above.
    *
    *@return String headerName
    *
    */
    public String getName() {
        return this.headerName;
    }

    /**
         * Set the name of the header .
         * @param hdrname String to set
         */
    public void setHeaderName(String hdrname) {
        headerName = hdrname;
    }

    /** Get the header value (i.e. what follows the name:).
    * This merely goes through and lops off the portion that follows
    * the headerName:
    */
    public String getHeaderValue() {
        String encodedHdr = null;
        try {
            encodedHdr = this.encode();
        } catch (Exception ex) {
            return null;
        }
        StringBuffer buffer = new StringBuffer(encodedHdr);
        while (buffer.length() > 0 && buffer.charAt(0) != ':') {
            buffer.deleteCharAt(0);
        }
        if (buffer.length() > 0)
            buffer.deleteCharAt(0);
        return buffer.toString().trim();
    }

    /** Return false if this is not a header list
    * (SIPHeaderList overrrides this method).
    *@return false
    */
    public boolean isHeaderList() {
        return false;
    }

    /** Encode this header into canonical form.
    */
    public String encode() {
        return encode(new StringBuffer()).toString();
    }

    public StringBuffer encode(StringBuffer buffer) {
        buffer.append(this.headerName).append(COLON).append(SP);
        this.encodeBody(buffer);
        buffer.append(NEWLINE);
        return buffer;
    }

    /** Encode the body of this header (the stuff that follows headerName).
    * A.K.A headerValue.
    */
    protected abstract String encodeBody();

    /** Encode the body of this header in the given buffer.
     * Default implementation calls encodeBody();
     */
    protected StringBuffer encodeBody(StringBuffer buffer) {
        return buffer.append(encodeBody());
    }

    /** Alias for getHeaderValue.
     */
    public String getValue() {
        return this.getHeaderValue();
    }

    /**
     * This is a pretty simple hashCode but satisfies requirements.
     *
     */
    public int hashCode() {
        return this.headerName.hashCode();
    }

    public final String toString() {
        return this.encode();
    }
}
