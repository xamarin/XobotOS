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
package gov.nist.core.net;

import java.io.IOException;
import java.net.DatagramSocket;
import java.net.InetAddress;
import java.net.ServerSocket;
import java.net.Socket;
import java.net.SocketException;

// Added by Daniel J. Martinez Manzano <dani@dif.um.es>
import javax.net.ssl.SSLServerSocket;
import javax.net.ssl.SSLSocket;


/**
 * basic interface to the network layer
 *
 * @author m.andrews
 *
 */
public interface NetworkLayer {

    /**
     * Creates a server with the specified port, listen backlog, and local IP address to bind to.
     * comparable to "new java.net.ServerSocket(port,backlog,bindAddress);"
     *
     * @param port
     * @param backlog
     * @param bindAddress
     * @return the server socket
     */
    public ServerSocket createServerSocket(int port, int backlog,
            InetAddress bindAddress) throws IOException;

    /**
     * Creates an SSL server with the specified port, listen backlog, and local IP address to bind to.
     * Added by Daniel J. Martinez Manzano <dani@dif.um.es>
     *
     * @param port
     * @param backlog
     * @param bindAddress
     * @return the server socket
     */
    public SSLServerSocket createSSLServerSocket(int port, int backlog,
            InetAddress bindAddress) throws IOException;

    /**
     * Creates a stream socket and connects it to the specified port number at the specified IP address.
     * comparable to "new java.net.Socket(address, port);"
     *
     * @param address
     * @param port
     * @return the socket
     */
    public Socket createSocket(InetAddress address, int port) throws IOException;

    /**
     * Creates a stream socket and connects it to the specified port number at the specified IP address.
     * comparable to "new java.net.Socket(address, port,localaddress);"
     *
     * @param address
     * @param port
     * @param localAddress
     * @return the socket
     */
    public Socket createSocket(InetAddress address, int port, InetAddress localAddress) throws IOException;

    /**
     * Creates a new Socket, binds it to myAddress:myPort and connects it to
     * address:port.
     *
     * @param address the InetAddress that we'd like to connect to.
     * @param port the port that we'd like to connect to
     * @param myAddress the address that we are supposed to bind on or null
     *        for the "any" address.
     * @param myPort the port that we are supposed to bind on or 0 for a random
     * one.
     *
     * @return a new Socket, bound on myAddress:myPort and connected to
     * address:port.
     * @throws IOException if binding or connecting the socket fail for a reason
     * (exception relayed from the correspoonding Socket methods)
     */
    public Socket createSocket(InetAddress address, int port,
                    InetAddress myAddress, int myPort)
        throws IOException;

    /**
     * Creates a stream SSL socket and connects it to the specified port number at the specified IP address.
     * Added by Daniel J. Martinez Manzano <dani@dif.um.es>
     *
     * @param address
     * @param port
     * @return the socket
     */
    public SSLSocket createSSLSocket(InetAddress address, int port) throws IOException;

    /**
     * Creates a stream SSL socket and connects it to the specified port number at the specified IP address.
     * Added by Daniel J. Martinez Manzano <dani@dif.um.es>
     *
     * @param address
     * @param port
     * @param localAddress -- my address.
     * @return the socket
     */
    public SSLSocket createSSLSocket(InetAddress address, int port, InetAddress localAddress) throws IOException;

    /**
     * Constructs a datagram socket and binds it to any available port on the local host machine.
     * comparable to "new java.net.DatagramSocket();"
     *
     * @return the datagram socket
     */
    public DatagramSocket createDatagramSocket() throws SocketException;

    /**
     * Creates a datagram socket, bound to the specified local address.
     * comparable to "new java.net.DatagramSocket(port,laddr);"
     *
     * @param port
     * @param laddr
     * @return the datagram socket
     */
    public DatagramSocket createDatagramSocket(int port, InetAddress laddr)
            throws SocketException;

}
