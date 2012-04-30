package javax.sip.header;

import java.text.ParseException;
import javax.sip.InvalidArgumentException;

public interface ViaHeader extends Header, Parameters {
    String NAME = "Via";

    String getBranch();
    void setBranch(String branch) throws ParseException;

    String getHost();
    void setHost(String host) throws ParseException;

    String getMAddr();
    void setMAddr(String mAddr) throws ParseException;

    int getPort();
    void setPort(int port) throws InvalidArgumentException;

    String getProtocol();
    void setProtocol(String protocol) throws ParseException;

    String getReceived();
    void setReceived(String received) throws ParseException;

    int getRPort();
    void setRPort() throws InvalidArgumentException;

    String getTransport();
    void setTransport(String transport) throws ParseException;

    int getTTL();
    void setTTL(int ttl) throws InvalidArgumentException;

    String getSentByField();
    String getSentProtocolField();
}
