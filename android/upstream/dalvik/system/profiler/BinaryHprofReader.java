/*
 * Copyright (C) 2010 The Android Open Source Project
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

package dalvik.system.profiler;

import java.io.BufferedInputStream;
import java.io.DataInputStream;
import java.io.EOFException;
import java.io.IOException;
import java.io.InputStream;
import java.util.Date;
import java.util.HashMap;
import java.util.Map;

/**
 * <pre>   {@code
 * BinaryHprofReader reader = new BinaryHprofReader(new BufferedInputStream(inputStream));
 * reader.setStrict(false); // for RI compatability
 * reader.read();
 * inputStream.close();
 * reader.getVersion();
 * reader.getHprofData();
 * }</pre>
 */
public final class BinaryHprofReader {

    private static final boolean TRACE = false;

    private final DataInputStream in;

    /**
     * By default we try to strictly validate rules followed by
     * our HprofWriter. For example, every end thread is preceded
     * by a matching start thread.
     */
    private boolean strict = true;

    /**
     * version string from header after read has been performed,
     * otherwise null. nullness used to detect if callers try to
     * access data before read is called.
     */
    private String version;

    private final Map<HprofData.StackTrace, int[]> stackTraces
            = new HashMap<HprofData.StackTrace, int[]>();

    private final HprofData hprofData = new HprofData(stackTraces);

    private final Map<Integer, String> idToString = new HashMap<Integer, String>();
    private final Map<Integer, String> idToClassName = new HashMap<Integer, String>();
    private final Map<Integer, StackTraceElement> idToStackFrame
            = new HashMap<Integer, StackTraceElement>();
    private final Map<Integer, HprofData.StackTrace> idToStackTrace
            = new HashMap<Integer, HprofData.StackTrace>();

    /**
     * Creates a BinaryHprofReader around the specified {@code
     * inputStream}
     */
    public BinaryHprofReader(InputStream inputStream) throws IOException {
        this.in = new DataInputStream(inputStream);
    }

    public boolean getStrict () {
        return strict;
    }

    public void setStrict (boolean strict) {
        if (version != null) {
            throw new IllegalStateException("cannot set strict after read()");
        }
        this.strict = strict;
    }

    /**
     * throws IllegalStateException if read() has not been called.
     */
    private void checkRead() {
        if (version == null) {
            throw new IllegalStateException("data access before read()");
        }
    }

    public String getVersion() {
        checkRead();
        return version;
    }

    public HprofData getHprofData() {
        checkRead();
        return hprofData;
    }

    /**
     * Read the hprof header and records from the input
     */
    public void read() throws IOException {
        parseHeader();
        parseRecords();
    }

    private void parseHeader() throws IOException {
        if (TRACE) {
            System.out.println("hprofTag=HEADER");
        }
        parseVersion();
        parseIdSize();
        parseTime();
    }

    private void parseVersion() throws IOException {
        String version = BinaryHprof.readMagic(in);
        if (version == null) {
            throw new MalformedHprofException("Could not find HPROF version");
        }
        if (TRACE) {
            System.out.println("\tversion=" + version);
        }
        this.version = version;
    }

    private void parseIdSize() throws IOException {
        int idSize = in.readInt();
        if (TRACE) {
            System.out.println("\tidSize=" + idSize);
        }
        if (idSize != BinaryHprof.ID_SIZE) {
            throw new MalformedHprofException("Unsupported identifier size: " + idSize);
        }
    }

    private void parseTime() throws IOException {
        long time = in.readLong();
        if (TRACE) {
            System.out.println("\ttime=" + Long.toHexString(time) + " " + new Date(time));
        }
        hprofData.setStartMillis(time);
    }

    private void parseRecords() throws IOException {
        while (parseRecord()) {
            ;
        }
    }

    /**
     * Read and process the next record. Returns true if a
     * record was handled, false on EOF.
     */
    private boolean parseRecord() throws IOException {
        int tagOrEOF = in.read();
        if (tagOrEOF == -1) {
            return false;
        }
        byte tag = (byte) tagOrEOF;
        int timeDeltaInMicroseconds = in.readInt();
        int recordLength = in.readInt();
        BinaryHprof.Tag hprofTag = BinaryHprof.Tag.get(tag);
        if (TRACE) {
            System.out.println("hprofTag=" + hprofTag);
        }
        if (hprofTag == null) {
            skipRecord(hprofTag, recordLength);
            return true;
        }
        String error = hprofTag.checkSize(recordLength);
        if (error != null) {
            throw new MalformedHprofException(error);
        }
        switch (hprofTag) {
            case CONTROL_SETTINGS:
                parseControlSettings();
                return true;

            case STRING_IN_UTF8:
                parseStringInUtf8(recordLength);
                return true;

            case START_THREAD:
                parseStartThread();
                return true;
            case END_THREAD:
                parseEndThread();
                return true;

            case LOAD_CLASS:
                parseLoadClass();
                return true;
            case STACK_FRAME:
                parseStackFrame();
                return true;
            case STACK_TRACE:
                parseStackTrace(recordLength);
                return true;

            case CPU_SAMPLES:
                parseCpuSamples(recordLength);
                return true;

            case UNLOAD_CLASS:
            case ALLOC_SITES:
            case HEAP_SUMMARY:
            case HEAP_DUMP:
            case HEAP_DUMP_SEGMENT:
            case HEAP_DUMP_END:
            default:
                skipRecord(hprofTag, recordLength);
                return true;
        }
    }

    private void skipRecord(BinaryHprof.Tag hprofTag, long recordLength) throws IOException {
        if (TRACE) {
            System.out.println("\tskipping recordLength=" + recordLength);
        }
        long skipped = in.skip(recordLength);
        if (skipped != recordLength) {
            throw new EOFException("Expected to skip " + recordLength
                                   + " bytes but only skipped " + skipped + " bytes");
        }
    }

    private void parseControlSettings() throws IOException {
        int flags = in.readInt();
        short depth = in.readShort();
        if (TRACE) {
            System.out.println("\tflags=" + Integer.toHexString(flags));
            System.out.println("\tdepth=" + depth);
        }
        hprofData.setFlags(flags);
        hprofData.setDepth(depth);
    }

    private void parseStringInUtf8(int recordLength) throws IOException {
        int stringId = in.readInt();
        byte[] bytes = new byte[recordLength - BinaryHprof.ID_SIZE];
        readFully(in, bytes);
        String string = new String(bytes, "UTF-8");
        if (TRACE) {
            System.out.println("\tstring=" + string);
        }
        String old = idToString.put(stringId, string);
        if (old != null) {
            throw new MalformedHprofException("Duplicate string id: " + stringId);
        }
    }

    private static void readFully(InputStream in, byte[] dst) throws IOException {
        int offset = 0;
        int byteCount = dst.length;
        while (byteCount > 0) {
            int bytesRead = in.read(dst, offset, byteCount);
            if (bytesRead < 0) {
                throw new EOFException();
            }
            offset += bytesRead;
            byteCount -= bytesRead;
        }
    }

    private void parseLoadClass() throws IOException {
        int classId = in.readInt();
        int classObjectId = readId();
        // serial number apparently not a stack trace id. (int vs ID)
        // we don't use this field.
        int stackTraceSerialNumber = in.readInt();
        String className = readString();
        if (TRACE) {
            System.out.println("\tclassId=" + classId);
            System.out.println("\tclassObjectId=" + classObjectId);
            System.out.println("\tstackTraceSerialNumber=" + stackTraceSerialNumber);
            System.out.println("\tclassName=" + className);
        }
        String old = idToClassName.put(classId, className);
        if (old != null) {
            throw new MalformedHprofException("Duplicate class id: " + classId);
        }
    }

    private int readId() throws IOException {
        return in.readInt();
    }

    private String readString() throws IOException {
        int id = readId();
        if (id == 0) {
            return null;
        }
        String string = idToString.get(id);
        if (string == null) {
            throw new MalformedHprofException("Unknown string id " + id);
        }
        return string;
    }

    private String readClass() throws IOException {
        int id = readId();
        String string = idToClassName.get(id);
        if (string == null) {
            throw new MalformedHprofException("Unknown class id " + id);
        }
        return string;
    }

    private void parseStartThread() throws IOException {
        int threadId = in.readInt();
        int objectId = readId();
        // stack trace where thread was created.
        // serial number apparently not a stack trace id. (int vs ID)
        // we don't use this field.
        int stackTraceSerialNumber = in.readInt();
        String threadName = readString();
        String groupName = readString();
        String parentGroupName = readString();
        if (TRACE) {
            System.out.println("\tthreadId=" + threadId);
            System.out.println("\tobjectId=" + objectId);
            System.out.println("\tstackTraceSerialNumber=" + stackTraceSerialNumber);
            System.out.println("\tthreadName=" + threadName);
            System.out.println("\tgroupName=" + groupName);
            System.out.println("\tparentGroupName=" + parentGroupName);
        }
        HprofData.ThreadEvent event
                = HprofData.ThreadEvent.start(objectId, threadId,
                                              threadName, groupName, parentGroupName);
        hprofData.addThreadEvent(event);
    }

    private void parseEndThread() throws IOException {
        int threadId = in.readInt();
        if (TRACE) {
            System.out.println("\tthreadId=" + threadId);
        }
        HprofData.ThreadEvent event = HprofData.ThreadEvent.end(threadId);
        hprofData.addThreadEvent(event);
    }

    private void parseStackFrame() throws IOException {
        int stackFrameId = readId();
        String methodName = readString();
        String methodSignature = readString();
        String file = readString();
        String className = readClass();
        int line = in.readInt();
        if (TRACE) {
            System.out.println("\tstackFrameId=" + stackFrameId);
            System.out.println("\tclassName=" + className);
            System.out.println("\tmethodName=" + methodName);
            System.out.println("\tmethodSignature=" + methodSignature);
            System.out.println("\tfile=" + file);
            System.out.println("\tline=" + line);
        }
        StackTraceElement stackFrame = new StackTraceElement(className, methodName, file, line);
        StackTraceElement old = idToStackFrame.put(stackFrameId, stackFrame);
        if (old != null) {
            throw new MalformedHprofException("Duplicate stack frame id: " + stackFrameId);
        }
    }

    private void parseStackTrace(int recordLength) throws IOException {
        int stackTraceId = in.readInt();
        int threadId = in.readInt();
        int frames = in.readInt();
        if (TRACE) {
            System.out.println("\tstackTraceId=" + stackTraceId);
            System.out.println("\tthreadId=" + threadId);
            System.out.println("\tframes=" + frames);
        }
        int expectedLength = 4 + 4 + 4 + (frames * BinaryHprof.ID_SIZE);
        if (recordLength != expectedLength) {
            throw new MalformedHprofException("Expected stack trace record of size "
                                              + expectedLength
                                              + " based on number of frames but header "
                                              + "specified a length of  " + recordLength);
        }
        StackTraceElement[] stackFrames = new StackTraceElement[frames];
        for (int i = 0; i < frames; i++) {
            int stackFrameId = readId();
            StackTraceElement stackFrame = idToStackFrame.get(stackFrameId);
            if (TRACE) {
                System.out.println("\tstackFrameId=" + stackFrameId);
                System.out.println("\tstackFrame=" + stackFrame);
            }
            if (stackFrame == null) {
                throw new MalformedHprofException("Unknown stack frame id " + stackFrameId);
            }
            stackFrames[i] = stackFrame;
        }

        HprofData.StackTrace stackTrace
                = new HprofData.StackTrace(stackTraceId, threadId, stackFrames);
        if (strict) {
            hprofData.addStackTrace(stackTrace, new int[1]);
        } else {
            // The RI can have duplicate stacks, presumably they
            // have a minor race if two samples with the same
            // stack are taken around the same time. if we have a
            // duplicate, just skip adding it to hprofData, but
            // register it locally in idToStackFrame. if it seen
            // in CPU_SAMPLES, we will find a StackTrace is equal
            // to the first, so they will share a countCell.
            int[] countCell = stackTraces.get(stackTrace);
            if (countCell == null) {
                hprofData.addStackTrace(stackTrace, new int[1]);
            }
        }

        HprofData.StackTrace old = idToStackTrace.put(stackTraceId, stackTrace);
        if (old != null) {
            throw new MalformedHprofException("Duplicate stack trace id: " + stackTraceId);
        }

    }

    private void parseCpuSamples(int recordLength) throws IOException {
        int totalSamples = in.readInt();
        int samplesCount = in.readInt();
        if (TRACE) {
            System.out.println("\ttotalSamples=" + totalSamples);
            System.out.println("\tsamplesCount=" + samplesCount);
        }
        int expectedLength = 4 + 4 + (samplesCount * (4 + 4));
        if (recordLength != expectedLength) {
            throw new MalformedHprofException("Expected CPU samples record of size "
                                              + expectedLength
                                              + " based on number of samples but header "
                                              + "specified a length of  " + recordLength);
        }
        int total = 0;
        for (int i = 0; i < samplesCount; i++) {
            int count = in.readInt();
            int stackTraceId = in.readInt();
            if (TRACE) {
                System.out.println("\tcount=" + count);
                System.out.println("\tstackTraceId=" + stackTraceId);
            }
            HprofData.StackTrace stackTrace = idToStackTrace.get(stackTraceId);
            if (stackTrace == null) {
                throw new MalformedHprofException("Unknown stack trace id " + stackTraceId);
            }
            if (count == 0) {
                throw new MalformedHprofException("Zero sample count for stack trace "
                                                  + stackTrace);
            }
            int[] countCell = stackTraces.get(stackTrace);
            if (strict) {
                if (countCell[0] != 0) {
                    throw new MalformedHprofException("Setting sample count of stack trace "
                                                      + stackTrace + " to " + count
                                                      + " found it was already initialized to "
                                                      + countCell[0]);
                }
            } else {
                // Coalesce counts from duplicate stack traces.
                // For more on this, see comments in parseStackTrace.
                count += countCell[0];
            }
            countCell[0] = count;
            total += count;
        }
        if (strict && totalSamples != total) {
            throw new MalformedHprofException("Expected a total of " + totalSamples
                                              + " samples but saw " + total);
        }
    }
}
