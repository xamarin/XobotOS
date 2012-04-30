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
import java.io.Closeable;
import java.io.DataInputStream;
import java.io.EOFException;
import java.io.File;
import java.io.FileInputStream;
import java.io.IOException;
import java.io.InputStream;

/**
 * Run on device with:
 * adb shell dalvikvm 'dalvik.system.profiler.HprofBinaryToAscii'
 *
 * Run on host with:
 * java -classpath out/target/common/obj/JAVA_LIBRARIES/core_intermediates/classes.jar
 */
public final class HprofBinaryToAscii {

    /**
     * Main entry point for HprofBinaryToAscii command line tool
     */
    public static void main(String[] args) {
        System.exit(convert(args) ? 0 : 1);
    }

    /**
     * Reads single file from arguments and attempts to read it as
     * either a binary hprof file or a version with a text header.
     */
    private static boolean convert(String[] args) {

        if (args.length != 1) {
            usage("binary hprof file argument expected");
            return false;
        }
        File file = new File(args[0]);
        if (!file.exists()) {
            usage("file " + file + " does not exist");
            return false;
        }

        if (startsWithMagic(file)) {
            HprofData hprofData;
            try {
                hprofData = readHprof(file);
            } catch (IOException e) {
                System.out.println("Problem reading binary hprof data from "
                                   + file + ": " + e.getMessage());
                return false;
            }
            return write(hprofData);
        }

        HprofData hprofData;
        try {
            hprofData = readSnapshot(file);
        } catch (IOException e) {
            System.out.println("Problem reading snapshot containing binary hprof data from "
                               + file + ": " + e.getMessage());
            return false;
        }
        return write(hprofData);
    }

    /**
     * Probe the start of file to see if it starts with a plausible
     * binary hprof magic value. If so, it is returned. On any other
     * case including unexpected errors, false is returned.
     */
    private static boolean startsWithMagic(File file) {
        DataInputStream inputStream = null;
        try {
            inputStream = new DataInputStream(new BufferedInputStream(new FileInputStream(file)));
            return BinaryHprof.readMagic(inputStream) != null;
        } catch (IOException e) {
            return false;
        } finally {
            closeQuietly(inputStream);
        }
    }

    /**
     * Read and return an HprofData from a vanilla binary hprof file.
     */
    private static HprofData readHprof(File file) throws IOException {
        InputStream inputStream = null;
        try {
            inputStream = new BufferedInputStream(new FileInputStream(file));
            return read(inputStream);
        } finally {
            closeQuietly(inputStream);
        }
    }

    /**
     * Read a file looking for text header terminated by two newlines,
     * then proceed to read binary hprof data.
     */
    private static HprofData readSnapshot(File file) throws IOException {
        InputStream inputStream = null;
        try {
            inputStream = new BufferedInputStream(new FileInputStream(file));
            int ch;
            while ((ch = inputStream.read()) != -1) {
                if (ch == '\n' && inputStream.read() == '\n') {
                    return read(inputStream);
                }
            }
            throw new EOFException("Could not find expected header");
        } finally {
            closeQuietly(inputStream);
        }
    }

    /**
     * Read binary hprof data from the provided input stream and
     * return the HprofData object.
     */
    private static HprofData read(InputStream inputStream) throws IOException {
        BinaryHprofReader reader = new BinaryHprofReader(inputStream);
        reader.setStrict(false);
        reader.read();
        return reader.getHprofData();
    }

    /**
     * From IoUtils.closeQuietly but replicated for open source
     * version.
     */
    private static void closeQuietly(Closeable c) {
        if (c != null) {
            try {
                c.close();
            } catch (IOException ignored) {
            }
        }
    }

    /**
     * Write text verion of hprof data to standard output. Returns
     * false on error.
     */
    private static boolean write(HprofData hprofData) {
        try {
            AsciiHprofWriter.write(hprofData, System.out);
        } catch (IOException e) {
            System.out.println("Problem writing ASCII hprof data: " + e.getMessage());
            return false;
        }
        return true;
    }

    /**
     * Prints usage error but does not exit.
     */
    private static void usage(String error) {
        System.out.print("ERROR: ");
        System.out.println(error);
        System.out.println();
        System.out.println("usage: HprofBinaryToAscii <binary-hprof-file>");
        System.out.println();
        System.out.println("Reads a binary hprof file and print it in ASCII format");
    }
}
