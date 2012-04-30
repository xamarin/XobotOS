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

import java.util.Arrays;

/**
 * ThreadSampler implementation that only uses Thread.getStackTrace()
 * and therefore is portable.
 */
class PortableThreadSampler implements ThreadSampler {

    private int depth;

    @Override public void setDepth(int depth) {
        this.depth = depth;
    }

    @Override public StackTraceElement[] getStackTrace(Thread thread) {
        StackTraceElement[] stackFrames = thread.getStackTrace();
        if (stackFrames.length == 0) {
            return null;
        }
        if (stackFrames.length > depth) {
            stackFrames = Arrays.copyOfRange(stackFrames, 0, depth);
        }
        return stackFrames;
    }
}
