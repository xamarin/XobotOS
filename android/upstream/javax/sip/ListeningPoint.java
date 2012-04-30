package javax.sip;

import java.io.IOException;
import java.text.ParseException;
import javax.sip.header.ContactHeader;

public interface ListeningPoint extends Cloneable {
    String TCP = "TCP";
    String UDP = "UDP";
    String SCTP = "SCTP";
    String TLS = "TLS";
    int PORT_5060 = 5060;
    int PORT_5061 = 5061;

    String getIPAddress();
    int getPort();
    String getTransport();

    String getSentBy();
    void setSentBy(String sentBy) throws ParseException;

    ContactHeader createContactHeader();

    void sendHeartbeat(String s, int i) throws IOException;
}

