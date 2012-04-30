/* This file is auto-generated.  DO NOT MODIFY.
 * Source file: frameworks/base/telephony/java/com/android/internal/telephony/EventLogTags.logtags
 */

package com.android.internal.telephony;;

/**
 * @hide
 */
public class EventLogTags {
  private EventLogTags() { }  // don't instantiate

  /** 50100 pdp_bad_dns_address (dns_address|3) */
  public static final int PDP_BAD_DNS_ADDRESS = 50100;

  /** 50101 pdp_radio_reset_countdown_triggered (out_packet_count|1|1) */
  public static final int PDP_RADIO_RESET_COUNTDOWN_TRIGGERED = 50101;

  /** 50102 pdp_radio_reset (out_packet_count|1|1) */
  public static final int PDP_RADIO_RESET = 50102;

  /** 50103 pdp_context_reset (out_packet_count|1|1) */
  public static final int PDP_CONTEXT_RESET = 50103;

  /** 50104 pdp_reregister_network (out_packet_count|1|1) */
  public static final int PDP_REREGISTER_NETWORK = 50104;

  /** 50105 pdp_setup_fail (cause|1|5), (cid|1|5), (network_type|1|5) */
  public static final int PDP_SETUP_FAIL = 50105;

  /** 50106 call_drop (cause|1|5), (cid|1|5), (network_type|1|5) */
  public static final int CALL_DROP = 50106;

  /** 50107 data_network_registration_fail (op_numeric|1|5), (cid|1|5) */
  public static final int DATA_NETWORK_REGISTRATION_FAIL = 50107;

  /** 50108 data_network_status_on_radio_off (dc_state|3), (enable|1|5) */
  public static final int DATA_NETWORK_STATUS_ON_RADIO_OFF = 50108;

  /** 50109 pdp_network_drop (cid|1|5), (network_type|1|5) */
  public static final int PDP_NETWORK_DROP = 50109;

  /** 50110 cdma_data_setup_failed (cause|1|5), (cid|1|5), (network_type|1|5) */
  public static final int CDMA_DATA_SETUP_FAILED = 50110;

  /** 50111 cdma_data_drop (cid|1|5), (network_type|1|5) */
  public static final int CDMA_DATA_DROP = 50111;

  /** 50112 gsm_rat_switched (cid|1|5), (network_from|1|5), (network_to|1|5) */
  public static final int GSM_RAT_SWITCHED = 50112;

  /** 50113 gsm_data_state_change (oldState|3), (newState|3) */
  public static final int GSM_DATA_STATE_CHANGE = 50113;

  /** 50114 gsm_service_state_change (oldState|1|5), (oldGprsState|1|5), (newState|1|5), (newGprsState|1|5) */
  public static final int GSM_SERVICE_STATE_CHANGE = 50114;

  /** 50115 cdma_data_state_change (oldState|3), (newState|3) */
  public static final int CDMA_DATA_STATE_CHANGE = 50115;

  /** 50116 cdma_service_state_change (oldState|1|5), (oldDataState|1|5), (newState|1|5), (newDataState|1|5) */
  public static final int CDMA_SERVICE_STATE_CHANGE = 50116;

  /** 50117 bad_ip_address (ip_address|3) */
  public static final int BAD_IP_ADDRESS = 50117;

  public static void writePdpBadDnsAddress(String dnsAddress) {
    android.util.EventLog.writeEvent(PDP_BAD_DNS_ADDRESS, dnsAddress);
  }

  public static void writePdpRadioResetCountdownTriggered(int outPacketCount) {
    android.util.EventLog.writeEvent(PDP_RADIO_RESET_COUNTDOWN_TRIGGERED, outPacketCount);
  }

  public static void writePdpRadioReset(int outPacketCount) {
    android.util.EventLog.writeEvent(PDP_RADIO_RESET, outPacketCount);
  }

  public static void writePdpContextReset(int outPacketCount) {
    android.util.EventLog.writeEvent(PDP_CONTEXT_RESET, outPacketCount);
  }

  public static void writePdpReregisterNetwork(int outPacketCount) {
    android.util.EventLog.writeEvent(PDP_REREGISTER_NETWORK, outPacketCount);
  }

  public static void writePdpSetupFail(int cause, int cid, int networkType) {
    android.util.EventLog.writeEvent(PDP_SETUP_FAIL, cause, cid, networkType);
  }

  public static void writeCallDrop(int cause, int cid, int networkType) {
    android.util.EventLog.writeEvent(CALL_DROP, cause, cid, networkType);
  }

  public static void writeDataNetworkRegistrationFail(int opNumeric, int cid) {
    android.util.EventLog.writeEvent(DATA_NETWORK_REGISTRATION_FAIL, opNumeric, cid);
  }

  public static void writeDataNetworkStatusOnRadioOff(String dcState, int enable) {
    android.util.EventLog.writeEvent(DATA_NETWORK_STATUS_ON_RADIO_OFF, dcState, enable);
  }

  public static void writePdpNetworkDrop(int cid, int networkType) {
    android.util.EventLog.writeEvent(PDP_NETWORK_DROP, cid, networkType);
  }

  public static void writeCdmaDataSetupFailed(int cause, int cid, int networkType) {
    android.util.EventLog.writeEvent(CDMA_DATA_SETUP_FAILED, cause, cid, networkType);
  }

  public static void writeCdmaDataDrop(int cid, int networkType) {
    android.util.EventLog.writeEvent(CDMA_DATA_DROP, cid, networkType);
  }

  public static void writeGsmRatSwitched(int cid, int networkFrom, int networkTo) {
    android.util.EventLog.writeEvent(GSM_RAT_SWITCHED, cid, networkFrom, networkTo);
  }

  public static void writeGsmDataStateChange(String oldstate, String newstate) {
    android.util.EventLog.writeEvent(GSM_DATA_STATE_CHANGE, oldstate, newstate);
  }

  public static void writeGsmServiceStateChange(int oldstate, int oldgprsstate, int newstate, int newgprsstate) {
    android.util.EventLog.writeEvent(GSM_SERVICE_STATE_CHANGE, oldstate, oldgprsstate, newstate, newgprsstate);
  }

  public static void writeCdmaDataStateChange(String oldstate, String newstate) {
    android.util.EventLog.writeEvent(CDMA_DATA_STATE_CHANGE, oldstate, newstate);
  }

  public static void writeCdmaServiceStateChange(int oldstate, int olddatastate, int newstate, int newdatastate) {
    android.util.EventLog.writeEvent(CDMA_SERVICE_STATE_CHANGE, oldstate, olddatastate, newstate, newdatastate);
  }

  public static void writeBadIpAddress(String ipAddress) {
    android.util.EventLog.writeEvent(BAD_IP_ADDRESS, ipAddress);
  }
}
