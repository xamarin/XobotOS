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
import gov.nist.core.NameValueList;
import gov.nist.javax.sip.SIPConstants;
import gov.nist.javax.sip.Utils;
import gov.nist.javax.sip.address.AddressImpl;
import gov.nist.javax.sip.header.Contact;
import gov.nist.javax.sip.header.RecordRoute;
import gov.nist.javax.sip.header.RecordRouteList;
import gov.nist.javax.sip.header.Route;
import gov.nist.javax.sip.header.RouteList;
import gov.nist.javax.sip.header.TimeStamp;
import gov.nist.javax.sip.header.To;
import gov.nist.javax.sip.header.Via;
import gov.nist.javax.sip.header.ViaList;
import gov.nist.javax.sip.message.SIPMessage;
import gov.nist.javax.sip.message.SIPRequest;
import gov.nist.javax.sip.message.SIPResponse;

import java.io.IOException;
import java.security.cert.X509Certificate;
import java.text.ParseException;
import java.util.ListIterator;
import java.util.TimerTask;
import java.util.concurrent.ConcurrentHashMap;

import javax.net.ssl.SSLPeerUnverifiedException;
import javax.sip.Dialog;
import javax.sip.DialogState;
import javax.sip.InvalidArgumentException;
import javax.sip.ObjectInUseException;
import javax.sip.SipException;
import javax.sip.Timeout;
import javax.sip.TimeoutEvent;
import javax.sip.TransactionState;
import javax.sip.address.Hop;
import javax.sip.address.SipURI;
import javax.sip.header.ExpiresHeader;
import javax.sip.header.RouteHeader;
import javax.sip.header.TimeStampHeader;
import javax.sip.message.Request;

/*
 * Jeff Keyser -- initial. Daniel J. Martinez Manzano --Added support for TLS message channel.
 * Emil Ivov -- bug fixes. Chris Beardshear -- bug fix. Andreas Bystrom -- bug fixes. Matt Keller
 * (Motorolla) -- bug fix.
 */

/**
 * Represents a client transaction. Implements the following state machines. (From RFC 3261)
 * 
 * <pre>
 *                   
 *                    
 *                     
 *                      
 *                      
 *                      
 *                                                     |INVITE from TU
 *                                   Timer A fires     |INVITE sent
 *                                   Reset A,          V                      Timer B fires
 *                                   INVITE sent +-----------+                or Transport Err.
 *                                     +---------|           |---------------+inform TU
 *                                     |         |  Calling  |               |
 *                                     +--------&gt;|           |--------------&gt;|
 *                                               +-----------+ 2xx           |
 *                                                  |  |       2xx to TU     |
 *                                                  |  |1xx                  |
 *                          300-699 +---------------+  |1xx to TU            |
 *                         ACK sent |                  |                     |
 *                      resp. to TU |  1xx             V                     |
 *                                  |  1xx to TU  -----------+               |
 *                                  |  +---------|           |               |
 *                                  |  |         |Proceeding |--------------&gt;|
 *                                  |  +--------&gt;|           | 2xx           |
 *                                  |            +-----------+ 2xx to TU     |
 *                                  |       300-699    |                     |
 *                                  |       ACK sent,  |                     |
 *                                  |       resp. to TU|                     |
 *                                  |                  |                     |      NOTE:
 *                                  |  300-699         V                     |
 *                                  |  ACK sent  +-----------+Transport Err. |  transitions
 *                                  |  +---------|           |Inform TU      |  labeled with
 *                                  |  |         | Completed |--------------&gt;|  the event
 *                                  |  +--------&gt;|           |               |  over the action
 *                                  |            +-----------+               |  to take
 *                                  |              &circ;   |                     |
 *                                  |              |   | Timer D fires       |
 *                                  +--------------+   | -                   |
 *                                                     |                     |
 *                                                     V                     |
 *                                               +-----------+               |
 *                                               |           |               |
 *                                               | Terminated|&lt;--------------+
 *                                               |           |
 *                                               +-----------+
 *                      
 *                                       Figure 5: INVITE client transaction
 *                      
 *                      
 *                                                         |Request from TU
 *                                                         |send request
 *                                     Timer E             V
 *                                     send request  +-----------+
 *                                         +---------|           |-------------------+
 *                                         |         |  Trying   |  Timer F          |
 *                                         +--------&gt;|           |  or Transport Err.|
 *                                                   +-----------+  inform TU        |
 *                                      200-699         |  |                         |
 *                                      resp. to TU     |  |1xx                      |
 *                                      +---------------+  |resp. to TU              |
 *                                      |                  |                         |
 *                                      |   Timer E        V       Timer F           |
 *                                      |   send req +-----------+ or Transport Err. |
 *                                      |  +---------|           | inform TU         |
 *                                      |  |         |Proceeding |------------------&gt;|
 *                                      |  +--------&gt;|           |-----+             |
 *                                      |            +-----------+     |1xx          |
 *                                      |              |      &circ;        |resp to TU   |
 *                                      | 200-699      |      +--------+             |
 *                                      | resp. to TU  |                             |
 *                                      |              |                             |
 *                                      |              V                             |
 *                                      |            +-----------+                   |
 *                                      |            |           |                   |
 *                                      |            | Completed |                   |
 *                                      |            |           |                   |
 *                                      |            +-----------+                   |
 *                                      |              &circ;   |                         |
 *                                      |              |   | Timer K                 |
 *                                      +--------------+   | -                       |
 *                                                         |                         |
 *                                                         V                         |
 *                                   NOTE:           +-----------+                   |
 *                                                   |           |                   |
 *                               transitions         | Terminated|&lt;------------------+
 *                               labeled with        |           |
 *                               the event           +-----------+
 *                               over the action
 *                               to take
 *                      
 *                                       Figure 6: non-INVITE client transaction
 *                      
 *                      
 *                      
 *                      
 *                     
 *                    
 * </pre>
 * 
 * 
 * @author M. Ranganathan
 * 
 * @version 1.2 $Revision: 1.122 $ $Date: 2009/12/17 23:33:52 $
 */
public class SIPClientTransaction extends SIPTransaction implements ServerResponseInterface,
        javax.sip.ClientTransaction, gov.nist.javax.sip.ClientTransactionExt {

    // a SIP Client transaction may belong simultaneously to multiple
    // dialogs in the early state. These dialogs all have
    // the same call ID and same From tag but different to tags.

    private ConcurrentHashMap<String,SIPDialog> sipDialogs;

    private SIPRequest lastRequest;

    private int viaPort;

    private String viaHost;

    // Real ResponseInterface to pass messages to
    private transient ServerResponseInterface respondTo;

    private SIPDialog defaultDialog;

    private Hop nextHop;

    private boolean notifyOnRetransmit;

    private boolean timeoutIfStillInCallingState;

    private int callingStateTimeoutCount;

    public class TransactionTimer extends SIPStackTimerTask {

        public TransactionTimer() {

        }

        protected void runTask() {
            SIPClientTransaction clientTransaction;
            SIPTransactionStack sipStack;
            clientTransaction = SIPClientTransaction.this;
            sipStack = clientTransaction.sipStack;

            // If the transaction has terminated,
            if (clientTransaction.isTerminated()) {

                if (sipStack.isLoggingEnabled()) {
                    sipStack.getStackLogger().logDebug(
                            "removing  = " + clientTransaction + " isReliable "
                                    + clientTransaction.isReliable());
                }

                sipStack.removeTransaction(clientTransaction);

                try {
                    this.cancel();

                } catch (IllegalStateException ex) {
                    if (!sipStack.isAlive())
                        return;
                }

                // Client transaction terminated. Kill connection if
                // this is a TCP after the linger timer has expired.
                // The linger timer is needed to allow any pending requests to
                // return responses.
                if ((!sipStack.cacheClientConnections) && clientTransaction.isReliable()) {

                    int newUseCount = --clientTransaction.getMessageChannel().useCount;
                    if (newUseCount <= 0) {
                        // Let the connection linger for a while and then close
                        // it.
                        TimerTask myTimer = new LingerTimer();
                        sipStack.getTimer().schedule(myTimer,
                                SIPTransactionStack.CONNECTION_LINGER_TIME * 1000);
                    }

                } else {
                    // Cache the client connections so dont close the
                    // connection. This keeps the connection open permanently
                    // until the client disconnects.
                    if (sipStack.isLoggingEnabled() && clientTransaction.isReliable()) {
                       	int useCount = clientTransaction.getMessageChannel().useCount;
                       	if (sipStack.isLoggingEnabled())
                       		sipStack.getStackLogger().logDebug("Client Use Count = " + useCount);
                    }
                }

            } else {
                // If this transaction has not
                // terminated,
                // Fire the transaction timer.
                clientTransaction.fireTimer();

            }

        }

    }

    /**
     * Creates a new client transaction.
     * 
     * @param newSIPStack Transaction stack this transaction belongs to.
     * @param newChannelToUse Channel to encapsulate.
     * @return the created client transaction.
     */
    protected SIPClientTransaction(SIPTransactionStack newSIPStack, MessageChannel newChannelToUse) {
        super(newSIPStack, newChannelToUse);
        // Create a random branch parameter for this transaction
        // setBranch( SIPConstants.BRANCH_MAGIC_COOKIE +
        // Integer.toHexString( hashCode( ) ) );
        setBranch(Utils.getInstance().generateBranchId());
        this.messageProcessor = newChannelToUse.messageProcessor;
        this.setEncapsulatedChannel(newChannelToUse);
        this.notifyOnRetransmit = false;
        this.timeoutIfStillInCallingState = false;

        // This semaphore guards the listener from being
        // re-entered for this transaction. That is
        // for a give tx, the listener is called at most
        // once with an outstanding request.

        if (sipStack.isLoggingEnabled()) {
            sipStack.getStackLogger().logDebug("Creating clientTransaction " + this);
            sipStack.getStackLogger().logStackTrace();
        }
        // this.startTransactionTimer();
        this.sipDialogs = new ConcurrentHashMap();
    }

    /**
     * Sets the real ResponseInterface this transaction encapsulates.
     * 
     * @param newRespondTo ResponseInterface to send messages to.
     */
    public void setResponseInterface(ServerResponseInterface newRespondTo) {
        if (sipStack.isLoggingEnabled()) {
            sipStack.getStackLogger().logDebug(
                    "Setting response interface for " + this + " to " + newRespondTo);
            if (newRespondTo == null) {
                sipStack.getStackLogger().logStackTrace();
                sipStack.getStackLogger().logDebug("WARNING -- setting to null!");
            }
        }

        respondTo = newRespondTo;

    }

    /**
     * Returns this transaction.
     */
    public MessageChannel getRequestChannel() {

        return this;

    }

    /**
     * Deterines if the message is a part of this transaction.
     * 
     * @param messageToTest Message to check if it is part of this transaction.
     * 
     * @return true if the message is part of this transaction, false if not.
     */
    public boolean isMessagePartOfTransaction(SIPMessage messageToTest) {

        // List of Via headers in the message to test
        ViaList viaHeaders = messageToTest.getViaHeaders();
        // Flags whether the select message is part of this transaction
        boolean transactionMatches;
        String messageBranch = ((Via) viaHeaders.getFirst()).getBranch();
        boolean rfc3261Compliant = getBranch() != null
                && messageBranch != null
                && getBranch().toLowerCase().startsWith(
                        SIPConstants.BRANCH_MAGIC_COOKIE_LOWER_CASE)
                && messageBranch.toLowerCase().startsWith(
                        SIPConstants.BRANCH_MAGIC_COOKIE_LOWER_CASE);

        transactionMatches = false;
        if (TransactionState.COMPLETED == this.getState()) {
            if (rfc3261Compliant) {
                transactionMatches = getBranch().equalsIgnoreCase(
                        ((Via) viaHeaders.getFirst()).getBranch())
                        && getMethod().equals(messageToTest.getCSeq().getMethod());
            } else {
                transactionMatches = getBranch().equals(messageToTest.getTransactionId());
            }
        } else if (!isTerminated()) {
            if (rfc3261Compliant) {
                if (viaHeaders != null) {
                    // If the branch parameter is the
                    // same as this transaction and the method is the same,
                    if (getBranch().equalsIgnoreCase(((Via) viaHeaders.getFirst()).getBranch())) {
                        transactionMatches = getOriginalRequest().getCSeq().getMethod().equals(
                                messageToTest.getCSeq().getMethod());

                    }
                }
            } else {
                // not RFC 3261 compliant.
                if (getBranch() != null) {
                    transactionMatches = getBranch().equalsIgnoreCase(
                            messageToTest.getTransactionId());
                } else {
                    transactionMatches = getOriginalRequest().getTransactionId()
                            .equalsIgnoreCase(messageToTest.getTransactionId());
                }

            }

        }
        return transactionMatches;

    }

    /**
     * Send a request message through this transaction and onto the client.
     * 
     * @param messageToSend Request to process and send.
     */
    public void sendMessage(SIPMessage messageToSend) throws IOException {

        try {
            // Message typecast as a request
            SIPRequest transactionRequest;

            transactionRequest = (SIPRequest) messageToSend;

            // Set the branch id for the top via header.
            Via topVia = (Via) transactionRequest.getViaHeaders().getFirst();
            // Tack on a branch identifier to match responses.
            try {
                topVia.setBranch(getBranch());
            } catch (java.text.ParseException ex) {
            }

            if (sipStack.isLoggingEnabled()) {
                sipStack.getStackLogger().logDebug("Sending Message " + messageToSend);
                sipStack.getStackLogger().logDebug("TransactionState " + this.getState());
            }
            // If this is the first request for this transaction,
            if (TransactionState.PROCEEDING == getState()
                    || TransactionState.CALLING == getState()) {

                // If this is a TU-generated ACK request,
                if (transactionRequest.getMethod().equals(Request.ACK)) {

                    // Send directly to the underlying
                    // transport and close this transaction
                    if (isReliable()) {
                        this.setState(TransactionState.TERMINATED);
                    } else {
                        this.setState(TransactionState.COMPLETED);
                    }
                    // BUGBUG -- This suppresses sending the ACK uncomment this
                    // to
                    // test 4xx retransmission
                    // if (transactionRequest.getMethod() != Request.ACK)
                    super.sendMessage(transactionRequest);
                    return;

                }

            }
            try {

                // Send the message to the server
                lastRequest = transactionRequest;
                if (getState() == null) {
                    // Save this request as the one this transaction
                    // is handling
                    setOriginalRequest(transactionRequest);
                    // Change to trying/calling state
                    // Set state first to avoid race condition..

                    if (transactionRequest.getMethod().equals(Request.INVITE)) {
                        this.setState(TransactionState.CALLING);
                    } else if (transactionRequest.getMethod().equals(Request.ACK)) {
                        // Acks are never retransmitted.
                        this.setState(TransactionState.TERMINATED);
                    } else {
                        this.setState(TransactionState.TRYING);
                    }
                    if (!isReliable()) {
                        enableRetransmissionTimer();
                    }
                    if (isInviteTransaction()) {
                        enableTimeoutTimer(TIMER_B);
                    } else {
                        enableTimeoutTimer(TIMER_F);
                    }
                }
                // BUGBUG This supresses sending ACKS -- uncomment to test
                // 4xx retransmission.
                // if (transactionRequest.getMethod() != Request.ACK)
                super.sendMessage(transactionRequest);

            } catch (IOException e) {

                this.setState(TransactionState.TERMINATED);
                throw e;

            }
        } finally {
            this.isMapped = true;
            this.startTransactionTimer();

        }

    }

    /**
     * Process a new response message through this transaction. If necessary, this message will
     * also be passed onto the TU.
     * 
     * @param transactionResponse Response to process.
     * @param sourceChannel Channel that received this message.
     */
    public synchronized void processResponse(SIPResponse transactionResponse,
            MessageChannel sourceChannel, SIPDialog dialog) {

        // If the state has not yet been assigned then this is a
        // spurious response.

        if (getState() == null)
            return;

        // Ignore 1xx
        if ((TransactionState.COMPLETED == this.getState() || TransactionState.TERMINATED == this
                .getState())
                && transactionResponse.getStatusCode() / 100 == 1) {
            return;
        }

        if (sipStack.isLoggingEnabled()) {
            sipStack.getStackLogger().logDebug(
                    "processing " + transactionResponse.getFirstLine() + "current state = "
                            + getState());
            sipStack.getStackLogger().logDebug("dialog = " + dialog);
        }

        this.lastResponse = transactionResponse;

        /*
         * JvB: this is now duplicate with code in the other processResponse
         * 
         * if (dialog != null && transactionResponse.getStatusCode() != 100 &&
         * (transactionResponse.getTo().getTag() != null || sipStack .isRfc2543Supported())) { //
         * add the route before you process the response. dialog.setLastResponse(this,
         * transactionResponse); this.setDialog(dialog, transactionResponse.getDialogId(false)); }
         */

        try {
            if (isInviteTransaction())
                inviteClientTransaction(transactionResponse, sourceChannel, dialog);
            else
                nonInviteClientTransaction(transactionResponse, sourceChannel, dialog);
        } catch (IOException ex) {
            if (sipStack.isLoggingEnabled())
                sipStack.getStackLogger().logException(ex);
            this.setState(TransactionState.TERMINATED);
            raiseErrorEvent(SIPTransactionErrorEvent.TRANSPORT_ERROR);
        }
    }

    /**
     * Implements the state machine for invite client transactions.
     * 
     * <pre>
     *                   
     *                    
     *                     
     *                      
     *                      
     *                                                         |Request from TU
     *                                                         |send request
     *                                     Timer E             V
     *                                     send request  +-----------+
     *                                         +---------|           |-------------------+
     *                                         |         |  Trying   |  Timer F          |
     *                                         +--------&gt;|           |  or Transport Err.|
     *                                                   +-----------+  inform TU        |
     *                                      200-699         |  |                         |
     *                                      resp. to TU     |  |1xx                      |
     *                                      +---------------+  |resp. to TU              |
     *                                      |                  |                         |
     *                                      |   Timer E        V       Timer F           |
     *                                      |   send req +-----------+ or Transport Err. |
     *                                      |  +---------|           | inform TU         |
     *                                      |  |         |Proceeding |------------------&gt;|
     *                                      |  +--------&gt;|           |-----+             |
     *                                      |            +-----------+     |1xx          |
     *                                      |              |      &circ;        |resp to TU   |
     *                                      | 200-699      |      +--------+             |
     *                                      | resp. to TU  |                             |
     *                                      |              |                             |
     *                                      |              V                             |
     *                                      |            +-----------+                   |
     *                                      |            |           |                   |
     *                                      |            | Completed |                   |
     *                                      |            |           |                   |
     *                                      |            +-----------+                   |
     *                                      |              &circ;   |                         |
     *                                      |              |   | Timer K                 |
     *                                      +--------------+   | -                       |
     *                                                         |                         |
     *                                                         V                         |
     *                                   NOTE:           +-----------+                   |
     *                                                   |           |                   |
     *                               transitions         | Terminated|&lt;------------------+
     *                               labeled with        |           |
     *                               the event           +-----------+
     *                               over the action
     *                               to take
     *                      
     *                                       Figure 6: non-INVITE client transaction
     *                      
     *                      
     *                     
     *                    
     * </pre>
     * 
     * @param transactionResponse -- transaction response received.
     * @param sourceChannel - source channel on which the response was received.
     */
    private void nonInviteClientTransaction(SIPResponse transactionResponse,
            MessageChannel sourceChannel, SIPDialog sipDialog) throws IOException {
        int statusCode = transactionResponse.getStatusCode();
        if (TransactionState.TRYING == this.getState()) {
            if (statusCode / 100 == 1) {
                this.setState(TransactionState.PROCEEDING);
                enableRetransmissionTimer(MAXIMUM_RETRANSMISSION_TICK_COUNT);
                enableTimeoutTimer(TIMER_F);
                // According to RFC, the TU has to be informed on
                // this transition.
                if (respondTo != null) {
                    respondTo.processResponse(transactionResponse, this, sipDialog);
                } else {
                    this.semRelease();
                }
            } else if (200 <= statusCode && statusCode <= 699) {
                // Send the response up to the TU.
                if (respondTo != null) {
                    respondTo.processResponse(transactionResponse, this, sipDialog);
                } else {
                    this.semRelease();
                }
                if (!isReliable()) {
                    this.setState(TransactionState.COMPLETED);
                    enableTimeoutTimer(TIMER_K);
                } else {
                    this.setState(TransactionState.TERMINATED);
                }
            }
        } else if (TransactionState.PROCEEDING == this.getState()) {
            if (statusCode / 100 == 1) {
                if (respondTo != null) {
                    respondTo.processResponse(transactionResponse, this, sipDialog);
                } else {
                    this.semRelease();
                }
            } else if (200 <= statusCode && statusCode <= 699) {
                if (respondTo != null) {
                    respondTo.processResponse(transactionResponse, this, sipDialog);
                } else {
                    this.semRelease();
                }
                disableRetransmissionTimer();
                disableTimeoutTimer();
                if (!isReliable()) {
                    this.setState(TransactionState.COMPLETED);
                    enableTimeoutTimer(TIMER_K);
                } else {
                    this.setState(TransactionState.TERMINATED);
                }
            }
        } else {
            if (sipStack.isLoggingEnabled()) {
                sipStack.getStackLogger().logDebug(
                        " Not sending response to TU! " + getState());
            }
            this.semRelease();
        }
    }

    /**
     * Implements the state machine for invite client transactions.
     * 
     * <pre>
     *                   
     *                    
     *                     
     *                      
     *                      
     *                                                     |INVITE from TU
     *                                   Timer A fires     |INVITE sent
     *                                   Reset A,          V                      Timer B fires
     *                                   INVITE sent +-----------+                or Transport Err.
     *                                     +---------|           |---------------+inform TU
     *                                     |         |  Calling  |               |
     *                                     +--------&gt;|           |--------------&gt;|
     *                                               +-----------+ 2xx           |
     *                                                  |  |       2xx to TU     |
     *                                                  |  |1xx                  |
     *                          300-699 +---------------+  |1xx to TU            |
     *                         ACK sent |                  |                     |
     *                      resp. to TU |  1xx             V                     |
     *                                  |  1xx to TU  -----------+               |
     *                                  |  +---------|           |               |
     *                                  |  |         |Proceeding |--------------&gt;|
     *                                  |  +--------&gt;|           | 2xx           |
     *                                  |            +-----------+ 2xx to TU     |
     *                                  |       300-699    |                     |
     *                                  |       ACK sent,  |                     |
     *                                  |       resp. to TU|                     |
     *                                  |                  |                     |      NOTE:
     *                                  |  300-699         V                     |
     *                                  |  ACK sent  +-----------+Transport Err. |  transitions
     *                                  |  +---------|           |Inform TU      |  labeled with
     *                                  |  |         | Completed |--------------&gt;|  the event
     *                                  |  +--------&gt;|           |               |  over the action
     *                                  |            +-----------+               |  to take
     *                                  |              &circ;   |                     |
     *                                  |              |   | Timer D fires       |
     *                                  +--------------+   | -                   |
     *                                                     |                     |
     *                                                     V                     |
     *                                               +-----------+               |
     *                                               |           |               |
     *                                               | Terminated|&lt;--------------+
     *                                               |           |
     *                                               +-----------+
     *                      
     *                      
     *                     
     *                    
     * </pre>
     * 
     * @param transactionResponse -- transaction response received.
     * @param sourceChannel - source channel on which the response was received.
     */

    private void inviteClientTransaction(SIPResponse transactionResponse,
            MessageChannel sourceChannel, SIPDialog dialog) throws IOException {
        int statusCode = transactionResponse.getStatusCode();
       
        if (TransactionState.TERMINATED == this.getState()) {
            boolean ackAlreadySent = false;
            if (dialog != null && dialog.isAckSeen() && dialog.getLastAckSent() != null) {
                if (dialog.getLastAckSent().getCSeq().getSeqNumber() == transactionResponse.getCSeq()
                        .getSeqNumber()
                        && transactionResponse.getFromTag().equals(
                                dialog.getLastAckSent().getFromTag())) {
                    // the last ack sent corresponded to this response
                    ackAlreadySent = true;
                }
            }
            // retransmit the ACK for this response.
            if (dialog!= null && ackAlreadySent
                    && transactionResponse.getCSeq().getMethod().equals(dialog.getMethod())) {
                try {
                    // Found the dialog - resend the ACK and
                    // dont pass up the null transaction
                    if (sipStack.isLoggingEnabled())
                        sipStack.getStackLogger().logDebug("resending ACK");

                    dialog.resendAck();
                } catch (SipException ex) {
                    // What to do here ?? kill the dialog?
                }
            }

            this.semRelease();
            return;
        } else if (TransactionState.CALLING == this.getState()) {
            if (statusCode / 100 == 2) {

                // JvB: do this ~before~ calling the application, to avoid
                // retransmissions
                // of the INVITE after app sends ACK
                disableRetransmissionTimer();
                disableTimeoutTimer();
                this.setState(TransactionState.TERMINATED);

                // 200 responses are always seen by TU.
                if (respondTo != null)
                    respondTo.processResponse(transactionResponse, this, dialog);
                else {
                    this.semRelease();
                }

            } else if (statusCode / 100 == 1) {
                disableRetransmissionTimer();
                disableTimeoutTimer();
                this.setState(TransactionState.PROCEEDING);

                if (respondTo != null)
                    respondTo.processResponse(transactionResponse, this, dialog);
                else {
                    this.semRelease();
                }

            } else if (300 <= statusCode && statusCode <= 699) {
                // Send back an ACK request

                try {
                    sendMessage((SIPRequest) createErrorAck());

                } catch (Exception ex) {
                    sipStack.getStackLogger().logError(
                            "Unexpected Exception sending ACK -- sending error AcK ", ex);

                }

                /*
                 * When in either the "Calling" or "Proceeding" states, reception of response with
                 * status code from 300-699 MUST cause the client transaction to transition to
                 * "Completed". The client transaction MUST pass the received response up to the
                 * TU, and the client transaction MUST generate an ACK request.
                 */

                if (respondTo != null) {
                    respondTo.processResponse(transactionResponse, this, dialog);
                } else {
                    this.semRelease();
                }

                if (this.getDialog() != null &&  ((SIPDialog)this.getDialog()).isBackToBackUserAgent()) {
                    ((SIPDialog) this.getDialog()).releaseAckSem();
                }

                if (!isReliable()) {
                    this.setState(TransactionState.COMPLETED);
                    enableTimeoutTimer(TIMER_D);
                } else {
                    // Proceed immediately to the TERMINATED state.
                    this.setState(TransactionState.TERMINATED);
                }
            }
        } else if (TransactionState.PROCEEDING == this.getState()) {
            if (statusCode / 100 == 1) {
                if (respondTo != null) {
                    respondTo.processResponse(transactionResponse, this, dialog);
                } else {
                    this.semRelease();
                }
            } else if (statusCode / 100 == 2) {
                this.setState(TransactionState.TERMINATED);
                if (respondTo != null) {
                    respondTo.processResponse(transactionResponse, this, dialog);
                } else {
                    this.semRelease();
                }

            } else if (300 <= statusCode && statusCode <= 699) {
                // Send back an ACK request
                try {
                    sendMessage((SIPRequest) createErrorAck());
                } catch (Exception ex) {
                    InternalErrorHandler.handleException(ex);
                }

                if (this.getDialog() != null) {
                    ((SIPDialog) this.getDialog()).releaseAckSem();
                }
                // JvB: update state before passing to app
                if (!isReliable()) {
                    this.setState(TransactionState.COMPLETED);
                    this.enableTimeoutTimer(TIMER_D);
                } else {
                    this.setState(TransactionState.TERMINATED);
                }

                // Pass up to the TU for processing.
                if (respondTo != null)
                    respondTo.processResponse(transactionResponse, this, dialog);
                else {
                    this.semRelease();
                }

                // JvB: duplicate with line 874
                // if (!isReliable()) {
                // enableTimeoutTimer(TIMER_D);
                // }
            }
        } else if (TransactionState.COMPLETED == this.getState()) {
            if (300 <= statusCode && statusCode <= 699) {
                // Send back an ACK request
                try {
                    sendMessage((SIPRequest) createErrorAck());
                } catch (Exception ex) {
                    InternalErrorHandler.handleException(ex);
                } finally {
                    this.semRelease();
                }
            }

        }

    }

    /*
     * (non-Javadoc)
     * 
     * @see javax.sip.ClientTransaction#sendRequest()
     */
    public void sendRequest() throws SipException {
        SIPRequest sipRequest = this.getOriginalRequest();

        if (this.getState() != null)
            throw new SipException("Request already sent");

        if (sipStack.isLoggingEnabled()) {
            sipStack.getStackLogger().logDebug("sendRequest() " + sipRequest);
        }

        try {
            sipRequest.checkHeaders();
        } catch (ParseException ex) {
        	if (sipStack.isLoggingEnabled())
        		sipStack.getStackLogger().logError("missing required header");
            throw new SipException(ex.getMessage());
        }

        if (getMethod().equals(Request.SUBSCRIBE)
                && sipRequest.getHeader(ExpiresHeader.NAME) == null) {
            /*
             * If no "Expires" header is present in a SUBSCRIBE request, the implied default is
             * defined by the event package being used.
             * 
             */
        	if (sipStack.isLoggingEnabled())
        		sipStack.getStackLogger().logWarning(
                    "Expires header missing in outgoing subscribe --"
                            + " Notifier will assume implied value on event package");
        }
        try {
            /*
             * This check is removed because it causes problems for load balancers ( See issue
             * 136) reported by Raghav Ramesh ( BT )
             * 
             */
            if (this.getOriginalRequest().getMethod().equals(Request.CANCEL)
                    && sipStack.isCancelClientTransactionChecked()) {
                SIPClientTransaction ct = (SIPClientTransaction) sipStack.findCancelTransaction(
                        this.getOriginalRequest(), false);
                if (ct == null) {
                    /*
                     * If the original request has generated a final response, the CANCEL SHOULD
                     * NOT be sent, as it is an effective no-op, since CANCEL has no effect on
                     * requests that have already generated a final response.
                     */
                    throw new SipException("Could not find original tx to cancel. RFC 3261 9.1");
                } else if (ct.getState() == null) {
                    throw new SipException(
                            "State is null no provisional response yet -- cannot cancel RFC 3261 9.1");
                } else if (!ct.getMethod().equals(Request.INVITE)) {
                    throw new SipException("Cannot cancel non-invite requests RFC 3261 9.1");
                }
            } else

            if (this.getOriginalRequest().getMethod().equals(Request.BYE)
                    || this.getOriginalRequest().getMethod().equals(Request.NOTIFY)) {
                SIPDialog dialog = sipStack.getDialog(this.getOriginalRequest()
                        .getDialogId(false));
                // I want to behave like a user agent so send the BYE using the
                // Dialog
                if (this.getSipProvider().isAutomaticDialogSupportEnabled() && dialog != null) {
                    throw new SipException(
                            "Dialog is present and AutomaticDialogSupport is enabled for "
                                    + " the provider -- Send the Request using the Dialog.sendRequest(transaction)");
                }
            }
            // Only map this after the fist request is sent out.
            if (this.getMethod().equals(Request.INVITE)) {
                SIPDialog dialog = this.getDefaultDialog();

                if (dialog != null && dialog.isBackToBackUserAgent()) {
                    // Block sending re-INVITE till we see the ACK.
                    if ( ! dialog.takeAckSem() ) {
                        throw new SipException ("Failed to take ACK semaphore");
                    }

                }
            }
            this.isMapped = true;
            this.sendMessage(sipRequest);

        } catch (IOException ex) {
            this.setState(TransactionState.TERMINATED);
            throw new SipException("IO Error sending request", ex);

        }

    }

    /**
     * Called by the transaction stack when a retransmission timer fires.
     */
    protected void fireRetransmissionTimer() {

        try {

            // Resend the last request sent
            if (this.getState() == null || !this.isMapped)
                return;

            boolean inv = isInviteTransaction();
            TransactionState s = this.getState();

            // JvB: INVITE CTs only retransmit in CALLING, non-INVITE in both TRYING and
            // PROCEEDING
            // Bug-fix for non-INVITE transactions not retransmitted when 1xx response received
            if ((inv && TransactionState.CALLING == s)
                    || (!inv && (TransactionState.TRYING == s || TransactionState.PROCEEDING == s))) {
                // If the retransmission filter is disabled then
                // retransmission of the INVITE is the application
                // responsibility.

                if (lastRequest != null) {
                    if (sipStack.generateTimeStampHeader
                            && lastRequest.getHeader(TimeStampHeader.NAME) != null) {
                        long milisec = System.currentTimeMillis();
                        TimeStamp timeStamp = new TimeStamp();
                        try {
                            timeStamp.setTimeStamp(milisec);
                        } catch (InvalidArgumentException ex) {
                            InternalErrorHandler.handleException(ex);
                        }
                        lastRequest.setHeader(timeStamp);
                    }
                    super.sendMessage(lastRequest);
                    if (this.notifyOnRetransmit) {
                        TimeoutEvent txTimeout = new TimeoutEvent(this.getSipProvider(), this,
                                Timeout.RETRANSMIT);
                        this.getSipProvider().handleEvent(txTimeout, this);
                    }
                    if (this.timeoutIfStillInCallingState
                            && this.getState() == TransactionState.CALLING) {
                        this.callingStateTimeoutCount--;
                        if (callingStateTimeoutCount == 0) {
                            TimeoutEvent timeoutEvent = new TimeoutEvent(this.getSipProvider(),
                                    this, Timeout.RETRANSMIT);
                            this.getSipProvider().handleEvent(timeoutEvent, this);
                            this.timeoutIfStillInCallingState = false;
                        }

                    }
                }

            }
        } catch (IOException e) {
            this.raiseIOExceptionEvent();
            raiseErrorEvent(SIPTransactionErrorEvent.TRANSPORT_ERROR);
        }

    }

    /**
     * Called by the transaction stack when a timeout timer fires.
     */
    protected void fireTimeoutTimer() {

        if (sipStack.isLoggingEnabled())
            sipStack.getStackLogger().logDebug("fireTimeoutTimer " + this);

        SIPDialog dialog = (SIPDialog) this.getDialog();
        if (TransactionState.CALLING == this.getState()
                || TransactionState.TRYING == this.getState()
                || TransactionState.PROCEEDING == this.getState()) {
            // Timeout occured. If this is asociated with a transaction
            // creation then kill the dialog.
            if (dialog != null
                    && (dialog.getState() == null || dialog.getState() == DialogState.EARLY)) {
                if (((SIPTransactionStack) getSIPStack()).isDialogCreated(this
                        .getOriginalRequest().getMethod())) {
                    // If this is a re-invite we do not delete the dialog even
                    // if the
                    // reinvite times out. Else
                    // terminate the enclosing dialog.
                    dialog.delete();
                }
            } else if (dialog != null) {
                // Guard against the case of BYE time out.

                if (getOriginalRequest().getMethod().equalsIgnoreCase(Request.BYE)
                        && dialog.isTerminatedOnBye()) {
                    // Terminate the associated dialog on BYE Timeout.
                    dialog.delete();
                }
            }
        }
        if (TransactionState.COMPLETED != this.getState()) {
            raiseErrorEvent(SIPTransactionErrorEvent.TIMEOUT_ERROR);
            // Got a timeout error on a cancel.
            if (this.getOriginalRequest().getMethod().equalsIgnoreCase(Request.CANCEL)) {
                SIPClientTransaction inviteTx = (SIPClientTransaction) this.getOriginalRequest()
                        .getInviteTransaction();
                if (inviteTx != null
                        && ((inviteTx.getState() == TransactionState.CALLING || inviteTx
                                .getState() == TransactionState.PROCEEDING))
                        && inviteTx.getDialog() != null) {
                    /*
                     * A proxy server should have started TIMER C and take care of the Termination
                     * using transaction.terminate() by itself (i.e. this is not the job of the
                     * stack at this point but we do it to be nice.
                     */
                    inviteTx.setState(TransactionState.TERMINATED);

                }
            }

        } else {
            this.setState(TransactionState.TERMINATED);
        }

    }

    /*
     * (non-Javadoc)
     * 
     * @see javax.sip.ClientTransaction#createCancel()
     */
    public Request createCancel() throws SipException {
        SIPRequest originalRequest = this.getOriginalRequest();
        if (originalRequest == null)
            throw new SipException("Bad state " + getState());
        if (!originalRequest.getMethod().equals(Request.INVITE))
            throw new SipException("Only INIVTE may be cancelled");

        if (originalRequest.getMethod().equalsIgnoreCase(Request.ACK))
            throw new SipException("Cannot Cancel ACK!");
        else {
            SIPRequest cancelRequest = originalRequest.createCancelRequest();
            cancelRequest.setInviteTransaction(this);
            return cancelRequest;
        }
    }

    /*
     * (non-Javadoc)
     * 
     * @see javax.sip.ClientTransaction#createAck()
     */
    public Request createAck() throws SipException {
        SIPRequest originalRequest = this.getOriginalRequest();
        if (originalRequest == null)
            throw new SipException("bad state " + getState());
        if (getMethod().equalsIgnoreCase(Request.ACK)) {
            throw new SipException("Cannot ACK an ACK!");
        } else if (lastResponse == null) {
            throw new SipException("bad Transaction state");
        } else if (lastResponse.getStatusCode() < 200) {
            if (sipStack.isLoggingEnabled()) {
                sipStack.getStackLogger().logDebug("lastResponse = " + lastResponse);
            }
            throw new SipException("Cannot ACK a provisional response!");
        }
        SIPRequest ackRequest = originalRequest.createAckRequest((To) lastResponse.getTo());
        // Pull the record route headers from the last reesponse.
        RecordRouteList recordRouteList = lastResponse.getRecordRouteHeaders();
        if (recordRouteList == null) {
            // If the record route list is null then we can
            // construct the ACK from the specified contact header.
            // Note the 3xx check here because 3xx is a redirect.
            // The contact header for the 3xx is the redirected
            // location so we cannot use that to construct the
            // request URI.
            if (lastResponse.getContactHeaders() != null
                    && lastResponse.getStatusCode() / 100 != 3) {
                Contact contact = (Contact) lastResponse.getContactHeaders().getFirst();
                javax.sip.address.URI uri = (javax.sip.address.URI) contact.getAddress().getURI()
                        .clone();
                ackRequest.setRequestURI(uri);
            }
            return ackRequest;
        }

        ackRequest.removeHeader(RouteHeader.NAME);
        RouteList routeList = new RouteList();
        // start at the end of the list and walk backwards
        ListIterator<RecordRoute> li = recordRouteList.listIterator(recordRouteList.size());
        while (li.hasPrevious()) {
            RecordRoute rr = (RecordRoute) li.previous();

            Route route = new Route();
            route.setAddress((AddressImpl) ((AddressImpl) rr.getAddress()).clone());
            route.setParameters((NameValueList) rr.getParameters().clone());
            routeList.add(route);
        }

        Contact contact = null;
        if (lastResponse.getContactHeaders() != null) {
            contact = (Contact) lastResponse.getContactHeaders().getFirst();
        }

        if (!((SipURI) ((Route) routeList.getFirst()).getAddress().getURI()).hasLrParam()) {

            // Contact may not yet be there (bug reported by Andreas B).

            Route route = null;
            if (contact != null) {
                route = new Route();
                route.setAddress((AddressImpl) ((AddressImpl) (contact.getAddress())).clone());
            }

            Route firstRoute = (Route) routeList.getFirst();
            routeList.removeFirst();
            javax.sip.address.URI uri = firstRoute.getAddress().getURI();
            ackRequest.setRequestURI(uri);

            if (route != null)
                routeList.add(route);

            ackRequest.addHeader(routeList);
        } else {
            if (contact != null) {
                javax.sip.address.URI uri = (javax.sip.address.URI) contact.getAddress().getURI()
                        .clone();
                ackRequest.setRequestURI(uri);
                ackRequest.addHeader(routeList);
            }
        }
        return ackRequest;

    }

    /*
     * Creates an ACK for an error response, according to RFC3261 section 17.1.1.3
     * 
     * Note that this is different from an ACK for 2xx
     */
    private final Request createErrorAck() throws SipException, ParseException {
        SIPRequest originalRequest = this.getOriginalRequest();
        if (originalRequest == null)
            throw new SipException("bad state " + getState());
        if (!getMethod().equals(Request.INVITE)) {
            throw new SipException("Can only ACK an INVITE!");
        } else if (lastResponse == null) {
            throw new SipException("bad Transaction state");
        } else if (lastResponse.getStatusCode() < 200) {
            if (sipStack.isLoggingEnabled()) {
                sipStack.getStackLogger().logDebug("lastResponse = " + lastResponse);
            }
            throw new SipException("Cannot ACK a provisional response!");
        }
        return originalRequest.createErrorAck((To) lastResponse.getTo());
    }

    /**
     * Set the port of the recipient.
     */
    protected void setViaPort(int port) {
        this.viaPort = port;
    }

    /**
     * Set the port of the recipient.
     */
    protected void setViaHost(String host) {
        this.viaHost = host;
    }

    /**
     * Get the port of the recipient.
     */
    public int getViaPort() {
        return this.viaPort;
    }

    /**
     * Get the host of the recipient.
     */
    public String getViaHost() {
        return this.viaHost;
    }

    /**
     * get the via header for an outgoing request.
     */
    public Via getOutgoingViaHeader() {
        return this.getMessageProcessor().getViaHeader();
    }

    /**
     * This is called by the stack after a non-invite client transaction goes to completed state.
     */
    public void clearState() {
        // reduce the state to minimum
        // This assumes that the application will not need
        // to access the request once the transaction is
        // completed.
        // TODO -- revisit this - results in a null pointer
        // occuring occasionally.
        // this.lastRequest = null;
        // this.originalRequest = null;
        // this.lastResponse = null;
    }

    /**
     * Sets a timeout after which the connection is closed (provided the server does not use the
     * connection for outgoing requests in this time period) and calls the superclass to set
     * state.
     */
    public void setState(TransactionState newState) {
        // Set this timer for connection caching
        // of incoming connections.
        if (newState == TransactionState.TERMINATED && this.isReliable()
                && (!getSIPStack().cacheClientConnections)) {
            // Set a time after which the connection
            // is closed.
            this.collectionTime = TIMER_J;

        }
        if (super.getState() != TransactionState.COMPLETED
                && (newState == TransactionState.COMPLETED || newState == TransactionState.TERMINATED)) {
            sipStack.decrementActiveClientTransactionCount();
        }
        super.setState(newState);
    }

    /**
     * Start the timer task.
     */
    protected  void startTransactionTimer() {
        if (this.transactionTimerStarted.compareAndSet(false, true)) {
	        TimerTask myTimer = new TransactionTimer();
	        if ( sipStack.getTimer() != null ) {
	            sipStack.getTimer().schedule(myTimer, BASE_TIMER_INTERVAL, BASE_TIMER_INTERVAL);
	        }
        }
    }

    /*
     * Terminate a transaction. This marks the tx as terminated The tx scanner will run and remove
     * the tx. (non-Javadoc)
     * 
     * @see javax.sip.Transaction#terminate()
     */
    public void terminate() throws ObjectInUseException {
        this.setState(TransactionState.TERMINATED);

    }

    /**
     * Check if the From tag of the response matches the from tag of the original message. A
     * Response with a tag mismatch should be dropped if a Dialog has been created for the
     * original request.
     * 
     * @param sipResponse the response to check.
     * @return true if the check passes.
     */
    public boolean checkFromTag(SIPResponse sipResponse) {
        String originalFromTag = ((SIPRequest) this.getRequest()).getFromTag();
        if (this.defaultDialog != null) {
            if (originalFromTag == null ^ sipResponse.getFrom().getTag() == null) {
            	if (sipStack.isLoggingEnabled())
            		sipStack.getStackLogger().logDebug("From tag mismatch -- dropping response");
                return false;
            }
            if (originalFromTag != null
                    && !originalFromTag.equalsIgnoreCase(sipResponse.getFrom().getTag())) {
            	if (sipStack.isLoggingEnabled())
            		sipStack.getStackLogger().logDebug("From tag mismatch -- dropping response");
                return false;
            }
        }
        return true;

    }

    /*
     * (non-Javadoc)
     * 
     * @see gov.nist.javax.sip.stack.ServerResponseInterface#processResponse(gov.nist.javax.sip.message.SIPResponse,
     *      gov.nist.javax.sip.stack.MessageChannel)
     */
    public void processResponse(SIPResponse sipResponse, MessageChannel incomingChannel) {

        // If a dialog has already been created for this response,
        // pass it up.
        SIPDialog dialog = null;
        String method = sipResponse.getCSeq().getMethod();
        String dialogId = sipResponse.getDialogId(false);
        if (method.equals(Request.CANCEL) && lastRequest != null) {
            // JvB for CANCEL: use invite CT in CANCEL request to get dialog
            // (instead of stripping tag)
            SIPClientTransaction ict = (SIPClientTransaction) lastRequest.getInviteTransaction();
            if (ict != null) {
                dialog = ict.defaultDialog;
            }
        } else {
            dialog = this.getDialog(dialogId);
        }

        // JvB: Check all conditions required for creating a new Dialog
        if (dialog == null) {
            int code = sipResponse.getStatusCode();
            if ((code > 100 && code < 300)
            /* skip 100 (may have a to tag */
            && (sipResponse.getToTag() != null || sipStack.isRfc2543Supported())
                    && sipStack.isDialogCreated(method)) {

                /*
                 * Dialog cannot be found for the response. This must be a forked response. no
                 * dialog assigned to this response but a default dialog has been assigned. Note
                 * that if automatic dialog support is configured then a default dialog is always
                 * created.
                 */

                synchronized (this) {
                    /*
                     * We need synchronization here because two responses may compete for the
                     * default dialog simultaneously
                     */
                    if (defaultDialog != null) {
                        if (sipResponse.getFromTag() != null) {
                            SIPResponse dialogResponse = defaultDialog.getLastResponse();
                            String defaultDialogId = defaultDialog.getDialogId();
                            if (dialogResponse == null
                                    || (method.equals(Request.SUBSCRIBE)
                                            && dialogResponse.getCSeq().getMethod().equals(
                                                    Request.NOTIFY) && defaultDialogId
                                            .equals(dialogId))) {
                                // The default dialog has not been claimed yet.
                                defaultDialog.setLastResponse(this, sipResponse);
                                dialog = defaultDialog;
                            } else {
                                /*
                                 * check if we have created one previously (happens in the case of
                                 * REINVITE processing. JvB: should not happen, this.defaultDialog
                                 * should then get set in Dialog#sendRequest line 1662
                                 */

                                dialog = sipStack.getDialog(dialogId);
                                if (dialog == null) {
                                    if (defaultDialog.isAssigned()) {
                                        /*
                                         * Nop we dont have one. so go ahead and allocate a new
                                         * one.
                                         */
                                        dialog = sipStack.createDialog(this, sipResponse);

                                    }
                                }

                            }
                            if ( dialog != null ) {
                                this.setDialog(dialog, dialog.getDialogId());
                            } else {
                                sipStack.getStackLogger().logError("dialog is unexpectedly null",new NullPointerException());
                            }
                        } else {
                            throw new RuntimeException("Response without from-tag");
                        }
                    } else {
                        // Need to create a new Dialog, this becomes default
                        // JvB: not sure if this ever gets executed
                        if (sipStack.isAutomaticDialogSupportEnabled) {
                            dialog = sipStack.createDialog(this, sipResponse);
                            this.setDialog(dialog, dialog.getDialogId());
                        }
                    }
                } // synchronized
            } else {
                dialog = defaultDialog;
            }
        } else {
            dialog.setLastResponse(this, sipResponse);
        }
        this.processResponse(sipResponse, incomingChannel, dialog);
    }

    /*
     * (non-Javadoc)
     * 
     * @see gov.nist.javax.sip.stack.SIPTransaction#getDialog()
     */
    public  Dialog getDialog() {
        // This is for backwards compatibility.
        Dialog retval = null;
        if (this.lastResponse != null && this.lastResponse.getFromTag() != null
                && this.lastResponse.getToTag() != null
                && this.lastResponse.getStatusCode() != 100) {
            String dialogId = this.lastResponse.getDialogId(false);
            retval = (Dialog) getDialog(dialogId);
        }

        if (retval == null) {
            retval = (Dialog) this.defaultDialog;

        }
        if (sipStack.isLoggingEnabled()) {
            sipStack.getStackLogger().logDebug(
                    " sipDialogs =  " + sipDialogs + " default dialog " + this.defaultDialog
                            + " retval " + retval);
        }
        return retval;

    }

    /*
     * (non-Javadoc)
     * 
     * @see gov.nist.javax.sip.stack.SIPTransaction#setDialog(gov.nist.javax.sip.stack.SIPDialog,
     *      gov.nist.javax.sip.message.SIPMessage)
     */
    public SIPDialog getDialog(String dialogId) {
        SIPDialog retval = (SIPDialog) this.sipDialogs.get(dialogId);
        return retval;

    }

    /*
     * (non-Javadoc)
     * 
     * @see gov.nist.javax.sip.stack.SIPTransaction#setDialog(gov.nist.javax.sip.stack.SIPDialog,
     *      gov.nist.javax.sip.message.SIPMessage)
     */
    public void setDialog(SIPDialog sipDialog, String dialogId) {
        if (sipStack.isLoggingEnabled())
            sipStack.getStackLogger().logDebug(
                    "setDialog: " + dialogId + "sipDialog = " + sipDialog);

        if (sipDialog == null) {
        	if (sipStack.isLoggingEnabled())
        		sipStack.getStackLogger().logError("NULL DIALOG!!");
            throw new NullPointerException("bad dialog null");
        }
        if (this.defaultDialog == null) {
            this.defaultDialog = sipDialog;
            if ( this.getMethod().equals(Request.INVITE) && this.getSIPStack().maxForkTime != 0) {
                this.getSIPStack().addForkedClientTransaction(this);
            }
        }
        if (dialogId != null && sipDialog.getDialogId() != null) {
            this.sipDialogs.put(dialogId, sipDialog);

        }

    }

    public SIPDialog getDefaultDialog() {
        return this.defaultDialog;
    }

    /**
     * Set the next hop ( if it has already been computed).
     * 
     * @param hop -- the hop that has been previously computed.
     */
    public void setNextHop(Hop hop) {
        this.nextHop = hop;

    }

    /**
     * Reeturn the previously computed next hop (avoid computing it twice).
     * 
     * @return -- next hop previously computed.
     */
    public Hop getNextHop() {
        return nextHop;
    }

    /**
     * Set this flag if you want your Listener to get Timeout.RETRANSMIT notifications each time a
     * retransmission occurs.
     * 
     * @param notifyOnRetransmit the notifyOnRetransmit to set
     */
    public void setNotifyOnRetransmit(boolean notifyOnRetransmit) {
        this.notifyOnRetransmit = notifyOnRetransmit;
    }

    /**
     * @return the notifyOnRetransmit
     */
    public boolean isNotifyOnRetransmit() {
        return notifyOnRetransmit;
    }

    public void alertIfStillInCallingStateBy(int count) {
        this.timeoutIfStillInCallingState = true;
        this.callingStateTimeoutCount = count;
    }

    
   
}
