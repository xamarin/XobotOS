/*
* Conditions Of Use
*
* This software was developed by employees of the National Institute of
* Standards and Technology (NIST), an agency of the Federal Government,
* and others.
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
/*******************************************
 * PRODUCT OF PT INOVACAO - EST DEPARTMENT   *
 *******************************************/

package gov.nist.javax.sip.header.ims;


import gov.nist.javax.sip.header.SIPHeaderList;


/**
 * List of P-Asserted-Identity headers
 *
 * @author Miguel Freitas (IT) PT-Inovacao
 */

/*
 * PAssertedID = "P-Asserted-Identity" HCOLON PAssertedID-value
 *               *(COMMA PAssertedID-value)
 * PAssertedID-value = name-addr / addr-spec
 */


public class PAssertedIdentityList extends SIPHeaderList<PAssertedIdentity> {

    private static final long serialVersionUID = -6465152445570308974L;


    /**
     * constructor.
     */
    public PAssertedIdentityList()
    {
        super(PAssertedIdentity.class, PAssertedIdentityHeader.NAME);
    }


    public Object clone() {
        PAssertedIdentityList retval = new PAssertedIdentityList();
        return retval.clonehlist(this.hlist);
    }
}
