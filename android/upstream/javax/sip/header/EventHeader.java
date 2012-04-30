package javax.sip.header;

import java.text.ParseException;

public interface EventHeader extends Header, Parameters {
    String NAME = "Event";

    String getEventId();
    void setEventId(String eventId) throws ParseException;

    String getEventType();
    void setEventType(String eventType) throws ParseException;
}
