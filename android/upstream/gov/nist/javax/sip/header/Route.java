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
 * Product of NIST/ITL Advanced Networking Technologies Division (ANTD).       *
 ******************************************************************************/
package gov.nist.javax.sip.header;

import gov.nist.javax.sip.address.AddressImpl;

import javax.sip.header.RouteHeader;

/**
 * Route  SIPHeader Object
 *
 * @version 1.2 $Revision: 1.6 $ $Date: 2009/07/17 18:57:36 $
 *
 * @author M. Ranganathan   <br/>
 *
 *
 */
public class Route
    extends AddressParametersHeader
    implements javax.sip.header.RouteHeader {

    /**
     * Comment for <code>serialVersionUID</code>
     */
    private static final long serialVersionUID = 5683577362998368846L;

    /** Default constructor
     */
    public Route() {
        super(NAME);
    }

    /** Default constructor given an address.
     *
     *@param address -- address of this header.
     *
     */

    public Route(AddressImpl address) {
        super(NAME);
        this.address = address;
    }

    /**
     * Hashcode so this header can be inserted into a set.
     *
     *@return the hashcode of the encoded address.
     */
    public int hashCode() {
        return this.address.getHostPort().encode().toLowerCase().hashCode();
    }

    /**
     * Encode into canonical form.
     * Acknowledgement: contains a bug fix for a bug reported by
     * Laurent Schwizer
     *
     *@return a canonical encoding of the header.
     */
    public String encodeBody() {
        return encodeBody(new StringBuffer()).toString();
    }

    protected StringBuffer encodeBody(StringBuffer buffer) {
        boolean addrFlag = address.getAddressType() == AddressImpl.NAME_ADDR;
        if (!addrFlag) {
            buffer.append('<');
            address.encode(buffer);
            buffer.append('>');
        } else {
            address.encode(buffer);
        }
        if (!parameters.isEmpty()) {
            buffer.append(SEMICOLON);
            parameters.encode(buffer);
        }
        return buffer;
    }

    public boolean equals(Object other) {
        return (other instanceof RouteHeader) && super.equals(other);
    }

}

