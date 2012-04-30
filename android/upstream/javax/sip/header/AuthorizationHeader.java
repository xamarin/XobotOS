package javax.sip.header;

import java.text.ParseException;
import javax.sip.address.URI;

public interface AuthorizationHeader extends Header, Parameters {
    String NAME = "Authorization";

    String getAlgorithm();
    void setAlgorithm(String algorithm) throws ParseException;

    String getCNonce();
    void setCNonce(String cNonce) throws ParseException;

    String getNonce();
    void setNonce(String nonce) throws ParseException;

    int getNonceCount();
    void setNonceCount(int nonceCount) throws ParseException;

    String getOpaque();
    void setOpaque(String opaque) throws ParseException;

    String getQop();
    void setQop(String qop) throws ParseException;

    String getRealm();
    void setRealm(String realm) throws ParseException;

    String getResponse();
    void setResponse(String response) throws ParseException;

    String getScheme();
    void setScheme(String scheme);

    boolean isStale();
    void setStale(boolean stale);

    URI getURI();
    void setURI(URI uri);

    String getUsername();
    void setUsername(String username) throws ParseException;
}
