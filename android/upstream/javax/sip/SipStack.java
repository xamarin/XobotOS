package javax.sip;

import java.util.Collection;
import java.util.Iterator;
import javax.sip.address.Router;

public interface SipStack {
    /**
     * Deprecated. Use {@link #createListeningPoint(String, int, String)}
     * instead.
     */
    ListeningPoint createListeningPoint(int port, String transport)
            throws TransportNotSupportedException, InvalidArgumentException;
    ListeningPoint createListeningPoint(String ipAddress, int port,
            String transport) throws TransportNotSupportedException,
            InvalidArgumentException;
    void deleteListeningPoint(ListeningPoint listeningPoint)
            throws ObjectInUseException;

    SipProvider createSipProvider(ListeningPoint listeningPoint)
            throws ObjectInUseException;
    void deleteSipProvider(SipProvider sipProvider) throws ObjectInUseException;

    Collection getDialogs();
    String getIPAddress();
    Iterator getListeningPoints();
    Router getRouter();
    Iterator getSipProviders();
    String getStackName();

    /**
     * @deprecated
     * Use {@link ServerTransaction#enableRetransmissionAlerts()} to enable
     * retransmission alerts instead.
     */
    boolean isRetransmissionFilterActive();

    void start() throws ProviderDoesNotExistException, SipException;
    void stop();
}

