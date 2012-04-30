package javax.sip;

public class ObjectInUseException extends SipException {
    public ObjectInUseException() {
    }

    public ObjectInUseException(String message) {
        super(message);
    }

    public ObjectInUseException(String message, Throwable cause) {
        super(message, cause);
    }
}

