
{
  'includes': [
    '../skia/gyp/common.gypi',
  ],
  'targets': [
    {
      'target_name': 'android_ui',
      'type': 'static_library',
      'mac_bundle' : 1,
      'include_dirs' : [
        'include'
      ],
      'conditions': [
        [ 'skia_os == "linux"', {
          'cflags': [
            '-fPIC', '-Wall'
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
        'ui/Input.cpp',
	'ui/Keyboard.cpp',
	'ui/KeyLayoutMap.cpp',
	'ui/KeyCharacterMap.cpp',
	'ui/VirtualKeyMap.cpp'
      ],
      'dependencies': [
        'android-libs.gyp:android_libs'
      ],
      'link_settings': {
        'libraries': [
        ],
      },
      'direct_dependent_settings': {
        'include_dirs': [
        ],
        'cflags': [
        ],
      },
    }
  ]
}

