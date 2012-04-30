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
 * Product of NIST/ITL Advanced Networking Technologies Division (ANTD)         *
 *******************************************************************************/
package gov.nist.javax.sip.message;

import gov.nist.javax.sip.address.*;
import gov.nist.core.*;

import java.util.HashSet;
import java.util.Hashtable;
import java.util.LinkedList;
import java.util.Set;
import java.io.UnsupportedEncodingException;
import java.util.Iterator;
import javax.sip.address.URI;
import javax.sip.message.*;

import java.text.ParseException;
import javax.sip.*;
import javax.sip.header.*;

import gov.nist.javax.sip.header.*;
import gov.nist.javax.sip.stack.SIPTransactionStack;

/*
 * Acknowledgements: Mark Bednarek made a few fixes to this code. Jeff Keyser added two methods
 * that create responses and generate cancel requests from incoming orignial requests without the
 * additional overhead of encoding and decoding messages. Bruno Konik noticed an extraneous
 * newline added to the end of the buffer when encoding it. Incorporates a bug report from Andreas
 * Bystrom. Szabo Barna noticed a contact in a cancel request - this is a pointless header for
 * cancel. Antonis Kyardis contributed bug fixes. Jeroen van Bemmel noted that method names are
 * case sensitive, should use equals() in getting CannonicalName
 * 
 */

/**
 * The SIP Request structure.
 * 
 * @version 1.2 $Revision: 1.52 $ $Date: 2009/12/16 14:58:40 $
 * @since 1.1
 * 
 * @author M. Ranganathan <br/>
 * 
 * 
 * 
 */

public final class SIPRequest extends SIPMessage implements javax.sip.message.Request, RequestExt {

    private static final long serialVersionUID = 3360720013577322927L;

    private static final String DEFAULT_USER = "ip";

    private static final String DEFAULT_TRANSPORT = "udp";

    private transient Object transactionPointer;

    private RequestLine requestLine;

    private transient Object messageChannel;
    
    

    private transient Object inviteTransaction; // The original invite request for a
    // given cancel request

    /**
     * Set of target refresh methods, currently: INVITE, UPDATE, SUBSCRIBE, NOTIFY, REFER
     * 
     * A target refresh request and its response MUST have a Contact
     */
    private static final Set<String> targetRefreshMethods = new HashSet<String>();

    /*
     * A table that maps a name string to its cannonical constant. This is used to speed up
     * parsing of messages .equals reduces to == if we use the constant value.
     */
    private static final Hashtable<String, String> nameTable = new Hashtable<String, String>();

    private static void putName(String name) {
        nameTable.put(name, name);
    }

    static {
        targetRefreshMethods.add(Request.INVITE);
        targetRefreshMethods.add(Request.UPDATE);
        targetRefreshMethods.add(Request.SUBSCRIBE);
        targetRefreshMethods.add(Request.NOTIFY);
        targetRefreshMethods.add(Request.REFER);

        putName(Request.INVITE);
        putName(Request.BYE);
        putName(Request.CANCEL);
        putName(Request.ACK);
        putName(Request.PRACK);
        putName(Request.INFO);
        putName(Request.MESSAGE);
        putName(Request.NOTIFY);
        putName(Request.OPTIONS);
        putName(Request.PRACK);
        putName(Request.PUBLISH);
        putName(Request.REFER);
        putName(Request.REGISTER);
        putName(Request.SUBSCRIBE);
        putName(Request.UPDATE);

    }

    /**
     * @return true iff the method is a target refresh
     */
    public static boolean isTargetRefresh(String ucaseMethod) {
        return targetRefreshMethods.contains(ucaseMethod);
    }

    /**
     * @return true iff the method is a dialog creating method
     */
    public static boolean isDialogCreating(String ucaseMethod) {
        return SIPTransactionStack.isDialogCreated(ucaseMethod);
    }
    
    /**
     * Set to standard constants to speed up processing. this makes equals comparisons run much
     * faster in the stack because then it is just identity comparision. Character by char
     * comparison is not required. The method returns the String CONSTANT corresponding to the
     * String name.
     * 
     */
    public static String getCannonicalName(String method) {

        if (nameTable.containsKey(method))
            return (String) nameTable.get(method);
        else
            return method;
    }

    /**
     * Get the Request Line of the SIPRequest.
     * 
     * @return the request line of the SIP Request.
     */

    public RequestLine getRequestLine() {
        return requestLine;
    }

    /**
     * Set the request line of the SIP Request.
     * 
     * @param requestLine is the request line to set in the SIP Request.
     */

    public void setRequestLine(RequestLine requestLine) {
        this.requestLine = requestLine;
    }

    /**
     * Constructor.
     */
    public SIPRequest() {
        super();
    }

    /**
     * Convert to a formatted string for pretty printing. Note that the encode method converts
     * this into a sip message that is suitable for transmission. Note hack here if you want to
     * convert the nice curly brackets into some grotesque XML tag.
     * 
     * @return a string which can be used to examine the message contents.
     * 
     */
    public String debugDump() {
        String superstring = super.debugDump();
        stringRepresentation = "";
        sprint(SIPRequest.class.getName());
        sprint("{");
        if (requestLine != null)
            sprint(requestLine.debugDump());
        sprint(superstring);
        sprint("}");
        return stringRepresentation;
    }

    /**
     * Check header for constraints. (1) Invite options and bye requests can only have SIP URIs in
     * the contact headers. (2) Request must have cseq, to and from and via headers. (3) Method in
     * request URI must match that in CSEQ.
     */
    public void checkHeaders() throws ParseException {
        String prefix = "Missing a required header : ";

        /* Check for required headers */

        if (getCSeq() == null) {
            throw new ParseException(prefix + CSeqHeader.NAME, 0);
        }
        if (getTo() == null) {
            throw new ParseException(prefix + ToHeader.NAME, 0);
        }

        if (this.callIdHeader == null || this.callIdHeader.getCallId() == null
                || callIdHeader.getCallId().equals("")) {
            throw new ParseException(prefix + CallIdHeader.NAME, 0);
        }
        if (getFrom() == null) {
            throw new ParseException(prefix + FromHeader.NAME, 0);
        }
        if (getViaHeaders() == null) {
            throw new ParseException(prefix + ViaHeader.NAME, 0);
        }
        // BEGIN android-deleted
        /*
        if (getMaxForwards() == null) {
            throw new ParseException(prefix + MaxForwardsHeader.NAME, 0);
        }
        */
        // END android-deleted

        if (getTopmostVia() == null)
            throw new ParseException("No via header in request! ", 0);

        if (getMethod().equals(Request.NOTIFY)) {
            if (getHeader(SubscriptionStateHeader.NAME) == null)
                throw new ParseException(prefix + SubscriptionStateHeader.NAME, 0);

            if (getHeader(EventHeader.NAME) == null)
                throw new ParseException(prefix + EventHeader.NAME, 0);

        } else if (getMethod().equals(Request.PUBLISH)) {
            /*
             * For determining the type of the published event state, the EPA MUST include a
             * single Event header field in PUBLISH requests. The value of this header field
             * indicates the event package for which this request is publishing event state.
             */
            if (getHeader(EventHeader.NAME) == null)
                throw new ParseException(prefix + EventHeader.NAME, 0);
        }

        /*
         * RFC 3261 8.1.1.8 The Contact header field MUST be present and contain exactly one SIP
         * or SIPS URI in any request that can result in the establishment of a dialog. For the
         * methods defined in this specification, that includes only the INVITE request. For these
         * requests, the scope of the Contact is global. That is, the Contact header field value
         * contains the URI at which the UA would like to receive requests, and this URI MUST be
         * valid even if used in subsequent requests outside of any dialogs.
         * 
         * If the Request-URI or top Route header field value contains a SIPS URI, the Contact
         * header field MUST contain a SIPS URI as well.
         */
        if (requestLine.getMethod().equals(Request.INVITE)
                || requestLine.getMethod().equals(Request.SUBSCRIBE)
                || requestLine.getMethod().equals(Request.REFER)) {
            if (this.getContactHeader() == null) {
                // Make sure this is not a target refresh. If this is a target
                // refresh its ok not to have a contact header. Otherwise
                // contact header is mandatory.
                if (this.getToTag() == null)
                    throw new ParseException(prefix + ContactHeader.NAME, 0);
            }

            if (requestLine.getUri() instanceof SipUri) {
                String scheme = ((SipUri) requestLine.getUri()).getScheme();
                if ("sips".equalsIgnoreCase(scheme)) {
                    SipUri sipUri = (SipUri) this.getContactHeader().getAddress().getURI();
                    if (!sipUri.getScheme().equals("sips")) {
                        throw new ParseException("Scheme for contact should be sips:" + sipUri, 0);
                    }
                }
            }
        }

        /*
         * Contact header is mandatory for a SIP INVITE request.
         */
        if (this.getContactHeader() == null
                && (this.getMethod().equals(Request.INVITE)
                        || this.getMethod().equals(Request.REFER) || this.getMethod().equals(
                        Request.SUBSCRIBE))) {
            throw new ParseException("Contact Header is Mandatory for a SIP INVITE", 0);
        }

        if (requestLine != null && requestLine.getMethod() != null
                && getCSeq().getMethod() != null
                && requestLine.getMethod().compareTo(getCSeq().getMethod()) != 0) {
            throw new ParseException("CSEQ method mismatch with  Request-Line ", 0);

        }

    }

    /**
     * Set the default values in the request URI if necessary.
     */
    protected void setDefaults() {
        // The request line may be unparseable (set to null by the
        // exception handler.
        if (requestLine == null)
            return;
        String method = requestLine.getMethod();
        // The requestLine may be malformed!
        if (method == null)
            return;
        GenericURI u = requestLine.getUri();
        if (u == null)
            return;
        if (method.compareTo(Request.REGISTER) == 0 || method.compareTo(Request.INVITE) == 0) {
            if (u instanceof SipUri) {
                SipUri sipUri = (SipUri) u;
                sipUri.setUserParam(DEFAULT_USER);
                try {
                    sipUri.setTransportParam(DEFAULT_TRANSPORT);
                } catch (ParseException ex) {
                }
            }
        }
    }

    /**
     * Patch up the request line as necessary.
     */
    protected void setRequestLineDefaults() {
        String method = requestLine.getMethod();
        if (method == null) {
            CSeq cseq = (CSeq) this.getCSeq();
            if (cseq != null) {
                method = getCannonicalName(cseq.getMethod());
                requestLine.setMethod(method);
            }
        }
    }

    /**
     * A conveniance function to access the Request URI.
     * 
     * @return the requestURI if it exists.
     */
    public javax.sip.address.URI getRequestURI() {
        if (this.requestLine == null)
            return null;
        else
            return (javax.sip.address.URI) this.requestLine.getUri();
    }

    /**
     * Sets the RequestURI of Request. The Request-URI is a SIP or SIPS URI or a general URI. It
     * indicates the user or service to which this request is being addressed. SIP elements MAY
     * support Request-URIs with schemes other than "sip" and "sips", for example the "tel" URI
     * scheme. SIP elements MAY translate non-SIP URIs using any mechanism at their disposal,
     * resulting in SIP URI, SIPS URI, or some other scheme.
     * 
     * @param uri the new Request URI of this request message
     */
    public void setRequestURI(URI uri) {
        if ( uri == null ) {
            throw new NullPointerException("Null request URI");
        }
        if (this.requestLine == null) {
            this.requestLine = new RequestLine();
        }
        this.requestLine.setUri((GenericURI) uri);
        this.nullRequest = false;
    }

    /**
     * Set the method.
     * 
     * @param method is the method to set.
     * @throws IllegalArgumentException if the method is null
     */
    public void setMethod(String method) {
        if (method == null)
            throw new IllegalArgumentException("null method");
        if (this.requestLine == null) {
            this.requestLine = new RequestLine();
        }

        // Set to standard constants to speed up processing.
        // this makes equals compares run much faster in the
        // stack because then it is just identity comparision

        String meth = getCannonicalName(method);
        this.requestLine.setMethod(meth);

        if (this.cSeqHeader != null) {
            try {
                this.cSeqHeader.setMethod(meth);
            } catch (ParseException e) {
            }
        }
    }

    /**
     * Get the method from the request line.
     * 
     * @return the method from the request line if the method exits and null if the request line
     *         or the method does not exist.
     */
    public String getMethod() {
        if (requestLine == null)
            return null;
        else
            return requestLine.getMethod();
    }

    /**
     * Encode the SIP Request as a string.
     * 
     * @return an encoded String containing the encoded SIP Message.
     */

    public String encode() {
        String retval;
        if (requestLine != null) {
            this.setRequestLineDefaults();
            retval = requestLine.encode() + super.encode();
        } else if (this.isNullRequest()) {
            retval = "\r\n\r\n";
        } else {       
            retval = super.encode();
        }
        return retval;
    }

    /**
     * Encode only the headers and not the content.
     */
    public String encodeMessage() {
        String retval;
        if (requestLine != null) {
            this.setRequestLineDefaults();
            retval = requestLine.encode() + super.encodeSIPHeaders();
        } else if (this.isNullRequest()) {
            retval = "\r\n\r\n";
        } else
            retval = super.encodeSIPHeaders();
        return retval;

    }

    /**
     * ALias for encode above.
     */
    public String toString() {
        return this.encode();
    }

    /**
     * Make a clone (deep copy) of this object. You can use this if you want to modify a request
     * while preserving the original
     * 
     * @return a deep copy of this object.
     */

    public Object clone() {
        SIPRequest retval = (SIPRequest) super.clone();
        // Do not copy over the tx pointer -- this is only for internal
        // tracking.
        retval.transactionPointer = null;
        if (this.requestLine != null)
            retval.requestLine = (RequestLine) this.requestLine.clone();

        return retval;
    }

    /**
     * Compare for equality.
     * 
     * @param other object to compare ourselves with.
     */
    public boolean equals(Object other) {
        if (!this.getClass().equals(other.getClass()))
            return false;
        SIPRequest that = (SIPRequest) other;

        return requestLine.equals(that.requestLine) && super.equals(other);
    }

    /**
     * Get the message as a linked list of strings. Use this if you want to iterate through the
     * message.
     * 
     * @return a linked list containing the request line and headers encoded as strings.
     */
    public LinkedList getMessageAsEncodedStrings() {
        LinkedList retval = super.getMessageAsEncodedStrings();
        if (requestLine != null) {
            this.setRequestLineDefaults();
            retval.addFirst(requestLine.encode());
        }
        return retval;

    }

    /**
     * Match with a template. You can use this if you want to match incoming messages with a
     * pattern and do something when you find a match. This is useful for building filters/pattern
     * matching responders etc.
     * 
     * @param matchObj object to match ourselves with (null matches wildcard)
     * 
     */
    public boolean match(Object matchObj) {
        if (matchObj == null)
            return true;
        else if (!matchObj.getClass().equals(this.getClass()))
            return false;
        else if (matchObj == this)
            return true;
        SIPRequest that = (SIPRequest) matchObj;
        RequestLine rline = that.requestLine;
        if (this.requestLine == null && rline != null)
            return false;
        else if (this.requestLine == rline)
            return super.match(matchObj);
        return requestLine.match(that.requestLine) && super.match(matchObj);

    }

    /**
     * Get a dialog identifier. Generates a string that can be used as a dialog identifier.
     * 
     * @param isServer is set to true if this is the UAS and set to false if this is the UAC
     */
    public String getDialogId(boolean isServer) {
        CallID cid = (CallID) this.getCallId();
        StringBuffer retval = new StringBuffer(cid.getCallId());
        From from = (From) this.getFrom();
        To to = (To) this.getTo();
        if (!isServer) {
            // retval.append(COLON).append(from.getUserAtHostPort());
            if (from.getTag() != null) {
                retval.append(COLON);
                retval.append(from.getTag());
            }
            // retval.append(COLON).append(to.getUserAtHostPort());
            if (to.getTag() != null) {
                retval.append(COLON);
                retval.append(to.getTag());
            }
        } else {
            // retval.append(COLON).append(to.getUserAtHostPort());
            if (to.getTag() != null) {
                retval.append(COLON);
                retval.append(to.getTag());
            }
            // retval.append(COLON).append(from.getUserAtHostPort());
            if (from.getTag() != null) {
                retval.append(COLON);
                retval.append(from.getTag());
            }
        }
        return retval.toString().toLowerCase();

    }

    /**
     * Get a dialog id given the remote tag.
     */
    public String getDialogId(boolean isServer, String toTag) {
        From from = (From) this.getFrom();
        CallID cid = (CallID) this.getCallId();
        StringBuffer retval = new StringBuffer(cid.getCallId());
        if (!isServer) {
            // retval.append(COLON).append(from.getUserAtHostPort());
            if (from.getTag() != null) {
                retval.append(COLON);
                retval.append(from.getTag());
            }
            // retval.append(COLON).append(to.getUserAtHostPort());
            if (toTag != null) {
                retval.append(COLON);
                retval.append(toTag);
            }
        } else {
            // retval.append(COLON).append(to.getUserAtHostPort());
            if (toTag != null) {
                retval.append(COLON);
                retval.append(toTag);
            }
            // retval.append(COLON).append(from.getUserAtHostPort());
            if (from.getTag() != null) {
                retval.append(COLON);
                retval.append(from.getTag());
            }
        }
        return retval.toString().toLowerCase();
    }

    /**
     * Encode this into a byte array. This is used when the body has been set as a binary array
     * and you want to encode the body as a byte array for transmission.
     * 
     * @return a byte array containing the SIPRequest encoded as a byte array.
     */

    public byte[] encodeAsBytes(String transport) {
        if (this.isNullRequest()) {
            // Encoding a null message for keepalive.
            return "\r\n\r\n".getBytes();
        } else if ( this.requestLine == null ) {
            return new byte[0];
        }

        byte[] rlbytes = null;
        if (requestLine != null) {
            try {
                rlbytes = requestLine.encode().getBytes("UTF-8");
            } catch (UnsupportedEncodingException ex) {
                InternalErrorHandler.handleException(ex);
            }
        }
        byte[] superbytes = super.encodeAsBytes(transport);
        byte[] retval = new byte[rlbytes.length + superbytes.length];
        System.arraycopy(rlbytes, 0, retval, 0, rlbytes.length);
        System.arraycopy(superbytes, 0, retval, rlbytes.length, superbytes.length);
        return retval;
    }

    /**
     * Creates a default SIPResponse message for this request. Note You must add the necessary
     * tags to outgoing responses if need be. For efficiency, this method does not clone the
     * incoming request. If you want to modify the outgoing response, be sure to clone the
     * incoming request as the headers are shared and any modification to the headers of the
     * outgoing response will result in a modification of the incoming request. Tag fields are
     * just copied from the incoming request. Contact headers are removed from the incoming
     * request. Added by Jeff Keyser.
     * 
     * @param statusCode Status code for the response. Reason phrase is generated.
     * 
     * @return A SIPResponse with the status and reason supplied, and a copy of all the original
     *         headers from this request.
     */

    public SIPResponse createResponse(int statusCode) {

        String reasonPhrase = SIPResponse.getReasonPhrase(statusCode);
        return this.createResponse(statusCode, reasonPhrase);

    }

    /**
     * Creates a default SIPResponse message for this request. Note You must add the necessary
     * tags to outgoing responses if need be. For efficiency, this method does not clone the
     * incoming request. If you want to modify the outgoing response, be sure to clone the
     * incoming request as the headers are shared and any modification to the headers of the
     * outgoing response will result in a modification of the incoming request. Tag fields are
     * just copied from the incoming request. Contact headers are removed from the incoming
     * request. Added by Jeff Keyser. Route headers are not added to the response.
     * 
     * @param statusCode Status code for the response.
     * @param reasonPhrase Reason phrase for this response.
     * 
     * @return A SIPResponse with the status and reason supplied, and a copy of all the original
     *         headers from this request except the ones that are not supposed to be part of the
     *         response .
     */

    public SIPResponse createResponse(int statusCode, String reasonPhrase) {
        SIPResponse newResponse;
        Iterator headerIterator;
        SIPHeader nextHeader;

        newResponse = new SIPResponse();
        try {
            newResponse.setStatusCode(statusCode);
        } catch (ParseException ex) {
            throw new IllegalArgumentException("Bad code " + statusCode);
        }
        if (reasonPhrase != null)
            newResponse.setReasonPhrase(reasonPhrase);
        else
            newResponse.setReasonPhrase(SIPResponse.getReasonPhrase(statusCode));
        headerIterator = getHeaders();
        while (headerIterator.hasNext()) {
            nextHeader = (SIPHeader) headerIterator.next();
            if (nextHeader instanceof From
                    || nextHeader instanceof To
                    || nextHeader instanceof ViaList
                    || nextHeader instanceof CallID
                    || (nextHeader instanceof RecordRouteList && mustCopyRR(statusCode))
                    || nextHeader instanceof CSeq
                    // We just copy TimeStamp for all headers (not just 100).
                    || nextHeader instanceof TimeStamp) {

                try {

                    newResponse.attachHeader((SIPHeader) nextHeader.clone(), false);
                } catch (SIPDuplicateHeaderException e) {
                    e.printStackTrace();
                }
            }
        }
        if (MessageFactoryImpl.getDefaultServerHeader() != null) {
            newResponse.setHeader(MessageFactoryImpl.getDefaultServerHeader());

        }
        if (newResponse.getStatusCode() == 100) {
            // Trying is never supposed to have the tag parameter set.
            newResponse.getTo().removeParameter("tag");

        }
        ServerHeader server = MessageFactoryImpl.getDefaultServerHeader();
        if (server != null) {
            newResponse.setHeader(server);
        }
        return newResponse;
    }

    // Helper method for createResponse, to avoid copying Record-Route unless needed
    private final boolean mustCopyRR( int code ) {
    	// Only for 1xx-2xx, not for 100 or errors
    	if ( code>100 && code<300 ) {
    		return isDialogCreating( this.getMethod() ) && getToTag() == null;
    	} else return false;
    }
    
    /**
     * Creates a default SIPResquest message that would cancel this request. Note that tag
     * assignment and removal of is left to the caller (we use whatever tags are present in the
     * original request).
     * 
     * @return A CANCEL SIPRequest constructed according to RFC3261 section 9.1
     * 
     * @throws SipException
     * @throws ParseException
     */
    public SIPRequest createCancelRequest() throws SipException {

        // see RFC3261 9.1

        // A CANCEL request SHOULD NOT be sent to cancel a request other than
        // INVITE

        if (!this.getMethod().equals(Request.INVITE))
            throw new SipException("Attempt to create CANCEL for " + this.getMethod());

        /*
         * The following procedures are used to construct a CANCEL request. The Request-URI,
         * Call-ID, To, the numeric part of CSeq, and From header fields in the CANCEL request
         * MUST be identical to those in the request being cancelled, including tags. A CANCEL
         * constructed by a client MUST have only a single Via header field value matching the top
         * Via value in the request being cancelled. Using the same values for these header fields
         * allows the CANCEL to be matched with the request it cancels (Section 9.2 indicates how
         * such matching occurs). However, the method part of the CSeq header field MUST have a
         * value of CANCEL. This allows it to be identified and processed as a transaction in its
         * own right (See Section 17).
         */
        SIPRequest cancel = new SIPRequest();
        cancel.setRequestLine((RequestLine) this.requestLine.clone());
        cancel.setMethod(Request.CANCEL);
        cancel.setHeader((Header) this.callIdHeader.clone());
        cancel.setHeader((Header) this.toHeader.clone());
        cancel.setHeader((Header) cSeqHeader.clone());
        try {
            cancel.getCSeq().setMethod(Request.CANCEL);
        } catch (ParseException e) {
            e.printStackTrace(); // should not happen
        }
        cancel.setHeader((Header) this.fromHeader.clone());

        cancel.addFirst((Header) this.getTopmostVia().clone());
        cancel.setHeader((Header) this.maxForwardsHeader.clone());

        /*
         * If the request being cancelled contains a Route header field, the CANCEL request MUST
         * include that Route header field's values.
         */
        if (this.getRouteHeaders() != null) {
            cancel.setHeader((SIPHeaderList< ? >) this.getRouteHeaders().clone());
        }
        if (MessageFactoryImpl.getDefaultUserAgentHeader() != null) {
            cancel.setHeader(MessageFactoryImpl.getDefaultUserAgentHeader());

        }
        return cancel;
    }

    /**
     * Creates a default ACK SIPRequest message for this original request. Note that the
     * defaultACK SIPRequest does not include the content of the original SIPRequest. If
     * responseToHeader is null then the toHeader of this request is used to construct the ACK.
     * Note that tag fields are just copied from the original SIP Request. Added by Jeff Keyser.
     * 
     * @param responseToHeader To header to use for this request.
     * 
     * @return A SIPRequest with an ACK method.
     */
    public SIPRequest createAckRequest(To responseToHeader) {
        SIPRequest newRequest;
        Iterator headerIterator;
        SIPHeader nextHeader;

        newRequest = new SIPRequest();
        newRequest.setRequestLine((RequestLine) this.requestLine.clone());
        newRequest.setMethod(Request.ACK);
        headerIterator = getHeaders();
        while (headerIterator.hasNext()) {
            nextHeader = (SIPHeader) headerIterator.next();
            if (nextHeader instanceof RouteList) {
                // Ack and cancel do not get ROUTE headers.
                // Route header for ACK is assigned by the
                // Dialog if necessary.
                continue;
            } else if (nextHeader instanceof ProxyAuthorization) {
                // Remove proxy auth header.
                // Assigned by the Dialog if necessary.
                continue;
            } else if (nextHeader instanceof ContentLength) {
                // Adding content is responsibility of user.
                nextHeader = (SIPHeader) nextHeader.clone();
                try {
                    ((ContentLength) nextHeader).setContentLength(0);
                } catch (InvalidArgumentException e) {
                }
            } else if (nextHeader instanceof ContentType) {
                // Content type header is removed since
                // content length is 0.
                continue;
            } else if (nextHeader instanceof CSeq) {
                // The CSeq header field in the
                // ACK MUST contain the same value for the
                // sequence number as was present in the
                // original request, but the method parameter
                // MUST be equal to "ACK".
                CSeq cseq = (CSeq) nextHeader.clone();
                try {
                    cseq.setMethod(Request.ACK);
                } catch (ParseException e) {
                }
                nextHeader = cseq;
            } else if (nextHeader instanceof To) {
                if (responseToHeader != null) {
                    nextHeader = responseToHeader;
                } else {
                    nextHeader = (SIPHeader) nextHeader.clone();
                }
            } else if (nextHeader instanceof ContactList || nextHeader instanceof Expires) {
                // CONTACT header does not apply for ACK requests.
                continue;
            } else if (nextHeader instanceof ViaList) {
                // Bug reported by Gianluca Martinello
                // The ACK MUST contain a single Via header field,
                // and this MUST be equal to the top Via header
                // field of the original
                // request.

                nextHeader = (SIPHeader) ((ViaList) nextHeader).getFirst().clone();
            } else {
                nextHeader = (SIPHeader) nextHeader.clone();
            }

            try {
                newRequest.attachHeader(nextHeader, false);
            } catch (SIPDuplicateHeaderException e) {
                e.printStackTrace();
            }
        }
        if (MessageFactoryImpl.getDefaultUserAgentHeader() != null) {
            newRequest.setHeader(MessageFactoryImpl.getDefaultUserAgentHeader());

        }
        return newRequest;
    }

    /**
     * Creates an ACK for non-2xx responses according to RFC3261 17.1.1.3
     * 
     * @return A SIPRequest with an ACK method.
     * @throws SipException
     * @throws NullPointerException
     * @throws ParseException
     * 
     * @author jvb
     */
    public final SIPRequest createErrorAck(To responseToHeader) throws SipException,
            ParseException {

        /*
         * The ACK request constructed by the client transaction MUST contain values for the
         * Call-ID, From, and Request-URI that are equal to the values of those header fields in
         * the request passed to the transport by the client transaction (call this the "original
         * request"). The To header field in the ACK MUST equal the To header field in the
         * response being acknowledged, and therefore will usually differ from the To header field
         * in the original request by the addition of the tag parameter. The ACK MUST contain a
         * single Via header field, and this MUST be equal to the top Via header field of the
         * original request. The CSeq header field in the ACK MUST contain the same value for the
         * sequence number as was present in the original request, but the method parameter MUST
         * be equal to "ACK".
         */
        SIPRequest newRequest = new SIPRequest();
        newRequest.setRequestLine((RequestLine) this.requestLine.clone());
        newRequest.setMethod(Request.ACK);
        newRequest.setHeader((Header) this.callIdHeader.clone());
        newRequest.setHeader((Header) this.maxForwardsHeader.clone()); // ISSUE
        // 130
        // fix
        newRequest.setHeader((Header) this.fromHeader.clone());
        newRequest.setHeader((Header) responseToHeader.clone());
        newRequest.addFirst((Header) this.getTopmostVia().clone());
        newRequest.setHeader((Header) cSeqHeader.clone());
        newRequest.getCSeq().setMethod(Request.ACK);

        /*
         * If the INVITE request whose response is being acknowledged had Route header fields,
         * those header fields MUST appear in the ACK. This is to ensure that the ACK can be
         * routed properly through any downstream stateless proxies.
         */
        if (this.getRouteHeaders() != null) {
            newRequest.setHeader((SIPHeaderList) this.getRouteHeaders().clone());
        }
        if (MessageFactoryImpl.getDefaultUserAgentHeader() != null) {
            newRequest.setHeader(MessageFactoryImpl.getDefaultUserAgentHeader());

        }
        return newRequest;
    }

    /**
     * Create a new default SIPRequest from the original request. Warning: the newly created
     * SIPRequest, shares the headers of this request but we generate any new headers that we need
     * to modify so the original request is umodified. However, if you modify the shared headers
     * after this request is created, then the newly created request will also be modified. If you
     * want to modify the original request without affecting the returned Request make sure you
     * clone it before calling this method.
     * 
     * Only required headers are copied.
     * <ul>
     * <li> Contact headers are not included in the newly created request. Setting the appropriate
     * sequence number is the responsibility of the caller. </li>
     * <li> RouteList is not copied for ACK and CANCEL </li>
     * <li> Note that we DO NOT copy the body of the argument into the returned header. We do not
     * copy the content type header from the original request either. These have to be added
     * seperately and the content length has to be correctly set if necessary the content length
     * is set to 0 in the returned header. </li>
     * <li>Contact List is not copied from the original request.</li>
     * <li>RecordRoute List is not included from original request. </li>
     * <li>Via header is not included from the original request. </li>
     * </ul>
     * 
     * @param requestLine is the new request line.
     * 
     * @param switchHeaders is a boolean flag that causes to and from headers to switch (set this
     *        to true if you are the server of the transaction and are generating a BYE request).
     *        If the headers are switched, we generate new From and To headers otherwise we just
     *        use the incoming headers.
     * 
     * @return a new Default SIP Request which has the requestLine specified.
     * 
     */
    public SIPRequest createSIPRequest(RequestLine requestLine, boolean switchHeaders) {
        SIPRequest newRequest = new SIPRequest();
        newRequest.requestLine = requestLine;
        Iterator<SIPHeader> headerIterator = this.getHeaders();
        while (headerIterator.hasNext()) {
            SIPHeader nextHeader = (SIPHeader) headerIterator.next();
            // For BYE and cancel set the CSeq header to the
            // appropriate method.
            if (nextHeader instanceof CSeq) {
                CSeq newCseq = (CSeq) nextHeader.clone();
                nextHeader = newCseq;
                try {
                    newCseq.setMethod(requestLine.getMethod());
                } catch (ParseException e) {
                }
            } else if (nextHeader instanceof ViaList) {
                Via via = (Via) (((ViaList) nextHeader).getFirst().clone());
                via.removeParameter("branch");
                nextHeader = via;
                // Cancel and ACK preserve the branch ID.
            } else if (nextHeader instanceof To) {
                To to = (To) nextHeader;
                if (switchHeaders) {
                    nextHeader = new From(to);
                    ((From) nextHeader).removeTag();
                } else {
                    nextHeader = (SIPHeader) to.clone();
                    ((To) nextHeader).removeTag();
                }
            } else if (nextHeader instanceof From) {
                From from = (From) nextHeader;
                if (switchHeaders) {
                    nextHeader = new To(from);
                    ((To) nextHeader).removeTag();
                } else {
                    nextHeader = (SIPHeader) from.clone();
                    ((From) nextHeader).removeTag();
                }
            } else if (nextHeader instanceof ContentLength) {
                ContentLength cl = (ContentLength) nextHeader.clone();
                try {
                    cl.setContentLength(0);
                } catch (InvalidArgumentException e) {
                }
                nextHeader = cl;
            } else if (!(nextHeader instanceof CallID) && !(nextHeader instanceof MaxForwards)) {
                // Route is kept by dialog.
                // RR is added by the caller.
                // Contact is added by the Caller
                // Any extension headers must be added
                // by the caller.
                continue;
            }
            try {
                newRequest.attachHeader(nextHeader, false);
            } catch (SIPDuplicateHeaderException e) {
                e.printStackTrace();
            }
        }
        if (MessageFactoryImpl.getDefaultUserAgentHeader() != null) {
            newRequest.setHeader(MessageFactoryImpl.getDefaultUserAgentHeader());

        }
        return newRequest;

    }

    /**
     * Create a BYE request from this request.
     * 
     * @param switchHeaders is a boolean flag that causes from and isServerTransaction to headers
     *        to be swapped. Set this to true if you are the server of the dialog and are
     *        generating a BYE request for the dialog.
     * @return a new default BYE request.
     */
    public SIPRequest createBYERequest(boolean switchHeaders) {
        RequestLine requestLine = (RequestLine) this.requestLine.clone();
        requestLine.setMethod("BYE");
        return this.createSIPRequest(requestLine, switchHeaders);
    }

    /**
     * Create an ACK request from this request. This is suitable for generating an ACK for an
     * INVITE client transaction.
     * 
     * @return an ACK request that is generated from this request.
     */
    public SIPRequest createACKRequest() {
        RequestLine requestLine = (RequestLine) this.requestLine.clone();
        requestLine.setMethod(Request.ACK);
        return this.createSIPRequest(requestLine, false);
    }

    /**
     * Get the host from the topmost via header.
     * 
     * @return the string representation of the host from the topmost via header.
     */
    public String getViaHost() {
        Via via = (Via) this.getViaHeaders().getFirst();
        return via.getHost();

    }

    /**
     * Get the port from the topmost via header.
     * 
     * @return the port from the topmost via header (5060 if there is no port indicated).
     */
    public int getViaPort() {
        Via via = (Via) this.getViaHeaders().getFirst();
        if (via.hasPort())
            return via.getPort();
        else
            return 5060;
    }

    /**
     * Get the first line encoded.
     * 
     * @return a string containing the encoded request line.
     */
    public String getFirstLine() {
        if (requestLine == null)
            return null;
        else
            return this.requestLine.encode();
    }

    /**
     * Set the sip version.
     * 
     * @param sipVersion the sip version to set.
     */
    public void setSIPVersion(String sipVersion) throws ParseException {
        if (sipVersion == null || !sipVersion.equalsIgnoreCase("SIP/2.0"))
            throw new ParseException("sipVersion", 0);
        this.requestLine.setSipVersion(sipVersion);
    }

    /**
     * Get the SIP version.
     * 
     * @return the SIP version from the request line.
     */
    public String getSIPVersion() {
        return this.requestLine.getSipVersion();
    }

    /**
     * Book keeping method to return the current tx for the request if one exists.
     * 
     * @return the assigned tx.
     */
    public Object getTransaction() {
        // Return an opaque pointer to the transaction object.
        // This is for consistency checking and quick lookup.
        return this.transactionPointer;
    }

    /**
     * Book keeping field to set the current tx for the request.
     * 
     * @param transaction
     */
    public void setTransaction(Object transaction) {
        this.transactionPointer = transaction;
    }

    /**
     * Book keeping method to get the messasge channel for the request.
     * 
     * @return the message channel for the request.
     */

    public Object getMessageChannel() {
        // return opaque ptr to the message chanel on
        // which the message was recieved. For consistency
        // checking and lookup.
        return this.messageChannel;
    }

    /**
     * Set the message channel for the request ( bookkeeping field ).
     * 
     * @param messageChannel
     */

    public void setMessageChannel(Object messageChannel) {
        this.messageChannel = messageChannel;
    }

    /**
     * Generates an Id for checking potentially merged requests.
     * 
     * @return String to check for merged requests
     */
    public String getMergeId() {
        /*
         * generate an identifier from the From tag, Call-ID, and CSeq
         */
        String fromTag = this.getFromTag();
        String cseq = this.cSeqHeader.toString();
        String callId = this.callIdHeader.getCallId();
        /* NOTE : The RFC does NOT specify you need to include a Request URI 
         * This is added here for the case of Back to Back User Agents.
         */
        String requestUri = this.getRequestURI().toString();

        if (fromTag != null) {
            return new StringBuffer().append(requestUri).append(":").append(fromTag).append(":").append(cseq).append(":")
                    .append(callId).toString();
        } else
            return null;

    }

    /**
     * @param inviteTransaction the inviteTransaction to set
     */
    public void setInviteTransaction(Object inviteTransaction) {
        this.inviteTransaction = inviteTransaction;
    }

    /**
     * @return the inviteTransaction
     */
    public Object getInviteTransaction() {
        return inviteTransaction;
    }

   
   
    

}
