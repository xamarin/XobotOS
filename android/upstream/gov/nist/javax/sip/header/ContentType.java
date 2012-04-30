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

import javax.sip.header.ContentTypeHeader;
import java.text.ParseException;

/**
*  ContentType SIP Header
* <pre>
*14.17 Content-Type
*
*   The Content-Type entity-header field indicates the media type of the
*   entity-body sent to the recipient or, in the case of the HEAD method,
*   the media type that would have been sent had the request been a GET.
*
*   Content-Type   = "Content-Type" ":" media-type
*
*   Media types are defined in section 3.7. An example of the field is
*
*       Content-Type: text/html; charset=ISO-8859-4
*
*   Further discussion of methods for identifying the media type of an
*   entity is provided in section 7.2.1.
*
* From  HTTP RFC 2616
* </pre>
*
*
*@version 1.2
*
*@author M. Ranganathan   <br/>
*@author Olivier Deruelle <br/>
*@version 1.2 $Revision: 1.7 $ $Date: 2009/07/17 18:57:29 $
*@since 1.1
*
*/
public class ContentType
    extends ParametersHeader
    implements javax.sip.header.ContentTypeHeader {

    /**
     * Comment for <code>serialVersionUID</code>
     */
    private static final long serialVersionUID = 8475682204373446610L;
    /** mediaRange field.
     */
    protected MediaRange mediaRange;

    /** Default constructor.
     */
    public ContentType() {
        super(CONTENT_TYPE);
    }

    /** Constructor given a content type and subtype.
    *@param contentType is the content type.
    *@param contentSubtype is the content subtype
    */
    public ContentType(String contentType, String contentSubtype) {
        this();
        this.setContentType(contentType, contentSubtype);
    }

    /** compare two MediaRange headers.
     * @param media String to set
     * @return int.
     */
    public int compareMediaRange(String media) {
        return (
            mediaRange.type + "/" + mediaRange.subtype).compareToIgnoreCase(
            media);
    }

    /**
     * Encode into a canonical string.
     * @return String.
     */
    public String encodeBody() {
        return encodeBody(new StringBuffer()).toString();
    }

    protected StringBuffer encodeBody(StringBuffer buffer) {
        mediaRange.encode(buffer);
        if (hasParameters()) {
            buffer.append(SEMICOLON);
            parameters.encode(buffer);
        }
        return buffer;
    }

    /** get the mediaRange field.
     * @return MediaRange.
     */
    public MediaRange getMediaRange() {
        return mediaRange;
    }

    /** get the Media Type.
     * @return String.
     */
    public String getMediaType() {
        return mediaRange.type;
    }

    /** get the MediaSubType field.
     * @return String.
     */
    public String getMediaSubType() {
        return mediaRange.subtype;
    }

    /** Get the content subtype.
    *@return the content subtype string (or null if not set).
    */
    public String getContentSubType() {
        return mediaRange == null ? null : mediaRange.getSubtype();
    }

    /** Get the content subtype.
    *@return the content tyep string (or null if not set).
    */

    public String getContentType() {
        return mediaRange == null ? null : mediaRange.getType();
    }

    /** Get the charset parameter.
    */
    public String getCharset() {
        return this.getParameter("charset");
    }

    /**
     * Set the mediaRange member
     * @param m mediaRange field.
     */
    public void setMediaRange(MediaRange m) {
        mediaRange = m;
    }

    /**
    * set the content type and subtype.
    *@param contentType Content type string.
    *@param contentSubType content subtype string
    */
    public void setContentType(String contentType, String contentSubType) {
        if (mediaRange == null)
            mediaRange = new MediaRange();
        mediaRange.setType(contentType);
        mediaRange.setSubtype(contentSubType);
    }

    /**
    * set the content type.
    *@param contentType Content type string.
    */

    public void setContentType(String contentType) throws ParseException {
        if (contentType == null)
            throw new NullPointerException("null arg");
        if (mediaRange == null)
            mediaRange = new MediaRange();
        mediaRange.setType(contentType);

    }

    /** Set the content subtype.
         * @param contentType String to set
         */
    public void setContentSubType(String contentType) throws ParseException {
        if (contentType == null)
            throw new NullPointerException("null arg");
        if (mediaRange == null)
            mediaRange = new MediaRange();
        mediaRange.setSubtype(contentType);
    }

    public Object clone() {
        ContentType retval = (ContentType) super.clone();
        if (this.mediaRange != null)
            retval.mediaRange = (MediaRange) this.mediaRange.clone();
        return retval;
    }

    public boolean equals(Object other) {
        if (other instanceof ContentTypeHeader) {
            final ContentTypeHeader o = (ContentTypeHeader) other;
            return this.getContentType().equalsIgnoreCase( o.getContentType() )
                && this.getContentSubType().equalsIgnoreCase( o.getContentSubType() )
                && equalParameters( o );
        }
        return false;
    }
}

