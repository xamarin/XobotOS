/* Copyright (C) 2009  Versant Inc.   http://www.db4o.com */
package sharpen.core;

import static sharpen.core.framework.Environments.my;

import org.eclipse.jdt.core.dom.*;

public class CRefBuilder {

	private ASTNode _crefTarget;

	public CRefBuilder(ASTNode ref) {
		_crefTarget = ref;
	}

	public String build() {
		switch (_crefTarget.getNodeType()) {
		case ASTNode.SIMPLE_NAME:
		case ASTNode.QUALIFIED_NAME:
			return mapCRefTarget(_crefTarget, ((Name) _crefTarget).resolveBinding());
		case ASTNode.MEMBER_REF:
			return mapCRefTarget(_crefTarget, ((MemberRef) _crefTarget).resolveBinding());
		case ASTNode.METHOD_REF:
			return mapCRefTarget(_crefTarget, ((MethodRef) _crefTarget).resolveBinding());
		}
		return null;
	}

	private String mapCRefTarget(ASTNode node, IBinding binding) {
		if (null == binding) {
			my(Configuration.class).getWarningHandler().warning(node, "Unresolved cref target");
			return node.toString();
		}
		return documentationNameFor(binding);
	}

	private String documentationNameFor(IBinding binding) {
		switch (binding.getKind()) {
		case IBinding.METHOD:
			return methodSignatureForDocumentation((IMethodBinding) binding);
		case IBinding.TYPE:
			return mappedTypeName((ITypeBinding) binding);
		case IBinding.VARIABLE:
			return mappedQualifiedFieldName((IVariableBinding) binding);
		case IBinding.PACKAGE:
			return mappedNamespace(((IPackageBinding) binding).getName());
		}
		throw new IllegalArgumentException("Binding type not supported: " + binding);
	}

	private String methodSignatureForDocumentation(final IMethodBinding method) {
		StringBuilder methodFQN = new StringBuilder();

		if (belongsToCurrentType(method)) {
			methodFQN.append(mappedMethodName(method));
		} else {
			methodFQN.append(mappedQualifiedMethodName(method));
		}

		final String parameterList = parameterListSeparatedBy(method, 	", ");

		methodFQN.append(genericTypeParametersFor(method));
		methodFQN.append("(");
		methodFQN.append(parameterList);
		methodFQN.append(")");

		return methodFQN.toString();
	}

	private boolean belongsToCurrentType(IMethodBinding method) {
		return _currentType == method.getDeclaringClass();
	}

	private String mappedQualifiedMethodName(IMethodBinding binding) {
		String methodName = mappedMethodName(binding);
		if (methodName.indexOf('.') > -1) {
			return methodName;
		}
		return mappedTypeName(binding.getDeclaringClass()) + "." + methodName;
	}

	private String genericTypeParametersFor(IMethodBinding method) {
		final IMethodBinding bind = method.getMethodDeclaration();
		return genericQualifierFor(bind.getTypeParameters());
	}

	private String genericQualifierFor(final ITypeBinding[] typeParameters) {
		if (typeParameters.length == 0)
			return "";

		return "{" + typesSeparatedBy(typeParameters, ", ") + "}";
	}

	private String parameterListSeparatedBy(final IMethodBinding binding,	final String separator) {
		return typesSeparatedBy(binding.getParameterTypes(), separator);
	}

	private String typesSeparatedBy(final ITypeBinding[] types, final String separator) {
		StringBuilder result = new StringBuilder();
		for (ITypeBinding parameter : types) {
			if (result.length() > 0) {
				result.append(separator);
			}

			result.append(mappedTypeName(parameter));
		}
		return result.toString();
	}

	private String mappedMethodName(IMethodBinding binding) {
		return my(Mappings.class).mappedMethodName(binding);
	}

	private String mappedQualifiedFieldName(IVariableBinding binding) {
		String mapped = my(Mappings.class).mappedFieldName(binding);
		String name = mapped != null ? mapped : identifier(binding.getName());
		if (name.indexOf('.') > 0)
			return name;

		if (_currentType == binding.getDeclaringClass())
			return name;

		return mappedTypeName(binding.getDeclaringClass()) + "." + name;
	}

	private String mappedTypeName(ITypeBinding type) {
		if (type.isArray()){
			int dimensions = type.getDimensions();
			StringBuilder sb = new StringBuilder();
			for(int i =0; i < dimensions; i++){
				sb.append("[]");
			}
			return mappedTypeName(type.getElementType()) + sb;
		}

		final String mappedTypeName = my(Mappings.class).mappedTypeName(type);

		final String effectiveTypeName = _currentType.getPackage() == type.getPackage()
				? simpleName(mappedTypeName)
						: mappedTypeName;

				return effectiveTypeName + genericQualifierFor(type.getTypeDeclaration().getTypeParameters());
	}

	private String simpleName(String typeName) {
		final int lastDot = typeName.lastIndexOf('.');
		return lastDot > 0
				? typeName.substring(lastDot + 1)
						: typeName;
	}

	private String identifier(String name) {
		return my(Configuration.class).getNamingStrategy().identifier(name);
	}

	private String mappedNamespace(String namespace) {
		return my(Configuration.class).mappedNamespace(namespace);
	}

	private final ITypeBinding _currentType = my(NameScope.class).currentType().resolveBinding();
}
