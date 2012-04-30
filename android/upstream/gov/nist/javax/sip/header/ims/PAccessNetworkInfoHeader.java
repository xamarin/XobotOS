/*
* Conditions Of Use
*
* This software was developed by employees of the National Institute of
* Standards and Technology (NIST), an agency of the Federal Government
* and others.
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
* of the terms of this agreement.
*
*/

/*******************************************
 * PRODUCT OF PT INOVACAO - EST DEPARTMENT *
 *******************************************/


package gov.nist.javax.sip.header.ims;


import java.text.ParseException;
import javax.sip.header.Header;
import javax.sip.header.Parameters;


/**
 * <p>P-Access-Network-Info SIP P-Header </p>
 * <p>This header carries information relating to the access network between
 * the UAC and its serving proxy in the home network.</p>
 *
 * <p>IETF RFC3455 + 3GPP TS 24.229-720 (2005-12)</p>
 * <p>Sintax: </p>
 * <pre>
 * P-Access-Network-Info  = "P-Access-Network-Info": access-type *(; access-info)
 *
 * access-type    = "IEEE-802.11a" / "IEEE-802.11b" / "3GPP-GERAN" / "3GPP-UTRAN-FDD" /
 *                   "3GPP-UTRAN-TDD" / "ADSL" / "ADSL2" / "ADSL2+" / "RADSL" / "SDSL" /
 *                   "HDSL" / "HDSL2" / "G.SHDSL" / "VDSL" / "IDSL" / "3GPP2-1X" /
 *                   "3GPP2-1XHRPD" /token
 *
 * access-info            = cgi-3gpp / utran-cell-id-3gpp / dsl-location /
 *                          ci-3gpp2 / extension-access-info
 * cgi-3gpp               = "cgi-3gpp" EQUAL (token / quoted-string)
 * utran-cell-id-3gpp     = "utran-cell-id-3gpp" EQUAL (token / quoted-string)
 * dsl-location           = "dsl-location" EQUAL (token / quoted-string)
 * ci-3gpp2               = "ci-3gpp2" EQUAL (token / quoted-string)
 * extension-access-info  = gen-value
 * gen-value              = token / host / quoted-string
 * </pre>
 *
 * @author Miguel Freitas (IT) PT-Inovacao
 */


public interface PAccessNetworkInfoHeader extends Parameters, Header
{

    public final static String NAME = "P-Access-Network-Info";

    // access type
    public static final String IEEE_802_11 = "IEEE-802.11";
    public static final String IEEE_802_11A = "IEEE-802.11a";
    public static final String IEEE_802_11B = "IEEE-802.11b";
    public static final String IEEE_802_11G = "IEEE-802.11g";
    public static final String GGGPP_GERAN = "3GPP-GERAN";
    public static final String GGGPP_UTRAN_FDD = "3GPP-UTRAN-FDD";
    public static final String GGGPP_UTRAN_TDD = "3GPP-UTRAN-TDD";
    public static final String GGGPP_CDMA2000 = "3GPP-CDMA2000";
    public static final String ADSL = "ADSL";
    public static final String ADSL2 = "ADSL2";
    public static final String ADSL2p = "ADSL2+";
    public static final String RADSL = "RADSL";
    public static final String SDSL = "SDSL";
    public static final String HDSL = "HDSL";
    public static final String HDSL2 = "HDSL2";
    public static final String GSHDSL = "G.SHDSL";
    public static final String VDSL = "VDSL";
    public static final String IDSL = "IDSL";
    public static final String GGGPP2_1X = "3GPP2-1X";
    public static final String GGGPP2_1XHRPD = "3GPP2-1XHRPD";



    public void setAccessType(String accessTypeVal) throws ParseException;
    public String getAccessType();


    public void setCGI3GPP(String cgi) throws ParseException;
    public String getCGI3GPP();


    public void setUtranCellID3GPP(String utranCellID) throws ParseException;
    public String getUtranCellID3GPP();


    public void setDSLLocation(String dslLocation) throws ParseException;
    public String getDSLLocation();


    public void setCI3GPP2(String ci2Gpp2) throws ParseException;
    public String getCI3GPP2();


    public void setExtensionAccessInfo(Object extendAccessInfo) throws ParseException;
    public Object getExtensionAccessInfo();




}
