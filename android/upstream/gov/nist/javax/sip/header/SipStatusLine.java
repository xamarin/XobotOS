package gov.nist.javax.sip.header;

/**
 * The SIP Status line.
 * 
 * @since 2.0
 */
public interface SipStatusLine {

    /** get the Sip Version
     * @return SipVersion
     */
    public abstract String getSipVersion();

    /** get the Status Code
     * @return StatusCode
     */
    public abstract int getStatusCode();

    /** get the ReasonPhrase field
     * @return  ReasonPhrase field
     */
    public abstract String getReasonPhrase();

    /**
     * Set the sipVersion member
     * @param sipVersion String to set
     */
    public abstract void setSipVersion(String sipVersion);

    /**
     * Set the statusCode member
     * @param statusCode int to set
     */
    public abstract void setStatusCode(int statusCode);

    /**
     * Set the reasonPhrase member
     * @param reasonPhrase String to set
     */
    public abstract void setReasonPhrase(String reasonPhrase);

    /**
     * Get the major version number.
     *@return String major version number
     */
    public abstract String getVersionMajor();

    /**
     * Get the minor version number.
     *@return String minor version number
     */
    public abstract String getVersionMinor();

}
