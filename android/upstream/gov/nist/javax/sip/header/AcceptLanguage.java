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
 /****************************************************************************
 * Product of NIST/ITL Advanced Networking Technologies Division (ANTD).    *
 ****************************************************************************/
package gov.nist.javax.sip.header;
import gov.nist.core.*;
import javax.sip.header.AcceptLanguageHeader;
import javax.sip.InvalidArgumentException;
import java.util.Locale;

/**
 * Accept Language body.
 *
 * @author M. Ranganathan
 * @version 1.2 $Revision: 1.8 $ $Date: 2009/10/18 13:46:32 $
 * @since 1.1
 *
 *
 * <pre>
 * HTTP RFC 2616 Section 14.4
 * Accept-Language = "Accept-Language" ":"
 *                         1#( language-range [ ";" "q" "=" qvalue ] )
 *       language-range  = ( ( 1*8ALPHA *( "-" 1*8ALPHA ) ) | "*" )
 *
 * </pre>
 *
 * @see AcceptLanguageList
 */
public final class AcceptLanguage
    extends ParametersHeader
    implements AcceptLanguageHeader {

    /**
     * Comment for <code>serialVersionUID</code>
     */
    private static final long serialVersionUID = -4473982069737324919L;
    /** languageRange field
     */
    protected String languageRange;

    /** default constructor
     */
    public AcceptLanguage() {
        super(NAME);
    }

    /** Encode the value of this header to a string.
     *@return  encoded header as a string.
     */
    protected String encodeBody() {
        StringBuffer encoding = new StringBuffer();
        if (languageRange != null) {
            encoding.append(languageRange);
        }
        if (!parameters.isEmpty()) {
            encoding.append(SEMICOLON).append(parameters.encode());
        }
        return encoding.toString();
    }

    /** get the LanguageRange field
     * @return String
     */
    public String getLanguageRange() {
        return languageRange;
    }

    /** get the QValue field. Return -1 if the parameter has not been
     * set.
     * @return float
     */

    public float getQValue() {
        if (!hasParameter("q"))
            return -1;
        return ((Float) parameters.getValue("q")).floatValue();
    }

    /**
     * Return true if the q value has been set.
     * @since 1.0
     * @return boolean
     */
    public boolean hasQValue() {
        return hasParameter("q");
    }

    /**
     * Remove the q value.
     * @since 1.0
     */
    public void removeQValue() {
        removeParameter("q");
    }

    /**
     * Set the languageRange.
     *
     * @param languageRange is the language range to set.
     *
     */
    public void setLanguageRange(String languageRange) {
        this.languageRange = languageRange.trim();
    }

    /**
     * Sets q-value for media-range in AcceptLanguageHeader. Q-values allow the
     *
     * user to indicate the relative degree of preference for that media-range,
     *
     * using the qvalue scale from 0 to 1. If no q-value is present, the
     *
     * media-range should be treated as having a q-value of 1.
     *
     *
     *
     * @param q The new float value of the q-value, a value of -1 resets
     * the qValue.
     *
     * @throws InvalidArgumentException if the q parameter value is not
     *
     * <code>-1</code> or between <code>0 and 1</code>.
     *
     */
    public void setQValue(float q) throws InvalidArgumentException {
        if (q < 0.0 || q > 1.0)
            throw new InvalidArgumentException("qvalue out of range!");
        if (q == -1)
            this.removeParameter("q");
        else
            this.setParameter(new NameValue("q", Float.valueOf(q)));
    }

    /**
     * Gets the language value of the AcceptLanguageHeader.
     *
     *
     *
     * @return the language Locale value of this AcceptLanguageHeader
     *
     */
    public Locale getAcceptLanguage() {
        if (this.languageRange == null)
            return null;
        else {
            int dash = languageRange.indexOf('-');
            if (dash>=0) {
                return new Locale( languageRange.substring(0,dash), languageRange.substring(dash+1) );
            } else return new Locale( this.languageRange );
        }
    }

    /**
     * Sets the language parameter of this AcceptLanguageHeader.
     *
     *
     *
     * @param language - the new Locale value of the language of
     *
     * AcceptLanguageHeader
     *
     *
     */
    public void setAcceptLanguage(Locale language) {
        // JvB: need to take sub-tag into account
        if ( "".equals(language.getCountry())) {
            this.languageRange = language.getLanguage();
        } else {
            this.languageRange = language.getLanguage() + '-' + language.getCountry();
        }
    }

}
