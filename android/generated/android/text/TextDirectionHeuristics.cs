using Sharpen;

namespace android.text
{
	/// <summary>Some objects that implement TextDirectionHeuristic.</summary>
	/// <remarks>Some objects that implement TextDirectionHeuristic.</remarks>
	/// <hide></hide>
	[Sharpen.Sharpened]
	public class TextDirectionHeuristics
	{
		/// <summary>Always decides that the direction is left to right.</summary>
		/// <remarks>Always decides that the direction is left to right.</remarks>
		public static readonly android.text.TextDirectionHeuristic LTR = new android.text.TextDirectionHeuristics
			.TextDirectionHeuristicInternal(null, false);

		/// <summary>Always decides that the direction is right to left.</summary>
		/// <remarks>Always decides that the direction is right to left.</remarks>
		public static readonly android.text.TextDirectionHeuristic RTL = new android.text.TextDirectionHeuristics
			.TextDirectionHeuristicInternal(null, true);

		/// <summary>
		/// Determines the direction based on the first strong directional character,
		/// including bidi format chars, falling back to left to right if it
		/// finds none.
		/// </summary>
		/// <remarks>
		/// Determines the direction based on the first strong directional character,
		/// including bidi format chars, falling back to left to right if it
		/// finds none.  This is the default behavior of the Unicode Bidirectional
		/// Algorithm.
		/// </remarks>
		public static readonly android.text.TextDirectionHeuristic FIRSTSTRONG_LTR = new 
			android.text.TextDirectionHeuristics.TextDirectionHeuristicInternal(android.text.TextDirectionHeuristics
			.FirstStrong.INSTANCE, false);

		/// <summary>
		/// Determines the direction based on the first strong directional character,
		/// including bidi format chars, falling back to right to left if it
		/// finds none.
		/// </summary>
		/// <remarks>
		/// Determines the direction based on the first strong directional character,
		/// including bidi format chars, falling back to right to left if it
		/// finds none.  This is similar to the default behavior of the Unicode
		/// Bidirectional Algorithm, just with different fallback behavior.
		/// </remarks>
		public static readonly android.text.TextDirectionHeuristic FIRSTSTRONG_RTL = new 
			android.text.TextDirectionHeuristics.TextDirectionHeuristicInternal(android.text.TextDirectionHeuristics
			.FirstStrong.INSTANCE, true);

		/// <summary>
		/// If the text contains any strong right to left non-format character, determines
		/// that the direction is right to left, falling back to left to right if it
		/// finds none.
		/// </summary>
		/// <remarks>
		/// If the text contains any strong right to left non-format character, determines
		/// that the direction is right to left, falling back to left to right if it
		/// finds none.
		/// </remarks>
		public static readonly android.text.TextDirectionHeuristic ANYRTL_LTR = new android.text.TextDirectionHeuristics
			.TextDirectionHeuristicInternal(android.text.TextDirectionHeuristics.AnyStrong.INSTANCE_RTL
			, false);

		/// <summary>Force the paragraph direction to the Locale direction.</summary>
		/// <remarks>Force the paragraph direction to the Locale direction. Falls back to left to right.
		/// 	</remarks>
		public static readonly android.text.TextDirectionHeuristic LOCALE = android.text.TextDirectionHeuristics
			.TextDirectionHeuristicLocale.INSTANCE;

		public enum TriState
		{
			TRUE,
			FALSE,
			UNKNOWN
		}

		/// <summary>Computes the text direction based on an algorithm.</summary>
		/// <remarks>
		/// Computes the text direction based on an algorithm.  Subclasses implement
		/// <see cref="defaultIsRtl()">defaultIsRtl()</see>
		/// to handle cases where the algorithm cannot determine the
		/// direction from the text alone.
		/// </remarks>
		/// <hide></hide>
		public abstract class TextDirectionHeuristicImpl : android.text.TextDirectionHeuristic
		{
			private readonly android.text.TextDirectionHeuristics.TextDirectionAlgorithm mAlgorithm;

			public TextDirectionHeuristicImpl(android.text.TextDirectionHeuristics.TextDirectionAlgorithm
				 algorithm)
			{
				mAlgorithm = algorithm;
			}

			/// <summary>Return true if the default text direction is rtl.</summary>
			/// <remarks>Return true if the default text direction is rtl.</remarks>
			protected internal abstract bool defaultIsRtl();

			[Sharpen.ImplementsInterface(@"android.text.TextDirectionHeuristic")]
			public virtual bool isRtl(char[] chars, int start, int count)
			{
				if (chars == null || start < 0 || count < 0 || chars.Length - count < start)
				{
					throw new System.ArgumentException();
				}
				if (mAlgorithm == null)
				{
					return defaultIsRtl();
				}
				return doCheck(chars, start, count);
			}

			private bool doCheck(char[] chars, int start, int count)
			{
				switch (mAlgorithm.checkRtl(chars, start, count))
				{
					case android.text.TextDirectionHeuristics.TriState.TRUE:
					{
						return true;
					}

					case android.text.TextDirectionHeuristics.TriState.FALSE:
					{
						return false;
					}

					default:
					{
						return defaultIsRtl();
					}
				}
			}
		}

		private class TextDirectionHeuristicInternal : android.text.TextDirectionHeuristics
			.TextDirectionHeuristicImpl
		{
			internal readonly bool mDefaultIsRtl;

			internal TextDirectionHeuristicInternal(android.text.TextDirectionHeuristics.TextDirectionAlgorithm
				 algorithm, bool defaultIsRtl_1) : base(algorithm)
			{
				mDefaultIsRtl = defaultIsRtl_1;
			}

			[Sharpen.OverridesMethod(@"android.text.TextDirectionHeuristics.TextDirectionHeuristicImpl"
				)]
			protected internal override bool defaultIsRtl()
			{
				return mDefaultIsRtl;
			}
		}

		private static android.text.TextDirectionHeuristics.TriState isRtlText(int directionality
			)
		{
			switch (directionality)
			{
				case Sharpen.CharHelper.DIRECTIONALITY_LEFT_TO_RIGHT:
				{
					return android.text.TextDirectionHeuristics.TriState.FALSE;
				}

				case Sharpen.CharHelper.DIRECTIONALITY_RIGHT_TO_LEFT:
				case Sharpen.CharHelper.DIRECTIONALITY_RIGHT_TO_LEFT_ARABIC:
				{
					return android.text.TextDirectionHeuristics.TriState.TRUE;
				}

				default:
				{
					return android.text.TextDirectionHeuristics.TriState.UNKNOWN;
				}
			}
		}

		private static android.text.TextDirectionHeuristics.TriState isRtlTextOrFormat(int
			 directionality)
		{
			switch (directionality)
			{
				case Sharpen.CharHelper.DIRECTIONALITY_LEFT_TO_RIGHT:
				case Sharpen.CharHelper.DIRECTIONALITY_LEFT_TO_RIGHT_EMBEDDING:
				case Sharpen.CharHelper.DIRECTIONALITY_LEFT_TO_RIGHT_OVERRIDE:
				{
					return android.text.TextDirectionHeuristics.TriState.FALSE;
				}

				case Sharpen.CharHelper.DIRECTIONALITY_RIGHT_TO_LEFT:
				case Sharpen.CharHelper.DIRECTIONALITY_RIGHT_TO_LEFT_ARABIC:
				case Sharpen.CharHelper.DIRECTIONALITY_RIGHT_TO_LEFT_EMBEDDING:
				case Sharpen.CharHelper.DIRECTIONALITY_RIGHT_TO_LEFT_OVERRIDE:
				{
					return android.text.TextDirectionHeuristics.TriState.TRUE;
				}

				default:
				{
					return android.text.TextDirectionHeuristics.TriState.UNKNOWN;
				}
			}
		}

		/// <summary>Interface for an algorithm to guess the direction of a paragraph of text.
		/// 	</summary>
		/// <remarks>Interface for an algorithm to guess the direction of a paragraph of text.
		/// 	</remarks>
		/// <hide></hide>
		public interface TextDirectionAlgorithm
		{
			/// <summary>Returns whether the range of text is RTL according to the algorithm.</summary>
			/// <remarks>Returns whether the range of text is RTL according to the algorithm.</remarks>
			/// <hide></hide>
			android.text.TextDirectionHeuristics.TriState checkRtl(char[] text, int start, int
				 count);
		}

		/// <summary>
		/// Algorithm that uses the first strong directional character to determine
		/// the paragraph direction.
		/// </summary>
		/// <remarks>
		/// Algorithm that uses the first strong directional character to determine
		/// the paragraph direction.  This is the standard Unicode Bidirectional
		/// algorithm.
		/// </remarks>
		/// <hide></hide>
		public class FirstStrong : android.text.TextDirectionHeuristics.TextDirectionAlgorithm
		{
			[Sharpen.ImplementsInterface(@"android.text.TextDirectionHeuristics.TextDirectionAlgorithm"
				)]
			public virtual android.text.TextDirectionHeuristics.TriState checkRtl(char[] text
				, int start, int count)
			{
				android.text.TextDirectionHeuristics.TriState result = android.text.TextDirectionHeuristics
					.TriState.UNKNOWN;
				{
					int i = start;
					int e = start + count;
					for (; i < e && result == android.text.TextDirectionHeuristics.TriState.UNKNOWN; 
						++i)
					{
						result = isRtlTextOrFormat(Sharpen.CharHelper.GetDirectionality(text[i]));
					}
				}
				return result;
			}

			private FirstStrong()
			{
			}

			public static readonly android.text.TextDirectionHeuristics.FirstStrong INSTANCE = 
				new android.text.TextDirectionHeuristics.FirstStrong();
		}

		/// <summary>
		/// Algorithm that uses the presence of any strong directional non-format
		/// character (e.g.
		/// </summary>
		/// <remarks>
		/// Algorithm that uses the presence of any strong directional non-format
		/// character (e.g. excludes LRE, LRO, RLE, RLO) to determine the
		/// direction of text.
		/// </remarks>
		/// <hide></hide>
		public class AnyStrong : android.text.TextDirectionHeuristics.TextDirectionAlgorithm
		{
			private readonly bool mLookForRtl;

			[Sharpen.ImplementsInterface(@"android.text.TextDirectionHeuristics.TextDirectionAlgorithm"
				)]
			public virtual android.text.TextDirectionHeuristics.TriState checkRtl(char[] text
				, int start, int count)
			{
				bool haveUnlookedFor = false;
				{
					int i = start;
					int e = start + count;
					for (; i < e; ++i)
					{
						switch (isRtlText(Sharpen.CharHelper.GetDirectionality(text[i])))
						{
							case android.text.TextDirectionHeuristics.TriState.TRUE:
							{
								if (mLookForRtl)
								{
									return android.text.TextDirectionHeuristics.TriState.TRUE;
								}
								haveUnlookedFor = true;
								break;
							}

							case android.text.TextDirectionHeuristics.TriState.FALSE:
							{
								if (!mLookForRtl)
								{
									return android.text.TextDirectionHeuristics.TriState.FALSE;
								}
								haveUnlookedFor = true;
								break;
							}

							default:
							{
								break;
							}
						}
					}
				}
				if (haveUnlookedFor)
				{
					return mLookForRtl ? android.text.TextDirectionHeuristics.TriState.FALSE : android.text.TextDirectionHeuristics
						.TriState.TRUE;
				}
				return android.text.TextDirectionHeuristics.TriState.UNKNOWN;
			}

			private AnyStrong(bool lookForRtl)
			{
				this.mLookForRtl = lookForRtl;
			}

			public static readonly android.text.TextDirectionHeuristics.AnyStrong INSTANCE_RTL
				 = new android.text.TextDirectionHeuristics.AnyStrong(true);

			public static readonly android.text.TextDirectionHeuristics.AnyStrong INSTANCE_LTR
				 = new android.text.TextDirectionHeuristics.AnyStrong(false);
		}

		/// <summary>Algorithm that uses the Locale direction to force the direction of a paragraph.
		/// 	</summary>
		/// <remarks>Algorithm that uses the Locale direction to force the direction of a paragraph.
		/// 	</remarks>
		public class TextDirectionHeuristicLocale : android.text.TextDirectionHeuristics.
			TextDirectionHeuristicImpl
		{
			public TextDirectionHeuristicLocale() : base(null)
			{
			}

			[Sharpen.OverridesMethod(@"android.text.TextDirectionHeuristics.TextDirectionHeuristicImpl"
				)]
			protected internal override bool defaultIsRtl()
			{
				int dir = android.util.LocaleUtil.getLayoutDirectionFromLocale(System.Globalization.CultureInfo.CurrentCulture
					);
				return (dir == android.util.LocaleUtil.TEXT_LAYOUT_DIRECTION_RTL_DO_NOT_USE);
			}

			public static readonly android.text.TextDirectionHeuristics.TextDirectionHeuristicLocale
				 INSTANCE = new android.text.TextDirectionHeuristics.TextDirectionHeuristicLocale
				();
		}
	}
}
