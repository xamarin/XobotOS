
{
  'includes': [
    '../external/skia/gyp/common.gypi',
  ],
  'variables': {
    'glue_dir' : 'output'
  },
  'targets': [
    {
      'target_name': 'libxobotos',
      'type': 'shared_library',
      'mac_bundle' : 1,
      'include_dirs' : [
        '../external/skia/src/core', # needed to get SkConcaveToTriangle, maybe this should be moved to include dir?
        '../external/skia/gm',       # needed to pull gm.h
        '../external/skia/include/pipe', # To pull in SkGPipe.h for pipe reader/writer
        'include',
        '/usr/include/mono-2.0'
      ],
      'cflags': [
        '-fPIC', '-Wall'
      ],
      'link_settings': {
        'libraries': [
          '-lmono-2.0',
        ],
      },
      'sources': [
        'linux/XobotWindow.h',
        'linux/XobotWindow.cpp',
        'glue/MarshalHelper.cpp',
        'glue/MartinTest.cpp',
        'glue/BitmapGlue.cpp',
        'glue/CanvasGlue.cpp',
        'glue/PathGlue.cpp',
        'glue/PaintGlue.cpp',
        'glue/RegionGlue.cpp',
        'glue/MatrixGlue.cpp',
        'glue/ShaderGlue.cpp',
        'glue/PathEffectGlue.cpp',
        'glue/ColorFilterGlue.cpp',
        'glue/DrawFilterGlue.cpp',
        'glue/XfermodeGlue.cpp',
        'glue/PathMeasureGlue.cpp',
        'glue/InterpolatorGlue.cpp',
        'glue/NinePatchGlue.cpp',
        'glue/PictureGlue.cpp',
        'glue/RasterizerGlue.cpp',
        'glue/MaskFilterGlue.cpp',
        'glue/BitmapFactoryGlue.cpp',
        'glue/TypefaceGlue.cpp',
        'glue/AssetManagerGlue.cpp',
        'glue/RegexPatternGlue.cpp',
        'glue/RegexMatcherGlue.cpp',
        'glue/MotionEventGlue.cpp',
        'glue/VelocityTrackerGlue.cpp',
        'include/libxobotos.h',
        'include/CanvasGlue.h',
        'include/RegionGlue.h',
        'include/PaintGlue.h',
        'include/PathGlue.h',
        'include/MatrixGlue.h',
        'include/ShaderGlue.h',
        'include/PathEffectGlue.h',
        'include/ColorFilterGlue.h',
        'include/DrawFilterGlue.h',
        'include/XfermodeGlue.h',
        'include/PathMeasureGlue.h',
        'include/InterpolatorGlue.h',
        'include/NinePatchGlue.h',
        'include/PictureGlue.h',
        'include/RasterizerGlue.h',
        'include/BitmapFactoryGlue.h',
        'include/TypefaceGlue.h',
        'include/AssetManagerGlue.h',
        'include/RegexPatternGlue.h',
        'include/RegexMatcherGlue.h',
        'include/MotionEventGlue.h',
        'include/VelocityTrackerGlue.h',
        '../android/<(glue_dir)/glue/XobotOS.MarshalGlue.cpp',
        '../android/<(glue_dir)/glue/martin.Test.cpp',
        '../android/<(glue_dir)/glue/android.graphics.Rect.cpp',
        '../android/<(glue_dir)/glue/android.graphics.RectF.cpp',
        '../android/<(glue_dir)/glue/android.graphics.Bitmap.cpp',
        '../android/<(glue_dir)/glue/android.graphics.Canvas.cpp',
        '../android/<(glue_dir)/glue/android.graphics.Path.cpp',
        '../android/<(glue_dir)/glue/android.graphics.Paint.cpp',
        '../android/<(glue_dir)/glue/android.graphics.Region.cpp',
        '../android/<(glue_dir)/glue/android.graphics.RegionIterator.cpp',
        '../android/<(glue_dir)/glue/android.graphics.ComposePathEffect.cpp',
        '../android/<(glue_dir)/glue/android.graphics.CornerPathEffect.cpp',
        '../android/<(glue_dir)/glue/android.graphics.DashPathEffect.cpp',
        '../android/<(glue_dir)/glue/android.graphics.DiscretePathEffect.cpp',
        '../android/<(glue_dir)/glue/android.graphics.PathDashPathEffect.cpp',
        '../android/<(glue_dir)/glue/android.graphics.PathEffect.cpp',
        '../android/<(glue_dir)/glue/android.graphics.SumPathEffect.cpp',
        '../android/<(glue_dir)/glue/android.graphics.DrawFilter.cpp',
        '../android/<(glue_dir)/glue/android.graphics.PaintFlagsDrawFilter.cpp',
        '../android/<(glue_dir)/glue/android.graphics.Typeface.cpp',
        '../android/<(glue_dir)/glue/android.graphics.MaskFilter.cpp',
        '../android/<(glue_dir)/glue/android.graphics.BlurMaskFilter.cpp',
        '../android/<(glue_dir)/glue/android.graphics.EmbossMaskFilter.cpp',
        '../android/<(glue_dir)/glue/android.graphics.TableMaskFilter.cpp',
        '../android/<(glue_dir)/glue/android.graphics.Matrix.cpp',
        '../android/<(glue_dir)/glue/android.graphics.Shader.cpp',
        '../android/<(glue_dir)/glue/android.graphics.BitmapShader.cpp',
        '../android/<(glue_dir)/glue/android.graphics.ComposeShader.cpp',
        '../android/<(glue_dir)/glue/android.graphics.LinearGradient.cpp',
        '../android/<(glue_dir)/glue/android.graphics.RadialGradient.cpp',
        '../android/<(glue_dir)/glue/android.graphics.SweepGradient.cpp',
        '../android/<(glue_dir)/glue/android.graphics.PathEffect.cpp',
        '../android/<(glue_dir)/glue/android.graphics.ComposePathEffect.cpp',
        '../android/<(glue_dir)/glue/android.graphics.CornerPathEffect.cpp',
        '../android/<(glue_dir)/glue/android.graphics.DashPathEffect.cpp',
        '../android/<(glue_dir)/glue/android.graphics.DiscretePathEffect.cpp',
        '../android/<(glue_dir)/glue/android.graphics.PathDashPathEffect.cpp',
        '../android/<(glue_dir)/glue/android.graphics.SumPathEffect.cpp',
        '../android/<(glue_dir)/glue/android.graphics.ColorFilter.cpp',
        '../android/<(glue_dir)/glue/android.graphics.ColorMatrixColorFilter.cpp',
        '../android/<(glue_dir)/glue/android.graphics.LightingColorFilter.cpp',
        '../android/<(glue_dir)/glue/android.graphics.PorterDuffColorFilter.cpp',
        '../android/<(glue_dir)/glue/android.graphics.DrawFilter.cpp',
        '../android/<(glue_dir)/glue/android.graphics.PaintFlagsDrawFilter.cpp',
        '../android/<(glue_dir)/glue/android.graphics.Rasterizer.cpp',
        '../android/<(glue_dir)/glue/android.graphics.LayerRasterizer.cpp',
        '../android/<(glue_dir)/glue/android.graphics.Xfermode.cpp',
        '../android/<(glue_dir)/glue/android.graphics.AvoidXfermode.cpp',
        '../android/<(glue_dir)/glue/android.graphics.PixelXorXfermode.cpp',
        '../android/<(glue_dir)/glue/android.graphics.PorterDuffXfermode.cpp',
        '../android/<(glue_dir)/glue/android.graphics.PathMeasure.cpp',
        '../android/<(glue_dir)/glue/android.graphics.Color.cpp',
        '../android/<(glue_dir)/glue/android.graphics.Interpolator.cpp',
        '../android/<(glue_dir)/glue/android.graphics.NinePatch.cpp',
        '../android/<(glue_dir)/glue/android.graphics.Picture.cpp',
        '../android/<(glue_dir)/glue/android.graphics.BitmapFactory.cpp',
        '../android/<(glue_dir)/glue/android.util.TypedValue.cpp',
        '../android/<(glue_dir)/glue/android.content.res.AssetManager.cpp',
        '../android/<(glue_dir)/glue/android.content.res.StringBlock.cpp',
        '../android/<(glue_dir)/glue/android.content.res.XmlBlock.cpp',
        '../android/<(glue_dir)/glue/android.view.MotionEvent.cpp',
        '../android/<(glue_dir)/glue/android.view.MotionEvent.h',
        '../android/<(glue_dir)/glue/android.view.VelocityTracker.cpp',
        '../android/<(glue_dir)/glue/java.util.regex.Pattern.cpp',
        '../android/<(glue_dir)/glue/java.util.regex.Matcher.cpp'
      ],
      'dependencies': [
        '../external/skia/gyp/core.gyp:core',
        '../external/skia/gyp/effects.gyp:effects',
        '../external/skia/gyp/images.gyp:images',
        '../external/skia/gyp/views.gyp:views',
        '../external/skia/gyp/utils.gyp:utils',
        '../external/skia/gyp/animator.gyp:animator',
        '../external/skia/gyp/xml.gyp:xml',
        '../external/skia/gyp/svg.gyp:svg',
        '../external/skia/gyp/gpu.gyp:gr',
        '../external/skia/gyp/gpu.gyp:skgr',
        '../external/skia/gyp/pdf.gyp:pdf',
        '../external/icu4c/icu4c.gyp:icu4c',
        '../external/android/android-libs.gyp:android_libs',
        '../external/android/android-ui.gyp:android_ui',
        '../external/android/xorpt.gyp:xorpt'
      ],
      'msvs_settings': {
        'VCLinkerTool': {
          'SubSystem': '2',
          'AdditionalDependencies': [
            'd3d9.lib',
          ],
        },
      },
    },
    {
      'target_name': 'test_libxobotos',
      'type': 'executable',
      'sources': [
        'test-main.cpp'
      ],
      'include_dirs' : [
        'include'
      ],
      'dependencies': [
        'libxobotos',
        '../external/skia/gyp/core.gyp:core',
        '../external/skia/gyp/effects.gyp:effects',
        '../external/skia/gyp/images.gyp:images',
        '../external/skia/gyp/views.gyp:views',
        '../external/skia/gyp/utils.gyp:utils',
        '../external/skia/gyp/animator.gyp:animator',
        '../external/skia/gyp/xml.gyp:xml',
        '../external/skia/gyp/svg.gyp:svg',
        '../external/skia/gyp/gpu.gyp:gr',
        '../external/skia/gyp/gpu.gyp:skgr',
        '../external/skia/gyp/pdf.gyp:pdf',
        '../external/icu4c/icu4c.gyp:icu4c',
        '../external/android/android-libs.gyp:android_libs',
        '../external/android/android-ui.gyp:android_ui'
      ],
    },
    {
      'target_name': 'output',
      'type': 'none',
      'dependencies': [
        'libxobotos',
      ],
      'actions': [
        {
          'variables' : {
            'input' : '<(PRODUCT_DIR)/lib.target/libxobotos.so',
            'output' : '<(PRODUCT_DIR)/libxobotos.so'
          },
          'action_name' : 'copy_output',
          'inputs' : [ '<(input)' ],
          'outputs' : [ '<(output)' ],
          'action' : [ 'cp', '<(input)', '<(output)' ]
        }
      ],
    }
  ],
}

# Local Variables:
# tab-width:2
# indent-tabs-mode:nil
# End:
# vim: set expandtab tabstop=2 shiftwidth=2:
