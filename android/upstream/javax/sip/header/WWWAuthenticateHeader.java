package javax.sip.header;

import javax.sip.address.URI;

public interface WWWAuthenticateHeader extends AuthorizationHeader {
    String NAME = "WWW-Authenticate";

    /**
     * @deprecated This method should return null.
     */
    URI getURI();

    /**
     * @deprecated This method should return immediately.
     */
    void setURI(URI uri);
}
