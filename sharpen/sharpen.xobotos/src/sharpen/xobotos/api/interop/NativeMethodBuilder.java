package sharpen.xobotos.api.interop;

import static sharpen.core.framework.Environments.my;

import org.eclipse.jdt.core.dom.IMethodBinding;
import org.eclipse.jdt.core.dom.ITypeBinding;
import org.eclipse.jdt.core.dom.IVariableBinding;
import org.eclipse.jdt.core.dom.MethodDeclaration;
import org.eclipse.jdt.core.dom.VariableDeclaration;

import sharpen.core.Configuration;
import sharpen.core.NamingStrategy;
import sharpen.core.Sharpen;
import sharpen.core.csharp.ast.*;
import sharpen.core.framework.BindingUtils;
import sharpen.core.framework.ByRef;
import sharpen.xobotos.api.interop.NativeMethod.Kind;
import sharpen.xobotos.api.interop.Signature.Flags;
import sharpen.xobotos.api.interop.Signature.Mode;
import sharpen.xobotos.api.interop.Signature.ParameterInfo;
import sharpen.xobotos.api.interop.Signature.ReturnInfo;
import sharpen.xobotos.api.interop.glue.AbstractTypeReference;
import sharpen.xobotos.api.interop.glue.CompilationUnit;
import sharpen.xobotos.api.interop.glue.Expression;
import sharpen.xobotos.api.interop.glue.IncludeSection;
import sharpen.xobotos.api.interop.glue.Method;
import sharpen.xobotos.api.interop.marshal.MarshalAsClass;
import sharpen.xobotos.api.interop.marshal.MarshalAsNativeType;
import sharpen.xobotos.api.interop.marshal.MarshalInfo;

import java.util.ArrayList;
import java.util.List;
import java.util.logging.Level;

public class NativeMethodBuilder {
	private final NativeBuilder _builder;
	private final MethodDeclaration _node;
	private final NativeMethod _native;
	private final String _nativeName;
	private final String _nativeFunctionName;

	private boolean _resolved;
	private boolean _resolveFailed;
	private ElementInfo _returnInfo;
	private ElementInfo[] _paramInfo;
	private IVariableBinding _implicitInstance;

	private NativeHandleBuilder _nativeHandle;

	private IMethodBinding _binding;
	private String _methodName;

	public static class ElementInfo {
		public final ITypeBinding type;
		public final MarshalInfo marshal;
		public final Mode mode;
		public final Flags flags;

		public boolean isClass() {
			return marshal instanceof MarshalAsNativeType;
		}

		public ITypeBinding getType() {
			return marshal.getType();
		}

		public AbstractNativeTypeBuilder getTypeBuilder() {
			return ((MarshalAsNativeType) marshal).getTypeBuilder();
		}

		public CSTypeReferenceExpression getManagedType() {
			return marshal.getManagedType(mode, flags);
		}

		public CSTypeReferenceExpression getPInvokeType() {
			return marshal.getPInvokeType(mode, flags);
		}

		public CSTypeReferenceExpression getPInvokeReturnType() {
			return marshal.getPInvokeReturnType();
		}

		public AbstractTypeReference getNativeType() {
			return marshal.getNativeType(mode, flags);
		}

		public ElementInfo(ITypeBinding type, MarshalInfo marshal, Mode mode, Flags flags) {
			this.type = type;
			this.marshal = marshal;
			this.mode = mode;
			this.flags = flags;
		}

		public CSExpression marshalIn(CSExpression expr) {
			return marshal.marshalIn(expr, mode, flags);
		}

		public Expression marshalNativeArg(Expression expr) {
			return marshal.marshalNativeArg(expr, mode, flags);
		}
	}

	public NativeMethodBuilder(NativeBuilder builder, MethodDeclaration method, NativeMethod template,
			String name, String funcName, NativeHandleBuilder handleBuilder) {
		this._builder = builder;
		this._nativeHandle = handleBuilder;
		this._node = method;
		this._native = template;
		this._nativeName = name;
		this._nativeFunctionName = funcName;
	}

	public NativeBuilder getNativeBuilder() {
		return _builder;
	}

	public NativeConfiguration _getConfig() {
		return _builder.getConfig();
	}

	public MethodDeclaration getMethod() {
		return _node;
	}

	public NativeMethod getNativeMethod() {
		return _native;
	}

	public NativeHandleBuilder getNativeHandle() {
		return _nativeHandle;
	}

	protected static boolean isVoid(ITypeBinding type) {
		return (type == null) || BindingUtils.qualifiedName(type).equals("void");
	}

	public boolean resolve(IMarshalContext context) {
		if (_resolveFailed)
			return false;
		if (_resolved)
			return true;

		_binding = _node.resolveBinding();
		ITypeBinding returnType = _binding.getReturnType();
		ITypeBinding[] paramTypes = _binding.getParameterTypes();

		_methodName = BindingUtils.qualifiedSignature(_binding);

		final Signature signature = getNativeMethod().getSignature();
		final Kind kind = _native.getKind();

		MarshalInfo returnInfo = null;
		if (isVoid(returnType) && (kind == Kind.CONSTRUCTOR)) {
			ReturnInfo info = signature.getReturnInfo();
			if ((info != null) && (info.marshal != null))
				returnInfo = info.marshal.resolve(null);
			if (returnInfo == null) {
				Sharpen.Log(Level.SEVERE, "Missing marshal info for return type of constructor '%s'",
						_methodName);
				_resolveFailed = true;
			}
		} else if (!isVoid(returnType) && !getNativeMethod().returnVoid()) {
			ReturnInfo info = signature.getReturnInfo();
			if (info != null) {
				if (info.marshal != null)
					returnInfo = info.marshal.resolve(returnType);
				else
					returnInfo = context.getMarshalInfo(returnType);
			} else {
				returnInfo = context.getMarshalInfo(returnType);
			}

			if (returnInfo == null) {
				Sharpen.Log(Level.SEVERE, "Missing marshal info for return type '%s' of method '%s'",
						BindingUtils.qualifiedName(returnType), _methodName);
				_resolveFailed = true;
			}
		}

		if (kind == Kind.CONSTRUCTOR) {
			if (returnInfo == null) {
				Sharpen.Log(Level.SEVERE,
						"Missing marshal info for return type '%s' of constructor '%s'",
						BindingUtils.qualifiedName(returnType), _methodName);
				_resolveFailed = true;
			} else if (!(returnInfo instanceof MarshalAsClass)) {
				Sharpen.Log(Level.SEVERE,
						"Return type '%s' of constructor '%s' must have MarshalAsClass marshal info",
						BindingUtils.qualifiedName(returnType), _methodName);
				_resolveFailed = true;
			}
		}

		if (kind == Kind.DESTRUCTOR) {
			if (_returnInfo != null) {
				Sharpen.Log(Level.SEVERE, "Destructor '%s' cannot return a value.", _methodName);
				_resolveFailed = true;
			} else if (paramTypes.length != 1) {
				Sharpen.Log(Level.SEVERE, "Destructor '%s' must take one single argument.", _methodName);
				_resolveFailed = true;
			} else if (_nativeHandle == null) {
				Sharpen.Log(Level.SEVERE, "Destructor '%s' must have a native handle", _methodName);
				_resolveFailed = true;
			}
		}

		if (_resolveFailed)
			return false;

		if (returnInfo != null) {
			if (!returnInfo.resolve(context, returnType)) {
				Sharpen.Log(Level.SEVERE,
						"Cannot resolve return value in '%s'.", _methodName);
				_resolveFailed = true;
			} else {
				_returnInfo = new ElementInfo(returnType, returnInfo, Mode.OUT, null);
			}
		}

		if (kind == Kind.DESTRUCTOR) {
			_paramInfo = new ElementInfo[1];
			if (_nativeHandle == null) {
				Sharpen.Log(Level.SEVERE, "Missing 'native-handle' for destructor '%s'.", _methodName);
				_resolveFailed = true;
			} else {
				MarshalInfo info = new MarshalAsClass(paramTypes[0], null, _nativeHandle.getTemplate());
				VariableDeclaration vdecl = (VariableDeclaration) _node.parameters().get(0);
				IVariableBinding vbinding = vdecl.resolveBinding();
				ITypeBinding vtype = vbinding.getType();
				if (!info.resolve(context, vtype)) {
					Sharpen.Log(Level.SEVERE, "Cannot resolve marshal info for destructor '%s'.",
							_methodName);
					_resolveFailed = true;
				} else {
					_paramInfo[0] = new ElementInfo(vtype, info, null, null);
				}
			}
		} else {
			_paramInfo = new ElementInfo[paramTypes.length];
			for (int i = 0; i < paramTypes.length; i++) {
				final ParameterInfo info = signature.getParameterInfo(i);
				if ((info == null) || (info.mode == Mode.REMOVE))
					continue;

				MarshalInfo marshal;
				if (info.marshal != null)
					marshal = info.marshal.resolve(paramTypes[i]);
				else
					marshal = context.getMarshalInfo(paramTypes[i]);
				if (marshal == null) {
					Sharpen.Log(Level.SEVERE, "Missing marshal info for type '%s' in method '%s'",
							BindingUtils.qualifiedName(paramTypes[i]), _methodName);
					_resolveFailed = true;
					continue;
				}

				VariableDeclaration vdecl = (VariableDeclaration) _node.parameters().get(i);
				IVariableBinding vbinding = vdecl.resolveBinding();
				ITypeBinding vtype = vbinding.getType();

				boolean isInstanceArg;
				if ((kind == Kind.INSTANCE) || (kind == Kind.PROXY))
					isInstanceArg = (i == 0) && !signature.implicitInstance();
				else
					isInstanceArg = false;

				if (isInstanceArg) {
					_paramInfo[0] = new ElementInfo(vtype, marshal, Mode.REF, null);
					if (!marshal.resolve(context, vtype)) {
						Sharpen.Log(Level.SEVERE,
								"Cannot resolve instance parameter of method '%s'.",
								_methodName);
						_resolveFailed = true;
					}
				} else {
					_paramInfo[i] = new ElementInfo(vtype, marshal, info.mode, info.flags);
					if (!marshal.resolve(context, vtype)) {
						Sharpen.Log(Level.SEVERE, "Cannot resolve parameter %d of method '%s'.", i,
								_methodName);
						_resolveFailed = true;
					}
				}
			}
		}

		if (signature.implicitInstance()) {
			if (_nativeHandle == null) {
				Sharpen.Log(Level.SEVERE, "Cannot use <add-instance> without <native-handle> in '%s'",
						_methodName);
				_resolveFailed = true;
				return false;
			}
			String fieldName = _nativeHandle.getTemplate().getField();
			_implicitInstance = findField(_binding, fieldName);
			if (_implicitInstance == null) {
				Sharpen.Log(Level.SEVERE, "No such field '%s' in type '%s'", fieldName,
						BindingUtils.qualifiedName(_binding.getDeclaringClass()));
				_resolveFailed = true;
				return false;
			}
		}

		if (_resolveFailed)
			return false;

		_resolved = true;
		return true;
	}

	private IVariableBinding findField(IMethodBinding binding, String name) {
		for (final IVariableBinding field : binding.getDeclaringClass().getDeclaredFields()) {
			if (field.getName().equals(name))
				return field;
		}

		return null;
	}

	public String getNativeName() {
		return _nativeName;
	}

	public String getNativeFunction() {
		return _nativeFunctionName;
	}

	public ElementInfo getReturnInfo() {
		return _returnInfo;
	}

	public ElementInfo[] getParameterInfo() {
		return _paramInfo;
	}

	public IVariableBinding getImplicitInstance() {
		return _implicitInstance;
	}

	public void collectIncludes(IncludeSection section) {
		if (_resolveFailed)
			return;

		section.addIncludes(_native);
		for (final ElementInfo param : _paramInfo) {
			collectIncludes(section, param);
		}
		collectIncludes(section, _returnInfo);
	}

	private void collectIncludes(IncludeSection section, ElementInfo info) {
		if (info == null)
			return;
		if (info.isClass()) {
			if (info.getTypeBuilder() instanceof HelperClassBuilder) {

			}
			NativeBuilder builder = info.getTypeBuilder().getNativeBuilder();
			if (builder != _builder)
				section.addInclude(builder.getHeaderInclude());
		} else if (info.marshal != null) {
			section.addIncludes(info.marshal);
		}
	}

	public boolean createPInvokeWrapper(CSTypeDeclaration parent, final CSMethod method) {
		if (_resolveFailed)
			return false;

		final NamingStrategy ns = my(Configuration.class).getNamingStrategy();

		final CSTypeReferenceExpression pinvokeReturnType;
		final CSTypeReferenceExpression mappedReturnType;

		if (_returnInfo != null) {
			mappedReturnType = _returnInfo.getManagedType();
			pinvokeReturnType = _returnInfo.getPInvokeReturnType();
			method.returnType(mappedReturnType);
		} else {
			pinvokeReturnType = null;
			mappedReturnType = null;
		}

		CSTypeReferenceExpression[] mappedParamTypes = new CSTypeReferenceExpression[_paramInfo.length];

		for (int i = 0; i < _paramInfo.length; i++) {
			if (_paramInfo[i] == null)
				continue;
			mappedParamTypes[i] = _paramInfo[i].getManagedType();
			method.parameters().get(i).type(mappedParamTypes[i]);
		}

		final CSDllImport dllImport = _builder.getConfig().getDllImportAttribute();

		final List<CSExpression> args = new ArrayList<CSExpression>();

		final CSMethod pinvoke = new CSMethod(_nativeFunctionName);
		pinvoke.dllImport(dllImport);
		pinvoke.modifier(CSMethodModifier.Extern);
		pinvoke.visibility(CSVisibility.Private);

		if (_returnInfo != null) {
			pinvoke.returnType(pinvokeReturnType);
		} else {
			pinvoke.returnType(new CSTypeReference("void"));
		}

		if (_native.returnVoid())
			method.returnType(new CSTypeReference("void"));

		if (_native.getKind() == Kind.DESTRUCTOR) {
			final String name = method.parameters().get(0).name();
			CSExpression pref = new CSReferenceExpression(name);
			CSExpression mr = new CSMemberReferenceExpression(pref, "Dispose");
			method.body().addStatement(new CSMethodInvocationExpression(mr));
			return true;
		}

		if (_implicitInstance != null) {
			CSExpression fref = new CSReferenceExpression(_implicitInstance.getName());
			CSTypeReferenceExpression ftype = _nativeHandle.getManagedType();
			pinvoke.addParameter(new CSVariableDeclaration("_instance", ftype));
			args.add(fref);
		}

		final List<CSVariableDeclaration> decls = new ArrayList<CSVariableDeclaration>();
		final List<CSStatement> preStatements = new ArrayList<CSStatement>();
		final List<CSStatement> postStatements = new ArrayList<CSStatement>();
		final List<CSStatement> cleanupStatements = new ArrayList<CSStatement>();

		for (int i = 0, pos = 0; i < _paramInfo.length; i++) {
			if (_paramInfo[i] == null) {
				method.removeParameter(pos);
				continue;
			}

			final String name = ns.identifier(method.parameters().get(pos).name());
			CSExpression pref = new CSReferenceExpression(name);

			IManagedMarshalContext context = new IManagedMarshalContext() {
				@Override
				public void addDeclaration(CSVariableDeclaration decl, CSStatement cleanup) {
					decls.add(decl);
					if (cleanup != null)
						cleanupStatements.add(cleanup);
				}

				@Override
				public void addPreStatement(CSStatement statement) {
					preStatements.add(statement);
				}

				@Override
				public void addPostStatement(CSStatement statement) {
					postStatements.add(statement);
				}

				@Override
				public ManagedVariable addParameter(String suffix, CSTypeReferenceExpression type,
						CSExpression arg, CSAttribute... attrs) {
					final String pname = suffix != null ? name + suffix : name;
					CSVariableDeclaration vdecl = pinvoke.addParameter(pname, type, attrs);
					args.add(arg);
					return new ManagedVariable(vdecl);
				}

				@Override
				public String getVariableName(String suffix) {
					return suffix != null ? name + "_" + suffix : name;
				}
			};

			_paramInfo[i].marshal.marshal(context, pref, _paramInfo[i].mode, _paramInfo[i].flags);
			pos++;
		}

		final CSExpression[] arglist = args.toArray(new CSExpression[0]);
		CSExpression mie = new CSMethodInvocationExpression(new CSReferenceExpression(pinvoke.name()), arglist);

		final CSExpression outExpr;
		final ByRef<ManagedVariable> retval = new ByRef<ManagedVariable>();

		if (_returnInfo != null) {
			IManagedReturnContext context = new IManagedReturnContext() {
				@Override
				public void addStatement(CSStatement statement) {
					postStatements.add(statement);
				}

				@Override
				public ManagedVariable createVariable(String name, CSTypeReferenceExpression type,
						CSExpression init) {
					final String vname = "_retval_" + name;
					ManagedVariable var = new ManagedVariable(vname, type);
					if (init != null)
						var.getDeclaration().initializer(init);
					postStatements.add(var.getDeclarationStatement());
					return var;
				}

				@Override
				public ManagedVariable createRetval(CSExpression init) {
					retval.value = new ManagedVariable("_retval", mappedReturnType);
					retval.value.getDeclaration().initializer(init);
					postStatements.add(retval.value.getDeclarationStatement());
					return retval.value;
				}
			};
			outExpr = _returnInfo.marshal.marshalRetval(context, mie);
			if (retval.value != null) {
				if (outExpr != null)
					throw new IllegalStateException();
			} else if (outExpr == null) {
				throw new IllegalStateException();
			}
		} else {
			outExpr = null;
		}

		for (CSVariableDeclaration decl : decls)
			method.body().addStatement(new CSDeclarationStatement(-1, decl));

		final CSBlock block;
		if (cleanupStatements.size() > 0) {
			CSTryStatement tryBlock = new CSTryStatement(-1);
			CSBlock finallyBlock = new CSBlock();
			for (CSStatement stm : cleanupStatements) {
				finallyBlock.addStatement(stm);
			}
			tryBlock.finallyBlock(finallyBlock);
			method.body().addStatement(tryBlock);
			block = tryBlock.body();
		} else {
			block = method.body();
		}

		for (CSStatement stm : preStatements)
			block.addStatement(stm);

		if (_returnInfo != null) {
			if (postStatements.size() > 0) {
				if (retval.value == null) {
					retval.value = new ManagedVariable("_retval", mappedReturnType);
					retval.value.getDeclaration().initializer(outExpr);
					block.addStatement(retval.value.getDeclarationStatement());
				}

				for (CSStatement stmt : postStatements)
					block.addStatement(stmt);

				block.addStatement(new CSReturnStatement(-1, retval.value.getReference()));
			} else {
				block.addStatement(new CSReturnStatement(-1, outExpr));
			}
		} else {
			block.addStatement(mie);
			for (CSStatement stmt : postStatements)
				block.addStatement(stmt);
		}

		parent.addMember(pinvoke);
		return true;
	}

	public boolean createNativeMethod(CompilationUnit unit) {
		if(_resolveFailed)
			return false;

		if (_native.getKind() == Kind.DESTRUCTOR)
			return true;
		NativeGlueGenerator generator = new NativeGlueGenerator(this);
		if (!generator.resolve())
			return false;
		Method method = generator.generate();
		if (method == null)
			return false;
		unit.addMethod(method);
		return true;
	}
}
