package javax.sip;

public enum DialogState {
    EARLY,
    CONFIRMED,
    TERMINATED;

    public static final int _EARLY = EARLY.ordinal();
    public static final int _CONFIRMED = CONFIRMED.ordinal();
    public static final int _TERMINATED = TERMINATED.ordinal();

    public static DialogState getObject(int state) {
        try {
            return values()[state];
        } catch (IndexOutOfBoundsException e) {
            throw new IllegalArgumentException(
                    "Invalid dialog state: " + state);
        }
    }

    public int getValue() {
        return ordinal();
    }
}
