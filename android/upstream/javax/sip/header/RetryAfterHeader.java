package javax.sip.header;

import java.text.ParseException;
import javax.sip.InvalidArgumentException;

public interface RetryAfterHeader extends Header, Parameters {
    String NAME = "Retry-After";

    String getComment();
    void setComment(String comment) throws ParseException;
    boolean hasComment();
    void removeComment();

    int getDuration();
    void setDuration(int duration) throws InvalidArgumentException;
    void removeDuration();

    int getRetryAfter();
    void setRetryAfter(int retryAfter) throws InvalidArgumentException;
}
