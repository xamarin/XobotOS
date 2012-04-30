package javax.sip.header;

import java.text.ParseException;
import javax.sip.InvalidArgumentException;

public interface WarningHeader extends Header {
    String NAME = "Warning";

    int ATTRIBUTE_NOT_UNDERSTOOD = 10;
    int INCOMPATIBLE_BANDWIDTH_UNITS = 20;
    int INCOMPATIBLE_MEDIA_FORMAT = 21;
    int INCOMPATIBLE_NETWORK_ADDRESS_FORMATS = 22;
    int INCOMPATIBLE_NETWORK_PROTOCOL = 23;
    int INCOMPATIBLE_TRANSPORT_PROTOCOL = 24;
    int INSUFFICIENT_BANDWIDTH = 30;
    int MEDIA_TYPE_NOT_AVAILABLE = 40;
    int MISCELLANEOUS_WARNING = 99;
    int MULTICAST_NOT_AVAILABLE = 50;
    int SESSION_DESCRIPTION_PARAMETER_NOT_UNDERSTOOD = 60;
    int UNICAST_NOT_AVAILABLE = 51;

    String getAgent();
    void setAgent(String agent) throws ParseException;

    int getCode();
    void setCode(int code) throws InvalidArgumentException;

    String getText();
    void setText(String text) throws ParseException;
}
