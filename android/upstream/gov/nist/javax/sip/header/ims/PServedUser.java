package gov.nist.javax.sip.header.ims;
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
import java.text.ParseException;
import javax.sip.InvalidArgumentException;
import javax.sip.header.ExtensionHeader;
import gov.nist.javax.sip.address.AddressImpl;
import gov.nist.javax.sip.header.AddressParametersHeader;

/**
 *
 * @author aayush.bhatnagar
 * Rancore Technologies Pvt Ltd, Mumbai India.
 *
 * This is the class used for encoding of the P-Served-User header
 *
 *
 */
public class PServedUser extends AddressParametersHeader implements PServedUserHeader, SIPHeaderNamesIms, ExtensionHeader{


    public PServedUser(AddressImpl address)
    {
        super(P_SERVED_USER);
        this.address = address;
    }

    public PServedUser()
    {
        super(NAME);
    }

    public String getRegistrationState() {

        return getParameter(ParameterNamesIms.REGISTRATION_STATE);
    }

    public String getSessionCase() {

        return getParameter(ParameterNamesIms.SESSION_CASE);
    }

    public void setRegistrationState(String registrationState) {

        if((registrationState!=null))
        {
            if(registrationState.equals("reg")||registrationState.equals("unreg"))
            {
                try {
                    setParameter(ParameterNamesIms.REGISTRATION_STATE, registrationState);
                } catch (ParseException e) {
                    e.printStackTrace();
                }

            }
              else
              {
                  try {
                      throw new InvalidArgumentException("Value can be either reg or unreg");
                  } catch (InvalidArgumentException e) {
                         e.printStackTrace();
                    }
              }

        }
        else
        {
            throw new NullPointerException("regstate Parameter value is null");
        }

    }

    public void setSessionCase(String sessionCase) {

        if((sessionCase!=null))
        {
            if((sessionCase.equals("orig"))||(sessionCase.equals("term")))
            {
                try {
                    setParameter(ParameterNamesIms.SESSION_CASE, sessionCase);
                } catch (ParseException e) {
                    e.printStackTrace();
                }
            }
              else
              {
                  try {
                    throw new InvalidArgumentException("Value can be either orig or term");
                } catch (InvalidArgumentException e) {
                    e.printStackTrace();
                }

              }
        }
        else
        {
            throw new NullPointerException("sess-case Parameter value is null");
        }

    }

    @Override
    protected String encodeBody() {

        StringBuffer retval = new StringBuffer();

        retval.append(address.encode());

        if(parameters.containsKey(ParameterNamesIms.REGISTRATION_STATE))
            retval.append(SEMICOLON).append(ParameterNamesIms.REGISTRATION_STATE).append(EQUALS)
            .append(this.getRegistrationState());

        if(parameters.containsKey(ParameterNamesIms.SESSION_CASE))
            retval.append(SEMICOLON).append(ParameterNamesIms.SESSION_CASE).append(EQUALS)
            .append(this.getSessionCase());

        return retval.toString();
    }

    public void setValue(String value) throws ParseException {
        throw new ParseException(value,0);

    }

    public boolean equals(Object other)
    {
         if(other instanceof PServedUser)
         {
            final PServedUserHeader psu = (PServedUserHeader)other;
            return this.getAddress().equals(((PServedUser) other).getAddress());
         }
        return false;
    }


    public Object clone() {
        PServedUser retval = (PServedUser) super.clone();
        return retval;
    }

}
