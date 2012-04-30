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
package gov.nist.javax.sip;

import java.net.InetAddress;
import java.net.UnknownHostException;

import javax.sip.address.Hop;

import gov.nist.core.net.AddressResolver;
import gov.nist.javax.sip.stack.HopImpl;
import gov.nist.javax.sip.stack.MessageProcessor;

/**
 * This is the default implementation of the AddressResolver. The AddressResolver is a NIST-SIP specific
 * feature. The address resolover is consulted to convert a Hop into a meaningful address. The default
 * implementation is a passthrough. It only gets involved in setting the default port. However, you
 * can register your own AddressResolver implementation
 * Note that
 * The RI checks incoming via headers for resolving the sentBy field. If you want to set it to
 * some address that cannot be resolved you should register an AddressResolver with the stack.
 * This feature is also useful for DNS SRV lookup which is not implemented by the RI at present.
 *
 * @version 1.2
 * @since 1.2
 * @see gov.nist.javax.sip.SipStackImpl#setAddressResolver(AddressResolver)
 *
 * @author M. Ranganathan
 *
 */
public class DefaultAddressResolver implements AddressResolver {

    public DefaultAddressResolver() {

    }
    /*
     * (non-Javadoc)
     * @see gov.nist.core.net.AddressResolver#resolveAddress(javax.sip.address.Hop)
     */
    public Hop resolveAddress(Hop inputAddress) {
        if  (inputAddress.getPort()  != -1)
            return inputAddress;
        else {
            return new HopImpl(inputAddress.getHost(),
                    MessageProcessor.getDefaultPort(inputAddress.getTransport()),inputAddress.getTransport());
        }
    }



}
