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
package gov.nist.javax.sip.address;
import java.text.ParseException;

import javax.sip.address.URI;

/**
 * Implementation of the URI class. This relies on the 1.4 URI class.
 *
 * @author M. Ranganathan   <br/>
 * @version 1.2 $Revision: 1.10 $ $Date: 2009/11/15 19:50:45 $
 *
 *
 */
public class GenericURI extends NetObject implements javax.sip.address.URI {
    /**
     *
     */
    private static final long serialVersionUID = 3237685256878068790L;
    public static final String SIP = ParameterNames.SIP_URI_SCHEME;
    public static final String SIPS = ParameterNames.SIPS_URI_SCHEME;
    public static final String TEL = ParameterNames.TEL_URI_SCHEME;
    public static final String POSTDIAL = ParameterNames.POSTDIAL;
    public static final String PHONE_CONTEXT_TAG =
        ParameterNames.PHONE_CONTEXT_TAG;
    public static final String ISUB = ParameterNames.ISUB;
    public static final String PROVIDER_TAG = ParameterNames.PROVIDER_TAG;

    /** Imbedded URI
     */
    protected String uriString;

    /**
     * The URI Scheme.
     */
    protected String scheme;

    /** Consturctor
     */
    protected GenericURI() {
    }

    /** Constructor given the URI string
     * @param uriString The imbedded URI string.
     * @throws java.net.URISyntaxException When there is a syntaz error in the imbedded URI.
     */
    public GenericURI(String uriString) throws ParseException {
        try {
            this.uriString = uriString;
            int i = uriString.indexOf(":");
            scheme = uriString.substring(0, i);
        } catch (Exception e) {
            throw new ParseException("GenericURI, Bad URI format", 0);
        }
    }

    /** Encode the URI.
     * @return The encoded URI
     */
    public String encode() {
        return uriString;
    }

    public StringBuffer encode(StringBuffer buffer) {
        return buffer.append(uriString);
    }

    /** Encode this URI.
     * @return The encoded URI
     */
    public String toString() {
        return this.encode();

    }

    /** Returns the value of the "scheme" of
     * this URI, for example "sip", "sips" or "tel".
     *
     * @return the scheme paramter of the URI
     */
    public String getScheme() {
        return scheme;
    }

    /** This method determines if this is a URI with a scheme of
     * "sip" or "sips".
     *
     * @return true if the scheme is "sip" or "sips", false otherwise.
     */
    public boolean isSipURI() {
        return this instanceof SipUri;
    }

    // @Override
    public boolean equals(Object that) {
        if (this==that) return true;
        else if (that instanceof URI) {
            final URI o = (URI) that;

            // This is not sufficient for equality; revert to String equality...
            // return this.getScheme().equalsIgnoreCase( o.getScheme() )
            return this.toString().equalsIgnoreCase( o.toString() );
        }
        return false;
    }

    public int hashCode() {
        return this.toString().hashCode();
    }
}
