/*
 * This code has been contributed by the authors to the public domain.
 */
package gov.nist.javax.sip.header;

import javax.sip.header.ViaHeader;


/**
 * @author jean.deruelle@gmail.com
 *
 */
public interface ViaHeaderExt extends ViaHeader {
    /**
     * Returns hostname:port as a string equivalent to the "sent-by" field
     * @return "sent-by" field
     * @since 2.0
     */
    public String getSentByField();
    /**
     * Returns transport to the "sent-protocol" field
     * @return "sent-protocol" field
     * @since 2.0
     */
    public String getSentProtocolField();
}
