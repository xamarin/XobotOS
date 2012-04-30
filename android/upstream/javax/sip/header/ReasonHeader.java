package javax.sip.header;

import java.text.ParseException;
import javax.sip.InvalidArgumentException;

public interface ReasonHeader extends Header, Parameters {
    String NAME = "Reason";

    int getCause();
    void setCause(int cause) throws InvalidArgumentException;

    String getProtocol();
    void setProtocol(String protocol) throws ParseException;

    String getText();
    void setText(String text) throws ParseException;
}
