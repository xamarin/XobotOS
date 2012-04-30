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
package gov.nist.javax.sip.header;

import javax.sip.header.*;
import java.text.ParseException;

/**
 * InReplyTo SIP Header.
 *
 * @version 1.2 $Revision: 1.6 $ $Date: 2009/07/17 18:57:31 $
 *
 * @author M. Ranganathan   <br/>
 * @author Olivier Deruelle <br/>
 *
 *
 */
public class InReplyTo extends SIPHeader implements InReplyToHeader {

    /**
     * Comment for <code>serialVersionUID</code>
     */
    private static final long serialVersionUID = 1682602905733508890L;

    protected CallIdentifier callId;

    /** Default constructor
     */
    public InReplyTo() {
        super(IN_REPLY_TO);
    }

    /** constructor
     * @param cid CallIdentifier to set
     */
    public InReplyTo(CallIdentifier cid) {
        super(IN_REPLY_TO);
        callId = cid;
    }

    /**
     * Sets the Call-Id of the InReplyToHeader. The CallId parameter uniquely
     * identifies a serious of messages within a dialogue.
     *
     * @param callId - the string value of the Call-Id of this InReplyToHeader.
     * @throws ParseException which signals that an error has been reached
     * unexpectedly while parsing the callId value.
     */
    public void setCallId(String callId) throws ParseException {
        try {
            this.callId = new CallIdentifier(callId);
        } catch (Exception e) {
            throw new ParseException(e.getMessage(), 0);
        }
    }

    /**
     * Returns the Call-Id of InReplyToHeader. The CallId parameter uniquely
     * identifies a series of messages within a dialogue.
     *
     * @return the String value of the Call-Id of this InReplyToHeader
     */
    public String getCallId() {
        if (callId == null)
            return null;
        return callId.encode();
    }

    /**
         * Generate canonical form of the header.
         * @return String
         */
    public String encodeBody() {
        return callId.encode();
    }

    public Object clone() {
        InReplyTo retval = (InReplyTo) super.clone();
        if (this.callId != null)
            retval.callId = (CallIdentifier) this.callId.clone();
        return retval;
    }
}

