package javax.sip.header;

import javax.sip.InvalidArgumentException;

public interface ContentLengthHeader extends Header {
    String NAME = "Content-Length";

    int getContentLength();
    void setContentLength(int contentLength) throws InvalidArgumentException;
}
