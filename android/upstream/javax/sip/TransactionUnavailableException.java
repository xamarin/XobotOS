package javax.sip;

public class TransactionUnavailableException extends SipException {
    public TransactionUnavailableException() {
    }

    public TransactionUnavailableException(String message) {
        super(message);
    }

    public TransactionUnavailableException(String message, Throwable cause) {
        super(message, cause);
    }
}

