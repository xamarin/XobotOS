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
* Product of NIST/ITL Advanced Networking Technologies Division (ANTD)         *
*******************************************************************************/
package gov.nist.javax.sip;

import gov.nist.javax.sip.header.*;

/**
 * Default constants for SIP.
 * @version 1.2 $Revision: 1.9 $ $Date: 2009/07/17 18:57:20 $
 */
public interface SIPConstants
    extends
        SIPHeaderNames,
        gov.nist.javax.sip.address.ParameterNames,
        gov.nist.javax.sip.header.ParameterNames {
    public static final int DEFAULT_PORT = 5060;

    // Added by Daniel J. Martinez Manzano <dani@dif.um.es>
    public static final int DEFAULT_TLS_PORT = 5061;

    /**
     * Prefix for the branch parameter that identifies
     * BIS 09 compatible branch strings. This indicates
     * that the branch may be as a global identifier for
     * identifying transactions.
     */
    public static final String BRANCH_MAGIC_COOKIE = "z9hG4bK";

    public static final String BRANCH_MAGIC_COOKIE_LOWER_CASE = "z9hg4bk";

    public static final String BRANCH_MAGIC_COOKIE_UPPER_CASE = "Z9HG4BK";

    /**
     * constant SIP_VERSION_STRING
     */
    public static final String SIP_VERSION_STRING = "SIP/2.0";
}
