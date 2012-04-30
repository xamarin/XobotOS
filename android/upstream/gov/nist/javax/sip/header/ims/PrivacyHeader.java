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

import javax.sip.header.Header;
import javax.sip.header.Parameters;

/**
 * Privacy Header RFC 3323.
 *
 * <p>Sintax: </p>
 *<pre>
 * Privacy-hdr  = "Privacy" HCOLON priv-value *(";" priv-value)
 * priv-value   = "header" / "session" / "user" /
 *                "id" / "none" / "critical" / token
 * example:
 *           Privacy: id
 * </pre>
 *
 * @author Miguel Freitas (IT) PT-Inovacao
 */


public interface PrivacyHeader extends Header
{

    /**
     * Name of PrivacyHeader
     */
    public final static String NAME = "Privacy";


    /**
     * Set Privacy header value
     * @param  privacy -- privacy type to set.
     */
    public void setPrivacy(String privacy) throws ParseException;

    /**
     * Get Privacy header value
     * @return privacy token name
     */
    public String getPrivacy();


}

