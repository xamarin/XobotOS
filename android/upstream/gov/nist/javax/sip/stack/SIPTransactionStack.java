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
package gov.nist.javax.sip.stack;

import gov.nist.core.Host;
import gov.nist.core.HostPort;
import gov.nist.core.ServerLogger;
import gov.nist.core.StackLogger;
import gov.nist.core.ThreadAuditor;
import gov.nist.core.net.AddressResolver;
import gov.nist.core.net.DefaultNetworkLayer;
import gov.nist.core.net.NetworkLayer;
import gov.nist.javax.sip.DefaultAddressResolver;
import gov.nist.javax.sip.ListeningPointImpl;
import gov.nist.javax.sip.LogRecordFactory;
import gov.nist.javax.sip.SIPConstants;
import gov.nist.javax.sip.SipListenerExt;
import gov.nist.javax.sip.SipProviderImpl;
import gov.nist.javax.sip.SipStackImpl;
import gov.nist.javax.sip.header.Event;
import gov.nist.javax.sip.header.Via;
import gov.nist.javax.sip.header.extensions.JoinHeader;
import gov.nist.javax.sip.header.extensions.ReplacesHeader;
import gov.nist.javax.sip.message.SIPMessage;
import gov.nist.javax.sip.message.SIPRequest;
import gov.nist.javax.sip.message.SIPResponse;

import java.io.IOException;
import java.net.InetAddress;
import java.net.SocketAddress;
import java.net.UnknownHostException;
import java.util.ArrayList;
import java.util.Collection;
import java.util.HashSet;
import java.util.Iterator;
import java.util.LinkedList;
import java.util.Set;
import java.util.Timer;
import java.util.concurrent.ConcurrentHashMap;
import java.util.concurrent.atomic.AtomicInteger;

import javax.sip.ClientTransaction;
import javax.sip.Dialog;
import javax.sip.DialogState;
import javax.sip.DialogTerminatedEvent;
import javax.sip.ServerTransaction;
import javax.sip.SipException;
import javax.sip.SipListener;
import javax.sip.TransactionState;
import javax.sip.TransactionTerminatedEvent;
import javax.sip.address.Hop;
import javax.sip.address.Router;
import javax.sip.header.CallIdHeader;
import javax.sip.header.EventHeader;
import javax.sip.message.Request;
import javax.sip.message.Response;

/*
 * Jeff Keyser : architectural suggestions and contributions. Pierre De Rop and Thomas Froment :
 * Bug reports. Jeyashankher < jai@lucent.com > : bug reports. Jeroen van Bemmel : Bug fixes.
 *
 *
 */

/**
 *
 * This is the sip stack. It is essentially a management interface. It manages the resources for
 * the JAIN-SIP implementation. This is the structure that is wrapped by the SipStackImpl.
 *
 * @see gov.nist.javax.sip.SipStackImpl
 *
 * @author M. Ranganathan <br/>
 *
 * @version 1.2 $Revision: 1.141 $ $Date: 2009/12/17 23:38:27 $
 */
public abstract class SIPTransactionStack implements SIPTransactionEventListener, SIPDialogEventListener {

    /*
     * Number of milliseconds between timer ticks (500).
     */
    public static final int BASE_TIMER_INTERVAL = 500;

    /*
     * Connection linger time (seconds) this is the time (in seconds) for which we linger the TCP
     * connection before closing it.
     */
    public static final int CONNECTION_LINGER_TIME = 8;

    /*
     * Table of retransmission Alert timers.
     */
    protected ConcurrentHashMap<String, SIPServerTransaction> retransmissionAlertTransactions;

    // Table of early dialogs ( to keep identity mapping )
    protected ConcurrentHashMap<String, SIPDialog> earlyDialogTable;

    // Table of dialogs.
    protected ConcurrentHashMap<String, SIPDialog> dialogTable;

    // A set of methods that result in dialog creations.
    protected static final Set<String> dialogCreatingMethods = new HashSet<String>();

    // Global timer. Use this for all timer tasks.

    private Timer timer;

    // List of pending server transactions
    private ConcurrentHashMap<String, SIPServerTransaction> pendingTransactions;

    // hashtable for fast lookup
    private ConcurrentHashMap<String, SIPClientTransaction> clientTransactionTable;

    // Set to false if you want hiwat and lowat to be consulted.
    protected boolean unlimitedServerTransactionTableSize = true;

    // Set to false if you want unlimited size of client trnansactin table.
    protected boolean unlimitedClientTransactionTableSize = true;

    // High water mark for ServerTransaction Table
    // after which requests are dropped.
    protected int serverTransactionTableHighwaterMark = 5000;

    // Low water mark for Server Tx table size after which
    // requests are selectively dropped
    protected int serverTransactionTableLowaterMark = 4000;

    // Hiwater mark for client transaction table. These defaults can be
    // overriden by stack
    // configuration.
    protected int clientTransactionTableHiwaterMark = 1000;

    // Low water mark for client tx table.
    protected int clientTransactionTableLowaterMark = 800;

    private AtomicInteger activeClientTransactionCount = new AtomicInteger(0);

    // Hashtable for server transactions.
    private ConcurrentHashMap<String, SIPServerTransaction> serverTransactionTable;

    // A table of ongoing transactions indexed by mergeId ( for detecting merged
    // requests.
    private ConcurrentHashMap<String, SIPServerTransaction> mergeTable;
    
    private ConcurrentHashMap<String,SIPServerTransaction> terminatedServerTransactionsPendingAck;
    
    private ConcurrentHashMap<String,SIPClientTransaction> forkedClientTransactionTable;

    /*
     * A wrapper around differnt logging implementations (log4j, commons logging, slf4j, ...) to help log debug.
     */
    private StackLogger stackLogger;

    /*
     * ServerLog is used just for logging stack message tracecs.
     */
    protected ServerLogger serverLogger;

    /*
     * We support UDP on this stack.
     */
    boolean udpFlag;

    /*
     * Internal router. Use this for all sip: request routing.
     *
     */
    protected DefaultRouter defaultRouter;

    /*
     * Global flag that turns logging off
     */
    protected boolean needsLogging;

    /*
     * Flag used for testing TI, bypasses filtering of ACK to non-2xx
     */
    private boolean non2XXAckPassedToListener;

    /*
     * Class that handles caching of TCP/TLS connections.
     */
    protected IOHandler ioHandler;

    /*
     * Flag that indicates that the stack is active.
     */
    protected boolean toExit;

    /*
     * Name of the stack.
     */
    protected String stackName;

    /*
     * IP address of stack -- this can be re-written by stun.
     *
     * @deprecated
     */
    protected String stackAddress;

    /*
     * INET address of stack (cached to avoid repeated lookup)
     *
     * @deprecated
     */
    protected InetAddress stackInetAddress;

    /*
     * Request factory interface (to be provided by the application)
     */
    protected StackMessageFactory sipMessageFactory;

    /*
     * Router to determine where to forward the request.
     */
    protected javax.sip.address.Router router;

    /*
     * Number of pre-allocated threads for processing udp messages. -1 means no preallocated
     * threads ( dynamically allocated threads).
     */
    protected int threadPoolSize;

    /*
     * max number of simultaneous connections.
     */
    protected int maxConnections;

    /*
     * Close accept socket on completion.
     */
    protected boolean cacheServerConnections;

    /*
     * Close connect socket on Tx termination.
     */
    protected boolean cacheClientConnections;

    /*
     * Use the user supplied router for all out of dialog requests.
     */
    protected boolean useRouterForAll;

    /*
     * Max size of message that can be read from a TCP connection.
     */
    protected int maxContentLength;

    /*
     * Max # of headers that a SIP message can contain.
     */
    protected int maxMessageSize;

    /*
     * A collection of message processors.
     */
    private Collection<MessageProcessor> messageProcessors;

    /*
     * Read timeout on TCP incoming sockets -- defines the time between reads for after delivery
     * of first byte of message.
     */
    protected int readTimeout;

    /*
     * The socket factory. Can be overriden by applications that want direct access to the
     * underlying socket.
     */

    protected NetworkLayer networkLayer;

    /*
     * Outbound proxy String ( to be handed to the outbound proxy class on creation).
     */
    protected String outboundProxy;

    protected String routerPath;

    // Flag to indicate whether the stack will provide dialog
    // support.
    protected boolean isAutomaticDialogSupportEnabled;

    // The set of events for which subscriptions can be forked.

    protected HashSet<String> forkedEvents;

    // Generate a timestamp header for retransmitted requests.
    protected boolean generateTimeStampHeader;

    protected AddressResolver addressResolver;

    // Max time that the listener is allowed to take to respond to a
    // request. Default is "infinity". This property allows
    // containers to defend against buggy clients (that do not
    // want to respond to requests).
    protected int maxListenerResponseTime;

  
    // A flag that indicates whether or not RFC 2543 clients are fully supported.
    // If this is set to true, then To tag checking on the Dialog layer is
    // disabled in a few places - resulting in possible breakage of forked dialogs.
    protected boolean rfc2543Supported = true;

    // / Provides a mechanism for applications to check the health of threads in
    // the stack
    protected ThreadAuditor threadAuditor = new ThreadAuditor();

    protected LogRecordFactory logRecordFactory;

    // Set to true if the client CANCEL transaction should be checked before sending
    // it out.
    protected boolean cancelClientTransactionChecked = true;

    // Is to tag reassignment allowed.
    protected boolean remoteTagReassignmentAllowed = true;

    protected boolean logStackTraceOnMessageSend = true;
   
    // Receive UDP buffer size
    protected int receiveUdpBufferSize;
    
    // Send UDP buffer size
    protected int sendUdpBufferSize;

    protected boolean stackDoesCongestionControl = true;

    protected boolean isBackToBackUserAgent = false;

    protected boolean checkBranchId;

	protected boolean isAutomaticDialogErrorHandlingEnabled = true;
	
	protected boolean isDialogTerminatedEventDeliveredForNullDialog = false;
	
	// Max time for a forked response to arrive. After this time, the original dialog
	// is not tracked. If you want to track the original transaction you need to specify
	// the max fork time with a stack init property.
	protected int maxForkTime = 0;

   
    // / Timer to regularly ping the thread auditor (on behalf of the timer
    // thread)
    class PingTimer extends SIPStackTimerTask {
        // / Timer thread handle
        ThreadAuditor.ThreadHandle threadHandle;

        // / Constructor
        public PingTimer(ThreadAuditor.ThreadHandle a_oThreadHandle) {
            threadHandle = a_oThreadHandle;
        }

        protected void runTask() {
            // Check if we still have a timer (it may be null after shutdown)
            if (getTimer() != null) {
                // Register the timer task if we haven't done so
                if (threadHandle == null) {
                    // This happens only once since the thread handle is passed
                    // to the next scheduled ping timer
                    threadHandle = getThreadAuditor().addCurrentThread();
                }

                // Let the thread auditor know that the timer task is alive
                threadHandle.ping();

                // Schedule the next ping
                getTimer().schedule(new PingTimer(threadHandle),
                        threadHandle.getPingIntervalInMillisecs());
            }
        }

    }
    
    
    class RemoveForkedTransactionTimerTask extends SIPStackTimerTask {
        
        private SIPClientTransaction clientTransaction;

        public RemoveForkedTransactionTimerTask(SIPClientTransaction sipClientTransaction ) {
            this.clientTransaction = sipClientTransaction;
        }

        @Override
        protected void runTask() {
           forkedClientTransactionTable.remove(clientTransaction.getTransactionId()); 
        }
        
    }

    static {
    	// Standard set of methods that create dialogs.
    	dialogCreatingMethods.add(Request.REFER);
        dialogCreatingMethods.add(Request.INVITE);
        dialogCreatingMethods.add(Request.SUBSCRIBE);
    }
    
    /**
     * Default constructor.
     */
    protected SIPTransactionStack() {
        this.toExit = false;
        this.forkedEvents = new HashSet<String>();
        // set of events for which subscriptions can be forked.
        // Set an infinite thread pool size.
        this.threadPoolSize = -1;
        // Close response socket after infinte time.
        // for max performance
        this.cacheServerConnections = true;
        // Close the request socket after infinite time.
        // for max performance
        this.cacheClientConnections = true;
        // Max number of simultaneous connections.
        this.maxConnections = -1;
        // Array of message processors.
        messageProcessors = new ArrayList<MessageProcessor>();
        // Handle IO for this process.
        this.ioHandler = new IOHandler(this);

        // The read time out is infinite.
        this.readTimeout = -1;

        this.maxListenerResponseTime = -1;

        // The default (identity) address lookup scheme

        this.addressResolver = new DefaultAddressResolver();

        // Notify may or may not create a dialog. This is handled in
        // the code.
        // Create the transaction collections

        // Dialog dable.
        this.dialogTable = new ConcurrentHashMap<String, SIPDialog>();
        this.earlyDialogTable = new ConcurrentHashMap<String, SIPDialog>();

        clientTransactionTable = new ConcurrentHashMap<String, SIPClientTransaction>();
        serverTransactionTable = new ConcurrentHashMap<String, SIPServerTransaction>();
        this.terminatedServerTransactionsPendingAck = new ConcurrentHashMap<String, SIPServerTransaction>();
        mergeTable = new ConcurrentHashMap<String, SIPServerTransaction>();
        retransmissionAlertTransactions = new ConcurrentHashMap<String, SIPServerTransaction>();

        // Start the timer event thread.

        this.timer = new Timer();
        this.pendingTransactions = new ConcurrentHashMap<String, SIPServerTransaction>();
        
        
        this.forkedClientTransactionTable = new ConcurrentHashMap<String,SIPClientTransaction>();

        if (getThreadAuditor().isEnabled()) {
            // Start monitoring the timer thread
            timer.schedule(new PingTimer(null), 0);
        }
    }

    /**
     * Re Initialize the stack instance.
     */
    protected void reInit() {
        if (stackLogger.isLoggingEnabled())
            stackLogger.logDebug("Re-initializing !");

        // Array of message processors.
        messageProcessors = new ArrayList<MessageProcessor>();
        // Handle IO for this process.
        this.ioHandler = new IOHandler(this);
        // clientTransactions = new ConcurrentLinkedQueue();
        // serverTransactions = new ConcurrentLinkedQueue();
        pendingTransactions = new ConcurrentHashMap<String, SIPServerTransaction>();
        clientTransactionTable = new ConcurrentHashMap<String, SIPClientTransaction>();
        serverTransactionTable = new ConcurrentHashMap<String, SIPServerTransaction>();
        retransmissionAlertTransactions = new ConcurrentHashMap<String, SIPServerTransaction>();
        mergeTable = new ConcurrentHashMap<String, SIPServerTransaction>();
        // Dialog dable.
        this.dialogTable = new ConcurrentHashMap<String, SIPDialog>();
        this.earlyDialogTable = new ConcurrentHashMap<String, SIPDialog>();
        this.terminatedServerTransactionsPendingAck = new ConcurrentHashMap<String,SIPServerTransaction>();
        this.forkedClientTransactionTable = new ConcurrentHashMap<String,SIPClientTransaction>();

        this.timer = new Timer();

        this.activeClientTransactionCount = new AtomicInteger(0);

    }

    /**
     * Creates and binds, if necessary, a socket connected to the specified
     * destination address and port and then returns its local address.
     *
     * @param dst the destination address that the socket would need to connect
     *            to.
     * @param dstPort the port number that the connection would be established
     * with.
     * @param localAddress the address that we would like to bind on
     * (null for the "any" address).
     * @param localPort the port that we'd like our socket to bind to (0 for a
     * random port).
     *
     * @return the SocketAddress that this handler would use when connecting to
     * the specified destination address and port.
     *
     * @throws IOException
     */
    public SocketAddress obtainLocalAddress(InetAddress dst, int dstPort,
                    InetAddress localAddress, int localPort)
        throws IOException
    {
        return this.ioHandler.obtainLocalAddress(
                        dst, dstPort, localAddress, localPort);

    }

    /**
     * For debugging -- allows you to disable logging or enable logging selectively.
     *
     *
     */
    public void disableLogging() {
        this.getStackLogger().disableLogging();
    }

    /**
     * Globally enable message logging ( for debugging)
     *
     */
    public void enableLogging() {
        this.getStackLogger().enableLogging();
    }

    /**
     * Print the dialog table.
     *
     */
    public void printDialogTable() {
        if (isLoggingEnabled()) {
            this.getStackLogger().logDebug("dialog table  = " + this.dialogTable);
            System.out.println("dialog table = " + this.dialogTable);
        }
    }

    /**
     * Retrieve a transaction from our table of transactions with pending retransmission alerts.
     *
     * @param dialogId
     * @return -- the RetransmissionAlert enabled transaction corresponding to the given dialog
     *         ID.
     */
    public SIPServerTransaction getRetransmissionAlertTransaction(String dialogId) {
        return (SIPServerTransaction) this.retransmissionAlertTransactions.get(dialogId);
    }

    /**
     * Return true if extension is supported.
     *
     * @return true if extension is supported and false otherwise.
     */
    public static boolean isDialogCreated(String method) {
    	return dialogCreatingMethods.contains(method);
    }

    /**
     * Add an extension method.
     *
     * @param extensionMethod -- extension method to support for dialog creation
     */
    public void addExtensionMethod(String extensionMethod) {
        if (extensionMethod.equals(Request.NOTIFY)) {
            if (stackLogger.isLoggingEnabled())
                stackLogger.logDebug("NOTIFY Supported Natively");
        } else {
            dialogCreatingMethods.add(extensionMethod.trim().toUpperCase());
        }
    }

    /**
     * Put a dialog into the dialog table.
     *
     * @param dialog -- dialog to put into the dialog table.
     *
     */
    public void putDialog(SIPDialog dialog) {
        String dialogId = dialog.getDialogId();
        if (dialogTable.containsKey(dialogId)) {
            if (stackLogger.isLoggingEnabled()) {
                stackLogger.logDebug("putDialog: dialog already exists" + dialogId + " in table = "
                        + dialogTable.get(dialogId));
            }
            return;
        }
        if (stackLogger.isLoggingEnabled()) {
            stackLogger.logDebug("putDialog dialogId=" + dialogId + " dialog = " + dialog);
        }
        dialog.setStack(this);
        if (stackLogger.isLoggingEnabled())
            stackLogger.logStackTrace();
        dialogTable.put(dialogId, dialog);

    }

    /**
     * Create a dialog and add this transaction to it.
     *
     * @param transaction -- tx to add to the dialog.
     * @return the newly created Dialog.
     */
    public SIPDialog createDialog(SIPTransaction transaction) {

        SIPDialog retval = null;

        if (transaction instanceof SIPClientTransaction) {
            String dialogId = ((SIPRequest) transaction.getRequest()).getDialogId(false);
            if (this.earlyDialogTable.get(dialogId) != null) {
                SIPDialog dialog = this.earlyDialogTable.get(dialogId);
                if (dialog.getState() == null || dialog.getState() == DialogState.EARLY) {
                    retval = dialog;
                } else {
                    retval = new SIPDialog(transaction);
                    this.earlyDialogTable.put(dialogId, retval);
                }
            } else {
                retval = new SIPDialog(transaction);
                this.earlyDialogTable.put(dialogId, retval);
            }
        } else {
            retval = new SIPDialog(transaction);
        }

        return retval;

    }

    /**
     * Create a Dialog given a client tx and response.
     *
     * @param transaction
     * @param sipResponse
     * @return
     */

    public SIPDialog createDialog(SIPClientTransaction transaction, SIPResponse sipResponse) {
        String dialogId = ((SIPRequest) transaction.getRequest()).getDialogId(false);
        SIPDialog retval = null;
        if (this.earlyDialogTable.get(dialogId) != null) {
            retval = this.earlyDialogTable.get(dialogId);
            if (sipResponse.isFinalResponse()) {
                this.earlyDialogTable.remove(dialogId);
            }

        } else {
            retval = new SIPDialog(transaction, sipResponse);
        }
        return retval;

    }
    /**
     * Create a Dialog given a sip provider and response.
     *
     * @param sipProvider
     * @param sipResponse
     * @return
     */
    public SIPDialog createDialog(SipProviderImpl sipProvider,
			SIPResponse sipResponse) {
		return new SIPDialog(sipProvider, sipResponse);
	}

    /**
     * Remove the dialog from the dialog table.
     *
     * @param dialog -- dialog to remove.
     */
    public void removeDialog(SIPDialog dialog) {

        String id = dialog.getDialogId();

        String earlyId = dialog.getEarlyDialogId();

        if (earlyId != null) {
            this.earlyDialogTable.remove(earlyId);
            this.dialogTable.remove(earlyId);
        }

        if (id != null) {

            // FHT: Remove dialog from table only if its associated dialog is the same as the one
            // specified

            Object old = this.dialogTable.get(id);

            if (old == dialog) {
                this.dialogTable.remove(id);
            }
       
            // We now deliver DTE even when the dialog is not originally present in the Dialog
            // Table
            // This happens before the dialog state is assigned.

            if (!dialog.testAndSetIsDialogTerminatedEventDelivered()) {
                DialogTerminatedEvent event = new DialogTerminatedEvent(dialog.getSipProvider(),
                        dialog);

                // Provide notification to the listener that the dialog has
                // ended.
                dialog.getSipProvider().handleEvent(event, null);

            }

        } else if ( this.isDialogTerminatedEventDeliveredForNullDialog ) {
            if (!dialog.testAndSetIsDialogTerminatedEventDelivered()) {
                DialogTerminatedEvent event = new DialogTerminatedEvent(dialog.getSipProvider(),
                        dialog);

                // Provide notification to the listener that the dialog has
                // ended.
                dialog.getSipProvider().handleEvent(event, null);

            }
        }

    }

    /**
     * Return the dialog for a given dialog ID. If compatibility is enabled then we do not assume
     * the presence of tags and hence need to add a flag to indicate whether this is a server or
     * client transaction.
     *
     * @param dialogId is the dialog id to check.
     */

    public SIPDialog getDialog(String dialogId) {

        SIPDialog sipDialog = (SIPDialog) dialogTable.get(dialogId);
        if (stackLogger.isLoggingEnabled()) {
            stackLogger.logDebug("getDialog(" + dialogId + ") : returning " + sipDialog);
        }
        return sipDialog;

    }

    /**
     * Remove the dialog given its dialog id. This is used for dialog id re-assignment only.
     *
     * @param dialogId is the dialog Id to remove.
     */
    public void removeDialog(String dialogId) {
        if (stackLogger.isLoggingEnabled()) {
            stackLogger.logWarning("Silently removing dialog from table");
        }
        dialogTable.remove(dialogId);
    }

    /**
     * Find a matching client SUBSCRIBE to the incoming notify. NOTIFY requests are matched to
     * such SUBSCRIBE requests if they contain the same "Call-ID", a "To" header "tag" parameter
     * which matches the "From" header "tag" parameter of the SUBSCRIBE, and the same "Event"
     * header field. Rules for comparisons of the "Event" headers are described in section 7.2.1.
     * If a matching NOTIFY request contains a "Subscription-State" of "active" or "pending", it
     * creates a new subscription and a new dialog (unless they have already been created by a
     * matching response, as described above).
     *
     * @param notifyMessage
     * @return -- the matching ClientTransaction with semaphore aquired or null if no such client
     *         transaction can be found.
     */
    public SIPClientTransaction findSubscribeTransaction(SIPRequest notifyMessage,
            ListeningPointImpl listeningPoint) {
        SIPClientTransaction retval = null;
        try {
            Iterator it = clientTransactionTable.values().iterator();
            if (stackLogger.isLoggingEnabled())
            	stackLogger.logDebug("ct table size = " + clientTransactionTable.size());
            String thisToTag = notifyMessage.getTo().getTag();
            if (thisToTag == null) {
                return retval;
            }
            Event eventHdr = (Event) notifyMessage.getHeader(EventHeader.NAME);
            if (eventHdr == null) {
                if (stackLogger.isLoggingEnabled()) {
                    stackLogger.logDebug("event Header is null -- returning null");
                }

                return retval;
            }
            while (it.hasNext()) {
                SIPClientTransaction ct = (SIPClientTransaction) it.next();
                if (!ct.getMethod().equals(Request.SUBSCRIBE))
                    continue;

                // if ( sipProvider.getListeningPoint(transport) == null)
                String fromTag = ct.from.getTag();
                Event hisEvent = ct.event;
                // Event header is mandatory but some slopply clients
                // dont include it.
                if (hisEvent == null)
                    continue;
                if (stackLogger.isLoggingEnabled()) {
                    stackLogger.logDebug("ct.fromTag = " + fromTag);
                    stackLogger.logDebug("thisToTag = " + thisToTag);
                    stackLogger.logDebug("hisEvent = " + hisEvent);
                    stackLogger.logDebug("eventHdr " + eventHdr);
                }

                if (  fromTag.equalsIgnoreCase(thisToTag)
                      && hisEvent != null
                      && eventHdr.match(hisEvent)
                      && notifyMessage.getCallId().getCallId().equalsIgnoreCase(
                                ct.callId.getCallId())) {
                    if (ct.acquireSem())
                        retval = ct;
                    return retval;
                }
            }

            return retval;
        } finally {
        	if (stackLogger.isLoggingEnabled())
                stackLogger.logDebug("findSubscribeTransaction : returning " + retval);

        }

    }
    
    /**
     * Add entry to "Transaction Pending ACK" table.
     * 
     * @param serverTransaction
     */
    public void addTransactionPendingAck(SIPServerTransaction serverTransaction) {
        String branchId = ((SIPRequest)serverTransaction.getRequest()).getTopmostVia().getBranch();
        if ( branchId != null ) {
            this.terminatedServerTransactionsPendingAck.put(branchId, serverTransaction);
        }
        
    }
    
    /**
     * Get entry in the server transaction pending ACK table corresponding to an ACK.
     * 
     * @param ackMessage
     * @return
     */
    public SIPServerTransaction findTransactionPendingAck(SIPRequest ackMessage) {
        return this.terminatedServerTransactionsPendingAck.get(ackMessage.getTopmostVia().getBranch());
    }
    
    /**
     * Remove entry from "Transaction Pending ACK" table.
     * 
     * @param serverTransaction
     * @return
     */
    
    public boolean removeTransactionPendingAck(SIPServerTransaction serverTransaction) {
        String branchId = ((SIPRequest)serverTransaction.getRequest()).getTopmostVia().getBranch();
        if ( branchId != null && this.terminatedServerTransactionsPendingAck.containsKey(branchId) ) {
            this.terminatedServerTransactionsPendingAck.remove(branchId);
            return true;
        } else {
            return false;
        }
    }
    
    /**
     * Check if this entry exists in the "Transaction Pending ACK" table.
     * 
     * @param serverTransaction
     * @return
     */
    public boolean isTransactionPendingAck(SIPServerTransaction serverTransaction) {
        String branchId = ((SIPRequest)serverTransaction.getRequest()).getTopmostVia().getBranch();
        return this.terminatedServerTransactionsPendingAck.contains(branchId); 
    }
    
    /**
     * Find the transaction corresponding to a given request.
     *
     * @param sipMessage request for which to retrieve the transaction.
     *
     * @param isServer search the server transaction table if true.
     *
     * @return the transaction object corresponding to the request or null if no such mapping
     *         exists.
     */
    public SIPTransaction findTransaction(SIPMessage sipMessage, boolean isServer) {
        SIPTransaction retval = null;
        try {
            if (isServer) {
                Via via = sipMessage.getTopmostVia();
                if (via.getBranch() != null) {
                    String key = sipMessage.getTransactionId();

                    retval = (SIPTransaction) serverTransactionTable.get(key);
                    if (stackLogger.isLoggingEnabled())
                        getStackLogger().logDebug(
                                "serverTx: looking for key " + key + " existing="
                                + serverTransactionTable);
                    if (key.startsWith(SIPConstants.BRANCH_MAGIC_COOKIE_LOWER_CASE)) {
                        return retval;
                    }

                }
                // Need to scan the table for old style transactions (RFC 2543
                // style)
                Iterator<SIPServerTransaction> it = serverTransactionTable.values().iterator();
                while (it.hasNext()) {
                    SIPServerTransaction sipServerTransaction = (SIPServerTransaction) it.next();
                    if (sipServerTransaction.isMessagePartOfTransaction(sipMessage)) {
                        retval = sipServerTransaction;
                        return retval;
                    }
                }

            } else {
                Via via = sipMessage.getTopmostVia();
                if (via.getBranch() != null) {
                    String key = sipMessage.getTransactionId();
                    if (stackLogger.isLoggingEnabled())
                        getStackLogger().logDebug("clientTx: looking for key " + key);
                    retval = (SIPTransaction) clientTransactionTable.get(key);
                    if (key.startsWith(SIPConstants.BRANCH_MAGIC_COOKIE_LOWER_CASE)) {
                        return retval;
                    }

                }
                // Need to scan the table for old style transactions (RFC 2543
                // style). This is terribly slow but we need to do this
                // for backasswords compatibility.
                Iterator<SIPClientTransaction> it = clientTransactionTable.values().iterator();
                while (it.hasNext()) {
                    SIPClientTransaction clientTransaction = (SIPClientTransaction) it.next();
                    if (clientTransaction.isMessagePartOfTransaction(sipMessage)) {
                        retval = clientTransaction;
                        return retval;
                    }
                }

            }
        } finally {
        	if ( this.getStackLogger().isLoggingEnabled()) {
        	  this.getStackLogger().logDebug("findTransaction: returning  : " + retval);
        	}
        }
        return retval;

    }

    /**
     * Get the transaction to cancel. Search the server transaction table for a transaction that
     * matches the given transaction.
     */
    public SIPTransaction findCancelTransaction(SIPRequest cancelRequest, boolean isServer) {

        if (stackLogger.isLoggingEnabled()) {
            stackLogger.logDebug("findCancelTransaction request= \n" + cancelRequest
                    + "\nfindCancelRequest isServer=" + isServer);
        }

        if (isServer) {
            Iterator<SIPServerTransaction> li = this.serverTransactionTable.values().iterator();
            while (li.hasNext()) {
                SIPTransaction transaction = (SIPTransaction) li.next();

                SIPServerTransaction sipServerTransaction = (SIPServerTransaction) transaction;
                if (sipServerTransaction.doesCancelMatchTransaction(cancelRequest))
                    return sipServerTransaction;
            }

        } else {
            Iterator<SIPClientTransaction> li = this.clientTransactionTable.values().iterator();
            while (li.hasNext()) {
                SIPTransaction transaction = (SIPTransaction) li.next();

                SIPClientTransaction sipClientTransaction = (SIPClientTransaction) transaction;
                if (sipClientTransaction.doesCancelMatchTransaction(cancelRequest))
                    return sipClientTransaction;

            }

        }
        if (stackLogger.isLoggingEnabled())
            stackLogger.logDebug("Could not find transaction for cancel request");
        return null;
    }

    /**
     * Construcor for the stack. Registers the request and response factories for the stack.
     *
     * @param messageFactory User-implemented factory for processing messages.
     */
    protected SIPTransactionStack(StackMessageFactory messageFactory) {
        this();
        this.sipMessageFactory = messageFactory;
    }

    /**
     * Finds a pending server transaction. Since each request may be handled either statefully or
     * statelessly, we keep a map of pending transactions so that a duplicate transaction is not
     * created if a second request is recieved while the first one is being processed.
     *
     * @param requestReceived
     * @return -- the pending transaction or null if no such transaction exists.
     */
    public SIPServerTransaction findPendingTransaction(SIPRequest requestReceived) {
        if (this.stackLogger.isLoggingEnabled()) {
            this.stackLogger.logDebug("looking for pending tx for :"
                    + requestReceived.getTransactionId());
        }
        return (SIPServerTransaction) pendingTransactions.get(requestReceived.getTransactionId());

    }

    /**
     * See if there is a pending transaction with the same Merge ID as the Merge ID obtained from
     * the SIP Request. The Merge table is for handling the following condition: If the request
     * has no tag in the To header field, the UAS core MUST check the request against ongoing
     * transactions. If the From tag, Call-ID, and CSeq exactly match those associated with an
     * ongoing transaction, but the request does not match that transaction (based on the matching
     * rules in Section 17.2.3), the UAS core SHOULD generate a 482 (Loop Detected) response and
     * pass it to the server transaction.
     */
    public SIPServerTransaction findMergedTransaction(SIPRequest sipRequest) {
        if (! sipRequest.getMethod().equals(Request.INVITE)) {
            /*
             * Dont need to worry about request merging for Non-INVITE transactions.
             */
            return null;
        }
        String mergeId = sipRequest.getMergeId();
        SIPServerTransaction mergedTransaction = (SIPServerTransaction) this.mergeTable.get(mergeId);
        if (mergeId == null ) {
            return null;
        } else if (mergedTransaction != null && !mergedTransaction.isMessagePartOfTransaction(sipRequest) ) {
            return mergedTransaction;
        } else {
            /*
             * Check the server transactions that have resulted in dialogs.
             */
           for (Dialog dialog: this.dialogTable.values() ) {
               SIPDialog sipDialog = (SIPDialog) dialog ;
               if (sipDialog.getFirstTransaction()  != null && 
                   sipDialog.getFirstTransaction() instanceof ServerTransaction) {
                   SIPServerTransaction serverTransaction = ((SIPServerTransaction) sipDialog.getFirstTransaction());
                   SIPRequest transactionRequest = ((SIPServerTransaction) sipDialog.getFirstTransaction()).getOriginalRequest();
                   if ( (! serverTransaction.isMessagePartOfTransaction(sipRequest))
                           && sipRequest.getMergeId().equals(transactionRequest.getMergeId())) {
                           return (SIPServerTransaction) sipDialog.getFirstTransaction();  
                   }
               }
           } 
           return null;
        }
    }

    /**
     * Remove a pending Server transaction from the stack. This is called after the user code has
     * completed execution in the listener.
     *
     * @param tr -- pending transaction to remove.
     */
    public void removePendingTransaction(SIPServerTransaction tr) {
        if (this.stackLogger.isLoggingEnabled()) {
            this.stackLogger.logDebug("removePendingTx: " + tr.getTransactionId());
        }
        this.pendingTransactions.remove(tr.getTransactionId());

    }

    /**
     * Remove a transaction from the merge table.
     *
     * @param tr -- the server transaction to remove from the merge table.
     *
     */
    public void removeFromMergeTable(SIPServerTransaction tr) {
        if (stackLogger.isLoggingEnabled()) {
            this.stackLogger.logDebug("Removing tx from merge table ");
        }
        String key = ((SIPRequest) tr.getRequest()).getMergeId();
        if (key != null) {
            this.mergeTable.remove(key);
        }
    }

    /**
     * Put this into the merge request table.
     *
     * @param sipTransaction -- transaction to put into the merge table.
     *
     */
    public void putInMergeTable(SIPServerTransaction sipTransaction, SIPRequest sipRequest) {
        String mergeKey = sipRequest.getMergeId();
        if (mergeKey != null) {
            this.mergeTable.put(mergeKey, sipTransaction);
        }
    }

    /**
     * Map a Server transaction (possibly sending out a 100 if the server tx is an INVITE). This
     * actually places it in the hash table and makes it known to the stack.
     *
     * @param transaction -- the server transaction to map.
     */
    public void mapTransaction(SIPServerTransaction transaction) {
        if (transaction.isMapped)
            return;
        addTransactionHash(transaction);
        // transaction.startTransactionTimer();
        transaction.isMapped = true;
    }

    /**
     * Handles a new SIP request. It finds a server transaction to handle this message. If none
     * exists, it creates a new transaction.
     *
     * @param requestReceived Request to handle.
     * @param requestMessageChannel Channel that received message.
     *
     * @return A server transaction.
     */
    public ServerRequestInterface newSIPServerRequest(SIPRequest requestReceived,
            MessageChannel requestMessageChannel) {
        // Iterator through all server transactions
        Iterator<SIPServerTransaction> transactionIterator;
        // Next transaction in the set
        SIPServerTransaction nextTransaction;
        // Transaction to handle this request
        SIPServerTransaction currentTransaction;

        String key = requestReceived.getTransactionId();

        requestReceived.setMessageChannel(requestMessageChannel);

        currentTransaction = (SIPServerTransaction) serverTransactionTable.get(key);

        // Got to do this for bacasswards compatibility.
        if (currentTransaction == null
                || !currentTransaction.isMessagePartOfTransaction(requestReceived)) {

            // Loop through all server transactions
            transactionIterator = serverTransactionTable.values().iterator();
            currentTransaction = null;
            if (!key.toLowerCase().startsWith(SIPConstants.BRANCH_MAGIC_COOKIE_LOWER_CASE)) {
                while (transactionIterator.hasNext() && currentTransaction == null) {

                    nextTransaction = (SIPServerTransaction) transactionIterator.next();

                    // If this transaction should handle this request,
                    if (nextTransaction.isMessagePartOfTransaction(requestReceived)) {
                        // Mark this transaction as the one
                        // to handle this message
                        currentTransaction = nextTransaction;
                    }
                }
            }

            // If no transaction exists to handle this message
            if (currentTransaction == null) {
                currentTransaction = findPendingTransaction(requestReceived);
                if (currentTransaction != null) {
                    // Associate the tx with the received request.
                    requestReceived.setTransaction(currentTransaction);
                    if (currentTransaction != null && currentTransaction.acquireSem())
                        return currentTransaction;
                    else
                        return null;

                }
                // Creating a new server tx. May fail under heavy load.
                currentTransaction = createServerTransaction(requestMessageChannel);
                if (currentTransaction != null) {
                    // currentTransaction.setPassToListener();
                    currentTransaction.setOriginalRequest(requestReceived);
                    // Associate the tx with the received request.
                    requestReceived.setTransaction(currentTransaction);
                }

            }

        }

        // Set ths transaction's encapsulated request
        // interface from the superclass
        if (stackLogger.isLoggingEnabled()) {
            stackLogger.logDebug("newSIPServerRequest( " + requestReceived.getMethod() + ":"
                    + requestReceived.getTopmostVia().getBranch() + "):" + currentTransaction);
        }

        if (currentTransaction != null)
            currentTransaction.setRequestInterface(sipMessageFactory.newSIPServerRequest(
                    requestReceived, currentTransaction));

        if (currentTransaction != null && currentTransaction.acquireSem()) {
            return currentTransaction;
        } else if (currentTransaction != null) {
            try {
                /*
                 * Already processing a message for this transaction.
                 * SEND a trying ( message already being processed ).
                 */
                if (currentTransaction.isMessagePartOfTransaction(requestReceived) &&
                    currentTransaction.getMethod().equals(requestReceived.getMethod())) {
                    SIPResponse trying = requestReceived.createResponse(Response.TRYING);
                    trying.removeContent();
                    currentTransaction.getMessageChannel().sendMessage(trying);
                }
            } catch (Exception ex) {
            	if (isLoggingEnabled())
            		stackLogger.logError("Exception occured sending TRYING");
            }
            return null;
        } else {
            return null;
        }
    }

    /**
     * Handles a new SIP response. It finds a client transaction to handle this message. If none
     * exists, it sends the message directly to the superclass.
     *
     * @param responseReceived Response to handle.
     * @param responseMessageChannel Channel that received message.
     *
     * @return A client transaction.
     */
    public ServerResponseInterface newSIPServerResponse(SIPResponse responseReceived,
            MessageChannel responseMessageChannel) {

        // Iterator through all client transactions
        Iterator<SIPClientTransaction> transactionIterator;
        // Next transaction in the set
        SIPClientTransaction nextTransaction;
        // Transaction to handle this request
        SIPClientTransaction currentTransaction;

        String key = responseReceived.getTransactionId();

        // Note that for RFC 3261 compliant operation, this lookup will
        // return a tx if one exists and hence no need to search through
        // the table.
        currentTransaction = (SIPClientTransaction) clientTransactionTable.get(key);

        if (currentTransaction == null
                || (!currentTransaction.isMessagePartOfTransaction(responseReceived) && !key
                        .startsWith(SIPConstants.BRANCH_MAGIC_COOKIE_LOWER_CASE))) {
            // Loop through all client transactions

            transactionIterator = clientTransactionTable.values().iterator();
            currentTransaction = null;
            while (transactionIterator.hasNext() && currentTransaction == null) {

                nextTransaction = (SIPClientTransaction) transactionIterator.next();

                // If this transaction should handle this request,
                if (nextTransaction.isMessagePartOfTransaction(responseReceived)) {

                    // Mark this transaction as the one to
                    // handle this message
                    currentTransaction = nextTransaction;

                }

            }

            // If no transaction exists to handle this message,
            if (currentTransaction == null) {
                // JvB: Need to log before passing the response to the client
                // app, it
                // gets modified!
                if (this.stackLogger.isLoggingEnabled(StackLogger.TRACE_INFO)) {
                    responseMessageChannel.logResponse(responseReceived, System
                            .currentTimeMillis(), "before processing");
                }

                // Pass the message directly to the TU
                return sipMessageFactory.newSIPServerResponse(responseReceived,
                        responseMessageChannel);

            }
        }

        // Aquire the sem -- previous request may still be processing.
        boolean acquired = currentTransaction.acquireSem();
        // Set ths transaction's encapsulated response interface
        // from the superclass
        if (this.stackLogger.isLoggingEnabled(StackLogger.TRACE_INFO)) {
            currentTransaction.logResponse(responseReceived, System.currentTimeMillis(),
                    "before processing");
        }

        if (acquired) {
            ServerResponseInterface sri = sipMessageFactory.newSIPServerResponse(
                    responseReceived, currentTransaction);
            if (sri != null) {
                currentTransaction.setResponseInterface(sri);
            } else {
                if (this.stackLogger.isLoggingEnabled()) {
                    this.stackLogger.logDebug("returning null - serverResponseInterface is null!");
                }
                currentTransaction.releaseSem();
                return null;
            }
        } else {
        	if (stackLogger.isLoggingEnabled())
        		this.stackLogger.logDebug("Could not aquire semaphore !!");
        }

        if (acquired)
            return currentTransaction;
        else
            return null;

    }

    /**
     * Creates a client transaction to handle a new request. Gets the real message channel from
     * the superclass, and then creates a new client transaction wrapped around this channel.
     *
     * @param nextHop Hop to create a channel to contact.
     */
    public MessageChannel createMessageChannel(SIPRequest request, MessageProcessor mp,
            Hop nextHop) throws IOException {
        // New client transaction to return
        SIPTransaction returnChannel;

        // Create a new client transaction around the
        // superclass' message channel
        // Create the host/port of the target hop
        Host targetHost = new Host();
        targetHost.setHostname(nextHop.getHost());
        HostPort targetHostPort = new HostPort();
        targetHostPort.setHost(targetHost);
        targetHostPort.setPort(nextHop.getPort());
        MessageChannel mc = mp.createMessageChannel(targetHostPort);

        // Superclass will return null if no message processor
        // available for the transport.
        if (mc == null)
            return null;

        returnChannel = createClientTransaction(request, mc);

        ((SIPClientTransaction) returnChannel).setViaPort(nextHop.getPort());
        ((SIPClientTransaction) returnChannel).setViaHost(nextHop.getHost());
        addTransactionHash(returnChannel);
        // clientTransactionTable.put(returnChannel.getTransactionId(),
        // returnChannel);
        // Add the transaction timer for the state machine.
        // returnChannel.startTransactionTimer();
        return returnChannel;

    }

    /**
     * Creates a client transaction that encapsulates a MessageChannel. Useful for implementations
     * that want to subclass the standard
     *
     * @param encapsulatedMessageChannel Message channel of the transport layer.
     */
    public SIPClientTransaction createClientTransaction(SIPRequest sipRequest,
            MessageChannel encapsulatedMessageChannel) {
        SIPClientTransaction ct = new SIPClientTransaction(this, encapsulatedMessageChannel);
        ct.setOriginalRequest(sipRequest);
        return ct;
    }

    /**
     * Creates a server transaction that encapsulates a MessageChannel. Useful for implementations
     * that want to subclass the standard
     *
     * @param encapsulatedMessageChannel Message channel of the transport layer.
     */
    public SIPServerTransaction createServerTransaction(MessageChannel encapsulatedMessageChannel) {
    	// Issue 256 : be consistent with createClientTransaction, if unlimitedServerTransactionTableSize is true,
    	// a new Server Transaction is created no matter what
        if (unlimitedServerTransactionTableSize) {                
            return new SIPServerTransaction(this, encapsulatedMessageChannel);
        } else {
            float threshold = ((float) (serverTransactionTable.size() - serverTransactionTableLowaterMark))
                    / ((float) (serverTransactionTableHighwaterMark - serverTransactionTableLowaterMark));
            boolean decision = Math.random() > 1.0 - threshold;
            if (decision) {
                return null;
            } else {
                return new SIPServerTransaction(this, encapsulatedMessageChannel);
            }

        }

    }

    /**
     * Get the size of the client transaction table.
     *
     * @return -- size of the ct table.
     */
    public int getClientTransactionTableSize() {
        return this.clientTransactionTable.size();
    }
    
    /**
     * Get the size of the server transaction table.
     *
     * @return -- size of the server table.
     */
    public int getServerTransactionTableSize() {
        return this.serverTransactionTable.size();
    }

    /**
     * Add a new client transaction to the set of existing transactions. Add it to the top of the
     * list so an incoming response has less work to do in order to find the transaction.
     *
     * @param clientTransaction -- client transaction to add to the set.
     */
    public void addTransaction(SIPClientTransaction clientTransaction) {
        if (stackLogger.isLoggingEnabled())
            stackLogger.logDebug("added transaction " + clientTransaction);
        addTransactionHash(clientTransaction);
       
    }

    /**
     * Remove transaction. This actually gets the tx out of the search structures which the stack
     * keeps around. When the tx
     */
    public void removeTransaction(SIPTransaction sipTransaction) {
        if (stackLogger.isLoggingEnabled()) {
            stackLogger.logDebug("Removing Transaction = " + sipTransaction.getTransactionId()
                    + " transaction = " + sipTransaction);
        }
        if (sipTransaction instanceof SIPServerTransaction) {
            if (stackLogger.isLoggingEnabled())
                stackLogger.logStackTrace();
            String key = sipTransaction.getTransactionId();
            Object removed = serverTransactionTable.remove(key);
            String method = sipTransaction.getMethod();
            this.removePendingTransaction((SIPServerTransaction) sipTransaction);
            this.removeTransactionPendingAck((SIPServerTransaction) sipTransaction);
            if (method.equalsIgnoreCase(Request.INVITE)) {
                this.removeFromMergeTable((SIPServerTransaction) sipTransaction);
            }
            // Send a notification to the listener.
            SipProviderImpl sipProvider = (SipProviderImpl) sipTransaction.getSipProvider();
            if (removed != null && sipTransaction.testAndSetTransactionTerminatedEvent()) {
                TransactionTerminatedEvent event = new TransactionTerminatedEvent(sipProvider,
                        (ServerTransaction) sipTransaction);

                sipProvider.handleEvent(event, sipTransaction);

            }
        } else {

            String key = sipTransaction.getTransactionId();
            Object removed = clientTransactionTable.remove(key);

            if (stackLogger.isLoggingEnabled()) {
                stackLogger.logDebug("REMOVED client tx " + removed + " KEY = " + key);
                if ( removed != null ) {
                   SIPClientTransaction clientTx = (SIPClientTransaction)removed;
                   if ( clientTx.getMethod().equals(Request.INVITE) && this.maxForkTime != 0 ) {
                       RemoveForkedTransactionTimerTask ttask = new RemoveForkedTransactionTimerTask(clientTx);
                       this.timer.schedule(ttask, this.maxForkTime * 1000);
                   }
                }
            }

            // Send a notification to the listener.
            if (removed != null && sipTransaction.testAndSetTransactionTerminatedEvent()) {
                SipProviderImpl sipProvider = (SipProviderImpl) sipTransaction.getSipProvider();
                TransactionTerminatedEvent event = new TransactionTerminatedEvent(sipProvider,
                        (ClientTransaction) sipTransaction);

                sipProvider.handleEvent(event, sipTransaction);
            }

        }
    }

    /**
     * Add a new server transaction to the set of existing transactions. Add it to the top of the
     * list so an incoming ack has less work to do in order to find the transaction.
     *
     * @param serverTransaction -- server transaction to add to the set.
     */
    public void addTransaction(SIPServerTransaction serverTransaction) throws IOException {
        if (stackLogger.isLoggingEnabled())
            stackLogger.logDebug("added transaction " + serverTransaction);
        serverTransaction.map();

        addTransactionHash(serverTransaction);
      
    }

    /**
     * Hash table for quick lookup of transactions. Here we wait for room if needed.
     */
    private void addTransactionHash(SIPTransaction sipTransaction) {
        SIPRequest sipRequest = sipTransaction.getOriginalRequest();
        if (sipTransaction instanceof SIPClientTransaction) {
            if (!this.unlimitedClientTransactionTableSize) {
                if (this.activeClientTransactionCount.get() > clientTransactionTableHiwaterMark) {
                    try {
                        synchronized (this.clientTransactionTable) {
                            this.clientTransactionTable.wait();
                            this.activeClientTransactionCount.incrementAndGet();
                        }

                    } catch (Exception ex) {
                        if (stackLogger.isLoggingEnabled()) {
                            stackLogger.logError("Exception occured while waiting for room", ex);
                        }

                    }
                }
            } else {
                this.activeClientTransactionCount.incrementAndGet();
            }
            String key = sipRequest.getTransactionId();
            clientTransactionTable.put(key, (SIPClientTransaction) sipTransaction);
            
            if (stackLogger.isLoggingEnabled()) {
                stackLogger.logDebug(" putTransactionHash : " + " key = " + key);
            }
        } else {
            String key = sipRequest.getTransactionId();

            if (stackLogger.isLoggingEnabled()) {
                stackLogger.logDebug(" putTransactionHash : " + " key = " + key);
            }
            serverTransactionTable.put(key, (SIPServerTransaction) sipTransaction);

        }

    }

    /**
     * This method is called when a client tx transitions to the Completed or Terminated state.
     *
     */
    protected void decrementActiveClientTransactionCount() {

        if (this.activeClientTransactionCount.decrementAndGet() <= this.clientTransactionTableLowaterMark
                && !this.unlimitedClientTransactionTableSize) {
            synchronized (this.clientTransactionTable) {

                clientTransactionTable.notify();

            }
        }
    }

    /**
     * Remove the transaction from transaction hash.
     */
    protected void removeTransactionHash(SIPTransaction sipTransaction) {
        SIPRequest sipRequest = sipTransaction.getOriginalRequest();
        if (sipRequest == null)
            return;
        if (sipTransaction instanceof SIPClientTransaction) {
            String key = sipTransaction.getTransactionId();
            if (stackLogger.isLoggingEnabled()) {
                stackLogger.logStackTrace();
                stackLogger.logDebug("removing client Tx : " + key);
            }
            clientTransactionTable.remove(key);

        } else if (sipTransaction instanceof SIPServerTransaction) {
            String key = sipTransaction.getTransactionId();
            serverTransactionTable.remove(key);
            if (stackLogger.isLoggingEnabled()) {
                stackLogger.logDebug("removing server Tx : " + key);
            }
        }
    }

    /**
     * Invoked when an error has ocurred with a transaction.
     *
     * @param transactionErrorEvent Error event.
     */
    public synchronized void transactionErrorEvent(SIPTransactionErrorEvent transactionErrorEvent) {
        SIPTransaction transaction = (SIPTransaction) transactionErrorEvent.getSource();

        if (transactionErrorEvent.getErrorID() == SIPTransactionErrorEvent.TRANSPORT_ERROR) {
            // Kill scanning of this transaction.
            transaction.setState(SIPTransaction.TERMINATED_STATE);
            if (transaction instanceof SIPServerTransaction) {
                // let the reaper get him
                ((SIPServerTransaction) transaction).collectionTime = 0;
            }
            transaction.disableTimeoutTimer();
            transaction.disableRetransmissionTimer();
            // Send a IO Exception to the Listener.
        }
    }
    
    /*
     * (non-Javadoc)
     * @see gov.nist.javax.sip.stack.SIPDialogEventListener#dialogErrorEvent(gov.nist.javax.sip.stack.SIPDialogErrorEvent)
     */
    public synchronized void dialogErrorEvent(SIPDialogErrorEvent dialogErrorEvent) {
        SIPDialog sipDialog = (SIPDialog) dialogErrorEvent.getSource();
        SipListener sipListener = ((SipStackImpl)this).getSipListener();
        // if the app is not implementing the SipListenerExt interface we delete the dialog to avoid leaks
        if(sipDialog != null && !(sipListener instanceof SipListenerExt)) {
        	sipDialog.delete();
        }
    }

    /**
     * Stop stack. Clear all the timer stuff. Make the stack close all accept connections and
     * return. This is useful if you want to start/stop the stack several times from your
     * application. Caution : use of this function could cause peculiar bugs as messages are
     * prcessed asynchronously by the stack.
     */
    public void stopStack() {
        // Prevent NPE on two concurrent stops
        if (this.timer != null)
            this.timer.cancel();

        // JvB: set it to null, SIPDialog tries to schedule things after stop
        timer = null;
        this.pendingTransactions.clear();
        this.toExit = true;
        synchronized (this) {
            this.notifyAll();
        }
        synchronized (this.clientTransactionTable) {
            clientTransactionTable.notifyAll();
        }

        synchronized (this.messageProcessors) {
            // Threads must periodically check this flag.
            MessageProcessor[] processorList;
            processorList = getMessageProcessors();
            for (int processorIndex = 0; processorIndex < processorList.length; processorIndex++) {
                removeMessageProcessor(processorList[processorIndex]);
            }
            this.ioHandler.closeAll();
            // Let the processing complete.

        }
        try {

            Thread.sleep(1000);

        } catch (InterruptedException ex) {
        }
        this.clientTransactionTable.clear();
        this.serverTransactionTable.clear();

        this.dialogTable.clear();
        this.serverLogger.closeLogFile();

    }

    /**
     * Put a transaction in the pending transaction list. This is to avoid a race condition when a
     * duplicate may arrive when the application is deciding whether to create a transaction or
     * not.
     */
    public void putPendingTransaction(SIPServerTransaction tr) {
        if (stackLogger.isLoggingEnabled())
            stackLogger.logDebug("putPendingTransaction: " + tr);

        this.pendingTransactions.put(tr.getTransactionId(), tr);

    }

    /**
     * Return the network layer (i.e. the interface for socket creation or the socket factory for
     * the stack).
     *
     * @return -- the registered Network Layer.
     */
    public NetworkLayer getNetworkLayer() {
        if (networkLayer == null) {
            return DefaultNetworkLayer.SINGLETON;
        } else {
            return networkLayer;
        }
    }

    /**
     * Return true if logging is enabled for this stack.
     *
     * @return true if logging is enabled for this stack instance.
     */
    public boolean isLoggingEnabled() {
        return this.stackLogger == null ? false : this.stackLogger.isLoggingEnabled();
    }

    /**
     * Get the logger.
     *
     * @return --the logger for the sip stack. Each stack has its own logger instance.
     */
    public StackLogger getStackLogger() {
        return this.stackLogger;
    }

    /**
     * Server log is the place where we log messages for the signaling trace viewer.
     *
     * @return -- the log file where messages are logged for viewing by the trace viewer.
     */
    public ServerLogger getServerLogger() {
        return this.serverLogger;
    }

    /**
     * Maximum size of a single TCP message. Limiting the size of a single TCP message prevents
     * flooding attacks.
     *
     * @return the size of a single TCP message.
     */
    public int getMaxMessageSize() {
        return this.maxMessageSize;
    }

    /**
     * Set the flag that instructs the stack to only start a single thread for sequentially
     * processing incoming udp messages (thus serializing the processing). Same as setting thread
     * pool size to 1.
     */
    public void setSingleThreaded() {
        this.threadPoolSize = 1;
    }

    /**
     * Set the thread pool size for processing incoming UDP messages. Limit the total number of
     * threads for processing udp messages.
     *
     * @param size -- the thread pool size.
     *
     */
    public void setThreadPoolSize(int size) {
        this.threadPoolSize = size;
    }

    /**
     * Set the max # of simultaneously handled TCP connections.
     *
     * @param nconnections -- the number of connections to handle.
     */
    public void setMaxConnections(int nconnections) {
        this.maxConnections = nconnections;
    }

    /**
     * Get the default route string.
     *
     * @param sipRequest is the request for which we want to compute the next hop.
     * @throws SipException
     */
    public Hop getNextHop(SIPRequest sipRequest) throws SipException {
        if (this.useRouterForAll) {
            // Use custom router to route all messages.
            if (router != null)
                return router.getNextHop(sipRequest);
            else
                return null;
        } else {
            // Also non-SIP request containing Route headers goes to the default
            // router
            if (sipRequest.getRequestURI().isSipURI() || sipRequest.getRouteHeaders() != null) {
                return defaultRouter.getNextHop(sipRequest);
            } else if (router != null) {
                return router.getNextHop(sipRequest);
            } else
                return null;
        }
    }

    /**
     * Set the descriptive name of the stack.
     *
     * @param stackName -- descriptive name of the stack.
     */
    public void setStackName(String stackName) {
        this.stackName = stackName;
    }



    /**
     * Set my address.
     *
     * @param stackAddress -- A string containing the stack address.
     */
    protected void setHostAddress(String stackAddress) throws UnknownHostException {
        if (stackAddress.indexOf(':') != stackAddress.lastIndexOf(':')
                && stackAddress.trim().charAt(0) != '[')
            this.stackAddress = '[' + stackAddress + ']';
        else
            this.stackAddress = stackAddress;
        this.stackInetAddress = InetAddress.getByName(stackAddress);
    }

    /**
     * Get my address.
     *
     * @return hostAddress - my host address or null if no host address is defined.
     * @deprecated
     */
    public String getHostAddress() {

        // JvB: for 1.2 this may return null...
        return this.stackAddress;
    }

    /**
     * Set the router algorithm. This is meant for routing messages out of dialog or for non-sip
     * uri's.
     *
     * @param router A class that implements the Router interface.
     */
    protected void setRouter(Router router) {
        this.router = router;
    }

    /**
     * Get the router algorithm.
     *
     * @return Router router
     */
    public Router getRouter(SIPRequest request) {
        if (request.getRequestLine() == null) {
            return this.defaultRouter;
        } else if (this.useRouterForAll) {
            return this.router;
        } else {
            if (request.getRequestURI().getScheme().equals("sip")
                    || request.getRequestURI().getScheme().equals("sips")) {
                return this.defaultRouter;
            } else {
                if (this.router != null)
                    return this.router;
                else
                    return defaultRouter;
            }
        }
    }

    /*
     * (non-Javadoc)
     *
     * @see javax.sip.SipStack#getRouter()
     */
    public Router getRouter() {
        return this.router;
    }

    /**
     * return the status of the toExit flag.
     *
     * @return true if the stack object is alive and false otherwise.
     */
    public boolean isAlive() {
        return !toExit;
    }

    /**
     * Adds a new MessageProcessor to the list of running processors for this SIPStack and starts
     * it. You can use this method for dynamic stack configuration.
     */
    protected void addMessageProcessor(MessageProcessor newMessageProcessor) throws IOException {
        synchronized (messageProcessors) {
            // Suggested changes by Jeyashankher, jai@lucent.com
            // newMessageProcessor.start() can fail
            // because a local port is not available
            // This throws an IOException.
            // We should not add the message processor to the
            // local list of processors unless the start()
            // call is successful.
            // newMessageProcessor.start();
            messageProcessors.add(newMessageProcessor);

        }
    }

    /**
     * Removes a MessageProcessor from this SIPStack.
     *
     * @param oldMessageProcessor
     */
    protected void removeMessageProcessor(MessageProcessor oldMessageProcessor) {
        synchronized (messageProcessors) {
            if (messageProcessors.remove(oldMessageProcessor)) {
                oldMessageProcessor.stop();
            }
        }
    }

    /**
     * Gets an array of running MessageProcessors on this SIPStack. Acknowledgement: Jeff Keyser
     * suggested that applications should have access to the running message processors and
     * contributed this code.
     *
     * @return an array of running message processors.
     */
    protected MessageProcessor[] getMessageProcessors() {
        synchronized (messageProcessors) {
            return (MessageProcessor[]) messageProcessors.toArray(new MessageProcessor[0]);
        }
    }

    /**
     * Creates the equivalent of a JAIN listening point and attaches to the stack.
     *
     * @param ipAddress -- ip address for the listening point.
     * @param port -- port for the listening point.
     * @param transport -- transport for the listening point.
     */
    protected MessageProcessor createMessageProcessor(InetAddress ipAddress, int port,
            String transport) throws java.io.IOException {
        if (transport.equalsIgnoreCase("udp")) {
            UDPMessageProcessor udpMessageProcessor = new UDPMessageProcessor(ipAddress, this,
                    port);
            this.addMessageProcessor(udpMessageProcessor);
            this.udpFlag = true;
            return udpMessageProcessor;
        } else if (transport.equalsIgnoreCase("tcp")) {
            TCPMessageProcessor tcpMessageProcessor = new TCPMessageProcessor(ipAddress, this,
                    port);
            this.addMessageProcessor(tcpMessageProcessor);
            // this.tcpFlag = true;
            return tcpMessageProcessor;
        } else if (transport.equalsIgnoreCase("tls")) {
            TLSMessageProcessor tlsMessageProcessor = new TLSMessageProcessor(ipAddress, this,
                    port);
            this.addMessageProcessor(tlsMessageProcessor);
            // this.tlsFlag = true;
            return tlsMessageProcessor;
        } else if (transport.equalsIgnoreCase("sctp")) {
        	
        	// Need Java 7 for this, so these classes are packaged in a separate jar
        	// Try to load it indirectly, if fails report an error
        	try {
				Class<?> mpc = ClassLoader.getSystemClassLoader().loadClass( "gov.nist.javax.sip.stack.sctp.SCTPMessageProcessor" );
				MessageProcessor mp = (MessageProcessor) mpc.newInstance();
				mp.initialize( ipAddress, port, this );
				this.addMessageProcessor(mp);
				return mp;
			} catch (ClassNotFoundException e) {
				throw new IllegalArgumentException("SCTP not supported (needs Java 7 and SCTP jar in classpath)");
			} catch ( InstantiationException ie ) {
				throw new IllegalArgumentException("Error initializing SCTP", ie);				
			} catch ( IllegalAccessException ie ) {
				throw new IllegalArgumentException("Error initializing SCTP", ie);				
			}
        } else {
            throw new IllegalArgumentException("bad transport");
        }

    }

    /**
     * Set the message factory.
     *
     * @param messageFactory -- messageFactory to set.
     */
    protected void setMessageFactory(StackMessageFactory messageFactory) {
        this.sipMessageFactory = messageFactory;
    }

    /**
     * Creates a new MessageChannel for a given Hop.
     *
     * @param sourceIpAddress - Ip address of the source of this message.
     *
     * @param sourcePort - source port of the message channel to be created.
     *
     * @param nextHop Hop to create a MessageChannel to.
     *
     * @return A MessageChannel to the specified Hop, or null if no MessageProcessors support
     *         contacting that Hop.
     *
     * @throws UnknownHostException If the host in the Hop doesn't exist.
     */
    public MessageChannel createRawMessageChannel(String sourceIpAddress, int sourcePort,
            Hop nextHop) throws UnknownHostException {
        Host targetHost;
        HostPort targetHostPort;
        Iterator processorIterator;
        MessageProcessor nextProcessor;
        MessageChannel newChannel;

        // Create the host/port of the target hop
        targetHost = new Host();
        targetHost.setHostname(nextHop.getHost());
        targetHostPort = new HostPort();
        targetHostPort.setHost(targetHost);
        targetHostPort.setPort(nextHop.getPort());

        // Search each processor for the correct transport
        newChannel = null;
        processorIterator = messageProcessors.iterator();
        while (processorIterator.hasNext() && newChannel == null) {
            nextProcessor = (MessageProcessor) processorIterator.next();
            // If a processor that supports the correct
            // transport is found,
            if (nextHop.getTransport().equalsIgnoreCase(nextProcessor.getTransport())
                    && sourceIpAddress.equals(nextProcessor.getIpAddress().getHostAddress())
                    && sourcePort == nextProcessor.getPort()) {
                try {
                    // Create a channel to the target
                    // host/port
                    newChannel = nextProcessor.createMessageChannel(targetHostPort);
                } catch (UnknownHostException ex) {
                    if (stackLogger.isLoggingEnabled())
                        stackLogger.logException(ex);
                    throw ex;
                } catch (IOException e) {
                    if (stackLogger.isLoggingEnabled())
                        stackLogger.logException(e);
                    // Ignore channel creation error -
                    // try next processor
                }
            }
        }
        // Return the newly-created channel
        return newChannel;
    }

    /**
     * Return true if a given event can result in a forked subscription. The stack is configured
     * with a set of event names that can result in forked subscriptions.
     *
     * @param ename -- event name to check.
     *
     */
    public boolean isEventForked(String ename) {
        if (stackLogger.isLoggingEnabled()) {
            stackLogger.logDebug("isEventForked: " + ename + " returning "
                    + this.forkedEvents.contains(ename));
        }
        return this.forkedEvents.contains(ename);
    }

    /**
     * get the address resolver interface.
     *
     * @return -- the registered address resolver.
     */
    public AddressResolver getAddressResolver() {
        return this.addressResolver;
    }

    /**
     * Set the address resolution interface
     *
     * @param addressResolver -- the address resolver to set.
     */
    public void setAddressResolver(AddressResolver addressResolver) {
        this.addressResolver = addressResolver;
    }

    /**
     * Set the logger factory.
     *
     * @param logRecordFactory -- the log record factory to set.
     */
    public void setLogRecordFactory(LogRecordFactory logRecordFactory) {
        this.logRecordFactory = logRecordFactory;
    }

    /**
     * get the thread auditor object
     *
     * @return -- the thread auditor of the stack
     */
    public ThreadAuditor getThreadAuditor() {
        return this.threadAuditor;
    }

    // /
    // / Stack Audit methods
    // /

    /**
     * Audits the SIP Stack for leaks
     *
     * @return Audit report, null if no leaks were found
     */
    public String auditStack(Set activeCallIDs, long leakedDialogTimer,
            long leakedTransactionTimer) {
        String auditReport = null;
        String leakedDialogs = auditDialogs(activeCallIDs, leakedDialogTimer);
        String leakedServerTransactions = auditTransactions(serverTransactionTable,
                leakedTransactionTimer);
        String leakedClientTransactions = auditTransactions(clientTransactionTable,
                leakedTransactionTimer);
        if (leakedDialogs != null || leakedServerTransactions != null
                || leakedClientTransactions != null) {
            auditReport = "SIP Stack Audit:\n" + (leakedDialogs != null ? leakedDialogs : "")
                    + (leakedServerTransactions != null ? leakedServerTransactions : "")
                    + (leakedClientTransactions != null ? leakedClientTransactions : "");
        }
        return auditReport;
    }

    /**
     * Audits SIP dialogs for leaks - Compares the dialogs in the dialogTable with a list of Call
     * IDs passed by the application. - Dialogs that are not known by the application are leak
     * suspects. - Kill the dialogs that are still around after the timer specified.
     *
     * @return Audit report, null if no dialog leaks were found
     */
    private String auditDialogs(Set activeCallIDs, long leakedDialogTimer) {
        String auditReport = "  Leaked dialogs:\n";
        int leakedDialogs = 0;
        long currentTime = System.currentTimeMillis();

        // Make a shallow copy of the dialog list.
        // This copy will remain intact as leaked dialogs are removed by the
        // stack.
        LinkedList dialogs;
        synchronized (dialogTable) {
            dialogs = new LinkedList(dialogTable.values());
        }

        // Iterate through the dialogDialog, get the callID of each dialog and
        // check if it's in the
        // list of active calls passed by the application. If it isn't, start
        // the timer on it.
        // If the timer has expired, kill the dialog.
        Iterator it = dialogs.iterator();
        while (it.hasNext()) {
            // Get the next dialog
            SIPDialog itDialog = (SIPDialog) it.next();

            // Get the call id associated with this dialog
            CallIdHeader callIdHeader = (itDialog != null ? itDialog.getCallId() : null);
            String callID = (callIdHeader != null ? callIdHeader.getCallId() : null);

            // Check if the application knows about this call id
            if (itDialog != null && callID != null && !activeCallIDs.contains(callID)) {
                // Application doesn't know anything about this dialog...
                if (itDialog.auditTag == 0) {
                    // Mark this dialog as suspect
                    itDialog.auditTag = currentTime;
                } else {
                    // We already audited this dialog before. Check if his
                    // time's up.
                    if (currentTime - itDialog.auditTag >= leakedDialogTimer) {
                        // Leaked dialog found
                        leakedDialogs++;

                        // Generate report
                        DialogState dialogState = itDialog.getState();
                        String dialogReport = "dialog id: " + itDialog.getDialogId()
                                + ", dialog state: "
                                + (dialogState != null ? dialogState.toString() : "null");
                        auditReport += "    " + dialogReport + "\n";

                        // Kill it
                        itDialog.setState(SIPDialog.TERMINATED_STATE);
                        if (stackLogger.isLoggingEnabled())
                        	stackLogger.logDebug("auditDialogs: leaked " + dialogReport);
                    }
                }
            }
        }

        // Return final report
        if (leakedDialogs > 0) {
            auditReport += "    Total: " + Integer.toString(leakedDialogs)
                    + " leaked dialogs detected and removed.\n";
        } else {
            auditReport = null;
        }
        return auditReport;
    }

    /**
     * Audits SIP transactions for leaks
     *
     * @return Audit report, null if no transaction leaks were found
     */
    private String auditTransactions(ConcurrentHashMap transactionsMap,
            long a_nLeakedTransactionTimer) {
        String auditReport = "  Leaked transactions:\n";
        int leakedTransactions = 0;
        long currentTime = System.currentTimeMillis();

        // Make a shallow copy of the transaction list.
        // This copy will remain intact as leaked transactions are removed by
        // the stack.
        LinkedList transactionsList = new LinkedList(transactionsMap.values());

        // Iterate through our copy
        Iterator it = transactionsList.iterator();
        while (it.hasNext()) {
            SIPTransaction sipTransaction = (SIPTransaction) it.next();
            if (sipTransaction != null) {
                if (sipTransaction.auditTag == 0) {
                    // First time we see this transaction. Mark it as audited.
                    sipTransaction.auditTag = currentTime;
                } else {
                    // We've seen this transaction before. Check if his time's
                    // up.
                    if (currentTime - sipTransaction.auditTag >= a_nLeakedTransactionTimer) {
                        // Leaked transaction found
                        leakedTransactions++;

                        // Generate some report
                        TransactionState transactionState = sipTransaction.getState();
                        SIPRequest origRequest = sipTransaction.getOriginalRequest();
                        String origRequestMethod = (origRequest != null ? origRequest.getMethod()
                                : null);
                        String transactionReport = sipTransaction.getClass().getName()
                                + ", state: "
                                + (transactionState != null ? transactionState.toString()
                                        : "null") + ", OR: "
                                + (origRequestMethod != null ? origRequestMethod : "null");
                        auditReport += "    " + transactionReport + "\n";

                        // Kill it
                        removeTransaction(sipTransaction);
                        if (isLoggingEnabled())
                        	stackLogger.logDebug("auditTransactions: leaked " + transactionReport);
                    }
                }
            }
        }

        // Return final report
        if (leakedTransactions > 0) {
            auditReport += "    Total: " + Integer.toString(leakedTransactions)
                    + " leaked transactions detected and removed.\n";
        } else {
            auditReport = null;
        }
        return auditReport;
    }

    public void setNon2XXAckPassedToListener(boolean passToListener) {
        this.non2XXAckPassedToListener = passToListener;
    }

    /**
     * @return the non2XXAckPassedToListener
     */
    public boolean isNon2XXAckPassedToListener() {
        return non2XXAckPassedToListener;
    }

    /**
     * Get the count of client transactions that is not in the completed or terminated state.
     *
     * @return the activeClientTransactionCount
     */
    public int getActiveClientTransactionCount() {
        return activeClientTransactionCount.get();
    }

    public boolean isRfc2543Supported() {

        return this.rfc2543Supported;
    }

    public boolean isCancelClientTransactionChecked() {
        return this.cancelClientTransactionChecked;
    }

    public boolean isRemoteTagReassignmentAllowed() {
        return this.remoteTagReassignmentAllowed;
    }

    /**
     * This method is slated for addition to the next spec revision.
     *
     *
     * @return -- the collection of dialogs that is being managed by the stack.
     */
    public Collection<Dialog> getDialogs() {
        HashSet<Dialog> dialogs = new HashSet<Dialog>();
        dialogs.addAll(this.dialogTable.values());
        dialogs.addAll(this.earlyDialogTable.values());
        return dialogs;
    }

    /**
     *
     * @return -- the collection of dialogs matching the state that is being managed by the stack.
     */
    public Collection<Dialog> getDialogs(DialogState state) {
        HashSet<Dialog> matchingDialogs = new HashSet<Dialog>();
        if (DialogState.EARLY.equals(state)) {
            matchingDialogs.addAll(this.earlyDialogTable.values());
        } else {
            Collection<SIPDialog> dialogs = dialogTable.values();
            for (SIPDialog dialog : dialogs) {
                if (dialog.getState() != null && dialog.getState().equals(state)) {
                    matchingDialogs.add(dialog);
                }
            }
        }
        return matchingDialogs;
    }

    /**
     * Get the Replaced Dialog from the stack.
     *
     * @param replacesHeader -- the header that references the dialog being replaced.
     */
    public Dialog getReplacesDialog(ReplacesHeader replacesHeader) {
        String cid = replacesHeader.getCallId();
        String fromTag = replacesHeader.getFromTag();
        String toTag = replacesHeader.getToTag();

        StringBuffer dialogId = new StringBuffer(cid);

        // retval.append(COLON).append(to.getUserAtHostPort());
        if (toTag != null) {
            dialogId.append(":");
            dialogId.append(toTag);
        }
        // retval.append(COLON).append(from.getUserAtHostPort());
        if (fromTag != null) {
            dialogId.append(":");
            dialogId.append(fromTag);
        }
        String did = dialogId.toString().toLowerCase();
        if (stackLogger.isLoggingEnabled())
        	stackLogger.logDebug("Looking for dialog " + did);
        /*
         * Check if we can find this dialog in our dialog table.
         */
        Dialog replacesDialog =  this.dialogTable.get(did);
        /*
         * This could be a forked dialog. Search for it.
         */
        if ( replacesDialog == null ) {
           for ( SIPClientTransaction ctx : this.clientTransactionTable.values()) {
               if ( ctx.getDialog(did) != null ) {
                   replacesDialog = ctx.getDialog(did);
                   break;
               }
           }
        }

        return replacesDialog;
    }

    /**
     * Get the Join Dialog from the stack.
     *
     * @param joinHeader -- the header that references the dialog being joined.
     */
    public Dialog getJoinDialog(JoinHeader joinHeader) {
        String cid = joinHeader.getCallId();
        String fromTag = joinHeader.getFromTag();
        String toTag = joinHeader.getToTag();

        StringBuffer retval = new StringBuffer(cid);

        // retval.append(COLON).append(to.getUserAtHostPort());
        if (toTag != null) {
            retval.append(":");
            retval.append(toTag);
        }
        // retval.append(COLON).append(from.getUserAtHostPort());
        if (fromTag != null) {
            retval.append(":");
            retval.append(fromTag);
        }
        return this.dialogTable.get(retval.toString().toLowerCase());
    }

    /**
     * @param timer the timer to set
     */
    public void setTimer(Timer timer) {
        this.timer = timer;
    }

    /**
     * @return the timer
     */
    public Timer getTimer() {
        return timer;
    }

    
    /**
     * Size of the receive UDP buffer. This property affects performance under load. Bigger buffer
     * is better under load.
     * 
     * @return
     */
	public int getReceiveUdpBufferSize() {
		return receiveUdpBufferSize;
	}

    /**
     * Size of the receive UDP buffer. This property affects performance under load. Bigger buffer
     * is better under load.
     * 
     * @return
     */
	public void setReceiveUdpBufferSize(int receiveUdpBufferSize) {
		this.receiveUdpBufferSize = receiveUdpBufferSize;
	}

    /**
     * Size of the send UDP buffer. This property affects performance under load. Bigger buffer
     * is better under load.
     * 
     * @return
     */
	public int getSendUdpBufferSize() {
		return sendUdpBufferSize;
	}

    /**
     * Size of the send UDP buffer. This property affects performance under load. Bigger buffer
     * is better under load.
     * 
     * @return
     */
	public void setSendUdpBufferSize(int sendUdpBufferSize) {
		this.sendUdpBufferSize = sendUdpBufferSize;
	}

	/**
	 * @param stackLogger the stackLogger to set
	 */
	public void setStackLogger(StackLogger stackLogger) {		
		this.stackLogger = stackLogger;
	}
	
	 /**
	  * Flag that reqests checking of branch IDs on responses.
	  * 
	  * @return
	  */
	 public boolean checkBranchId() {
	       return this.checkBranchId;
	 }

    /**
     * @param logStackTraceOnMessageSend the logStackTraceOnMessageSend to set
     */
    public void setLogStackTraceOnMessageSend(boolean logStackTraceOnMessageSend) {
        this.logStackTraceOnMessageSend = logStackTraceOnMessageSend;
    }

    /**
     * @return the logStackTraceOnMessageSend
     */
    public boolean isLogStackTraceOnMessageSend() {
        return logStackTraceOnMessageSend;
    }
    
    public void setDeliverDialogTerminatedEventForNullDialog() {
        this.isDialogTerminatedEventDeliveredForNullDialog = true;
    }
    
    public void addForkedClientTransaction(SIPClientTransaction clientTransaction) {
        this.forkedClientTransactionTable.put(clientTransaction.getTransactionId(), clientTransaction );
    }

    public SIPClientTransaction getForkedTransaction(String transactionId) {
        return this.forkedClientTransactionTable.get(transactionId);
    }
	
	
}
