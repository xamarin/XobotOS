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
package gov.nist.javax.sip.address;

/*
 *Bug fix contributions
 *Daniel J. Martinez Manzano <dani@dif.um.es>
 *Stefan Marx.
 *pmusgrave@newheights.com (Additions for gruu and outbound drafts)
 *Jeroen van Bemmel ( additions for SCTP transport )
 */
import gov.nist.core.*;
import java.util.*;
import java.text.ParseException;

import javax.sip.PeerUnavailableException;
import javax.sip.SipFactory;
import javax.sip.address.SipURI;
import javax.sip.header.Header;
import javax.sip.header.HeaderFactory;


/**
 * Implementation of the SipURI interface.
 *
 *
 * @author M. Ranganathan   <br/>
 * @version 1.2 $Revision: 1.22 $ $Date: 2009/11/15 19:50:45 $
 *
 *
 *
 */
public class SipUri extends GenericURI implements javax.sip.address.SipURI , SipURIExt{

 
    private static final long serialVersionUID = 7749781076218987044L;

    /** Authority for the uri.
     */

    protected Authority authority;

    /** uriParms list
     */
    protected NameValueList uriParms;

    /** qheaders list
     */
    protected NameValueList qheaders;

    /** telephoneSubscriber field
     */
    protected TelephoneNumber telephoneSubscriber;

    public SipUri() {
        this.scheme = SIP;
        this.uriParms = new NameValueList();
        this.qheaders = new NameValueList();
        this.qheaders.setSeparator("&");
    }

    /** Constructor given the scheme.
    * The scheme must be either Sip or Sips
    */
    public void setScheme(String scheme) {
        if (scheme.compareToIgnoreCase(SIP) != 0
            && scheme.compareToIgnoreCase(SIPS) != 0)
            throw new IllegalArgumentException("bad scheme " + scheme);
        this.scheme = scheme.toLowerCase();
    }

    /** Get the scheme.
     */
    public String getScheme() {
        return scheme;
    }

    /**
     * clear all URI Parameters.
     * @since v1.0
     */
    public void clearUriParms() {
        uriParms = new NameValueList();
    }
    /**
    *Clear the password from the user part if it exists.
    */
    public void clearPassword() {
        if (this.authority != null) {
            UserInfo userInfo = authority.getUserInfo();
            if (userInfo != null)
                userInfo.clearPassword();
        }
    }

    /** Get the authority.
    */
    public Authority getAuthority() {
        return this.authority;
    }

    /**
     * Clear all Qheaders.
     */
    public void clearQheaders() {
        qheaders = new NameValueList();
    }

    /**
     * Compare two URIs and return true if they are equal.
     * @param that the object to compare to.
     * @return true if the object is equal to this object.
     *
     * JvB: Updated to define equality in terms of API methods, according to the rules
     * in RFC3261 section 19.1.4
     *
     * Jean Deruelle: Updated to define equality of API methods, according to the rules
     * in RFC3261 section 19.1.4 convert potential ie :
     *    %HEX HEX encoding parts of the URI before comparing them
     *    transport param added in comparison
     *    header equality enforced in comparison
     *
     */
    @SuppressWarnings("unchecked")
    @Override
    public boolean equals(Object that) {

        // Shortcut for same object
        if (that==this) return true;

        if (that instanceof SipURI) {
            final SipURI a = this;
            final SipURI b = (SipURI) that;

            // A SIP and SIPS URI are never equivalent
            if ( a.isSecure() ^ b.isSecure() ) return false;

            // For two URIs to be equal, the user, password, host, and port
            // components must match; comparison of userinfo is case-sensitive
            if (a.getUser()==null ^ b.getUser()==null) return false;
            if (a.getUserPassword()==null ^ b.getUserPassword()==null) return false;

            if (a.getUser()!=null && !RFC2396UrlDecoder.decode(a.getUser()).equals(RFC2396UrlDecoder.decode(b.getUser()))) return false;
            if (a.getUserPassword()!=null && !RFC2396UrlDecoder.decode(a.getUserPassword()).equals(RFC2396UrlDecoder.decode(b.getUserPassword()))) return false;
            if (a.getHost() == null ^ b.getHost() == null) return false;
            if (a.getHost() != null && !a.getHost().equalsIgnoreCase(b.getHost())) return false;
            if (a.getPort() != b.getPort()) return false;

            // URI parameters
            for (Iterator i = a.getParameterNames(); i.hasNext();) {
                String pname = (String) i.next();

                String p1 = a.getParameter(pname);
                String p2 = b.getParameter(pname);

                // those present in both must match (case-insensitive)
                if (p1!=null && p2!=null && !RFC2396UrlDecoder.decode(p1).equalsIgnoreCase(RFC2396UrlDecoder.decode(p2))) return false;
            }

            // transport, user, ttl or method must match when present in either
            if (a.getTransportParam()==null ^ b.getTransportParam()==null) return false;
            if (a.getUserParam()==null ^ b.getUserParam()==null) return false;
            if (a.getTTLParam()==-1 ^ b.getTTLParam()==-1) return false;
            if (a.getMethodParam()==null ^ b.getMethodParam()==null) return false;
            if (a.getMAddrParam()==null ^ b.getMAddrParam()==null) return false;

            // Headers: must match according to their definition.
            if(a.getHeaderNames().hasNext() && !b.getHeaderNames().hasNext()) return false;
            if(!a.getHeaderNames().hasNext() && b.getHeaderNames().hasNext()) return false;

            if(a.getHeaderNames().hasNext() && b.getHeaderNames().hasNext()) {
                HeaderFactory headerFactory = null;
                try {
                    headerFactory = SipFactory.getInstance().createHeaderFactory();
                } catch (PeerUnavailableException e) {
                    Debug.logError("Cannot get the header factory to parse the header of the sip uris to compare", e);
                    return false;
                }
                for (Iterator i = a.getHeaderNames(); i.hasNext();) {
                    String hname = (String) i.next();

                    String h1 = a.getHeader(hname);
                    String h2 = b.getHeader(hname);

                    if(h1 == null && h2 != null) return false;
                    if(h2 == null && h1 != null) return false;
                    // The following check should not be needed but we add it for findbugs.
                    if(h1 == null && h2 == null) continue; 
                    try {
                        Header header1 = headerFactory.createHeader(hname, RFC2396UrlDecoder.decode(h1));
                        Header header2 = headerFactory.createHeader(hname, RFC2396UrlDecoder.decode(h2));
                        // those present in both must match according to the equals method of the corresponding header
                        if (!header1.equals(header2)) return false;
                    } catch (ParseException e) {
                        Debug.logError("Cannot parse one of the header of the sip uris to compare " + a + " " + b, e);
                        return false;
                    }
                }
            }

            // Finally, we can conclude that they are indeed equal
            return true;
        }
        return false;
    }

    /**
     * Construct a URL from the parsed structure.
     * @return String
     */
    public String encode() {
        return encode(new StringBuffer()).toString();
    }

    public StringBuffer encode(StringBuffer buffer) {
        buffer.append(scheme).append(COLON);
        if (authority != null)
            authority.encode(buffer);
        if (!uriParms.isEmpty()) {
            buffer.append(SEMICOLON);
            uriParms.encode(buffer);
        }
        if (!qheaders.isEmpty()) {
            buffer.append(QUESTION);
            qheaders.encode(buffer);
        }
        return buffer;
    }

    /** Return a string representation.
    *
    *@return the String representation of this URI.
    *
    */
    public String toString() {
        return this.encode();
    }

    /**
     * getUser@host
     * @return user@host portion of the uri (null if none exists).
     *
     * Peter Musgrave - handle null user
     */
    public String getUserAtHost() {
        String user = "";
        if (authority.getUserInfo() != null)
            user = authority.getUserInfo().getUser();

        String host = authority.getHost().encode();
        StringBuffer s = null;
        if (user.equals("")) {
            s = new StringBuffer();
        } else {
            s = new StringBuffer(user).append(AT);
        }
        return s.append(host).toString();
    }

    /**
     * getUser@host
     * @return user@host portion of the uri (null if none exists).
     */
    public String getUserAtHostPort() {
        String user = "";
        if (authority.getUserInfo() != null)
            user = authority.getUserInfo().getUser();

        String host = authority.getHost().encode();
        int port = authority.getPort();
        // If port not set assign the default.
        StringBuffer s = null;
        if (user.equals("")) {
            s = new StringBuffer();
        } else {
            s = new StringBuffer(user).append(AT);
        }
        if (port != -1) {
            return s.append(host).append(COLON).append(port).toString();
        } else
            return s.append(host).toString();

    }

    /**
     * get the parameter (do a name lookup) and return null if none exists.
     * @param parmname Name of the parameter to get.
     * @return Parameter of the given name (null if none exists).
     */
    public Object getParm(String parmname) {
        Object obj = uriParms.getValue(parmname);
        return obj;
    }

    /**
     * Get the method parameter.
     * @return Method parameter.
     */
    public String getMethod() {
        return (String) getParm(METHOD);
    }

    /**
     * Accessor for URI parameters
     * @return A name-value list containing the parameters.
     */
    public NameValueList getParameters() {
        return uriParms;
    }

    /** Remove the URI parameters.
    *
    */
    public void removeParameters() {
        this.uriParms = new NameValueList();
    }

    /**
     * Accessor forSIPObjects
     * @return Get the query headers (that appear after the ? in
     * the URL)
     */
    public NameValueList getQheaders() {
        return qheaders;
    }

    /**
     * Get the urse parameter.
     * @return User parameter (user= phone or user=ip).
     */
    public String getUserType() {
        return (String) uriParms.getValue(USER);
    }

    /**
     * Get the password of the user.
     * @return User password when it embedded as part of the uri
     * ( a very bad idea).
     */
    public String getUserPassword() {
        if (authority == null)
            return null;
        return authority.getPassword();
    }

    /** Set the user password.
     *@param password - password to set.
     */
    public void setUserPassword(String password) {
        if (this.authority == null)
            this.authority = new Authority();
        authority.setPassword(password);
    }

    /**
     * Returns the stucture corresponding to the telephone number
     * provided that the user is a telephone subscriber.
     * @return TelephoneNumber part of the url (only makes sense
     * when user = phone is specified)
     */
    public TelephoneNumber getTelephoneSubscriber() {
        if (telephoneSubscriber == null) {

            telephoneSubscriber = new TelephoneNumber();
        }
        return telephoneSubscriber;
    }

    /**
     * Get the host and port of the server.
     * @return get the host:port part of the url parsed into a
     * structure.
     */
    public HostPort getHostPort() {

        if (authority == null || authority.getHost() == null )
            return null;
        else {
            return authority.getHostPort();
        }
    }

    /** Get the port from the authority field.
    *
    *@return the port from the authority field.
    */
    public int getPort() {
        HostPort hp = this.getHostPort();
        if (hp == null)
            return -1;
        return hp.getPort();
    }

    /** Get the host protion of the URI.
    * @return the host portion of the url.
    */
    public String getHost() {
        if ( authority == null) return null;
        else if (authority.getHost() == null ) return null;
        else return authority.getHost().encode();
    }

    /**
     * returns true if the user is a telephone subscriber.
     *  If the host is an Internet telephony
     * gateway, a telephone-subscriber field MAY be used instead
     * of a user field. The telephone-subscriber field uses the
     * notation of RFC 2806 [19]. Any characters of the un-escaped
     * "telephone-subscriber" that are not either in the set
     * "unreserved" or "user-unreserved" MUST be escaped. The set
     * of characters not reserved in the RFC 2806 description of
     * telephone-subscriber contains a number of characters in
     * various syntax elements that need to be escaped when used
     * in SIP URLs, for example quotation marks (%22), hash (%23),
     * colon (%3a), at-sign (%40) and the "unwise" characters,
     * i.e., punctuation of %5b and above.
     *
     * The telephone number is a special case of a user name and
     * cannot be distinguished by a BNF. Thus, a URL parameter,
     * user, is added to distinguish telephone numbers from user
     * names.
     *
     * The user parameter value "phone" indicates that the user
     * part contains a telephone number. Even without this
     * parameter, recipients of SIP URLs MAY interpret the pre-@
     * part as a telephone number if local restrictions on the
     * @return true if the user is a telephone subscriber.
     */
    public boolean isUserTelephoneSubscriber() {
        String usrtype = (String) uriParms.getValue(USER);
        if (usrtype == null)
            return false;
        return usrtype.equalsIgnoreCase(PHONE);
    }

    /**
     *remove the ttl value from the parameter list if it exists.
     */
    public void removeTTL() {
        if (uriParms != null)
            uriParms.delete(TTL);
    }

    /**
     *Remove the maddr param if it exists.
     */
    public void removeMAddr() {
        if (uriParms != null)
            uriParms.delete(MADDR);
    }

    /**
     *Delete the transport string.
     */
    public void removeTransport() {
        if (uriParms != null)
            uriParms.delete(TRANSPORT);
    }

    /** Remove a header given its name (provided it exists).
     * @param name name of the header to remove.
     */
    public void removeHeader(String name) {
        if (qheaders != null)
            qheaders.delete(name);
    }

    /** Remove all headers.
     */
    public void removeHeaders() {
        qheaders = new NameValueList();
    }

    /**
     * Set the user type.
     */
    public void removeUserType() {
        if (uriParms != null)
            uriParms.delete(USER);
    }

    /**
     *remove the port setting.
     */
    public void removePort() {
        authority.removePort();
    }

    /**
     * remove the Method.
     */
    public void removeMethod() {
        if (uriParms != null)
            uriParms.delete(METHOD);
    }

    /** Sets the user of SipURI. The identifier of a particular resource at
     * the host being addressed. The user and the user password including the
     * "at" sign make up the user-info.
     *
     * @param uname The new String value of the user.
     * @throws ParseException which signals that an error has been reached
     * unexpectedly while parsing the user value.
     */
    public void setUser(String uname) {
        if (this.authority == null) {
            this.authority = new Authority();
        }

        this.authority.setUser(uname);
    }

    /** Remove the user.
     */
    public void removeUser() {
        this.authority.removeUserInfo();
    }

    /** Set the default parameters for this URI.
     * Do nothing if the parameter is already set to some value.
     * Otherwise set it to the given value.
     * @param name Name of the parameter to set.
     * @param value value of the parameter to set.
     */
    public void setDefaultParm(String name, Object value) {
        if (uriParms.getValue(name) == null) {
            NameValue nv = new NameValue(name, value);
            uriParms.set(nv);
        }
    }

    /** Set the authority member
     * @param authority Authority to set.
     */
    public void setAuthority(Authority authority) {
        this.authority = authority;
    }

    /** Set the host for this URI.
     * @param h host to set.
     */
    public void setHost(Host h) {
        if (this.authority == null)
            this.authority = new Authority();
        this.authority.setHost(h);
    }

    /** Set the uriParms member
     * @param parms URI parameters to set.
     */
    public void setUriParms(NameValueList parms) {
        uriParms = parms;
    }

    /**
     * Set a given URI parameter. Note - parameter must be properly
    *  encoded before the function is called.
     * @param name Name of the parameter to set.
     * @param value value of the parameter to set.
     */
    public void setUriParm(String name, Object value) {
        NameValue nv = new NameValue(name, value);
        uriParms.set(nv);
    }

    /** Set the qheaders member
     * @param parms query headers to set.
     */
    public void setQheaders(NameValueList parms) {
        qheaders = parms;
    }

    /**
     * Set the MADDR parameter .
     * @param mAddr Host Name to set
     */
    public void setMAddr(String mAddr) {
        NameValue nameValue = uriParms.getNameValue(MADDR);
        Host host = new Host();
        host.setAddress(mAddr);
        if (nameValue != null)
            nameValue.setValueAsObject(host);
        else {
            nameValue = new NameValue(MADDR, host);
            uriParms.set(nameValue);
        }
    }

    /** Sets the value of the user parameter. The user URI parameter exists to
     * distinguish telephone numbers from user names that happen to look like
     * telephone numbers.  This is equivalent to setParameter("user", user).
     *
     * @param usertype New value String value of the method parameter
     */
    public void setUserParam(String usertype) {
        uriParms.set(USER, usertype);
    }

    /**
     * Set the Method
     * @param method method parameter
     */
    public void setMethod(String method) {
        uriParms.set(METHOD, method);
    }

    /**
    * Sets ISDN subaddress of SipURL
    * @param isdnSubAddress ISDN subaddress
    */
    public void setIsdnSubAddress(String isdnSubAddress) {
        if (telephoneSubscriber == null)
            telephoneSubscriber = new TelephoneNumber();
        telephoneSubscriber.setIsdnSubaddress(isdnSubAddress);
    }

    /**
     * Set the telephone subscriber field.
     * @param tel Telephone subscriber field to set.
     */
    public void setTelephoneSubscriber(TelephoneNumber tel) {
        telephoneSubscriber = tel;
    }

    /** set the port to a given value.
     * @param p Port to set.
     */
    public void setPort(int p) {
        if (authority == null)
            authority = new Authority();
        authority.setPort(p);
    }

    /**
     * Boolean to check if a parameter of a given name exists.
     * @param name Name of the parameter to check on.
     * @return a boolean indicating whether the parameter exists.
     */
    public boolean hasParameter(String name) {

        return uriParms.getValue(name) != null;
    }

    /**
     * Set the query header when provided as a name-value pair.
     * @param nameValue qeuery header provided as a name,value pair.
     */
    public void setQHeader(NameValue nameValue) {
        this.qheaders.set(nameValue);
    }

    /** Set the parameter as given.
     *@param nameValue - parameter to set.
     */
    public void setUriParameter(NameValue nameValue) {
        this.uriParms.set(nameValue);
    }

    /** Return true if the transport parameter is defined.
     * @return true if transport appears as a parameter and false otherwise.
     */
    public boolean hasTransport() {
        return hasParameter(TRANSPORT);
    }

    /**
     * Remove a parameter given its name
     * @param name -- name of the parameter to remove.
     */
    public void removeParameter(String name) {
        uriParms.delete(name);
    }

    /** Set the hostPort field of the imbedded authority field.
     *@param hostPort is the hostPort to set.
     */
    public void setHostPort(HostPort hostPort) {
        if (this.authority == null) {
            this.authority = new Authority();
        }
        authority.setHostPort(hostPort);
    }

    /** clone this.
     */
    public Object clone() {
        SipUri retval = (SipUri) super.clone();
        if (this.authority != null)
            retval.authority = (Authority) this.authority.clone();
        if (this.uriParms != null)
            retval.uriParms = (NameValueList) this.uriParms.clone();
        if (this.qheaders != null)
            retval.qheaders = (NameValueList) this.qheaders.clone();
        if (this.telephoneSubscriber != null)
            retval.telephoneSubscriber = (TelephoneNumber) this.telephoneSubscriber.clone();
        return retval;
    }

    /**
     * Returns the value of the named header, or null if it is not set.
     * SIP/SIPS URIs may specify headers. As an example, the URI
     * sip:joe@jcp.org?priority=urgent has a header "priority" whose
     * value is "urgent".
     *
     * @param name name of header to retrieve
     * @return the value of specified header
     */
    public String getHeader(String name) {
        return this.qheaders.getValue(name) != null
            ? this.qheaders.getValue(name).toString()
            : null;

    }

    /**
     * Returns an Iterator over the names (Strings) of all headers present
     * in this SipURI.
     *
     * @return an Iterator over all the header names
     */
    public Iterator<String> getHeaderNames() {
        return this.qheaders.getNames();

    }

    /** Returns the value of the <code>lr</code> parameter, or null if this
     * is not set. This is equivalent to getParameter("lr").
     *
     * @return the value of the <code>lr</code> parameter
     */
    public String getLrParam() {
        boolean haslr = this.hasParameter(LR);
        return haslr ? "true" : null;
    }

    /** Returns the value of the <code>maddr</code> parameter, or null if this
     * is not set. This is equivalent to getParameter("maddr").
     *
     * @return the value of the <code>maddr</code> parameter
     */
    public String getMAddrParam() {
        NameValue maddr = uriParms.getNameValue(MADDR);
        if (maddr == null)
            return null;
        String host = (String) maddr.getValueAsObject();
        return host;
    }

    /**
     * Returns the value of the <code>method</code> parameter, or null if this
     * is not set. This is equivalent to getParameter("method").
     *
     * @return  the value of the <code>method</code> parameter
     */
    public String getMethodParam() {
        return this.getParameter(METHOD);
    }

    /**
     * Returns the value of the named parameter, or null if it is not set. A
     * zero-length String indicates flag parameter.
     *
     * @param name name of parameter to retrieve
     * @return the value of specified parameter
     */
    public String getParameter(String name) {
        Object val = uriParms.getValue(name);
        if (val == null)
            return null;
        if (val instanceof GenericObject)
            return ((GenericObject) val).encode();
        else
            return val.toString();
    }

    /**
     * Returns an Iterator over the names (Strings) of all parameters present
     *
     * in this ParametersHeader.
     *
     *
     *
     * @return an Iterator over all the parameter names
     *
     */
    public Iterator<String> getParameterNames() {
        return this.uriParms.getNames();
    }

    /** Returns the value of the "ttl" parameter, or -1 if this is not set.
     * This method is equivalent to getParameter("ttl").
     *
     * @return the value of the <code>ttl</code> parameter
     */
    public int getTTLParam() {
        Integer ttl = (Integer) uriParms.getValue("ttl");
        if (ttl != null)
            return ttl.intValue();
        else
            return -1;
    }

    /** Returns the value of the "transport" parameter, or null if this is not
     * set. This is equivalent to getParameter("transport").
     *
     * @return the transport paramter of the SipURI
     */
    public String getTransportParam() {
        if (uriParms != null) {
            return (String) uriParms.getValue(TRANSPORT);
        } else
            return null;
    }

    /** Returns the value of the <code>userParam</code>,
     *or null if this is not set.
     * <p>
     * This is equivalent to getParameter("user").
     *
     * @return the value of the <code>userParam</code> of the SipURI
     */
    public String getUser() {
        return authority.getUser();
    }

    /** Returns true if this SipURI is secure i.e. if this SipURI represents a
     * sips URI. A sip URI returns false.
     *
     * @return  <code>true</code> if this SipURI represents a sips URI, and
     * <code>false</code> if it represents a sip URI.
     */
    public boolean isSecure() {
        return this.getScheme().equalsIgnoreCase(SIPS);
    }

    /** This method determines if this is a URI with a scheme of "sip" or "sips".
     *
     * @return true if the scheme is "sip" or "sips", false otherwise.
     */
    public boolean isSipURI() {
        return true;
    }

    /** Sets the value of the specified header fields to be included in a
     * request constructed from the URI. If the header already had a value it
     * will be overwritten.
     *
     * @param name - a String specifying the header name
     * @param value - a String specifying the header value
     */
    public void setHeader(String name, String value) {
        NameValue nv = new NameValue(name, value);
        qheaders.set(nv);

    }

    /**
     * Set the host portion of the SipURI
     *
     * @param host host to set.
     */
    public void setHost(String host) throws ParseException {
        Host h = new Host(host);
        this.setHost(h);
    }

    /** Sets the value of the <code>lr</code> parameter of this SipURI. The lr
     * parameter, when present, indicates that the element responsible for
     * this resource implements the routing mechanisms specified in RFC 3261.
     * This parameter will be used in the URIs proxies place in the
     * Record-Route header field values, and may appear in the URIs in a
     * pre-existing route set.
     */
    public void setLrParam() {
        this.uriParms.set("lr",null);   // JvB: fixed to not add duplicates
    }

    /**
     * Sets the value of the <code>maddr</code> parameter of this SipURI. The
     * maddr parameter indicates the server address to be contacted for this
     * user, overriding any address derived from the host field. This is
     * equivalent to setParameter("maddr", maddr).
     *
     * @param  maddr New value of the <code>maddr</code> parameter
     */
    public void setMAddrParam(String maddr) throws ParseException {
        if (maddr == null)
            throw new NullPointerException("bad maddr");
        setParameter("maddr", maddr);
    }

    /** Sets the value of the <code>method</code> parameter. This specifies
     * which SIP method to use in requests directed at this URI. This is
     * equivalent to setParameter("method", method).
     *
     * @param  method - new value String value of the method parameter
     */
    public void setMethodParam(String method) throws ParseException {
        setParameter("method", method);
    }

    /**
     * Sets the value of the specified parameter. If the parameter already had
     *
     * a value it will be overwritten. A zero-length String indicates flag
     *
     * parameter.
     *
     *
     *
     * @param name - a String specifying the parameter name
     *
     * @param value - a String specifying the parameter value
     *
     * @throws ParseException which signals that an error has been reached
     *
     * unexpectedly while parsing the parameter name or value.
     *
     */
    public void setParameter(String name, String value) throws ParseException {
        if (name.equalsIgnoreCase("ttl")) {
            try {
                Integer.parseInt(value);
            } catch (NumberFormatException ex) {
                throw new ParseException("bad parameter " + value, 0);
            }
        }
        uriParms.set(name,value);
    }

    /** Sets the scheme of this URI to sip or sips depending on whether the
     * argument is true or false. The default value is false.
     *
     * @param secure - the boolean value indicating if the SipURI is secure.
     */
    public void setSecure(boolean secure) {
        if (secure)
            this.scheme = SIPS;
        else
            this.scheme = SIP;
    }

    /** Sets the value of the <code>ttl</code> parameter. The ttl parameter
     * specifies the time-to-live value when packets are sent using UDP
     * multicast. This is equivalent to setParameter("ttl", ttl).
     *
     * @param ttl - new value of the <code>ttl</code> parameter
     */
    public void setTTLParam(int ttl) {
        if (ttl <= 0)
            throw new IllegalArgumentException("Bad ttl value");
        if (uriParms != null) {
            NameValue nv = new NameValue("ttl", Integer.valueOf(ttl));
            uriParms.set(nv);
        }
    }

    /** Sets the value of the "transport" parameter. This parameter specifies
     * which transport protocol to use for sending requests and responses to
     * this entity. The following values are defined: "udp", "tcp", "sctp",
     * "tls", but other values may be used also. This method is equivalent to
     * setParameter("transport", transport). Transport parameter constants
     * are defined in the {@link javax.sip.ListeningPoint}.
     *
     * @param transport - new value for the "transport" parameter
     * @see javax.sip.ListeningPoint
     */
    public void setTransportParam(String transport) throws ParseException {
        if (transport == null)
            throw new NullPointerException("null arg");
        if (transport.compareToIgnoreCase("UDP") == 0
            || transport.compareToIgnoreCase("TLS") == 0
            || transport.compareToIgnoreCase("TCP") == 0
            || transport.compareToIgnoreCase("SCTP") == 0) {
            NameValue nv = new NameValue(TRANSPORT, transport.toLowerCase());
            uriParms.set(nv);
        } else
            throw new ParseException("bad transport " + transport, 0);
    }

    /** Returns the user part of this SipURI, or null if it is not set.
     *
     * @return  the user part of this SipURI
     */
    public String getUserParam() {
        return getParameter("user");

    }

    /** Returns whether the the <code>lr</code> parameter is set. This is
     * equivalent to hasParameter("lr"). This interface has no getLrParam as
     * RFC3261 does not specify any values for the "lr" paramater.
     *
     * @return true if the "lr" parameter is set, false otherwise.
     */
    public boolean hasLrParam() {
        return uriParms.getNameValue("lr") != null;
    }

  
    /**
     * Returns whether the <code>gr</code> parameter is set.
     *
     * Not part on the interface since gruu is not part of the base RFC3261.
     */
    public boolean hasGrParam() {
        return uriParms.getNameValue(GRUU) != null;
    }

    /**
     * Sets the <code>gr</code> parameter.
     *
     * Not part on the interface since gruu is not part of the base RFC3261.
     */
    public void setGrParam(String value) {
            this.uriParms.set(GRUU, value); // JvB: fixed to not add duplicates
    }

    /**
     * Sets the <code>gr</code> parameter.
     *
     * Not part on the interface since gruu is not part of the base RFC3261.
     */
    public String getGrParam() {
            return (String) this.uriParms.getValue(GRUU);   // JvB: fixed to not add duplicates
    }

    /**
     *remove the +sip-instance value from the parameter list if it exists.
     */

}
