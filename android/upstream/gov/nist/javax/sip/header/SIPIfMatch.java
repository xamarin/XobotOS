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
* of the terms of this agreement.
*
*/
/*******************************************************************************
* Product of NIST/ITL Advanced Networking Technologies Division (ANTD).        *
*******************************************************************************/
package gov.nist.javax.sip.header;

import javax.sip.header.*;
import java.text.ParseException;

/**
 * the SIP-If-Match header.
 *
 * @author Jeroen van Bemmel<br/>
 * @version 1.2 $Revision: 1.3 $ $Date: 2009/07/17 18:57:38 $
 * @since 1.2
 */
public class SIPIfMatch extends SIPHeader implements SIPIfMatchHeader,ExtensionHeader {

    /**
     * unique serial id
     */
    private static final long serialVersionUID = 3833745477828359730L;

    /**
     * entity tag field
     */
    protected String entityTag;

    /** Default constructor
     */
    public SIPIfMatch() {
        super(NAME);
    }

    public SIPIfMatch(String etag) throws ParseException {
        this();
        this.setETag( etag );
    }

    /**
     * Encode into canonical form.
     * @return String
     */
    public String encodeBody() {
        return entityTag;
    }

    /**
     * get the priority value.
     * @return String
     */
    public String getETag() {
        return entityTag;
    }

    /**
     * Set the priority member
     * @param etag -- the entity tag to set.
     */
    public void setETag(String etag) throws ParseException {
        if (etag == null)
            throw new NullPointerException(
                "JAIN-SIP Exception,"
                    + "SIP-If-Match, setETag(), the etag parameter is null");
        this.entityTag = etag;
    }

    /**
     * For v 1.1 backwards compatibility.
     * @see javax.sip.header.ExtensionHeader#setValue(java.lang.String)
     */
    public void setValue(String value) throws ParseException {
        this.setETag(value);


    }
}
