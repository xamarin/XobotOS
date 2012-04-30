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

import gov.nist.core.InternalErrorHandler;
import gov.nist.javax.sip.SIPConstants;
import gov.nist.javax.sip.SipProviderImpl;
import gov.nist.javax.sip.header.CallID;
import gov.nist.javax.sip.header.Event;
import gov.nist.javax.sip.header.From;
import gov.nist.javax.sip.header.To;
import gov.nist.javax.sip.header.Via;
import gov.nist.javax.sip.header.ViaList;
import gov.nist.javax.sip.message.SIPMessage;
import gov.nist.javax.sip.message.SIPRequest;
import gov.nist.javax.sip.message.SIPResponse;

import java.io.IOException;
import java.net.InetAddress;
import java.util.Collections;
import java.util.HashSet;
import java.util.Iterator;
import java.util.Set;
import java.util.concurrent.Semaphore;
import java.util.concurrent.TimeUnit;
import java.util.concurrent.atomic.AtomicBoolean;

import javax.net.ssl.SSLPeerUnverifiedException;
import javax.sip.Dialog;
import javax.sip.IOExceptionEvent;
import javax.sip.ServerTransaction;
import javax.sip.TransactionState;
import javax.sip.message.Request;
import javax.sip.message.Response;

/*
 * Modifications for TLS Support added by Daniel J. Martinez Manzano
 * <dani@dif.um.es> Bug fixes by Jeroen van Bemmel (JvB) and others.
 */

/**
 * Abstract class to support both client and server transactions. Provides an
 * encapsulation of a message channel, handles timer events, and creation of the
 * Via header for a message.
 *
 * @author Jeff Keyser
 * @author M. Ranganathan
 *
 *
 * @version 1.2 $Revision: 1.71 $ $Date: 2009/11/29 04:31:29 $
 */
public abstract class SIPTransaction extends MessageChannel implements
        javax.sip.Transaction, gov.nist.javax.sip.TransactionExt {

    protected boolean toListener; // Flag to indicate that the listener gets

    // to see the event.

    protected int BASE_TIMER_INTERVAL = SIPTransactionStack.BASE_TIMER_INTERVAL;
    /**
     * 5 sec Maximum duration a message will remain in the network
     */
    protected int T4 = 5000 / BASE_TIMER_INTERVAL;

    /**
     * The maximum retransmit interval for non-INVITE requests and INVITE
     * responses
     */
    protected int T2 = 4000 / BASE_TIMER_INTERVAL;
    protected int TIMER_I = T4;

    protected int TIMER_K = T4;

    protected int TIMER_D = 32000 / BASE_TIMER_INTERVAL;

    // protected static final int TIMER_C = 3 * 60 * 1000 / BASE_TIMER_INTERVAL;

    /**
     * One timer tick.
     */
    protected static final int T1 = 1;

    /**
     * INVITE request retransmit interval, for UDP only
     */
    protected static final int TIMER_A = 1;

    /**
     * INVITE transaction timeout timer
     */
    protected static final int TIMER_B = 64;

    protected static final int TIMER_J = 64;

    protected static final int TIMER_F = 64;

    protected static final int TIMER_H = 64;

    // Proposed feature for next release.
    protected transient Object applicationData;

    protected SIPResponse lastResponse;

    // private SIPDialog dialog;

    protected boolean isMapped;

    private Semaphore semaphore;

    protected boolean isSemaphoreAquired;

    // protected boolean eventPending; // indicate that an event is pending
    // here.

    protected String transactionId; // Transaction Id.

    // Audit tag used by the SIP Stack audit
    public long auditTag = 0;

    /**
     * Initialized but no state assigned.
     */
    public static final TransactionState INITIAL_STATE = null;

    /**
     * Trying state.
     */
    public static final TransactionState TRYING_STATE = TransactionState.TRYING;

    /**
     * CALLING State.
     */
    public static final TransactionState CALLING_STATE = TransactionState.CALLING;

    /**
     * Proceeding state.
     */
    public static final TransactionState PROCEEDING_STATE = TransactionState.PROCEEDING;

    /**
     * Completed state.
     */
    public static final TransactionState COMPLETED_STATE = TransactionState.COMPLETED;

    /**
     * Confirmed state.
     */
    public static final TransactionState CONFIRMED_STATE = TransactionState.CONFIRMED;

    /**
     * Terminated state.
     */
    public static final TransactionState TERMINATED_STATE = TransactionState.TERMINATED;

    /**
     * Maximum number of ticks between retransmissions.
     */
    protected static final int MAXIMUM_RETRANSMISSION_TICK_COUNT = 8;

    // Parent stack for this transaction
    protected transient SIPTransactionStack sipStack;

    // Original request that is being handled by this transaction
    protected SIPRequest originalRequest;

    // Underlying channel being used to send messages for this transaction
    private transient MessageChannel encapsulatedChannel;

    // Port of peer
    protected int peerPort;

    // Address of peer
    protected InetAddress peerInetAddress;

    // Address of peer as a string
    protected String peerAddress;

    // Protocol of peer
    protected String peerProtocol;

    // @@@ hagai - NAT changes
    // Source port extracted from peer packet
    protected int peerPacketSourcePort;

    protected InetAddress peerPacketSourceAddress;

    protected AtomicBoolean transactionTimerStarted = new AtomicBoolean(false);

    // Transaction branch ID
    private String branch;

    // Method of the Request used to create the transaction.
    private String method;

    // Sequence number of request used to create the transaction
    private long cSeq;

    // Current transaction state
    private TransactionState currentState;

    // Number of ticks the retransmission timer was set to last
    private transient int retransmissionTimerLastTickCount;

    // Number of ticks before the message is retransmitted
    private transient int retransmissionTimerTicksLeft;

    // Number of ticks before the transaction times out
    protected int timeoutTimerTicksLeft;

    // List of event listeners for this transaction
    private transient Set<SIPTransactionEventListener> eventListeners;

    // Hang on to these - we clear out the request URI after
    // transaction goes to final state. Pointers to these are kept around
    // for transaction matching as long as the transaction is in
    // the transaction table.
    protected From from;

    protected To to;

    protected Event event;

    protected CallID callId;

    // Back ptr to the JAIN layer.
    // private Object wrapper;

    // Counter for caching of connections.
    // Connection lingers for collectionTime
    // after the Transaction goes to terminated state.
    protected int collectionTime;

    protected String toTag;

    protected String fromTag;

    private boolean terminatedEventDelivered;

    public String getBranchId() {
        return this.branch;
    }

    /**
     * The linger timer is used to remove the transaction from the transaction
     * table after it goes into terminated state. This allows connection caching
     * and also takes care of race conditins.
     *
     *
     */
    class LingerTimer extends SIPStackTimerTask {

        public LingerTimer() {
            SIPTransaction sipTransaction = SIPTransaction.this;
            if (sipStack.isLoggingEnabled()) {
                sipStack.getStackLogger().logDebug("LingerTimer : "
                        + sipTransaction.getTransactionId());
            }

        }

        protected void runTask() {
            SIPTransaction transaction = SIPTransaction.this;
            // release the connection associated with this transaction.
            SIPTransactionStack sipStack = transaction.getSIPStack();

            if (sipStack.isLoggingEnabled()) {
                sipStack.getStackLogger().logDebug("LingerTimer: run() : "
                        + getTransactionId());
            }

            if (transaction instanceof SIPClientTransaction) {
                sipStack.removeTransaction(transaction);
                transaction.close();

            } else if (transaction instanceof ServerTransaction) {
                // Remove it from the set
                if (sipStack.isLoggingEnabled())
                    sipStack.getStackLogger().logDebug("removing" + transaction);
                sipStack.removeTransaction(transaction);
                if ((!sipStack.cacheServerConnections)
                        && --transaction.encapsulatedChannel.useCount <= 0) {
                    // Close the encapsulated socket if stack is configured
                    transaction.close(); 
                } else {
                    if (sipStack.isLoggingEnabled()
                            && (!sipStack.cacheServerConnections)
                            && transaction.isReliable()) {
                        int useCount = transaction.encapsulatedChannel.useCount;
                        sipStack.getStackLogger().logDebug("Use Count = " + useCount);
                    }
                }
            }

        }
    }

    /**
     * Transaction constructor.
     *
     * @param newParentStack
     *            Parent stack for this transaction.
     * @param newEncapsulatedChannel
     *            Underlying channel for this transaction.
     */
    protected SIPTransaction(SIPTransactionStack newParentStack,
            MessageChannel newEncapsulatedChannel) {

        sipStack = newParentStack;
        this.semaphore = new Semaphore(1,true);

        encapsulatedChannel = newEncapsulatedChannel;
        // Record this to check if the address has changed before sending
        // message to avoid possible race condition.
        this.peerPort = newEncapsulatedChannel.getPeerPort();
        this.peerAddress = newEncapsulatedChannel.getPeerAddress();
        this.peerInetAddress = newEncapsulatedChannel.getPeerInetAddress();
        // @@@ hagai
        this.peerPacketSourcePort = newEncapsulatedChannel
                .getPeerPacketSourcePort();
        this.peerPacketSourceAddress = newEncapsulatedChannel
                .getPeerPacketSourceAddress();
        this.peerProtocol = newEncapsulatedChannel.getPeerProtocol();
        if (this.isReliable()) {            
                encapsulatedChannel.useCount++;
                if (sipStack.isLoggingEnabled())
                    sipStack.getStackLogger()
                            .logDebug("use count for encapsulated channel"
                                    + this
                                    + " "
                                    + encapsulatedChannel.useCount );
        }

        this.currentState = null;

        disableRetransmissionTimer();
        disableTimeoutTimer();
        eventListeners = Collections.synchronizedSet(new HashSet<SIPTransactionEventListener>());

        // Always add the parent stack as a listener
        // of this transaction
        addEventListener(newParentStack);

    }

    /**
     * Sets the request message that this transaction handles.
     *
     * @param newOriginalRequest
     *            Request being handled.
     */
    public void setOriginalRequest(SIPRequest newOriginalRequest) {

        // Branch value of topmost Via header
        String newBranch;

        if (this.originalRequest != null
                && (!this.originalRequest.getTransactionId().equals(
                        newOriginalRequest.getTransactionId()))) {
            sipStack.removeTransactionHash(this);
        }
        // This will be cleared later.

        this.originalRequest = newOriginalRequest;

        // just cache the control information so the
        // original request can be released later.
        this.method = newOriginalRequest.getMethod();
        this.from = (From) newOriginalRequest.getFrom();
        this.to = (To) newOriginalRequest.getTo();
        // Save these to avoid concurrent modification exceptions!
        this.toTag = this.to.getTag();
        this.fromTag = this.from.getTag();
        this.callId = (CallID) newOriginalRequest.getCallId();
        this.cSeq = newOriginalRequest.getCSeq().getSeqNumber();
        this.event = (Event) newOriginalRequest.getHeader("Event");
        this.transactionId = newOriginalRequest.getTransactionId();

        originalRequest.setTransaction(this);

        // If the message has an explicit branch value set,
        newBranch = ((Via) newOriginalRequest.getViaHeaders().getFirst())
                .getBranch();
        if (newBranch != null) {
            if (sipStack.isLoggingEnabled())
                sipStack.getStackLogger().logDebug("Setting Branch id : " + newBranch);

            // Override the default branch with the one
            // set by the message
            setBranch(newBranch);

        } else {
            if (sipStack.isLoggingEnabled())
                sipStack.getStackLogger().logDebug("Branch id is null - compute TID!"
                        + newOriginalRequest.encode());
            setBranch(newOriginalRequest.getTransactionId());
        }
    }

    /**
     * Gets the request being handled by this transaction.
     *
     * @return -- the original Request associated with this transaction.
     */
    public SIPRequest getOriginalRequest() {
        return originalRequest;
    }

    /**
     * Get the original request but cast to a Request structure.
     *
     * @return the request that generated this transaction.
     */
    public Request getRequest() {
        return (Request) originalRequest;
    }

    /**
     * Returns a flag stating whether this transaction is for an INVITE request
     * or not.
     *
     * @return -- true if this is an INVITE request, false if not.
     */
    public final boolean isInviteTransaction() {
        return getMethod().equals(Request.INVITE);
    }

    /**
     * Return true if the transaction corresponds to a CANCEL message.
     *
     * @return -- true if the transaciton is a CANCEL transaction.
     */
    public final boolean isCancelTransaction() {
        return getMethod().equals(Request.CANCEL);
    }

    /**
     * Return a flag that states if this is a BYE transaction.
     *
     * @return true if the transaciton is a BYE transaction.
     */
    public final boolean isByeTransaction() {
        return getMethod().equals(Request.BYE);
    }

    /**
     * Returns the message channel used for transmitting/receiving messages for
     * this transaction. Made public in support of JAIN dual transaction model.
     *
     * @return Encapsulated MessageChannel.
     *
     */
    public MessageChannel getMessageChannel() {
        return encapsulatedChannel;
    }

    /**
     * Sets the Via header branch parameter used to identify this transaction.
     *
     * @param newBranch
     *            New string used as the branch for this transaction.
     */
    public final void setBranch(String newBranch) {
        branch = newBranch;
    }

    /**
     * Gets the current setting for the branch parameter of this transaction.
     *
     * @return Branch parameter for this transaction.
     */
    public final String getBranch() {
        if (this.branch == null) {
            this.branch = getOriginalRequest().getTopmostVia().getBranch();
        }
        return branch;
    }

    /**
     * Get the method of the request used to create this transaction.
     *
     * @return the method of the request for the transaction.
     */
    public final String getMethod() {
        return this.method;
    }

    /**
     * Get the Sequence number of the request used to create the transaction.
     *
     * @return the cseq of the request used to create the transaction.
     */
    public final long getCSeq() {
        return this.cSeq;
    }

    /**
     * Changes the state of this transaction.
     *
     * @param newState
     *            New state of this transaction.
     */
    public void setState(TransactionState newState) {
        // PATCH submitted by sribeyron
        if (currentState == TransactionState.COMPLETED) {
            if (newState != TransactionState.TERMINATED
                    && newState != TransactionState.CONFIRMED)
                newState = TransactionState.COMPLETED;
        }
        if (currentState == TransactionState.CONFIRMED) {
            if (newState != TransactionState.TERMINATED)
                newState = TransactionState.CONFIRMED;
        }
        if (currentState != TransactionState.TERMINATED)
            currentState = newState;
        else
            newState = currentState;
        // END OF PATCH
        if (sipStack.isLoggingEnabled()) {
            sipStack.getStackLogger().logDebug("Transaction:setState " + newState
                    + " " + this + " branchID = " + this.getBranch()
                    + " isClient = " + (this instanceof SIPClientTransaction));
            sipStack.getStackLogger().logStackTrace();
        }
    }

    /**
     * Gets the current state of this transaction.
     *
     * @return Current state of this transaction.
     */
    public TransactionState getState() {
        return this.currentState;
    }

    /**
     * Enables retransmission timer events for this transaction to begin in one
     * tick.
     */
    protected final void enableRetransmissionTimer() {
        enableRetransmissionTimer(1);
    }

    /**
     * Enables retransmission timer events for this transaction to begin after
     * the number of ticks passed to this routine.
     *
     * @param tickCount
     *            Number of ticks before the next retransmission timer event
     *            occurs.
     */
    protected final void enableRetransmissionTimer(int tickCount) {
        // For INVITE Client transactions, double interval each time
        if (isInviteTransaction() && (this instanceof SIPClientTransaction)) {
            retransmissionTimerTicksLeft = tickCount;
        } else {
            // non-INVITE transactions and 3xx-6xx responses are capped at T2
            retransmissionTimerTicksLeft = Math.min(tickCount,
                    MAXIMUM_RETRANSMISSION_TICK_COUNT);
        }
        retransmissionTimerLastTickCount = retransmissionTimerTicksLeft;
    }

    /**
     * Turns off retransmission events for this transaction.
     */
    protected final void disableRetransmissionTimer() {
        retransmissionTimerTicksLeft = -1;
    }

    /**
     * Enables a timeout event to occur for this transaction after the number of
     * ticks passed to this method.
     *
     * @param tickCount
     *            Number of ticks before this transaction times out.
     */
    protected final void enableTimeoutTimer(int tickCount) {
        if (sipStack.isLoggingEnabled())
            sipStack.getStackLogger().logDebug("enableTimeoutTimer " + this
                    + " tickCount " + tickCount + " currentTickCount = "
                    + timeoutTimerTicksLeft);

        timeoutTimerTicksLeft = tickCount;
    }

    /**
     * Disabled the timeout timer.
     */
    protected final void disableTimeoutTimer() {
        timeoutTimerTicksLeft = -1;
    }

    /**
     * Fired after each timer tick. Checks the retransmission and timeout timers
     * of this transaction, and fired these events if necessary.
     */
    final void fireTimer() {
        // If the timeout timer is enabled,

        if (timeoutTimerTicksLeft != -1) {
            // Count down the timer, and if it has run out,
            if (--timeoutTimerTicksLeft == 0) {
                // Fire the timeout timer
                fireTimeoutTimer();
            }
        }

        // If the retransmission timer is enabled,
        if (retransmissionTimerTicksLeft != -1) {
            // Count down the timer, and if it has run out,
            if (--retransmissionTimerTicksLeft == 0) {
                // Enable this timer to fire again after
                // twice the original time
                enableRetransmissionTimer(retransmissionTimerLastTickCount * 2);
                // Fire the timeout timer
                fireRetransmissionTimer();
            }
        } 
    }

    /**
     * Tests if this transaction has terminated.
     *
     * @return Trus if this transaction is terminated, false if not.
     */
    public final boolean isTerminated() {
        return getState() == TERMINATED_STATE;
    }

    public String getHost() {
        return encapsulatedChannel.getHost();
    }

    public String getKey() {
        return encapsulatedChannel.getKey();
    }

    public int getPort() {
        return encapsulatedChannel.getPort();
    }

    public SIPTransactionStack getSIPStack() {
        return (SIPTransactionStack) sipStack;
    }

    public String getPeerAddress() {
        return this.peerAddress;
    }

    public int getPeerPort() {
        return this.peerPort;
    }

    // @@@ hagai
    public int getPeerPacketSourcePort() {
        return this.peerPacketSourcePort;
    }

    public InetAddress getPeerPacketSourceAddress() {
        return this.peerPacketSourceAddress;
    }

    protected InetAddress getPeerInetAddress() {
        return this.peerInetAddress;
    }

    protected String getPeerProtocol() {
        return this.peerProtocol;
    }

    public String getTransport() {
        return encapsulatedChannel.getTransport();
    }

    public boolean isReliable() {
        return encapsulatedChannel.isReliable();
    }

    /**
     * Returns the Via header for this channel. Gets the Via header of the
     * underlying message channel, and adds a branch parameter to it for this
     * transaction.
     */
    public Via getViaHeader() {
        // Via header of the encapulated channel
        Via channelViaHeader;

        // Add the branch parameter to the underlying
        // channel's Via header
        channelViaHeader = super.getViaHeader();
        try {
            channelViaHeader.setBranch(branch);
        } catch (java.text.ParseException ex) {
        }
        return channelViaHeader;

    }

    /**
     * Process the message through the transaction and sends it to the SIP peer.
     *
     * @param messageToSend
     *            Message to send to the SIP peer.
     */
    public void sendMessage(SIPMessage messageToSend) throws IOException {
        // Use the peer address, port and transport
        // that was specified when the transaction was
        // created. Bug was noted by Bruce Evangelder
        // soleo communications.
        try {
            encapsulatedChannel.sendMessage(messageToSend,
                    this.peerInetAddress, this.peerPort);
        } finally {
            this.startTransactionTimer();
        }
    }

    /**
     * Parse the byte array as a message, process it through the transaction,
     * and send it to the SIP peer. This is just a placeholder method -- calling
     * it will result in an IO exception.
     *
     * @param messageBytes
     *            Bytes of the message to send.
     * @param receiverAddress
     *            Address of the target peer.
     * @param receiverPort
     *            Network port of the target peer.
     *
     * @throws IOException
     *             If called.
     */
    protected void sendMessage(byte[] messageBytes,
            InetAddress receiverAddress, int receiverPort, boolean retry)
            throws IOException {
        throw new IOException(
                "Cannot send unparsed message through Transaction Channel!");
    }

    /**
     * Adds a new event listener to this transaction.
     *
     * @param newListener
     *            Listener to add.
     */
    public void addEventListener(SIPTransactionEventListener newListener) {
        eventListeners.add(newListener);
    }

    /**
     * Removed an event listener from this transaction.
     *
     * @param oldListener
     *            Listener to remove.
     */
    public void removeEventListener(SIPTransactionEventListener oldListener) {
        eventListeners.remove(oldListener);
    }

    /**
     * Creates a SIPTransactionErrorEvent and sends it to all of the listeners
     * of this transaction. This method also flags the transaction as
     * terminated.
     *
     * @param errorEventID
     *            ID of the error to raise.
     */
    protected void raiseErrorEvent(int errorEventID) {

        // Error event to send to all listeners
        SIPTransactionErrorEvent newErrorEvent;
        // Iterator through the list of listeners
        Iterator<SIPTransactionEventListener> listenerIterator;
        // Next listener in the list
        SIPTransactionEventListener nextListener;

        // Create the error event
        newErrorEvent = new SIPTransactionErrorEvent(this, errorEventID);

        // Loop through all listeners of this transaction
        synchronized (eventListeners) {
            listenerIterator = eventListeners.iterator();
            while (listenerIterator.hasNext()) {
                // Send the event to the next listener
                nextListener = (SIPTransactionEventListener) listenerIterator
                        .next();
                nextListener.transactionErrorEvent(newErrorEvent);
            }
        }
        // Clear the event listeners after propagating the error.
        // Retransmit notifications are just an alert to the
        // application (they are not an error).
        if (errorEventID != SIPTransactionErrorEvent.TIMEOUT_RETRANSMIT) {
            eventListeners.clear();

            // Errors always terminate a transaction
            this.setState(TransactionState.TERMINATED);

            if (this instanceof SIPServerTransaction && this.isByeTransaction()
                    && this.getDialog() != null)
                ((SIPDialog) this.getDialog())
                        .setState(SIPDialog.TERMINATED_STATE);
        }
    }

    /**
     * A shortcut way of telling if we are a server transaction.
     */
    protected boolean isServerTransaction() {
        return this instanceof SIPServerTransaction;
    }

    /**
     * Gets the dialog object of this Transaction object. This object returns
     * null if no dialog exists. A dialog only exists for a transaction when a
     * session is setup between a User Agent Client and a User Agent Server,
     * either by a 1xx Provisional Response for an early dialog or a 200OK
     * Response for a committed dialog.
     *
     * @return the Dialog Object of this Transaction object.
     * @see Dialog
     */
    public abstract Dialog getDialog();

    /**
     * set the dialog object.
     *
     * @param sipDialog --
     *            the dialog to set.
     * @param dialogId --
     *            the dialog id ot associate with the dialog.s
     */
    public abstract void setDialog(SIPDialog sipDialog, String dialogId);

    /**
     * Returns the current value of the retransmit timer in milliseconds used to
     * retransmit messages over unreliable transports.
     *
     * @return the integer value of the retransmit timer in milliseconds.
     */
    public int getRetransmitTimer() {
        return SIPTransactionStack.BASE_TIMER_INTERVAL;
    }

    /**
     * Get the host to assign for an outgoing Request via header.
     */
    public String getViaHost() {
        return this.getViaHeader().getHost();

    }

    /**
     * Get the last response. This is used internally by the implementation.
     * Dont rely on it.
     *
     * @return the last response received (for client transactions) or sent (for
     *         server transactions).
     */
    public SIPResponse getLastResponse() {
        return this.lastResponse;
    }

    /**
     * Get the JAIN interface response
     */
    public Response getResponse() {
        return (Response) this.lastResponse;
    }

    /**
     * Get the transaction Id.
     */
    public String getTransactionId() {
        return this.transactionId;
    }

    /**
     * Hashcode method for fast hashtable lookup.
     */
    public int hashCode() {
        if (this.transactionId == null)
            return -1;
        else
            return this.transactionId.hashCode();
    }

    /**
     * Get the port to assign for the via header of an outgoing message.
     */
    public int getViaPort() {
        return this.getViaHeader().getPort();
    }

    /**
     * A method that can be used to test if an incoming request belongs to this
     * transction. This does not take the transaction state into account when
     * doing the check otherwise it is identical to isMessagePartOfTransaction.
     * This is useful for checking if a CANCEL belongs to this transaction.
     *
     * @param requestToTest
     *            is the request to test.
     * @return true if the the request belongs to the transaction.
     *
     */
    public boolean doesCancelMatchTransaction(SIPRequest requestToTest) {

        // List of Via headers in the message to test
        ViaList viaHeaders;
        // Topmost Via header in the list
        Via topViaHeader;
        // Branch code in the topmost Via header
        String messageBranch;
        // Flags whether the select message is part of this transaction
        boolean transactionMatches;

        transactionMatches = false;

        if (this.getOriginalRequest() == null
                || this.getOriginalRequest().getMethod().equals(Request.CANCEL))
            return false;
        // Get the topmost Via header and its branch parameter
        viaHeaders = requestToTest.getViaHeaders();
        if (viaHeaders != null) {

            topViaHeader = (Via) viaHeaders.getFirst();
            messageBranch = topViaHeader.getBranch();
            if (messageBranch != null) {

                // If the branch parameter exists but
                // does not start with the magic cookie,
                if (!messageBranch.toLowerCase().startsWith(SIPConstants.BRANCH_MAGIC_COOKIE_LOWER_CASE)) {

                    // Flags this as old
                    // (RFC2543-compatible) client
                    // version
                    messageBranch = null;

                }

            }

            // If a new branch parameter exists,
            if (messageBranch != null && this.getBranch() != null) {

                // If the branch equals the branch in
                // this message,
                if (getBranch().equalsIgnoreCase(messageBranch)
                        && topViaHeader.getSentBy().equals(
                                ((Via) getOriginalRequest().getViaHeaders()
                                        .getFirst()).getSentBy())) {
                    transactionMatches = true;
                    if (sipStack.isLoggingEnabled())
                        sipStack.getStackLogger().logDebug("returning  true");
                }

            } else {
                // If this is an RFC2543-compliant message,
                // If RequestURI, To tag, From tag,
                // CallID, CSeq number, and top Via
                // headers are the same,
                if (sipStack.isLoggingEnabled())
                    sipStack.getStackLogger().logDebug("testing against "
                            + getOriginalRequest());

                if (getOriginalRequest().getRequestURI().equals(
                        requestToTest.getRequestURI())
                        && getOriginalRequest().getTo().equals(
                                requestToTest.getTo())
                        && getOriginalRequest().getFrom().equals(
                                requestToTest.getFrom())
                        && getOriginalRequest().getCallId().getCallId().equals(
                                requestToTest.getCallId().getCallId())
                        && getOriginalRequest().getCSeq().getSeqNumber() == requestToTest
                                .getCSeq().getSeqNumber()
                        && topViaHeader.equals(getOriginalRequest()
                                .getViaHeaders().getFirst())) {

                    transactionMatches = true;
                }

            }

        }

        // JvB: Need to pass the CANCEL to the listener! Retransmitted INVITEs
        // set it to false
        if (transactionMatches) {
            this.setPassToListener();
        }
        return transactionMatches;
    }

    /**
     * Sets the value of the retransmit timer to the newly supplied timer value.
     * The retransmit timer is expressed in milliseconds and its default value
     * is 500ms. This method allows the application to change the transaction
     * retransmit behavior for different networks. Take the gateway proxy as an
     * example. The internal intranet is likely to be reatively uncongested and
     * the endpoints will be relatively close. The external network is the
     * general Internet. This functionality allows different retransmit times
     * for either side.
     *
     * @param retransmitTimer -
     *            the new integer value of the retransmit timer in milliseconds.
     */
    public void setRetransmitTimer(int retransmitTimer) {

        if (retransmitTimer <= 0)
            throw new IllegalArgumentException(
                    "Retransmit timer must be positive!");
        if (this.transactionTimerStarted.get())
            throw new IllegalStateException(
                    "Transaction timer is already started");
        BASE_TIMER_INTERVAL = retransmitTimer;
        T4 = 5000 / BASE_TIMER_INTERVAL;

        T2 = 4000 / BASE_TIMER_INTERVAL;
        TIMER_I = T4;

        TIMER_K = T4;

        TIMER_D = 32000 / BASE_TIMER_INTERVAL;

    }

    /**
     * Close the encapsulated channel.
     */
    public void close() {
        this.encapsulatedChannel.close();
        if (sipStack.isLoggingEnabled())
            sipStack.getStackLogger().logDebug("Closing " + this.encapsulatedChannel);

    }

    public boolean isSecure() {
        return encapsulatedChannel.isSecure();
    }

    public MessageProcessor getMessageProcessor() {
        return this.encapsulatedChannel.getMessageProcessor();
    }

    /**
     * Set the application data pointer. This is un-interpreted by the stack.
     * This is provided as a conveniant way of keeping book-keeping data for
     * applications. Note that null clears the application data pointer
     * (releases it).
     *
     * @param applicationData --
     *            application data pointer to set. null clears the applicationd
     *            data pointer.
     *
     */

    public void setApplicationData(Object applicationData) {
        this.applicationData = applicationData;
    }

    /**
     * Get the application data associated with this transaction.
     *
     * @return stored application data.
     */
    public Object getApplicationData() {
        return this.applicationData;
    }

    /**
     * Set the encapsuated channel. The peer inet address and port are set equal
     * to the message channel.
     */
    public void setEncapsulatedChannel(MessageChannel messageChannel) {
        this.encapsulatedChannel = messageChannel;
        this.peerInetAddress = messageChannel.getPeerInetAddress();
        this.peerPort = messageChannel.getPeerPort();
    }

    /**
     * Return the SipProvider for which the transaction is assigned.
     *
     * @return the SipProvider for the transaction.
     */
    public SipProviderImpl getSipProvider() {

        return this.getMessageProcessor().getListeningPoint().getProvider();
    }

    /**
     * Raise an IO Exception event - this is used for reporting asynchronous IO
     * Exceptions that are attributable to this transaction.
     *
     */
    public void raiseIOExceptionEvent() {
        setState(TransactionState.TERMINATED);
        String host = getPeerAddress();
        int port = getPeerPort();
        String transport = getTransport();
        IOExceptionEvent exceptionEvent = new IOExceptionEvent(this, host,
                port, transport);
        getSipProvider().handleEvent(exceptionEvent, this);
    }

    /**
     * A given tx can process only a single outstanding event at a time. This
     * semaphore gaurds re-entrancy to the transaction.
     *
     */
    public boolean acquireSem() {
        boolean retval = false;
        try {
            if (sipStack.getStackLogger().isLoggingEnabled()) {
                sipStack.getStackLogger().logDebug("acquireSem [[[[" + this);
                sipStack.getStackLogger().logStackTrace();
            }
            retval = this.semaphore.tryAcquire(1000, TimeUnit.MILLISECONDS);
            if ( sipStack.isLoggingEnabled())
                sipStack.getStackLogger().logDebug(
                    "acquireSem() returning : " + retval);
            return retval;
        } catch (Exception ex) {
            sipStack.getStackLogger().logError("Unexpected exception acquiring sem",
                    ex);
            InternalErrorHandler.handleException(ex);
            return false;
        } finally {
            this.isSemaphoreAquired = retval;
        }

    }

    /**
     * Release the transaction semaphore.
     *
     */
    public void releaseSem() {
        try {

            this.toListener = false;
            this.semRelease();

        } catch (Exception ex) {
            sipStack.getStackLogger().logError("Unexpected exception releasing sem",
                    ex);

        }

    }

    protected void semRelease() {
        try {
            if (sipStack.isLoggingEnabled()) {
                sipStack.getStackLogger().logDebug("semRelease ]]]]" + this);
                sipStack.getStackLogger().logStackTrace();
            }
            this.isSemaphoreAquired = false;
            this.semaphore.release();

        } catch (Exception ex) {
            sipStack.getStackLogger().logError("Unexpected exception releasing sem",
                    ex);

        }
    }

    /**
     * Set true to pass the request up to the listener. False otherwise.
     *
     */

    public boolean passToListener() {
        return toListener;
    }

    /**
     * Set the passToListener flag to true.
     */
    public void setPassToListener() {
        if (sipStack.isLoggingEnabled()) {
            sipStack.getStackLogger().logDebug("setPassToListener()");
        }
        this.toListener = true;

    }

    /**
     * Flag to test if the terminated event is delivered.
     *
     * @return
     */
    protected synchronized boolean testAndSetTransactionTerminatedEvent() {
        boolean retval = !this.terminatedEventDelivered;
        this.terminatedEventDelivered = true;
        return retval;
    }
    
    public String getCipherSuite() throws UnsupportedOperationException {
        if (this.getMessageChannel() instanceof TLSMessageChannel ) {
            if (  ((TLSMessageChannel) this.getMessageChannel()).getHandshakeCompletedListener() == null ) 
                return null;
            else if ( ((TLSMessageChannel) this.getMessageChannel()).getHandshakeCompletedListener().getHandshakeCompletedEvent() == null)
                return null;
            else return ((TLSMessageChannel) this.getMessageChannel()).getHandshakeCompletedListener().getHandshakeCompletedEvent().getCipherSuite();
        } else throw new UnsupportedOperationException("Not a TLS channel");

    }

    
    public java.security.cert.Certificate[] getLocalCertificates() throws UnsupportedOperationException {
         if (this.getMessageChannel() instanceof TLSMessageChannel ) {
            if (  ((TLSMessageChannel) this.getMessageChannel()).getHandshakeCompletedListener() == null ) 
                return null;
            else if ( ((TLSMessageChannel) this.getMessageChannel()).getHandshakeCompletedListener().getHandshakeCompletedEvent() == null)
                return null;
            else return ((TLSMessageChannel) this.getMessageChannel()).getHandshakeCompletedListener().getHandshakeCompletedEvent().getLocalCertificates();
        } else throw new UnsupportedOperationException("Not a TLS channel");
    }

    
    public java.security.cert.Certificate[] getPeerCertificates() throws SSLPeerUnverifiedException {
        if (this.getMessageChannel() instanceof TLSMessageChannel ) {
            if (  ((TLSMessageChannel) this.getMessageChannel()).getHandshakeCompletedListener() == null ) 
                return null;
            else if ( ((TLSMessageChannel) this.getMessageChannel()).getHandshakeCompletedListener().getHandshakeCompletedEvent() == null)
                return null;
            else return ((TLSMessageChannel) this.getMessageChannel()).getHandshakeCompletedListener().getHandshakeCompletedEvent().getPeerCertificates();
        } else throw new UnsupportedOperationException("Not a TLS channel");

    }


    /**
     * Start the timer that runs the transaction state machine.
     *
     */

    protected abstract void startTransactionTimer();

    /**
     * Tests a message to see if it is part of this transaction.
     *
     * @return True if the message is part of this transaction, false if not.
     */
    public abstract boolean isMessagePartOfTransaction(SIPMessage messageToTest);

    /**
     * This method is called when this transaction's retransmission timer has
     * fired.
     */
    protected abstract void fireRetransmissionTimer();

    /**
     * This method is called when this transaction's timeout timer has fired.
     */
    protected abstract void fireTimeoutTimer();    

}
