using Sharpen;

namespace android.animation
{
	[Sharpen.Stub]
	public sealed partial class ObjectAnimator : android.animation.ValueAnimator
	{
		internal const bool DBG = false;

		private object mTarget;

		private string mPropertyName;

		private android.util.Property<object, object> mProperty;

		[Sharpen.Stub]
		public void setPropertyName(string propertyName)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void setProperty(android.util.Property<object, object> property)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public string getPropertyName()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public ObjectAnimator()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private ObjectAnimator(object target, string propertyName)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static android.animation.ObjectAnimator ofInt(object target, string propertyName
			, params int[] values)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static android.animation.ObjectAnimator ofInt<T>(T target, android.util.Property
			<T, int> property, params int[] values)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static android.animation.ObjectAnimator ofFloat(object target, string propertyName
			, params float[] values)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static android.animation.ObjectAnimator ofFloat<T>(T target, android.util.Property
			<T, float> property, params float[] values)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static android.animation.ObjectAnimator ofObject(object target, string propertyName
			, android.animation.TypeEvaluator<object> evaluator, params object[] values)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static android.animation.ObjectAnimator ofObject<T, V>(T target, android.util.Property
			<T, V> property, android.animation.TypeEvaluator<V> evaluator, params V[] values
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static android.animation.ObjectAnimator ofPropertyValuesHolder(object target
			, params android.animation.PropertyValuesHolder[] values)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.animation.ValueAnimator")]
		public override void setIntValues(params int[] values)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.animation.ValueAnimator")]
		public override void setFloatValues(params float[] values)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.animation.ValueAnimator")]
		public override void setObjectValues(params object[] values)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.animation.Animator")]
		public override void start()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.animation.ValueAnimator")]
		internal override void initAnimation()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.animation.Animator")]
		public override android.animation.Animator setDuration(long duration)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public object getTarget()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.animation.Animator")]
		public override void setTarget(object target)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.animation.Animator")]
		public override void setupStartValues()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.animation.Animator")]
		public override void setupEndValues()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.animation.ValueAnimator")]
		internal override void animateValue(float fraction)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.animation.Animator")]
		public override android.animation.Animator clone()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public override string ToString()
		{
			throw new System.NotImplementedException();
		}
	}
}
