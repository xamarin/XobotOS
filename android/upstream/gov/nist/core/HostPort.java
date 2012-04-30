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
package gov.nist.core;
import java.net.*;

/**
* Holds the hostname:port.
*
*@version 1.2
*
*@author M. Ranganathan
*
*
*
*/
public final class HostPort extends GenericObject {


    private static final long serialVersionUID = -7103412227431884523L;

    // host / ipv4/ ipv6/
    /** host field
     */
    protected Host host;

    /** port field
     *
     */
    protected int port;

    /** Default constructor
     */
    public HostPort() {

        host = null;
        port = -1; // marker for not set.
    }

    /**
     * Encode this hostport into its string representation.
     * Note that this could be different from the string that has
     * been parsed if something has been edited.
     * @return String
     */
    public String encode() {
        return encode(new StringBuffer()).toString();
    }

    public StringBuffer encode(StringBuffer buffer) {
        host.encode(buffer);
        if (port != -1)
            buffer.append(COLON).append(port);
        return buffer;
    }

    /** returns true if the two objects are equals, false otherwise.
     * @param other Object to set
     * @return boolean
     */
    public boolean equals(Object other) {
        if (other == null) return false;
        if (getClass () != other.getClass ()) {
            return false;
        }
        HostPort that = (HostPort) other;
        return port == that.port && host.equals(that.host);
    }

    /** get the Host field
     * @return host field
     */
    public Host getHost() {
        return host;
    }

    /** get the port field
     * @return int
     */
    public int getPort() {
        return port;
    }

    /**
     * Returns boolean value indicating if Header has port
     * @return boolean value indicating if Header has port
     */
    public boolean hasPort() {
        return port != -1;
    }

    /** remove port.
     */
    public void removePort() {
        port = -1;
    }

    /**
         * Set the host member
         * @param h Host to set
         */
    public void setHost(Host h) {
        host = h;
    }

    /**
         * Set the port member
         * @param p int to set
         */
    public void setPort(int p) {
        port = p;
    }

    /** Return the internet address corresponding to the host.
     *@throws java.net.UnkownHostException if host name cannot be resolved.
     *@return the inet address for the host.
     */
    public InetAddress getInetAddress() throws java.net.UnknownHostException {
        if (host == null)
            return null;
        else
            return host.getInetAddress();
    }

    public void merge(Object mergeObject) {
        super.merge (mergeObject);
        if (port == -1)
            port = ((HostPort) mergeObject).port;
    }

    public Object clone() {
        HostPort retval = (HostPort) super.clone();
        if (this.host != null)
            retval.host = (Host) this.host.clone();
        return retval;
    }

    public String toString() {
        return this.encode();
    }
    
    @Override
    public int hashCode() {
        return this.host.hashCode() + this.port;
    }
}
