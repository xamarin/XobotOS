/*
 * Copyright (C) 2007 The Android Open Source Project
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

package org.apache.harmony.dalvik;

/**
 * Methods used to test calling into native code. The methods in this
 * class are all effectively no-ops and may be used to test the mechanisms
 * and performance of calling native methods.
 */
public final class NativeTestTarget {
    /**
     * This class is uninstantiable.
     */
    private NativeTestTarget() {
        // This space intentionally left blank.
    }

    /**
     * This is an empty native static method with no args, hooked up using
     * JNI.
     */
    public static native void emptyJniStaticMethod0();

    /**
     * This is an empty native static method with six args, hooked up using
     * JNI.
     */
    public static native void emptyJniStaticMethod6(int a, int b, int c,
        int d, int e, int f);

    /**
     * This is an empty native static method with six args, hooked up
     * using JNI. These have more complex args to show the cost of
     * parsing the signature. All six values should be null
     * references.
     */
    public static native void emptyJniStaticMethod6L(String a, String[] b,
        int[][] c, Object d, Object[] e, Object[][][][] f);

    /**
     * This method is intended to be "inlined" by the virtual machine
     * (e.g., given special treatment as an intrinsic).
     */
    public static void emptyInlineMethod() {
        // This space intentionally left blank.
    }

    /**
     * This method is intended to be defined in native code and hooked
     * up using the virtual machine's special fast-path native linkage
     * (as opposed to being hooked up using JNI).
     */
    public static native void emptyInternalStaticMethod();
}
