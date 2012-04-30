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
/*******************************************
 * PRODUCT OF PT INOVACAO - EST DEPARTMENT *
 *******************************************/

package gov.nist.javax.sip.header.ims;

import java.text.ParseException;
import javax.sip.header.WWWAuthenticateHeader;



/**
 * Extension to WWW-authenticate header (3GPP TS 24229-5d0).
 *
 * <p>Defines a new authentication parameter (auth-param) for the WWW-Authenticate header
 * used in a 401 (Unauthorized) response to the REGISTER request.
 * For more information, see RFC 2617 [21] subclause 3.2.1.</p>
 *
 * <pre>
 *  auth-param = 1#( integrity-key / cipher-key )
 *  integrity-key = "ik" EQUAL ik-value
 *  cipher-key = "ck" EQUAL ck-value
 *  ik-value = LDQUOT *(HEXDIG) RDQUOT
 *  ck-value = LDQUOT *(HEXDIG) RDQUOT
 * </pre>
 *
 * @author ALEXANDRE MIGUEL SILVA SANTOS - Nú 10045401
 */


public interface WWWAuthenticateHeaderIms extends WWWAuthenticateHeader
{
    // issued by Miguel Freitas
    public static final String IK = ParameterNamesIms.IK;
    public static final String CK = ParameterNamesIms.CK;


    public void setIK(String ik) throws ParseException;

    public String getIK();

    public void setCK(String ck) throws ParseException;

    public String getCK();

}
