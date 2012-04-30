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
import javax.sip.header.ExtensionHeader;

/**
 *
 * @author aayush.bhatnagar
 * Rancore Technologies Pvt Ltd, Mumbai India.
 *
 */
public class PUserDatabase extends gov.nist.javax.sip.header.ParametersHeader  implements PUserDatabaseHeader,SIPHeaderNamesIms, ExtensionHeader{

    private String databaseName;

    /**
     *
     * @param databaseName
     */
    public PUserDatabase(String databaseName)
    {
        super(NAME);
        this.databaseName = databaseName;
    }

    /**
     * Default constructor.
     */
    public PUserDatabase() {
        super(P_USER_DATABASE);
    }

    public String getDatabaseName() {

        return this.databaseName;
    }


    public void setDatabaseName(String databaseName) {
        if((databaseName==null)||(databaseName.equals(" ")))
            throw new NullPointerException("Database name is null");
        else
            if(!databaseName.contains("aaa://"))
        this.databaseName = new StringBuffer().append("aaa://").append(databaseName).toString();
            else
                this.databaseName = databaseName;

    }

    protected String encodeBody() {

        StringBuffer retval = new StringBuffer();
        retval.append("<");
        if(getDatabaseName()!=null)
        retval.append(getDatabaseName());

        if (!parameters.isEmpty())
            retval.append(SEMICOLON + this.parameters.encode());
        retval.append(">");

        return retval.toString();
    }

    public boolean equals(Object other)
    {
        return (other instanceof PUserDatabaseHeader) && super.equals(other);

    }


    public Object clone() {
        PUserDatabase retval = (PUserDatabase) super.clone();
        return retval;
    }

    public void setValue(String value) throws ParseException {
        throw new ParseException(value,0);

    }



}
