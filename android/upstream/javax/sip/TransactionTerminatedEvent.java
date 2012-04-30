package javax.sip;

import java.util.EventObject;

public class TransactionTerminatedEvent extends EventObject {
    private boolean mIsServerTransaction;
    private ServerTransaction mServerTransaction;
    private ClientTransaction mClientTransaction;

    public TransactionTerminatedEvent(
            Object source, ServerTransaction serverTransaction) {
        super(source);
        mServerTransaction = serverTransaction;

        mIsServerTransaction = true;
    }

    public TransactionTerminatedEvent(
            Object source, ClientTransaction clientTransaction) {
        super(source);
        mClientTransaction = clientTransaction;

        mIsServerTransaction = false;
    }

    public boolean isServerTransaction() {
        return mIsServerTransaction;
    }

    public ClientTransaction getClientTransaction() {
        return mClientTransaction;
    }

    public ServerTransaction getServerTransaction() {
        return mServerTransaction;
    }
}
