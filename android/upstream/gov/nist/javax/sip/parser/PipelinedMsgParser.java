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
 * of the terms of this agreement
 *
 * .
 *
 */
/******************************************************************************
 * Product of NIST/ITL Advanced Networking Technologies Division (ANTD)       *
 ******************************************************************************/
package gov.nist.javax.sip.parser;

/*
 *
 * Lamine Brahimi and Yann Duponchel (IBM Zurich) noticed that the parser was
 * blocking so I threw out some cool pipelining which ran fast but only worked
 * when the phase of the moon matched its mood. Now things are serialized and
 * life goes slower but more reliably.
 *
 */
import gov.nist.core.*;
import gov.nist.javax.sip.message.*;
import gov.nist.javax.sip.header.*;
import java.text.ParseException;
import java.io.*;

/**
 * This implements a pipelined message parser suitable for use with a stream -
 * oriented input such as TCP. The client uses this class by instatiating with
 * an input stream from which input is read and fed to a message parser. It
 * keeps reading from the input stream and process messages in a never ending
 * interpreter loop. The message listener interface gets called for processing
 * messages or for processing errors. The payload specified by the
 * content-length header is read directly from the input stream. This can be
 * accessed from the SIPMessage using the getContent and getContentBytes methods
 * provided by the SIPMessage class.
 *
 * @version 1.2 $Revision: 1.23 $ $Date: 2009/08/16 17:28:28 $
 *
 * @author M. Ranganathan
 *
 * @see SIPMessageListener
 */
public final class PipelinedMsgParser implements Runnable {



    /**
     * The message listener that is registered with this parser. (The message
     * listener has methods that can process correct and erroneous messages.)
     */
    protected SIPMessageListener sipMessageListener;
    private Thread mythread; // Preprocessor thread
    //private byte[] messageBody;
    //private boolean errorFlag;
    private Pipeline rawInputStream;
    private int maxMessageSize;
    private int sizeCounter;
    //private int messageSize;

    /**
     * default constructor.
     */
    protected PipelinedMsgParser() {
        super();

    }

    private static int uid = 0;

    private static synchronized int getNewUid() {
        return uid++;
    }

    /**
     * Constructor when we are given a message listener and an input stream
     * (could be a TCP connection or a file)
     *
     * @param sipMessageListener
     *            Message listener which has methods that get called back from
     *            the parser when a parse is complete
     * @param in
     *            Input stream from which to read the input.
     * @param debug
     *            Enable/disable tracing or lexical analyser switch.
     */
    public PipelinedMsgParser(SIPMessageListener sipMessageListener,
            Pipeline in, boolean debug, int maxMessageSize) {
        this();
        this.sipMessageListener = sipMessageListener;
        rawInputStream = in;
        this.maxMessageSize = maxMessageSize;
        mythread = new Thread(this);
        mythread.setName("PipelineThread-" + getNewUid());

    }

    /**
     * This is the constructor for the pipelined parser.
     *
     * @param mhandler
     *            a SIPMessageListener implementation that provides the message
     *            handlers to handle correctly and incorrectly parsed messages.
     * @param in
     *            An input stream to read messages from.
     */

    public PipelinedMsgParser(SIPMessageListener mhandler, Pipeline in,
            int maxMsgSize) {
        this(mhandler, in, false, maxMsgSize);
    }

    /**
     * This is the constructor for the pipelined parser.
     *
     * @param in -
     *            An input stream to read messages from.
     */

    public PipelinedMsgParser(Pipeline in) {
        this(null, in, false, 0);
    }

    /**
     * Start reading and processing input.
     */
    public void processInput() {
        mythread.start();
    }

    /**
     * Create a new pipelined parser from an existing one.
     *
     * @return A new pipelined parser that reads from the same input stream.
     */
    protected Object clone() {
        PipelinedMsgParser p = new PipelinedMsgParser();

        p.rawInputStream = this.rawInputStream;
        p.sipMessageListener = this.sipMessageListener;
        Thread mythread = new Thread(p);
        mythread.setName("PipelineThread");
        return p;
    }

    /**
     * Add a class that implements a SIPMessageListener interface whose methods
     * get called * on successful parse and error conditons.
     *
     * @param mlistener
     *            a SIPMessageListener implementation that can react to correct
     *            and incorrect pars.
     */

    public void setMessageListener(SIPMessageListener mlistener) {
        sipMessageListener = mlistener;
    }

    /**
     * read a line of input (I cannot use buffered reader because we may need to
     * switch encodings mid-stream!
     */
    private String readLine(InputStream inputStream) throws IOException {
        StringBuffer retval = new StringBuffer("");
        while (true) {
            char ch;
            int i = inputStream.read();
            if (i == -1) {
                throw new IOException("End of stream");
            } else
                ch = (char) i;
            // reduce the available read size by 1 ("size" of a char).
            if (this.maxMessageSize > 0) {
                this.sizeCounter--;
                if (this.sizeCounter <= 0)
                    throw new IOException("Max size exceeded!");
            }
            if (ch != '\r')
                retval.append(ch);
            if (ch == '\n') {
                break;
            }
        }
        return retval.toString();
    }

    /**
     * This is input reading thread for the pipelined parser. You feed it input
     * through the input stream (see the constructor) and it calls back an event
     * listener interface for message processing or error. It cleans up the
     * input - dealing with things like line continuation
     */
    public void run() {

        Pipeline inputStream = this.rawInputStream;
        // inputStream = new MyFilterInputStream(this.rawInputStream);
        // I cannot use buffered reader here because we may need to switch
        // encodings to read the message body.
        try {
            while (true) {
                this.sizeCounter = this.maxMessageSize;
                // this.messageSize = 0;
                StringBuffer inputBuffer = new StringBuffer();

                if (Debug.parserDebug)
                    Debug.println("Starting parse!");

                String line1;
                String line2 = null;

                while (true) {
                    try {
                        line1 = readLine(inputStream);
                        // ignore blank lines.
                        if (line1.equals("\n")) {
                            if (Debug.parserDebug) {
                                Debug.println("Discarding blank line. ");
                            }
                            continue;
                        } else
                            break;
                    } catch (IOException ex) {
                        Debug.printStackTrace(ex);
                        this.rawInputStream.stopTimer();
                        return;

                    }
                }

                inputBuffer.append(line1);
                // Guard against bad guys.
                this.rawInputStream.startTimer();

                Debug.println("Reading Input Stream");
                while (true) {
                    try {
                        line2 = readLine(inputStream);
                        inputBuffer.append(line2);
                        if (line2.trim().equals(""))
                            break;
                    } catch (IOException ex) {
                        this.rawInputStream.stopTimer();
                        Debug.printStackTrace(ex);
                        return;

                    }
                }

                // Stop the timer that will kill the read.
                this.rawInputStream.stopTimer();
                inputBuffer.append(line2);
                StringMsgParser smp = new StringMsgParser(sipMessageListener);
                smp.readBody = false;
                SIPMessage sipMessage = null;

                try {
                    if (Debug.debug) {
                        Debug.println("About to parse : " + inputBuffer.toString());
                    }
                    sipMessage = smp.parseSIPMessage(inputBuffer.toString());
                    if (sipMessage == null) {
                        this.rawInputStream.stopTimer();
                        continue;
                    }
                } catch (ParseException ex) {
                    // Just ignore the parse exception.
                    Debug.logError("Detected a parse error", ex);
                    continue;
                }

                if (Debug.debug) {
                    Debug.println("Completed parsing message");
                }
                ContentLength cl = (ContentLength) sipMessage
                        .getContentLength();
                int contentLength = 0;
                if (cl != null) {
                    contentLength = cl.getContentLength();
                } else {
                    contentLength = 0;
                }

                if (Debug.debug) {
                    Debug.println("contentLength " + contentLength);
                }

                if (contentLength == 0) {
                    sipMessage.removeContent();
                } else if (maxMessageSize == 0
                        || contentLength < this.sizeCounter) {
                    byte[] message_body = new byte[contentLength];
                    int nread = 0;
                    while (nread < contentLength) {
                        // Start my starvation timer.
                        // This ensures that the other end
                        // writes at least some data in
                        // or we will close the pipe from
                        // him. This prevents DOS attack
                        // that takes up all our connections.
                        this.rawInputStream.startTimer();
                        try {

                            int readlength = inputStream.read(message_body,
                                    nread, contentLength - nread);
                            if (readlength > 0) {
                                nread += readlength;
                            } else {
                                break;
                            }
                        } catch (IOException ex) {
                            Debug.logError("Exception Reading Content",ex);
                            break;
                        } finally {
                            // Stop my starvation timer.
                            this.rawInputStream.stopTimer();
                        }
                    }
                    sipMessage.setMessageContent(message_body);
                }
                // Content length too large - process the message and
                // return error from there.
                if (sipMessageListener != null) {
                    try {
                        sipMessageListener.processMessage(sipMessage);
                    } catch (Exception ex) {
                        // fatal error in processing - close the
                        // connection.
                        break;
                    }
                }
            }
        } finally {
            try {
                inputStream.close();
            } catch (IOException e) {
                InternalErrorHandler.handleException(e);
            }
        }
    }

    public void close() {
        try {
            this.rawInputStream.close();
        } catch (IOException ex) {
            // Ignore.
        }
    }
}
/*
 * $Log: PipelinedMsgParser.java,v $
 * Revision 1.23  2009/08/16 17:28:28  mranga
 * Issue number:  208
 * Obtained from:
 * Submitted by:
 * Reviewed by:
 *
 * Add authentication mechanism that uses H(username:domain:password)
 *
 * Revision 1.22  2009/07/17 18:58:02  emcho
 * Converts indentation tabs to spaces so that we have a uniform indentation policy in the whole project.
 *
 * Revision 1.21  2008/05/24 04:10:01  mranga
 *
 * Issue number:   158
 * Obtained from:
 * Submitted by:
 * Reviewed by:   mranga
 *
 * Deliver tx timeout for Canceled INVITE. Fix pipeline thread exit.
 *
 * Revision 1.20  2008/05/22 19:38:07  jbemmel
 * Fix for issue 149: the logic wasn't always closing the internal socket pipe,
 * causing the pipe reader thread to block indefinitely
 *
 * Repeatedly starting/stopping the stack then gives hanging threads
 * Revision 1.19 2007/01/28 13:06:21 mranga
 * Issue number: 99 Obtained from: Submitted by: Reviewed by: mranga
 *
 * Fixed PRACK handling null pointer exception (for proxy case) and cleanup of
 * unused variables.
 *
 * CVS: ----------------------------------------------------------------------
 * CVS: Issue number: CVS: If this change addresses one or more issues, CVS:
 * then enter the issue number(s) here. CVS: Obtained from: CVS: If this change
 * has been taken from another system, CVS: then name the system in this line,
 * otherwise delete it. CVS: Submitted by: CVS: If this code has been
 * contributed to the project by someone else; i.e., CVS: they sent us a patch
 * or a set of diffs, then include their name/email CVS: address here. If this
 * is your work then delete this line. CVS: Reviewed by: CVS: If we are doing
 * pre-commit code reviews and someone else has CVS: reviewed your changes,
 * include their name(s) here. CVS: If you have not had it reviewed then delete
 * this line.
 *
 * Revision 1.18 2006/07/13 09:02:10 mranga Issue number: Obtained from:
 * Submitted by: jeroen van bemmel Reviewed by: mranga Moved some changes from
 * jain-sip-1.2 to java.net
 *
 * CVS: ----------------------------------------------------------------------
 * CVS: Issue number: CVS: If this change addresses one or more issues, CVS:
 * then enter the issue number(s) here. CVS: Obtained from: CVS: If this change
 * has been taken from another system, CVS: then name the system in this line,
 * otherwise delete it. CVS: Submitted by: CVS: If this code has been
 * contributed to the project by someone else; i.e., CVS: they sent us a patch
 * or a set of diffs, then include their name/email CVS: address here. If this
 * is your work then delete this line. CVS: Reviewed by: CVS: If we are doing
 * pre-commit code reviews and someone else has CVS: reviewed your changes,
 * include their name(s) here. CVS: If you have not had it reviewed then delete
 * this line.
 *
 * Revision 1.4 2006/06/19 06:47:27 mranga javadoc fixups
 *
 * Revision 1.3 2006/06/17 10:18:14 mranga Added some synchronization to the
 * sequence number checking. Small javadoc fixups
 *
 * Revision 1.2 2006/06/16 15:26:28 mranga Added NIST disclaimer to all public
 * domain files. Clean up some javadoc. Fixed a leak
 *
 * Revision 1.1.1.1 2005/10/04 17:12:35 mranga
 *
 * Import
 *
 *
 * Revision 1.16 2004/11/30 23:28:14 mranga Issue number: 44 Submitted by: Rob
 * Daugherty Reviewed by: M. Ranganathan
 *
 * TCP Pipelining truncates content when other end of pipe is closed.
 *
 * Revision 1.15 2004/05/30 18:55:56 mranga Reviewed by: mranga Move to timers
 * and eliminate the Transaction scanner Thread to improve scalability and
 * reduce cpu usage.
 *
 * Revision 1.14 2004/05/16 14:13:22 mranga Reviewed by: mranga Fixed the
 * use-count issue reported by Peter Parnes. Added property to prevent against
 * content-length dos attacks.
 *
 * Revision 1.13 2004/03/19 04:22:22 mranga Reviewed by: mranga Added IO Pacing
 * for long writes - split write into chunks and flush after each chunk to avoid
 * socket back pressure.
 *
 * Revision 1.12 2004/03/18 22:01:19 mranga Reviewed by: mranga Get rid of the
 * PipedInputStream from pipelined parser to avoid a copy.
 *
 * Revision 1.11 2004/03/07 22:25:23 mranga Reviewed by: mranga Added a new
 * configuration parameter that instructs the stack to drop a server connection
 * after server transaction termination set
 * gov.nist.javax.sip.CACHE_SERVER_CONNECTIONS=false for this Default behavior
 * is true.
 *
 * Revision 1.10 2004/02/29 15:32:58 mranga Reviewed by: mranga bug fixes on
 * limiting the max message size.
 *
 * Revision 1.9 2004/02/29 00:46:34 mranga Reviewed by: mranga Added new
 * configuration property to limit max message size for TCP transport. The
 * property is gov.nist.javax.sip.MAX_MESSAGE_SIZE
 *
 * Revision 1.8 2004/02/25 21:43:03 mranga Reviewed by: mranga Added a couple of
 * todo's and removed some debug printlns that could slow code down by a bit.
 *
 * Revision 1.7 2004/02/25 20:52:46 mranga Reviewed by: mranga Fix TCP transport
 * so messages in excess of 8192 bytes are accepted.
 *
 * Revision 1.6 2004/01/22 18:39:41 mranga Reviewed by: M. Ranganathan Moved the
 * ifdef SIMULATION and associated tags to the first column so Prep preprocessor
 * can deal with them.
 *
 * Revision 1.5 2004/01/22 14:23:45 mranga Reviewed by: mranga Fixed some minor
 * formatting issues.
 *
 * Revision 1.4 2004/01/22 13:26:31 sverker Issue number: Obtained from:
 * Submitted by: sverker Reviewed by: mranga
 *
 * Major reformat of code to conform with style guide. Resolved compiler and
 * javadoc warnings. Added CVS tags.
 *
 * CVS: ----------------------------------------------------------------------
 * CVS: Issue number: CVS: If this change addresses one or more issues, CVS:
 * then enter the issue number(s) here. CVS: Obtained from: CVS: If this change
 * has been taken from another system, CVS: then name the system in this line,
 * otherwise delete it. CVS: Submitted by: CVS: If this code has been
 * contributed to the project by someone else; i.e., CVS: they sent us a patch
 * or a set of diffs, then include their name/email CVS: address here. If this
 * is your work then delete this line. CVS: Reviewed by: CVS: If we are doing
 * pre-commit code reviews and someone else has CVS: reviewed your changes,
 * include their name(s) here. CVS: If you have not had it reviewed then delete
 * this line.
 *
 */
