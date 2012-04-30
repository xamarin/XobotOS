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

/**
 * Accept header : The top level header is actually AcceptList which is a list of
 * Accept headers.
 *
 * @version 1.2 $Revision: 1.9 $ $Date: 2009/07/17 18:57:24 $
 *
 * @since 1.1
 *
 * @author M. Ranganathan   <br/>
 *
 *
 *
 */
public final class Accept
    extends ParametersHeader
    implements javax.sip.header.AcceptHeader {

    /**
     * Comment for <code>serialVersionUID</code>
     */
    private static final long serialVersionUID = -7866187924308658151L;

    /** mediaRange field
     */
    protected MediaRange mediaRange;

    /** default constructor
     */
    public Accept() {
        super(NAME);
    }

    /** returns true if this header allows all ContentTypes,
      * false otherwise.
      * @return Boolean
      */
    public boolean allowsAllContentTypes() {
        if (mediaRange == null)
            return false;
        else
            return mediaRange.type.compareTo(STAR) == 0;
    }

    /**
     * returns true if this header allows all ContentSubTypes,
     * false otherwise.
     * @return boolean
     */
    public boolean allowsAllContentSubTypes() {
        if (mediaRange == null) {
            return false;
        } else
            return mediaRange.getSubtype().compareTo(STAR) == 0;
    }

    /** Encode the value of this header into cannonical form.
    *@return encoded value of the header as a string.
    */
    protected String encodeBody() {
        return encodeBody(new StringBuffer()).toString();
    }

    protected StringBuffer encodeBody(StringBuffer buffer) {
        if (mediaRange != null)
            mediaRange.encode(buffer);
        if (parameters != null && !parameters.isEmpty()) {
            buffer.append(';');
            parameters.encode(buffer);
        }
        return buffer;
    }

    /** get the MediaRange field
     * @return MediaRange
     */
    public MediaRange getMediaRange() {
        return mediaRange;
    }

    /** get the contentType field
     * @return String
     */
    public String getContentType() {
        if (mediaRange == null)
            return null;
        else
            return mediaRange.getType();
    }

    /** get the ContentSubType fiels
     * @return String
     */
    public String getContentSubType() {
        if (mediaRange == null)
            return null;
        else
            return mediaRange.getSubtype();
    }

    /**
     * Get the q value.
     * @return float
     */
    public float getQValue() {
        return getParameterAsFloat(ParameterNames.Q);
    }

    /**
     * Return true if the q value has been set.
     * @return boolean
     */
    public boolean hasQValue() {
        return super.hasParameter(ParameterNames.Q);

    }

    /**
     *Remove the q value.
     */
    public void removeQValue() {
        super.removeParameter(ParameterNames.Q);
    }

    /** set the ContentSubType field
     * @param subtype String to set
     */
    public void setContentSubType(String subtype) {
        if (mediaRange == null)
            mediaRange = new MediaRange();
        mediaRange.setSubtype(subtype);
    }

    /** set the ContentType field
     * @param type String to set
     */
    public void setContentType(String type) {
        if (mediaRange == null)
            mediaRange = new MediaRange();
        mediaRange.setType(type);
    }

    /**
     * Set the q value
     * @param qValue float to set
     * @throws IllegalArgumentException if qValue is <0.0 or >1.0
     */
    public void setQValue(float qValue) throws InvalidArgumentException {
        if (qValue == -1)
            super.removeParameter(ParameterNames.Q);
        super.setParameter(ParameterNames.Q, qValue);

    }

    /**
         * Set the mediaRange member
         * @param m MediaRange field
         */
    public void setMediaRange(MediaRange m) {
        mediaRange = m;
    }

    public Object clone() {
        Accept retval = (Accept) super.clone();
        if (this.mediaRange != null)
            retval.mediaRange = (MediaRange) this.mediaRange.clone();
        return retval;
    }

}
