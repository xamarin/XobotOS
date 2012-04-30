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

/**
 * The {@code ThreadSampler} interfaces allows a profiler to choose
 * between portable and VM specific implementations of thread
 * sampling.
 */
public interface ThreadSampler {

    /**
     * Used to specify the maximum stack depth to collect.
     */
    public void setDepth(int depth);

    /**
     * Return a stack trace for the current thread limited by the
     * maximum depth specified by {@link #setDepth setDepth}. May
     * return null if no sample is availble for the thread, which may
     * happen in cases such as thread termination. The resulting array
     * should be copied before the next call to {@code getStackTrace}
     * if the caller wants to use the results, since the {@code
     * ThreadSampler} may reuse the array. Note that the elements
     * themselves are immutable and do not need to be copied.
     */
    public StackTraceElement[] getStackTrace(Thread thread);
}
