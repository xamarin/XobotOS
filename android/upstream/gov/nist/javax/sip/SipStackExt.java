package gov.nist.javax.sip;

import gov.nist.core.net.AddressResolver;
import gov.nist.javax.sip.clientauthutils.AccountManager;
import gov.nist.javax.sip.clientauthutils.AuthenticationHelper;
import gov.nist.javax.sip.clientauthutils.SecureAccountManager;
import gov.nist.javax.sip.header.extensions.JoinHeader;
import gov.nist.javax.sip.header.extensions.ReplacesHeader;

import java.io.IOException;
import java.net.InetAddress;
import java.net.SocketAddress;
import java.util.Collection;

import javax.sip.Dialog;
import javax.sip.SipStack;
import javax.sip.header.HeaderFactory;

/**
 * SIP Stack extensions to be added to the next spec revision. Only these may be safely used in
 * the interim between now and the next release. SipStackImpl implements this interface.
 * 
 * The following new stack initialization flags are defined (not the gov.nist prefix will be
 * dropped when the spec is updated):
 * 
 * <ul>
 *<li>gov.nist.javax.sip.AUTOMATIC_DIALOG_ERROR_HANDLING
 *<li>gov.nist.javax.sip.IS_BACK_TO_BACK_USER_AGENT
 *<li>gov.nist.javax.sip.DELIVER_TERMINATED_EVENT_FOR_NULL_DIALOG
 *<li>gov.nist.javax.sip.MAX_FORK_TIME_SECONDS 
 * </ul>
 * @author M. Ranganathan
 * 
 */
public interface SipStackExt extends SipStack {

    /**
     * Get the collection of dialogs currently in the Dialog table. This is useful for debugging
     * purposes.
     *
     */
    public Collection<Dialog> getDialogs();

    /**
     * Get the ReferedTo dialog in the Replaces header.
     *
     * @return Dialog object matching the Replaces header, provided it is in an appropriate state
     *         to be replaced, <code>null</code> otherwise
     *
     * @since 2.0
     */
    public Dialog getReplacesDialog(ReplacesHeader replacesHeader);

    /**
     * Get the authentication helper.
     *
     *
     * @param accountManager -- account manager (for fetching credentials).
     * @param headerFactory -- header factory.
     *
     * @return - the authentication helper which can be used for generating the appropriate
     *         headers for handling authentication challenges for user agents.
     *
     * @since 2.0
     */
    public AuthenticationHelper getAuthenticationHelper(AccountManager accountManager,
            HeaderFactory headerFactory);
    
    /**
     * Get the authentication helper.
     *
     *
     * @param accountManager -- account manager (for fetching credentials).
     * @param headerFactory -- header factory.
     *
     * @return - the authentication helper which can be used for generating the appropriate
     *         headers for handling authentication challenges for user agents.
     *
     * @since 2.0
     */
    public AuthenticationHelper getSecureAuthenticationHelper(SecureAccountManager accountManager,
            HeaderFactory headerFactory);

    /**
     * Set the address resolution interface. The address resolver allows you to register custom
     * lookup schemes ( for example DNS SRV lookup ) that are not directly supported by the JDK.
     *
     * @param addressResolver -- the address resolver to set.
     *
     * @since 2.0
     */
    public void setAddressResolver(AddressResolver addressResolver);

    /**
     * Get the dialog in the Join header.
     *
     * @return Dialog object matching the Join header, provided it is in an appropriate state to
     *         be replaced, <code>null</code> otherwise
     *
     * @since 2.0
     */
    public Dialog getJoinDialog(JoinHeader joinHeader);

    /**
     * Set the list of cipher suites supported by the stack. A stack can have only one set of
     * suites. These are not validated against the supported cipher suites of the java runtime, so
     * specifying a cipher here does not guarantee that it will work.<br>
     * The stack has a default cipher suite of:
     * <ul>
     * <li> TLS_RSA_WITH_AES_128_CBC_SHA </li>
     * <li> SSL_RSA_WITH_3DES_EDE_CBC_SHA </li>
     * <li> TLS_DH_anon_WITH_AES_128_CBC_SHA </li>
     * <li> SSL_DH_anon_WITH_3DES_EDE_CBC_SHA </li>
     * </ul>
     *
     * <b>NOTE: This function must be called before adding a TLS listener</b>
     *
     * @since 2.0
     * @param newCipherSuites -- The new set of ciphers to support.
     *
     */
    public void setEnabledCipherSuites(String[] newCipherSuites);

    /**
     * Creates and binds, if necessary, a TCP socket connected to the specified
     * destination address and port and then returns its local address.
     *
     * @param dst the destination address that the socket would need to connect
     *            to.
     * @param dstPort the port number that the connection would be established
     * with.
     * @param localAddress the address that we would like to bind on
     * (null for the "any" address).
     * @param localPort the port that we'd like our socket to bind to (0 for a
     * random port).
     *
     * @return the SocketAddress that this handler would use when connecting to
     * the specified destination address and port.
     *
     * @throws IOException
     */
    public SocketAddress obtainLocalAddress(InetAddress dst, int dstPort,
                    InetAddress localAddress, int localPort)
        throws IOException;

}
