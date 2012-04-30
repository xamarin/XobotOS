package gov.nist.javax.sip;

import java.security.cert.Certificate;
import java.security.cert.X509Certificate;

import javax.net.ssl.SSLPeerUnverifiedException;
import javax.sip.ClientTransaction;
import javax.sip.Timeout;
import javax.sip.address.Hop;

public interface ClientTransactionExt extends ClientTransaction, TransactionExt {

    /**
     * Notify on retransmission from the client transaction side. The listener will get a
     * notification on retransmission when this flag is set. When set the client transaction
     * listener will get a Timeout.RETRANSMIT event on each retransmission.
     * 
     * @param flag -- the flag that indicates whether or not notification is desired.
     * 
     * @since 2.0
     */
    public void setNotifyOnRetransmit(boolean flag);

    /**
     * Send a transaction timeout event to the application if Tx is still in Calling state in the
     * given time period ( in base timer interval count ) after sending request. The stack will
     * start a timer and alert the application if the client transaction does not transition out
     * of the Trying state by the given interval. This is a "one shot" alert.
     * 
     * @param count -- the number of base timer intervals after which an alert is issued.
     * 
     * 
     * @since 2.0
     */
    public void alertIfStillInCallingStateBy(int count);
    
    /**
     * Get the next hop that was computed by the routing layer.
     * when it sent out the request. This allows you to route requests
     * to the SAME destination if required ( for example if you get
     * an authentication challenge ).
     */
    public Hop getNextHop();
    
    /**
     * Return true if this Ctx is a secure transport.
     * 
     */
    public boolean isSecure();
    
  
   
   

}
