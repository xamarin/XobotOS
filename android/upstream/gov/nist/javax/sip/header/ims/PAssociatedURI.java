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
* of the terms of this agreement
*
* .
*
*/

/****************************************************************************
 * PRODUCT OF PT INOVACAO - EST DEPARTMENT and Aveiro University (Portugal) *
 ****************************************************************************/

package gov.nist.javax.sip.header.ims;


import java.text.ParseException;

import gov.nist.javax.sip.address.AddressImpl;
import gov.nist.javax.sip.address.GenericURI;
import javax.sip.address.URI;
import javax.sip.header.ExtensionHeader;

import gov.nist.javax.sip.header.ims.PAssociatedURIHeader;


/**
 * <p>P-Associated-URI SIP Private Header. </p>
 * <p>An associated URI is a URI that the service provider
 * has allocated to a user for his own usage (address-of-record). </p>
 *
 * <p>sintax (RFC 3455): </p>
 * <pre>
 * P-Associated-URI  = "P-Associated-URI" HCOLON
 *                    (p-aso-uri-spec) *(COMMA p-aso-uri-spec)
 * p-aso-uri-spec    = name-addr *(SEMI ai-param)
 * ai-param          = generic-param
 * name-addr         =   [display-name] angle-addr
 * angle-addr        =   [CFWS] "<" addr-spec ">" [CFWS] / obs-angle-addr
 * </pre>
 *
 * @author Miguel Freitas (IT) PT-Inovacao
 */


public class PAssociatedURI
    extends gov.nist.javax.sip.header.AddressParametersHeader
    implements PAssociatedURIHeader, SIPHeaderNamesIms, ExtensionHeader
{
    // TODO: Need a unique UID


    /**
     * Default Constructor
     */
    public PAssociatedURI()
    {
        super(PAssociatedURIHeader.NAME);
    }

    /**
     * Constructor
     * @param address to be set in the header
     */
    public PAssociatedURI(AddressImpl address)
    {
        super(PAssociatedURIHeader.NAME);
        this.address = address;
    }

    /**
     * Constructor
     * @param associatedURI - GenericURI to be set in the address of this header
     */
    public PAssociatedURI(GenericURI associatedURI)
    {
        super(PAssociatedURIHeader.NAME);
        this.address = new AddressImpl();
        this.address.setURI(associatedURI);
    }




    /**
     * Encode into canonical form.
     * @return String containing the canonicaly encoded header.
     */
    public String encodeBody()
    {
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


    /**
     * <p>Set the URI on this address</p>
     * @param associatedURI - GenericURI to be set in the address of this header
     * @throws NullPointerException when supplied URI is null
     */
    public void setAssociatedURI(URI associatedURI) throws NullPointerException
    {
        if (associatedURI == null)
            throw new NullPointerException("null URI");

        this.address.setURI(associatedURI);
    }

    /**
     * <p>Get the address's URI</p>
     * @return URI set in the address of this header
     */
    public URI getAssociatedURI() {
        return this.address.getURI();
    }


    public Object clone() {
        PAssociatedURI retval = (PAssociatedURI) super.clone();
        if (this.address != null)
            retval.address = (AddressImpl) this.address.clone();
        return retval;
    }


    public void setValue(String value) throws ParseException{
        // not implemented
        throw new ParseException(value,0);

    }

}
