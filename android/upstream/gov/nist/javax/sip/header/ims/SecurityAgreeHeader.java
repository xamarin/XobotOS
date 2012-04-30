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
* of the terms of this agreement.
*
*/
/************************************************************************************************
 * PRODUCT OF PT INOVACAO - EST DEPARTMENT and Telecommunications Institute (Aveiro, Portugal)  *
 ************************************************************************************************/


package gov.nist.javax.sip.header.ims;

import java.text.ParseException;

import javax.sip.InvalidArgumentException;
import javax.sip.header.Header;
import javax.sip.header.Parameters;


/**
 * "Security Mechanism Agreemet for SIP Sessions"
 *  - sec-agree: RFC 3329 + 3GPP TS33.203 (Annex H).
 *
 * <p>Headers: Security-Server + Security-Client + Security-Verify</p>
 *
 * @author Miguel Freitas (IT) PT-Inovacao
 */


public interface SecurityAgreeHeader extends Parameters, Header
{

    /**
     * Set security mechanism.
     * <p>eg: Security-Client: ipsec-3gpp</p>
     * @param secMech - security mechanism name
     */
    public void setSecurityMechanism(String secMech) throws ParseException;

    /**
     * Set Encryption Algorithm (ealg parameter)
     * @param ealg - encryption algorithm value
     * @throws ParseException
     */
    public void setEncryptionAlgorithm(String ealg) throws ParseException;

    /**
     * Set Algorithm (alg parameter)
     * @param alg - algorithm value
     * @throws ParseException
     */
    public void setAlgorithm(String alg) throws ParseException;

    /**
     * Set Protocol (prot paramater)
     * @param prot - protocol value
     * @throws ParseException
     */
    public void setProtocol(String prot) throws ParseException;

    /**
     * Set Mode (mod parameter)
     * @param mod - mode value
     * @throws ParseException
     */
    public void setMode(String mod) throws ParseException;

    /**
     * Set Client SPI (spi-c parameter)
     * @param spic - spi-c value
     * @throws InvalidArgumentException
     */
    public void setSPIClient(int spic) throws InvalidArgumentException;

    /**
     * Set Server SPI (spi-s parameter)
     * @param spis - spi-s value
     * @throws InvalidArgumentException - when value is not valid
     */
    public void setSPIServer(int spis) throws InvalidArgumentException;

    /**
     * Set Client Port (port-c parameter)
     * @param portC - port-c value
     * @throws InvalidArgumentException - when value is not valid
     */
    public void setPortClient(int portC) throws InvalidArgumentException;


    /**
     * Set Server Port (port-s parameter)
     * @param portS - port-s value
     * @throws InvalidArgumentException - when value is not valid
     */
    public void setPortServer(int portS) throws InvalidArgumentException;

    /**
     * Set Preference
     * @param q - q parameter value
     * @throws InvalidArgumentException - when value is not valid
     */
    public void setPreference(float q) throws InvalidArgumentException;



    /**
     * Get Security Mechanism
     * @return security mechanims value
     */
    public String getSecurityMechanism();

    /**
     * Get Encryption Algorithm
     * @return ealg parameter value
     */
    public String getEncryptionAlgorithm();

    /**
     * Get Algorithm
     * @return alg parameter value
     */
    public String getAlgorithm();

    /**
     * Get Protocol
     * @return prot parameter value
     */
    public String getProtocol();

    /**
     * Get Mode
     * @return mod parameter value
     */
    public String getMode();

    /**
     * Get Client SPI
     * @return spi-c parameter value
     */
    public int getSPIClient();

    /**
     * Get Server SPI
     * @return spi-s parameter value
     */
    public int getSPIServer();

    /**
     * Get Client Port
     * @return port-c parameter value
     */
    public int getPortClient();

    /**
     * Get Server Port
     * @return port-s parameter value
     */
    public int getPortServer();

    /**
     * Get Preference
     * @return q parameter value
     */
    public float getPreference();

}
