package gov.nist.core;

public interface LogLevels {
    /*
     * Each of these levels must be mapped internally to logically equivalent
     * logging levels in your logger.
     */
    public static final int TRACE_NONE  =  0;
    public static final int TRACE_FATAL =  2;
    public static final int TRACE_ERROR =  4;
    public static final int TRACE_WARN  =  8;
    public static final int TRACE_INFO  = 16;
    public static final int TRACE_DEBUG = 32;
    public static final int TRACE_TRACE = 64;
    public static final int TRACE_MESSAGES = TRACE_INFO;
    public static final int TRACE_EXCEPTION = TRACE_ERROR;
    
}
