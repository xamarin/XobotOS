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
package gov.nist.core.net;

import java.net.InetAddress;
import java.net.UnknownHostException;

import javax.sip.address.Hop;

/**
 * An interface that allows you to customize address lookup.
 * The user can implement this interface to do DNS lookups or other lookup
 * schemes and register it with the stack.
 * The default implementation of the address resolver does nothing more than just return back
 * the Hop that it was passed (fixing up the port if necessary).
 * However, this behavior can be overriden. To override
 * implement this interface and register it with the stack using
 * {@link gov.nist.javax.sip.SipStackExt#setAddressResolver(AddressResolver)}.
 * This interface will be incorporated into version 2.0 of the JAIN-SIP Specification.
 *
 * @since 2.0
 *
 *
 * @author M. Ranganathan
 *
 */
public interface AddressResolver {

    /**
     * Do a name lookup and resolve the given IP address.
     * The default implementation is just an identity mapping
     * (returns the argument).
     *
     * @param hop - an incoming Hop containing a potenitally unresolved address.
     * @return a new hop ( if the address is recomputed ) or the original hop
     * if this is just an identity mapping ( the default behavior ).
     */
    public Hop resolveAddress( Hop hop);





}
