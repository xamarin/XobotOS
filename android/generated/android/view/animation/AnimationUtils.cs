using Sharpen;

namespace android.view.animation
{
	/// <summary>Defines common utilities for working with animations.</summary>
	/// <remarks>Defines common utilities for working with animations.</remarks>
	[Sharpen.Sharpened]
	public class AnimationUtils
	{
		/// <summary>These flags are used when parsing AnimatorSet objects</summary>
		internal const int TOGETHER = 0;

		internal const int SEQUENTIALLY = 1;

		/// <summary>Returns the current animation time in milliseconds.</summary>
		/// <remarks>
		/// Returns the current animation time in milliseconds. This time should be used when invoking
		/// <see cref="Animation.setStartTime(long)">Animation.setStartTime(long)</see>
		/// . Refer to
		/// <see cref="android.os.SystemClock">android.os.SystemClock</see>
		/// for more
		/// information about the different available clocks. The clock used by this method is
		/// <em>not</em> the "wall" clock (it is not
		/// <see cref="Sharpen.Util.CurrentTimeMillis()">Sharpen.Util.CurrentTimeMillis()</see>
		/// ).
		/// </remarks>
		/// <returns>the current animation time in milliseconds</returns>
		/// <seealso cref="android.os.SystemClock">android.os.SystemClock</seealso>
		public static long currentAnimationTimeMillis()
		{
			return android.os.SystemClock.uptimeMillis();
		}

		/// <summary>
		/// Loads an
		/// <see cref="Animation">Animation</see>
		/// object from a resource
		/// </summary>
		/// <param name="context">Application context used to access resources</param>
		/// <param name="id">The resource id of the animation to load</param>
		/// <returns>The animation object reference by the specified id</returns>
		/// <exception cref="android.content.res.Resources.NotFoundException">when the animation cannot be loaded
		/// 	</exception>
		public static android.view.animation.Animation loadAnimation(android.content.Context
			 context, int id)
		{
			android.content.res.XmlResourceParser parser = null;
			try
			{
				parser = context.getResources().getAnimation(id);
				return createAnimationFromXml(context, parser);
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
		private static android.view.animation.Animation createAnimationFromXml(android.content.Context
			 c, org.xmlpull.v1.XmlPullParser parser)
		{
			return createAnimationFromXml(c, parser, null, android.util.Xml.asAttributeSet(parser
				));
		}

		/// <exception cref="org.xmlpull.v1.XmlPullParserException"></exception>
		/// <exception cref="System.IO.IOException"></exception>
		private static android.view.animation.Animation createAnimationFromXml(android.content.Context
			 c, org.xmlpull.v1.XmlPullParser parser, android.view.animation.AnimationSet parent
			, android.util.AttributeSet attrs)
		{
			android.view.animation.Animation anim = null;
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
				if (name.Equals("set"))
				{
					anim = new android.view.animation.AnimationSet(c, attrs);
					createAnimationFromXml(c, parser, (android.view.animation.AnimationSet)anim, attrs
						);
				}
				else
				{
					if (name.Equals("alpha"))
					{
						anim = new android.view.animation.AlphaAnimation(c, attrs);
					}
					else
					{
						if (name.Equals("scale"))
						{
							anim = new android.view.animation.ScaleAnimation(c, attrs);
						}
						else
						{
							if (name.Equals("rotate"))
							{
								anim = new android.view.animation.RotateAnimation(c, attrs);
							}
							else
							{
								if (name.Equals("translate"))
								{
									anim = new android.view.animation.TranslateAnimation(c, attrs);
								}
								else
								{
									throw new java.lang.RuntimeException("Unknown animation name: " + parser.getName(
										));
								}
							}
						}
					}
				}
				if (parent != null)
				{
					parent.addAnimation(anim);
				}
			}
			return anim;
		}

		/// <exception cref="android.content.res.Resources.NotFoundException"></exception>
		public static android.view.animation.LayoutAnimationController loadLayoutAnimation
			(android.content.Context context, int id)
		{
			android.content.res.XmlResourceParser parser = null;
			try
			{
				parser = context.getResources().getAnimation(id);
				return createLayoutAnimationFromXml(context, parser);
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
		private static android.view.animation.LayoutAnimationController createLayoutAnimationFromXml
			(android.content.Context c, org.xmlpull.v1.XmlPullParser parser)
		{
			return createLayoutAnimationFromXml(c, parser, android.util.Xml.asAttributeSet(parser
				));
		}

		/// <exception cref="org.xmlpull.v1.XmlPullParserException"></exception>
		/// <exception cref="System.IO.IOException"></exception>
		private static android.view.animation.LayoutAnimationController createLayoutAnimationFromXml
			(android.content.Context c, org.xmlpull.v1.XmlPullParser parser, android.util.AttributeSet
			 attrs)
		{
			android.view.animation.LayoutAnimationController controller = null;
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
				if ("layoutAnimation".Equals(name))
				{
					controller = new android.view.animation.LayoutAnimationController(c, attrs);
				}
				else
				{
					if ("gridLayoutAnimation".Equals(name))
					{
						controller = new android.view.animation.GridLayoutAnimationController(c, attrs);
					}
					else
					{
						throw new java.lang.RuntimeException("Unknown layout animation name: " + name);
					}
				}
			}
			return controller;
		}

		/// <summary>Make an animation for objects becoming visible.</summary>
		/// <remarks>
		/// Make an animation for objects becoming visible. Uses a slide and fade
		/// effect.
		/// </remarks>
		/// <param name="c">Context for loading resources</param>
		/// <param name="fromLeft">is the object to be animated coming from the left</param>
		/// <returns>The new animation</returns>
		public static android.view.animation.Animation makeInAnimation(android.content.Context
			 c, bool fromLeft)
		{
			android.view.animation.Animation a;
			if (fromLeft)
			{
				a = android.view.animation.AnimationUtils.loadAnimation(c, android.@internal.R.anim
					.slide_in_left);
			}
			else
			{
				a = android.view.animation.AnimationUtils.loadAnimation(c, android.@internal.R.anim
					.slide_in_right);
			}
			a.setInterpolator(new android.view.animation.DecelerateInterpolator());
			a.setStartTime(currentAnimationTimeMillis());
			return a;
		}

		/// <summary>Make an animation for objects becoming invisible.</summary>
		/// <remarks>
		/// Make an animation for objects becoming invisible. Uses a slide and fade
		/// effect.
		/// </remarks>
		/// <param name="c">Context for loading resources</param>
		/// <param name="toRight">is the object to be animated exiting to the right</param>
		/// <returns>The new animation</returns>
		public static android.view.animation.Animation makeOutAnimation(android.content.Context
			 c, bool toRight)
		{
			android.view.animation.Animation a;
			if (toRight)
			{
				a = android.view.animation.AnimationUtils.loadAnimation(c, android.@internal.R.anim
					.slide_out_right);
			}
			else
			{
				a = android.view.animation.AnimationUtils.loadAnimation(c, android.@internal.R.anim
					.slide_out_left);
			}
			a.setInterpolator(new android.view.animation.AccelerateInterpolator());
			a.setStartTime(currentAnimationTimeMillis());
			return a;
		}

		/// <summary>Make an animation for objects becoming visible.</summary>
		/// <remarks>
		/// Make an animation for objects becoming visible. Uses a slide up and fade
		/// effect.
		/// </remarks>
		/// <param name="c">Context for loading resources</param>
		/// <returns>The new animation</returns>
		public static android.view.animation.Animation makeInChildBottomAnimation(android.content.Context
			 c)
		{
			android.view.animation.Animation a;
			a = android.view.animation.AnimationUtils.loadAnimation(c, android.@internal.R.anim
				.slide_in_child_bottom);
			a.setInterpolator(new android.view.animation.AccelerateInterpolator());
			a.setStartTime(currentAnimationTimeMillis());
			return a;
		}

		/// <summary>
		/// Loads an
		/// <see cref="Interpolator">Interpolator</see>
		/// object from a resource
		/// </summary>
		/// <param name="context">Application context used to access resources</param>
		/// <param name="id">The resource id of the animation to load</param>
		/// <returns>The animation object reference by the specified id</returns>
		/// <exception cref="android.content.res.Resources.NotFoundException">android.content.res.Resources.NotFoundException
		/// 	</exception>
		public static android.view.animation.Interpolator loadInterpolator(android.content.Context
			 context, int id)
		{
			android.content.res.XmlResourceParser parser = null;
			try
			{
				parser = context.getResources().getAnimation(id);
				return createInterpolatorFromXml(context, parser);
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
		private static android.view.animation.Interpolator createInterpolatorFromXml(android.content.Context
			 c, org.xmlpull.v1.XmlPullParser parser)
		{
			android.view.animation.Interpolator interpolator = null;
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
				android.util.AttributeSet attrs = android.util.Xml.asAttributeSet(parser);
				string name = parser.getName();
				if (name.Equals("linearInterpolator"))
				{
					interpolator = new android.view.animation.LinearInterpolator(c, attrs);
				}
				else
				{
					if (name.Equals("accelerateInterpolator"))
					{
						interpolator = new android.view.animation.AccelerateInterpolator(c, attrs);
					}
					else
					{
						if (name.Equals("decelerateInterpolator"))
						{
							interpolator = new android.view.animation.DecelerateInterpolator(c, attrs);
						}
						else
						{
							if (name.Equals("accelerateDecelerateInterpolator"))
							{
								interpolator = new android.view.animation.AccelerateDecelerateInterpolator(c, attrs
									);
							}
							else
							{
								if (name.Equals("cycleInterpolator"))
								{
									interpolator = new android.view.animation.CycleInterpolator(c, attrs);
								}
								else
								{
									if (name.Equals("anticipateInterpolator"))
									{
										interpolator = new android.view.animation.AnticipateInterpolator(c, attrs);
									}
									else
									{
										if (name.Equals("overshootInterpolator"))
										{
											interpolator = new android.view.animation.OvershootInterpolator(c, attrs);
										}
										else
										{
											if (name.Equals("anticipateOvershootInterpolator"))
											{
												interpolator = new android.view.animation.AnticipateOvershootInterpolator(c, attrs
													);
											}
											else
											{
												if (name.Equals("bounceInterpolator"))
												{
													interpolator = new android.view.animation.BounceInterpolator(c, attrs);
												}
												else
												{
													throw new java.lang.RuntimeException("Unknown interpolator name: " + parser.getName
														());
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
			return interpolator;
		}
	}
}
