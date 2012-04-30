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

import java.io.DataOutputStream;
import java.io.IOException;
import java.io.OutputStream;
import java.util.HashMap;
import java.util.Map;
import java.util.Set;

/**
 * BinaryHprofWriter produces hprof compatible binary output for use
 * with third party tools. Such files can be converted to text with
 * with {@link HprofBinaryToAscii} or read back in with {@link BinaryHprofReader}.
 */
public final class BinaryHprofWriter {

    private int nextStringId = 1; // id 0 => null
    private int nextClassId = 1;
    private int nextStackFrameId = 1;
    private final Map<String, Integer> stringToId = new HashMap<String, Integer>();
    private final Map<String, Integer> classNameToId = new HashMap<String, Integer>();
    private final Map<StackTraceElement, Integer> stackFrameToId
            = new HashMap<StackTraceElement, Integer>();

    private final HprofData data;
    private final DataOutputStream out;

    /**
     * Writes the provided data to the specified stream.
     */
    public static void write(HprofData data, OutputStream outputStream) throws IOException {
        new BinaryHprofWriter(data, outputStream).write();
    }

    private BinaryHprofWriter(HprofData data, OutputStream outputStream) {
        this.data = data;
        this.out = new DataOutputStream(outputStream);
    }

    private void write() throws IOException {
        try {
            writeHeader(data.getStartMillis());

            writeControlSettings(data.getFlags(), data.getDepth());

            for (HprofData.ThreadEvent event : data.getThreadHistory()) {
                writeThreadEvent(event);
            }

            Set<HprofData.Sample> samples = data.getSamples();
            int total = 0;
            for (HprofData.Sample sample : samples) {
                total += sample.count;
                writeStackTrace(sample.stackTrace);
            }
            writeCpuSamples(total, samples);

        } finally {
            out.flush();
        }
    }

    private void writeHeader(long dumpTimeInMilliseconds) throws IOException {
        out.writeBytes(BinaryHprof.MAGIC + "1.0.2");
        out.writeByte(0); // null terminated string
        out.writeInt(BinaryHprof.ID_SIZE);
        out.writeLong(dumpTimeInMilliseconds);
    }

    private void writeControlSettings(int flags, int depth) throws IOException {
        if (depth > Short.MAX_VALUE) {
            throw new IllegalArgumentException("depth too large for binary hprof: "
                                               + depth + " > " + Short.MAX_VALUE);
        }
        writeRecordHeader(BinaryHprof.Tag.CONTROL_SETTINGS,
                          0,
                          BinaryHprof.Tag.CONTROL_SETTINGS.maximumSize);
        out.writeInt(flags);
        out.writeShort((short) depth);
    }

    private void writeThreadEvent(HprofData.ThreadEvent e) throws IOException {
        switch (e.type) {
            case START:
                writeStartThread(e);
                return;
            case END:
                writeStopThread(e);
                return;
        }
        throw new IllegalStateException(e.type.toString());
    }

    private void writeStartThread(HprofData.ThreadEvent e) throws IOException {
        int threadNameId = writeString(e.threadName);
        int groupNameId = writeString(e.groupName);
        int parentGroupNameId = writeString(e.parentGroupName);
        writeRecordHeader(BinaryHprof.Tag.START_THREAD,
                          0,
                          BinaryHprof.Tag.START_THREAD.maximumSize);
        out.writeInt(e.threadId);
        writeId(e.objectId);
        out.writeInt(0); // stack trace where thread was started unavailable
        writeId(threadNameId);
        writeId(groupNameId);
        writeId(parentGroupNameId);
    }

    private void writeStopThread(HprofData.ThreadEvent e) throws IOException {
        writeRecordHeader(BinaryHprof.Tag.END_THREAD,
                          0,
                          BinaryHprof.Tag.END_THREAD.maximumSize);
        out.writeInt(e.threadId);
    }

    private void writeRecordHeader(BinaryHprof.Tag hprofTag,
                                   int timeDeltaInMicroseconds,
                                   int recordLength) throws IOException {
        String error = hprofTag.checkSize(recordLength);
        if (error != null) {
            throw new AssertionError(error);
        }
        out.writeByte(hprofTag.tag);
        out.writeInt(timeDeltaInMicroseconds);
        out.writeInt(recordLength);
    }

    private void writeId(int id) throws IOException {
        out.writeInt(id);
    }

    /**
     * Ensures that a string has been writen to the out and
     * returns its ID. The ID of a null string is zero, and
     * doesn't actually result in any output. In a string has
     * already been written previously, the earlier ID will be
     * returned and no output will be written.
     */
    private int writeString(String string) throws IOException {
        if (string == null) {
            return 0;
        }
        Integer identifier = stringToId.get(string);
        if (identifier != null) {
            return identifier;
        }

        int id = nextStringId++;
        stringToId.put(string, id);

        byte[] bytes = string.getBytes("UTF-8");
        writeRecordHeader(BinaryHprof.Tag.STRING_IN_UTF8,
                          0,
                          BinaryHprof.ID_SIZE + bytes.length);
        out.writeInt(id);
        out.write(bytes, 0, bytes.length);

        return id;
    }

    private void writeCpuSamples(int totalSamples, Set<HprofData.Sample> samples)
            throws IOException {
        int samplesCount = samples.size();
        if (samplesCount == 0) {
            return;
        }
        writeRecordHeader(BinaryHprof.Tag.CPU_SAMPLES, 0, 4 + 4 + (samplesCount * (4 + 4)));
        out.writeInt(totalSamples);
        out.writeInt(samplesCount);
        for (HprofData.Sample sample : samples) {
            out.writeInt(sample.count);
            out.writeInt(sample.stackTrace.stackTraceId);
        }
    }

    private void writeStackTrace(HprofData.StackTrace stackTrace) throws IOException {
        int frames = stackTrace.stackFrames.length;
        int[] stackFrameIds = new int[frames];
        for (int i = 0; i < frames; i++) {
            stackFrameIds[i] = writeStackFrame(stackTrace.stackFrames[i]);
        }
        writeRecordHeader(BinaryHprof.Tag.STACK_TRACE,
                          0,
                          4 + 4 + 4 + (frames * BinaryHprof.ID_SIZE));
        out.writeInt(stackTrace.stackTraceId);
        out.writeInt(stackTrace.threadId);
        out.writeInt(frames);
        for (int stackFrameId : stackFrameIds) {
            writeId(stackFrameId);
        }
    }

    private int writeLoadClass(String className) throws IOException {
        Integer identifier = classNameToId.get(className);
        if (identifier != null) {
            return identifier;
        }
        int id = nextClassId++;
        classNameToId.put(className, id);

        int classNameId = writeString(className);
        writeRecordHeader(BinaryHprof.Tag.LOAD_CLASS,
                          0,
                          BinaryHprof.Tag.LOAD_CLASS.maximumSize);
        out.writeInt(id);
        writeId(0); // class object ID
        out.writeInt(0); // stack trace where class was loaded is unavailable
        writeId(classNameId);

        return id;
    }

    private int writeStackFrame(StackTraceElement stackFrame) throws IOException {
        Integer identifier = stackFrameToId.get(stackFrame);
        if (identifier != null) {
            return identifier;
        }

        int id = nextStackFrameId++;
        stackFrameToId.put(stackFrame, id);

        int classId = writeLoadClass(stackFrame.getClassName());
        int methodNameId = writeString(stackFrame.getMethodName());
        int sourceId = writeString(stackFrame.getFileName());
        writeRecordHeader(BinaryHprof.Tag.STACK_FRAME,
                          0,
                          BinaryHprof.Tag.STACK_FRAME.maximumSize);
        writeId(id);
        writeId(methodNameId);
        writeId(0); // method signature is unavailable from StackTraceElement
        writeId(sourceId);
        out.writeInt(classId);
        out.writeInt(stackFrame.getLineNumber());

        return id;
    }
}
