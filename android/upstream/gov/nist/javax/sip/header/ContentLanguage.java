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

import java.util.Locale;

/**
* ContentLanguage header
* <pre>
*Fielding, et al.            Standards Track                   [Page 118]
*RFC 2616                        HTTP/1.1                       June 1999
*
*  14.12 Content-Language
*
*   The Content-Language entity-header field describes the natural
*   language(s) of the intended audience for the enclosed entity. Note
*   that this might not be equivalent to all the languages used within
*   the entity-body.
*
*       Content-Language  = "Content-Language" ":" 1#language-tag
*
*   Language tags are defined in section 3.10. The primary purpose of
*   Content-Language is to allow a user to identify and differentiate
*   entities according to the user's own preferred language. Thus, if the
*   body content is intended only for a Danish-literate audience, the
*   appropriate field is
*
*       Content-Language: da
*
*   If no Content-Language is specified, the default is that the content
*   is intended for all language audiences. This might mean that the
*   sender does not consider it to be specific to any natural language,
*   or that the sender does not know for which language it is intended.
*
*   Multiple languages MAY be listed for content that is intended for
*   multiple audiences. For example, a rendition of the "Treaty of
*   Waitangi," presented simultaneously in the original Maori and English
*   versions, would call for
*
*       Content-Language: mi, en
*
*   However, just because multiple languages are present within an entity
*   does not mean that it is intended for multiple linguistic audiences.
*   An example would be a beginner's language primer, such as "A First
*   Lesson in Latin," which is clearly intended to be used by an
*   English-literate audience. In this case, the Content-Language would
*   properly only include "en".
*
*   Content-Language MAY be applied to any media type -- it is not
*   limited to textual documents.
*</pre>
* @author M. Ranganathan
* @version 1.2 $Revision: 1.8 $ $Date: 2009/07/17 18:57:29 $
* @since 1.1
*/
public class ContentLanguage
    extends SIPHeader
    implements javax.sip.header.ContentLanguageHeader {

    /**
     * Comment for <code>serialVersionUID</code>
     */
    private static final long serialVersionUID = -5195728427134181070L;
    /** languageTag field.
     */
    protected Locale locale;

    public ContentLanguage() {
        super(CONTENT_LANGUAGE);
    }

    /**
     * Default constructor.
     * @param languageTag String to set
     */
    public ContentLanguage(String languageTag) {
        super(CONTENT_LANGUAGE);
        this.setLanguageTag( languageTag );
    }

    /**
     * Canonical encoding of the  value of the header.
     * @return encoded body of header.
     */
    public String encodeBody() {
        return this.getLanguageTag();
    }

    /** get the languageTag field.
     * @return String
     */
    public String getLanguageTag() {
        // JvB: Need to take sub-tags into account
        if ( "".equals(locale.getCountry())) {
            return locale.getLanguage();
        } else {
            return locale.getLanguage() + '-' + locale.getCountry();
        }
    }

    /** set the languageTag field
     * @param languageTag -- language tag to set.
     */
    public void setLanguageTag(String languageTag) {

        final int slash = languageTag.indexOf('-');
        if (slash>=0) {
            this.locale = new Locale(languageTag.substring(0,slash), languageTag.substring(slash+1) );
        } else {
            this.locale = new Locale(languageTag);
        }
    }

    /**
     * Gets the language value of the ContentLanguageHeader.
     *
     *
     *
     * @return the Locale value of this ContentLanguageHeader
     *
     */
    public Locale getContentLanguage() {
        return locale;
    }

    /**
     * Sets the language parameter of this ContentLanguageHeader.
     *
     * @param language - the new Locale value of the language of
     *
     * ContentLanguageHeader
     *
     */
    public void setContentLanguage(Locale language) {
        this.locale = language;
    }

    public Object clone() {
        ContentLanguage retval = (ContentLanguage) super.clone();
        if (this.locale != null)
            retval.locale = (Locale) this.locale.clone();
        return retval;
    }
}
