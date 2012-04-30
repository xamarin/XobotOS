package javax.sip;

import javax.sip.address.Hop;
import javax.sip.message.Request;

public interface ClientTransaction extends Transaction {
    /**
     * @deprecated
     * For 2xx response, use {@link Dialog.createAck(long)}. The application
     * should not need to handle non-2xx responses.
     */
    Request createAck() throws SipException;

    Request createCancel() throws SipException;
    void sendRequest() throws SipException;

    void alertIfStillInCallingStateBy(int count);

    Hop getNextHop();

    void setNotifyOnRetransmit(boolean notifyOnRetransmit);
}

