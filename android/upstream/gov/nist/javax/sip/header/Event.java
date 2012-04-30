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
* Event SIP Header.
*
*@version 1.2 $Revision: 1.7 $ $Date: 2007/06/28 15:08:42 $
*@since 1.1
*
*@author M. Ranganathan   <br/>
*@author Olivier Deruelle <br/>
*
*
*/
public class Event extends ParametersHeader implements EventHeader {

    /**
     * Comment for <code>serialVersionUID</code>
     */
    private static final long serialVersionUID = -6458387810431874841L;

    protected String eventType;

    /**
     * Creates a new instance of Event
     */
    public Event() {
        super(EVENT);
    }

    /**
    * Sets the eventType to the newly supplied eventType string.
    *
    * @param eventType - the  new string defining the eventType supported
    * in this EventHeader
    * @throws ParseException which signals that an error has been reached
    * unexpectedly while parsing the eventType value.
    */
    public void setEventType(String eventType) throws ParseException {
        if (eventType == null)
            throw new NullPointerException(" the eventType is null");
        this.eventType = eventType;
    }

    /**
     * Gets the eventType of the EventHeader.
     *
     * @return the string object identifing the eventType of EventHeader.
     */
    public String getEventType() {
        return eventType;
    }

    /**
     * Sets the id to the newly supplied <var>eventId</var> string.
     *
     * @param eventId - the new string defining the eventId of this EventHeader
     * @throws ParseException which signals that an error has been reached
     * unexpectedly while parsing the eventId value.
     */
    public void setEventId(String eventId) throws ParseException {
        if (eventId == null)
            throw new NullPointerException(" the eventId parameter is null");
        setParameter(ParameterNames.ID, eventId);
    }

    /**
     * Gets the id of the EventHeader. This method may return null if the
     * "eventId" is not set.
     * @return the string object identifing the eventId of EventHeader.
     */
    public String getEventId() {
        return getParameter(ParameterNames.ID);
    }

    /**
     * Encode in canonical form.
     * @return String
     */
    public String encodeBody() {
        return encodeBody(new StringBuffer()).toString();
    }

    protected StringBuffer encodeBody(StringBuffer buffer) {
        if (eventType != null)
            buffer.append(eventType);

        if (!parameters.isEmpty()) {
            buffer.append(SEMICOLON);
            this.parameters.encode(buffer);
        }
        return buffer;
    }

    /**
     *  Return true if the given event header matches the supplied one.
     *
     * @param matchTarget -- event header to match against.
     */
    public boolean match(Event matchTarget) {
        if (matchTarget.eventType == null && this.eventType != null)
            return false;
        else if (matchTarget.eventType != null && this.eventType == null)
            return false;
        else if (this.eventType == null && matchTarget.eventType == null)
            return false;
        else if (getEventId() == null && matchTarget.getEventId() != null)
            return false;
        else if (getEventId() != null && matchTarget.getEventId() == null)
            return false;
        return matchTarget.eventType.equalsIgnoreCase(this.eventType)
            && ((this.getEventId() == matchTarget.getEventId())
                || this.getEventId().equalsIgnoreCase(matchTarget.getEventId()));
    }
}
