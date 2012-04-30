
/*******************************************************************************
* Product of NIST/ITL Advanced Networking Technologies Division (ANTD).        *
*******************************************************************************/

package gov.nist.javax.sip.header.extensions;

import java.text.ParseException;

import javax.sip.header.ExtensionHeader;
import gov.nist.javax.sip.header.*;

import gov.nist.javax.sip.address.*;
/*
* This code has been contributed by the author to the public domain.
*/

/**
 * ReferredBy SIP Header. RFC 3892
 *
 * @version JAIN-SIP-1.2
 *
 * @author Peter Musgrave.
 *
 *
 */
public final class ReferredBy
    extends AddressParametersHeader implements ExtensionHeader, ReferredByHeader {

    // TODO: Need a unique UID
    private static final long serialVersionUID = 3134344915465784267L;

    // TODO: When the MinSEHeader is added to javax - move this there...pmusgrave
    public static final String NAME = "Referred-By";

    /** default Constructor.
     */
    public ReferredBy() {
        super(NAME);
    }

    public void setValue(String value) throws ParseException {
        // not implemented.
        throw new ParseException(value,0);

    }

    /**
     * Encode the header content into a String.
     * @return String
     */
    protected String encodeBody() {
        if (address == null)
            return null;
        String retval = "";
        if (address.getAddressType() == AddressImpl.ADDRESS_SPEC) {
            retval += LESS_THAN;
        }
        retval += address.encode();
        if (address.getAddressType() == AddressImpl.ADDRESS_SPEC) {
            retval += GREATER_THAN;
        }

        if (!parameters.isEmpty()) {
            retval += SEMICOLON + parameters.encode();
        }
        return retval;
    }
}
/*
 * $Log: ReferredBy.java,v $
 * Revision 1.3  2009/07/17 18:57:42  emcho
 * Converts indentation tabs to spaces so that we have a uniform indentation policy in the whole project.
 *
 * Revision 1.2  2006/10/27 20:58:31  mranga
 * Issue number:
 * Obtained from:
 * Submitted by:
 * Reviewed by:   mranga
 * doc fixups
 * CVS: ----------------------------------------------------------------------
 * CVS: Issue number:
 * CVS:   If this change addresses one or more issues,
 * CVS:   then enter the issue number(s) here.
 * CVS: Obtained from:
 * CVS:   If this change has been taken from another system,
 * CVS:   then name the system in this line, otherwise delete it.
 * CVS: Submitted by:
 * CVS:   If this code has been contributed to the project by someone else; i.e.,
 * CVS:   they sent us a patch or a set of diffs, then include their name/email
 * CVS:   address here. If this is your work then delete this line.
 * CVS: Reviewed by:
 * CVS:   If we are doing pre-commit code reviews and someone else has
 * CVS:   reviewed your changes, include their name(s) here.
 * CVS:   If you have not had it reviewed then delete this line.
 *
 * Revision 1.1  2006/10/12 11:57:52  pmusgrave
 * Issue number:  79, 80
 * Submitted by:  pmusgrave@newheights.com
 * Reviewed by:   mranga
 *
 * Revision 1.2  2006/03/20 20:52:03  pmusgrave
 * Add RefferedBy to header factory
 * Correct implements statement in ReferredBy
 *
 * Revision 1.1.1.1  2006/03/15 16:00:07  pmusgrave
 * Source with additions
 *
 * Revision 1.3  2004/01/22 13:26:29  sverker
 * Issue number:
 * Obtained from:
 * Submitted by:  sverker
 * Reviewed by:   mranga
 *
 * Major reformat of code to conform with style guide. Resolved compiler and javadoc warnings. Added CVS tags.
 *
 * CVS: ----------------------------------------------------------------------
 * CVS: Issue number:
 * CVS:   If this change addresses one or more issues,
 * CVS:   then enter the issue number(s) here.
 * CVS: Obtained from:
 * CVS:   If this change has been taken from another system,
 * CVS:   then name the system in this line, otherwise delete it.
 * CVS: Submitted by:
 * CVS:   If this code has been contributed to the project by someone else; i.e.,
 * CVS:   they sent us a patch or a set of diffs, then include their name/email
 * CVS:   address here. If this is your work then delete this line.
 * CVS: Reviewed by:
 * CVS:   If we are doing pre-commit code reviews and someone else has
 * CVS:   reviewed your changes, include their name(s) here.
 * CVS:   If you have not had it reviewed then delete this line.
 *
 */

