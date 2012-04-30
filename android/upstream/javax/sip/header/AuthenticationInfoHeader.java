package javax.sip.header;

import java.text.ParseException;

public interface AuthenticationInfoHeader extends Header, Parameters {
    String NAME = "Authentication-Info";

    String getCNonce();
    void setCNonce(String cNonce) throws ParseException;

    String getNextNonce();
    void setNextNonce(String nextNonce) throws ParseException;

    int getNonceCount();
    void setNonceCount(int nonceCount) throws ParseException;

    String getQop();
    void setQop(String qop) throws ParseException;

    String getResponse();
    void setResponse(String response) throws ParseException;
}
