/*
* Conditions Of Use
*
* This software was developed by employees of the National Institute of
* Standards and Technology (NIST), an agency of the Federal Government,
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

/************************************************************************************************
 * PRODUCT OF PT INOVACAO - EST DEPARTMENT and Telecommunications Institute (Aveiro, Portugal)  *
 ************************************************************************************************/

package gov.nist.javax.sip.header.ims;



import java.text.ParseException;
import javax.sip.InvalidArgumentException;
import javax.sip.header.Parameters;

import gov.nist.core.NameValue;
import gov.nist.core.Separators;
import gov.nist.javax.sip.header.ims.ParameterNamesIms;
import gov.nist.javax.sip.header.ParametersHeader;


/**
 * "Security Mechanism Agreemet for SIP Sessions"
 *  - sec-agree: RFC 3329 + 3GPP TS33.203 (Annex H).
 *
 * <p>Headers: Security-Server + Security-Client + Security-Verify</p>
 *
 * @author Miguel Freitas (IT) PT-Inovacao
 */


public abstract class SecurityAgree
    extends ParametersHeader
{
    //TODO serialVersionUID
    //private static final long serialVersionUID = -6671234553927258745L;

    //public static final String EALG = ParameterNamesIms.EALG;
    // ...

    /**
     * Security Mechanism value
     */
    private String secMechanism;


    /**
     * Constructor
     * @param name - name of the Security Agree header to create
     */
    public SecurityAgree(String name)
    {
        super(name);
        parameters.setSeparator(Separators.SEMICOLON);
    }

    /**
     * Default constructor
     */
    public SecurityAgree()
    {
        super();
        parameters.setSeparator(Separators.SEMICOLON);
    }


    public void setParameter(String name, String value) throws ParseException
    {
        if (value == null)
            throw new NullPointerException("null value");

        NameValue nv = super.parameters.getNameValue(name.toLowerCase());
        if (nv == null)
        {
            nv = new NameValue(name, value);

            // quoted values
            if (name.equalsIgnoreCase(ParameterNamesIms.D_VER))
            {
                nv.setQuotedValue();

                if (value.startsWith(Separators.DOUBLE_QUOTE))
                    throw new ParseException(value
                            + " : Unexpected DOUBLE_QUOTE", 0);
            }

            super.setParameter(nv);
        }
        else
        {
            nv.setValueAsObject(value);
        }

    }

    public String encodeBody()
    {
        return this.secMechanism + SEMICOLON + SP + parameters.encode();
    }



    /**
     * Set security mechanism.
     * <p>eg: Security-Client: ipsec-3gpp</p>
     * @param secMech - security mechanism name
     */
    public void setSecurityMechanism(String secMech) throws ParseException {
        if (secMech == null)
            throw new NullPointerException(
                "JAIN-SIP "
                    + "Exception, SecurityAgree, setSecurityMechanism(), the sec-mechanism parameter is null");
        this.secMechanism = secMech;
    }

    /**
     * Set Encryption Algorithm (ealg parameter)
     * @param ealg - encryption algorithm value
     * @throws ParseException
     */
    public void setEncryptionAlgorithm(String ealg) throws ParseException {
        if (ealg == null)
            throw new NullPointerException(
                "JAIN-SIP "
                    + "Exception, SecurityClient, setEncryptionAlgorithm(), the encryption-algorithm parameter is null");

        setParameter(ParameterNamesIms.EALG, ealg);
    }

    /**
     * Set Algorithm (alg parameter)
     * @param alg - algorithm value
     * @throws ParseException
     */
    public void setAlgorithm(String alg) throws ParseException {
        if (alg == null)
            throw new NullPointerException(
                "JAIN-SIP "
                    + "Exception, SecurityClient, setAlgorithm(), the algorithm parameter is null");
        setParameter(ParameterNamesIms.ALG, alg);
    }

    /**
     * Set Protocol (prot paramater)
     * @param prot - protocol value
     * @throws ParseException
     */
    public void setProtocol(String prot) throws ParseException {
        if (prot == null)
            throw new NullPointerException(
                "JAIN-SIP "
                    + "Exception, SecurityClient, setProtocol(), the protocol parameter is null");
        setParameter(ParameterNamesIms.PROT, prot);
    }

    /**
     * Set Mode (mod parameter)
     * @param mod - mode value
     * @throws ParseException
     */
    public void setMode(String mod) throws ParseException {
        if (mod == null)
            throw new NullPointerException(
                "JAIN-SIP "
                    + "Exception, SecurityClient, setMode(), the mode parameter is null");
        setParameter(ParameterNamesIms.MOD, mod);
    }

    /**
     * Set Client SPI (spi-c parameter)
     * @param spic - spi-c value
     * @throws InvalidArgumentException
     */
    public void setSPIClient(int spic) throws InvalidArgumentException {
        if (spic < 0)
            throw new InvalidArgumentException(
                "JAIN-SIP "
                    + "Exception, SecurityClient, setSPIClient(), the spi-c parameter is <0");
        setParameter(ParameterNamesIms.SPI_C, spic);
    }

    /**
     * Set Server SPI (spi-s parameter)
     * @param spis - spi-s value
     * @throws InvalidArgumentException - when value is not valid
     */
    public void setSPIServer(int spis) throws InvalidArgumentException {
        if (spis < 0)
            throw new InvalidArgumentException(
                "JAIN-SIP "
                    + "Exception, SecurityClient, setSPIServer(), the spi-s parameter is <0");
        setParameter(ParameterNamesIms.SPI_S, spis);
    }

    /**
     * Set Client Port (port-c parameter)
     * @param portC - port-c value
     * @throws InvalidArgumentException - when value is not valid
     */
    public void setPortClient(int portC) throws InvalidArgumentException {
        if (portC < 0)
            throw new InvalidArgumentException(
                "JAIN-SIP "
                    + "Exception, SecurityClient, setPortClient(), the port-c parameter is <0");
        setParameter(ParameterNamesIms.PORT_C, portC);
    }

    /**
     * Set Server Port (port-s parameter)
     * @param portS - port-s value
     * @throws InvalidArgumentException - when value is not valid
     */
    public void setPortServer(int portS) throws InvalidArgumentException {
        if (portS < 0)
            throw new InvalidArgumentException(
                "JAIN-SIP "
                    + "Exception, SecurityClient, setPortServer(), the port-s parameter is <0");
        setParameter(ParameterNamesIms.PORT_S, portS);
    }

    /**
     * <p>Set Preference.
     * The "q" parameter indicates a relative preference for the particular mechanism.
     * The higher the value the more preferred the mechanism is.
     * Range from 0.001 to 0.999.</p>
     * @param q - q parameter value
     * @throws InvalidArgumentException - when value is not valid
     */
    public void setPreference(float q) throws InvalidArgumentException {
        if (q < 0.0f)
            throw new InvalidArgumentException(
                "JAIN-SIP "
                    + "Exception, SecurityClient, setPreference(), the preference (q) parameter is <0");
        setParameter(ParameterNamesIms.Q, q);
    }



    // get param

    /**
     * Get Security Mechanism
     * @return security mechanims value
     */
    public String getSecurityMechanism() {
        return this.secMechanism;
    }
    /**
     * Get Encryption Algorithm
     * @return ealg parameter value
     */
    public String getEncryptionAlgorithm() {
        return getParameter(ParameterNamesIms.EALG);
    }

    /**
     * Get Algorithm
     * @return alg parameter value
     */
    public String getAlgorithm() {
        return getParameter(ParameterNamesIms.ALG);
    }

    /**
     * Get Protocol
     * @return prot parameter value
     */
    public String getProtocol() {
        return getParameter(ParameterNamesIms.PROT);
    }

    /**
     * Get Mode
     * @return mod parameter value
     */
    public String getMode() {
        return getParameter(ParameterNamesIms.MOD);

    }
    /**
     * Get Client SPI
     * @return spi-c parameter value
     */
    public int getSPIClient() {
        return (Integer.parseInt(getParameter(ParameterNamesIms.SPI_C)));
    }

    /**
     * Get Server SPI
     * @return spi-s parameter value
     */
    public int getSPIServer() {
        return (Integer.parseInt(getParameter(ParameterNamesIms.SPI_S)));
    }

    /**
     * Get Client Port
     * @return port-c parameter value
     */
    public int getPortClient() {
        return (Integer.parseInt(getParameter(ParameterNamesIms.PORT_C)));
    }

    /**
     * Get Server Port
     * @return port-s parameter value
     */
    public int getPortServer() {
        return (Integer.parseInt(getParameter(ParameterNamesIms.PORT_S)));
    }

    /**
     * Get Preference
     * @return q parameter value
     */
    public float getPreference() {
        return (Float.parseFloat(getParameter(ParameterNamesIms.Q)));
    }


    public boolean equals(Object other)
    {

        if(other instanceof SecurityAgreeHeader)
        {
            SecurityAgreeHeader o = (SecurityAgreeHeader) other;
            return (this.getSecurityMechanism().equals( o.getSecurityMechanism() )
                && this.equalParameters( (Parameters) o ));
        }
        return false;

    }


    public Object clone() {
        SecurityAgree retval = (SecurityAgree) super.clone();
        if (this.secMechanism != null)
            retval.secMechanism = this.secMechanism;
        return retval;
    }


}


