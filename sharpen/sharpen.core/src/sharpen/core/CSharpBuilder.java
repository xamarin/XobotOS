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

import static sharpen.core.framework.Environments.my;
import static sharpen.core.framework.StaticImports.isStaticImport;
import static sharpen.core.framework.StaticImports.staticImportMethodBinding;

import org.eclipse.jdt.core.ICompilationUnit;
import org.eclipse.jdt.core.JavaModelException;
import org.eclipse.jdt.core.dom.*;

import sharpen.core.Configuration.MappingFlags;
import sharpen.core.Configuration.MemberMapping;
import sharpen.core.SharpenProblem.ProblemKind;
import sharpen.core.csharp.ast.*;
import sharpen.core.framework.*;
import sharpen.core.framework.CSharpDriver.IAnonymousClassBuilderDelegate;
import sharpen.core.framework.CSharpDriver.IEnumBuilderDelegate;
import sharpen.core.framework.CSharpDriver.IFieldBuilderDelegate;
import sharpen.core.framework.CSharpDriver.IMemberFilter;
import sharpen.core.framework.CSharpDriver.IMethodBuilderDelegate;
import sharpen.core.framework.CSharpDriver.IPropertyBuilderDelegate;
import sharpen.core.framework.CSharpDriver.ITypeBuilderDelegate;
import sharpen.core.framework.IBindingManager.IExtractedEnumInfo;
import sharpen.core.framework.IBindingManager.ITypeInfo;
import sharpen.core.framework.IBindingManager.IVariableInfo;

import java.util.*;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class CSharpBuilder extends ASTVisitor {

	private static final String JAVA_LANG_VOID_TYPE = "java.lang.Void.TYPE";

	private static final String JAVA_LANG_BOOLEAN_TYPE = "java.lang.Boolean.TYPE";

	private static final String JAVA_LANG_CHARACTER_TYPE = "java.lang.Character.TYPE";

	private static final String JAVA_LANG_INTEGER_TYPE = "java.lang.Integer.TYPE";

	private static final String JAVA_LANG_LONG_TYPE = "java.lang.Long.TYPE";

	private static final String JAVA_LANG_BYTE_TYPE = "java.lang.Byte.TYPE";

	private static final String JAVA_LANG_SHORT_TYPE = "java.lang.Short.TYPE";

	private static final String JAVA_LANG_FLOAT_TYPE = "java.lang.Float.TYPE";

	private static final String JAVA_LANG_DOUBLE_TYPE = "java.lang.Double.TYPE";

	private static final CSTypeReference OBJECT_TYPE_REFERENCE = new CSTypeReference("object");

	private final CSCompilationUnit _compilationUnit;

	protected CSTypeDeclaration _currentType;

	private CSBlock _currentBlock;

	private CSExpression _currentExpression;

	private CSMethodBase _currentMethod;

	protected BodyDeclaration _currentBodyDeclaration;

	protected TypeDeclaration _currentTypeDeclaration;

	private CSLabelStatement _currentContinueLabel;

	private static final Pattern SUMMARY_CLOSURE_PATTERN = Pattern.compile("\\.(\\s|$)");

	private static final Pattern HTML_ANCHOR_PATTERN = Pattern.compile("<([aA])\\s+.+>");

	protected CompilationUnitPair _pair;

	protected CompilationUnit _ast;

	protected Configuration _configuration;

	private ASTResolver _resolver;

	private IVariableBinding _currentExceptionVariable;

	private final DynamicVariable<Boolean> _ignoreExtends = new DynamicVariable<Boolean>(Boolean.FALSE);

	private List<Initializer> _instanceInitializers = new ArrayList<Initializer>();

	private HashMap<ITypeBinding, String> _currentWildcardParams;

	private Stack<ITypeBinding> _currentExpectedType = new Stack<ITypeBinding>();

	private final ITypeBinding _objectType;
	private final ITypeBinding _classType;

	protected NamingStrategy namingStrategy() {
		return _configuration.getNamingStrategy();
	}

	protected WarningHandler warningHandler() {
		return _configuration.getWarningHandler();
	}

	public CSharpBuilder() {
		_configuration = my(Configuration.class);
		_pair = my(CompilationUnitPair.class);
		_ast = my(CompilationUnit.class);
		_resolver = my(ASTResolver.class);
		_compilationUnit = my(CSCompilationUnit.class);
		_compilationUnit.addUsing(new CSUsing("Sharpen"));

		_objectType = my(IBindingManager.class).getObjectType();
		_classType = my(IBindingManager.class).getClassType();
	}

	protected CSharpBuilder(CSharpBuilder other) {
		_configuration = other._configuration;
		_pair = other._pair;
		_ast = other._ast;
		_resolver = other._resolver;
		_compilationUnit = other._compilationUnit;

		_currentType = other._currentType;
		_currentBlock = other._currentBlock;
		_currentExpression = other._currentExpression;
		_currentMethod = other._currentMethod;
		_currentBodyDeclaration = other._currentBodyDeclaration;

		_objectType = other._objectType;
		_classType = other._classType;
	}

	public void setSourceCompilationUnit(CompilationUnit ast) {
		_ast = ast;
	}

	public void run() {
		if (null == warningHandler() || null == _ast) {
			throw new IllegalStateException();
		}
		_ast.accept(this);
		visit(_ast.getCommentList());
	}

	@Override
	public boolean visit(LineComment node) {
		_compilationUnit.addComment(new CSLineComment(node.getStartPosition(), getText(node.getStartPosition(),
				node
				.getLength())));
		return false;
	}

	private String getText(int startPosition, int length) {
		try {
			return ((ICompilationUnit) _ast.getJavaElement()).getBuffer().getText(startPosition, length);
		} catch (JavaModelException e) {
			throw new RuntimeException(e);
		}
	}

	public CSCompilationUnit compilationUnit() {
		return _compilationUnit;
	}

	@Override
	public boolean visit(ImportDeclaration node) {
		return false;
	}

	@Override
	public boolean visit(final EnumDeclaration node) {
		if (SharpenAnnotations.hasIgnoreAnnotation(node))
			return false;

		final ITypeBinding typeBinding = node.resolveBinding();
		final CSTypeContainer current = _currentType != null ? _currentType : _compilationUnit;

		IExtractedEnumInfo info = my(IBindingManager.class).getExtractedEnumInfo(typeBinding);
		if (info != null) {
			processExtractedEnum(node, info);
			return false;
		}

		my(CSharpDriver.class).processEnumDeclaration(this, current, node, new IEnumBuilderDelegate() {

			public CSEnum create() {
				return new CSEnum(typeName(node));
			}

			public void map(final CSEnum theEnum) {
				theEnum.visibility(mapVisibility(typeBinding));
				node.accept(new ASTVisitor() {
					@Override
					public boolean visit(EnumConstantDeclaration node) {
						final String name = identifier(node.getName());
						CSEnumValue value;
						if (node.arguments().size() == 0)
							value = new CSEnumValue(name);
						else if (node.arguments().size() != 1) {
							addProblem(node, ProblemKind.PARSING_ERROR,
									"Enum value can not have more than one initializer.");
							return false;
						} else {
							Object arg = node.arguments().get(0);
							if (!(arg instanceof NumberLiteral)) {
								addProblem(node, ProblemKind.PARSING_ERROR,
										"Invalid enum initializer.");
								return false;
							}
							NumberLiteral literal = (NumberLiteral) arg;
							value = new CSEnumValue(name, mapExpression(literal));
						}
						mapJavadoc(node, value);
						theEnum.addValue(value);
						return false;
					}

					@Override
					public boolean visit(MethodDeclaration node) {
						if (node.isConstructor()) {
							int mods = node.getModifiers();
							if ((mods == 0) || Modifier.isPrivate(mods))
								return false;
						}
						addProblem(node, ProblemKind.WARNING,
								"Enum can contain only fields and a private constructor.");
						return false;
					}
				});
			}

			public void document(CSEnum theEnum) {
				mapJavadoc(node, theEnum);
			}

			public void fixup(CSEnum member) {

			}
		});

		return false;
	}

	private CSTypeDeclaration processExtractedEnum(final EnumDeclaration node, final IExtractedEnumInfo info) {
		final ITypeBinding typeBinding = node.resolveBinding();
		final CSTypeContainer current = getCurrentType(typeBinding);

		final String typeName = typeName(node);
		final String valueName = info.valueField();

		return my(CSharpDriver.class).processExtractedEnumDeclaration(this, current, node,
				new ITypeBuilderDelegate() {

			CSConstructor _ctor;
			CSField _valueField;
			int _nextId;

			public CSTypeDeclaration create() {
				CSClass klass = new CSClass(typeName, CSClassModifier.None);
				klass.startPosition(node.getStartPosition());
				klass.sourceLength(node.getLength());
				return klass;
			}

			public void map(CSTypeDeclaration klass) {
				CSTypeReference intRef = new CSTypeReference("int");
				_valueField = new CSField(valueName, intRef, CSVisibility.Public);
				_valueField.addModifier(CSFieldModifier.Readonly);
				klass.addMember(_valueField);

				_ctor = new CSConstructor();
				_ctor.visibility(CSVisibility.Protected);
				_ctor.addParameter(valueName, intRef);

				CSExpression paramRef = new CSReferenceExpression(valueName);
				CSExpression valueRef = new CSMemberReferenceExpression(
						new CSThisExpression(), valueName);
				CSExpression init = new CSInfixExpression("=", valueRef, paramRef);
				_ctor.body().addStatement(init);
				klass.addMember(_ctor);

				klass.visibility(mapVisibility(typeBinding));
			}

			public void mapMembers(CSTypeDeclaration klass, final IMemberFilter filter) {
				List<EnumConstantDeclaration> constants = node.enumConstants();
				for (final EnumConstantDeclaration ec : constants) {
					int id = ++_nextId;
					CSTypeReference typeRef = new CSTypeReference(typeName);
					CSharpBuilder.this.mapEnumConstant(klass, id, typeRef, ec);
				}
				CSharpBuilder.this.mapMembers(node, klass, new IMemberFilter() {
					public boolean includeMember(ASTNode member) {
						if ((filter != null) && !filter.includeMember(member))
							return false;
						return true;
					}
				});
			}

			public void document(CSTypeDeclaration klass) {
				CSharpBuilder.this.mapDocumentation(node, klass);
			}

			public void fixup(CSTypeDeclaration type) {
				CSClass klass = (CSClass) type;
				for (CSMember member : klass.members()) {
					if (member instanceof CSMethod) {
						CSMethod method = (CSMethod) member;
						if (method.isAbstract())
							klass.modifier(CSClassModifier.Abstract);
					}
				}
			}
		});
	}

	private void mapEnumConstant(CSTypeDeclaration klass, int id, CSTypeReference typeRef,
			EnumConstantDeclaration node) {
		final String name = identifier(node.getName());
		final CSReferenceExpression idRef = new CSReferenceExpression(name + "_ID");

		CSExpression initializer;

		AnonymousClassDeclaration anon = node.getAnonymousClassDeclaration();
		if (anon != null) {
			CSAnonymousClassBuilder anonBuilder = mapAnonymousClass(anon);
			if (anonBuilder == null)
				initializer = new CSNullLiteralExpression();
			else {
				initializer = anonBuilder.createConstructorInvocation();
				CSConstructor ctor = anonBuilder.constructor();
				CSConstructorInvocationExpression cie;
				if (ctor.chainedConstructorInvocation() == null) {
					cie = new CSConstructorInvocationExpression(new CSBaseExpression());
					cie.addArgument(idRef);
					ctor.chainedConstructorInvocation(cie);
				} else {
					CSConstructorInvocationExpression oldCie = ctor.chainedConstructorInvocation();
					cie = new CSConstructorInvocationExpression(new CSBaseExpression());
					ctor.chainedConstructorInvocation(cie);
					cie.addArgument(idRef);
					for (CSExpression arg : oldCie.arguments())
						cie.addArgument(arg);
				}
			}
		} else {
			CSConstructorInvocationExpression cie = new CSConstructorInvocationExpression(typeRef);
			cie.addArgument(idRef);
			for (Object o : node.arguments()) {
				Expression expr = (Expression) o;
				cie.addArgument(mapExpression(expr));
			}
			initializer = cie;
		}

		CSField field = new CSField(name, typeRef, CSVisibility.Public);
		field.initializer(initializer);
		field.addModifier(CSFieldModifier.Static);
		field.addModifier(CSFieldModifier.Readonly);
		klass.addMember(field);

		CSTypeReference intRef = new CSTypeReference("int");
		CSField idField = new CSField(name + "_ID", intRef, CSVisibility.Public);
		idField.initializer(new CSNumberLiteralExpression(Integer.toString(id)));
		idField.addModifier(CSFieldModifier.Const);
		klass.addMember(idField);
	}

	@Override
	public boolean visit(AnnotationTypeDeclaration node) {
		// TODO: SHA-51
		return false;
	}

	@Override
	public boolean visit(MarkerAnnotation node) {
		// TODO: SHA-51
		return false;
	}

	@Override
	public boolean visit(NormalAnnotation node) {
		// TODO: SHA-51
		return false;
	}

	@Override
	public boolean visit(final LabeledStatement node) {
		String identifier = node.getLabel().getIdentifier();
		_currentContinueLabel = new CSLabelStatement(continueLabel(identifier));
		try {
			node.getBody().accept(this);
		} finally {
			_currentContinueLabel = null;
		}
		addStatement(new CSLabelStatement(breakLabel(identifier)));
		return false;
	}

	private String breakLabel(String identifier) {
		return identifier + "_break";
	}

	private String continueLabel(String identifier) {
		return identifier + "_continue";
	}

	@Override
	public boolean visit(SuperFieldAccess node) {
		IVariableBinding binding = node.resolveFieldBinding();
		String name = mappedFieldName(binding);
		if (name == null)
			name = identifier(node.getName());
		pushExpression(new CSMemberReferenceExpression(new CSBaseExpression(), name));
		return false;
	}

	@Override
	public boolean visit(MemberRef node) {
		notImplemented(node);
		return false;
	}

	@Override
	public boolean visit(WildcardType node) {
		notImplemented(node);
		return false;
	}

	private void notImplemented(ASTNode node) {
		addProblem(node, ProblemKind.PARSING_ERROR, "Not implemented: %s", node.getClass().getSimpleName());
	}

	@Override
	public boolean visit(PackageDeclaration node) {
		String namespace = node.getName().toString();
		_compilationUnit.namespace(mappedNamespace(namespace));

		processDisableTags(node, _compilationUnit);
		return false;
	}

	@Override
	public boolean visit(AnonymousClassDeclaration node) {
		CSAnonymousClassBuilder builder = mapAnonymousClass(node);
		if (builder == null)
			pushExpression(new CSNullLiteralExpression());
		else
			pushExpression(builder.createConstructorInvocation());
		return false;
	}

	private CSAnonymousClassBuilder mapAnonymousClass(final AnonymousClassDeclaration node) {
		final ByRef<CSAnonymousClassBuilder> builder = new ByRef<CSAnonymousClassBuilder>(null);
		my(CSharpDriver.class).processAnonymousClass(this, _currentType, node,
				new IAnonymousClassBuilderDelegate() {

			public CSAnonymousClass create() {
				builder.value = new CSAnonymousClassBuilder(CSharpBuilder.this, node);
				return new CSAnonymousClass(builder.value.type());
			}

			public void map(CSAnonymousClass member) {

			}

			public void document(CSAnonymousClass member) {

			}

			public void fixup(CSAnonymousClass member) {

			}

		});
		return builder.value;
	}

	@Override
	public boolean visit(final TypeDeclaration node) {

		if (processIgnoredType(node)) {
			return false;
		}

		try {
			my(NameScope.class).enterTypeDeclaration(node);

			final ITypeBinding binding = node.resolveBinding();
			if (!binding.isNested()) {
				processTypeDeclaration(node);
				return false;
			}

			if (isNonStaticNestedType(binding))
				NonStaticNestedClassBuilder.build(CSharpBuilder.this, node);
			else
				StaticNestedClassBuilder.build(CSharpBuilder.this, node);
		} finally {
			my(NameScope.class).leaveTypeDeclaration(node);
		}

		return false;
	}

	protected boolean isPrivate(MethodDeclaration node) {
		return Modifier.isPrivate(node.getModifiers());
	}

	private boolean processIgnoredType(TypeDeclaration node) {
		if (!hasIgnoreOrRemoveAnnotation(node)) {
			return false;
		}
		if (isMainType(node)) {
			compilationUnit().ignore(true);
		}
		return true;
	}

	private boolean hasIgnoreOrRemoveAnnotation(TypeDeclaration node) {
		return SharpenAnnotations.hasIgnoreAnnotation(node) || hasRemoveAnnotation(node);
	}

	protected CSTypeDeclaration processTypeDeclaration(final TypeDeclaration node) {
		final ITypeBinding typeBinding = node.resolveBinding();

		CSTypeDeclaration type;

		TypeDeclaration oldCurrentTypeDeclaration = _currentTypeDeclaration;
		_currentTypeDeclaration = node;

		if (node.isInterface() && !isValidCSInterface(typeBinding)) {
			type = processExtractedInterface(node);
		} else if (mustExtractRawType(typeBinding)) {
			type = processExtractedRawType(node);
		} else {
			type = processOrdinaryTypeDeclaration(node);
		}

		_currentTypeDeclaration = oldCurrentTypeDeclaration;

		return type;
	}

	private CSTypeDeclaration processOrdinaryTypeDeclaration(final TypeDeclaration node) {
		final ITypeBinding typeBinding = node.resolveBinding();
		final CSTypeContainer current = getCurrentType(typeBinding);

		CSTypeDeclaration type = my(CSharpDriver.class).processTypeDeclaration(this, current, node,
				new CSharpDriver.ITypeBuilderDelegate() {

			public CSTypeDeclaration create() {
				return mapTypeDeclaration(node);
			}

			public void map(CSTypeDeclaration type) {

				processDisabledType(node, isMainType(node) ? _compilationUnit : type);

				if (_configuration.shouldMakePartial(BindingUtils
						.qualifiedName(typeBinding)))
					type.partial(true);

				mapSuperTypes(node, type);

				type.visibility(mapVisibility(typeBinding));
			}

			public void mapMembers(CSTypeDeclaration type, IMemberFilter filter) {
				CSharpBuilder.this.mapMembers(node, type, filter);
			}

			public void document(CSTypeDeclaration type) {
				CSharpBuilder.this.mapDocumentation(node, type);
				processConversionJavadocTags(node, type);
			}

			public void fixup(CSTypeDeclaration type) {
				adjustMemberVisibility(node, type);

				autoImplementCloneable(node, type);

				moveInitializersDependingOnThisReferenceToConstructor(type);

				if (_configuration.junitConversion() && hasTests(type))
					type.addAttribute(new CSAttribute("NUnit.Framework.TestFixture"));

				type.cleanupStaticConstructor();
			}
		});

		return type;
	}

	private void processDisabledType(TypeDeclaration node, CSNode type) {
		final String expression = _configuration.conditionalCompilationExpressionFor(packageNameFor(node));
		if (null != expression) {
			compilationUnit().addEnclosingIfDef(expression);
		}

		processDisableTags(node, type);
	}

	private String packageNameFor(TypeDeclaration node) {
		ITypeBinding type = node.resolveBinding();
		return type.getPackage().getName();
	}

	protected void flushInstanceInitializers(CSTypeDeclaration type, int startStatementIndex) {

		if (_instanceInitializers.isEmpty()) {
			return;
		}

		ensureConstructorsFor(type);

		int initializerIndex = startStatementIndex;
		for (Initializer node : _instanceInitializers) {
			final CSBlock body = mapInitializer(node);

			for (CSConstructor ctor : type.constructors()) {
				if (ctor.isStatic() || hasChainedThisInvocation(ctor)) {
					continue;
				}
				ctor.body().addStatement(initializerIndex, body);
			}

			++initializerIndex;
		}

		_instanceInitializers.clear();
	}

	private CSBlock mapInitializer(Initializer node) {
		final CSConstructor template = new CSConstructor();
		visitBodyDeclarationBlock(node, node.getBody(), template);
		final CSBlock body = template.body();
		return body;
	}

	private boolean hasChainedThisInvocation(CSConstructor ctor) {
		final CSConstructorInvocationExpression chained = ctor.chainedConstructorInvocation();
		return chained != null && chained.expression() instanceof CSThisExpression;
	}

	private void moveInitializersDependingOnThisReferenceToConstructor(CSTypeDeclaration type) {

		final HashSet<String> memberNames = memberNameSetFor(type);

		int index = 0;
		for (CSMember member : copy(type.members())) {
			if (!(member instanceof CSField))
				continue;

			final CSField field = (CSField) member;
			if (!isDependentOnThisOrMember(field, memberNames))
				continue;

			moveFieldInitializerToConstructors(field, type, index++);
		}
	}

	private HashSet<String> memberNameSetFor(CSTypeDeclaration type) {
		final HashSet<String> members = new HashSet<String>();
		for (CSMember member : type.members()) {
			if (member instanceof CSType)
				continue;
			if (isStatic(member))
				continue;
			members.add(member.name());
		}
		return members;
	}

	private boolean isStatic(CSMember member) {
		if (member instanceof CSField)
			return isStatic((CSField) member);
		if (member instanceof CSMethod)
			return isStatic((CSMethod) member);
		return false;
	}

	private boolean isStatic(CSMethod method) {
		return method.modifier() == CSMethodModifier.Static;
	}

	private boolean isStatic(CSField member) {
		final Set<CSFieldModifier> fieldModifiers = member.modifiers();
		return fieldModifiers.contains(CSFieldModifier.Static)
				|| fieldModifiers.contains(CSFieldModifier.Const);
	}

	private CSMember[] copy(final List<CSMember> list) {
		return list.toArray(new CSMember[0]);
	}

	private boolean isDependentOnThisOrMember(CSField field, final Set<String> fields) {
		if (null == field.initializer())
			return false;

		if (this instanceof AbstractNestedClassBuilder) {
			if (!field.isConst() && !field.isStatic())
				return true;
		}

		final ByRef<Boolean> foundThisReference = new ByRef<Boolean>(false);
		field.initializer().accept(new CSExpressionVisitor() {
			@Override
			public void visit(CSThisExpression node) {
				foundThisReference.value = true;
			}

			@Override
			public void visit(CSReferenceExpression node) {
				if (fields.contains(node.name())) {
					foundThisReference.value = true;
				}
			}
		});
		return foundThisReference.value;
	}

	private void moveFieldInitializerToConstructors(CSField field, CSTypeDeclaration type, int index) {
		final CSExpression initializer = field.initializer();
		if (field.isStatic()) {
			CSConstructor ctor = type.ensureStaticConstructor();
			if (!ctor.isStub())
				ctor.body().addStatement(index, newAssignment(field, initializer));
		} else {
			for (CSConstructor ctor : ensureConstructorsFor(type)) {
				if (ctor.isStatic() || ctor.isStub())
					continue;
				ctor.body().addStatement(index, newAssignment(field, initializer));
			}
		}
		field.initializer(null);
	}

	private CSExpression newAssignment(CSField field, final CSExpression initializer) {
		return CSharpCode.newAssignment(CSharpCode.newReference(field), initializer);
	}

	private Iterable<CSConstructor> ensureConstructorsFor(CSTypeDeclaration type) {
		final List<CSConstructor> ctors = type.constructors();
		if (!ctors.isEmpty())
			return ctors;

		return Collections.singletonList(addDefaultConstructor(type));
	}

	private CSConstructor addDefaultConstructor(CSTypeDeclaration type) {
		final CSConstructor ctor = CSharpCode.newPublicConstructor();
		type.addMember(ctor);
		return ctor;
	}

	private void autoImplementCloneable(TypeDeclaration node, CSTypeDeclaration type) {

		if (!implementsCloneable(type) || node.isInterface()) {
			return;
		}

		final String name;
		if (type.getMember("Clone") instanceof CSMethod)
			name = "Clone";
		else
			name = "MemberwiseClone";

		CSMethod clone = new CSMethod("System.ICloneable.Clone");
		clone.returnType(OBJECT_TYPE_REFERENCE);
		clone.body().addStatement(
				new CSReturnStatement(-1,
						new CSMethodInvocationExpression(new CSReferenceExpression(name))));

		type.addMember(clone);
	}

	private boolean implementsCloneable(CSTypeDeclaration node) {
		for (CSTypeReferenceExpression typeRef : node.baseTypes()) {
			if (typeRef.getTypeName().equals("System.ICloneable")) {
				return true;
			}
		}
		return false;
	}

	private void mapSuperTypes(TypeDeclaration node, CSTypeDeclaration type) {
		if (!_ignoreExtends.value()) {
			mapSuperClass(node, type);
		}
		if (!ignoreImplements(node)) {
			mapSuperInterfaces(node, type);
		}
	}

	private boolean ignoreImplements(TypeDeclaration node) {
		return containsJavadoc(node, SharpenAnnotations.SHARPEN_IGNORE_IMPLEMENTS);
	}

	@SuppressWarnings("unused")
	private boolean ignoreExtends(TypeDeclaration node) {
		return containsJavadoc(node, SharpenAnnotations.SHARPEN_IGNORE_EXTENDS);
	}

	private void processConversionJavadocTags(TypeDeclaration node, CSTypeDeclaration type) {
		processPartialTagElement(node, type);
	}

	public CSTypeDeclaration mapTypeDeclaration(TypeDeclaration node) {
		CSTypeDeclaration type = typeDeclarationFor(node);
		type.startPosition(node.getStartPosition());
		type.sourceLength(node.getLength());
		mapTypeParameters(node.typeParameters(), type);
		return checkForMainType(node, type);
	}

	private void mapTypeParameters(final List typeParameters, CSTypeParameterProvider type) {
		for (Object item : typeParameters) {
			type.addTypeParameter(mapTypeParameter((TypeParameter) item));
		}
	}

	private CSTypeParameter mapTypeParameter(TypeParameter item) {
		CSTypeParameter tp = new CSTypeParameter(identifier(item.getName()));
		ITypeBinding tb = item.resolveBinding();
		if (tb != null) {
			ITypeBinding superc = mapTypeParameterExtendedType(tb);
			if (superc != null)
				tp.superClass(mappedTypeReference(superc));
		}
		return tp;
	}

	private CSTypeDeclaration typeDeclarationFor(TypeDeclaration node) {
		final String typeName = typeName(node);
		if (node.isInterface()) {
			if (!isValidCSInterface(node.resolveBinding()))
				addProblem(node, ProblemKind.INTERNAL_ERROR, "Must extract interface");
			return new CSInterface(processInterfaceName(node));
		}

		if (isStruct(node)) {
			return new CSStruct(typeName);
		}
		return new CSClass(typeName, mapClassModifier(node.getModifiers()));
	}

	private CSTypeDeclaration processExtractedInterface(final TypeDeclaration node) {
		final ITypeBinding typeBinding = node.resolveBinding();
		final CSTypeContainer current = getCurrentType(typeBinding);

		final String typeName = typeName(node);
		final String extractedName = typeName + "Class";

		my(CSharpDriver.class).processTypeDeclaration(this, current, node,
				new ITypeBuilderDelegate() {

			public CSTypeDeclaration create() {
				CSInterface iface = new CSInterface(typeName);
				iface.startPosition(node.getStartPosition());
				iface.sourceLength(node.getLength());
				CSharpBuilder.this.mapTypeParameters(node.typeParameters(), iface);
				return iface;
			}

			public void map(CSTypeDeclaration iface) {
				mapSuperTypes(node, iface);
				iface.visibility(mapVisibility(typeBinding));
			}

			public void mapMembers(CSTypeDeclaration iface, final IMemberFilter filter) {
				CSharpBuilder.this.mapMembers(node, iface, new IMemberFilter() {
					public boolean includeMember(ASTNode member) {
						if ((filter != null) && !filter.includeMember(member))
							return false;
						if (!(member instanceof MethodDeclaration))
							return false;
						MethodDeclaration method = (MethodDeclaration) member;
						if (method.isConstructor())
							return false;
						if (Modifier.isStatic(method.getModifiers()))
							return false;
						return true;
					}
				});
			}

			public void document(CSTypeDeclaration iface) {
				CSharpBuilder.this.mapDocumentation(node, iface);
				processConversionJavadocTags(node, iface);
			}

			public void fixup(CSTypeDeclaration iface) {

			}

		});

		return my(CSharpDriver.class).processTypeDeclaration(this, current, node,
				new ITypeBuilderDelegate() {

			public CSTypeDeclaration create() {
				CSClass klass = new CSClass(extractedName, CSClassModifier.Static);
				klass.startPosition(node.getStartPosition());
				klass.sourceLength(node.getLength());
				return klass;
			}

			public void map(CSTypeDeclaration klass) {
				klass.visibility(mapVisibility(typeBinding));
			}

			public void mapMembers(CSTypeDeclaration klass, final IMemberFilter filter) {
				CSharpBuilder.this.mapMembers(node, klass, new IMemberFilter() {
					public boolean includeMember(ASTNode member) {
						if ((filter != null) && !filter.includeMember(member))
							return false;
						if (member instanceof MethodDeclaration) {
							MethodDeclaration method = (MethodDeclaration) member;
							if (!Modifier.isStatic(method.getModifiers()))
								return false;
						}
						return true;
					}
				});
			}

			public void document(CSTypeDeclaration klass) {
				CSharpBuilder.this.mapDocumentation(node, klass);
				processConversionJavadocTags(node, klass);
			}

			public void fixup(CSTypeDeclaration klass) {
				for (CSMember member : klass.members()) {
					member.visibility(CSVisibility.Public);
				}

				autoImplementCloneable(node, klass);

				adjustMemberVisibility(node, klass);

				moveInitializersDependingOnThisReferenceToConstructor(klass);
			}
		});
	}

	private CSTypeDeclaration processExtractedRawType(final TypeDeclaration node) {
		final ITypeBinding typeBinding = node.resolveBinding();
		final CSTypeContainer current = getCurrentType(typeBinding);
		final String typeName = typeName(node);

		my(CSharpDriver.class).processTypeDeclaration(this, current, node,
				new ITypeBuilderDelegate() {

			public CSTypeDeclaration create() {
				return new CSClass(typeName, CSClassModifier.Static);
			}

			public void map(CSTypeDeclaration raw) {
				raw.visibility(mapVisibility(typeBinding));
			}

			public void mapMembers(CSTypeDeclaration raw, final IMemberFilter filter) {
				CSharpBuilder.this.mapMembers(node, raw, new IMemberFilter() {
					public boolean includeMember(ASTNode member) {
						if ((filter != null) && !filter.includeMember(member))
							return false;
						if (member instanceof TypeDeclaration) {
							TypeDeclaration tdecl = (TypeDeclaration) member;
							ITypeBinding binding = tdecl.resolveBinding();
							return extractIntoRawType(binding);
						} else if (member instanceof EnumDeclaration) {
							return true;
						} else if (member instanceof FieldDeclaration) {
							FieldDeclaration fdecl = (FieldDeclaration) member;
							if (fdecl.fragments().size() != 1)
								return false;
							VariableDeclarationFragment fragment = (VariableDeclarationFragment) fdecl
									.fragments().get(0);
							return isConstField(fdecl, fragment);
						}
						return false;
					}
				});
			}

			public void document(CSTypeDeclaration raw) {
				CSharpBuilder.this.mapDocumentation(node, raw);
			}

			public void fixup(CSTypeDeclaration raw) {
				for (CSMember member : raw.members()) {
					if (member.visibility() != CSVisibility.Public)
						member.visibility(CSVisibility.Internal);
				}
			}
		});

		CSTypeDeclaration type = my(CSharpDriver.class).processTypeDeclaration(this, current, node,
				new CSharpDriver.ITypeBuilderDelegate() {

			public CSTypeDeclaration create() {
				CSTypeDeclaration type = typeDeclarationFor(node);
				type.startPosition(node.getStartPosition());
				type.sourceLength(node.getLength());
				mapTypeParameters(node.typeParameters(), type);
				return type;
			}

			public void map(CSTypeDeclaration type) {
				mapSuperTypes(node, type);
				type.visibility(mapVisibility(typeBinding));
			}

			public void mapMembers(CSTypeDeclaration type, final IMemberFilter filter) {
				CSharpBuilder.this.mapMembers(node, type, new IMemberFilter() {
					public boolean includeMember(ASTNode member) {
						if ((filter != null) && !filter.includeMember(member))
							return false;
						if (member instanceof TypeDeclaration) {
							TypeDeclaration tdecl = (TypeDeclaration) member;
							ITypeBinding binding = tdecl.resolveBinding();
							return !extractIntoRawType(binding);
						} else if (member instanceof EnumDeclaration) {
							return false;
						} else if (member instanceof FieldDeclaration) {
							FieldDeclaration fdecl = (FieldDeclaration) member;
							if (fdecl.fragments().size() != 1)
								return true;
							VariableDeclarationFragment fragment = (VariableDeclarationFragment) fdecl
									.fragments().get(0);
							return !isConstField(fdecl, fragment);
						}
						return true;
					}
				});
			}

			public void document(CSTypeDeclaration type) {
				CSharpBuilder.this.mapDocumentation(node, type);
				processConversionJavadocTags(node, type);
			}

			public void fixup(CSTypeDeclaration type) {
				adjustMemberVisibility(node, type);

				autoImplementCloneable(node, type);

				moveInitializersDependingOnThisReferenceToConstructor(type);
			}
		});

		return type;
	}

	private String typeName(AbstractTypeDeclaration node) {
		String renamed = annotatedRenaming(node);
		if (renamed != null)
			return renamed;
		renamed = mappedTypeName(node.resolveBinding());
		if (renamed != null) {
			int i = renamed.lastIndexOf('.');
			if (i != -1)
				return renamed.substring(i + 1);
			else
				return renamed;
		}
		return node.getName().toString();
	}

	private boolean isStruct(TypeDeclaration node) {
		return containsJavadoc(node, SharpenAnnotations.SHARPEN_STRUCT);
	}

	private CSTypeDeclaration checkForMainType(TypeDeclaration node, CSTypeDeclaration type) {
		if (isMainType(node)) {
			setCompilationUnitElementName(type.name());
		}
		return type;
	}

	private void setCompilationUnitElementName(String name) {
		_compilationUnit.elementName(name + ".cs");
	}

	private String processInterfaceName(TypeDeclaration node) {
		String name = node.getName().getFullyQualifiedName();
		return interfaceName(name);
	}

	private boolean isMainType(TypeDeclaration node) {
		return node.isPackageMemberTypeDeclaration() && Modifier.isPublic(node.getModifiers());
	}

	private void mapSuperClass(TypeDeclaration node, CSTypeDeclaration type) {
		if (handledExtends(node, type))
			return;

		if (null == node.getSuperclassType())
			return;

		final ITypeBinding superClassBinding = node.getSuperclassType().resolveBinding();
		if (null == superClassBinding)
			unresolvedTypeBinding(node.getSuperclassType());

		if (!isLegacyTestFixtureClass(superClassBinding))
			type.addBaseType(mappedTypeReference(superClassBinding));
		else {
			type.addAttribute(new CSAttribute("NUnit.Framework.TestFixture"));
		}
	}

	private boolean isLegacyTestFixtureClass(ITypeBinding type)
	{
		return (_configuration.junitConversion() && type.getQualifiedName().equals("junit.framework.TestCase"));
	}

	private boolean isLegacyTestFixture(ITypeBinding type) {
		if (!_configuration.junitConversion())
			return false;
		if (isLegacyTestFixtureClass(type))
			return true;
		ITypeBinding base = type.getSuperclass();
		return (base != null) && isLegacyTestFixture(base);
	}

	private boolean hasTests(CSTypeDeclaration type) {
		for (CSMember m : type.members()) {
			if (m instanceof CSMethod) {
				CSMethod met = (CSMethod) m;
				for (CSAttribute at : met.attributes()) {
					if (at.name().equals("Test") || at.name().equals("NUnit.Framework.Test"))
						return true;
				}
			}
		}
		return false;
	}

	private boolean handledExtends(TypeDeclaration node, CSTypeDeclaration type) {
		final TagElement replaceExtendsTag = javadocTagFor(node, SharpenAnnotations.SHARPEN_EXTENDS);
		if (null == replaceExtendsTag)
			return false;

		final String baseType = JavadocUtility.singleTextFragmentFrom(replaceExtendsTag);
		type.addBaseType(new CSTypeReference(baseType));
		return true;
	}

	private void mapSuperInterfaces(TypeDeclaration node, CSTypeDeclaration type) {
		final ITypeBinding serializable = my(IBindingManager.class).getSerializableType();
		for (Object itf : node.superInterfaceTypes()) {
			Type iface = (Type) itf;
			ITypeBinding binding = iface.resolveBinding();
			if (binding == serializable) {
				continue;
			} else {
				type.addBaseType(mappedTypeReference(iface));
			}
		}

		if (!type.isInterface() && node.resolveBinding().isSubTypeCompatible(serializable)) {
			type.addAttribute(new CSAttribute("System.Serializable"));
		}
	}

	private boolean isJavaLangCharSequence(ITypeBinding binding) {
		return binding.getQualifiedName().equals("java.lang.CharSequence");
	}

	private boolean isJavaLangString(ITypeBinding binding) {
		return binding.getQualifiedName().equals("java.lang.String");
	}

	private boolean isJavaLangNumber(ITypeBinding binding) {
		return binding.getQualifiedName().equals("java.lang.Number");
	}

	private ITypeBinding resolveWellKnownType(String typeName) {
		return _ast.getAST().resolveWellKnownType(typeName);
	}

	private void mapMembers(TypeDeclaration node, CSTypeDeclaration type, CSharpDriver.IMemberFilter filter) {
		CSTypeDeclaration saved = _currentType;
		_currentType = type;
		try {
			List<ASTNode> members = node.bodyDeclarations();
			for (final ASTNode member : members) {
				if ((filter != null) && !filter.includeMember(member))
					continue;
				member.accept(this);
			}
			createInheritedAbstractMemberStubs(node);
			flushInstanceInitializers(type, 0);
		} finally {
			_currentType = saved;
		}
	}

	private void mapMembers(EnumDeclaration node, CSTypeDeclaration type, CSharpDriver.IMemberFilter filter) {
		CSTypeDeclaration saved = _currentType;
		_currentType = type;
		try {
			List<ASTNode> members = node.bodyDeclarations();
			for (final ASTNode member : members) {
				if ((filter != null) && !filter.includeMember(member))
					continue;
				member.accept(this);
			}
			flushInstanceInitializers(type, 0);
		} finally {
			_currentType = saved;
		}
	}

	private void adjustMemberVisibility(TypeDeclaration node, CSTypeDeclaration type) {
		ITypeBinding binding = node.resolveBinding();

		for (final CSMember member : type.members()) {
			if (member instanceof CSMethod)
				continue;
			if (binding.isNested() && Modifier.isPrivate(binding.getModifiers())) {
				if (member.visibility() == CSVisibility.Private)
					member.visibility(CSVisibility.Internal);
			}
		}
	}

	private boolean containsNonPublicTypes(ITypeBinding binding, boolean privateOnly) {
		if (binding.isPrimitive())
			return false;
		if (binding.isTypeVariable())
			return false;
		if (binding.isWildcardType())
			return false;
		if (binding.isArray())
			return containsNonPublicTypes(binding.getElementType(), privateOnly);
		if (binding.isParameterizedType()) {
			for (final ITypeBinding tp : binding.getTypeArguments()) {
				if (containsNonPublicTypes(tp, privateOnly))
					return true;
			}
		}
		if (privateOnly)
			return Modifier.isPrivate(binding.getModifiers());
		else
			return !Modifier.isPublic(binding.getModifiers());
	}

	private boolean containsNonPublicTypes(IMethodBinding binding, boolean privateOnly) {
		ITypeBinding returnType = binding.getReturnType();
		if ((returnType != null) && containsNonPublicTypes(returnType, privateOnly))
			return true;
		for (final ITypeBinding type : binding.getParameterTypes()) {
			if (containsNonPublicTypes(type, privateOnly))
				return true;
		}
		return false;
	}

	protected boolean isNonStaticNestedType(ITypeBinding binding) {
		if (binding.isInterface())
			return false;
		if (!binding.isNested())
			return false;
		return !isStatic(binding);
	}

	private boolean isGenericInstance(ITypeBinding type) {
		if (type.isArray())
			return isGenericInstance(type.getElementType());
		if (type.isParameterizedType())
			return true;
		if (type.isCapture()) {
			ITypeBinding erasure = type.getErasure();
			return erasure.isGenericType();
		}
		return false;
	}

	private boolean isRawOrGenericType(ITypeBinding type) {
		if (type.isArray())
			return isRawOrGenericType(type.getElementType());
		return type.isRawType() || type.isGenericType();
	}

	/*
	 * Only use this for comparisons.
	 */
	private ITypeBinding getUnderlyingGenericType(ITypeBinding type) {
		if (type.isGenericType())
			return type;
		if (type.isParameterizedType())
			return type.getTypeDeclaration();
		if (type.isRawType())
			return type.getTypeDeclaration();
		if (type.isCapture()) {
			ITypeBinding erasure = type.getErasure();
			return isRawOrGenericType(erasure) ? erasure : null;
		}
		if (type.isArray())
			return getUnderlyingGenericType(type.getElementType());
		return null;
	}

	private boolean isStatic(ITypeBinding binding) {
		return Modifier.isStatic(binding.getModifiers());
	}

	private CSTypeContainer getCurrentType(ITypeBinding binding) {
		if (null != _currentType && !isExtractedNestedType(binding)) {
			return _currentType;
		} else {
			return _compilationUnit;
		}
	}

	private void mapDocumentation(final BodyDeclaration bodyDecl, final CSMember member) {
		my(PreserveFullyQualifiedNamesState.class).using(true, new Runnable() {
			public void run() {
				if (processDocumentationOverlay(member)) {
					return;
				}

				mapJavadoc(bodyDecl, member);
				mapDeclaredExceptions(bodyDecl, member);

			}
		});
	}

	private void mapDeclaredExceptions(BodyDeclaration bodyDecl, CSMember member) {
		if (!(bodyDecl instanceof MethodDeclaration))
			return;

		MethodDeclaration method = (MethodDeclaration) bodyDecl;
		mapThrownExceptions(method.thrownExceptions(), member);
	}

	private void mapThrownExceptions(List thrownExceptions, CSMember member) {
		for (Object exception : thrownExceptions) {
			mapThrownException((Name) exception, member);
		}
	}

	private void mapThrownException(Name exception, CSMember member) {
		final String typeName = mappedTypeName(exception.resolveTypeBinding());
		if (containsExceptionTagWithCRef(member, typeName))
			return;

		member.addDoc(newTagWithCRef("exception", typeName));
	}

	private boolean containsExceptionTagWithCRef(CSMember member, String cref) {
		for (CSDocNode node : member.docs()) {
			if (!(node instanceof CSDocTagNode))
				continue;

			if (cref.equals(((CSDocTagNode) node).getAttribute("cref"))) {
				return true;
			}
		}
		return false;
	}

	private void mapJavadoc(final BodyDeclaration bodyDecl, final CSMember member) {
		final Javadoc javadoc = bodyDecl.getJavadoc();
		if (null == javadoc) {
			return;
		}

		mapJavadocTags(javadoc, member);
	}

	private boolean processDocumentationOverlay(CSMember node) {
		if (node instanceof CSTypeDeclaration) {
			return processTypeDocumentationOverlay((CSTypeDeclaration) node);
		}
		return processMemberDocumentationOverlay((CSMember) node);
	}

	private boolean processMemberDocumentationOverlay(CSMember node) {
		String overlay = documentationOverlay().forMember(currentTypeQName(), node.signature());
		return processDocumentationOverlay(node, overlay);
	}

	private String currentTypeQName() {
		return qualifiedName(_currentType);
	}

	private boolean processTypeDocumentationOverlay(CSTypeDeclaration node) {
		String overlay = documentationOverlay().forType(qualifiedName(node));
		return processDocumentationOverlay(node, overlay);
	}

	private boolean processDocumentationOverlay(CSMember node, String overlay) {
		if (null == overlay) {
			return false;
		}
		node.addDoc(new CSDocTextOverlay(overlay.trim()));
		return true;
	}

	private DocumentationOverlay documentationOverlay() {
		return _configuration.documentationOverlay();
	}

	private String qualifiedName(CSTypeDeclaration node) {
		if (currentNamespace() == null) {
			return node.name();
		}
		return currentNamespace() + "." + node.name();
	}

	private String currentNamespace() {
		return _compilationUnit.namespace();
	}

	private IMethodBinding currentMethodBinding() {
		if (_currentBodyDeclaration == null)
			return null;
		else if (_currentBodyDeclaration instanceof MethodDeclaration)
			return ((MethodDeclaration) _currentBodyDeclaration).resolveBinding();
		return null;
	}

	private void mapJavadocTags(final Javadoc javadoc, final CSMember member) {
		for (Object tag : javadoc.tags()) {
			try {
				TagElement element = (TagElement) tag;
				String tagName = element.getTagName();
				if (null == tagName) {
					mapJavadocSummary(member, element);
				} else {
					processTagElement(member, element);
				}
			} catch (Exception x) {
				warning((ASTNode) tag, x.getMessage());
				x.printStackTrace();
			}
		}
	}

	private void processTagElement(final CSMember member, TagElement element) {
		if (processSemanticallySignificantTagElement(member, element)) {
			return;
		}
		if (!isConversionTag(element.getTagName())) {
			member.addDoc(mapTagElement(element));
		}
		else if (isAttributeAnnotation(element)) {
			processAttribute(member, element);
		}
		else if (isNewAnnotation(element)) {
			member.setNewModifier(true);
		}
	}

	private boolean isAttributeAnnotation(TagElement element) {
		return element.getTagName().equals(SharpenAnnotations.SHARPEN_ATTRIBUTE);
	}

	private boolean isNewAnnotation(TagElement element) {
		return element.getTagName().equals(SharpenAnnotations.SHARPEN_NEW);
	}

	private void processAttribute(CSMember member, TagElement element) {
		String attrType = mappedTypeName(JavadocUtility.singleTextFragmentFrom(element));
		CSAttribute attribute = new CSAttribute(attrType);
		member.addAttribute(attribute);
	}

	private boolean processSemanticallySignificantTagElement(CSMember member, TagElement element) {
		if (element.getTagName().equals("@deprecated")) {
			member.removeAttribute("System.Obsolete");
			member.removeAttribute("System.ObsoleteAttribute");
			member.addAttribute(obsoleteAttributeFromDeprecatedTagElement(element));
			return true;
		}
		return false;
	}

	private CSAttribute obsoleteAttributeFromDeprecatedTagElement(TagElement element) {

		CSAttribute attribute = new CSAttribute(mappedTypeName("System.ObsoleteAttribute"));
		if (element.fragments().isEmpty()) {
			return attribute;
		}
		attribute.addArgument(new CSStringLiteralExpression(toLiteralStringForm(getWholeText(element))));
		return attribute;
	}

	private String getWholeText(TagElement element) {
		StringBuilder builder = new StringBuilder();

		for (ASTNode fragment : (List<ASTNode>) element.fragments()) {
			if (fragment instanceof TextElement) {
				TextElement textElement = (TextElement) fragment;
				String text = textElement.getText();
				appendWithSpaceIfRequired(builder, text);
			} else if (fragment instanceof TagElement) {
				builder.append(getWholeText((TagElement) fragment));
			} else if (fragment instanceof MethodRef) {
				builder.append(mapCRefTarget(fragment));
			} else if (fragment instanceof MemberRef) {
				builder.append(mapCRefTarget(fragment));
			} else if (fragment instanceof Name) {
				builder.append(mapCRefTarget(fragment));
			} else {
				break;
			}
		}
		return builder.toString().trim();
	}

	private void appendWithSpaceIfRequired(StringBuilder builder, String text) {
		if (builder.length() > 0 && builder.charAt(builder.length() - 1) != ' '
				&& text.startsWith(" ") == false) {
			builder.append(" ");
		}
		builder.append(text);
	}

	private String toLiteralStringForm(String s) {
		// TODO: deal with escaping sequences here
		return "@\"" + s.replace("\"", "\"\"") + "\"";
	}

	private boolean isConversionTag(String tagName) {
		return tagName.startsWith("@sharpen.");
	}

	private void processPartialTagElement(TypeDeclaration node, CSTypeDeclaration member) {
		TagElement element = javadocTagFor(node, SharpenAnnotations.SHARPEN_PARTIAL);
		if (null == element)
			return;
		((CSTypeDeclaration) member).partial(true);
	}

	private TagElement javadocTagFor(PackageDeclaration node, final String withName) {
		return JavadocUtility.getJavadocTag(node, withName);
	}

	private TagElement javadocTagFor(BodyDeclaration node, final String withName) {
		return JavadocUtility.getJavadocTag(node, withName);
	}

	private void mapJavadocSummary(final CSMember member, TagElement element) {
		List<String> summary = getFirstSentence(element);
		if (null != summary) {
			CSDocTagNode summaryNode = new CSDocTagNode("summary");
			for (String fragment : summary) {
				summaryNode.addFragment(new CSDocTextNode(fragment));
			}
			member.addDoc(summaryNode);
			member.addDoc(createTagNode("remarks", element));
		} else {
			member.addDoc(createTagNode("summary", element));
		}
	}

	private List<String> getFirstSentence(TagElement element) {
		List<String> fragments = new LinkedList<String>();
		for (Object fragment : element.fragments()) {
			if (fragment instanceof TextElement) {
				TextElement textElement = (TextElement) fragment;
				String text = textElement.getText();
				int index = findSentenceClosure(text);
				if (index > -1) {
					fragments.add(text.substring(0, index + 1));
					return fragments;
				} else {
					fragments.add(text);
				}
			} else {
				break;
			}
		}
		return null;
	}

	private int findSentenceClosure(String text) {
		Matcher matcher = SUMMARY_CLOSURE_PATTERN.matcher(text);
		return matcher.find() ? matcher.start() : -1;
	}

	private CSDocNode mapTagElement(TagElement element) {
		String tagName = element.getTagName();
		if (TagElement.TAG_PARAM.equals(tagName)) {
			return mapTagParam(element);
		} else if (TagElement.TAG_RETURN.equals(tagName)) {
			return createTagNode("returns", element);
		} else if (TagElement.TAG_LINK.equals(tagName)) {
			return mapTagLink(element);
		} else if (TagElement.TAG_THROWS.equals(tagName)) {
			return mapTagThrows(element);
		} else if (TagElement.TAG_SEE.equals(tagName)) {
			return mapTagWithCRef("seealso", element);
		}
		return createTagNode(tagName.substring(1), element);
	}

	private CSDocNode mapTagThrows(TagElement element) {
		return mapTagWithCRef("exception", element);
	}

	private CSDocNode mapTagLink(TagElement element) {
		return mapTagWithCRef("see", element);
	}

	private CSDocNode mapTagWithCRef(String tagName, TagElement element) {
		final List fragments = element.fragments();
		if (fragments.isEmpty()) {
			return invalidTagWithCRef(element, tagName, element);
		}
		final ASTNode linkTarget = (ASTNode) fragments.get(0);
		String cref = mapCRefTarget(linkTarget);
		if (null == cref) {
			return invalidTagWithCRef(linkTarget, tagName, element);
		}
		CSDocTagNode node = newTagWithCRef(tagName, cref);
		if (fragments.size() > 1) {
			if (isLinkWithSimpleLabel(fragments, linkTarget)) {
				node.addTextFragment(unqualifiedName(cref));
			} else {
				collectFragments(node, fragments, 1);
			}
		} else {
			// TODO: Move the XML encoding to the right place
			// (CSharpPrinter)
			node.addTextFragment(cref.replace("{", "&lt;").replace("}", "&gt;"));
		}
		return node;
	}

	private ASTNode documentedNodeAttachedTo(TagElement element) {
		ASTNode attachedToNode = element;
		while (attachedToNode instanceof TagElement || attachedToNode instanceof Javadoc) {
			attachedToNode = attachedToNode.getParent();
		}
		return attachedToNode;
	}

	private CSDocNode invalidTagWithCRef(final ASTNode linkTarget, String tagName, TagElement element) {
		warning(linkTarget, "Tag '" + element.getTagName() + "' demands a valid cref target.");
		CSDocNode newTag = createTagNode(tagName, element);
		return newTag;
	}

	private CSDocTagNode newTagWithCRef(String tagName, String cref) {
		CSDocTagNode node = new CSDocTagNode(tagName);
		node.addAttribute("cref", cref);
		return node;
	}

	private boolean isLinkWithSimpleLabel(List<ASTNode> fragments, final ASTNode linkTarget) {
		if (fragments.size() != 2)
			return false;
		if (!JavadocUtility.isTextFragment(fragments, 1))
			return false;
		final String link = linkTarget.toString();
		final String label = JavadocUtility.textFragment(fragments, 1);
		return label.equals(link) || label.equals(unqualifiedName(link));
	}

	private String mapCRefTarget(final ASTNode crefTarget) {
		return new CRefBuilder(crefTarget).build();
	}

	private CSDocNode mapTagParam(TagElement element) {

		List fragments = element.fragments();

		if (!(fragments.get(0) instanceof SimpleName))
			return new CSDocTagNode("?");
		SimpleName name = (SimpleName) fragments.get(0);
		if (null == name.resolveBinding()) {
			warning(name, "Parameter '" + name + "' not found.");
		}

		CSDocTagNode param = isPropertyNode(documentedNodeAttachedTo(element))
				? new CSDocTagNode("value")
		: newCSDocTag(fixIdentifierNameFor(identifier(name), element));

				collectFragments(param, fragments, 1);
				return param;
	}

	private CSDocTagNode newCSDocTag(final String paramName) {
		CSDocTagNode param;
		param = new CSDocTagNode("param");
		param.addAttribute("name", paramName);
		return param;
	}

	private boolean isPropertyNode(ASTNode node) {
		if (node.getNodeType() != ASTNode.METHOD_DECLARATION) {
			return false;
		}

		return isProperty((MethodDeclaration) node);
	}

	private String fixIdentifierNameFor(String identifier, TagElement element) {
		return removeAtSign(identifier);
	}

	private String removeAtSign(String identifier) {
		return identifier.startsWith("@")
				? identifier.substring(1)
						: identifier;
	}

	private void collectFragments(CSDocTagNode node, List fragments, int index) {
		for (int i = index; i < fragments.size(); ++i) {
			node.addFragment(mapTagElementFragment((ASTNode) fragments.get(i)));
		}
	}

	private CSDocNode mapTextElement(TextElement element) {
		final String text = element.getText();
		if (HTML_ANCHOR_PATTERN.matcher(text).find()) {
			warning(element,
					"Caution: HTML anchors can result in broken links. Consider using @link instead.");
		}
		return new CSDocTextNode(text);
	}

	private CSDocNode createTagNode(String tagName, TagElement element) {
		CSDocTagNode summary = new CSDocTagNode(tagName);
		for (Object f : element.fragments()) {
			summary.addFragment(mapTagElementFragment((ASTNode) f));
		}
		return summary;
	}

	private CSDocNode mapTagElementFragment(ASTNode node) {
		switch (node.getNodeType()) {
		case ASTNode.TAG_ELEMENT:
			return mapTagElement((TagElement) node);
		case ASTNode.TEXT_ELEMENT:
			return mapTextElement((TextElement) node);
		}
		warning(node, "Documentation node not supported: " + node.getClass() + ": " + node);
		return new CSDocTextNode(node.toString());
	}

	@Override
	public boolean visit(final FieldDeclaration node) {

		if (SharpenAnnotations.hasIgnoreAnnotation(node)) {
			return false;
		}

		for (Object item : node.fragments()) {
			final VariableDeclarationFragment fragment = (VariableDeclarationFragment) item;
			my(CSharpDriver.class).processFieldDeclaration(this, _currentType, node, fragment,
					new IFieldBuilderDelegate() {

				public CSField create() {
					final IVariableBinding binding = fragment.resolveBinding();
					final ITypeBinding fieldType = binding.getType();

					CSTypeReferenceExpression fieldTypeRef = mappedVariableType(binding);
					CSVisibility visibility = mapVisibility(binding);

					pushExpectedType(fieldType);
					CSField field = mapFieldDeclarationFragment(node, fragment,
							fieldTypeRef, visibility);
					popExpectedType();

					return field;
				}

				public void map(CSField member) {
					// Nothing to do
				}

				public void document(CSField member) {
					// Nothing to do
				}

				public void fixup(CSField member) {
					// Nothing to do
				}

			});
		}

		return false;
	}

	private CSField mapFieldDeclarationFragment(FieldDeclaration node, VariableDeclarationFragment fragment,
			CSTypeReferenceExpression fieldType, CSVisibility fieldVisibility) {
		final String mappedName = mappedFieldDeclarationName(node, fragment);
		CSExpression initializer = mapFieldInitializer(fragment);
		CSField field = new CSField(mappedName, fieldType, fieldVisibility, initializer);
		if (isConstField(node, fragment)) {
			ITypeBinding type = fragment.resolveBinding().getType();
			boolean useStaticReadonly;
			if (type.equals(my(IBindingManager.class).getStringType()))
				useStaticReadonly = !(initializer instanceof CSStringLiteralExpression)
						&& !(initializer instanceof CSNullLiteralExpression);
			else
				useStaticReadonly = type.isArray() || !type.isPrimitive();
			if (useStaticReadonly) {
				field.addModifier(CSFieldModifier.Static);
				field.addModifier(CSFieldModifier.Readonly);
			} else {
				field.addModifier(CSFieldModifier.Const);
				if (field.visibility() != CSVisibility.Public)
					field.visibility(CSVisibility.Internal);
			}
		} else {
			processFieldModifiers(field, node.getModifiers());
		}
		mapDocumentation(node, field);
		mapAnnotations(node, field);
		return field;
	}

	private String mappedFieldDeclarationName(FieldDeclaration node, VariableDeclarationFragment fragment) {
		final IVariableBinding binding = fragment.resolveBinding();
		final String mappedName = null == binding ? null : my(Mappings.class).mappedFieldName(binding);

		if (null == mappedName || 0 == mappedName.length() || mappedName.contains(".")) {
			return fieldName(fragment);
		}

		return mappedName;
	}

	private CSVisibility mapVisibility(IVariableBinding binding) {
		CSVisibility vis = my(CSharpDriver.class).mapVisibility(binding);
		if (vis != null)
			return vis;

		if (binding.getDeclaringClass().isInterface())
			return CSVisibility.Public;

		vis = mapVisibility(binding.getModifiers());
		vis = adjustVisibility(binding.getDeclaringClass(), binding.getType(), vis);
		return vis;
	}

	private void mapAnnotations(BodyDeclaration node, CSMember member) {
		for (Object m : node.modifiers()) {
			if (!(m instanceof Annotation)) {
				continue;
			}
			if (isIgnoredAnnotation((Annotation) m)) {
				continue;
			}
			if (m instanceof MarkerAnnotation) {
				mapMarkerAnnotation((MarkerAnnotation) m, member);
			}
		}
	}

	private boolean isIgnoredAnnotation(Annotation m) {
		return _configuration.isIgnoredAnnotation(qualifiedName(m.resolveAnnotationBinding()
				.getAnnotationType()));
	}

	private void mapMarkerAnnotation(MarkerAnnotation annotation, CSMember member) {
		final IAnnotationBinding binding = annotation.resolveAnnotationBinding();
		String name = mappedTypeName(binding.getAnnotationType());
		if (name.equals("System.Obsolete") || name.equals("System.ObsoleteAttribute")) {
			for (CSAttribute old : member.attributes()) {
				if (old.name().equals("System.Obsolete")
						|| old.name().equals("System.ObsoleteAttribute"))
					return;
			}
		}
		final CSAttribute attribute = new CSAttribute(name);
		member.addAttribute(attribute);
	}

	protected String fieldName(VariableDeclarationFragment fragment) {
		return identifier(fragment.getName());
	}

	protected CSExpression mapFieldInitializer(VariableDeclarationFragment fragment) {
		return mapExpression(fragment.resolveBinding().getType(), fragment.getInitializer());
	}

	private boolean isConstField(FieldDeclaration node, VariableDeclarationFragment fragment) {
		IVariableBinding binding = fragment.resolveBinding();
		if (binding.getDeclaringClass().isInterface())
			return true;
		ITypeBinding type = binding.getType();
		boolean isPrimitive = type.isPrimitive() || type.equals(my(IBindingManager.class).getStringType());
		return Modifier.isFinal(node.getModifiers()) && isPrimitive &&
				hasConstValue(fragment) && Modifier.isStatic(node.getModifiers());
	}

	private boolean hasConstValue(VariableDeclarationFragment fragment) {
		return null != fragment.resolveBinding().getConstantValue();
	}

	private void processFieldModifiers(CSField field, int modifiers) {
		if (Modifier.isStatic(modifiers)) {
			field.addModifier(CSFieldModifier.Static);
		}
		if (Modifier.isFinal(modifiers)) {
			field.addModifier(CSFieldModifier.Readonly);
		}
		if (Modifier.isTransient(modifiers)) {
			field.addAttribute(new CSAttribute(mappedTypeName("System.NonSerialized")));
		}
		if (Modifier.isVolatile(modifiers)) {
			field.addModifier(CSFieldModifier.Volatile);
		}

	}

	private boolean isDestructor(MethodDeclaration node) {
		return node.getName().toString().equals("finalize");
	}

	@Override
	public boolean visit(Initializer node) {
		if (Modifier.isStatic(node.getModifiers())) {
			CSConstructor ctor = _currentType.ensureStaticConstructor();
			CSBlock block = new CSBlock();
			ctor.body().addStatement(block);
			visitBodyDeclarationBlock(node, node.getBody(), ctor, block);
		} else {
			_instanceInitializers.add(node);
		}
		return false;
	}

	@Override
	public boolean visit(MethodDeclaration node) {
		if (SharpenAnnotations.hasIgnoreAnnotation(node) || isRemoved(node)) {
			return false;
		}

		if (isEvent(node)) {
			processEventDeclaration(node);
			return false;
		}

		if (isMappedToProperty(node)) {
			processMappedPropertyDeclaration(node);
			return false;
		}

		if (isTaggedAsProperty(node)) {
			processPropertyDeclaration(node);
			return false;
		}

		if (isIndexer(node)) {
			processIndexerDeclaration(node);
			return false;
		}

		processMethodDeclaration(node);

		return false;
	}

	private void processIndexerDeclaration(MethodDeclaration node) {
		processPropertyDeclaration(node, CSProperty.INDEXER);
	}

	private boolean isIndexer(MethodDeclaration node) {
		return isTaggedDeclaration(node, SharpenAnnotations.SHARPEN_INDEXER)
				|| isMappedToIndexer(node);
	}

	private boolean isRemoved(MethodDeclaration node) {
		return hasRemoveAnnotation(node) || isRemoved(node.resolveBinding());
	}

	private boolean hasRemoveAnnotation(BodyDeclaration node) {
		return containsJavadoc(node, SharpenAnnotations.SHARPEN_REMOVE);
	}

	private boolean isRemoved(final IMethodBinding binding) {
		return _configuration.isRemoved(qualifiedName(binding));
	}

	public static boolean containsJavadoc(BodyDeclaration node, final String tag) {
		return JavadocUtility.containsJavadoc(node, tag);
	}

	private void processPropertyDeclaration(MethodDeclaration node) {
		processPropertyDeclaration(node, propertyName(node));
	}

	private void processMappedPropertyDeclaration(MethodDeclaration node) {
		processPropertyDeclaration(node, mappedMethodName(node));
	}

	private void processPropertyDeclaration(final MethodDeclaration node, final String name) {
		final CSProperty existingProperty = findProperty(node, name);
		my(CSharpDriver.class).processPropertyDeclaration(this, _currentType, node, name, existingProperty,
				new IPropertyBuilderDelegate() {

			public boolean isGetter() {
				return CSharpBuilder.this.isGetter(node);
			}

			public CSProperty create() {
				if (existingProperty != null)
					return existingProperty;
				return newPropertyFor(node, name);
			}

			public void map(CSProperty property) {
				if (!CSharpBuilder.this.isGetter(node))
					mapImplicitSetterParameter(node, property);
				mapMetaMemberAttributes(node, property);
				mapParameters(node, property);
			}

			public void document(CSProperty member) {

			}

			public void fixup(CSProperty member) {

			}

			public void mapBody(CSProperty property) {
				final CSBlock block = CSharpBuilder.this.mapBody(node);

				if (isGetter()) {
					property.getter(block);
				} else {
					property.setter(block);
				}
			}
		});
	}

	private CSProperty findProperty(MethodDeclaration node, final String name) {
		CSMember existingProperty = _currentType.getMember(name);
		if (existingProperty != null) {
			if (!(existingProperty instanceof CSProperty)) {
				throw new IllegalArgumentException(sourceInformation(node)
						+ ": Previously declared member redeclared as property.");
			}
		}
		return (CSProperty) existingProperty;
	}

	@Override
	public boolean visit(AssertStatement node) {
		// Ignore
		return false;
	}

	private void mapImplicitSetterParameter(MethodDeclaration node, CSProperty property) {
		final String parameterName = parameter(node, 0).getName().toString();
		if (parameterName.equals("value")) {
			return;
		}

		property.setter().addStatement(
				0,
				newVariableDeclarationExpression(parameterName, property.type(),
						new CSReferenceExpression("value")));
	}

	private CSDeclarationExpression newVariableDeclarationExpression(final String name,
			final CSTypeReferenceExpression type, final CSReferenceExpression initializer) {
		return new CSDeclarationExpression(
				new CSVariableDeclaration(name, type, initializer));
	}

	private CSProperty newPropertyFor(MethodDeclaration node, final String propName) {
		final CSTypeReferenceExpression propertyType = isGetter(node)
				? mappedReturnType(node)
						: mappedTypeReference(lastParameter(node).getType());
				CSProperty p = new CSProperty(propName, propertyType);
				return p;
	}

	private CSBlock mapBody(MethodDeclaration node) {
		final CSBlock block = new CSBlock();
		processBlock(node, node.getBody(), block);
		return block;
	}

	private boolean isGetter(MethodDeclaration node) {
		return !"void".equals(node.getReturnType2().toString());
	}

	private SingleVariableDeclaration lastParameter(MethodDeclaration node) {
		return parameter(node, node.parameters().size() - 1);
	}

	private String propertyName(MethodDeclaration node) {
		return my(Annotations.class).annotatedPropertyName(node);
	}

	private String propertyName(IMethodBinding binding) {
		return propertyName(declaringNode(binding));
	}

	private boolean isProperty(MethodDeclaration node) {
		return isTaggedAsProperty(node)
				|| isMappedToProperty(node);
	}

	private boolean isTaggedAsProperty(MethodDeclaration node) {
		return isTaggedDeclaration(node, SharpenAnnotations.SHARPEN_PROPERTY);
	}

	private boolean isTaggedDeclaration(MethodDeclaration node, final String tag) {
		return effectiveAnnotationFor(node, tag) != null;
	}

	private void cleanBaseSetupCalls(CSMethod method) {
		ArrayList<CSStatement> toDelete = new ArrayList<CSStatement>();
		for (CSStatement st : method.body().statements()) {
			if (st instanceof CSExpressionStatement) {
				CSExpressionStatement es = (CSExpressionStatement) st;
				if (es.expression() instanceof CSMethodInvocationExpression) {
					CSMethodInvocationExpression mie = (CSMethodInvocationExpression) es
							.expression();
					if (mie.expression() instanceof CSMemberReferenceExpression) {
						CSMemberReferenceExpression mr = (CSMemberReferenceExpression) mie
								.expression();
						if ((mr.expression() instanceof CSBaseExpression)
								&& (mr.name().equals("SetUp") || mr.name().equals(
										"TearDown")))
							toDelete.add(st);
					}
				}
			}
		}
		for (CSStatement st : toDelete)
			method.body().removeStatement(st);
	}

	protected CSMethodBase processMethodDeclaration(final MethodDeclaration node) {

		final IMethodBinding binding = node.resolveBinding();

		final ASTNode parent = node.getParent();
		final ITypeBinding declaringType;
		if (parent instanceof TypeDeclaration) {
			declaringType = ((TypeDeclaration) parent).resolveBinding();
		} else if (parent instanceof AnonymousClassDeclaration) {
			declaringType = ((AnonymousClassDeclaration) parent).resolveBinding();
		} else {
			declaringType = null;
		}

		_currentWildcardParams = new HashMap<ITypeBinding, String>();

		CSMethodBase method = my(CSharpDriver.class).processMethodDeclaration(this, _currentType, node,
				new IMethodBuilderDelegate() {

			public ITypeBinding getDeclaringType() {
				return declaringType;
			}

			public IMethodBinding getBaseMethod(boolean overrideOnly, boolean allowStatic) {
				return CSharpBuilder.this.getBaseMethod(binding, overrideOnly,
						allowStatic);
			}

			public CSMethodBase create() {
				if (isDestructor(node))
					return new CSDestructor();

				if (node.isConstructor())
					return new CSConstructor();

				final String name = mappedMethodDeclarationName(node);

				CSMethod method = new CSMethod(name);
				method.returnType(mappedReturnType(node));
				method.modifier(mapMethodModifier(node));
				mapTypeParameters(node.typeParameters(), method);
				return method;
			}

			public void map(CSMethodBase method) {
				method.startPosition(node.getStartPosition());
				method.isVarArgs(node.isVarargs());
				mapParameters(node, method);
				mapAnnotations(node, method);
			}

			public void mapBody(CSMethodBase method) {
				visitBodyDeclarationBlock(node, node.getBody(), method);
			}

			public void document(CSMethodBase method) {
				CSharpBuilder.this.mapDocumentation(node, method);
			}

			public void fixup(CSMethodBase method) {
				CSharpBuilder.this.fixupMethod(node, method);
			}

			public void fixup(CSTypeDeclaration parent, CSMethodBase method) {
				if (method instanceof CSMethod)
					CSharpBuilder.this.fixupMethod(node, parent, (CSMethod) method);
			}
		});

		_currentWildcardParams = null;

		return method;
	}

	private CSVisibility mapVisibility(IMethodBinding binding) {
		CSVisibility vis = my(CSharpDriver.class).mapVisibility(binding);
		if (vis != null)
			return vis;

		IMethodBinding overriden = getBaseMethod(binding, false, false);
		if (overriden != null) {
			vis = mapVisibility(overriden);
			if (vis == CSVisibility.ProtectedInternal && !overriden.getDeclaringClass().isFromSource())
				vis = CSVisibility.Protected;
			return vis;
		} else if (binding.getDeclaringClass().isInterface()) {
			return CSVisibility.Public;
		}

		vis = mapVisibility(binding.getModifiers());

		final ITypeBinding declaringClass = binding.getDeclaringClass();
		final boolean isNestedPrivate = declaringClass.isNested()
				&& Modifier.isPrivate(declaringClass.getModifiers());

		final IMethodBinding declaration = binding.getMethodDeclaration();

		if (!isNestedPrivate) {
			if (containsNonPublicTypes(declaration, true)) {
				vis = CSVisibility.Private;
			} else if (containsNonPublicTypes(declaration, false))
				vis = CSVisibility.Internal;
		} else {
			if (vis == CSVisibility.Private)
				vis = CSVisibility.Internal;
		}

		return vis;
	}

	private void fixupMethod(MethodDeclaration node, CSMethodBase method) {
		final IMethodBinding binding = node.resolveBinding();

		method.visibility(mapVisibility(binding));

		if (method instanceof CSMethod)
			fixupMethod(node, (CSMethod) method);
	}

	private void fixupMethod(MethodDeclaration node, CSMethod method) {
		final IMethodBinding binding = node.resolveBinding();

		final ITypeBinding declaringClass = binding.getDeclaringClass();

		IMethodBinding overriden = getBaseMethod(binding, true, true);
		ITypeBinding interfaceImpl = null;

		if (overriden != null) {
			if (Modifier.isStatic(binding.getModifiers())) {
				method.setNewModifier(true);
			} else if (Modifier.isPrivate(overriden.getModifiers())) {
				method.setNewModifier(true);
				if (method.modifier() == CSMethodModifier.Override)
					method.modifier(CSMethodModifier.None);
			} else {
				ITypeBinding declaringType = overriden.getDeclaringClass();
				String overrideName = BindingUtils.qualifiedName(declaringType);

				if (declaringType.isInterface())
					interfaceImpl = declaringType;
				else {
					CSAttribute attr = new CSAttribute("Sharpen.OverridesMethod");
					attr.addArgument(new CSStringLiteralExpression(
							toLiteralStringForm(overrideName)));
					method.addAttribute(attr);
				}
			}
		}

		if ((interfaceImpl == null) && !declaringClass.isInterface()) {
			overriden = getBaseMethod(binding, false, false);
			if (overriden != null)
				interfaceImpl = overriden.getDeclaringClass();
		}

		if ((interfaceImpl != null) && interfaceImpl.isInterface()) {
			ITypeBinding parentType = null;
			ASTNode parent = node.getParent();
			if (parent instanceof TypeDeclaration)
				parentType = ((TypeDeclaration) parent).resolveBinding();
			else if (parent instanceof AnonymousClassDeclaration)
				parentType = ((AnonymousClassDeclaration) parent).resolveBinding();
			if (parentType != null)
				parentType = parentType.getSuperclass();
			if (Modifier.isAbstract(node.getModifiers())) {
				if (BindingUtils.findInterfaceInClassHierarchy(interfaceImpl, parentType))
					method.modifier(CSMethodModifier.AbstractOverride);
				else
					method.modifier(CSMethodModifier.Abstract);
			} else {
				if (BindingUtils.findInterfaceInClassHierarchy(interfaceImpl, parentType))
					method.modifier(CSMethodModifier.Override);
				else if (_currentType.isSealed())
					method.modifier(CSMethodModifier.None);
				else
					method.modifier(CSMethodModifier.Virtual);
			}
			CSAttribute attr = new CSAttribute("Sharpen.ImplementsInterface");
			String overrideName = BindingUtils.qualifiedName(interfaceImpl);
			attr.addArgument(new CSStringLiteralExpression(toLiteralStringForm(overrideName)));
			method.addAttribute(attr);
		}

		if ((method.modifier() == CSMethodModifier.Virtual) && (method.visibility() == CSVisibility.Private))
			method.modifier(CSMethodModifier.None);

		if (_configuration.junitConversion() && isLegacyTestFixture(node.resolveBinding().getDeclaringClass())) {
			if (method.name().startsWith("Test") && method.visibility() == CSVisibility.Public)
				method.addAttribute(new CSAttribute("NUnit.Framework.Test"));
			if (isLegacyTestFixtureClass(node.resolveBinding().getDeclaringClass().getSuperclass())) {
				if (method.name().equals("SetUp")) {
					method.addAttribute(new CSAttribute("NUnit.Framework.SetUp"));
					method.modifier(CSMethodModifier.Virtual);
					cleanBaseSetupCalls(method);
				} else if (method.name().equals("TearDown")) {
					method.addAttribute(new CSAttribute("NUnit.Framework.TearDown"));
					method.modifier(CSMethodModifier.Virtual);
					cleanBaseSetupCalls(method);
				}
			}
		}
	}

	private void fixupMethod(MethodDeclaration node, CSTypeDeclaration typeDecl, CSMethod method) {
		final IMethodBinding binding = node.resolveBinding();
		final ITypeBinding returnType = binding.getReturnType();

		if ((returnType == null) || binding.getDeclaringClass().isInterface())
			return;

		for (final ITypeBinding iface : BindingUtils.getAllInterfaces(binding.getDeclaringClass())) {
			IMethodBinding ifaceMethod = BindingUtils.findOverriddenMethodInType(iface, binding);
			if (ifaceMethod == null)
				continue;

			ITypeBinding ifaceReturnType = ifaceMethod.getReturnType();
			if (!returnType.equals(ifaceReturnType)) {
				CSMethod proxy = createInterfaceProxy(node, method, ifaceMethod);
				typeDecl.addMember(proxy);
			}
		}
	}

	private CSMethod createInterfaceProxy(MethodDeclaration node, CSMethod method, IMethodBinding ifaceMethod) {
		final IMethodBinding binding = node.resolveBinding();
		final ITypeBinding returnType = binding.getReturnType();
		final ITypeBinding ifaceReturnType = ifaceMethod.getReturnType();

		CSTypeReferenceExpression ifaceName = mappedTypeReference(ifaceMethod.getDeclaringClass());
		CSMethod proxy = new CSMethod(ifaceName.getTypeName() + '.' + ifaceMethod.getName());
		proxy.visibility(CSVisibility.Private);
		proxy.modifier(CSMethodModifier.None);
		proxy.returnType(mappedTypeReference(ifaceMethod.getReturnType()));
		mapTypeParameters(node.typeParameters(), proxy);
		mapParameters(node, proxy);

		CSAttribute attr = new CSAttribute("Sharpen.Proxy");
		proxy.addAttribute(attr);

		CSExpression name = new CSReferenceExpression(method.name());
		CSMethodInvocationExpression mie = new CSMethodInvocationExpression(name);
		for (CSVariableDeclaration param : proxy.parameters())
			mie.addArgument(new CSReferenceExpression(param.name()));
		for (CSTypeParameter param : proxy.typeParameters())
			mie.addTypeArgument(new CSTypeReference(param.name()));

		CSExpression retval = castIfNeeded(ifaceReturnType, returnType, mie);

		proxy.body().addStatement(new CSReturnStatement(-1, retval));
		return proxy;
	}

	protected void processMethodBody(MethodDeclaration node, CSMethodBase method) {
		visitBodyDeclarationBlock(node, node.getBody(), method);
	}

	private String mappedMethodDeclarationName(MethodDeclaration node) {
		final IMethodBinding binding = node.resolveBinding();
		final IMethodBinding baseMethod = getBaseMethod(binding, false, false);

		String mappedName;
		if (baseMethod != null)
			mappedName = mappedMethodName(baseMethod);
		else
			mappedName = mappedMethodName(node);

		if (null == mappedName || 0 == mappedName.length() || mappedName.contains(".")) {
			return methodName(node.getName().toString());
		}
		return mappedName;
	}

	private void mapParameters(MethodDeclaration node, CSParameterized method) {
		if (method instanceof CSMethod) {
			mapMethodParameters(node, (CSMethod) method);
			return;
		}
		for (Object p : node.parameters()) {
			mapParameter((SingleVariableDeclaration) p, method);
		}
	}

	private void mapParameter(SingleVariableDeclaration parameter, CSParameterized method) {
		method.addParameter(createParameter(parameter));
	}

	ITypeBinding mapTypeParameterExtendedType(ITypeBinding tb) {
		ITypeBinding superc = tb.getSuperclass();
		if (superc != null && !superc.equals(_objectType)
				&& !superc.getQualifiedName().equals("java.lang.Enum<?>")) {
			return superc;
		}
		ITypeBinding[] ints = tb.getInterfaces();
		if (ints.length > 0)
			return ints[0];
		return null;
	}

	private void mapMethodParameters(MethodDeclaration node, CSMethod method) {
		final IMethodBinding methodBinding = node.resolveBinding();
		final IMethodBinding baseMethod = my(IBindingManager.class).getBaseMethod(methodBinding);
		final IMethodBinding baseOrThis = baseMethod != null ? baseMethod : methodBinding;
		final ITypeBinding[] baseTypes = baseMethod != null ? baseMethod.getParameterTypes() : null;

		int first = 0;
		final List<SingleVariableDeclaration> params = node.parameters();

		ITypeInfo typeInfo = my(IBindingManager.class).getTypeInfo(baseOrThis.getDeclaringClass());
		if ((typeInfo != null) && typeInfo.isEventInterface()) {
			IVariableBinding vb = params.get(0).resolveBinding();
			method.addParameter(createVariableDeclaration(vb, OBJECT_TYPE_REFERENCE, null));
			first = 1;
		}

		for (int i = first; i < params.size(); i++) {
			ITypeBinding baseType = !node.isVarargs() && (baseMethod != null) ? baseTypes[i] : null;
			mapMethodParameter(node, baseType, params.get(i), method);
		}
	}

	private void mapMethodParameter(MethodDeclaration node, ITypeBinding baseType, SingleVariableDeclaration p,
			CSMethod method) {
		final IMethodBinding methodBinding = node.resolveBinding();
		final ITypeBinding parameterType = p.getType().resolveBinding();
		final IVariableBinding vb = p.resolveBinding();
		final ITypeBinding[] ta = vb.getType().getTypeArguments();

		if (isGenericRuntimeParameterIdiom(methodBinding, parameterType)) {
			// System.Type <p.name> = typeof(<T>);
			CSTypeofExpression to = new CSTypeofExpression(genericRuntimeTypeIdiomType(parameterType));
			CSTypeReference str = new CSTypeReference("System.Type");
			CSVariableDeclaration vdecl = new CSVariableDeclaration(identifier(p.getName()), str, to);
			method.body().addStatement(new CSDeclarationStatement(p.getStartPosition(), vdecl));
			return;
		}

		final List<CSTypeReferenceExpression> args = new ArrayList<CSTypeReferenceExpression>();

		if (ta.length > 0)
			mapWildcardType(methodBinding, method, args, parameterType);
		else if (baseType != null)
			mapWildcardType(methodBinding, method, args, baseType);

		if (isJavaLangClass(parameterType) && (args.size() == 1)) {
			CSExpression typeof = new CSTypeofExpression(args.get(0));
			CSTypeReference str = new CSTypeReference("System.Type");
			CSVariableDeclaration vdecl = createVariableDeclaration(vb, str, typeof);
			method.body().addStatement(new CSDeclarationStatement(p.getStartPosition(), vdecl));
		} else if (args.size() > 0) {
			CSTypeReference tr = new CSTypeReference(mappedTypeName(parameterType.getTypeDeclaration()));
			for (CSTypeReferenceExpression arg : args)
				tr.addTypeArgument(arg);
			method.addParameter(createVariableDeclaration(vb, tr, null));
		} else {
			method.addParameter(createVariableDeclaration(vb, null));
		}
	}

	private void mapWildcardType(IMethodBinding binding, CSMethod method, List<CSTypeReferenceExpression> list,
			ITypeBinding type) {
		final ITypeBinding[] args = type.getTypeArguments();

		for (int i = 0; i < args.length; i++) {
			final ITypeBinding arg = args[i];
			if (!arg.isWildcardType()) {
				list.add(mappedTypeReference(arg));
				continue;
			}

			final ITypeBinding bound = arg.getBound();
			if (bound != null) {
				IMethodBinding boundDecl = bound.getDeclaringMethod();
				if ((boundDecl != null) && boundDecl.equals(binding)) {
					list.add(mappedTypeReference(bound));
					continue;
				}
			}

			final ITypeBinding extended = mapTypeParameterExtendedType(arg);
			String genericArg = "_T" + method.typeParameters().size();
			CSTypeParameter tp = new CSTypeParameter(genericArg);
			if (extended != null)
				tp.superClass(mappedTypeReference(extended));
			else if (bound != null) {
				list.add(mappedTypeReference(bound));
				continue;
			}
			method.addTypeParameter(tp);
			_currentWildcardParams.put(arg, genericArg);
			list.add(new CSTypeReference(genericArg));
		}
	}

	private CSTypeReferenceExpression genericRuntimeTypeIdiomType(ITypeBinding parameterType) {
		return mappedTypeReference(parameterType.getTypeArguments()[0]);
	}

	private boolean isGenericRuntimeParameterIdiom(IMethodBinding method, ITypeBinding parameterType) {
		if (!parameterType.isParameterizedType()) {
			return false;
		}
		if (!parameterType.getTypeDeclaration().equals(_classType)) {
			return false;
		}
		// detecting if the T in Class<T> comes from the method itself
		final ITypeBinding arg = parameterType.getTypeArguments()[0];
		final IMethodBinding decl = getTypeParameterDeclaringMethod(arg);
		return method.equals(decl);
	}

	private IMethodBinding getTypeParameterDeclaringMethod(ITypeBinding type) {
		if (type.isWildcardType()) {
			ITypeBinding bound = type.getBound();
			if (bound != null)
				return getTypeParameterDeclaringMethod(bound);
		}

		if (type.isArray())
			return getTypeParameterDeclaringMethod(type.getElementType());

		return type.getDeclaringMethod();
	}

	private CSTypeReferenceExpression mappedReturnType(MethodDeclaration node) {
		IMethodBinding overriden = getOverridedMethod(node);
		if (overriden != null)
			return mappedTypeReference(overriden.getReturnType());
		return mappedTypeReference(node.getReturnType2());
	}

	private void processEventDeclaration(MethodDeclaration node) {
		CSTypeReference eventHandlerType = new CSTypeReference(getEventHandlerTypeName(node));
		CSEvent event = createEventFromMethod(node, eventHandlerType);
		mapMetaMemberAttributes(node, event);
		if (_currentType.isInterface())
			return;

		VariableDeclarationFragment field = getEventBackingField(node);
		CSField backingField = (CSField) _currentType.getMember(field.getName().toString());
		backingField.type(eventHandlerType);

		// clean field
		backingField.initializer(null);
		backingField.removeModifier(CSFieldModifier.Readonly);

		final CSBlock addBlock = createEventBlock(backingField, "System.Delegate.Combine");
		String onAddMethod = getEventOnAddMethod(node);
		if (onAddMethod != null) {
			addBlock.addStatement(new CSMethodInvocationExpression(new CSReferenceExpression(onAddMethod)));
		}
		event.setAddBlock(addBlock);
		event.setRemoveBlock(createEventBlock(backingField, "System.Delegate.Remove"));
	}

	private String getEventOnAddMethod(MethodDeclaration node) {
		final TagElement onAddTag = javadocTagFor(node, SharpenAnnotations.SHARPEN_EVENT_ON_ADD);
		if (null == onAddTag)
			return null;
		return methodName(JavadocUtility.singleTextFragmentFrom(onAddTag));
	}

	private String getEventHandlerTypeName(MethodDeclaration node) {
		final String eventArgsType = getEventArgsType(node);
		return buildEventHandlerTypeName(node, eventArgsType);
	}

	private void mapMetaMemberAttributes(MethodDeclaration node, CSMetaMember metaMember) {
		final IMethodBinding binding = node.resolveBinding();
		metaMember.visibility(mapVisibility(binding));
		metaMember.modifier(mapMethodModifier(node));
		mapDocumentation(node, metaMember);
	}

	private CSBlock createEventBlock(CSField backingField, String delegateMethod) {
		CSBlock block = new CSBlock();
		block.addStatement(new CSInfixExpression("=", new CSReferenceExpression(backingField.name()),
				new CSCastExpression(backingField.type(), new CSMethodInvocationExpression(
						new CSReferenceExpression(
								delegateMethod), new CSReferenceExpression(backingField
										.name()), new CSReferenceExpression(
												"value")))));
		return block;
	}

	private static final class CheckVariableUseVisitor extends ASTVisitor {

		private final IVariableBinding _var;
		private boolean _used;

		private CheckVariableUseVisitor(IVariableBinding var) {
			this._var = var;
		}

		@Override
		public boolean visit(SimpleName name) {
			IBinding binding = name.resolveBinding();
			if (binding == null) {
				return false;
			}
			if (binding.equals(_var)) {
				_used = true;
			}

			return false;
		}

		public boolean used() {
			return _used;
		}
	}

	private static final class FieldAccessFinder extends ASTVisitor {
		public IBinding field;

		@Override
		public boolean visit(SimpleName node) {
			field = node.resolveBinding();
			return false;
		}
	}

	private VariableDeclarationFragment getEventBackingField(MethodDeclaration node) {
		FieldAccessFinder finder = new FieldAccessFinder();
		node.accept(finder);
		return findDeclaringNode(finder.field);
	}

	private CSEvent createEventFromMethod(MethodDeclaration node, CSTypeReference eventHandlerType) {
		String eventName = methodName(node);
		CSEvent event = new CSEvent(eventName, eventHandlerType);
		_currentType.addMember(event);
		return event;
	}

	private String methodName(MethodDeclaration node) {
		return methodName(node.getName().toString());
	}

	private String unqualifiedName(String typeName) {
		int index = typeName.lastIndexOf('.');
		if (index < 0)
			return typeName;
		return typeName.substring(index + 1);
	}

	private String buildEventHandlerTypeName(ASTNode node, String eventArgsTypeName) {
		if (!eventArgsTypeName.endsWith("EventArgs")) {
			warning(node, SharpenAnnotations.SHARPEN_EVENT + " type name must end with 'EventArgs'");
			return eventArgsTypeName + "EventHandler";
		}

		return "System.EventHandler<" + eventArgsTypeName + ">";
	}

	private String getEventArgsType(MethodDeclaration node) {
		TagElement tag = eventTagFor(node);
		if (null == tag)
			return null;
		return mappedTypeName(JavadocUtility.singleTextFragmentFrom(tag));
	}

	private TagElement eventTagFor(MethodDeclaration node) {
		return effectiveAnnotationFor(node, SharpenAnnotations.SHARPEN_EVENT);
	}

	private TagElement effectiveAnnotationFor(MethodDeclaration node, final String annotation) {
		return my(Annotations.class).effectiveAnnotationFor(node, annotation);
	}

	private <T extends ASTNode> T findDeclaringNode(IBinding binding) {
		return (T) my(Bindings.class).findDeclaringNode(binding);
	}

	private void visitBodyDeclarationBlock(BodyDeclaration node, Block block, CSMethodBase method) {
		visitBodyDeclarationBlock(node, block, method, method.body());
	}

	private void visitBodyDeclarationBlock(BodyDeclaration node, Block block, CSMethodBase method, CSBlock body) {
		CSMethodBase saved = _currentMethod;
		_currentMethod = method;

		processDisableTags(node, method);
		processBlock(node, block, body);

		_currentMethod = saved;
	}

	private void processDisableTags(PackageDeclaration packageDeclaration, CSNode csNode) {
		TagElement tag = javadocTagFor(packageDeclaration, SharpenAnnotations.SHARPEN_IF);
		if (null == tag)
			return;

		csNode.addEnclosingIfDef(JavadocUtility.singleTextFragmentFrom(tag));
	}

	private void processDisableTags(BodyDeclaration node, CSNode csNode) {
		TagElement tag = javadocTagFor(node, SharpenAnnotations.SHARPEN_IF);
		if (null == tag)
			return;

		csNode.addEnclosingIfDef(JavadocUtility.singleTextFragmentFrom(tag));
	}

	private void processBlock(BodyDeclaration node, Block block, final CSBlock targetBlock) {
		if (containsJavadoc(node, SharpenAnnotations.SHARPEN_REMOVE_FIRST)) {
			block.statements().remove(0);
		}

		BodyDeclaration savedDeclaration = _currentBodyDeclaration;
		_currentBodyDeclaration = node;

		if (Modifier.isSynchronized(node.getModifiers())) {
			CSLockStatement lock = new CSLockStatement(node.getStartPosition(), getLockTarget(node));
			targetBlock.addStatement(lock);
			visitBlock(lock.body(), block);
		} else {
			visitBlock(targetBlock, block);
		}
		_currentBodyDeclaration = savedDeclaration;
	}

	private CSExpression getLockTarget(BodyDeclaration node) {
		return Modifier.isStatic(node.getModifiers()) ? new CSTypeofExpression(new CSTypeReference(
				_currentType.name()))
		: new CSThisExpression();
	}

	@Override
	public boolean visit(ConstructorInvocation node) {
		addChainedConstructorInvocation(new CSThisExpression(), node.arguments(),
				node.resolveConstructorBinding());
		return false;
	}

	private void addChainedConstructorInvocation(CSExpression target, List arguments, IMethodBinding binding) {
		CSConstructorInvocationExpression cie = mapChainedConstructorInvocation(target, arguments, binding);
		((CSConstructor) _currentMethod).chainedConstructorInvocation(cie);
	}

	public CSConstructorInvocationExpression mapChainedConstructorInvocation(CSExpression target, List args,
			IMethodBinding binding) {
		CSConstructorInvocationExpression cie = new CSConstructorInvocationExpression(target);
		mapArguments(cie, args, binding);
		return cie;
	}

	@Override
	public boolean visit(SuperConstructorInvocation node) {
		if (null != node.getExpression()) {
			notImplemented(node);
		}
		addChainedConstructorInvocation(new CSBaseExpression(), node.arguments(),
				node.resolveConstructorBinding());
		return false;
	}

	private <T extends ASTNode> void visitBlock(CSBlock block, T node) {
		if (null == node) {
			return;
		}

		CSBlock saved = _currentBlock;
		_currentBlock = block;

		_currentContinueLabel = null;

		node.accept(this);
		_currentBlock = saved;
	}

	@Override
	public boolean visit(VariableDeclarationExpression node) {
		pushExpression(new CSDeclarationExpression(createVariableDeclaration((VariableDeclarationFragment) node
				.fragments().get(0))));
		return false;
	}

	@Override
	public boolean visit(VariableDeclarationStatement node) {
		for (Object f : node.fragments()) {
			VariableDeclarationFragment variable = (VariableDeclarationFragment) f;
			addStatement(new CSDeclarationStatement(node.getStartPosition(),
					createVariableDeclaration(variable)));
		}
		return false;
	}

	private CSVariableDeclaration createVariableDeclaration(VariableDeclarationFragment variable) {
		final IVariableBinding binding = variable.resolveBinding();
		final ITypeBinding type = binding.getType();

		final Expression initializer = variable.getInitializer();
		if (initializer == null)
			return createVariableDeclaration(binding, null);

		if (isZeroLiteral(initializer)) {
			CSExpression nullPointer = my(CSharpDriver.class).mappedNullPointer(binding);
			if (nullPointer != null)
				return createVariableDeclaration(binding, nullPointer);
		}

		final ITypeBinding initType = initializer.resolveTypeBinding();

		ITypeBinding expected = type;
		if (isGenericInstance(initType)) {
			ITypeBinding underlyingLeftType = getUnderlyingGenericType(type);
			ITypeBinding underlyingRightType = getUnderlyingGenericType(initType);
			if ((underlyingLeftType != null) && underlyingLeftType.equals(underlyingRightType))
				expected = initType;
		}

		pushExpectedType(expected);

		CSExpression mapped = mapExpression(type, initializer);
		CSVariableDeclaration vdecl = createVariableDeclaration(binding, mapped);

		popExpectedType();
		return vdecl;
	}

	public static boolean isZeroLiteral(Expression expr) {
		if (expr instanceof NumberLiteral) {
			NumberLiteral literal = (NumberLiteral) expr;
			Object value = literal.resolveConstantExpressionValue();
			return value.equals(0);
		}

		if (expr instanceof NullLiteral)
			return true;

		return false;
	}

	private CSVariableDeclaration createVariableDeclaration(IVariableBinding binding, CSExpression initializer) {
		CSTypeReferenceExpression type = mappedVariableType(binding);
		return createVariableDeclaration(binding, type, initializer);
	}

	private CSVariableDeclaration createVariableDeclaration(IVariableBinding binding,
			CSTypeReferenceExpression type, CSExpression initializer) {
		String name = my(CSharpDriver.class).mappedVariableName(binding);
		if (name == null)
			name = binding.getName();
		return new CSVariableDeclaration(identifier(name), type, initializer);
	}

	@Override
	public boolean visit(ExpressionStatement node) {
		if (isRemovedMethodInvocation(node.getExpression())) {
			return false;
		}

		addStatement(new CSExpressionStatement(node.getStartPosition(), mapExpression(node.getExpression())));
		return false;
	}

	private boolean isRemovedMethodInvocation(Expression expression) {
		if (!(expression instanceof MethodInvocation)) {
			return false;
		}

		MethodInvocation invocation = (MethodInvocation) expression;
		return isTaggedMethodInvocation(invocation, SharpenAnnotations.SHARPEN_REMOVE)
				|| isRemoved(invocation.resolveMethodBinding());

	}

	public boolean isEnumOrdinalMethodInvocation(MethodInvocation node) {
		return node.getName().getIdentifier().equals("ordinal") &&
				node.getExpression() != null &&
				node.getExpression().resolveTypeBinding().isEnum();
	}

	public boolean isEnumNameMethodInvocation(MethodInvocation node) {
		return node.getName().getIdentifier().equals("name") &&
				node.getExpression() != null &&
				node.getExpression().resolveTypeBinding().isEnum();
	}

	public boolean isEnumValuesMethodInvocation(MethodInvocation node) {
		return node.getName().getIdentifier().equals("values") &&
				node.getExpression() != null &&
				node.getExpression().resolveTypeBinding().isEnum();
	}

	@Override
	public boolean visit(IfStatement node) {
		Expression expression = node.getExpression();

		Object constValue = constValue(expression);
		if (null != constValue) {
			// dead branch elimination
			if (isTrue(constValue)) {
				node.getThenStatement().accept(this);
			} else {
				if (null != node.getElseStatement()) {
					node.getElseStatement().accept(this);
				}
			}
		} else {
			CSIfStatement stmt = new CSIfStatement(node.getStartPosition(), mapExpression(expression));
			visitBlock(stmt.trueBlock(), node.getThenStatement());
			visitBlock(stmt.falseBlock(), node.getElseStatement());
			addStatement(stmt);
		}
		return false;
	}

	private boolean isTrue(Object constValue) {
		return ((Boolean) constValue).booleanValue();
	}

	private Object constValue(Expression expression) {
		switch (expression.getNodeType()) {
		case ASTNode.PREFIX_EXPRESSION:
			return constValue((PrefixExpression) expression);
		case ASTNode.SIMPLE_NAME:
		case ASTNode.QUALIFIED_NAME:
			return constValue((Name) expression);
		}
		return null;
	}

	public Object constValue(PrefixExpression expression) {
		if (PrefixExpression.Operator.NOT == expression.getOperator()) {
			Object value = constValue(expression.getOperand());
			if (null != value) {
				return isTrue(value) ? Boolean.FALSE : Boolean.TRUE;
			}
		}
		return null;
	}

	public Object constValue(Name expression) {
		IBinding binding = expression.resolveBinding();
		if (IBinding.VARIABLE == binding.getKind()) {
			return ((IVariableBinding) binding).getConstantValue();
		}
		return null;
	}

	@Override
	public boolean visit(final WhileStatement node) {
		consumeContinueLabel(new Function<CSBlock>() {
			public CSBlock apply() {
				CSWhileStatement stmt = new CSWhileStatement(node.getStartPosition(),
						mapExpression(node.getExpression()));
				visitBlock(stmt.body(), node.getBody());
				addStatement(stmt);
				return stmt.body();
			}
		});
		return false;
	}

	@Override
	public boolean visit(final DoStatement node) {
		consumeContinueLabel(new Function<CSBlock>() {
			public CSBlock apply() {
				CSDoStatement stmt = new CSDoStatement(node.getStartPosition(),
						mapExpression(node.getExpression()));
				visitBlock(stmt.body(), node.getBody());
				addStatement(stmt);
				return stmt.body();
			}
		});
		return false;
	}

	@Override
	public boolean visit(TryStatement node) {
		CSTryStatement stmt = new CSTryStatement(node.getStartPosition());
		visitBlock(stmt.body(), node.getBody());
		for (Object o : node.catchClauses()) {
			CatchClause clause = (CatchClause) o;
			if (!_configuration.isIgnoredExceptionType(qualifiedName(clause.getException().getType()
					.resolveBinding()))) {
				stmt.addCatchClause(mapCatchClause(clause));
			}
		}
		if (null != node.getFinally()) {
			CSBlock finallyBlock = new CSBlock();
			visitBlock(finallyBlock, node.getFinally());
			stmt.finallyBlock(finallyBlock);
		}

		if (null != stmt.finallyBlock() || !stmt.catchClauses().isEmpty()) {

			addStatement(stmt);
		} else {

			_currentBlock.addAll(stmt.body());
		}
		return false;
	}

	private CSCatchClause mapCatchClause(CatchClause node) {
		IVariableBinding oldExceptionVariable = _currentExceptionVariable;
		_currentExceptionVariable = node.getException().resolveBinding();
		try {
			CheckVariableUseVisitor check = new CheckVariableUseVisitor(_currentExceptionVariable);
			node.getBody().accept(check);

			CSCatchClause clause;
			if (isEmptyCatch(node, check)) {
				clause = new CSCatchClause();
			} else {
				clause = new CSCatchClause(createVariableDeclaration(_currentExceptionVariable, null));
			}
			clause.anonymous(!check.used());
			visitBlock(clause.body(), node.getBody());
			return clause;
		} finally {
			_currentExceptionVariable = oldExceptionVariable;
		}
	}

	private boolean isEmptyCatch(CatchClause clause, CheckVariableUseVisitor check) {
		if (check.used())
			return false;
		return isThrowable(clause.getException().resolveBinding().getType());
	}

	private boolean isThrowable(ITypeBinding declaringClass) {
		return "java.lang.Throwable".equals(qualifiedName(declaringClass));
	}

	@Override
	public boolean visit(ThrowStatement node) {
		addStatement(mapThrowStatement(node));
		return false;
	}

	private CSThrowStatement mapThrowStatement(ThrowStatement node) {
		Expression exception = node.getExpression();
		if (isCurrentExceptionVariable(exception)) {
			return new CSThrowStatement(node.getStartPosition(), null);
		}
		return new CSThrowStatement(node.getStartPosition(), mapExpression(exception));
	}

	private boolean isCurrentExceptionVariable(Expression exception) {
		if (!(exception instanceof SimpleName)) {
			return false;
		}
		return ((SimpleName) exception).resolveBinding() == _currentExceptionVariable;
	}

	@Override
	public boolean visit(BreakStatement node) {
		SimpleName labelName = node.getLabel();
		if (labelName != null) {
			addStatement(new CSGotoStatement(node.getStartPosition(), breakLabel(labelName.getIdentifier())));
			return false;
		}
		addStatement(new CSBreakStatement(node.getStartPosition()));
		return false;
	}

	@Override
	public boolean visit(ContinueStatement node) {
		SimpleName labelName = node.getLabel();
		if (labelName != null) {
			addStatement(new CSGotoStatement(node.getStartPosition(),
					continueLabel(labelName.getIdentifier())));
			return false;
		}
		addStatement(new CSContinueStatement(node.getStartPosition()));
		return false;
	}

	@Override
	public boolean visit(SynchronizedStatement node) {
		CSLockStatement stmt = new CSLockStatement(node.getStartPosition(), mapExpression(node.getExpression()));
		visitBlock(stmt.body(), node.getBody());
		addStatement(stmt);
		return false;
	}

	@Override
	public boolean visit(ReturnStatement node) {
		CSExpression expr;
		IMethodBinding binding = currentMethodBinding();
		if (binding != null)
			expr = mapExpression(binding.getReturnType(), node.getExpression());
		else
			expr = mapExpression(node.getExpression());
		addStatement(new CSReturnStatement(node.getStartPosition(), expr));
		return false;
	}

	@Override
	public boolean visit(NumberLiteral node) {

		String token = node.getToken();
		CSExpression literal = new CSNumberLiteralExpression(token);

		if (expectingType("byte") && token.startsWith("-")) {
			literal = uncheckedCast("byte", literal);
		}
		else if (token.startsWith("0x")) {
			if (token.endsWith("l") || token.endsWith("L")) {
				literal = uncheckedCast("long", literal);
			} else {
				literal = uncheckedCast("int", literal);
			}

		} else if (token.startsWith("0") && token.indexOf('.') == -1
				&& Character.isDigit(token.charAt(token.length() - 1))) {
			try {
				int n = Integer.parseInt(token, 8);
				if (n != 0)
					literal = new CSNumberLiteralExpression("0x" + Integer.toHexString(n));
			} catch (NumberFormatException ex) {
			}
		} else if (token.endsWith(".f")) {
			literal = new CSNumberLiteralExpression(token.substring(0, token.length() - 2) + ".0f");
		}

		pushExpression(literal);
		return false;
	}

	private CSUncheckedExpression uncheckedCast(String type, CSExpression expression) {
		return new CSUncheckedExpression(new CSCastExpression(new CSTypeReference(type),
				new CSParenthesizedExpression(
						expression)));
	}

	@Override
	public boolean visit(StringLiteral node) {
		String value = node.getLiteralValue();
		if (value != null && value.length() == 0) {
			pushExpression(new CSReferenceExpression("string.Empty"));
		} else {
			pushExpression(new CSStringLiteralExpression(fixEscapedNumbers(node.getEscapedValue())));
		}
		return false;
	}

	String fixEscapedNumbers(String literal) {
		StringBuffer s = new StringBuffer();
		for (int n = 0; n < literal.length(); n++) {
			if (literal.charAt(n) == '\\') {
				int i = n + 1;
				if (i < literal.length() && literal.charAt(i) == '\\') {
					s.append("\\\\");
					n = i;
					continue;
				}
				while (i < literal.length() && Character.isDigit(literal.charAt(i)))
					i++;
				if (i != n + 1) {
					int num = Integer.parseInt(literal.substring(n + 1, i));
					s.append("\\x" + Integer.toHexString(num));
					n = i - 1;
					continue;
				}
			}
			s.append(literal.charAt(n));
		}
		return s.toString();
	}

	@Override
	public boolean visit(CharacterLiteral node) {
		CSExpression expr = new CSCharLiteralExpression(node.getEscapedValue());
		if (expectingType("byte")) {
			expr = new CSCastExpression(new CSTypeReference("byte"), new CSParenthesizedExpression(
					expr));
		}
		pushExpression(expr);
		return false;
	}

	private boolean expectingType(String name) {
		ITypeBinding expected = getExpectedType();
		return (expected != null && expected.getName().equals(name));
	}

	@Override
	public boolean visit(NullLiteral node) {
		pushExpression(new CSNullLiteralExpression());
		return false;
	}

	@Override
	public boolean visit(BooleanLiteral node) {
		pushExpression(new CSBoolLiteralExpression(node.booleanValue()));
		return false;
	}

	@Override
	public boolean visit(ThisExpression node) {
		pushExpression(new CSThisExpression());
		return false;
	}

	@Override
	public boolean visit(ArrayAccess node) {
		pushExpression(new CSIndexedExpression(mapExpression(node.getArray()), mapExpression(node.getIndex())));
		return false;
	}

	@Override
	public boolean visit(ArrayCreation node) {
		ITypeBinding expected = getExpectedType();
		if ((expected != null) && expected.isArray())
			pushExpectedType(expected.getElementType());
		else
			pushExpectedType(node.getType().getElementType().resolveBinding());
		if (node.dimensions().size() > 1) {
			if (null != node.getInitializer()) {
				notImplemented(node);
			}
			pushExpression(unfoldMultiArrayCreation(node));
		} else {
			pushExpression(mapSingleArrayCreation(node));
		}
		popExpectedType();
		return false;
	}

	/**
	 * Unfolds java multi array creation shortcut "new String[2][3][2]" into
	 * explicitly array creation "new string[][][] { new string[][] { new
	 * string[2], new string[2], new string[2] }, new string[][] { new
	 * string[2], new string[2], new string[2] } }"
	 */
	private CSArrayCreationExpression unfoldMultiArrayCreation(ArrayCreation node) {
		return unfoldMultiArray((ArrayType) node.getType().getComponentType(), node.dimensions(), 0);
	}

	private CSArrayCreationExpression unfoldMultiArray(ArrayType type, List dimensions, int dimensionIndex) {
		final CSArrayCreationExpression expression = new CSArrayCreationExpression(mappedTypeReference(type));
		expression.initializer(new CSArrayInitializerExpression());
		int length = resolveIntValue(dimensions.get(dimensionIndex));
		if (dimensionIndex < lastIndex(dimensions) - 1) {
			for (int i = 0; i < length; ++i) {
				expression.initializer().addExpression(
						unfoldMultiArray((ArrayType) type.getComponentType(), dimensions,
								dimensionIndex + 1));
			}
		} else {
			Expression innerLength = (Expression) dimensions.get(dimensionIndex + 1);
			CSTypeReferenceExpression innerType = mappedTypeReference(type.getComponentType());
			for (int i = 0; i < length; ++i) {
				expression.initializer().addExpression(
						new CSArrayCreationExpression(innerType, mapExpression(innerLength)));
			}
		}
		return expression;
	}

	private int lastIndex(List<?> dimensions) {
		return dimensions.size() - 1;
	}

	private int resolveIntValue(Object expression) {
		return ((Number) ((Expression) expression).resolveConstantExpressionValue()).intValue();
	}

	private CSArrayCreationExpression mapSingleArrayCreation(ArrayCreation node) {
		CSArrayCreationExpression expression = new CSArrayCreationExpression(
				mappedTypeReference(componentType(node
						.getType())));
		if (!node.dimensions().isEmpty()) {
			expression.length(mapExpression((Expression) node.dimensions().get(0)));
		}
		expression.initializer(mapArrayInitializer(node));
		return expression;
	}

	private CSArrayInitializerExpression mapArrayInitializer(ArrayCreation node) {
		return (CSArrayInitializerExpression) mapExpression(node.getInitializer());
	}

	@Override
	public boolean visit(ArrayInitializer node) {
		if (isImplicitelyTypedArrayInitializer(node)) {
			CSArrayCreationExpression ace = new CSArrayCreationExpression(mappedTypeReference(node
					.resolveTypeBinding()
					.getComponentType()));
			pushExpectedType(node.resolveTypeBinding().getElementType());
			ace.initializer(mapArrayInitializer(node));
			popExpectedType();
			pushExpression(ace);
			return false;
		}

		pushExpression(mapArrayInitializer(node));
		return false;
	}

	private CSArrayInitializerExpression mapArrayInitializer(ArrayInitializer node) {
		CSArrayInitializerExpression initializer = new CSArrayInitializerExpression();
		for (Object e : node.expressions()) {
			initializer.addExpression(mapExpression((Expression) e));
		}
		return initializer;
	}

	private boolean isImplicitelyTypedArrayInitializer(ArrayInitializer node) {
		return !(node.getParent() instanceof ArrayCreation);
	}

	public ITypeBinding componentType(ArrayType type) {
		return type.getComponentType().resolveBinding();
	}

	private boolean isIterableType(ITypeBinding type) {
		final String fullName = BindingUtils.qualifiedName(type);
		if (_configuration.typeHasMapping(fullName))
			return false;
		if (fullName.equals("java.lang.Iterable"))
			return true;
		for (ITypeBinding iface : type.getInterfaces()) {
			if (isIterableType(iface))
				return true;
		}

		ITypeBinding parent = type.getSuperclass();
		if (parent != null)
			return isIterableType(parent);

		return false;
	}

	@Override
	public boolean visit(EnhancedForStatement node) {
		Expression expr = node.getExpression();
		ITypeBinding exprType = expr.resolveTypeBinding();

		CSExpression mappedExpr = mapExpression(expr);
		if (isIterableType(exprType)) {
			CSReferenceExpression proxy = new CSReferenceExpression("Sharpen.IterableProxy.Create");
			CSMethodInvocationExpression cie = new CSMethodInvocationExpression(proxy);
			cie.addArgument(mappedExpr);
			mappedExpr = cie;
		}

		CSForEachStatement stmt = new CSForEachStatement(node.getStartPosition(), mappedExpr);
		stmt.variable(createParameter(node.getParameter()));
		visitBlock(stmt.body(), node.getBody());
		addStatement(stmt);
		return false;
	}

	@Override
	public boolean visit(final ForStatement node) {
		consumeContinueLabel(new Function<CSBlock>() {
			public CSBlock apply() {
				List<CSExpression> initializers = new ArrayList<CSExpression>();
				int count = 0;
				for (final Object i : node.initializers()) {
					if (i instanceof VariableDeclarationExpression) {
						VariableDeclarationExpression vde = (VariableDeclarationExpression) i;
						count += vde.fragments().size();
					}
				}
				CSBlock declBlock = null;
				if (count > 0)
					declBlock = new CSBlock();
				for (final Object i : node.initializers()) {
					if (!(i instanceof VariableDeclarationExpression)) {
						initializers.add(mapExpression((Expression) i));
						continue;
					}
					VariableDeclarationExpression vde = (VariableDeclarationExpression) i;
					for (final Object f : vde.fragments()) {
						VariableDeclarationFragment fragment = (VariableDeclarationFragment) f;
						CSVariableDeclaration decl = createVariableDeclaration(fragment);
						CSDeclarationExpression expr = new CSDeclarationExpression(decl);
						if (count > 1)
							declBlock.addStatement(new CSExpressionStatement(-1, expr));
						else
							initializers.add(expr);
					}
				}
				CSForStatement stmt = new CSForStatement(node.getStartPosition(),
						mapExpression(node.getExpression()));
				for (CSExpression i : initializers) {
					stmt.addInitializer(i);
				}
				for (Object u : node.updaters()) {
					stmt.addUpdater(mapExpression((Expression) u));
				}
				visitBlock(stmt.body(), node.getBody());
				if (declBlock != null) {
					declBlock.addStatement(stmt);
					addStatement(declBlock);
					return declBlock;
				} else {
					addStatement(stmt);
					return stmt.body();
				}
			}
		});
		return false;
	}

	private void consumeContinueLabel(Function<CSBlock> func) {
		CSLabelStatement label = _currentContinueLabel;
		_currentContinueLabel = null;
		CSBlock body = func.apply();
		if (label != null) {
			body.addStatement(label);
		}
	}

	@Override
	public boolean visit(SwitchStatement node) {
		_currentContinueLabel = null;
		CSBlock saved = _currentBlock;

		final ITypeBinding switchType = node.getExpression().resolveTypeBinding();

		final ITypeBinding effectiveSwitchType;
		final IExtractedEnumInfo eei = my(IBindingManager.class).getExtractedEnumInfo(switchType);
		if (eei != null)
			effectiveSwitchType = my(IBindingManager.class).getIntType();
		else
			effectiveSwitchType = switchType;

		pushExpectedType(effectiveSwitchType);
		CSExpression expression = mapExpression(node.getExpression());
		if (eei != null)
			expression = new CSMemberReferenceExpression(expression, eei.valueField());
		popExpectedType();

		CSSwitchStatement mappedNode = new CSSwitchStatement(node.getStartPosition(), expression);
		addStatement(mappedNode);

		CSCaseClause current = null;
		_currentBlock = null;
		for (ASTNode element : Types.<ASTNode> cast(node.statements())) {
			if (ASTNode.SWITCH_CASE == element.getNodeType()) {
				CSBlock openCaseBlock = null;
				if (null == current) {
					if ((_currentBlock != null) && FlowAnalysis.isReachable(_currentBlock))
						openCaseBlock = _currentBlock;
					current = new CSCaseClause();
					mappedNode.addCase(current);
					_currentBlock = current.body();
				}
				SwitchCase sc = (SwitchCase) element;
				if (sc.isDefault()) {
					current.isDefault(true);
					if (openCaseBlock != null)
						openCaseBlock.addStatement(new CSGotoStatement(Integer.MIN_VALUE,
								"default"));
				} else {
					pushExpectedType(effectiveSwitchType);
					CSExpression caseExpression = mapExpression(sc.getExpression());
					current.addExpression(caseExpression);
					popExpectedType();
					if (openCaseBlock != null)
						openCaseBlock.addStatement(new CSGotoStatement(Integer.MIN_VALUE,
								caseExpression));
				}
				openCaseBlock = null;
			} else {
				element.accept(this);
				current = null;
			}
		}

		if ((_currentBlock != null) && FlowAnalysis.isReachable(_currentBlock)) {
			_currentBlock.addStatement(new CSBreakStatement(Integer.MIN_VALUE));
		}

		_currentBlock = saved;
		return false;
	}

	private boolean isTypeVariable(ITypeBinding type) {
		if (type.isTypeVariable())
			return true;
		if (type.isWildcardType()) {
			ITypeBinding bound = type.getBound();
			if (bound != null)
				return isTypeVariable(bound);
		}
		return false;
	}

	@Override
	public boolean visit(CastExpression node) {
		Expression expr = node.getExpression();
		ITypeBinding exprType = expr.resolveTypeBinding();
		ITypeBinding type = node.getType().resolveBinding();

		if (isJavaLangCharSequence(exprType) && isJavaLangString(type)) {
			CSReferenceExpression re = new CSReferenceExpression("java.lang.CharSequenceProxy.UnWrap");
			CSMethodInvocationExpression mie = new CSMethodInvocationExpression(re);
			mie.addArgument(mapExpression(expr));
			pushExpression(mie);
			return false;
		} else if (isJavaLangString(exprType) && isJavaLangCharSequence(type)) {
			CSReferenceExpression re = new CSReferenceExpression("java.lang.CharSequenceProxy.Wrap");
			CSMethodInvocationExpression mie = new CSMethodInvocationExpression(re);
			mie.addArgument(mapExpression(expr));
			pushExpression(mie);
			return false;
		} else if (isJavaLangNumber(type)) {
			pushExpression(mapExpression(expr));
			return false;
		}

		final CSTypeReferenceExpression target = mappedTypeReference(type);
		final CSExpression mappedExpr = mapExpression(expr);

		if (isTypeVariable(type) && isTypeVariable(exprType)) {
			CSExpression objectCast = new CSCastExpression(OBJECT_TYPE_REFERENCE, mappedExpr);
			pushExpression(new CSCastExpression(target, objectCast));
			return false;
		}

		pushExpression(new CSCastExpression(target, mappedExpr));
		// Make all byte casts unchecked
		if (type.equals(my(IBindingManager.class).getByteType()))
			pushExpression(new CSUncheckedExpression(popExpression()));
		return false;
	}

	@Override
	public boolean visit(PrefixExpression node) {
		CSExpression expr;
		expr = new CSPrefixExpression(node.getOperator().toString(), mapExpression(node.getOperand()));
		if (expectingType("byte") && node.getOperator() == PrefixExpression.Operator.MINUS) {
			expr = uncheckedCast("byte", expr);
		}
		pushExpression(expr);
		return false;
	}

	@Override
	public boolean visit(PostfixExpression node) {
		pushExpression(new CSPostfixExpression(node.getOperator().toString(), mapExpression(node.getOperand())));
		return false;
	}

	@Override
	public boolean visit(InfixExpression node) {
		final Expression left = node.getLeftOperand();
		final Expression right = node.getRightOperand();
		final ITypeBinding leftType = left.resolveTypeBinding();
		final ITypeBinding rightType = right.resolveTypeBinding();
		CSExpression mappedLeft = mapExpression(left);
		CSExpression mappedRight = mapExpression(right);
		final String type = left.resolveTypeBinding().getQualifiedName();
		final InfixExpression.Operator op = node.getOperator();

		final ITypeBinding byteType = my(IBindingManager.class).getByteType();
		final ITypeBinding longType = my(IBindingManager.class).getLongType();

		if (op == InfixExpression.Operator.RIGHT_SHIFT_UNSIGNED) {
			if (leftType.equals(byteType)) {
				pushExpression(new CSInfixExpression(">>", mappedLeft, mappedRight));
			} else {
				CSExpression cast = new CSCastExpression(new CSTypeReference("u" + type), mappedLeft);
				cast = new CSParenthesizedExpression(cast);
				CSExpression shiftResult = new CSInfixExpression(">>", cast, mappedRight);
				shiftResult = new CSParenthesizedExpression(shiftResult);
				pushExpression(new CSCastExpression(new CSTypeReference(type), shiftResult));
			}
			return false;
		} else if ((op == InfixExpression.Operator.RIGHT_SHIFT_SIGNED)
				|| (op == InfixExpression.Operator.LEFT_SHIFT)) {
			if (rightType.equals(longType))
				mappedRight = new CSCastExpression(new CSTypeReference("int"), mappedRight);
		} else if ((op == InfixExpression.Operator.EQUALS) || (op == InfixExpression.Operator.NOT_EQUALS)) {
			if (isZeroLiteral(right)) {
				CSExpression mapped = my(CSharpDriver.class).mappedNullPointer(left);
				if (mapped != null)
					mappedRight = mapped;
				if (leftType.isTypeVariable())
					mappedLeft = new CSCastExpression(OBJECT_TYPE_REFERENCE, mappedLeft);
			} else if (isZeroLiteral(left)) {
				CSExpression mapped = my(CSharpDriver.class).mappedNullPointer(right);
				if (mapped != null)
					mappedLeft = mapped;
				if (rightType.isTypeVariable())
					mappedRight = new CSCastExpression(OBJECT_TYPE_REFERENCE, mappedRight);
			}
			if ((leftType.equals(_objectType) && isTypeVariable(rightType))
					|| ((rightType.equals(_objectType) && isTypeVariable(leftType)))) {
				CSTypeReference helperRef = new CSTypeReference("Sharpen.Util");
				CSMemberReferenceExpression mr = new CSMemberReferenceExpression(helperRef, "Equals");
				CSMethodInvocationExpression mie = new CSMethodInvocationExpression(mr);
				if (isTypeVariable(leftType)) {
					mie.addArgument(mappedLeft);
					mie.addArgument(mappedRight);
				} else {
					mie.addArgument(mappedRight);
					mie.addArgument(mappedLeft);
				}
				pushExpression(mie);
				return false;
			}
		}
		if (leftType.equals(byteType)
				&& ((op == InfixExpression.Operator.LESS) || (op == InfixExpression.Operator.LESS_EQUALS))) {
			mappedLeft = new CSCastExpression(new CSTypeReference("sbyte"), mappedLeft);
			mappedLeft = new CSParenthesizedExpression(mappedLeft);
		}
		String operator = node.getOperator().toString();
		pushExpression(new CSInfixExpression(operator, mappedLeft, mappedRight));
		pushExtendedOperands(operator, node);
		return false;
	}

	private void pushExtendedOperands(String operator, InfixExpression node) {
		for (Object x : node.extendedOperands()) {
			pushExpression(new CSInfixExpression(operator, popExpression(), mapExpression((Expression) x)));
		}
	}

	@Override
	public boolean visit(ParenthesizedExpression node) {
		pushExpression(new CSParenthesizedExpression(mapExpression(node.getExpression())));
		return false;
	}

	@Override
	public boolean visit(ConditionalExpression node) {
		final Expression thenExpr = node.getThenExpression();
		final Expression elseExpr = node.getElseExpression();

		final ITypeBinding type = node.resolveTypeBinding();
		final ITypeBinding thenType = thenExpr.resolveTypeBinding();
		final ITypeBinding elseType = elseExpr.resolveTypeBinding();

		CSExpression mappedCondition = mapExpression(node.getExpression());
		CSExpression mappedThen = mapExpression(type, thenExpr);
		CSExpression mappedElse = mapExpression(type, elseExpr);

		boolean oneIsNull = thenExpr instanceof NullLiteral || elseExpr instanceof NullLiteral;

		// HACK: If 'then' is a field that's been mapped to "IntPtr" and
		// 'else' is a "0" literal, map it to "IntPtr.Zero"
		if (isZeroLiteral(elseExpr)) {
			CSExpression mapped = my(CSharpDriver.class).mappedNullPointer(thenExpr);
			if (mapped != null)
				mappedElse = mapped;
			oneIsNull = true;
		}
		if (isZeroLiteral(thenExpr)) {
			CSExpression mapped = my(CSharpDriver.class).mappedNullPointer(elseExpr);
			if (mapped != null)
				mappedThen = mapped;
			oneIsNull = true;
		}

		if (oneIsNull) {
			pushExpression(new CSConditionalExpression(mappedCondition, mappedThen, mappedElse));
			return false;
		}

		final ITypeBinding stringType = my(IBindingManager.class).getStringType();
		final ITypeBinding serializableType = my(IBindingManager.class).getSerializableType();

		if ((type.equals(stringType) || type.equals(serializableType))
				&& (thenType.equals(stringType) || elseType.equals(stringType))) {
			if (!thenType.equals(stringType)) {
				CSExpression toStringRef = new CSMemberReferenceExpression(mappedThen, "ToString");
				mappedThen = new CSMethodInvocationExpression(toStringRef);
			}
			if (!elseType.equals(stringType)) {
				CSExpression toStringRef = new CSMemberReferenceExpression(mappedElse, "ToString");
				mappedElse = new CSMethodInvocationExpression(toStringRef);
			}
		}

		if (type.isClass() && thenType.isAssignmentCompatible(type) && elseType.isAssignmentCompatible(type)
				&& !thenType.isAssignmentCompatible(elseType)
				&& !elseType.isAssignmentCompatible(thenType)) {
			if (!thenType.equals(type))
				mappedThen = new CSCastExpression(mappedTypeReference(type), mappedThen);
			if (!elseType.equals(type))
				mappedElse = new CSCastExpression(mappedTypeReference(type), mappedElse);
		}

		pushExpression(new CSConditionalExpression(mappedCondition, mappedThen, mappedElse));
		return false;
	}

	@Override
	public boolean visit(InstanceofExpression node) {
		Expression lo = node.getLeftOperand();
		ITypeBinding loType = lo.resolveTypeBinding();
		ITypeBinding type = node.getRightOperand().resolveBinding();

		if (isJavaLangCharSequence(loType) && isJavaLangString(type)) {
			CSReferenceExpression re = new CSReferenceExpression(
					"java.lang.CharSequenceProxy.IsStringProxy");
			CSMethodInvocationExpression mie = new CSMethodInvocationExpression(re);
			mie.addArgument(mapExpression(lo));
			pushExpression(mie);
			return false;
		} else if (isJavaLangString(loType) && isJavaLangCharSequence(type)) {
			pushExpression(new CSBoolLiteralExpression(true));
			return false;
		}

		pushExpression(new CSInfixExpression("is", mapExpression(lo), mappedTypeReference(type)));
		return false;
	}

	@Override
	public boolean visit(Assignment node) {
		final Expression lhs = node.getLeftHandSide();
		final Expression rhs = node.getRightHandSide();
		final ITypeBinding lhsType = lhs.resolveTypeBinding();
		pushExpectedType(lhsType);
		final Assignment.Operator op = node.getOperator();

		if (op == Assignment.Operator.RIGHT_SHIFT_UNSIGNED_ASSIGN) {
			String type = lhsType.getQualifiedName();
			if (type == "byte") {
				pushExpression(new CSInfixExpression(">>", mapExpression(lhs), mapExpression(lhs
						.resolveTypeBinding(), rhs)));
			} else {
				CSExpression mappedLhs = new CSParenthesizedExpression(mapExpression(lhs));
				CSExpression cast = new CSCastExpression(new CSTypeReference("u" + type), mappedLhs);
				CSExpression shiftResult = new CSInfixExpression(">>", cast, mapExpression(rhs));
				shiftResult = new CSParenthesizedExpression(shiftResult);
				shiftResult = new CSCastExpression(new CSTypeReference(type), shiftResult);
				pushExpression(new CSInfixExpression("=", mappedLhs, shiftResult));
			}
		} else if ((op == Assignment.Operator.PLUS_ASSIGN) || (op == Assignment.Operator.MINUS_ASSIGN)
				|| (op == Assignment.Operator.TIMES_ASSIGN)
				|| (op == Assignment.Operator.DIVIDE_ASSIGN)) {
			ITypeBinding rhsType = rhs.resolveTypeBinding();
			CSExpression mappedLhs = mapExpression(lhs);
			CSExpression mappedRhs = mapExpression(lhsType, rhs);
			final ITypeBinding intType = my(IBindingManager.class).getIntType();
			final ITypeBinding longType = my(IBindingManager.class).getLongType();
			final ITypeBinding floatType = my(IBindingManager.class).getFloatType();
			if (lhsType.equals(intType) && (rhsType.equals(longType) || rhsType.equals(floatType))) {
				mappedRhs = new CSParenthesizedExpression(mappedRhs);
				mappedRhs = new CSCastExpression(new CSTypeReference("int"), mappedRhs);
			}
			pushExpression(new CSInfixExpression(op.toString(), mappedLhs, mappedRhs));
		} else if ((op == Assignment.Operator.ASSIGN) && isZeroLiteral(rhs)) {
			CSExpression mappedLhs = mapExpression(lhs);
			CSExpression mappedRhs = mapExpression(lhsType, rhs);

			CSExpression mapped = my(CSharpDriver.class).mappedNullPointer(lhs);
			if (mapped != null)
				mappedRhs = mapped;

			pushExpression(new CSInfixExpression(op.toString(), mappedLhs, mappedRhs));
		} else {
			CSExpression mappedLhs = mapExpression(lhs);
			CSExpression mappedRhs = mapExpression(lhsType, rhs);
			pushExpression(new CSInfixExpression(op.toString(), mappedLhs, mappedRhs));
		}
		popExpectedType();
		return false;
	}

	public CSExpression mapExpression(ITypeBinding expectedType, Expression expression) {
		if (expression instanceof NullLiteral) {
			if ((expectedType != null) && isTypeVariable(expectedType))
				return new CSDefaultExpression(expectedType.getName());
			else
				return new CSNullLiteralExpression();
		}

		if ((expression != null) && (expectedType != null)) {
			final ITypeBinding type = expression.resolveTypeBinding();
			pushExpectedType(expectedType);
			CSExpression mappedExpr = mapExpression(expression);
			popExpectedType();
			return castIfNeeded(expectedType, type, mappedExpr);
		} else {
			return mapExpression(expression);
		}
	}

	private CSExpression castIfNeeded(ITypeBinding expectedType, ITypeBinding actualType, CSExpression expression) {
		if (expectedType != actualType && isSubclassOf(expectedType, actualType))
			return new CSCastExpression(mappedTypeReference(expectedType), expression);

		if (actualType == expectedType)
			return expression;

		if (isJavaLangCharSequence(expectedType) && isJavaLangString(actualType)) {
			CSReferenceExpression proxy = new CSReferenceExpression("java.lang.CharSequenceProxy.Wrap");
			CSMethodInvocationExpression mie = new CSMethodInvocationExpression(proxy);
			mie.addArgument(expression);
			return mie;
		}

		if (actualType.equals(_objectType))
			return new CSCastExpression(mappedTypeReference(expectedType), expression);

		CSExpression casted = my(CSharpDriver.class).castIfNeeded(this, expectedType, actualType, expression);
		if (casted != null)
			return casted;

		if (expectedType != my(IBindingManager.class).getCharType())
			return expression;
		if (actualType == expectedType)
			return expression;
		return new CSCastExpression(mappedTypeReference(expectedType), expression);
	}

	private boolean isSubclassOf(ITypeBinding t, ITypeBinding tbase) {
		while (t != null) {
			if (t.isEqualTo(tbase))
				return true;
			t = t.getSuperclass();
		}
		return false;
	}

	@Override
	public boolean visit(ClassInstanceCreation node) {
		if (null != node.getAnonymousClassDeclaration()) {
			node.getAnonymousClassDeclaration().accept(this);
			return false;
		}

		CSMethodInvocationExpression expression = mapConstructorInvocation(node);
		if (null == expression) {
			return false;
		}

		if (node.getExpression() != null) {
			expression.addArgument(mapExpression(node.getExpression()));
		} else if (isNonStaticNestedTypeCreation(node)) {
			ITypeBinding target = node.resolveTypeBinding();
			expression.addArgument(createEnclosingThisReference(target.getDeclaringClass()));
		}

		mapArguments(expression, node.arguments(), node.resolveConstructorBinding());
		pushExpression(expression);
		return false;
	}

	protected CSExpression createEnclosingThisReference(ITypeBinding enclosingClassBinding) {
		return new CSThisExpression();
	}

	private boolean isNonStaticNestedTypeCreation(ClassInstanceCreation node) {
		return isNonStaticNestedType(node.resolveTypeBinding());
	}

	private CSMethodInvocationExpression mapConstructorInvocation(ClassInstanceCreation node) {
		Configuration.MemberMapping mappedConstructor = effectiveMappingFor(node.resolveConstructorBinding());
		if (null == mappedConstructor) {
			return new CSConstructorInvocationExpression(mappedTypeReference(node.resolveTypeBinding()));
		}
		final String mappedName = mappedConstructor.name;
		if (mappedName.length() == 0) {
			pushExpression(mapExpression((Expression) node.arguments().get(0)));
			return null;
		}
		if (mappedName.startsWith("System.Convert.To")) {
			if (optimizeSystemConvert(mappedName, node)) {
				return null;
			}
		}
		return new CSMethodInvocationExpression(new CSReferenceExpression(methodName(mappedName)));
	}

	private boolean optimizeSystemConvert(String mappedConstructor, ClassInstanceCreation node) {
		String typeName = _configuration.getConvertRelatedWellKnownTypeName(mappedConstructor);
		if (null != typeName) {
			assert 1 == node.arguments().size();
			Expression arg = (Expression) node.arguments().get(0);
			if (arg.resolveTypeBinding() == resolveWellKnownType(typeName)) {
				arg.accept(this);
				return true;
			}
		}
		return false;
	}

	@Override
	public boolean visit(TypeLiteral node) {

		if (isReferenceToRemovedType(node.getType())) {
			pushExpression(new CSRemovedExpression(node.toString()));
			return false;
		}

		pushTypeOfExpression(mappedTypeReference(node.getType()));
		return false;
	}

	private boolean isReferenceToRemovedType(Type node) {
		BodyDeclaration typeDeclaration = findDeclaringNode(node.resolveBinding());
		if (null == typeDeclaration)
			return false;
		return hasRemoveAnnotation(typeDeclaration);
	}

	private void pushTypeOfExpression(CSTypeReferenceExpression type) {
		pushExpression(new CSTypeofExpression(type));
	}

	@Override
	public boolean visit(MethodInvocation node) {
		final IMethodBinding binding = node.resolveMethodBinding();
		final ITypeBinding declaringType = binding.getDeclaringClass();

		if ((declaringType == _objectType) && (binding.getName().equals("clone"))) {
			final Expression expr = node.getExpression();
			final ITypeBinding exprType = expr.resolveTypeBinding();
			if (exprType.isArray()) {
				CSExpression mapped = mapExpression(expr);
				CSExpression target = new CSMemberReferenceExpression(parensIfNeeded(mapped), "Clone");
				CSExpression mie = new CSMethodInvocationExpression(target);
				ITypeBinding expected = getExpectedType();
				if (expected == null)
					expected = exprType;
				pushExpression(new CSCastExpression(mappedTypeReference(expected), mie));
				return false;
			}
		}

		CSExpression mapped = my(CSharpDriver.class).mappedMethodInvocation(this, node);
		if (mapped != null) {
			pushExpression(mapped);
			return false;
		}

		IMethodBinding originalBinding = originalMethodBinding(node.resolveMethodBinding());
		Configuration.MemberMapping mapping = mappingForInvocation(node, originalBinding);

		if (null != mapping) {
			processMappedMethodInvocation(node, originalBinding, mapping);
		} else {
			processUnmappedMethodInvocation(node);
		}

		return false;
	}

	@Override
	public boolean visit(SuperMethodInvocation node) {
		if (null != node.getQualifier()) {
			notImplemented(node);
		}

		final IMethodBinding binding = originalMethodBinding(node.resolveMethodBinding());

		final ITypeBinding declaringType = binding.getDeclaringClass();

		if (declaringType.equals(_objectType) && node.getName().toString().equals("finalize")) {
			pushExpression(new CSEmptyExpression());
			return false;
		}

		Configuration.MemberMapping mapping = mappingForInvocation(node, binding);
		CSExpression target = new CSMemberReferenceExpression(new CSBaseExpression(), mappedMethodName(binding));

		if (mapping != null) {
			if (mapping.kind == MemberKind.Indexer) {
				processIndexerInvocation(node, binding);
				return false;
			} else if (mapping.kind != MemberKind.Method) {
				pushExpression(target);
				return false;
			}
		}

		CSMethodInvocationExpression mie = new CSMethodInvocationExpression(target);
		mapArguments(mie, node.arguments(), binding);
		pushExpression(mie);
		return false;
	}

	private Configuration.MemberMapping mappingForInvocation(ASTNode node, IMethodBinding binding) {
		Configuration.MemberMapping mapping = effectiveMappingFor(binding);

		if (null == mapping) {
			if (isIndexer(binding)) {
				mapping = new MemberMapping(null, MemberKind.Indexer);
			} else if (isTaggedMethodInvocation(binding, SharpenAnnotations.SHARPEN_EVENT)) {
				mapping = new MemberMapping(binding.getName(), MemberKind.Property);
			} else if (isTaggedMethodInvocation(binding, SharpenAnnotations.SHARPEN_PROPERTY)) {
				mapping = new MemberMapping(propertyName(binding), MemberKind.Property);
			}
		}
		return mapping;
	}

	private boolean isIndexer(final IMethodBinding binding) {
		return isTaggedMethod(binding, SharpenAnnotations.SHARPEN_INDEXER);
	}

	private boolean isTaggedMethod(final IMethodBinding binding, final String tag) {
		final MethodDeclaration declaration = declaringNode(binding);
		if (null == declaration) {
			return false;
		}
		return isTaggedDeclaration(declaration, tag);
	}

	private IMethodBinding originalMethodBinding(IMethodBinding binding) {
		IMethodBinding original = BindingUtils.findMethodDefininition(binding, my(CompilationUnit.class)
				.getAST());
		if (null != original)
			return original;
		return binding;
	}

	private void processUnmappedMethodInvocation(MethodInvocation node) {

		if (isMappedEventSubscription(node)) {
			processMappedEventSubscription(node);
			return;
		}

		if (isEventSubscription(node)) {
			processEventSubscription(node);
			return;
		}

		if (isRemovedMethodInvocation(node)) {
			processRemovedInvocation(node);
			return;
		}

		if (isUnwrapInvocation(node)) {
			processUnwrapInvocation(node);
			return;
		}

		if (isMacro(node)) {
			processMacroInvocation(node);
			return;
		}

		if (isEnumOrdinalMethodInvocation(node)) {
			processEnumOrdinalMethodInvocation(node);
			return;
		}

		if (isEnumNameMethodInvocation(node)) {
			processEnumNameMethodInvocation(node);
			return;
		}

		if (isEnumValuesMethodInvocation(node)) {
			processEnumValuesMethodInvocation(node);
			return;
		}

		processOrdinaryMethodInvocation(node);
	}

	private boolean isMacro(MethodInvocation node) {
		return isTaggedMethodInvocation(node, SharpenAnnotations.SHARPEN_MACRO);
	}

	private void processMacroInvocation(MethodInvocation node) {
		final MethodDeclaration declaration = declaringNode(node.resolveMethodBinding());
		final TagElement macro = effectiveAnnotationFor(declaration, SharpenAnnotations.SHARPEN_MACRO);
		final CSMacro code = new CSMacro(JavadocUtility.singleTextFragmentFrom(macro));

		code.addVariable("expression", mapExpression(node.getExpression()));
		code.addVariable("arguments", mapExpressions(node.arguments()));

		pushExpression(new CSMacroExpression(code));
	}

	private List<CSExpression> mapExpressions(List expressions) {
		final ArrayList<CSExpression> result = new ArrayList<CSExpression>(expressions.size());
		for (Object expression : expressions) {
			result.add(mapExpression((Expression) expression));
		}
		return result;
	}

	private boolean isUnwrapInvocation(MethodInvocation node) {
		return isTaggedMethodInvocation(node, SharpenAnnotations.SHARPEN_UNWRAP);
	}

	private void processUnwrapInvocation(MethodInvocation node) {
		final List arguments = node.arguments();
		if (arguments.size() != 1) {
			unsupportedConstruct(node, SharpenAnnotations.SHARPEN_UNWRAP
					+ " only works against single argument methods.");
		}
		pushExpression(mapExpression((Expression) arguments.get(0)));
	}

	private void processOrdinaryMethodInvocation(MethodInvocation node) {
		final IMethodBinding method = node.resolveMethodBinding();
		final IMethodBinding methodDecl = method.getMethodDeclaration();

		CSExpression targetExpression = mapMethodTargetExpression(node);
		if ((method.getModifiers() & Modifier.STATIC) != 0
				&& !(targetExpression instanceof CSTypeReferenceExpression)
				&& node.getExpression() != null)
			targetExpression = mappedTypeReference(node.getExpression().resolveTypeBinding());

		final String name = resolveTargetMethodName(targetExpression, node);
		final String qualifiedName = BindingUtils.qualifiedName(method);

		if (qualifiedName.equals("com.android.internal.util.ArrayUtils.emptyArray")) {
			final ITypeBinding instanceType = method.getParameterTypes()[0].getTypeArguments()[0];
			CSArrayCreationExpression ace = new CSArrayCreationExpression(mappedTypeReference(instanceType));
			ace.length(new CSNumberLiteralExpression("0"));
			pushExpression(ace);
			return;
		}

		CSExpression target = null == targetExpression ? new CSReferenceExpression(name)
		: new CSMemberReferenceExpression(targetExpression, name);

		CSMethodInvocationExpression mie = new CSMethodInvocationExpression(target);
		mapMethodInvocationArguments(mie, node);
		mapTypeArguments(mie, node);

		if (methodDecl.isGenericMethod() && (mie.typeArguments().size() == 0)) {
			IMethodBinding current = null;
			if (_currentBodyDeclaration instanceof MethodDeclaration)
				current = ((MethodDeclaration) _currentBodyDeclaration).resolveBinding();

			final ITypeBinding expected = getExpectedType();
			final ITypeBinding retType = methodDecl.getReturnType();

			final ITypeBinding[] mtp = methodDecl.getTypeParameters();
			if ((expected != null) && expected.isParameterizedType() && retType.isParameterizedType()) {
				ITypeBinding retDecl = methodDecl.getReturnType().getTypeDeclaration();
				ITypeBinding expDecl = expected.getTypeDeclaration();
				if (retDecl.equals(expDecl) && (expected.getTypeArguments().length == mtp.length)) {
					for (ITypeBinding tp : expected.getTypeArguments())
						mie.addTypeArgument(mappedTypeReference(tp));
				}
			} else if ((current != null) && (current.getTypeParameters().length == mtp.length)) {
				for (ITypeBinding tp : current.getTypeParameters()) {
					mie.addTypeArgument(new CSTypeReference(tp.getName()));
				}
			}
		}

		IMethodBinding base = getOverridedMethod(method);
		if (base != null && base.getReturnType() != method.getReturnType()
				&& !(node.getParent() instanceof ExpressionStatement))
			pushExpression(new CSParenthesizedExpression(new CSCastExpression(
					mappedTypeReference(method.getReturnType()), mie)));
		else
			pushExpression(mie);
	}

	private String resolveTargetMethodName(CSExpression targetExpression, MethodInvocation node) {
		final IMethodBinding method = staticImportMethodBinding(node.getName(), _ast.imports());
		if (method != null && targetExpression == null) {
			return mappedTypeName(method.getDeclaringClass()) + "."
					+ mappedMethodName(node.resolveMethodBinding());
		}
		return mappedMethodName(node.resolveMethodBinding());
	}

	private void mapTypeArguments(CSMethodInvocationExpression mie, MethodInvocation node) {
		for (Object o : node.typeArguments()) {
			mie.addTypeArgument(mappedTypeReference((Type) o));
		}
	}

	private void processMappedEventSubscription(MethodInvocation node) {

		final MethodInvocation event = (MethodInvocation) node.getExpression();
		final String eventArgsType = _configuration.mappedEvent(qualifiedName(event));
		final String eventHandlerType = buildEventHandlerTypeName(node, eventArgsType);
		mapEventSubscription(node, eventArgsType, eventHandlerType);
	}

	private void processRemovedInvocation(MethodInvocation node) {
		TagElement element = javadocTagFor(declaringNode(node.resolveMethodBinding()),
				SharpenAnnotations.SHARPEN_REMOVE);

		String exchangeValue = JavadocUtility.singleTextFragmentFrom(element);
		pushExpression(new CSReferenceExpression(exchangeValue));
	}

	private void processEnumOrdinalMethodInvocation(MethodInvocation node)
	{
		CSExpression exp = mapExpression(node.getExpression());
		pushExpression(new CSCastExpression(new CSTypeReference("int"), new CSParenthesizedExpression(exp)));
	}

	private void processEnumNameMethodInvocation(MethodInvocation node)
	{
		CSExpression exp = mapExpression(node.getExpression());
		pushExpression(new CSMethodInvocationExpression(new CSMemberReferenceExpression(exp, "ToString")));
	}

	private void processEnumValuesMethodInvocation(MethodInvocation node)
	{
		CSExpression exp = mapExpression(node.getExpression());
		CSExpression type = new CSTypeofExpression((CSTypeReferenceExpression) exp);
		CSExpression mref = new CSMemberReferenceExpression(new CSTypeReference("System.Enum"), "GetValues");
		pushExpression(new CSMethodInvocationExpression(mref, type));
	}

	private void mapMethodInvocationArguments(CSMethodInvocationExpression mie, MethodInvocation node) {
		final List arguments = node.arguments();
		final IMethodBinding actualMethod = node.resolveMethodBinding();
		final ITypeBinding[] actualTypes = actualMethod.getParameterTypes();
		final IMethodBinding originalMethod = actualMethod.getMethodDeclaration();
		final ITypeBinding[] originalTypes = originalMethod.getParameterTypes();
		for (int i = 0; i < arguments.size(); ++i) {
			final Expression arg = (Expression) arguments.get(i);
			if (i >= originalTypes.length) {
				addArgument(mie, arg, null);
				continue;
			}
			if (isGenericRuntimeParameterIdiom(originalMethod, originalTypes[i])) {
				if (isClassLiteral(arg)) {
					mie.addTypeArgument(genericRuntimeTypeIdiomType(actualTypes[i]));
					continue;
				}
				ITypeBinding argType = arg.resolveTypeBinding();
				if (isJavaLangClass(argType) && argType.getTypeArguments().length == 1) {
					mie.addTypeArgument(genericRuntimeTypeIdiomType(argType));
					continue;
				}
			} else if (isJavaLangClass(originalTypes[i])) {
				ITypeBinding[] ota = originalTypes[i].getTypeArguments();
				ITypeBinding[] ata = actualTypes[i].getTypeArguments();
				if (ota.length == 1 && ata.length == 1 && ota[0].getName().startsWith("?")) {
					mie.addTypeArgument(mappedTypeReference(ata[0]));
					continue;
				}
			}
			CSExpression expr = my(CSharpDriver.class).mappedMethodInvocationArgument(this, node, i, arg);
			if (expr != null)
				mie.addArgument(expr);
		}
		adjustJUnitArguments(mie, node);
	}

	private void adjustJUnitArguments(CSMethodInvocationExpression mie, MethodInvocation node) {
		if (!_configuration.junitConversion())
			return;
		ITypeBinding t = node.resolveMethodBinding().getDeclaringClass();
		if (t.getQualifiedName().equals("junit.framework.Assert")
				|| t.getQualifiedName().equals("org.junit.Assert")) {
			String method = node.getName().getIdentifier();
			int np = -1;

			if (method.equals("assertTrue") || method.equals("assertFalse")
					|| method.equals("assertNull") || method.equals("assertNotNull"))
				np = 1;
			else if (method.equals("fail"))
				np = 0;
			else if (method.startsWith("assert"))
				np = 2;

			if (np == -1)
				return;

			if (mie.arguments().size() == np + 1) {
				// Move the comment argument to the end
				mie.addArgument(mie.arguments().get(0));
				mie.removeArgument(0);
			}

			if (method.equals("assertSame")) {
				boolean useEquals = false;
				final List arguments = node.arguments();
				for (int i = 0; i < arguments.size(); ++i) {
					final Expression arg = (Expression) arguments.get(i);
					ITypeBinding b = arg.resolveTypeBinding();
					if (b.isEnum()) {
						useEquals = true;
						break;
					}
				}
				if (useEquals) {
					CSReferenceExpression mref = (CSReferenceExpression) mie.expression();
					mref.name("NUnit.Framework.Assert.AreEqual");
				}
			}
		}
	}

	private boolean isClassLiteral(Expression arg) {
		return arg.getNodeType() == ASTNode.TYPE_LITERAL;
	}

	private void processEventSubscription(MethodInvocation node) {

		final MethodDeclaration addListener = declaringNode(node.resolveMethodBinding());
		assertValidEventAddListener(node, addListener);

		final MethodInvocation eventInvocation = (MethodInvocation) node.getExpression();

		final MethodDeclaration eventDeclaration = declaringNode(eventInvocation.resolveMethodBinding());
		mapEventSubscription(node, getEventArgsType(eventDeclaration),
				getEventHandlerTypeName(eventDeclaration));
	}

	private void mapEventSubscription(MethodInvocation node, final String eventArgsType,
			final String eventHandlerType) {
		final CSAnonymousClassBuilder listenerBuilder = mapAnonymousEventListener(node);
		final CSMemberReferenceExpression handlerMethodRef = new CSMemberReferenceExpression(listenerBuilder
				.createConstructorInvocation(), eventListenerMethodName(listenerBuilder));

		final CSReferenceExpression delegateType = new CSReferenceExpression(eventHandlerType);

		patchEventListener(listenerBuilder, eventArgsType);

		CSConstructorInvocationExpression delegateConstruction = new CSConstructorInvocationExpression(
				delegateType);
		delegateConstruction.addArgument(handlerMethodRef);

		pushExpression(new CSInfixExpression("+=", mapMethodTargetExpression(node), delegateConstruction));
	}

	private CSAnonymousClassBuilder mapAnonymousEventListener(MethodInvocation node) {
		ClassInstanceCreation creation = (ClassInstanceCreation) node.arguments().get(0);
		return mapAnonymousClass(creation.getAnonymousClassDeclaration());
	}

	private String eventListenerMethodName(final CSAnonymousClassBuilder listenerBuilder) {
		return mappedMethodName(getFirstMethod(listenerBuilder.anonymousBaseType()));
	}

	private void patchEventListener(CSAnonymousClassBuilder listenerBuilder, String eventArgsType) {
		final CSClass type = listenerBuilder.type();
		type.clearBaseTypes();

		final CSMethod handlerMethod = (CSMethod) type.getMember(eventListenerMethodName(listenerBuilder));
		handlerMethod.parameters().get(0).type(OBJECT_TYPE_REFERENCE);
		handlerMethod.parameters().get(0).name("sender");
		handlerMethod.parameters().get(1).type(new CSTypeReference(eventArgsType));

	}

	private IMethodBinding getFirstMethod(ITypeBinding listenerType) {
		return listenerType.getDeclaredMethods()[0];
	}

	private void assertValidEventAddListener(ASTNode source, MethodDeclaration addListener) {
		if (isValidEventAddListener(addListener))
			return;

		unsupportedConstruct(source, SharpenAnnotations.SHARPEN_EVENT_ADD
				+ " must take lone single method interface argument");
	}

	private boolean isValidEventAddListener(MethodDeclaration addListener) {
		if (1 != addListener.parameters().size())
			return false;

		final ITypeBinding type = getFirstParameterType(addListener);
		if (!type.isInterface())
			return false;

		return type.getDeclaredMethods().length == 1;
	}

	private ITypeBinding getFirstParameterType(MethodDeclaration addListener) {
		return parameter(addListener, 0).getType().resolveBinding();
	}

	private SingleVariableDeclaration parameter(MethodDeclaration method, final int index) {
		return (SingleVariableDeclaration) method.parameters().get(index);
	}

	private boolean isEventSubscription(MethodInvocation node) {
		return isTaggedMethodInvocation(node, SharpenAnnotations.SHARPEN_EVENT_ADD);
	}

	private boolean isMappedEventSubscription(MethodInvocation node) {
		return _configuration.isMappedEventAdd(qualifiedName(node));
	}

	private String qualifiedName(MethodInvocation node) {
		return qualifiedName(node.resolveMethodBinding());
	}

	private boolean isTaggedMethodInvocation(MethodInvocation node, final String tag) {
		return isTaggedMethodInvocation(node.resolveMethodBinding(), tag);
	}

	private boolean isTaggedMethodInvocation(final IMethodBinding binding, final String tag) {
		final MethodDeclaration method = declaringNode(originalMethodBinding(binding));
		if (null == method) {
			return false;
		}
		return containsJavadoc(method, tag);
	}

	@SuppressWarnings("unchecked")
	private void processMappedMethodInvocation(MethodInvocation node, IMethodBinding binding,
			Configuration.MemberMapping mapping) {

		if (mapping.kind == MemberKind.Indexer) {
			processIndexerInvocation(node, binding);
			return;
		}

		String name = mappedMethodName(binding);
		if (0 == name.length()) {
			final Expression expression = node.getExpression();
			final CSExpression target = expression != null ? mapExpression(expression)
					: new CSThisExpression();

			pushExpression(target);
			return;
		}

		boolean isMappingToStaticMethod = isMappingToStaticMember(name);

		List<Expression> arguments = node.arguments();
		CSExpression expression = mapMethodTargetExpression(node);
		CSExpression target = null;

		if (null == expression || isMappingToStaticMethod) {
			target = new CSReferenceExpression(name);
		} else {
			if (BindingUtils.isStatic(binding) && arguments.size() > 0) {
				// mapping static method to instance member
				// typical example is String.valueOf(arg) =>
				// arg.ToString()
				target = new CSMemberReferenceExpression(
						parensIfNeeded(mapExpression(arguments.get(0))), name);
				arguments = arguments.subList(1, arguments.size());
			} else {
				target = new CSMemberReferenceExpression(expression, name);
			}
		}

		if (mapping.kind != MemberKind.Method) {
			IMethodBinding originalBinding = node.resolveMethodBinding();
			if (binding != originalBinding && originalBinding.getReturnType() != binding.getReturnType()
					&& !(node.getParent() instanceof ExpressionStatement))
				target = new CSParenthesizedExpression(new CSCastExpression(
						mappedTypeReference(originalBinding.getReturnType()), target));
			switch (arguments.size()) {
			case 0:
				pushExpression(target);
				break;

			case 1:
				pushExpression(new CSInfixExpression("=", target, mapExpression(arguments.get(0))));
				break;

			default:
				unsupportedConstruct(node,
						"Method invocation with more than 1 argument mapped to property");
				break;
			}
			return;
		}

		CSMethodInvocationExpression mie = new CSMethodInvocationExpression(target);
		if (isMappingToStaticMethod && isInstanceMethod(binding)) {
			if (null == expression) {
				mie.addArgument(new CSThisExpression());
			} else {
				mie.addArgument(expression);
			}
		}
		mapArguments(mie, arguments, null);
		adjustJUnitArguments(mie, node);

		if (mapping.flags == MappingFlags.CastResult) {
			pushExpression(new CSCastExpression(mappedTypeReference(binding.getReturnType()), mie));
		} else {
			pushExpression(mie);
		}
	}

	private void processIndexerInvocation(MethodInvocation node, IMethodBinding binding) {
		CSExpression target;
		if (node.getExpression() == null)
			target = new CSThisExpression();
		else
			target = mapMethodTargetExpression(node);
		List<Expression> arguments = new ArrayList<Expression>();
		arguments.addAll(node.arguments());

		processIndexerInvocation(binding, target, arguments);
	}

	private void processIndexerInvocation(SuperMethodInvocation node, IMethodBinding binding) {
		CSExpression target = new CSBaseExpression();
		List<Expression> arguments = new ArrayList<Expression>();
		arguments.addAll(node.arguments());

		processIndexerInvocation(binding, target, arguments);
	}

	private void processIndexerInvocation(IMethodBinding binding, CSExpression target, List<Expression> arguments) {
		if (arguments.size() == 1)
			processIndexerGetter(binding, target, arguments);
		else
			processIndexerSetter(binding, target, arguments);
	}

	private void processIndexerSetter(IMethodBinding binding, CSExpression target, List<Expression> arguments) {
		// target(arg0 ... argN) => target[arg0... argN-1] = argN;

		final CSIndexedExpression indexer = new CSIndexedExpression(target);
		final Expression lastArgument = arguments.get(arguments.size() - 1);
		for (int i = 0; i < arguments.size() - 1; ++i) {
			indexer.addIndex(mapExpression(arguments.get(i)));
		}
		pushExpression(CSharpCode.newAssignment(indexer, mapExpression(lastArgument)));
	}

	private void processIndexerGetter(IMethodBinding binding, CSExpression target, List<Expression> arguments) {
		final Expression singleArgument = arguments.get(0);
		pushExpression(new CSIndexedExpression(target, mapExpression(singleArgument)));
	}

	private CSExpression parensIfNeeded(CSExpression expression) {
		if (expression instanceof CSInfixExpression || expression instanceof CSPrefixExpression
				|| expression instanceof CSPostfixExpression || expression instanceof CSCastExpression) {

			return new CSParenthesizedExpression(expression);
		}
		return expression;
	}

	protected CSExpression mapMethodTargetExpression(MethodInvocation node) {
		return parensIfNeeded(mapExpression(node.getExpression()));
	}

	private boolean isInstanceMethod(IMethodBinding binding) {
		return !BindingUtils.isStatic(binding);
	}

	private boolean isMappingToStaticMember(String name) {
		return -1 != name.indexOf('.');
	}

	protected void mapArguments(CSMethodInvocationExpression mie, List arguments, IMethodBinding binding) {
		if (binding != null) {
			ITypeBinding[] ptypes = binding.getParameterTypes();
			for (int i = 0; i < ptypes.length; i++) {
				Expression expr = (Expression) arguments.get(i);
				mie.addArgument(mapExpression(ptypes[i], expr));
			}
		} else {
			for (Object arg : arguments) {
				addArgument(mie, (Expression) arg, null);
			}
		}
	}

	private void addArgument(CSMethodInvocationExpression mie, Expression arg, ITypeBinding expectedType) {
		mie.addArgument(mapExpression(expectedType, arg));
	}

	@Override
	public boolean visit(FieldAccess node) {
		IVariableBinding vb = node.resolveFieldBinding();
		String name = mappedFieldName(vb);
		if (name == null)
			name = identifier(node.getName());
		if (Modifier.isStatic(vb.getModifiers())) {
			Expression expr = node.getExpression();
			ITypeBinding type = expr.resolveTypeBinding();
			pushExpression(new CSMemberReferenceExpression(mappedTypeReference(type), name));
			return false;
		} else if (null == node.getExpression()) {
			pushExpression(new CSReferenceExpression(name));
		} else {
			pushExpression(new CSMemberReferenceExpression(mapExpression(node.getExpression()), name));
		}
		return false;
	}

	protected String mappedVariableName(IVariableBinding binding) {
		return my(CSharpDriver.class).mappedVariableName(binding);
	}

	private boolean isBoolLiteral(String name) {
		return name.equals("true") || name.equals("false");
	}

	@Override
	public boolean visit(SimpleName node) {
		CSExpression expr = createSimpleNameReference(node, null);
		if (expr != null)
			pushExpression(expr);
		return false;
	}

	protected CSExpression createSimpleNameReference(SimpleName node, CSExpression target) {
		if (isTypeReference(node)) {
			return mappedTypeReference(node.resolveTypeBinding());
		} else if (_currentExpression != null) {
			return null;
		}

		final IBinding b = node.resolveBinding();
		final IVariableBinding vb = b instanceof IVariableBinding ? (IVariableBinding) b : null;
		if (vb == null) {
			if (target != null)
				return new CSMemberReferenceExpression(target, identifier(node));
			else
				return new CSReferenceExpression(identifier(node));
		}

		final String ident = identifier(vb.getName());
		final ITypeBinding cls = vb.getDeclaringClass();
		if (cls != null) {
			ITypeBinding intType = my(IBindingManager.class).getIntType();
			IExtractedEnumInfo eei = my(IBindingManager.class).getExtractedEnumInfo(cls);
			if ((eei != null) && (intType.equals(getExpectedType()))) {
				return new CSMemberReferenceExpression(mappedTypeReference(cls), ident + "_ID");
			}
			if (isStaticImport(vb, _ast.imports()))
				return new CSMemberReferenceExpression(mappedTypeReference(cls), ident);
			else if (cls.isEnum() && ident.indexOf('.') == -1) {
				CSExpression expr = my(CSharpDriver.class).mappedEnumAccess(this, node, vb);
				if (expr != null)
					return expr;
				return new CSMemberReferenceExpression(mappedTypeReference(cls), ident);
			}
		}

		final String mapped;
		if (vb.isField())
			mapped = mappedFieldName(vb);
		else
			mapped = mappedVariableName(vb);

		if (null != mapped) {
			if (isBoolLiteral(mapped)) {
				return new CSBoolLiteralExpression(Boolean.parseBoolean(mapped));
			} else if ((target == null) || (mapped.indexOf('.') > 0)) {
				return new CSReferenceExpression(mapped);
			} else {
				return new CSMemberReferenceExpression(target, mapped);
			}
		}

		final CSExpression expr;
		if (target != null) {
			expr = new CSMemberReferenceExpression(target, ident);
		} else {
			expr = new CSReferenceExpression(ident);
		}

		final IVariableInfo info = my(IBindingManager.class).getVariableInfo(vb);
		if (info != null) {
			CSTypeReferenceExpression autoCast = info.autoCast();
			if (autoCast != null)
				return new CSCastExpression(autoCast, expr);
		}

		return expr;
	}

	private void addStatement(CSStatement statement) {
		_currentBlock.addStatement(statement);
	}

	private void pushTypeReference(ITypeBinding typeBinding) {
		pushExpression(mappedTypeReference(typeBinding));
	}

	/*
	 * protected CSReferenceExpression createTypeReference(ITypeBinding
	 * typeBinding) { return new
	 * CSReferenceExpression(mappedTypeName(typeBinding)); }
	 */private boolean isTypeReference(Name node) {
		 final IBinding binding = node.resolveBinding();
		 if (null == binding) {
			 unresolvedTypeBinding(node);
			 return false;
		 }
		 return IBinding.TYPE == binding.getKind();
	 }

	 @Override
	 public boolean visit(QualifiedName node) {
		 if (isTypeReference(node)) {
			 pushTypeReference(node.resolveTypeBinding());
		 } else {
			 String primitiveTypeRef = checkForPrimitiveTypeReference(node);
			 if (primitiveTypeRef != null) {
				 pushTypeOfExpression(new CSTypeReference(primitiveTypeRef));
			 } else {
				 handleRegularQualifiedName(node);
			 }
		 }
		 return false;
	 }

	 private void handleRegularQualifiedName(QualifiedName node) {
		 IVariableBinding vb = variableBinding(node);
		 if (vb != null) {
			 String mapped = mappedFieldName(vb);
			 if (null != mapped) {
				 if (isBoolLiteral(mapped)) {
					 pushExpression(new CSBoolLiteralExpression(Boolean.parseBoolean(mapped)));
					 return;
				 }
				 if (isMappingToStaticMember(mapped)) {
					 pushExpression(new CSReferenceExpression(mapped));
				 } else {
					 pushMemberReferenceExpression(node.getQualifier(), mapped);
				 }
				 return;
			 }
		 }
		 Name qualifier = node.getQualifier();
		 String name = identifier(node.getName().getIdentifier());
		 if ((vb != null) && vb.getDeclaringClass().isEnum()) {
			 ITypeBinding type = vb.getDeclaringClass();

			 CSExpression expr = my(CSharpDriver.class).mappedEnumAccess(this, qualifier, vb);
			 if (expr != null) {
				 pushExpression(expr);
				 return;
			 }

			 if (my(IBindingManager.class).getExtractedEnumInfo(type) != null) {
				 final ITypeBinding intType = my(IBindingManager.class).getIntType();
				 if (intType.equals(getExpectedType())) {
					 CSExpression typeRef = mappedTypeReference(type);
					 pushExpression(new CSMemberReferenceExpression(typeRef, name + "_ID"));
					 return;
				 }
			 }
		 }
		 if ((vb != null) && Modifier.isStatic(vb.getModifiers())) {
			 ITypeBinding type = vb.getDeclaringClass();
			 pushExpression(new CSMemberReferenceExpression(mappedTypeReference(type), name));
		 } else {
			 pushMemberReferenceExpression(qualifier, name);
		 }
	 }

	 private String checkForPrimitiveTypeReference(QualifiedName node) {
		 String name = qualifiedName(node);
		 if (name.equals(JAVA_LANG_VOID_TYPE))
			 return "void";
		 if (name.equals(JAVA_LANG_BOOLEAN_TYPE))
			 return "bool";
		 if (name.equals(JAVA_LANG_BYTE_TYPE))
			 return "byte";
		 if (name.equals(JAVA_LANG_CHARACTER_TYPE))
			 return "char";
		 if (name.equals(JAVA_LANG_SHORT_TYPE))
			 return "short";
		 if (name.equals(JAVA_LANG_INTEGER_TYPE))
			 return "int";
		 if (name.equals(JAVA_LANG_LONG_TYPE))
			 return "long";
		 if (name.equals(JAVA_LANG_FLOAT_TYPE))
			 return "float";
		 if (name.equals(JAVA_LANG_DOUBLE_TYPE))
			 return "double";
		 return null;
	 }

	 private String qualifiedName(QualifiedName node) {
		 IVariableBinding binding = variableBinding(node);
		 if (binding == null)
			 return node.toString();
		 return BindingUtils.qualifiedName(binding);
	 }

	 private void pushMemberReferenceExpression(Name qualifier, String name) {
		 pushExpression(new CSMemberReferenceExpression(mapExpression(qualifier), name));
	 }

	 private IVariableBinding variableBinding(Name node) {
		 if (node.resolveBinding() instanceof IVariableBinding) {
			 return (IVariableBinding) node.resolveBinding();
		 }
		 return null;
	 }

	 protected String mappedFieldName(IVariableBinding binding) {
		 return my(Mappings.class).mappedFieldName(binding);
	 }

	 protected CSExpression mapExpression(Expression expression) {
		 if (null == expression)
			 return null;

		 try {
			 expression.accept(this);
			 return popExpression();
		 } catch (Exception e) {
			 unsupportedConstruct(expression, e);
			 return null; // we'll never get here
		 }
	 }

	 private void unsupportedConstruct(ASTNode node, Exception cause) {
		 unsupportedConstruct(node, "failed to map: '" + node + "'", cause);
	 }

	 private void unsupportedConstruct(ASTNode node, String message) {
		 unsupportedConstruct(node, message, null);
	 }

	 private void unsupportedConstruct(ASTNode node, final String message, Exception cause) {
		 addProblem(node, ProblemKind.INTERNAL_ERROR, message + ": " + cause);
		 throw new IllegalArgumentException(sourceInformation(node) + ": " + message, cause);
	 }

	 public void addProblem(ASTNode node, ProblemKind kind, String message) {
		 _pair.addProblem(new SharpenProblem(_ast, node, kind, message));
	 }

	 public void addProblem(ASTNode node, ProblemKind kind, String message, Object... args) {
		 addProblem(node, kind, String.format(message, args));
	 }

	 private ITypeBinding getExpectedType() {
		 if (_currentExpectedType.size() > 0)
			 return _currentExpectedType.peek();
		 return null;
	 }

	 private void pushExpectedType(ITypeBinding type) {
		 _currentExpectedType.push(type);
	 }

	 private void popExpectedType() {
		 _currentExpectedType.pop();
	 }

	 protected void pushExpression(CSExpression expression) {
		 if (null != _currentExpression) {
			 throw new IllegalStateException();
		 }
		 _currentExpression = expression;
	 }

	 private CSExpression popExpression() {
		 if (null == _currentExpression) {
			 throw new IllegalStateException();
		 }
		 CSExpression found = _currentExpression;
		 _currentExpression = null;
		 return found;
	 }

	 private CSVariableDeclaration createParameter(SingleVariableDeclaration declaration) {
		 return createVariableDeclaration(declaration.resolveBinding(), null);
	 }

	 protected void visit(List nodes) {
		 for (Object node : nodes) {
			 ((ASTNode) node).accept(this);
		 }
	 }

	 private void createInheritedAbstractMemberStubs(TypeDeclaration node) {
		 if (node.isInterface())
			 return;

		 ITypeBinding binding = node.resolveBinding();
		 if (!Modifier.isAbstract(node.getModifiers()))
			 return;

		 for (ITypeBinding baseType : BindingUtils.getAllInterfaces(binding)) {
			 createInheritedAbstractMemberStubs(binding, baseType);
		 }
	 }

	 private void createInheritedAbstractMemberStubs(ITypeBinding type, ITypeBinding baseType) {
		 IMethodBinding[] methods = baseType.getDeclaredMethods();
		 for (int i = 0; i < methods.length; ++i) {
			 IMethodBinding method = methods[i];
			 if (!Modifier.isAbstract(method.getModifiers())) {
				 continue;
			 }
			 if (null != BindingUtils.findOverriddenMethodInTypeOrSuperclasses(type, method)) {
				 continue;
			 }
			 if (isIgnored(originalMethodBinding(method))) {
				 continue;
			 }
			 if (stubIsProperty(method)) {
				 _currentType.addMember(createAbstractPropertyStub(method));
			 } else {
				 CSMethod newMethod = createAbstractMethodStub(method);
				 // the same method might be defined in multiple
				 // interfaces
				 // but only a single stub must be created for
				 // those
				 if (!_currentType.members().contains(newMethod)) {
					 _currentType.addMember(newMethod);
				 }
			 }
		 }
	 }

	 private boolean isIgnored(IMethodBinding binding) {
		 final MethodDeclaration dec = declaringNode(binding);
		 return dec != null && SharpenAnnotations.hasIgnoreAnnotation(dec);
	 }

	 private boolean stubIsProperty(IMethodBinding method) {
		 final MethodDeclaration dec = declaringNode(method);
		 return dec != null && isProperty(dec);
	 }

	 private MethodDeclaration declaringNode(IMethodBinding method) {
		 return findDeclaringNode(method);
	 }

	 private CSProperty createAbstractPropertyStub(IMethodBinding method) {
		 CSProperty stub = newAbstractPropertyStubFor(method);
		 safeProcessDisableTags(method, stub);

		 return stub;
	 }

	 private CSProperty newAbstractPropertyStubFor(IMethodBinding method) {
		 CSProperty stub = new CSProperty(mappedMethodName(method), mappedTypeReference(method.getReturnType()));
		 stub.modifier(CSMethodModifier.Abstract);
		 stub.visibility(mapVisibility(method));
		 stub.getter(new CSBlock());
		 return stub;
	 }

	 private CSMethod createAbstractMethodStub(IMethodBinding method) {
		 CSMethod stub = newAbstractMethodStubFor(method);
		 safeProcessDisableTags(method, stub);

		 return stub;
	 }

	 private CSMethod newAbstractMethodStubFor(IMethodBinding method) {
		 CSMethod stub = new CSMethod(mappedMethodName(method));

		 stub.modifier(CSMethodModifier.Abstract);
		 stub.visibility(mapVisibility(method));
		 stub.returnType(mappedTypeReference(method.getReturnType()));

		 ITypeBinding[] parameters = method.getParameterTypes();
		 for (int i = 0; i < parameters.length; ++i) {
			 stub.addParameter(new CSVariableDeclaration("arg" + (i + 1), mappedTypeReference(parameters[i])));
		 }
		 return stub;
	 }

	 private void safeProcessDisableTags(IMethodBinding method, CSMember member) {
		 final MethodDeclaration node = declaringNode(method);
		 if (node == null)
			 return;

		 processDisableTags(node, member);
	 }

	 CSMethodModifier mapMethodModifier(MethodDeclaration method) {
		 if (_currentType.isInterface() || method.resolveBinding().getDeclaringClass().isInterface()) {
			 return CSMethodModifier.Abstract;
		 }
		 int modifiers = method.getModifiers();
		 if (Modifier.isStatic(modifiers)) {
			 return CSMethodModifier.Static;
		 }
		 if (Modifier.isPrivate(modifiers)) {
			 return CSMethodModifier.None;
		 }

		 boolean override = isOverride(method);
		 if (Modifier.isAbstract(modifiers)) {
			 return override ? CSMethodModifier.AbstractOverride : CSMethodModifier.Abstract;
		 }
		 boolean isFinal = Modifier.isFinal(modifiers);
		 if (override) {
			 return isFinal ? CSMethodModifier.Sealed : modifierIfNewAnnotationNotApplied(method,
					 CSMethodModifier.Override);
		 }
		 return isFinal || _currentType.isSealed() ? CSMethodModifier.None : CSMethodModifier.Virtual;
	 }

	 private CSMethodModifier modifierIfNewAnnotationNotApplied(MethodDeclaration method, CSMethodModifier modifier) {
		 return containsJavadoc(method, SharpenAnnotations.SHARPEN_NEW)
				 ? CSMethodModifier.None
						 : modifier;
	 }

	 private boolean isExtractedNestedType(ITypeBinding type) {
		 return _configuration.typeHasMapping(BindingUtils.typeMappingKey(type));
	 }

	 private boolean mustExtractRawType(ITypeBinding type) {
		 if (!type.isGenericType())
			 return false;
		 for (final ITypeBinding nested : type.getDeclaredTypes()) {
			 if (nested.isInterface() || nested.isEnum())
				 return true;
			 if (nested.isClass() && Modifier.isStatic(nested.getModifiers()))
				 return true;
			 if (mustExtractRawType(nested))
				 return true;
		 }
		 for (final IVariableBinding field : type.getDeclaredFields()) {
			 if (field.getConstantValue() != null)
				 return true;
		 }
		 return false;
	 }

	 private boolean extractIntoRawType(ITypeBinding type) {
		 if (type.isInterface() || type.isEnum())
			 return true;
		 if (Modifier.isStatic(type.getModifiers()))
			 return true;
		 return false;
	 }

	 private boolean isOverride(MethodDeclaration method) {
		 return null != getOverridedMethod(method);
	 }

	 private IMethodBinding getOverridedMethod(MethodDeclaration method) {
		 return getBaseMethod(method.resolveBinding(), true, false);
	 }

	 private IMethodBinding getOverridedMethod(IMethodBinding methodBinding) {
		 return getBaseMethod(methodBinding, true, false);
	 }

	 public IMethodBinding getBaseMethod(IMethodBinding methodBinding, boolean overrideOnly, boolean allowStatic) {
		 return BindingUtils.getBaseMethod(methodBinding, overrideOnly, allowStatic);
	 }

	 private boolean isValidCSInterface(ITypeBinding type) {
		 return BindingUtils.isValidCSInterface(type);
	 }

	 CSClassModifier mapClassModifier(int modifiers) {
		 if (Modifier.isAbstract(modifiers)) {
			 return CSClassModifier.Abstract;
		 }
		 if (Modifier.isFinal(modifiers)) {
			 return CSClassModifier.Sealed;
		 }
		 return CSClassModifier.None;
	 }

	 private CSVisibility mapVisibility(ITypeBinding type, boolean recursive) {
		 CSVisibility vis = my(CSharpDriver.class).mapVisibility(type);
		 if (vis != null)
			 return vis;

		 if (type.isPrimitive())
			 return CSVisibility.Public;

		 if (type.isArray())
			 vis = mapVisibility(type.getElementType());
		 else
			 vis = mapVisibility(type.getModifiers());

		 if (recursive)
			 return vis;

		 if (type.getSuperclass() != null)
			 vis = adjustVisibility(type, type.getSuperclass(), vis);

		 return vis;
	 }

	 private CSVisibility mapVisibility(ITypeBinding type) {
		 return mapVisibility(type, false);
	 }

	 private CSVisibility adjustVisibility(ITypeBinding type, ITypeBinding memberType, CSVisibility vis) {
		 CSVisibility typeVisibility = mapVisibility(memberType, true);
		 if (typeVisibility == CSVisibility.Protected && vis == CSVisibility.Internal)
			 vis = CSVisibility.Protected;
		 else if (typeVisibility == CSVisibility.Private)
			 vis = CSVisibility.Private;
		 else if (typeVisibility == CSVisibility.Internal) {
			 if ((vis == CSVisibility.Protected) || (vis == CSVisibility.ProtectedInternal)
					 || (vis == CSVisibility.Public))
				 vis = CSVisibility.Internal;
		 }

		 if (memberType.isParameterizedType()) {
			 List<ITypeBinding> tp = new ArrayList<ITypeBinding>();
			 for (ITypeBinding ta : type.getTypeParameters())
				 tp.add(ta);
			 for (ITypeBinding ta : memberType.getTypeArguments()) {
				 if (tp.contains(ta))
					 continue;
				 vis = adjustVisibility(type, ta, vis);
			 }
		 }

		 return vis;
	 }

	 private CSVisibility mapVisibility(int modifiers) {
		 if (Modifier.isPublic(modifiers)) {
			 return CSVisibility.Public;
		 }
		 if (Modifier.isProtected(modifiers)) {
			 return CSVisibility.ProtectedInternal;
		 }
		 if (Modifier.isPrivate(modifiers)) {
			 return CSVisibility.Private;
		 }
		 return CSVisibility.Internal;
	 }

	 protected CSTypeReferenceExpression mappedTypeReference(Type type) {
		 return mappedTypeReference(type.resolveBinding());
	 }

	 private CSTypeReferenceExpression mappedMacroTypeReference(ITypeBinding typeUsage,
			 final TypeDeclaration typeDeclaration) {

		 final CSMacro macro = new CSMacro(JavadocUtility.singleTextFragmentFrom(javadocTagFor(typeDeclaration,
				 SharpenAnnotations.SHARPEN_MACRO)));

		 final ITypeBinding[] typeArguments = typeUsage.getTypeArguments();
		 if (typeArguments.length > 0) {
			 final ITypeBinding[] typeParameters = typeUsage.getTypeDeclaration().getTypeParameters();
			 for (int i = 0; i < typeParameters.length; i++) {
				 macro.addVariable(typeParameters[i].getName(), mappedTypeReference(typeArguments[i]));
			 }
		 }

		 return new CSMacroTypeReference(macro);
	 }

	 private boolean isMacroType(final ASTNode declaration) {
		 return declaration instanceof TypeDeclaration
				 && containsJavadoc((TypeDeclaration) declaration, SharpenAnnotations.SHARPEN_MACRO);
	 }

	 public CSTypeReferenceExpression mappedTypeReference(ITypeBinding type) {
		 CSTypeReferenceExpression mapped = my(CSharpDriver.class).mappedTypeReference(this, type);
		 if (mapped != null)
			 return mapped;

		 final ASTNode declaration = findDeclaringNode(type);
		 if (isMacroType(declaration)) {
			 return mappedMacroTypeReference(type, (TypeDeclaration) declaration);
		 }

		 final ITypeBinding expected = getExpectedType();

		 if (type.isTypeVariable()) {
			 return new CSTypeReference(type.getName());
		 }
		 if (type.isArray()) {
			 if ((expected != null) && expected.isArray())
				 pushExpectedType(expected.getElementType());
			 else
				 pushExpectedType(null);
			 CSTypeReferenceExpression array = mappedArrayTypeReference(type);
			 popExpectedType();
			 return array;
		 }
		 if (type.isWildcardType()) {
			 return mappedWildcardTypeReference(type);
		 }
		 if (isJavaLangClass(type)) {
			 return new CSTypeReference(mappedTypeName(type));
		 }

		 if (type.isCapture()) {
			 return mappedWildcardTypeReference(type.getWildcard());
		 }

		 final String fullName = BindingUtils.qualifiedName(type);
		 if (fullName.equals("java.lang.reflect.Constructor")) {
			 return new CSTypeReference("System.Reflection.ConstructorInfo");
		 }

		 if ((expected != null) && isGenericInstance(expected)) {
			 ITypeBinding underlying = getUnderlyingGenericType(type);
			 ITypeBinding underlyingExpected = getUnderlyingGenericType(expected);
			 if ((underlying != null) && underlying.equals(underlyingExpected)) {
				 pushExpectedType(null);
				 CSTypeReferenceExpression retval = mappedTypeReference(expected);
				 popExpectedType();
				 return retval;
			 }
		 }

		 final ITypeBinding declaring = type.getDeclaringClass();
		 final boolean hasMapping = _configuration.typeHasMapping(BindingUtils.typeMappingKey(type));
		 if (type.isNested() && !type.isAnonymous() && !hasMapping && (declaring != null)) {
			 final String childName = identifier(type.getTypeDeclaration().getName());

			 CSTypeReferenceExpression parentRef;
			 if (declaring.isInterface()) {
				 final String parentName = extractedInterfaceName(declaring);
				 parentRef = new CSTypeReference(parentName);
			 } else if (extractIntoRawType(type)) {
				 final String parentName = mappedTypeName(declaring);
				 parentRef = new CSTypeReference(parentName);
			 } else {
				 parentRef = mappedTypeReference(declaring);
			 }

			 final CSTypeReferenceExpression childRef = mappedSimpleTypeReference(type, childName);
			 CSNestedTypeReference nestedRef = new CSNestedTypeReference(parentRef, childRef);
			 return nestedRef;
		 }

		 return mappedSimpleTypeReference(type, mappedTypeName(type));
	 }

	 private CSTypeReferenceExpression mappedVariableType(IVariableBinding binding) {
		 CSTypeReferenceExpression type = my(CSharpDriver.class).mappedVariableType(binding);
		 if (type != null)
			 return type;

		 return mappedTypeReference(binding.getType());
	 }

	 private boolean isJavaLangClass(ITypeBinding type) {
		 return type.getErasure() == _classType;
	 }

	 private CSTypeReferenceExpression mappedWildcardTypeReference(ITypeBinding type) {
		 final ITypeBinding bound = type.getBound();

		 if (_currentWildcardParams != null) {
			 String tp = _currentWildcardParams.get(type);
			 if (tp != null)
				 return new CSTypeReference(tp);
		 }

		 if (bound != null)
			 return mappedTypeReference(bound);

		 if (_currentType != null) {
			 if (_currentType.typeParameters().size() == 1)
				 return new CSTypeReference(_currentType.typeParameters().get(0).name());
		 }

		 return OBJECT_TYPE_REFERENCE;
	 }

	 private CSTypeReferenceExpression mappedArrayTypeReference(ITypeBinding type) {
		 return new CSArrayTypeReference(mappedTypeReference(type.getElementType()), type.getDimensions());

	 }

	 public CSTypeReferenceExpression mappedSimpleTypeReference(ITypeBinding type, String name) {
		 final CSTypeReference typeRef = new CSTypeReference(name);
		 addTypeArguments(typeRef, type);
		 return typeRef;
	 }

	 private static class GenericContext {
		 public final ITypeBinding type;
		 public final ITypeBinding[] tparams;

		 private GenericContext(ITypeBinding type, ITypeBinding[] tparams) {
			 this.type = type;
			 this.tparams = tparams;
		 }

		 public GenericContext(IMethodBinding method) {
			 this(method.getDeclaringClass(), method.getTypeParameters());
		 }

		 public static GenericContext create(ITypeBinding type) {
			 while (type.isNested() && !type.isGenericType() && !type.isParameterizedType()) {
				 type = type.getDeclaringClass();
			 }
			 while ((type != null) && !type.isGenericType() && !type.isParameterizedType()) {
				 type = type.getSuperclass();
			 }
			 if (type == null)
				 return null;
			 if (type.isParameterizedType())
				 return new GenericContext(type, type.getTypeArguments());
			 else if (type.isGenericType())
				 return new GenericContext(type, type.getTypeParameters());
			 return null;
		 }
	 }

	 private GenericContext getGenericContext() {
		 final IMethodBinding method;
		 if (_currentBodyDeclaration instanceof MethodDeclaration)
			 method = ((MethodDeclaration) _currentBodyDeclaration).resolveBinding();
		 else
			 method = null;

		 if ((method != null) && method.isGenericMethod())
			 return new GenericContext(method);

		 if (_currentTypeDeclaration != null)
			 return GenericContext.create(_currentTypeDeclaration.resolveBinding());
		 else if (method != null)
			 return GenericContext.create(method.getDeclaringClass());
		 else
			 return null;
	 }

	 private void addTypeArguments(CSTypeReference typeRef, ITypeBinding type) {
		 if (_addTypeArguments(typeRef, type))
			 return;

		 final ITypeBinding[] tparams = type.getTypeDeclaration().getTypeParameters();
		 for (ITypeBinding tparam : tparams) {
			 ITypeBinding sclass = mapTypeParameterExtendedType(tparam);
			 if (sclass == null)
				 typeRef.addTypeArgument(OBJECT_TYPE_REFERENCE);
			 else
				 typeRef.addTypeArgument(mappedTypeReference(sclass));
		 }
	 }

	 private boolean _addTypeArguments(CSTypeReference typeRef, ITypeBinding type) {
		 final ITypeBinding[] targs = type.getTypeArguments();
		 if (targs.length > 0) {
			 for (ITypeBinding arg : targs) {
				 typeRef.addTypeArgument(mappedTypeReference(arg));
			 }
			 return true;
		 }

		 GenericContext context = getGenericContext();
		 if (context == null)
			 return false;

		 ITypeBinding declType = type.getTypeDeclaration();

		 if (context.type.isGenericType() && context.type.isEqualTo(declType)
				 || isNestedInside(context.type, declType)
				 || (declType.getTypeParameters().length == context.tparams.length)) {
			 for (ITypeBinding arg : context.tparams) {
				 typeRef.addTypeArgument(mappedTypeReference(arg));
			 }
			 return true;
		 }

		 return false;
	 }

	 protected boolean isNestedInside(ITypeBinding parent, ITypeBinding child) {
		 if (!child.isNested())
			 return false;
		 while ((child = child.getSuperclass()) != null) {
			 if (child.isEqualTo(parent))
				 return true;
		 }

		 return false;
	 }

	 protected final String mappedTypeName(ITypeBinding type) {
		 final String mapped = my(CSharpDriver.class).mappedTypeName(this, type);
		 if (mapped != null)
			 return mapped;
		 return my(Mappings.class).mappedTypeName(type);
	 }

	 private final String extractedInterfaceName(ITypeBinding type) {
		 return my(Mappings.class).extractedInterfaceName(type);
	 }

	 private static String qualifiedName(ITypeBinding type) {
		 return BindingUtils.qualifiedName(type);
	 }

	 private String interfaceName(String name) {
		 return my(Configuration.class).toInterfaceName(name);
	 }

	 private String mappedTypeName(String typeName) {
		 return mappedTypeName(typeName, typeName);
	 }

	 private String mappedTypeName(String typeName, String defaultValue) {
		 return _configuration.mappedTypeName(typeName, defaultValue);
	 }

	 private String annotatedRenaming(BodyDeclaration node) {
		 return my(Annotations.class).annotatedRenaming(node);
	 }

	 protected String mappedMethodName(MethodDeclaration node) {
		 return mappedMethodName(node.resolveBinding());
	 }

	 protected final String mappedMethodName(IMethodBinding binding) {
		 return my(Mappings.class).mappedMethodName(binding);
	 }

	 private String qualifiedName(IMethodBinding actual) {
		 return BindingUtils.qualifiedName(actual);
	 }

	 private boolean isEvent(MethodDeclaration declaring) {
		 return eventTagFor(declaring) != null;
	 }

	 private boolean isMappedToProperty(MethodDeclaration original) {
		 final MemberMapping mapping = effectiveMappingFor(original.resolveBinding());
		 if (null == mapping)
			 return false;
		 return mapping.kind == MemberKind.Property;
	 }

	 private boolean isMappedToIndexer(MethodDeclaration original) {
		 final MemberMapping mapping = effectiveMappingFor(original.resolveBinding());
		 if (null == mapping)
			 return false;
		 return mapping.kind == MemberKind.Indexer;
	 }

	 private MemberMapping effectiveMappingFor(IMethodBinding binding) {
		 return my(Mappings.class).effectiveMappingFor(binding);
	 }

	 private String methodName(String name) {
		 return namingStrategy().methodName(name);
	 }

	 protected String identifier(SimpleName name) {
		 return identifier(name.toString());
	 }

	 protected String identifier(String name) {
		 return namingStrategy().identifier(name);
	 }

	 private void unresolvedTypeBinding(ASTNode node) {
		 warning(node, "unresolved type binding for node: " + node);
	 }

	 @Override
	 public boolean visit(CompilationUnit node) {
		 return true;
	 }

	 private void warning(ASTNode node, String message) {
		 warningHandler().warning(node, message);
	 }

	 protected final String sourceInformation(ASTNode node) {
		 return ASTUtility.sourceInformation(_ast, node);
	 }

	 @SuppressWarnings("deprecation")
	 protected int lineNumber(ASTNode node) {
		 return _ast.lineNumber(node.getStartPosition());
	 }

	 public void setASTResolver(ASTResolver resolver) {
		 _resolver = resolver;
	 }

	 private String mappedNamespace(String namespace) {
		 return _configuration.mappedNamespace(namespace);
	 }

	 @Override
	 public boolean visit(Block node) {
		 if (isBlockInsideBlock(node)) {
			 CSBlock parent = _currentBlock;
			 _currentBlock = new CSBlock();
			 _currentBlock.parent(parent);
			 parent.addStatement(_currentBlock);
		 }
		 _currentContinueLabel = null;
		 return super.visit(node);
	 }

	 @Override
	 public void endVisit(Block node) {
		 if (isBlockInsideBlock(node)) {
			 _currentBlock = (CSBlock) _currentBlock.parent();
		 }
		 super.endVisit(node);
	 }

	 boolean isBlockInsideBlock(Block node) {
		 return node.getParent() instanceof Block;
	 }

}
