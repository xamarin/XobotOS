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
/******************************************************************************
 * Product of NIST/ITL Advanced Networking Technologies Division (ANTD).      *
 ******************************************************************************/
package gov.nist.javax.sip;

import gov.nist.core.InternalErrorHandler;
import gov.nist.javax.sip.DialogTimeoutEvent.Reason;
import gov.nist.javax.sip.address.RouterExt;
import gov.nist.javax.sip.header.CallID;
import gov.nist.javax.sip.header.Via;
import gov.nist.javax.sip.message.SIPMessage;
import gov.nist.javax.sip.message.SIPRequest;
import gov.nist.javax.sip.message.SIPResponse;
import gov.nist.javax.sip.stack.HopImpl;
import gov.nist.javax.sip.stack.MessageChannel;
import gov.nist.javax.sip.stack.SIPClientTransaction;
import gov.nist.javax.sip.stack.SIPDialog;
import gov.nist.javax.sip.stack.SIPDialogErrorEvent;
import gov.nist.javax.sip.stack.SIPDialogEventListener;
import gov.nist.javax.sip.stack.SIPServerTransaction;
import gov.nist.javax.sip.stack.SIPTransaction;
import gov.nist.javax.sip.stack.SIPTransactionErrorEvent;
import gov.nist.javax.sip.stack.SIPTransactionEventListener;

import java.io.IOException;
import java.text.ParseException;
import java.util.EventObject;
import java.util.Iterator;
import java.util.TooManyListenersException;
import java.util.concurrent.ConcurrentHashMap;

import javax.sip.ClientTransaction;
import javax.sip.Dialog;
import javax.sip.DialogState;
import javax.sip.InvalidArgumentException;
import javax.sip.ListeningPoint;
import javax.sip.ObjectInUseException;
import javax.sip.RequestEvent;
import javax.sip.ResponseEvent;
import javax.sip.ServerTransaction;
import javax.sip.SipException;
import javax.sip.SipListener;
import javax.sip.SipStack;
import javax.sip.Timeout;
import javax.sip.TimeoutEvent;
import javax.sip.Transaction;
import javax.sip.TransactionAlreadyExistsException;
import javax.sip.TransactionState;
import javax.sip.TransactionUnavailableException;
import javax.sip.address.Hop;
import javax.sip.header.CallIdHeader;
import javax.sip.message.Request;
import javax.sip.message.Response;

/*
 * Contributions (bug fixes) made by: Daniel J. Martinez Manzano, Hagai Sela.
 * Bug reports by Shanti Kadiyala, Rhys Ulerich,Victor Hugo
 */
/**
 * Implementation of the JAIN-SIP provider interface.
 *
 * @version 1.2 $Revision: 1.82 $ $Date: 2009/11/24 17:16:59 $
 *
 * @author M. Ranganathan <br/>
 *
 *
 */

public class SipProviderImpl implements javax.sip.SipProvider, gov.nist.javax.sip.SipProviderExt,
        SIPTransactionEventListener, SIPDialogEventListener {

    private SipListener sipListener;

    protected SipStackImpl sipStack;

    /*
     * A set of listening points associated with the provider At most one LP per
     * transport
     */
    private ConcurrentHashMap listeningPoints;

    private EventScanner eventScanner;

    private String address;

    private int port;

    private boolean automaticDialogSupportEnabled ; 
    /**
     * A string containing the 0.0.0.0 IPv4 ANY address.
     */
    private String IN_ADDR_ANY = "0.0.0.0";

    /**
     * A string containing the ::0 IPv6 ANY address.
     */
    private String IN6_ADDR_ANY = "::0";

    private boolean dialogErrorsAutomaticallyHandled = true;
    
    private SipProviderImpl() {
    	
    }

    /**
     * Stop processing messages for this provider. Post an empty message to our
     * message processing queue that signals us to quit.
     */
    protected void stop() {
        // Put an empty event in the queue and post ourselves a message.
        if (sipStack.isLoggingEnabled())
            sipStack.getStackLogger().logDebug("Exiting provider");
        for (Iterator it = listeningPoints.values().iterator(); it.hasNext();) {
            ListeningPointImpl listeningPoint = (ListeningPointImpl) it.next();
            listeningPoint.removeSipProvider();
        }
        this.eventScanner.stop();

    }

    /*
     * (non-Javadoc)
     *
     * @see javax.sip.SipProvider#getListeningPoint(java.lang.String)
     */
    public ListeningPoint getListeningPoint(String transport) {
        if (transport == null)
            throw new NullPointerException("Null transport param");
        return (ListeningPoint) this.listeningPoints.get(transport
                .toUpperCase());
    }

    /**
     * Handle the SIP event - because we have only one listener and we are
     * already in the context of a separate thread, we dont need to enque the
     * event and signal another thread.
     *
     * @param sipEvent
     *            is the event to process.
     *
     */

    public void handleEvent(EventObject sipEvent, SIPTransaction transaction) {
        if (sipStack.isLoggingEnabled()) {
            sipStack.getStackLogger().logDebug(
                    "handleEvent " + sipEvent + "currentTransaction = "
                            + transaction + "this.sipListener = "
                            + this.getSipListener() + "sipEvent.source = "
                            + sipEvent.getSource());
            if (sipEvent instanceof RequestEvent) {
                Dialog dialog = ((RequestEvent) sipEvent).getDialog();
                if ( sipStack.isLoggingEnabled())  sipStack.getStackLogger().logDebug("Dialog = " + dialog);
            } else if (sipEvent instanceof ResponseEvent) {
                Dialog dialog = ((ResponseEvent) sipEvent).getDialog();
                if (sipStack.isLoggingEnabled() ) sipStack.getStackLogger().logDebug("Dialog = " + dialog);
            }
            sipStack.getStackLogger().logStackTrace();
        }

        EventWrapper eventWrapper = new EventWrapper(sipEvent, transaction);

        if (!sipStack.reEntrantListener) {
            // Run the event in the context of a single thread.
            this.eventScanner.addEvent(eventWrapper);
        } else {
            // just call the delivery method
            this.eventScanner.deliverEvent(eventWrapper);
        }
    }

    /** Creates a new instance of SipProviderImpl */
    protected SipProviderImpl(SipStackImpl sipStack) {
        this.eventScanner = sipStack.getEventScanner(); // for quick access.
        this.sipStack = sipStack;
        this.eventScanner.incrementRefcount();
        this.listeningPoints = new ConcurrentHashMap<String,ListeningPointImpl>();
        this.automaticDialogSupportEnabled = this.sipStack
                .isAutomaticDialogSupportEnabled();
        this.dialogErrorsAutomaticallyHandled = this.sipStack.isAutomaticDialogErrorHandlingEnabled();
    }

    /*
     * (non-Javadoc)
     *
     * @see java.lang.Object#clone()
     */
    protected Object clone() throws java.lang.CloneNotSupportedException {
        throw new java.lang.CloneNotSupportedException();
    }

    
    /*
     * (non-Javadoc)
     *
     * @see javax.sip.SipProvider#addSipListener(javax.sip.SipListener)
     */
    public void addSipListener(SipListener sipListener)
            throws TooManyListenersException {

        if (sipStack.sipListener == null) {
            sipStack.sipListener = sipListener;
        } else if (sipStack.sipListener != sipListener) {
            throw new TooManyListenersException(
                    "Stack already has a listener. Only one listener per stack allowed");
        }

        if (sipStack.isLoggingEnabled())
            sipStack.getStackLogger().logDebug("add SipListener " + sipListener);
        this.sipListener = sipListener;

    }

    /*
     * This method is deprecated (non-Javadoc)
     *
     * @see javax.sip.SipProvider#getListeningPoint()
     */

    public ListeningPoint getListeningPoint() {
        if (this.listeningPoints.size() > 0)
            return (ListeningPoint) this.listeningPoints.values().iterator()
                    .next();
        else
            return null;
    }

    /*
     * (non-Javadoc)
     *
     * @see javax.sip.SipProvider#getNewCallId()
     */
    public CallIdHeader getNewCallId() {
        String callId = Utils.getInstance().generateCallIdentifier(this.getListeningPoint()
                .getIPAddress());
        CallID callid = new CallID();
        try {
            callid.setCallId(callId);
        } catch (java.text.ParseException ex) {
        }
        return callid;

    }

    /*
     * (non-Javadoc)
     *
     * @see javax.sip.SipProvider#getNewClientTransaction(javax.sip.message.Request)
     */
    public ClientTransaction getNewClientTransaction(Request request)
            throws TransactionUnavailableException {
        if (request == null)
            throw new NullPointerException("null request");
        if (!sipStack.isAlive())
            throw new TransactionUnavailableException("Stack is stopped");

        SIPRequest sipRequest = (SIPRequest) request;
        if (sipRequest.getTransaction() != null)
            throw new TransactionUnavailableException(
                    "Transaction already assigned to request");
        if ( sipRequest.getMethod().equals(Request.ACK)) {
            throw new TransactionUnavailableException ("Cannot create client transaction for  " + Request.ACK);
        }
        // Be kind and assign a via header for this provider if the user is
        // sloppy
        if (sipRequest.getTopmostVia() == null) {
            ListeningPointImpl lp = (ListeningPointImpl) this
                    .getListeningPoint("udp");
            Via via = lp.getViaHeader();
            request.setHeader(via);
        }
        // Give the request a quick check to see if all headers are assigned.
        try {
            sipRequest.checkHeaders();
        } catch (ParseException ex) {
            throw new TransactionUnavailableException(ex.getMessage(), ex);
        }

        /*
         * User decided to give us his own via header branch. Lets see if it
         * results in a clash. If so reject the request.
         */
        if (sipRequest.getTopmostVia().getBranch() != null
                && sipRequest.getTopmostVia().getBranch().startsWith(
                        SIPConstants.BRANCH_MAGIC_COOKIE)
                && sipStack.findTransaction((SIPRequest) request, false) != null) {
            throw new TransactionUnavailableException(
                    "Transaction already exists!");
        }




        if (request.getMethod().equalsIgnoreCase(Request.CANCEL)) {
            SIPClientTransaction ct = (SIPClientTransaction) sipStack
                    .findCancelTransaction((SIPRequest) request, false);
            if (ct != null) {
                ClientTransaction retval = sipStack.createClientTransaction(
                        (SIPRequest) request, ct.getMessageChannel());

                ((SIPTransaction) retval).addEventListener(this);
                sipStack.addTransaction((SIPClientTransaction) retval);
                if (ct.getDialog() != null) {
                    ((SIPClientTransaction) retval).setDialog((SIPDialog) ct
                            .getDialog(), sipRequest.getDialogId(false));

                }
                return retval;
            }

        }
        if (sipStack.isLoggingEnabled())
            sipStack.getStackLogger().logDebug(
                    "could not find existing transaction for "
                            + ((SIPRequest) request).getFirstLine()
                            + " creating a new one ");

        // Could not find a dialog or the route is not set in dialog.

        Hop hop = null;
        try {
            hop = sipStack.getNextHop((SIPRequest) request);
            if (hop == null)
                throw new TransactionUnavailableException(
                        "Cannot resolve next hop -- transaction unavailable");
        } catch (SipException ex) {
            throw new TransactionUnavailableException(
                    "Cannot resolve next hop -- transaction unavailable", ex);
        }
        String transport = hop.getTransport();
        ListeningPointImpl listeningPoint = (ListeningPointImpl) this
                .getListeningPoint(transport);

        String dialogId = sipRequest.getDialogId(false);
        SIPDialog dialog = sipStack.getDialog(dialogId);
        if (dialog != null && dialog.getState() == DialogState.TERMINATED) {

            // throw new TransactionUnavailableException
            // ("Found a terminated dialog -- possible re-use of old tag
            // parameters");
            sipStack.removeDialog(dialog);

        }

        // An out of dialog route was found. Assign this to the
        // client transaction.

        try {
            // Set the brannch id before you ask for a tx.
            // If the user has set his own branch Id and the
            // branch id starts with a valid prefix, then take it.
            // otherwise, generate one. If branch ID checking has 
            // been requested, set the branch ID.
            String branchId = null;
            if (sipRequest.getTopmostVia().getBranch() == null
                    || !sipRequest.getTopmostVia().getBranch().startsWith(
                            SIPConstants.BRANCH_MAGIC_COOKIE)
                            || sipStack.checkBranchId() ) {
                branchId = Utils.getInstance().generateBranchId();

                sipRequest.getTopmostVia().setBranch(branchId);
            }
            Via topmostVia = sipRequest.getTopmostVia();

            //set port and transport if user hasn't already done this.
            if(topmostVia.getTransport() == null)
                topmostVia.setTransport(transport);

            if(topmostVia.getPort() == -1)
                topmostVia.setPort(listeningPoint.getPort());
            branchId = sipRequest.getTopmostVia().getBranch();

            SIPClientTransaction ct = (SIPClientTransaction) sipStack
                    .createMessageChannel(sipRequest, listeningPoint
                            .getMessageProcessor(), hop);
            if (ct == null)
                throw new TransactionUnavailableException("Cound not create tx");
            ct.setNextHop(hop);
            ct.setOriginalRequest(sipRequest);
            ct.setBranch(branchId);
            // if the stack supports dialogs then
            if (sipStack.isDialogCreated(request.getMethod())) {
                // create a new dialog to contain this transaction
                // provided this is necessary.
                // This could be a re-invite
                // in which case the dialog is re-used.
                // (but noticed by Brad Templeton)
                if (dialog != null)
                    ct.setDialog(dialog, sipRequest.getDialogId(false));
                else if (this.isAutomaticDialogSupportEnabled()) {
                    SIPDialog sipDialog = sipStack.createDialog(ct);
                    ct.setDialog(sipDialog, sipRequest.getDialogId(false));
                }
            } else {
                if (dialog != null) {
                    ct.setDialog(dialog, sipRequest.getDialogId(false));
                }

            }

            // The provider is the event listener for all transactions.
            ct.addEventListener(this);
            return (ClientTransaction) ct;
        } catch (IOException ex) {

            throw new TransactionUnavailableException(
                    "Could not resolve next hop or listening point unavailable! ",
                    ex);

        } catch (java.text.ParseException ex) {
            InternalErrorHandler.handleException(ex);
            throw new TransactionUnavailableException(
                    "Unexpected Exception FIXME! ", ex);
        } catch (InvalidArgumentException ex) {
            InternalErrorHandler.handleException(ex);
            throw new TransactionUnavailableException(
                    "Unexpected Exception FIXME! ", ex);
        }

    }

    /*
     * (non-Javadoc)
     *
     * @see javax.sip.SipProvider#getNewServerTransaction(javax.sip.message.Request)
     */
    public ServerTransaction getNewServerTransaction(Request request)
            throws TransactionAlreadyExistsException,
            TransactionUnavailableException {

        if (!sipStack.isAlive())
            throw new TransactionUnavailableException("Stack is stopped");
        SIPServerTransaction transaction = null;
        SIPRequest sipRequest = (SIPRequest) request;
        try {
            sipRequest.checkHeaders();
        } catch (ParseException ex) {
            throw new TransactionUnavailableException(ex.getMessage(), ex);
        }

        if ( request.getMethod().equals(Request.ACK)) {
            if ( sipStack.isLoggingEnabled())
                sipStack.getStackLogger().logError("Creating server transaction for ACK -- makes no sense!");
            throw new TransactionUnavailableException("Cannot create Server transaction for ACK ");
        }
        /*
         * Got a notify.
         */
        if (sipRequest.getMethod().equals(Request.NOTIFY)
                && sipRequest.getFromTag() != null
                && sipRequest.getToTag() == null) {

            SIPClientTransaction ct = sipStack.findSubscribeTransaction(
                    sipRequest, (ListeningPointImpl) this.getListeningPoint());
            /* Issue 104 */
            if (ct == null && ! sipStack.deliverUnsolicitedNotify) {
                throw new TransactionUnavailableException(
                        "Cannot find matching Subscription (and gov.nist.javax.sip.DELIVER_UNSOLICITED_NOTIFY not set)");
            }
        }
        if ( !sipStack.acquireSem()) {
            throw new TransactionUnavailableException(
            "Transaction not available -- could not acquire stack lock");
        }
        try {
            if (sipStack.isDialogCreated(sipRequest.getMethod())) {
                if (sipStack.findTransaction((SIPRequest) request, true) != null)
                    throw new TransactionAlreadyExistsException(
                    "server transaction already exists!");

                transaction = (SIPServerTransaction) ((SIPRequest) request)
                .getTransaction();
                if (transaction == null)
                    throw new TransactionUnavailableException(
                    "Transaction not available");
                if (transaction.getOriginalRequest() == null)
                    transaction.setOriginalRequest(sipRequest);
                try {
                    sipStack.addTransaction(transaction);
                } catch (IOException ex) {
                    throw new TransactionUnavailableException(
                    "Error sending provisional response");
                }
                // So I can handle timeouts.
                transaction.addEventListener(this);
                if (isAutomaticDialogSupportEnabled()) {
                    // If automatic dialog support is enabled then
                    // this tx gets his own dialog.
                    String dialogId = sipRequest.getDialogId(true);
                    SIPDialog dialog = sipStack.getDialog(dialogId);
                    if (dialog == null) {
                        dialog = sipStack.createDialog(transaction);

                    }
                    transaction.setDialog(dialog, sipRequest.getDialogId(true));
                    if (sipRequest.getMethod().equals(Request.INVITE) && this.isDialogErrorsAutomaticallyHandled()) {
                        sipStack.putInMergeTable(transaction, sipRequest);
                    }
                    dialog.addRoute(sipRequest);
                    if (dialog.getRemoteTag() != null
                            && dialog.getLocalTag() != null) {
                        this.sipStack.putDialog(dialog);
                    }
                }

            } else {
                if (isAutomaticDialogSupportEnabled()) {
                    /*
                     * Under automatic dialog support, dialog is tied into a transaction. You cannot
                     * create a server tx except for dialog creating transactions. After that, all
                     * subsequent transactions are created for you by the stack.
                     */
                    transaction = (SIPServerTransaction) sipStack.findTransaction(
                            (SIPRequest) request, true);
                    if (transaction != null)
                        throw new TransactionAlreadyExistsException(
                        "Transaction exists! ");
                    transaction = (SIPServerTransaction) ((SIPRequest) request)
                    .getTransaction();
                    if (transaction == null)
                        throw new TransactionUnavailableException(
                        "Transaction not available!");
                    if (transaction.getOriginalRequest() == null)
                        transaction.setOriginalRequest(sipRequest);
                    // Map the transaction.
                    try {
                        sipStack.addTransaction(transaction);
                    } catch (IOException ex) {
                        throw new TransactionUnavailableException(
                        "Could not send back provisional response!");
                    }

                    // If there is a dialog already assigned then just update the
                    // dialog state.
                    String dialogId = sipRequest.getDialogId(true);
                    SIPDialog dialog = sipStack.getDialog(dialogId);
                    if (dialog != null) {
                        dialog.addTransaction(transaction);
                        dialog.addRoute(sipRequest);
                        transaction.setDialog(dialog, sipRequest.getDialogId(true));
                    }

                } else {
                    transaction = (SIPServerTransaction) sipStack.findTransaction(
                            (SIPRequest) request, true);
                    if (transaction != null)
                        throw new TransactionAlreadyExistsException(
                        "Transaction exists! ");
                    transaction = (SIPServerTransaction) ((SIPRequest) request)
                    .getTransaction();
                    if (transaction != null) {
                        if (transaction.getOriginalRequest() == null)
                            transaction.setOriginalRequest(sipRequest);
                        // Map the transaction.
                        sipStack.mapTransaction(transaction);

                        // If there is a dialog already assigned then just
                        // assign the dialog to the transaction.
                        String dialogId = sipRequest.getDialogId(true);
                        SIPDialog dialog = sipStack.getDialog(dialogId);
                        if (dialog != null) {
                            dialog.addTransaction(transaction);
                            dialog.addRoute(sipRequest);
                            transaction.setDialog(dialog, sipRequest
                                    .getDialogId(true));
                        }

                        return transaction;
                    } else {
                        // tx does not exist so create the tx.

                        MessageChannel mc = (MessageChannel) sipRequest
                        .getMessageChannel();
                        transaction = sipStack.createServerTransaction(mc);
                        if (transaction == null)
                            throw new TransactionUnavailableException(
                            "Transaction unavailable -- too many servrer transactions");

                        transaction.setOriginalRequest(sipRequest);
                        sipStack.mapTransaction(transaction);

                        // If there is a dialog already assigned then just
                        // assign the dialog to the transaction.
                        String dialogId = sipRequest.getDialogId(true);
                        SIPDialog dialog = sipStack.getDialog(dialogId);
                        if (dialog != null) {
                            dialog.addTransaction(transaction);
                            dialog.addRoute(sipRequest);
                            transaction.setDialog(dialog, sipRequest
                                    .getDialogId(true));
                        }

                        return transaction;
                    }
                }

            }
            return transaction;
        } finally {
            sipStack.releaseSem();
        }

    }

    /*
     * (non-Javadoc)
     *
     * @see javax.sip.SipProvider#getSipStack()
     */
    public SipStack getSipStack() {
        return (SipStack) this.sipStack;
    }

    /*
     * (non-Javadoc)
     *
     * @see javax.sip.SipProvider#removeSipListener(javax.sip.SipListener)
     */
    public void removeSipListener(SipListener sipListener) {
        if (sipListener == this.getSipListener()) {
            this.sipListener = null;
        }

        boolean found = false;

        for (Iterator<SipProviderImpl> it = sipStack.getSipProviders(); it.hasNext();) {
            SipProviderImpl nextProvider = (SipProviderImpl) it.next();
            if (nextProvider.getSipListener() != null)
                found = true;
        }
        if (!found) {
            sipStack.sipListener = null;
        }
    }

    /*
     * (non-Javadoc)
     *
     * @see javax.sip.SipProvider#sendRequest(javax.sip.message.Request)
     */
    public void sendRequest(Request request) throws SipException {
        if (!sipStack.isAlive())
            throw new SipException("Stack is stopped.");

        // mranga: added check to ensure we are not sending empty (keepalive)
        // message.
        if (((SIPRequest) request).getRequestLine() != null
                && request.getMethod().equals(Request.ACK)) {
            Dialog dialog = sipStack.getDialog(((SIPRequest) request)
                    .getDialogId(false));
            if (dialog != null && dialog.getState() != null) {
            	if (sipStack.isLoggingEnabled())
            		sipStack.getStackLogger().logWarning(
                        "Dialog exists -- you may want to use Dialog.sendAck() "
                                + dialog.getState());
            }
        }
        Hop hop = sipStack.getRouter((SIPRequest) request).getNextHop(request);
        if (hop == null)
            throw new SipException("could not determine next hop!");
        SIPRequest sipRequest = (SIPRequest) request;
        // Check if we have a valid via.
        // Null request is used to send default proxy keepalive messages.
        if ((!sipRequest.isNullRequest()) && sipRequest.getTopmostVia() == null)
            throw new SipException("Invalid SipRequest -- no via header!");

        try {
            /*
             * JvB: Via branch should already be OK, dont touch it here? Some
             * apps forward statelessly, and then it's not set. So set only when
             * not set already, dont overwrite CANCEL branch here..
             */
            if (!sipRequest.isNullRequest()) {
                Via via = sipRequest.getTopmostVia();
                String branch = via.getBranch();
                if (branch == null || branch.length() == 0) {
                    via.setBranch(sipRequest.getTransactionId());
                }
            }
            MessageChannel messageChannel = null;
            if (this.listeningPoints.containsKey(hop.getTransport()
                    .toUpperCase()))
                messageChannel = sipStack.createRawMessageChannel(
                        this.getListeningPoint(hop.getTransport()).getIPAddress(),
                        this.getListeningPoint(hop.getTransport()).getPort(), hop);
            if (messageChannel != null) {
                messageChannel.sendMessage((SIPMessage) sipRequest,hop);
            } else {
                throw new SipException(
                        "Could not create a message channel for "
                                + hop.toString());
            }
        } catch (IOException ex) {
            if (sipStack.isLoggingEnabled()) {
                sipStack.getStackLogger().logException(ex);
            }

            throw new SipException(
                    "IO Exception occured while Sending Request", ex);

        } catch (ParseException ex1) {
            InternalErrorHandler.handleException(ex1);
        } finally {
            if (sipStack.isLoggingEnabled())
                sipStack.getStackLogger().logDebug(
                        "done sending " + request.getMethod() + " to hop "
                                + hop);
        }
    }

    /*
     * (non-Javadoc)
     *
     * @see javax.sip.SipProvider#sendResponse(javax.sip.message.Response)
     */
    public void sendResponse(Response response) throws SipException {
        if (!sipStack.isAlive())
            throw new SipException("Stack is stopped");
        SIPResponse sipResponse = (SIPResponse) response;
        Via via = sipResponse.getTopmostVia();
        if (via == null)
            throw new SipException("No via header in response!");
        SIPServerTransaction st = (SIPServerTransaction) sipStack.findTransaction((SIPMessage)response, true);
        if ( st != null   && st.getState() != TransactionState.TERMINATED && this.isAutomaticDialogSupportEnabled()) {
            throw new SipException("Transaction exists -- cannot send response statelessly");
        }
        String transport = via.getTransport();

        // check to see if Via has "received paramaeter". If so
        // set the host to the via parameter. Else set it to the
        // Via host.
        String host = via.getReceived();

        if (host == null)
            host = via.getHost();

        // Symmetric nat support
        int port = via.getRPort();
        if (port == -1) {
            port = via.getPort();
            if (port == -1) {
                if (transport.equalsIgnoreCase("TLS"))
                    port = 5061;
                else
                    port = 5060;
            }
        }

        // for correct management of IPv6 addresses.
        if (host.indexOf(":") > 0)
            if (host.indexOf("[") < 0)
                host = "[" + host + "]";

        Hop hop = sipStack.getAddressResolver().resolveAddress(
                new HopImpl(host, port, transport));

        try {
            ListeningPointImpl listeningPoint = (ListeningPointImpl) this
                    .getListeningPoint(transport);
            if (listeningPoint == null)
                throw new SipException(
                        "whoopsa daisy! no listening point found for transport "
                                + transport);
            MessageChannel messageChannel = sipStack.createRawMessageChannel(
                    this.getListeningPoint(hop.getTransport()).getIPAddress(),
                    listeningPoint.port, hop);
            messageChannel.sendMessage(sipResponse);
        } catch (IOException ex) {
            throw new SipException(ex.getMessage());
        }
    }

    /*
     * (non-Javadoc)
     *
     * @see javax.sip.SipProvider#setListeningPoint(javax.sip.ListeningPoint)
     */
    public synchronized void setListeningPoint(ListeningPoint listeningPoint) {
        if (listeningPoint == null)
            throw new NullPointerException("Null listening point");
        ListeningPointImpl lp = (ListeningPointImpl) listeningPoint;
        lp.sipProvider = this;
        String transport = lp.getTransport().toUpperCase();
        this.address = listeningPoint.getIPAddress();
        this.port = listeningPoint.getPort();
        // This is the first listening point.
        this.listeningPoints.clear();
        this.listeningPoints.put(transport, listeningPoint);

    }

    /*
     * (non-Javadoc)
     *
     * @see javax.sip.SipProvider#getNewDialog(javax.sip.Transaction)
     */

    public Dialog getNewDialog(Transaction transaction) throws SipException {
        if (transaction == null)
            throw new NullPointerException("Null transaction!");

        if (!sipStack.isAlive())
            throw new SipException("Stack is stopped.");

        if (isAutomaticDialogSupportEnabled())
            throw new SipException(" Error - AUTOMATIC_DIALOG_SUPPORT is on");

        if (!sipStack.isDialogCreated(transaction.getRequest().getMethod()))
            throw new SipException("Dialog cannot be created for this method "
                    + transaction.getRequest().getMethod());

        SIPDialog dialog = null;
        SIPTransaction sipTransaction = (SIPTransaction) transaction;

        if (transaction instanceof ServerTransaction) {
            SIPServerTransaction st = (SIPServerTransaction) transaction;
            Response response = st.getLastResponse();
            if (response != null) {
                if (response.getStatusCode() != 100)
                    throw new SipException(
                            "Cannot set dialog after response has been sent");
            }
            SIPRequest sipRequest = (SIPRequest) transaction.getRequest();
            String dialogId = sipRequest.getDialogId(true);
            dialog = sipStack.getDialog(dialogId);
            if (dialog == null) {
                dialog = sipStack.createDialog((SIPTransaction) transaction);
                // create and register the dialog and add the inital route set.
                dialog.addTransaction(sipTransaction);
                dialog.addRoute(sipRequest);
                sipTransaction.setDialog(dialog, null);

            } else {
                sipTransaction.setDialog(dialog, sipRequest.getDialogId(true));
            }
            if (sipRequest.getMethod().equals(Request.INVITE) && this.isDialogErrorsAutomaticallyHandled()) {
                sipStack.putInMergeTable(st, sipRequest);
            }
        } else {

            SIPClientTransaction sipClientTx = (SIPClientTransaction) transaction;

            SIPResponse response = sipClientTx.getLastResponse();

            if (response == null) {
                // A response has not yet been received, then set this up as the
                // default dialog.
                SIPRequest request = (SIPRequest) sipClientTx.getRequest();

                String dialogId = request.getDialogId(false);
                dialog = sipStack.getDialog(dialogId);
                if (dialog != null) {
                    throw new SipException("Dialog already exists!");
                } else {
                    dialog = sipStack.createDialog(sipTransaction);
                }
                sipClientTx.setDialog(dialog, null);

            } else {
                throw new SipException(
                        "Cannot call this method after response is received!");
            }
        }
        dialog.addEventListener(this);
        return dialog;

    }

    /**
     * Invoked when an error has ocurred with a transaction. Propagate up to the
     * listeners.
     *
     * @param transactionErrorEvent
     *            Error event.
     */
    public void transactionErrorEvent(
            SIPTransactionErrorEvent transactionErrorEvent) {
        SIPTransaction transaction = (SIPTransaction) transactionErrorEvent
                .getSource();

        if (transactionErrorEvent.getErrorID() == SIPTransactionErrorEvent.TRANSPORT_ERROR) {
            // There must be a way to inform the TU here!!
            if (sipStack.isLoggingEnabled()) {
                sipStack.getStackLogger().logDebug(
                        "TransportError occured on " + transaction);
            }
            // Treat this like a timeout event. (Suggestion from Christophe).
            Object errorObject = transactionErrorEvent.getSource();
            Timeout timeout = Timeout.TRANSACTION;
            TimeoutEvent ev = null;

            if (errorObject instanceof SIPServerTransaction) {
                ev = new TimeoutEvent(this, (ServerTransaction) errorObject,
                        timeout);
            } else {
                SIPClientTransaction clientTx = (SIPClientTransaction) errorObject;
                Hop hop = clientTx.getNextHop();
                if ( sipStack.getRouter() instanceof RouterExt ) {
                    ((RouterExt) sipStack.getRouter()).transactionTimeout(hop);
                }
                ev = new TimeoutEvent(this, (ClientTransaction) errorObject,
                        timeout);
            }
            // Handling transport error like timeout
            this.handleEvent(ev, (SIPTransaction) errorObject);
        } else if (transactionErrorEvent.getErrorID() == SIPTransactionErrorEvent.TIMEOUT_ERROR) {
            // This is a timeout event.
            Object errorObject = transactionErrorEvent.getSource();
            Timeout timeout = Timeout.TRANSACTION;
            TimeoutEvent ev = null;

            if (errorObject instanceof SIPServerTransaction) {
                ev = new TimeoutEvent(this, (ServerTransaction) errorObject,
                        timeout);
            } else {
                SIPClientTransaction clientTx = (SIPClientTransaction) errorObject;
                Hop hop = clientTx.getNextHop();
                if ( sipStack.getRouter() instanceof RouterExt ) {
                    ((RouterExt) sipStack.getRouter()).transactionTimeout(hop);
                }

                ev = new TimeoutEvent(this, (ClientTransaction) errorObject,
                        timeout);
            }
            this.handleEvent(ev, (SIPTransaction) errorObject);

        } else if (transactionErrorEvent.getErrorID() == SIPTransactionErrorEvent.TIMEOUT_RETRANSMIT) {
            // This is a timeout retransmit event.
            // We should never get this if retransmit filter is
            // enabled (ie. in that case the stack should handle.
            // all retransmits.
            Object errorObject = transactionErrorEvent.getSource();
            Transaction tx = (Transaction) errorObject;

            if (tx.getDialog() != null)
                InternalErrorHandler.handleException("Unexpected event !",
                        this.sipStack.getStackLogger());

            Timeout timeout = Timeout.RETRANSMIT;
            TimeoutEvent ev = null;

            if (errorObject instanceof SIPServerTransaction) {
                ev = new TimeoutEvent(this, (ServerTransaction) errorObject,
                        timeout);
            } else {
                ev = new TimeoutEvent(this, (ClientTransaction) errorObject,
                        timeout);
            }
            this.handleEvent(ev, (SIPTransaction) errorObject);
        }
    }
    
    /*
     * (non-Javadoc)
     * @see gov.nist.javax.sip.stack.SIPDialogEventListener#dialogErrorEvent(gov.nist.javax.sip.stack.SIPDialogErrorEvent)
     */
    public synchronized void dialogErrorEvent(SIPDialogErrorEvent dialogErrorEvent) {
        SIPDialog sipDialog = (SIPDialog) dialogErrorEvent.getSource();
        Reason reason = Reason.AckNotReceived;
        if (dialogErrorEvent.getErrorID() == SIPDialogErrorEvent.DIALOG_ACK_NOT_SENT_TIMEOUT) {
        	reason= Reason.AckNotSent;
        } else if (dialogErrorEvent.getErrorID() == SIPDialogErrorEvent.DIALOG_REINVITE_TIMEOUT) {
            reason = Reason.ReInviteTimeout;
        }
        if (sipStack.isLoggingEnabled()) {
            sipStack.getStackLogger().logDebug(
                    "Dialog TimeoutError occured on " + sipDialog);
        }
        DialogTimeoutEvent ev = new DialogTimeoutEvent(this, sipDialog, reason);
        // Handling transport error like timeout
        this.handleEvent(ev, null);
    }

    /*
     * (non-Javadoc)
     *
     * @see javax.sip.SipProvider#getListeningPoints()
     */
    public synchronized ListeningPoint[] getListeningPoints() {

        ListeningPoint[] retval = new ListeningPointImpl[this.listeningPoints
                .size()];
        this.listeningPoints.values().toArray(retval);
        return retval;
    }

    /*
     * (non-Javadoc)
     *
     * @see javax.sip.SipProvider#addListeningPoint(javax.sip.ListeningPoint)
     */
    public synchronized void addListeningPoint(ListeningPoint listeningPoint)
            throws ObjectInUseException {
        ListeningPointImpl lp = (ListeningPointImpl) listeningPoint;
        if (lp.sipProvider != null && lp.sipProvider != this)
            throw new ObjectInUseException(
                    "Listening point assigned to another provider");
        String transport = lp.getTransport().toUpperCase();
        if (this.listeningPoints.isEmpty()) {
            // first one -- record the IP address/port of the LP

            this.address = listeningPoint.getIPAddress();
            this.port = listeningPoint.getPort();
        } else {
            if ((!this.address.equals(listeningPoint.getIPAddress()))
                    || this.port != listeningPoint.getPort())
                throw new ObjectInUseException(
                        "Provider already has different IP Address associated");

        }
        if (this.listeningPoints.containsKey(transport)
                && this.listeningPoints.get(transport) != listeningPoint)
            throw new ObjectInUseException(
                    "Listening point already assigned for transport!");

        // This is for backwards compatibility.
        lp.sipProvider = this;

        this.listeningPoints.put(transport, lp);

    }

    /*
     * (non-Javadoc)
     *
     * @see javax.sip.SipProvider#removeListeningPoint(javax.sip.ListeningPoint)
     */
    public synchronized void removeListeningPoint(ListeningPoint listeningPoint)
            throws ObjectInUseException {
        ListeningPointImpl lp = (ListeningPointImpl) listeningPoint;
        if (lp.messageProcessor.inUse())
            throw new ObjectInUseException("Object is in use");
        this.listeningPoints.remove(lp.getTransport().toUpperCase());

    }

    /**
     * Remove all the listening points for this sip provider. This is called
     * when the stack removes the Provider
     */
    public synchronized void removeListeningPoints() {
        for (Iterator it = this.listeningPoints.values().iterator(); it
                .hasNext();) {
            ListeningPointImpl lp = (ListeningPointImpl) it.next();
            lp.messageProcessor.stop();
            it.remove();
        }

    }

    /*
     * (non-Javadoc)
     *
     * @see javax.sip.SipProvider#setAutomaticDialogSupportEnabled(boolean)
     */
    public void setAutomaticDialogSupportEnabled(
            boolean automaticDialogSupportEnabled) {
        this.automaticDialogSupportEnabled = automaticDialogSupportEnabled;
        if ( this.automaticDialogSupportEnabled ) {
            this.dialogErrorsAutomaticallyHandled = true;
        }
    }

    /**
     * @return Returns the automaticDialogSupportEnabled.
     */
    public boolean isAutomaticDialogSupportEnabled() {
        return automaticDialogSupportEnabled;
    }

    /*
     * (non-Javadoc)
     * @see gov.nist.javax.sip.SipProviderExt#setDialogErrorsAutomaticallyHandled()
     */
    public void setDialogErrorsAutomaticallyHandled() {
        this.dialogErrorsAutomaticallyHandled = true;
    }
    
    public boolean isDialogErrorsAutomaticallyHandled() {
        return this.dialogErrorsAutomaticallyHandled;
    }


    /**
     * @return the sipListener
     */
    public SipListener getSipListener() {
        return sipListener;
    }

   
}
