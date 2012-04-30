package javax.sip;

import java.util.EventObject;

public class IOExceptionEvent extends EventObject {
    private String mHost;
    private int mPort;
    private String mTransport;

    public IOExceptionEvent(Object source, String host, int port,
            String transport) {
        super(source);
        mHost = host;
        mPort = port;
        mTransport = transport;
    }

    public String getHost() {
        return mHost;
    }

    public int getPort() {
        return mPort;
    }

    public String getTransport() {
        return mTransport;
    }
}
