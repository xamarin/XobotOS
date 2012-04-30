package javax.sip;

public class TransactionAlreadyExistsException extends SipException {
    public TransactionAlreadyExistsException(){
    }

    public TransactionAlreadyExistsException(String message) {
        super(message);
    }

    public TransactionAlreadyExistsException(String message, Throwable cause) {
        super(message, cause);
    }
}

