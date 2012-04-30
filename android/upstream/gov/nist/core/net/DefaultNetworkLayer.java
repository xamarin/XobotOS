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
import java.net.InetSocketAddress;
import java.net.MulticastSocket;
import java.net.ServerSocket;
import java.net.Socket;
import java.net.SocketException;

/* Added by Daniel J. Martinez Manzano <dani@dif.um.es> */
import javax.net.ssl.SSLSocket;
import javax.net.ssl.SSLSocketFactory;
import javax.net.ssl.SSLServerSocket;
import javax.net.ssl.SSLServerSocketFactory;

/**
 * default implementation which passes straight through to java platform
 *
 * @author m.andrews
 * @version 1.2
 * @since 1.1
 *
 */
public class DefaultNetworkLayer implements NetworkLayer {

    private SSLSocketFactory sslSocketFactory;

    private SSLServerSocketFactory sslServerSocketFactory;

    /**
     * single default network layer; for flexibility, it may be better not to
     * make it a singleton, but singleton seems to make sense currently.
     */
    public static final DefaultNetworkLayer SINGLETON = new DefaultNetworkLayer();

    private DefaultNetworkLayer() {
        sslServerSocketFactory = (SSLServerSocketFactory) SSLServerSocketFactory
                .getDefault();
        sslSocketFactory = (SSLSocketFactory) SSLSocketFactory.getDefault();
    }

    public ServerSocket createServerSocket(int port, int backlog,
            InetAddress bindAddress) throws IOException {
        return new ServerSocket(port, backlog, bindAddress);
    }

    public Socket createSocket(InetAddress address, int port)
            throws IOException {
        return new Socket(address, port);
    }

    public DatagramSocket createDatagramSocket() throws SocketException {
        return new DatagramSocket();
    }

    public DatagramSocket createDatagramSocket(int port, InetAddress laddr)
            throws SocketException {

        if ( laddr.isMulticastAddress() ) {
            try {
                MulticastSocket ds = new MulticastSocket( port );
                ds.joinGroup( laddr );
                return ds;
            } catch (IOException e) {
                throw new SocketException( e.getLocalizedMessage() );
            }
        } else return new DatagramSocket(port, laddr);
    }

    /* Added by Daniel J. Martinez Manzano <dani@dif.um.es> */
    public SSLServerSocket createSSLServerSocket(int port, int backlog,
            InetAddress bindAddress) throws IOException {
        return (SSLServerSocket) sslServerSocketFactory.createServerSocket(
                port, backlog, bindAddress);
    }

    /* Added by Daniel J. Martinez Manzano <dani@dif.um.es> */
    public SSLSocket createSSLSocket(InetAddress address, int port)
            throws IOException {
        return (SSLSocket) sslSocketFactory.createSocket(address, port);
    }

    /* Added by Daniel J. Martinez Manzano <dani@dif.um.es> */
    public SSLSocket createSSLSocket(InetAddress address, int port,
            InetAddress myAddress) throws IOException {
        return (SSLSocket) sslSocketFactory.createSocket(address, port,
                myAddress, 0);
    }

    public Socket createSocket(InetAddress address, int port,
            InetAddress myAddress) throws IOException {
        if (myAddress != null)
            return new Socket(address, port, myAddress, 0);
        else
            return new Socket(address, port);
    }

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
        throws IOException
    {
        if (myAddress != null)
            return new Socket(address, port, myAddress, myPort);
        else if (port != 0)
        {
            //myAddress is null (i.e. any)  but we have a port number
            Socket sock = new Socket();
            sock.bind(new InetSocketAddress(port));
            sock.connect(new InetSocketAddress(address, port));
            return sock;
        }
        else
            return new Socket(address, port);
    }

}
