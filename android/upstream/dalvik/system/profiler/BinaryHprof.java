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

import java.io.DataInputStream;
import java.io.IOException;
import java.util.HashMap;
import java.util.Map;

/**
 * Hprof binary format related constants shared between the
 * BinaryHprofReader and BinaryHprofWriter.
 */
public final class BinaryHprof {
    /**
     * Currently code only supports 4 byte id size.
     */
    public static final int ID_SIZE = 4;

    /**
     * Prefix of valid magic values from the start of a binary hprof file.
     */
    static String MAGIC = "JAVA PROFILE ";

    /**
     * Returns the file's magic value as a String if found, otherwise null.
     */
    public static final String readMagic(DataInputStream in) {
        try {
            byte[] bytes = new byte[512];
            for (int i = 0; i < bytes.length; i++) {
                byte b = in.readByte();
                if (b == '\0') {
                    String string = new String(bytes, 0, i, "UTF-8");
                    if (string.startsWith(MAGIC)) {
                        return string;
                    }
                    return null;
                }
                bytes[i] = b;
            }
            return null;
        } catch (IOException e) {
            return null;
        }
    }

    public static enum Tag {

        STRING_IN_UTF8(0x01, -ID_SIZE),
        LOAD_CLASS(0x02, 4 + ID_SIZE + 4 + ID_SIZE),
        UNLOAD_CLASS(0x03, 4),
        STACK_FRAME(0x04, ID_SIZE + ID_SIZE + ID_SIZE + ID_SIZE + 4 + 4),
        STACK_TRACE(0x05, -(4 + 4 + 4)),
        ALLOC_SITES(0x06, -(2 + 4 + 4 + 4 + 8 + 8 + 4)),
        HEAP_SUMMARY(0x07, 4 + 4 + 8 + 8),
        START_THREAD(0x0a, 4 + ID_SIZE + 4 + ID_SIZE + ID_SIZE + ID_SIZE),
        END_THREAD(0x0b, 4),
        HEAP_DUMP(0x0c, -0),
        HEAP_DUMP_SEGMENT(0x1c, -0),
        HEAP_DUMP_END(0x2c, 0),
        CPU_SAMPLES(0x0d, -(4 + 4)),
        CONTROL_SETTINGS(0x0e, 4 + 2);

        public final byte tag;

        /**
         * Minimum size in bytes.
         */
        public final int minimumSize;

        /**
         * Maximum size in bytes. 0 mean no specific limit.
         */
        public final int maximumSize;

        private Tag(int tag, int size) {
            this.tag = (byte) tag;
            if (size > 0) {
                // fixed size, max and min the same
                this.minimumSize = size;
                this.maximumSize = size;
            } else {
                // only minimum bound
                this.minimumSize = -size;
                this.maximumSize = 0;
            }
        }

        private static final Map<Byte, Tag> BYTE_TO_TAG
                = new HashMap<Byte, Tag>();

        static {
            for (Tag v : Tag.values()) {
                BYTE_TO_TAG.put(v.tag, v);
            }
        }

        public static Tag get(byte tag) {
            return BYTE_TO_TAG.get(tag);
        }

        /**
         * Returns null if the actual size meets expectations, or a
         * String error message if not.
         */
        public String checkSize(int actual) {
            if (actual < minimumSize) {
                return "expected a minimial record size of " + minimumSize + " for " + this
                        + " but received " + actual;
            }
            if (maximumSize == 0) {
                return null;
            }
            if (actual > maximumSize) {
                return "expected a maximum record size of " + maximumSize + " for " + this
                        + " but received " + actual;
            }
            return null;
        }
    }

    public static enum ControlSettings {
        ALLOC_TRACES(0x01),
        CPU_SAMPLING(0x02);

        public final int bitmask;

        private ControlSettings(int bitmask) {
            this.bitmask = bitmask;
        }
    }

}
