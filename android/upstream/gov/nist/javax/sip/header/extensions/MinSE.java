/*******************************************************************************
* Product of NIST/ITL Advanced Networking Technologies Division (ANTD).        *
*******************************************************************************/
/*
* This code has been contributed by the author to the public domain.
*/
package gov.nist.javax.sip.header.extensions;

import java.text.ParseException;
import gov.nist.javax.sip.header.*;

import javax.sip.*;
import javax.sip.header.ExtensionHeader;

/**
 * MinSE SIP Header.
 *
 * (Created by modifying Expires.java)
 *
 * @version JAIN-SIP-1.1 $Revision: 1.4 $ $Date: 2009/10/18 13:46:36 $
 *
 * @author P. Musgrave <pmusgrave@newheights.com>  <br/>
 *
 */
public class MinSE
    extends ParametersHeader implements ExtensionHeader, MinSEHeader {

    // TODO: When the MinSEHeader is added to javax - move this there...pmusgrave
    public static final String NAME = "Min-SE";

    /**
     * Comment for <code>serialVersionUID</code>
     */
    private static final long serialVersionUID = 3134344915465784267L;

    /** expires field
     */
    public int expires;

    /** default constructor
     */
    public MinSE() {
        super(NAME);
    }

    /**
     * Return canonical form.
     * @return String
     */
    public String encodeBody() {
        String retval = Integer.toString(expires); // seems overkill - but Expires did this.

        if (!parameters.isEmpty()) {
            retval += SEMICOLON + parameters.encode();
        }
        return retval;
    }

    public void setValue(String value) throws ParseException {
        // not implemented.
        throw new ParseException(value,0);

    }

    /**
     * Gets the expires value of the ExpiresHeader. This expires value is
     *
     * relative time.
     *
     *
     *
     * @return the expires value of the ExpiresHeader.
     *
     * @since JAIN SIP v1.1
     *
     */
    public int getExpires() {
        return expires;
    }

    /**
     * Sets the relative expires value of the ExpiresHeader.
     * The expires value MUST be greater than zero and MUST be
     * less than 2**31.
     *
     * @param expires - the new expires value of this ExpiresHeader
     *
     * @throws InvalidArgumentException if supplied value is less than zero.
     *
     * @since JAIN SIP v1.2
     *
     */
    public void setExpires(int expires) throws InvalidArgumentException {
        if (expires < 0)
            throw new InvalidArgumentException("bad argument " + expires);
        this.expires = expires;
    }
}
