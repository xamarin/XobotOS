/*
* Conditions Of Use
*
* This software was developed by employees of the National Institute of
* Standards and Technology (NIST), an agency of the Federal Government.
* Pursuant to title 15 Untied States Code Section 105, works of NIST
* employees are not subject to copyright protection in the United States
* and are considered to be in the public domain.  As a result, a formal
* license is not needed to use the software.
*
* This software is provided by NIST as a service and is expressly
* provided "AS IS."  NIST MAKES NO WARRANTY OF ANY KIND, EXPRESS, IMPLIED
* OR STATUTORY, INCLUDING, WITHOUT LIMITATION, THE IMPLIED WARRANTY OF
* MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE, NON-INFRINGEMENT
* AND DATA ACCURACY.  NIST does not warrant or make any representations
* regarding the use of the software or the results thereof, including but
* not limited to the correctness, accuracy, reliability or usefulness of
* the software.
*
* Permission to use this software is contingent upon your acceptance
* of the terms of this agreement
*
* .
*
*/
/*******************************************************************************
* Product of NIST/ITL Advanced Networking Technologies Division (ANTD).        *
*******************************************************************************/
package gov.nist.javax.sip.header;
import javax.sip.header.*;
import gov.nist.javax.sip.header.extensions.*;

/**
 * SIPHeader names that are supported by this parser
 *
 * @version 1.2 $Revision: 1.9 $ $Date: 2009/07/17 18:57:37 $
 *
 * @author M. Ranganathan   <br/>
 *
 *
 */
public interface SIPHeaderNames {

    public static final String MIN_EXPIRES = MinExpiresHeader.NAME; //1
    public static final String ERROR_INFO = ErrorInfoHeader.NAME; //2
    public static final String MIME_VERSION = MimeVersionHeader.NAME; //3
    public static final String IN_REPLY_TO = InReplyToHeader.NAME; //4
    public static final String ALLOW = AllowHeader.NAME; //5
    public static final String CONTENT_LANGUAGE = ContentLanguageHeader.NAME;
    //6
    public static final String CALL_INFO = CallInfoHeader.NAME; //7
    public static final String CSEQ = CSeqHeader.NAME; //8
    public static final String ALERT_INFO = AlertInfoHeader.NAME; //9
    public static final String ACCEPT_ENCODING = AcceptEncodingHeader.NAME;
    //10
    public static final String ACCEPT = AcceptHeader.NAME; //11
    public static final String ACCEPT_LANGUAGE = AcceptLanguageHeader.NAME;
    //12
    public static final String RECORD_ROUTE = RecordRouteHeader.NAME; //13
    public static final String TIMESTAMP = TimeStampHeader.NAME; //14
    public static final String TO = ToHeader.NAME; //15
    public static final String VIA = ViaHeader.NAME; //16
    public static final String FROM = FromHeader.NAME; //17
    public static final String CALL_ID = CallIdHeader.NAME; //18
    public static final String AUTHORIZATION = AuthorizationHeader.NAME; //19
    public static final String PROXY_AUTHENTICATE =
        ProxyAuthenticateHeader.NAME;
    //20
    public static final String SERVER = ServerHeader.NAME; //21
    public static final String UNSUPPORTED = UnsupportedHeader.NAME; //22
    public static final String RETRY_AFTER = RetryAfterHeader.NAME; //23
    public static final String CONTENT_TYPE = ContentTypeHeader.NAME; //24
    public static final String CONTENT_ENCODING = ContentEncodingHeader.NAME;
    //25
    public static final String CONTENT_LENGTH = ContentLengthHeader.NAME; //26
    public static final String ROUTE = RouteHeader.NAME; //27
    public static final String CONTACT = ContactHeader.NAME; //28
    public static final String WWW_AUTHENTICATE = WWWAuthenticateHeader.NAME;
    //29
    public static final String MAX_FORWARDS = MaxForwardsHeader.NAME; //30
    public static final String ORGANIZATION = OrganizationHeader.NAME; //31
    public static final String PROXY_AUTHORIZATION =
        ProxyAuthorizationHeader.NAME;
    //32
    public static final String PROXY_REQUIRE = ProxyRequireHeader.NAME; //33
    public static final String REQUIRE = RequireHeader.NAME; //34
    public static final String CONTENT_DISPOSITION =
        ContentDispositionHeader.NAME;
    //35
    public static final String SUBJECT = SubjectHeader.NAME; //36
    public static final String USER_AGENT = UserAgentHeader.NAME; //37
    public static final String WARNING = WarningHeader.NAME; //38
    public static final String PRIORITY = PriorityHeader.NAME; //39
    public static final String DATE = DateHeader.NAME; //40
    public static final String EXPIRES = ExpiresHeader.NAME; //41
    public static final String SUPPORTED = SupportedHeader.NAME; //42
    public static final String AUTHENTICATION_INFO =
        AuthenticationInfoHeader.NAME;
    //43
    public static final String REPLY_TO = ReplyToHeader.NAME; //44
    public static final String RACK = RAckHeader.NAME; //45
    public static final String RSEQ = RSeqHeader.NAME; //46
    public static final String REASON = ReasonHeader.NAME; //47
    public static final String SUBSCRIPTION_STATE =
        SubscriptionStateHeader.NAME;
    //48
    public static final String EVENT = EventHeader.NAME; //44
    public static final String ALLOW_EVENTS = AllowEventsHeader.NAME; //45

    public static final String SIP_ETAG = SIPETagHeader.NAME; //46
    public static final String SIP_IF_MATCH = SIPIfMatchHeader.NAME; //47

    // NewHeights pmusgrave
    public static final String REFERRED_BY = ReferredByHeader.NAME; //48
    public static final String SESSION_EXPIRES = SessionExpiresHeader.NAME; //49
    public static final String MIN_SE = MinSEHeader.NAME; //50
    public static final String REPLACES = ReplacesHeader.NAME; //51
    public static final String JOIN = JoinHeader.NAME; //52

}

