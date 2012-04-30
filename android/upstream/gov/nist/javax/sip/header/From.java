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

import gov.nist.core.HostPort;
import gov.nist.javax.sip.address.AddressImpl;
import gov.nist.javax.sip.parser.Parser;

import javax.sip.header.FromHeader;
import java.text.ParseException;

/**
 * From SIP Header.
 *
 * @version 1.2 $Revision: 1.9 $ $Date: 2009/07/17 18:57:31 $
 * @since 1.1
 *
 * @author M. Ranganathan   <br/>
 *
 *
 */
public final class From
    extends AddressParametersHeader
    implements javax.sip.header.FromHeader {

    /**
     * Comment for <code>serialVersionUID</code>
     */
    private static final long serialVersionUID = -6312727234330643892L;

    /** Default constructor
     */
    public From() {
        super(NAME);
    }

    /** Generate a FROM header from a TO header
     */
    public From(To to) {
        super(NAME);
        address = to.address;
        parameters = to.parameters;
    }

    /**
     * Encode the header content into a String.
     *
     * @return String
     */
    protected String encodeBody() {
        return encodeBody(new StringBuffer()).toString();
    }

    protected StringBuffer encodeBody(StringBuffer buffer) {
        if (address.getAddressType() == AddressImpl.ADDRESS_SPEC) {
            buffer.append(LESS_THAN);
        }
        address.encode(buffer);
        if (address.getAddressType() == AddressImpl.ADDRESS_SPEC) {
            buffer.append(GREATER_THAN);
        }
        if (!parameters.isEmpty()) {
            buffer.append(SEMICOLON);
            parameters.encode(buffer);
        }
        return buffer;
    }

    /**
     * Conveniance accessor function to get the hostPort field from the address.
     * Warning -- this assumes that the embedded URI is a SipURL.
     *
     * @return hostport field
     */
    public HostPort getHostPort() {
        return address.getHostPort();
    }

    /**
     * Get the display name from the address.
     * @return Display name
     */
    public String getDisplayName() {
        return address.getDisplayName();
    }

    /**
     * Get the tag parameter from the address parm list.
     * @return tag field
     */
    public String getTag() {
        if (parameters == null)
            return null;
        return getParameter(ParameterNames.TAG);
    }

    /** Boolean function
     * @return true if the Tag exist
     */
    public boolean hasTag() {
        return hasParameter(ParameterNames.TAG);
    }

    /** remove Tag member
     */
    public void removeTag() {
        parameters.delete(ParameterNames.TAG);
    }

    /**
     * Set the address member
     * @param address Address to set
     */
    public void setAddress(javax.sip.address.Address address) {
        this.address = (AddressImpl) address;
    }

    /**
     * Set the tag member
     * @param t tag to set. From tags are mandatory.
     */
    public void setTag(String t) throws ParseException {
        // JvB: check that it is a valid token
        Parser.checkToken(t);
        this.setParameter(ParameterNames.TAG, t);
    }

    /** Get the user@host port string.
     */
    public String getUserAtHostPort() {
        return address.getUserAtHostPort();
    }

    public boolean equals(Object other) {
        return (other instanceof FromHeader) && super.equals(other);
    }

}
