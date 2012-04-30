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

import gov.nist.javax.sip.header.*;
import java.text.ParseException;

/**
 * Duplicate header exception:  thrown when there is more
 * than one header of a type where there should only be one.
 * The exception handler may choose to :
 * 1. discard the duplicate  by returning null
 * 2. keep the duplicate by just returning it.
 * 3. Discard the entire message by throwing an exception.
 * @version 1.2 $Revision: 1.6 $ $Date: 2009/07/17 18:57:54 $
 * @since 1.1
 * @author M. Ranganathan
 */
public class SIPDuplicateHeaderException extends ParseException {

    private static final long serialVersionUID = 8241107266407879291L;
    protected SIPHeader sipHeader;
    protected SIPMessage sipMessage;
    public SIPDuplicateHeaderException(String msg) {
        super(msg, 0);
    }
    public SIPMessage getSIPMessage() {
        return sipMessage;
    }

    public SIPHeader getSIPHeader() {
        return sipHeader;
    }

    public void setSIPHeader(SIPHeader sipHeader) {
        this.sipHeader = sipHeader;
    }

    public void setSIPMessage(SIPMessage sipMessage) {
        this.sipMessage = sipMessage;
    }
}
