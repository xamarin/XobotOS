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
 * Product of NIST/ITL Advanced Networking Technologies Division (ANTD).       *
 ******************************************************************************/
package gov.nist.javax.sip.stack;

import gov.nist.javax.sip.message.*;
import gov.nist.javax.sip.address.*;
import gov.nist.javax.sip.header.*;
import gov.nist.javax.sip.*;
import gov.nist.core.*;
import gov.nist.core.net.AddressResolver;

import javax.sip.*;
import java.util.Iterator;
import java.util.LinkedList;
import java.util.ListIterator;

import javax.sip.header.RouteHeader;
import javax.sip.header.ViaHeader;
import javax.sip.message.*;
import javax.sip.address.*;

/*
 * Bug reported by Will Scullin -- maddr was being ignored when routing
 * requests. Bug reported by Antonis Karydas - the RequestURI can be a non-sip
 * URI Jiang He - use address in route header. Significant changes to conform to
 * RFC 3261 made by Jeroen van Bemmel. Hagai Sela contributed a bug fix to the
 * strict route post processing code.
 *
 */

/**
 * This is the default router. When the implementation wants to forward a
 * request and had run out of othe options, then it calls this method to figure
 * out where to send the request. The default router implements a simple
 * "default routing algorithm" which just forwards to the configured proxy
 * address.
 *
 * <p>
 * When <code>javax.sip.USE_ROUTER_FOR_ALL_URIS</code> is set to
 * <code>false</code>, the next hop is determined according to the following
 * algorithm:
 * <ul>
 * <li> If the request contains one or more Route headers, use the URI of the
 * topmost Route header as next hop, possibly modifying the request in the
 * process if the topmost Route header contains no lr parameter(*)
 * <li> Else, if the property <code>javax.sip.OUTBOUND_PROXY</code> is set,
 * use its value as the next hop
 * <li> Otherwise, use the request URI as next hop. If the request URI is not a
 * SIP URI, call {@link javax.sip.address.Router#getNextHop(Request)} provided
 * by the application.
 * </ul>
 *
 * <p>
 * (*)Note that in case the topmost Route header contains no 'lr' parameter
 * (which means the next hop is a strict router), the implementation will
 * perform 'Route Information Postprocessing' as described in RFC3261 section
 * 16.6 step 6 (also known as "Route header popping"). That is, the following
 * modifications will be made to the request:
 * <ol>
 * <li>The implementation places the Request-URI into the Route header field as
 * the last value.
 * <li>The implementation then places the first Route header field value into
 * the Request-URI and removes that value from the Route header field.
 * </ol>
 * Subsequently, the request URI will be used as next hop target
 *
 *
 * @version 1.2 $Revision: 1.17 $ $Date: 2009/11/14 20:06:17 $
 *
 * @author M. Ranganathan <br/>
 *
 */
public class DefaultRouter implements Router {

    private SipStackImpl sipStack;

    private Hop defaultRoute;

    private DefaultRouter() {

    }

    /**
     * Constructor.
     */
    public DefaultRouter(SipStack sipStack, String defaultRoute) {
        this.sipStack = (SipStackImpl) sipStack;
        if (defaultRoute != null) {
            try {
                this.defaultRoute = (Hop) this.sipStack.getAddressResolver()
                        .resolveAddress((Hop) (new HopImpl(defaultRoute)));
            } catch (IllegalArgumentException ex) {
                // The outbound proxy is optional. If specified it should be host:port/transport.
                ((SIPTransactionStack) sipStack)
                        .getStackLogger()
                        .logError(
                                "Invalid default route specification - need host:port/transport");
                throw ex;
            }
        }
    }

    /**
     * Return addresses for default proxy to forward the request to. The list is
     * organized in the following priority. If the requestURI refers directly to
     * a host, the host and port information are extracted from it and made the
     * next hop on the list. If the default route has been specified, then it is
     * used to construct the next element of the list. <code>
     * RouteHeader firstRoute = (RouteHeader) req.getHeader( RouteHeader.NAME );
     * if (firstRoute!=null) {
     *   URI uri = firstRoute.getAddress().getURI();
     *    if (uri.isSIPUri()) {
     *       SipURI nextHop = (SipURI) uri;
     *       if ( nextHop.hasLrParam() ) {
     *           // OK, use it
     *       } else {
     *           nextHop = fixStrictRouting( req );        <--- Here, make the modifications as per RFC3261
     *       }
     *   } else {
     *       // error: non-SIP URI not allowed in Route headers
     *       throw new SipException( "Request has Route header with non-SIP URI" );
     *   }
     * } else if (outboundProxy!=null) {
     *   // use outbound proxy for nextHop
     * } else if ( req.getRequestURI().isSipURI() ) {
     *   // use request URI for nextHop
     * }
     *
     * </code>
     *
     * @param request
     *            is the sip request to route.
     *
     */
    public Hop getNextHop(Request request) throws SipException {

        SIPRequest sipRequest = (SIPRequest) request;

        RequestLine requestLine = sipRequest.getRequestLine();
        if (requestLine == null) {
            return defaultRoute;
        }
        javax.sip.address.URI requestURI = requestLine.getUri();
        if (requestURI == null)
            throw new IllegalArgumentException("Bad message: Null requestURI");

        RouteList routes = sipRequest.getRouteHeaders();

        /*
         * In case the topmost Route header contains no 'lr' parameter (which
         * means the next hop is a strict router), the implementation will
         * perform 'Route Information Postprocessing' as described in RFC3261
         * section 16.6 step 6 (also known as "Route header popping"). That is,
         * the following modifications will be made to the request:
         *
         * The implementation places the Request-URI into the Route header field
         * as the last value.
         *
         * The implementation then places the first Route header field value
         * into the Request-URI and removes that value from the Route header
         * field.
         *
         * Subsequently, the request URI will be used as next hop target
         */

        if (routes != null) {

            // to send the request through a specified hop the application is
            // supposed to prepend the appropriate Route header which.
            Route route = (Route) routes.getFirst();
            URI uri = route.getAddress().getURI();
            if (uri.isSipURI()) {
                SipURI sipUri = (SipURI) uri;
                if (!sipUri.hasLrParam()) {

                    fixStrictRouting(sipRequest);
                    if (sipStack.isLoggingEnabled())
                        sipStack.getStackLogger()
                                .logDebug("Route post processing fixed strict routing");
                }

                Hop hop = createHop(sipUri,request);
                if (sipStack.isLoggingEnabled())
                    sipStack.getStackLogger()
                            .logDebug("NextHop based on Route:" + hop);
                return hop;
            } else {
                throw new SipException("First Route not a SIP URI");
            }

        } else if (requestURI.isSipURI()
                && ((SipURI) requestURI).getMAddrParam() != null) {
            Hop hop = createHop((SipURI) requestURI,request);
            if (sipStack.isLoggingEnabled())
                sipStack.getStackLogger()
                        .logDebug("Using request URI maddr to route the request = "
                                + hop.toString());

            // JvB: don't remove it!
            // ((SipURI) requestURI).removeParameter("maddr");

            return hop;

        } else if (defaultRoute != null) {
            if (sipStack.isLoggingEnabled())
                sipStack.getStackLogger()
                        .logDebug("Using outbound proxy to route the request = "
                                + defaultRoute.toString());
            return defaultRoute;
        } else if (requestURI.isSipURI()) {
            Hop hop = createHop((SipURI) requestURI,request);
            if (hop != null && sipStack.isLoggingEnabled())
                sipStack.getStackLogger().logDebug("Used request-URI for nextHop = "
                        + hop.toString());
            else if (sipStack.isLoggingEnabled()) {
                sipStack.getStackLogger()
                        .logDebug("returning null hop -- loop detected");
            }
            return hop;

        } else {
            // The internal router should never be consulted for non-sip URIs.
            InternalErrorHandler.handleException("Unexpected non-sip URI",
                    this.sipStack.getStackLogger());
            return null;
        }

    }

    /**
     * Performs strict router fix according to RFC3261 section 16.6 step 6
     *
     * pre: top route header in request has no 'lr' parameter in URI post:
     * request-URI added as last route header, new req-URI = top-route-URI
     */
    public void fixStrictRouting(SIPRequest req) {

        RouteList routes = req.getRouteHeaders();
        Route first = (Route) routes.getFirst();
        SipUri firstUri = (SipUri) first.getAddress().getURI();
        routes.removeFirst();

        // Add request-URI as last Route entry
        AddressImpl addr = new AddressImpl();
        addr.setAddess(req.getRequestURI()); // don't clone it
        Route route = new Route(addr);

        routes.add(route); // as last one
        req.setRequestURI(firstUri);
        if (sipStack.isLoggingEnabled()) {
            sipStack.getStackLogger().logDebug("post: fixStrictRouting" + req);
        }
    }

    /**
     * Utility method to create a hop from a SIP URI
     *
     * @param sipUri
     * @return
     */


    private final Hop createHop(SipURI sipUri, Request request) {
        // always use TLS when secure
        String transport = sipUri.isSecure() ? SIPConstants.TLS : sipUri
                .getTransportParam();
        if (transport == null) {
            //@see issue 131
            ViaHeader via = (ViaHeader) request.getHeader(ViaHeader.NAME);
            transport = via.getTransport();
        }

        // sipUri.removeParameter("transport");

        int port;
        if (sipUri.getPort() != -1) {
            port = sipUri.getPort();
        } else {
            if (transport.equalsIgnoreCase(SIPConstants.TLS))
                port = 5061;
            else
                port = 5060; // TCP or UDP
        }
        String host = sipUri.getMAddrParam() != null ? sipUri.getMAddrParam()
                : sipUri.getHost();
        AddressResolver addressResolver = this.sipStack.getAddressResolver();
        return addressResolver
                .resolveAddress(new HopImpl(host, port, transport));

    }

    /**
     * Get the default hop.
     *
     * @return defaultRoute is the default route. public java.util.Iterator
     *         getDefaultRoute(Request request) { return
     *         this.getNextHops((SIPRequest)request); }
     */

    public javax.sip.address.Hop getOutboundProxy() {
        return this.defaultRoute;
    }

    /*
     * (non-Javadoc)
     *
     * @see javax.sip.address.Router#getNextHop(javax.sip.message.Request)
     */
    public ListIterator getNextHops(Request request) {
        try {
            LinkedList llist = new LinkedList();
            llist.add(this.getNextHop(request));
            return llist.listIterator();
        } catch (SipException ex) {
            return null;
        }

    }
}
