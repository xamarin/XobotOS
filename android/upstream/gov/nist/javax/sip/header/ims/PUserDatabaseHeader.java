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
import javax.sip.header.Header;
import javax.sip.header.Parameters;
/**
 *
 * @author aayush.bhatnagar
 * Rancore Technologies Pvt Ltd, Mumbai India.
 *
 * This is the interface that exposes the behavior
 * of the P-User-Database header. We only have one
 * major value for this header, as per RFC 4457.
 * This value is the Database name. The DB here refers
 * to the IMS HSS. The DB name is encoded as a URI, delimited
 * by the < and > signs. There may be generic parameters for
 * this header encoded as URI parameters. They also lie between
 * the < and > delimiters. However, this URI is neither a SIP URI
 * nor a TEL URI. It is a DIAMETER AAA URI.The value of this AAA URI
 * is consumed by the S-CSCF. The S-CSCF can cache the value of the
 * HSS received in this header,thus optimizing the IMS registration
 * process.
 *
 */
public interface PUserDatabaseHeader extends Parameters,Header
{
    public final static String NAME = "P-User-Database";

    public String getDatabaseName();

    public void setDatabaseName(String name);



}
