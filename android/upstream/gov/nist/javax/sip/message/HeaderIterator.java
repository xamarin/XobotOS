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
package gov.nist.javax.sip.message;

import gov.nist.javax.sip.header.*;
import java.util.ListIterator;
import java.util.NoSuchElementException;

/**
 * Iterator over lists of headers. Allows for uniform removal handling for singleton headers.
 * @author M. Ranganathan
 * @version 1.2 $Revision: 1.8 $ $Date: 2009/07/17 18:57:53 $
 * @since 1.1
 */
public class HeaderIterator implements ListIterator {
    private boolean toRemove;
    private int index;
    private SIPMessage sipMessage;
    private SIPHeader sipHeader;

    protected HeaderIterator(SIPMessage sipMessage, SIPHeader sipHeader) {
        this.sipMessage = sipMessage;
        this.sipHeader = sipHeader;
    }

    public Object next() throws NoSuchElementException {
        if (sipHeader == null || index == 1)
            throw new NoSuchElementException();
        toRemove = true;
        index = 1;
        return (Object) sipHeader;
    }

    public Object previous() throws NoSuchElementException {
        if (sipHeader == null || index == 0)
            throw new NoSuchElementException();
        toRemove = true;
        index = 0;
        return (Object) sipHeader;
    }

    public int nextIndex() {
        return 1;
    }

    public int previousIndex() {
        return index == 0 ? -1 : 0;
    }

    public void set(Object header) {
        throw new UnsupportedOperationException();
    }

    public void add(Object header) {
        throw new UnsupportedOperationException();
    }

    public void remove() throws IllegalStateException {
        if (this.sipHeader == null)
            throw new IllegalStateException();
        if (toRemove) {
            this.sipHeader = null;
            this.sipMessage.removeHeader(sipHeader.getName());
        } else {
            throw new IllegalStateException();
        }
    }

    public boolean hasNext() {
        return index == 0;
    }

    public boolean hasPrevious() {
        return index == 1;
    }
}
