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
import javax.sip.header.ContentLengthHeader;

/**
* ContentLength SIPHeader (of which there can be only one in a SIPMessage).
*<pre>
*Fielding, et al.            Standards Track                   [Page 119]
*RFC 2616                        HTTP/1.1                       June 1999
*
*
*      14.13 Content-Length
*
*   The Content-Length entity-header field indicates the size of the
*   entity-body, in decimal number of OCTETs, sent to the recipient or,
*   in the case of the HEAD method, the size of the entity-body that
*   would have been sent had the request been a GET.
*
*       Content-Length    = "Content-Length" ":" 1*DIGIT
*
*   An example is
*
*       Content-Length: 3495
*
*   Applications SHOULD use this field to indicate the transfer-length of
*   the message-body, unless this is prohibited by the rules in section
*   4.4.
*
*   Any Content-Length greater than or equal to zero is a valid value.
*   Section 4.4 describes how to determine the length of a message-body
*   if a Content-Length is not given.
*
*   Note that the meaning of this field is significantly different from
*   the corresponding definition in MIME, where it is an optional field
*   used within the "message/external-body" content-type. In HTTP, it
*   SHOULD be sent whenever the message's length can be determined prior
*   to being transferred, unless this is prohibited by the rules in
*   section 4.4.
* </pre>
*
*@author M. Ranganathan   <br/>
*@author Olivier Deruelle <br/>
*@version 1.2 $Revision: 1.7 $ $Date: 2009/10/18 13:46:34 $
*@since 1.1
*/
public class ContentLength
    extends SIPHeader
    implements javax.sip.header.ContentLengthHeader {

    /**
     * Comment for <code>serialVersionUID</code>
     */
    private static final long serialVersionUID = 1187190542411037027L;
    /**
     * contentLength field.
     */
    protected Integer contentLength;

    /**
     * Default constructor.
     */
    public ContentLength() {
        super(NAME);
    }

    /**
     * Constructor given a length.
     */
    public ContentLength(int length) {
        super(NAME);
        this.contentLength = Integer.valueOf(length);
    }

    /**
     * get the ContentLength field.
     * @return int
     */
    public int getContentLength() {
        return contentLength.intValue();
    }

    /**
     * Set the contentLength member
     * @param contentLength int to set
     */
    public void setContentLength(int contentLength)
        throws InvalidArgumentException {
        if (contentLength < 0)
            throw new InvalidArgumentException(
                "JAIN-SIP Exception"
                    + ", ContentLength, setContentLength(), the contentLength parameter is <0");
        this.contentLength = Integer.valueOf(contentLength);
    }

    /**
     * Encode into a canonical string.
     * @return String
     */
    public String encodeBody() {
        return encodeBody(new StringBuffer()).toString();
    }

    protected StringBuffer encodeBody(StringBuffer buffer) {
        if (contentLength == null)
            buffer.append("0");
        else
            buffer.append(contentLength.toString());
        return buffer;
    }

    /**
     * Pattern matcher ignores content length.
     */
    public boolean match(Object other) {
        if (other instanceof ContentLength)
            return true;
        else
            return false;
    }

    public boolean equals(Object other) {
        if (other instanceof ContentLengthHeader) {
            final ContentLengthHeader o = (ContentLengthHeader) other;
            return this.getContentLength() == o.getContentLength();
        }
        return false;
    }
}
