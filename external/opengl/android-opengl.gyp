
{
  'includes': [
    '../skia/gyp/common.gypi',
  ],
  'targets': [
    {
      'target_name': 'android_opengl',
      'type': 'static_library',
      'mac_bundle' : 1,
      'include_dirs' : [
        'include',
	'libs'
      ],
      'defines': [
        'GL_GLEXT_PROTOTYPES',
        'EGL_EGLEXT_PROTOTYPES',
	'ANDROID'
      ],
      'conditions': [
        [ 'skia_os == "linux"', {
          'cflags': [
            '-fPIC', '-Wall'
          ],
        }],
      ],
      'sources' : [
        'libs/EGL/egl_tls.cpp',
	'libs/EGL/egl_display.cpp',
	'libs/EGL/egl_object.cpp',
	'libs/EGL/egl.cpp',
	'libs/EGL/eglApi.cpp',
	'libs/EGL/trace.cpp',
	'libs/EGL/getProcAddress.cpp.arm',
	'libs/EGL/Loader.cpp'
      ],
      'dependencies': [
        '../android/android-libs.gyp:android_libs'
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
