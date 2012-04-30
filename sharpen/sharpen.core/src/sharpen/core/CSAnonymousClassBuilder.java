/* Copyright (C) 2004 - 2008  Versant Inc.  http://www.db4o.com

This file is part of the sharpen open source java to c# translator.

sharpen is free software; you can redistribute it and/or modify it under
the terms of version 2 of the GNU General Public License as published
by the Free Software Foundation and as clarified by db4objects' GPL
interpretation policy, available at
http://www.db4o.com/about/company/legalpolicies/gplinterpretation/
Alternatively you can write to db4objects, Inc., 1900 S Norfolk Street,
Suite 350, San Mateo, CA 94403, USA.

sharpen is distributed in the hope that it will be useful, but WITHOUT ANY
WARRANTY; without even the implied warranty of MERCHANTABILITY or
FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License
for more details.

You should have received a copy of the GNU General Public License along
with this program; if not, write to the Free Software Foundation, Inc.,
59 Temple Place - Suite 330, Boston, MA  02111-1307, USA. */

package sharpen.core;

import org.eclipse.jdt.core.dom.*;

import sharpen.core.csharp.ast.*;

import java.util.LinkedHashSet;
import java.util.List;
import java.util.Set;

public class CSAnonymousClassBuilder extends AbstractNestedClassBuilder {

	private AnonymousClassDeclaration _node;

	private CSClass _type;

	private CSConstructor _constructor;

	private Set<IVariableBinding> _capturedVariables = new LinkedHashSet<IVariableBinding>();

	private CSharpBuilder _parent;

	private Set<VariableDeclarationFragment> _fieldInitializers = new LinkedHashSet<VariableDeclarationFragment>();

	public CSAnonymousClassBuilder(CSharpBuilder builder, AnonymousClassDeclaration node) {
		super(builder);
		_parent = builder;
		_node = node;
		run();
	}

	public CSClass type() {
		return _type;
	}

	public CSConstructor constructor() {
		return _constructor;
	}

	public Set<IVariableBinding> capturedVariables() {
		return _capturedVariables;
	}

	public CSConstructorInvocationExpression createConstructorInvocation() {
		CSExpression typeRef = new CSReferenceExpression(_type.name());
		CSConstructorInvocationExpression invocation = new CSConstructorInvocationExpression(typeRef);
		if (isEnclosingReferenceRequired()) {
			invocation.addArgument(new CSThisExpression());
		}

		addCapturedVariables(invocation);
		addBaseConstructorArguments(invocation);
		return invocation;
	}

	private void addCapturedVariables(CSConstructorInvocationExpression invocation) {
		for (IVariableBinding variable : _capturedVariables) {
			String mapped = mappedVariableName(variable);
			String name = mapped != null ? mapped : identifier(variable.getName());
			invocation.addArgument(new CSReferenceExpression(name));
		}
	}

	private void addBaseConstructorArguments(CSConstructorInvocationExpression invocation) {
		final List arguments = constructorArguments();
		if (arguments.isEmpty()) {
			return;
		}

		final IMethodBinding ctor = constructorBinding();
		final ITypeBinding[] ctorParameterTypes = ctor.getParameterTypes();

		final CSConstructorInvocationExpression cci;
		if (_constructor.chainedConstructorInvocation() != null)
			cci = _constructor.chainedConstructorInvocation();
		else {
			cci = new CSConstructorInvocationExpression(new CSBaseExpression());
			_constructor.chainedConstructorInvocation(cci);
		}

		for (int i=0; i<ctorParameterTypes.length; ++i) {
			ITypeBinding parameterType = ctorParameterTypes[i];
			Expression argument = (Expression)arguments.get(i);

			String parameterName = "baseArg" + (i + 1);
			_constructor.addParameter(parameterName, mappedTypeReference(parameterType));
			cci.addArgument(new CSReferenceExpression(parameterName));

			invocation.addArgument(_parent.mapExpression(argument));
		}
	}

	private List constructorArguments() {
		if (_node.getParent() instanceof EnumConstantDeclaration) {
			final EnumConstantDeclaration node = (EnumConstantDeclaration) _node.getParent();
			return node.arguments();
		} else {
			final ClassInstanceCreation node = (ClassInstanceCreation) _node.getParent();
			return node.arguments();
		}
	}

	private IMethodBinding constructorBinding() {
		if (_node.getParent() instanceof EnumConstantDeclaration) {
			final EnumConstantDeclaration node = (EnumConstantDeclaration) _node.getParent();
			return node.resolveConstructorBinding();
		} else {
			final ClassInstanceCreation node = (ClassInstanceCreation) _node.getParent();
			return node.resolveConstructorBinding();
		}
	}

	@Override
	public void run() {
		captureExternalLocalVariables();
		setUpAnonymousType();
		setUpConstructor();
		processAnonymousBody();
		flushFieldInitializers();
		int capturedVariableCount = flushCapturedVariables();
		flushInstanceInitializers(_type, capturedVariableCount);
	}

	private void flushFieldInitializers() {

		for (VariableDeclarationFragment field : _fieldInitializers) {
			addToConstructor(createFieldAssignment(fieldName(field), mapExpression(field.getInitializer())));
		}
	}

	@Override
	protected CSExpression mapFieldInitializer(VariableDeclarationFragment fragment) {
		if (Modifier.isStatic(fragment.resolveBinding().getModifiers()))
			return super.mapFieldInitializer(fragment);
		if (fragment.getInitializer() != null) {
			_fieldInitializers.add(fragment);
		}
		return null;
	}

	private void processAnonymousBody() {
		CSTypeDeclaration saved = _currentType;
		_currentType = _type;
		visit(_node.bodyDeclarations());
		_currentType = saved;
	}

	@Override
	public boolean visit(AnonymousClassDeclaration node) {
		CSAnonymousClassBuilder builder = new CSAnonymousClassBuilder(this, node);
		if (builder.isEnclosingReferenceRequired()) {
			requireEnclosingReference();
		}
		captureNeededVariables(builder);
		pushExpression(builder.createConstructorInvocation());
		_currentType.addMember(builder.type());
		return false;
	}

	private void captureNeededVariables(CSAnonymousClassBuilder builder) {

		IMethodBinding currentMethod = currentMethodDeclarationBinding();
		for (IVariableBinding variable : builder.capturedVariables()) {
			IMethodBinding method = variable.getDeclaringMethod();
			if (method != currentMethod) {
				_capturedVariables.add(variable);
			}
		}
	}

	private IMethodBinding currentMethodDeclarationBinding() {
		return _currentBodyDeclaration instanceof MethodDeclaration
				? ((MethodDeclaration)_currentBodyDeclaration).resolveBinding()
						: null;
	}

	private void addFieldParameter(String name, CSTypeReferenceExpression type) {
		addFieldParameter(CSharpCode.newPrivateReadonlyField(name, type));
	}

	private void addFieldParameter(CSField field) {
		_type.addMember(field);

		String parameterName = field.name();
		_constructor.addParameter(parameterName, field.type());
		addToConstructor(createFieldAssignment(field.name(), parameterName));
	}

	private void addToConstructor(final CSExpression expression) {
		_constructor.body().addStatement(expression);
	}

	private String anonymousBaseTypeName() {
		return mappedTypeName(anonymousBaseType());
	}

	public ITypeBinding anonymousBaseType() {
		ITypeBinding binding = nestedTypeBinding();
		return binding.getInterfaces().length > 0
				? binding.getInterfaces()[0]
						: binding.getSuperclass();
	}

	@Override
	protected ITypeBinding nestedTypeBinding() {
		return _node.resolveBinding();
	}

	private String anonymousInnerClassName() {
		String baseTypeName = anonymousBaseTypeName();
		return "_" + removeTypeArguments(simpleName(baseTypeName)) + "_" + lineNumber(_node);
	}

	private String simpleName(String typeName) {
		final int index = typeName.lastIndexOf('.');
		if (index < 0) return typeName;
		return typeName.substring(index + 1);
	}

	private String removeTypeArguments(String typeName) {
		final int index = typeName.indexOf('<');
		if (index < 0) return typeName;
		return typeName.substring(0, index);
	}

	private void setUpAnonymousType() {
		_type = classForAnonymousType();
	}

	private CSClass classForAnonymousType() {
		CSClass type = new CSClass(anonymousInnerClassName(), CSClassModifier.Sealed);
		type.visibility(CSVisibility.Private);
		type.anonymous(true);
		ITypeBinding bt = anonymousBaseType();
		CSTypeReferenceExpression tref = mappedTypeReference(bt);
		type.addBaseType(tref);
		for (ITypeBinding tp : bt.getTypeParameters())
			type.addTypeParameter(new CSTypeParameter(identifier(tp.getName())));
		if (isNonStaticNestedType(bt))
			requireEnclosingReference();
		return type;
	}

	private void setUpConstructor() {
		_constructor = new CSConstructor();
		_constructor.visibility(CSVisibility.Public);
		_type.addMember(_constructor);
	}

	private int flushCapturedVariables() {
		int capturedVariableCount = 0;
		if (isEnclosingReferenceRequired()) {
			capturedVariableCount++;
			CSField ef = createEnclosingField();
			addFieldParameter(ef);
			ITypeBinding bt = anonymousBaseType();
			if (bt != null && isNonStaticNestedType (bt)) {
				if (null == _constructor.chainedConstructorInvocation ())
					_constructor.chainedConstructorInvocation(new CSConstructorInvocationExpression(new CSBaseExpression()));

				final IMethodBinding ctor = constructorBinding();
				final ITypeBinding superclass = ctor.getDeclaringClass().getSuperclass();

				CSExpression enclosing = createEnclosingBaseCtorArgument(ef.name(), superclass);
				_constructor.chainedConstructorInvocation().addArgument(enclosing);
			}
		}

		for (IVariableBinding variable : _capturedVariables) {
			capturedVariableCount++;
			String mapped = mappedVariableName(variable);
			String name = mapped != null ? mapped : identifier(variable.getName());
			addFieldParameter(name, mappedTypeReference(variable.getType()));
		}

		return capturedVariableCount;
	}

	private void captureExternalLocalVariables() {
		_node.accept(new ASTVisitor() {

			IMethodBinding _currentMethodBinding;

			@Override
			public boolean visit(MethodDeclaration node) {
				IMethodBinding saved = _currentMethodBinding;
				_currentMethodBinding = node.resolveBinding();
				node.getBody().accept(this);
				_currentMethodBinding = saved;
				return false;
			}

			@Override
			public boolean visit(AnonymousClassDeclaration node) {
				return node == _node;
			}

			@Override
			public boolean visit(SimpleName node) {
				IBinding binding = node.resolveBinding();
				if (isExternalLocal(binding)) {
					_capturedVariables.add((IVariableBinding)binding);
				}
				return false;
			}

			boolean isExternalLocal(IBinding binding) {
				if (binding instanceof IVariableBinding) {
					IVariableBinding variable = (IVariableBinding)binding;
					if (!variable.isField()) {
						return variable.getDeclaringMethod() != _currentMethodBinding;
					}
				}
				return false;
			}
		});
	}

}
