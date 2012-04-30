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
package gov.nist.javax.sip.parser;

import gov.nist.core.*;

import gov.nist.javax.sip.header.extensions.*;

import gov.nist.javax.sip.header.ims.*;

import javax.sip.header.*;
import java.util.Hashtable;

/**
 * Lexer class for the parser.
 *
 * @version 1.2
 *
 * @author M. Ranganathan <br/>
 *
 *
 */
public class Lexer extends LexerCore {
    /**
     * get the header name of the line
     *
     * @return the header name (stuff before the :) bug fix submitted by
     *         zvali@dev.java.net
     */
    public static String getHeaderName(String line) {
        if (line == null)
            return null;
        String headerName = null;
        try {
            int begin = line.indexOf(":");
            headerName = null;
            if (begin >= 1)
                headerName = line.substring(0, begin).trim();
        } catch (IndexOutOfBoundsException e) {
            return null;
        }
        return headerName;
    }

    public Lexer(String lexerName, String buffer) {
        super(lexerName, buffer);
        this.selectLexer(lexerName);
    }

    /**
     * get the header value of the line
     *
     * @return String
     */
    public static String getHeaderValue(String line) {
        if (line == null)
            return null;
        String headerValue = null;
        try {
            int begin = line.indexOf(":");
            headerValue = line.substring(begin + 1);
        } catch (IndexOutOfBoundsException e) {
            return null;
        }
        return headerValue;
    }

    public void selectLexer(String lexerName) {
        synchronized (lexerTables) {
            // Synchronization Bug fix by Robert Rosen.
            currentLexer = (Hashtable) lexerTables.get(lexerName);
            this.currentLexerName = lexerName;
            if (currentLexer == null) {
                addLexer(lexerName);
                if (lexerName.equals("method_keywordLexer")) {
                    addKeyword(TokenNames.REGISTER, TokenTypes.REGISTER);
                    addKeyword(TokenNames.ACK, TokenTypes.ACK);
                    addKeyword(TokenNames.OPTIONS, TokenTypes.OPTIONS);
                    addKeyword(TokenNames.BYE, TokenTypes.BYE);
                    addKeyword(TokenNames.INVITE, TokenTypes.INVITE);
                    addKeyword(TokenNames.SIP.toUpperCase(), TokenTypes.SIP);
                    addKeyword(TokenNames.SIPS.toUpperCase(), TokenTypes.SIPS);
                    addKeyword(TokenNames.SUBSCRIBE, TokenTypes.SUBSCRIBE);
                    addKeyword(TokenNames.NOTIFY, TokenTypes.NOTIFY);
                    addKeyword(TokenNames.MESSAGE, TokenTypes.MESSAGE);

                    // JvB: added to support RFC3903
                    addKeyword(TokenNames.PUBLISH, TokenTypes.PUBLISH);

                } else if (lexerName.equals("command_keywordLexer")) {
                    addKeyword(ErrorInfoHeader.NAME.toUpperCase(),
                            TokenTypes.ERROR_INFO);
                    addKeyword(AllowEventsHeader.NAME.toUpperCase(),
                            TokenTypes.ALLOW_EVENTS);
                    addKeyword(AuthenticationInfoHeader.NAME.toUpperCase(),
                            TokenTypes.AUTHENTICATION_INFO);
                    addKeyword(EventHeader.NAME.toUpperCase(), TokenTypes.EVENT);
                    addKeyword(MinExpiresHeader.NAME.toUpperCase(),
                            TokenTypes.MIN_EXPIRES);
                    addKeyword(RSeqHeader.NAME.toUpperCase(), TokenTypes.RSEQ);
                    addKeyword(RAckHeader.NAME.toUpperCase(), TokenTypes.RACK);
                    addKeyword(ReasonHeader.NAME.toUpperCase(),
                            TokenTypes.REASON);
                    addKeyword(ReplyToHeader.NAME.toUpperCase(),
                            TokenTypes.REPLY_TO);
                    addKeyword(SubscriptionStateHeader.NAME.toUpperCase(),
                            TokenTypes.SUBSCRIPTION_STATE);
                    addKeyword(TimeStampHeader.NAME.toUpperCase(),
                            TokenTypes.TIMESTAMP);
                    addKeyword(InReplyToHeader.NAME.toUpperCase(),
                            TokenTypes.IN_REPLY_TO);
                    addKeyword(MimeVersionHeader.NAME.toUpperCase(),
                            TokenTypes.MIME_VERSION);
                    addKeyword(AlertInfoHeader.NAME.toUpperCase(),
                            TokenTypes.ALERT_INFO);
                    addKeyword(FromHeader.NAME.toUpperCase(), TokenTypes.FROM);
                    addKeyword(ToHeader.NAME.toUpperCase(), TokenTypes.TO);
                    addKeyword(ReferToHeader.NAME.toUpperCase(),
                            TokenTypes.REFER_TO);
                    addKeyword(ViaHeader.NAME.toUpperCase(), TokenTypes.VIA);
                    addKeyword(UserAgentHeader.NAME.toUpperCase(),
                            TokenTypes.USER_AGENT);
                    addKeyword(ServerHeader.NAME.toUpperCase(),
                            TokenTypes.SERVER);
                    addKeyword(AcceptEncodingHeader.NAME.toUpperCase(),
                            TokenTypes.ACCEPT_ENCODING);
                    addKeyword(AcceptHeader.NAME.toUpperCase(),
                            TokenTypes.ACCEPT);
                    addKeyword(AllowHeader.NAME.toUpperCase(), TokenTypes.ALLOW);
                    addKeyword(RouteHeader.NAME.toUpperCase(), TokenTypes.ROUTE);
                    addKeyword(AuthorizationHeader.NAME.toUpperCase(),
                            TokenTypes.AUTHORIZATION);
                    addKeyword(ProxyAuthorizationHeader.NAME.toUpperCase(),
                            TokenTypes.PROXY_AUTHORIZATION);
                    addKeyword(RetryAfterHeader.NAME.toUpperCase(),
                            TokenTypes.RETRY_AFTER);
                    addKeyword(ProxyRequireHeader.NAME.toUpperCase(),
                            TokenTypes.PROXY_REQUIRE);
                    addKeyword(ContentLanguageHeader.NAME.toUpperCase(),
                            TokenTypes.CONTENT_LANGUAGE);
                    addKeyword(UnsupportedHeader.NAME.toUpperCase(),
                            TokenTypes.UNSUPPORTED);
                    addKeyword(SupportedHeader.NAME.toUpperCase(),
                            TokenTypes.SUPPORTED);
                    addKeyword(WarningHeader.NAME.toUpperCase(),
                            TokenTypes.WARNING);
                    addKeyword(MaxForwardsHeader.NAME.toUpperCase(),
                            TokenTypes.MAX_FORWARDS);
                    addKeyword(DateHeader.NAME.toUpperCase(), TokenTypes.DATE);
                    addKeyword(PriorityHeader.NAME.toUpperCase(),
                            TokenTypes.PRIORITY);
                    addKeyword(ProxyAuthenticateHeader.NAME.toUpperCase(),
                            TokenTypes.PROXY_AUTHENTICATE);
                    addKeyword(ContentEncodingHeader.NAME.toUpperCase(),
                            TokenTypes.CONTENT_ENCODING);
                    addKeyword(ContentLengthHeader.NAME.toUpperCase(),
                            TokenTypes.CONTENT_LENGTH);
                    addKeyword(SubjectHeader.NAME.toUpperCase(),
                            TokenTypes.SUBJECT);
                    addKeyword(ContentTypeHeader.NAME.toUpperCase(),
                            TokenTypes.CONTENT_TYPE);
                    addKeyword(ContactHeader.NAME.toUpperCase(),
                            TokenTypes.CONTACT);
                    addKeyword(CallIdHeader.NAME.toUpperCase(),
                            TokenTypes.CALL_ID);
                    addKeyword(RequireHeader.NAME.toUpperCase(),
                            TokenTypes.REQUIRE);
                    addKeyword(ExpiresHeader.NAME.toUpperCase(),
                            TokenTypes.EXPIRES);
                    addKeyword(RecordRouteHeader.NAME.toUpperCase(),
                            TokenTypes.RECORD_ROUTE);
                    addKeyword(OrganizationHeader.NAME.toUpperCase(),
                            TokenTypes.ORGANIZATION);
                    addKeyword(CSeqHeader.NAME.toUpperCase(), TokenTypes.CSEQ);
                    addKeyword(AcceptLanguageHeader.NAME.toUpperCase(),
                            TokenTypes.ACCEPT_LANGUAGE);
                    addKeyword(WWWAuthenticateHeader.NAME.toUpperCase(),
                            TokenTypes.WWW_AUTHENTICATE);
                    addKeyword(CallInfoHeader.NAME.toUpperCase(),
                            TokenTypes.CALL_INFO);
                    addKeyword(ContentDispositionHeader.NAME.toUpperCase(),
                            TokenTypes.CONTENT_DISPOSITION);
                    // And now the dreaded short forms....
                    addKeyword(TokenNames.K.toUpperCase(), TokenTypes.SUPPORTED);
                    addKeyword(TokenNames.C.toUpperCase(),
                            TokenTypes.CONTENT_TYPE);
                    addKeyword(TokenNames.E.toUpperCase(),
                            TokenTypes.CONTENT_ENCODING);
                    addKeyword(TokenNames.F.toUpperCase(), TokenTypes.FROM);
                    addKeyword(TokenNames.I.toUpperCase(), TokenTypes.CALL_ID);
                    addKeyword(TokenNames.M.toUpperCase(), TokenTypes.CONTACT);
                    addKeyword(TokenNames.L.toUpperCase(),
                            TokenTypes.CONTENT_LENGTH);
                    addKeyword(TokenNames.S.toUpperCase(), TokenTypes.SUBJECT);
                    addKeyword(TokenNames.T.toUpperCase(), TokenTypes.TO);
                    addKeyword(TokenNames.U.toUpperCase(),
                            TokenTypes.ALLOW_EVENTS); // JvB: added
                    addKeyword(TokenNames.V.toUpperCase(), TokenTypes.VIA);
                    addKeyword(TokenNames.R.toUpperCase(), TokenTypes.REFER_TO);
                    addKeyword(TokenNames.O.toUpperCase(), TokenTypes.EVENT); // Bug
                                                                                // fix
                                                                                // by
                                                                                // Mario
                                                                                // Mantak
                    addKeyword(TokenNames.X.toUpperCase(), TokenTypes.SESSIONEXPIRES_TO); // Bug fix by Jozef Saniga
                    
                    // JvB: added to support RFC3903
                    addKeyword(SIPETagHeader.NAME.toUpperCase(),
                            TokenTypes.SIP_ETAG);
                    addKeyword(SIPIfMatchHeader.NAME.toUpperCase(),
                            TokenTypes.SIP_IF_MATCH);

                    // pmusgrave: Add RFC4028 and ReferredBy
                    addKeyword(SessionExpiresHeader.NAME.toUpperCase(),
                            TokenTypes.SESSIONEXPIRES_TO);
                    addKeyword(MinSEHeader.NAME.toUpperCase(),
                            TokenTypes.MINSE_TO);
                    addKeyword(ReferredByHeader.NAME.toUpperCase(),
                            TokenTypes.REFERREDBY_TO);

                    // pmusgrave RFC3891
                    addKeyword(ReplacesHeader.NAME.toUpperCase(),
                            TokenTypes.REPLACES_TO);
                    //jean deruelle RFC3911
                    addKeyword(JoinHeader.NAME.toUpperCase(),
                            TokenTypes.JOIN_TO);

                    // IMS Headers
                    addKeyword(PathHeader.NAME.toUpperCase(), TokenTypes.PATH);
                    addKeyword(ServiceRouteHeader.NAME.toUpperCase(),
                            TokenTypes.SERVICE_ROUTE);
                    addKeyword(PAssertedIdentityHeader.NAME.toUpperCase(),
                            TokenTypes.P_ASSERTED_IDENTITY);
                    addKeyword(PPreferredIdentityHeader.NAME.toUpperCase(),
                            TokenTypes.P_PREFERRED_IDENTITY);
                    addKeyword(PrivacyHeader.NAME.toUpperCase(),
                            TokenTypes.PRIVACY);

                    // issued by Miguel Freitas
                    addKeyword(PCalledPartyIDHeader.NAME.toUpperCase(),
                            TokenTypes.P_CALLED_PARTY_ID);
                    addKeyword(PAssociatedURIHeader.NAME.toUpperCase(),
                            TokenTypes.P_ASSOCIATED_URI);
                    addKeyword(PVisitedNetworkIDHeader.NAME.toUpperCase(),
                            TokenTypes.P_VISITED_NETWORK_ID);
                    addKeyword(PChargingFunctionAddressesHeader.NAME
                            .toUpperCase(),
                            TokenTypes.P_CHARGING_FUNCTION_ADDRESSES);
                    addKeyword(PChargingVectorHeader.NAME.toUpperCase(),
                            TokenTypes.P_VECTOR_CHARGING);
                    addKeyword(PAccessNetworkInfoHeader.NAME.toUpperCase(),
                            TokenTypes.P_ACCESS_NETWORK_INFO);
                    addKeyword(PMediaAuthorizationHeader.NAME.toUpperCase(),
                            TokenTypes.P_MEDIA_AUTHORIZATION);

                    addKeyword(SecurityServerHeader.NAME.toUpperCase(),
                            TokenTypes.SECURITY_SERVER);
                    addKeyword(SecurityVerifyHeader.NAME.toUpperCase(),
                            TokenTypes.SECURITY_VERIFY);
                    addKeyword(SecurityClientHeader.NAME.toUpperCase(),
                            TokenTypes.SECURITY_CLIENT);

                    // added by aayush@rancore
                    addKeyword(PUserDatabaseHeader.NAME.toUpperCase(),
                            TokenTypes.P_USER_DATABASE);

                    // added by aayush@rancore
                    addKeyword(PProfileKeyHeader.NAME.toUpperCase(),
                            TokenTypes.P_PROFILE_KEY);

                    // added by aayush@rancore
                    addKeyword(PServedUserHeader.NAME.toUpperCase(),
                            TokenTypes.P_SERVED_USER);

                    // added by aayush@rancore
                    addKeyword(PPreferredServiceHeader.NAME.toUpperCase(),
                            TokenTypes.P_PREFERRED_SERVICE);

                    // added by aayush@rancore
                    addKeyword(PAssertedServiceHeader.NAME.toUpperCase(),
                            TokenTypes.P_ASSERTED_SERVICE);
                    
                    // added References header
                    addKeyword(ReferencesHeader.NAME.toUpperCase(),TokenTypes.REFERENCES);

                    // end //


                } else if (lexerName.equals("status_lineLexer")) {
                    addKeyword(TokenNames.SIP.toUpperCase(), TokenTypes.SIP);
                } else if (lexerName.equals("request_lineLexer")) {
                    addKeyword(TokenNames.SIP.toUpperCase(), TokenTypes.SIP);
                } else if (lexerName.equals("sip_urlLexer")) {
                    addKeyword(TokenNames.TEL.toUpperCase(), TokenTypes.TEL);
                    addKeyword(TokenNames.SIP.toUpperCase(), TokenTypes.SIP);
                    addKeyword(TokenNames.SIPS.toUpperCase(), TokenTypes.SIPS);
                }
            }
        }
    }
}
