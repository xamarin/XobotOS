package javax.sip;

public class ProviderDoesNotExistException extends SipException {
    public ProviderDoesNotExistException(){
    }

    public ProviderDoesNotExistException(String message) {
        super(message);
    }

    public ProviderDoesNotExistException(String message, Throwable cause) {
        super(message, cause);
    }
}

