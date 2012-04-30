package javax.sip;

import java.io.Serializable;
import java.text.ParseException;
import java.util.Iterator;
import javax.sip.address.Address;
import javax.sip.header.CallIdHeader;
import javax.sip.message.Request;
import javax.sip.message.Response;

public interface Dialog extends Serializable {
    Object getApplicationData();
    void setApplicationData(Object applicationData);

    CallIdHeader getCallId();
    String getDialogId();

    /**
     * @deprecated
     */
    Transaction getFirstTransaction();

    Address getLocalParty();

    /**
     * @deprecated
     * @see #getLocalSeqNumber()
     */
    int getLocalSequenceNumber();

    long getLocalSeqNumber();

    String getLocalTag();

    Address getRemoteParty();

    /**
     * @deprecated
     * @see #getRemoteSeqNumber()
     */
    int getRemoteSequenceNumber();

    long getRemoteSeqNumber();

    String getRemoteTag();

    Address getRemoteTarget();

    Iterator getRouteSet();

    SipProvider getSipProvider();

    DialogState getState();

    boolean isSecure();

    boolean isServer();

    void delete();

    void incrementLocalSequenceNumber();

    Request createRequest(String method) throws SipException;
    Request createAck(long cseq) throws InvalidArgumentException, SipException;
    Request createPrack(Response relResponse)
            throws DialogDoesNotExistException, SipException;
    Response createReliableProvisionalResponse(int statusCode)
            throws InvalidArgumentException, SipException;


    void sendRequest(ClientTransaction clientTransaction)
            throws TransactionDoesNotExistException, SipException;
    void sendAck(Request ackRequest) throws SipException;
    void sendReliableProvisionalResponse(Response relResponse)
            throws SipException;

    void setBackToBackUserAgent();

    void terminateOnBye(boolean terminateFlag) throws SipException;
}
