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
import gov.nist.core.*;

/**
 * Credentials  that are used in authentication and authorization headers.
 * @author M. Ranganathan
 * @version 1.2 $Revision: 1.7 $ $Date: 2009/07/17 18:57:30 $
 * @since 1.1
 */
public class Credentials extends SIPObject {

    /**
     * Comment for <code>serialVersionUID</code>
     */
    private static final long serialVersionUID = -6335592791505451524L;

    private static String DOMAIN = ParameterNames.DOMAIN;
    private static String REALM = ParameterNames.REALM;
    private static String OPAQUE = ParameterNames.OPAQUE;
    private static String RESPONSE = ParameterNames.RESPONSE;
    private static String URI = ParameterNames.URI;
    private static String NONCE = ParameterNames.NONCE;
    private static String CNONCE = ParameterNames.CNONCE;
    private static String USERNAME = ParameterNames.USERNAME;

    protected String scheme;

    /**
     * parameters list.
     */
    protected NameValueList parameters;

    /**
     * Default constructor
     */
    public Credentials() {
        parameters = new NameValueList();
        parameters.setSeparator(COMMA);
    }

    /**
     * get the parameters list.
     * @return NameValueList
     */
    public NameValueList getCredentials() {
        return parameters;
    }

    /**
     * get the scheme field.
     * @return String.
     */
    public String getScheme() {
        return scheme;
    }

    /**
     * Set the scheme member
     * @param s String to set
     */
    public void setScheme(String s) {
        scheme = s;
    }

    /**
     * Set the parameters member
     * @param c NameValueList to set.
     */
    public void setCredentials(NameValueList c) {
        parameters = c;
    }

    public String encode() {
        String retval = scheme;
        if (!parameters.isEmpty()) {
            retval += SP + parameters.encode();
        }
        return retval;
    }

    /*public void setCredential(NameValue nameValue) {
        if (nameValue.getName().compareToIgnoreCase(URI) == 0)
            nameValue.setQuotedValue();
        else if (nameValue.getName().compareToIgnoreCase(NONCE) == 0)
            nameValue.setQuotedValue();
        else if (nameValue.getName().compareToIgnoreCase(REALM) == 0)
            nameValue.setQuotedValue();
        else if (nameValue.getName().compareToIgnoreCase(CNONCE) == 0)
            nameValue.setQuotedValue();
        else if (nameValue.getName().compareToIgnoreCase(RESPONSE) == 0)
            nameValue.setQuotedValue();
        else if (nameValue.getName().compareToIgnoreCase(OPAQUE) == 0)
            nameValue.setQuotedValue();
        else if (nameValue.getName().compareToIgnoreCase(USERNAME) == 0)
            nameValue.setQuotedValue();
        else if (nameValue.getName().compareToIgnoreCase(DOMAIN) == 0)
            nameValue.setQuotedValue();
        parameters.set(nameValue);
    }*/

    public Object clone() {
        Credentials retval = (Credentials) super.clone();
        if (this.parameters != null)
            retval.parameters = (NameValueList) this.parameters.clone();
        return retval;
    }
}
