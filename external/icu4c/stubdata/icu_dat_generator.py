#!/usr/bin/python
#
# Copyright (C) 2010 The Android Open Source Project
#
# Licensed under the Apache License, Version 2.0 (the "License");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
#
#      http://www.apache.org/licenses/LICENSE-2.0
#
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an "AS IS" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.
#
# Generate ICU dat files for locale relevant resources.
#
# Usage:
#    icu_dat_generator.py [-v] [-h]
#
# Sample usage:
#   $ANDROID_BUILD_TOP/external/icu4c/stubdata$ ./icu_dat_generator.py --verbose
#
#  Add new dat file:
#   1. Add icudtxxl-<datname>.txt to $ANDROID_BUILD_TOP/external/icu4c/stubdata.
#      Check the example file under
#      $ANDROID_BUILD_TOP/external/icu4c/stubdata/icudt46l-us.txt
#   2. Add an entry to main() --> datlist[]
#   3. Run this script to generate dat files.
#
#  For ICU upgrade
#    We cannot get CLDR version from dat file unless calling ICU function.
#    If there is a CLDR version change, please modify "global CLDR_VERSION".

import getopt
import glob
import os.path
import re
import shutil
import subprocess
import sys


def PrintHelpAndExit():
  print "Usage:"
  print "  icu_dat_generator.py [-v|--verbose] [-h|--help]"
  print "Example:"
  print "  $ANDROID_BUILD_TOP/external/icu4c/stubdata$ ./icu_dat_generator.py"
  sys.exit(1)


def InvokeIcuTool(tool, working_dir, args):
  command_list = [os.path.join(ICU_PREBUILT_DIR, tool)]
  command_list.extend(args)

  if VERBOSE:
    command = "[%s] %s" % (working_dir, " ".join(command_list))
    print command

  ret = subprocess.call(command_list, cwd=working_dir)
  if ret != 0:
    sys.exit(command_list[0:])


def ExtractAllResourceToTempDir():
  # copy icudtxxl-all.dat to icudtxxl.dat
  src_dat = os.path.join(ICU4C_DIR, "stubdata", ICUDATA + "-all.dat")
  dst_dat = os.path.join(ICU4C_DIR, "stubdata", ICUDATA + ".dat")
  shutil.copyfile(src_dat, dst_dat)
  InvokeIcuTool("icupkg", None, [dst_dat, "-x", "*", "-d", TMP_DAT_PATH])


def MakeDat(input_file, stubdata_dir):
  print "------ Processing '%s'..." % (input_file)
  if not os.path.isfile(input_file):
    print "%s not a file!" % input_file
    sys.exit(1)
  GenResIndex(input_file)
  CopyAndroidCnvFiles(stubdata_dir)
  # Run "icupkg -tl -s icudt46l -a icudt46l-us.txt new icudt46l.dat".
  args = ["-tl", "-s", TMP_DAT_PATH, "-a", input_file, "new", ICUDATA + ".dat"]
  InvokeIcuTool("icupkg", TMP_DAT_PATH, args)


def WriteIndex(path, locales, cldr_version=None):
  empty_value = " {\"\"}\n"  # key-value pair for all locale entries

  f = open(path, "w")
  f.write("res_index:table(nofallback) {\n")
  if cldr_version:
    f.write("  CLDRVersion { %s }\n" % cldr_version)
  f.write("  InstalledLocales {\n")
  for locale in locales:
    f.write(locale + empty_value)

  f.write("  }\n")
  f.write("}\n")
  f.close()


def AddResFile(collection, path):
  # There are two consumers of the the input .txt file: this script and
  # icupkg. We only care about .res files, but icupkg needs files they depend
  # on too, so it's not an error to have to ignore non-.res files here.
  end = path.find(".res")
  if end > 0:
    collection.add(path[path.find("/")+1:end])
  return


# Open input file (such as icudt46l-us.txt).
# Go through the list and generate res_index.txt for locales, brkitr,
# coll, et cetera.
def GenResIndex(input_file):
  res_index = "res_index.txt"

  brkitrs = set()
  colls = set()
  currs = set()
  langs = set()
  locales = set()
  regions = set()
  zones = set()

  for line in open(input_file, "r"):
    if "root." in line or "res_index" in line or "_.res" in line:
      continue
    if "brkitr/" in line:
      AddResFile(brkitrs, line)
    elif "coll/" in line:
      AddResFile(colls, line)
    elif "curr/" in line:
      AddResFile(currs, line)
    elif "lang/" in line:
      AddResFile(langs, line)
    elif "region/" in line:
      AddResFile(regions, line)
    elif "zone/" in line:
      AddResFile(zones, line)
    elif ".res" in line:
      # We need to determine the resource is locale resource or misc resource.
      # To determine the locale resource, we assume max script length is 3.
      end = line.find(".res")
      if end <= 3 or (line.find("_") <= 3 and line.find("_") > 0):
        locales.add(line[:end])

  kind_to_locales = {
      "brkitr": brkitrs,
      "coll": colls,
      "curr": currs,
      "lang": langs,
      "locales": locales,
      "region": regions,
      "zone": zones
  }

  # Find every locale we've mentioned, for whatever reason.
  every_locale = set()
  for locales in kind_to_locales.itervalues():
    every_locale = every_locale.union(locales)

  if VERBOSE:
    for kind, locales in kind_to_locales.items():
      print "%s=%s" % (kind, sorted(locales))

  # Print a human-readable list of the languages supported.
  every_language = set()
  for locale in every_locale:
    language = re.sub(r"(_.*)", "", locale)
    if language != "pool" and language != "supplementalData":
      every_language.add(language)
  input_basename = os.path.basename(input_file)
  print "%s includes %s." % (input_basename, ", ".join(sorted(every_language)))

  # Find cases where we've included only part of a locale's data.
  missing_files = []
  for locale in every_locale:
    for kind, locales in kind_to_locales.items():
      p = os.path.join(ICU4C_DIR, "data", kind, locale + ".txt")
      if not locale in locales and os.path.exists(p):
        missing_files.append(p)

  # Warn about the missing files.
  for missing_file in sorted(missing_files):
    relative_path = "/".join(missing_file.split("/")[-2:])
    print "warning: missing data for supported locale: %s" % relative_path

  # Write the genrb input files.
  WriteIndex(os.path.join(TMP_DAT_PATH, res_index), locales, CLDR_VERSION)
  for kind, locales in kind_to_locales.items():
    if kind == "locales":
      continue
    WriteIndex(os.path.join(TMP_DAT_PATH, kind, res_index), locales)

  # Call genrb to generate new res_index.res.
  InvokeIcuTool("genrb", TMP_DAT_PATH, [res_index])
  for kind, locales in kind_to_locales.items():
    if kind == "locales":
      continue
    InvokeIcuTool("genrb", os.path.join(TMP_DAT_PATH, kind), [res_index])


def CopyAndroidCnvFiles(stubdata_dir):
  android_specific_cnv = ["gsm-03.38-2000.cnv",
                          "iso-8859_16-2001.cnv",
                          "docomo-shift_jis-2007.cnv",
                          "kddi-jisx-208-2007.cnv",
                          "kddi-shift_jis-2007.cnv",
                          "softbank-jisx-208-2007.cnv",
                          "softbank-shift_jis-2007.cnv"]
  for cnv_file in android_specific_cnv:
    src_path = os.path.join(stubdata_dir, "cnv", cnv_file)
    dst_path = os.path.join(TMP_DAT_PATH, cnv_file)
    shutil.copyfile(src_path, dst_path)
    if VERBOSE:
      print "copy " + src_path + " " + dst_path


def main():
  global ANDROID_BUILD_TOP  # $ANDROID_BUILD_TOP
  global ICU4C_DIR          # $ANDROID_BUILD_TOP/external/icu4c
  global ICU_PREBUILT_DIR   # Directory containing pre-built ICU tools.
  global ICUDATA       # e.g. "icudt46l"
  global CLDR_VERSION  # CLDR version. The value varies between ICU releases.
  global TMP_DAT_PATH  # temp directory to store all resource files and
                       # intermediate dat files.
  global VERBOSE

  CLDR_VERSION = "1.9"
  VERBOSE = False

  show_help = False
  try:
    opts, args = getopt.getopt(sys.argv[1:], "hv", ["help", "verbose"])
  except getopt.error:
    PrintHelpAndExit()
  for opt, _ in opts:
    if opt in ("-h", "--help"):
      show_help = True
    elif opt in ("-v", "--verbose"):
      VERBOSE = True
  if args:
    show_help = True

  if show_help:
    PrintHelpAndExit()

  ANDROID_BUILD_TOP = os.environ.get("ANDROID_BUILD_TOP")
  if not ANDROID_BUILD_TOP:
    print "$ANDROID_BUILD_TOP not set! Run 'env_setup.sh'."
    sys.exit(1)
  ICU4C_DIR = os.path.join(ANDROID_BUILD_TOP, "external", "icu4c")
  stubdata_dir = os.path.join(ICU4C_DIR, "stubdata")

  # Find all the input files.
  input_files = glob.glob(os.path.join(stubdata_dir, "icudt[0-9][0-9]l-*.txt"))

  # Work out the ICU version from the input filenames, so we can find the
  # appropriate pre-built ICU tools.
  icu_version = re.sub(r"([^0-9])", "", os.path.basename(input_files[0]))
  ICU_PREBUILT_DIR = os.path.join(os.environ.get("ANDROID_EABI_TOOLCHAIN"),
      "..", "..", "..", "icu-%s.%s" % (icu_version[0], icu_version[1]))
  if not os.path.exists(ICU_PREBUILT_DIR):
    print "%s does not exist!" % ICU_PREBUILT_DIR

  ICUDATA = "icudt" + icu_version + "l"

  # Check that -all.dat exists (since we build the other .dat files from that).
  full_data_filename = os.path.join(stubdata_dir, ICUDATA + "-all.dat")
  if not os.path.isfile(full_data_filename):
    print "%s not present." % full_data_filename
    sys.exit(1)

  # Create a temporary working directory.
  TMP_DAT_PATH = os.path.join(ICU4C_DIR, "tmp")
  if os.path.exists(TMP_DAT_PATH):
    shutil.rmtree(TMP_DAT_PATH)
  os.mkdir(TMP_DAT_PATH)

  # Extract resource files from icudtxxl-all.dat to TMP_DAT_PATH.
  ExtractAllResourceToTempDir()

  # Process each input file in turn.
  for input_file in sorted(input_files):
    output_file = input_file[:-3] + "dat"
    MakeDat(input_file, stubdata_dir)
    shutil.copyfile(os.path.join(TMP_DAT_PATH, ICUDATA + ".dat"), output_file)
    print "Generated ICU data: %s" % output_file

  # Cleanup temporary working directory and icudtxxl.dat
  shutil.rmtree(TMP_DAT_PATH)
  os.remove(os.path.join(stubdata_dir, ICUDATA + ".dat"))

if __name__ == "__main__":
  main()
