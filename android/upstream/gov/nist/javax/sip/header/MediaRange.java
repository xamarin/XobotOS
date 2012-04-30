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
* See ../../../../doc/uncopyright.html for conditions of use.                  *
* Author: M. Ranganathan (mranga@nist.gov)                                     *
* Modified By:  O. Deruelle (deruelle@nist.gov)                                *
* Questions/Comments: nist-sip-dev@antd.nist.gov                               *
*******************************************************************************/
package gov.nist.javax.sip.header;

/**
*   Media Range
* @see Accept
* @since 0.9
* @version 1.2 $Revision: 1.6 $ $Date: 2009/07/17 18:57:32 $
* <pre>
* Revisions:
*
* Version 1.0
*    1. Added encode method.
*
* media-range    = ( "STAR/STAR"
*                        | ( type "/" STAR )
*                        | ( type "/" subtype )
*                        ) *( ";" parameter )
*
* HTTP RFC 2616 Section 14.1
* </pre>
*/
public class MediaRange extends SIPObject {

    /**
     * Comment for <code>serialVersionUID</code>
     */
    private static final long serialVersionUID = -6297125815438079210L;

    /** type field
     */
    protected String type;

    /** subtype field
     */
    protected String subtype;

    /** Default constructor
     */
    public MediaRange() {
    }

    /** get type field
     * @return String
     */
    public String getType() {
        return type;
    }

    /** get the subType field.
     * @return String
     */
    public String getSubtype() {
        return subtype;
    }

    /**
     * Set the type member
     * @param t String to set
     */
    public void setType(String t) {
        type = t;
    }

    /**
     * Set the subtype member
     * @param s String to set
     */
    public void setSubtype(String s) {
        subtype = s;
    }

    /**
     * Encode the object.
     * @return String
     */
    public String encode() {
        return encode(new StringBuffer()).toString();
    }

    public StringBuffer encode(StringBuffer buffer) {
        return buffer.append(type)
                .append(SLASH)
                .append(subtype);
    }
}
