package javax.sip.header;

import java.text.ParseException;
import java.util.List;
import java.util.ListIterator;

public interface UserAgentHeader extends Header {
    String NAME = "User-Agent";

    ListIterator getProduct();
    void setProduct(List product) throws ParseException;
    void addProductToken(String productToken);
}
