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
import java.util.*;

/**
 * A list of Route Headers.
 *
 * @version 1.2 $Revision: 1.8 $ $Date: 2009/07/17 18:57:36 $
 *
 * @author M. Ranganathan   <br/>
 *
 *
 *
 */
public class RouteList extends SIPHeaderList<Route> {

    private static final long serialVersionUID = 3407603519354809748L;


    /** default constructor
     */
    public RouteList() {
        super(Route.class, RouteHeader.NAME);

    }

    public Object clone() {
        RouteList retval = new RouteList();
        retval.clonehlist(this.hlist);
        return retval;
    }

    public String encode() {
        if ( super.hlist.isEmpty()) return "";
        else return super.encode();
    }


    /**
    * Order is important when comparing route lists.
    */
    public boolean equals(Object other) {
        if (!(other instanceof RouteList))
            return false;
        RouteList that = (RouteList) other;
        if (this.size() != that.size())
            return false;
        ListIterator<Route> it = this.listIterator();
        ListIterator<Route> it1 = that.listIterator();
        while (it.hasNext()) {
            Route route = (Route) it.next();
            Route route1 = (Route) it1.next();
            if (!route.equals(route1))
                return false;
        }
        return true;
    }


}
