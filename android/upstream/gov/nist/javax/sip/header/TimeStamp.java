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
import javax.sip.header.*;

/**
 * TimeStamp SIP Header.
 *
 * @version 1.2 $Revision: 1.7 $ $Date: 2009/10/18 13:46:31 $
 *
 * @author M. Ranganathan <br/>
 * @author Olivier Deruelle <br/>
 *
 *
 *
 */
public class TimeStamp extends SIPHeader implements TimeStampHeader {

    /**
     * Comment for <code>serialVersionUID</code>
     */
    private static final long serialVersionUID = -3711322366481232720L;

    /**
     * timeStamp field
     */
    protected long timeStamp = -1;

    /**
     * delay field
     */
    protected int delay = -1;

    protected float delayFloat = -1;

    private float timeStampFloat = -1;

    /**
     * Default Constructor
     */
    public TimeStamp() {
        super(TIMESTAMP);
        delay = -1;
    }

    private String getTimeStampAsString() {
        if (timeStamp == -1 && timeStampFloat == -1)
            return "";
        else if (timeStamp != -1)
            return Long.toString(timeStamp);
        else
            return Float.toString(timeStampFloat);
    }

    private String getDelayAsString() {
        if (delay == -1 && delayFloat == -1)
            return "";
        else if (delay != -1)
            return Integer.toString(delay);
        else
            return Float.toString(delayFloat);
    }

    /**
     * Return canonical form of the header.
     *
     * @return String
     */
    public String encodeBody() {
        StringBuffer retval = new StringBuffer();
        String s1 = getTimeStampAsString();
        String s2 = getDelayAsString();
        if (s1.equals("") && s2.equals(""))
            return "";
        if (!s1.equals(""))
            retval.append(s1);
        if (!s2.equals(""))
            retval.append(" ").append(s2);
        return retval.toString();

    }

    /**
     * return true if delay exists
     *
     * @return boolean
     */
    public boolean hasDelay() {
        return delay != -1;
    }

    /*
     * remove the Delay field
     */
    public void removeDelay() {
        delay = -1;
    }



    public void setTimeStamp(float timeStamp) throws InvalidArgumentException {
        if (timeStamp < 0)
            throw new InvalidArgumentException(
                    "JAIN-SIP Exception, TimeStamp, "
                            + "setTimeStamp(), the timeStamp parameter is <0");
        this.timeStamp = -1;
        this.timeStampFloat = timeStamp;
    }


    public float getTimeStamp() {
        return this.timeStampFloat == -1 ? Float.valueOf(timeStamp).floatValue()
                : this.timeStampFloat;
    }



    public float getDelay() {
        return delayFloat == -1 ? Float.valueOf(delay).floatValue() : delayFloat;
    }

    /**
     * Sets the new delay value of the TimestampHeader to the delay paramter
     * passed to this method
     *
     * @param delay -
     *            the Float.valueOf delay value
     * @throws InvalidArgumentException
     *             if the delay value argumenmt is a negative value other than
     *             <code>-1</code>.
     */

    public void setDelay(float delay) throws InvalidArgumentException {
        if (delay < 0 && delay != -1)
            throw new InvalidArgumentException(
                    "JAIN-SIP Exception, TimeStamp, "
                            + "setDelay(), the delay parameter is <0");
        this.delayFloat = delay;
        this.delay = -1;
    }

    public long getTime() {
        return this.timeStamp == -1 ? (long) timeStampFloat : timeStamp;
    }

    public int getTimeDelay() {
        return this.delay == -1 ? (int) delayFloat : delay;

    }

    public void setTime(long timeStamp) throws InvalidArgumentException {
        if (timeStamp < -1)
            throw new InvalidArgumentException("Illegal timestamp");
        this.timeStamp = timeStamp;
        this.timeStampFloat = -1;

    }

    public void setTimeDelay(int delay) throws InvalidArgumentException {
        if (delay < -1)
            throw new InvalidArgumentException("Value out of range " + delay);
        this.delay = delay;
        this.delayFloat = -1;

    }

}
