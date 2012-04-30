/*
* Conditions Of Use
*
* This software was developed by employees of the National Institute of
* Standards and Technology (NIST), an agency of the Federal Government
* and others.
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
/*******************************************
 * PRODUCT OF PT INOVACAO - EST DEPARTMENT *
 *******************************************/

package gov.nist.javax.sip.header.ims;

import gov.nist.core.NameValue;
import java.text.ParseException;
import java.util.ArrayList;
import java.util.Iterator;
import java.util.LinkedList;
import java.util.ListIterator;

import javax.sip.header.ExtensionHeader;

import gov.nist.javax.sip.header.ims.PChargingFunctionAddressesHeader;
import gov.nist.javax.sip.header.ims.ParameterNamesIms;


/**
 * <p>P-Charging-Function-Addresses SIP Private Header. </p>
 *
 * <p>Sintax (RFC 3455):</p>
 * <pre>
 * P-Charging-Addr        = "P-Charging-Function-Addresses" HCOLON
 *                           charge-addr-params
 *                           *(SEMI charge-addr-params)
 * charge-addr-params     = ccf / ecf / generic-param
 * ccf                    = "ccf" EQUAL gen-value
 * ecf                    = "ecf" EQUAL gen-value
 * gen-value              = token / host / quoted-string
 * </pre>
 *
 * <p>example:</p>
 *  <p>P-Charging-Function-Addresses: ccf=192.1.1.1; ccf=192.1.1.2;
 *  ecf=192.1.1.3; ecf=192.1.1.4</p>
 *
 * <p>TODO: add PARSER support for IPv6 address.
 * eg: P-Charging-Function-Addresses: ccf=[5555.b99.c88.d77.e66]; ecf=[5555.6aa.7bb.8cc.9dd] </p>
 *
 * @author ALEXANDRE MIGUEL SILVA SANTOS - Nú 10045401
 */


public class PChargingFunctionAddresses
    extends gov.nist.javax.sip.header.ParametersHeader
    implements PChargingFunctionAddressesHeader, SIPHeaderNamesIms , ExtensionHeader{


    // TODO: serialVersionUID

    /**
     * Defaul Constructor
     */
    public PChargingFunctionAddresses() {

        super(P_CHARGING_FUNCTION_ADDRESSES);
    }

    /* (non-Javadoc)
     * @see gov.nist.javax.sip.header.ParametersHeader#encodeBody()
     */
    protected String encodeBody() {

        StringBuffer encoding = new StringBuffer();

        // issued by Miguel Freitas
        if (!duplicates.isEmpty())
        {
            encoding.append(duplicates.encode());
        }

        return encoding.toString();

    }

    /**
     * <p>Set the Charging Collection Function (CCF) Address</p>
     *
     * @param ccfAddress - the address to set in the CCF parameter
     * @throws ParseException
     */
    public void setChargingCollectionFunctionAddress(String ccfAddress) throws ParseException {

        if (ccfAddress == null)
            throw new NullPointerException(
                "JAIN-SIP Exception, "
                    + "P-Charging-Function-Addresses, setChargingCollectionFunctionAddress(), the ccfAddress parameter is null.");

       // setParameter(ParameterNamesIms.CCF, ccfAddress);
        setMultiParameter(ParameterNamesIms.CCF, ccfAddress);

    }

    /**
     * <p>Add another Charging Collection Function (CCF) Address to this header</p>
     *
     * @param ccfAddress - the address to set in the CCF parameter
     * @throws ParseException
     */
    public void addChargingCollectionFunctionAddress(String ccfAddress) throws ParseException {

        if (ccfAddress == null)
            throw new NullPointerException(
                "JAIN-SIP Exception, "
                    + "P-Charging-Function-Addresses, setChargingCollectionFunctionAddress(), the ccfAddress parameter is null.");

        this.parameters.set(ParameterNamesIms.CCF, ccfAddress);

    }

    /**
     * <p>Remove a Charging Collection Function (CCF) Address set in this header</p>
     *
     * @param ccfAddress - the address in the CCF parameter to remove
     * @throws ParseException if the address was not removed
     */
    public void removeChargingCollectionFunctionAddress(String ccfAddress) throws ParseException {

        if (ccfAddress == null)
            throw new NullPointerException(
                "JAIN-SIP Exception, "
                    + "P-Charging-Function-Addresses, setChargingCollectionFunctionAddress(), the ccfAddress parameter is null.");

        if(!this.delete(ccfAddress, ParameterNamesIms.CCF)) {

            throw new ParseException("CCF Address Not Removed",0);

        }

    }

    /**
     * <p>Get all the Charging Collection Function (CCF) Addresses set in this header</p>
     *
     * @return ListIterator that constains all CCF addresses of this header
     */
    public ListIterator getChargingCollectionFunctionAddresses() {

        Iterator li = this.parameters.iterator();
        LinkedList ccfLIST = new LinkedList();
        NameValue nv;
        while (li.hasNext()) {
            nv = (NameValue) li.next();
            if (nv.getName().equalsIgnoreCase(ParameterNamesIms.CCF)) {

                NameValue ccfNV = new NameValue();

                ccfNV.setName(nv.getName());
                ccfNV.setValueAsObject(nv.getValueAsObject());

                ccfLIST.add(ccfNV);

            }
        }

        return ccfLIST.listIterator();
    }

    /**
     * <p>Set the Event Charging Function (ECF) Address</p>
     *
     * @param ecfAddress - the address to set in the ECF parameter
     * @throws ParseException
     */
    public void setEventChargingFunctionAddress(String ecfAddress) throws ParseException {

        if (ecfAddress == null)
            throw new NullPointerException(
                "JAIN-SIP Exception, "
                    + "P-Charging-Function-Addresses, setEventChargingFunctionAddress(), the ecfAddress parameter is null.");

        setMultiParameter(ParameterNamesIms.ECF, ecfAddress);
       // setParameter(ParameterNamesIms.ECF, ecfAddress);

    }

    /**
     * <p>Add another Event Charging Function (ECF) Address to this header</p>
     *
     * @param ecfAddress - the address to set in the ECF parameter
     * @throws ParseException
     */
    public void addEventChargingFunctionAddress(String ecfAddress) throws ParseException {

        if (ecfAddress == null)
            throw new NullPointerException(
                "JAIN-SIP Exception, "
                    + "P-Charging-Function-Addresses, setEventChargingFunctionAddress(), the ecfAddress parameter is null.");

        this.parameters.set(ParameterNamesIms.ECF, ecfAddress);

    }

    /**
     * <p>Remove a Event Charging Function (ECF) Address set in this header</p>
     *
     * @param ecfAddress - the address in the ECF parameter to remove
     * @throws ParseException if the address was not removed
     */
    public void removeEventChargingFunctionAddress(String ecfAddress) throws ParseException {

        if (ecfAddress == null)
            throw new NullPointerException(
                "JAIN-SIP Exception, "
                    + "P-Charging-Function-Addresses, setEventChargingFunctionAddress(), the ecfAddress parameter is null.");

        if(!this.delete(ecfAddress, ParameterNamesIms.ECF)) {

            throw new java.text.ParseException("ECF Address Not Removed",0);

        }

    }

    /**
     * <p>Get all the Event Charging Function (ECF) Addresses set in this header</p>
     *
     * @return ListIterator that constains all CCF addresses of this header
     */
    public ListIterator<NameValue> getEventChargingFunctionAddresses() {

    	LinkedList<NameValue> listw = new LinkedList<NameValue>();
   
        Iterator li = this.parameters.iterator();
        ListIterator<NameValue> ecfLIST = listw.listIterator();
        NameValue nv;
        boolean removed = false;
        while (li.hasNext()) {
            nv = (NameValue) li.next();
            if (nv.getName().equalsIgnoreCase(ParameterNamesIms.ECF)) {

                NameValue ecfNV = new NameValue();

                ecfNV.setName(nv.getName());
                ecfNV.setValueAsObject(nv.getValueAsObject());

                ecfLIST.add(ecfNV);

            }
        }

        return ecfLIST;
    }

    /**
     * <p>Remove parameter </p>
     *
     * @param value - of the parameter
     * @param name - of the parameter
     * @return true if parameter was removed, and false if not
     */
    public boolean delete(String value, String name) {
        Iterator li = this.parameters.iterator();
        NameValue nv;
        boolean removed = false;
        while (li.hasNext()) {
            nv = (NameValue) li.next();
            if (((String) nv.getValueAsObject()).equalsIgnoreCase(value) && nv.getName().equalsIgnoreCase(name)) {
                li.remove();
                removed = true;
            }
        }

        return removed;

    }

    public void setValue(String value) throws ParseException {
        throw new ParseException ( value,0);

    }

}
