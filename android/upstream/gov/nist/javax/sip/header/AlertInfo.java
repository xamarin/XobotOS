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
* of the terms of this agreement.
*
*/
/*******************************************************************************
* Product of NIST/ITL Advanced Networking Technologies Division (ANTD)         *
*******************************************************************************/
package gov.nist.javax.sip.header;

import java.text.ParseException;

import gov.nist.javax.sip.address.*;
import javax.sip.address.*;

/**
 * AlertInfo SIP Header.
 *
 * @author M. Ranganathan   <br/>
 *
 * @since 1.1
 *
 * @version 1.2 $Revision: 1.8 $ $Date: 2009/07/17 18:57:25 $
 *
 *
 */
public final class AlertInfo
    extends ParametersHeader
    implements javax.sip.header.AlertInfoHeader {

    /**
     * Comment for <code>serialVersionUID</code>
     */
    private static final long serialVersionUID = 4159657362051508719L;
    /** URI field
     */
    protected GenericURI uri;
    /** String field
     */
    protected String string;

    /** Constructor
     */
    public AlertInfo() {
        super(NAME);
    }

    /**
     * Return value encoding in canonical form.
     * @return The value of the header in canonical encoding.
     */
    protected String encodeBody() {
        StringBuffer encoding = new StringBuffer();
        if (uri != null) {
            encoding.append(LESS_THAN).append(uri.encode()).append(GREATER_THAN);
        } else if (string != null) {
            encoding.append(string);
        }
        if (!parameters.isEmpty()) {
            encoding.append(SEMICOLON).append(parameters.encode());
        }
        return encoding.toString();
    }

    /**
     * Set the uri member
     * @param uri URI to set
     */
    public void setAlertInfo(URI uri) {
        this.uri = (GenericURI) uri;
    }

    /**
     * Set the string member
     * @param string String to set
     */
    public void setAlertInfo(String string) {
        this.string = string;
    }

    /**
     * Returns the AlertInfo value of this AlertInfoHeader.
     * @return the URI representing the AlertInfo.
     */
    public URI getAlertInfo() {
        URI alertInfoUri = null;

        if (this.uri != null) {
            alertInfoUri = (URI) this.uri;
        } else {
            try {
                alertInfoUri = (URI) new GenericURI(string);
            } catch (ParseException e) {
                ;  // Eat the exception.
            }
        }

        return alertInfoUri;
    }

    public Object clone() {
        AlertInfo retval = (AlertInfo) super.clone();
        if (this.uri != null) {
            retval.uri = (GenericURI) this.uri.clone();
        } else if (this.string != null) {
            retval.string = this.string;
        }
        return retval;
    }
}
