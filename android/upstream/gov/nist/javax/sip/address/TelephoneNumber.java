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
package gov.nist.javax.sip.address;

import gov.nist.core.*;

import java.util.Iterator;

/**
 * Telephone number class.
 * @version 1.2
 * @version 1.2 $Revision: 1.10 $ $Date: 2009/07/17 18:57:23 $
 *
 * @author M. Ranganathan
 *
 */
public class TelephoneNumber extends NetObject {
    public static final String POSTDIAL = ParameterNames.POSTDIAL;
    public static final String PHONE_CONTEXT_TAG =
        ParameterNames.PHONE_CONTEXT_TAG;
    public static final String ISUB = ParameterNames.ISUB;
    public static final String PROVIDER_TAG = ParameterNames.PROVIDER_TAG;

    /** isglobal field
     */
    protected boolean isglobal;

    /** phoneNumber field
     */
    protected String phoneNumber;

    /** parmeters list
     */
    protected NameValueList parameters;

    /** Creates new TelephoneNumber */
    public TelephoneNumber() {
        parameters = new NameValueList();
    }

    /** delete the specified parameter.
     * @param name String to set
     */
    public void deleteParm(String name) {
        parameters.delete(name);
    }

    /** get the PhoneNumber field
     * @return String
     */
    public String getPhoneNumber() {
        return phoneNumber;
    }

    /** get the PostDial field
     * @return String
     */
    public String getPostDial() {
        return (String) parameters.getValue(POSTDIAL);
    }

    /**
     * Get the isdn subaddress for this number.
     * @return String
     */
    public String getIsdnSubaddress() {
        return (String) parameters.getValue(ISUB);
    }

    /** returns true if th PostDial field exists
     * @return boolean
     */
    public boolean hasPostDial() {
        return parameters.getValue(POSTDIAL) != null;
    }

    /** return true if this header has parameters.
     * @param pname String to set
     * @return boolean
     */
    public boolean hasParm(String pname) {
        return parameters.hasNameValue(pname);
    }

    /**
     * return true if the isdn subaddress exists.
     * @return boolean
     */
    public boolean hasIsdnSubaddress() {
        return hasParm(ISUB);
    }

    /**
     * is a global telephone number.
     * @return boolean
     */
    public boolean isGlobal() {
        return isglobal;
    }

    /** remove the PostDial field
     */
    public void removePostDial() {
        parameters.delete(POSTDIAL);
    }

    /**
     * Remove the isdn subaddress (if it exists).
     */
    public void removeIsdnSubaddress() {
        deleteParm(ISUB);
    }

    /**
     * Set the list of parameters.
     * @param p NameValueList to set
     */
    public void setParameters(NameValueList p) {
        parameters = p;
    }

    /** set the Global field
     * @param g boolean to set
     */
    public void setGlobal(boolean g) {
        isglobal = g;
    }

    /** set the PostDial field
     * @param p String to set
     */
    public void setPostDial(String p) {
        NameValue nv = new NameValue(POSTDIAL, p);
        parameters.set(nv);
    }

    /** set the specified parameter
     * @param name String to set
     * @param value Object to set
     */
    public void setParm(String name, Object value) {
        NameValue nv = new NameValue(name, value);
        parameters.set(nv);
    }

    /**
     * set the isdn subaddress for this structure.
     * @param isub String to set
     */
    public void setIsdnSubaddress(String isub) {
        setParm(ISUB, isub);
    }

    /** set the PhoneNumber field
     * @param num String to set
     */
    public void setPhoneNumber(String num) {
        phoneNumber = num;
    }

    public String encode() {
        return encode(new StringBuffer()).toString();
    }

    public StringBuffer encode(StringBuffer buffer) {
        if (isglobal)
            buffer.append('+');
        buffer.append(phoneNumber);
        if (!parameters.isEmpty()) {
            buffer.append(SEMICOLON);
            parameters.encode(buffer);
        }
        return buffer;
    }

    /**
     * Returns the value of the named parameter, or null if it is not set. A
     * zero-length String indicates flag parameter.
     *
     * @param name name of parameter to retrieve
     *
     * @return the value of specified parameter
     *
     */
    public String getParameter(String name) {
        Object val = parameters.getValue(name);
        if (val == null)
            return null;
        if (val instanceof GenericObject)
            return ((GenericObject) val).encode();
        else
            return val.toString();
    }

    /**
     *
     * Returns an Iterator over the names (Strings) of all parameters.
     *
     * @return an Iterator over all the parameter names
     *
     */
    public Iterator<String> getParameterNames() {
        return this.parameters.getNames();
    }

    public void removeParameter(String parameter) {
        this.parameters.delete(parameter);
    }

    public void setParameter(String name, String value) {
        NameValue nv = new NameValue(name, value);
        this.parameters.set(nv);
    }

    public Object clone() {
        TelephoneNumber retval = (TelephoneNumber) super.clone();
        if (this.parameters != null)
            retval.parameters = (NameValueList) this.parameters.clone();
        return retval;
    }

    public NameValueList getParameters() {
        return this.parameters;
    }
}
