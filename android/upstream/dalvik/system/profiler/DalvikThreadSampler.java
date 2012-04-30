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

import dalvik.system.VMStack;
import java.util.Arrays;

class DalvikThreadSampler implements ThreadSampler {

    private int depth;

    /**
     * Reusable storage for sampling sized for the specified depth.
     */
    private StackTraceElement[][] mutableStackTraceElements;

    @Override public void setDepth(int depth) {
        this.depth = depth;
        this.mutableStackTraceElements = new StackTraceElement[depth+1][];
        for (int i = 1; i < mutableStackTraceElements.length; i++) {
            this.mutableStackTraceElements[i] = new StackTraceElement[i];
        }
    }

    @Override public StackTraceElement[] getStackTrace(Thread thread) {
        int count = VMStack.fillStackTraceElements(thread, mutableStackTraceElements[depth]);
        if (count == 0) {
            return null;
        }
        if (count < depth) {
            System.arraycopy(mutableStackTraceElements[depth], 0,
                             mutableStackTraceElements[count], 0,
                             count);
        }
        return mutableStackTraceElements[count];
    }
}
