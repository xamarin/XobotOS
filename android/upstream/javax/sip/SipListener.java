package javax.sip;

public interface SipListener {
    void processDialogTerminated(DialogTerminatedEvent dialogTerminatedEvent);
    void processIOException(IOExceptionEvent exceptionEvent);
    void processRequest(RequestEvent requestEvent);
    void processResponse(ResponseEvent responseEvent);
    void processTimeout(TimeoutEvent timeoutEvent);
    void processTransactionTerminated(
            TransactionTerminatedEvent transactionTerminatedEvent);
}

