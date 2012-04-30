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
package gov.nist.javax.sip.address;
import gov.nist.core.*;
import javax.sip.address.*;

/*
 * BUG Fix from Antonis Kadris.
 */
/**
 * Address structure. Imbeds a URI and adds a display name.
 *
 *@author M. Ranganathan   <br/>
 *
 *
 *
 *@version 1.2 $Revision: 1.11 $ $Date: 2009/07/17 18:57:21 $
 *
 */
public final class AddressImpl
    extends NetObject
    implements javax.sip.address.Address {


    private static final long serialVersionUID = 429592779568617259L;

    /** Constant field.
     */
    public static final int NAME_ADDR = 1;

    /** constant field.
     */
    public static final int ADDRESS_SPEC = 2;

    /** Constant field.
     */
    public static final int WILD_CARD = 3;

    protected int addressType;

    /** displayName field
     */
    protected String displayName;

    /** address field
     */
    protected GenericURI address;

    /** Match on the address only.
     * Dont care about the display name.
     */

    public boolean match(Object other) {
        // TODO -- add the matcher;
        if (other == null)
            return true;
        if (!(other instanceof Address))
            return false;
        else {
            AddressImpl that = (AddressImpl) other;
            if (that.getMatcher() != null)
                return that.getMatcher().match(this.encode());
            else if (that.displayName != null && this.displayName == null)
                return false;
            else if (that.displayName == null)
                return address.match(that.address);
            else
                return displayName.equalsIgnoreCase(that.displayName)
                    && address.match(that.address);
        }

    }

    /** Get the host port portion of the address spec.
     *@return host:port in a HostPort structure.
     */
    public HostPort getHostPort() {
        if (!(address instanceof SipUri))
            throw new RuntimeException("address is not a SipUri");
        SipUri uri = (SipUri) address;
        return uri.getHostPort();
    }

    /** Get the port from the imbedded URI. This assumes that a SIP URL
     * is encapsulated in this address object.
     *
     *@return the port from the address.
     *
     */
    public int getPort() {
        if (!(address instanceof SipUri))
            throw new RuntimeException("address is not a SipUri");
        SipUri uri = (SipUri) address;
        return uri.getHostPort().getPort();
    }

    /** Get the user@host:port for the address field. This assumes
     * that the encapsulated object is a SipUri.
     *
     *
     *@return string containing user@host:port.
     */
    public String getUserAtHostPort() {
        if (address instanceof SipUri) {
            SipUri uri = (SipUri) address;
            return uri.getUserAtHostPort();
        } else
            return address.toString();
    }

    /** Get the host name from the address.
     *
     *@return the host name.
     */
    public String getHost() {
        if (!(address instanceof SipUri))
            throw new RuntimeException("address is not a SipUri");
        SipUri uri = (SipUri) address;
        return uri.getHostPort().getHost().getHostname();
    }

    /** Remove a parameter from the address.
     *
     *@param parameterName is the name of the parameter to remove.
     */
    public void removeParameter(String parameterName) {
        if (!(address instanceof SipUri))
            throw new RuntimeException("address is not a SipUri");
        SipUri uri = (SipUri) address;
        uri.removeParameter(parameterName);
    }

    /**
     * Encode the address as a string and return it.
     * @return String canonical encoded version of this address.
     */
    public String encode() {
        return encode(new StringBuffer()).toString();
    }

    public StringBuffer encode(StringBuffer buffer) {
        if (this.addressType == WILD_CARD) {
            buffer.append('*');
        }
        else {
            if (displayName != null) {
                buffer.append(DOUBLE_QUOTE)
                        .append(displayName)
                        .append(DOUBLE_QUOTE)
                        .append(SP);
            }
            if (address != null) {
                if (addressType == NAME_ADDR || displayName != null)
                    buffer.append(LESS_THAN);
                address.encode(buffer);
                if (addressType == NAME_ADDR || displayName != null)
                    buffer.append(GREATER_THAN);
            }
        }
        return buffer;
    }

    public AddressImpl() {
        this.addressType = NAME_ADDR;
    }

    /**
     * Get the address type;
     * @return int
     */
    public int getAddressType() {
        return addressType;
    }

    /**
     * Set the address type. The address can be NAME_ADDR, ADDR_SPEC or
     * WILD_CARD
     *
     * @param atype int to set
     *
     */
    public void setAddressType(int atype) {
        addressType = atype;
    }

    /**
     * get the display name
     *
     * @return String
     *
     */
    public String getDisplayName() {
        return displayName;
    }

    /**
     * Set the displayName member
     *
     * @param displayName String to set
     *
     */
    public void setDisplayName(String displayName) {
        this.displayName = displayName;
        this.addressType = NAME_ADDR;
    }

    /**
     * Set the address field
     *
     * @param address SipUri to set
     *
     */
    public void setAddess(javax.sip.address.URI address) {
        this.address = (GenericURI) address;
    }

    /**
     * hashCode impelmentation
     *
     */
    public int hashCode() {
        return this.address.hashCode();
    }

    /**
     * Compare two address specs for equality.
     *
     * @param other Object to compare this this address
     *
     * @return boolean
     *
     */
    public boolean equals(Object other) {

        if (this==other) return true;

        if (other instanceof Address) {
            final Address o = (Address) other;

            // Don't compare display name (?)
            return this.getURI().equals( o.getURI() );
        }
        return false;
    }

    /** return true if DisplayName exist.
     *
     * @return boolean
     */
    public boolean hasDisplayName() {
        return (displayName != null);
    }

    /** remove the displayName field
     */
    public void removeDisplayName() {
        displayName = null;
    }

    /** Return true if the imbedded URI is a sip URI.
     *
     * @return true if the imbedded URI is a SIP URI.
     *
     */
    public boolean isSIPAddress() {
        return address instanceof SipUri;
    }

    /** Returns the URI address of this Address. The type of URI can be
     * determined by the scheme.
     *
     * @return address parmater of the Address object
     */
    public URI getURI() {
        return this.address;
    }

    /** This determines if this address is a wildcard address. That is
     * <code>Address.getAddress.getUserInfo() == *;</code>
     *
     * @return true if this name address is a wildcard, false otherwise.
     */
    public boolean isWildcard() {
        return this.addressType == WILD_CARD;
    }

    /** Sets the URI address of this Address. The URI can be either a
     * TelURL or a SipURI.
     *
     * @param address - the new URI address value of this NameAddress.
     */
    public void setURI(URI address) {
        this.address = (GenericURI) address;
    }

    /** Set the user name for the imbedded URI.
     *
     *@param user -- user name to set for the imbedded URI.
     */
    public void setUser(String user) {
        ((SipUri) this.address).setUser(user);
    }

    /** Mark this a wild card address type.
     * Also set the SIP URI to a special wild card address.
     */
    public void setWildCardFlag() {
        this.addressType = WILD_CARD;
        this.address = new SipUri();
        ((SipUri)this.address).setUser("*");
    }

    public Object clone() {
        AddressImpl retval = (AddressImpl) super.clone();
        if (this.address != null)
            retval.address = (GenericURI) this.address.clone();
        return retval;
    }

}
