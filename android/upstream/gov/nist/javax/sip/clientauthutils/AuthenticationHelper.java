package gov.nist.javax.sip.clientauthutils;

import java.text.ParseException;
import java.util.Collection;

import javax.sip.ClientTransaction;
import javax.sip.InvalidArgumentException;
import javax.sip.SipException;
import javax.sip.SipProvider;
import javax.sip.header.AuthorizationHeader;
import javax.sip.message.Request;
import javax.sip.message.Response;

/**
 * A helper interface that provides useful functionality for clients that need to authenticate
 * with servers.
 *
 * @author Emil Ivov
 * @author Jeroen van Bemmel
 * @author M. Ranganathan
 *
 * @since 2.0
 *
 *
 */
public interface AuthenticationHelper {

    /**
     * Uses securityAuthority to determinie a set of valid user credentials for
     * the specified Response (Challenge) and appends it to the challenged
     * request so that it could be retransmitted.
     *
     *
     *
     * @param challenge
     *            the 401/407 challenge response
     * @param challengedTransaction
     *            the transaction established by the challenged request
     * @param transactionCreator
     *            the JAIN SipProvider that we should use to create the new
     *            transaction.
     * @param cacheTime The amount of time (seconds ) for which the authentication helper
     *      will keep a reference to the generated credentials in a cache.
     *      If you specify -1, then the authentication credentials are cached
     *      until you remove them from the cache. If you choose this option, make sure
     *      you remove the cached headers or you will have a memory leak.
     *
     * @return a transaction containing a re-originated request with the
     *         necessary authorization header.
     * @throws SipException
     *             if we get an exception white creating the new transaction
     * @throws NullPointerException
     *             if an argument or a header is null.
     */
    public abstract ClientTransaction handleChallenge(Response challenge,
            ClientTransaction challengedTransaction,
            SipProvider transactionCreator, int cacheTime ) throws SipException,
             NullPointerException;

    /**
     * Attach authentication headers to the given request. This looks up
     * the credential cache and picks up any stored authentication headers
     * for the given call ID and attaches it to the request.
     * @param request - the request for which we attach the authentication headers.
     */
    public abstract void setAuthenticationHeaders(Request request) ;

    /**
     * Remove cached entry.
     *
     * @param callId -- the call Id for which we want to remove the cached headers.
     *
     */
    public abstract void removeCachedAuthenticationHeaders(String callId);
}
