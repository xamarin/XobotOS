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
/******************************************************************************
 * Product of NIST/ITL Advanced Networking Technologies Division (ANTD).      *
 ******************************************************************************/
package gov.nist.core;
import java.lang.reflect.*;
import java.io.Serializable;
import java.util.*;

/**
* The base class from which all the other classes in the
* sipheader, sdpfields and sipmessage packages are extended.
* Provides a few utility funcitons such as indentation and
* pretty printing that all other classes benifit from.
*
*@version 1.2
*
*@author M. Ranganathan   <br/>
*
*
*
*/

public abstract class GenericObject implements Serializable, Cloneable {
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

    protected static final Set<Class<?>> immutableClasses = new HashSet<Class<?>> (10);
    static final String[] immutableClassNames ={
        "String", "Character",
        "Boolean", "Byte", "Short", "Integer", "Long",
        "Float", "Double"
        };

    protected int indentation;
    protected String stringRepresentation;
    protected Match matchExpression; // Pattern matcher.

    static {
        try {
            for (int i = 0; i < immutableClassNames.length; i++)
                immutableClasses.add(Class.forName("java.lang." + immutableClassNames [i]));
        } catch (ClassNotFoundException e) {
            throw new RuntimeException ("Internal error", e);
        }
    }

    /** Set the  pattern matcher. To match on the
     * field of a sip message, set the match expression in the match template
     * and invoke the match function. This useful because
     * SIP headers and parameters may appear in different orders and are not
     * necessarily in canonical form. This makes it hard to write a pattern
     * matcher that relies on regular expressions alone.
     * Thus we rely on the following  strategy i.e. To do pattern matching on
     * an incoming message, first parse it, and then construct a match template,
     * filling in the fields that you want to
     * match. The rules for matching are: A null object matches wild card -
     * that is a match template of null matches any parsed SIP object.
     * To match with any subfield, set the match template on a template object
     * of the same type and invoke the match interface.
     * Regular expressions matching implements the gov.nist.sip.Match interface
     * that can be done using the Jakarta regexp package for example.
     * package included herein. This can be used to implement the Match interface
     * <a href=http://www.apache.org> See the APACHE website for documents </a>
     *
     */
    public void setMatcher(Match matchExpression) {
        if (matchExpression == null)
            throw new IllegalArgumentException("null arg!");
        this.matchExpression = matchExpression;
    }

    /** Return the match expression.
     *@return the match expression that has previously been set.
     */
    public Match getMatcher() {
        return matchExpression;
    }

    public static Class<?> getClassFromName(String className) {
        try {
            return Class.forName(className);
        } catch (Exception ex) {
            InternalErrorHandler.handleException(ex);
            return null;
        }
    }

    public static boolean isMySubclass(Class<?> other) {

            return GenericObject.class.isAssignableFrom(other);

    }

    /** Clones the given object.
     *  If the object is a wrapped type, an array, a GenericObject
     *  or a GenericObjectList, it is cast to the appropriate type
     *  and the clone() method is invoked. Else if the object implements
     *  Cloneable, reflection is used to discover and invoke
     *  clone() method. Otherwise, the original object is returned.
     */
    public static Object makeClone(Object obj) {
        if (obj == null)
            throw new NullPointerException("null obj!");
        Class<?> c = obj.getClass();
        Object clone_obj = obj;
        if (immutableClasses.contains (c))
            return obj;
        else if (c.isArray ()) {
            Class<?> ec = c.getComponentType();
            if (! ec.isPrimitive())
                clone_obj = ((Object []) obj).clone();
            else {
                if (ec == Character.TYPE)
                    clone_obj = ((char []) obj).clone();
                else if (ec == Boolean.TYPE)
                    clone_obj = ((boolean []) obj).clone();
                if (ec == Byte.TYPE)
                    clone_obj = ((byte []) obj).clone();
                else if (ec == Short.TYPE)
                    clone_obj = ((short []) obj).clone();
                else if (ec == Integer.TYPE)
                    clone_obj = ((int []) obj).clone();
                else if (ec == Long.TYPE)
                    clone_obj = ((long []) obj).clone();
                else if (ec == Float.TYPE)
                    clone_obj = ((float []) obj).clone();
                else if (ec == Double.TYPE)
                    clone_obj = ((double []) obj).clone();
            }
        } else if (GenericObject.class.isAssignableFrom (c))
            clone_obj = ((GenericObject) obj).clone();
        else if (GenericObjectList.class.isAssignableFrom (c))
            clone_obj = ((GenericObjectList) obj).clone();
        else if (Cloneable.class.isAssignableFrom (c)) {
            // If a clone method exists for the object, then
            // invoke it
            try {
                Method meth = c.getMethod("clone", (Class[]) null);
                clone_obj = meth.invoke(obj,(Object[]) null);
            } catch (SecurityException ex) {
            } catch (IllegalArgumentException ex) {
                InternalErrorHandler.handleException(ex);
            } catch (IllegalAccessException ex) {
            } catch (InvocationTargetException ex) {
            } catch (NoSuchMethodException ex) {
            }
        }
        return clone_obj;
    }

    /** Clones this object.
     */
    public Object clone() {
        try {
            return super.clone();
        } catch (CloneNotSupportedException e) {
            throw new RuntimeException("Internal error");
        }
    }
    /**
     * Recursively override the fields of this object with the fields
     * of a new object. This is useful when you want to genrate a template
     * and override the fields of an incoming SIPMessage with another
     * SIP message that you have already generated.
     *
     * @param mergeObject is the replacement object.  The override
     * obect must be of the same class as this object.
     * Set any fields that you do not want to override as null in the
     * mergeOject object.
     */
    public void merge(Object mergeObject) {
        // Base case.
        if (mergeObject == null)
            return;

        if (!mergeObject.getClass().equals(this.getClass()))
            throw new IllegalArgumentException("Bad override object");
                        
        Class<?> myclass = this.getClass();
        while (true) {
            Field[] fields = myclass.getDeclaredFields();
            for (int i = 0; i < fields.length; i++) {
                Field f = fields[i];
                int modifier = f.getModifiers();
                if (Modifier.isPrivate(modifier)) {
                    continue;
                } else if (Modifier.isStatic(modifier)) {
                    continue;
                } else if (Modifier.isInterface(modifier)) {
                    continue;
                }
                Class<?> fieldType = f.getType();
                String fname = fieldType.toString();
                try {
                    // Primitive fields are printed with type: value
                    if (fieldType.isPrimitive()) {
                        if (fname.compareTo("int") == 0) {
                            int intfield = f.getInt(mergeObject);
                            f.setInt(this, intfield);
                        } else if (fname.compareTo("short") == 0) {
                            short shortField = f.getShort(mergeObject);
                            f.setShort(this, shortField);
                        } else if (fname.compareTo("char") == 0) {
                            char charField = f.getChar(mergeObject);
                            f.setChar(this, charField);
                        } else if (fname.compareTo("long") == 0) {
                            long longField = f.getLong(mergeObject);
                            f.setLong(this, longField);
                        } else if (fname.compareTo("boolean") == 0) {
                            boolean booleanField = f.getBoolean(mergeObject);
                            f.setBoolean(this, booleanField);
                        } else if (fname.compareTo("double") == 0) {
                            double doubleField = f.getDouble(mergeObject);
                            f.setDouble(this, doubleField);
                        } else if (fname.compareTo("float") == 0) {
                            float floatField = f.getFloat(mergeObject);
                            f.setFloat(this, floatField);
                        }
                    } else {
                        Object obj = f.get(this);
                        Object mobj = f.get(mergeObject);
                        if (mobj == null)
                            continue;
                        if (obj == null) {
                            f.set(this, mobj);
                            continue;
                        }
                        if (obj instanceof GenericObject) {
                            GenericObject gobj = (GenericObject) obj;
                            gobj.merge(mobj);
                        } else {
                            f.set(this, mobj);
                        }
                    }
                } catch (IllegalAccessException ex1) {
                    ex1.printStackTrace();
                    continue; // we are accessing a private field...
                }
            }
            myclass = myclass.getSuperclass();
            if (myclass.equals(GenericObject.class))
                break;
        }
    }

    protected GenericObject() {
        indentation = 0;
        stringRepresentation = "";
    }

    protected String getIndentation() {
    char [] chars = new char [indentation];
    java.util.Arrays.fill (chars, ' ');
    return new String (chars);
    }

    /**
     * Add a new string to the accumulated string representation.
     */

    protected void sprint(String a) {
        if (a == null) {
            stringRepresentation += getIndentation();
            stringRepresentation += "<null>\n";
            return;
        }
        if (a.compareTo("}") == 0 || a.compareTo("]") == 0) {
            indentation--;
        }
        stringRepresentation += getIndentation();
        stringRepresentation += a;
        stringRepresentation += "\n";
        if (a.compareTo("{") == 0 || a.compareTo("[") == 0) {
            indentation++;
        }

    }

    /**
     * Pretty printing function accumulator for objects.
     */

    protected void sprint(Object o) {
        sprint(o.toString());
    }

    /**
     * Pretty printing accumulator function for ints
     */

    protected void sprint(int intField) {
        sprint(String.valueOf(intField));
    }

    /**
     * Pretty printing accumulator function for shorts
     */
    protected void sprint(short shortField) {
        sprint(String.valueOf(shortField));
    }

    /**
     * Pretty printing accumulator function for chars
     */

    protected void sprint(char charField) {
        sprint(String.valueOf(charField));

    }

    /**
     * Pretty printing accumulator function for longs
     */

    protected void sprint(long longField) {
        sprint(String.valueOf(longField));
    }

    /**
     * Pretty printing accumulator function for booleans
     */

    protected void sprint(boolean booleanField) {
        sprint(String.valueOf(booleanField));
    }

    /**
     * Pretty printing accumulator function for doubles
     */

    protected void sprint(double doubleField) {
        sprint(String.valueOf(doubleField));
    }

    /**
     * Pretty printing accumulator function for floats
     */

    protected void sprint(float floatField) {
        sprint(String.valueOf(floatField));
    }

    /**
     * Debug printing function.
     */

    protected void dbgPrint() {
        Debug.println(debugDump());
    }

    /**
     * Debug printing function.
     */
    protected void dbgPrint(String s) {
        Debug.println(s);
    }

    /**
     * An introspection based equality predicate for GenericObjects.
     *@param that is the other object to test against.
     *@return true if the objects are euqal and false otherwise
     */
    public boolean equals(Object that) {
        if ( that == null ) return false;
        if (!this.getClass().equals(that.getClass()))
            return false;
        Class<?> myclass = this.getClass();
        Class<?> hisclass = that.getClass();
        while (true) {
            Field[] fields = myclass.getDeclaredFields();
            Field[] hisfields = hisclass.getDeclaredFields();
            for (int i = 0; i < fields.length; i++) {
                Field f = fields[i];
                Field g = hisfields[i];
                // Only print protected and public members.
                int modifier = f.getModifiers();
                if ((modifier & Modifier.PRIVATE) == Modifier.PRIVATE)
                    continue;
                Class<?> fieldType = f.getType();
                String fieldName = f.getName();
                if (fieldName.compareTo("stringRepresentation") == 0) {
                    continue;
                }
                if (fieldName.compareTo("indentation") == 0) {
                    continue;
                }
                try {
                    // Primitive fields are printed with type: value
                    if (fieldType.isPrimitive()) {
                        String fname = fieldType.toString();
                        if (fname.compareTo("int") == 0) {
                            if (f.getInt(this) != g.getInt(that))
                                return false;
                        } else if (fname.compareTo("short") == 0) {
                            if (f.getShort(this) != g.getShort(that))
                                return false;
                        } else if (fname.compareTo("char") == 0) {
                            if (f.getChar(this) != g.getChar(that))
                                return false;
                        } else if (fname.compareTo("long") == 0) {
                            if (f.getLong(this) != g.getLong(that))
                                return false;
                        } else if (fname.compareTo("boolean") == 0) {
                            if (f.getBoolean(this) != g.getBoolean(that))
                                return false;
                        } else if (fname.compareTo("double") == 0) {
                            if (f.getDouble(this) != g.getDouble(that))
                                return false;
                        } else if (fname.compareTo("float") == 0) {
                            if (f.getFloat(this) != g.getFloat(that))
                                return false;
                        }
                    } else if (g.get(that) == f.get(this))
                        return true;
                    else if (f.get(this) == null)
                        return false;
                    else if (g.get(that) == null)
                        return false;
                    else if (g.get(that) == null && f.get(this) != null)
                        return false;
                    else if (!f.get(this).equals(g.get(that)))
                        return false;
                } catch (IllegalAccessException ex1) {
                    InternalErrorHandler.handleException(ex1);
                }
            }
            if (myclass.equals(GenericObject.class))
                break;
            else {
                myclass = myclass.getSuperclass();
                hisclass = hisclass.getSuperclass();
            }

        }
        return true;
    }

    /** An introspection based predicate matching using a template
     * object. Allows for partial match of two protocl Objects.
     *@param other the match pattern to test against. The match object
     * has to be of the same type (class). Primitive types
     * and non-sip fields that are non null are matched for equality.
     * Null in any field  matches anything. Some book-keeping fields
     * are ignored when making the comparison.
     */

    public boolean match(Object other) {
        if (other == null)
            return true;
        if (!this.getClass().equals(other.getClass()))
            return false;
        GenericObject that = (GenericObject) other;
        Class<?> myclass = this.getClass();
        Field[] fields = myclass.getDeclaredFields();
        Class<?> hisclass = other.getClass();
        Field[] hisfields = hisclass.getDeclaredFields();
        for (int i = 0; i < fields.length; i++) {
            Field f = fields[i];
            Field g = hisfields[i];
            // Only print protected and public members.
            int modifier = f.getModifiers();
            if ((modifier & Modifier.PRIVATE) == Modifier.PRIVATE)
                continue;
            Class<?> fieldType = f.getType();
            String fieldName = f.getName();
            if (fieldName.compareTo("stringRepresentation") == 0) {
                continue;
            }
            if (fieldName.compareTo("indentation") == 0) {
                continue;
            }
            try {
                // Primitive fields are printed with type: value
                if (fieldType.isPrimitive()) {
                    String fname = fieldType.toString();
                    if (fname.compareTo("int") == 0) {
                        if (f.getInt(this) != g.getInt(that))
                            return false;
                    } else if (fname.compareTo("short") == 0) {
                        if (f.getShort(this) != g.getShort(that))
                            return false;
                    } else if (fname.compareTo("char") == 0) {
                        if (f.getChar(this) != g.getChar(that))
                            return false;
                    } else if (fname.compareTo("long") == 0) {
                        if (f.getLong(this) != g.getLong(that))
                            return false;
                    } else if (fname.compareTo("boolean") == 0) {
                        if (f.getBoolean(this) != g.getBoolean(that))
                            return false;
                    } else if (fname.compareTo("double") == 0) {
                        if (f.getDouble(this) != g.getDouble(that))
                            return false;
                    } else if (fname.compareTo("float") == 0) {
                        if (f.getFloat(this) != g.getFloat(that))
                            return false;
                    }
                } else {
                    Object myObj = f.get(this);
                    Object hisObj = g.get(that);
                    if (hisObj != null && myObj == null)
                        return false;
                    else if (hisObj == null && myObj != null)
                        continue;
                    else if (hisObj == null && myObj == null)
                        continue;
                    else if (
                        hisObj instanceof java.lang.String
                            && myObj instanceof java.lang.String) {
                        if ((((String) hisObj).trim()).equals(""))
                            continue;
                        if (((String) myObj)
                            .compareToIgnoreCase((String) hisObj)
                            != 0)
                            return false;
                    } else if (
                        GenericObject.isMySubclass(myObj.getClass())
                            && !((GenericObject) myObj).match(hisObj))
                        return false;
                    else if (
                        GenericObjectList.isMySubclass(myObj.getClass())
                            && !((GenericObjectList) myObj).match(hisObj))
                        return false;

                }
            } catch (IllegalAccessException ex1) {
                InternalErrorHandler.handleException(ex1);
            }
        }
        return true;
    }

    /**
     * Generic print formatting function:
     * Does depth-first descent of the structure and
     * recursively prints all non-private objects pointed to
     * by this object.
     * <bf>
     * Warning - the following generic string routine will
     * bomb (go into infinite loop) if there are any circularly linked
     * structures so if you have these, they had better be private!
     * </bf>
     * We dont have to worry about such things for our structures
     *(we never use circular linked structures).
     */

    public String debugDump() {
        stringRepresentation = "";
        Class<?> myclass = getClass();
        sprint(myclass.getName());
        sprint("{");
        Field[] fields = myclass.getDeclaredFields();
        for (int i = 0; i < fields.length; i++) {
            Field f = fields[i];
            // Only print protected and public members.
            int modifier = f.getModifiers();
            if ((modifier & Modifier.PRIVATE) == Modifier.PRIVATE)
                continue;
            Class<?> fieldType = f.getType();
            String fieldName = f.getName();
            if (fieldName.compareTo("stringRepresentation") == 0) {
                // avoid nasty recursions...
                continue;
            }
            if (fieldName.compareTo("indentation") == 0) {
                // formatting stuff - not relevant here.
                continue;
            }
            sprint(fieldName + ":");
            try {
                // Primitive fields are printed with type: value
                if (fieldType.isPrimitive()) {
                    String fname = fieldType.toString();
                    sprint(fname + ":");
                    if (fname.compareTo("int") == 0) {
                        int intfield = f.getInt(this);
                        sprint(intfield);
                    } else if (fname.compareTo("short") == 0) {
                        short shortField = f.getShort(this);
                        sprint(shortField);
                    } else if (fname.compareTo("char") == 0) {
                        char charField = f.getChar(this);
                        sprint(charField);
                    } else if (fname.compareTo("long") == 0) {
                        long longField = f.getLong(this);
                        sprint(longField);
                    } else if (fname.compareTo("boolean") == 0) {
                        boolean booleanField = f.getBoolean(this);
                        sprint(booleanField);
                    } else if (fname.compareTo("double") == 0) {
                        double doubleField = f.getDouble(this);
                        sprint(doubleField);
                    } else if (fname.compareTo("float") == 0) {
                        float floatField = f.getFloat(this);
                        sprint(floatField);
                    }
                } else if (GenericObject.class.isAssignableFrom(fieldType)) {
                    if (f.get(this) != null) {
                        sprint(
                            ((GenericObject) f.get(this)).debugDump(
                                indentation + 1));
                    } else {
                        sprint("<null>");
                    }

                } else if (
                    GenericObjectList.class.isAssignableFrom(fieldType)) {
                    if (f.get(this) != null) {
                        sprint(
                            ((GenericObjectList) f.get(this)).debugDump(
                                indentation + 1));
                    } else {
                        sprint("<null>");
                    }

                } else {
                    // Dont do recursion on things that are not
                    // of our header type...
                    if (f.get(this) != null) {
                        sprint(f.get(this).getClass().getName() + ":");
                    } else {
                        sprint(fieldType.getName() + ":");
                    }

                    sprint("{");
                    if (f.get(this) != null) {
                        sprint(f.get(this).toString());
                    } else {
                        sprint("<null>");
                    }
                    sprint("}");
                }
            } catch (IllegalAccessException ex1) {
                continue; // we are accessing a private field...
            } catch (Exception ex) {
                InternalErrorHandler.handleException(ex);
            }
        }
        sprint("}");
        return stringRepresentation;
    }

    /**
     * Formatter with a given starting indentation.
     */
    public String debugDump(int indent) {
        indentation = indent;
        String retval = this.debugDump();
        indentation = 0;
        return retval;
    }


    /**
     *  Get the string encoded version of this object
     * @since v1.0
     */
    public abstract String encode();

    /**
     * Put the encoded version of this object in the given StringBuffer.
     */
    public StringBuffer encode(StringBuffer buffer) {
        return buffer.append(encode());
    }
}
