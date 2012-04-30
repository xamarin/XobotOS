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

import javax.sip.header.Header;
import javax.sip.header.Parameters;
import java.text.ParseException;
import java.util.ArrayList;
import java.util.ListIterator;


/**
 * P-Charging-Function-Addresses header -
 * Private Header: RFC 3455.
 *
 * There is a need to inform each SIP proxy involved in a transaction about the common
 * charging functional entities to receive the generated charging records or charging events.
 * <ul>
 * <li>
 *   - CCF is used for off-line charging (e.g., for postpaid account charging).
 * <li>
 *   - ECF is used for on-line charging (e.g., for pre-paid account charging).
 * </ul>
 * Only one instance of the header MUST be present in a particular request or response.
 *
 * <pre>
 * P-Charging-Addr = "P-Charging-Function-Addresses" HCOLON
 *          charge-addr-params
 *          *(SEMI charge-addr-params)
 * charge-addr-params   = ccf / ecf / generic-param
 * ccf              = "ccf" EQUAL gen-value
 * ecf              = "ecf" EQUAL gen-value
 *
 * gen-value    = token / host / quoted-string
 *
 * host             =  hostname / IPv4address / IPv6reference
 * hostname         =  *( domainlabel "." ) toplabel [ "." ]
 * domainlabel      =  alphanum / alphanum *( alphanum / "-" ) alphanum
 * toplabel         =  ALPHA / ALPHA *( alphanum / "-" ) alphanum
 *
 *
 * example:
 *  P-Charging-Function-Addresses: ccf=192.1.1.1; ccf=192.1.1.2;
 *  ecf=192.1.1.3; ecf=192.1.1.4
 * </pre>
 *
 * @author ALEXANDRE MIGUEL SILVA SANTOS - Nú 10045401
 */



public interface PChargingFunctionAddressesHeader extends Parameters, Header {

    /**
     * Name of PChargingFunctionAddressesHeader
     */
    public final static String NAME = "P-Charging-Function-Addresses";


    /**
     * <p>Set the Charging Collection Function (CCF) Address</p>
     * @param ccfAddress - the address to set in the CCF parameter
     * @throws ParseException
     */
    public void setChargingCollectionFunctionAddress(String ccfAddress) throws ParseException;

    /**
     * <p>Add another Charging Collection Function (CCF) Address to this header</p>
     * @param ccfAddress - the address to set in the CCF parameter
     * @throws ParseException
     */
    public void addChargingCollectionFunctionAddress(String ccfAddress) throws ParseException;

    /**
     * <p>Remove a Charging Collection Function (CCF) Address set in this header</p>
     * @param ccfAddress - the address in the CCF parameter to remove
     * @throws ParseException if the address was not removed
     */
    public void removeChargingCollectionFunctionAddress(String ccfAddress) throws ParseException;

    /**
     * <p>Get all the Charging Collection Function (CCF) Addresses set in this header</p>
     * @return ListIterator that constains all CCF addresses of this header
     */
    public ListIterator getChargingCollectionFunctionAddresses();

    /**
     * <p>Set the Event Charging Function (ECF) Address</p>
     * @param ecfAddress - the address to set in the ECF parameter
     * @throws ParseException
     */
    public void setEventChargingFunctionAddress(String ecfAddress)throws ParseException;

    /**
     * <p>Add another Event Charging Function (ECF) Address to this header</p>
     * @param ecfAddress - the address to set in the ECF parameter
     * @throws ParseException
     */
    public void addEventChargingFunctionAddress(String ecfAddress) throws ParseException;

    /**
     * <p>Remove a Event Charging Function (ECF) Address set in this header</p>
     * @param ecfAddress - the address in the ECF parameter to remove
     * @throws ParseException if the address was not removed
     */
    public void removeEventChargingFunctionAddress(String ecfAddress) throws ParseException;

    /**
     * <p>Get all the Event Charging Function (ECF) Addresses set in this header</p>
     * @return ListIterator that constains all CCF addresses of this header
     */
    public ListIterator getEventChargingFunctionAddresses();

}
