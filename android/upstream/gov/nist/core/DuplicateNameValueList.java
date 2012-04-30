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
package gov.nist.core;

import java.io.Serializable;
import java.util.Collection;
import java.util.Iterator;
import java.util.Map;
import java.util.Set;

/**
 * 
 * 
 * This is a Duplicate Name Value List that will allow multiple values map to the same key.
 * 
 * The parsing and encoding logic for it is the same as that of NameValueList. Only the HashMap
 * container is different.
 * 
 * @author aayush.bhatnagar
 * @since 2.0
 * 
 */
public class DuplicateNameValueList implements Serializable, Cloneable {

    private MultiValueMapImpl<NameValue> nameValueMap = new MultiValueMapImpl<NameValue>();
    private String separator;

    private static final long serialVersionUID = -5611332957903796952L;

    public DuplicateNameValueList()

    {
        this.separator = ";";
    }

    // ------------------

    public void setSeparator(String separator) {
        this.separator = separator;
    }

    /**
     * Encode the list in semicolon separated form.
     * 
     * @return an encoded string containing the objects in this list.
     * @since v1.0
     */
    public String encode() {
        return encode(new StringBuffer()).toString();
    }

    public StringBuffer encode(StringBuffer buffer) {
        if (!nameValueMap.isEmpty()) {
            Iterator<NameValue> iterator = nameValueMap.values().iterator();
            if (iterator.hasNext()) {
                while (true) {
                    Object obj = iterator.next();
                    if (obj instanceof GenericObject) {
                        GenericObject gobj = (GenericObject) obj;
                        gobj.encode(buffer);
                    } else {
                        buffer.append(obj.toString());
                    }
                    if (iterator.hasNext())
                        buffer.append(separator);
                    else
                        break;
                }
            }
        }
        return buffer;
    }

    public String toString() {
        return this.encode();
    }

    /**
     * Set a namevalue object in this list.
     */

    public void set(NameValue nv) {
        this.nameValueMap.put(nv.getName().toLowerCase(), nv);
    }

    /**
     * Set a namevalue object in this list.
     */
    public void set(String name, Object value) {
        NameValue nameValue = new NameValue(name, value);
        nameValueMap.put(name.toLowerCase(), nameValue);

    }

    /**
     * Compare if two NameValue lists are equal.
     * 
     * @param otherObject is the object to compare to.
     * @return true if the two objects compare for equality.
     */
    public boolean equals(Object otherObject) {
        if ( otherObject == null ) {
            return false;
        }
        if (!otherObject.getClass().equals(this.getClass())) {
            return false;
        }
        DuplicateNameValueList other = (DuplicateNameValueList) otherObject;

        if (nameValueMap.size() != other.nameValueMap.size()) {
            return false;
        }
        Iterator<String> li = this.nameValueMap.keySet().iterator();

        while (li.hasNext()) {
            String key = (String) li.next();
            Collection nv1 = this.getNameValue(key);
            Collection nv2 = (Collection) other.nameValueMap.get(key);
            if (nv2 == null)
                return false;
            else if (!nv2.equals(nv1))
                return false;
        }
        return true;
    }

    /**
     * Do a lookup on a given name and return value associated with it.
     */
    public Object getValue(String name) {
        Collection nv = this.getNameValue(name.toLowerCase());
        if (nv != null)
            return nv;
        else
            return null;
    }

    /**
     * Get the NameValue record given a name.
     * 
     */
    public Collection getNameValue(String name) {
        return (Collection) this.nameValueMap.get(name.toLowerCase());
    }

    /**
     * Returns a boolean telling if this NameValueList has a record with this name
     */
    public boolean hasNameValue(String name) {
        return nameValueMap.containsKey(name.toLowerCase());
    }

    /**
     * Remove the element corresponding to this name.
     */
    public boolean delete(String name) {
        String lcName = name.toLowerCase();
        if (this.nameValueMap.containsKey(lcName)) {
            this.nameValueMap.remove(lcName);
            return true;
        } else {
            return false;
        }

    }

    public Object clone() {
        DuplicateNameValueList retval = new DuplicateNameValueList();
        retval.setSeparator(this.separator);
        Iterator<NameValue> it = this.nameValueMap.values().iterator();
        while (it.hasNext()) {
            retval.set((NameValue) ((NameValue) it.next()).clone());
        }
        return retval;
    }

    /**
     * Return an iterator for the name-value pairs of this list.
     * 
     * @return the iterator.
     */
    public Iterator<NameValue> iterator() {
        return this.nameValueMap.values().iterator();
    }

    /**
     * Get a list of parameter names.
     * 
     * @return a list iterator that has the names of the parameters.
     */
    public Iterator<String> getNames() {
        return this.nameValueMap.keySet().iterator();

    }

    /**
     * Get the parameter as a String.
     * 
     * @return the parameter as a string.
     */
    public String getParameter(String name) {
        Object val = this.getValue(name);
        if (val == null)
            return null;
        if (val instanceof GenericObject)
            return ((GenericObject) val).encode();
        else
            return val.toString();
    }

    public void clear() {
        nameValueMap.clear();

    }

    public boolean isEmpty() {
        return this.nameValueMap.isEmpty();
    }

    public NameValue put(String key, NameValue value) {
        return (NameValue) this.nameValueMap.put(key, value);
    }

    public NameValue remove(Object key) {
        return (NameValue) this.nameValueMap.remove(key);
    }

    public int size() {
        return this.nameValueMap.size();
    }

    public Collection<NameValue> values() {
        return this.nameValueMap.values();
    }

    public int hashCode() {
        return this.nameValueMap.keySet().hashCode();
    }

}
