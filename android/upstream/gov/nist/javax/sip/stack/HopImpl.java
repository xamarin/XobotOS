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
package gov.nist.javax.sip.stack;

import java.io.Serializable;
import java.util.StringTokenizer;
/*
 * IPv6 Support added by Emil Ivov (emil_ivov@yahoo.com)<br/>
 * Network Research Team (http://www-r2.u-strasbg.fr))<br/>
 * Louis Pasteur University - Strasbourg - France<br/>
 * Bug fix for correct handling of IPV6 Address added by
 * Daniel J. Martinez Manzano <dani@dif.um.es>
 */
/**
 * Routing algorithms return a list of hops to which the request is
 * routed.
 *
 * @version 1.2 $Revision: 1.11 $ $Date: 2009/07/17 18:58:13 $
 *
 * @author M. Ranganathan   <br/>
 *
 *
 *

 *
 */
public final class HopImpl extends Object implements javax.sip.address.Hop, Serializable {
    protected String host;
    protected int port;
    protected String transport;

    protected boolean defaultRoute; // This is generated from the proxy addr
    protected boolean uriRoute; // This is extracted from the requestURI.

    /**
     * Debugging println.
     */
    public String toString() {
        return host + ":" + port + "/" + transport;
    }

    /**
     * Create new hop given host, port and transport.
     * @param hostName hostname
     * @param portNumber port
     * @param trans transport
     */
    public HopImpl(String hostName, int portNumber, String trans) {
        host = hostName;

        // Added by Daniel J. Martinez Manzano <dani@dif.um.es>
        // for correct management of IPv6 addresses.
        if(host.indexOf(":") >= 0)
            if(host.indexOf("[") < 0)
                host = "[" + host + "]";

        port = portNumber;
        transport = trans;
    }


    /**
     * Creates new Hop
     * @param hop is a hop string in the form of host:port/Transport
     * @throws IllegalArgument exception if string is not properly formatted or null.
     */
    HopImpl(String hop) throws IllegalArgumentException {

        if (hop == null)
            throw new IllegalArgumentException("Null arg!");

        // System.out.println("hop = " + hop);
        int brack = hop.indexOf(']');
        int colon = hop.indexOf(':',brack);
        int slash = hop.indexOf('/',colon);

        if (colon>0) {
            this.host = hop.substring(0,colon);
            String portstr;
            if (slash>0) {
                portstr = hop.substring(colon+1,slash);
                this.transport = hop.substring(slash+1);
            } else {
                portstr = hop.substring(colon+1);
                this.transport = "UDP";
            }
            try {
                port = Integer.parseInt(portstr);
            } catch (NumberFormatException ex) {
                throw new IllegalArgumentException("Bad port spec");
            }
        } else {
            if (slash>0) {
                this.host = hop.substring(0,slash);
                this.transport = hop.substring(slash+1);
                this.port = transport.equalsIgnoreCase("TLS") ? 5061 : 5060;
            } else {
                this.host = hop;
                this.transport = "UDP";
                this.port = 5060;
            }
        }

        // Validate it
        if (host == null || host.length() == 0)
            throw new IllegalArgumentException("no host!");

        // normalize
        this.host = this.host.trim();
        this.transport = this.transport.trim();

        if ((brack>0) && host.charAt(0)!='[') {
            throw new IllegalArgumentException("Bad IPv6 reference spec");
        }

        if (transport.compareToIgnoreCase("UDP") != 0
            && transport.compareToIgnoreCase("TLS") != 0
            && transport.compareToIgnoreCase("TCP") != 0) {
            System.err.println("Bad transport string " + transport);
            throw new IllegalArgumentException(hop);
        }
    }

    /**
     * Retruns the host string.
     * @return host String
     */
    public String getHost() {
        return host;
    }

    /**
     * Returns the port.
     * @return port integer.
     */
    public int getPort() {
        return port;
    }

    /** returns the transport string.
     */
    public String getTransport() {
        return transport;
    }



    /** Return true if this is uriRoute
     */
    public boolean isURIRoute() {
        return uriRoute;
    }

    /** Set the URIRoute flag.
     */
    public void setURIRouteFlag() {
        uriRoute = true;
    }



}
