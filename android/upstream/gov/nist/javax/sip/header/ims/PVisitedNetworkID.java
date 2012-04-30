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

import javax.sip.header.ExtensionHeader;
import javax.sip.header.Parameters;

import gov.nist.core.Token;

/**
 * P-Visited-Network-ID SIP Private Header: RFC 3455.
 *
 *
 * @author ALEXANDRE MIGUEL SILVA SANTOS - Nú 10045401
 */



public class PVisitedNetworkID
    extends gov.nist.javax.sip.header.ParametersHeader
    implements PVisitedNetworkIDHeader, SIPHeaderNamesIms, ExtensionHeader {

    /**
     * visited Network ID
     */
    private String networkID;

    // issued by Miguel Freitas
    private boolean isQuoted;


    public PVisitedNetworkID() {

        super(P_VISITED_NETWORK_ID);

    }

    public PVisitedNetworkID(String networkID) {

        super(P_VISITED_NETWORK_ID);
        setVisitedNetworkID(networkID);

    }

    public PVisitedNetworkID(Token tok) {

        super(P_VISITED_NETWORK_ID);
        setVisitedNetworkID(tok.getTokenValue());

    }

    protected String encodeBody() {

        StringBuffer retval = new StringBuffer();

        if (getVisitedNetworkID() != null)
        {
            // issued by Miguel Freitas
            if (isQuoted)
                retval.append(DOUBLE_QUOTE + getVisitedNetworkID() + DOUBLE_QUOTE);
            else
                retval.append(getVisitedNetworkID());
        }

        if (!parameters.isEmpty())
            retval.append(SEMICOLON + this.parameters.encode());

        return retval.toString();

    }

    /**
     * Set the visited network ID as a string. The value will be quoted in the header.
     * @param networkID - string value
     */
    public void setVisitedNetworkID(String networkID) {
        if (networkID == null)
            throw new NullPointerException(" the networkID parameter is null");

        this.networkID = networkID;

        // issued by Miguel Freitas
        this.isQuoted = true;
    }

    /**
     * Set the visited network ID as a token
     * @param networkID - token value
     */
    public void setVisitedNetworkID(Token networkID) {
        if (networkID == null)
            throw new NullPointerException(" the networkID parameter is null");

        this.networkID = networkID.getTokenValue();

        // issued by Miguel Freitas
        this.isQuoted = false;
    }

    /**
     * Get the visited network ID value of this header
     */
    public String getVisitedNetworkID() {
        return networkID;
    }


    public void setValue(String value) throws ParseException {
        throw new ParseException (value,0);

    }


    public boolean equals(Object other)
    {
        if (other instanceof PVisitedNetworkIDHeader)
        {
            PVisitedNetworkIDHeader o = (PVisitedNetworkIDHeader) other;
            return (this.getVisitedNetworkID().equals( o.getVisitedNetworkID() )
                && this.equalParameters( (Parameters) o ));
        }
        return false;
    }


    public Object clone() {
        PVisitedNetworkID retval = (PVisitedNetworkID) super.clone();
        if (this.networkID != null)
            retval.networkID = this.networkID;
        retval.isQuoted = this.isQuoted;
        return retval;
    }


}
