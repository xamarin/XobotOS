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
 *   Product of NIST/ITL Advanced Networking Technologies Division (ANTD).     *
 *******************************************************************************/
package gov.nist.javax.sip.stack;

import java.io.IOException;
import java.util.LinkedList;
import java.net.*;

import gov.nist.core.*;

/**
 * Sit in a loop and handle incoming udp datagram messages. For each Datagram
 * packet, a new UDPMessageChannel is created (upto the max thread pool size).
 * Each UDP message is processed in its own thread).
 *
 * @version 1.2 $Revision: 1.37 $ $Date: 2009/11/14 20:06:16 $
 *
 * @author M. Ranganathan  <br/>
 *
 *
 *
 * <a href="{@docRoot}/../uml/udp-request-processing-sequence-diagram.jpg">
 * See the implementation sequence diagram for processing incoming requests.
 * </a>
 *
 *
 * Acknowledgement: Jeff Keyser contributed ideas on starting and stoppping the
 * stack that were incorporated into this code. Niklas Uhrberg suggested that
 * thread pooling be added to limit the number of threads and improve
 * performance.
 */
public class UDPMessageProcessor extends MessageProcessor {
    /**
     * The Mapped port (in case STUN suport is enabled)
     */
    private int port;

    /**
     * Incoming messages are queued here.
     */
    protected LinkedList messageQueue;

    /**
     * A list of message channels that we have started.
     */
    protected LinkedList messageChannels;

    /**
     * Max # of udp message channels
     */
    protected int threadPoolSize;

    protected DatagramSocket sock;

    /**
     * A flag that is set to false to exit the message processor (suggestion by
     * Jeff Keyser).
     */
    protected boolean isRunning;
    
    private static final int HIGHWAT=5000;
    
    private static final int LOWAT=2500;

    /**
     * Constructor.
     *
     * @param sipStack
     *            pointer to the stack.
     */
    protected UDPMessageProcessor(InetAddress ipAddress,
            SIPTransactionStack sipStack, int port) throws IOException {
        super(ipAddress, port, "udp",sipStack);

        this.sipStack = sipStack;

        this.messageQueue = new LinkedList();

        this.port = port;
        try {
            this.sock = sipStack.getNetworkLayer().createDatagramSocket(port,
                    ipAddress);
            // Create a new datagram socket.
            sock.setReceiveBufferSize(sipStack.getReceiveUdpBufferSize());
            sock.setSendBufferSize(sipStack.getSendUdpBufferSize());

            /**
             * If the thread auditor is enabled, define a socket timeout value in order to
             * prevent sock.receive() from blocking forever
             */
            if (sipStack.getThreadAuditor().isEnabled()) {
                sock.setSoTimeout((int) sipStack.getThreadAuditor().getPingIntervalInMillisecs());
            }
            if ( ipAddress.getHostAddress().equals(IN_ADDR_ANY)  ||
                 ipAddress.getHostAddress().equals(IN6_ADDR_ANY)){
                // Store the address to which we are actually bound
                // Note that on WINDOWS this is actually broken. It will
                // return IN_ADDR_ANY again. On linux it will return the
                // address to which the socket was actually bound.
                super.setIpAddress( sock.getLocalAddress() );

            }
        } catch (SocketException ex) {
            throw new IOException(ex.getMessage());
        }
    }



    /**
     * Get port on which to listen for incoming stuff.
     *
     * @return port on which I am listening.
     */
    public int getPort() {
        return this.port;
    }

    /**
     * Start our processor thread.
     */
    public void start() throws IOException {


        this.isRunning = true;
        Thread thread = new Thread(this);
        thread.setDaemon(true);
        // Issue #32 on java.net
        thread.setName("UDPMessageProcessorThread");
        // Issue #184
        thread.setPriority(Thread.MAX_PRIORITY);
        thread.start();
    }

    /**
     * Thread main routine.
     */
    public void run() {
        // Check for running flag.
        this.messageChannels = new LinkedList();
        // start all our messageChannels (unless the thread pool size is
        // infinity.
        if (sipStack.threadPoolSize != -1) {
            for (int i = 0; i < sipStack.threadPoolSize; i++) {
                UDPMessageChannel channel = new UDPMessageChannel(sipStack,
                        this);
                this.messageChannels.add(channel);

            }
        }

        // Ask the auditor to monitor this thread
        ThreadAuditor.ThreadHandle threadHandle = sipStack.getThreadAuditor().addCurrentThread();

        // Somebody asked us to exit. if isRunnning is set to false.
        while (this.isRunning) {

            try {
                // Let the thread auditor know we're up and running
                threadHandle.ping();

                int bufsize = sock.getReceiveBufferSize();
                byte message[] = new byte[bufsize];
                DatagramPacket packet = new DatagramPacket(message, bufsize);
                sock.receive(packet);

           
             
             // This is a simplistic congestion control algorithm.
             // It accepts packets if queuesize is < LOWAT. It drops
             // requests if the queue size exceeds a HIGHWAT and accepts
             // requests with probability p proportional to the difference
             // between current queue size and LOWAT in the range
             // of queue sizes between HIGHWAT and LOWAT.
             // TODO -- penalize spammers by looking at the source
             // port and IP address.
             if ( sipStack.stackDoesCongestionControl ) {  
             if ( this.messageQueue.size() >= HIGHWAT) {
                    if (sipStack.isLoggingEnabled()) {
                        sipStack.getStackLogger().logDebug("Dropping message -- queue length exceeded");

                    }
                    //System.out.println("HIGHWAT Drop!");
                    continue;
                } else if ( this.messageQueue.size() > LOWAT && this .messageQueue.size() < HIGHWAT ) {
                    // Drop the message with a probabilty that is linear in the range 0 to 1
                    float threshold = ((float)(messageQueue.size() - LOWAT))/ ((float)(HIGHWAT - LOWAT));
                    boolean decision = Math.random() > 1.0 - threshold;
                    if ( decision ) {
                        if (sipStack.isLoggingEnabled()) {
                            sipStack.getStackLogger().logDebug("Dropping message with probability  " + (1.0 - threshold));

                        }
                        //System.out.println("RED Drop!");
                        continue;
                    }

                }
             }
                
                
                
                // Count of # of packets in process.
                // this.useCount++;
                if (sipStack.threadPoolSize != -1) {
                    // Note: the only condition watched for by threads
                    // synchronizing on the messageQueue member is that it is
                    // not empty. As soon as you introduce some other
                    // condition you will have to call notifyAll instead of
                    // notify below.

                    synchronized (this.messageQueue) {
                        // was addLast
                        this.messageQueue.add(packet);
                        this.messageQueue.notify();
                    }
                } else {
                    new UDPMessageChannel(sipStack, this, packet);
                }
            } catch (SocketTimeoutException ex) {
              // This socket timeout alows us to ping the thread auditor periodically
            } catch (SocketException ex) {
                if (sipStack.isLoggingEnabled())
                    getSIPStack().getStackLogger()
                            .logDebug("UDPMessageProcessor: Stopping");
                isRunning = false;
                // The notifyAll should be in a synchronized block.
                // ( bug report by Niklas Uhrberg ).
                synchronized (this.messageQueue) {
                    this.messageQueue.notifyAll();
                }
            } catch (IOException ex) {
                isRunning = false;
                ex.printStackTrace();
                if (sipStack.isLoggingEnabled())
                    getSIPStack().getStackLogger()
                            .logDebug("UDPMessageProcessor: Got an IO Exception");
            } catch (Exception ex) {
                if (sipStack.isLoggingEnabled())
                    getSIPStack().getStackLogger()
                            .logDebug("UDPMessageProcessor: Unexpected Exception - quitting");
                InternalErrorHandler.handleException(ex);
                return;
            }
        }
    }

    /**
     * Shut down the message processor. Close the socket for recieving incoming
     * messages.
     */
    public void stop() {
        synchronized (this.messageQueue) {
            this.isRunning = false;
            this.messageQueue.notifyAll();
            sock.close();


        }
    }

    /**
     * Return the transport string.
     *
     * @return the transport string
     */
    public String getTransport() {
        return "udp";
    }

    /**
     * Returns the stack.
     *
     * @return my sip stack.
     */
    public SIPTransactionStack getSIPStack() {
        return sipStack;
    }

    /**
     * Create and return new TCPMessageChannel for the given host/port.
     */
    public MessageChannel createMessageChannel(HostPort targetHostPort)
            throws UnknownHostException {
        return new UDPMessageChannel(targetHostPort.getInetAddress(),
                targetHostPort.getPort(), sipStack, this);
    }

    public MessageChannel createMessageChannel(InetAddress host, int port)
            throws IOException {
        return new UDPMessageChannel(host, port, sipStack, this);
    }

    /**
     * Default target port for UDP
     */
    public int getDefaultTargetPort() {
        return 5060;
    }

    /**
     * UDP is not a secure protocol.
     */
    public boolean isSecure() {
        return false;
    }

    /**
     * UDP can handle a message as large as the MAX_DATAGRAM_SIZE.
     */
    public int getMaximumMessageSize() {
        return 8*1024;
    }

    /**
     * Return true if there are any messages in use.
     */
    public boolean inUse() {
        synchronized (messageQueue) {
            return messageQueue.size() != 0;
        }
    }

}
