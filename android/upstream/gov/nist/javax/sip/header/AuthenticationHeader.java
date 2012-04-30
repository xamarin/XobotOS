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
/*****************************************************************************
 * Product of NIST/ITL Advanced Networking Technologies Division (ANTD).     *
******************************************************************************/
package gov.nist.javax.sip.header;

import gov.nist.core.*;
import gov.nist.javax.sip.header.ims.ParameterNamesIms;

import java.text.ParseException;
 /*
 * 2005/06/12: geir.hedemark@telio.no: Changed behaviour of qop parameter in
 *           Authorization header - removed quoting of string according to
 *          RFC3261, BNF element "message-qop" (as opposed to "qop-options",
 *           which is quoted.
 */

/**
 * The generic AuthenticationHeader
 *
 * @author Olivier Deruelle
 * @author M. Ranganathan <br/>
 * @since 1.1
 * @version 1.2 $Revision: 1.13 $ $Date: 2009/10/18 13:46:32 $
 *
 *
 */
public abstract class AuthenticationHeader extends ParametersHeader {

    public static final String DOMAIN = ParameterNames.DOMAIN;

    public static final String REALM = ParameterNames.REALM;

    public static final String OPAQUE = ParameterNames.OPAQUE;

    public static final String ALGORITHM = ParameterNames.ALGORITHM;

    public static final String QOP = ParameterNames.QOP;

    public static final String STALE = ParameterNames.STALE;

    public static final String SIGNATURE = ParameterNames.SIGNATURE;

    public static final String RESPONSE = ParameterNames.RESPONSE;

    public static final String SIGNED_BY = ParameterNames.SIGNED_BY;

    public static final String NC = ParameterNames.NC;

    public static final String URI = ParameterNames.URI;

    public static final String USERNAME = ParameterNames.USERNAME;

    public static final String CNONCE = ParameterNames.CNONCE;

    public static final String NONCE = ParameterNames.NONCE;

    public static final String IK = ParameterNamesIms.IK;
    public static final String CK = ParameterNamesIms.CK;
    public static final String INTEGRITY_PROTECTED = ParameterNamesIms.INTEGRITY_PROTECTED;

    protected String scheme;

    public AuthenticationHeader(String name) {
        super(name);
        parameters.setSeparator(Separators.COMMA); // oddball
        this.scheme = ParameterNames.DIGEST;
    }

    public AuthenticationHeader() {
        super();
        parameters.setSeparator(Separators.COMMA);
    }

    /**
     * set the specified parameter. Bug reported by Dominic Sparks.
     *
     * @param name --
     *            name of the parameter
     * @param value --
     *            value of the parameter.
     */
    public void setParameter(String name, String value) throws ParseException {
        NameValue nv = super.parameters.getNameValue(name.toLowerCase());
        if (nv == null) {
            nv = new NameValue(name, value);
            if (name.equalsIgnoreCase(ParameterNames.QOP)
                    || name.equalsIgnoreCase(ParameterNames.REALM)
                    || name.equalsIgnoreCase(ParameterNames.CNONCE)
                    || name.equalsIgnoreCase(ParameterNames.NONCE)
                    || name.equalsIgnoreCase(ParameterNames.USERNAME)
                    || name.equalsIgnoreCase(ParameterNames.DOMAIN)
                    || name.equalsIgnoreCase(ParameterNames.OPAQUE)
                    || name.equalsIgnoreCase(ParameterNames.NEXT_NONCE)
                    || name.equalsIgnoreCase(ParameterNames.URI)
                    || name.equalsIgnoreCase(ParameterNames.RESPONSE )
                    ||name.equalsIgnoreCase(ParameterNamesIms.IK)
                    || name.equalsIgnoreCase(ParameterNamesIms.CK)
                    || name.equalsIgnoreCase(ParameterNamesIms.INTEGRITY_PROTECTED)) {
                if (((this instanceof Authorization) || (this instanceof ProxyAuthorization))
                        && name.equalsIgnoreCase(ParameterNames.QOP)) {
                    // NOP, QOP not quoted in authorization headers
                } else {
                    nv.setQuotedValue();
                }
                if (value == null)
                    throw new NullPointerException("null value");
                if (value.startsWith(Separators.DOUBLE_QUOTE))
                    throw new ParseException(value
                            + " : Unexpected DOUBLE_QUOTE", 0);
            }
            super.setParameter(nv);
        } else
            nv.setValueAsObject(value);

    }

    /**
     * This is only used for the parser interface.
     *
     * @param challenge --
     *            the challenge from which the parameters are extracted.
     */
    public void setChallenge(Challenge challenge) {
        this.scheme = challenge.scheme;
        super.parameters = challenge.authParams;
    }

    /**
     * Encode in canonical form.
     *
     * @return canonical string.
     */
    public String encodeBody() {
        this.parameters.setSeparator(Separators.COMMA);
        return this.scheme + SP + parameters.encode();
    }

    /**
     * Sets the scheme of the challenge information for this
     * AuthenticationHeaderHeader. For example, Digest.
     *
     * @param scheme -
     *            the new string value that identifies the challenge information
     *            scheme.
     */
    public void setScheme(String scheme) {
        this.scheme = scheme;
    }

    /**
     * Returns the scheme of the challenge information for this
     * AuthenticationHeaderHeader.
     *
     * @return the string value of the challenge information.
     */
    public String getScheme() {
        return scheme;
    }

    /**
     * Sets the Realm of the WWWAuthenicateHeader to the <var>realm</var>
     * parameter value. Realm strings MUST be globally unique. It is RECOMMENDED
     * that a realm string contain a hostname or domain name. Realm strings
     * SHOULD present a human-readable identifier that can be rendered to a
     * user.
     *
     * @param realm
     *            the new Realm String of this WWWAuthenicateHeader.
     * @throws ParseException
     *             which signals that an error has been reached unexpectedly
     *             while parsing the realm.
     */
    public void setRealm(String realm) throws ParseException {
        if (realm == null)
            throw new NullPointerException(
                    "JAIN-SIP Exception, "
                            + " AuthenticationHeader, setRealm(), The realm parameter is null");
        setParameter(ParameterNames.REALM, realm);
    }

    /**
     * Returns the Realm value of this WWWAuthenicateHeader. This convenience
     * method returns only the realm of the complete Challenge.
     *
     * @return the String representing the Realm information, null if value is
     *         not set.
     * @since v1.1
     */
    public String getRealm() {
        return getParameter(ParameterNames.REALM);
    }

    /**
     * Sets the Nonce of the WWWAuthenicateHeader to the <var>nonce</var>
     * parameter value.
     *
     * @param nonce -
     *            the new nonce String of this WWWAuthenicateHeader.
     * @throws ParseException
     *             which signals that an error has been reached unexpectedly
     *             while parsing the nonce value.
     * @since v1.1
     */
    public void setNonce(String nonce) throws ParseException {
        if (nonce == null)
            throw new NullPointerException(
                    "JAIN-SIP Exception, "
                            + " AuthenticationHeader, setNonce(), The nonce parameter is null");
        setParameter(NONCE, nonce);
    }

    /**
     * Returns the Nonce value of this WWWAuthenicateHeader.
     *
     * @return the String representing the nonce information, null if value is
     *         not set.
     * @since v1.1
     */
    public String getNonce() {
        return getParameter(ParameterNames.NONCE);
    }

    /**
     * Sets the URI of the WWWAuthenicateHeader to the <var>uri</var> parameter
     * value.
     *
     * @param uri -
     *            the new URI of this AuthenicationHeader.
     * @since v1.1
     *
     * Note that since 1.2 this is no longer applicable to the WWW-Authenticate
     * and Proxy-Authenticate headers
     */
    public void setURI(javax.sip.address.URI uri) {
        if (uri != null) {
            NameValue nv = new NameValue(ParameterNames.URI, uri);
            nv.setQuotedValue();
            super.parameters.set(nv);
        } else {
            throw new NullPointerException("Null URI");
        }
    }

    /**
     * Returns the URI value of this WWWAuthenicateHeader, for example
     * DigestURI.
     *
     * @return the URI representing the URI information, null if value is not
     *         set.
     * @since v1.1
     *
     * Note that since 1.2 this is no longer applicable to the WWW-Authenticate
     * and Proxy-Authenticate headers
     */
    public javax.sip.address.URI getURI() {
        return getParameterAsURI(ParameterNames.URI);
    }

    /**
     * Sets the Algorithm of the WWWAuthenicateHeader to the new <var>algorithm</var>
     * parameter value.
     *
     * @param algorithm -
     *            the new algorithm String of this WWWAuthenicateHeader.
     * @throws ParseException
     *             which signals that an error has been reached unexpectedly
     *             while parsing the algorithm value.
     * @since v1.1
     */
    public void setAlgorithm(String algorithm) throws ParseException {
        if (algorithm == null)
            throw new NullPointerException("null arg");
        setParameter(ParameterNames.ALGORITHM, algorithm);
    }

    /**
     * Returns the Algorithm value of this WWWAuthenicateHeader.
     *
     * @return the String representing the Algorithm information, null if the
     *         value is not set.
     * @since v1.1
     */
    public String getAlgorithm() {
        return getParameter(ParameterNames.ALGORITHM);
    }

    /**
     * Sets the Qop value of the WWWAuthenicateHeader to the new <var>qop</var>
     * parameter value.
     *
     * @param qop -
     *            the new Qop string of this WWWAuthenicateHeader.
     * @throws ParseException
     *             which signals that an error has been reached unexpectedly
     *             while parsing the Qop value.
     * @since v1.1
     */
    public void setQop(String qop) throws ParseException {
        if (qop == null)
            throw new NullPointerException("null arg");
        setParameter(ParameterNames.QOP, qop);
    }

    /**
     * Returns the Qop value of this WWWAuthenicateHeader.
     *
     * @return the string representing the Qop information, null if the value is
     *         not set.
     * @since v1.1
     */
    public String getQop() {
        return getParameter(ParameterNames.QOP);
    }

    /**
     * Sets the Opaque value of the WWWAuthenicateHeader to the new <var>opaque</var>
     * parameter value.
     *
     * @param opaque -
     *            the new Opaque string of this WWWAuthenicateHeader.
     * @throws ParseException
     *             which signals that an error has been reached unexpectedly
     *             while parsing the opaque value.
     * @since v1.1
     */
    public void setOpaque(String opaque) throws ParseException {
        if (opaque == null)
            throw new NullPointerException("null arg");
        setParameter(ParameterNames.OPAQUE, opaque);
    }

    /**
     * Returns the Opaque value of this WWWAuthenicateHeader.
     *
     * @return the String representing the Opaque information, null if the value
     *         is not set.
     * @since v1.1
     */
    public String getOpaque() {
        return getParameter(ParameterNames.OPAQUE);
    }

    /**
     * Sets the Domain of the WWWAuthenicateHeader to the <var>domain</var>
     * parameter value.
     *
     * @param domain -
     *            the new Domain string of this WWWAuthenicateHeader.
     * @throws ParseException
     *             which signals that an error has been reached unexpectedly
     *             while parsing the domain.
     * @since v1.1
     */
    public void setDomain(String domain) throws ParseException {
        if (domain == null)
            throw new NullPointerException("null arg");
        setParameter(ParameterNames.DOMAIN, domain);
    }

    /**
     * Returns the Domain value of this WWWAuthenicateHeader.
     *
     * @return the String representing the Domain information, null if value is
     *         not set.
     * @since v1.1
     */
    public String getDomain() {
        return getParameter(ParameterNames.DOMAIN);
    }

    /**
     * Sets the value of the stale parameter of the WWWAuthenicateHeader to the
     * <var>stale</var> parameter value.
     *
     * @param stale -
     *            the Boolean.valueOf value of the stale parameter.
     * @since v1.1
     */
    public void setStale(boolean stale) {
        setParameter(new NameValue(ParameterNames.STALE, Boolean.valueOf(stale)));
    }

    /**
     * Returns the boolean value of the state paramater of this
     * WWWAuthenicateHeader.
     *
     * @return the boolean representing if the challenge is stale.
     * @since v1.1
     */
    public boolean isStale() {
        return this.getParameterAsBoolean(ParameterNames.STALE);
    }

    /**
     * Set the CNonce.
     *
     * @param cnonce --
     *            a nonce string.
     */
    public void setCNonce(String cnonce) throws ParseException {
        this.setParameter(ParameterNames.CNONCE, cnonce);
    }

    /**
     * Get the CNonce.
     *
     * @return the cnonce value.
     */
    public String getCNonce() {
        return getParameter(ParameterNames.CNONCE);
    }

    public int getNonceCount() {
        return this.getParameterAsHexInt(ParameterNames.NC);

    }

    /**
     * Set the nonce count pakrameter. Bug fix sent in by Andreas Bystr�m
     */

    public void setNonceCount(int param) throws java.text.ParseException {
        if (param < 0)
            throw new ParseException("bad value", 0);

        String nc = Integer.toHexString(param);

        String base = "00000000";
        nc = base.substring(0, 8 - nc.length()) + nc;
        this.setParameter(ParameterNames.NC, nc);

    }

    /**
     * Get the RESPONSE value (or null if it does not exist).
     *
     * @return String response parameter value.
     */
    public String getResponse() {
        return (String) getParameterValue(ParameterNames.RESPONSE);
    }

    /**
     * Set the Response.
     *
     * @param response
     *            to set.
     */
    public void setResponse(String response) throws ParseException {
        if (response == null)
            throw new NullPointerException("Null parameter");
        // Bug fix from Andreas Bystr�m
        this.setParameter(RESPONSE, response);
    }

    /**
     * Returns the Username value of this AuthorizationHeader. This convenience
     * method returns only the username of the complete Response.
     *
     * @return the String representing the Username information, null if value
     *         is not set.
     *
     *
     *
     */
    public String getUsername() {
        return (String) getParameter(ParameterNames.USERNAME);
    }

    /**
     * Sets the Username of the AuthorizationHeader to the <var>username</var>
     * parameter value.
     *
     * @param username
     *            the new Username String of this AuthorizationHeader.
     *
     * @throws ParseException
     *             which signals that an error has been reached
     *
     * unexpectedly while parsing the username.
     *
     *
     *
     */
    public void setUsername(String username) throws ParseException {
        this.setParameter(ParameterNames.USERNAME, username);
    }

    public void setIK(String ik) throws ParseException {
        if (ik == null)
            throw new NullPointerException(
                "JAIN-SIP Exception, "
                    + " AuthenticationHeader, setIk(), The auth-param IK parameter is null");
        setParameter(IK, ik);
    }

    public String getIK() {
        return getParameter(ParameterNamesIms.IK);
    }

    public void setCK(String ck) throws ParseException {
        if (ck == null)
            throw new NullPointerException(
                "JAIN-SIP Exception, "
                    + " AuthenticationHeader, setCk(), The auth-param CK parameter is null");
        setParameter(CK, ck);
    }

    public String getCK() {
        return getParameter(ParameterNamesIms.CK);
    }


    public void setIntegrityProtected(String integrityProtected) throws ParseException
    {
        if (integrityProtected == null)
            throw new NullPointerException(
                "JAIN-SIP Exception, "
                    + " AuthenticationHeader, setIntegrityProtected(), The integrity-protected parameter is null");

        setParameter(INTEGRITY_PROTECTED, integrityProtected);
    }



    public String getIntegrityProtected() {
        return getParameter(ParameterNamesIms.INTEGRITY_PROTECTED);
    }

}
