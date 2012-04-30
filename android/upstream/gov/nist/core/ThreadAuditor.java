package gov.nist.core;

import java.util.*;

/**
 * Thread Auditor class:
 *   - Provides a mechanism for applications to check the health of internal threads
 *   - The mechanism is fairly simple:
 *   - Threads register with the auditor at startup and "ping" the auditor every so often.
 *   - The application queries the auditor about the health of the system periodically. The
 *     auditor reports if the threads are healthy or if any of them failed to ping and are
 *     considered dead or stuck.
 *   - The main implication for the monitored threads is that they can no longer block
 *     waiting for an event forever. Any wait() must be implemented with a timeout so that
 *     the thread can periodically ping the auditor.
 *
 * This code is in the public domain.
 *
 * @author R. Borba (Natural Convergence)   <br/>
 * @version 1.2
 */

public class ThreadAuditor {
    /// Threads being monitored
    private Map<Thread,ThreadHandle> threadHandles = new HashMap<Thread,ThreadHandle>();

    /// How often are threads supposed to ping
    private long pingIntervalInMillisecs = 0;

    /// Internal class, used as a handle by the monitored threads
    public class ThreadHandle {
        /// Set to true when the thread pings, periodically reset to false by the auditor
        private boolean isThreadActive;

        /// Thread being monitored
        private Thread thread;

        /// Thread auditor monitoring this thread
        private ThreadAuditor threadAuditor;

        /// Constructor
        public ThreadHandle(ThreadAuditor aThreadAuditor) {
            isThreadActive = false;
            thread = Thread.currentThread();
            threadAuditor = aThreadAuditor;
        }

        /// Called by the auditor thread to check the ping status of the thread
        public boolean isThreadActive() {
            return isThreadActive;
        }

        /// Called by the auditor thread to reset the ping status of the thread
        protected void setThreadActive(boolean value) {
            isThreadActive = value;
        }

        /// Return the thread being monitored
        public Thread getThread() {
            return thread;
        }

        // Helper function to allow threads to ping using this handle
        public void ping() {
            threadAuditor.ping(this);
        }

        // Helper function to allow threads to get the ping interval directly from this handle
        public long getPingIntervalInMillisecs() {
            return threadAuditor.getPingIntervalInMillisecs();
        }

        /**
         * Returns a string representation of the object
         *
         * @return a string representation of the object
         */
        public String toString() {
            StringBuffer toString = new StringBuffer()
                    .append("Thread Name: ").append(thread.getName())
                    .append(", Alive: ").append(thread.isAlive());
            return toString.toString();
        }
    }

    /// Indicates how often monitored threads are supposed to ping (0 = no thread monitoring)
    public long getPingIntervalInMillisecs() {
        return pingIntervalInMillisecs;
    }

    /// Defines how often monitored threads are supposed to ping
    public void setPingIntervalInMillisecs(long value) {
        pingIntervalInMillisecs = value;
    }

    /// Indicates if the auditing of threads is enabled
    public boolean isEnabled() {
        return (pingIntervalInMillisecs > 0);
    }

    /// Called by a thread that wants to be monitored
    public synchronized ThreadHandle addCurrentThread() {
        // Create and return a thread handle but only add it
        // to the list of monitored threads if the auditor is enabled
        ThreadHandle threadHandle = new ThreadHandle(this);
        if (isEnabled()) {
            threadHandles.put(Thread.currentThread(), threadHandle);
        }
        return threadHandle;
    }

    /// Stops monitoring a given thread
    public synchronized void removeThread(Thread thread) {
        threadHandles.remove(thread);
    }

    /// Called by a monitored thread reporting that it's alive and well
    public synchronized void ping(ThreadHandle threadHandle) {
        threadHandle.setThreadActive(true);
    }

    /// Resets the auditor
    public synchronized void reset() {
        threadHandles.clear();
    }

    /**
     * Audits the sanity of all threads
     *
     * @return An audit report string (multiple lines), or null if all is well
     */
    public synchronized String auditThreads() {
        String auditReport = null;
        // Map stackTraces = null;

        // Scan all monitored threads looking for non-responsive ones
        Iterator<ThreadHandle> it = threadHandles.values().iterator();
        while (it.hasNext()) {
            ThreadHandle threadHandle = (ThreadHandle) it.next();
            if (!threadHandle.isThreadActive()) {
                // Get the non-responsive thread
                Thread thread = threadHandle.getThread();

                // Update the audit report
                if (auditReport == null) {
                    auditReport = "Thread Auditor Report:\n";
                }
                auditReport += "   Thread [" + thread.getName() + "] has failed to respond to an audit request.\n";

                /*
                 * Stack traces are not available with JDK 1.4.
                 * Feel free to uncomment this block to get a better report if you're using JDK 1.5.
                 */
                //  // Get stack traces for all live threads (do this only once per audit)
                //  if (stackTraces == null) {
                //      stackTraces = Thread.getAllStackTraces();
                //  }
                //
                //  // Get the stack trace for the non-responsive thread
                //  StackTraceElement[] stackTraceElements = (StackTraceElement[])stackTraces.get(thread);
                //  if (stackTraceElements != null && stackTraceElements.length > 0) {
                //      auditReport += "      Stack trace:\n";
                //
                //      for (int i = 0; i < stackTraceElements.length ; i ++ ) {
                //          StackTraceElement stackTraceElement = stackTraceElements[i];
                //          auditReport += "         " + stackTraceElement.toString() + "\n";
                //      }
                //  } else {
                //      auditReport += "      Stack trace is not available.\n";
                //  }
            }

            // Reset the ping status of the thread
            threadHandle.setThreadActive(false);
        }
        return auditReport;
    }

    /**
     * Returns a string representation of the object
     *
     * @return a string representation of the object
     */
    public synchronized String toString() {
        String toString = "Thread Auditor - List of monitored threads:\n";
        Iterator<ThreadHandle> it = threadHandles.values().iterator();
        while ( it.hasNext()) {
            ThreadHandle threadHandle = (ThreadHandle)it.next();
            toString += "   " + threadHandle.toString() + "\n";
        }
        return toString;
    }
}
