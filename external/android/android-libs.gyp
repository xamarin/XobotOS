
{
  'includes': [
    '../skia/gyp/common.gypi',
  ],
  'targets': [
    {
      'target_name': 'android_libs',
      'type': 'static_library',
      'mac_bundle' : 1,
      'include_dirs' : [
        'xobotos/include',
        'include'
      ],
      'conditions': [
        [ 'skia_os == "linux"', {
          'cflags': [
            '-fPIC', '-Wall',
            '-include', '$(srcdir)/AndroidConfig.h',
	    '-I/usr/include/mono-2.0'
          ],
          'defines': [
	    'ANDROID_SMP=1',
	    'FAKE_LOG_DEVICE'
          ],
          'sources': [
          ],
        }],
      ],
      'sources' : [
        'xobotos/Buffer.cpp',
        'xobotos/FileBuffer.cpp',
        'xobotos/FileMapBuffer.cpp',
        'xobotos/MemoryBuffer.cpp',
        'xobotos/ZipFileRO.cpp',
        'xobotos/ZipFileBuffer.cpp',
	'xobotos/MonoImageResource.cpp',
        'utils/Asset.cpp',
        'utils/AssetDir.cpp',
        'utils/AssetManager.cpp',
        'utils/BufferedTextOutput.cpp',
        'utils/Debug.cpp',
        'utils/FileMap.cpp',
        'utils/Flattenable.cpp',
        'utils/LinearTransform.cpp',
        'utils/ObbFile.cpp',
        'utils/PropertyMap.cpp',
        'utils/RefBase.cpp',
        'utils/ResourceTypes.cpp',
        'utils/SharedBuffer.cpp',
        'utils/Static.cpp',
        'utils/StreamingZipInflater.cpp',
        'utils/String8.cpp',
        'utils/String16.cpp',
        'utils/StringArray.cpp',
        'utils/TextOutput.cpp',
	'utils/Timers.cpp',
        'utils/Tokenizer.cpp',
        'utils/Unicode.cpp',
        'utils/VectorImpl.cpp',
        'utils/ZipUtils.cpp',
        'utils/misc.cpp',
	'libcutils/atomic.c',
	'libcutils/threads.c',
	'libcutils/properties.c',
	'libcutils/memory.c',
	'liblog/logd_write.c',
	'liblog/logprint.c',
	'liblog/event_tag_map.c',
	'liblog/fake_log_device.c',
	'libhardware/hardware.c'
      ],
      'dependencies': [
        '../icu4c/icu4c.gyp:icu4c',
      ],
      'link_settings': {
        'libraries': [
          '-lpthread', '-lrt', '-lmono-2.0'
        ],
      },
      'direct_dependent_settings': {
        'include_dirs': [
          '../android/include'
        ],
        'cflags': [
          '-include', '$(srcdir)/AndroidConfig.h'
        ],
      },
    }
  ]
}

