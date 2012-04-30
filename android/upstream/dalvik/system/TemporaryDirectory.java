/*
 * Copyright (C) 2008 The Android Open Source Project
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

/**
 * Utility class to handle the setup of the core library's concept of
 * what the "default temporary directory" is. Application code may
 * call into this class with an appropriate base directory during its
 * startup, as a reasonably easy way to get the standard property
 * <code>java.io.tmpdir</code> to point at something useful.
 *
 * @hide
 */
public class TemporaryDirectory {
    /** system property name for the temporary directory */
    private static final String PROPERTY = "java.io.tmpdir";

    /** final path component name for the temporary directory */
    private static final String PATH_NAME = "tmp";

    /** whether a temporary directory has been configured yet */
    private static boolean configured = false;

    /**
     * Convenience method which is equivalent to
     * <code>setupDirectory(new File(baseDir))</code>.
     *
     * @param baseDir the base directory of the temporary directory
     */
    public static void setUpDirectory(String baseDir) {
        setUpDirectory(new File(baseDir));
    }

    /**
     * Sets up the temporary directory, but only if one isn't already
     * defined for this process, and only if it is possible (e.g., the
     * directory already exists and is read-write, or the directory
     * can be created). This call will do one of three things:
     *
     * <ul>
     * <li>return without error and without doing anything, if a
     * previous call to this method succeeded</li>
     * <li>return without error, having either created a temporary
     * directory under the given base or verified that such a directory
     * already exists</li>
     * <li>throw <code>UnsupportedOperationException</code> if the
     * directory could not be created or accessed</li>
     * </ul>
     *
     * @param baseDir the base directory of the temporary directory
     */
    public static synchronized void setUpDirectory(File baseDir) {
        if (configured) {
            System.logE("Already set to: " + System.getProperty(PROPERTY));
            return;
        }

        File dir = new File(baseDir, PATH_NAME);
        String absolute = dir.getAbsolutePath();

        if (dir.exists()) {
            if (!dir.isDirectory()) {
                throw new UnsupportedOperationException(
                        "Name is used by a non-directory file: " +
                        absolute);
            } else if (!(dir.canRead() && dir.canWrite())) {
                throw new UnsupportedOperationException(
                        "Existing directory is not readable and writable: " +
                        absolute);
            }
        } else {
            if (!dir.mkdirs()) {
                throw new UnsupportedOperationException(
                        "Failed to create directory: " + absolute);
            }
        }

        System.setProperty(PROPERTY, absolute);
        configured = true;
    }
}
