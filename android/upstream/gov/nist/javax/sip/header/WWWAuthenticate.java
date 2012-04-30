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

import gov.nist.javax.sip.header.ims.WWWAuthenticateHeaderIms;

import javax.sip.address.URI;
import javax.sip.header.*;

/**
 * The WWWAuthenticate SIP header.
 *
 * @version 1.2 $Revision: 1.6 $ $Date: 2009/07/17 18:57:41 $
 *
 *
 *
 * @see WWWAuthenticateList SIPHeader which strings these together.
 */

public class WWWAuthenticate
    extends AuthenticationHeader
    implements WWWAuthenticateHeader, WWWAuthenticateHeaderIms {

    /**
     * Comment for <code>serialVersionUID</code>
     */
    private static final long serialVersionUID = 115378648697363486L;

    /**
     * Default Constructor.
     */
    public WWWAuthenticate() {
        super(NAME);
    }

    /* (non-Javadoc)
     * @see gov.nist.javax.sip.header.AuthenticationHeader#getURI()
     *
     * @since 1.2 this method is deprecated, uri is not a valid paramter for this header
     * Fail silently for backwards compatibility
     */
    public URI getURI() {
        return null;
    }

    /* (non-Javadoc)
     * @see gov.nist.javax.sip.header.AuthenticationHeader#setURI(javax.sip.address.URI)
     *
     * @since 1.2 this method is deprecated, uri is not a valid paramter for this header
     * Fail silently for backwards compatibility
     */
    public void setURI(URI uri) {
        // empty, fail silently
    }

}
