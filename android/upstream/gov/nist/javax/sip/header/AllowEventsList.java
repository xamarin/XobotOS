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

import java.util.*;
import java.text.ParseException;
import javax.sip.header.*;

/**
 * List of AllowEvents headers.
 * The sip message can have multiple AllowEvents headers which are strung
 * together in a list.
 *
 * @author M. Ranganathan  <br/>
 * @author Olivier Deruelle <br/>
 *
 *
 * @version 1.2 $Revision: 1.7 $ $Date: 2009/07/17 18:57:26 $
 * @since 1.1
 *
 */
public class AllowEventsList extends SIPHeaderList<AllowEvents>  {

    private static final long serialVersionUID = -684763195336212992L;

    public Object clone() {
        AllowEventsList retval = new AllowEventsList();
        retval.clonehlist(this.hlist);
        return retval;
    }


    /** default constructor
     */
    public AllowEventsList() {
        super(AllowEvents.class, AllowEventsHeader.NAME);
    }

    /**
     * Gets an Iterator of all the methods of the AllowEventsHeader. Returns an empty
     *
     * Iterator if no methods are defined in this AllowEvents Header.
     *
     *
     *
     * @return Iterator of String objects each identifing the methods of
     *
     * AllowEventsHeader.
     *
     *
     */
    public ListIterator<String> getMethods() {
        ListIterator<AllowEvents> li = super.hlist.listIterator();
        LinkedList<String>  ll = new LinkedList<String> ();
        while (li.hasNext()) {
            AllowEvents allowEvents = (AllowEvents) li.next();
            ll.add(allowEvents.getEventType());
        }
        return ll.listIterator();
    }

    /**
     * Sets the methods supported defined by this AllowEventsHeader.
     *
     *
     *
     * @param methods - the Iterator of Strings defining the methods supported
     *
     * in this AllowEventsHeader
     *
     * @throws ParseException which signals that an error has been reached
     *
     * unexpectedly while parsing the Strings defining the methods supported.
     *
     *
     */
    public void setMethods(List<String> methods) throws ParseException {
        ListIterator<String> it = methods.listIterator();
        while (it.hasNext()) {
            AllowEvents allowEvents = new AllowEvents();
            allowEvents.setEventType((String) it.next());
            this.add(allowEvents);
        }
    }
}
