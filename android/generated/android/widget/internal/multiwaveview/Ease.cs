using Sharpen;

namespace android.widget.@internal.multiwaveview
{
	[Sharpen.Sharpened]
	internal class Ease
	{
		internal const float DOMAIN = 1.0f;

		internal const float DURATION = 1.0f;

		internal const float START = 0.0f;

		internal class Linear
		{
			private sealed class _TimeInterpolator_27 : android.animation.TimeInterpolator
			{
				public _TimeInterpolator_27()
				{
				}

				[Sharpen.ImplementsInterface(@"android.animation.TimeInterpolator")]
				public float getInterpolation(float input)
				{
					return input;
				}
			}

			public static readonly android.animation.TimeInterpolator easeNone = new _TimeInterpolator_27
				();
		}

		internal class Cubic
		{
			private sealed class _TimeInterpolator_35 : android.animation.TimeInterpolator
			{
				public _TimeInterpolator_35()
				{
				}

				[Sharpen.ImplementsInterface(@"android.animation.TimeInterpolator")]
				public float getInterpolation(float input)
				{
					return android.widget.@internal.multiwaveview.Ease.DOMAIN * (input /= android.widget.@internal.multiwaveview.Ease
						.DURATION) * input * input + android.widget.@internal.multiwaveview.Ease.START;
				}
			}

			public static readonly android.animation.TimeInterpolator easeIn = new _TimeInterpolator_35
				();

			private sealed class _TimeInterpolator_40 : android.animation.TimeInterpolator
			{
				public _TimeInterpolator_40()
				{
				}

				[Sharpen.ImplementsInterface(@"android.animation.TimeInterpolator")]
				public float getInterpolation(float input)
				{
					return android.widget.@internal.multiwaveview.Ease.DOMAIN * ((input = input / android.widget.@internal.multiwaveview.Ease
						.DURATION - 1) * input * input + 1) + android.widget.@internal.multiwaveview.Ease
						.START;
				}
			}

			public static readonly android.animation.TimeInterpolator easeOut = new _TimeInterpolator_40
				();

			private sealed class _TimeInterpolator_45 : android.animation.TimeInterpolator
			{
				public _TimeInterpolator_45()
				{
				}

				[Sharpen.ImplementsInterface(@"android.animation.TimeInterpolator")]
				public float getInterpolation(float input)
				{
					return ((input /= android.widget.@internal.multiwaveview.Ease.DURATION / 2) < 1.0f
						) ? (android.widget.@internal.multiwaveview.Ease.DOMAIN / 2 * input * input * input
						 + android.widget.@internal.multiwaveview.Ease.START) : (android.widget.@internal.multiwaveview.Ease
						.DOMAIN / 2 * ((input -= 2) * input * input + 2) + android.widget.@internal.multiwaveview.Ease
						.START);
				}
			}

			public static readonly android.animation.TimeInterpolator easeInOut = new _TimeInterpolator_45
				();
		}

		internal class Quad
		{
			private sealed class _TimeInterpolator_55 : android.animation.TimeInterpolator
			{
				public _TimeInterpolator_55()
				{
				}

				[Sharpen.ImplementsInterface(@"android.animation.TimeInterpolator")]
				public float getInterpolation(float input)
				{
					return android.widget.@internal.multiwaveview.Ease.DOMAIN * (input /= android.widget.@internal.multiwaveview.Ease
						.DURATION) * input + android.widget.@internal.multiwaveview.Ease.START;
				}
			}

			public static readonly android.animation.TimeInterpolator easeIn = new _TimeInterpolator_55
				();

			private sealed class _TimeInterpolator_60 : android.animation.TimeInterpolator
			{
				public _TimeInterpolator_60()
				{
				}

				[Sharpen.ImplementsInterface(@"android.animation.TimeInterpolator")]
				public float getInterpolation(float input)
				{
					return -android.widget.@internal.multiwaveview.Ease.DOMAIN * (input /= android.widget.@internal.multiwaveview.Ease
						.DURATION) * (input - 2) + android.widget.@internal.multiwaveview.Ease.START;
				}
			}

			public static readonly android.animation.TimeInterpolator easeOut = new _TimeInterpolator_60
				();

			private sealed class _TimeInterpolator_65 : android.animation.TimeInterpolator
			{
				public _TimeInterpolator_65()
				{
				}

				[Sharpen.ImplementsInterface(@"android.animation.TimeInterpolator")]
				public float getInterpolation(float input)
				{
					return ((input /= android.widget.@internal.multiwaveview.Ease.DURATION / 2) < 1) ? 
						(android.widget.@internal.multiwaveview.Ease.DOMAIN / 2 * input * input + android.widget.@internal.multiwaveview.Ease
						.START) : (-android.widget.@internal.multiwaveview.Ease.DOMAIN / 2 * ((--input) 
						* (input - 2) - 1) + android.widget.@internal.multiwaveview.Ease.START);
				}
			}

			public static readonly android.animation.TimeInterpolator easeInOut = new _TimeInterpolator_65
				();
		}

		internal class Quart
		{
			private sealed class _TimeInterpolator_75 : android.animation.TimeInterpolator
			{
				public _TimeInterpolator_75()
				{
				}

				[Sharpen.ImplementsInterface(@"android.animation.TimeInterpolator")]
				public float getInterpolation(float input)
				{
					return android.widget.@internal.multiwaveview.Ease.DOMAIN * (input /= android.widget.@internal.multiwaveview.Ease
						.DURATION) * input * input * input + android.widget.@internal.multiwaveview.Ease
						.START;
				}
			}

			public static readonly android.animation.TimeInterpolator easeIn = new _TimeInterpolator_75
				();

			private sealed class _TimeInterpolator_80 : android.animation.TimeInterpolator
			{
				public _TimeInterpolator_80()
				{
				}

				[Sharpen.ImplementsInterface(@"android.animation.TimeInterpolator")]
				public float getInterpolation(float input)
				{
					return -android.widget.@internal.multiwaveview.Ease.DOMAIN * ((input = input / android.widget.@internal.multiwaveview.Ease
						.DURATION - 1) * input * input * input - 1) + android.widget.@internal.multiwaveview.Ease
						.START;
				}
			}

			public static readonly android.animation.TimeInterpolator easeOut = new _TimeInterpolator_80
				();

			private sealed class _TimeInterpolator_85 : android.animation.TimeInterpolator
			{
				public _TimeInterpolator_85()
				{
				}

				[Sharpen.ImplementsInterface(@"android.animation.TimeInterpolator")]
				public float getInterpolation(float input)
				{
					return ((input /= android.widget.@internal.multiwaveview.Ease.DURATION / 2) < 1) ? 
						(android.widget.@internal.multiwaveview.Ease.DOMAIN / 2 * input * input * input 
						* input + android.widget.@internal.multiwaveview.Ease.START) : (-android.widget.@internal.multiwaveview.Ease
						.DOMAIN / 2 * ((input -= 2) * input * input * input - 2) + android.widget.@internal.multiwaveview.Ease
						.START);
				}
			}

			public static readonly android.animation.TimeInterpolator easeInOut = new _TimeInterpolator_85
				();
		}

		internal class Quint
		{
			private sealed class _TimeInterpolator_95 : android.animation.TimeInterpolator
			{
				public _TimeInterpolator_95()
				{
				}

				[Sharpen.ImplementsInterface(@"android.animation.TimeInterpolator")]
				public float getInterpolation(float input)
				{
					return android.widget.@internal.multiwaveview.Ease.DOMAIN * (input /= android.widget.@internal.multiwaveview.Ease
						.DURATION) * input * input * input * input + android.widget.@internal.multiwaveview.Ease
						.START;
				}
			}

			public static readonly android.animation.TimeInterpolator easeIn = new _TimeInterpolator_95
				();

			private sealed class _TimeInterpolator_100 : android.animation.TimeInterpolator
			{
				public _TimeInterpolator_100()
				{
				}

				[Sharpen.ImplementsInterface(@"android.animation.TimeInterpolator")]
				public float getInterpolation(float input)
				{
					return android.widget.@internal.multiwaveview.Ease.DOMAIN * ((input = input / android.widget.@internal.multiwaveview.Ease
						.DURATION - 1) * input * input * input * input + 1) + android.widget.@internal.multiwaveview.Ease
						.START;
				}
			}

			public static readonly android.animation.TimeInterpolator easeOut = new _TimeInterpolator_100
				();

			private sealed class _TimeInterpolator_105 : android.animation.TimeInterpolator
			{
				public _TimeInterpolator_105()
				{
				}

				[Sharpen.ImplementsInterface(@"android.animation.TimeInterpolator")]
				public float getInterpolation(float input)
				{
					return ((input /= android.widget.@internal.multiwaveview.Ease.DURATION / 2) < 1) ? 
						(android.widget.@internal.multiwaveview.Ease.DOMAIN / 2 * input * input * input 
						* input * input + android.widget.@internal.multiwaveview.Ease.START) : (android.widget.@internal.multiwaveview.Ease
						.DOMAIN / 2 * ((input -= 2) * input * input * input * input + 2) + android.widget.@internal.multiwaveview.Ease
						.START);
				}
			}

			public static readonly android.animation.TimeInterpolator easeInOut = new _TimeInterpolator_105
				();
		}

		internal class Sine
		{
			private sealed class _TimeInterpolator_115 : android.animation.TimeInterpolator
			{
				public _TimeInterpolator_115()
				{
				}

				[Sharpen.ImplementsInterface(@"android.animation.TimeInterpolator")]
				public float getInterpolation(float input)
				{
					return -android.widget.@internal.multiwaveview.Ease.DOMAIN * (float)System.Math.Cos
						(input / android.widget.@internal.multiwaveview.Ease.DURATION * (System.Math.PI 
						/ 2)) + android.widget.@internal.multiwaveview.Ease.DOMAIN + android.widget.@internal.multiwaveview.Ease
						.START;
				}
			}

			public static readonly android.animation.TimeInterpolator easeIn = new _TimeInterpolator_115
				();

			private sealed class _TimeInterpolator_120 : android.animation.TimeInterpolator
			{
				public _TimeInterpolator_120()
				{
				}

				[Sharpen.ImplementsInterface(@"android.animation.TimeInterpolator")]
				public float getInterpolation(float input)
				{
					return android.widget.@internal.multiwaveview.Ease.DOMAIN * (float)System.Math.Sin
						(input / android.widget.@internal.multiwaveview.Ease.DURATION * (System.Math.PI 
						/ 2)) + android.widget.@internal.multiwaveview.Ease.START;
				}
			}

			public static readonly android.animation.TimeInterpolator easeOut = new _TimeInterpolator_120
				();

			private sealed class _TimeInterpolator_125 : android.animation.TimeInterpolator
			{
				public _TimeInterpolator_125()
				{
				}

				[Sharpen.ImplementsInterface(@"android.animation.TimeInterpolator")]
				public float getInterpolation(float input)
				{
					return -android.widget.@internal.multiwaveview.Ease.DOMAIN / 2 * ((float)System.Math.Cos
						(System.Math.PI * input / android.widget.@internal.multiwaveview.Ease.DURATION) 
						- 1.0f) + android.widget.@internal.multiwaveview.Ease.START;
				}
			}

			public static readonly android.animation.TimeInterpolator easeInOut = new _TimeInterpolator_125
				();
		}
	}
}
