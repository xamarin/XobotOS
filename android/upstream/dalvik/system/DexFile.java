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

import java.io.File;
import java.io.FileNotFoundException;
import java.io.IOException;
import java.util.Enumeration;

/**
 * Manipulates DEX files. The class is similar in principle to
 * {@link java.util.zip.ZipFile}. It is used primarily by class loaders.
 * <p>
 * Note we don't directly open and read the DEX file here. They're memory-mapped
 * read-only by the VM.
 */
public final class DexFile {
    private int mCookie;
    private final String mFileName;
    private final CloseGuard guard = CloseGuard.get();

    /**
     * Opens a DEX file from a given File object. This will usually be a ZIP/JAR
     * file with a "classes.dex" inside.
     *
     * The VM will generate the name of the corresponding file in
     * /data/dalvik-cache and open it, possibly creating or updating
     * it first if system permissions allow.  Don't pass in the name of
     * a file in /data/dalvik-cache, as the named file is expected to be
     * in its original (pre-dexopt) state.
     *
     * @param file
     *            the File object referencing the actual DEX file
     *
     * @throws IOException
     *             if an I/O error occurs, such as the file not being found or
     *             access rights missing for opening it
     */
    public DexFile(File file) throws IOException {
        this(file.getPath());
    }

    /**
     * Opens a DEX file from a given filename. This will usually be a ZIP/JAR
     * file with a "classes.dex" inside.
     *
     * The VM will generate the name of the corresponding file in
     * /data/dalvik-cache and open it, possibly creating or updating
     * it first if system permissions allow.  Don't pass in the name of
     * a file in /data/dalvik-cache, as the named file is expected to be
     * in its original (pre-dexopt) state.
     *
     * @param fileName
     *            the filename of the DEX file
     *
     * @throws IOException
     *             if an I/O error occurs, such as the file not being found or
     *             access rights missing for opening it
     */
    public DexFile(String fileName) throws IOException {
        mCookie = openDexFile(fileName, null, 0);
        mFileName = fileName;
        guard.open("close");
        //System.out.println("DEX FILE cookie is " + mCookie);
    }

    /**
     * Opens a DEX file from a given filename, using a specified file
     * to hold the optimized data.
     *
     * @param sourceName
     *  Jar or APK file with "classes.dex".
     * @param outputName
     *  File that will hold the optimized form of the DEX data.
     * @param flags
     *  Enable optional features.
     */
    private DexFile(String sourceName, String outputName, int flags) throws IOException {
        mCookie = openDexFile(sourceName, outputName, flags);
        mFileName = sourceName;
        guard.open("close");
        //System.out.println("DEX FILE cookie is " + mCookie);
    }

    /**
     * Open a DEX file, specifying the file in which the optimized DEX
     * data should be written.  If the optimized form exists and appears
     * to be current, it will be used; if not, the VM will attempt to
     * regenerate it.
     *
     * This is intended for use by applications that wish to download
     * and execute DEX files outside the usual application installation
     * mechanism.  This function should not be called directly by an
     * application; instead, use a class loader such as
     * dalvik.system.DexClassLoader.
     *
     * @param sourcePathName
     *  Jar or APK file with "classes.dex".  (May expand this to include
     *  "raw DEX" in the future.)
     * @param outputPathName
     *  File that will hold the optimized form of the DEX data.
     * @param flags
     *  Enable optional features.  (Currently none defined.)
     * @return
     *  A new or previously-opened DexFile.
     * @throws IOException
     *  If unable to open the source or output file.
     */
    static public DexFile loadDex(String sourcePathName, String outputPathName,
        int flags) throws IOException {

        /*
         * TODO: we may want to cache previously-opened DexFile objects.
         * The cache would be synchronized with close().  This would help
         * us avoid mapping the same DEX more than once when an app
         * decided to open it multiple times.  In practice this may not
         * be a real issue.
         */
        return new DexFile(sourcePathName, outputPathName, flags);
    }

    /**
     * Gets the name of the (already opened) DEX file.
     *
     * @return the file name
     */
    public String getName() {
        return mFileName;
    }

    /**
     * Closes the DEX file.
     * <p>
     * This may not be able to release any resources. If classes from this
     * DEX file are still resident, the DEX file can't be unmapped.
     *
     * @throws IOException
     *             if an I/O error occurs during closing the file, which
     *             normally should not happen
     */
    public void close() throws IOException {
        guard.close();
        closeDexFile(mCookie);
        mCookie = 0;
    }

    /**
     * Loads a class. Returns the class on success, or a {@code null} reference
     * on failure.
     * <p>
     * If you are not calling this from a class loader, this is most likely not
     * going to do what you want. Use {@link Class#forName(String)} instead.
     * <p>
     * The method does not throw {@link ClassNotFoundException} if the class
     * isn't found because it isn't reasonable to throw exceptions wildly every
     * time a class is not found in the first DEX file we look at.
     *
     * @param name
     *            the class name, which should look like "java/lang/String"
     *
     * @param loader
     *            the class loader that tries to load the class (in most cases
     *            the caller of the method
     *
     * @return the {@link Class} object representing the class, or {@code null}
     *         if the class cannot be loaded
     */
    public Class loadClass(String name, ClassLoader loader) {
        String slashName = name.replace('.', '/');
        return loadClassBinaryName(slashName, loader);
    }

    /**
     * See {@link #loadClass(String, ClassLoader)}.
     *
     * This takes a "binary" class name to better match ClassLoader semantics.
     *
     * @hide
     */
    public Class loadClassBinaryName(String name, ClassLoader loader) {
        return defineClass(name, loader, mCookie);
    }

    private native static Class defineClass(String name, ClassLoader loader, int cookie);

    /**
     * Enumerate the names of the classes in this DEX file.
     *
     * @return an enumeration of names of classes contained in the DEX file, in
     *         the usual internal form (like "java/lang/String").
     */
    public Enumeration<String> entries() {
        return new DFEnum(this);
    }

    /*
     * Helper class.
     */
    private class DFEnum implements Enumeration<String> {
        private int mIndex;
        private String[] mNameList;

        DFEnum(DexFile df) {
            mIndex = 0;
            mNameList = getClassNameList(mCookie);
        }

        public boolean hasMoreElements() {
            return (mIndex < mNameList.length);
        }

        public String nextElement() {
            return mNameList[mIndex++];
        }
    }

    /* return a String array with class names */
    native private static String[] getClassNameList(int cookie);

    /**
     * Called when the class is finalized. Makes sure the DEX file is closed.
     *
     * @throws IOException
     *             if an I/O error occurs during closing the file, which
     *             normally should not happen
     */
    @Override protected void finalize() throws Throwable {
        try {
            if (guard != null) {
                guard.warnIfOpen();
            }
            close();
        } finally {
            super.finalize();
        }
    }

    /*
     * Open a DEX file.  The value returned is a magic VM cookie.  On
     * failure, an IOException is thrown.
     */
    native private static int openDexFile(String sourceName, String outputName,
        int flags) throws IOException;

    /*
     * Open a DEX file based on a {@code byte[]}. The value returned
     * is a magic VM cookie. On failure, a RuntimeException is thrown.
     */
    native private static int openDexFile(byte[] fileContents);

    /*
     * Close DEX file.
     */
    native private static void closeDexFile(int cookie);

    /**
     * Returns true if the VM believes that the apk/jar file is out of date
     * and should be passed through "dexopt" again.
     *
     * @param fileName the absolute path to the apk/jar file to examine.
     * @return true if dexopt should be called on the file, false otherwise.
     * @throws java.io.FileNotFoundException if fileName is not readable,
     *         not a file, or not present.
     * @throws java.io.IOException if fileName is not a valid apk/jar file or
     *         if problems occur while parsing it.
     * @throws java.lang.NullPointerException if fileName is null.
     * @throws dalvik.system.StaleDexCacheError if the optimized dex file
     *         is stale but exists on a read-only partition.
     */
    native public static boolean isDexOptNeeded(String fileName)
            throws FileNotFoundException, IOException;
}
