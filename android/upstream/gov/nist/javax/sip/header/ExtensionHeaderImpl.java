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
 * A generic extension header for the stack.
 * The input text of the header gets recorded here.
 *
 * @version 1.2 $Revision: 1.5 $ $Date: 2009/07/17 18:57:30 $
 * @since 1.1
 *
 * @author M. Ranganathan   <br/>
 *
 *
 */
public class ExtensionHeaderImpl
    extends SIPHeader
    implements javax.sip.header.ExtensionHeader {

    /**
     * Comment for <code>serialVersionUID</code>
     */
    private static final long serialVersionUID = -8693922839612081849L;

    protected String value;

    /**
     * This was added to allow for automatic cloning of headers.
     */
    public ExtensionHeaderImpl() {
    }

    public ExtensionHeaderImpl(String headerName) {
        super(headerName);
    }

    /**
     * Set the name of the header.
     * @param headerName is the name of the header to set.
     */

    public void setName(String headerName) {
        this.headerName = headerName;
    }

    /**
     * Set the value of the header.
     */
    public void setValue(String value) {
        this.value = value;
    }

    /**
     * Get the value of the extension header.
     * @return the value of the extension header.
     */
    public String getHeaderValue() {
        if (this.value != null) {
            return this.value;
        } else {
            String encodedHdr = null;
            try {
                // Bug fix submitted by Lamine Brahimi
                encodedHdr = this.encode();
            } catch (Exception ex) {
                return null;
            }
            StringBuffer buffer = new StringBuffer(encodedHdr);
            while (buffer.length() > 0 && buffer.charAt(0) != ':') {
                buffer.deleteCharAt(0);
            }
            buffer.deleteCharAt(0);
            this.value = buffer.toString().trim();
            return this.value;
        }
    }

    /**
     * Return the canonical encoding of this header.
     */
    public String encode() {
        return new StringBuffer(this.headerName)
            .append(COLON)
            .append(SP)
            .append(this.value)
            .append(NEWLINE)
            .toString();
    }

    /**
     * Return just the body of this header encoded (leaving out the
     * name and the CRLF at the end).
     */
    public String encodeBody() {
        return this.getHeaderValue();
    }
}
