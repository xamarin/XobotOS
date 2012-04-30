package sharpen.xobotos;

import sharpen.core.Configuration;
import sharpen.core.MemberKind;

public abstract class StandardConfiguration extends Configuration {

	public enum ConfigFlags {
		DEFAULT
	}

	protected StandardConfiguration(ConfigFlags flags) {
		setUpDefaultMappings(flags);
	}

	private void setUpDefaultMappings(ConfigFlags flags) {
		setUpPrimitiveMappings();
		setUpAnnotationMappings();

		mapMethod("java.lang.System.identityHashCode", sharpenUtilMethod("IdentityHashCode"));
		mapProperty("java.lang.System.currentTimeMillis", sharpenUtilMethod("CurrentTimeMillis"));

		mapType("java.lang.Math", "System.Math");
		mapMethod("java.lang.Math.abs", "System.Math.Abs");
		mapMethod("java.lang.Math.max", "System.Math.Max");
		mapMethod("java.lang.Math.min", "System.Math.Min");
		mapMethod("java.lang.Math.round", "System.Math.Round");
		mapMethod("java.lang.Math.round(float)", sharpenUtilMethod("Round"));
		mapMethod("java.lang.Math.floor", sharpenUtilMethod("Floor"));
		mapMethod("java.lang.Math.ceil", "System.Math.Ceiling");
		mapMethod("java.lang.Math.log", "System.Math.Log");
		mapMethod("java.lang.Math.exp", "System.Math.Exp");
		mapMethod("java.lang.Math.pow", "System.Math.Pow");
		mapMethod("java.lang.Math.sqrt", "System.Math.Sqrt");
		mapMethod("java.lang.Math.sin", "System.Math.Sin");
		mapMethod("java.lang.Math.cos", "System.Math.Cos");
		mapMethod("java.lang.Math.tan", "System.Math.Tan");
		mapMethod("java.lang.Math.sinh", "System.Math.Sinh");
		mapMethod("java.lang.Math.cosh", "System.Math.Cosh");
		mapMethod("java.lang.Math.tanh", "System.Math.Tanh");
		mapMethod("java.lang.Math.asin", "System.Math.Asin");
		mapMethod("java.lang.Math.acos", "System.Math.Acos");
		mapMethod("java.lang.Math.atan", "System.Math.Atan");
		mapMethod("java.lang.Math.atan2", "System.Math.Atan2");
		mapMethod("java.lang.Math.signum", "System.Math.Sign");

		mapType("java.util.Random", "System.Random");
		mapMethod("java.util.Random.nextInt", sharpenUtilMethod("Random_NextInt"));
		mapMethod("java.util.Random.nextFloat", sharpenUtilMethod("Random_NextFloat"));

		mapMethod("java.lang.System.exit", "System.Environment.Exit");
		mapMethod("java.lang.System.logI", miscRuntimeMethod("LogI"));
		mapMethod("java.lang.System.logW", miscRuntimeMethod("LogW"));
		mapMethod("java.lang.System.logE", miscRuntimeMethod("LogE"));

		setUpExceptionMappings();

		mapType("java.lang.Cloneable", "System.ICloneable");

		mapType("java.util.Date", "System.DateTime");

		mapMethod("java.lang.Object.toString", "ToString");
		mapMethod("java.lang.Object.hashCode", "GetHashCode");
		mapMethod("java.lang.Object.equals", "Equals");

		mapMethod("java.lang.Float.isNaN", "float.IsNaN");
		mapMethod("java.lang.Double.isNaN", "double.IsNaN");
		mapMethod("java.lang.Float.compare", "CompareTo");
		mapMethod("java.lang.Double.compare", sharpenUtilMethod("Compare"));

		setUpStringMappings();

		setUpIoMappings();

		mapMethod("java.lang.Throwable.printStackTrace", miscRuntimeMethod("PrintStackTrace"));

		mapMethod("java.lang.System.arraycopy", "System.Array.Copy");
		mapMethod("java.lang.Object.wait", "System.Threading.Monitor.Wait");
		mapMethod("java.lang.Object.notify", "System.Threading.Monitor.Pulse");
		mapMethod("java.lang.Object.notifyAll", "System.Threading.Monitor.PulseAll");
		mapMethod("java.lang.Object.clone", "MemberwiseClone");

		setUpPrimitiveWrappers();

		mapMethod("length", "Length"); // see qualifiedname(IVariableBinding)

		setUpNativeTypeSystem();

		mapMethod("java.math.BigDecimal", "System.Decimal");
	}

	protected String collectionRuntimeMethod(String methodName) {
		return "Sharpen.Collections." + methodName;
	}

	protected String sharpenUtilMethod(String methodName) {
		return "Sharpen.Util." + methodName;
	}

	protected String sharpenUtilType(String typeName) {
		return "Sharpen.Util." + typeName;
	}

	protected String sharpenCharMethod(String methodName) {
		return "Sharpen.CharHelper." + methodName;
	}

	protected String sharpenStringMethod(String methodName) {
		return "Sharpen.StringHelper." + methodName;
	}

	protected abstract String reflectionRuntimeMethod(String methodName);

	protected abstract String miscRuntimeMethod(String methodName);

	protected void setUpAnnotationMappings() {
		mapType("java.lang.Deprecated", "System.Obsolete");
	}

	protected void setUpPrimitiveMappings() {
		mapType("boolean", "bool");
		mapPrimitive("void");
		mapPrimitive("char");
		mapPrimitive("byte");
		mapPrimitive("short");
		mapPrimitive("int");
		mapPrimitive("long");
		mapPrimitive("float");
		mapPrimitive("double");
		mapType("ubyte", "byte");

		mapType("java.lang.Object", "object");
		mapType("java.lang.String", "string");
		mapType("java.lang.Character", "char");
		mapType("java.lang.Byte", "byte");
		mapType("java.lang.Boolean", "bool");
		mapType("java.lang.Short", "short");
		mapType("java.lang.Integer", "int");
		mapType("java.lang.Long", "long");
		mapType("java.lang.Float", "float");
		mapType("java.lang.Double", "double");
		mapType("java.lang.Void", "object");
	}

	final static String[] charConstants = { "MIN_VALUE", "MAX_VALUE", "MIN_RADIX", "MAX_RADIX", "UNASSIGNED",
		"UPPERCASE_LETTER", "LOWERCASE_LETTER", "TITLECASE_LETTER", "MODIFIER_LETTER", "OTHER_LETTER",
		"NON_SPACING_MARK", "ENCLOSING_MARK", "COMBINING_SPACING_MARK", "DECIMAL_DIGIT_NUMBER",
		"LETTER_NUMBER", "OTHER_NUMBER", "SPACE_SEPARATOR", "LINE_SEPARATOR", "PARAGRAPH_SEPARATOR",
		"CONTROL", "FORMAT", "PRIVATE_USE", "SURROGATE", "DASH_PUNCTUATION", "START_PUNCTUATION",
		"END_PUNCTUATION", "CONNECTOR_PUNCTUATION", "OTHER_PUNCTUATION", "MATH_SYMBOL",
		"CURRENCY_SYMBOL", "MODIFIER_SYMBOL", "OTHER_SYMBOL", "INITIAL_QUOTE_PUNCTUATION",
		"FINAL_QUOTE_PUNCTUATION", "DIRECTIONALITY_UNDEFINED", "DIRECTIONALITY_LEFT_TO_RIGHT",
		"DIRECTIONALITY_RIGHT_TO_LEFT", "DIRECTIONALITY_RIGHT_TO_LEFT_ARABIC",
		"DIRECTIONALITY_EUROPEAN_NUMBER", "DIRECTIONALITY_EUROPEAN_NUMBER_SEPARATOR",
		"DIRECTIONALITY_EUROPEAN_NUMBER_TERMINATOR", "DIRECTIONALITY_ARABIC_NUMBER",
		"DIRECTIONALITY_COMMON_NUMBER_SEPARATOR", "DIRECTIONALITY_NONSPACING_MARK",
		"DIRECTIONALITY_BOUNDARY_NEUTRAL", "DIRECTIONALITY_PARAGRAPH_SEPARATOR",
		"DIRECTIONALITY_SEGMENT_SEPARATOR", "DIRECTIONALITY_WHITESPACE",
		"DIRECTIONALITY_OTHER_NEUTRALS", "DIRECTIONALITY_LEFT_TO_RIGHT_EMBEDDING",
		"DIRECTIONALITY_LEFT_TO_RIGHT_OVERRIDE", "DIRECTIONALITY_RIGHT_TO_LEFT_EMBEDDING",
		"DIRECTIONALITY_RIGHT_TO_LEFT_OVERRIDE", "DIRECTIONALITY_POP_DIRECTIONAL_FORMAT",
		"MIN_HIGH_SURROGATE", "MAX_HIGH_SURROGATE", "MIN_LOW_SURROGATE", "MAX_LOW_SURROGATE",
		"MIN_SURROGATE", "MAX_SURROGATE", "MIN_SUPPLEMENTARY_CODE_POINT", "MIN_CODE_POINT",
		"MAX_CODE_POINT", "SIZE" };

	protected void setUpStringMappings() {
		mapMethod("java.lang.String.intern", "string.Intern");
		mapMethod("java.lang.String.indexOf", "IndexOf");
		mapMethod("java.lang.String.lastIndexOf", "LastIndexOf");
		mapMethod("java.lang.String.trim", "Trim");
		mapMethod("java.lang.String.toUpperCase", "ToUpper");
		mapMethod("java.lang.String.toLowerCase", "ToLower");
		mapMethod("java.lang.String.compareTo", "CompareTo");
		mapMethod("java.lang.String.compareToIgnoreCase", sharpenStringMethod("CompareToIgnoreCase"));
		mapMethod("java.lang.Comparable.compareTo(java.lang.String)", "string.CompareOrdinal");
		mapMethod("java.lang.String.toCharArray", "ToCharArray");
		mapMethod("java.lang.String.replace", "Replace");
		mapMethod("java.lang.String.startsWith(java.lang.String,int)", sharpenStringMethod("StartsWith"));
		mapMethod("java.lang.String.startsWith", "StartsWith");
		mapMethod("java.lang.String.endsWith", "EndsWith");
		mapMethod("java.lang.String.substring", sharpenStringMethod("Substring"));
		mapIndexer("java.lang.String.charAt");
		mapMethod("java.lang.String.getChars", sharpenStringMethod("GetCharsForString"));
		mapMethod("java.lang.String._getChars", sharpenStringMethod("GetCharsForString"));
		mapMethod("java.lang.String.getBytes(java.nio.charset.Charset)", miscRuntimeMethod("GetBytesForString"));
		mapMethod("java.lang.String.getBytes", sharpenStringMethod("GetBytesForString"));
		mapMethod("java.lang.String.equalsIgnoreCase", sharpenStringMethod("EqualsIgnoreCase"));
		mapMethod("java.lang.String.valueOf(java.lang.Object)", sharpenStringMethod("GetValueOf"));
		mapMethod("java.lang.String.valueOf", "ToString");
		mapMethod("java.lang.String.String(byte[])", sharpenStringMethod("GetStringForBytes"));
		mapMethod("java.lang.String.String(byte[],int,int)", sharpenStringMethod("GetStringForBytes"));
		mapMethod("java.lang.String.String(byte[],int,int,java.lang.String)",
				sharpenStringMethod("GetStringForBytes"));
		mapMethod("java.lang.String.String(byte[],java.lang.String)", sharpenStringMethod("GetStringForBytes"));
		mapMethod("java.lang.String.String(int,int,char[])", sharpenStringMethod("GetString"));
		mapMethod("java.lang.String.String(byte[],java.nio.charset.Charset)",
				miscRuntimeMethod("GetStringForBytes"));
		mapMethod("java.lang.String.String(byte[],int,int,java.nio.charset.Charset)",
				miscRuntimeMethod("GetStringForBytes"));
		mapProperty("java.lang.String.length", "Length");
		mapMethod("java.lang.String.format", "string.Format");
		mapMethod("java.lang.String.contains", "Contains");
		mapMethod("java.lang.String.codePointAt", sharpenCharMethod("CodePointAt"));
		mapMethod("java.lang.String.codePointBefore", sharpenCharMethod("CodePointBefore"));
		mapMethod("java.lang.String.split(java.lang.String,int)", miscRuntimeMethod("SplitStringRegex"));
		mapMethod("java.lang.String.split(java.lang.String)", miscRuntimeMethod("SplitStringRegex"));
		mapMethod("java.lang.String.split", "Split");
		mapMethod("java.lang.String.copyValueOf", sharpenStringMethod("CopyValueOf"));
		mapMethod("java.lang.String.isEmpty", "string.IsNullOrEmpty");
		mapMethod("java.lang.String.regionMatches", sharpenStringMethod("RegionMatches"));

		mapIndexer("java.lang.CharSequence.charAt");
		mapProperty("java.lang.CharSequence.length", "Length");
		mapMethod("java.lang.CharSequence.subSequence", "SubSequence");

		mapIndexer("java.lang.AbstractStringBuilder.charAt");
		mapProperty("java.lang.AbstractStringBuilder.length", "Length");
		mapMethod("java.lang.AbstractStringBuilder.subSequence", "SubSequence");

		mapMethod("java.lang.Character.isLowerCase(int)", sharpenCharMethod("IsLower"));
		mapMethod("java.lang.Character.isLowerCase", "System.Char.IsLower");
		mapMethod("java.lang.Character.isUpperCase(int)", sharpenCharMethod("IsUpper"));
		mapMethod("java.lang.Character.isUpperCase", "System.Char.IsUpper");
		mapMethod("java.lang.Character.isHighSurrogate", "System.Char.IsHighSurrogate");
		mapMethod("java.lang.Character.isSpaceChar", "System.Char.IsWhiteSpace");
		mapMethod("java.lang.Character.isLetter", "System.Char.IsLetter");
		mapMethod("java.lang.Character.isDigit(int)", sharpenCharMethod("IsDigit"));
		mapMethod("java.lang.Character.isDigit", "System.Char.IsDigit");
		mapMethod("java.lang.Character.isISOControl", sharpenCharMethod("IsISOControl"));
		mapMethod("java.lang.Character.digit", sharpenCharMethod("Digit"));
		mapMethod("java.lang.Character.isLetterOrDigit", "System.Char.IsLetterOrDigit");
		mapMethod("java.lang.Character.isLetterOrDigit(int)", sharpenCharMethod("IsLetterOrDigit"));
		mapMethod("java.lang.Character.getType", sharpenCharMethod("GetType"));
		mapMethod("java.lang.Character.toLowerCase(int)", sharpenCharMethod("ToLower"));
		mapMethod("java.lang.Character.toLowerCase", "System.Char.ToLower");
		mapMethod("java.lang.Character.toUpperCase(int)", sharpenCharMethod("ToUpper"));
		mapMethod("java.lang.Character.toUpperCase", "System.Char.ToUpper");
		mapMethod("java.lang.Character.isSurrogatePair", "System.Char.IsSurrogatePair");
		mapMethod("java.lang.Character.codePointAt", sharpenCharMethod("CodePointAt"));
		mapMethod("java.lang.Character.codePointBefore", sharpenCharMethod("CodePointBefore"));
		mapMethod("java.lang.Character.codePointCount", sharpenCharMethod("CodePointCount"));
		mapMethod("java.lang.Character.offsetByCodePoints", sharpenCharMethod("OffsetByCodePoints"));
		mapMethod("java.lang.Character.getDirectionality", sharpenCharMethod("GetDirectionality"));
		mapMethod("java.lang.Character.getNumericValue", sharpenCharMethod("GetNumericValue"));
		for (final String name : charConstants) {
			mapField("java.lang.Character." + name, sharpenCharMethod(name));
		}

		mapType("java.util.Locale", "System.Globalization.CultureInfo");
		mapProperty("java.util.Locale.getDefault", "System.Globalization.CultureInfo.CurrentCulture");
		mapMethod("java.util.Locale.setDefault", sharpenUtilMethod("SetCurrentCulture"));
		mapProperty("java.util.Locale.US", "System.Globalization.CultureInfo.InvariantCulture");
		mapMethod("java.util.Locale.getLanguage", sharpenUtilMethod("GetLanguage"));
		mapMethod("java.util.Locale.getCountry", sharpenUtilMethod("GetCountry"));
		mapMethod("java.util.Locale.getVariant", sharpenUtilMethod("GetVariant"));
		mapMethod("java.util.Locale.clone", "Clone");
		mapType("libcore.icu.LocaleData", sharpenUtilType("LocaleData"));
		mapMethod("libcore.icu.LocaleData.get(java.util.Locale)", sharpenUtilMethod("GetLocaleData"));
	}

	protected void setUpStringBuilderMapping(String typeName) {
		mapType(typeName, "System.Text.StringBuilder");
		mapProperty(typeName + ".length", "Length");
		mapProperty(typeName + ".setLength", "Length");
		mapMethod(typeName + ".append", "Append");
		mapMethod(typeName + ".append(char)", "Append");
		mapMethod(typeName + ".insert", "Insert");
		mapMethod(typeName + ".deleteCharAt", sharpenStringMethod("DeleteCharAt"));
		mapMethod(typeName + ".setCharAt", sharpenStringMethod("SetCharAt"));
	}

	protected void setUpIoMappings() {
		mapProperty("java.lang.System.in", "java.io.Console.In");
		mapProperty("java.lang.System.out", "java.io.Console.Out");
		mapProperty("java.lang.System.err", "java.io.Console.Error");
		mapProperty("java.lang.System.lineSeparator", "System.Environment.NewLine");
	}

	protected void setUpNativeTypeSystem() {
		mapType("java.lang.reflect.InvocationTargetException", "System.Reflection.TargetInvocationException");
		mapProperty("java.lang.reflect.InvocationTargetException.getTargetException", "InnerException");
		mapType("java.lang.IllegalAccessException", "System.MemberAccessException");

		// mapType("java.lang.reflect.Array", "System.Array");
		mapMethod("java.lang.reflect.Array.getLength", collectionRuntimeMethod("GetArrayLength"));
		mapMethod("java.lang.reflect.Array.get", collectionRuntimeMethod("GetArrayValue"));
		mapMethod("java.lang.reflect.Array.set", collectionRuntimeMethod("SetArrayValue"));
		mapMethod("java.lang.reflect.Array.newInstance", "System.Array.CreateInstance");

		mapMethod("java.lang.Object.getClass", "GetType");
		mapType("java.lang.Class", "System.Type");
		mapType("java.lang.Class<>", "System.Type");
		mapJavaLangClassProperty("getName", "FullName");
		mapJavaLangClassProperty("getSimpleName", "Name");
		mapJavaLangClassProperty("getSuperclass", "BaseType");
		mapJavaLangClassProperty("isArray", "IsArray");
		mapJavaLangClassProperty("isPrimitive", "IsPrimitive");
		mapJavaLangClassProperty("isInterface", "IsInterface");
		mapJavaLangClassMethod("isInstance", "IsInstanceOfType");
		mapJavaLangClassMethod("newInstance", "System.Activator.CreateInstance");
		mapJavaLangClassMethod("forName", reflectionRuntimeMethod("GetType"));
		mapJavaLangClassMethod("getComponentType", "GetElementType");
		mapJavaLangClassMethod("getField", "GetField");
		mapJavaLangClassMethod("getFields", "GetFields");
		mapJavaLangClassMethod("getDeclaredField", reflectionRuntimeMethod("GetDeclaredField"));
		mapJavaLangClassMethod("getDeclaredFields", reflectionRuntimeMethod("GetDeclaredFields"));
		mapJavaLangClassMethod("getDeclaredMethod", reflectionRuntimeMethod("GetDeclaredMethod"));
		mapJavaLangClassMethod("getDeclaredMethods", reflectionRuntimeMethod("GetDeclaredMethods"));
		mapJavaLangClassMethod("getMethod", reflectionRuntimeMethod("GetMethod"));
		mapJavaLangClassMethod("getConstructor", reflectionRuntimeMethod("GetConstructor"));
		mapJavaLangClassMethod("isAssignableFrom", "IsAssignableFrom");
		mapJavaLangClassMethod("getCanonicalName", reflectionRuntimeMethod("GetCanonicalName"));
		mapJavaLangClassMethod("asSubclass", reflectionRuntimeMethod("AsSubclass"));
		mapJavaLangClassMethod("getClassLoader", reflectionRuntimeMethod("GetClassLoader"));

		mapProperty("java.lang.reflect.Member.getName", "Name");
		mapProperty("java.lang.reflect.Member.getDeclaringClass", "DeclaringType");

		mapType("java.lang.reflect.Field", "System.Reflection.FieldInfo");
		mapProperty("java.lang.reflect.Field.getName", "Name");
		mapMethod("java.lang.reflect.Field.get", "GetValue");
		mapMethod("java.lang.reflect.Field.set", "SetValue");

		mapType("java.lang.reflect.Method", "System.Reflection.MethodInfo");
		mapProperty("java.lang.reflect.Method.getName", "Name");
		mapProperty("java.lang.reflect.Method.getReturnType", "ReturnType");
		mapMethod("java.lang.reflect.Method.getParameterTypes", reflectionRuntimeMethod("GetParameterTypes"));
		removeMethod("java.lang.reflect.AccessibleObject.setAccessible");

		mapMethod("java.lang.reflect.Method.invoke", reflectionRuntimeMethod("InvokeMethod"));

		mapType("java.lang.reflect.Constructor<>", "System.Reflection.ConstructorInfo");
		mapMember("java.lang.reflect.Constructor.newInstance", new MemberMapping("Invoke", MemberKind.Method,
				MappingFlags.CastResult));
	}

	private void mapJavaLangClassProperty(String methodName, String propertyName) {
		mapProperty("java.lang.Class." + methodName, propertyName);
	}

	private void mapJavaLangClassMethod(String methodName, String newMethodName) {
		mapMethod("java.lang.Class." + methodName, newMethodName);
	}

	protected void setUpExceptionMappings() {
		mapType("java.lang.Throwable", "System.Exception");
		mapProperty("java.lang.Throwable.getMessage", "Message");
		mapProperty("java.lang.Throwable.initCause", "InnerException");
		mapProperty("java.lang.Throwable.getCause", "InnerException");
		mapMethod("java.lang.Throwable.fillInStackTrace", miscRuntimeMethod("FillInStackTrace"));
		mapMethod("java.lang.Throwable.setStackTrace", miscRuntimeMethod("SetStackTrace"));
		mapProperty("java.lang.Throwable.getStackTrace", "StackTrace");
		mapType("java.lang.Error", "System.Exception");
		mapType("java.lang.OutOfMemoryError", "System.OutOfMemoryException");
		mapType("java.lang.Exception", "System.Exception");
		mapType("java.lang.ClassCastException", "System.InvalidCastException");
		mapType("java.lang.NullPointerException", "System.ArgumentNullException");
		mapType("java.lang.IllegalArgumentException", "System.ArgumentException");
		mapType("java.lang.IllegalStateException", "System.InvalidOperationException");
		mapType("java.lang.InterruptedException", "System.Exception");
		mapType("java.lang.IndexOutOfBoundsException", "System.IndexOutOfRangeException");
		mapType("java.lang.UnsupportedOperationException", "System.NotSupportedException");
		mapType("java.lang.ArrayIndexOutOfBoundsException", "System.IndexOutOfRangeException");
		mapType("java.lang.NoSuchMethodError", "System.MissingMethodException");
		mapType("java.lang.NumberFormatException", "System.ArgumentException");
		mapType("java.io.IOException", "System.IO.IOException");
		mapType("java.net.SocketException", "System.Net.Sockets.SocketException");
		mapType("java.lang.SecurityException", "System.Security.SecurityException");

		mapMethod("java.lang.ArrayIndexOutOfBoundsException.ArrayIndexOutOfBoundsException(int)",
				sharpenUtilMethod("IndexOutOfRangeCtor"));
		mapMethod("java.lang.ArrayIndexOutOfBoundsException.ArrayIndexOutOfBoundsException(int,int)",
				sharpenUtilMethod("IndexOutOfRangeCtor"));
		mapMethod("java.lang.ArrayIndexOutOfBoundsException.ArrayIndexOutOfBoundsException(int,int,int)",
				sharpenUtilMethod("IndexOutOfRangeCtor"));
	}

	protected void setUpPrimitiveWrappers() {
		mapField("java.lang.Short.MAX_VALUE", "short.MaxValue");
		mapField("java.lang.Short.MIN_VALUE", "short.MinValue");
		mapField("java.lang.Integer.MAX_VALUE", "int.MaxValue");
		mapField("java.lang.Integer.MIN_VALUE", "int.MinValue");
		mapField("java.lang.Long.MAX_VALUE", "long.MaxValue");
		mapField("java.lang.Long.MIN_VALUE", "long.MinValue");
		mapField("java.lang.Float.MAX_VALUE", "float.MaxValue");
		mapField("java.lang.Float.MIN_VALUE", "float.MinValue");
		mapField("java.lang.Float.POSITIVE_INFINITY", "float.PositiveInfinity");
		mapField("java.lang.Float.NEGATIVE_INFINITY", "float.NegativeInfinity");
		mapField("java.lang.Double.MAX_VALUE", "double.MaxValue");
		mapField("java.lang.Double.MIN_VALUE", "double.MinValue");
		mapField("java.lang.Double.NEGATIVE_INFINITY", "double.NegativeInfinity");
		mapField("java.lang.Double.POSITIVE_INFINITY", "double.PositiveInfinity");
		mapField("java.lang.Boolean.TRUE", "true");
		mapField("java.lang.Boolean.FALSE", "false");
		mapField("java.lang.Byte.MAX_VALUE", "byte.MaxValue");
		mapField("java.lang.Byte.MIN_VALUE", "byte.MinValue");
		mapField("java.lang.Character.MAX_VALUE", "char.MaxValue");
		mapField("java.lang.Character.MIN_VALUE", "char.MinValue");
		mapMethod("java.lang.Character.isWhitespace", "char.IsWhiteSpace");

		mapWrapperConstructor("java.lang.Boolean.Boolean", "System.Convert.ToBoolean", "boolean");
		mapWrapperConstructor("java.lang.Byte.Byte", "System.Convert.ToByte", "byte");
		mapWrapperConstructor("java.lang.Character.Character", "System.Convert.ToChar", "char");
		mapWrapperConstructor("java.lang.Short.Short", "System.Convert.ToInt16", "short");
		mapWrapperConstructor("java.lang.Integer.Integer", "System.Convert.ToInt32", "int");
		mapWrapperConstructor("java.lang.Long.Long", "System.Convert.ToInt64", "long");
		mapWrapperConstructor("java.lang.Float.Float", "System.Convert.ToSingle", "float");
		mapWrapperConstructor("java.lang.Double.Double", "System.Convert.ToDouble", "double");

		mapMethod("java.lang.Long.toString", "System.Convert.ToString");
		mapMethod("java.lang.Long.parseLong", "long.Parse");
		mapMethod("java.lang.Long.parseLong(java.lang.String,int)", sharpenUtilMethod("ParseLong"));
		mapMethod("java.lang.Long.bitCount", sharpenUtilMethod("Long_GetBitCount"));
		mapMethod("java.lang.Long.longValue", "");
		mapMethod("java.lang.Long.valueOf", "long.Parse");
		mapMethod("java.lang.Integer.toString", "System.Convert.ToString");
		mapMethod("java.lang.Integer.valueOf", "int.Parse");
		mapMethod("java.lang.Integer.valueOf(int)", sharpenUtilMethod("IntValueOf"));
		mapMethod("java.lang.Integer.parseInt", "System.Convert.ToInt32");
		mapMethod("java.lang.Integer.toHexString", sharpenUtilMethod("IntToHexString"));
		mapMethod("java.lang.Integer.bitCount", sharpenUtilMethod("IntGetBitCount"));
		mapMethod("java.lang.Integer.intValue", "");
		mapMethod("java.lang.Number.shortValue", "");
		mapMethod("java.lang.Number.intValue", "");
		mapMethod("java.lang.Number.longValue", "");
		mapMethod("java.lang.Number.byteValue", "");
		mapMethod("java.lang.Number.floatValue", "");
		mapMethod("java.lang.Number.doubleValue", "");
		mapMethod("java.lang.Character.charValue", "");
		mapMethod("java.lang.Boolean.booleanValue", "");
		mapMethod("java.lang.Boolean.valueOf", "bool.Parse");
		mapMethod("java.lang.Byte.toHexString", sharpenUtilMethod("ByteToHexString"));
		mapMethod("java.lang.Float.toString", "System.Convert.ToString");
		mapMethod("java.lang.Float.floatToIntBits", sharpenUtilMethod("FloatToIntBits"));
		mapMethod("java.lang.Float.floatToRawIntBits", sharpenUtilMethod("FloatToRawIntBits"));
		mapMethod("java.lang.Float.intBitsToFloat", sharpenUtilMethod("IntBitsToFloat"));
		mapMethod("java.lang.Float.parseFloat", "float.Parse");
		mapMethod("java.lang.Double.toString", "System.Convert.ToString");
		mapMethod("java.lang.Double.doubleToLongBits", sharpenUtilMethod("DoubleToLongBits"));
		mapMethod("java.lang.Double.longBitsToDouble", sharpenUtilMethod("LongBitsToDouble"));
		mapMethod("java.lang.Double.doubleToRawLongBits", sharpenUtilMethod("DoubleToRawLongBits"));
	}

	@Override
	public boolean isIgnoredExceptionType(String exceptionType) {
		return exceptionType.equals("java.lang.CloneNotSupportedException");
	}
}
