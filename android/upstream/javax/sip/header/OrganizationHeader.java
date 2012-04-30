package javax.sip.header;

import java.text.ParseException;

public interface OrganizationHeader extends Header {
    String NAME = "Organization";

    String getOrganization();
    void setOrganization(String organization) throws ParseException;
}
