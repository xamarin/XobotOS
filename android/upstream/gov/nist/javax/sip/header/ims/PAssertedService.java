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
import gov.nist.javax.sip.header.SIPHeader;
import javax.sip.header.ExtensionHeader;
/**
 *
 * @author aayush.bhatnagar
 * Rancore Technologies Pvt Ltd, Mumbai India.
 *
 */
public class PAssertedService extends SIPHeader implements PAssertedServiceHeader, SIPHeaderNamesIms, ExtensionHeader{

    private String subServiceIds;
    private String subAppIds;

    protected PAssertedService(String name) {
        super(NAME);
    }

    public PAssertedService()
    {
        super(P_ASSERTED_SERVICE);
    }

    @Override
    protected String encodeBody() {
        StringBuffer retval = new StringBuffer();

         retval.append(ParameterNamesIms.SERVICE_ID);

            if(this.subServiceIds!=null)
            {
                retval.append(ParameterNamesIms.SERVICE_ID_LABEL).append(".");

            retval.append(this.getSubserviceIdentifiers());
            }

            else if(this.subAppIds!=null)
            {
                retval.append(ParameterNamesIms.APPLICATION_ID_LABEL).append(".");
                retval.append(this.getApplicationIdentifiers());
            }

        return retval.toString();
    }

    public void setValue(String value) throws ParseException {
        throw new ParseException(value,0);

    }

    public String getApplicationIdentifiers() {
        if(this.subAppIds.charAt(0)=='.')
        {
            return this.subAppIds.substring(1);
        }
        return this.subAppIds;
    }

    public String getSubserviceIdentifiers() {
        if(this.subServiceIds.charAt(0)=='.')
        {
            return this.subServiceIds.substring(1);
        }
        return this.subServiceIds;
    }
    public void setApplicationIdentifiers(String appids) {
        this.subAppIds = appids;

    }

    public void setSubserviceIdentifiers(String subservices) {
        this.subServiceIds = subservices;

    }

    public boolean equals(Object other)
    {
        return (other instanceof PAssertedServiceHeader) && super.equals(other);

    }


    public Object clone() {
        PAssertedService retval = (PAssertedService) super.clone();
        return retval;
    }


}
