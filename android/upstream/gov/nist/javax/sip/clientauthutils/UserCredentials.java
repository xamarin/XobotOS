package gov.nist.javax.sip.clientauthutils;

/**
* The class is used whenever user credentials for a particular realm (site
* server or service) are necessary
* @author Emil Ivov <emcho@dev.java.net>
* @author M. Ranganathan <mranga@dev.java.net>
* @version 1.0
*/

public interface UserCredentials
{
   

   /**
    * Returns the name of the user that these credentials relate to.
    * @return the user name.
    */
   public String getUserName();
   

   /**
    * Returns a password associated with this set of credentials.
    *
    * @return a password associated with this set of credentials.
    */
   public String getPassword();
   
   
   /**
    * Returns the SIP Domain for this username password combination.
    * 
    * @return the sip domain
    */
   public String getSipDomain();
   
   
  
}


