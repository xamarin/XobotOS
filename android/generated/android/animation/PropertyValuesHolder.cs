using Sharpen;

namespace android.animation
{
	[Sharpen.Stub]
	public class PropertyValuesHolder : System.ICloneable
	{
		internal string mPropertyName;

		protected internal android.util.Property<object, object> mProperty;

		internal System.Reflection.MethodInfo mSetter = null;

		private System.Reflection.MethodInfo mGetter = null;

		internal System.Type mValueType;

		internal android.animation.KeyframeSet mKeyframeSet = null;

		private static readonly android.animation.TypeEvaluator<object> sIntEvaluator;

		private static readonly android.animation.TypeEvaluator<object> sFloatEvaluator;

		private static System.Type[] FLOAT_VARIANTS = new System.Type[] { typeof(float), 
			typeof(float), typeof(double), typeof(int), typeof(double), typeof(int) };

		private static System.Type[] INTEGER_VARIANTS = new System.Type[] { typeof(int), 
			typeof(int), typeof(float), typeof(double), typeof(float), typeof(double) };

		private static System.Type[] DOUBLE_VARIANTS = new System.Type[] { typeof(double)
			, typeof(double), typeof(float), typeof(int), typeof(float), typeof(int) };

		private static readonly java.util.HashMap<System.Type, java.util.HashMap<string, 
			System.Reflection.MethodInfo>> sSetterPropertyMap = new java.util.HashMap<System.Type
			, java.util.HashMap<string, System.Reflection.MethodInfo>>();

		private static readonly java.util.HashMap<System.Type, java.util.HashMap<string, 
			System.Reflection.MethodInfo>> sGetterPropertyMap = new java.util.HashMap<System.Type
			, java.util.HashMap<string, System.Reflection.MethodInfo>>();

		internal readonly java.util.concurrent.locks.ReentrantReadWriteLock mPropertyMapLock
			 = new java.util.concurrent.locks.ReentrantReadWriteLock();

		internal readonly object[] mTmpValueArray = new object[1];

		private android.animation.TypeEvaluator<object> mEvaluator;

		private object mAnimatedValue;

		[Sharpen.Stub]
		private PropertyValuesHolder(string propertyName)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private PropertyValuesHolder(android.util.Property<object, object> property)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static android.animation.PropertyValuesHolder ofInt(string propertyName, params 
			int[] values)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static android.animation.PropertyValuesHolder ofInt<_T0>(android.util.Property
			<_T0, int> property, params int[] values)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static android.animation.PropertyValuesHolder ofFloat(string propertyName, 
			params float[] values)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static android.animation.PropertyValuesHolder ofFloat<_T0>(android.util.Property
			<_T0, float> property, params float[] values)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static android.animation.PropertyValuesHolder ofObject(string propertyName
			, android.animation.TypeEvaluator<object> evaluator, params object[] values)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static android.animation.PropertyValuesHolder ofObject<V>(android.util.Property
			<object, object> property, android.animation.TypeEvaluator<V> evaluator, params 
			V[] values)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static android.animation.PropertyValuesHolder ofKeyframe(string propertyName
			, params android.animation.Keyframe[] values)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static android.animation.PropertyValuesHolder ofKeyframe(android.util.Property
			<object, object> property, params android.animation.Keyframe[] values)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setIntValues(params int[] values)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setFloatValues(params float[] values)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setKeyframes(params android.animation.Keyframe[] values)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setObjectValues(params object[] values)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private System.Reflection.MethodInfo getPropertyFunction(System.Type targetClass, 
			string prefix, System.Type valueType)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private System.Reflection.MethodInfo setupSetterOrGetter(System.Type targetClass, 
			java.util.HashMap<System.Type, java.util.HashMap<string, System.Reflection.MethodInfo
			>> propertyMapMap, string prefix, System.Type valueType)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual void setupSetter(System.Type targetClass)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void setupGetter(System.Type targetClass)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual void setupSetterAndGetter(object target)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void setupValue(object target, android.animation.Keyframe kf)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual void setupStartValue(object target)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual void setupEndValue(object target)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.animation.PropertyValuesHolder clone()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual void setAnimatedValue(object target)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual void init()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setEvaluator(android.animation.TypeEvaluator<object> evaluator
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual void calculateValue(float fraction)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setPropertyName(string propertyName)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setProperty(android.util.Property<object, object> property)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual string getPropertyName()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual object getAnimatedValue()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public override string ToString()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal static string getMethodName(string prefix, string propertyName)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal class IntPropertyValuesHolder : android.animation.PropertyValuesHolder
		{
			private static readonly java.util.HashMap<System.Type, java.util.HashMap<string, 
				int>> sJNISetterPropertyMap = new java.util.HashMap<System.Type, java.util.HashMap
				<string, int>>();

			internal int mJniSetter;

			private android.util.IntProperty<object> mIntProperty;

			internal android.animation.IntKeyframeSet mIntKeyframeSet;

			internal int mIntAnimatedValue;

			[Sharpen.Stub]
			internal IntPropertyValuesHolder(string propertyName, android.animation.IntKeyframeSet
				 keyframeSet) : base(propertyName)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			internal IntPropertyValuesHolder(android.util.Property<object, object> property, 
				android.animation.IntKeyframeSet keyframeSet) : base(property)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public IntPropertyValuesHolder(string propertyName, params int[] values) : base(propertyName
				)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public IntPropertyValuesHolder(android.util.Property<object, object> property, params 
				int[] values) : base(property)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"android.animation.PropertyValuesHolder")]
			public override void setIntValues(params int[] values)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"android.animation.PropertyValuesHolder")]
			internal override void calculateValue(float fraction)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"android.animation.PropertyValuesHolder")]
			internal override object getAnimatedValue()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"android.animation.PropertyValuesHolder")]
			public override android.animation.PropertyValuesHolder clone()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"android.animation.PropertyValuesHolder")]
			internal override void setAnimatedValue(object target)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"android.animation.PropertyValuesHolder")]
			internal override void setupSetter(System.Type targetClass)
			{
				throw new System.NotImplementedException();
			}
		}

		[Sharpen.Stub]
		internal class FloatPropertyValuesHolder : android.animation.PropertyValuesHolder
		{
			private static readonly java.util.HashMap<System.Type, java.util.HashMap<string, 
				int>> sJNISetterPropertyMap = new java.util.HashMap<System.Type, java.util.HashMap
				<string, int>>();

			internal int mJniSetter;

			private android.util.FloatProperty<object> mFloatProperty;

			internal android.animation.FloatKeyframeSet mFloatKeyframeSet;

			internal float mFloatAnimatedValue;

			[Sharpen.Stub]
			internal FloatPropertyValuesHolder(string propertyName, android.animation.FloatKeyframeSet
				 keyframeSet) : base(propertyName)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			internal FloatPropertyValuesHolder(android.util.Property<object, object> property
				, android.animation.FloatKeyframeSet keyframeSet) : base(property)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public FloatPropertyValuesHolder(string propertyName, params float[] values) : base
				(propertyName)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public FloatPropertyValuesHolder(android.util.Property<object, object> property, 
				params float[] values) : base(property)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"android.animation.PropertyValuesHolder")]
			public override void setFloatValues(params float[] values)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"android.animation.PropertyValuesHolder")]
			internal override void calculateValue(float fraction)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"android.animation.PropertyValuesHolder")]
			internal override object getAnimatedValue()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"android.animation.PropertyValuesHolder")]
			public override android.animation.PropertyValuesHolder clone()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"android.animation.PropertyValuesHolder")]
			internal override void setAnimatedValue(object target)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"android.animation.PropertyValuesHolder")]
			internal override void setupSetter(System.Type targetClass)
			{
				throw new System.NotImplementedException();
			}
		}

		[Sharpen.Stub]
		private static int nGetIntMethod(System.Type targetClass, string methodName)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static int nGetFloatMethod(System.Type targetClass, string methodName)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static void nCallIntMethod(object target, int methodID, int arg)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static void nCallFloatMethod(object target, int methodID, float arg)
		{
			throw new System.NotImplementedException();
		}

		object System.ICloneable.Clone()
		{
			return MemberwiseClone();
		}
	}
}
