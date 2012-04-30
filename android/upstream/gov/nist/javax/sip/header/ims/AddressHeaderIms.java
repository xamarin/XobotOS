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
 * PRODUCT OF PT INOVAO - EST DEPARTMENT   *
 *******************************************/

package gov.nist.javax.sip.header.ims;

import javax.sip.address.Address;

import gov.nist.javax.sip.address.AddressImpl;
import gov.nist.javax.sip.header.SIPHeader;

/**
 * AddressHeader base class.
 * @author ALEXANDRE MIGUEL SILVA SANTOS (PT Innovacau)
 */

public abstract class AddressHeaderIms extends SIPHeader {

    protected AddressImpl address;

    /**
     * get the Address field
     * @return the imbedded  Address
     */
    public Address getAddress() {
        return address;
    }

    /**
     * set the Address field
     * @param address Address to set
     */
    public void setAddress(Address address) {
        this.address = (AddressImpl) address;
    }

    public abstract String encodeBody();
    //protected abstract String encodeBody();


    /**
     * Constructor given the name of the header.
     */
    public AddressHeaderIms(String name) {
    //protected AddressHeader(String name) {
        super(name);
    }

    public Object clone() {
        AddressHeaderIms retval = (AddressHeaderIms) super.clone();
        if (this.address != null)
            retval.address = (AddressImpl) this.address.clone();
        return retval;
    }


}

