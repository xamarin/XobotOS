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
package gov.nist.javax.sip.header;
import gov.nist.core.*;
import gov.nist.javax.sip.header.ims.*;

import java.util.Hashtable;

/**
 * A mapping class that returns the SIPHeader for a given header name.
 * Add new classes to this map if you are implementing new header types if
 * you want some of the introspection based methods to work.
 * @version 1.2 $Revision: 1.11 $ $Date: 2009/07/17 18:57:32 $
 * @since 1.1
 */
public class NameMap implements SIPHeaderNames, PackageNames {
    static Hashtable nameMap;
    static {
        initializeNameMap();
    }

    protected static void putNameMap(String headerName, String className) {
        nameMap.put(
            headerName.toLowerCase(),
            className);
    }

    public static Class getClassFromName(String headerName) {
        String className = (String) nameMap.get(headerName.toLowerCase());
        if (className == null)
            return null;
        else {
            try {
                return Class.forName(className);
            } catch (ClassNotFoundException ex) {
                return null;
            }
        }
    }

    /** add an extension header to this map.
    *@param headerName is the extension header name.
    *@param className is the fully qualified class name that implements
    * the header (does not have to belong to the nist-sip package).
    * Use this if you want to use the introspection-based methods.
    */

    public static void addExtensionHeader(
        String headerName,
        String className) {
        nameMap.put(headerName.toLowerCase(), className);
    }

    private static void initializeNameMap() {
        nameMap = new Hashtable();
        putNameMap(MinExpires.NAME, MinExpires.class.getName()); // 1

        putNameMap(ErrorInfo.NAME, ErrorInfo.class.getName()); // 2

        putNameMap(MimeVersion.NAME, MimeVersion.class.getName()); // 3

        putNameMap(InReplyTo.NAME, InReplyTo.class.getName()); // 4

        putNameMap(Allow.NAME, Allow.class.getName()); // 5

        putNameMap(ContentLanguage.NAME, ContentLanguage.class.getName()); // 6

        putNameMap(CALL_INFO, CallInfo.class.getName()); //7

        putNameMap(CSEQ, CSeq.class.getName()); //8

        putNameMap(ALERT_INFO, AlertInfo.class.getName()); //9

        putNameMap(ACCEPT_ENCODING, AcceptEncoding.class.getName()); //10

        putNameMap(ACCEPT, Accept.class.getName()); //11

        putNameMap(ACCEPT_LANGUAGE, AcceptLanguage.class.getName()); //12

        putNameMap(RECORD_ROUTE, RecordRoute.class.getName()); //13

        putNameMap(TIMESTAMP, TimeStamp.class.getName()); //14

        putNameMap(TO, To.class.getName()); //15

        putNameMap(VIA, Via.class.getName()); //16

        putNameMap(FROM, From.class.getName()); //17

        putNameMap(CALL_ID, CallID.class.getName()); //18

        putNameMap(AUTHORIZATION, Authorization.class.getName()); //19

        putNameMap(PROXY_AUTHENTICATE, ProxyAuthenticate.class.getName()); //20

        putNameMap(SERVER, Server.class.getName()); //21

        putNameMap(UNSUPPORTED, Unsupported.class.getName()); //22

        putNameMap(RETRY_AFTER, RetryAfter.class.getName()); //23

        putNameMap(CONTENT_TYPE, ContentType.class.getName()); //24

        putNameMap(CONTENT_ENCODING, ContentEncoding.class.getName()); //25

        putNameMap(CONTENT_LENGTH, ContentLength.class.getName()); //26

        putNameMap(ROUTE, Route.class.getName()); //27

        putNameMap(CONTACT, Contact.class.getName()); //28

        putNameMap(WWW_AUTHENTICATE, WWWAuthenticate.class.getName()); //29

        putNameMap(MAX_FORWARDS, MaxForwards.class.getName()); //30

        putNameMap(ORGANIZATION, Organization.class.getName()); //31

        putNameMap(PROXY_AUTHORIZATION, ProxyAuthorization.class.getName()); //32

        putNameMap(PROXY_REQUIRE, ProxyRequire.class.getName()); //33

        putNameMap(REQUIRE, Require.class.getName()); //34

        putNameMap(CONTENT_DISPOSITION, ContentDisposition.class.getName()); //35

        putNameMap(SUBJECT, Subject.class.getName()); //36

        putNameMap(USER_AGENT, UserAgent.class.getName()); //37

        putNameMap(WARNING, Warning.class.getName()); //38

        putNameMap(PRIORITY, Priority.class.getName()); //39

        putNameMap(DATE, SIPDateHeader.class.getName()); //40

        putNameMap(EXPIRES, Expires.class.getName()); //41

        putNameMap(SUPPORTED, Supported.class.getName()); //42

        putNameMap(REPLY_TO, ReplyTo.class.getName()); // 43

        putNameMap(SUBSCRIPTION_STATE, SubscriptionState.class.getName()); //44

        putNameMap(EVENT, Event.class.getName()); //45

        putNameMap(ALLOW_EVENTS, AllowEvents.class.getName()); //46


        // pmusgrave - extensions
        putNameMap(REFERRED_BY, "ReferredBy");
        putNameMap(SESSION_EXPIRES, "SessionExpires");
        putNameMap(MIN_SE, "MinSE");
        putNameMap(REPLACES, "Replaces");
        // jean deruelle
        putNameMap(JOIN, "Join");


        // IMS Specific headers.

        putNameMap(PAccessNetworkInfoHeader.NAME, PAccessNetworkInfo.class.getName());

        putNameMap(PAssertedIdentityHeader.NAME, PAssertedIdentity.class.getName());

        putNameMap(PAssociatedURIHeader.NAME, PAssociatedURI.class.getName());

        putNameMap(PCalledPartyIDHeader.NAME, PCalledPartyID.class.getName());

        putNameMap(PChargingFunctionAddressesHeader.NAME,  PChargingFunctionAddresses.class.getName());

        putNameMap(PChargingVectorHeader.NAME,PChargingVector.class.getName());

        putNameMap(PMediaAuthorizationHeader.NAME,PMediaAuthorization.class.getName());

        putNameMap(Path.NAME, Path.class.getName());

        putNameMap(PPreferredIdentity.NAME, PPreferredIdentity.class.getName());

        putNameMap(Privacy.NAME,Privacy.class.getName());

        putNameMap(ServiceRoute.NAME, ServiceRoute.class.getName());

        putNameMap(PVisitedNetworkID.NAME, PVisitedNetworkID.class.getName());



    }
}
