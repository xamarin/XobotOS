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

import java.io.IOException;
import java.io.OutputStream;
import java.io.PrintWriter;
import java.util.ArrayList;
import java.util.Collections;
import java.util.Comparator;
import java.util.Date;
import java.util.List;

/**
 * AsciiHprofWriter produces hprof compatible text output for use with
 * third party tools such as PerfAnal.
 */
public final class AsciiHprofWriter {

    private final HprofData data;
    private final PrintWriter out;

    /**
     * Writes the provided data to the specified stream.
     */
    public static void write(HprofData data, OutputStream outputStream) throws IOException {
        new AsciiHprofWriter(data, outputStream).write();
    }

    private AsciiHprofWriter(HprofData data, OutputStream outputStream) {
        this.data = data;
        this.out = new PrintWriter(outputStream);
    }

    private void write() throws IOException {
        for (HprofData.ThreadEvent e : data.getThreadHistory()) {
            out.println(e);
        }

        List<HprofData.Sample> samples
                = new ArrayList<HprofData.Sample>(data.getSamples());
        Collections.sort(samples, SAMPLE_COMPARATOR);
        int total = 0;
        for (HprofData.Sample sample : samples) {
            HprofData.StackTrace stackTrace = sample.stackTrace;
            int count = sample.count;
            total += count;
            out.printf("TRACE %d: (thread=%d)\n",
                       stackTrace.stackTraceId,
                       stackTrace.threadId);
            for (StackTraceElement e : stackTrace.stackFrames) {
                out.printf("\t%s\n", e);
            }
        }
        Date now = new Date(data.getStartMillis());
        // "CPU SAMPLES BEGIN (total = 826) Wed Jul 21 12:03:46 2010"
        out.printf("CPU SAMPLES BEGIN (total = %d) %ta %tb %td %tT %tY\n",
                   total, now, now, now, now, now);
        out.printf("rank   self  accum   count trace method\n");
        int rank = 0;
        double accum = 0;
        for (HprofData.Sample sample : samples) {
            rank++;
            HprofData.StackTrace stackTrace = sample.stackTrace;
            int count = sample.count;
            double self = (double)count/(double)total;
            accum += self;

            // "   1 65.62% 65.62%     542 300302 java.lang.Long.parseLong"
            out.printf("% 4d% 6.2f%%% 6.2f%% % 7d % 5d %s.%s\n",
                       rank, self*100, accum*100, count, stackTrace.stackTraceId,
                       stackTrace.stackFrames[0].getClassName(),
                       stackTrace.stackFrames[0].getMethodName());
        }
        out.printf("CPU SAMPLES END\n");
        out.flush();
    }

    private static final Comparator<HprofData.Sample> SAMPLE_COMPARATOR
            = new Comparator<HprofData.Sample>() {
        public int compare(HprofData.Sample s1, HprofData.Sample s2) {
            return s2.count - s1.count;
        }
    };
}
