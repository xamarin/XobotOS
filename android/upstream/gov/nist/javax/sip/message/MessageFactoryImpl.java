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
 * Product of NIST/ITL Advanced Networking Technologies Division (ANTD).        *
 *******************************************************************************/
package gov.nist.javax.sip.message;

import java.text.ParseException;
import javax.sip.header.*;

import java.util.LinkedList;
import java.util.List;
import gov.nist.javax.sip.header.*;

import javax.sip.message.*;
import javax.sip.address.*;
import gov.nist.javax.sip.parser.*;

/**
 * Message Factory implementation
 *
 * @version 1.2 $Revision: 1.23 $ $Date: 2009/09/08 01:58:40 $
 * @since 1.1
 *
 * @author M. Ranganathan <br/>
 * @author Olivier Deruelle <br/>
 *
 */
@SuppressWarnings("unchecked")
public class MessageFactoryImpl implements MessageFactory, MessageFactoryExt {

    private boolean testing = false;
    
    private boolean strict  = true;

    private static String defaultContentEncodingCharset = "UTF-8";


    /*
     * The UserAgent header to include for all requests created from this message factory.
     */
    private static UserAgentHeader userAgent;

    /*
     * The Server header to include
     */
    private static ServerHeader server;
    
    
    public void setStrict(boolean strict) {
        this.strict = strict;
    }



    /**
     * This is for testing -- allows you to generate invalid requests
     */
    public void setTest(boolean flag) {
        this.testing = flag;
    }

    /**
     * Creates a new instance of MessageFactoryImpl
     */
    public MessageFactoryImpl() {
    }

    /**
     * Creates a new Request message of type specified by the method paramater,
     * containing the URI of the Request, the mandatory headers of the message
     * with a body in the form of a Java object and the body content type.
     *
     * @param requestURI -
     *            the new URI object of the requestURI value of this Message.
     * @param method -
     *            the new string of the method value of this Message.
     * @param callId -
     *            the new CallIdHeader object of the callId value of this
     *            Message.
     * @param cSeq -
     *            the new CSeqHeader object of the cSeq value of this Message.
     * @param from -
     *            the new FromHeader object of the from value of this Message.
     * @param to -
     *            the new ToHeader object of the to value of this Message.
     * @param via -
     *            the new List object of the ViaHeaders of this Message.
     * @param content -
     *            the new Object of the body content value of this Message.
     * @param contentType -
     *            the new ContentTypeHeader object of the content type value of
     *            this Message.
     * @throws ParseException
     *             which signals that an error has been reached unexpectedly
     *             while parsing the method or the body.
     */
    public Request createRequest(javax.sip.address.URI requestURI,
            String method, CallIdHeader callId, CSeqHeader cSeq,
            FromHeader from, ToHeader to, List via,
            MaxForwardsHeader maxForwards, ContentTypeHeader contentType,
            Object content) throws ParseException {
        if (requestURI == null || method == null || callId == null
                || cSeq == null || from == null || to == null || via == null
                || maxForwards == null || content == null
                || contentType == null)
            throw new NullPointerException("Null parameters");

        SIPRequest sipRequest = new SIPRequest();
        sipRequest.setRequestURI(requestURI);
        sipRequest.setMethod(method);
        sipRequest.setCallId(callId);
        sipRequest.setCSeq(cSeq);
        sipRequest.setFrom(from);
        sipRequest.setTo(to);
        sipRequest.setVia(via);
        sipRequest.setMaxForwards(maxForwards);
        sipRequest.setContent(content, contentType);
        if ( userAgent != null ) {
            sipRequest.setHeader(userAgent);
        }

        return sipRequest;
    }

    /**
     * Creates a new Request message of type specified by the method paramater,
     * containing the URI of the Request, the mandatory headers of the message
     * with a body in the form of a byte array and body content type.
     *
     * @param requestURI -
     *            the new URI object of the requestURI value of this Message.
     * @param method -
     *            the new string of the method value of this Message.
     * @param callId -
     *            the new CallIdHeader object of the callId value of this
     *            Message.
     * @param cSeq -
     *            the new CSeqHeader object of the cSeq value of this Message.
     * @param from -
     *            the new FromHeader object of the from value of this Message.
     * @param to -
     *            the new ToHeader object of the to value of this Message.
     * @param via -
     *            the new List object of the ViaHeaders of this Message.
     * @param content -
     *            the new byte array of the body content value of this Message.
     * @param contentType -
     *            the new ContentTypeHeader object of the content type value of
     *            this Message.
     * @throws ParseException
     *             which signals that an error has been reached unexpectedly
     *             while parsing the method or the body.
     */
    public Request createRequest(URI requestURI, String method,
            CallIdHeader callId, CSeqHeader cSeq, FromHeader from, ToHeader to,
            List via, MaxForwardsHeader maxForwards, byte[] content,
            ContentTypeHeader contentType) throws ParseException {
        if (requestURI == null || method == null || callId == null
                || cSeq == null || from == null || to == null || via == null
                || maxForwards == null || content == null
                || contentType == null)
            throw new ParseException(
                    "JAIN-SIP Exception, some parameters are missing"
                            + ", unable to create the request", 0);

        SIPRequest sipRequest = new SIPRequest();
        sipRequest.setRequestURI(requestURI);
        sipRequest.setMethod(method);
        sipRequest.setCallId(callId);
        sipRequest.setCSeq(cSeq);
        sipRequest.setFrom(from);
        sipRequest.setTo(to);
        sipRequest.setVia(via);
        sipRequest.setMaxForwards(maxForwards);
        sipRequest.setHeader((ContentType) contentType);
        sipRequest.setMessageContent(content);
        if ( userAgent != null ) {
            sipRequest.setHeader(userAgent);
        }
        return sipRequest;
    }

    /**
     * Creates a new Request message of type specified by the method paramater,
     * containing the URI of the Request, the mandatory headers of the message.
     * This new Request does not contain a body.
     *
     * @param requestURI -
     *            the new URI object of the requestURI value of this Message.
     * @param method -
     *            the new string of the method value of this Message.
     * @param callId -
     *            the new CallIdHeader object of the callId value of this
     *            Message.
     * @param cSeq -
     *            the new CSeqHeader object of the cSeq value of this Message.
     * @param from -
     *            the new FromHeader object of the from value of this Message.
     * @param to -
     *            the new ToHeader object of the to value of this Message.
     * @param via -
     *            the new List object of the ViaHeaders of this Message.
     * @throws ParseException
     *             which signals that an error has been reached unexpectedly
     *             while parsing the method.
     */
    public Request createRequest(URI requestURI, String method,
            CallIdHeader callId, CSeqHeader cSeq, FromHeader from, ToHeader to,
            List via, MaxForwardsHeader maxForwards) throws ParseException {
        if (requestURI == null || method == null || callId == null
                || cSeq == null || from == null || to == null || via == null
                || maxForwards == null)
            throw new ParseException(
                    "JAIN-SIP Exception, some parameters are missing"
                            + ", unable to create the request", 0);

        SIPRequest sipRequest = new SIPRequest();
        sipRequest.setRequestURI(requestURI);
        sipRequest.setMethod(method);
        sipRequest.setCallId(callId);
        sipRequest.setCSeq(cSeq);
        sipRequest.setFrom(from);
        sipRequest.setTo(to);
        sipRequest.setVia(via);
        sipRequest.setMaxForwards(maxForwards);
        if (userAgent != null) {
            sipRequest.setHeader(userAgent);
        }

        return sipRequest;
    }

    // Standard Response Creation methods

    /**
     * Creates a new Response message of type specified by the statusCode
     * paramater, containing the mandatory headers of the message with a body in
     * the form of a Java object and the body content type.
     *
     * @param statusCode -
     *            the new integer of the statusCode value of this Message.
     * @param callId -
     *            the new CallIdHeader object of the callId value of this
     *            Message.
     * @param cSeq -
     *            the new CSeqHeader object of the cSeq value of this Message.
     * @param from -
     *            the new FromHeader object of the from value of this Message.
     * @param to -
     *            the new ToHeader object of the to value of this Message.
     * @param via -
     *            the new List object of the ViaHeaders of this Message.
     * @param content -
     *            the new Object of the body content value of this Message.
     * @param contentType -
     *            the new ContentTypeHeader object of the content type value of
     *            this Message.
     * @throws ParseException
     *             which signals that an error has been reached unexpectedly
     *             while parsing the statusCode or the body.
     */
    public Response createResponse(int statusCode, CallIdHeader callId,
            CSeqHeader cSeq, FromHeader from, ToHeader to, List via,
            MaxForwardsHeader maxForwards, Object content,
            ContentTypeHeader contentType) throws ParseException {
        if (callId == null || cSeq == null || from == null || to == null
                || via == null || maxForwards == null || content == null
                || contentType == null)
            throw new NullPointerException(" unable to create the response");

        SIPResponse sipResponse = new SIPResponse();
        StatusLine statusLine = new StatusLine();
        statusLine.setStatusCode(statusCode);
        String reasonPhrase = SIPResponse.getReasonPhrase(statusCode);
        //if (reasonPhrase == null)
        //  throw new ParseException(statusCode + " Unkown  ", 0);
        statusLine.setReasonPhrase(reasonPhrase);
        sipResponse.setStatusLine(statusLine);
        sipResponse.setCallId(callId);
        sipResponse.setCSeq(cSeq);
        sipResponse.setFrom(from);
        sipResponse.setTo(to);
        sipResponse.setVia(via);
        sipResponse.setMaxForwards(maxForwards);
        sipResponse.setContent(content, contentType);
        if (userAgent != null) {
            sipResponse.setHeader(userAgent);
        }
        return sipResponse;
    }

    /**
     * Creates a new Response message of type specified by the statusCode
     * paramater, containing the mandatory headers of the message with a body in
     * the form of a byte array and the body content type.
     *
     * @param statusCode -
     *            the new integer of the statusCode value of this Message.
     * @param callId -
     *            the new CallIdHeader object of the callId value of this
     *            Message.
     * @param cSeq -
     *            the new CSeqHeader object of the cSeq value of this Message.
     * @param from -
     *            the new FromHeader object of the from value of this Message.
     * @param to -
     *            the new ToHeader object of the to value of this Message.
     * @param via -
     *            the new List object of the ViaHeaders of this Message.
     * @param content -
     *            the new byte array of the body content value of this Message.
     * @param contentType -
     *            the new ContentTypeHeader object of the content type value of
     *            this Message.
     * @throws ParseException
     *             which signals that an error has been reached unexpectedly
     *             while parsing the statusCode or the body.
     */
    public Response createResponse(int statusCode, CallIdHeader callId,
            CSeqHeader cSeq, FromHeader from, ToHeader to, List via,
            MaxForwardsHeader maxForwards, byte[] content,
            ContentTypeHeader contentType) throws ParseException {
        if (callId == null || cSeq == null || from == null || to == null
                || via == null || maxForwards == null || content == null
                || contentType == null)
            throw new NullPointerException("Null params ");

        SIPResponse sipResponse = new SIPResponse();
        sipResponse.setStatusCode(statusCode);
        sipResponse.setCallId(callId);
        sipResponse.setCSeq(cSeq);
        sipResponse.setFrom(from);
        sipResponse.setTo(to);
        sipResponse.setVia(via);
        sipResponse.setMaxForwards(maxForwards);
        sipResponse.setHeader((ContentType) contentType);
        sipResponse.setMessageContent(content);
        if (userAgent != null) {
            sipResponse.setHeader(userAgent);
        }
        return sipResponse;
    }

    /**
     * Creates a new Response message of type specified by the statusCode
     * paramater, containing the mandatory headers of the message. This new
     * Response does not contain a body.
     *
     * @param statusCode -
     *            the new integer of the statusCode value of this Message.
     * @param callId -
     *            the new CallIdHeader object of the callId value of this
     *            Message.
     * @param cSeq -
     *            the new CSeqHeader object of the cSeq value of this Message.
     * @param from -
     *            the new FromHeader object of the from value of this Message.
     * @param to -
     *            the new ToHeader object of the to value of this Message.
     * @param via -
     *            the new List object of the ViaHeaders of this Message.
     * @throws ParseException
     *             which signals that an error has been reached unexpectedly
     *             while parsing the statusCode.
     */
    public Response createResponse(int statusCode, CallIdHeader callId,
            CSeqHeader cSeq, FromHeader from, ToHeader to, List via,
            MaxForwardsHeader maxForwards) throws ParseException {
        if (callId == null || cSeq == null || from == null || to == null
                || via == null || maxForwards == null)
            throw new ParseException(
                    "JAIN-SIP Exception, some parameters are missing"
                            + ", unable to create the response", 0);

        SIPResponse sipResponse = new SIPResponse();
        sipResponse.setStatusCode(statusCode);
        sipResponse.setCallId(callId);
        sipResponse.setCSeq(cSeq);
        sipResponse.setFrom(from);
        sipResponse.setTo(to);
        sipResponse.setVia(via);
        sipResponse.setMaxForwards(maxForwards);
        if (userAgent != null) {
            sipResponse.setHeader(userAgent);
        }
        return sipResponse;
    }

    // Response Creation methods based on a Request

    /**
     * Creates a new Response message of type specified by the statusCode
     * paramater, based on a specific Request with a new body in the form of a
     * Java object and the body content type.
     *
     * @param statusCode -
     *            the new integer of the statusCode value of this Message.
     * @param request -
     *            the received Reqest object upon which to base the Response.
     * @param content -
     *            the new Object of the body content value of this Message.
     * @param contentType -
     *            the new ContentTypeHeader object of the content type value of
     *            this Message.
     * @throws ParseException
     *             which signals that an error has been reached unexpectedly
     *             while parsing the statusCode or the body.
     */
    public Response createResponse(int statusCode, Request request,
            ContentTypeHeader contentType, Object content)
            throws ParseException {
        if (request == null || content == null || contentType == null)
            throw new NullPointerException("null parameters");

        SIPRequest sipRequest = (SIPRequest) request;
        SIPResponse sipResponse = sipRequest.createResponse(statusCode);
        sipResponse.setContent(content, contentType);
        if (server != null) {
            sipResponse.setHeader(server);
        }
        return sipResponse;
    }

    /**
     * Creates a new Response message of type specified by the statusCode
     * paramater, based on a specific Request with a new body in the form of a
     * byte array and the body content type.
     *
     * @param statusCode -
     *            the new integer of the statusCode value of this Message.
     * @param request -
     *            the received Reqest object upon which to base the Response.
     * @param content -
     *            the new byte array of the body content value of this Message.
     * @param contentType -
     *            the new ContentTypeHeader object of the content type value of
     *            this Message.
     * @throws ParseException
     *             which signals that an error has been reached unexpectedly
     *             while parsing the statusCode or the body.
     */
    public Response createResponse(int statusCode, Request request,
            ContentTypeHeader contentType, byte[] content)
            throws ParseException {
        if (request == null || content == null || contentType == null)
            throw new NullPointerException("null Parameters");

        SIPRequest sipRequest = (SIPRequest) request;
        SIPResponse sipResponse = sipRequest.createResponse(statusCode);
        sipResponse.setHeader((ContentType) contentType);
        sipResponse.setMessageContent(content);
        if (server != null) {
            sipResponse.setHeader(server);
        }
        return sipResponse;
    }

    /**
     * Creates a new Response message of type specified by the statusCode
     * paramater, based on a specific Request message. This new Response does
     * not contain a body.
     *
     * @param statusCode -
     *            the new integer of the statusCode value of this Message.
     * @param request -
     *            the received Reqest object upon which to base the Response.
     * @throws ParseException
     *             which signals that an error has been reached unexpectedly
     *             while parsing the statusCode.
     */
    public Response createResponse(int statusCode, Request request)
            throws ParseException {
        if (request == null)
            throw new NullPointerException("null parameters");

        // if (LogWriter.needsLogging)
        // LogWriter.logMessage("createResponse " + request);

        SIPRequest sipRequest = (SIPRequest) request;
        SIPResponse sipResponse = sipRequest.createResponse(statusCode);
        // Remove the content from the message (Bug report from
        // Antonis Karydas.
        sipResponse.removeContent();
        sipResponse.removeHeader(ContentTypeHeader.NAME);
        if (server != null) {
            sipResponse.setHeader(server);
        }
        return sipResponse;
    }

    /**
     * Creates a new Request message of type specified by the method paramater,
     * containing the URI of the Request, the mandatory headers of the message
     * with a body in the form of a byte array and body content type.
     *
     * @param requestURI -
     *            the new URI object of the requestURI value of this Message.
     * @param method -
     *            the new string of the method value of this Message.
     * @param callId -
     *            the new CallIdHeader object of the callId value of this
     *            Message.
     * @param cSeq -
     *            the new CSeqHeader object of the cSeq value of this Message.
     * @param from -
     *            the new FromHeader object of the from value of this Message.
     * @param to -
     *            the new ToHeader object of the to value of this Message.
     * @param via -
     *            the new List object of the ViaHeaders of this Message.
     * @param contentType -
     *            the new ContentTypeHeader object of the content type value of
     *            this Message.
     * @param content -
     *            the new byte array of the body content value of this Message.
     * @throws ParseException
     *             which signals that an error has been reached unexpectedly
     *             while parsing the method or the body.
     */
    public Request createRequest(javax.sip.address.URI requestURI,
            String method, CallIdHeader callId, CSeqHeader cSeq,
            FromHeader from, ToHeader to, List via,
            MaxForwardsHeader maxForwards, ContentTypeHeader contentType,
            byte[] content) throws ParseException {
        if (requestURI == null || method == null || callId == null
                || cSeq == null || from == null || to == null || via == null
                || maxForwards == null || content == null
                || contentType == null)
            throw new NullPointerException("missing parameters");

        SIPRequest sipRequest = new SIPRequest();
        sipRequest.setRequestURI(requestURI);
        sipRequest.setMethod(method);
        sipRequest.setCallId(callId);
        sipRequest.setCSeq(cSeq);
        sipRequest.setFrom(from);
        sipRequest.setTo(to);
        sipRequest.setVia(via);
        sipRequest.setMaxForwards(maxForwards);
        sipRequest.setContent(content, contentType);
        if (userAgent != null) {
            sipRequest.setHeader(userAgent);
        }
        return sipRequest;
    }

    /**
     * Creates a new Response message of type specified by the statusCode
     * paramater, containing the mandatory headers of the message with a body in
     * the form of a Java object and the body content type.
     *
     * @param statusCode
     *            the new integer of the statusCode value of this Message.
     * @param callId
     *            the new CallIdHeader object of the callId value of this
     *            Message.
     * @param cSeq
     *            the new CSeqHeader object of the cSeq value of this Message.
     * @param from
     *            the new FromHeader object of the from value of this Message.
     * @param to
     *            the new ToHeader object of the to value of this Message.
     * @param via
     *            the new List object of the ViaHeaders of this Message.
     * @param contentType
     *            the new ContentTypeHeader object of the content type value of
     *            this Message.
     * @param content
     *            the new Object of the body content value of this Message.
     * @throws ParseException
     *             which signals that an error has been reached unexpectedly
     *             while parsing the statusCode or the body.
     */
    public Response createResponse(int statusCode, CallIdHeader callId,
            CSeqHeader cSeq, FromHeader from, ToHeader to, List via,
            MaxForwardsHeader maxForwards, ContentTypeHeader contentType,
            Object content) throws ParseException {
        if (callId == null || cSeq == null || from == null || to == null
                || via == null || maxForwards == null || content == null
                || contentType == null)
            throw new NullPointerException("missing parameters");
        SIPResponse sipResponse = new SIPResponse();
        StatusLine statusLine = new StatusLine();
        statusLine.setStatusCode(statusCode);
        String reason = SIPResponse.getReasonPhrase(statusCode);
        if (reason == null)
            throw new ParseException(statusCode + " Unknown", 0);
        statusLine.setReasonPhrase(reason);
        sipResponse.setStatusLine(statusLine);
        sipResponse.setCallId(callId);
        sipResponse.setCSeq(cSeq);
        sipResponse.setFrom(from);
        sipResponse.setTo(to);
        sipResponse.setVia(via);
        sipResponse.setContent(content, contentType);
        if ( userAgent != null) {
            sipResponse.setHeader(userAgent);
        }
        return sipResponse;

    }

    /**
     * Creates a new Response message of type specified by the statusCode
     * paramater, containing the mandatory headers of the message with a body in
     * the form of a byte array and the body content type.
     *
     * @param statusCode
     *            the new integer of the statusCode value of this Message.
     * @param callId
     *            the new CallIdHeader object of the callId value of this
     *            Message.
     * @param cSeq
     *            the new CSeqHeader object of the cSeq value of this Message.
     * @param from
     *            the new FromHeader object of the from value of this Message.
     * @param to
     *            the new ToHeader object of the to value of this Message.
     * @param via
     *            the new List object of the ViaHeaders of this Message.
     * @param contentType
     *            the new ContentTypeHeader object of the content type value of
     *            this Message.
     * @param content
     *            the new byte array of the body content value of this Message.
     * @throws ParseException
     *             which signals that an error has been reached unexpectedly
     *             while parsing the statusCode or the body.
     */
    public Response createResponse(int statusCode, CallIdHeader callId,
            CSeqHeader cSeq, FromHeader from, ToHeader to, List via,
            MaxForwardsHeader maxForwards, ContentTypeHeader contentType,
            byte[] content) throws ParseException {
        if (callId == null || cSeq == null || from == null || to == null
                || via == null || maxForwards == null || content == null
                || contentType == null)
            throw new NullPointerException("missing parameters");
        SIPResponse sipResponse = new SIPResponse();
        StatusLine statusLine = new StatusLine();
        statusLine.setStatusCode(statusCode);
        String reason = SIPResponse.getReasonPhrase(statusCode);
        if (reason == null)
            throw new ParseException(statusCode + " : Unknown", 0);
        statusLine.setReasonPhrase(reason);
        sipResponse.setStatusLine(statusLine);
        sipResponse.setCallId(callId);
        sipResponse.setCSeq(cSeq);
        sipResponse.setFrom(from);
        sipResponse.setTo(to);
        sipResponse.setVia(via);
        sipResponse.setContent(content, contentType);
        if ( userAgent != null) {
            sipResponse.setHeader(userAgent);
        }
        return sipResponse;
    }

    /**
     * Create a request from a string. Conveniance method for UACs that want to
     * create an outgoing request from a string. Only the headers of the request
     * should be included in the String that is supplied to this method.
     *
     * @param requestString --
     *            string from which to create the message null string returns an
     *            empty message.
     */
    public javax.sip.message.Request createRequest(String requestString)
            throws java.text.ParseException {
        if (requestString == null || requestString.equals("")) {
            SIPRequest retval = new SIPRequest();
            retval.setNullRequest();
            return retval;
        }

        StringMsgParser smp = new StringMsgParser();
        smp.setStrict(this.strict);

        /*
         * This allows you to catch parse exceptions and create invalid messages
         * if you want.
         */
        ParseExceptionListener parseExceptionListener = new ParseExceptionListener() {

            public void handleException(ParseException ex,
                    SIPMessage sipMessage, Class headerClass,
                    String headerText, String messageText)
                    throws ParseException {
                // Rethrow the error for the essential headers. Otherwise bad
                // headers are simply
                // recorded in the message.
                if (testing) {
                    if (headerClass == From.class || headerClass == To.class
                            || headerClass == CallID.class
                            || headerClass == MaxForwards.class
                            || headerClass == Via.class
                            || headerClass == RequestLine.class
                            || headerClass == StatusLine.class
                            || headerClass == CSeq.class)
                        throw ex;

                    sipMessage.addUnparsed(headerText);
                }

            }

        };

        if (this.testing)
            smp.setParseExceptionListener(parseExceptionListener);

        SIPMessage sipMessage = smp.parseSIPMessage(requestString);

        if (!(sipMessage instanceof SIPRequest))
            throw new ParseException(requestString, 0);

        return (SIPRequest) sipMessage;
    }

    /**
     * Create a response from a string
     *
     * @param responseString --
     *            string from which to create the message null string returns an
     *            empty message.
     *
     */
    public Response createResponse(String responseString)
            throws java.text.ParseException {
        if (responseString == null)
            return new SIPResponse();

        StringMsgParser smp = new StringMsgParser();

        SIPMessage sipMessage = smp.parseSIPMessage(responseString);

        if (!(sipMessage instanceof SIPResponse))
            throw new ParseException(responseString, 0);

        return (SIPResponse) sipMessage;
    }

    /**
     * Set the common UserAgent header for all requests created from this message factory.
     * This header is applied to all Messages created from this Factory object except those
     * that take String for an argument and create Message from the given String.
     *
     * @param userAgent -- the user agent header to set.
     *
     * @since 2.0
     */

    public void setDefaultUserAgentHeader(UserAgentHeader userAgent) {
        MessageFactoryImpl.userAgent = userAgent;
    }

    /**
     * Set the common Server header for all responses created from this message factory.
     * This header is applied to all Messages created from this Factory object except those
     * that take String for an argument and create Message from the given String.
     *
     * @param userAgent -- the user agent header to set.
     *
     * @since 2.0
     */

    public void setDefaultServerHeader(ServerHeader server) {
        MessageFactoryImpl.server = server;
    }
    /**
     * Get the default common UserAgentHeader.
     *
     * @return the user agent header.
     *
     * @since 2.0
     */
    public static UserAgentHeader getDefaultUserAgentHeader() {
        return userAgent;
    }


    /**
     * Get the default common server header.
     *
     * @return the server header.
     */
    public static ServerHeader getDefaultServerHeader() {
        return server;
    }


    /**
     * Set default charset used for encoding String content.
     * @param charset
     */
    public  void setDefaultContentEncodingCharset(String charset) throws NullPointerException,
    IllegalArgumentException {
        if (charset == null ) throw new NullPointerException ("Null argument!");
        MessageFactoryImpl.defaultContentEncodingCharset = charset;

    }

    public static String getDefaultContentEncodingCharset() {
        return MessageFactoryImpl.defaultContentEncodingCharset;
    }

    
    public MultipartMimeContent createMultipartMimeContent(ContentTypeHeader multipartMimeCth,
            String[] contentType,
            String[] contentSubtype, 
            String[] contentBody) {
        String boundary = multipartMimeCth.getParameter("boundary");
        MultipartMimeContentImpl retval = new MultipartMimeContentImpl(multipartMimeCth);
        for (int i = 0 ;  i < contentType.length; i++ ) {
            ContentTypeHeader cth = new ContentType(contentType[i],contentSubtype[i]);
            ContentImpl contentImpl  = new ContentImpl(contentBody[i],boundary);
            contentImpl.setContentTypeHeader(cth);
            retval.add(contentImpl);
        }
        return retval;
    }




}
