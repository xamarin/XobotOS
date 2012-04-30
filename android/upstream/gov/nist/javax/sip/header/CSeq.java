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
/******************************************************************************
 * Product of NIST/ITL Advanced Networking Technologies Division (ANTD).      *
 ******************************************************************************/
package gov.nist.javax.sip.header;

import gov.nist.javax.sip.message.SIPRequest;

import javax.sip.InvalidArgumentException;
import javax.sip.header.CSeqHeader;
import java.text.ParseException;

/**
 *  CSeq SIP Header.
 *
 * @author M. Ranganathan    <br/>
 * @version 1.2 $Revision: 1.10 $ $Date: 2009/10/18 13:46:33 $
 * @since 1.1
 *
 */

public class CSeq extends SIPHeader implements javax.sip.header.CSeqHeader {

    /**
     * Comment for <code>serialVersionUID</code>
     */
    private static final long serialVersionUID = -5405798080040422910L;

    /**
     * seqno field
     */
    protected Long seqno;

    /**
     * method field
     */
    protected String method;

    /**
     * Constructor.
     */
    public CSeq() {
        super(CSEQ);
    }

    /**
     * Constructor given the sequence number and method.
     *
     * @param seqno is the sequence number to assign.
     * @param method is the method string.
     */
    public CSeq(long seqno, String method) {
        this();
        this.seqno = Long.valueOf(seqno);
        this.method = SIPRequest.getCannonicalName(method);
    }

    /**
     * Compare two cseq headers for equality.
     * @param other Object to compare against.
     * @return true if the two cseq headers are equals, false
     * otherwise.
     */
    public boolean equals(Object other) {

        if (other instanceof CSeqHeader) {
            final CSeqHeader o = (CSeqHeader) other;
            return this.getSeqNumber() == o.getSeqNumber()
                && this.getMethod().equals( o.getMethod() );
        }
        return false;
    }

    /**
     * Return canonical encoded header.
     * @return String with canonical encoded header.
     */
    public String encode() {
        return headerName + COLON + SP + encodeBody() + NEWLINE;
    }

    /**
     * Return canonical header content. (encoded header except headerName:)
     *
     * @return encoded string.
     */
    public String encodeBody() {
        return encodeBody(new StringBuffer()).toString();
    }

    protected StringBuffer encodeBody(StringBuffer buffer) {
        return buffer.append(seqno).append(SP).append(method.toUpperCase());
    }

    /**
     * Get the method.
     * @return String the method.
     */
    public String getMethod() {
        return method;
    }

    /*
     * (non-Javadoc)
     * @see javax.sip.header.CSeqHeader#setSequenceNumber(long)
     */
    public void setSeqNumber(long sequenceNumber)
        throws InvalidArgumentException {
        if (sequenceNumber < 0 )
            throw new InvalidArgumentException(
                "JAIN-SIP Exception, CSeq, setSequenceNumber(), "
                    + "the sequence number parameter is < 0 : " + sequenceNumber);
        else if ( sequenceNumber >  ((long)1)<<32 - 1)
            throw new InvalidArgumentException(
                    "JAIN-SIP Exception, CSeq, setSequenceNumber(), "
                        + "the sequence number parameter is too large : " + sequenceNumber);

        seqno = Long.valueOf(sequenceNumber);
    }

    /**
     * For backwards compatibility
     */
    public void setSequenceNumber(int sequenceNumber) throws InvalidArgumentException {
        this.setSeqNumber( (long) sequenceNumber );
    }

    /*
     * (non-Javadoc)
     * @see javax.sip.header.CSeqHeader#setMethod(java.lang.String)
     */
    public void setMethod(String meth) throws ParseException {
        if (meth == null)
            throw new NullPointerException(
                "JAIN-SIP Exception, CSeq"
                    + ", setMethod(), the meth parameter is null");
        this.method = SIPRequest.getCannonicalName(meth);
    }

    /*
     * (non-Javadoc)
     * @see javax.sip.header.CSeqHeader#getSequenceNumber()
     */
    public int getSequenceNumber() {
        if (this.seqno == null)
            return 0;
        else
            return this.seqno.intValue();
    }




    public long getSeqNumber() {
        return this.seqno.longValue();
    }


}

