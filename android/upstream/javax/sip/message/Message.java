package javax.sip.message;

import java.io.Serializable;
import java.text.ParseException;
import java.util.ListIterator;
import javax.sip.SipException;
import javax.sip.header.ContentDispositionHeader;
import javax.sip.header.ContentEncodingHeader;
import javax.sip.header.ContentLanguageHeader;
import javax.sip.header.ContentLengthHeader;
import javax.sip.header.ContentTypeHeader;
import javax.sip.header.ExpiresHeader;
import javax.sip.header.Header;

public interface Message extends Cloneable, Serializable {
    void addFirst(Header header) throws SipException, NullPointerException;
    void addHeader(Header header);
    void addLast(Header header) throws SipException, NullPointerException;

    Header getHeader(String headerName);
    void setHeader(Header header);

    void removeFirst(String headerName) throws NullPointerException;
    void removeLast(String headerName) throws NullPointerException;
    void removeHeader(String headerName);

    ListIterator getHeaderNames();
    ListIterator getHeaders(String headerName);
    ListIterator getUnrecognizedHeaders();

    Object getApplicationData();
    void setApplicationData(Object applicationData);

    ContentLengthHeader getContentLength();
    void setContentLength(ContentLengthHeader contentLength);

    ContentLanguageHeader getContentLanguage();
    void setContentLanguage(ContentLanguageHeader contentLanguage);

    ContentEncodingHeader getContentEncoding();
    void setContentEncoding(ContentEncodingHeader contentEncoding);

    ContentDispositionHeader getContentDisposition();
    void setContentDisposition(ContentDispositionHeader contentDisposition);

    Object getContent();
    byte[] getRawContent();
    void setContent(Object content, ContentTypeHeader contentTypeHeader)
            throws ParseException;
    void removeContent();


    ExpiresHeader getExpires();
    void setExpires(ExpiresHeader expires);

    String getSIPVersion();
    void setSIPVersion(String version) throws ParseException;

    Object clone();
    boolean equals(Object object);
    int hashCode();
    String toString();
}
