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

/**
 *
 * @author aayush.bhatnagar
 * Rancore Technologies Pvt Ltd, Mumbai India.
 *
 * The ABNF of the P-Served-User Header is as follows:
 *
 * P-Served-User              = "P-Served-User" HCOLON PServedUser-value
 *                              *(SEMI served-user-param)
 * served-user-param          = sessioncase-param
 *                              / registration-state-param
 *                              / generic-param
 * PServedUser-value          = name-addr / addr-spec
 * sessioncase-param          = "sescase" EQUAL "orig" / "term"
 * registration-state-param   = "regstate" EQUAL "unreg" / "reg"
 *
 * Eg: P-Served-User: <sip:aayush@rancore.com>; sescase=orig; regstate=reg
 *
 *
 */
public interface PServedUserHeader {

    public static final String NAME = "P-Served-User";

    public void setSessionCase(String sessionCase);

    public String getSessionCase();

    public void setRegistrationState(String registrationState);

    public String getRegistrationState();


}
