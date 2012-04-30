package gov.nist.javax.sip.header;

import javax.sip.address.URI;


/**
 * The SIP Request Line.
 * 
 * @since 2.0
 */
public interface SipRequestLine {

    /** get the Request-URI.
     *
     * @return the request URI
     */
    public abstract URI getUri();

    /**
     * Get the Method
     *
     * @return method string.
     */
    public abstract String getMethod();

    /**
     * Get the SIP version.
     *
     * @return String
     */
    public abstract String getSipVersion();

    /**
     * Set the URI.
     * 
     * @param uri URI to set.
     */
    public abstract void setUri(URI uri);

    /**
     * Set the method member
     *
     * @param method String to set
     */
    public abstract void setMethod(String method);

    /**
     * Set the sipVersion member
     *
     * @param s String to set
     */
    public abstract void setSipVersion(String version);

    /**
     * Get the major verrsion number.
     *
     *@return String major version number
     */
    public abstract String getVersionMajor();

    /**
     * Get the minor version number.
     *
     *@return String minor version number
     *
     */
    public abstract String getVersionMinor();

}
