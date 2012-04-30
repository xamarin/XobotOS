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

import java.util.ArrayList;
import java.util.Arrays;
import java.util.Collections;
import java.util.HashMap;
import java.util.HashSet;
import java.util.List;
import java.util.Map.Entry;
import java.util.Map;
import java.util.Set;

/**
 * Represents sampling profiler data. Can be converted to ASCII or
 * binary hprof-style output using {@link AsciiHprofWriter} or
 * {@link BinaryHprofWriter}.
 * <p>
 * The data includes:
 * <ul>
 * <li>the start time of the last sampling period
 * <li>the history of thread start and end events
 * <li>stack traces with frequency counts
 * <ul>
 */
public final class HprofData {

    public static enum ThreadEventType { START, END };

    /**
     * ThreadEvent represents thread creation and death events for
     * reporting. It provides a record of the thread and thread group
     * names for tying samples back to their source thread.
     */
    public static final class ThreadEvent {

        public final ThreadEventType type;
        public final int objectId;
        public final int threadId;
        public final String threadName;
        public final String groupName;
        public final String parentGroupName;

        public static ThreadEvent start(int objectId, int threadId, String threadName,
                                        String groupName, String parentGroupName) {
            return new ThreadEvent(ThreadEventType.START, objectId, threadId,
                                   threadName, groupName, parentGroupName);
        }

        public static ThreadEvent end(int threadId) {
            return new ThreadEvent(ThreadEventType.END, threadId);
        }

        private ThreadEvent(ThreadEventType type, int objectId, int threadId,
                            String threadName, String groupName, String parentGroupName) {
            if (threadName == null) {
                throw new NullPointerException("threadName == null");
            }
            this.type = ThreadEventType.START;
            this.objectId = objectId;
            this.threadId = threadId;
            this.threadName = threadName;
            this.groupName = groupName;
            this.parentGroupName = parentGroupName;
        }

        private ThreadEvent(ThreadEventType type, int threadId) {
            this.type = ThreadEventType.END;
            this.objectId = -1;
            this.threadId = threadId;
            this.threadName = null;
            this.groupName = null;
            this.parentGroupName = null;
        }

        @Override public int hashCode() {
            int result = 17;
            result = 31 * result + objectId;
            result = 31 * result + threadId;
            result = 31 * result + hashCode(threadName);
            result = 31 * result + hashCode(groupName);
            result = 31 * result + hashCode(parentGroupName);
            return result;
        }

        private static int hashCode(Object o) {
            return (o == null) ? 0 : o.hashCode();
        }

        @Override public boolean equals(Object o) {
            if (!(o instanceof ThreadEvent)) {
                return false;
            }
            ThreadEvent event = (ThreadEvent) o;
            return (this.type == event.type
                    && this.objectId == event.objectId
                    && this.threadId == event.threadId
                    && equal(this.threadName, event.threadName)
                    && equal(this.groupName, event.groupName)
                    && equal(this.parentGroupName, event.parentGroupName));
        }

        private static boolean equal(Object a, Object b) {
            return a == b || (a != null && a.equals(b));
        }

        @Override public String toString() {
            switch (type) {
                case START:
                    return String.format(
                            "THREAD START (obj=%d, id = %d, name=\"%s\", group=\"%s\")",
                            objectId, threadId, threadName, groupName);
                case END:
                    return String.format("THREAD END (id = %d)", threadId);
            }
            throw new IllegalStateException(type.toString());
        }
    }

    /**
     * A unique stack trace for a specific thread.
     */
    public static final class StackTrace {

        public final int stackTraceId;
        int threadId;
        StackTraceElement[] stackFrames;

        StackTrace() {
            this.stackTraceId = -1;
        }

        public StackTrace(int stackTraceId, int threadId, StackTraceElement[] stackFrames) {
            if (stackFrames == null) {
                throw new NullPointerException("stackFrames == null");
            }
            this.stackTraceId = stackTraceId;
            this.threadId = threadId;
            this.stackFrames = stackFrames;
        }

        public int getThreadId() {
            return threadId;
        }

        public StackTraceElement[] getStackFrames() {
            return stackFrames;
        }

        @Override public int hashCode() {
            int result = 17;
            result = 31 * result + threadId;
            result = 31 * result + Arrays.hashCode(stackFrames);
            return result;
        }

        @Override public boolean equals(Object o) {
            if (!(o instanceof StackTrace)) {
                return false;
            }
            StackTrace s = (StackTrace) o;
            return threadId == s.threadId && Arrays.equals(stackFrames, s.stackFrames);
        }

        @Override public String toString() {
            StringBuilder frames = new StringBuilder();
            if (stackFrames.length > 0) {
                frames.append('\n');
                for (StackTraceElement stackFrame : stackFrames) {
                    frames.append("\t at ");
                    frames.append(stackFrame);
                    frames.append('\n');
                }
            } else {
                frames.append("<empty>");
            }
            return "StackTrace[stackTraceId=" + stackTraceId
                    + ", threadId=" + threadId
                    + ", frames=" + frames + "]";

        }
    }

    /**
     * A read only container combining a stack trace with its frequency.
     */
    public static final class Sample {

        public final StackTrace stackTrace;
        public final int count;

        private Sample(StackTrace stackTrace, int count) {
            if (stackTrace == null) {
                throw new NullPointerException("stackTrace == null");
            }
            if (count < 0) {
                throw new IllegalArgumentException("count < 0:" + count);
            }
            this.stackTrace = stackTrace;
            this.count = count;
        }

        @Override public int hashCode() {
            int result = 17;
            result = 31 * result + stackTrace.hashCode();
            result = 31 * result + count;
            return result;
        }

        @Override public boolean equals(Object o) {
            if (!(o instanceof Sample)) {
                return false;
            }
            Sample s = (Sample) o;
            return count == s.count && stackTrace.equals(s.stackTrace);
        }

        @Override public String toString() {
            return "Sample[count=" + count + " " + stackTrace + "]";
        }

    }

    /**
     * Start of last sampling period.
     */
    private long startMillis;

    /**
     * CONTROL_SETTINGS flags
     */
    private int flags;

    /**
     * stack sampling depth
     */
    private int depth;

    /**
     * List of thread creation and death events.
     */
    private final List<ThreadEvent> threadHistory = new ArrayList<ThreadEvent>();

    /**
     * Map of thread id to a start ThreadEvent
     */
    private final Map<Integer, ThreadEvent> threadIdToThreadEvent
            = new HashMap<Integer, ThreadEvent>();

    /**
     * Map of stack traces to a mutable sample count. The map is
     * provided by the creator of the HprofData so only have
     * mutable access to the int[] cells that contain the sample
     * count. Only an unmodifiable iterator view is available to
     * users of the HprofData.
     */
    private final Map<HprofData.StackTrace, int[]> stackTraces;

    public HprofData(Map<StackTrace, int[]> stackTraces) {
        if (stackTraces == null) {
            throw new NullPointerException("stackTraces == null");
        }
        this.stackTraces = stackTraces;
    }

    /**
     * The start time in milliseconds of the last profiling period.
     */
    public long getStartMillis() {
        return startMillis;
    }

    /**
     * Set the time for the start of the current sampling period.
     */
    public void setStartMillis(long startMillis) {
        this.startMillis = startMillis;
    }

    /**
     * Get the {@link BinaryHprof.ControlSettings} flags
     */
    public int getFlags() {
        return flags;
    }

    /**
     * Set the {@link BinaryHprof.ControlSettings} flags
     */
    public void setFlags(int flags) {
        this.flags = flags;
    }

    /**
     * Get the stack sampling depth
     */
    public int getDepth() {
        return depth;
    }

    /**
     * Set the stack sampling depth
     */
    public void setDepth(int depth) {
        this.depth = depth;
    }

    /**
     * Return an unmodifiable history of start and end thread events.
     */
    public List<ThreadEvent> getThreadHistory() {
        return Collections.unmodifiableList(threadHistory);
    }

    /**
     * Return a new set containing the current sample data.
     */
    public Set<Sample> getSamples() {
        Set<Sample> samples = new HashSet<Sample>(stackTraces.size());
        for (Entry<StackTrace, int[]> e : stackTraces.entrySet()) {
            StackTrace stackTrace = e.getKey();
            int countCell[] = e.getValue();
            int count = countCell[0];
            Sample sample = new Sample(stackTrace, count);
            samples.add(sample);
        }
        return samples;
    }

    /**
     * Record an event in the thread history.
     */
    public void addThreadEvent(ThreadEvent event) {
        if (event == null) {
            throw new NullPointerException("event == null");
        }
        ThreadEvent old = threadIdToThreadEvent.put(event.threadId, event);
        switch (event.type) {
            case START:
                if (old != null) {
                    throw new IllegalArgumentException("ThreadEvent already registered for id "
                                                       + event.threadId);
                }
                break;
            case END:
                // Do not assert that the END_THREAD matches a
                // START_THREAD unless in strict mode. While thhis
                // hold true in the binary hprof BinaryHprofWriter
                // produces, it is not true of hprof files created
                // by the RI. However, if there is an event
                // already registed for a thread id, it should be
                // the matching start, not a duplicate end.
                if (old != null && old.type == ThreadEventType.END) {
                    throw new IllegalArgumentException("Duplicate ThreadEvent.end for id "
                                                       + event.threadId);
                }
                break;
        }
        threadHistory.add(event);
    }

    /**
     * Record an stack trace and an associated int[] cell of
     * sample cound for the stack trace. The caller is allowed
     * retain a pointer to the cell to update the count. The
     * SamplingProfiler intentionally does not present a mutable
     * view of the count.
     */
    public void addStackTrace(StackTrace stackTrace, int[] countCell) {
        if (!threadIdToThreadEvent.containsKey(stackTrace.threadId)) {
            throw new IllegalArgumentException("Unknown thread id " + stackTrace.threadId);
        }
        int[] old = stackTraces.put(stackTrace, countCell);
        if (old != null) {
            throw new IllegalArgumentException("StackTrace already registered for id "
                                               + stackTrace.stackTraceId + ":\n" + stackTrace);
        }
    }
}
