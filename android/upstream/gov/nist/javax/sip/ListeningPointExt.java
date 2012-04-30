package gov.nist.javax.sip;

import java.io.IOException;

import javax.sip.ListeningPoint;
import javax.sip.header.ContactHeader;
import javax.sip.header.ViaHeader;

public interface ListeningPointExt extends ListeningPoint {

    /**
     * Create a contact for this listening point.
     *
     * @return a contact header corresponding to this listening point.
     *
     * @since 2.0
     *
     */

    ContactHeader createContactHeader() ;

    /**
     * Send a heartbeat to the specified Ip address and port
     * via this listening point. This method can be used to send out a period
     * CR-LF for NAT keepalive.
     *
     * @since 2.0
     */
    public void sendHeartbeat(String ipAddress, int port) throws IOException ;
    
    /**
     * Create a Via header for this listening point.
     * 
     * @return a via header corresponding to this listening point. Branch ID is set to NULL.
     * 
     * @since 2.0
     */
    public ViaHeader createViaHeader();


}
