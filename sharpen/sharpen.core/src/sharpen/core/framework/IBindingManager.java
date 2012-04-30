package sharpen.core.framework;

import org.eclipse.jdt.core.dom.IMethodBinding;
import org.eclipse.jdt.core.dom.ITypeBinding;
import org.eclipse.jdt.core.dom.IVariableBinding;

import sharpen.core.csharp.ast.CSTypeReferenceExpression;

public interface IBindingManager {

	ITypeBinding getObjectType();

	ITypeBinding getClassType();

	ITypeBinding getStringType();

	ITypeBinding getCharType();

	ITypeBinding getByteType();

	ITypeBinding getIntType();

	ITypeBinding getLongType();

	ITypeBinding getFloatType();

	ITypeBinding getSerializableType();

	ITypeInfo getTypeInfo(ITypeBinding binding);

	interface ITypeInfo {
		boolean isEventInterface();
	}

	IMethodInfo getMethodInfo(IMethodBinding binding);

	IMethodBinding getBaseMethod(IMethodBinding binding);

	interface IMethodInfo {
	}

	IVariableInfo getVariableInfo(IVariableBinding binding);

	interface IVariableInfo {
		String rename();

		CSTypeReferenceExpression autoCast();
	}

	IExtractedEnumInfo getExtractedEnumInfo(ITypeBinding binding);

	interface IExtractedEnumInfo {
		String valueField();
	}

}
