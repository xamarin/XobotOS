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
/*****************************************************************************
 * PRODUCT OF PT INOVACAO - EST DEPARTMENT and Aveiro University - Portugal)   *
 *****************************************************************************/




package gov.nist.javax.sip.header.ims;

import java.text.ParseException;

import javax.sip.header.ExtensionHeader;
import javax.sip.header.Parameters;

import gov.nist.core.NameValueList;
import gov.nist.javax.sip.header.SIPHeader;

/**
 * Privacy SIP header - RFC 3323.
 *
 * @author Miguel Freitas (IT) PT-Inovacao
 */


public class Privacy
    extends SIPHeader
    implements PrivacyHeader, SIPHeaderNamesIms, ExtensionHeader
{

    /**
     * Privacy type
     */
    private String privacy;


    /**
     * Default constructor.
     */
    public Privacy() {
        super(PRIVACY);
    }

    /**
     * Constructor given a privacy type
     *@param privacy
     */
    public Privacy(String privacy)
    {
        this();
        this.privacy = privacy;

    }


    /**
     * Encode into a canonical string.
     * @return String.
     */
    public String encodeBody()
    {
        return this.privacy;
    }



    /**
     * Get privacy type
     * @return privacy type
     */
    public String getPrivacy()
    {
        return privacy;
    }



    /**
     * set the privacy type.
     * @param  privacy -- privacy type to set.
     */

    public void setPrivacy(String privacy) throws ParseException
    {

        if (privacy == null || privacy == "")
            throw new NullPointerException(
                "JAIN-SIP Exception, "
                    + " Privacy, setPrivacy(), privacy value is null or empty");
        this.privacy = privacy;

    }

    /**
     * Suppress direct setting of values.
     *
     */
    public void setValue(String value) throws ParseException {
        throw new ParseException(value,0);

    }


    public boolean equals(Object other)
    {
        if (other instanceof PrivacyHeader)
        {
            PrivacyHeader o = (PrivacyHeader) other;
            return (this.getPrivacy().equals( o.getPrivacy() ));
        }
        return false;

    }


    public Object clone() {
        Privacy retval = (Privacy) super.clone();
        if (this.privacy != null)
            retval.privacy = this.privacy;
        return retval;
    }



}
