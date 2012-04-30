
{
  'includes': [
    '../skia/gyp/common.gypi',
  ],
  'targets': [
    {
      'target_name': 'xorpt',
      'type': 'executable',
      'mac_bundle' : 1,
      'include_dirs' : [
        'include'
      ],
      'conditions': [
        [ 'skia_os == "linux"', {
          'cflags': [
            '-fPIC', '-Wall'
          ],
          'sources': [
          ],
        }],
      ],
      'sources' : [
        'aapt/AaptAssets.cpp',
        'aapt/Command.cpp',
        'aapt/CrunchCache.cpp',
        'aapt/FileFinder.cpp',
        'aapt/Images.cpp',
        'aapt/Main.cpp',
        'aapt/Package.cpp',
        'aapt/Resource.cpp',
        'aapt/ResourceFilter.cpp',
        'aapt/ResourceTable.cpp',
        'aapt/SourcePos.cpp',
        'aapt/StringPool.cpp',
        'aapt/XMLNode.cpp',
        'aapt/ZipEntry.cpp',
        'aapt/ZipFile.cpp',
        'aapt/AaptAssets.h',
        'aapt/Bundle.h',
        'aapt/CacheUpdater.h',
        'aapt/CrunchCache.h',
        'aapt/DirectoryWalker.h',
        'aapt/FileFinder.h',
        'aapt/Images.h',
        'aapt/Main.h',
        'aapt/ResourceFilter.h',
        'aapt/ResourceTable.h',
        'aapt/SourcePos.h',
        'aapt/StringPool.h',
        'aapt/XMLNode.h',
        'aapt/ZipEntry.h',
        'aapt/ZipFile.h'
      ],
      'link_settings': {
        'libraries': [
          '-lpng'
        ],
      },
      'dependencies': [
        'android-libs.gyp:android_libs',
	'../expat/expat.gyp:expat',
        '../jpeg/libjpeg.gyp:android_libjpeg'
      ],
    }
  ]
}
