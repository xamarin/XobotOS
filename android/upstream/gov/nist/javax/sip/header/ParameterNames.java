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
 * of the terms of this agreement.
 *
 */
package gov.nist.javax.sip.header;

/**
 * A list of commonly occuring parameter names. These are for conveniance so as
 * to avoid typo's
 *
 * @version 1.2 $Revision: 1.8 $ $Date: 2009/07/17 18:57:33 $
 * @since 1.1
 *
 * @author M. Ranganathan <br/>
 *
 *
 *
 */
public interface ParameterNames {
    // Issue reported by larryb
    public static final String NEXT_NONCE = "nextnonce";

    public static final String TAG = "tag";

    public static final String USERNAME = "username";

    public static final String URI = "uri";

    public static final String DOMAIN = "domain";

    public static final String CNONCE = "cnonce";

    public static final String PASSWORD = "password";

    public static final String RESPONSE = "response";

    public static final String RESPONSE_AUTH = "rspauth";

    public static final String OPAQUE = "opaque";

    public static final String ALGORITHM = "algorithm";

    public static final String DIGEST = "Digest";

    public static final String SIGNED_BY = "signed-by";

    public static final String SIGNATURE = "signature";

    public static final String NONCE = "nonce";

    // Issue reported by larryb
    public static final String NONCE_COUNT = "nc";

    public static final String PUBKEY = "pubkey";

    public static final String COOKIE = "cookie";

    public static final String REALM = "realm";

    public static final String VERSION = "version";

    public static final String STALE = "stale";

    public static final String QOP = "qop";

    public static final String NC = "nc";

    public static final String PURPOSE = "purpose";

    public static final String CARD = "card";

    public static final String INFO = "info";

    public static final String ACTION = "action";

    public static final String PROXY = "proxy";

    public static final String REDIRECT = "redirect";

    public static final String EXPIRES = "expires";

    public static final String Q = "q";

    public static final String RENDER = "render";

    public static final String SESSION = "session";

    public static final String ICON = "icon";

    public static final String ALERT = "alert";

    public static final String HANDLING = "handling";

    public static final String REQUIRED = "required";

    public static final String OPTIONAL = "optional";

    public static final String EMERGENCY = "emergency";

    public static final String URGENT = "urgent";

    public static final String NORMAL = "normal";

    public static final String NON_URGENT = "non-urgent";

    public static final String DURATION = "duration";

    public static final String BRANCH = "branch";

    public static final String HIDDEN = "hidden";

    public static final String RECEIVED = "received";

    public static final String MADDR = "maddr";

    public static final String TTL = "ttl";

    public static final String TRANSPORT = "transport";

    public static final String TEXT = "text";

    public static final String CAUSE = "cause";

    public static final String ID = "id";

    // @@@ hagai
    public static final String RPORT = "rport";

    // Added pmusgrave (Replaces support)
    public static final String TO_TAG = "to-tag";
    public static final String FROM_TAG = "from-tag";

    // pmusgrave (outbound and gruu)
    // draft-sip-outbouund-08
    // draft-sip-gruu-12
    public static final String SIP_INSTANCE = "+sip.instance";
    public static final String PUB_GRUU = "pub-gruu";
    public static final String TEMP_GRUU = "temp-gruu";
    public static final String GRUU = "gruu";
}
