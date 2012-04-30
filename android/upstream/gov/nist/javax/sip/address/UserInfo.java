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
/*
 * Acknowledgement -- Lamine Brahimi
 * Submitted a bug fix for a this class.
 */
/*******************************************************************************
 * Product of NIST/ITL Advanced Networking Technologies Division (ANTD).       *
 *******************************************************************************/
package gov.nist.javax.sip.address;

/**
 * User information part of a URL.
 *
 * @version 1.2 $Revision: 1.8 $ $Date: 2009/07/17 18:57:23 $
 * @author M. Ranganathan   <br/>
 *
 */
public final class UserInfo extends NetObject {


    private static final long serialVersionUID = 7268593273924256144L;

    /** user field
     */
    protected String user;

    /** password field
     */
    protected String password;

    /** userType field
         */
    protected int userType;

    /** Constant field
     */
    public final static int TELEPHONE_SUBSCRIBER = 1;

    /** constant field
     */
    public final static int USER = 2;

    /** Default constructor
     */
    public UserInfo() {
        super();
    }

    /**
     * Compare for equality.
     * @param obj Object to set
     * @return true if the two headers are equals, false otherwise.
     */
    public boolean equals(Object obj) {
        if (getClass() != obj.getClass()) {
            return false;
        }
        UserInfo other = (UserInfo) obj;
        if (this.userType != other.userType) {
            return false;
        }
        if (!this.user.equalsIgnoreCase(other.user)) {
            return false;
        }
        if (this.password != null && other.password == null)
            return false;

        if (other.password != null && this.password == null)
            return false;

        if (this.password == other.password)
            return true;

        return (this.password.equals(other.password));
    }

    /**
     * Encode the user information as a string.
     * @return String
     */
    public String encode() {
        return encode(new StringBuffer()).toString();
    }

    public StringBuffer encode(StringBuffer buffer) {
        if (password != null)
            buffer.append(user).append(COLON).append(password);
        else
            buffer.append(user);

        return buffer;
    }

    /** Clear the password field.
    */
    public void clearPassword() {
        this.password = null;
    }

    /**
     * Gets the user type (which can be set to TELEPHONE_SUBSCRIBER or USER)
     * @return the type of user.
     */
    public int getUserType() {
        return userType;
    }

    /** get the user field.
     * @return String
     */
    public String getUser() {
        return user;
    }

    /** get the password field.
     * @return String
     */
    public String getPassword() {
        return password;
    }

    /**
     * Set the user member
     * @param user String to set
     */
    public void setUser(String user) {
        this.user = user;
        // BUG Fix submitted by Lamine Brahimi
        // add this (taken form sip_messageParser)
        // otherwise comparison of two SipUrl will fail because this
        // parameter is not set (whereas it is set in sip_messageParser).
        if (user != null
            && (user.indexOf(POUND) >= 0 || user.indexOf(SEMICOLON) >= 0)) {
            setUserType(TELEPHONE_SUBSCRIBER);
        } else {
            setUserType(USER);
        }
    }

    /**
     * Set the password member
     * @param p String to set
     */
    public void setPassword(String p) {
        password = p;
    }

    /**
     * Set the user type (to TELEPHONE_SUBSCRIBER or USER).
     * @param type int to set
     * @throws IllegalArgumentException if type is not in range.
     */
    public void setUserType(int type) throws IllegalArgumentException {
        if (type != TELEPHONE_SUBSCRIBER && type != USER) {
            throw new IllegalArgumentException("Parameter not in range");
        }
        userType = type;
    }
}
