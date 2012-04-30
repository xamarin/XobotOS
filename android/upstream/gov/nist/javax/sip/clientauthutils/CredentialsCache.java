package gov.nist.javax.sip.clientauthutils;

import java.util.*;
import java.util.concurrent.ConcurrentHashMap;

import javax.sip.*;
import javax.sip.header.*;
import javax.sip.address.*;
import javax.sip.message.*;

/**
 * A cache of authorization headers to be used for subsequent processing when we
 * set up calls. We cache credentials on a per proxy domain per user basis.
 *
 */

class CredentialsCache {


    /**
     * The key for this map is the proxy domain name. A given proxy authorizes a
     * user for a number of domains. The Hashtable value of the mapping is a
     * mapping of user names to AuthorizationHeader list for that proxy domain.
     */
    private ConcurrentHashMap<String, List<AuthorizationHeader>> authorizationHeaders =
            new ConcurrentHashMap<String, List<AuthorizationHeader>>();
    private Timer timer;

    class TimeoutTask extends TimerTask {
        String callId;
        String userName;

        public TimeoutTask(String userName, String proxyDomain) {
            this.callId = proxyDomain;
            this.userName = userName;
        }

        @Override
        public void run() {
            authorizationHeaders.remove(callId);

        }

    }



    CredentialsCache (Timer timer) {
        this.timer = timer;
    }

    /**
     * Cache the bindings of proxyDomain and authorization header.
     *
     * @param callid
     *            the id of the call that the <tt>authorization</tt> header
     *            belongs to.
     * @param authorization
     *            the authorization header that we'd like to cache.
     */
    void cacheAuthorizationHeader(String callId,
            AuthorizationHeader authorization, int cacheTime) {
        String user = authorization.getUsername();
        if ( callId == null) throw new NullPointerException("Call ID is null!");
        if ( authorization == null) throw new NullPointerException("Null authorization domain");

        List<AuthorizationHeader> authHeaders = authorizationHeaders.get(callId);
        if (authHeaders == null) {
            authHeaders = new LinkedList<AuthorizationHeader>();
            authorizationHeaders.put(callId, authHeaders);
        } else {
            String realm = authorization.getRealm();
            for (ListIterator<AuthorizationHeader> li = authHeaders.listIterator(); li.hasNext();) {
                AuthorizationHeader authHeader = (AuthorizationHeader) li.next();
                if ( realm.equals(authHeader.getRealm()) ) {
                    li.remove();
                }
            }
        }

        authHeaders.add(authorization);

        TimeoutTask timeoutTask  = new TimeoutTask( callId,user);
        if ( cacheTime != -1)
            this.timer.schedule(timeoutTask, cacheTime*1000);


    }

    /**
     * Returns an authorization header cached for the specified call id and null
     * if no authorization header has been previously cached for this call.
     *
     * @param callid
     *            the call id that we'd like to retrive a cached authorization
     *            header for.
     *
     * @return authorization header corresponding to that user for the given
     *         proxy domain.
     */
    Collection<AuthorizationHeader> getCachedAuthorizationHeaders(
            String callid) {
        if (callid == null)
            throw new NullPointerException("Null arg!");
        return this.authorizationHeaders.get(callid);

    }

    /**
     * Remove a cached authorization header.
     *
     * @param callId
     */
    public void removeAuthenticationHeader(String callId) {
        this.authorizationHeaders.remove(callId);

    }

}
