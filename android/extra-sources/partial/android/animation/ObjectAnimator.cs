using System;
using android.util;

namespace android.animation
{
	partial class ObjectAnimator
	{
		/// <summary>Private utility constructor that initializes the target object and property being animated.
		/// 	</summary>
		/// <remarks>Private utility constructor that initializes the target object and property being animated.
		/// 	</remarks>
		/// <param name="target">The object whose property is to be animated.</param>
		/// <param name="property">The property being animated.</param>
		internal ObjectAnimator (object target, Property<object, object> property)
		{
			mTarget = target;
			setProperty (property);
		}

	}
}

