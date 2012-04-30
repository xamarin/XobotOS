package javax.sip.header;

import java.util.Locale;
import javax.sip.InvalidArgumentException;

public interface AcceptLanguageHeader extends Header, Parameters {
    String NAME = "Accept-Language";

    Locale getAcceptLanguage();
    void setAcceptLanguage(Locale acceptLanguage);
    void setLanguageRange(String languageRange);

    float getQValue();
    void setQValue(float qValue) throws InvalidArgumentException;
    boolean hasQValue();
    void removeQValue();
}
