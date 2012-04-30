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
package gov.nist.javax.sip.header;

import javax.sip.InvalidArgumentException;

/**
 *
 * @version 1.2 $Revision: 1.7 $ $Date: 2009/10/18 13:46:35 $
 *
 * @author M. Ranganathan   <br/>
 *
 *
 */
public class RSeq extends SIPHeader implements javax.sip.header.RSeqHeader {
    /**
     * Comment for <code>serialVersionUID</code>
     */
    private static final long serialVersionUID = 8765762413224043394L;
    protected long sequenceNumber;

    /** Creates a new instance of RSeq */
    public RSeq() {
        super(NAME);
    }

    /** Gets the sequence number of this RSeqHeader.
     * @deprecated
     * @return the integer value of the Sequence number of the RSeqHeader
     */
    public int getSequenceNumber() {
        return (int)this.sequenceNumber;
    }


    /** Encode the body of this header (the stuff that follows headerName).
     * A.K.A headerValue.
     */
    protected String encodeBody() {
        return Long.toString(this.sequenceNumber);
    }

    public long getSeqNumber() {
        return this.sequenceNumber;
    }

    public void setSeqNumber(long sequenceNumber) throws InvalidArgumentException {

            if (sequenceNumber <= 0 ||sequenceNumber > ((long)1)<<32 - 1)
                throw new InvalidArgumentException(
                    "Bad seq number " + sequenceNumber);
            this.sequenceNumber = sequenceNumber;

    }

    /**
     * @deprecated
     * @see javax.sip.header.RSeqHeader#setSequenceNumber(int)
     */
    public void setSequenceNumber(int sequenceNumber) throws InvalidArgumentException {
        this.setSeqNumber(sequenceNumber);

    }



}
