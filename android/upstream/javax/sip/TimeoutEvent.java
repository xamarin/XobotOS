package javax.sip;

public class TimeoutEvent extends TransactionTerminatedEvent {
    private Timeout mTimeout;

    public TimeoutEvent(Object source, ServerTransaction serverTransaction,
            Timeout timeout) {
        super(source, serverTransaction);
        mTimeout = timeout;
    }

    public TimeoutEvent(Object source, ClientTransaction clientTransaction,
            Timeout timeout) {
        super(source, clientTransaction);
        mTimeout = timeout;
    }

    public Timeout getTimeout() {
        return mTimeout;
    }
}
