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
/*******************************************************************************
* Product of NIST/ITL Advanced Networking Technologies Division (ANTD).        *
*******************************************************************************/
package gov.nist.javax.sip.header;

import java.text.ParseException;

/**
 *  Protocol name and version.
 *
 * @version 1.2 $Revision: 1.8 $ $Date: 2009/07/17 18:57:33 $
 *
 * @author M. Ranganathan   <br/>
 *
 *
 *
 */
public class Protocol extends SIPObject {

    /**
     * Comment for <code>serialVersionUID</code>
     */
    private static final long serialVersionUID = 2216758055974073280L;

    /** protocolName field
     */
    protected String protocolName;

    /** protocolVersion field
     */
    protected String protocolVersion;

    /** transport field
     */
    protected String transport;

    /**
     * Return canonical form.
     * @return String
     */
    public String encode() {
        return encode(new StringBuffer()).toString();
    }

    public StringBuffer encode(StringBuffer buffer) {
        buffer.append(protocolName.toUpperCase())
                .append(SLASH)
                .append(protocolVersion)
                .append(SLASH)
                .append(transport.toUpperCase());

        return buffer;
    }

    /** get the protocol name
     * @return String
     */
    public String getProtocolName() {
        return protocolName;
    }

    /** get the protocol version
     * @return String
     */
    public String getProtocolVersion() {
        return protocolVersion;
    }

    /**
     * Get the protocol name + version
     * JvB: This is what is returned in the ViaHeader interface for 'getProtocol()'
     *
     * @return String : protocolname + '/' + version
     */
    public String getProtocol() {
        return protocolName + '/' + protocolVersion;
    }

    public void setProtocol( String name_and_version ) throws ParseException {
        int slash = name_and_version.indexOf('/');
        if (slash>0) {
            this.protocolName = name_and_version.substring(0,slash);
            this.protocolVersion = name_and_version.substring( slash+1 );
        } else throw new ParseException( "Missing '/' in protocol", 0 );
    }

    /** get the transport
     * @return String
     */
    public String getTransport() {
        return transport;
    }

    /**
         * Set the protocolName member
         * @param p String to set
         */
    public void setProtocolName(String p) {
        protocolName = p;
    }

    /**
         * Set the protocolVersion member
         * @param p String to set
         */
    public void setProtocolVersion(String p) {
        protocolVersion = p;
    }

    /**
         * Set the transport member
         * @param t String to set
         */
    public void setTransport(String t) {
        transport = t;
    }

    /**
    * Default constructor.
    */
    public Protocol() {
        protocolName = "SIP";
        protocolVersion = "2.0";
        transport = "UDP";
    }
}
/*
 * $Log: Protocol.java,v $
 * Revision 1.8  2009/07/17 18:57:33  emcho
 * Converts indentation tabs to spaces so that we have a uniform indentation policy in the whole project.
 *
 * Revision 1.7  2007/02/12 15:19:23  belangery
 * Changed the encode() and encodeBody() methods of SIP headers and basic classes to make them use the same StringBuffer instance during the encoding phase.
 *
 * Revision 1.6  2006/07/13 09:01:24  mranga
 * Issue number:
 * Obtained from:
 * Submitted by:  jeroen van bemmel
 * Reviewed by:   mranga
 * Moved some changes from jain-sip-1.2 to java.net
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
 * Revision 1.4  2006/06/19 06:47:26  mranga
 * javadoc fixups
 *
 * Revision 1.3  2006/06/16 15:26:28  mranga
 * Added NIST disclaimer to all public domain files. Clean up some javadoc. Fixed a leak
 *
 * Revision 1.2  2005/10/09 18:47:53  jeroen
 * defined equals() in terms of API calls
 *
 * Revision 1.1.1.1  2005/10/04 17:12:35  mranga
 *
 * Import
 *
 *
 * Revision 1.2  2004/01/22 13:26:29  sverker
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
