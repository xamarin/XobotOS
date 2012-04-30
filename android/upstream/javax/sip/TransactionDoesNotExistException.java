package javax.sip;

public class TransactionDoesNotExistException extends SipException {
    public TransactionDoesNotExistException(){
    }

    public TransactionDoesNotExistException(String message) {
        super(message);
    }

    public TransactionDoesNotExistException(String message, Throwable cause) {
        super(message, cause);
    }
}

