package gov.nist.core;

import java.util.Properties;


/**
 * interface that loggers should implement so that the stack can log to various
 * loggers impl such as log4j, commons logging, sl4j, ...
 * @author jean.deruelle@gmail.com
 *
 */
public interface StackLogger extends LogLevels {

    /**
     * log a stack trace. This helps to look at the stack frame.
     */
	public void logStackTrace();
	
	/**
	 * Log a stack trace if the current logging level exceeds 
	 * given trace level.
	 * @param traceLevel
	 */
	public void logStackTrace(int traceLevel);
	
	/**
     * Get the line count in the log stream.
     *
     * @return
     */
	public int getLineCount();
	
	/**
     * Log an exception.
     *
     * @param ex
     */
    public void logException(Throwable ex);
    /**
     * Log a message into the log file.
     *
     * @param message
     *            message to log into the log file.
     */
    public void logDebug(String message);
    /**
     * Log a message into the log file.
     *
     * @param message
     *            message to log into the log file.
     */
    public void logTrace(String message);
    /**
     * Log an error message.
     *
     * @param message --
     *            error message to log.
     */
    public void logFatalError(String message);
    /**
     * Log an error message.
     *
     * @param message --
     *            error message to log.
     *
     */
    public void logError(String message);
    /**
     * @return flag to indicate if logging is enabled.
     */
    public boolean isLoggingEnabled();
    /**
     * Return true/false if loging is enabled at a given level.
     *
     * @param logLevel
     */
    public boolean isLoggingEnabled(int logLevel);
    /**
     * Log an error message.
     *
     * @param message
     * @param ex
     */
    public void logError(String message, Exception ex);
    /**
     * Log a warning mesasge.
     *
     * @param string
     */
    public void logWarning(String string);
    /**
     * Log an info message.
     *
     * @param string
     */
    public void logInfo(String string);
    
   
    /**
     * Disable logging altogether.
     *
     */
    public void disableLogging();

    /**
     * Enable logging (globally).
     */
    public void enableLogging();
    
    /**
     * Set the build time stamp. This is logged into the logging stream.
     */
    public void setBuildTimeStamp(String buildTimeStamp);
    
    /**
     * Stack creation properties.
     * @param stackProperties
     */
    
    public void setStackProperties(Properties stackProperties);
    
    /**
     * The category for the logger.
     * @return
     */
    public String getLoggerName();
    
    
   
}
