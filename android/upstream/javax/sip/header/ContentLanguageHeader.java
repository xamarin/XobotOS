package javax.sip.header;

import java.util.Locale;

public interface ContentLanguageHeader extends Header {
    String NAME = "Content-Language";

    Locale getContentLanguage();
    void setContentLanguage(Locale language);

    String getLanguageTag();
    void setLanguageTag(String languageTag);
}
