/*
* Conditions Of Use
*
* This software was developed by employees of the National Institute of
* Standards and Technology (NIST), an agency of the Federal Government
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

import javax.sip.header.ExtensionHeader;

import gov.nist.javax.sip.address.AddressImpl;
import gov.nist.javax.sip.header.ims.PCalledPartyIDHeader;

/**
 * P-Called-Party-ID SIP Private Header.
 *
 * @author ALEXANDRE MIGUEL SILVA SANTOS - Nú 10045401
 */

public class PCalledPartyID
    extends gov.nist.javax.sip.header.AddressParametersHeader
    implements PCalledPartyIDHeader, SIPHeaderNamesIms , ExtensionHeader{

    /**
     * constructor
     * @param address address to set
     */
    public PCalledPartyID(AddressImpl address) {
        super(NAME);
        this.address = address;
    }

    /**
     * default constructor
     */
    public PCalledPartyID() {
        super(CALLED_PARTY_ID);

    }

    /** Encode into canonical form.
     *@return String containing the canonicaly encoded header.
     */
    public String encodeBody() {
        StringBuffer retval = new StringBuffer();
        if (address.getAddressType() == AddressImpl.ADDRESS_SPEC) {
            retval.append(LESS_THAN);
        }
        retval.append(address.encode());
        if (address.getAddressType() == AddressImpl.ADDRESS_SPEC) {
            retval.append(GREATER_THAN);
        }

        if (!parameters.isEmpty())
            retval.append(SEMICOLON + this.parameters.encode());
        return retval.toString();
    }

    public void setValue(String value) throws ParseException {
        // not implemented.
        throw new ParseException(value,0);

    }

}
