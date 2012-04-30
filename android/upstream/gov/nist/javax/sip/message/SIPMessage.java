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
 * Product of NIST/ITL Advanced Networking Technologies Division (ANTD)        *
 ******************************************************************************/
package gov.nist.javax.sip.message;

import gov.nist.core.InternalErrorHandler;
import gov.nist.javax.sip.SIPConstants;
import gov.nist.javax.sip.Utils;
import gov.nist.javax.sip.header.AlertInfo;
import gov.nist.javax.sip.header.Authorization;
import gov.nist.javax.sip.header.CSeq;
import gov.nist.javax.sip.header.CallID;
import gov.nist.javax.sip.header.Contact;
import gov.nist.javax.sip.header.ContactList;
import gov.nist.javax.sip.header.ContentLength;
import gov.nist.javax.sip.header.ContentType;
import gov.nist.javax.sip.header.ErrorInfo;
import gov.nist.javax.sip.header.ErrorInfoList;
import gov.nist.javax.sip.header.From;
import gov.nist.javax.sip.header.InReplyTo;
import gov.nist.javax.sip.header.MaxForwards;
import gov.nist.javax.sip.header.Priority;
import gov.nist.javax.sip.header.ProxyAuthenticate;
import gov.nist.javax.sip.header.ProxyAuthorization;
import gov.nist.javax.sip.header.ProxyRequire;
import gov.nist.javax.sip.header.ProxyRequireList;
import gov.nist.javax.sip.header.RSeq;
import gov.nist.javax.sip.header.RecordRouteList;
import gov.nist.javax.sip.header.RetryAfter;
import gov.nist.javax.sip.header.Route;
import gov.nist.javax.sip.header.RouteList;
import gov.nist.javax.sip.header.SIPETag;
import gov.nist.javax.sip.header.SIPHeader;
import gov.nist.javax.sip.header.SIPHeaderList;
import gov.nist.javax.sip.header.SIPHeaderNamesCache;
import gov.nist.javax.sip.header.SIPIfMatch;
import gov.nist.javax.sip.header.Server;
import gov.nist.javax.sip.header.Subject;
import gov.nist.javax.sip.header.To;
import gov.nist.javax.sip.header.Unsupported;
import gov.nist.javax.sip.header.UserAgent;
import gov.nist.javax.sip.header.Via;
import gov.nist.javax.sip.header.ViaList;
import gov.nist.javax.sip.header.WWWAuthenticate;
import gov.nist.javax.sip.header.Warning;
import gov.nist.javax.sip.parser.HeaderParser;
import gov.nist.javax.sip.parser.ParserFactory;
import gov.nist.javax.sip.parser.PipelinedMsgParser;
import gov.nist.javax.sip.parser.StringMsgParser;

import java.io.UnsupportedEncodingException;
import java.lang.reflect.Field;
import java.text.ParseException;
import java.util.Collection;
import java.util.Hashtable;
import java.util.Iterator;
import java.util.LinkedList;
import java.util.List;
import java.util.ListIterator;
import java.util.concurrent.ConcurrentLinkedQueue;

import javax.sip.InvalidArgumentException;
import javax.sip.SipException;
import javax.sip.header.AuthorizationHeader;
import javax.sip.header.CSeqHeader;
import javax.sip.header.CallIdHeader;
import javax.sip.header.ContactHeader;
import javax.sip.header.ContentDispositionHeader;
import javax.sip.header.ContentEncodingHeader;
import javax.sip.header.ContentLanguageHeader;
import javax.sip.header.ContentLengthHeader;
import javax.sip.header.ContentTypeHeader;
import javax.sip.header.ExpiresHeader;
import javax.sip.header.FromHeader;
import javax.sip.header.Header;
import javax.sip.header.MaxForwardsHeader;
import javax.sip.header.RecordRouteHeader;
import javax.sip.header.RouteHeader;
import javax.sip.header.ToHeader;
import javax.sip.header.ViaHeader;
import javax.sip.message.Request;

/*
 * Acknowledgements: Yanick Belanger sent in a patch for the right content length when the content
 * is a String. Bill Mccormick from Nortel Networks sent in a bug fix for setContent.
 * 
 */
/**
 * This is the main SIP Message structure.
 * 
 * @see StringMsgParser
 * @see PipelinedMsgParser
 * 
 * @version 1.2 $Revision: 1.53 $ $Date: 2009/12/16 14:58:40 $
 * @since 1.1
 * 
 * @author M. Ranganathan <br/>
 * 
 * 
 */
public abstract class SIPMessage extends MessageObject implements javax.sip.message.Message,
        MessageExt {

	// JvB: use static here?
    private String contentEncodingCharset = MessageFactoryImpl.getDefaultContentEncodingCharset();
    
    /*
     * True if this is a null request.
     */
    protected boolean nullRequest;
    
    /**
     * unparsed headers
     */
    protected LinkedList<String> unrecognizedHeaders;

    /**
     * List of parsed headers (in the order they were added)
     */
    protected ConcurrentLinkedQueue<SIPHeader> headers;

    /**
     * Direct accessors for frequently accessed headers
     */
    protected From fromHeader;

    protected To toHeader;

    protected CSeq cSeqHeader;

    protected CallID callIdHeader;

    protected ContentLength contentLengthHeader;

    protected MaxForwards maxForwardsHeader;

    // Cumulative size of all the headers.
    protected int size;

    // Payload
    private String messageContent;

    private byte[] messageContentBytes;

    private Object messageContentObject;

    // Table of headers indexed by name.
    private Hashtable<String, SIPHeader> nameTable;

    /**
     * The application data pointer. This is un-interpreted by the stack. This is provided as a
     * convenient way of keeping book-keeping data for applications.
     */
    protected Object applicationData;

    /**
     * Return true if the header belongs only in a Request.
     * 
     * @param sipHeader is the header to test.
     */
    public static boolean isRequestHeader(SIPHeader sipHeader) {
        return sipHeader instanceof AlertInfo || sipHeader instanceof InReplyTo
                || sipHeader instanceof Authorization || sipHeader instanceof MaxForwards
                || sipHeader instanceof UserAgent || sipHeader instanceof Priority
                || sipHeader instanceof ProxyAuthorization || sipHeader instanceof ProxyRequire
                || sipHeader instanceof ProxyRequireList || sipHeader instanceof Route
                || sipHeader instanceof RouteList || sipHeader instanceof Subject
                || sipHeader instanceof SIPIfMatch;
    }

    /**
     * Return true if the header belongs only in a response.
     * 
     * @param sipHeader is the header to test.
     */
    public static boolean isResponseHeader(SIPHeader sipHeader) {
        return sipHeader instanceof ErrorInfo || sipHeader instanceof ProxyAuthenticate
                || sipHeader instanceof Server || sipHeader instanceof Unsupported
                || sipHeader instanceof RetryAfter || sipHeader instanceof Warning
                || sipHeader instanceof WWWAuthenticate || sipHeader instanceof SIPETag
                || sipHeader instanceof RSeq;

    }

    /**
     * Get the headers as a linked list of encoded Strings
     * 
     * @return a linked list with each element of the list containing a string encoded header in
     *         canonical form.
     */
    public LinkedList<String> getMessageAsEncodedStrings() {
        LinkedList<String> retval = new LinkedList<String>();
        Iterator<SIPHeader> li = headers.iterator();
        while (li.hasNext()) {
            SIPHeader sipHeader = (SIPHeader) li.next();
            if (sipHeader instanceof SIPHeaderList) {
                SIPHeaderList< ? > shl = (SIPHeaderList< ? >) sipHeader;
                retval.addAll(shl.getHeadersAsEncodedStrings());
            } else {
                retval.add(sipHeader.encode());
            }
        }

        return retval;
    }

    /**
     * Encode only the message and exclude the contents (for debugging);
     * 
     * @return a string with all the headers encoded.
     */
    protected String encodeSIPHeaders() {
        StringBuffer encoding = new StringBuffer();
        Iterator<SIPHeader> it = this.headers.iterator();

        while (it.hasNext()) {
            SIPHeader siphdr = (SIPHeader) it.next();
            if (!(siphdr instanceof ContentLength))
                siphdr.encode(encoding);
        }

        return contentLengthHeader.encode(encoding).append(NEWLINE).toString();
    }

    /**
     * Encode all the headers except the contents. For debug logging.
     */
    public abstract String encodeMessage();

    /**
     * Get A dialog identifier constructed from this messsage. This is an id that can be used to
     * identify dialogs.
     * 
     * @param isServerTransaction is a flag that indicates whether this is a server transaction.
     */
    public abstract String getDialogId(boolean isServerTransaction);

    /**
     * Template match for SIP messages. The matchObj is a SIPMessage template to match against.
     * This method allows you to do pattern matching with incoming SIP messages. Null matches wild
     * card.
     * 
     * @param other is the match template to match against.
     * @return true if a match occured and false otherwise.
     */
    public boolean match(Object other) {
        if (other == null)
            return true;
        if (!other.getClass().equals(this.getClass()))
            return false;
        SIPMessage matchObj = (SIPMessage) other;
        Iterator<SIPHeader> li = matchObj.getHeaders();
        while (li.hasNext()) {
            SIPHeader hisHeaders = (SIPHeader) li.next();
            List<SIPHeader> myHeaders = this.getHeaderList(hisHeaders.getHeaderName());

            // Could not find a header to match his header.
            if (myHeaders == null || myHeaders.size() == 0)
                return false;

            if (hisHeaders instanceof SIPHeaderList) {
                ListIterator< ? > outerIterator = ((SIPHeaderList< ? >) hisHeaders)
                        .listIterator();
                while (outerIterator.hasNext()) {
                    SIPHeader hisHeader = (SIPHeader) outerIterator.next();
                    if (hisHeader instanceof ContentLength)
                        continue;
                    ListIterator< ? > innerIterator = myHeaders.listIterator();
                    boolean found = false;
                    while (innerIterator.hasNext()) {
                        SIPHeader myHeader = (SIPHeader) innerIterator.next();
                        if (myHeader.match(hisHeader)) {
                            found = true;
                            break;
                        }
                    }
                    if (!found)
                        return false;
                }
            } else {
                SIPHeader hisHeader = hisHeaders;
                ListIterator<SIPHeader> innerIterator = myHeaders.listIterator();
                boolean found = false;
                while (innerIterator.hasNext()) {
                    SIPHeader myHeader = (SIPHeader) innerIterator.next();
                    if (myHeader.match(hisHeader)) {
                        found = true;
                        break;
                    }
                }
                if (!found)
                    return false;
            }
        }
        return true;

    }

    /**
     * Merge a request with a template
     * 
     * @param template -- template to merge with.
     * 
     */
    public void merge(Object template) {
        if (!template.getClass().equals(this.getClass()))
            throw new IllegalArgumentException("Bad class " + template.getClass());
        SIPMessage templateMessage = (SIPMessage) template;
        Object[] templateHeaders = templateMessage.headers.toArray();
        for (int i = 0; i < templateHeaders.length; i++) {
            SIPHeader hdr = (SIPHeader) templateHeaders[i];
            String hdrName = hdr.getHeaderName();
            List<SIPHeader> myHdrs = this.getHeaderList(hdrName);
            if (myHdrs == null) {
                this.attachHeader(hdr);
            } else {
                ListIterator<SIPHeader> it = myHdrs.listIterator();
                while (it.hasNext()) {
                    SIPHeader sipHdr = (SIPHeader) it.next();
                    sipHdr.merge(hdr);
                }
            }
        }

    }

    /**
     * Encode this message as a string. This is more efficient when the payload is a string
     * (rather than a binary array of bytes). If the payload cannot be encoded as a UTF-8 string
     * then it is simply ignored (will not appear in the encoded message).
     * 
     * @return The Canonical String representation of the message (including the canonical string
     *         representation of the SDP payload if it exists).
     */
    public String encode() {
        StringBuffer encoding = new StringBuffer();
        Iterator<SIPHeader> it = this.headers.iterator();

        while (it.hasNext()) {
            SIPHeader siphdr = (SIPHeader) it.next();
            if (!(siphdr instanceof ContentLength))
                encoding.append(siphdr.encode());
        }
        // Append the unrecognized headers. Headers that are not
        // recognized are passed through unchanged.
        for (String unrecognized : this.unrecognizedHeaders) {
            encoding.append(unrecognized).append(NEWLINE);
        }

        encoding.append(contentLengthHeader.encode()).append(NEWLINE);

        if (this.messageContentObject != null) {
            String mbody = this.getContent().toString();

            encoding.append(mbody);
        } else if (this.messageContent != null || this.messageContentBytes != null) {

            String content = null;
            try {
                if (messageContent != null)
                    content = messageContent;
                else {
                	// JvB: Check for 'charset' parameter which overrides the default UTF-8
                    content = new String(messageContentBytes, getCharset() );
                }
            } catch (UnsupportedEncodingException ex) {
            	InternalErrorHandler.handleException(ex);
            }

            encoding.append(content);
        }
        return encoding.toString();
    }

    /**
     * Encode the message as a byte array. Use this when the message payload is a binary byte
     * array.
     * 
     * @return The Canonical byte array representation of the message (including the canonical
     *         byte array representation of the SDP payload if it exists all in one contiguous
     *         byte array).
     */
    public byte[] encodeAsBytes(String transport) {
        if (this instanceof SIPRequest && ((SIPRequest) this).isNullRequest()) {
            return "\r\n\r\n".getBytes();
        }
        // JvB: added to fix case where application provides the wrong transport
        // in the topmost Via header
        ViaHeader topVia = (ViaHeader) this.getHeader(ViaHeader.NAME);
        try {
            topVia.setTransport(transport);
        } catch (ParseException e) {
            InternalErrorHandler.handleException(e);
        }

        StringBuffer encoding = new StringBuffer();
        synchronized (this.headers) {
            Iterator<SIPHeader> it = this.headers.iterator();

            while (it.hasNext()) {
                SIPHeader siphdr = (SIPHeader) it.next();
                if (!(siphdr instanceof ContentLength))
                    siphdr.encode(encoding);

            }
        }
        contentLengthHeader.encode(encoding);
        encoding.append(NEWLINE);

        byte[] retval = null;
        byte[] content = this.getRawContent();
        if (content != null) {
            // Append the content

            byte[] msgarray = null;
            try {
                msgarray = encoding.toString().getBytes( getCharset() );
            } catch (UnsupportedEncodingException ex) {
                InternalErrorHandler.handleException(ex);
            }

            retval = new byte[msgarray.length + content.length];
            System.arraycopy(msgarray, 0, retval, 0, msgarray.length);
            System.arraycopy(content, 0, retval, msgarray.length, content.length);
        } else {
            // Message content does not exist.

            try {
                retval = encoding.toString().getBytes( getCharset() );
            } catch (UnsupportedEncodingException ex) {
                InternalErrorHandler.handleException(ex);
            }
        }
        return retval;
    }

    /**
     * clone this message (create a new deep physical copy). All headers in the message are
     * cloned. You can modify the cloned copy without affecting the original. The content is
     * handled as follows: If the content is a String, or a byte array, a new copy of the content
     * is allocated and copied over. If the content is an Object that supports the clone method,
     * then the clone method is invoked and the cloned content is the new content. Otherwise, the
     * content of the new message is set equal to the old one.
     * 
     * @return A cloned copy of this object.
     */
    public Object clone() {
        SIPMessage retval = (SIPMessage) super.clone();
        retval.nameTable = new Hashtable<String, SIPHeader>();
        retval.fromHeader = null;
        retval.toHeader = null;
        retval.cSeqHeader = null;
        retval.callIdHeader = null;
        retval.contentLengthHeader = null;
        retval.maxForwardsHeader = null;
        if (this.headers != null) {
            retval.headers = new ConcurrentLinkedQueue<SIPHeader>();
            for (Iterator<SIPHeader> iter = headers.iterator(); iter.hasNext();) {
                SIPHeader hdr = (SIPHeader) iter.next();
                retval.attachHeader((SIPHeader) hdr.clone());
            }

        }
        if (this.messageContentBytes != null)
            retval.messageContentBytes = (byte[]) this.messageContentBytes.clone();
        if (this.messageContentObject != null)
            retval.messageContentObject = makeClone(messageContentObject);
        retval.unrecognizedHeaders = this.unrecognizedHeaders;
        return retval;
    }

    /**
     * Get the string representation of this header (for pretty printing the generated structure).
     * 
     * @return Formatted string representation of the object. Note that this is NOT the same as
     *         encode(). This is used mainly for debugging purposes.
     */
    public String debugDump() {
        stringRepresentation = "";
        sprint("SIPMessage:");
        sprint("{");
        try {

            Field[] fields = this.getClass().getDeclaredFields();
            for (int i = 0; i < fields.length; i++) {
                Field f = fields[i];
                Class< ? > fieldType = f.getType();
                String fieldName = f.getName();
                if (f.get(this) != null && SIPHeader.class.isAssignableFrom(fieldType)
                        && fieldName.compareTo("headers") != 0) {
                    sprint(fieldName + "=");
                    sprint(((SIPHeader) f.get(this)).debugDump());
                }
            }
        } catch (Exception ex) {
            InternalErrorHandler.handleException(ex);
        }

        sprint("List of headers : ");
        sprint(headers.toString());
        sprint("messageContent = ");
        sprint("{");
        sprint(messageContent);
        sprint("}");
        if (this.getContent() != null) {
            sprint(this.getContent().toString());
        }
        sprint("}");
        return stringRepresentation;
    }

    /**
     * Constructor: Initializes lists and list headers. All the headers for which there can be
     * multiple occurances in a message are derived from the SIPHeaderListClass. All singleton
     * headers are derived from SIPHeader class.
     */
    public SIPMessage() {
        this.unrecognizedHeaders = new LinkedList<String>();
        this.headers = new ConcurrentLinkedQueue<SIPHeader>();
        nameTable = new Hashtable<String, SIPHeader>();
        try {
            this.attachHeader(new ContentLength(0), false);
        } catch (Exception ex) {
        }
    }

    /**
     * Attach a header and die if you get a duplicate header exception.
     * 
     * @param h SIPHeader to attach.
     */
    private void attachHeader(SIPHeader h) {
        if (h == null)
            throw new IllegalArgumentException("null header!");
        try {
            if (h instanceof SIPHeaderList) {
                SIPHeaderList< ? > hl = (SIPHeaderList< ? >) h;
                if (hl.isEmpty()) {
                    return;
                }
            }
            attachHeader(h, false, false);
        } catch (SIPDuplicateHeaderException ex) {
            // InternalErrorHandler.handleException(ex);
        }
    }

    /**
     * Attach a header (replacing the original header).
     * 
     * @param sipHeader SIPHeader that replaces a header of the same type.
     */
    public void setHeader(Header sipHeader) {
        SIPHeader header = (SIPHeader) sipHeader;
        if (header == null)
            throw new IllegalArgumentException("null header!");
        try {
            if (header instanceof SIPHeaderList) {
                SIPHeaderList< ? > hl = (SIPHeaderList< ? >) header;
                // Ignore empty lists.
                if (hl.isEmpty())
                    return;
            }
            this.removeHeader(header.getHeaderName());
            attachHeader(header, true, false);
        } catch (SIPDuplicateHeaderException ex) {
            InternalErrorHandler.handleException(ex);
        }
    }

    /**
     * Set a header from a linked list of headers.
     * 
     * @param headers -- a list of headers to set.
     */
    public void setHeaders(java.util.List<SIPHeader> headers) {
        ListIterator<SIPHeader> listIterator = headers.listIterator();
        while (listIterator.hasNext()) {
            SIPHeader sipHeader = (SIPHeader) listIterator.next();
            try {
                this.attachHeader(sipHeader, false);
            } catch (SIPDuplicateHeaderException ex) {
            }
        }
    }

    /**
     * Attach a header to the end of the existing headers in this SIPMessage structure. This is
     * equivalent to the attachHeader(SIPHeader,replaceflag,false); which is the normal way in
     * which headers are attached. This was added in support of JAIN-SIP.
     * 
     * @param h header to attach.
     * @param replaceflag if true then replace a header if it exists.
     * @throws SIPDuplicateHeaderException If replaceFlag is false and only a singleton header is
     *         allowed (fpr example CSeq).
     */
    public void attachHeader(SIPHeader h, boolean replaceflag) throws SIPDuplicateHeaderException {
        this.attachHeader(h, replaceflag, false);
    }

    /**
     * Attach the header to the SIP Message structure at a specified position in its list of
     * headers.
     * 
     * @param header Header to attach.
     * @param replaceFlag If true then replace the existing header.
     * @param top Location in the header list to insert the header.
     * @exception SIPDuplicateHeaderException if the header is of a type that cannot tolerate
     *            duplicates and one of this type already exists (e.g. CSeq header).
     * @throws IndexOutOfBoundsException If the index specified is greater than the number of
     *         headers that are in this message.
     */

    public void attachHeader(SIPHeader header, boolean replaceFlag, boolean top)
            throws SIPDuplicateHeaderException {
        if (header == null) {
            throw new NullPointerException("null header");
        }

        SIPHeader h;

        if (ListMap.hasList(header) && !SIPHeaderList.class.isAssignableFrom(header.getClass())) {
            SIPHeaderList<SIPHeader> hdrList = ListMap.getList(header);
            hdrList.add(header);
            h = hdrList;
        } else {
            h = header;
        }

        String headerNameLowerCase = SIPHeaderNamesCache.toLowerCase(h.getName());
        if (replaceFlag) {
            nameTable.remove(headerNameLowerCase);
        } else if (nameTable.containsKey(headerNameLowerCase) && !(h instanceof SIPHeaderList)) {
            if (h instanceof ContentLength) {
                try {
                    ContentLength cl = (ContentLength) h;
                    contentLengthHeader.setContentLength(cl.getContentLength());
                } catch (InvalidArgumentException e) {
                }
            }
            // Just ignore duplicate header.
            return;
        }

        SIPHeader originalHeader = (SIPHeader) getHeader(header.getName());

        // Delete the original header from our list structure.
        if (originalHeader != null) {
            Iterator<SIPHeader> li = headers.iterator();
            while (li.hasNext()) {
                SIPHeader next = (SIPHeader) li.next();
                if (next.equals(originalHeader)) {
                    li.remove();
                }
            }
        }

        if (!nameTable.containsKey(headerNameLowerCase)) {
            nameTable.put(headerNameLowerCase, h);
            headers.add(h);
        } else {
            if (h instanceof SIPHeaderList) {
                SIPHeaderList< ? > hdrlist = (SIPHeaderList< ? >) nameTable
                        .get(headerNameLowerCase);
                if (hdrlist != null)
                    hdrlist.concatenate((SIPHeaderList) h, top);
                else
                    nameTable.put(headerNameLowerCase, h);
            } else {
                nameTable.put(headerNameLowerCase, h);
            }
        }

        // Direct accessor fields for frequently accessed headers.
        if (h instanceof From) {
            this.fromHeader = (From) h;
        } else if (h instanceof ContentLength) {
            this.contentLengthHeader = (ContentLength) h;
        } else if (h instanceof To) {
            this.toHeader = (To) h;
        } else if (h instanceof CSeq) {
            this.cSeqHeader = (CSeq) h;
        } else if (h instanceof CallID) {
            this.callIdHeader = (CallID) h;
        } else if (h instanceof MaxForwards) {
            this.maxForwardsHeader = (MaxForwards) h;
        }

    }

    /**
     * Remove a header given its name. If multiple headers of a given name are present then the
     * top flag determines which end to remove headers from.
     * 
     * @param headerName is the name of the header to remove.
     * @param top -- flag that indicates which end of header list to process.
     */
    public void removeHeader(String headerName, boolean top) {

        String headerNameLowerCase = SIPHeaderNamesCache.toLowerCase(headerName);
        SIPHeader toRemove = (SIPHeader) nameTable.get(headerNameLowerCase);
        // nothing to do then we are done.
        if (toRemove == null)
            return;
        if (toRemove instanceof SIPHeaderList) {
            SIPHeaderList< ? > hdrList = (SIPHeaderList< ? >) toRemove;
            if (top)
                hdrList.removeFirst();
            else
                hdrList.removeLast();
            // Clean up empty list
            if (hdrList.isEmpty()) {
                Iterator<SIPHeader> li = this.headers.iterator();
                while (li.hasNext()) {
                    SIPHeader sipHeader = (SIPHeader) li.next();
                    if (sipHeader.getName().equalsIgnoreCase(headerNameLowerCase))
                        li.remove();
                }

                // JvB: also remove it from the nameTable! Else NPE in
                // DefaultRouter
                nameTable.remove(headerNameLowerCase);
            }
        } else {
            this.nameTable.remove(headerNameLowerCase);
            if (toRemove instanceof From) {
                this.fromHeader = null;
            } else if (toRemove instanceof To) {
                this.toHeader = null;
            } else if (toRemove instanceof CSeq) {
                this.cSeqHeader = null;
            } else if (toRemove instanceof CallID) {
                this.callIdHeader = null;
            } else if (toRemove instanceof MaxForwards) {
                this.maxForwardsHeader = null;
            } else if (toRemove instanceof ContentLength) {
                this.contentLengthHeader = null;
            }
            Iterator<SIPHeader> li = this.headers.iterator();
            while (li.hasNext()) {
                SIPHeader sipHeader = (SIPHeader) li.next();
                if (sipHeader.getName().equalsIgnoreCase(headerName))
                    li.remove();
            }
        }

    }

    /**
     * Remove all headers given its name.
     * 
     * @param headerName is the name of the header to remove.
     */
    public void removeHeader(String headerName) {

        if (headerName == null)
            throw new NullPointerException("null arg");
        String headerNameLowerCase = SIPHeaderNamesCache.toLowerCase(headerName);
        SIPHeader removed = (SIPHeader) nameTable.remove(headerNameLowerCase);
        // nothing to do then we are done.
        if (removed == null)
            return;

        // Remove the fast accessor fields.
        if (removed instanceof From) {
            this.fromHeader = null;
        } else if (removed instanceof To) {
            this.toHeader = null;
        } else if (removed instanceof CSeq) {
            this.cSeqHeader = null;
        } else if (removed instanceof CallID) {
            this.callIdHeader = null;
        } else if (removed instanceof MaxForwards) {
            this.maxForwardsHeader = null;
        } else if (removed instanceof ContentLength) {
            this.contentLengthHeader = null;
        }

        Iterator<SIPHeader> li = this.headers.iterator();
        while (li.hasNext()) {
            SIPHeader sipHeader = (SIPHeader) li.next();
            if (sipHeader.getName().equalsIgnoreCase(headerNameLowerCase))
                li.remove();

        }
    }

    /**
     * Generate (compute) a transaction ID for this SIP message.
     * 
     * @return A string containing the concatenation of various portions of the From,To,Via and
     *         RequestURI portions of this message as specified in RFC 2543: All responses to a
     *         request contain the same values in the Call-ID, CSeq, To, and From fields (with the
     *         possible addition of a tag in the To field (section 10.43)). This allows responses
     *         to be matched with requests. Incorporates a bug fix for a bug sent in by Gordon
     *         Ledgard of IPera for generating transactionIDs when no port is present in the via
     *         header. Incorporates a bug fix for a bug report sent in by Chris Mills of Nortel
     *         Networks (converts to lower case when returning the transaction identifier).
     * 
     * @return a string that can be used as a transaction identifier for this message. This can be
     *         used for matching responses and requests (i.e. an outgoing request and its matching
     *         response have the same computed transaction identifier).
     */
    public String getTransactionId() {
        Via topVia = null;
        if (!this.getViaHeaders().isEmpty()) {
            topVia = (Via) this.getViaHeaders().getFirst();
        }
        // Have specified a branch Identifier so we can use it to identify
        // the transaction. BranchId is not case sensitive.
        // Branch Id prefix is not case sensitive.
        if (topVia != null
                && topVia.getBranch() != null
                && topVia.getBranch().toUpperCase().startsWith(
                        SIPConstants.BRANCH_MAGIC_COOKIE_UPPER_CASE)) {
            // Bis 09 compatible branch assignment algorithm.
            // implies that the branch id can be used as a transaction
            // identifier.
            if (this.getCSeq().getMethod().equals(Request.CANCEL))
                return (topVia.getBranch() + ":" + this.getCSeq().getMethod()).toLowerCase();
            else
                return topVia.getBranch().toLowerCase();
        } else {
            // Old style client so construct the transaction identifier
            // from various fields of the request.
            StringBuffer retval = new StringBuffer();
            From from = (From) this.getFrom();
            To to = (To) this.getTo();
            // String hpFrom = from.getUserAtHostPort();
            // retval.append(hpFrom).append(":");
            if (from.hasTag())
                retval.append(from.getTag()).append("-");
            // String hpTo = to.getUserAtHostPort();
            // retval.append(hpTo).append(":");
            String cid = this.callIdHeader.getCallId();
            retval.append(cid).append("-");
            retval.append(this.cSeqHeader.getSequenceNumber()).append("-").append(
                    this.cSeqHeader.getMethod());
            if (topVia != null) {
                retval.append("-").append(topVia.getSentBy().encode());
                if (!topVia.getSentBy().hasPort()) {
                    retval.append("-").append(5060);
                }
            }
            if (this.getCSeq().getMethod().equals(Request.CANCEL)) {
                retval.append(Request.CANCEL);
            }
            return retval.toString().toLowerCase().replace(":", "-").replace("@", "-")
                    + Utils.getSignature();
        }
    }

    /**
     * Override the hashcode method ( see issue # 55 ) Note that if you try to use this method
     * before you assemble a valid request, you will get a constant ( -1 ). Beware of placing any
     * half formed requests in a table.
     */
    public int hashCode() {
        if (this.callIdHeader == null)
            throw new RuntimeException(
                    "Invalid message! Cannot compute hashcode! call-id header is missing !");
        else
            return this.callIdHeader.getCallId().hashCode();
    }

    /**
     * Return true if this message has a body.
     */
    public boolean hasContent() {
        return messageContent != null || messageContentBytes != null;
    }

    /**
     * Return an iterator for the list of headers in this message.
     * 
     * @return an Iterator for the headers of this message.
     */
    public Iterator<SIPHeader> getHeaders() {
        return headers.iterator();
    }

    /**
     * Get the first header of the given name.
     * 
     * @return header -- the first header of the given name.
     */
    public Header getHeader(String headerName) {
        return getHeaderLowerCase(SIPHeaderNamesCache.toLowerCase(headerName));
    }

    private Header getHeaderLowerCase(String lowerCaseHeaderName) {
        if (lowerCaseHeaderName == null)
            throw new NullPointerException("bad name");
        SIPHeader sipHeader = (SIPHeader) nameTable.get(lowerCaseHeaderName);
        if (sipHeader instanceof SIPHeaderList)
            return (Header) ((SIPHeaderList) sipHeader).getFirst();
        else
            return (Header) sipHeader;
    }

    /**
     * Get the contentType header (null if one does not exist).
     * 
     * @return contentType header
     */
    
    public ContentType getContentTypeHeader() {
        return (ContentType) getHeaderLowerCase(CONTENT_TYPE_LOWERCASE);
    }
    
    private static final String CONTENT_TYPE_LOWERCASE = SIPHeaderNamesCache
    .toLowerCase(ContentTypeHeader.NAME);

    
    /**
     * Get the contentLength header.
     */
    public ContentLengthHeader getContentLengthHeader() {
        return this.getContentLength();
    }

  
    /**
     * Get the from header.
     * 
     * @return -- the from header.
     */
    public FromHeader getFrom() {
        return (FromHeader) fromHeader;
    }

    /**
     * Get the ErrorInfo list of headers (null if one does not exist).
     * 
     * @return List containing ErrorInfo headers.
     */
    public ErrorInfoList getErrorInfoHeaders() {
        return (ErrorInfoList) getSIPHeaderListLowerCase(ERROR_LOWERCASE);
    }

    private static final String ERROR_LOWERCASE = SIPHeaderNamesCache.toLowerCase(ErrorInfo.NAME);

    /**
     * Get the Contact list of headers (null if one does not exist).
     * 
     * @return List containing Contact headers.
     */
    public ContactList getContactHeaders() {
        return (ContactList) this.getSIPHeaderListLowerCase(CONTACT_LOWERCASE);
    }

    private static final String CONTACT_LOWERCASE = SIPHeaderNamesCache
            .toLowerCase(ContactHeader.NAME);

    /**
     * Get the contact header ( the first contact header) which is all we need for the most part.
     * 
     */
    public Contact getContactHeader() {
        ContactList clist = this.getContactHeaders();
        if (clist != null) {
            return (Contact) clist.getFirst();

        } else {
            return null;
        }
    }

    /**
     * Get the Via list of headers (null if one does not exist).
     * 
     * @return List containing Via headers.
     */
    public ViaList getViaHeaders() {
        return (ViaList) getSIPHeaderListLowerCase(VIA_LOWERCASE);
    }

    private static final String VIA_LOWERCASE = SIPHeaderNamesCache.toLowerCase(ViaHeader.NAME);

    /**
     * Set A list of via headers.
     * 
     * @param viaList a list of via headers to add.
     */
    public void setVia(java.util.List viaList) {
        ViaList vList = new ViaList();
        ListIterator it = viaList.listIterator();
        while (it.hasNext()) {
            Via via = (Via) it.next();
            vList.add(via);
        }
        this.setHeader(vList);
    }

    /**
     * Set the header given a list of headers.
     * 
     * @param sipHeaderList a headerList to set
     */

    public void setHeader(SIPHeaderList<Via> sipHeaderList) {
        this.setHeader((Header) sipHeaderList);
    }

    /**
     * Get the topmost via header.
     * 
     * @return the top most via header if one exists or null if none exists.
     */
    public Via getTopmostVia() {
        if (this.getViaHeaders() == null)
            return null;
        else
            return (Via) (getViaHeaders().getFirst());
    }

    /**
     * Get the CSeq list of header (null if one does not exist).
     * 
     * @return CSeq header
     */
    public CSeqHeader getCSeq() {
        return (CSeqHeader) cSeqHeader;
    }

    /**
     * Get the Authorization header (null if one does not exist).
     * 
     * @return Authorization header.
     */
    public Authorization getAuthorization() {
        return (Authorization) getHeaderLowerCase(AUTHORIZATION_LOWERCASE);
    }

    private static final String AUTHORIZATION_LOWERCASE = SIPHeaderNamesCache
            .toLowerCase(AuthorizationHeader.NAME);

    /**
     * Get the MaxForwards header (null if one does not exist).
     * 
     * @return Max-Forwards header
     */

    public MaxForwardsHeader getMaxForwards() {
        return maxForwardsHeader;
    }

    /**
     * Set the max forwards header.
     * 
     * @param maxForwards is the MaxForwardsHeader to set.
     */
    public void setMaxForwards(MaxForwardsHeader maxForwards) {
        this.setHeader(maxForwards);
    }

    /**
     * Get the Route List of headers (null if one does not exist).
     * 
     * @return List containing Route headers
     */
    public RouteList getRouteHeaders() {
        return (RouteList) getSIPHeaderListLowerCase(ROUTE_LOWERCASE);
    }

    private static final String ROUTE_LOWERCASE = SIPHeaderNamesCache
            .toLowerCase(RouteHeader.NAME);

    /**
     * Get the CallID header (null if one does not exist)
     * 
     * @return Call-ID header .
     */
    public CallIdHeader getCallId() {
        return callIdHeader;
    }

    /**
     * Set the call id header.
     * 
     * @param callId call idHeader (what else could it be?)
     */
    public void setCallId(CallIdHeader callId) {
        this.setHeader(callId);
    }

    /**
     * Get the CallID header (null if one does not exist)
     * 
     * @param callId -- the call identifier to be assigned to the call id header
     */
    public void setCallId(String callId) throws java.text.ParseException {
        if (callIdHeader == null) {
            this.setHeader(new CallID());
        }
        callIdHeader.setCallId(callId);
    }

    /**
     * Get the RecordRoute header list (null if one does not exist).
     * 
     * @return Record-Route header
     */
    public RecordRouteList getRecordRouteHeaders() {
        return (RecordRouteList) this.getSIPHeaderListLowerCase(RECORDROUTE_LOWERCASE);
    }

    private static final String RECORDROUTE_LOWERCASE = SIPHeaderNamesCache
            .toLowerCase(RecordRouteHeader.NAME);

    /**
     * Get the To header (null if one does not exist).
     * 
     * @return To header
     */
    public ToHeader getTo() {
        return (ToHeader) toHeader;
    }

    public void setTo(ToHeader to) {
        this.setHeader(to);
    }

    public void setFrom(FromHeader from) {
        this.setHeader(from);

    }

    /**
     * Get the ContentLength header (null if one does not exist).
     * 
     * @return content-length header.
     */
    public ContentLengthHeader getContentLength() {
        return this.contentLengthHeader;
    }

    /**
     * Get the message body as a string. If the message contains a content type header with a
     * specified charset, and if the payload has been read as a byte array, then it is returned
     * encoded into this charset.
     * 
     * @return Message body (as a string)
     * @throws UnsupportedEncodingException if the platform does not support the charset specified
     *         in the content type header.
     * 
     */
    public String getMessageContent() throws UnsupportedEncodingException {
        if (this.messageContent == null && this.messageContentBytes == null)
            return null;
        else if (this.messageContent == null) {
            this.messageContent = new String(messageContentBytes, getCharset() );
        }
        return this.messageContent;
    }

    /**
     * Get the message content as an array of bytes. If the payload has been read as a String then
     * it is decoded using the charset specified in the content type header if it exists.
     * Otherwise, it is encoded using the default encoding which is UTF-8.
     * 
     * @return an array of bytes that is the message payload.
     */
    public byte[] getRawContent() {
        try {
            if ( this.messageContentBytes != null ) {
                // return messageContentBytes;
            } else if (this.messageContentObject != null) {
                String messageContent = this.messageContentObject.toString();
                this.messageContentBytes = messageContent.getBytes( getCharset() );
            } else if (this.messageContent != null) {
            	this.messageContentBytes = messageContent.getBytes( getCharset() );                
            }
            return this.messageContentBytes;
        } catch (UnsupportedEncodingException ex) {
            InternalErrorHandler.handleException(ex);
            return null;
        }
    }

    /**
     * Set the message content given type and subtype.
     * 
     * @param type is the message type (eg. application)
     * @param subType is the message sybtype (eg. sdp)
     * @param messageContent is the messge content as a string.
     */
    public void setMessageContent(String type, String subType, String messageContent) {
        if (messageContent == null)
            throw new IllegalArgumentException("messgeContent is null");
        ContentType ct = new ContentType(type, subType);
        this.setHeader(ct);
        this.messageContent = messageContent;
        this.messageContentBytes = null;
        this.messageContentObject = null;
        // Could be double byte so we need to compute length
        // after converting to byte[]
        computeContentLength(messageContent);
    }

    /**
     * Set the message content after converting the given object to a String.
     * 
     * @param content -- content to set.
     * @param contentTypeHeader -- content type header corresponding to content.
     */
    public void setContent(Object content, ContentTypeHeader contentTypeHeader)
            throws ParseException {
        if (content == null)
            throw new NullPointerException("null content");
        this.setHeader(contentTypeHeader);

        this.messageContent = null;
        this.messageContentBytes = null;
        this.messageContentObject = null;

        if (content instanceof String) {
            this.messageContent = (String) content;
        } else if (content instanceof byte[]) {
            this.messageContentBytes = (byte[]) content;
        } else
            this.messageContentObject = content;

        computeContentLength(content);
    }

    /**
     * Get the content (body) of the message.
     * 
     * @return the content of the sip message.
     */
    public Object getContent() {
        if (this.messageContentObject != null)
            return messageContentObject;
        else if (this.messageContent != null)
            return this.messageContent;
        else if (this.messageContentBytes != null)
            return this.messageContentBytes;
        else
            return null;
    }

    /**
     * Set the message content for a given type and subtype.
     * 
     * @param type is the messge type.
     * @param subType is the message subType.
     * @param messageContent is the message content as a byte array.
     */
    public void setMessageContent(String type, String subType, byte[] messageContent) {
        ContentType ct = new ContentType(type, subType);
        this.setHeader(ct);
        this.setMessageContent(messageContent);

        computeContentLength(messageContent);
    }

    /**
     * Set the message content for this message.
     * 
     * @param content Message body as a string.
     */
    public void setMessageContent(String content, boolean strict, boolean computeContentLength, int givenLength)
            throws ParseException {
        // Note that that this could be a double byte character
        // set - bug report by Masafumi Watanabe
        computeContentLength(content);
        if ((!computeContentLength)) {
            if ( (!strict && this.contentLengthHeader.getContentLength() != givenLength) 
                    || this.contentLengthHeader.getContentLength() < givenLength) {
                throw new ParseException("Invalid content length "
                        + this.contentLengthHeader.getContentLength() + " / " + givenLength, 0);
            }
        }

        messageContent = content;
        messageContentBytes = null;
        messageContentObject = null;
    }

    /**
     * Set the message content as an array of bytes.
     * 
     * @param content is the content of the message as an array of bytes.
     */
    public void setMessageContent(byte[] content) {
        computeContentLength(content);

        messageContentBytes = content;
        messageContent = null;
        messageContentObject = null;
    }

    /**
     * Method to set the content - called by the parser
     * 
     * @param content
     * @throws ParseException
     */
    public void setMessageContent(byte[] content, boolean computeContentLength, int givenLength)
            throws ParseException {
        computeContentLength(content);
        if ((!computeContentLength) && this.contentLengthHeader.getContentLength() < givenLength) {
            // System.out.println("!!!!!!!!!!! MISMATCH !!!!!!!!!!!");
            throw new ParseException("Invalid content length "
                    + this.contentLengthHeader.getContentLength() + " / " + givenLength, 0);
        }
        messageContentBytes = content;
        messageContent = null;
        messageContentObject = null;
    }

    /**
     * Compute and set the Content-length header based on the given content object.
     * 
     * @param content is the content, as String, array of bytes, or other object.
     */
    private void computeContentLength(Object content) {
        int length = 0;
        if (content != null) {
            if (content instanceof String) {
                try {
                    length = ((String) content).getBytes( getCharset() ).length;
                } catch (UnsupportedEncodingException ex) {
                    InternalErrorHandler.handleException(ex);
                }
            } else if (content instanceof byte[]) {
                length = ((byte[]) content).length;
            } else {
                length = content.toString().length();
            }
        }

        try {
            contentLengthHeader.setContentLength(length);
        } catch (InvalidArgumentException e) {
            // Cannot happen.
        }
    }

    /**
     * Remove the message content if it exists.
     */
    public void removeContent() {
        messageContent = null;
        messageContentBytes = null;
        messageContentObject = null;
        try {
            this.contentLengthHeader.setContentLength(0);
        } catch (InvalidArgumentException ex) {
        }
    }

    /**
     * Get a SIP header or Header list given its name.
     * 
     * @param headerName is the name of the header to get.
     * @return a header or header list that contians the retrieved header.
     */
    @SuppressWarnings("unchecked")
    public ListIterator<SIPHeader> getHeaders(String headerName) {
        if (headerName == null)
            throw new NullPointerException("null headerName");
        SIPHeader sipHeader = (SIPHeader) nameTable.get(SIPHeaderNamesCache
                .toLowerCase(headerName));
        // empty iterator
        if (sipHeader == null)
            return new LinkedList<SIPHeader>().listIterator();
        if (sipHeader instanceof SIPHeaderList) {
            return ((SIPHeaderList<SIPHeader>) sipHeader).listIterator();
        } else {
            return new HeaderIterator(this, sipHeader);
        }
    }

    /**
     * Get a header of the given name as a string. This concatenates the headers of a given type
     * as a comma separted list. This is useful for formatting and printing headers.
     * 
     * @param name
     * @return the header as a formatted string
     */
    public String getHeaderAsFormattedString(String name) {
        String lowerCaseName = name.toLowerCase();
        if (this.nameTable.containsKey(lowerCaseName)) {
            return this.nameTable.get(lowerCaseName).toString();
        } else {
            return this.getHeader(name).toString();
        }
    }

    private SIPHeader getSIPHeaderListLowerCase(String lowerCaseHeaderName) {
        return nameTable.get(lowerCaseHeaderName);
    }

    /**
     * Get a list of headers of the given name ( or null if no such header exists ).
     * 
     * @param headerName -- a header name from which to retrieve the list.
     * @return -- a list of headers with that name.
     */
    @SuppressWarnings("unchecked")
    private List<SIPHeader> getHeaderList(String headerName) {
        SIPHeader sipHeader = (SIPHeader) nameTable.get(SIPHeaderNamesCache
                .toLowerCase(headerName));
        if (sipHeader == null)
            return null;
        else if (sipHeader instanceof SIPHeaderList)
            return (List<SIPHeader>) (((SIPHeaderList< ? >) sipHeader).getHeaderList());
        else {
            LinkedList<SIPHeader> ll = new LinkedList<SIPHeader>();
            ll.add(sipHeader);
            return ll;
        }
    }

    /**
     * Return true if the SIPMessage has a header of the given name.
     * 
     * @param headerName is the header name for which we are testing.
     * @return true if the header is present in the message
     */
    public boolean hasHeader(String headerName) {
        return nameTable.containsKey(SIPHeaderNamesCache.toLowerCase(headerName));
    }

    /**
     * Return true if the message has a From header tag.
     * 
     * @return true if the message has a from header and that header has a tag.
     */
    public boolean hasFromTag() {
        return fromHeader != null && fromHeader.getTag() != null;
    }

    /**
     * Return true if the message has a To header tag.
     * 
     * @return true if the message has a to header and that header has a tag.
     */
    public boolean hasToTag() {
        return toHeader != null && toHeader.getTag() != null;
    }

    /**
     * Return the from tag.
     * 
     * @return the tag from the from header.
     * 
     */
    public String getFromTag() {
        return fromHeader == null ? null : fromHeader.getTag();
    }

    /**
     * Set the From Tag.
     * 
     * @param tag -- tag to set in the from header.
     */
    public void setFromTag(String tag) {
        try {
            fromHeader.setTag(tag);
        } catch (ParseException e) {
        }
    }

    /**
     * Set the to tag.
     * 
     * @param tag -- tag to set.
     */
    public void setToTag(String tag) {
        try {
            toHeader.setTag(tag);
        } catch (ParseException e) {
        }
    }

    /**
     * Return the to tag.
     */
    public String getToTag() {
        return toHeader == null ? null : toHeader.getTag();
    }

    /**
     * Return the encoded first line.
     */
    public abstract String getFirstLine();

    /**
     * Add a SIP header.
     * 
     * @param sipHeader -- sip header to add.
     */
    public void addHeader(Header sipHeader) {
        // Content length is never stored. Just computed.
        SIPHeader sh = (SIPHeader) sipHeader;
        try {
            if ((sipHeader instanceof ViaHeader) || (sipHeader instanceof RecordRouteHeader)) {
                attachHeader(sh, false, true);
            } else {
                attachHeader(sh, false, false);
            }
        } catch (SIPDuplicateHeaderException ex) {
            try {
                if (sipHeader instanceof ContentLength) {
                    ContentLength cl = (ContentLength) sipHeader;
                    contentLengthHeader.setContentLength(cl.getContentLength());
                }
            } catch (InvalidArgumentException e) {
            }
        }
    }

    /**
     * Add a header to the unparsed list of headers.
     * 
     * @param unparsed -- unparsed header to add to the list.
     */
    public void addUnparsed(String unparsed) {
        this.unrecognizedHeaders.add(unparsed);
    }

    /**
     * Add a SIP header.
     * 
     * @param sipHeader -- string version of SIP header to add.
     */

    public void addHeader(String sipHeader) {
        String hdrString = sipHeader.trim() + "\n";
        try {
            HeaderParser parser = ParserFactory.createParser(sipHeader);
            SIPHeader sh = parser.parse();
            this.attachHeader(sh, false);
        } catch (ParseException ex) {
            this.unrecognizedHeaders.add(hdrString);
        }
    }

    /**
     * Get a list containing the unrecognized headers.
     * 
     * @return a linked list containing unrecongnized headers.
     */
    public ListIterator<String> getUnrecognizedHeaders() {
        return this.unrecognizedHeaders.listIterator();
    }

    /**
     * Get the header names.
     * 
     * @return a list iterator to a list of header names. These are ordered in the same order as
     *         are present in the message.
     */
    public ListIterator<String> getHeaderNames() {
        Iterator<SIPHeader> li = this.headers.iterator();
        LinkedList<String> retval = new LinkedList<String>();
        while (li.hasNext()) {
            SIPHeader sipHeader = (SIPHeader) li.next();
            String name = sipHeader.getName();
            retval.add(name);
        }
        return retval.listIterator();
    }

    /**
     * Compare for equality.
     * 
     * @param other -- the other object to compare with.
     */
    public boolean equals(Object other) {
        if (!other.getClass().equals(this.getClass())) {
            return false;
        }
        SIPMessage otherMessage = (SIPMessage) other;
        Collection<SIPHeader> values = this.nameTable.values();
        Iterator<SIPHeader> it = values.iterator();
        if (nameTable.size() != otherMessage.nameTable.size()) {
            return false;
        }

        while (it.hasNext()) {
            SIPHeader mine = (SIPHeader) it.next();
            SIPHeader his = (SIPHeader) (otherMessage.nameTable.get(SIPHeaderNamesCache
                    .toLowerCase(mine.getName())));
            if (his == null) {
                return false;
            } else if (!his.equals(mine)) {
                return false;
            }
        }
        return true;
    }

    /**
     * get content disposition header or null if no such header exists.
     * 
     * @return the contentDisposition header
     */
    public javax.sip.header.ContentDispositionHeader getContentDisposition() {
        return (ContentDispositionHeader) getHeaderLowerCase(CONTENT_DISPOSITION_LOWERCASE);
    }

    private static final String CONTENT_DISPOSITION_LOWERCASE = SIPHeaderNamesCache
            .toLowerCase(ContentDispositionHeader.NAME);

    /**
     * get the content encoding header.
     * 
     * @return the contentEncoding header.
     */
    public javax.sip.header.ContentEncodingHeader getContentEncoding() {
        return (ContentEncodingHeader) getHeaderLowerCase(CONTENT_ENCODING_LOWERCASE);
    }

    private static final String CONTENT_ENCODING_LOWERCASE = SIPHeaderNamesCache
            .toLowerCase(ContentEncodingHeader.NAME);

    /**
     * Get the contentLanguage header.
     * 
     * @return the content language header.
     */
    public javax.sip.header.ContentLanguageHeader getContentLanguage() {
        return (ContentLanguageHeader) getHeaderLowerCase(CONTENT_LANGUAGE_LOWERCASE);
    }

    private static final String CONTENT_LANGUAGE_LOWERCASE = SIPHeaderNamesCache
            .toLowerCase(ContentLanguageHeader.NAME);

    /**
     * Get the exipres header.
     * 
     * @return the expires header or null if one does not exist.
     */
    public javax.sip.header.ExpiresHeader getExpires() {
        return (ExpiresHeader) getHeaderLowerCase(EXPIRES_LOWERCASE);
    }

    private static final String EXPIRES_LOWERCASE = SIPHeaderNamesCache
            .toLowerCase(ExpiresHeader.NAME);

    /**
     * Set the expiresHeader
     * 
     * @param expiresHeader -- the expires header to set.
     */

    public void setExpires(ExpiresHeader expiresHeader) {
        this.setHeader(expiresHeader);
    }

    /**
     * Set the content disposition header.
     * 
     * @param contentDispositionHeader -- content disposition header.
     */

    public void setContentDisposition(ContentDispositionHeader contentDispositionHeader) {
        this.setHeader(contentDispositionHeader);

    }

    public void setContentEncoding(ContentEncodingHeader contentEncodingHeader) {
        this.setHeader(contentEncodingHeader);

    }

    public void setContentLanguage(ContentLanguageHeader contentLanguageHeader) {
        this.setHeader(contentLanguageHeader);
    }

    /**
     * Set the content length header.
     * 
     * @param contentLength -- content length header.
     */
    public void setContentLength(ContentLengthHeader contentLength) {
        try {
            this.contentLengthHeader.setContentLength(contentLength.getContentLength());
        } catch (InvalidArgumentException ex) {
        }

    }

    /**
     * Set the size of all the headers. This is for book keeping. Called by the parser.
     * 
     * @param size -- size of the headers.
     */
    public void setSize(int size) {
        this.size = size;
    }

    public int getSize() {
        return this.size;
    }

    /*
     * (non-Javadoc)
     * 
     * @see javax.sip.message.Message#addLast(javax.sip.header.Header)
     */
    public void addLast(Header header) throws SipException, NullPointerException {
        if (header == null)
            throw new NullPointerException("null arg!");

        try {
            this.attachHeader((SIPHeader) header, false, false);
        } catch (SIPDuplicateHeaderException ex) {
            throw new SipException("Cannot add header - header already exists");
        }

    }

    /*
     * (non-Javadoc)
     * 
     * @see javax.sip.message.Message#addFirst(javax.sip.header.Header)
     */
    public void addFirst(Header header) throws SipException, NullPointerException {

        if (header == null)
            throw new NullPointerException("null arg!");

        try {
            this.attachHeader((SIPHeader) header, false, true);
        } catch (SIPDuplicateHeaderException ex) {
            throw new SipException("Cannot add header - header already exists");
        }

    }

    /*
     * (non-Javadoc)
     * 
     * @see javax.sip.message.Message#removeFirst(java.lang.String)
     */
    public void removeFirst(String headerName) throws NullPointerException {
        if (headerName == null)
            throw new NullPointerException("Null argument Provided!");
        this.removeHeader(headerName, true);

    }

    /*
     * (non-Javadoc)
     * 
     * @see javax.sip.message.Message#removeLast(java.lang.String)
     */
    public void removeLast(String headerName) {
        if (headerName == null)
            throw new NullPointerException("Null argument Provided!");
        this.removeHeader(headerName, false);

    }

    /**
     * Set the CSeq header.
     * 
     * @param cseqHeader -- CSeq Header.
     */

    public void setCSeq(CSeqHeader cseqHeader) {
        this.setHeader(cseqHeader);
    }

    /**
     * Set the application data pointer. This method is not used the stack. It is provided as a
     * convenient way of storing book-keeping data for applications. Note that null clears the
     * application data pointer (releases it).
     * 
     * @param applicationData -- application data pointer to set. null clears the application data
     *        pointer.
     */
    public void setApplicationData(Object applicationData) {
        this.applicationData = applicationData;
    }

    /**
     * Get the application data associated with this message.
     * 
     * @return stored application data.
     */
    public Object getApplicationData() {
        return this.applicationData;
    }

    /**
     * Get the multipart MIME content
     * 
     */
    public MultipartMimeContent getMultipartMimeContent() throws ParseException {
        if (this.contentLengthHeader.getContentLength() == 0) {
            return null;
        }
        MultipartMimeContentImpl retval = new MultipartMimeContentImpl(this
                .getContentTypeHeader());
        byte[] rawContent = getRawContent();
		try {
			String body = new String( rawContent, getCharset() );
	        retval.createContentList(body);
	        return retval;
		} catch (UnsupportedEncodingException e) {
			InternalErrorHandler.handleException(e);
			return null;
		}
    }
    
    public CallIdHeader getCallIdHeader() {
        return this.callIdHeader;
    }

   
    public FromHeader getFromHeader() {
        return this.fromHeader;
    }

   
    public ToHeader getToHeader() {
        return this.toHeader;
    }

  
    public ViaHeader getTopmostViaHeader() {
        return this.getTopmostVia();
    }
    
    public CSeqHeader getCSeqHeader() {
        return this.cSeqHeader;
    }
 
    /**
     * Returns the charset to use for encoding/decoding the body of this message
     */
    protected final String getCharset() {
    	ContentType ct = getContentTypeHeader();
    	if (ct!=null) {
    		String c = ct.getCharset();
    		return c!=null ? c : contentEncodingCharset;
    	} else return contentEncodingCharset;
    }
    
    /**
     * Return true if this is a null request (i.e. does not have a request line ).
     * 
     * @return true if null request.
     */
    public boolean isNullRequest() {
        return  this.nullRequest;
    }
    
    /**
     * Set a flag to indiate this is a special message ( encoded with CRLFCRLF ).
     * 
     */
    public void setNullRequest() {
        this.nullRequest = true;
    }
    
    
    public abstract void setSIPVersion(String sipVersion) throws ParseException;

    public abstract String getSIPVersion();

    public abstract String toString();

}
