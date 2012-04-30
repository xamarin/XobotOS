/*
 * JBoss, Home of Professional Open Source
 * This code has been contributed to the public domain by the author.
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
 * of the terms of this agreement.
 */
package gov.nist.javax.sip.header;

import javax.sip.header.Header;

/**
 * Extensions to the Header interface supported by the implementation and 
 * will be included in the next spec release.
 * 
 * @author jean.deruelle@gmail.com
 *
 */
public interface HeaderExt extends  Header {

    /**
     * Gets the header value (i.e. what follows the name:) as a string
     * @return the header value (i.e. what follows the name:)
     * @since 2.0
     */
    public String getValue();
}
