package gov.nist.javax.sip;


/**
 * The stack calls the message log factory to create logging records. The default implementatation
 * of this interface can be replaced using the gov.nist.javax.sip.LOG_RECORD_FACTORY property.
 * This override is provided to allow applications to log axuiliary information (such as environment
 * conditions etc) when messages are logged in the stack.
 *
 * @author M. Ranganathan
 *
 */
public interface LogRecordFactory {

    /**
     * Create a log record.
     *
     * @param message  -- the message to be logged.
     * @param source   -- host:port of the source of the message.
     * @param destination -- host:port of the destination of the message.
     * @param timeStamp  -- The time at which this message was seen by the stack or sent out by
     *                      the stack.
     * @param isSender   -- true if we are sending the message false otherwise.
     * @param firstLine  -- the first line of the message to be logged.
     * @param tid -- the transaction id
     * @param callId -- the call id
     * @param timestampVal -- the timestamp header value of the incoming message.
     *
     * @return -- a log record with the appropriate fields set.
     */


    public LogRecord createLogRecord(String message, String source,
            String destination, long timeStamp, boolean isSender,
            String firstLine, String tid, String callId, long timestampVal);

}
