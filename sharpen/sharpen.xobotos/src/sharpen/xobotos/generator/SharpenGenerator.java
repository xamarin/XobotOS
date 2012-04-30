package sharpen.xobotos.generator;

import static sharpen.core.framework.Environments.my;

import org.eclipse.jdt.core.dom.*;

import sharpen.core.CSharpBuilder;
import sharpen.core.Configuration.MemberMapping;
import sharpen.core.Configuration.TypeMapping;
import sharpen.core.Sharpen;
import sharpen.core.SharpenConversion;
import sharpen.core.csharp.ast.*;
import sharpen.core.framework.ASTResolver;
import sharpen.core.framework.ASTUtility;
import sharpen.core.framework.BindingUtils;
import sharpen.core.framework.CSharpDriver;
import sharpen.xobotos.StandardConfiguration.ConfigFlags;
import sharpen.xobotos.XobotConfiguration;
import sharpen.xobotos.api.APIDefinition;
import sharpen.xobotos.api.Visibility;
import sharpen.xobotos.api.bindings.*;
import sharpen.xobotos.api.bindings.MethodBinding;
import sharpen.xobotos.api.bindings.VariableBinding;
import sharpen.xobotos.api.interop.NativeHandle;
import sharpen.xobotos.api.interop.NativeMethodBuilder;
import sharpen.xobotos.api.interop.Signature;
import sharpen.xobotos.api.interop.Signature.Mode;
import sharpen.xobotos.api.interop.Signature.ParameterInfo;
import sharpen.xobotos.api.interop.marshal.MarshalAsClass;
import sharpen.xobotos.api.templates.*;
import sharpen.xobotos.output.IOutputProvider;
import sharpen.xobotos.output.OutputMode;
import sharpen.xobotos.output.OutputType;

import java.util.Stack;

public abstract class SharpenGenerator implements CSharpDriver {

	private final CompilationUnitBuilder _builder;
	private final Stack<ITypeBuilder> _typeStack = new Stack<ITypeBuilder>();
	private final Stack<IOutputProvider> _outputProviderStack = new Stack<IOutputProvider>();
	private AbstractMethodBuilder<?, ?> _currentMethod;

	public SharpenGenerator(CompilationUnitBuilder builder, IOutputProvider defaultOutput) {
		this._builder = builder;
		if (defaultOutput != null)
			_outputProviderStack.push(defaultOutput);
		_outputProviderStack.push(builder.getTemplate());
	}

	public boolean generate() {
		XobotConfiguration config = my(XobotConfiguration.class);
		ConfigFlags flags = _builder.getTemplate().getConfigFlags();
		if (flags != null)
			config = config.clone(flags);

		XobotSharpenConversion conversion = new XobotSharpenConversion(config);
		if (!conversion.convert())
			return false;

		if (getOutputType().removeDocs())
			_builder.getCompilationUnit().clearComments();

		return true;
	}

	protected abstract void registerType(ITypeBinding binding, CSTypeDeclaration type);

	protected abstract void registerMethod(IMethodBinding binding, CSMethod method);

	private class XobotSharpenConversion extends SharpenConversion {

		protected XobotSharpenConversion(XobotConfiguration config) {
			super(config);

			setSource(_builder.getPair().source);
			setDriver(SharpenGenerator.this);
			setASTResolver(my(ASTResolver.class));
		}

		public boolean convert() {
			final CompilationUnit ast = _builder.getPair().ast;
			final String path = ASTUtility.compilationUnitPath(ast);
			prepareForConversion(ast);
			try {
				convert(_builder.getPair(), _builder.getCompilationUnit());
				return true;
			} catch (Exception e) {
				Sharpen.Log(e, "Exception while converting %s", path);
				createProblemMarker(ast, null, "Exception: " + e.toString(), true);
				_foundErrors = true;
				return false;
			}
		}
	}

	private CSTypeDeclaration generateNakedStub(CSharpBuilder builder, TypeDeclaration node, CSTypeDeclaration type) {
		type.addAttribute(new CSAttribute("Sharpen.NakedStub"));
		type.visibility(CSVisibility.Public);
		type.removeDocs();

		if (node.isInterface())
			return type;

		for (final Object member : node.bodyDeclarations()) {
			if (!(member instanceof TypeDeclaration))
				continue;
			TypeDeclaration nested = (TypeDeclaration) member;
			if (Modifier.isPrivate(nested.getModifiers()))
				continue;

			CSTypeDeclaration inner = builder.mapTypeDeclaration(nested);
			CSTypeDeclaration innerType = generateNakedStub(builder, nested, inner);
			type.addMember(innerType);
		}

		return type;
	}

	protected ITypeContainer getCurrentContainer() {
		if (_typeStack.size() > 0)
			return _typeStack.peek();
		else
			return _builder.getTemplate();
	}

	private TypeTemplate findTypeTemplate(TypeDeclaration node) {
		final ITypeContainer container = getCurrentContainer();
		return container.findTypeTemplate(node);
	}

	private EnumTemplate findEnumTemplate(EnumDeclaration node) {
		final ITypeContainer container = getCurrentContainer();
		return container.findEnumTemplate(node);
	}

	private OutputType getOutputType() {
		for (int i = _outputProviderStack.size() - 1; i >= 0; i--) {
			IOutputProvider provider = _outputProviderStack.get(i);
			if (provider == null)
				continue;
			OutputType type = provider.getOutputType();
			if (type != null)
				return type;
		}
		return OutputType.NAKED_STUB;
	}

	@Override
	public CSTypeDeclaration processTypeDeclaration(CSharpBuilder csharpBuilder, CSTypeContainer parent,
			TypeDeclaration node, ITypeBuilderDelegate delegate) {
		final TypeTemplate template = findTypeTemplate(node);
		if (template == null)
			return null;

		final ITypeBinding typeBinding = node.resolveBinding();
		final AbstractTypeBinding binding = my(BindingManager.class).resolveBinding(typeBinding);
		if ((binding != null) && (binding.getMapping() != null))
			return null;

		try {
			_outputProviderStack.push(template);

			final OutputType output = getOutputType();
			final OutputMode mode;
			if (node.resolveBinding().isNested())
				mode = output.getModeForMember(node);
			else
				mode = output.getMode();

			CSTypeDeclaration type;

			if (mode == OutputMode.NOTHING)
				return null;
			else if (mode == OutputMode.NAKED_STUB) {
				type = delegate.create();
				generateNakedStub(csharpBuilder, node, type);
				parent.addType(type);
				return type;
			}

			TypeBuilder builder = new TypeBuilder(template, output, node);
			_typeStack.push(builder);

			type = builder.build(csharpBuilder, delegate);

			if (type != null) {
				registerType(typeBinding, type);
				parent.addType(type);
			}

			_typeStack.pop();
			return type;
		} finally {
			_outputProviderStack.pop();
		}
	}

	@Override
	public CSMethodBase processMethodDeclaration(CSharpBuilder csharpBuilder, CSTypeDeclaration parent,
			MethodDeclaration node, IMethodBuilderDelegate delegate) {
		final ITypeBuilder type = _typeStack.peek();
		final AbstractMethodTemplate<?> template = type.findMethodTemplate(node);
		if (template == null)
			return null;

		try {
			_outputProviderStack.push(template);

			final OutputType output = getOutputType();
			final OutputMode mode = output.getModeForMember(node);

			if (mode == OutputMode.NOTHING)
				return null;

			MethodBinding binding = template.getBinding();
			if ((binding != null) && (binding.getNativeHandle() != null))
				return null;

			AbstractMethodBuilder<?, ?> builder;
			if (node.isConstructor())
				builder = new ConstructorBuilder((ConstructorTemplate) template, output, node);
			else if (template instanceof DestructorTemplate)
				builder = new DestructorBuilder((DestructorTemplate) template, output, node);
			else
				builder = new MethodBuilder(type, (MethodTemplate) template, output, node,
						_builder.getNativeBuilder());
			type.registerMember(node, builder);

			_currentMethod = builder;
			CSMethodBase method = builder.build(csharpBuilder, delegate);
			_currentMethod = null;

			if (method != null) {
				delegate.fixup(parent, method);
				parent.addMember(method);
				if (method instanceof CSMethod)
					registerMethod(node.resolveBinding(), (CSMethod) method);
			}

			return method;
		} finally {
			_outputProviderStack.pop();
		}
	}

	@Override
	public CSField processFieldDeclaration(CSharpBuilder csharpBuilder, CSTypeDeclaration parent,
			FieldDeclaration node, VariableDeclarationFragment fragment, IFieldBuilderDelegate delegate) {
		final ITypeBuilder type = _typeStack.peek();
		final FieldTemplate template = type.getTypeTemplate().findFieldTemplate(node);

		if (template == null)
			return null;

		try {
			_outputProviderStack.push(template);

			final OutputType output = getOutputType();
			final OutputMode mode = output.getModeForMember(node);

			if (mode == OutputMode.NOTHING)
				return null;

			FieldBuilder builder = new FieldBuilder(template, output, node, fragment);
			type.registerMember(node, builder);

			CSField field = builder.build(csharpBuilder, delegate);
			if (field != null)
				parent.addMember(field);

			return field;
		} finally {
			_outputProviderStack.pop();
		}
	}

	@Override
	public CSAnonymousClass processAnonymousClass(CSharpBuilder csharpBuilder, CSTypeContainer parent,
			AnonymousClassDeclaration node, IAnonymousClassBuilderDelegate delegate) {
		final TypeTemplate typeTemplate = _typeStack.peek().getTypeTemplate();
		final AnonymousClassTemplate template = typeTemplate.findAnonymousClassTemplate(node);
		if (template == null)
			return null;

		try {
			_outputProviderStack.push(template);

			final OutputType output = getOutputType();
			final OutputMode mode = output.getModeForMember(node);

			if (mode == OutputMode.NOTHING)
				return null;

			AnonymousClassBuilder builder = new AnonymousClassBuilder(template, output, node);
			_typeStack.push(builder);

			CSAnonymousClass type = builder.build(csharpBuilder, delegate);

			if (type != null)
				parent.addType(type.type());

			_typeStack.pop();
			return type;
		} finally {
			_outputProviderStack.pop();
		}
	}

	@Override
	public CSProperty processPropertyDeclaration(CSharpBuilder csharpBuilder, CSTypeDeclaration parent,
			MethodDeclaration node, String name, CSProperty property, IPropertyBuilderDelegate delegate) {
		final ITypeBuilder type = _typeStack.peek();
		final PropertyTemplate template = type.getTypeTemplate().findPropertyTemplate(node);
		if (template == null)
			return null;

		try {
			_outputProviderStack.push(template);

			final OutputType output = getOutputType();
			final OutputMode mode = output.getModeForMember(node);

			if (mode == OutputMode.NOTHING)
				return null;

			PropertyBuilder builder = new PropertyBuilder(template, output, node);
			type.registerMember(node, builder);

			boolean existing = property != null;
			property = builder.build(csharpBuilder, delegate);
			if (!existing)
				parent.addMember(property);

			return property;
		} finally {
			_outputProviderStack.pop();
		}
	}

	@Override
	public CSEnum processEnumDeclaration(CSharpBuilder csharpBuilder, CSTypeContainer parent, EnumDeclaration node,
			IEnumBuilderDelegate delegate) {
		final EnumTemplate template = findEnumTemplate(node);
		if (template == null)
			return null;

		try {
			_outputProviderStack.push(template);

			final OutputType output = getOutputType();
			final OutputMode mode;
			if (node.resolveBinding().isNested())
				mode = output.getModeForMember(node);
			else
				mode = output.getMode();

			if (mode == OutputMode.NOTHING)
				return null;

			EnumBuilder builder = new EnumBuilder(template, output, node);

			CSEnum theEnum = builder.build(csharpBuilder, delegate);
			if (theEnum != null)
				parent.addType(theEnum);

			return theEnum;
		} finally {
			_outputProviderStack.pop();
		}
	}

	@Override
	public CSTypeDeclaration processExtractedEnumDeclaration(CSharpBuilder csharpBuilder, CSTypeContainer parent,
			EnumDeclaration node, ITypeBuilderDelegate delegate) {
		final EnumTemplate template = findEnumTemplate(node);
		if (template == null)
			return null;

		final ITypeBinding typeBinding = node.resolveBinding();
		final AbstractTypeBinding binding = my(BindingManager.class).resolveBinding(typeBinding);
		if ((binding != null) && (binding.getMapping() != null))
			return null;

		try {
			_outputProviderStack.push(template);

			final OutputType output = getOutputType();
			final OutputMode mode;
			if (node.resolveBinding().isNested())
				mode = output.getModeForMember(node);
			else
				mode = output.getMode();

			CSTypeDeclaration type;

			if ((mode == OutputMode.NOTHING) || (mode == OutputMode.NAKED_STUB))
				return null;

			ExtractedEnumBuilder builder = new ExtractedEnumBuilder(template, output, node);
			_typeStack.push(builder);

			type = builder.build(csharpBuilder, delegate);

			if (type != null)
				parent.addType(type);

			_typeStack.pop();
			return type;
		} finally {
			_outputProviderStack.pop();
		}
	}

	@Override
	public String mappedVariableName(IVariableBinding binding) {
		VariableBinding variable = my(BindingManager.class).resolveBinding(binding);
		if (variable == null)
			return null;

		return variable.rename();
	}

	@Override
	public CSExpression mappedNullPointer(IVariableBinding binding) {
		if (binding == null)
			return null;

		VariableBinding variable = my(BindingManager.class).resolveBinding(binding);
		if (variable == null)
			return null;

		if (variable.getNativeHandle() != null)
			return new CSNullLiteralExpression();

		if (variable.isPointer())
			return new CSReferenceExpression("System.IntPtr.Zero");

		return null;
	}

	private VariableBinding lookupVariableBinding(Expression expr) {
		if (expr instanceof Name) {
			IBinding binding = ((Name) expr).resolveBinding();
			if (binding instanceof IVariableBinding)
				return my(BindingManager.class).resolveBinding((IVariableBinding) binding);
			return null;
		}

		if (expr instanceof QualifiedName) {
			IBinding binding = ((QualifiedName) expr).resolveBinding();
			if (binding instanceof IVariableBinding)
				return my(BindingManager.class).resolveBinding((IVariableBinding) binding);
			return null;
		}

		return null;
	}

	@Override
	public CSExpression mappedNullPointer(Expression expr) {
		VariableBinding variable = lookupVariableBinding(expr);
		if (variable != null) {
			if (variable.getNativeHandle() != null)
				return new CSNullLiteralExpression();

			if (variable.isPointer())
				return new CSReferenceExpression("System.IntPtr.Zero");

			return null;
		}

		if (expr instanceof MethodInvocation) {
			IMethodBinding method = ((MethodInvocation) expr).resolveMethodBinding();
			MethodBinding binding = my(BindingManager.class).resolveBinding(method);
			if (binding == null)
				return null;

			if (binding.getNativeHandle() != null)
				return new CSNullLiteralExpression();
		}

		return null;
	}

	@Override
	public CSTypeReferenceExpression mappedVariableType(IVariableBinding binding) {
		if (binding == null)
			return null;

		VariableBinding variable = my(BindingManager.class).resolveBinding(binding);
		if (variable == null)
			return null;

		NativeHandle nh = variable.getNativeHandle();
		if (nh != null)
			return nh.getManagedType();

		if (variable.isPointer())
			return new CSTypeReference("System.IntPtr");

		if (variable.modifyType() != null)
			return variable.modifyType().getExpression();

		return null;
	}

	@Override
	public MemberMapping mappedMethod(IMethodBinding binding) {
		MethodBinding method = my(BindingManager.class).resolveBinding(binding);
		if (method != null)
			return method.getMapping();

		return null;
	}

	@Override
	public CSExpression mappedMethodInvocation(CSharpBuilder builder, MethodInvocation node) {
		final IMethodBinding binding = node.resolveMethodBinding();
		final ITypeBinding declaringType = binding.getDeclaringClass();
		final AbstractTypeBinding typeBinding = my(BindingManager.class).resolveBinding(declaringType);
		final MethodBinding methodBinding = my(BindingManager.class).resolveBinding(binding);

		if (typeBinding instanceof EnumBinding) {
			EnumBinding enumBinding = (EnumBinding) typeBinding;
			String ctorMethod = enumBinding.getConstructorMethod();
			if ((ctorMethod != null) && node.getName().toString().equals(ctorMethod)) {
				return builder.mapExpression(declaringType, (Expression) node.arguments().get(0));
			}
		}

		if (methodBinding != null) {
			NativeHandle nh = methodBinding.getNativeHandle();
			if (nh != null) {
				CSExpression expr = builder.mapExpression(declaringType, node.getExpression());
				String member = nh.getProperty() != null ? nh.getProperty() : nh.getField();
				return new CSMemberReferenceExpression(expr, member);
			}
		}

		if (_currentMethod != null)
			_currentMethod.checkInvocationTarget(binding);

		return null;
	}

	@Override
	public CSExpression mappedMethodInvocationArgument(CSharpBuilder builder, MethodInvocation node, int index,
			Expression expr) {
		final IMethodBinding binding = node.resolveMethodBinding();
		final NativeMethodBuilder nativeBuilder = my(BindingManager.class).resolveNativeBinding(binding);

		final ITypeBinding[] actualTypes = binding.getParameterTypes();
		final CSExpression mappedExpr = builder.mapExpression(actualTypes[index], expr);

		if (nativeBuilder != null) {
			final Signature signature = nativeBuilder.getNativeMethod().getSignature();
			final ParameterInfo info = signature.getParameterInfo(index);
			if ((info == null) || (info.mode == Mode.REMOVE))
				return null;

			if ((info.marshal == null) || !(info.marshal instanceof MarshalAsClass.Entry))
				return mappedExpr;

			if (CSharpBuilder.isZeroLiteral(expr)) {
				MarshalAsClass.Entry marshal = (MarshalAsClass.Entry) info.marshal;
				if (marshal.getNativeHandle() != null)
					return new CSNullLiteralExpression();
				else
					return new CSReferenceExpression("System.IntPtr.Zero");
			}
		}

		return mappedExpr;
	}

	@Override
	public CSExpression mappedEnumAccess(CSharpBuilder builder, Expression expr, IVariableBinding binding) {
		final ITypeBinding declaringType = binding.getDeclaringClass();
		final AbstractTypeBinding typeBinding = my(BindingManager.class).resolveBinding(declaringType);

		if ((typeBinding == null) || !(typeBinding instanceof EnumBinding))
			return null;

		EnumBinding enumBinding = (EnumBinding) typeBinding;
		if ((enumBinding.getValueField() != null) && (binding.getName().equals(enumBinding.getValueField())))
			return builder.mapExpression(binding.getType(), expr);

		if (!Modifier.isStatic(binding.getModifiers()))
			return null;

		CSTypeReferenceExpression qualifier = new CSTypeReference(BindingUtils.qualifiedName(declaringType));
		return new CSMemberReferenceExpression(qualifier, binding.getName());
	}

	@Override
	public CSExpression castIfNeeded(CSharpBuilder builder, ITypeBinding expectedType, ITypeBinding actualType,
			CSExpression expression) {
		final AbstractTypeBinding expectedBinding = my(BindingManager.class).resolveBinding(expectedType);
		final AbstractTypeBinding actualBinding = my(BindingManager.class).resolveBinding(actualType);

		if ((actualBinding instanceof EnumBinding) && expectedType.isPrimitive()) {
			final EnumBinding enumBinding = (EnumBinding) actualBinding;
			final String baseType = enumBinding.getBaseType();
			if ((baseType != null) && expectedType.getName().equals(baseType))
				return new CSCastExpression(new CSTypeReference(baseType), expression);
		}

		if ((expectedBinding instanceof EnumBinding) && actualType.isPrimitive()) {
			final EnumBinding enumBinding = (EnumBinding) expectedBinding;
			final String baseType = enumBinding.getBaseType();
			if ((baseType != null) && actualType.getName().equals(baseType)) {
				CSTypeReferenceExpression tr = builder.mappedTypeReference(expectedType);
				return new CSCastExpression(tr, expression);
			}
		}

		return null;
	}

	@Override
	public String mappedTypeName(CSharpBuilder builder, ITypeBinding binding) {
		final AbstractTypeBinding type = my(BindingManager.class).resolveBinding(binding);

		if (type != null) {
			TypeMapping mapping = type.getMapping();
			if (mapping != null)
				return mapping.name;
		}

		return null;
	}

	@Override
	public CSTypeReferenceExpression mappedTypeReference(CSharpBuilder builder, ITypeBinding binding) {
		final AbstractTypeBinding type = my(BindingManager.class).resolveBinding(binding);

		if (type instanceof EnumBinding) {
			final EnumBinding enumBinding = (EnumBinding) type;
			if (enumBinding.isNullable()) {
				CSTypeReference tr = new CSTypeReference(BindingUtils.qualifiedName(binding));
				return new CSNullableTypeReference(tr);
			}
		}

		return null;
	}

	private CSVisibility mapVisibility(MemberBinding binding) {
		Visibility visibility = binding.getVisibility();
		if (visibility != null)
			return APIDefinition.mapVisibility(visibility);

		return null;
	}

	@Override
	public CSVisibility mapVisibility(ITypeBinding binding) {
		final AbstractTypeBinding typeBinding = my(BindingManager.class).resolveBinding(binding);
		if (typeBinding == null)
			return null;

		return mapVisibility(typeBinding);
	}

	@Override
	public CSVisibility mapVisibility(IMethodBinding binding) {
		final MethodBinding methodBinding = my(BindingManager.class).resolveBinding(binding);
		if (methodBinding == null)
			return null;

		return mapVisibility(methodBinding);
	}

	@Override
	public CSVisibility mapVisibility(IVariableBinding binding) {
		final VariableBinding variableBinding = my(BindingManager.class).resolveBinding(binding);
		if (variableBinding == null)
			return null;

		return mapVisibility(variableBinding);
	}

}
