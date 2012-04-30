package javax.sip.header;

import java.text.ParseException;

public interface FromHeader extends HeaderAddress, Header, Parameters {
    String NAME = "From";

    String getTag();
    void setTag(String tag) throws ParseException;
    boolean hasTag();
    void removeTag();

    String getDisplayName();
    String getUserAtHostPort();
}
