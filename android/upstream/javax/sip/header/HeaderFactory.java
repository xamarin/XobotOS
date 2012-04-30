package javax.sip.header;

import java.text.ParseException;
import java.util.Calendar;
import java.util.List;
import java.util.Locale;
import javax.sip.InvalidArgumentException;
import javax.sip.address.Address;
import javax.sip.address.URI;

public interface HeaderFactory {
    void setPrettyEncoding(boolean flag);

    AcceptEncodingHeader createAcceptEncodingHeader(String encoding)
            throws ParseException;

    AcceptHeader createAcceptHeader(String contentType, String contentSubType)
            throws ParseException;

    AcceptLanguageHeader createAcceptLanguageHeader(Locale language);

    AlertInfoHeader createAlertInfoHeader(URI alertInfo);

    AllowEventsHeader createAllowEventsHeader(String eventType)
            throws ParseException;

    AllowHeader createAllowHeader(String method) throws ParseException;

    AuthenticationInfoHeader createAuthenticationInfoHeader(String response)
            throws ParseException;

    AuthorizationHeader createAuthorizationHeader(String scheme)
            throws ParseException;

    CallIdHeader createCallIdHeader(String callId) throws ParseException;

    CallInfoHeader createCallInfoHeader(URI callInfo);

    ContactHeader createContactHeader();

    ContactHeader createContactHeader(Address address);

    ContentDispositionHeader createContentDispositionHeader(
            String contentDispositionType) throws ParseException;

    ContentEncodingHeader createContentEncodingHeader(String encoding)
            throws ParseException;

    ContentLanguageHeader createContentLanguageHeader(Locale contentLanguage);

    ContentLengthHeader createContentLengthHeader(int contentLength)
            throws InvalidArgumentException;

    ContentTypeHeader createContentTypeHeader(String contentType,
            String contentSubType) throws ParseException;

    /**
     * @deprecated
     * @see #createCSeqHeader(long, String)
     */
    CSeqHeader createCSeqHeader(int sequenceNumber, String method)
            throws ParseException, InvalidArgumentException;

    CSeqHeader createCSeqHeader(long sequenceNumber, String method)
            throws ParseException, InvalidArgumentException;

    DateHeader createDateHeader(Calendar date);

    ErrorInfoHeader createErrorInfoHeader(URI errorInfo);

    EventHeader createEventHeader(String eventType) throws ParseException;

    ExpiresHeader createExpiresHeader(int expires)
            throws InvalidArgumentException;

    ExtensionHeader createExtensionHeader(String name, String value)
            throws ParseException;

    FromHeader createFromHeader(Address address, String tag)
            throws ParseException;

    Header createHeader(String name, String value) throws ParseException;
    Header createHeader(String headerText) throws ParseException;

    List createHeaders(String headers) throws ParseException;

    InReplyToHeader createInReplyToHeader(String callId) throws ParseException;

    MaxForwardsHeader createMaxForwardsHeader(int maxForwards)
            throws InvalidArgumentException;

    MimeVersionHeader createMimeVersionHeader(int majorVersion,
            int minorVersion) throws InvalidArgumentException;

    MinExpiresHeader createMinExpiresHeader(int minExpires)
            throws InvalidArgumentException;

    OrganizationHeader createOrganizationHeader(String organization)
            throws ParseException;

    PriorityHeader createPriorityHeader(String priority) throws ParseException;

    ProxyAuthenticateHeader createProxyAuthenticateHeader(String scheme)
            throws ParseException;

    ProxyAuthorizationHeader createProxyAuthorizationHeader(String scheme)
            throws ParseException;

    ProxyRequireHeader createProxyRequireHeader(String optionTag)
            throws ParseException;

    RAckHeader createRAckHeader(long rSeqNumber, long cSeqNumber, String method)
            throws InvalidArgumentException, ParseException;

    /**
     * @deprecated
     * @see #createRAckHeader(long, long, String)
     */
    RAckHeader createRAckHeader(int rSeqNumber, int cSeqNumber, String method)
            throws InvalidArgumentException, ParseException;

    ReasonHeader createReasonHeader(String protocol, int cause, String text)
            throws InvalidArgumentException, ParseException;

    RecordRouteHeader createRecordRouteHeader(Address address);

    ReferToHeader createReferToHeader(Address address);

    ReplyToHeader createReplyToHeader(Address address);

    RequireHeader createRequireHeader(String optionTag) throws ParseException;

    RetryAfterHeader createRetryAfterHeader(int retryAfter)
            throws InvalidArgumentException;

    RouteHeader createRouteHeader(Address address);

    RSeqHeader createRSeqHeader(long sequenceNumber)
            throws InvalidArgumentException;

    /**
     * @deprecated
     * @see #createRSeqHeader(long)
     */
    RSeqHeader createRSeqHeader(int sequenceNumber)
            throws InvalidArgumentException;

    ServerHeader createServerHeader(List product) throws ParseException;

    SIPETagHeader createSIPETagHeader(String etag) throws ParseException;

    SIPIfMatchHeader createSIPIfMatchHeader(String etag) throws ParseException;

    SubjectHeader createSubjectHeader(String subject) throws ParseException;

    SubscriptionStateHeader createSubscriptionStateHeader(
            String subscriptionState) throws ParseException;

    SupportedHeader createSupportedHeader(String optionTag)
            throws ParseException;

    TimeStampHeader createTimeStampHeader(float timeStamp)
            throws InvalidArgumentException;

    ToHeader createToHeader(Address address, String tag) throws ParseException;

    UnsupportedHeader createUnsupportedHeader(String optionTag)
            throws ParseException;

    UserAgentHeader createUserAgentHeader(List product) throws ParseException;

    ViaHeader createViaHeader(String host, int port, String transport,
            String branch) throws InvalidArgumentException, ParseException;

    WarningHeader createWarningHeader(String agent, int code, String comment)
            throws InvalidArgumentException, ParseException;

    WWWAuthenticateHeader createWWWAuthenticateHeader(String scheme)
            throws ParseException;
}
