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

package dalvik.system;

/**
 * Dummy class used during JNI initialization.  The JNI functions want
 * to be able to create objects, and the VM needs to discard the references
 * when the function returns.  That gets a little weird when we're
 * calling JNI functions from the C main(), and there's no Java stack frame
 * to hitch the references onto.
 *
 * Rather than having some special-case code, we create this simple little
 * class and pretend that it called the C main().
 *
 * This also comes in handy when a native thread attaches itself with the
 * JNI AttachCurrentThread call.  If they attach the thread and start
 * creating objects, we need a fake frame to store stuff in.
 */
class NativeStart {
    private NativeStart() {}

    private static native void main(String[] dummy);

    private static native void run();
}
