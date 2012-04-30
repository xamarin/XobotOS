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
/**************************************************************************/
/* Product of NIST Advanced Networking Technologies Division      */
/**************************************************************************/
package gov.nist.javax.sip.stack;

import gov.nist.core.InternalErrorHandler;
import gov.nist.core.NameValueList;
import gov.nist.javax.sip.DialogExt;
import gov.nist.javax.sip.ListeningPointImpl;
import gov.nist.javax.sip.SipListenerExt;
import gov.nist.javax.sip.SipProviderImpl;
import gov.nist.javax.sip.Utils;
import gov.nist.javax.sip.address.AddressImpl;
import gov.nist.javax.sip.address.SipUri;
import gov.nist.javax.sip.header.Authorization;
import gov.nist.javax.sip.header.CSeq;
import gov.nist.javax.sip.header.Contact;
import gov.nist.javax.sip.header.ContactList;
import gov.nist.javax.sip.header.From;
import gov.nist.javax.sip.header.MaxForwards;
import gov.nist.javax.sip.header.RAck;
import gov.nist.javax.sip.header.RSeq;
import gov.nist.javax.sip.header.Reason;
import gov.nist.javax.sip.header.RecordRoute;
import gov.nist.javax.sip.header.RecordRouteList;
import gov.nist.javax.sip.header.Require;
import gov.nist.javax.sip.header.Route;
import gov.nist.javax.sip.header.RouteList;
import gov.nist.javax.sip.header.SIPHeader;
import gov.nist.javax.sip.header.TimeStamp;
import gov.nist.javax.sip.header.To;
import gov.nist.javax.sip.header.Via;
import gov.nist.javax.sip.message.MessageFactoryImpl;
import gov.nist.javax.sip.message.SIPMessage;
import gov.nist.javax.sip.message.SIPRequest;
import gov.nist.javax.sip.message.SIPResponse;

import java.io.IOException;
import java.io.PrintWriter;
import java.io.Serializable;
import java.io.StringWriter;
import java.net.InetAddress;
import java.text.ParseException;
import java.util.ArrayList;
import java.util.Iterator;
import java.util.LinkedList;
import java.util.List;
import java.util.ListIterator;
import java.util.Set;
import java.util.concurrent.CopyOnWriteArraySet;
import java.util.concurrent.Semaphore;
import java.util.concurrent.TimeUnit;

import javax.sip.ClientTransaction;
import javax.sip.DialogDoesNotExistException;
import javax.sip.DialogState;
import javax.sip.IOExceptionEvent;
import javax.sip.InvalidArgumentException;
import javax.sip.ListeningPoint;
import javax.sip.ObjectInUseException;
import javax.sip.SipException;
import javax.sip.Transaction;
import javax.sip.TransactionDoesNotExistException;
import javax.sip.TransactionState;
import javax.sip.address.Address;
import javax.sip.address.Hop;
import javax.sip.address.SipURI;
import javax.sip.header.CallIdHeader;
import javax.sip.header.ContactHeader;
import javax.sip.header.EventHeader;
import javax.sip.header.OptionTag;
import javax.sip.header.RAckHeader;
import javax.sip.header.RSeqHeader;
import javax.sip.header.ReasonHeader;
import javax.sip.header.RequireHeader;
import javax.sip.header.RouteHeader;
import javax.sip.header.SupportedHeader;
import javax.sip.header.TimeStampHeader;
import javax.sip.message.Request;
import javax.sip.message.Response;

/*
 * Acknowledgements:
 * 
 * Bugs in this class were reported by Antonis Karydas, Brad Templeton, Jeff Adams, Alex Rootham ,
 * Martin Le Clerk, Christophe Anzille, Andreas Bystrom, Lebing Xie, Jeroen van Bemmel. Hagai Sela
 * reported a bug in updating the route set (on RE-INVITE). Jens Tinfors submitted a bug fix and
 * the .equals method. Jan Schaumloeffel contributed a buf fix ( memory leak was happening when
 * 180 contained a To tag.
 * 
 */

/**
 * Tracks dialogs. A dialog is a peer to peer association of communicating SIP entities. For
 * INVITE transactions, a Dialog is created when a success message is received (i.e. a response
 * that has a To tag). The SIP Protocol stores enough state in the message structure to extract a
 * dialog identifier that can be used to retrieve this structure from the SipStack.
 * 
 * @version 1.2 $Revision: 1.159 $ $Date: 2010/01/08 15:14:12 $
 * 
 * @author M. Ranganathan
 * 
 * 
 */

public class SIPDialog implements javax.sip.Dialog, DialogExt {

    private static final long serialVersionUID = -1429794423085204069L;

    private transient boolean dialogTerminatedEventDelivered; // prevent duplicate
    
    private transient String stackTrace; // for semaphore debugging.

    private String method;

    // delivery of the event
    private transient boolean isAssigned;

    private boolean reInviteFlag;

    private transient Object applicationData; // Opaque pointer to application data.

    private transient SIPRequest originalRequest;

    // Last response (JvB: either sent or received).
    private SIPResponse lastResponse;

    // Should be transient, in case the dialog is serialized it will be null
    // so when a subsequent request will be sent it will be set and a new message channel can be
    // created
    private transient SIPTransaction firstTransaction;

    private transient SIPTransaction lastTransaction;

    private String dialogId;

    private transient String earlyDialogId;

    private long localSequenceNumber;

    private long remoteSequenceNumber;

    protected String myTag;

    protected String hisTag;

    private RouteList routeList;

    private transient SIPTransactionStack sipStack;

    private int dialogState;

    protected transient boolean ackSeen;
    
    private transient SIPRequest lastAckSent;

    private SIPRequest lastAckReceived;

    // could be set on recovery by examining the method looks like a duplicate of ackSeen
    protected transient boolean ackProcessed;

    protected transient DialogTimerTask timerTask;

    protected transient Long nextSeqno;

    private transient int retransmissionTicksLeft;

    private transient int prevRetransmissionTicks;

    private long originalLocalSequenceNumber;

    // This is for debugging only.
    private transient int ackLine;

    // Audit tag used by the SIP Stack audit
    public transient long auditTag = 0;

    // The following fields are extracted from the request that created the
    // Dialog.

    protected javax.sip.address.Address localParty;

    protected javax.sip.address.Address remoteParty;

    protected CallIdHeader callIdHeader;

    public final static int NULL_STATE = -1;

    public final static int EARLY_STATE = DialogState._EARLY;

    public final static int CONFIRMED_STATE = DialogState._CONFIRMED;

    public final static int TERMINATED_STATE = DialogState._TERMINATED;

    // the amount of time to keep this dialog around before the stack GC's it

    private static final int DIALOG_LINGER_TIME = 8;

    private boolean serverTransactionFlag;

    private transient SipProviderImpl sipProvider;

    private boolean terminateOnBye;

    private transient boolean byeSent; // Flag set when BYE is sent, to disallow new

    // requests

    private Address remoteTarget;

    private EventHeader eventHeader; // for Subscribe notify

    // Stores the last OK for the INVITE
    // Used in createAck.
    private transient long lastInviteOkReceived;

    private transient Semaphore ackSem = new Semaphore(1);

    private transient int reInviteWaitTime = 100;

    private transient DialogDeleteTask dialogDeleteTask;

	private transient DialogDeleteIfNoAckSentTask dialogDeleteIfNoAckSentTask;
    
    private transient boolean isAcknowledged;
    
    private transient long highestSequenceNumberAcknowledged = -1;
    
    private boolean isBackToBackUserAgent;

    private boolean sequenceNumberValidation = true;

    // List of event listeners for this dialog
	private transient Set<SIPDialogEventListener> eventListeners;
	// added for Issue 248 : https://jain-sip.dev.java.net/issues/show_bug.cgi?id=248
	private Semaphore timerTaskLock = new Semaphore(1);
	
	// We store here the useful data from the first transaction without having to
	// keep the whole transaction object for the duration of the dialog. It also
	// contains the non-transient information used in the replication of dialogs.
	protected boolean firstTransactionSecure;
	protected boolean firstTransactionSeen;
    protected String firstTransactionMethod;
    protected String firstTransactionId;
    protected boolean firstTransactionIsServerTransaction;
    protected int firstTransactionPort = 5060;   
    protected Contact contactHeader;

    // //////////////////////////////////////////////////////
    // Inner classes
    // //////////////////////////////////////////////////////

    /**
     * This task waits till a pending ACK has been recorded and then sends out a re-INVITE. This
     * is to prevent interleaving INVITEs ( which will result in a 493 from the UA that receives
     * the out of order INVITE). This is primarily for B2BUA support. A B2BUA may send a delayed
     * ACK while it does mid call codec renegotiation. In the meanwhile, it cannot send an intervening
     * re-INVITE otherwise the othr end will respond with a REQUEST_PENDING. We want to avoid this
     * condition. Hence we wait till the ACK for the previous re-INVITE has been sent before 
     * sending the next re-INVITE. 
     */
    public class ReInviteSender implements Runnable, Serializable {
        private static final long serialVersionUID = 1019346148741070635L;
        ClientTransaction ctx;

        public void terminate() {
            try {
                ctx.terminate();
                Thread.currentThread().interrupt();
            } catch (ObjectInUseException e) {
                sipStack.getStackLogger().logError("unexpected error", e);
            }
        }

        public ReInviteSender(ClientTransaction ctx) {
            this.ctx = ctx;
        }

        public void run() {
            try {
                long timeToWait = 0;
                long startTime = System.currentTimeMillis();

                if (!SIPDialog.this.takeAckSem()) {
                    /*
                     * Could not send re-INVITE fire a timeout on the INVITE.
                     */
                	if (sipStack.isLoggingEnabled())
                		sipStack.getStackLogger().logError(
                            "Could not send re-INVITE time out ClientTransaction");
                    ((SIPClientTransaction) ctx).fireTimeoutTimer();
                    /*
                     * Send BYE to the Dialog. 
                     */
                    if ( sipProvider.getSipListener() != null && sipProvider.getSipListener() instanceof SipListenerExt ) {
                        raiseErrorEvent(SIPDialogErrorEvent.DIALOG_REINVITE_TIMEOUT);
                    } else {
                        Request byeRequest = SIPDialog.this.createRequest(Request.BYE);
                        if ( MessageFactoryImpl.getDefaultUserAgentHeader() != null ) {
                            byeRequest.addHeader(MessageFactoryImpl.getDefaultUserAgentHeader());
                        }
                        ReasonHeader reasonHeader = new Reason();
                        reasonHeader.setCause(1024);
                        reasonHeader.setText("Timed out waiting to re-INVITE");
                        byeRequest.addHeader(reasonHeader);
                        ClientTransaction byeCtx = SIPDialog.this.getSipProvider().getNewClientTransaction(byeRequest);
                        SIPDialog.this.sendRequest(byeCtx);
                        return;
                    }
                }
                if (getState() != DialogState.TERMINATED) {

                    timeToWait = System.currentTimeMillis() - startTime;
                }

                /*
                 * If we had to wait for ACK then wait for the ACK to actually get to the other
                 * side. Wait for any ACK retransmissions to finish. Then send out the request.
                 * This is a hack in support of some UA that want re-INVITEs to be spaced out in
                 * time ( else they return a 400 error code ).
                 */
                try {
                    if (timeToWait != 0) {
                        Thread.sleep(SIPDialog.this.reInviteWaitTime);
                    }
                } catch (InterruptedException ex) {
                	if (sipStack.isLoggingEnabled())
                		sipStack.getStackLogger().logDebug("Interrupted sleep");
                    return;
                }
                if (SIPDialog.this.getState() != DialogState.TERMINATED) {
                    SIPDialog.this.sendRequest(ctx, true);
                }
                if (sipStack.isLoggingEnabled())
                	sipStack.getStackLogger().logDebug("re-INVITE successfully sent");
            } catch (Exception ex) {
                sipStack.getStackLogger().logError("Error sending re-INVITE", ex);
            } finally {
                this.ctx = null;
            }
        }
    }

	class LingerTimer extends SIPStackTimerTask implements Serializable {

        public LingerTimer() {

        }

        protected void runTask() {
            SIPDialog dialog = SIPDialog.this;
            if(eventListeners != null) {
            	eventListeners.clear();
            }
            timerTaskLock = null;
            sipStack.removeDialog(dialog);
        }

    }

    class DialogTimerTask extends SIPStackTimerTask implements Serializable {
        int nRetransmissions;

        SIPServerTransaction transaction;

        public DialogTimerTask(SIPServerTransaction transaction) {
            this.transaction = transaction;
            this.nRetransmissions = 0;
        }

        protected void runTask() {
            // If I ACK has not been seen on Dialog,
            // resend last response.
            SIPDialog dialog = SIPDialog.this;
            if (sipStack.isLoggingEnabled())
                sipStack.getStackLogger().logDebug("Running dialog timer");
            nRetransmissions++;
            SIPServerTransaction transaction = this.transaction;
            /*
             * Issue 106. Section 13.3.1.4 RFC 3261 The 2xx response is passed to the transport
             * with an interval that starts at T1 seconds and doubles for each retransmission
             * until it reaches T2 seconds If the server retransmits the 2xx response for 64*T1
             * seconds without receiving an ACK, the dialog is confirmed, but the session SHOULD
             * be terminated.
             */

            if (nRetransmissions > 64 * SIPTransaction.T1) {
                if (sipProvider.getSipListener() != null && sipProvider.getSipListener() instanceof SipListenerExt ) {
                    raiseErrorEvent(SIPDialogErrorEvent.DIALOG_ACK_NOT_RECEIVED_TIMEOUT);
                } else  {
                    dialog.delete();
                }
                if (transaction != null
                        && transaction.getState() != javax.sip.TransactionState.TERMINATED) {
                    transaction.raiseErrorEvent(SIPTransactionErrorEvent.TIMEOUT_ERROR);  
                }
            } else if ((!dialog.ackSeen) && (transaction != null)) {
                // Retransmit to 200 until ack receivedialog.
                SIPResponse response = transaction.getLastResponse();
                if (response.getStatusCode() == 200) {
                    try {

                        // resend the last response.
                        if (dialog.toRetransmitFinalResponse(transaction.T2))
                            transaction.sendMessage(response);

                    } catch (IOException ex) {

                        raiseIOException(transaction.getPeerAddress(), transaction.getPeerPort(),
                                transaction.getPeerProtocol());

                    } finally {
                        // Need to fire the timer so
                        // transaction will eventually
                        // time out whether or not
                        // the IOException occurs
                        // Note that this firing also
                        // drives Listener timeout.
                        SIPTransactionStack stack = dialog.sipStack;
                        if (stack.isLoggingEnabled()) {
                            stack.getStackLogger().logDebug("resend 200 response from " + dialog);
                        }
                        transaction.fireTimer();
                    }
                }
            }

            // Stop running this timer if the dialog is in the
            // confirmed state or ack seen if retransmit filter on.
            if (dialog.isAckSeen() || dialog.dialogState == TERMINATED_STATE) {
                this.transaction = null;
                this.cancel();

            }

        }

    }

    /**
     * This timer task is used to garbage collect the dialog after some time.
     * 
     */

    class DialogDeleteTask extends SIPStackTimerTask implements Serializable {

        protected void runTask() {
            delete();
        }

    }
    
    /**
     * This timer task is used to garbage collect the dialog after some time.
     * 
     */

    class DialogDeleteIfNoAckSentTask extends SIPStackTimerTask implements Serializable {
        private long seqno;
   
        public DialogDeleteIfNoAckSentTask(long seqno) {
            this.seqno = seqno;
        }

        protected void runTask() {
            if (SIPDialog.this.highestSequenceNumberAcknowledged < seqno) {  
                /*
                 * Did not send ACK so we need to delete the dialog.
                 * B2BUA NOTE: we may want to send BYE to the Dialog at this 
                 * point. Do we want to make this behavior tailorable?
                 */
            	dialogDeleteIfNoAckSentTask = null;
                if ( !SIPDialog.this.isBackToBackUserAgent) {
                	if (sipStack.isLoggingEnabled())
                		sipStack.getStackLogger().logError("ACK Was not sent. killing dialog");
                	if ( ((SipProviderImpl)sipProvider).getSipListener() instanceof SipListenerExt ){
                	    raiseErrorEvent(SIPDialogErrorEvent.DIALOG_ACK_NOT_SENT_TIMEOUT);
                	} else {
                	    delete();
                	}
                } else {
                	if (sipStack.isLoggingEnabled()) 
                		sipStack.getStackLogger().logError("ACK Was not sent. Sending BYE");
                	   if ( ((SipProviderImpl)sipProvider).getSipListener() instanceof SipListenerExt ){    
                	       raiseErrorEvent(SIPDialogErrorEvent.DIALOG_ACK_NOT_SENT_TIMEOUT);
                	   } else {

                        /*
                         * Send BYE to the Dialog. 
                         * This will be removed for the next spec revision.
                         */
                        try {
                            Request byeRequest = SIPDialog.this.createRequest(Request.BYE);
                            if ( MessageFactoryImpl.getDefaultUserAgentHeader() != null ) {
                                byeRequest.addHeader(MessageFactoryImpl.getDefaultUserAgentHeader());
                            }
                            ReasonHeader reasonHeader = new Reason();
                            reasonHeader.setProtocol("SIP");
                            reasonHeader.setCause(1025);
                            reasonHeader.setText("Timed out waiting to send ACK");
                            byeRequest.addHeader(reasonHeader);
                            ClientTransaction byeCtx = SIPDialog.this.getSipProvider().getNewClientTransaction(byeRequest);
                            SIPDialog.this.sendRequest(byeCtx);
                            return;
                        } catch (Exception ex) {
                            SIPDialog.this.delete();
                        }
                    }
                }
            }
        }

    }

    // ///////////////////////////////////////////////////////////
    // Constructors.
    // ///////////////////////////////////////////////////////////
    /**
     * Protected Dialog constructor.
     */
    private SIPDialog(SipProviderImpl provider) {
        this.terminateOnBye = true;
        this.routeList = new RouteList();
        this.dialogState = NULL_STATE; // not yet initialized.
        localSequenceNumber = 0;
        remoteSequenceNumber = -1;
        this.sipProvider = provider;
        eventListeners = new CopyOnWriteArraySet<SIPDialogEventListener>();
    }
    
    private void recordStackTrace() {
      StringWriter stringWriter = new StringWriter();
      PrintWriter writer = new PrintWriter(stringWriter);
      new Exception().printStackTrace(writer);
       this.stackTrace = stringWriter.getBuffer().toString();
    }

    /**
     * Constructor given the first transaction.
     * 
     * @param transaction is the first transaction.
     */
    public SIPDialog(SIPTransaction transaction) {
        this(transaction.getSipProvider());
       
        SIPRequest sipRequest = (SIPRequest) transaction.getRequest();
        this.callIdHeader = sipRequest.getCallId();
        this.earlyDialogId = sipRequest.getDialogId(false);
        if (transaction == null)
            throw new NullPointerException("Null tx");
        this.sipStack = transaction.sipStack;

        // this.defaultRouter = new DefaultRouter((SipStack) sipStack,
        // sipStack.outboundProxy);

        this.sipProvider = (SipProviderImpl) transaction.getSipProvider();
        if (sipProvider == null)
            throw new NullPointerException("Null Provider!");
        this.addTransaction(transaction);
        if (sipStack.isLoggingEnabled()) {
            sipStack.getStackLogger().logDebug("Creating a dialog : " + this);
            sipStack.getStackLogger().logDebug(
                    "provider port = " + this.sipProvider.getListeningPoint().getPort());
            sipStack.getStackLogger().logStackTrace();
        }
        this.isBackToBackUserAgent = sipStack.isBackToBackUserAgent;
        addEventListener(sipStack);
    }

    /**
     * Constructor given a transaction and a response.
     * 
     * @param transaction -- the transaction ( client/server)
     * @param sipResponse -- response with the appropriate tags.
     */
    public SIPDialog(SIPClientTransaction transaction, SIPResponse sipResponse) {
        this(transaction);
        if (sipResponse == null)
            throw new NullPointerException("Null SipResponse");
        this.setLastResponse(transaction, sipResponse);
        this.isBackToBackUserAgent = sipStack.isBackToBackUserAgent;
    }

    /**
     * create a sip dialog with a response ( no tx)
     */
    public SIPDialog(SipProviderImpl sipProvider, SIPResponse sipResponse) {
        this(sipProvider);
        this.sipStack = (SIPTransactionStack) sipProvider.getSipStack();
        this.setLastResponse(null, sipResponse);
        this.localSequenceNumber = sipResponse.getCSeq().getSeqNumber();
        this.originalLocalSequenceNumber = localSequenceNumber;
        this.myTag = sipResponse.getFrom().getTag();
        this.hisTag = sipResponse.getTo().getTag();
        this.localParty = sipResponse.getFrom().getAddress();
        this.remoteParty = sipResponse.getTo().getAddress();
        this.method = sipResponse.getCSeq().getMethod();
        this.callIdHeader = sipResponse.getCallId();
        this.serverTransactionFlag = false;
        if (sipStack.isLoggingEnabled()) {
            sipStack.getStackLogger().logDebug("Creating a dialog : " + this);
            sipStack.getStackLogger().logStackTrace();
        }
        this.isBackToBackUserAgent = sipStack.isBackToBackUserAgent;
        addEventListener(sipStack);
    }

    // ///////////////////////////////////////////////////////////
    // Private methods
    // ///////////////////////////////////////////////////////////
    /**
     * A debugging print routine.
     */
    private void printRouteList() {
        if (sipStack.isLoggingEnabled()) {
            sipStack.getStackLogger().logDebug("this : " + this);
            sipStack.getStackLogger().logDebug("printRouteList : " + this.routeList.encode());
        }
    }

    /**
     * Return true if this is a client dialog.
     * 
     * @return true if the transaction that created this dialog is a client transaction and false
     *         otherwise.
     */
    private boolean isClientDialog() {
        SIPTransaction transaction = (SIPTransaction) this.getFirstTransaction();
        return transaction instanceof SIPClientTransaction;
    }

    /**
     * Raise an io exception for asyncrhonous retransmission of responses
     * 
     * @param host -- host to where the io was headed
     * @param port -- remote port
     * @param protocol -- protocol (udp/tcp/tls)
     */
    private void raiseIOException(String host, int port, String protocol) {
        // Error occured in retransmitting response.
        // Deliver the error event to the listener
        // Kill the dialog.

        IOExceptionEvent ioError = new IOExceptionEvent(this, host, port, protocol);
        sipProvider.handleEvent(ioError, null);

        setState(SIPDialog.TERMINATED_STATE);
    }
    
    /**
     * Raise a dialog timeout if an ACK has not been sent or received
     * 
     * @param dialogTimeoutError 
     */
    private void raiseErrorEvent(int dialogTimeoutError) {
		// Error event to send to all listeners
		SIPDialogErrorEvent newErrorEvent;
		// Iterator through the list of listeners
		Iterator<SIPDialogEventListener> listenerIterator;
		// Next listener in the list
		SIPDialogEventListener nextListener;

		// Create the error event
		newErrorEvent = new SIPDialogErrorEvent(this, dialogTimeoutError);

		// Loop through all listeners of this transaction
		synchronized (eventListeners) {
			listenerIterator = eventListeners.iterator();
			while (listenerIterator.hasNext()) {
				// Send the event to the next listener
				nextListener = (SIPDialogEventListener) listenerIterator.next();
				nextListener.dialogErrorEvent(newErrorEvent);
			}
		}
		// Clear the event listeners after propagating the error.
		eventListeners.clear();
		// Errors always terminate a dialog except if a timeout has occured because an ACK was not sent or received, then it is the responsibility of the app to terminate
		// the dialog, either by sending a BYE or by calling delete() on the dialog		
		if(dialogTimeoutError != SIPDialogErrorEvent.DIALOG_ACK_NOT_SENT_TIMEOUT &&
		        dialogTimeoutError != SIPDialogErrorEvent.DIALOG_ACK_NOT_RECEIVED_TIMEOUT &&
		        dialogTimeoutError != SIPDialogErrorEvent.DIALOG_REINVITE_TIMEOUT ) {
			delete();
		}
		// we stop the timer in any case
		stopTimer();
	}

    /**
     * Set the remote party for this Dialog.
     * 
     * @param sipMessage -- SIP Message to extract the relevant information from.
     */
    private void setRemoteParty(SIPMessage sipMessage) {

        if (!isServer()) {

            this.remoteParty = sipMessage.getTo().getAddress();
        } else {
            this.remoteParty = sipMessage.getFrom().getAddress();

        }
        if (sipStack.isLoggingEnabled()) {
            sipStack.getStackLogger().logDebug("settingRemoteParty " + this.remoteParty);
        }
    }

    /**
     * Add a route list extracted from a record route list. If this is a server dialog then we
     * assume that the record are added to the route list IN order. If this is a client dialog
     * then we assume that the record route headers give us the route list to add in reverse
     * order.
     * 
     * @param recordRouteList -- the record route list from the incoming message.
     */

    private void addRoute(RecordRouteList recordRouteList) {
        try {
            if (this.isClientDialog()) {
                // This is a client dialog so we extract the record
                // route from the response and reverse its order to
                // careate a route list.
                this.routeList = new RouteList();
                // start at the end of the list and walk backwards

                ListIterator li = recordRouteList.listIterator(recordRouteList.size());
                boolean addRoute = true;
                while (li.hasPrevious()) {
                    RecordRoute rr = (RecordRoute) li.previous();

                    if (addRoute) {
                        Route route = new Route();
                        AddressImpl address = ((AddressImpl) ((AddressImpl) rr.getAddress())
                                .clone());

                        route.setAddress(address);
                        route.setParameters((NameValueList) rr.getParameters().clone());

                        this.routeList.add(route);
                    }
                }
            } else {
                // This is a server dialog. The top most record route
                // header is the one that is closest to us. We extract the
                // route list in the same order as the addresses in the
                // incoming request.
                this.routeList = new RouteList();
                ListIterator li = recordRouteList.listIterator();
                boolean addRoute = true;
                while (li.hasNext()) {
                    RecordRoute rr = (RecordRoute) li.next();

                    if (addRoute) {
                        Route route = new Route();
                        AddressImpl address = ((AddressImpl) ((AddressImpl) rr.getAddress())
                                .clone());
                        route.setAddress(address);
                        route.setParameters((NameValueList) rr.getParameters().clone());
                        routeList.add(route);
                    }
                }
            }
        } finally {
            if (sipStack.getStackLogger().isLoggingEnabled()) {
                Iterator it = routeList.iterator();

                while (it.hasNext()) {
                    SipURI sipUri = (SipURI) (((Route) it.next()).getAddress().getURI());
                    if (!sipUri.hasLrParam()) {                     
                    	if (sipStack.isLoggingEnabled()) {
                    		sipStack.getStackLogger().logWarning(
                                "NON LR route in Route set detected for dialog : " + this);
                        	sipStack.getStackLogger().logStackTrace();
                    	}	
                    }
                }
            }
        }
    }

    /**
     * Add a route list extacted from the contact list of the incoming message.
     * 
     * @param contactList -- contact list extracted from the incoming message.
     * 
     */

    void setRemoteTarget(ContactHeader contact) {
        this.remoteTarget = contact.getAddress();
        if (sipStack.isLoggingEnabled()) {
            sipStack.getStackLogger().logDebug("Dialog.setRemoteTarget: " + this.remoteTarget);
            sipStack.getStackLogger().logStackTrace();
        }

    }

    /**
     * Extract the route information from this SIP Message and add the relevant information to the
     * route set.
     * 
     * @param sipMessage is the SIP message for which we want to add the route.
     */
    private synchronized void addRoute(SIPResponse sipResponse) {

        try {
            if (sipStack.isLoggingEnabled()) {
                sipStack.getStackLogger().logDebug(
                        "setContact: dialogState: " + this + "state = " + this.getState());
            }
            if (sipResponse.getStatusCode() == 100) {
                // Do nothing for trying messages.
                return;
            } else if (this.dialogState == TERMINATED_STATE) {
                // Do nothing if the dialog state is terminated.
                return;
            } else if (this.dialogState == CONFIRMED_STATE) {
                // cannot add route list after the dialog is initialized.
                // Remote target is updated on RE-INVITE but not
                // the route list.
                if (sipResponse.getStatusCode() / 100 == 2 && !this.isServer()) {
                    ContactList contactList = sipResponse.getContactHeaders();
                    if (contactList != null
                            && SIPRequest.isTargetRefresh(sipResponse.getCSeq().getMethod())) {
                        this.setRemoteTarget((ContactHeader) contactList.getFirst());
                    }
                }
                return;
            }

            // Update route list on response if I am a client dialog.
            if (!isServer()) {

                // only update the route set if the dialog is not in the confirmed state.
                if (this.getState() != DialogState.CONFIRMED
                        && this.getState() != DialogState.TERMINATED) {
                    RecordRouteList rrlist = sipResponse.getRecordRouteHeaders();
                    // Add the route set from the incoming response in reverse
                    // order for record route headers.
                    if (rrlist != null) {
                        this.addRoute(rrlist);
                    } else {
                        // Set the rotue list to the last seen route list.
                        this.routeList = new RouteList();
                    }
                }

                ContactList contactList = sipResponse.getContactHeaders();
                if (contactList != null) {
                    this.setRemoteTarget((ContactHeader) contactList.getFirst());
                }
            }

        } finally {
            if (sipStack.isLoggingEnabled()) {
                sipStack.getStackLogger().logStackTrace();
            }
        }
    }

    /**
     * Get a cloned copy of route list for the Dialog.
     * 
     * @return -- a cloned copy of the dialog route list.
     */
    private synchronized RouteList getRouteList() {
        if (sipStack.isLoggingEnabled())
            sipStack.getStackLogger().logDebug("getRouteList " + this);
        // Find the top via in the route list.
        ListIterator li;
        RouteList retval = new RouteList();

        retval = new RouteList();
        if (this.routeList != null) {
            li = routeList.listIterator();
            while (li.hasNext()) {
                Route route = (Route) li.next();
                retval.add((Route) route.clone());
            }
        }

        if (sipStack.isLoggingEnabled()) {
            sipStack.getStackLogger().logDebug("----- ");
            sipStack.getStackLogger().logDebug("getRouteList for " + this);
            if (retval != null)
                sipStack.getStackLogger().logDebug("RouteList = " + retval.encode());
            if (routeList != null)
                sipStack.getStackLogger().logDebug("myRouteList = " + routeList.encode());
            sipStack.getStackLogger().logDebug("----- ");
        }
        return retval;
    }
    
    void setRouteList(RouteList routeList) {
    	this.routeList = routeList;
    }

    /**
     * Sends ACK Request to the remote party of this Dialogue.
     * 
     * 
     * @param request the new ACK Request message to send.
     * @param throwIOExceptionAsSipException - throws SipException if IOEx encountered. Otherwise,
     *        no exception is propagated.
     * @param releaseAckSem - release ack semaphore.
     * @throws SipException if implementation cannot send the ACK Request for any other reason
     * 
     */
    private void sendAck(Request request, boolean throwIOExceptionAsSipException)
            throws SipException {
        SIPRequest ackRequest = (SIPRequest) request;
        if (sipStack.isLoggingEnabled())
            sipStack.getStackLogger().logDebug("sendAck" + this);

        if (!ackRequest.getMethod().equals(Request.ACK))
            throw new SipException("Bad request method -- should be ACK");
        if (this.getState() == null || this.getState().getValue() == EARLY_STATE) {
            if (sipStack.isLoggingEnabled()) {
                sipStack.getStackLogger().logError(
                        "Bad Dialog State for " + this + " dialogID = " + this.getDialogId());
            }
            throw new SipException("Bad dialog state " + this.getState());
        }

        if (!this.getCallId().getCallId().equals(((SIPRequest) request).getCallId().getCallId())) {
            if (sipStack.isLoggingEnabled()) {
                sipStack.getStackLogger().logError("CallID " + this.getCallId());
                sipStack.getStackLogger().logError(
                        "RequestCallID = " + ackRequest.getCallId().getCallId());
                sipStack.getStackLogger().logError("dialog =  " + this);
            }
            throw new SipException("Bad call ID in request");
        }
        try {
            if (sipStack.isLoggingEnabled()) {
                sipStack.getStackLogger().logDebug(
                        "setting from tag For outgoing ACK= " + this.getLocalTag());
                sipStack.getStackLogger().logDebug(
                        "setting To tag for outgoing ACK = " + this.getRemoteTag());
                sipStack.getStackLogger().logDebug("ack = " + ackRequest);
            }
            if (this.getLocalTag() != null)
                ackRequest.getFrom().setTag(this.getLocalTag());
            if (this.getRemoteTag() != null)
                ackRequest.getTo().setTag(this.getRemoteTag());
        } catch (ParseException ex) {
            throw new SipException(ex.getMessage());
        }

        Hop hop = sipStack.getNextHop(ackRequest);
        // Hop hop = defaultRouter.getNextHop(ackRequest);
        if (hop == null)
            throw new SipException("No route!");
        try {
            if (sipStack.isLoggingEnabled())
                sipStack.getStackLogger().logDebug("hop = " + hop);
            ListeningPointImpl lp = (ListeningPointImpl) this.sipProvider.getListeningPoint(hop
                    .getTransport());
            if (lp == null)
                throw new SipException("No listening point for this provider registered at "
                        + hop);
            InetAddress inetAddress = InetAddress.getByName(hop.getHost());
            MessageChannel messageChannel = lp.getMessageProcessor().createMessageChannel(
                    inetAddress, hop.getPort());
            boolean releaseAckSem = false;
            long cseqNo = ((SIPRequest)request).getCSeq().getSeqNumber();
            if (!this.isAckSent(cseqNo)) {
                releaseAckSem = true;
            }

            this.setLastAckSent(ackRequest);
            messageChannel.sendMessage(ackRequest);
            // Sent atleast one ACK.
            this.isAcknowledged = true;
            this.highestSequenceNumberAcknowledged = Math.max(this.highestSequenceNumberAcknowledged,
                    ((SIPRequest)ackRequest).getCSeq().getSeqNumber());
            if (releaseAckSem && this.isBackToBackUserAgent) {
                this.releaseAckSem();
            } else {
                if ( sipStack.isLoggingEnabled() ) {
                    sipStack.getStackLogger().logDebug("Not releasing ack sem for " + this + " isAckSent " + releaseAckSem );
                }
            }
        } catch (IOException ex) {
            if (throwIOExceptionAsSipException)
                throw new SipException("Could not send ack", ex);
            this.raiseIOException(hop.getHost(), hop.getPort(), hop.getTransport());
        } catch (SipException ex) {
            if (sipStack.isLoggingEnabled())
                sipStack.getStackLogger().logException(ex);
            throw ex;
        } catch (Exception ex) {
            if (sipStack.isLoggingEnabled())
                sipStack.getStackLogger().logException(ex);
            throw new SipException("Could not create message channel", ex);
        }
        if (this.dialogDeleteTask != null) {
            this.dialogDeleteTask.cancel();
            this.dialogDeleteTask = null;
        }
        this.ackSeen = true;

    }

    // /////////////////////////////////////////////////////////////
    // Package local methods
    // /////////////////////////////////////////////////////////////

    /**
     * Set the stack address. Prevent us from routing messages to ourselves.
     * 
     * @param sipStack the address of the SIP stack.
     * 
     */
    void setStack(SIPTransactionStack sipStack) {
        this.sipStack = sipStack;

    }

    /**
     * Get the stack .
     * 
     * @return sipStack the SIP stack of the dialog.
     * 
     */
    SIPTransactionStack getStack() {
        return sipStack;
    }

    /**
     * Return True if this dialog is terminated on BYE.
     * 
     */
    boolean isTerminatedOnBye() {

        return this.terminateOnBye;
    }

    /**
     * Mark that the dialog has seen an ACK.
     */
    void ackReceived(SIPRequest sipRequest) {

        // Suppress retransmission of the final response
        if (this.ackSeen)
            return;
        SIPServerTransaction tr = this.getInviteTransaction();
        if (tr != null) {
            if (tr.getCSeq() == sipRequest.getCSeq().getSeqNumber()) {
            	acquireTimerTaskSem();
            	try {
	                if (this.timerTask != null) {                	                	
	                	this.timerTask.cancel();
		                this.timerTask = null;                	
	                }
            	} finally {
            		releaseTimerTaskSem();
            	}
                this.ackSeen = true;
                if (this.dialogDeleteTask != null) {
                    this.dialogDeleteTask.cancel();
                    this.dialogDeleteTask = null;
                }
                this.setLastAckReceived(sipRequest);
                if (sipStack.isLoggingEnabled()) {
                    sipStack.getStackLogger().logDebug(
                            "ackReceived for " + ((SIPTransaction) tr).getMethod());
                    this.ackLine = sipStack.getStackLogger().getLineCount();
                    this.printDebugInfo();
                }
                if (this.isBackToBackUserAgent) {
                    this.releaseAckSem();
                }
                this.setState(CONFIRMED_STATE);
            }
        }
    }

    /**
     * Return true if a terminated event was delivered to the application as a result of the
     * dialog termination.
     * 
     */
    synchronized boolean testAndSetIsDialogTerminatedEventDelivered() {
        boolean retval = this.dialogTerminatedEventDelivered;
        this.dialogTerminatedEventDelivered = true;
        return retval;
    }

    // /////////////////////////////////////////////////////////
    // Public methods
    // /////////////////////////////////////////////////////////

    /**
	 * Adds a new event listener to this dialog.
	 * 
	 * @param newListener
	 *            Listener to add.
	 */
	public void addEventListener(SIPDialogEventListener newListener) {
		eventListeners.add(newListener);
	}

	/**
	 * Removed an event listener from this dialog.
	 * 
	 * @param oldListener
	 *            Listener to remove.
	 */
	public void removeEventListener(SIPDialogEventListener oldListener) {
		eventListeners.remove(oldListener);
	}
    
    /*
     * @see javax.sip.Dialog#setApplicationData()
     */
    public void setApplicationData(Object applicationData) {
        this.applicationData = applicationData;
    }

    /*
     * (non-Javadoc)
     * 
     * @see javax.sip.Dialog#getApplicationData()
     */
    public Object getApplicationData() {
        return this.applicationData;
    }

    /**
     * Updates the next consumable seqno.
     * 
     */
    public synchronized void requestConsumed() {
        this.nextSeqno = Long.valueOf(this.getRemoteSeqNumber() + 1);

        if (sipStack.isLoggingEnabled()) {
            this.sipStack.getStackLogger().logDebug(
                    "Request Consumed -- next consumable Request Seqno = " + this.nextSeqno);
        }

    }

    /**
     * Return true if this request can be consumed by the dialog.
     * 
     * @param dialogRequest is the request to check with the dialog.
     * @return true if the dialogRequest sequence number matches the next consumable seqno.
     */
    public synchronized boolean isRequestConsumable(SIPRequest dialogRequest) {
        // have not yet set remote seqno - this is a fresh
        if (dialogRequest.getMethod().equals(Request.ACK))
            throw new RuntimeException("Illegal method");

        // For loose validation this function is delegated to the application
        if (!this.isSequnceNumberValidation()) {
            return true;
        }

        // JvB: Acceptable iff remoteCSeq < cseq. remoteCSeq==-1
        // when not defined yet, so that works too
        return remoteSequenceNumber < dialogRequest.getCSeq().getSeqNumber();
    }

    /**
     * This method is called when a forked dialog is created from the client side. It starts a
     * timer task. If the timer task expires before an ACK is sent then the dialog is cancelled
     * (i.e. garbage collected ).
     * 
     */
    public void doDeferredDelete() {
        if (sipStack.getTimer() == null)
            this.setState(TERMINATED_STATE);
        else {
            this.dialogDeleteTask = new DialogDeleteTask();
            // Delete the transaction after the max ack timeout.
            sipStack.getTimer().schedule(this.dialogDeleteTask,
                    SIPTransaction.TIMER_H * SIPTransactionStack.BASE_TIMER_INTERVAL);
        }

    }

    /**
     * Set the state for this dialog.
     * 
     * @param state is the state to set for the dialog.
     */

    public void setState(int state) {
        if (sipStack.isLoggingEnabled()) {
            sipStack.getStackLogger().logDebug(
                    "Setting dialog state for " + this + "newState = " + state);
            sipStack.getStackLogger().logStackTrace();
            if (state != NULL_STATE && state != this.dialogState)
                if (sipStack.isLoggingEnabled()) {
                    sipStack.getStackLogger().logDebug(
                            this + "  old dialog state is " + this.getState());
                    sipStack.getStackLogger().logDebug(
                            this + "  New dialog state is " + DialogState.getObject(state));
                }

        }
        this.dialogState = state;
        // Dialog is in terminated state set it up for GC.
        if (state == TERMINATED_STATE) {
            if (sipStack.getTimer() != null) { // may be null after shutdown
                sipStack.getTimer().schedule(new LingerTimer(), DIALOG_LINGER_TIME * 1000);
            }
            this.stopTimer();

        }
    }

    /**
     * Debugging print for the dialog.
     */
    public void printDebugInfo() {
        if (sipStack.isLoggingEnabled()) {
            sipStack.getStackLogger().logDebug("isServer = " + isServer());
            sipStack.getStackLogger().logDebug("localTag = " + getLocalTag());
            sipStack.getStackLogger().logDebug("remoteTag = " + getRemoteTag());
            sipStack.getStackLogger().logDebug("localSequenceNumer = " + getLocalSeqNumber());
            sipStack.getStackLogger().logDebug("remoteSequenceNumer = " + getRemoteSeqNumber());
            sipStack.getStackLogger().logDebug("ackLine:" + this.getRemoteTag() + " " + ackLine);
        }
    }

    /**
     * Return true if the dialog has already seen the ack.
     * 
     * @return flag that records if the ack has been seen.
     */
    public boolean isAckSeen() {
        return this.ackSeen;
    }

    /**
     * Get the last ACK for this transaction.
     */
    public SIPRequest getLastAckSent() {
        return this.lastAckSent;
    }

    /**
     * Return true if ACK was sent ( for client tx ). For server tx, this is a NO-OP ( we dont
     * send ACK).
     */
    public boolean isAckSent(long cseqNo) {
        if (this.getLastTransaction() == null)
            return true;
        if (this.getLastTransaction() instanceof ClientTransaction) {
            if (this.getLastAckSent() == null) {
                return false;
            } else {
                return cseqNo <=((SIPRequest) this.getLastAckSent()).getCSeq().getSeqNumber();
            }
        } else {
            return true;
        }
    }

    /**
     * Get the transaction that created this dialog.
     */
    public Transaction getFirstTransaction() {
        return this.firstTransaction;
    }


    /**
     * Gets the route set for the dialog. When acting as an User Agent Server the route set MUST
     * be set to the list of URIs in the Record-Route header field from the request, taken in
     * order and preserving all URI parameters. When acting as an User Agent Client the route set
     * MUST be set to the list of URIs in the Record-Route header field from the response, taken
     * in reverse order and preserving all URI parameters. If no Record-Route header field is
     * present in the request or response, the route set MUST be set to the empty set. This route
     * set, even if empty, overrides any pre-existing route set for future requests in this
     * dialog.
     * <p>
     * Requests within a dialog MAY contain Record-Route and Contact header fields. However, these
     * requests do not cause the dialog's route set to be modified.
     * <p>
     * The User Agent Client uses the remote target and route set to build the Request-URI and
     * Route header field of the request.
     * 
     * @return an Iterator containing a list of route headers to be used for forwarding. Empty
     *         iterator is returned if route has not been established.
     */
    public Iterator getRouteSet() {
        if (this.routeList == null) {
            return new LinkedList().listIterator();
        } else {
            return this.getRouteList().listIterator();
        }
    }

    /**
     * Add a Route list extracted from a SIPRequest to this Dialog.
     * 
     * @param sipRequest
     */
    public synchronized void addRoute(SIPRequest sipRequest) {
        if (sipStack.isLoggingEnabled()) {
            sipStack.getStackLogger().logDebug(
                    "setContact: dialogState: " + this + "state = " + this.getState());
        }

        if (this.dialogState == CONFIRMED_STATE
                && SIPRequest.isTargetRefresh(sipRequest.getMethod())) {
            this.doTargetRefresh(sipRequest);
        }
        if (this.dialogState == CONFIRMED_STATE || this.dialogState == TERMINATED_STATE) {
            return;
        }
        
        // Fix for issue #225: mustn't learn Route set from mid-dialog requests
        if ( sipRequest.getToTag()!=null ) return;
        
        // Incoming Request has the route list
        RecordRouteList rrlist = sipRequest.getRecordRouteHeaders();
        // Add the route set from the incoming response in reverse
        // order
        if (rrlist != null) {
            this.addRoute(rrlist);
        } else {
            // Set the rotue list to the last seen route list.
            this.routeList = new RouteList();
        }

        // put the contact header from the incoming request into
        // the route set. JvB: some duplication here, ref. doTargetRefresh
        ContactList contactList = sipRequest.getContactHeaders();
        if (contactList != null) {
            this.setRemoteTarget((ContactHeader) contactList.getFirst());
        }
    }

    /**
     * Set the dialog identifier.
     */
    public void setDialogId(String dialogId) {
        this.dialogId = dialogId;
    }

    /**
     * Creates a new dialog based on a received NOTIFY. The dialog state is initialized
     * appropriately. The NOTIFY differs in the From tag
     * 
     * Made this a separate method to clearly distinguish what's happening here - this is a
     * non-trivial case
     * 
     * @param subscribeTx - the transaction started with the SUBSCRIBE that we sent
     * @param notifyST - the ServerTransaction created for an incoming NOTIFY
     * @return -- a new dialog created from the subscribe original SUBSCRIBE transaction.
     * 
     * 
     */
    public static SIPDialog createFromNOTIFY(SIPClientTransaction subscribeTx,
            SIPTransaction notifyST) {
        SIPDialog d = new SIPDialog(notifyST);
        //
        // The above sets d.firstTransaction to NOTIFY (ST), correct that
        //
        d.serverTransactionFlag = false;
        // they share this one
        d.lastTransaction = subscribeTx;
        storeFirstTransactionInfo(d, subscribeTx);
        d.terminateOnBye = false;
        d.localSequenceNumber = subscribeTx.getCSeq();
        SIPRequest not = (SIPRequest) notifyST.getRequest();
        d.remoteSequenceNumber = not.getCSeq().getSeqNumber();
        d.setDialogId(not.getDialogId(true));
        d.setLocalTag(not.getToTag());
        d.setRemoteTag(not.getFromTag());
        // to properly create the Dialog object.
        // If not the stack will throw an exception when creating the response.
        d.setLastResponse(subscribeTx, subscribeTx.getLastResponse());

        // Dont use setLocal / setRemote here, they make other assumptions
        d.localParty = not.getTo().getAddress();
        d.remoteParty = not.getFrom().getAddress();

        // initialize d's route set based on the NOTIFY. Any proxies must have
        // Record-Routed
        d.addRoute(not);
        d.setState(CONFIRMED_STATE); // set state, *after* setting route set!
        return d;
    }

    /**
     * Return true if is server.
     * 
     * @return true if is server transaction created this dialog.
     */
    public boolean isServer() {
        if (this.firstTransactionSeen == false)
            return this.serverTransactionFlag;
        else
            return this.firstTransactionIsServerTransaction;

    }

    /**
     * Return true if this is a re-establishment of the dialog.
     * 
     * @return true if the reInvite flag is set.
     */
    protected boolean isReInvite() {
        return this.reInviteFlag;
    }

    /**
     * Get the id for this dialog.
     * 
     * @return the string identifier for this dialog.
     * 
     */
    public String getDialogId() {

        if (this.dialogId == null && this.lastResponse != null)
            this.dialogId = this.lastResponse.getDialogId(isServer());

        return this.dialogId;
    }

    private static void storeFirstTransactionInfo(SIPDialog dialog, SIPTransaction transaction) {
    	dialog.firstTransaction = transaction;
    	dialog.firstTransactionSeen = true;
    	dialog.firstTransactionIsServerTransaction = transaction.isServerTransaction(); 
    	dialog.firstTransactionSecure = transaction.getRequest().getRequestURI().getScheme()
        	.equalsIgnoreCase("sips");
    	dialog.firstTransactionPort = transaction.getPort();
    	dialog.firstTransactionId = transaction.getBranchId();
    	dialog.firstTransactionMethod = transaction.getMethod();
    	
        if (dialog.isServer()) {
            SIPServerTransaction st = (SIPServerTransaction) transaction;
            SIPResponse response = st.getLastResponse();
            dialog.contactHeader = response != null ? response.getContactHeader() : null;
        } else {
            SIPClientTransaction ct = (SIPClientTransaction) transaction;
            if (ct != null){
            	SIPRequest sipRequest = ct.getOriginalRequest();
            	dialog.contactHeader = sipRequest.getContactHeader();
            }
        }
    }
    /**
     * Add a transaction record to the dialog.
     * 
     * @param transaction is the transaction to add to the dialog.
     */
    public void addTransaction(SIPTransaction transaction) {

        SIPRequest sipRequest = (SIPRequest) transaction.getOriginalRequest();

        // Proessing a re-invite.
        if (firstTransactionSeen && !firstTransactionId.equals(transaction.getBranchId()) 
                && transaction.getMethod().equals(firstTransactionMethod)) {
            this.reInviteFlag = true;
        }

        if (firstTransactionSeen == false) {
            // Record the local and remote sequenc
            // numbers and the from and to tags for future
            // use on this dialog.
        	storeFirstTransactionInfo(this, transaction);
            if (sipRequest.getMethod().equals(Request.SUBSCRIBE))
                this.eventHeader = (EventHeader) sipRequest.getHeader(EventHeader.NAME);

            this.setLocalParty(sipRequest);
            this.setRemoteParty(sipRequest);
            this.setCallId(sipRequest);
            if (this.originalRequest == null) {
                this.originalRequest = sipRequest;
            }
            if (this.method == null) {
                this.method = sipRequest.getMethod();
            }

            if (transaction instanceof SIPServerTransaction) {
                this.hisTag = sipRequest.getFrom().getTag();
                // My tag is assigned when sending response
            } else {
                setLocalSequenceNumber(sipRequest.getCSeq().getSeqNumber());
                this.originalLocalSequenceNumber = localSequenceNumber;
                this.myTag = sipRequest.getFrom().getTag();
                if (myTag == null)
                	if (sipStack.isLoggingEnabled())
                		sipStack.getStackLogger().logError(
                            "The request's From header is missing the required Tag parameter.");
            }
        } else if (transaction.getMethod().equals(firstTransactionMethod)
                && firstTransactionIsServerTransaction != transaction.isServerTransaction()) {
            // This case occurs when you are processing a re-invite.
            // Switch from client side to server side for re-invite
            // (put the other side on hold).
        	
			storeFirstTransactionInfo(this, transaction);
			
            this.setLocalParty(sipRequest);
            this.setRemoteParty(sipRequest);
            this.setCallId(sipRequest);
            this.originalRequest = sipRequest;
            this.method = sipRequest.getMethod();

        }
        if (transaction instanceof SIPServerTransaction)
            setRemoteSequenceNumber(sipRequest.getCSeq().getSeqNumber());

        // If this is a server transaction record the remote
        // sequence number to avoid re-processing of requests
        // with the same sequence number directed towards this
        // dialog.

        this.lastTransaction = transaction;
        // set a back ptr in the incoming dialog.
        // CHECKME -- why is this here?
        // transaction.setDialog(this,sipRequest);
        if (sipStack.isLoggingEnabled()) {
            sipStack.getStackLogger()
                    .logDebug("Transaction Added " + this + myTag + "/" + hisTag);
            sipStack.getStackLogger().logDebug(
                    "TID = " + transaction.getTransactionId() + "/"
                            + transaction.isServerTransaction());
            sipStack.getStackLogger().logStackTrace();
        }
    }

    /**
     * Set the remote tag.
     * 
     * @param hisTag is the remote tag to set.
     */
    private void setRemoteTag(String hisTag) {
        if (sipStack.isLoggingEnabled()) {
            sipStack.getStackLogger().logDebug(
                    "setRemoteTag(): " + this + " remoteTag = " + this.hisTag + " new tag = "
                            + hisTag);
        }
        if (this.hisTag != null && hisTag != null && !hisTag.equals(this.hisTag)) {
            if (this.getState() != DialogState.EARLY) {
            	if (sipStack.isLoggingEnabled())
            		sipStack.getStackLogger().logDebug(
                        "Dialog is already established -- ignoring remote tag re-assignment");
                return;
            } else if (sipStack.isRemoteTagReassignmentAllowed()) {
            	if (sipStack.isLoggingEnabled())
            		sipStack.getStackLogger().logDebug(
                        "UNSAFE OPERATION !  tag re-assignment " + this.hisTag
                                + " trying to set to " + hisTag
                                + " can cause unexpected effects ");
                boolean removed = false;
                if (this.sipStack.getDialog(dialogId) == this) {
                    this.sipStack.removeDialog(dialogId);
                    removed = true;

                }
                // Force recomputation of Dialog ID;
                this.dialogId = null;
                this.hisTag = hisTag;
                if (removed) {
                	if (sipStack.isLoggingEnabled())
                		sipStack.getStackLogger().logDebug("ReInserting Dialog");
                    this.sipStack.putDialog(this);
                }
            }
        } else {
            if (hisTag != null) {
                this.hisTag = hisTag;
            } else {
            	if (sipStack.isLoggingEnabled())
            		sipStack.getStackLogger().logWarning("setRemoteTag : called with null argument ");
            }
        }
    }

    /**
     * Get the last transaction from the dialog.
     */
    public SIPTransaction getLastTransaction() {
        return this.lastTransaction;
    }

    /**
     * Get the INVITE transaction (null if no invite transaction).
     */
    public SIPServerTransaction getInviteTransaction() {
        DialogTimerTask t = this.timerTask;
        if (t != null)
            return t.transaction;
        else
            return null;
    }

    /**
     * Set the local sequece number for the dialog (defaults to 1 when the dialog is created).
     * 
     * @param lCseq is the local cseq number.
     * 
     */
    private void setLocalSequenceNumber(long lCseq) {
        if (sipStack.isLoggingEnabled())
            sipStack.getStackLogger().logDebug(
                    "setLocalSequenceNumber: original  " + this.localSequenceNumber + " new  = "
                            + lCseq);
        if (lCseq <= this.localSequenceNumber)
            throw new RuntimeException("Sequence number should not decrease !");
        this.localSequenceNumber = lCseq;
    }

    /**
     * Set the remote sequence number for the dialog.
     * 
     * @param rCseq is the remote cseq number.
     * 
     */
    public void setRemoteSequenceNumber(long rCseq) {
        if (sipStack.isLoggingEnabled())
            sipStack.getStackLogger().logDebug("setRemoteSeqno " + this + "/" + rCseq);
        this.remoteSequenceNumber = rCseq;
    }

    /**
     * Increment the local CSeq # for the dialog. This is useful for if you want to create a hole
     * in the sequence number i.e. route a request outside the dialog and then resume within the
     * dialog.
     */
    public void incrementLocalSequenceNumber() {
        ++this.localSequenceNumber;
    }

    /**
     * Get the remote sequence number (for cseq assignment of outgoing requests within this
     * dialog).
     * 
     * @deprecated
     * @return local sequence number.
     */

    public int getRemoteSequenceNumber() {
        return (int) this.remoteSequenceNumber;
    }

    /**
     * Get the local sequence number (for cseq assignment of outgoing requests within this
     * dialog).
     * 
     * @deprecated
     * @return local sequence number.
     */

    public int getLocalSequenceNumber() {
        return (int) this.localSequenceNumber;
    }

    /**
     * Get the sequence number for the request that origianlly created the Dialog.
     * 
     * @return -- the original starting sequence number for this dialog.
     */
    public long getOriginalLocalSequenceNumber() {
        return this.originalLocalSequenceNumber;
    }

    /*
     * (non-Javadoc)
     * 
     * @see javax.sip.Dialog#getLocalSequenceNumberLong()
     */
    public long getLocalSeqNumber() {
        return this.localSequenceNumber;
    }

    /*
     * (non-Javadoc)
     * 
     * @see javax.sip.Dialog#getRemoteSequenceNumberLong()
     */
    public long getRemoteSeqNumber() {
        return this.remoteSequenceNumber;
    }

    /*
     * (non-Javadoc)
     * 
     * @see javax.sip.Dialog#getLocalTag()
     */
    public String getLocalTag() {
        return this.myTag;
    }

    /*
     * (non-Javadoc)
     * 
     * @see javax.sip.Dialog#getRemoteTag()
     */
    public String getRemoteTag() {

        return hisTag;
    }

    /**
     * Set local tag for the transaction.
     * 
     * @param mytag is the tag to use in From headers client transactions that belong to this
     *        dialog and for generating To tags for Server transaction requests that belong to
     *        this dialog.
     */
    private void setLocalTag(String mytag) {
        if (sipStack.isLoggingEnabled()) {
            sipStack.getStackLogger().logDebug("set Local tag " + mytag + " " + this.dialogId);
            sipStack.getStackLogger().logStackTrace();
        }

        this.myTag = mytag;

    }

    /*
     * (non-Javadoc)
     * 
     * @see javax.sip.Dialog#delete()
     */

    public void delete() {
        // the reaper will get him later.
        this.setState(TERMINATED_STATE);
    }

    /*
     * (non-Javadoc)
     * 
     * @see javax.sip.Dialog#getCallId()
     */
    public CallIdHeader getCallId() {
        return this.callIdHeader;
    }

    /**
     * set the call id header for this dialog.
     */
    private void setCallId(SIPRequest sipRequest) {
        this.callIdHeader = sipRequest.getCallId();
    }

    /*
     * (non-Javadoc)
     * 
     * @see javax.sip.Dialog#getLocalParty()
     */

    public javax.sip.address.Address getLocalParty() {
        return this.localParty;
    }

    private void setLocalParty(SIPMessage sipMessage) {
        if (!isServer()) {
            this.localParty = sipMessage.getFrom().getAddress();
        } else {
            this.localParty = sipMessage.getTo().getAddress();
        }
    }

    /**
     * Returns the Address identifying the remote party. This is the value of the To header of
     * locally initiated requests in this dialogue when acting as an User Agent Client.
     * <p>
     * This is the value of the From header of recieved responses in this dialogue when acting as
     * an User Agent Server.
     * 
     * @return the address object of the remote party.
     */
    public javax.sip.address.Address getRemoteParty() {

        if (sipStack.isLoggingEnabled()) {
            sipStack.getStackLogger().logDebug("gettingRemoteParty " + this.remoteParty);
        }
        return this.remoteParty;

    }

    /*
     * (non-Javadoc)
     * 
     * @see javax.sip.Dialog#getRemoteTarget()
     */
    public javax.sip.address.Address getRemoteTarget() {

        return this.remoteTarget;
    }

    /*
     * (non-Javadoc)
     * 
     * @see javax.sip.Dialog#getState()
     */
    public DialogState getState() {
        if (this.dialogState == NULL_STATE)
            return null; // not yet initialized
        return DialogState.getObject(this.dialogState);
    }

    /**
     * Returns true if this Dialog is secure i.e. if the request arrived over TLS, and the
     * Request-URI contained a SIPS URI, the "secure" flag is set to TRUE.
     * 
     * @return <code>true</code> if this dialogue was established using a sips URI over TLS, and
     *         <code>false</code> otherwise.
     */
    public boolean isSecure() {
        return this.firstTransactionSecure;
    }

    /*
     * (non-Javadoc)
     * 
     * @see javax.sip.Dialog#sendAck(javax.sip.message.Request)
     */
    public void sendAck(Request request) throws SipException {
        this.sendAck(request, true);
    }

    /*
     * (non-Javadoc)
     * 
     * @see javax.sip.Dialog#createRequest(java.lang.String)
     */
    public Request createRequest(String method) throws SipException {

        if (method.equals(Request.ACK) || method.equals(Request.PRACK)) {
            throw new SipException("Invalid method specified for createRequest:" + method);
        }
        if (lastResponse != null)
            return this.createRequest(method, this.lastResponse);
        else
            throw new SipException("Dialog not yet established -- no response!");
    }

    /**
     * The method that actually does the work of creating a request.
     * 
     * @param method
     * @param response
     * @return
     * @throws SipException
     */
    private Request createRequest(String method, SIPResponse sipResponse) throws SipException {
        /*
         * Check if the dialog is in the right state (RFC 3261 section 15). The caller's UA MAY
         * send a BYE for either CONFIRMED or EARLY dialogs, and the callee's UA MAY send a BYE on
         * CONFIRMED dialogs, but MUST NOT send a BYE on EARLY dialogs.
         * 
         * Throw out cancel request.
         */

        if (method == null || sipResponse == null)
            throw new NullPointerException("null argument");

        if (method.equals(Request.CANCEL))
            throw new SipException("Dialog.createRequest(): Invalid request");

        if (this.getState() == null
                || (this.getState().getValue() == TERMINATED_STATE && !method
                        .equalsIgnoreCase(Request.BYE))
                || (this.isServer() && this.getState().getValue() == EARLY_STATE && method
                        .equalsIgnoreCase(Request.BYE)))
            throw new SipException("Dialog  " + getDialogId()
                    + " not yet established or terminated " + this.getState());

        SipUri sipUri = null;
        if (this.getRemoteTarget() != null)
            sipUri = (SipUri) this.getRemoteTarget().getURI().clone();
        else {
            sipUri = (SipUri) this.getRemoteParty().getURI().clone();
            sipUri.clearUriParms();
        }

        CSeq cseq = new CSeq();
        try {
            cseq.setMethod(method);
            cseq.setSeqNumber(this.getLocalSeqNumber());
        } catch (Exception ex) {
        	if (sipStack.isLoggingEnabled())
        		sipStack.getStackLogger().logError("Unexpected error");
            InternalErrorHandler.handleException(ex);
        }
        /*
         * Add a via header for the outbound request based on the transport of the message
         * processor.
         */

        ListeningPointImpl lp = (ListeningPointImpl) this.sipProvider
                .getListeningPoint(sipResponse.getTopmostVia().getTransport());
        if (lp == null) {
            if (sipStack.isLoggingEnabled())
                sipStack.getStackLogger().logError(
                        "Cannot find listening point for transport "
                                + sipResponse.getTopmostVia().getTransport());
            throw new SipException("Cannot find listening point for transport "
                    + sipResponse.getTopmostVia().getTransport());
        }
        Via via = lp.getViaHeader();

        From from = new From();
        from.setAddress(this.localParty);
        To to = new To();
        to.setAddress(this.remoteParty);
        SIPRequest sipRequest = sipResponse.createRequest(sipUri, via, cseq, from, to);

        /*
         * The default contact header is obtained from the provider. The application can override
         * this.
         * 
         * JvB: Should only do this for target refresh requests, ie not for BYE, PRACK, etc
         */

        if (SIPRequest.isTargetRefresh(method)) {
            ContactHeader contactHeader = ((ListeningPointImpl) this.sipProvider
                    .getListeningPoint(lp.getTransport())).createContactHeader();

            ((SipURI) contactHeader.getAddress().getURI()).setSecure(this.isSecure());
            sipRequest.setHeader(contactHeader);
        }

        try {
            /*
             * Guess of local sequence number - this is being re-set when the request is actually
             * dispatched
             */
            cseq = (CSeq) sipRequest.getCSeq();
            cseq.setSeqNumber(this.localSequenceNumber + 1);

        } catch (InvalidArgumentException ex) {
            InternalErrorHandler.handleException(ex);
        }

        if (method.equals(Request.SUBSCRIBE)) {

            if (eventHeader != null)
                sipRequest.addHeader(eventHeader);

        }

        /*
         * RFC3261, section 12.2.1.1:
         * 
         * The URI in the To field of the request MUST be set to the remote URI from the dialog
         * state. The tag in the To header field of the request MUST be set to the remote tag of
         * the dialog ID. The From URI of the request MUST be set to the local URI from the dialog
         * state. The tag in the From header field of the request MUST be set to the local tag of
         * the dialog ID. If the value of the remote or local tags is null, the tag parameter MUST
         * be omitted from the To or From header fields, respectively.
         */

        try {
            if (this.getLocalTag() != null) {
                from.setTag(this.getLocalTag());
            } else {
                from.removeTag();
            }
            if (this.getRemoteTag() != null) {
                to.setTag(this.getRemoteTag());
            } else {
                to.removeTag();
            }
        } catch (ParseException ex) {
            InternalErrorHandler.handleException(ex);
        }

        // get the route list from the dialog.
        this.updateRequest(sipRequest);

        return sipRequest;

    }

    /*
     * (non-Javadoc)
     * 
     * @see javax.sip.Dialog#sendRequest(javax.sip.ClientTransaction)
     */

    public void sendRequest(ClientTransaction clientTransactionId)
            throws TransactionDoesNotExistException, SipException {
        this.sendRequest(clientTransactionId, !this.isBackToBackUserAgent);
    }

    public void sendRequest(ClientTransaction clientTransactionId, boolean allowInterleaving)
            throws TransactionDoesNotExistException, SipException {

        if ( (!allowInterleaving)
                && clientTransactionId.getRequest().getMethod().equals(Request.INVITE)) {
            new Thread((new ReInviteSender(clientTransactionId))).start();
            return;
        }

        SIPRequest dialogRequest = ((SIPClientTransaction) clientTransactionId)
                .getOriginalRequest();

        if (sipStack.isLoggingEnabled())
            sipStack.getStackLogger().logDebug(
                    "dialog.sendRequest " + " dialog = " + this + "\ndialogRequest = \n"
                            + dialogRequest);

        if (clientTransactionId == null)
            throw new NullPointerException("null parameter");

        if (dialogRequest.getMethod().equals(Request.ACK)
                || dialogRequest.getMethod().equals(Request.CANCEL))
            throw new SipException("Bad Request Method. " + dialogRequest.getMethod());

        // JvB: added, allow re-sending of BYE after challenge
        if (byeSent && isTerminatedOnBye() && !dialogRequest.getMethod().equals(Request.BYE)) {
            if (sipStack.isLoggingEnabled())
                sipStack.getStackLogger().logError("BYE already sent for " + this);
            throw new SipException("Cannot send request; BYE already sent");
        }

        if (dialogRequest.getTopmostVia() == null) {
            Via via = ((SIPClientTransaction) clientTransactionId).getOutgoingViaHeader();
            dialogRequest.addHeader(via);
        }
        if (!this.getCallId().getCallId().equalsIgnoreCase(dialogRequest.getCallId().getCallId())) {

            if (sipStack.isLoggingEnabled()) {
                sipStack.getStackLogger().logError("CallID " + this.getCallId());
                sipStack.getStackLogger().logError(
                        "RequestCallID = " + dialogRequest.getCallId().getCallId());
                sipStack.getStackLogger().logError("dialog =  " + this);
            }
            throw new SipException("Bad call ID in request");
        }

        // Set the dialog back pointer.
        ((SIPClientTransaction) clientTransactionId).setDialog(this, this.dialogId);

        this.addTransaction((SIPTransaction) clientTransactionId);
        // Enable the retransmission filter for the transaction

        ((SIPClientTransaction) clientTransactionId).isMapped = true;

        From from = (From) dialogRequest.getFrom();
        To to = (To) dialogRequest.getTo();

        // Caller already did the tag assignment -- check to see if the
        // tag assignment is OK.
        if (this.getLocalTag() != null && from.getTag() != null
                && !from.getTag().equals(this.getLocalTag()))
            throw new SipException("From tag mismatch expecting  " + this.getLocalTag());

        if (this.getRemoteTag() != null && to.getTag() != null
                && !to.getTag().equals(this.getRemoteTag())) {
        	if (sipStack.isLoggingEnabled())
        		this.sipStack.getStackLogger().logWarning(
                    "To header tag mismatch expecting " + this.getRemoteTag());
        }
        /*
         * The application is sending a NOTIFY before sending the response of the dialog.
         */
        if (this.getLocalTag() == null && dialogRequest.getMethod().equals(Request.NOTIFY)) {
            if (!this.getMethod().equals(Request.SUBSCRIBE))
                throw new SipException("Trying to send NOTIFY without SUBSCRIBE Dialog!");
            this.setLocalTag(from.getTag());

        }

        try {
            if (this.getLocalTag() != null)
                from.setTag(this.getLocalTag());
            if (this.getRemoteTag() != null)
                to.setTag(this.getRemoteTag());

        } catch (ParseException ex) {

            InternalErrorHandler.handleException(ex);

        }

        Hop hop = ((SIPClientTransaction) clientTransactionId).getNextHop();
        if (sipStack.isLoggingEnabled()) {
            sipStack.getStackLogger().logDebug(
                    "Using hop = " + hop.getHost() + " : " + hop.getPort());
        }

        try {
            MessageChannel messageChannel = sipStack.createRawMessageChannel(this
                    .getSipProvider().getListeningPoint(hop.getTransport()).getIPAddress(),
                    this.firstTransactionPort, hop);
            
            MessageChannel oldChannel = ((SIPClientTransaction) 
            		clientTransactionId).getMessageChannel();

            // Remove this from the connection cache if it is in the
            // connection
            // cache and is not yet active.
            oldChannel.uncache();

            // Not configured to cache client connections.
            if (!sipStack.cacheClientConnections) {
                oldChannel.useCount--;
                if (sipStack.isLoggingEnabled())
                    sipStack.getStackLogger().logDebug(
                            "oldChannel: useCount " + oldChannel.useCount);

            }

            if (messageChannel == null) {
                /*
                 * At this point the procedures of 8.1.2 and 12.2.1.1 of RFC3261 have been tried
                 * but the resulting next hop cannot be resolved (recall that the exception thrown
                 * is caught and ignored in SIPStack.createMessageChannel() so we end up here with
                 * a null messageChannel instead of the exception handler below). All else
                 * failing, try the outbound proxy in accordance with 8.1.2, in particular: This
                 * ensures that outbound proxies that do not add Record-Route header field values
                 * will drop out of the path of subsequent requests. It allows endpoints that
                 * cannot resolve the first Route URI to delegate that task to an outbound proxy.
                 * 
                 * if one considers the 'first Route URI' of a request constructed according to
                 * 12.2.1.1 to be the request URI when the route set is empty.
                 */
                if (sipStack.isLoggingEnabled())
                    sipStack.getStackLogger().logDebug(
                            "Null message channel using outbound proxy !");
                Hop outboundProxy = sipStack.getRouter(dialogRequest).getOutboundProxy();
                if (outboundProxy == null)
                    throw new SipException("No route found! hop=" + hop);
                messageChannel = sipStack.createRawMessageChannel(this.getSipProvider()
                        .getListeningPoint(outboundProxy.getTransport()).getIPAddress(),
                        this.firstTransactionPort, outboundProxy);
                if (messageChannel != null)
                    ((SIPClientTransaction) clientTransactionId)
                            .setEncapsulatedChannel(messageChannel);
            } else {
                ((SIPClientTransaction) clientTransactionId)
                        .setEncapsulatedChannel(messageChannel);

                if (sipStack.isLoggingEnabled()) {
                    sipStack.getStackLogger().logDebug("using message channel " + messageChannel);

                }

            }

            if (messageChannel != null) messageChannel.useCount++;
            
            // See if we need to release the previously mapped channel.
            if ((!sipStack.cacheClientConnections) && oldChannel != null
                    && oldChannel.useCount <= 0)
                oldChannel.close();            
        } catch (Exception ex) {
            if (sipStack.isLoggingEnabled())
                sipStack.getStackLogger().logException(ex);
            throw new SipException("Could not create message channel", ex);
        }

        try {
            // Increment before setting!!
            localSequenceNumber++;
            dialogRequest.getCSeq().setSeqNumber(getLocalSeqNumber());
        } catch (InvalidArgumentException ex) {
            sipStack.getStackLogger().logFatalError(ex.getMessage());
        }

        try {
            ((SIPClientTransaction) clientTransactionId).sendMessage(dialogRequest);
            /*
             * Note that if the BYE is rejected then the Dialog should bo back to the ESTABLISHED
             * state so we only set state after successful send.
             */
            if (dialogRequest.getMethod().equals(Request.BYE)) {
                this.byeSent = true;
                /*
                 * Dialog goes into TERMINATED state as soon as BYE is sent. ISSUE 182.
                 */
                if (isTerminatedOnBye()) {
                    this.setState(DialogState._TERMINATED);
                }
            }
        } catch (IOException ex) {
            throw new SipException("error sending message", ex);
        }

    }

    /**
     * Return yes if the last response is to be retransmitted.
     */
    private boolean toRetransmitFinalResponse(int T2) {
        if (--retransmissionTicksLeft == 0) {
            if (2 * prevRetransmissionTicks <= T2)
                this.retransmissionTicksLeft = 2 * prevRetransmissionTicks;
            else
                this.retransmissionTicksLeft = prevRetransmissionTicks;
            this.prevRetransmissionTicks = retransmissionTicksLeft;
            return true;
        } else
            return false;

    }

    protected void setRetransmissionTicks() {
        this.retransmissionTicksLeft = 1;
        this.prevRetransmissionTicks = 1;
    }

    /**
     * Resend the last ack.
     */
    public void resendAck() throws SipException {
        // Check for null.

        if (this.getLastAckSent() != null) {
            if (getLastAckSent().getHeader(TimeStampHeader.NAME) != null
                    && sipStack.generateTimeStampHeader) {
                TimeStamp ts = new TimeStamp();
                try {
                    ts.setTimeStamp(System.currentTimeMillis());
                    getLastAckSent().setHeader(ts);
                } catch (InvalidArgumentException e) {

                }
            }
            this.sendAck(getLastAckSent(), false);
        }

    }

    /**
     * Get the method of the request/response that resulted in the creation of the Dialog.
     * 
     * @return -- the method of the dialog.
     */
    public String getMethod() {
        // Method of the request or response used to create this dialog
        return this.method;
    }

    /**
     * Start the dialog timer.
     * 
     * @param transaction
     */

    protected void startTimer(SIPServerTransaction transaction) {
        if (this.timerTask != null && timerTask.transaction == transaction) {
        	if (sipStack.isLoggingEnabled())
        		sipStack.getStackLogger().logDebug("Timer already running for " + getDialogId());
            return;
        }
        if (sipStack.isLoggingEnabled())
            sipStack.getStackLogger().logDebug("Starting dialog timer for " + getDialogId());
        this.ackSeen = false;
        
		acquireTimerTaskSem();
		try {
	        if (this.timerTask != null) {
	            this.timerTask.transaction = transaction;
	        } else {
	            this.timerTask = new DialogTimerTask(transaction);
	            sipStack.getTimer().schedule(timerTask, SIPTransactionStack.BASE_TIMER_INTERVAL,
	                    SIPTransactionStack.BASE_TIMER_INTERVAL);
	        }
		} finally {
			releaseTimerTaskSem();
		}
        
        this.setRetransmissionTicks();
    }

    /**
     * Stop the dialog timer. This is called when the dialog is terminated.
     * 
     */
    protected void stopTimer() {
        try {
        	acquireTimerTaskSem();
        	try {
	            if (this.timerTask != null) {            	
	            	this.timerTask.cancel();
		            this.timerTask = null;
	            }   
        	} finally {
        		releaseTimerTaskSem();
        	}
        } catch (Exception ex) {
        }
    }

    /*
     * (non-Javadoc) Retransmissions of the reliable provisional response cease when a matching
     * PRACK is received by the UA core. PRACK is like any other request within a dialog, and the
     * UAS core processes it according to the procedures of Sections 8.2 and 12.2.2 of RFC 3261. A
     * matching PRACK is defined as one within the same dialog as the response, and whose method,
     * CSeq-num, and response-num in the RAck header field match, respectively, the method from
     * the CSeq, the sequence number from the CSeq, and the sequence number from the RSeq of the
     * reliable provisional response.
     * 
     * @see javax.sip.Dialog#createPrack(javax.sip.message.Response)
     */
    public Request createPrack(Response relResponse) throws DialogDoesNotExistException,
            SipException {

        if (this.getState() == null || this.getState().equals(DialogState.TERMINATED))
            throw new DialogDoesNotExistException("Dialog not initialized or terminated");

        if ((RSeq) relResponse.getHeader(RSeqHeader.NAME) == null) {
            throw new SipException("Missing RSeq Header");
        }

        try {
            SIPResponse sipResponse = (SIPResponse) relResponse;
            SIPRequest sipRequest = (SIPRequest) this.createRequest(Request.PRACK,
                    (SIPResponse) relResponse);
            String toHeaderTag = sipResponse.getTo().getTag();
            sipRequest.setToTag(toHeaderTag);
            RAck rack = new RAck();
            RSeq rseq = (RSeq) relResponse.getHeader(RSeqHeader.NAME);
            rack.setMethod(sipResponse.getCSeq().getMethod());
            rack.setCSequenceNumber((int) sipResponse.getCSeq().getSeqNumber());
            rack.setRSequenceNumber(rseq.getSeqNumber());
            sipRequest.setHeader(rack);
            return (Request) sipRequest;
        } catch (Exception ex) {
            InternalErrorHandler.handleException(ex);
            return null;
        }

    }

    private void updateRequest(SIPRequest sipRequest) {

        RouteList rl = this.getRouteList();
        if (rl.size() > 0) {
            sipRequest.setHeader(rl);
        } else {
            sipRequest.removeHeader(RouteHeader.NAME);
        }
        if (MessageFactoryImpl.getDefaultUserAgentHeader() != null) {
            sipRequest.setHeader(MessageFactoryImpl.getDefaultUserAgentHeader());
        }

    }

    /*
     * (non-Javadoc) The UAC core MUST generate an ACK request for each 2xx received from the
     * transaction layer. The header fields of the ACK are constructed in the same way as for any
     * request sent within a dialog (see Section 12) with the exception of the CSeq and the header
     * fields related to authentication. The sequence number of the CSeq header field MUST be the
     * same as the INVITE being acknowledged, but the CSeq method MUST be ACK. The ACK MUST
     * contain the same credentials as the INVITE. If the 2xx contains an offer (based on the
     * rules above), the ACK MUST carry an answer in its body. If the offer in the 2xx response is
     * not acceptable, the UAC core MUST generate a valid answer in the ACK and then send a BYE
     * immediately.
     * 
     * Note that for the case of forked requests, you can create multiple outgoing invites each
     * with a different cseq and hence you need to supply the invite.
     * 
     * @see javax.sip.Dialog#createAck(long)
     */
    public Request createAck(long cseqno) throws InvalidArgumentException, SipException {

        // JvB: strictly speaking it is allowed to start a dialog with
        // SUBSCRIBE,
        // then send INVITE+ACK later on
        if (!method.equals(Request.INVITE))
            throw new SipException("Dialog was not created with an INVITE" + method);

        if (cseqno <= 0)
            throw new InvalidArgumentException("bad cseq <= 0 ");
        else if (cseqno > ((((long) 1) << 32) - 1))
            throw new InvalidArgumentException("bad cseq > " + ((((long) 1) << 32) - 1));

        if (this.remoteTarget == null) {
            throw new SipException("Cannot create ACK - no remote Target!");
        }

        if (this.sipStack.isLoggingEnabled()) {
            this.sipStack.getStackLogger().logDebug("createAck " + this + " cseqno " + cseqno);
        }

        // MUST ack in the same order that the OKs were received. This traps
        // out of order ACK sending. Old ACKs seqno's can always be ACKed.
        if (lastInviteOkReceived < cseqno) {
        	if (sipStack.isLoggingEnabled()) {
        		this.sipStack.getStackLogger().logDebug(
                    "WARNING : Attempt to crete ACK without OK " + this);
            	this.sipStack.getStackLogger().logDebug("LAST RESPONSE = " + this.lastResponse);
        	}
            throw new SipException("Dialog not yet established -- no OK response!");
        }

        try {

            // JvB: Transport from first entry in route set, or remote Contact
            // if none
            // Only used to find correct LP & create correct Via
            SipURI uri4transport = null;

            if (this.routeList != null && !this.routeList.isEmpty()) {
                Route r = (Route) this.routeList.getFirst();
                uri4transport = ((SipURI) r.getAddress().getURI());
            } else { // should be !=null, checked above
                uri4transport = ((SipURI) this.remoteTarget.getURI());
            }

            String transport = uri4transport.getTransportParam();
            if (transport == null) {
                // JvB fix: also support TLS
                transport = uri4transport.isSecure() ? ListeningPoint.TLS : ListeningPoint.UDP;
            }
            ListeningPointImpl lp = (ListeningPointImpl) sipProvider.getListeningPoint(transport);
            if (lp == null) {
            	if (sipStack.isLoggingEnabled()) {
            		sipStack.getStackLogger().logError(
                        "remoteTargetURI " + this.remoteTarget.getURI());
                	sipStack.getStackLogger().logError("uri4transport = " + uri4transport);
                	sipStack.getStackLogger().logError("No LP found for transport=" + transport);
            	}
                throw new SipException(
                        "Cannot create ACK - no ListeningPoint for transport towards next hop found:"
                                + transport);
            }
            SIPRequest sipRequest = new SIPRequest();
            sipRequest.setMethod(Request.ACK);
            sipRequest.setRequestURI((SipUri) getRemoteTarget().getURI().clone());
            sipRequest.setCallId(this.callIdHeader);
            sipRequest.setCSeq(new CSeq(cseqno, Request.ACK));
            List<Via> vias = new ArrayList<Via>();
            // Via via = lp.getViaHeader();
            // The user may have touched the sentby for the response.
            // so use the via header extracted from the response for the ACK =>
            // https://jain-sip.dev.java.net/issues/show_bug.cgi?id=205
            // strip the params from the via of the response and use the params from the
            // original request
            Via via = this.lastResponse.getTopmostVia();
            via.removeParameters();
            if (originalRequest != null && originalRequest.getTopmostVia() != null) {
                NameValueList originalRequestParameters = originalRequest.getTopmostVia()
                        .getParameters();
                if (originalRequestParameters != null && originalRequestParameters.size() > 0) {
                    via.setParameters((NameValueList) originalRequestParameters.clone());
                }
            }
            via.setBranch(Utils.getInstance().generateBranchId()); // new branch
            vias.add(via);
            sipRequest.setVia(vias);
            From from = new From();
            from.setAddress(this.localParty);
            from.setTag(this.myTag);
            sipRequest.setFrom(from);
            To to = new To();
            to.setAddress(this.remoteParty);
            if (hisTag != null)
                to.setTag(this.hisTag);
            sipRequest.setTo(to);
            sipRequest.setMaxForwards(new MaxForwards(70));

            if (this.originalRequest != null) {
                Authorization authorization = this.originalRequest.getAuthorization();
                if (authorization != null)
                    sipRequest.setHeader(authorization);
            }

            // ACKs for 2xx responses
            // use the Route values learned from the Record-Route of the 2xx
            // responses.
            this.updateRequest(sipRequest);

            return sipRequest;
        } catch (Exception ex) {
            InternalErrorHandler.handleException(ex);
            throw new SipException("unexpected exception ", ex);
        }

    }

    /**
     * Get the provider for this Dialog.
     * 
     * SPEC_REVISION
     * 
     * @return -- the SIP Provider associated with this transaction.
     */
    public SipProviderImpl getSipProvider() {
        return this.sipProvider;
    }

    /**
     * @param sipProvider the sipProvider to set
     */
    public void setSipProvider(SipProviderImpl sipProvider) {
        this.sipProvider = sipProvider;
    }

    /**
     * Check the tags of the response against the tags of the Dialog. Return true if the respnse
     * matches the tags of the dialog. We do this check wehn sending out a response.
     * 
     * @param sipResponse -- the response to check.
     * 
     */
    public void setResponseTags(SIPResponse sipResponse) {
        if (this.getLocalTag() != null || this.getRemoteTag() != null) {
            return;
        }
        String responseFromTag = sipResponse.getFromTag();
        if ( responseFromTag != null ) {
            if (responseFromTag.equals(this.getLocalTag())) {
                sipResponse.setToTag(this.getRemoteTag());
            } else if (responseFromTag.equals(this.getRemoteTag())) {
                sipResponse.setToTag(this.getLocalTag());
            }
        } else {
        	if (sipStack.isLoggingEnabled())
        		sipStack.getStackLogger().logWarning("No from tag in response! Not RFC 3261 compatible.");
        }

    }

    /**
     * Set the last response for this dialog. This method is called for updating the dialog state
     * when a response is either sent or received from within a Dialog.
     * 
     * @param transaction -- the transaction associated with the response
     * @param sipResponse -- the last response to set.
     */
    public void setLastResponse(SIPTransaction transaction, SIPResponse sipResponse) {
        this.callIdHeader = sipResponse.getCallId();     
        int statusCode = sipResponse.getStatusCode();
        if (statusCode == 100) {
        	if (sipStack.isLoggingEnabled())
        		sipStack.getStackLogger().logWarning(
                    "Invalid status code - 100 in setLastResponse - ignoring");
            return;
        }

        this.lastResponse = sipResponse;
        this.setAssigned();
        // Adjust state of the Dialog state machine.
        if (sipStack.isLoggingEnabled()) {
            sipStack.getStackLogger().logDebug(
                    "sipDialog: setLastResponse:" + this + " lastResponse = "
                            + this.lastResponse.getFirstLine());
        }
        if (this.getState() == DialogState.TERMINATED) {
            if (sipStack.isLoggingEnabled()) {
                sipStack.getStackLogger().logDebug(
                        "sipDialog: setLastResponse -- dialog is terminated - ignoring ");
            }
            // Capture the OK response for later use in createAck
            // This is handy for late arriving OK's that we want to ACK.
            if (sipResponse.getCSeq().getMethod().equals(Request.INVITE) && statusCode == 200) {
               
                this.lastInviteOkReceived = Math.max(sipResponse.getCSeq().getSeqNumber(),
                        this.lastInviteOkReceived);
            }
            return;
        }
        String cseqMethod = sipResponse.getCSeq().getMethod();
        if (sipStack.isLoggingEnabled()) {
            sipStack.getStackLogger().logStackTrace();
            sipStack.getStackLogger().logDebug("cseqMethod = " + cseqMethod);
            sipStack.getStackLogger().logDebug("dialogState = " + this.getState());
            sipStack.getStackLogger().logDebug("method = " + this.getMethod());
            sipStack.getStackLogger().logDebug("statusCode = " + statusCode);
            sipStack.getStackLogger().logDebug("transaction = " + transaction);
        }

        // JvB: don't use "!this.isServer" here
        // note that the transaction can be null for forked
        // responses.
        if (transaction == null || transaction instanceof ClientTransaction) {
            if (sipStack.isDialogCreated(cseqMethod)) {
                // Make a final tag assignment.
                if (getState() == null && (statusCode / 100 == 1)) {
                    /*
                     * Guard aginst slipping back into early state from confirmed state.
                     */
                    // Was (sipResponse.getToTag() != null || sipStack.rfc2543Supported)
                    setState(SIPDialog.EARLY_STATE);
                    if ((sipResponse.getToTag() != null || sipStack.rfc2543Supported)
                            && this.getRemoteTag() == null) {
                        setRemoteTag(sipResponse.getToTag());
                        this.setDialogId(sipResponse.getDialogId(false));
                        sipStack.putDialog(this);
                        this.addRoute(sipResponse);
                    }
                } else if (getState() != null && getState().equals(DialogState.EARLY)
                        && statusCode / 100 == 1) {
                    /*
                     * This case occurs for forked dialog responses. The To tag can change as a
                     * result of the forking. The remote target can also change as a result of the
                     * forking.
                     */
                    if (cseqMethod.equals(getMethod()) && transaction != null
                            && (sipResponse.getToTag() != null || sipStack.rfc2543Supported)) {
                        setRemoteTag(sipResponse.getToTag());
                        this.setDialogId(sipResponse.getDialogId(false));
                        sipStack.putDialog(this);
                        this.addRoute(sipResponse);
                    }
                } else if (statusCode / 100 == 2) {
                    // This is a dialog creating method (such as INVITE).
                    // 2xx response -- set the state to the confirmed
                    // state. To tag is MANDATORY for the response.

                    // Only do this if method equals initial request!

                    if (cseqMethod.equals(getMethod())
                            && (sipResponse.getToTag() != null || sipStack.rfc2543Supported)
                            && this.getState() != DialogState.CONFIRMED) {
                        setRemoteTag(sipResponse.getToTag());
                        this.setDialogId(sipResponse.getDialogId(false));
                        sipStack.putDialog(this);
                        this.addRoute(sipResponse);

                        setState(SIPDialog.CONFIRMED_STATE);
                    }

                    // Capture the OK response for later use in createAck
                    if (cseqMethod.equals(Request.INVITE)) {
                        this.lastInviteOkReceived = Math.max(sipResponse.getCSeq().getSeqNumber(),
                                this.lastInviteOkReceived);
                    }

                } else if (statusCode >= 300
                        && statusCode <= 699
                        && (getState() == null || (cseqMethod.equals(getMethod()) && getState()
                                .getValue() == SIPDialog.EARLY_STATE))) {
                    /*
                     * This case handles 3xx, 4xx, 5xx and 6xx responses. RFC 3261 Section 12.3 -
                     * dialog termination. Independent of the method, if a request outside of a
                     * dialog generates a non-2xx final response, any early dialogs created
                     * through provisional responses to that request are terminated.
                     */
                    setState(SIPDialog.TERMINATED_STATE);
                }

                /*
                 * This code is in support of "proxy" servers that are constructed as back to back
                 * user agents. This could be a dialog in the middle of the call setup path
                 * somewhere. Hence the incoming invite has record route headers in it. The
                 * response will have additional record route headers. However, for this dialog
                 * only the downstream record route headers matter. Ideally proxy servers should
                 * not be constructed as Back to Back User Agents. Remove all the record routes
                 * that are present in the incoming INVITE so you only have the downstream Route
                 * headers present in the dialog. Note that for an endpoint - you will have no
                 * record route headers present in the original request so the loop will not
                 * execute.
                 */
                if ( this.getState() != DialogState.CONFIRMED && this.getState() != DialogState.TERMINATED ) {
                    if (originalRequest != null) {
                        RecordRouteList rrList = originalRequest.getRecordRouteHeaders();
                        if (rrList != null) {
                            ListIterator<RecordRoute> it = rrList.listIterator(rrList.size());
                            while (it.hasPrevious()) {
                                RecordRoute rr = (RecordRoute) it.previous();
                                Route route = (Route) routeList.getFirst();
                                if (route != null && rr.getAddress().equals(route.getAddress())) {
                                    routeList.removeFirst();
                                } else
                                    break;
                            }
                        }
                    }
                }

            } else if (cseqMethod.equals(Request.NOTIFY)
                    && (this.getMethod().equals(Request.SUBSCRIBE) || this.getMethod().equals(
                            Request.REFER)) && sipResponse.getStatusCode() / 100 == 2
                    && this.getState() == null) {
                // This is a notify response.
                this.setDialogId(sipResponse.getDialogId(true));
                sipStack.putDialog(this);
                this.setState(SIPDialog.CONFIRMED_STATE);

            } else if (cseqMethod.equals(Request.BYE) && statusCode / 100 == 2
                    && isTerminatedOnBye()) {
                // Dialog will be terminated when the transction is terminated.
                setState(SIPDialog.TERMINATED_STATE);
            }
        } else {
            // Processing Server Dialog.

            if (cseqMethod.equals(Request.BYE) && statusCode / 100 == 2
                    && this.isTerminatedOnBye()) {
                /*
                 * Only transition to terminated state when 200 OK is returned for the BYE. Other
                 * status codes just result in leaving the state in COMPLETED state.
                 */
                this.setState(SIPDialog.TERMINATED_STATE);
            } else {
                boolean doPutDialog = false;

                if (getLocalTag() == null && sipResponse.getTo().getTag() != null
                        && sipStack.isDialogCreated(cseqMethod) && cseqMethod.equals(getMethod())) {
                    setLocalTag(sipResponse.getTo().getTag());

                    doPutDialog = true;
                }

                if (statusCode / 100 != 2) {
                    if (statusCode / 100 == 1) {
                        if (doPutDialog) {

                            setState(SIPDialog.EARLY_STATE);
                            this.setDialogId(sipResponse.getDialogId(true));
                            sipStack.putDialog(this);
                        }
                    } else {
                        /*
                         * RFC 3265 chapter 3.1.4.1 "Non-200 class final responses indicate that
                         * no subscription or dialog has been created, and no subsequent NOTIFY
                         * message will be sent. All non-200 class" + responses (with the
                         * exception of "489", described herein) have the same meanings and
                         * handling as described in SIP"
                         */
                        // Bug Fix by Jens tinfors
                        // see https://jain-sip.dev.java.net/servlets/ReadMsg?list=users&msgNo=797
                        if (statusCode == 489
                                && (cseqMethod.equals(Request.NOTIFY) || cseqMethod
                                        .equals(Request.SUBSCRIBE))) {
                        	if (sipStack.isLoggingEnabled())
                        		sipStack.getStackLogger().logDebug(
                                    "RFC 3265 : Not setting dialog to TERMINATED for 489");
                        } else {
                            // baranowb: simplest fix to
                            // https://jain-sip.dev.java.net/issues/show_bug.cgi?id=175
                            // application is responsible for terminating in this case
                            // see rfc 5057 for better explanation
                            if (!this.isReInvite() && getState() != DialogState.CONFIRMED) {
                                this.setState(SIPDialog.TERMINATED_STATE);
                            }
                        }
                    }

                } else {

                    /*
                     * JvB: RFC4235 says that when sending 2xx on UAS side, state should move to
                     * CONFIRMED
                     */
                    if (this.dialogState <= SIPDialog.EARLY_STATE
                            && (cseqMethod.equals(Request.INVITE)
                                    || cseqMethod.equals(Request.SUBSCRIBE) || cseqMethod
                                    .equals(Request.REFER))) {
                        this.setState(SIPDialog.CONFIRMED_STATE);
                    }

                    if (doPutDialog) {
                        this.setDialogId(sipResponse.getDialogId(true));
                        sipStack.putDialog(this);
                    }
                    /*
                     * We put the dialog into the table. We must wait for ACK before re-INVITE is
                     * sent
                     */
                    if (transaction.getState() != TransactionState.TERMINATED
                            && sipResponse.getStatusCode() == Response.OK
                            && cseqMethod.equals(Request.INVITE)
                            && this.isBackToBackUserAgent) {
                            /*
                             * Acquire the flag for re-INVITE so that we cannot re-INVITE before
                             * ACK is received.
                             */
                            if (!this.takeAckSem()) {
                                if (sipStack.isLoggingEnabled()) {
                                    sipStack.getStackLogger().logDebug(
                                            "Delete dialog -- cannot acquire ackSem");
                                }
                                this.delete();
                                return;
                            }
                        
                    }
                }
            }

        }

    }

    /**
     * Start the retransmit timer.
     * 
     * @param sipServerTx -- server transaction on which the response was sent
     * @param response - response that was sent.
     */
    public void startRetransmitTimer(SIPServerTransaction sipServerTx, Response response) {
        if (sipServerTx.getRequest().getMethod().equals(Request.INVITE)
                && response.getStatusCode() / 100 == 2) {
            this.startTimer(sipServerTx);
        }
    }

    /**
     * @return -- the last response associated with the dialog.
     */
    public SIPResponse getLastResponse() {

        return lastResponse;
    }

    /**
     * Do taget refresh dialog state updates.
     * 
     * RFC 3261: Requests within a dialog MAY contain Record-Route and Contact header fields.
     * However, these requests do not cause the dialog's route set to be modified, although they
     * may modify the remote target URI. Specifically, requests that are not target refresh
     * requests do not modify the dialog's remote target URI, and requests that are target refresh
     * requests do. For dialogs that have been established with an
     * 
     * INVITE, the only target refresh request defined is re-INVITE (see Section 14). Other
     * extensions may define different target refresh requests for dialogs established in other
     * ways.
     */
    private void doTargetRefresh(SIPMessage sipMessage) {

        ContactList contactList = sipMessage.getContactHeaders();

        /*
         * INVITE is the target refresh for INVITE dialogs. SUBSCRIBE is the target refresh for
         * subscribe dialogs from the client side. This modifies the remote target URI potentially
         */
        if (contactList != null) {

            Contact contact = (Contact) contactList.getFirst();
            this.setRemoteTarget(contact);

        }

    }

    private static final boolean optionPresent(ListIterator l, String option) {
        while (l.hasNext()) {
            OptionTag opt = (OptionTag) l.next();
            if (opt != null && option.equalsIgnoreCase(opt.getOptionTag()))
                return true;
        }
        return false;
    }

    /*
     * (non-Javadoc)
     * 
     * @see javax.sip.Dialog#createReliableProvisionalResponse(int)
     */
    public Response createReliableProvisionalResponse(int statusCode)
            throws InvalidArgumentException, SipException {

        if (!(firstTransactionIsServerTransaction)) {
            throw new SipException("Not a Server Dialog!");

        }
        /*
         * A UAS MUST NOT attempt to send a 100 (Trying) response reliably. Only provisional
         * responses numbered 101 to 199 may be sent reliably. If the request did not include
         * either a Supported or Require header field indicating this feature, the UAS MUST NOT
         * send the provisional response reliably.
         */
        if (statusCode <= 100 || statusCode > 199)
            throw new InvalidArgumentException("Bad status code ");
        SIPRequest request = this.originalRequest;
        if (!request.getMethod().equals(Request.INVITE))
            throw new SipException("Bad method");

        ListIterator<SIPHeader> list = request.getHeaders(SupportedHeader.NAME);
        if (list == null || !optionPresent(list, "100rel")) {
            list = request.getHeaders(RequireHeader.NAME);
            if (list == null || !optionPresent(list, "100rel")) {
                throw new SipException("No Supported/Require 100rel header in the request");
            }
        }

        SIPResponse response = request.createResponse(statusCode);
        /*
         * The provisional response to be sent reliably is constructed by the UAS core according
         * to the procedures of Section 8.2.6 of RFC 3261. In addition, it MUST contain a Require
         * header field containing the option tag 100rel, and MUST include an RSeq header field.
         * The value of the header field for the first reliable provisional response in a
         * transaction MUST be between 1 and 2**31 - 1. It is RECOMMENDED that it be chosen
         * uniformly in this range. The RSeq numbering space is within a single transaction. This
         * means that provisional responses for different requests MAY use the same values for the
         * RSeq number.
         */
        Require require = new Require();
        try {
            require.setOptionTag("100rel");
        } catch (Exception ex) {
            InternalErrorHandler.handleException(ex);
        }
        response.addHeader(require);
        RSeq rseq = new RSeq();
        /*
         * set an arbitrary sequence number. This is actually set when the response is sent out
         */
        rseq.setSeqNumber(1L);
        /*
         * Copy the record route headers from the request to the response ( Issue 160 ). Note that
         * other 1xx headers do not get their Record Route headers copied over but reliable
         * provisional responses do. See RFC 3262 Table 2.
         */
        RecordRouteList rrl = request.getRecordRouteHeaders();
        if (rrl != null) {
            RecordRouteList rrlclone = (RecordRouteList) rrl.clone();
            response.setHeader(rrlclone);
        }

        return response;
    }

    /**
     * Do the processing necessary for the PRACK
     * 
     * @param prackRequest
     * @return true if this is the first time the tx has seen the prack ( and hence needs to be
     *         passed up to the TU)
     */
    public boolean handlePrack(SIPRequest prackRequest) {
        /*
         * The RAck header is sent in a PRACK request to support reliability of provisional
         * responses. It contains two numbers and a method tag. The first number is the value from
         * the RSeq header in the provisional response that is being acknowledged. The next
         * number, and the method, are copied from the CSeq in the response that is being
         * acknowledged. The method name in the RAck header is case sensitive.
         */
        if (!this.isServer()) {
            if (sipStack.isLoggingEnabled())
                sipStack.getStackLogger().logDebug("Dropping Prack -- not a server Dialog");
            return false;
        }
        SIPServerTransaction sipServerTransaction = (SIPServerTransaction) this
                .getFirstTransaction();
        SIPResponse sipResponse = sipServerTransaction.getReliableProvisionalResponse();

        if (sipResponse == null) {
            if (sipStack.isLoggingEnabled())
                sipStack.getStackLogger()
                        .logDebug("Dropping Prack -- ReliableResponse not found");
            return false;
        }

        RAck rack = (RAck) prackRequest.getHeader(RAckHeader.NAME);

        if (rack == null) {
            if (sipStack.isLoggingEnabled())
                sipStack.getStackLogger().logDebug("Dropping Prack -- rack header not found");
            return false;
        }
        CSeq cseq = (CSeq) sipResponse.getCSeq();

        if (!rack.getMethod().equals(cseq.getMethod())) {
            if (sipStack.isLoggingEnabled())
                sipStack.getStackLogger().logDebug(
                        "Dropping Prack -- CSeq Header does not match PRACK");
            return false;
        }

        if (rack.getCSeqNumberLong() != cseq.getSeqNumber()) {
            if (sipStack.isLoggingEnabled())
                sipStack.getStackLogger().logDebug(
                        "Dropping Prack -- CSeq Header does not match PRACK");
            return false;
        }

        RSeq rseq = (RSeq) sipResponse.getHeader(RSeqHeader.NAME);

        if (rack.getRSequenceNumber() != rseq.getSeqNumber()) {
            if (sipStack.isLoggingEnabled())
                sipStack.getStackLogger().logDebug(
                        "Dropping Prack -- RSeq Header does not match PRACK");
            return false;
        }

        return sipServerTransaction.prackRecieved();
    }

    /*
     * (non-Javadoc)
     * 
     * @see javax.sip.Dialog#sendReliableProvisionalResponse(javax.sip.message.Response)
     */
    public void sendReliableProvisionalResponse(Response relResponse) throws SipException {
        if (!this.isServer()) {
            throw new SipException("Not a Server Dialog");
        }

        SIPResponse sipResponse = (SIPResponse) relResponse;

        if (relResponse.getStatusCode() == 100)
            throw new SipException("Cannot send 100 as a reliable provisional response");

        if (relResponse.getStatusCode() / 100 > 2)
            throw new SipException(
                    "Response code is not a 1xx response - should be in the range 101 to 199 ");

        /*
         * Do a little checking on the outgoing response.
         */
        if (sipResponse.getToTag() == null) {
            throw new SipException(
                    "Badly formatted response -- To tag mandatory for Reliable Provisional Response");
        }
        ListIterator requireList = (ListIterator) relResponse.getHeaders(RequireHeader.NAME);
        boolean found = false;

        if (requireList != null) {

            while (requireList.hasNext() && !found) {
                RequireHeader rh = (RequireHeader) requireList.next();
                if (rh.getOptionTag().equalsIgnoreCase("100rel")) {
                    found = true;
                }
            }
        }

        if (!found) {
            Require require = new Require("100rel");
            relResponse.addHeader(require);
            if (sipStack.isLoggingEnabled()) {
                sipStack.getStackLogger().logDebug(
                        "Require header with optionTag 100rel is needed -- adding one");
            }

        }

        SIPServerTransaction serverTransaction = (SIPServerTransaction) this
                .getFirstTransaction();
        /*
         * put into the dialog table before sending the response so as to avoid race condition
         * with PRACK
         */
        this.setLastResponse(serverTransaction, sipResponse);

        this.setDialogId(sipResponse.getDialogId(true));

        serverTransaction.sendReliableProvisionalResponse(relResponse);

        this.startRetransmitTimer(serverTransaction, relResponse);

    }

    /*
     * (non-Javadoc)
     * 
     * @see javax.sip.Dialog#terminateOnBye(boolean)
     */
    public void terminateOnBye(boolean terminateFlag) throws SipException {

        this.terminateOnBye = terminateFlag;
    }

    /**
     * Set the "assigned" flag to true. We do this when inserting the dialog into the dialog table
     * of the stack.
     * 
     */
    public void setAssigned() {
        this.isAssigned = true;
    }

    /**
     * Return true if the dialog has already been mapped to a transaction.
     * 
     */

    public boolean isAssigned() {
        return this.isAssigned;
    }

    /**
     * Get the contact header that the owner of this dialog assigned. Subsequent Requests are
     * considered to belong to the dialog if the dialog identifier matches and the contact header
     * matches the ip address and port on which the request is received.
     * 
     * @return contact header belonging to the dialog.
     */
    public Contact getMyContactHeader() {
    	return contactHeader;
    }

    /**
     * Do the necessary processing to handle an ACK directed at this Dialog.
     * 
     * @param ackTransaction -- the ACK transaction that was directed at this dialog.
     * @return -- true if the ACK was successfully consumed by the Dialog and resulted in the
     *         dialog state being changed.
     */
    public boolean handleAck(SIPServerTransaction ackTransaction) {
        SIPRequest sipRequest = ackTransaction.getOriginalRequest();

        if (isAckSeen() && getRemoteSeqNumber() == sipRequest.getCSeq().getSeqNumber()) {

            if (sipStack.isLoggingEnabled()) {
                sipStack.getStackLogger().logDebug(
                        "ACK already seen by dialog -- dropping Ack" + " retransmission");
            }
            acquireTimerTaskSem();
            try {
            	if (this.timerTask != null) {            	
	                this.timerTask.cancel();
	                this.timerTask = null;
            	} 
            } finally {
        		releaseTimerTaskSem();
        	}
            return false;
        } else if (this.getState() == DialogState.TERMINATED) {
            if (sipStack.isLoggingEnabled())
                sipStack.getStackLogger().logDebug("Dialog is terminated -- dropping ACK");
            return false;

        } else {

            /*
             * This could be a re-invite processing. check to see if the ack matches with the last
             * transaction. s
             */

            SIPServerTransaction tr = getInviteTransaction();

            SIPResponse sipResponse = (tr != null ? tr.getLastResponse() : null);

            // Idiot check for sending ACK from the wrong side!
            if (tr != null
                    && sipResponse != null
                    && sipResponse.getStatusCode() / 100 == 2
                    && sipResponse.getCSeq().getMethod().equals(Request.INVITE)
                    && sipResponse.getCSeq().getSeqNumber() == sipRequest.getCSeq()
                            .getSeqNumber()) {

                ackTransaction.setDialog(this, sipResponse.getDialogId(false));
                /*
                 * record that we already saw an ACK for this dialog.
                 */

                ackReceived(sipRequest);
                if (sipStack.isLoggingEnabled())
                	sipStack.getStackLogger().logDebug("ACK for 2XX response --- sending to TU ");
                return true;

            } else {
                /*
                 * This happens when the ACK is re-transmitted and arrives too late to be
                 * processed.
                 */

                if (sipStack.isLoggingEnabled())
                    sipStack.getStackLogger().logDebug(
                            " INVITE transaction not found  -- Discarding ACK");
                return false;
            }
        }
    }

    void setEarlyDialogId(String earlyDialogId) {
        this.earlyDialogId = earlyDialogId;
    }

    String getEarlyDialogId() {
        return earlyDialogId;
    }

    /**
     * Release the semaphore for ACK processing so the next re-INVITE may proceed.
     */
    void releaseAckSem() {
        if (this.isBackToBackUserAgent) {
            if (sipStack.isLoggingEnabled()) {
                sipStack.getStackLogger().logDebug("releaseAckSem]" + this);
            }
            this.ackSem.release();
        }

    }

    boolean takeAckSem() {
        if (sipStack.isLoggingEnabled()) {
            sipStack.getStackLogger().logDebug("[takeAckSem " + this);
        }
        try {
            if (!this.ackSem.tryAcquire(2, TimeUnit.SECONDS)) {
                if (sipStack.isLoggingEnabled()) {
                    sipStack.getStackLogger().logError("Cannot aquire ACK semaphore");
                }

                if ( sipStack.isLoggingEnabled() ) {
                    sipStack.getStackLogger().logDebug("Semaphore previously acquired at " + this.stackTrace);
                    sipStack.getStackLogger().logStackTrace();
                    
                }
                return false;
            }
            
            if ( sipStack.isLoggingEnabled() ) {
                
                this.recordStackTrace();
            }
            
        } catch (InterruptedException ex) {
            sipStack.getStackLogger().logError("Cannot aquire ACK semaphore");
            return false;

        }
        return true;

    }

    /**
     * @param lastAckReceived the lastAckReceived to set
     */
    private void setLastAckReceived(SIPRequest lastAckReceived) {
        this.lastAckReceived = lastAckReceived;
    }

    /**
     * @return the lastAckReceived
     */
    protected SIPRequest getLastAckReceived() {
        return lastAckReceived;
    }

    /**
     * @param lastAckSent the lastAckSent to set
     */
    private void setLastAckSent(SIPRequest lastAckSent) {
        this.lastAckSent = lastAckSent;
    }
    
    /**
     * @return true if an ack was ever sent for this Dialog
     */
    public boolean isAtleastOneAckSent() {
        return this.isAcknowledged;
    }

    
    
    public boolean isBackToBackUserAgent() {
        return this.isBackToBackUserAgent;
    }
    
    public synchronized void doDeferredDeleteIfNoAckSent(long seqno) {
		if (sipStack.getTimer() == null) {
			this.setState(TERMINATED_STATE);
		} else if(dialogDeleteIfNoAckSentTask == null){
			// Delete the transaction after the max ack timeout.
			dialogDeleteIfNoAckSentTask = new DialogDeleteIfNoAckSentTask(seqno);
			sipStack.getTimer().schedule(
					dialogDeleteIfNoAckSentTask,
					SIPTransaction.TIMER_J
							* SIPTransactionStack.BASE_TIMER_INTERVAL);
		}
	}

    /*
     * (non-Javadoc)
     * @see gov.nist.javax.sip.DialogExt#setBackToBackUserAgent(boolean)
     */
    public void setBackToBackUserAgent() {
        this.isBackToBackUserAgent = true;   
    }

	/**
	 * @return the eventHeader
	 */
	EventHeader getEventHeader() {
		return eventHeader;
	}

	/**
	 * @param eventHeader the eventHeader to set
	 */
	void setEventHeader(EventHeader eventHeader) {
		this.eventHeader = eventHeader;
	}	

	/**
	 * @param serverTransactionFlag the serverTransactionFlag to set
	 */
	void setServerTransactionFlag(boolean serverTransactionFlag) {
		this.serverTransactionFlag = serverTransactionFlag;
	}

	/**
	 * @param reInviteFlag the reinviteFlag to set
	 */
	void setReInviteFlag(boolean reInviteFlag) {
		this.reInviteFlag = reInviteFlag;
	}

  
	public boolean isSequnceNumberValidation() {
	    return this.sequenceNumberValidation;
	}
   
    public void disableSequenceNumberValidation() {
        this.sequenceNumberValidation = false;
    }
    
   
    public void acquireTimerTaskSem() {
    	boolean acquired = false;
        try {
            acquired = this.timerTaskLock.tryAcquire(10, TimeUnit.SECONDS);
        } catch ( InterruptedException ex) {
            acquired = false;
        }
        if(!acquired) {
        	throw new IllegalStateException("Impossible to acquire the dialog timer task lock");
        }
    }
    
    public void releaseTimerTaskSem() {
        this.timerTaskLock.release();
    }    
    
	
}
