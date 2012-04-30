package sharpen.xobotos.api.bindings;

import org.eclipse.jdt.core.dom.*;

import sharpen.core.Sharpen;
import sharpen.core.SharpenProblem;
import sharpen.core.SharpenProblem.ProblemKind;
import sharpen.core.csharp.ast.*;
import sharpen.core.framework.BindingUtils;
import sharpen.core.framework.CompilationUnitPair;
import sharpen.core.framework.IBindingManager;
import sharpen.core.framework.Types;
import sharpen.xobotos.api.TypeReference;
import sharpen.xobotos.api.Visibility;
import sharpen.xobotos.api.interop.*;
import sharpen.xobotos.api.interop.NativeMethodBuilder.ElementInfo;
import sharpen.xobotos.api.interop.Signature.Flags;
import sharpen.xobotos.api.interop.marshal.MarshalAsBoolean;
import sharpen.xobotos.api.interop.marshal.MarshalAsNativeType;
import sharpen.xobotos.api.interop.marshal.MarshalAsPrimitive;
import sharpen.xobotos.api.interop.marshal.MarshalInfo;
import sharpen.xobotos.api.templates.*;
import sharpen.xobotos.generator.CompilationUnitBuilder;
import sharpen.xobotos.generator.SharpenGenerator;
import sharpen.xobotos.output.IOutputProvider;
import sharpen.xobotos.output.OutputMode;
import sharpen.xobotos.output.OutputType;

import java.util.*;
import java.util.logging.Level;

public class BindingManager implements IBindingManager {
	private final NativeConfiguration _nativeConfig;
	private final HashMap<CompilationUnit, Visitor> _compilationUnits = new HashMap<CompilationUnit, Visitor>();
	private final HashMap<ITypeBinding, AbstractTypeBinding> _typeBindings = new HashMap<ITypeBinding, AbstractTypeBinding>();
	private final HashMap<IMethodBinding, MethodBinding> _methodBindings = new HashMap<IMethodBinding, MethodBinding>();
	private final HashMap<IVariableBinding, VariableBinding> _variableBindings = new HashMap<IVariableBinding, VariableBinding>();
	private final HashMap<IMethodBinding, NativeMethodEntry> _nativeMethods = new HashMap<IMethodBinding, NativeMethodEntry>();
	private final HashMap<ITypeBinding, NativeTypeEntry> _nativeTypes = new HashMap<ITypeBinding, NativeTypeEntry>();
	private final HashMap<ITypeBinding, ArrayHelperClass> _sharedArrayHelpers = new HashMap<ITypeBinding, ArrayHelperClass>();
	private final HashMap<IMethodBinding, MethodEntry> _methodHash = new HashMap<IMethodBinding, MethodEntry>();
	private final ITypeBinding _objectType;
	private final ITypeBinding _classType;
	private final ITypeBinding _stringType;
	private final ITypeBinding _charType;
	private final ITypeBinding _byteType;
	private final ITypeBinding _boolType;
	private final ITypeBinding _intType;
	private final ITypeBinding _longType;
	private final ITypeBinding _floatType;
	private final ITypeBinding _serializableType;

	private final MarshalInfo _charMarshal;
	private final MarshalInfo _byteMarshal;
	private final MarshalInfo _boolMarshal;

	private NativeBuilder _sharedNativeBuilder;
	private CSCompilationUnit _sharedManagedBuilder;
	private CSClass _sharedTypedef;
	private StringHelperClass _stringHelper;
	private MarshalInfo _stringMarshal;

	public static final CSTypeReference MANAGED_SHARED_HELPER = new CSTypeReference("XobotOS.Runtime.MarshalGlue");

	public static boolean DEBUG = false;

	public BindingManager(AST ast, NativeConfiguration config) {
		this._nativeConfig = config;

		_objectType = resolveWellKnownType(ast, "java.lang.Object");
		_classType = resolveWellKnownType(ast, "java.lang.Class");
		_stringType = resolveWellKnownType(ast, "java.lang.String");
		_charType = resolveWellKnownType(ast, "char");
		_byteType = resolveWellKnownType(ast, "byte");
		_boolType = resolveWellKnownType(ast, "boolean");
		_intType = resolveWellKnownType(ast, "int");
		_longType = resolveWellKnownType(ast, "long");
		_floatType = resolveWellKnownType(ast, "float");
		_serializableType = resolveWellKnownType(ast, "java.io.Serializable");

		_charMarshal = new MarshalAsPrimitive(_charType, "char", "char16_t");
		_byteMarshal = new MarshalAsPrimitive(_byteType, "byte", "uint8_t");
		_boolMarshal = new MarshalAsBoolean(_boolType);
	}

	private ITypeBinding resolveWellKnownType(AST ast, String name) {
		ITypeBinding type = ast.resolveWellKnownType(name);
		if (type == null)
			throw new RuntimeException(String.format("Cannot resolve well known type '%s'", name));
		return type;
	}

	public CompilationUnitBuilder preprocess(CompilationUnitPair pair, CompilationUnitTemplate template,
			String name,
			IOutputProvider defaultOutput) {
		Visitor visitor = new Visitor(pair, template, name, defaultOutput);
		_compilationUnits.put(pair.ast, visitor);
		pair.ast.accept(visitor);
		visitor.setup();
		return visitor;
	}

	private NativeBuilder createNativeBuilder(NativeConfiguration config, String name) {
		if (_sharedNativeBuilder == null) {
			_sharedNativeBuilder = new NativeBuilder(config, "XobotOS.MarshalGlue");
			_sharedManagedBuilder = new CSCompilationUnit();
			_sharedManagedBuilder.namespace("XobotOS.Runtime");

			_sharedTypedef = new CSClass("MarshalGlue", CSClassModifier.Static);
			_sharedTypedef.visibility(CSVisibility.Internal);

			_sharedManagedBuilder.addType(_sharedTypedef);
			_sharedManagedBuilder.addUsing(new CSUsing("System.Runtime.InteropServices"));

			_stringHelper = new StringHelperClass(_sharedNativeBuilder, _stringType);
			_stringMarshal = new MarshalAsNativeType(_stringType, _stringHelper);
			_sharedNativeBuilder.registerNativeType(_stringHelper);

			createSharedArrayHelper(_charType, _charMarshal);
			createSharedArrayHelper(_byteType, _byteMarshal);
			createSharedArrayHelper(_intType, new MarshalAsPrimitive(_intType, "int", "int"));
			createSharedArrayHelper(_longType, new MarshalAsPrimitive(_longType, "long", "long"));
			createSharedArrayHelper(_floatType, new MarshalAsPrimitive(_floatType, "float", "float"));
		}

		NativeBuilder builder = new NativeBuilder(config, name);
		builder.getCompilationUnit().getIncludeSection().addInclude(_sharedNativeBuilder.getHeaderInclude());
		return builder;
	}

	private void createSharedArrayHelper(ITypeBinding type, MarshalInfo marshal) {
		ElementInfo info = new ElementInfo(type, marshal, null, Flags.ELEMENT);

		ArrayHelperClass helper = new ArrayHelperClass(type, "Array_" + type.getName(),
				_sharedNativeBuilder, info, true);
		_sharedArrayHelpers.put(type, helper);

		_sharedNativeBuilder.registerNativeType(helper);
	}

	public boolean resolveTypes() {
		boolean ok = true;

		for (Visitor visitor : _compilationUnits.values()) {
			if (!visitor.resolveTypes()) {
				Sharpen.Log(Level.SEVERE, "Failed to resolve native type '%s'", visitor.getName());
				ok = false;
			}
		}

		for (Visitor visitor : _compilationUnits.values()) {
			if (!visitor.resolveMethods()) {
				Sharpen.Log(Level.SEVERE, "Failed to resolve native type '%s'", visitor.getName());
				ok = false;
			}
		}

		for (Visitor visitor : _compilationUnits.values()) {
			if (!visitor.emitHelpers()) {
				Sharpen.Log(Level.SEVERE, "Failed to resolve native type '%s'", visitor.getName());
				ok = false;
			}
		}

		return ok;
	}

	public boolean postProcess() {
		if (_sharedNativeBuilder == null)
			return true;

		_sharedNativeBuilder.build(true);
		_stringHelper.createManagedType(_sharedTypedef);
		for (ArrayHelperClass helper : _sharedArrayHelpers.values())
			helper.createManagedType(_sharedTypedef);

		if (!_sharedNativeBuilder.printManagedType(_sharedManagedBuilder))
			return false;

		return _sharedNativeBuilder.writeOutput();
	}

	@Override
	public ITypeBinding getObjectType() {
		return _objectType;
	}

	@Override
	public ITypeBinding getClassType() {
		return _classType;
	}

	@Override
	public ITypeBinding getStringType() {
		return _stringType;
	}

	@Override
	public ITypeBinding getCharType() {
		return _charType;
	}

	@Override
	public ITypeBinding getByteType() {
		return _byteType;
	}

	@Override
	public ITypeBinding getIntType() {
		return _intType;
	}

	@Override
	public ITypeBinding getLongType() {
		return _longType;
	}

	@Override
	public ITypeBinding getFloatType() {
		return _floatType;
	}

	@Override
	public ITypeBinding getSerializableType() {
		return _serializableType;
	}

	public boolean isBlittable(ITypeBinding type) {
		return type.equals(_byteType) || type.equals(_charType) || type.equals(_floatType) ||
				type.equals(_intType) || type.equals(_longType) || type.equals(_boolType);
	}

	public AbstractTypeBinding resolveBinding(ITypeBinding binding) {
		return _typeBindings.get(binding.getTypeDeclaration());
	}

	public MethodBinding resolveBinding(IMethodBinding binding) {
		return _methodBindings.get(binding.getMethodDeclaration());
	}

	public VariableBinding resolveBinding(IVariableBinding binding) {
		return _variableBindings.get(binding.getVariableDeclaration());
	}

	public NativeMethodBuilder resolveNativeBinding(IMethodBinding binding) {
		NativeMethodEntry entry = _nativeMethods.get(binding.getMethodDeclaration());
		return entry != null ? entry.Builder : null;
	}

	public AbstractNativeTypeBuilder getNativeTypeBuilder(ITypeBinding binding) {
		if (binding.equals(_stringType))
			return _stringHelper;
		NativeTypeEntry entry = _nativeTypes.get(binding.getTypeDeclaration());
		return entry != null ? entry.Builder : null;
	}

	public MethodEntry lookupMethod(IMethodBinding binding) {
		return _methodHash.get(binding.getMethodDeclaration());
	}

	@Override
	public ITypeInfo getTypeInfo(ITypeBinding type) {
		AbstractTypeBinding binding = _typeBindings.get(type.getTypeDeclaration());
		if (binding instanceof TypeBinding)
			return (TypeBinding) binding;
		else
			return null;
	}

	@Override
	public IMethodInfo getMethodInfo(IMethodBinding method) {
		return _methodBindings.get(method.getMethodDeclaration());
	}

	@Override
	public IMethodBinding getBaseMethod(IMethodBinding method) {
		MethodEntry entry = _methodHash.get(method.getMethodDeclaration());
		return entry != null ? entry.BaseMethod : null;
	}

	@Override
	public IVariableInfo getVariableInfo(IVariableBinding variable) {
		return _variableBindings.get(variable.getVariableDeclaration());
	}

	@Override
	public IExtractedEnumInfo getExtractedEnumInfo(ITypeBinding type) {
		AbstractTypeBinding binding = resolveBinding(type);
		if (binding instanceof EnumBinding)
			return ((EnumBinding) binding).getExtractionInfo();

		return null;
	}

	public static boolean reportStubUsage() {
		return false;
	}

	private class Visitor extends ASTVisitor implements CompilationUnitBuilder {

		private final CompilationUnitPair _pair;
		private final CompilationUnitTemplate _template;
		private final String _name;
		private final CSCompilationUnit _unit;
		private final SharpenGenerator _generator;
		private final Stack<ITypeEntry> _typeStack = new Stack<ITypeEntry>();
		private final Stack<IOutputProvider> _outputProviderStack = new Stack<IOutputProvider>();
		private final Stack<ScopeEntry> _scopeStack = new Stack<ScopeEntry>();
		private final List<NativeMethodEntry> _nativeMethodList = new ArrayList<NativeMethodEntry>();
		private final List<NativeTypeEntry> _nativeTypeList = new ArrayList<NativeTypeEntry>();
		private final HashMap<ITypeBinding, ArrayHelperClass> _arrayHelpers = new HashMap<ITypeBinding, ArrayHelperClass>();

		private NativeBuilder _nativeBuilder;
		private ITypeBinding _nativeTypeContainer;
		private boolean _needsHeader;
		private MethodEntry _currentMethod;

		public Visitor(CompilationUnitPair pair, CompilationUnitTemplate template, String name,
				IOutputProvider defaultOutput) {
			this._pair = pair;
			this._template = template;
			this._name = name;
			this._unit = new CSCompilationUnit();

			if (defaultOutput != null)
				_outputProviderStack.push(defaultOutput);
			_outputProviderStack.push(template);

			_generator = new Generator(defaultOutput);
		}

		private void setup() {
			if (_nativeTypeContainer == null)
				return;

			_nativeBuilder = createNativeBuilder(_nativeConfig, _name);
			_unit.addUsing(new CSUsing("System.Runtime.InteropServices"));
		}

		@Override
		public String getName() {
			return _name;
		}

		@Override
		public CompilationUnitPair getPair() {
			return _pair;
		}

		@Override
		public CompilationUnitTemplate getTemplate() {
			return _template;
		}

		@Override
		public CSCompilationUnit getCompilationUnit() {
			return _unit;
		}

		@Override
		public NativeBuilder getNativeBuilder() {
			return _nativeBuilder;
		}

		private ITypeContainer getCurrentType() {
			if (_typeStack.size() == 0)
				return _template;
			return _typeStack.peek().getTemplate();
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

		private void pushScope() {
			ScopeEntry scope;
			if (_scopeStack.size() > 0)
				scope = new ScopeEntry(_scopeStack.peek());
			else
				scope = new ScopeEntry();
			_scopeStack.push(scope);
		}

		private ScopeEntry getScope() {
			return _scopeStack.peek();
		}

		private void popScope() {
			_scopeStack.pop();
		}

		@Override
		public boolean visit(AnonymousClassDeclaration node) {
			final IMemberContainer type = _typeStack.peek().getTemplate();
			final AnonymousClassTemplate template = type.findAnonymousClassTemplate(node);
			if (template == null)
				return false;

			final OutputType output = getOutputType();
			final OutputMode mode = output.getModeForMember(node);

			if (mode == OutputMode.NOTHING)
				return false;

			ITypeEntry entry = new AnonymousClassEntry(node, template, output);
			_outputProviderStack.push(template);
			_typeStack.push(entry);

			for (final Object o : node.bodyDeclarations()) {
				if (!(o instanceof ASTNode))
					continue;
				ASTNode member = (ASTNode) o;
				member.accept(this);
			}

			_typeStack.pop();
			_outputProviderStack.pop();
			return false;
		}

		@Override
		public boolean visit(CompilationUnit node) {
			return true;
		}

		@Override
		public boolean visit(EnumDeclaration node) {
			final EnumTemplate template = getCurrentType().findEnumTemplate(node);
			if (template == null)
				return false;

			EnumBinding binding = template.getBinding();
			if (binding != null)
				_typeBindings.put(node.resolveBinding(), binding);

			return false;
		}

		@Override
		public boolean visit(TypeDeclaration node) {
			final TypeTemplate template = getCurrentType().findTypeTemplate(node);
			if (template == null)
				return false;

			final ITypeBinding typeBinding = node.resolveBinding();

			final NativeTypeEntry nativeType;
			if (template.getNativeType() != null) {
				if (_nativeTypeContainer == null)
					_nativeTypeContainer = typeBinding;

				nativeType = new NativeTypeEntry(typeBinding, template.getNativeType());
				_nativeTypes.put(typeBinding, nativeType);
				_nativeTypeList.add(nativeType);
			} else if (template.getNativeHandle() != null) {
				if (_nativeTypeContainer == null)
					_nativeTypeContainer = typeBinding;

				nativeType = new NativeTypeEntry(typeBinding, template.getNativeHandle());
				_nativeTypes.put(typeBinding, nativeType);
				_nativeTypeList.add(nativeType);
			} else if (template.getNativeStruct() != null) {
				if (_nativeTypeContainer == null)
					_nativeTypeContainer = typeBinding;

				nativeType = new NativeTypeEntry(typeBinding, template.getNativeStruct());
				_nativeTypes.put(typeBinding, nativeType);
				_nativeTypeList.add(nativeType);
			} else {
				nativeType = null;
			}

			_outputProviderStack.push(template);

			final OutputType output = getOutputType();

			TypeEntry type = new TypeEntry(node, template, output, nativeType);
			_typeStack.push(type);

			TypeBinding binding = template.getBinding();
			if (binding != null) {
				_typeBindings.put(typeBinding, binding);

				if (binding.isEventInterface())
					checkValidEventInterface(node);
			}

			for (final Object o : node.bodyDeclarations()) {
				if (!(o instanceof ASTNode))
					continue;
				ASTNode member = (ASTNode) o;
				member.accept(this);
			}

			_typeStack.pop();
			_outputProviderStack.pop();
			return false;
		}

		@Override
		public boolean visit(FieldDeclaration node) {
			final ITypeEntry entry = _typeStack.peek();
			final FieldTemplate template = entry.getTemplate().findFieldTemplate(node);
			if (template == null)
				return false;

			final NativeHandle nativeHandle;
			final NativeTypeEntry nativeType = entry.getNativeType();
			if ((nativeType != null) && (nativeType.Template instanceof NativeHandle))
				nativeHandle = (NativeHandle) nativeType.Template;
			else
				nativeHandle = null;

			VariableBinding binding = template.getBinding();

			for (Object o : node.fragments()) {
				VariableDeclarationFragment fragment = (VariableDeclarationFragment) o;
				final IVariableBinding vb = fragment.resolveBinding();
				final String name = vb.getName();
				if ((nativeHandle != null) && name.equals(nativeHandle.getField()))
					nativeHandleField(vb, nativeHandle);
				else if (binding != null)
					_variableBindings.put(vb, binding);

				checkFieldAndMethodNameClash(fragment, vb);

				if (fragment.getInitializer() != null)
					fragment.getInitializer().accept(this);
			}

			return false;
		}

		void nativeHandleField(IVariableBinding binding, final NativeHandle handle) {
			_variableBindings.put(binding, new VariableBinding() {
				@Override
				public boolean isPointer() {
					return false;
				}

				@Override
				public NativeHandle getNativeHandle() {
					return handle;
				}
			});
		}

		private void checkFieldAndMethodNameClash(VariableDeclarationFragment node, IVariableBinding binding) {
			final ITypeBinding declType = binding.getDeclaringClass();
			final String name = binding.getName();

			final List<String> visibleMethods = getVisibleMethodNames(declType);
			if (!visibleMethods.contains(name))
				return;

			int mods = binding.getModifiers();
			boolean isNonPrivate = Modifier.isPublic(mods) || Modifier.isProtected(mods);
			if (isNonPrivate && !autoRenameFields()) {
				addProblem(node, ProblemKind.PARSING_ERROR,
						"Non-private field %s.%s clashes with visible method",
						BindingUtils.qualifiedName(declType), name);
			}

			int i = 0;
			String newName = name.startsWith("_") ? name + '_' + (++i) : '_' + name;
			while (visibleMethods.contains(newName)) {
				newName = name + '_' + (++i);
			}
			final String renamed = newName;

			addRenamedVariable(binding, renamed);
		}

		private boolean autoRenameFields() {
			CompilationUnitBinding binding = _template.getBinding();
			if (binding == null)
				return false;

			return binding.autoRenameFields();
		}

		@Override
		public boolean visit(MethodDeclaration node) {
			final ITypeEntry entry = _typeStack.peek();
			final AbstractMethodTemplate<?> template = entry.getTemplate().findMethodTemplate(node);
			if (template == null)
				return false;

			pushScope();

			final IMethodBinding methodBinding = node.resolveBinding();

			MethodBinding binding = template.getBinding();
			if (binding != null)
				_methodBindings.put(methodBinding, binding);

			final ASTNode parent = node.getParent();
			final ITypeBinding declaringType;
			if (parent instanceof TypeDeclaration) {
				declaringType = ((TypeDeclaration) parent).resolveBinding();
			} else if (parent instanceof AnonymousClassDeclaration) {
				declaringType = ((AnonymousClassDeclaration) parent).resolveBinding();
			} else {
				declaringType = null;
			}

			if (declaringType != null) {
				List<String> visibleMethods = getVisibleMethodNames(declaringType);
				getScope().addVisibleMethods(visibleMethods);
			}

			int index = 0;
			for (final Object p : node.parameters()) {
				final VariableDeclaration vdecl = (VariableDeclaration) p;
				final IVariableBinding vb = vdecl.resolveBinding();

				ParameterTemplate param = template.findParameterTemplate(index++);
				if (param != null) {
					VariableBinding pb = param.getBinding();
					if (pb != null)
						_variableBindings.put(vb, pb);
				}

				createVariableDeclaration(vb);
			}

			if ((template instanceof MethodTemplate) && (entry instanceof TypeEntry)) {
				MethodTemplate mt = (MethodTemplate) template;
				if (Modifier.isNative(node.getModifiers()) || (mt.getNativeMethod() != null))
					addNativeMethod((TypeEntry) entry, (MethodTemplate) template, node);
			}

			_outputProviderStack.push(template);

			final OutputType output = getOutputType();

			final MethodEntry oldMethod = _currentMethod;

			final IMethodBinding baseMethod = BindingUtils.getBaseMethod(methodBinding, false, false);

			_currentMethod = new MethodEntry(node, template, baseMethod, output);
			_methodHash.put(node.resolveBinding(), _currentMethod);

			Block body = node.getBody();
			if (body != null)
				body.accept(this);

			popScope();

			_currentMethod = oldMethod;
			_outputProviderStack.pop();

			return false;
		}

		@Override
		public boolean visit(VariableDeclarationFragment node) {
			final IVariableBinding vb = node.resolveBinding();

			if (_currentMethod != null) {
				VariableTemplate template = _currentMethod.Template.findVariableTemplate(node);
				if (template != null) {
					VariableBinding binding = template.getBinding();
					if (binding != null)
						_variableBindings.put(vb, binding);
				}
			}

			createVariableDeclaration(vb);
			return false;
		}

		private void createVariableDeclaration(IVariableBinding binding) {
			final ScopeEntry scope = getScope();
			final String name = binding.getName();

			final String renamed = scope.renameVariable(binding, name);
			if (renamed != null)
				addRenamedVariable(binding, renamed);
		}

		private void addNativeMethod(TypeEntry type, MethodTemplate template, MethodDeclaration node) {
			if ((template == null) || (template.getNativeMethod() == null) || (type.NativeType == null))
				return;

			final NativeMethod method = template.getNativeMethod();
			final IMethodBinding binding = node.resolveBinding();

			NativeMethodEntry entry = new NativeMethodEntry(type.NativeType, node, method);
			_nativeMethods.put(binding, entry);
			_nativeMethodList.add(entry);
		}

		private void addRenamedVariable(IVariableBinding binding, String name) {
			VariableBinding old = _variableBindings.get(binding);
			VariableBinding renamed = new RenamedVariable(old, name);
			_variableBindings.put(binding, renamed);
		}

		@Override
		public boolean visit(Block node) {
			pushScope();
			return super.visit(node);
		}

		@Override
		public void endVisit(Block node) {
			popScope();
			super.endVisit(node);
		}

		@Override
		public boolean visit(TryStatement node) {
			node.getBody().accept(this);
			for (Object o : node.catchClauses()) {
				CatchClause clause = (CatchClause) o;
				pushScope();
				clause.accept(this);
				popScope();
			}
			if (node.getFinally() != null)
				node.getFinally().accept(this);
			return true;
		}

		private void collectVisibleMethodNames(ArrayList<String> list, ITypeBinding type) {
			for (final IMethodBinding method : type.getDeclaredMethods()) {
				if (!list.contains(method.getName()))
					list.add(method.getName());
			}

			ITypeBinding superClass = type.getSuperclass();
			if (superClass != null)
				collectVisibleMethodNames(list, superClass);

			for (final ITypeBinding iface : type.getInterfaces()) {
				collectVisibleMethodNames(list, iface);
			}
		}

		protected List<String> getVisibleMethodNames(ITypeBinding type) {
			ArrayList<String> list = new ArrayList<String>();
			collectVisibleMethodNames(list, type);
			return Collections.unmodifiableList(list);
		}

		private void addProblem(ASTNode node, ProblemKind kind, String message, Object... args) {
			_pair.addProblem(new SharpenProblem(_pair.ast, node, kind, String.format(message, args)));
		}

		private void addProblem(ASTNode node, String message, Object... args) {
			addProblem(node, ProblemKind.PARSING_ERROR, message, args);
		}

		private boolean checkValidEventInterface(TypeDeclaration node) {
			final ITypeBinding type = node.resolveBinding();
			final ITypeBinding declType = type.getDeclaringClass().getTypeDeclaration();

			if (!type.isInterface() || !type.isNested()) {
				addProblem(node, "Type '%s' is not a valid even interface.",
						BindingUtils.qualifiedName(type));
				return false;
			}

			for (ASTNode member : Types.<ASTNode> cast(node.bodyDeclarations())) {
				if (!(member instanceof MethodDeclaration)) {
					addProblem(node, "Event interface '%s' must only contain methods.",
							BindingUtils.qualifiedName(type));
					return false;

				}
			}

			for (MethodDeclaration method : node.getMethods()) {
				final IMethodBinding binding = method.resolveBinding();
				final ITypeBinding[] ptypes = binding.getParameterTypes();

				if (ptypes.length < 1) {
					addProblem(node,
							"Method '%s' in event interface must have at least one parameter.",
							BindingUtils.qualifiedSignature(binding));
					return false;
				}

				ITypeBinding sender = ptypes[0];
				if (!sender.getTypeDeclaration().equals(declType)) {
					addProblem(node, "Method '%s' in event interface has invalid first argument.",
							BindingUtils.qualifiedSignature(binding));
					return false;
				}
			}

			return true;
		}

		public boolean resolveTypes() {
			final IMarshalContext context = new IMarshalContext() {
				@Override
				public NativeConfiguration getConfig() {
					return _nativeConfig;
				}

				@Override
				public HelperClassBuilder getHelperClass(ITypeBinding type) {
					return Visitor.this.getHelperClass(this, type);
				}

				@Override
				public MarshalInfo getMarshalInfo(ITypeBinding type) {
					return Visitor.this.getMarshalInfo(this, type);
				}
			};

			boolean foundErrors = false;

			for (NativeTypeEntry entry : _nativeTypeList) {
				final String name = BindingUtils.qualifiedName(entry.Binding);
				if (DEBUG)
					Sharpen.Debug("RESOLVE NATIVE TYPE: %s", name);

				if (entry.Template instanceof NativeHandle)
					entry.Builder = new NativeHandleBuilder(_nativeBuilder, entry.Binding,
							(NativeHandle) entry.Template);
				else if (entry.Template instanceof NativeStruct) {
					entry.Builder = new StructHelperClass(_nativeBuilder, entry.Binding,
							(NativeStruct) entry.Template);
					_needsHeader = true;
				} else {
					if (DEBUG)
						Sharpen.Debug("RESOLVE NATIVE TYPE EMPTY: %s", name);
					continue;
				}

				boolean ok = entry.Builder.resolve(context);

				if (DEBUG)
					Sharpen.Debug("RESOLVE NATIVE TYPE DONE: %s - %s", name, ok);
				if (!ok)
					foundErrors = true;

				_nativeBuilder.registerNativeType(entry.Builder);
			}

			return !foundErrors;
		}

		public boolean resolveMethods() {
			final IMarshalContext context = new IMarshalContext() {
				@Override
				public NativeConfiguration getConfig() {
					return _nativeConfig;
				}

				@Override
				public HelperClassBuilder getHelperClass(ITypeBinding type) {
					return Visitor.this.getHelperClass(this, type);
				}

				@Override
				public MarshalInfo getMarshalInfo(ITypeBinding type) {
					return Visitor.this.getMarshalInfo(this, type);
				}
			};

			boolean foundErrors = false;

			for (NativeMethodEntry entry : _nativeMethodList) {
				final String name = BindingUtils.qualifiedSignature(entry.Node.resolveBinding());
				if(DEBUG)
					Sharpen.Debug("RESOLVE NATIVE METHOD: %s", name);

				entry.Builder = _nativeBuilder.registerNativeMethod(
						entry.Node, entry.Template, (NativeHandleBuilder) entry.Type.Builder);

				boolean ok = entry.Builder.resolve(context);

				if(DEBUG)
					Sharpen.Debug("RESOLVE NATIVE METHOD DONE: %s - %s", name, ok);
				if (!ok)
					foundErrors = true;
			}

			return !foundErrors;
		}

		private HelperClassBuilder getHelperClass(IMarshalContext context, ITypeBinding type) {
			if (type.isClass()) {
				AbstractNativeTypeBuilder builder = getNativeTypeBuilder(type);
				if (builder != null)
					return (HelperClassBuilder) builder;
			}

			if (type.equals(_stringType))
				return _stringHelper;

			if (type.isArray()) {
				ITypeBinding elementType = type.getElementType();
				ArrayHelperClass helper = _sharedArrayHelpers.get(elementType);
				if (helper != null)
					return helper;

				helper = _arrayHelpers.get(elementType);
				if (helper != null)
					return helper;

				MarshalInfo marshal = getMarshalInfo(context, elementType);
				if (marshal == null)
					return null;

				ElementInfo element = new ElementInfo(elementType, marshal, null, Flags.ELEMENT);

				String name = "Array_" + elementType.getName();
				helper = new ArrayHelperClass(type, name, _nativeBuilder, element, false);
				_arrayHelpers.put(elementType, helper);

				if (!helper.resolve(context))
					return null;

				_nativeBuilder.registerNativeType(helper);
				return helper;
			}

			return null;
		}

		private MarshalInfo getMarshalInfo(IMarshalContext context, ITypeBinding type) {
			if(type.equals(_charType))
				return _charMarshal;
			else if(type.equals(_byteType))
				return _byteMarshal;
			else if(type.equals(_stringType))
				return _stringMarshal;
			else if (type.equals(_boolType))
				return _boolMarshal;
			else if(type.isPrimitive())
				return new MarshalAsPrimitive(type, type.getName(), type.getName());

			HelperClassBuilder helper = getHelperClass(context, type);
			if (helper != null)
				return new MarshalAsNativeType(type, helper);

			return null;
		}

		public boolean emitHelpers() {
			if (_nativeBuilder != null) {
				if (!_nativeBuilder.build(_needsHeader))
					return false;
			}

			return true;
		}

		private void registerType(ITypeBinding binding, CSTypeDeclaration type) {
			if(DEBUG)
				Sharpen.Debug("REGISTER TYPE: %s", BindingUtils.qualifiedName(binding));

			if (binding == _nativeTypeContainer) {
				for (HelperClassBuilder helper : _arrayHelpers.values()) {
					if(DEBUG)
						Sharpen.Debug("REGISTER TYPE - HELPER: %s", helper.getName());
					helper.createManagedType(type);
				}
			}

			NativeTypeEntry entry = _nativeTypes.get(binding.getTypeDeclaration());
			if ((entry != null) && (entry.Builder != null))
				entry.Builder.createManagedType(type);
		}

		@Override
		public boolean build() {
			return _generator.generate();
		}

		@Override
		public boolean writeOutput() {
			if (_nativeBuilder == null)
				return true;

			if (DEBUG)
				Sharpen.Debug("WRITING OUTPUT: %s", _name);
			return _nativeBuilder.writeOutput();
		}

		private class Generator extends SharpenGenerator {

			public Generator(IOutputProvider defaultOutput) {
				super(Visitor.this, defaultOutput);
			}

			@Override
			protected void registerType(ITypeBinding binding, CSTypeDeclaration type) {
				Visitor.this.registerType(binding, type);
			}

			@Override
			protected void registerMethod(IMethodBinding binding, CSMethod method) {
				;
			}
		}
	}

	private interface ITypeEntry {
		ASTNode getNode();

		IMemberContainer getTemplate();

		OutputType getOutput();

		NativeTypeEntry getNativeType();
	}

	public class AnonymousClassEntry implements ITypeEntry {
		public final AnonymousClassDeclaration Declaration;
		public final AnonymousClassTemplate Template;
		public final OutputType Output;

		public AnonymousClassEntry(AnonymousClassDeclaration node, AnonymousClassTemplate template,
				OutputType output) {
			this.Declaration = node;
			this.Template = template;
			this.Output = output;
		}

		@Override
		public ASTNode getNode() {
			return Declaration;
		}

		@Override
		public IMemberContainer getTemplate() {
			return Template;
		}

		@Override
		public OutputType getOutput() {
			return Output;
		}

		@Override
		public NativeTypeEntry getNativeType() {
			return null;
		}
	}

	public class TypeEntry implements ITypeEntry {
		public final TypeDeclaration Declaration;
		public final TypeTemplate Template;
		public final OutputType Output;
		public final NativeTypeEntry NativeType;

		public TypeEntry(TypeDeclaration node, TypeTemplate template, OutputType output,
				NativeTypeEntry nativeType) {
			this.Declaration = node;
			this.Template = template;
			this.Output = output;
			this.NativeType = nativeType;
		}

		@Override
		public ASTNode getNode() {
			return Declaration;
		}

		@Override
		public IMemberContainer getTemplate() {
			return Template;
		}

		@Override
		public OutputType getOutput() {
			return Output;
		}

		@Override
		public NativeTypeEntry getNativeType() {
			return NativeType;
		}

		@Override
		public String toString() {
			return String.format("TypeEntry[%s:%s:%s]",
					BindingUtils.qualifiedName(Declaration.resolveBinding()), Template, Output);
		}
	}

	public class MethodEntry {
		public final MethodDeclaration Declaration;
		public final AbstractMethodTemplate<?> Template;
		public final IMethodBinding BaseMethod;
		public final OutputType Output;

		public MethodEntry(MethodDeclaration node, AbstractMethodTemplate<?> template,
				IMethodBinding baseMethod, OutputType output) {
			this.Declaration = node;
			this.Template = template;
			this.BaseMethod = baseMethod;
			this.Output = output;
		}

		@Override
		public String toString() {
			return String.format("MethodEntry[%s:%s:%s]",
					BindingUtils.qualifiedName(Declaration.resolveBinding()), Template, Output);
		}
	}

	private class ScopeEntry {
		private final ScopeEntry _parent;
		private final Set<String> _localBlockVariables = new HashSet<String>();
		private final Set<String> _blockVariables = new HashSet<String>();

		public ScopeEntry() {
			_parent = null;
		}

		public ScopeEntry(ScopeEntry parent) {
			_parent = parent;
			_localBlockVariables.addAll(parent._localBlockVariables);
			_blockVariables.addAll(_localBlockVariables);
		}

		void addVisibleMethods(List<String> methods) {
			_localBlockVariables.addAll(methods);
			_blockVariables.addAll(methods);
		}

		String renameVariable(IVariableBinding binding, String name) {
			String renamed = null;
			if (_blockVariables.contains(name)) {
				int count = 1;
				while (_blockVariables.contains(name + "_" + count)) {
					count++;
				}
				name = name + "_" + count;
				renamed = name;
			}
			_localBlockVariables.add(name);
			_blockVariables.add(name);
			ScopeEntry parent = _parent;
			while (parent != null) {
				parent._blockVariables.add(name);
				parent = parent._parent;
			}
			return renamed;
		}
	}

	private class RenamedVariable extends VariableBinding {
		private final VariableBinding _parent;
		private final String _renamed;

		public RenamedVariable(VariableBinding parent, String renamed) {
			this._parent = parent;
			this._renamed = renamed;
		}

		@Override
		public String rename() {
			return _renamed;
		}

		@Override
		public boolean isPointer() {
			return _parent != null ? _parent.isPointer() : false;
		}

		@Override
		public TypeReference modifyType() {
			return _parent != null ? _parent.modifyType() : null;
		}

		@Override
		public NativeHandle getNativeHandle() {
			return _parent != null ? _parent.getNativeHandle() : null;
		}

		@Override
		public Visibility getVisibility() {
			return _parent != null ? _parent.getVisibility() : null;
		}
	}

	private class NativeTypeEntry {
		private final ITypeBinding Binding;
		private final NativeTypeTemplate Template;

		private AbstractNativeTypeBuilder Builder;

		public NativeTypeEntry(ITypeBinding type, NativeTypeTemplate template) {
			this.Binding = type;
			this.Template = template;
		}
	}

	private class NativeMethodEntry {
		private final NativeTypeEntry Type;
		private final MethodDeclaration Node;
		private final NativeMethod Template;

		private NativeMethodBuilder Builder;

		public NativeMethodEntry(NativeTypeEntry type, MethodDeclaration method, NativeMethod template) {
			this.Type = type;
			this.Node = method;
			this.Template = template;
		}
	}

}
