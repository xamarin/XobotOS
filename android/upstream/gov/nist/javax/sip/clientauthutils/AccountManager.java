package gov.nist.javax.sip.clientauthutils;

import javax.sip.ClientTransaction;

public interface AccountManager {

    /**
     * Returns the user credentials for a given SIP Domain.
     * You can implement any desired method (such as popping up a dialog for example )
     * to retrieve the credentials.
     *
     * @param challengedTransaction - the transaction that is being challenged.
     * @param realm - the realm that is being challenged for which a credential should be
     *         returned.
     * @return -- the user credentials associated with the domain.
     */

    UserCredentials getCredentials(ClientTransaction challengedTransaction, String realm);

}
