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
package gov.nist.javax.sip.address;
import gov.nist.core.*;
import java.util.ListIterator;
import java.util.LinkedList;
import java.util.Iterator;
import java.lang.reflect.*;

/**
* Root class for all the collection objects in this list:
* a wrapper class on the GenericObjectList class for lists of objects
* that can appear in NetObjects.
* IMPORTANT NOTE: NetObjectList cannot derive from NetObject as this
* will screw up the way in which we attach objects to headers.
*
*@version 1.2 $Revision: 1.8 $ $Date: 2009/07/17 18:57:22 $
*
*@author M. Ranganathan   <br/>
*
*
*
*/
public class NetObjectList extends GenericObjectList {


    /**
     *
     */
    private static final long serialVersionUID = -1551780600806959023L;

    /**
     * Construct a NetObject List given a list name.
     * @param lname String to set
     */
    public NetObjectList(String lname) {
        super(lname);
    }

    /**
     * Construct a NetObject List given a list name and a class for
     * the objects that go into the list.
     * @param lname String to set
     * @param cname Class to set
     */
    public NetObjectList(String lname, Class<?> cname) {
        super(lname, cname);
    }



    /**
     * Construct an empty NetObjectList.
     */
    public NetObjectList() {
        super();
    }

    /**
     * Add a new object to the list.
     * @param obj NetObject to set
     */
    public void add(NetObject obj) {
        super.add(obj);
    }

    /** concatenate the two Lists
     * @param net_obj_list NetObjectList to set
     */
    public void concatenate(NetObjectList net_obj_list) {
        super.concatenate(net_obj_list);
    }



    /** returns the first element
     * @return GenericObject
     */
    public GenericObject first() {
        return (NetObject) super.first();
    }



    /** returns the next element
     * @return GenericObject
     */
    public GenericObject next() {
        return (NetObject) super.next();
    }

    /** returns the next element
     * @param li ListIterator to set
     * @return GenericObject
     */
    public GenericObject next(ListIterator li) {
        return (NetObject) super.next(li);
    }



    /** set the class
     * @param cl Class to set
     */
    public void setMyClass(Class cl) {
        super.setMyClass(cl);
    }

    /**
     * Convert to a string given an indentation(for pretty printing).
     * @param indent int to set
     * @return String
     */
    public String debugDump(int indent) {
        return super.debugDump(indent);
    }

    /**
    * Encode this to a string.
    *
    *@return a string representation for this object.
    */
    public String toString() {
        return this.encode();
    }
}
