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
package gov.nist.core;

import java.util.*;
import java.io.Serializable;

/**
 * Implements a homogenous consistent linked list. All the objects in the linked
 * list must derive from the same root class. This is a useful constraint to
 * place on our code as this property is invariant.The list is created with the
 * superclass which can be specified as either a class name or a Class.
 *
 * @version 1.2
 *
 * @author M. Ranganathan <br/>
 *
 *
 *
 */
public abstract class GenericObjectList extends LinkedList<GenericObject> implements
        Serializable, Cloneable{
    // Useful constants.
    protected static final String SEMICOLON = Separators.SEMICOLON;

    protected static final String COLON = Separators.COLON;

    protected static final String COMMA = Separators.COMMA;

    protected static final String SLASH = Separators.SLASH;

    protected static final String SP = Separators.SP;

    protected static final String EQUALS = Separators.EQUALS;

    protected static final String STAR = Separators.STAR;

    protected static final String NEWLINE = Separators.NEWLINE;

    protected static final String RETURN = Separators.RETURN;

    protected static final String LESS_THAN = Separators.LESS_THAN;

    protected static final String GREATER_THAN = Separators.GREATER_THAN;

    protected static final String AT = Separators.AT;

    protected static final String DOT = Separators.DOT;

    protected static final String QUESTION = Separators.QUESTION;

    protected static final String POUND = Separators.POUND;

    protected static final String AND = Separators.AND;

    protected static final String LPAREN = Separators.LPAREN;

    protected static final String RPAREN = Separators.RPAREN;

    protected static final String DOUBLE_QUOTE = Separators.DOUBLE_QUOTE;

    protected static final String QUOTE = Separators.QUOTE;

    protected static final String HT = Separators.HT;

    protected static final String PERCENT = Separators.PERCENT;

    protected int indentation;

    protected String listName; // For debugging

    private ListIterator<? extends GenericObject> myListIterator;

    private String stringRep;

    protected Class<?> myClass;

    protected String separator;

    protected String getIndentation() {
        char[] chars = new char[indentation];
        java.util.Arrays.fill(chars, ' ');
        return new String(chars);
    }

    /**
     * Return true if this supports reflection based cloning.
     */
    protected static boolean isCloneable(Object obj) {
        return obj instanceof Cloneable;
    }

    public static boolean isMySubclass(Class<?> other) {
        return GenericObjectList.class.isAssignableFrom(other);

    }

    /**
     * Makes a deep clone of this list.
     */
    public Object clone() {
        GenericObjectList retval = (GenericObjectList) super.clone();
        for (ListIterator<GenericObject> iter = retval.listIterator(); iter.hasNext();) {
            GenericObject obj = (GenericObject) ((GenericObject) iter.next())
                    .clone();
            iter.set(obj);
        }
        return retval;
    }



    public void setMyClass(Class cl) {
        myClass = cl;
    }

    protected GenericObjectList() {
        super();
        listName = null;
        stringRep = "";
        separator = ";";
    }

    protected GenericObjectList(String lname) {
        this();
        listName = lname;
    }

    /**
     * A Constructor which takes a list name and a class name (for assertion
     * checking).
     */

    protected GenericObjectList(String lname, String classname) {
        this(lname);
        try {
            myClass = Class.forName(classname);
        } catch (ClassNotFoundException ex) {
            InternalErrorHandler.handleException(ex);
        }

    }

    /**
     * A Constructor which takes a list name and a class (for assertion
     * checking).
     */

    protected GenericObjectList(String lname, Class objclass) {
        this(lname);
        myClass = objclass;
    }

    /**
     * Traverse the list given a list iterator
     */
    protected GenericObject next(ListIterator iterator) {
        try {
            return (GenericObject) iterator.next();
        } catch (NoSuchElementException ex) {
            return null;
        }
    }

    /**
     * This is the default list iterator.This will not handle nested list
     * traversal.
     */
    protected GenericObject first() {
        myListIterator = this.listIterator(0);
        try {
            return (GenericObject) myListIterator.next();
        } catch (NoSuchElementException ex) {
            return null;
        }
    }

    /**
     * Fetch the next object from the list based on the default list iterator
     */
    protected GenericObject next() {
        if (myListIterator == null) {
            myListIterator = this.listIterator(0);
        }
        try {
            return (GenericObject) myListIterator.next();
        } catch (NoSuchElementException ex) {
            myListIterator = null;
            return null;
        }
    }

    /**
     * Concatenate two compatible header lists, adding the argument to the tail
     * end of this list.
     *
     * @param <var>
     *            topFlag </var> set to true to add items to top of list
     */
    protected void concatenate(GenericObjectList objList) {
        concatenate(objList, false);
    }

    /**
     * Concatenate two compatible header lists, adding the argument either to
     * the beginning or the tail end of this list. A type check is done before
     * concatenation.
     *
     * @param <var>
     *            topFlag </var> set to true to add items to top of list else
     *            add them to the tail end of the list.
     */
    protected void concatenate(GenericObjectList objList, boolean topFlag) {
        if (!topFlag) {
            this.addAll(objList);
        } else {
            // add given items to the top end of the list.
            this.addAll(0, objList);
        }
    }

    /**
     * string formatting function.
     */

    private void sprint(String s) {
        if (s == null) {
            stringRep += getIndentation();
            stringRep += "<null>\n";
            return;
        }

        if (s.compareTo("}") == 0 || s.compareTo("]") == 0) {
            indentation--;
        }
        stringRep += getIndentation();
        stringRep += s;
        stringRep += "\n";
        if (s.compareTo("{") == 0 || s.compareTo("[") == 0) {
            indentation++;
        }
    }

    /**
     * Convert this list of headers to a formatted string.
     */

    public String debugDump() {
        stringRep = "";
        Object obj = this.first();
        if (obj == null)
            return "<null>";
        sprint("listName:");
        sprint(listName);
        sprint("{");
        while (obj != null) {
            sprint("[");
            sprint(((GenericObject) obj).debugDump(this.indentation));
            obj = next();
            sprint("]");
        }
        sprint("}");
        return stringRep;
    }

    /**
     * Convert this list of headers to a string (for printing) with an
     * indentation given.
     */

    public String debugDump(int indent) {
        int save = indentation;
        indentation = indent;
        String retval = this.debugDump();
        indentation = save;
        return retval;
    }

    public void addFirst(GenericObject objToAdd) {
        if (myClass == null) {
            myClass = objToAdd.getClass();
        } else {
            super.addFirst(objToAdd);
        }
    }

    /**
     * Do a merge of the GenericObjects contained in this list with the
     * GenericObjects in the mergeList. Note that this does an inplace
     * modification of the given list. This does an object by object merge of
     * the given objects.
     *
     * @param mergeList
     *            is the list of Generic objects that we want to do an object by
     *            object merge with. Note that no new objects are added to this
     *            list.
     *
     */

    public void mergeObjects(GenericObjectList mergeList) {

        if (mergeList == null)
            return;
        Iterator it1 = this.listIterator();
        Iterator it2 = mergeList.listIterator();
        while (it1.hasNext()) {
            GenericObject outerObj = (GenericObject) it1.next();
            while (it2.hasNext()) {
                Object innerObj = it2.next();
                outerObj.merge(innerObj);
            }
        }
    }

    /**
     * Encode the list in semicolon separated form.
     *
     * @return an encoded string containing the objects in this list.
     * @since v1.0
     */
    public String encode() {
        if (this.isEmpty())
            return "";
        StringBuffer encoding = new StringBuffer();
        ListIterator iterator = this.listIterator();
        if (iterator.hasNext()) {
            while (true) {
                Object obj = iterator.next();
                if (obj instanceof GenericObject) {
                    GenericObject gobj = (GenericObject) obj;
                    encoding.append(gobj.encode());
                } else {
                    encoding.append(obj.toString());
                }
                if (iterator.hasNext())
                    encoding.append(separator);
                else
                    break;
            }
        }
        return encoding.toString();
    }

    /**
     * Alias for the encode function above.
     */
    public String toString() {
        return this.encode();
    }

    /**
     * Set the separator (for encoding the list)
     *
     * @since v1.0
     * @param sep
     *            is the new seperator (default is semicolon)
     */
    public void setSeparator(String sep) {
        separator = sep;
    }
    
    /**
     * Hash code. We never expect to put this in a hash table so return a constant.
     */
    public int hashCode() { return 42; }

    /**
     * Equality checking predicate.
     *
     * @param other
     *            is the object to compare ourselves to.
     * @return true if the objects are equal.
     */
    public boolean equals(Object other) {
        if (other == null ) return false;
        if (!this.getClass().equals(other.getClass()))
            return false;
        GenericObjectList that = (GenericObjectList) other;
        if (this.size() != that.size())
            return false;
        ListIterator myIterator = this.listIterator();
        while (myIterator.hasNext()) {
            Object myobj = myIterator.next();
            ListIterator hisIterator = that.listIterator();
            try {
                while (true) {
                    Object hisobj = hisIterator.next();
                    if (myobj.equals(hisobj))
                        break;
                }
            } catch (NoSuchElementException ex) {
                return false;
            }
        }
        ListIterator hisIterator = that.listIterator();
        while (hisIterator.hasNext()) {
            Object hisobj = hisIterator.next();
            myIterator = this.listIterator();
            try {
                while (true) {
                    Object myobj = myIterator.next();
                    if (hisobj.equals(myobj))
                        break;
                }
            } catch (NoSuchElementException ex) {
                return false;
            }
        }
        return true;
    }

    /**
     * Match with a template (return true if we have a superset of the given
     * template. This can be used for partial match (template matching of SIP
     * objects). Note -- this implementation is not unnecessarily efficient :-)
     *
     * @param other
     *            template object to compare against.
     */

    public boolean match(Object other) {
        if (!this.getClass().equals(other.getClass()))
            return false;
        GenericObjectList that = (GenericObjectList) other;
        ListIterator hisIterator = that.listIterator();
        outer: while (hisIterator.hasNext()) {
            Object hisobj = hisIterator.next();
            Object myobj = null;
            ListIterator myIterator = this.listIterator();
            while (myIterator.hasNext()) {
                myobj = myIterator.next();
                if (myobj instanceof GenericObject)
                    System.out.println("Trying to match  = "
                            + ((GenericObject) myobj).encode());
                if (GenericObject.isMySubclass(myobj.getClass())
                        && ((GenericObject) myobj).match(hisobj))
                    break outer;
                else if (GenericObjectList.isMySubclass(myobj.getClass())
                        && ((GenericObjectList) myobj).match(hisobj))
                    break outer;
            }
            System.out.println(((GenericObject) hisobj).encode());
            return false;
        }
        return true;
    }
}
