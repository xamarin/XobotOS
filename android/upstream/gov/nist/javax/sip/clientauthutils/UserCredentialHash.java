package gov.nist.javax.sip.clientauthutils;

/**
 * Interface for those clients that only supply 
 * hash(user:domain:password). This is more secure than simply supplying
 * password because the password cannot be extracted. Implementations
 * tend to prefer to store information in user accounts using such a
 * hash rather than plain text passwords because it offers better security.
 * 
 */
public interface UserCredentialHash {
    
    /**
     * Get the user name.
     * 
     * @return userName
     */
    public String getUserName();
    
    
    /**
     * Get the SipDomain.
     * 
     * @return the SIP Domain.
     */
    public String getSipDomain();
    
    
    /**
     * Get the MD5(userName:sipdomain:password)
     * 
     * @return the MD5 hash of userName:sipDomain:password.
     */
    public String getHashUserDomainPassword();

}
