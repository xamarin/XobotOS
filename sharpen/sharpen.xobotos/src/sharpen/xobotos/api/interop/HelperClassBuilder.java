package sharpen.xobotos.api.interop;

import static sharpen.core.framework.Environments.my;

import org.eclipse.jdt.core.dom.ITypeBinding;

import sharpen.core.csharp.ast.*;
import sharpen.xobotos.api.bindings.BindingManager;
import sharpen.xobotos.api.interop.NativeMethodBuilder.ElementInfo;
import sharpen.xobotos.api.interop.Signature.Flags;
import sharpen.xobotos.api.interop.Signature.Mode;
import sharpen.xobotos.api.interop.glue.*;
import sharpen.xobotos.api.interop.glue.AbstractMember.Visibility;

import java.util.ArrayList;
import java.util.EnumSet;
import java.util.List;

public abstract class HelperClassBuilder extends AbstractNativeTypeBuilder {

	private static final boolean GENERATE_ALL = true;
	protected static final boolean TRACK_ALLOCATIONS = true;

	private final String _name;
	private final CSTypeReferenceExpression _managedType;
	private final AbstractTypeReference _nativeType;

	private final List<Member> _members;
	private final List<AbstractMember> _nativeMembers;
	private final List<AbstractMember> _nativeHeaders;

	private final AbstractTypeReference _structType;
	private final StructDefinition _struct;

	private final AbstractTypeReference _klassType;
	private final ClassDefinition _klass;

	private final CSStruct _managedStruct;
	private final CSTypeReference _managedStructRef;
	private final CSClass _managedHelper;
	private final CSTypeReference _managedHelperRef;

	private final String _destructorName;

	private final boolean _needsHeader;
	private final boolean _isShared;

	public HelperClassBuilder(ITypeBinding type, String name, NativeBuilder builder,
			CSTypeReferenceExpression managedType, AbstractTypeReference nativeType,
			boolean needsHeader, boolean isShared) {
		super(builder, type);
		this._name = name;
		this._managedType = managedType;
		this._nativeType = nativeType;
		this._needsHeader = needsHeader;
		this._isShared = isShared;

		_members = new ArrayList<Member>();
		_nativeMembers = new ArrayList<AbstractMember>();
		if (_needsHeader)
			_nativeHeaders = new ArrayList<AbstractMember>();
		else
			_nativeHeaders = null;

		_struct = new StructDefinition(_name + "_Struct", Visibility.PRIVATE);
		_structType = new TypeReference(_struct.getName());
		_nativeMembers.add(_struct);
		if (_needsHeader)
			_nativeHeaders.add(_struct.getDeclaration());

		_klass = new ClassDefinition(_name + "_Helper", Visibility.PUBLIC, _needsHeader);
		_klassType = new TypeReference(_klass.getName());
		_nativeMembers.add(_klass);
		if (_needsHeader)
			_nativeHeaders.add(_klass.getDeclaration());

		CSStructLayout layout = new CSStructLayout(CSStructLayout.LayoutKind.Sequential);
		_managedStruct = new CSStruct(_name + "_Struct", layout);
		_managedStruct.visibility(CSVisibility.Private);
		_managedStructRef = new CSTypeReference(_managedStruct.name());

		_managedHelper = new CSClass(_name + "_Helper", CSClassModifier.Static);
		_managedHelper.visibility(CSVisibility.Internal);
		_managedHelper.addMember(_managedStruct);
		_managedHelper.addAttribute(getMarshalHelperAttribute());
		_managedHelperRef = new CSTypeReference(_managedHelper.name());

		_destructorName = builder.getFunctionPrefix() + "_" + name + "_destructor";
	}

	public String getName() {
		return _name;
	}

	public CSTypeDeclaration getManagedHelper() {
		return _managedHelper;
	}

	@Override
	public CSTypeReferenceExpression getManagedType() {
		return _managedType;
	}

	@Override
	public CSTypeReferenceExpression getPInvokeType() {
		return new CSTypeReference("System.IntPtr");
	}

	public CSTypeReferenceExpression getManagedStructType() {
		return _managedStructRef;
	}

	@Override
	public AbstractTypeReference getNativePInvokeType() {
		return _structType;
	}

	@Override
	public AbstractTypeReference getNativeType() {
		return isByRef() ? new PointerType(_nativeType) : _nativeType;
	}

	@Override
	public AbstractTypeReference getRealNativeType() {
		return _nativeType;
	}

	protected Member addMember(Member member) {
		_members.add(member);
		return member;
	}

	@Override
	public boolean createManagedType(CSTypeDeclaration parent) {
		parent.addMember(_managedHelper);
		return true;
	}

	@Override
	public boolean createNativeType(CompilationUnit unit) {
		for (AbstractMember member : _nativeMembers)
			unit.addMember(member);
		return true;
	}

	@Override
	public boolean createHeader(CompilationUnitHeader header) {
		if (_needsHeader) {
			for (AbstractMember member : _nativeHeaders)
				header.addMember(member);
		}
		return true;
	}

	protected static boolean isBlittable(ITypeBinding type) {
		return my(BindingManager.class).isBlittable(type);
	}

	protected abstract boolean isBlittable();

	protected abstract boolean isByRef();

	@Override
	public boolean build() {
		if (_members.size() > 0)
			throw new IllegalStateException();

		_members.add(new OwnerMember());
		buildMembers();

		buildStruct();

		buildDefaultCtor();

		buildNativeHelpers(UNWRAP, DEEP_UNWRAP, MARSHAL_OUT, WRAP, DEEP_WRAP, WRAP_CONST,
				DESTRUCTOR, FREE_MEMBERS, C_DESTRUCTOR);

		buildManagedHelpers(NATIVE_SIZE, MANAGED_MARSHAL_IN, MANAGED_MARSHAL_OUT, MANAGED_TO_NATIVE,
				NATIVE_TO_MANAGED, FREE_NATIVE_PTR, FREE_MANAGED_PTR, DEEP_FREE_MANAGED_PTR);

		if (isBlittable()) {
			buildManagedHelpers(PINNED_HANDLE, GET_PINNED_PTR);
		}

		addMembers();

		return true;
	}

	protected abstract void buildMembers();

	@SuppressWarnings("unused")
	private void addMembers() {
		for (Helper helper : _helpers) {
			if (GENERATE_ALL || helper.isUsed())
				helper.add();
		}
	}

	private final List<Helper> _helpers = new ArrayList<Helper>();

	@SuppressWarnings("unused")
	private void buildNativeHelpers(NativeHelper... helpers) {
		for (NativeHelper helper : helpers) {
			if (GENERATE_ALL || helper.isUsed())
				helper.create();
		}
	}

	@SuppressWarnings("unused")
	private void buildManagedHelpers(ManagedHelper... helpers) {
		for (ManagedHelper helper : helpers) {
			if (GENERATE_ALL || helper.isUsed())
				helper.create();
		}
	}

	private CSTypeReferenceExpression getNativeHandleInterface() {
		return new CSTypeReference("Sharpen.INativeHandle");
	}

	private CSAttribute getMarshalHelperAttribute() {
		CSAttribute attr = new CSAttribute("Sharpen.MarshalHelper");
		attr.addArgument(new CSStringLiteralExpression("@\"" + _nativeType.getTypeName() + "\""));
		return attr;
	}

	protected Statement createAssert(Expression expr) {
		if (expr == null)
			expr = new BoolLiteralExpression(false);
		return new ExpressionStatement(new MethodInvocation(new ReferenceExpression("assert"), expr));
	}

	protected CSStatement createManagedAssert(CSExpression expr) {
		CSExpression exType = new CSReferenceExpression("System.InvalidOperationException");
		CSStatement stm = new CSThrowStatement(-1, new CSConstructorInvocationExpression(exType));
		if (expr == null)
			return stm;
		CSIfStatement ifStm = new CSIfStatement(-1, expr);
		ifStm.trueBlock().addStatement(stm);
		return ifStm;
	}

	private void buildStruct() {
		for (Member member : _members) {
			if (member.hasValue())
				continue;
			_struct.addMember(member.createField());
			_managedStruct.addMember(member.createManagedField());
		}
	}

	protected CSTypeReferenceExpression getManagedHelperType() {
		if (_isShared)
			return new CSNestedTypeReference(BindingManager.MANAGED_SHARED_HELPER, _managedHelperRef);
		else
			return _managedHelperRef;
	}

	protected static CSExpression getMarshalPtrToStructure(CSExpression ptr, CSTypeReferenceExpression type) {
		CSExpression marshal = new CSReferenceExpression("Marshal.PtrToStructure");
		CSExpression typeof = new CSTypeofExpression(type);
		return new CSCastExpression(type, new CSMethodInvocationExpression(marshal, ptr, typeof));
	}

	protected abstract class Helper {
		private final String _name;
		private boolean _used;

		protected Helper(String name) {
			this._name = name;
		}

		public String getName() {
			return _name;
		}

		public abstract void create();

		public abstract void add();

		public boolean isUsed() {
			return _used;
		}

		protected void reference() {
			_used = true;
		}
	}

	protected abstract class ManagedHelper extends Helper {
		protected ManagedHelper(String name) {
			super(name);
		}

		public CSExpression expr() {
			if (_members.size() > 0)
				create();
			else
				reference();
			return new CSMemberReferenceExpression(getManagedHelperType(), getName());
		}

		private CSMember _member;

		@Override
		public void create() {
			if (_member == null) {
				reference();
				_member = build();
				_helpers.add(this);
			}
		}

		@Override
		public void add() {
			_managedHelper.addMember(_member);
		}

		protected abstract CSMember build();
	}

	protected abstract class NativeHelper extends Helper {
		protected NativeHelper(String name) {
			super(name);
		}

		public Expression expr() {
			if (_members.size() > 0)
				create();
			else
				reference();
			return new StaticMemberAccess(_klassType, getName());
		}

		private Method _method;

		@Override
		public void create() {
			if (_method == null) {
				reference();
				_method = build();
				_helpers.add(this);
			}
		}

		@Override
		public void add() {
			_klass.addMember(_method);
		}

		protected abstract Method build();
	}

	protected final NativeHelper UNWRAP = new NativeHelper("unwrap") {
		@Override
		protected Method build() {
			AbstractTypeReference retType = new PointerType(_structType);
			Method unwrap = new Method(getName(), retType, Visibility.PUBLIC, Method.Flags.STATIC);
			NativeVariable src = NativeVariable.createParameter(unwrap, _nativeType, "src",
					NativeVariable.Flags.CLASS, NativeVariable.Flags.BYREF);

			Expression nullPtr = new NullLiteralExpression();
			Expression nullCheck = new BinaryOperator("==", src.getReference(), nullPtr);
			IfStatement ifStm = new IfStatement(nullCheck);
			ifStm.getThenBlock().addStatement(new ReturnStatement(nullPtr));
			unwrap.getBody().addStatement(ifStm);

			Expression ctorCall = new ConstructorInvocation(_structType);
			NativeVariable retval = NativeVariable.createLocal(unwrap.getBody(), _structType, "retval",
					ctorCall, NativeVariable.Flags.BYREF);
			Expression retvalRef = retval.getReference();

			unwrap.getBody().addStatement(
					new MethodInvocation(DEEP_UNWRAP.expr(), src.getDereferenceExpr(), retvalRef));

			unwrap.getBody().addStatement(new ReturnStatement(retvalRef));
			return unwrap;
		}
	};

	protected final NativeHelper DEEP_UNWRAP = new NativeHelper("unwrap") {
		@Override
		protected Method build() {
			Method unwrap = new Method(getName(), new TypeReference("void"), Visibility.PUBLIC,
					Method.Flags.STATIC);

			NativeVariable from = NativeVariable.createParameter(unwrap, _nativeType, "from",
					NativeVariable.Flags.CLASS, NativeVariable.Flags.REF);
			NativeVariable to = NativeVariable.createParameter(unwrap, _structType, "to",
					NativeVariable.Flags.BYREF);

			for (Member member : _members) {
				Statement stm = member.unwrap(from, to);
				if (stm != null)
					unwrap.getBody().addStatement(stm);
			}

			return unwrap;
		}
	};

	protected final NativeHelper WRAP = new NativeHelper("wrap") {
		@Override
		protected Method build() {
			Method wrap = new Method(getName(), new PointerType(_nativeType), Visibility.PUBLIC,
					Method.Flags.STATIC);
			NativeVariable src = NativeVariable.createParameter(wrap, _structType, "src",
					NativeVariable.Flags.CONST, NativeVariable.Flags.BYREF);

			Expression nullPtr = new NullLiteralExpression();
			Expression nullCheck = new BinaryOperator("==", src.getReference(), nullPtr);
			IfStatement ifStm = new IfStatement(nullCheck);
			ifStm.getThenBlock().addStatement(new ReturnStatement(nullPtr));
			wrap.getBody().addStatement(ifStm);

			buildWrap(wrap, src);
			return wrap;
		}
	};

	protected void buildWrap(Method method, NativeVariable src) {
		ConstructorInvocation ctorCall = new ConstructorInvocation(_nativeType);
		for (Member member : _members) {
			if (member.passToConstructor())
				ctorCall.addArgument(member.getReference(src));
		}

		NativeVariable retval = NativeVariable.createLocal(method.getBody(), _nativeType, "retval", ctorCall,
				NativeVariable.Flags.BYREF);

		Expression srcDeref = src.getDereferenceExpr();
		method.getBody().addStatement(new MethodInvocation(DEEP_WRAP.expr(), srcDeref, retval.getReference()));
		method.getBody().addStatement(new ReturnStatement(retval.getReference()));
	}

	protected final NativeHelper DEEP_WRAP = new NativeHelper("wrap") {
		@Override
		protected Method build() {
			Method method = new Method(getName(), new TypeReference("void"), Visibility.PUBLIC,
					Method.Flags.STATIC);

			NativeVariable from = NativeVariable.createParameter(method, _structType, "from",
					NativeVariable.Flags.CONST);
			NativeVariable to = NativeVariable.createParameter(method, _nativeType, "to",
					NativeVariable.Flags.CLASS, NativeVariable.Flags.BYREF);

			for (Member member : _members) {
				Statement stm = member.wrap(from, to);
				if (stm != null)
					method.getBody().addStatement(stm);
			}

			return method;
		}
	};

	protected final NativeHelper WRAP_CONST = new NativeHelper("wrapConst") {
		@Override
		protected Method build() {
			AbstractTypeReference retType = new ConstPointerType(_nativeType);
			Method wrapConst = new Method(getName(), retType, Visibility.PUBLIC, Method.Flags.STATIC);
			Parameter src = new Parameter(new ConstPointerType(_structType), "src");
			Expression srcRef = new VariableReference(src);
			wrapConst.addParameter(src);

			MethodInvocation call = new MethodInvocation(WRAP.expr(), srcRef);
			Expression templateRef = new TemplateFunctionReference("const_cast", retType);
			MethodInvocation cast = new MethodInvocation(templateRef, call);

			wrapConst.getBody().addStatement(new ReturnStatement(cast));
			return wrapConst;
		}
	};

	protected final NativeHelper MARSHAL_OUT = new NativeHelper("marshalOut") {
		@Override
		protected Method build() {
			Method marshal = new Method(getName(), new TypeReference("void"), Visibility.PUBLIC,
					Method.Flags.STATIC);

			NativeVariable from = NativeVariable.createParameter(marshal, _nativeType, "from",
					NativeVariable.Flags.CLASS, NativeVariable.Flags.CONST);
			NativeVariable to = NativeVariable.createParameter(marshal, _structType, "to",
					NativeVariable.Flags.BYREF);

			for (Member member : _members) {
				Statement stm = member.marshalOut(from, to);
				if (stm != null)
					marshal.getBody().addStatement(stm);
			}

			return marshal;
		}
	};

	private void buildDefaultCtor() {
		Constructor ctor = new Constructor(_klassType, Visibility.PRIVATE);
		_klass.addMember(ctor.getDeclaration());
	}

	protected final NativeHelper DESTRUCTOR = new NativeHelper("destructor") {
		@Override
		protected Method build() {
			Method dtor = new Method(getName(), new TypeReference("void"), Visibility.PUBLIC,
					Method.Flags.STATIC);
			NativeVariable obj = NativeVariable.createParameter(dtor, _structType, "obj",
					NativeVariable.Flags.BYREF);

			IfStatement ifStm = new IfStatement(new BinaryOperator("==", obj.getReference(),
					new NullLiteralExpression()));
			ifStm.getThenBlock().addStatement(new ReturnStatement());
			dtor.getBody().addStatement(ifStm);

			dtor.getBody()
			.addStatement(new MethodInvocation(FREE_MEMBERS.expr(), obj
					.getDereferenceExpr()));

			dtor.getBody().addStatement(new DestructorInvocation(obj.getReference()));
			return dtor;
		}
	};

	protected final NativeHelper FREE_MEMBERS = new NativeHelper("freeMembers") {
		@Override
		protected Method build() {
			Method method = new Method(getName(), new TypeReference("void"), Visibility.PUBLIC,
					Method.Flags.STATIC);
			NativeVariable obj = NativeVariable.createParameter(method, _structType, "obj",
					NativeVariable.Flags.REF);

			for (Member member : _members) {
				Statement stm = member.freeMembers(obj);
				if (stm != null)
					method.getBody().addStatement(stm);
			}

			return method;
		}
	};

	protected final NativeHelper C_DESTRUCTOR = new NativeHelper("destructor") {
		private Method _dtor;

		@Override
		protected Method build() {
			_dtor = new Method(_destructorName, new TypeReference("void"), Visibility.PUBLIC,
					Method.Flags.EXPORT);
			Parameter obj = new Parameter(new PointerType(_structType), "obj");
			Expression objRef = new VariableReference(obj);
			_dtor.addParameter(obj);

			DESTRUCTOR.reference();
			_dtor.getBody().addStatement(new MethodInvocation(DESTRUCTOR.expr(), objRef));
			return _dtor;
		}

		@Override
		public void add() {
			_nativeMembers.add(_dtor);
		}
	};

	protected final ManagedHelper NATIVE_SIZE = new ManagedHelper("NativeSize") {
		@Override
		protected CSMember build() {
			CSProperty prop = new CSProperty(getName(), new CSTypeReference("int"));
			prop.visibility(CSVisibility.Internal);
			prop.modifier(CSMethodModifier.Static);

			CSBlock block = new CSBlock();
			block.addStatement(new CSReturnStatement(-1, new CSMethodInvocationExpression(
					new CSReferenceExpression("Marshal.SizeOf"), new CSTypeofExpression(_managedStructRef))));
			prop.getter(block);
			return prop;
		}
	};

	protected final ManagedHelper MANAGED_MARSHAL_IN = new ManagedHelper("MarshalIn") {
		@Override
		protected CSMember build() {
			CSMethod method = new CSMethod(getName());
			method.returnType(new CSTypeReference("void"));
			method.visibility(CSVisibility.Public);
			method.modifier(CSMethodModifier.Static);

			final ManagedVariable ptr = new ManagedVariable("ptr", new CSTypeReference("System.IntPtr"));
			method.addParameter(ptr.getDeclaration());

			final ManagedVariable arg = new ManagedVariable("arg", _managedType);
			method.addParameter(arg.getDeclaration());

			final ManagedVariable obj = new ManagedVariable("obj", _managedStructRef);
			obj.getDeclaration().initializer(new CSConstructorInvocationExpression(_managedStructRef));
			method.body().addStatement(new CSDeclarationStatement(-1, obj.getDeclaration()));

			for (Member member : _members) {
				CSStatement stm = member.marshalIn(arg, obj, ptr);
				if (stm != null)
					method.body().addStatement(stm);
			}

			method.body().addStatement(
					new CSMethodInvocationExpression(
							new CSReferenceExpression("Marshal.StructureToPtr"),
							obj.getReference(), ptr.getReference(),
							new CSBoolLiteralExpression(false)));
			return method;
		}
	};

	protected final ManagedHelper MANAGED_MARSHAL_OUT = new ManagedHelper("MarshalOut") {
		@Override
		protected CSMember build() {
			CSMethod method = new CSMethod(getName());
			method.returnType(new CSTypeReference("void"));
			method.visibility(CSVisibility.Public);
			method.modifier(CSMethodModifier.Static);

			final ManagedVariable ptr = new ManagedVariable("ptr", new CSTypeReference("System.IntPtr"));
			method.addParameter(ptr.getDeclaration());

			final ManagedVariable arg = new ManagedVariable("arg", _managedType);
			method.addParameter(arg.getDeclaration());

			final ManagedVariable obj = new ManagedVariable("obj", _managedStructRef);
			method.body().addStatement(new CSDeclarationStatement(-1, obj.getDeclaration()));

			obj.getDeclaration().initializer(
					getMarshalPtrToStructure(ptr.getReference(), _managedStructRef));

			for (Member member : _members) {
				CSStatement stm = member.marshalOut(arg, obj, ptr);
				if (stm != null)
					method.body().addStatement(stm);
			}

			return method;
		}
	};

	protected final ManagedHelper MANAGED_TO_NATIVE = new ManagedHelper("ManagedToNative") {
		@Override
		protected CSMember build() {
			CSMethod method = new CSMethod(getName());
			method.returnType(new CSTypeReference("System.IntPtr"));
			method.visibility(CSVisibility.Public);
			method.modifier(CSMethodModifier.Static);

			final ManagedVariable arg = new ManagedVariable("arg", _managedType);
			method.addParameter(arg.getDeclaration());

			final CSExpression nullPtr = new CSNullLiteralExpression();
			final CSExpression zeroPtr = new CSReferenceExpression("System.IntPtr.Zero");
			final CSExpression argRef = arg.getReference();

			CSIfStatement nullCheck = new CSIfStatement(-1, new CSInfixExpression("==", argRef, nullPtr));
			nullCheck.trueBlock().addStatement(new CSReturnStatement(-1, zeroPtr));
			method.body().addStatement(nullCheck);

			final ManagedVariable ptr = new ManagedVariable("ptr", new CSTypeReference("System.IntPtr"));
			method.body().addStatement(new CSDeclarationStatement(-1, ptr.getDeclaration()));

			ptr.getDeclaration().initializer(new CSMethodInvocationExpression(
					new CSReferenceExpression("Marshal.AllocHGlobal"), computeNativeSize(argRef)));

			method.body().addStatement(
					new CSMethodInvocationExpression(MANAGED_MARSHAL_IN.expr(),
							ptr.getReference(), arg.getReference()));

			method.body().addStatement(new CSReturnStatement(-1, ptr.getReference()));
			return method;
		}
	};

	protected final ManagedHelper NATIVE_TO_MANAGED = new ManagedHelper("NativeToManaged") {
		@Override
		protected CSMethod build() {
			CSMethod method = new CSMethod(getName());
			method.returnType(_managedType);
			method.visibility(CSVisibility.Public);
			method.modifier(CSMethodModifier.Static);

			final ManagedVariable ptr = new ManagedVariable("ptr", new CSTypeReference("System.IntPtr"));
			method.addParameter(ptr.getDeclaration());

			final CSExpression nullPtr = new CSNullLiteralExpression();
			final CSExpression zeroPtr = new CSReferenceExpression("System.IntPtr.Zero");
			final CSExpression argRef = ptr.getReference();

			CSIfStatement nullCheck = new CSIfStatement(-1, new CSInfixExpression("==", argRef, zeroPtr));
			nullCheck.trueBlock().addStatement(new CSReturnStatement(-1, nullPtr));
			method.body().addStatement(nullCheck);

			final ManagedVariable obj = new ManagedVariable("obj", _managedStructRef);
			method.body().addStatement(new CSDeclarationStatement(-1, obj.getDeclaration()));

			obj.getDeclaration().initializer(
					getMarshalPtrToStructure(ptr.getReference(), _managedStructRef));

			final ManagedVariable arg = new ManagedVariable("arg", _managedType);
			arg.getDeclaration().initializer(createInstance(obj));
			method.body().addStatement(new CSDeclarationStatement(-1, arg.getDeclaration()));

			for (Member member : _members) {
				CSStatement stm = member.nativeToManaged(arg, obj, ptr);
				if (stm != null)
					method.body().addStatement(stm);
			}

			method.body().addStatement(new CSReturnStatement(-1, arg.getReference()));
			return method;
		}
	};

	protected final ManagedHelper FREE_MANAGED_PTR = new ManagedHelper("FreeManagedPtr") {
		@Override
		protected CSMember build() {
			CSMethod method = new CSMethod(getName());
			method.returnType(new CSTypeReference("void"));
			method.visibility(CSVisibility.Public);
			method.modifier(CSMethodModifier.Static);

			final ManagedVariable ptr = new ManagedVariable("ptr", new CSTypeReference("System.IntPtr"));
			method.addParameter(ptr.getDeclaration());

			CSIfStatement nullCheck = new CSIfStatement(-1, new CSInfixExpression("==", ptr.getReference(),
					new CSReferenceExpression("System.IntPtr.Zero")));
			nullCheck.trueBlock().addStatement(new CSReturnStatement(-1, null));
			method.body().addStatement(nullCheck);

			method.body().addStatement(
					new CSMethodInvocationExpression(DEEP_FREE_MANAGED_PTR.expr(), ptr
							.getReference()));

			method.body().addStatement(
					new CSMethodInvocationExpression(new CSReferenceExpression(
							"Marshal.FreeHGlobal"),
							ptr.getReference()));
			return method;
		}
	};

	protected final ManagedHelper DEEP_FREE_MANAGED_PTR = new ManagedHelper("FreeManagedPtr_inner") {
		@Override
		protected CSMember build() {
			CSMethod method = new CSMethod(getName());
			method.returnType(new CSTypeReference("void"));
			method.visibility(CSVisibility.Public);
			method.modifier(CSMethodModifier.Static);

			final ManagedVariable ptr = new ManagedVariable("ptr", new CSTypeReference("System.IntPtr"));
			method.addParameter(ptr.getDeclaration());

			final ManagedVariable obj = new ManagedVariable("obj", _managedStructRef);
			obj.getDeclaration().initializer(
					getMarshalPtrToStructure(ptr.getReference(), _managedStructRef));
			method.body().addStatement(new CSDeclarationStatement(-1, obj.getDeclaration()));

			for (Member member : _members) {
				CSStatement stm = member.free(obj);
				if (stm != null)
					method.body().addStatement(stm);
			}

			return method;
		}
	};

	protected final ManagedHelper FREE_NATIVE_PTR = new ManagedHelper("FreeNativePtr") {
		private CSMethod _pinvoke;

		@Override
		protected CSMember build() {
			final ManagedVariable ptr = new ManagedVariable("ptr", new CSTypeReference("System.IntPtr"));

			_pinvoke = new CSMethod(_destructorName);
			_pinvoke.dllImport(getConfig().getDllImportAttribute());
			_pinvoke.modifier(CSMethodModifier.Extern);
			_pinvoke.visibility(CSVisibility.Private);
			_pinvoke.returnType(new CSTypeReference("void"));
			_pinvoke.addParameter(ptr.getDeclaration());

			CSMethod method = new CSMethod(getName());
			method.returnType(new CSTypeReference("void"));
			method.visibility(CSVisibility.Public);
			method.modifier(CSMethodModifier.Static);
			method.addParameter(ptr.getDeclaration());

			CSExpression dtorRef = new CSReferenceExpression(_pinvoke.name());
			method.body().addStatement(new CSMethodInvocationExpression(dtorRef, ptr.getReference()));
			return method;
		}

		@Override
		public void reference() {
			super.reference();
			C_DESTRUCTOR.reference();
		}

		@Override
		public void add() {
			super.add();
			_managedHelper.addMember(_pinvoke);
		}
	};

	protected final ManagedHelper GET_PINNED_PTR = new ManagedHelper("GetPinnedPtr") {
		@Override
		protected CSMethod build() {
			CSMethod method = new CSMethod(getName());
			method.returnType(getNativeHandleInterface());
			method.visibility(CSVisibility.Public);
			method.modifier(CSMethodModifier.Static);

			final ManagedVariable arg = new ManagedVariable("arg", _managedType);
			method.addParameter(arg.getDeclaration());

			final CSExpression nullPtr = new CSNullLiteralExpression();
			final CSExpression argRef = arg.getReference();

			CSIfStatement nullCheck = new CSIfStatement(-1, new CSInfixExpression("==", argRef, nullPtr));
			nullCheck.trueBlock().addStatement(new CSReturnStatement(-1, nullPtr));
			method.body().addStatement(nullCheck);

			PINNED_HANDLE.expr();
			final ManagedVariable pinned = new ManagedVariable("pinned", new CSTypeReference("PinnedHandle"));
			pinned.getDeclaration().initializer(
					new CSConstructorInvocationExpression(new CSTypeReference("PinnedHandle")));
			method.body().addStatement(pinned.getDeclarationStatement());

			final ManagedVariable obj = new ManagedVariable("obj", _managedStructRef);
			obj.getDeclaration().initializer(new CSConstructorInvocationExpression(_managedStructRef));
			method.body().addStatement(obj.getDeclarationStatement());

			for (Member member : _members) {
				CSStatement stm = member.getPinnedPtr(arg, obj, pinned);
				if (stm != null)
					method.body().addStatement(stm);
			}

			CSExpression handleRef = new CSMemberReferenceExpression(pinned.getReference(), "handle");
			CSExpression ptrRef = new CSMemberReferenceExpression(pinned.getReference(), "ptr");

			CSExpression createHandle = new CSMethodInvocationExpression(
					new CSReferenceExpression("GCHandle.Alloc"), obj.getReference(),
					new CSReferenceExpression("GCHandleType.Pinned"));
			method.body().addStatement(new CSInfixExpression("=", handleRef, createHandle));

			CSExpression getAddr = new CSMethodInvocationExpression(new CSMemberReferenceExpression(
					handleRef, "AddrOfPinnedObject"));
			method.body().addStatement(new CSInfixExpression("=", ptrRef, getAddr));

			method.body().addStatement(new CSReturnStatement(-1, pinned.getReference()));
			return method;
		}
	};

	protected final ManagedHelper PINNED_HANDLE = new ManagedHelper("PinnedHandle") {
		@Override
		protected CSMember build() {
			CSStruct struct = new CSStruct(getName());
			struct.addBaseType(getNativeHandleInterface());

			CSField handle = new CSField("handle", new CSTypeReference("GCHandle"), CSVisibility.Public);
			struct.addMember(handle);

			CSField ptr = new CSField("ptr", new CSTypeReference("System.IntPtr"), CSVisibility.Public);
			struct.addMember(ptr);

			CSProperty prop = new CSProperty("Address", new CSTypeReference("System.IntPtr"));
			prop.visibility(CSVisibility.Public);
			struct.addMember(prop);

			prop.getter(new CSBlock());
			prop.getter().addStatement(new CSReturnStatement(-1, new CSReferenceExpression(ptr.name())));

			CSMethod free = new CSMethod("Free");
			free.returnType(new CSTypeReference("void"));
			free.visibility(CSVisibility.Public);
			struct.addMember(free);

			CSExpression freeRef = new CSMemberReferenceExpression(new CSReferenceExpression(handle.name()), "Free");
			free.body().addStatement(new CSMethodInvocationExpression(freeRef));

			for (Member member : _members) {
				member.createPinnedPtr(struct, free);
			}
			return struct;
		}
	};

	protected abstract CSExpression computeNativeSize(CSExpression expr);

	protected abstract CSExpression createInstance(ManagedVariable obj);

	@Override
	public void marshalNative(INativeMarshalContext context, Mode mode, Flags flags) {
		final NativeVariable param = NativeVariable.createParameter(context, _structType, "ptr",
				mode == Mode.OUT ? NativeVariable.Flags.OUT : NativeVariable.Flags.BYREF);

		EnumSet<NativeVariable.Flags> e = EnumSet.of(NativeVariable.Flags.CLASS);

		final Expression wrap;
		if (mode == Mode.OUT) {
			wrap = null;
		} else if (mode == Mode.REF) {
			wrap = new MethodInvocation(WRAP.expr(), param.getReference());
			e.add(NativeVariable.Flags.BYREF);
		} else {
			wrap = new MethodInvocation(WRAP_CONST.expr(), param.getReference());
			e.add(NativeVariable.Flags.BYREF);
			e.add(NativeVariable.Flags.CONST);
		}

		final NativeVariable var = NativeVariable.createLocal(context, _nativeType, null, wrap, e);
		if (mode == Mode.OUT)
			context.addArgument(var.getAddressOfExpr());
		else if (flags == Flags.ALLOW_NULL)
			context.addArgument(var.getReference());
		else
			context.addArgument(var.getDereferenceExpr());

		if (!isBlittable() && (mode == Mode.REF)) {
			Expression nullPtr = new NullLiteralExpression();
			Expression nullCheck = new BinaryOperator("!=", param.getReference(), nullPtr);
			IfStatement ifStm = new IfStatement(nullCheck);

			ifStm.getThenBlock().addStatement(
					new MethodInvocation(MARSHAL_OUT.expr(),
							var.getDereferenceExpr(), param.getReference()));
			context.addPostStatement(ifStm);
		} else if (mode == Mode.OUT) {
			context.addPostStatement(new AssignmentStatement(param.getDereferenceExpr(),
					new MethodInvocation(UNWRAP.expr(), var.getAddressOfExpr())));
		}

		if (mode != Mode.OUT)
			context.addPostStatement(new DestructorInvocation(var.getReference()));
	}

	@Override
	public void marshalManaged(IManagedMarshalContext context, CSExpression expr, Mode mode, Flags flags) {
		if (isBlittable() && (mode != Mode.OUT)) {
			marshalBlittable(context, expr, mode, flags);
			return;
		}

		final CSTypeReference intPtr = new CSTypeReference("System.IntPtr");
		ManagedVariable arg = new ManagedVariable(context.getVariableName("ptr"), intPtr, null,
				mode == Mode.OUT ? ManagedVariable.Flags.OUT : null);

		ManagedVariable ptr = new ManagedVariable(context.getVariableName("ptr"), intPtr,
				new CSReferenceExpression("System.IntPtr.Zero"));

		context.addParameter(null, arg.getDeclaration().type(),
				mode == Mode.OUT ? ptr.getOutReference() : ptr.getReference());

		CSExpression cleanupFunc = mode == Mode.OUT ? FREE_NATIVE_PTR.expr() : FREE_MANAGED_PTR.expr();
		CSExpression cleanup = new CSMethodInvocationExpression(cleanupFunc, ptr.getReference());
		context.addDeclaration(ptr.getDeclaration(), new CSExpressionStatement(-1, cleanup));

		if (mode != Mode.OUT) {
			CSExpression marshal = new CSInfixExpression("=", ptr.getReference(),
					new CSMethodInvocationExpression(MANAGED_TO_NATIVE.expr(), expr));
			context.addPreStatement(new CSExpressionStatement(-1, marshal));
		}

		if ((mode == Mode.REF) || (mode == Mode.OUT)) {
			CSExpression marshal = new CSMethodInvocationExpression(MANAGED_MARSHAL_OUT.expr(),
					ptr.getReference(), expr);
			context.addPostStatement(new CSExpressionStatement(-1, marshal));
		}
	}

	@Override
	public CSExpression marshalRetval(IManagedReturnContext context, CSExpression expr) {
		ManagedVariable ptr = context.createVariable("ptr", new CSTypeReference("System.IntPtr"), expr);

		context.createRetval(new CSMethodInvocationExpression(NATIVE_TO_MANAGED.expr(), ptr.getReference()));

		CSExpression freeInvoc = new CSMethodInvocationExpression(FREE_NATIVE_PTR.expr(), ptr.getReference());
		context.addStatement(new CSExpressionStatement(-1, freeInvoc));

		return null;
	}

	private void marshalBlittable(IManagedMarshalContext context, CSExpression expr, Mode mode, Flags flags) {
		ManagedVariable handle = new ManagedVariable(context.getVariableName("handle"),
				getNativeHandleInterface(), new CSNullLiteralExpression());
		CSExpression nullCheck = new CSInfixExpression("!=", handle.getReference(),
				new CSNullLiteralExpression());
		CSIfStatement cleanup = new CSIfStatement(-1, nullCheck);
		cleanup.trueBlock().addStatement(new CSMethodInvocationExpression(new CSMemberReferenceExpression(
				handle.getReference(), "Free")));
		context.addDeclaration(handle.getDeclaration(), cleanup);

		CSExpression marshal = new CSInfixExpression("=", handle.getReference(),
				new CSMethodInvocationExpression(GET_PINNED_PTR.expr(), expr));
		context.addPreStatement(new CSExpressionStatement(-1, marshal));

		CSExpression addrRef = new CSMemberReferenceExpression(handle.getReference(), "Address");

		CSExpression arg;
		if (flags == Flags.ALLOW_NULL)
			arg = new CSConditionalExpression(nullCheck, addrRef, new CSReferenceExpression(
					"System.IntPtr.Zero"));
		else
			arg = addrRef;

		context.addParameter(null, new CSTypeReference("System.IntPtr"), arg);
	}

	@Override
	public Expression marshalNativeRetval(Expression expr) {
		return new MethodInvocation(UNWRAP.expr(), expr);
	}

	protected abstract static class Member {
		private final AbstractTypeReference _type;
		private final CSTypeReferenceExpression _managed;
		private final String _name;
		private final String _managedName;
		private final EnumSet<Flags> _flags;

		public Member(AbstractTypeReference type, CSTypeReferenceExpression managed, String name,
				String managedName, Flags... flags) {
			this(type, managed, name, managedName, buildSet(Flags.class, flags));
		}

		public Member(AbstractTypeReference type, CSTypeReferenceExpression managed, String name,
				String managedName, EnumSet<Flags> flags) {
			this._flags = flags;
			this._type = type;
			this._managed = managed;
			this._name = name;
			this._managedName = managedName;
		}

		public enum Flags {
			FUNCTION,
			PASS_TO_CTOR,
			BYREF,
			POINTER,
			HAS_VALUE
		}

		public String getName() {
			return _name;
		}

		public String getManagedName() {
			return _managedName;
		}

		protected final AbstractTypeReference getNativeType() {
			if (hasValue())
				throw new IllegalStateException();
			if (isByRef())
				return new PointerType(_type);
			else
				return _type;
		}

		protected final boolean isFunction() {
			return _flags.contains(Flags.FUNCTION);
		}

		protected final boolean passToConstructor() {
			return _flags.contains(Flags.PASS_TO_CTOR);
		}

		protected final boolean isByRef() {
			return _flags.contains(Flags.BYREF);
		}

		protected final boolean isPointer() {
			return _flags.contains(Flags.POINTER);
		}

		protected final boolean hasValue() {
			return _flags.contains(Flags.HAS_VALUE);
		}

		protected final EnumSet<Flags> getFlags() {
			return _flags;
		}

		public Expression getReference(NativeVariable var) {
			Expression varRef = var.getMemberAccess(_name);
			if (var.isTarget() && isFunction())
				varRef = new MethodInvocation(varRef);
			return varRef;
		}

		public Expression getIndex(NativeVariable var, Expression expr) {
			Expression varRef = var.getMemberAccess("item");
			return new MethodInvocation(varRef, expr);
		}

		public CSExpression getReference(ManagedVariable var) {
			return new CSMemberReferenceExpression(var.getReference(), _managedName);
		}

		protected Field createField() {
			if (hasValue())
				throw new IllegalStateException();
			AbstractTypeReference fieldType = _type;
			if (isByRef())
				fieldType = new PointerType(fieldType);
			if (isPointer())
				fieldType = new PointerType(fieldType);
			return new Field(fieldType, _name, Visibility.PRIVATE);
		}

		protected final CSField createManagedField() {
			if (hasValue())
				throw new IllegalStateException();
			return new CSField(_managedName, _managed, CSVisibility.Public);
		}

		protected abstract void createPinnedPtr(CSStruct struct, CSMethod dtor);

		protected abstract CSStatement getPinnedPtr(ManagedVariable arg, ManagedVariable obj,
				ManagedVariable pinned);

		protected abstract CSStatement marshalIn(ManagedVariable arg, ManagedVariable obj, ManagedVariable ptr);

		protected abstract CSStatement marshalOut(ManagedVariable arg, ManagedVariable obj, ManagedVariable ptr);

		protected abstract CSStatement nativeToManaged(ManagedVariable arg, ManagedVariable obj,
				ManagedVariable ptr);

		public abstract CSStatement free(ManagedVariable obj);

		protected abstract Statement wrap(NativeVariable src, NativeVariable dest);

		protected abstract Statement unwrap(NativeVariable src, NativeVariable dest);

		protected abstract Statement freeMembers(NativeVariable obj);

		protected abstract Statement marshalOut(NativeVariable src, NativeVariable dest);
	}

	protected abstract static class ElementMember extends Member {
		private final ElementInfo _elementInfo;
		private final HelperClassBuilder _elementHelper;

		protected ElementMember(ElementInfo info, String name, String managedName, Flags... flags) {
			this(info, name, managedName, buildSet(Flags.class, flags));
		}

		protected ElementMember(ElementInfo info, String name, String managedName, EnumSet<Flags> flags) {
			super(computeNativeType(info), computeManagedType(info, flags), name, managedName, flags);
			this._elementInfo = info;

			if (info.isClass()) {
				AbstractNativeTypeBuilder builder = info.getTypeBuilder();
				if (builder instanceof HelperClassBuilder) {
					_elementHelper = (HelperClassBuilder) builder;
					if (_elementHelper.isByRef())
						getFlags().add(Flags.BYREF);
				} else {
					_elementHelper = null;
				}
			} else
				_elementHelper = null;
		}

		private static AbstractTypeReference computeNativeType(ElementInfo info) {
			if (info.isClass())
				return info.getTypeBuilder().getNativePInvokeType();
			else
				return info.getNativeType();
		}

		private static CSTypeReferenceExpression computeManagedType(ElementInfo info, EnumSet<Flags> flags) {
			if (flags.contains(Flags.POINTER))
				return new CSTypeReference("System.IntPtr");
			else
				return info.getPInvokeType();
		}

		protected boolean isClass() {
			return _elementHelper != null;
		}

		protected HelperClassBuilder getHelper() {
			return _elementHelper;
		}

		protected ElementInfo getElementInfo() {
			return _elementInfo;
		}

		protected CSExpression getNativeElementSizeExpr() {
			if (isClass())
				return getHelper().NATIVE_SIZE.expr();

			CSExpression sizeof = new CSReferenceExpression("Marshal.SizeOf");
			return new CSMethodInvocationExpression(sizeof, new CSTypeofExpression(
					_elementInfo.getManagedType()));
		}

		protected CSStatement marshalIn(CSExpression addr, CSExpression expr) {
			if (isClass()) {
				return new CSExpressionStatement(-1, new CSMethodInvocationExpression(
						getHelper().MANAGED_MARSHAL_IN.expr(), addr, expr));
			} else {
				return new CSExpressionStatement(-1, new CSMethodInvocationExpression(
						new CSReferenceExpression("Marshal.StructureToPtr"), expr, addr,
						new CSBoolLiteralExpression(false)));
			}
		}

		protected CSStatement marshalOut(CSExpression addr, CSExpression expr, CSTypeReferenceExpression type) {
			if (isClass()) {
				return new CSExpressionStatement(-1, new CSMethodInvocationExpression(
						getHelper().MANAGED_MARSHAL_OUT.expr(), addr, expr));
			} else {
				return new CSExpressionStatement(-1, new CSInfixExpression("=", expr,
						getMarshalPtrToStructure(addr, type)));
			}
		}

		protected CSStatement nativeToManaged(CSExpression addr, CSExpression expr,
				CSTypeReferenceExpression type) {
			CSExpression marshal;
			if (isClass())
				marshal = new CSMethodInvocationExpression(getHelper().NATIVE_TO_MANAGED.expr(), addr);
			else
				marshal = getMarshalPtrToStructure(addr, type);
			return new CSExpressionStatement(-1, new CSInfixExpression("=", expr, marshal));
		}
	}

	static <T extends Enum<T>> EnumSet<T> buildSet(Class<T> klass, T... args) {
		EnumSet<T> set = EnumSet.noneOf(klass);
		if (args != null) {
			for (T arg : args)
				set.add(arg);
		}
		return set;
	}

	// Randomly generated numbers; no special meaning.
	private static final CSExpression MANAGED_MAGIC = new CSNumberLiteralExpression("0x972f3813");
	private static final CSExpression PINNED_MAGIC = new CSNumberLiteralExpression("0x337b4904");
	private static final Expression NATIVE_MAGIC = new NumberLiteralExpression("0x7380548b");

	private class OwnerMember extends Member {

		public OwnerMember() {
			super(new TypeReference("uint32_t"), new CSTypeReference("uint"), "_owner", "_owner");
		}

		@Override
		protected void createPinnedPtr(CSStruct struct, CSMethod free) {
			;
		}

		@Override
		protected CSStatement getPinnedPtr(ManagedVariable arg, ManagedVariable obj, ManagedVariable pinned) {
			return new CSExpressionStatement(-1, new CSInfixExpression("=", getReference(obj),
					PINNED_MAGIC));
		}

		@Override
		protected CSStatement marshalIn(ManagedVariable arg, ManagedVariable obj, ManagedVariable ptr) {
			return new CSExpressionStatement(-1, new CSInfixExpression("=", getReference(obj),
					MANAGED_MAGIC));
		}

		@Override
		protected CSStatement marshalOut(ManagedVariable arg, ManagedVariable obj, ManagedVariable ptr) {
			return null;
		}

		@Override
		protected CSStatement nativeToManaged(ManagedVariable arg, ManagedVariable obj, ManagedVariable ptr) {
			return null;
		}

		@Override
		public CSStatement free(ManagedVariable obj) {
			return createManagedAssert(new CSInfixExpression("!=", getReference(obj), MANAGED_MAGIC));
		}

		@Override
		protected Statement unwrap(NativeVariable src, NativeVariable dest) {
			return new AssignmentStatement(getReference(dest), NATIVE_MAGIC);
		}

		@Override
		protected Statement freeMembers(NativeVariable obj) {
			return createAssert(new BinaryOperator("==", getReference(obj), NATIVE_MAGIC));
		}

		@Override
		protected Statement wrap(NativeVariable src, NativeVariable dest) {
			return null;
		}

		@Override
		protected Statement marshalOut(NativeVariable src, NativeVariable dest) {
			return null;
		}

	}

}
