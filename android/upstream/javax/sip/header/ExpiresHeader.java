package javax.sip.header;

import javax.sip.InvalidArgumentException;

public interface ExpiresHeader extends Header {
    String NAME = "Expires";

    int getExpires();
    void setExpires(int expires) throws InvalidArgumentException;
}
