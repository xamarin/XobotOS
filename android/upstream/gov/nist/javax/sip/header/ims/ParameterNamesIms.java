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
/*******************************************
 * PRODUCT OF PT INOVAO - EST DEPARTMENT *
 *******************************************/
package gov.nist.javax.sip.header.ims;

import gov.nist.javax.sip.address.ParameterNames;

/**
 * @author ALEXANDRE MIGUEL SILVA SANTOS - Nú 10045401
 */
public interface ParameterNamesIms extends ParameterNames {

    public static final String IK = "ik";
    public static final String CK = "ck";
    public static final String INTEGRITY_PROTECTED = "integrity-protected";
    public static final String CCF = "ccf";
    public static final String ECF = "ecf";
    public static final String ICID_VALUE = "icid-value";
    public static final String ICID_GENERATED_AT = "icid-generated-at";
    public static final String ORIG_IOI = "orig-ioi";
    public static final String TERM_IOI = "term-ioi";

    // issued by Miguel Freitas //
    // P-Access-Network-ID
    public static final String CGI_3GPP = "cgi-3gpp";
    public static final String UTRAN_CELL_ID_3GPP = "utran-cell-id-3gpp";
    public static final String DSL_LOCATION = "dsl-location";
    public static final String CI_3GPP2 = "ci-3gpp2";
    // P-Charging-Vector
    public static final String GGSN = "ggsn";
    public static final String PDP_INFO = "pdp-info";
    public static final String PDP_ITEM = "pdp-item";
    public static final String PDP_SIG = "pdp-sig";
    public static final String GCID = "gcid";
    public static final String AUTH_TOKEN = "auth-token";
    public static final String FLOW_ID = "flow-id";
    public static final String PDG = "pdg";
    public static final String BRAS = "bras";
    public static final String DSL_BEARER_INFO = "dsl-bearer-info";
    public static final String DSL_BEARER_ITEM = "dsl-bearer-item";
    public static final String DSL_BEARER_SIG = "dsl-bearer-sig";

    // sec-agree (Security-Server, Security-Client, Security-Verify)
    public static final String ALG    = "alg";
    public static final String EALG   = "ealg";
    public static final String Q      = "q";
    public static final String PROT   = "prot";
    public static final String MOD    = "mod";
    public static final String SPI_C  = "spi-c";
    public static final String SPI_S  = "spi-s";
    public static final String PORT_C = "port-c";
    public static final String PORT_S = "port-s";
    public static final String D_VER  = "d-ver";
    // end //

    //added by aayush.bhatnagar(Ref: RFC 5502)
    public static final String SESSION_CASE = "sescase";
    public static final String REGISTRATION_STATE = "regstate";

    //added by aayush.bhatnagar(Ref: draft-drage-sipping-service-identification-03)
    public static final String SERVICE_ID = "urn:urn-7:";
    public static final String SERVICE_ID_LABEL = "3gpp-service";
    public static final String APPLICATION_ID_LABEL = "3gpp-application";


}
