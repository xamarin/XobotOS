package javax.sip;

public class DialogDoesNotExistException extends SipException {
    public DialogDoesNotExistException(){
    }

    public DialogDoesNotExistException(String message) {
        super(message);
    }

    public DialogDoesNotExistException(String message, Throwable cause) {
        super(message, cause);
    }
}

