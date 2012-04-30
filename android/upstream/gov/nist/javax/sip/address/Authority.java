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
import gov.nist.core.*;

/**
 * Authority part of a URI structure. Section 3.2.2 RFC2396
 *
 * @version 1.2 $Revision: 1.10 $ $Date: 2009/12/16 14:48:33 $
 *
 * @author M. Ranganathan   <br/>
 *
 *
 *
 */
public class Authority extends NetObject {

    private static final long serialVersionUID = -3570349777347017894L;

    /** hostport field
     */
    protected HostPort hostPort;

    /** userInfo field
     */
    protected UserInfo userInfo;

    /**
     * Return the host name in encoded form.
     * @return encoded string (does the same thing as toString)
     */
    public String encode() {
        return encode(new StringBuffer()).toString();
    }

    public StringBuffer encode(StringBuffer buffer) {
        if (userInfo != null) {
            userInfo.encode(buffer);
            buffer.append(AT);
            hostPort.encode(buffer);
        } else {
            hostPort.encode(buffer);
        }
        return buffer;
    }

    /** retruns true if the two Objects are equals , false otherwise.
     * @param other Object to test.
     * @return boolean
     */
    @Override
    public boolean equals(Object other) {
        if (other == null) return false;
        if (other.getClass() != getClass()) {
            return false;
        }
        Authority otherAuth = (Authority) other;
        if (!this.hostPort.equals(otherAuth.hostPort)) {
            return false;
        }
        if (this.userInfo != null && otherAuth.userInfo != null) {
            if (!this.userInfo.equals(otherAuth.userInfo)) {
                return false;
            }
        }
        return true;
    }

    /**
     * get the hostPort member.
     * @return HostPort
     */
    public HostPort getHostPort() {
        return hostPort;
    }

    /**
     * get the userInfo memnber.
     * @return UserInfo
     */
    public UserInfo getUserInfo() {
        return userInfo;
    }

    /**
         * Get password from the user info.
         * @return String
         */
    public String getPassword() {
        if (userInfo == null)
            return null;
        else
            return userInfo.password;
    }

    /**
     * Get the user name if it exists.
     * @return String user or null if not set.
     */
    public String getUser() {
        return userInfo != null ? userInfo.user : null;
    }

    /**
     * Get the host name.
     * @return Host (null if not set)
     */
    public Host getHost() {
        if (hostPort == null)
            return null;
        else
            return hostPort.getHost();
    }

    /**
     * Get the port.
     * @return int port (-1) if port is not set.
     */
    public int getPort() {
        if (hostPort == null)
            return -1;
        else
            return hostPort.getPort();
    }

    /** remove the port.
     */
    public void removePort() {
        if (hostPort != null)
            hostPort.removePort();
    }

    /**
     * set the password.
     * @param passwd String to set
     */
    public void setPassword(String passwd) {
        if (userInfo == null)
            userInfo = new UserInfo();
        userInfo.setPassword(passwd);
    }

    /**
     * Set the user name of the userInfo member.
     * @param user String to set
     */
    public void setUser(String user) {
        if (userInfo == null)
            userInfo = new UserInfo();
        this.userInfo.setUser(user);
    }

    /**
     * set the host.
     * @param host Host to set
     */
    public void setHost(Host host) {
        if (hostPort == null)
            hostPort = new HostPort();
        hostPort.setHost(host);
    }

    /**
     * Set the port.
     * @param port int to set
     */
    public void setPort(int port) {
        if (hostPort == null)
            hostPort = new HostPort();
        hostPort.setPort(port);
    }

    /**
         * Set the hostPort member
         * @param h HostPort to set
         */
    public void setHostPort(HostPort h) {
        hostPort = h;
    }

    /**
         * Set the userInfo member
         * @param u UserInfo to set
         */
    public void setUserInfo(UserInfo u) {
        userInfo = u;
    }

    /** Remove the user Infor.
    *
    */
    public void removeUserInfo() {
        this.userInfo = null;
    }

    public Object clone() {
        Authority retval = (Authority) super.clone();
        if (this.hostPort != null)
            retval.hostPort = (HostPort) this.hostPort.clone();
        if (this.userInfo != null)
            retval.userInfo = (UserInfo) this.userInfo.clone();
        return retval;
    }
    
    @Override
    public int hashCode() {
        if ( this.hostPort == null ) throw new UnsupportedOperationException("Null hostPort cannot compute hashcode");
        return this.hostPort.encode().hashCode();
    }
}
