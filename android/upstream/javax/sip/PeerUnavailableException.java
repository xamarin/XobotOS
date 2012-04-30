package javax.sip;

public class PeerUnavailableException extends SipException {
    public PeerUnavailableException() {
    }

    public PeerUnavailableException(String message) {
        super(message);
    }

    public PeerUnavailableException(String message, Throwable cause) {
        super(message, cause);
    }
}

