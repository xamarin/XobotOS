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

import java.text.ParseException;

/**
 * Content encoding part of a content encoding header list.
 * @see ContentEncodingList
 *<pre>
 * From HTTP RFC 2616
 *14.11 Content-Encoding
 *
 *   The Content-Encoding entity-header field is used as a modifier to the
 *   media-type. When present, its value indicates what additional content
 *   codings have been applied to the entity-body, and thus what decoding
 *   mechanisms must be applied in order to obtain the media-type
 *   referenced by the Content-Type header field. Content-Encoding is
 *   primarily used to allow a document to be compressed without losing
 *   the identity of its underlying media type.
 *
 *       Content-Encoding  = "Content-Encoding" ":" 1#content-coding
 *
 *   Content codings are defined in section 3.5. An example of its use is
 *
 *       Content-Encoding: gzip
 *
 *   The content-coding is a characteristic of the entity identified by
 *   the Request-URI. Typically, the entity-body is stored with this
 *   encoding and is only decoded before rendering or analogous usage.
 *   However, a non-transparent proxy MAY modify the content-coding if the
 *   new coding is known to be acceptable to the recipient, unless the
 *   "no-transform" cache-control directive is present in the message.
 *
 *   If the content-coding of an entity is not "identity", then the
 *   response MUST include a Content-Encoding entity-header (section
 *   14.11) that lists the non-identity content-coding(s) used.
 *
 *   If the content-coding of an entity in a request message is not
 *   acceptable to the origin server, the server SHOULD respond with a
 *   status code of 415 (Unsupported Media Type).
 *
 *   If multiple encodings have been applied to an entity, the content
 *   codings MUST be listed in the order in which they were applied.
 *   Additional information about the encoding parameters MAY be provided
 *   by other entity-header fields not defined by this specification.
 *</pre>
 *
 * @author M. Ranganathan   <br/>
 * @author Olivier Deruelle <br/>
 * @version 1.2 $Revision: 1.5 $ $Date: 2009/07/17 18:57:29 $
 * @since 1.1
 */
public class ContentEncoding
    extends SIPHeader
    implements javax.sip.header.ContentEncodingHeader {

    /**
     * Comment for <code>serialVersionUID</code>
     */
    private static final long serialVersionUID = 2034230276579558857L;
    /**
     * ContentEncoding field.
     */
    protected String contentEncoding;

    /**
     * Default constructor.
     */
    public ContentEncoding() {
        super(CONTENT_ENCODING);
    }

    /**
     * Constructor.
     * @param enc String to set.
     */
    public ContentEncoding(String enc) {
        super(CONTENT_ENCODING);
        contentEncoding = enc;
    }

    /**
     * Canonical encoding of body of the header.
     * @return  encoded body of the header.
     */
    public String encodeBody() {
        return contentEncoding;
    }

    /**
     * Get the ContentEncoding field.
     * @return String
     */
    public String getEncoding() {
        return contentEncoding;
    }

    /**
     * Set the ConentEncoding field.
     * @param encoding String to set
     */
    public void setEncoding(String encoding) throws ParseException {
        if (encoding == null)
            throw new NullPointerException(
                "JAIN-SIP Exception, " + " encoding is null");
        contentEncoding = encoding;
    }
}
