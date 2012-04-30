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

import java.util.ArrayList;
import java.util.Collection;
import java.util.HashMap;
import java.util.Iterator;
import java.util.List;
import java.util.Map;
import java.util.Set;

public class MultiValueMapImpl<V> implements MultiValueMap<String, V>, Cloneable {
    private HashMap<String, ArrayList<V>> map = new HashMap<String, ArrayList<V>>();

    private static final long serialVersionUID = 4275505380960964605L;

    public MultiValueMapImpl() {
        super();

    }

    public List<V> put(String key, V value) {
        ArrayList<V> keyList = map.get(key);
        if (keyList == null) {
            keyList = new ArrayList<V>(10);
            map.put(key, keyList);
        }

        keyList.add(value);
        return keyList;
    }

    public boolean containsValue(Object value) {
        Set pairs = map.entrySet();

        if (pairs == null)
            return false;

        Iterator pairsIterator = pairs.iterator();
        while (pairsIterator.hasNext()) {
            Map.Entry keyValuePair = (Map.Entry) (pairsIterator.next());
            ArrayList list = (ArrayList) (keyValuePair.getValue());
            if (list.contains(value))
                return true;
        }
        return false;
    }

    public void clear() {
        Set pairs = map.entrySet();
        Iterator pairsIterator = pairs.iterator();
        while (pairsIterator.hasNext()) {
            Map.Entry keyValuePair = (Map.Entry) (pairsIterator.next());
            ArrayList list = (ArrayList) (keyValuePair.getValue());
            list.clear();
        }
        map.clear();
    }

    public Collection values() {
        ArrayList returnList = new ArrayList(map.size());

        Set pairs = map.entrySet();
        Iterator pairsIterator = pairs.iterator();
        while (pairsIterator.hasNext()) {
            Map.Entry keyValuePair = (Map.Entry) (pairsIterator.next());
            ArrayList list = (ArrayList) (keyValuePair.getValue());

            Object[] values = list.toArray();
            for (int ii = 0; ii < values.length; ii++) {
                returnList.add(values[ii]);
            }
        }
        return returnList;
    }

    public Object clone() {
        MultiValueMapImpl obj = new MultiValueMapImpl<V>();
        obj.map = (HashMap<Object, ArrayList<V>>) this.map.clone();
        return obj;
    }

    public int size() {
        return this.map.size();
    }

    public boolean containsKey(Object key) {
        return map.containsKey(key);
    }

    public Set entrySet() {
        return map.entrySet();
    }

    public boolean isEmpty() {
        return map.isEmpty();
    }

    public Set<String> keySet() {
        return this.map.keySet();
    }

    public Object remove(String key, V item) {
        ArrayList<V> list = this.map.get(key);
        if (list == null) {
            return null;
        } else {
            return list.remove(item);
        }
    }

    public List<V> get(Object key) {
        return map.get(key);
    }

    public List<V> put(String key, List<V> value) {
        return this.map.put(key,(ArrayList<V>) value);
    }

    public List<V> remove(Object key) {
        return map.remove(key);
    }
    
    public void putAll(Map< ? extends String, ? extends List<V>> mapToPut) {
        for (String k : mapToPut.keySet()) {
            ArrayList<V> al = new ArrayList<V>();
            al.addAll(mapToPut.get(k));
            this.map.put(k, al);
        }  
    }

}
