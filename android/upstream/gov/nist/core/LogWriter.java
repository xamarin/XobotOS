/*
 * Conditions Of Use
 *
 * This software was developed by employees of the National Institute of
 * Standards and Technology (NIST), an agency of the Federal Government.
 * Pursuant to title 15 Untied States Code Section 105, works of NIST
 * employees are not subject to copyright protection in the United States
 * and are considered to be in the public domain.  As a result, a formal
 * license is not needed to use the software.
 *
 * This software is provided by NIST as a service and is expressly
 * provided "AS IS."  NIST MAKES NO WARRANTY OF ANY KIND, EXPRESS, IMPLIED
 * OR STATUTORY, INCLUDING, WITHOUT LIMITATION, THE IMPLIED WARRANTY OF
 * MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE, NON-INFRINGEMENT
 * AND DATA ACCURACY.  NIST does not warrant or make any representations
 * regarding the use of the software or the results thereof, including but
 * not limited to the correctness, accuracy, reliability or usefulness of
 * the software.
 *
 * Permission to use this software is contingent upon your acceptance
 * of the terms of this agreement.
 *
 */
/***************************************************************************
 * Product of NIST/ITL Advanced Networking Technologies Division (ANTD).    *
 ***************************************************************************/
package gov.nist.core;

import java.io.*;
import java.util.Properties;

// BEGIN ANDROID-added
// TODO: this class should be replaced by android logging mechanism.
public class LogWriter implements StackLogger {
    private static final String TAG = "SIP_STACK";

    private boolean mEnabled = true;

    public void logStackTrace() {
        // TODO
    }

    public void logStackTrace(int traceLevel) {
        // TODO
    }

    public int getLineCount() {
        return 0;
    }

    public void logException(Throwable ex) {
        //Log.e(TAG, "", ex);
    }
    public void logDebug(String message) {
        //Log.d(TAG, message);
    }
    public void logTrace(String message) {
        //Log.d(TAG, message);
    }
    public void logFatalError(String message) {
        //Log.e(TAG, message);
    }
    public void logError(String message) {
        //Log.e(TAG, message);
    }
    public boolean isLoggingEnabled() {
        return mEnabled;
    }
    public boolean isLoggingEnabled(int logLevel) {
        // TODO
        return mEnabled;
    }
    public void logError(String message, Exception ex) {
        //Log.e(TAG, message, ex);
    }
    public void logWarning(String string) {
        //Log.w(TAG, string);
    }
    public void logInfo(String string) {
        //Log.i(TAG, string);
    }

    public void disableLogging() {
        mEnabled = false;
    }

    public void enableLogging() {
        mEnabled = true;
    }

    public void setBuildTimeStamp(String buildTimeStamp) {
    }

    public void setStackProperties(Properties stackProperties) {
    }

    public String getLoggerName() {
        return "Android SIP Logger";
    }
}
// END android-added

// BEGIN android-deleted

//import org.apache.log4j.Appender;
//import org.apache.log4j.FileAppender;
//import org.apache.log4j.Level;
//import org.apache.log4j.Logger;
//import org.apache.log4j.Priority;
//import org.apache.log4j.SimpleLayout;
//
///**
// * A wrapper around log4j that is used for logging debug and errors. You can
// * replace this file if you want to change the way in which messages are logged.
// *
// * @version 1.2
// *
// * @author M. Ranganathan <br/>
// * @author M.Andrews
// * @author Jeroen van Bemmel
// * @author Jean Deruelle
// *
// */
//
//public class LogWriter implements StackLogger {
//
//    /**
//     * The logger to which we will write our logging output.
//     */
//    private Logger logger;
//
//    /**
//     * The stack name.
//     */
//    private String stackName;
//
//    /**
//     * Name of the log file in which the trace is written out (default is
//     * /tmp/sipserverlog.txt)
//     */
//    private String logFileName = null;
//
//    /**
//     * Flag to indicate that logging is enabled.
//     */
//    private volatile boolean needsLogging = false;
//
//    private int lineCount;
//
//    /**
//     * trace level
//     */
//
//    protected int traceLevel = TRACE_NONE;
//
//    private String buildTimeStamp;
//
//    private Properties configurationProperties;
//
//    /**
//     * log a stack trace. This helps to look at the stack frame.
//     */
//    public void logStackTrace() {
//        this.logStackTrace(TRACE_DEBUG);
//
//    }
//
//    public void logStackTrace(int traceLevel) {
//        if (needsLogging) {
//            StringWriter sw = new StringWriter();
//            PrintWriter pw = new PrintWriter(sw);
//            StackTraceElement[] ste = new Exception().getStackTrace();
//            // Skip the log writer frame and log all the other stack frames.
//            for (int i = 1; i < ste.length; i++) {
//                String callFrame = "[" + ste[i].getFileName() + ":"
//                        + ste[i].getLineNumber() + "]";
//                pw.print(callFrame);
//            }
//            pw.close();
//            String stackTrace = sw.getBuffer().toString();
//            Level level = this.getLevel(traceLevel);
//            Priority priority = this.getLogPriority();
//            if ( level.isGreaterOrEqual(priority)) {
//                logger.log(level,stackTrace);
//            }
//
//        }
//    }
//
//    /**
//     * Get the line count in the log stream.
//     *
//     * @return
//     */
//    public int getLineCount() {
//        return lineCount;
//    }
//
//    /**
//     * Get the logger.
//     *
//     * @return
//     */
//    public Logger getLogger() {
//        return logger;
//    }
//
//
//    /**
//     * This method allows you to add an external appender.
//     * This is useful for the case when you want to log to
//     * a different log stream than a file.
//     *
//     * @param appender
//     */
//    public void addAppender(Appender appender) {
//
//        this.logger.addAppender(appender);
//
//    }
//
//    /**
//     * Log an exception.
//     *
//     * @param ex
//     */
//    public void logException(Throwable ex) {
//
//        if (needsLogging) {
//
//            this.getLogger().error(ex.getMessage(), ex);
//        }
//    }
//
//
//
//
//    /**
//     * Counts the line number so that the debug log can be correlated to the
//     * message trace.
//     *
//     * @param message --
//     *            message to count the lines for.
//     */
//    private void countLines(String message) {
//        char[] chars = message.toCharArray();
//        for (int i = 0; i < chars.length; i++) {
//            if (chars[i] == '\n')
//                lineCount++;
//        }
//
//    }
//
//    /**
//     * Prepend the line and file where this message originated from
//     *
//     * @param message
//     * @return re-written message.
//     */
//    private String enhanceMessage(String message) {
//
//        StackTraceElement[] stackTrace = new Exception().getStackTrace();
//        StackTraceElement elem = stackTrace[2];
//        String className = elem.getClassName();
//        String methodName = elem.getMethodName();
//        String fileName = elem.getFileName();
//        int lineNumber = elem.getLineNumber();
//        String newMessage = className + "." + methodName + "(" + fileName + ":"
//                + lineNumber + ") [" + message + "]";
//        return newMessage;
//
//    }
//
//    /**
//     * Log a message into the log file.
//     *
//     * @param message
//     *            message to log into the log file.
//     */
//    public void logDebug(String message) {
//        if (needsLogging) {
//            String newMessage = this.enhanceMessage(message);
//            if ( this.lineCount == 0) {
//                getLogger().debug("BUILD TIMESTAMP = " + this.buildTimeStamp);
//                getLogger().debug("Config Propeties = " + this.configurationProperties);
//            }
//            countLines(newMessage);
//            getLogger().debug(newMessage);
//        }
//
//    }
//    
//    /**
//     * Log a message into the log file.
//     *
//     * @param message
//     *            message to log into the log file.
//     */
//    public void logTrace(String message) {
//        if (needsLogging) {
//            String newMessage = this.enhanceMessage(message);
//            if ( this.lineCount == 0) {
//                getLogger().debug("BUILD TIMESTAMP = " + this.buildTimeStamp);
//                getLogger().debug("Config Propeties = " + this.configurationProperties);
//            }
//            countLines(newMessage);
//            getLogger().trace(newMessage);
//        }
//
//    }
//
//    /**
//     * Set the trace level for the stack.
//     */
//    private void setTraceLevel(int level) {
//        traceLevel = level;
//    }
//
//    /**
//     * Get the trace level for the stack.
//     */
//    public int getTraceLevel() {
//        return traceLevel;
//    }
//
//    /**
//     * Log an error message.
//     *
//     * @param message --
//     *            error message to log.
//     */
//    public void logFatalError(String message) {
//        Logger logger = this.getLogger();
//        String newMsg = this.enhanceMessage(message);
//        countLines(newMsg);
//        logger.fatal(newMsg);
//
//    }
//
//    /**
//     * Log an error message.
//     *
//     * @param message --
//     *            error message to log.
//     *
//     */
//    public void logError(String message) {
//        Logger logger = this.getLogger();
//        String newMsg = this.enhanceMessage(message);
//        countLines(newMsg);
//        logger.error(newMsg);
//
//    }
//
//    public LogWriter() {
//    }
//    
//	public void setStackProperties(Properties configurationProperties) {
//
//        this.configurationProperties = configurationProperties;
//
//        String logLevel = configurationProperties
//                .getProperty("gov.nist.javax.sip.TRACE_LEVEL");
//
//        this.logFileName = configurationProperties
//                .getProperty("gov.nist.javax.sip.DEBUG_LOG");
//
//        this.stackName = configurationProperties
//                .getProperty("javax.sip.STACK_NAME");
//
//        //check whether a Log4j logger name has been
//        //specified. if not, use the stack name as the default
//        //logger name.
//        String category = configurationProperties
//                                .getProperty("gov.nist.javax.sip.LOG4J_LOGGER_NAME", this.stackName);
//
//
//        logger = Logger.getLogger(category);
//        if (logLevel != null) {
//            if (logLevel.equals("LOG4J")) {
//                //if TRACE_LEVEL property is specified as
//                //"LOG4J" then, set the traceLevel based on
//                //the log4j effective log level.
//                Level level = logger.getEffectiveLevel();
//                this.needsLogging = true;
//                if (level == Level.OFF)
//                    this.needsLogging = false;
//                this.traceLevel = TRACE_NONE;
//                if (level.isGreaterOrEqual(Level.DEBUG)) {
//                    this.traceLevel = TRACE_DEBUG;
//                } else if (level.isGreaterOrEqual(Level.INFO)) {
//                    this.traceLevel = TRACE_INFO;
//                } else if (level.isGreaterOrEqual(Level.WARN)) {
//                    this.traceLevel = TRACE_ERROR;
//                }
//            }
//            else {
//                try {
//                    int ll = 0;
//                    if (logLevel.equals("TRACE")) {
//                        ll = TRACE_DEBUG;
//                        Debug.debug = true;
//                        Debug.setStackLogger(this);
//                    } else if (logLevel.equals("DEBUG")) {
//                        ll = TRACE_DEBUG;
//                    } else if ( logLevel.equals("INFO")) {
//                        ll = TRACE_INFO;
//                    } else if (logLevel.equals("ERROR")) {
//                        ll = TRACE_ERROR;
//                    } else if (logLevel.equals("NONE") || logLevel.equals("OFF")) {
//                        ll = TRACE_NONE;
//                    } else {
//                        ll = Integer.parseInt(logLevel);
//                        if ( ll > 32 ) {
//                            Debug.debug = true;
//                            Debug.setStackLogger(this);
//                        }
//                    }
//
//                    this.setTraceLevel(ll);
//                    this.needsLogging = true;
//                    if (traceLevel == TRACE_DEBUG) {
//                        logger.setLevel(Level.DEBUG);
//                    } else if (traceLevel == TRACE_INFO) {
//                        logger.setLevel(Level.INFO);
//                    } else if (traceLevel == TRACE_ERROR) {
//                        logger.setLevel(Level.ERROR);
//                    } else if (traceLevel == TRACE_NONE) {
//                        logger.setLevel(Level.OFF);
//                        this.needsLogging = false;
//                    }
//
//                    /*
//                     * If user specifies a logging file as part of the startup
//                     * properties then we try to create the appender.
//                     */
//                    if (this.needsLogging && this.logFileName != null) {
//
//                        boolean overwrite = Boolean.valueOf(
//                                configurationProperties.getProperty(
//                                "gov.nist.javax.sip.DEBUG_LOG_OVERWRITE"));
//
//                        FileAppender fa = null;
//                        try {
//                            fa = new FileAppender(new SimpleLayout(),
//                                    this.logFileName, !overwrite);
//                        } catch (FileNotFoundException fnf) {
//
//                            // Likely due to some directoy not existing. Create
//                            // them
//                            File logfile = new File(this.logFileName);
//                            logfile.getParentFile().mkdirs();
//                            logfile.delete();
//
//                            try {
//                                fa = new FileAppender(new SimpleLayout(),
//                                        this.logFileName);
//                            } catch (IOException ioe) {
//                                ioe.printStackTrace(); // give up
//                            }
//                        } catch (IOException ex) {
//                            ex.printStackTrace();
//                        }
//
//                        if (fa != null)
//                            logger.addAppender(fa);
//                    }
//
//                } catch (NumberFormatException ex) {
//                    ex.printStackTrace();
//                    System.err.println("LogWriter: Bad integer " + logLevel);
//                    System.err.println("logging dislabled ");
//                    needsLogging = false;
//                }
//            }
//        } else {
//            this.needsLogging = false;
//
//        }
//
//        
//    }
//
//    /**
//     * @return flag to indicate if logging is enabled.
//     */
//    public boolean isLoggingEnabled() {
//
//        return this.needsLogging;
//    }
//
//    /**
//     * Return true/false if loging is enabled at a given level.
//     *
//     * @param logLevel
//     */
//    public boolean isLoggingEnabled(int logLevel) {
//        return this.needsLogging && logLevel <= traceLevel;
//    }
//
//
//    /**
//     * Log an error message.
//     *
//     * @param message
//     * @param ex
//     */
//    public void logError(String message, Exception ex) {
//        Logger logger = this.getLogger();
//        logger.error(message, ex);
//
//    }
//
//    /**
//     * Log a warning mesasge.
//     *
//     * @param string
//     */
//    public void logWarning(String string) {
//        getLogger().warn(string);
//
//    }
//
//    /**
//     * Log an info message.
//     *
//     * @param string
//     */
//    public void logInfo(String string) {
//        getLogger().info(string);
//    }
//
//    /**
//     * Disable logging altogether.
//     *
//     */
//    public void disableLogging() {
//        this.needsLogging = false;
//    }
//
//    /**
//     * Enable logging (globally).
//     */
//    public void enableLogging() {
//        this.needsLogging = true;
//
//    }
//
//    public void setBuildTimeStamp(String buildTimeStamp) {
//        this.buildTimeStamp = buildTimeStamp;
//
//    }
//
//    public Priority getLogPriority() {
//         if ( this.traceLevel == TRACE_INFO ) {
//            return Priority.INFO;
//        } else if ( this.traceLevel == TRACE_ERROR ) {
//            return Priority.ERROR;
//        } else if ( this.traceLevel == TRACE_DEBUG) {
//            return Priority.DEBUG;
//        } else if ( this.traceLevel == TRACE_TRACE) {
//            return Priority.DEBUG;
//        } else {
//            return Priority.FATAL;
//        }
//    }
//
//    public Level getLevel(int traceLevel) {
//        if ( traceLevel == TRACE_INFO ) {
//           return Level.INFO;
//       } else if ( traceLevel == TRACE_ERROR ) {
//           return Level.ERROR;
//       } else if ( traceLevel == TRACE_DEBUG) {
//           return Level.DEBUG;
//       } else if (traceLevel == TRACE_TRACE) {
//           return Level.ALL;
//       } else {
//           return Level.OFF;
//       }
//   }
//	
//	public String getLoggerName() {
//	    if ( this.logger != null ) {
//	        return logger.getName();
//	    } else {
//	        return null;
//	    }
//	}
//
//  
//}

// END android-deleted
