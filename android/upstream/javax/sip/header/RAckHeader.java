package javax.sip.header;

import java.text.ParseException;
import javax.sip.InvalidArgumentException;

public interface RAckHeader extends Header {
    String NAME = "RAck";

    String getMethod();
    void setMethod(String method) throws ParseException;

    long getCSequenceNumber();
    void setCSequenceNumber(long cSequenceNumber) throws InvalidArgumentException;

    long getRSequenceNumber();
    void setRSequenceNumber(long rSequenceNumber) throws InvalidArgumentException;

    /**
     * @deprecated
     * @see #getCSequenceNumber()
     */
    int getCSeqNumber();
    /**
     * @deprecated
     * @see #setCSequenceNumber(long)
     */
    void setCSeqNumber(int cSeqNumber) throws InvalidArgumentException;

    /**
     * @deprecated
     * @see #getRSequenceNumber()
     */
    int getRSeqNumber();
    /**
     * @deprecated
     * @see #setRSequenceNumber(long)
     */
    void setRSeqNumber(int rSeqNumber) throws InvalidArgumentException;
}
