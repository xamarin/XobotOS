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
import javax.sip.InvalidArgumentException;

/**
 * MaxForwards SIPHeader
 *
 * @version 1.2 $Revision: 1.8 $ $Date: 2009/07/17 18:57:32 $
 *
 * @author M. Ranganathan   <br/>
 * @author Olivier Deruelle <br/>
 *
 */
public class MaxForwards extends SIPHeader implements MaxForwardsHeader {

    /**
     * Comment for <code>serialVersionUID</code>
     */
    private static final long serialVersionUID = -3096874323347175943L;
    /** maxForwards field.
     */
    protected int maxForwards;

    /** Default constructor.
     */
    public MaxForwards() {
        super(NAME);
    }

  public MaxForwards( int m ) throws InvalidArgumentException {
        super(NAME);
        this.setMaxForwards( m );
    }

    /** get the MaxForwards field.
     * @return the maxForwards member.
     */
    public int getMaxForwards() {
        return maxForwards;
    }

    /**
         * Set the maxForwards member
         * @param maxForwards maxForwards parameter to set
         */
    public void setMaxForwards(int maxForwards)
        throws InvalidArgumentException {
        if (maxForwards < 0 || maxForwards > 255)
            throw new InvalidArgumentException(
                "bad max forwards value " + maxForwards);
        this.maxForwards = maxForwards;
    }

    /**
         * Encode into a string.
         * @return encoded string.
         *
         */
    public String encodeBody() {
        return encodeBody(new StringBuffer()).toString();
    }

    protected StringBuffer encodeBody(StringBuffer buffer) {
        return buffer.append(maxForwards);
    }

    /** Boolean function
     * @return true if MaxForwards field reached zero.
     */
    public boolean hasReachedZero() {
        return maxForwards == 0;
    }

    /** decrement MaxForwards field one by one.
     */
    public void decrementMaxForwards() throws TooManyHopsException {
        if (maxForwards > 0)
            maxForwards--;
        else throw new TooManyHopsException ("has already reached 0!");
    }

    public boolean equals(Object other) {
        if (this==other) return true;
        if (other instanceof MaxForwardsHeader) {
            final MaxForwardsHeader o = (MaxForwardsHeader) other;
            return this.getMaxForwards() == o.getMaxForwards();
        }
        return false;
    }
}
