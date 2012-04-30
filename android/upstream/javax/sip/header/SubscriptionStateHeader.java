package javax.sip.header;

import java.text.ParseException;
import javax.sip.InvalidArgumentException;

public interface SubscriptionStateHeader extends ExpiresHeader, Parameters {
    String NAME = "Subscription-State";

    String DEACTIVATED = "Deactivated";
    String GIVE_UP = "Give-Up";
    String NO_RESOURCE = "No-Resource";
    String PROBATION = "Probation";
    String REJECTED = "Rejected";
    String TIMEOUT = "Timeout";
    String UNKNOWN = "Unknown";

    String ACTIVE = "Active";
    String PENDING = "Pending";
    String TERMINATED = "Terminated";

    String getReasonCode();
    void setReasonCode(String reasonCode) throws ParseException;

    int getRetryAfter();
    void setRetryAfter(int retryAfter) throws InvalidArgumentException;

    String getState();
    void setState(String state) throws ParseException;
}
