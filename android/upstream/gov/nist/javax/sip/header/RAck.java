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

import javax.sip.InvalidArgumentException;
import java.text.ParseException;

/**
 * RAck SIP Header implementation
 *
 * @version 1.2 $Revision: 1.7 $ $Date: 2009/07/17 18:57:34 $
 *
 * @author M. Ranganathan <br/>
 *
 *
 */
public class RAck extends SIPHeader implements javax.sip.header.RAckHeader {

    /**
     * Comment for <code>serialVersionUID</code>
     */
    private static final long serialVersionUID = 743999286077404118L;

    protected long cSeqNumber;

    protected long rSeqNumber;

    protected String method;

    /** Creates a new instance of RAck */
    public RAck() {
        super(NAME);
    }

    /**
     * Encode the body of this header (the stuff that follows headerName). A.K.A
     * headerValue.
     *
     */
    protected String encodeBody() {
        // Bug reported by Bruno Konik - was encoded in
        // the wrong order.
        return new StringBuffer().append(rSeqNumber).append(SP).append(
                cSeqNumber).append(SP).append(method).toString();

    }

    /**
     * Gets the CSeq sequence number of this RAckHeader.
     *
     * @deprecated
     * @return the integer value of the cSeq number of the RAckHeader
     */
    public int getCSeqNumber() {
        return (int) cSeqNumber;
    }

    /**
     * Gets the CSeq sequence number of this RAckHeader.
     *
     * @return the integer value of the cSeq number of the RAckHeader
     */
    public long getCSeqNumberLong() {
        return cSeqNumber;
    }

    /**
     * Gets the method of RAckHeader
     *
     * @return method of RAckHeader
     */
    public String getMethod() {
        return this.method;
    }

    /**
     * Gets the RSeq sequence number of this RAckHeader.
     *
     * @deprecated
     * @return the integer value of the RSeq number of the RAckHeader
     */
    public int getRSeqNumber() {
        return (int) rSeqNumber;
    }

    /**
     * @deprecated
     * @see javax.sip.header.RAckHeader#setCSeqNumber(int)
     */
    public void setCSeqNumber(int cSeqNumber) throws InvalidArgumentException {
        this.setCSequenceNumber(cSeqNumber);
    }

    public void setMethod(String method) throws ParseException {
        this.method = method;
    }


    public long getCSequenceNumber() {
        return this.cSeqNumber;
    }

    public long getRSequenceNumber() {
        return this.rSeqNumber;
    }

    public void setCSequenceNumber(long cSeqNumber)
            throws InvalidArgumentException {
        if (cSeqNumber <= 0 || cSeqNumber > ((long) 1) << 32 - 1)
            throw new InvalidArgumentException("Bad CSeq # " + cSeqNumber);
        this.cSeqNumber = cSeqNumber;

    }

    /**
     *@deprecated
     * @see javax.sip.header.RAckHeader#setRSeqNumber(int)
     */
    public void setRSeqNumber(int rSeqNumber) throws InvalidArgumentException {
        this.setRSequenceNumber(rSeqNumber);
    }


    public void setRSequenceNumber(long rSeqNumber)
            throws InvalidArgumentException {
        if (rSeqNumber <= 0 || cSeqNumber > ((long) 1) << 32 - 1)
            throw new InvalidArgumentException("Bad rSeq # " + rSeqNumber);
        this.rSeqNumber = rSeqNumber;
    }
}
