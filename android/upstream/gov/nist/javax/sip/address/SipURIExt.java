package gov.nist.javax.sip.address;

import javax.sip.address.SipURI;

/**
 * URI Interface extensions that will be added to version 2.0 of the JSR 32 spec.
 *
 * @author mranga
 *
 * @since 2.0
 *
 */
public interface SipURIExt extends SipURI {

    /**
     * Strip the headers that are tacked to the URI.
     *
     * @since 2.0
     */
    public void removeHeaders();

    /**
     * Strip a specific header tacked to the URI.
     *
     * @param headerName -- the name of the header.
     *
     * @since 2.0
     */
    public void removeHeader(String headerName);

    /**
     * Returns whether the <code>gr</code> parameter is set.
     *
     * @since 2.0
     */
    public boolean hasGrParam();

    /**
     * Sets the <code>gr</code> parameter.
     *
     * @param value -- the GRUU param value.
     *
     * @since 2.0
     */
    public void setGrParam(String value);

}
