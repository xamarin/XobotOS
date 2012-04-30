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
package gov.nist.javax.sip;

import gov.nist.core.ServerLogger;
import gov.nist.core.StackLogger;
import gov.nist.core.net.AddressResolver;
import gov.nist.core.net.NetworkLayer;
import gov.nist.core.net.SslNetworkLayer;
import gov.nist.javax.sip.clientauthutils.AccountManager;
import gov.nist.javax.sip.clientauthutils.AuthenticationHelper;
import gov.nist.javax.sip.clientauthutils.AuthenticationHelperImpl;
import gov.nist.javax.sip.clientauthutils.SecureAccountManager;
import gov.nist.javax.sip.parser.StringMsgParser;
import gov.nist.javax.sip.stack.DefaultMessageLogFactory;
import gov.nist.javax.sip.stack.DefaultRouter;
import gov.nist.javax.sip.stack.MessageProcessor;
import gov.nist.javax.sip.stack.SIPTransactionStack;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.lang.reflect.Constructor;
import java.lang.reflect.InvocationTargetException;
import java.net.InetAddress;
import java.util.Hashtable;
import java.util.LinkedList;
import java.util.Properties;
import java.util.StringTokenizer;
import java.util.concurrent.Semaphore;
import java.util.concurrent.TimeUnit;

import javax.sip.InvalidArgumentException;
import javax.sip.ListeningPoint;
import javax.sip.ObjectInUseException;
import javax.sip.PeerUnavailableException;
import javax.sip.ProviderDoesNotExistException;
import javax.sip.SipException;
import javax.sip.SipListener;
import javax.sip.SipProvider;
import javax.sip.SipStack;
import javax.sip.TransportNotSupportedException;
import javax.sip.address.Router;
import javax.sip.header.HeaderFactory;
import javax.sip.message.Request;

/**
 * Implementation of SipStack.
 * 
 * The JAIN-SIP stack is initialized by a set of properties (see the JAIN SIP
 * documentation for an explanation of these properties
 * {@link javax.sip.SipStack} ). In addition to these, the following are
 * meaningful properties for the NIST SIP stack (specify these in the property
 * array when you create the JAIN-SIP statck):
 * <ul>
 * 
 * <li><b>gov.nist.javax.sip.TRACE_LEVEL = integer </b><br/>
 * <b> Use of this property is still supported but deprecated. Please use
 * gov.nist.javax.sip.STACK_LOGGER and gov.nist.javax.sip.SERVER_LOGGER for
 * integration with logging frameworks and for custom formatting of log records.
 * </b> This property is used by the built in log4j based logger. You can use
 * the standard log4j level names here (i.e. ERROR, INFO, WARNING, OFF, DEBUG,
 * TRACE) If this is set to INFO or above, then incoming valid messages are
 * logged in SERVER_LOG. If you set this to 32 and specify a DEBUG_LOG then vast
 * amounts of trace information will be dumped in to the specified DEBUG_LOG.
 * The server log accumulates the signaling trace. <a href="{@docRoot}
 * /tools/tracesviewer/tracesviewer.html"> This can be viewed using the trace
 * viewer tool .</a> Please send us both the server log and debug log when
 * reporting non-obvious problems. You can also use the strings DEBUG or INFO
 * for level 32 and 16 respectively. If the value of this property is set to
 * LOG4J, then the effective log levels are determined from the log4j settings
 * file (e.g. log4j.properties). The logger name for the stack is specified
 * using the gov.nist.javax.sip.LOG4J_LOGGER_NAME property. By default log4j
 * logger name for the stack is the same as the stack name. For example, <code>
 * properties.setProperty("gov.nist.javax.sip.TRACE_LEVEL", "LOG4J");
 * properties.setProperty("gov.nist.javax.sip.LOG4J_LOGGER_NAME", "SIPStackLogger");
 * </code> allows you to now control logging in the stack entirely using log4j
 * facilities.</li>
 * 
 * <li><b>gov.nist.javax.sip.LOG_FACTORY = classpath </b> <b> Use of this
 * property is still supported but deprecated. Please use
 * gov.nist.javax.sip.STACK_LOGGER and gov.nist.javax.sip.SERVER_LOGGER for
 * integration with logging frameworks and for custom formatting of log records.
 * </b> <br/>
 * The fully qualified classpath for an implementation of the MessageLogFactory.
 * The stack calls the MessageLogFactory functions to format the log for
 * messages that are received or sent. This function allows you to log auxiliary
 * information related to the application or environmental conditions into the
 * log stream. The log factory must have a default constructor.</li>
 * 
 * <li><b>gov.nist.javax.sip.SERVER_LOG = fileName </b><br/>
 * <b> Use of this property is still supported but deprecated. Please use
 * gov.nist.javax.sip.STACK_LOGGER and gov.nist.javax.sip.SERVER_LOGGER for
 * integration with logging frameworks and for custom formatting of log records.
 * </b> Log valid incoming messages here. If this is left null AND the
 * TRACE_LEVEL is above INFO (or TRACE) then the messages are printed to stdout.
 * Otherwise messages are logged in a format that can later be viewed using the
 * trace viewer application which is located in the tools/tracesviewer
 * directory. <font color=red> Mail this to us with bug reports. </font></li>
 * 
 * <li><b>gov.nist.javax.sip.DEBUG_LOG = fileName </b> <b> Use of this property
 * is still supported but deprecated. Please use gov.nist.javax.sip.STACK_LOGGER
 * and gov.nist.javax.sip.SERVER_LOGGER for integration with logging frameworks
 * and for custom formatting of log records. </b> <br/>
 * Where the debug log goes. <font color=red> Mail this to us with bug reports.
 * </font></li>
 * 
 * <li><b>gov.nist.javax.sip.LOG_MESSAGE_CONTENT = true|false </b><br/>
 * Set true if you want to capture content into the log. Default is false. A bad
 * idea to log content if you are using SIP to push a lot of bytes through TCP.</li>
 * 
 * <li><b>gov.nist.javax.sip.LOG_STACK_TRACE_ON_MESSAGE_SEND = true|false </b><br/>
 * Set true if you want to to log a stack trace at INFO level for each message
 * send. This is really handy for debugging.</li>
 * 
 * <li><b>gov.nist.javax.sip.STACK_LOGGER = full path name to the class
 * implementing gov.nist.core.StackLogger interface</b><br/>
 * If this property is defined the sip stack will try to instantiate it through
 * a no arg constructor. This allows to use different logging implementations
 * than the ones provided by default to log what happens within the stack while
 * processing SIP messages. If this property is not defined, the default sip
 * stack LogWriter will be used for logging</li>
 * 
 * <li><b>gov.nist.javax.sip.SERVER_LOGGER = full path name to the class
 * implementing gov.nist.core.ServerLogger interface</b><br/>
 * If this property is defined the sip stack will try to instantiate it through
 * a no arg constructor. This allows to use different logging implementations
 * than the ones provided by default to log sent/received messages by the sip
 * stack. If this property is not defined, the default sip stack ServerLog will
 * be used for logging</li>
 * 
 * <li><b>gov.nist.javax.sip.AUTOMATIC_DIALOG_ERROR_HANDLING = [true|false] </b>
 * <br/>
 * Default is <it>true</it>. This is also settable on a per-provider basis. This
 * flag is set to true by default. When set
 * to <it>false</it> the following behaviors are enabled:
 * 
 * 
 * <li>Turn off Merged requests Loop Detection: The following behavior is turned off
 * : If the request has no tag in the To header field, the UAS core MUST check
 * the request against ongoing transactions. If the From tag, Call-ID, and CSeq
 * exactly match those associated with an ongoing transaction, but the request
 * does not match that transaction (based on the matching rules in Section
 * 17.2.3), the UAS core SHOULD generate a 482 (Loop Detected) response and pass
 * it to the server transaction.
 * 
 * </ul>
 * 
 * <li><b>gov.nist.javax.sip.IS_BACK_TO_BACK_USER_AGENT = [true|false] </b> <br/>
 * Default is <it>false</it> This property controls a setting on the Dialog
 * objects that the stack manages. Pure B2BUA applications should set this flag
 * to <it>true</it>. This property can also be set on a per-dialog basis.
 * Setting this to <it>true</it> imposes serialization on re-INVITE and makes
 * the sending of re-INVITEs asynchronous. The sending of re-INVITE is
 * controlled as follows : If the previous in-DIALOG request was an invite
 * ClientTransaction then the next re-INVITEs that uses the dialog will wait
 * till an ACK has been sent before admitting the new re-INVITE. If the previous
 * in-DIALOG transaction was a INVITE ServerTransaction then Dialog waits for
 * ACK before re-INVITE is allowed to be sent. If a dialog is not ACKed within
 * 32 seconds, then the dialog is torn down and a BYE sent to the peer.</li>
 * <li><b>gov.nist.javax.sip.MAX_MESSAGE_SIZE = integer</b> <br/>
 * Maximum size of content that a TCP connection can read. Must be at least 4K.
 * Default is "infinity" -- ie. no limit. This is to prevent DOS attacks
 * launched by writing to a TCP connection until the server chokes.</li>
 * 
 * <li><b>gov.nist.javax.sip.DELIVER_TERMINATED_EVENT_FOR_NULL_DIALOG = [true|false] </b><br/>
 * If set to false (the default), the application does NOT get notified when a Dialog in the
 * NULL state is terminated. ( Dialogs in the NULL state are not associated with an actual SIP Dialog.
 * They are a programming convenience. A Dialog is in the NULL state before the first response for the 
 * Dialog forming Transaction). If set to true, the SipListener will get a DialogTerminatedEvent
 * when a Dialog in the NULL state is terminated. 
 * </li>
 * 
 * <li><b>gov.nist.javax.sip.CACHE_SERVER_CONNECTIONS = [true|false] </b> <br/>
 * Default value is true. Setting this to false makes the Stack close the server
 * socket after a Server Transaction goes to the TERMINATED state. This allows a
 * server to protectect against TCP based Denial of Service attacks launched by
 * clients (ie. initiate hundreds of client transactions). If true (default
 * action), the stack will keep the socket open so as to maximize performance at
 * the expense of Thread and memory resources - leaving itself open to DOS
 * attacks.</li>
 * 
 * 
 * <li><b>gov.nist.javax.sip.CACHE_CLIENT_CONNECTIONS = [true|false] </b> <br/>
 * Default value is true. Setting this to false makes the Stack close the server
 * socket after a Client Transaction goes to the TERMINATED state. This allows a
 * client release any buffers threads and socket connections associated with a
 * client transaction after the transaction has terminated at the expense of
 * performance.</li>
 * 
 * <li><b>gov.nist.javax.sip.THREAD_POOL_SIZE = integer </b> <br/>
 * Concurrency control for number of simultaneous active threads. If
 * unspecificed, the default is "infinity". This feature is useful if you are
 * trying to build a container.
 * <ul>
 * <li>
 * <li>If this is not specified, <b> and the listener is re-entrant</b>, each
 * event delivered to the listener is run in the context of a new thread.</li>
 * <li>If this is specified and the listener is re-entrant, then the stack will
 * run the listener using a thread from the thread pool. This allows you to
 * manage the level of concurrency to a fixed maximum. Threads are pre-allocated
 * when the stack is instantiated.</li>
 * <li>If this is specified and the listener is not re-entrant, then the stack
 * will use the thread pool thread from this pool to parse and manage the state
 * machine but will run the listener in its own thread.</li>
 * </ul>
 * 
 * <li><b>gov.nist.javax.sip.REENTRANT_LISTENER = true|false </b> <br/>
 * Default is false. Set to true if the listener is re-entrant. If the listener
 * is re-entrant then the stack manages a thread pool and synchronously calls
 * the listener from the same thread which read the message. Multiple
 * transactions may concurrently receive messages and this will result in
 * multiple threads being active in the listener at the same time. The listener
 * has to be written with this in mind. <b> If you want good performance on a
 * multithreaded machine write your listener to be re-entrant and set this
 * property to be true </b></li>
 * 
 * <li><b>gov.nist.javax.sip.MAX_CONNECTIONS = integer </b> <br/>
 * Max number of simultaneous TCP connections handled by stack.</li>
 * 
 * <li><b>gov.nist.javax.sip.MAX_SERVER_TRANSACTIONS = integer </b> <br/>
 * Maximum size of server transaction table. The low water mark is 80% of the
 * high water mark. Requests are selectively dropped in the lowater mark to
 * highwater mark range. Requests are unconditionally accepted if the table is
 * smaller than the low water mark. The default highwater mark is 5000</li>
 * 
 * <li><b>gov.nist.javax.sip.MAX_CLIENT_TRANSACTIONS = integer </b> <br/>
 * Max number of active client transactions before the caller blocks and waits
 * for the number to drop below a threshold. Default is unlimited, i.e. the
 * caller never blocks and waits for a client transaction to become available
 * (i.e. it does its own resource management in the application).</li>
 * 
 * <li><b>gov.nist.javax.sip.PASS_INVITE_NON_2XX_ACK_TO_LISTENER = true|false
 * </b> <br/>
 * If true then the listener will see the ACK for non-2xx responses for server
 * transactions. This is not standard behavior per RFC 3261 (INVITE server
 * transaction state machine) but this is a useful flag for testing. The TCK
 * uses this flag for example.</li>
 * 
 * <li><b>gov.nist.javax.sip.MAX_LISTENER_RESPONSE_TIME = Integer </b> <br/>
 * Max time (seconds) before sending a response to a server transaction. If a
 * response is not sent within this time period, the transaction will be deleted
 * by the stack. Default time is "infinity" - i.e. if the listener never
 * responds, the stack will hang on to a reference for the transaction and
 * result in a memory leak.
 * 
 * <li><b>gov.nist.javax.sip.DELIVER_TERMINATED_EVENT_FOR_ACK = [true|false]</b>
 * <br/>
 * Default is <it>false</it>. ACK Server Transaction is a Pseuedo-transaction.
 * If you want termination notification on ACK transactions (so all server
 * transactions can be handled uniformly in user code during cleanup), then set
 * this flag to <it>true</it>.</li>
 * 
 * <li><b>gov.nist.javax.sip.READ_TIMEOUT = integer </b> <br/>
 * This is relevant for incoming TCP connections to prevent starvation at the
 * server. This defines the timeout in miliseconds between successive reads
 * after the first byte of a SIP message is read by the stack. All the sip
 * headers must be delivered in this interval and each successive buffer must be
 * of the content delivered in this interval. Default value is -1 (ie. the stack
 * is wide open to starvation attacks) and the client can be as slow as it wants
 * to be.</li>
 * 
 * <li><b>gov.nist.javax.sip.NETWORK_LAYER = classpath </b> <br/>
 * This is an EXPERIMENTAL property (still under active devlopment). Defines a
 * network layer that allows a client to have control over socket allocations
 * and monitoring of socket activity. A network layer should implement
 * gov.nist.core.net.NetworkLayer. The default implementation simply acts as a
 * wrapper for the standard java.net socket layer. This functionality is still
 * under active development (may be extended to support security and other
 * features).</li>
 * 
 * <li><b>gov.nist.javax.sip.ADDRESS_RESOLVER = classpath </b><br/>
 * The fully qualified class path for an implementation of the AddressResolver
 * interface. The AddressResolver allows you to support lookup schemes for
 * addresses that are not directly resolvable to IP adresses using
 * getHostByName. Specifying your own address resolver allows you to customize
 * address lookup. The default address resolver is a pass-through address
 * resolver (i.e. just returns the input string without doing a resolution). See
 * gov.nist.javax.sip.DefaultAddressResolver.</li>
 * 
 * <li><b>gov.nist.javax.sip.AUTO_GENERATE_TIMESTAMP= [true| false] </b><br/>
 * (default is false) Automatically generate a getTimeOfDay timestamp for a
 * retransmitted request if the original request contained a timestamp. This is
 * useful for profiling.</li>
 * 
 * <li><b>gov.nist.javax.sip.THREAD_AUDIT_INTERVAL_IN_MILLISECS = long </b> <br/>
 * Defines how often the application intends to audit the SIP Stack about the
 * health of its internal threads (the property specifies the time in
 * miliseconds between successive audits). The audit allows the application to
 * detect catastrophic failures like an internal thread terminating because of
 * an exception or getting stuck in a deadlock condition. Events like these will
 * make the stack inoperable and therefore require immediate action from the
 * application layer (e.g., alarms, traps, reboot, failover, etc.) Thread audits
 * are disabled by default. If this property is not specified, audits will
 * remain disabled. An example of how to use this property is in
 * src/examples/threadaudit.</li>
 * 
 * 
 * 
 * <li><b>gov.nist.javax.sip.COMPUTE_CONTENT_LENGTH_FROM_MESSAGE_BODY =
 * [true|false] </b> <br/>
 * Default is <it>false</it> If set to <it>true</it>, when you are creating a
 * message from a <it>String</it>, the MessageFactory will compute the content
 * length from the message content and ignore the provided content length
 * parameter in the Message. Otherwise, it will use the content length supplied
 * and generate a parse exception if the content is truncated.
 * 
 * <li><b>gov.nist.javax.sip.CANCEL_CLIENT_TRANSACTION_CHECKED = [true|false]
 * </b> <br/>
 * Default is <it>true</it>. This flag is added in support of load balancers or
 * failover managers where you may want to cancel ongoing transactions from a
 * different stack than the original stack. If set to <it>false</it> then the
 * CANCEL client transaction is not checked for the existence of the INVITE or
 * the state of INVITE when you send the CANCEL request. Hence you can CANCEL an
 * INVITE from a different stack than the INVITE. You can also create a CANCEL
 * client transaction late and send it out after the INVITE server transaction
 * has been Terminated. Clearly this will result in protocol errors. Setting the
 * flag to true ( default ) enables you to avoid common protocol errors.</li>
 * 
 * <li><b>gov.nist.javax.sip.IS_BACK_TO_BACK_USER_AGENT = [true|false] </b> <br/>
 * Default is <it>false</it> This property controls a setting on the Dialog
 * objects that the stack manages. Pure B2BUA applications should set this flag
 * to <it>true</it>. This property can also be set on a per-dialog basis.
 * Setting this to <it>true</it> imposes serialization on re-INVITE and makes
 * the sending of re-INVITEs asynchronous. The sending of re-INVITE is
 * controlled as follows : If the previous in-DIALOG request was an invite
 * ClientTransaction then the next re-INVITEs that uses the dialog will wait
 * till an ACK has been sent before admitting the new re-INVITE. If the previous
 * in-DIALOG transaction was a INVITE ServerTransaction then Dialog waits for
 * ACK before re-INVITE is allowed to be sent. If a dialog is not ACKed within
 * 32 seconds, then the dialog is torn down and a BYE sent to the peer.</li>
 * 
 * 
 * <li><b>gov.nist.javax.sip.RECEIVE_UDP_BUFFER_SIZE = int </b> <br/>
 * Default is <it>8*1024</it>. This property control the size of the UDP buffer
 * used for SIP messages. Under load, if the buffer capacity is overflown the
 * messages are dropped causing retransmissions, further increasing the load and
 * causing even more retransmissions. Good values to this property for servers
 * is a big number in the order of 8*8*1024.</li>
 * 
 * <li><b>gov.nist.javax.sip.SEND_UDP_BUFFER_SIZE = int </b> <br/>
 * Default is <it>8*1024</it>. This property control the size of the UDP buffer
 * used for SIP messages. Under load, if the buffer capacity is overflown the
 * messages are dropped causing retransmissions, further increasing the load and
 * causing even more retransmissions. Good values to this property for servers
 * is a big number in the order of 8*8*1024 or higher.</li>
 * 
 * <li><b>gov.nist.javax.sip.CONGESTION_CONTROL_ENABLED = boolean </b> Defailt
 * is true. If set to true stack will enforce queue length limitation for UDP.
 * The Max queue size is 5000 messages. The minimum queue size is 2500 messages.
 * </li>
 * 
 * <li><b>gov.nist.javax.sip.DELIVER_UNSOLICITED_NOTIFY = [true|false] </b> <br/>
 * Default is <it>false</it>. This flag is added to allow Sip Listeners to
 * receive all NOTIFY requests including those that are not part of a valid
 * dialog.</li>
 * 
 * <li><b>gov.nist.javax.sip.REJECT_STRAY_RESPONSES = [true|false] </b> Default
 * is <it>false</it> A flag that checks responses to test whether the response
 * corresponds to a via header that was previously generated by us. Note that
 * setting this flag implies that the stack will take control over setting the
 * VIA header for Sip Requests sent through the stack. The stack will attach a
 * suffix to the VIA header branch and check any response arriving at the stack
 * to see if that response suffix is present. If it is not present, then the
 * stack will silently drop the response.</li>
 * 
 * <li><b>gov.nist.javax.sip.MAX_FORK_TIME_SECONDS = integer </b> Maximum time for which the original 
 * transaction for which a forked response is received is tracked. This property
 * is only relevant to Dialog Stateful applications ( User Agents or B2BUA).
 * When a forked response is received in this time interval from when the original
 * INVITE client transaction was sent, the stack will place the original INVITE
 * client transction in the ResponseEventExt and deliver that to the application.
 * The event handler can get the original transaction from this event. </li>
 * 
 *  * <li><b>gov.nist.javax.sip.TLS_CLIENT_PROTOCOLS = String </b>
 *  Comma-separated list of protocols to use when creating outgoing TLS connections.
 *  The default is "SSLv3, SSLv2Hello, TLSv1".
 *  Some servers do not support SSLv2Hello, so override to "SSLv3, TLSv1". 
 * </li>

 * <li><b>javax.net.ssl.keyStore = fileName </b> <br/>
 * Default is <it>NULL</it>. If left undefined the keyStore and trustStore will
 * be left to the java runtime defaults. If defined, any TLS sockets created
 * (client and server) will use the key store provided in the fileName. The
 * trust store will default to the same store file. A password must be provided
 * to access the keyStore using the following property: <br>
 * <code>
 * properties.setProperty("javax.net.ssl.keyStorePassword", "&lt;password&gt;");
 * </code> <br>
 * The trust store can be changed, to a separate file with the following
 * setting: <br>
 * <code>
 * properties.setProperty("javax.net.ssl.trustStore", "&lt;trustStoreFileName location&gt;");
 * </code> <br>
 * If the trust store property is provided the password on the trust store must
 * be the same as the key store. <br>
 * <br>
 * <b> Note that the stack supports the extensions that are defined in
 * SipStackExt. These will be supported in the next release of JAIN-SIP. You
 * should only use the extensions that are defined in this class. </b>
 * 
 * 
 * @version 1.2 $Revision: 1.115 $ $Date: 2010/01/10 00:13:14 $
 * 
 * @author M. Ranganathan <br/>
 * 
 * 
 * 
 * 
 */
public class SipStackImpl extends SIPTransactionStack implements
		javax.sip.SipStack, SipStackExt {

	private EventScanner eventScanner;

	private Hashtable<String, ListeningPointImpl> listeningPoints;

	private LinkedList<SipProviderImpl> sipProviders;

	/**
	 * Max datagram size.
	 */
	public static final Integer MAX_DATAGRAM_SIZE = 8 * 1024;

	// Flag to indicate that the listener is re-entrant and hence
	// Use this flag with caution.
	boolean reEntrantListener;

	SipListener sipListener;

	// If set to true then a transaction terminated event is
	// delivered for ACK transactions.
	boolean deliverTerminatedEventForAck = false;

	// If set to true then the application want to receive
	// unsolicited NOTIFYs, ie NOTIFYs that don't match any dialog
	boolean deliverUnsolicitedNotify = false;
	
	// Stack semaphore (global lock).
	private Semaphore stackSemaphore = new Semaphore(1);

	// RFC3261: TLS_RSA_WITH_AES_128_CBC_SHA MUST be supported
	// RFC3261: TLS_RSA_WITH_3DES_EDE_CBC_SHA SHOULD be supported for backwards
	// compat
	private String[] cipherSuites = {
			"TLS_RSA_WITH_AES_128_CBC_SHA", // AES difficult to get with
											// c++/Windows
			// "TLS_RSA_WITH_3DES_EDE_CBC_SHA", // Unsupported by Sun impl,
			"SSL_RSA_WITH_3DES_EDE_CBC_SHA", // For backwards comp., C++

			// JvB: patch from Sebastien Mazy, issue with mismatching
			// ciphersuites
			"TLS_DH_anon_WITH_AES_128_CBC_SHA",
			"SSL_DH_anon_WITH_3DES_EDE_CBC_SHA", };

	// Supported protocols for TLS client: can be overridden by application
	private String[] enabledProtocols = {
			"SSLv3",
			"SSLv2Hello",
			"TLSv1"
	};

	/**
	 * Creates a new instance of SipStackImpl.
	 */

	protected SipStackImpl() {
		super();
		NistSipMessageFactoryImpl msgFactory = new NistSipMessageFactoryImpl(
				this);
		super.setMessageFactory(msgFactory);
		this.eventScanner = new EventScanner(this);
		this.listeningPoints = new Hashtable<String, ListeningPointImpl>();
		this.sipProviders = new LinkedList<SipProviderImpl>();

	}

	/**
	 * ReInitialize the stack instance.
	 */
	private void reInitialize() {
		super.reInit();
		this.eventScanner = new EventScanner(this);
		this.listeningPoints = new Hashtable<String, ListeningPointImpl>();
		this.sipProviders = new LinkedList<SipProviderImpl>();
		this.sipListener = null;

	}

	/**
	 * Return true if automatic dialog support is enabled for this stack.
	 * 
	 * @return boolean, true if automatic dialog support is enabled for this
	 *         stack
	 */
	boolean isAutomaticDialogSupportEnabled() {
		return super.isAutomaticDialogSupportEnabled;
	}

	/**
	 * Constructor for the stack.
	 * 
	 * @param configurationProperties
	 *            -- stack configuration properties including NIST-specific
	 *            extensions.
	 * @throws PeerUnavailableException
	 */
	public SipStackImpl(Properties configurationProperties)
			throws PeerUnavailableException {
		this();
		String address = configurationProperties
				.getProperty("javax.sip.IP_ADDRESS");
		try {
			/** Retrieve the stack IP address */
			if (address != null) {
				// In version 1.2 of the spec the IP address is
				// associated with the listening point and
				// is not madatory.
				super.setHostAddress(address);

			}
		} catch (java.net.UnknownHostException ex) {
			throw new PeerUnavailableException("bad address " + address);
		}

		/** Retrieve the stack name */
		String name = configurationProperties
				.getProperty("javax.sip.STACK_NAME");
		if (name == null)
			throw new PeerUnavailableException("stack name is missing");
		super.setStackName(name);
		String stackLoggerClassName = configurationProperties
				.getProperty("gov.nist.javax.sip.STACK_LOGGER");
		// To log debug messages.
		if (stackLoggerClassName == null)
			stackLoggerClassName = "gov.nist.core.LogWriter";
			try {
				Class<?> stackLoggerClass = Class.forName(stackLoggerClassName);
				Class<?>[] constructorArgs = new Class[0];
				Constructor<?> cons = stackLoggerClass
						.getConstructor(constructorArgs);
				Object[] args = new Object[0];
				StackLogger stackLogger = (StackLogger) cons.newInstance(args);
				stackLogger.setStackProperties(configurationProperties);
				super.setStackLogger(stackLogger);
			} catch (InvocationTargetException ex1) {
				throw new IllegalArgumentException(
						"Cound not instantiate stack logger "
								+ stackLoggerClassName
								+ "- check that it is present on the classpath and that there is a no-args constructor defined",
						ex1);
			} catch (Exception ex) {
				throw new IllegalArgumentException(
						"Cound not instantiate stack logger "
								+ stackLoggerClassName
								+ "- check that it is present on the classpath and that there is a no-args constructor defined",
						ex);
			}

		String serverLoggerClassName = configurationProperties
				.getProperty("gov.nist.javax.sip.SERVER_LOGGER");
		// To log debug messages.
		if (serverLoggerClassName == null)
			serverLoggerClassName = "gov.nist.javax.sip.stack.ServerLog";
			try {
				Class<?> serverLoggerClass = Class
						.forName(serverLoggerClassName);
				Class<?>[] constructorArgs = new Class[0];
				Constructor<?> cons = serverLoggerClass
						.getConstructor(constructorArgs);
				Object[] args = new Object[0];
				this.serverLogger = (ServerLogger) cons.newInstance(args);
				serverLogger.setSipStack(this);
				serverLogger.setStackProperties(configurationProperties);
			} catch (InvocationTargetException ex1) {
				throw new IllegalArgumentException(
						"Cound not instantiate server logger "
								+ stackLoggerClassName
								+ "- check that it is present on the classpath and that there is a no-args constructor defined",
						ex1);
			} catch (Exception ex) {
				throw new IllegalArgumentException(
						"Cound not instantiate server logger "
								+ stackLoggerClassName
								+ "- check that it is present on the classpath and that there is a no-args constructor defined",
						ex);
			}

		// Default router -- use this for routing SIP URIs.
		// Our router does not do DNS lookups.
		this.outboundProxy = configurationProperties
				.getProperty("javax.sip.OUTBOUND_PROXY");

		this.defaultRouter = new DefaultRouter(this, outboundProxy);

		/** Retrieve the router path */
		String routerPath = configurationProperties
				.getProperty("javax.sip.ROUTER_PATH");
		if (routerPath == null)
			routerPath = "gov.nist.javax.sip.stack.DefaultRouter";

		try {
			Class<?> routerClass = Class.forName(routerPath);
			Class<?>[] constructorArgs = new Class[2];
			constructorArgs[0] = javax.sip.SipStack.class;
			constructorArgs[1] = String.class;
			Constructor<?> cons = routerClass.getConstructor(constructorArgs);
			Object[] args = new Object[2];
			args[0] = (SipStack) this;
			args[1] = outboundProxy;
			Router router = (Router) cons.newInstance(args);
			super.setRouter(router);
		} catch (InvocationTargetException ex1) {
			getStackLogger()
					.logError(
							"could not instantiate router -- invocation target problem",
							(Exception) ex1.getCause());
			throw new PeerUnavailableException(
					"Cound not instantiate router - check constructor", ex1);
		} catch (Exception ex) {
			getStackLogger().logError("could not instantiate router",
					(Exception) ex.getCause());
			throw new PeerUnavailableException("Could not instantiate router",
					ex);
		}

		// The flag that indicates that the default router is to be ignored.
		String useRouterForAll = configurationProperties
				.getProperty("javax.sip.USE_ROUTER_FOR_ALL_URIS");
		this.useRouterForAll = true;
		if (useRouterForAll != null) {
			this.useRouterForAll = "true".equalsIgnoreCase(useRouterForAll);
		}

		/*
		 * Retrieve the EXTENSION Methods. These are used for instantiation of
		 * Dialogs.
		 */
		String extensionMethods = configurationProperties
				.getProperty("javax.sip.EXTENSION_METHODS");

		if (extensionMethods != null) {
			java.util.StringTokenizer st = new java.util.StringTokenizer(
					extensionMethods);
			while (st.hasMoreTokens()) {
				String em = st.nextToken(":");
				if (em.equalsIgnoreCase(Request.BYE)
						|| em.equalsIgnoreCase(Request.INVITE)
						|| em.equalsIgnoreCase(Request.SUBSCRIBE)
						|| em.equalsIgnoreCase(Request.NOTIFY)
						|| em.equalsIgnoreCase(Request.ACK)
						|| em.equalsIgnoreCase(Request.OPTIONS))
					throw new PeerUnavailableException("Bad extension method "
							+ em);
				else
					this.addExtensionMethod(em);
			}
		}
		String keyStoreFile = configurationProperties
				.getProperty("javax.net.ssl.keyStore");
		String trustStoreFile = configurationProperties
				.getProperty("javax.net.ssl.trustStore");
		if (keyStoreFile != null) {
			if (trustStoreFile == null) {
				trustStoreFile = keyStoreFile;
			}
			String keyStorePassword = configurationProperties
					.getProperty("javax.net.ssl.keyStorePassword");
			try {
				this.networkLayer = new SslNetworkLayer(trustStoreFile,
						keyStoreFile, keyStorePassword.toCharArray(),
						configurationProperties
								.getProperty("javax.net.ssl.keyStoreType"));
			} catch (Exception e1) {
				getStackLogger().logError(
						"could not instantiate SSL networking", e1);
			}
		}

		// Set the auto dialog support flag.
		super.isAutomaticDialogSupportEnabled = configurationProperties
				.getProperty("javax.sip.AUTOMATIC_DIALOG_SUPPORT", "on")
				.equalsIgnoreCase("on");

		super.isAutomaticDialogErrorHandlingEnabled = configurationProperties
					.getProperty("gov.nist.javax.sip.AUTOMATIC_DIALOG_ERROR_HANDLING","true")
					.equals(Boolean.TRUE.toString());
		if ( super.isAutomaticDialogSupportEnabled ) {
			super.isAutomaticDialogErrorHandlingEnabled = true;
		}
	
		if (configurationProperties
				.getProperty("gov.nist.javax.sip.MAX_LISTENER_RESPONSE_TIME") != null) {
			super.maxListenerResponseTime = Integer
					.parseInt(configurationProperties
							.getProperty("gov.nist.javax.sip.MAX_LISTENER_RESPONSE_TIME"));
			if (super.maxListenerResponseTime <= 0)
				throw new PeerUnavailableException(
						"Bad configuration parameter gov.nist.javax.sip.MAX_LISTENER_RESPONSE_TIME : should be positive");
		} else {
			super.maxListenerResponseTime = -1;
		}

		

		this.deliverTerminatedEventForAck = configurationProperties
				.getProperty(
						"gov.nist.javax.sip.DELIVER_TERMINATED_EVENT_FOR_ACK",
						"false").equalsIgnoreCase("true");

		this.deliverUnsolicitedNotify = configurationProperties.getProperty(
				"gov.nist.javax.sip.DELIVER_UNSOLICITED_NOTIFY", "false")
				.equalsIgnoreCase("true");

		String forkedSubscriptions = configurationProperties
				.getProperty("javax.sip.FORKABLE_EVENTS");
		if (forkedSubscriptions != null) {
			StringTokenizer st = new StringTokenizer(forkedSubscriptions);
			while (st.hasMoreTokens()) {
				String nextEvent = st.nextToken();
				this.forkedEvents.add(nextEvent);
			}
		}

		// The following features are unique to the NIST implementation.

		/*
		 * gets the NetworkLayer implementation, if any. Note that this is a
		 * NIST only feature.
		 */

		final String NETWORK_LAYER_KEY = "gov.nist.javax.sip.NETWORK_LAYER";

		if (configurationProperties.containsKey(NETWORK_LAYER_KEY)) {
			String path = configurationProperties
					.getProperty(NETWORK_LAYER_KEY);
			try {
				Class<?> clazz = Class.forName(path);
				Constructor<?> c = clazz.getConstructor(new Class[0]);
				networkLayer = (NetworkLayer) c.newInstance(new Object[0]);
			} catch (Exception e) {
				throw new PeerUnavailableException(
						"can't find or instantiate NetworkLayer implementation: "
								+ path);
			}
		}

		final String ADDRESS_RESOLVER_KEY = "gov.nist.javax.sip.ADDRESS_RESOLVER";

		if (configurationProperties.containsKey(ADDRESS_RESOLVER_KEY)) {
			String path = configurationProperties
					.getProperty(ADDRESS_RESOLVER_KEY);
			try {
				Class<?> clazz = Class.forName(path);
				Constructor<?> c = clazz.getConstructor(new Class[0]);
				this.addressResolver = (AddressResolver) c
						.newInstance(new Object[0]);
			} catch (Exception e) {
				throw new PeerUnavailableException(
						"can't find or instantiate AddressResolver implementation: "
								+ path);
			}
		}

		String maxConnections = configurationProperties
				.getProperty("gov.nist.javax.sip.MAX_CONNECTIONS");
		if (maxConnections != null) {
			try {
				this.maxConnections = new Integer(maxConnections).intValue();
			} catch (NumberFormatException ex) {
				if (isLoggingEnabled())
					getStackLogger().logError(
						"max connections - bad value " + ex.getMessage());
			}
		}

		String threadPoolSize = configurationProperties
				.getProperty("gov.nist.javax.sip.THREAD_POOL_SIZE");
		if (threadPoolSize != null) {
			try {
				this.threadPoolSize = new Integer(threadPoolSize).intValue();
			} catch (NumberFormatException ex) {
				if (isLoggingEnabled())
					this.getStackLogger().logError(
						"thread pool size - bad value " + ex.getMessage());
			}
		}

		String serverTransactionTableSize = configurationProperties
				.getProperty("gov.nist.javax.sip.MAX_SERVER_TRANSACTIONS");
		if (serverTransactionTableSize != null) {
			try {
				this.serverTransactionTableHighwaterMark = new Integer(
						serverTransactionTableSize).intValue();
				this.serverTransactionTableLowaterMark = this.serverTransactionTableHighwaterMark * 80 / 100;
				// Lowater is 80% of highwater
			} catch (NumberFormatException ex) {
				if (isLoggingEnabled())
					this.getStackLogger()
						.logError(
								"transaction table size - bad value "
										+ ex.getMessage());
			}
		} else {
			// Issue 256 : consistent with MAX_CLIENT_TRANSACTIONS, if the MAX_SERVER_TRANSACTIONS is not set
			// we assume the transaction table size can grow unlimited
			this.unlimitedServerTransactionTableSize = true;
		}

		String clientTransactionTableSize = configurationProperties
				.getProperty("gov.nist.javax.sip.MAX_CLIENT_TRANSACTIONS");
		if (clientTransactionTableSize != null) {
			try {
				this.clientTransactionTableHiwaterMark = new Integer(
						clientTransactionTableSize).intValue();
				this.clientTransactionTableLowaterMark = this.clientTransactionTableLowaterMark * 80 / 100;
				// Lowater is 80% of highwater
			} catch (NumberFormatException ex) {
				if (isLoggingEnabled())
					this.getStackLogger()
						.logError(
								"transaction table size - bad value "
										+ ex.getMessage());
			}
		} else {
			this.unlimitedClientTransactionTableSize = true;
		}

		super.cacheServerConnections = true;
		String flag = configurationProperties
				.getProperty("gov.nist.javax.sip.CACHE_SERVER_CONNECTIONS");

		if (flag != null && "false".equalsIgnoreCase(flag.trim())) {
			super.cacheServerConnections = false;
		}

		super.cacheClientConnections = true;
		String cacheflag = configurationProperties
				.getProperty("gov.nist.javax.sip.CACHE_CLIENT_CONNECTIONS");

		if (cacheflag != null && "false".equalsIgnoreCase(cacheflag.trim())) {
			super.cacheClientConnections = false;
		}

		String readTimeout = configurationProperties
				.getProperty("gov.nist.javax.sip.READ_TIMEOUT");
		if (readTimeout != null) {
			try {

				int rt = Integer.parseInt(readTimeout);
				if (rt >= 100) {
					super.readTimeout = rt;
				} else {
					System.err.println("Value too low " + readTimeout);
				}
			} catch (NumberFormatException nfe) {
				// Ignore.
				if (isLoggingEnabled())
					getStackLogger().logError("Bad read timeout " + readTimeout);
			}
		}

		// Get the address of the stun server.

		String stunAddr = configurationProperties
				.getProperty("gov.nist.javax.sip.STUN_SERVER");

		if (stunAddr != null)
			this.getStackLogger().logWarning(
					"Ignoring obsolete property "
							+ "gov.nist.javax.sip.STUN_SERVER");

		String maxMsgSize = configurationProperties
				.getProperty("gov.nist.javax.sip.MAX_MESSAGE_SIZE");

		try {
			if (maxMsgSize != null) {
				super.maxMessageSize = new Integer(maxMsgSize).intValue();
				if (super.maxMessageSize < 4096)
					super.maxMessageSize = 4096;
			} else {
				// Allow for "infinite" size of message
				super.maxMessageSize = 0;
			}
		} catch (NumberFormatException ex) {
			if (isLoggingEnabled())
				getStackLogger().logError(
					"maxMessageSize - bad value " + ex.getMessage());
		}

		String rel = configurationProperties
				.getProperty("gov.nist.javax.sip.REENTRANT_LISTENER");
		this.reEntrantListener = (rel != null && "true".equalsIgnoreCase(rel));

		// Check if a thread audit interval is specified
		String interval = configurationProperties
				.getProperty("gov.nist.javax.sip.THREAD_AUDIT_INTERVAL_IN_MILLISECS");
		if (interval != null) {
			try {
				// Make the monitored threads ping the auditor twice as fast as
				// the audits
				getThreadAuditor().setPingIntervalInMillisecs(
						Long.valueOf(interval).longValue() / 2);
			} catch (NumberFormatException ex) {
				if (isLoggingEnabled())
					getStackLogger().logError(
						"THREAD_AUDIT_INTERVAL_IN_MILLISECS - bad value ["
								+ interval + "] " + ex.getMessage());
			}
		}

		// JvB: added property for testing
		this
				.setNon2XXAckPassedToListener(Boolean
						.valueOf(
								configurationProperties
										.getProperty(
												"gov.nist.javax.sip.PASS_INVITE_NON_2XX_ACK_TO_LISTENER",
												"false")).booleanValue());

		this.generateTimeStampHeader = Boolean.valueOf(
				configurationProperties.getProperty(
						"gov.nist.javax.sip.AUTO_GENERATE_TIMESTAMP", "false"))
				.booleanValue();

		String messageLogFactoryClasspath = configurationProperties
				.getProperty("gov.nist.javax.sip.LOG_FACTORY");
		if (messageLogFactoryClasspath != null) {
			try {
				Class<?> clazz = Class.forName(messageLogFactoryClasspath);
				Constructor<?> c = clazz.getConstructor(new Class[0]);
				this.logRecordFactory = (LogRecordFactory) c
						.newInstance(new Object[0]);
			} catch (Exception ex) {
				if (isLoggingEnabled())
					getStackLogger()
						.logError(
								"Bad configuration value for LOG_FACTORY -- using default logger");
				this.logRecordFactory = new DefaultMessageLogFactory();
			}

		} else {
			this.logRecordFactory = new DefaultMessageLogFactory();
		}

		boolean computeContentLength = configurationProperties.getProperty(
				"gov.nist.javax.sip.COMPUTE_CONTENT_LENGTH_FROM_MESSAGE_BODY",
				"false").equalsIgnoreCase("true");
		StringMsgParser
				.setComputeContentLengthFromMessage(computeContentLength);

		String tlsClientProtocols = configurationProperties.getProperty(
				"gov.nist.javax.sip.TLS_CLIENT_PROTOCOLS");
		if (tlsClientProtocols != null)
		{
			StringTokenizer st = new StringTokenizer(tlsClientProtocols, " ,");
			String[] protocols = new String[st.countTokens()];
			
			int i=0;
			while (st.hasMoreTokens()) {
				protocols[i++] = st.nextToken();
			}
			this.enabledProtocols = protocols;
		}

		super.rfc2543Supported = configurationProperties.getProperty(
				"gov.nist.javax.sip.RFC_2543_SUPPORT_ENABLED", "true")
				.equalsIgnoreCase("true");

		super.cancelClientTransactionChecked = configurationProperties
				.getProperty(
						"gov.nist.javax.sip.CANCEL_CLIENT_TRANSACTION_CHECKED",
						"true").equalsIgnoreCase("true");
		super.logStackTraceOnMessageSend = configurationProperties.getProperty(
				"gov.nist.javax.sip.LOG_STACK_TRACE_ON_MESSAGE_SEND", "false")
				.equalsIgnoreCase("true");
		if (isLoggingEnabled())
			getStackLogger().logDebug(
				"created Sip stack. Properties = " + configurationProperties);
		InputStream in = getClass().getResourceAsStream("/TIMESTAMP");
		if (in != null) {
			BufferedReader streamReader = new BufferedReader(
					new InputStreamReader(in));

			try {
				String buildTimeStamp = streamReader.readLine();
				if (in != null) {
					in.close();
				}
				getStackLogger().setBuildTimeStamp(buildTimeStamp);
			} catch (IOException ex) {
				getStackLogger().logError("Could not open build timestamp.");
			}
		}

		String bufferSize = configurationProperties.getProperty(
				"gov.nist.javax.sip.RECEIVE_UDP_BUFFER_SIZE", MAX_DATAGRAM_SIZE
						.toString());
		int bufferSizeInteger = new Integer(bufferSize).intValue();
		super.setReceiveUdpBufferSize(bufferSizeInteger);

		bufferSize = configurationProperties.getProperty(
				"gov.nist.javax.sip.SEND_UDP_BUFFER_SIZE", MAX_DATAGRAM_SIZE
						.toString());
		bufferSizeInteger = new Integer(bufferSize).intValue();
		super.setSendUdpBufferSize(bufferSizeInteger);

		boolean congetstionControlEnabled = Boolean
				.parseBoolean(configurationProperties.getProperty(
						"gov.nist.javax.sip.CONGESTION_CONTROL_ENABLED",
						Boolean.TRUE.toString()));
		super.stackDoesCongestionControl = congetstionControlEnabled;

		super.isBackToBackUserAgent = Boolean
				.parseBoolean(configurationProperties.getProperty(
						"gov.nist.javax.sip.IS_BACK_TO_BACK_USER_AGENT",
						Boolean.FALSE.toString()));
		super.checkBranchId = Boolean.parseBoolean(configurationProperties
				.getProperty("gov.nist.javax.sip.REJECT_STRAY_RESPONSES",
						Boolean.FALSE.toString()));
		
		super.isDialogTerminatedEventDeliveredForNullDialog = (Boolean.parseBoolean(configurationProperties.getProperty("gov.nist.javax.sip.DELIVER_TERMINATED_EVENT_FOR_NULL_DIALOG",
		        Boolean.FALSE.toString())));
		
		
		super.maxForkTime = Integer.parseInt(
		        configurationProperties.getProperty("gov.nist.javax.sip.MAX_FORK_TIME_SECONDS","0"));
		
	}

	/*
	 * (non-Javadoc)
	 * 
	 * @see javax.sip.SipStack#createListeningPoint(java.lang.String, int,
	 * java.lang.String)
	 */
	public synchronized ListeningPoint createListeningPoint(String address,
			int port, String transport) throws TransportNotSupportedException,
			InvalidArgumentException {
		if (isLoggingEnabled())
			getStackLogger().logDebug(
				"createListeningPoint : address = " + address + " port = "
						+ port + " transport = " + transport);

		if (address == null)
			throw new NullPointerException(
					"Address for listening point is null!");
		if (transport == null)
			throw new NullPointerException("null transport");
		if (port <= 0)
			throw new InvalidArgumentException("bad port");

		if (!transport.equalsIgnoreCase("UDP")
				&& !transport.equalsIgnoreCase("TLS")
				&& !transport.equalsIgnoreCase("TCP")
				&& !transport.equalsIgnoreCase("SCTP"))
			throw new TransportNotSupportedException("bad transport "
					+ transport);

		/** Reusing an old stack instance */
		if (!this.isAlive()) {
			this.toExit = false;
			this.reInitialize();
		}

		String key = ListeningPointImpl.makeKey(address, port, transport);

		ListeningPointImpl lip = (ListeningPointImpl) listeningPoints.get(key);
		if (lip != null) {
			return lip;
		} else {
			try {
				InetAddress inetAddr = InetAddress.getByName(address);
				MessageProcessor messageProcessor = this
						.createMessageProcessor(inetAddr, port, transport);
				if (this.isLoggingEnabled()) {
					this.getStackLogger().logDebug(
							"Created Message Processor: " + address
									+ " port = " + port + " transport = "
									+ transport);
				}
				lip = new ListeningPointImpl(this, port, transport);
				lip.messageProcessor = messageProcessor;
				messageProcessor.setListeningPoint(lip);
				this.listeningPoints.put(key, lip);
				// start processing messages.
				messageProcessor.start();
				return (ListeningPoint) lip;
			} catch (java.io.IOException ex) {
				if (isLoggingEnabled())
					getStackLogger().logError(
						"Invalid argument address = " + address + " port = "
								+ port + " transport = " + transport);
				throw new InvalidArgumentException(ex.getMessage(), ex);
			}
		}
	}

	/*
	 * (non-Javadoc)
	 * 
	 * @see javax.sip.SipStack#createSipProvider(javax.sip.ListeningPoint)
	 */
	public SipProvider createSipProvider(ListeningPoint listeningPoint)
			throws ObjectInUseException {
		if (listeningPoint == null)
			throw new NullPointerException("null listeningPoint");
		if (this.isLoggingEnabled())
			this.getStackLogger().logDebug(
					"createSipProvider: " + listeningPoint);
		ListeningPointImpl listeningPointImpl = (ListeningPointImpl) listeningPoint;
		if (listeningPointImpl.sipProvider != null)
			throw new ObjectInUseException("Provider already attached!");

		SipProviderImpl provider = new SipProviderImpl(this);

		provider.setListeningPoint(listeningPointImpl);
		listeningPointImpl.sipProvider = provider;
		this.sipProviders.add(provider);
		return provider;
	}

	/*
	 * (non-Javadoc)
	 * 
	 * @see javax.sip.SipStack#deleteListeningPoint(javax.sip.ListeningPoint)
	 */
	public void deleteListeningPoint(ListeningPoint listeningPoint)
			throws ObjectInUseException {
		if (listeningPoint == null)
			throw new NullPointerException("null listeningPoint arg");
		ListeningPointImpl lip = (ListeningPointImpl) listeningPoint;
		// Stop the message processing thread in the listening point.
		super.removeMessageProcessor(lip.messageProcessor);
		String key = lip.getKey();
		this.listeningPoints.remove(key);

	}

	/*
	 * (non-Javadoc)
	 * 
	 * @see javax.sip.SipStack#deleteSipProvider(javax.sip.SipProvider)
	 */
	public void deleteSipProvider(SipProvider sipProvider)
			throws ObjectInUseException {

		if (sipProvider == null)
			throw new NullPointerException("null provider arg");
		SipProviderImpl sipProviderImpl = (SipProviderImpl) sipProvider;

		// JvB: API doc is not clear, but in_use ==
		// sipProviderImpl.sipListener!=null
		// so we should throw if app did not call removeSipListener
		// sipProviderImpl.sipListener = null;
		if (sipProviderImpl.getSipListener() != null) {
			throw new ObjectInUseException(
					"SipProvider still has an associated SipListener!");
		}

		sipProviderImpl.removeListeningPoints();

		// Bug reported by Rafael Barriuso
		sipProviderImpl.stop();
		sipProviders.remove(sipProvider);
		if (sipProviders.isEmpty()) {
			this.stopStack();
		}
	}

	/**
	 * Get the IP Address of the stack.
	 * 
	 * @see javax.sip.SipStack#getIPAddress()
	 * @deprecated
	 */
	public String getIPAddress() {
		return super.getHostAddress();
	}

	/*
	 * (non-Javadoc)
	 * 
	 * @see javax.sip.SipStack#getListeningPoints()
	 */
	public java.util.Iterator getListeningPoints() {
		return this.listeningPoints.values().iterator();
	}

	/**
	 * Return true if retransmission filter is active.
	 * 
	 * @see javax.sip.SipStack#isRetransmissionFilterActive()
	 * @deprecated
	 */
	public boolean isRetransmissionFilterActive() {
		return true;
	}

	/*
	 * (non-Javadoc)
	 * 
	 * @see javax.sip.SipStack#getSipProviders()
	 */
	public java.util.Iterator<SipProviderImpl> getSipProviders() {
		return this.sipProviders.iterator();
	}

	/*
	 * (non-Javadoc)
	 * 
	 * @see javax.sip.SipStack#getStackName()
	 */
	public String getStackName() {
		return this.stackName;
	}

	/**
	 * Finalization -- stop the stack on finalization. Exit the transaction
	 * scanner and release all resources.
	 * 
	 * @see java.lang.Object#finalize()
	 */
	protected void finalize() {
		this.stopStack();
	}

	/**
	 * This uses the default stack address to create a listening point.
	 * 
	 * @see javax.sip.SipStack#createListeningPoint(java.lang.String, int,
	 *      java.lang.String)
	 * @deprecated
	 */
	public ListeningPoint createListeningPoint(int port, String transport)
			throws TransportNotSupportedException, InvalidArgumentException {
		if (super.stackAddress == null)
			throw new NullPointerException(
					"Stack does not have a default IP Address!");
		return this.createListeningPoint(super.stackAddress, port, transport);
	}

	/*
	 * (non-Javadoc)
	 * 
	 * @see javax.sip.SipStack#stop()
	 */
	public void stop() {
		if (isLoggingEnabled()) {
			getStackLogger().logDebug("stopStack -- stoppping the stack");
		}
		this.stopStack();
		this.sipProviders = new LinkedList<SipProviderImpl>();
		this.listeningPoints = new Hashtable<String, ListeningPointImpl>();
		/*
		 * Check for presence of an event scanner ( may happen if stack is
		 * stopped before listener is attached ).
		 */
		if (this.eventScanner != null)
			this.eventScanner.forceStop();
		this.eventScanner = null;

	}

	/*
	 * (non-Javadoc)
	 * 
	 * @see javax.sip.SipStack#start()
	 */
	public void start() throws ProviderDoesNotExistException, SipException {
		// Start a new event scanner if one does not exist.
		if (this.eventScanner == null) {
			this.eventScanner = new EventScanner(this);
		}

	}

	/**
	 * Get the listener for the stack. A stack can have only one listener. To
	 * get an event from a provider, the listener has to be registered with the
	 * provider. The SipListener is application code.
	 * 
	 * @return -- the stack SipListener
	 * 
	 */
	public SipListener getSipListener() {
		return this.sipListener;
	}

	/**
	 * Get the message log factory registered with the stack.
	 * 
	 * @return -- the messageLogFactory of the stack.
	 */
	public LogRecordFactory getLogRecordFactory() {
		return super.logRecordFactory;
	}

	/**
	 * Set the log appender ( this is useful if you want to specify a particular
	 * log format or log to something other than a file for example). This method
	 * is will be removed May 11, 2010 or shortly there after.
	 * 
	 * @param Appender
	 *            - the log4j appender to add.
	 * @deprecated TODO: remove this method May 11, 2010.
	 */
        // BEGIN android-deleted
	/*
        @Deprecated
	public void addLogAppender(org.apache.log4j.Appender appender) {
		if (this.getStackLogger() instanceof gov.nist.core.LogWriter) {
			((gov.nist.core.LogWriter) this.getStackLogger()).addAppender(appender);
		}
	}
        */
        // END android-deleted

	/**
	 * Get the log4j logger ( for log stream integration ).
	 * This method will be removed May 11, 2010 or shortly there after.
	 * 
	 * @return  the log4j logger.
	 * @deprecated TODO: This method will be removed May 11, 2010.
	 */
	@Deprecated
        // BEGIN andoird-deleted
        /*
	public org.apache.log4j.Logger getLogger() {
		if (this.getStackLogger() instanceof gov.nist.core.LogWriter) {
			return ((gov.nist.core.LogWriter) this.getStackLogger()).getLogger();
		}
		return null;
	}
        */
        // END android-deleted

	public EventScanner getEventScanner() {
		return eventScanner;
	}

	/*
	 * (non-Javadoc)
	 * 
	 * @see
	 * gov.nist.javax.sip.SipStackExt#getAuthenticationHelper(gov.nist.javax
	 * .sip.clientauthutils.AccountManager, javax.sip.header.HeaderFactory)
	 */
	public AuthenticationHelper getAuthenticationHelper(
			AccountManager accountManager, HeaderFactory headerFactory) {
		return new AuthenticationHelperImpl(this, accountManager, headerFactory);
	}

	/*
	 * (non-Javadoc)
	 * 
	 * @see
	 * gov.nist.javax.sip.SipStackExt#getAuthenticationHelper(gov.nist.javax
	 * .sip.clientauthutils.AccountManager, javax.sip.header.HeaderFactory)
	 */
	public AuthenticationHelper getSecureAuthenticationHelper(
			SecureAccountManager accountManager, HeaderFactory headerFactory) {
		return new AuthenticationHelperImpl(this, accountManager, headerFactory);
	}

	/**
	 * Set the list of cipher suites supported by the stack. A stack can have
	 * only one set of suites. These are not validated against the supported
	 * cipher suites of the java runtime, so specifying a cipher here does not
	 * guarantee that it will work.<br>
	 * The stack has a default cipher suite of:
	 * <ul>
	 * <li>TLS_RSA_WITH_AES_128_CBC_SHA</li>
	 * <li>SSL_RSA_WITH_3DES_EDE_CBC_SHA</li>
	 * <li>TLS_DH_anon_WITH_AES_128_CBC_SHA</li>
	 * <li>SSL_DH_anon_WITH_3DES_EDE_CBC_SHA</li>
	 * </ul>
	 * 
	 * <b>NOTE: This function must be called before adding a TLS listener</b>
	 * 
	 * @param String
	 *            [] The new set of ciphers to support.
	 * @return
	 * 
	 */
	public void setEnabledCipherSuites(String[] newCipherSuites) {
		cipherSuites = newCipherSuites;
	}

	/**
	 * Return the currently enabled cipher suites of the Stack.
	 * 
	 * @return The currently enabled cipher suites.
	 */
	public String[] getEnabledCipherSuites() {
		return cipherSuites;
	}

	/**
	 * Set the list of protocols supported by the stack for outgoing TLS connections.
	 * A stack can have only one set of protocols.
	 * These are not validated against the supported
	 * protocols of the java runtime, so specifying a protocol here does not
	 * guarantee that it will work.<br>
	 * The stack has a default protocol suite of:
	 * <ul>
	 * <li>SSLv3</li>
	 * <li>SSLv2Hello</li>
	 * <li>TLSv1</li>
	 * </ul>
	 * 
	 * <b>NOTE: This function must be called before creating a TLSMessageChannel.</b>
	 * 
	 * @param String
	 *            [] The new set of protocols to use for outgoing TLS connections.
	 * @return
	 * 
	 */
	public void setEnabledProtocols(String[] newProtocols) {
		enabledProtocols = newProtocols;
	}

	/**
	 * Return the currently enabled protocols to use when creating TLS connection.
	 * 
	 * @return The currently enabled protocols.
	 */
	public String[] getEnabledProtocols() {
		return enabledProtocols;
	}

	/**
	 * Set the "back to back User Agent" flag.
	 * 
	 * @param flag
	 *            - boolean flag to set.
	 * 
	 */
	public void setIsBackToBackUserAgent(boolean flag) {
		super.isBackToBackUserAgent = flag;
	}
	
	/**
	 * Get the "back to back User Agent" flag.
	 * 
	 * return the value of the flag
	 * 
	 */
	public boolean isBackToBackUserAgent() {
		return super.isBackToBackUserAgent;
	}

	public boolean isAutomaticDialogErrorHandlingEnabled() {
		return super.isAutomaticDialogErrorHandlingEnabled;
	}

    public boolean acquireSem() {
        try {
            return this.stackSemaphore.tryAcquire(10, TimeUnit.SECONDS);
        } catch ( InterruptedException ex) {
            return false;
        }
    }
    
    public void releaseSem() {
        this.stackSemaphore.release();
    }


    

}
