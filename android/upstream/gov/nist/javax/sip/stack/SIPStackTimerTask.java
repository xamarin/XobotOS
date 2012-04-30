/*
 * @author:     Brett Buckingham
 * @author:     Last modified by: $Author: emcho $
 * @version:    $Date: 2009/07/17 18:58:14 $ $Revision: 1.3 $
 *
 * This source code has been contributed to the public domain.
 */

package gov.nist.javax.sip.stack;

import java.util.TimerTask;

/**
 * A subclass of TimerTask which runs TimerTask code within a try/catch block to
 * avoid killing the SIPTransactionStack timer thread. Note: subclasses MUST not
 * override run(); instead they should override runTask().
 *
 * @author Brett Buckingham
 *
 */
public abstract class SIPStackTimerTask extends TimerTask {
    // / Implements code to be run when the SIPStackTimerTask is executed.
    protected abstract void runTask();

    // / The run() method is final to ensure that all subclasses inherit the
    // exception handling.
    public final void run() {
        try {
            runTask();
        } catch (Throwable e) {
            System.out.println("SIP stack timer task failed due to exception:");
            e.printStackTrace();
        }
    }
}
