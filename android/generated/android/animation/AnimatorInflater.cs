using Sharpen;

namespace android.animation
{
	/// <summary>This class is used to instantiate animator XML files into Animator objects.
	/// 	</summary>
	/// <remarks>
	/// This class is used to instantiate animator XML files into Animator objects.
	/// <p>
	/// For performance reasons, inflation relies heavily on pre-processing of
	/// XML files that is done at build time. Therefore, it is not currently possible
	/// to use this inflater with an XmlPullParser over a plain XML file at runtime;
	/// it only works with an XmlPullParser returned from a compiled resource (R.
	/// <em>something</em> file.)
	/// </remarks>
	[Sharpen.Sharpened]
	public class AnimatorInflater
	{
		/// <summary>These flags are used when parsing AnimatorSet objects</summary>
		internal const int TOGETHER = 0;

		internal const int SEQUENTIALLY = 1;

		/// <summary>Enum values used in XML attributes to indicate the value for mValueType</summary>
		internal const int VALUE_TYPE_FLOAT = 0;

		internal const int VALUE_TYPE_INT = 1;

		internal const int VALUE_TYPE_COLOR = 4;

		internal const int VALUE_TYPE_CUSTOM = 5;

		/// <summary>
		/// Loads an
		/// <see cref="Animator">Animator</see>
		/// object from a resource
		/// </summary>
		/// <param name="context">Application context used to access resources</param>
		/// <param name="id">The resource id of the animation to load</param>
		/// <returns>The animator object reference by the specified id</returns>
		/// <exception cref="android.content.res.Resources.NotFoundException">when the animation cannot be loaded
		/// 	</exception>
		public static android.animation.Animator loadAnimator(android.content.Context context
			, int id)
		{
			android.content.res.XmlResourceParser parser = null;
			try
			{
				parser = context.getResources().getAnimation(id);
				return createAnimatorFromXml(context, parser);
			}
			catch (org.xmlpull.v1.XmlPullParserException ex)
			{
				android.content.res.Resources.NotFoundException rnf = new android.content.res.Resources
					.NotFoundException("Can't load animation resource ID #0x" + Sharpen.Util.IntToHexString
					(id));
				rnf.InnerException = ex;
				throw rnf;
			}
			catch (System.IO.IOException ex)
			{
				android.content.res.Resources.NotFoundException rnf = new android.content.res.Resources
					.NotFoundException("Can't load animation resource ID #0x" + Sharpen.Util.IntToHexString
					(id));
				rnf.InnerException = ex;
				throw rnf;
			}
			finally
			{
				if (parser != null)
				{
					parser.close();
				}
			}
		}

		/// <exception cref="org.xmlpull.v1.XmlPullParserException"></exception>
		/// <exception cref="System.IO.IOException"></exception>
		private static android.animation.Animator createAnimatorFromXml(android.content.Context
			 c, org.xmlpull.v1.XmlPullParser parser)
		{
			return createAnimatorFromXml(c, parser, android.util.Xml.asAttributeSet(parser), 
				null, 0);
		}

		/// <exception cref="org.xmlpull.v1.XmlPullParserException"></exception>
		/// <exception cref="System.IO.IOException"></exception>
		private static android.animation.Animator createAnimatorFromXml(android.content.Context
			 c, org.xmlpull.v1.XmlPullParser parser, android.util.AttributeSet attrs, android.animation.AnimatorSet
			 parent, int sequenceOrdering)
		{
			android.animation.Animator anim = null;
			java.util.ArrayList<android.animation.Animator> childAnims = null;
			// Make sure we are on a start tag.
			int type;
			int depth = parser.getDepth();
			while (((type = parser.next()) != org.xmlpull.v1.XmlPullParserClass.END_TAG || parser
				.getDepth() > depth) && type != org.xmlpull.v1.XmlPullParserClass.END_DOCUMENT)
			{
				if (type != org.xmlpull.v1.XmlPullParserClass.START_TAG)
				{
					continue;
				}
				string name = parser.getName();
				if (name.Equals("objectAnimator"))
				{
					anim = loadObjectAnimator(c, attrs);
				}
				else
				{
					if (name.Equals("animator"))
					{
						anim = loadAnimator(c, attrs, null);
					}
					else
					{
						if (name.Equals("set"))
						{
							anim = new android.animation.AnimatorSet();
							android.content.res.TypedArray a = c.obtainStyledAttributes(attrs, android.@internal.R
								.styleable.AnimatorSet);
							int ordering = a.getInt(android.@internal.R.styleable.AnimatorSet_ordering, TOGETHER
								);
							createAnimatorFromXml(c, parser, attrs, (android.animation.AnimatorSet)anim, ordering
								);
							a.recycle();
						}
						else
						{
							throw new java.lang.RuntimeException("Unknown animator name: " + parser.getName()
								);
						}
					}
				}
				if (parent != null)
				{
					if (childAnims == null)
					{
						childAnims = new java.util.ArrayList<android.animation.Animator>();
					}
					childAnims.add(anim);
				}
			}
			if (parent != null && childAnims != null)
			{
				android.animation.Animator[] animsArray = new android.animation.Animator[childAnims
					.size()];
				int index = 0;
				foreach (android.animation.Animator a in Sharpen.IterableProxy.Create(childAnims))
				{
					animsArray[index++] = a;
				}
				if (sequenceOrdering == TOGETHER)
				{
					parent.playTogether(animsArray);
				}
				else
				{
					parent.playSequentially(animsArray);
				}
			}
			return anim;
		}

		/// <exception cref="android.content.res.Resources.NotFoundException"></exception>
		private static android.animation.ObjectAnimator loadObjectAnimator(android.content.Context
			 context, android.util.AttributeSet attrs)
		{
			android.animation.ObjectAnimator anim = new android.animation.ObjectAnimator();
			loadAnimator(context, attrs, anim);
			android.content.res.TypedArray a = context.obtainStyledAttributes(attrs, android.@internal.R
				.styleable.PropertyAnimator);
			string propertyName = a.getString(android.@internal.R.styleable.PropertyAnimator_propertyName
				);
			anim.setPropertyName(propertyName);
			a.recycle();
			return anim;
		}

		/// <summary>
		/// Creates a new animation whose parameters come from the specified context and
		/// attributes set.
		/// </summary>
		/// <remarks>
		/// Creates a new animation whose parameters come from the specified context and
		/// attributes set.
		/// </remarks>
		/// <param name="context">the application environment</param>
		/// <param name="attrs">the set of attributes holding the animation parameters</param>
		/// <exception cref="android.content.res.Resources.NotFoundException"></exception>
		private static android.animation.ValueAnimator loadAnimator(android.content.Context
			 context, android.util.AttributeSet attrs, android.animation.ValueAnimator anim)
		{
			android.content.res.TypedArray a = context.obtainStyledAttributes(attrs, android.@internal.R
				.styleable.Animator);
			long duration = a.getInt(android.@internal.R.styleable.Animator_duration, 0);
			long startDelay = a.getInt(android.@internal.R.styleable.Animator_startOffset, 0);
			int valueType = a.getInt(android.@internal.R.styleable.Animator_valueType, VALUE_TYPE_FLOAT
				);
			if (anim == null)
			{
				anim = new android.animation.ValueAnimator();
			}
			android.animation.TypeEvaluator<object> evaluator = null;
			int valueFromIndex = android.@internal.R.styleable.Animator_valueFrom;
			int valueToIndex = android.@internal.R.styleable.Animator_valueTo;
			bool getFloats = (valueType == VALUE_TYPE_FLOAT);
			android.util.TypedValue tvFrom = a.peekValue(valueFromIndex);
			bool hasFrom = (tvFrom != null);
			int fromType = hasFrom ? tvFrom.type : 0;
			android.util.TypedValue tvTo = a.peekValue(valueToIndex);
			bool hasTo = (tvTo != null);
			int toType = hasTo ? tvTo.type : 0;
			if ((hasFrom && (fromType >= android.util.TypedValue.TYPE_FIRST_COLOR_INT) && (fromType
				 <= android.util.TypedValue.TYPE_LAST_COLOR_INT)) || (hasTo && (toType >= android.util.TypedValue
				.TYPE_FIRST_COLOR_INT) && (toType <= android.util.TypedValue.TYPE_LAST_COLOR_INT
				)))
			{
				// special case for colors: ignore valueType and get ints
				getFloats = false;
				anim.setEvaluator(new android.animation.ArgbEvaluator());
			}
			if (getFloats)
			{
				float valueFrom;
				float valueTo;
				if (hasFrom)
				{
					if (fromType == android.util.TypedValue.TYPE_DIMENSION)
					{
						valueFrom = a.getDimension(valueFromIndex, 0f);
					}
					else
					{
						valueFrom = a.getFloat(valueFromIndex, 0f);
					}
					if (hasTo)
					{
						if (toType == android.util.TypedValue.TYPE_DIMENSION)
						{
							valueTo = a.getDimension(valueToIndex, 0f);
						}
						else
						{
							valueTo = a.getFloat(valueToIndex, 0f);
						}
						anim.setFloatValues(valueFrom, valueTo);
					}
					else
					{
						anim.setFloatValues(valueFrom);
					}
				}
				else
				{
					if (toType == android.util.TypedValue.TYPE_DIMENSION)
					{
						valueTo = a.getDimension(valueToIndex, 0f);
					}
					else
					{
						valueTo = a.getFloat(valueToIndex, 0f);
					}
					anim.setFloatValues(valueTo);
				}
			}
			else
			{
				int valueFrom;
				int valueTo;
				if (hasFrom)
				{
					if (fromType == android.util.TypedValue.TYPE_DIMENSION)
					{
						valueFrom = (int)a.getDimension(valueFromIndex, 0f);
					}
					else
					{
						if ((fromType >= android.util.TypedValue.TYPE_FIRST_COLOR_INT) && (fromType <= android.util.TypedValue
							.TYPE_LAST_COLOR_INT))
						{
							valueFrom = a.getColor(valueFromIndex, 0);
						}
						else
						{
							valueFrom = a.getInt(valueFromIndex, 0);
						}
					}
					if (hasTo)
					{
						if (toType == android.util.TypedValue.TYPE_DIMENSION)
						{
							valueTo = (int)a.getDimension(valueToIndex, 0f);
						}
						else
						{
							if ((toType >= android.util.TypedValue.TYPE_FIRST_COLOR_INT) && (toType <= android.util.TypedValue
								.TYPE_LAST_COLOR_INT))
							{
								valueTo = a.getColor(valueToIndex, 0);
							}
							else
							{
								valueTo = a.getInt(valueToIndex, 0);
							}
						}
						anim.setIntValues(valueFrom, valueTo);
					}
					else
					{
						anim.setIntValues(valueFrom);
					}
				}
				else
				{
					if (hasTo)
					{
						if (toType == android.util.TypedValue.TYPE_DIMENSION)
						{
							valueTo = (int)a.getDimension(valueToIndex, 0f);
						}
						else
						{
							if ((toType >= android.util.TypedValue.TYPE_FIRST_COLOR_INT) && (toType <= android.util.TypedValue
								.TYPE_LAST_COLOR_INT))
							{
								valueTo = a.getColor(valueToIndex, 0);
							}
							else
							{
								valueTo = a.getInt(valueToIndex, 0);
							}
						}
						anim.setIntValues(valueTo);
					}
				}
			}
			anim.setDuration(duration);
			anim.setStartDelay(startDelay);
			if (a.hasValue(android.@internal.R.styleable.Animator_repeatCount))
			{
				anim.setRepeatCount(a.getInt(android.@internal.R.styleable.Animator_repeatCount, 
					0));
			}
			if (a.hasValue(android.@internal.R.styleable.Animator_repeatMode))
			{
				anim.setRepeatMode(a.getInt(android.@internal.R.styleable.Animator_repeatMode, android.animation.ValueAnimator
					.RESTART));
			}
			if (evaluator != null)
			{
				anim.setEvaluator(evaluator);
			}
			int resID = a.getResourceId(android.@internal.R.styleable.Animator_interpolator, 
				0);
			if (resID > 0)
			{
				anim.setInterpolator(android.view.animation.AnimationUtils.loadInterpolator(context
					, resID));
			}
			a.recycle();
			return anim;
		}
	}
}
