package gov.nist.javax.sip.header.extensions;

import javax.sip.InvalidArgumentException;
import javax.sip.header.*;

/*
 * Extension for SessionTimer RFC 4028
 *
 *
 */


public interface SessionExpiresHeader extends Parameters, Header, ExtensionHeader{

    public final static String NAME = "Session-Expires";

    public int getExpires();

    public void setExpires(int expires) throws InvalidArgumentException;

    public String getRefresher() ;

    public void setRefresher(String refresher);



}
