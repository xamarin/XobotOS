
package gov.nist.javax.sip;

import java.security.cert.Certificate;

import javax.net.ssl.SSLPeerUnverifiedException;
import javax.sip.SipProvider;
import javax.sip.Transaction;

public interface TransactionExt extends Transaction {

    /**
     * Get the Sip Provider associated with this transaction
     */
    public SipProvider getSipProvider();

    /**
     * Returns the IP address of the upstream/downstream hop from which this message was initially received
     * @return the IP address of the upstream/downstream hop from which this message was initially received
     * @since 2.0
     */
    public String getPeerAddress();
    /**
     * Returns the port of the upstream/downstream hop from which this message was initially received
     * @return the port of the upstream/downstream hop from which this message was initially received
     * @since 2.0
     */
    public int getPeerPort();
    /**
     * Returns the name of the protocol with which this message was initially received
     * @return the name of the protocol with which this message was initially received
     * @since 2.0
     */
    public String getTransport();

    /**
     * return the ip address on which this message was initially received
     * @return the ip address on which this message was initially received
     */
    public String getHost();
    /**
     * return the port on which this message was initially received
     * @return the port on which this message was initially received
     */
    public int getPort();
    
    /**
     * Return the Cipher Suite that was used for the SSL handshake. 
     * 
     * @return     Returns the cipher suite in use by the session which was produced by the handshake.
     * @throw UnsupportedOperationException if this is not a secure client transaction.
     */
    public String getCipherSuite() throws UnsupportedOperationException;
    
    /**
     * Get the certificate(s) that were sent to the peer during handshaking.
     *@return the certificate(s) that were sent to the peer during handshaking.
     *@throw UnsupportedOperationException if this is not a secure client transaction.
     * 
     */
   Certificate[] getLocalCertificates() throws UnsupportedOperationException;
    
    /**
     * @return the identity of the peer which was identified as part of defining the session.
     * @throws SSLPeerUnverifiedException 
     * @throw UnsupportedOperationException if this is not a secure client transaction.
     */
   Certificate[]  getPeerCertificates() throws SSLPeerUnverifiedException;
}
