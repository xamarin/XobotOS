package sharpen.xobotos.api.interop;

import org.eclipse.jdt.core.dom.IVariableBinding;
import org.eclipse.jdt.core.dom.MethodDeclaration;
import org.eclipse.jdt.core.dom.VariableDeclaration;

import sharpen.core.framework.ByRef;
import sharpen.xobotos.api.interop.NativeMethod.Kind;
import sharpen.xobotos.api.interop.NativeMethodBuilder.ElementInfo;
import sharpen.xobotos.api.interop.glue.*;
import sharpen.xobotos.api.interop.glue.AbstractMember.Visibility;
import sharpen.xobotos.api.interop.glue.Method.Flags;
import sharpen.xobotos.api.interop.marshal.MarshalAsNativeType;

import java.util.ArrayList;
import java.util.List;

public class NativeGlueGenerator {
	private final NativeMethodBuilder _builder;
	private final NativeMethod _method;
	private final MethodDeclaration _decl;

	public NativeGlueGenerator(NativeMethodBuilder builder) {
		this._builder = builder;
		this._method = builder.getNativeMethod();
		this._decl = builder.getMethod();
	}

	private ElementInfo _returnInfo;
	private AbstractNativeTypeBuilder _returnHelper;
	private AbstractTypeReference _returnType;
	private ElementInfo[] _paramInfo;
	private IVariableBinding _implicitInstance;
	private String _nativeName;
	private String _nativeFunction;
	private AbstractTypeReference _nativeClass;

	protected boolean resolve() {
		_returnInfo = _builder.getReturnInfo();
		_paramInfo = _builder.getParameterInfo();

		_nativeName = _builder.getNativeName();
		_nativeFunction = _builder.getNativeFunction();
		_implicitInstance = _builder.getImplicitInstance();

		if (_method.getNativeClass() != null)
			_nativeClass = new TypeReference(_method.getNativeClass());
		else if (_builder.getNativeHandle() != null)
			_nativeClass = _builder.getNativeHandle().getNativeClass();

		if (_returnInfo != null) {
			if (_returnInfo.marshal instanceof MarshalAsNativeType) {
				_returnHelper = ((MarshalAsNativeType) _returnInfo.marshal).getTypeBuilder();
				_returnType = new PointerType(_returnHelper.getNativePInvokeType());
			} else
				_returnType = _returnInfo.getNativeType();
		} else {
			_returnType = new TypeReference("void");
		}

		return true;
	}

	protected boolean generate(Printer printer) {
		Method method = generate();
		if (method == null)
			return false;

		printer.visit(method);
		return true;
	}

	public Method generate() {
		final Method method = new Method(_nativeFunction, _returnType, Visibility.PUBLIC, Flags.EXPORT);

		final List<Expression> args = new ArrayList<Expression>();
		final List<Statement> preStmnts = new ArrayList<Statement>();
		final List<Statement> postStmnts = new ArrayList<Statement>();

		final Kind kind = _method.getKind();

		final ByRef<Expression> instanceArg;
		if ((kind == Kind.INSTANCE) || (kind == Kind.PROXY))
			instanceArg = new ByRef<Expression>(null);
		else
			instanceArg = null;

		if (_implicitInstance != null) {
			Parameter param = new Parameter(new PointerType(_nativeClass), "_instance");
			method.addParameter(param);

			Expression arg = new VariableReference(param);
			if (instanceArg != null)
				instanceArg.value = arg;
			else
				args.add(new DereferenceExpression(arg));
		}

		for (int i = 0; i < _paramInfo.length; i++) {
			if (_paramInfo[i] == null)
				continue;

			VariableDeclaration vdecl = (VariableDeclaration) _decl.parameters().get(i);
			IVariableBinding vbinding = vdecl.resolveBinding();
			final String name = getNativeName(vbinding.getName());

			boolean hasInstanceArg = (instanceArg != null) && (instanceArg.value == null);
			final boolean isInstanceArg = hasInstanceArg && (i == 0);

			INativeMarshalContext context = new INativeMarshalContext() {
				@Override
				public void addPreStatement(Statement statement) {
					preStmnts.add(statement);
				}

				@Override
				public void addPostStatement(Statement statement) {
					postStmnts.add(statement);
				}

				@Override
				public NativeVariable createParameter(String suffix, AbstractTypeReference type) {
					String pname = suffix != null ? name + "_" + suffix : name;
					Parameter param = new Parameter(type, pname);
					method.addParameter(param);
					return new NativeVariable(param);
				}

				@Override
				public NativeVariable createVariable(String suffix, AbstractTypeReference type,
						Expression init) {
					String vname = suffix != null ? name + "_" + suffix : name;
					LocalVariable var = new LocalVariable(type, vname, init);
					preStmnts.add(var);
					return new NativeVariable(var);
				}

				@Override
				public void addArgument(Expression arg) {
					if (isInstanceArg)
						instanceArg.value = arg;
					else
						args.add(arg);
				}
			};

			_paramInfo[i].marshal.marshalNative(context, _paramInfo[i].mode, _paramInfo[i].flags);
		}

		if (_method.getKind() == Kind.DESTRUCTOR) {
			method.getBody().addStatement(new DestructorInvocation(args.get(0)));
			return method;
		}

		final AbstractInvocation invocation;

		if (_method.getKind() == Kind.INSTANCE) {
			Expression member = new InstanceMemberAccess(instanceArg.value, _nativeName);
			invocation = new MethodInvocation(member, args);
		} else if (_method.getKind() == Kind.PROXY) {
			Expression member = new StaticMemberAccess(_nativeClass, _nativeName);
			args.add(0, new DereferenceExpression(instanceArg.value));
			invocation = new MethodInvocation(member, args);
		} else if (_method.getKind() == Kind.STATIC) {
			Expression member = new StaticMemberAccess(_nativeClass, _nativeName);
			invocation = new MethodInvocation(member, args);
		} else if (_method.getKind() == Kind.CONSTRUCTOR) {
			AbstractTypeReference type = ((PointerType) _returnType).getElementType();
			invocation = new ConstructorInvocation(type, args);
		} else {
			return null;
		}

		for (Statement stm : preStmnts) {
			method.getBody().addStatement(stm);
		}

		final NativeVariable retval;

		if (_returnHelper != null) {
			NativeVariable cppRetval = NativeVariable.createLocal(method.getBody(),
					_returnHelper.getRealNativeType(), "_returnObj", invocation,
					NativeVariable.Flags.BYREF);
			retval = NativeVariable.createLocal(method.getBody(),
					_returnHelper.getNativePInvokeType(), "_retval",
					_returnHelper.marshalNativeRetval(cppRetval.getReference()),
					NativeVariable.Flags.BYREF);
			method.getBody().addStatement(new DestructorInvocation(cppRetval.getReference()));
		} else if (_returnInfo != null) {
			retval = NativeVariable.createLocal(method.getBody(), _returnType, "_retval", invocation);
		} else {
			method.getBody().addStatement(invocation);
			retval = null;
		}

		for (Statement stm : postStmnts) {
			method.getBody().addStatement(stm);
		}

		if (retval != null) {
			method.getBody().addStatement(new ReturnStatement(retval.getReference()));
		}

		return method;
	}

	private String getNativeName(String name) {
		if (name.equals("mutable") || name.equals("namespace"))
			return "_" + name;
		return name;
	}
}
