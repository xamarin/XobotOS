package sharpen.xobotos.api.interop;

import static sharpen.core.framework.Environments.my;

import org.eclipse.jdt.core.dom.ITypeBinding;
import org.eclipse.jdt.core.dom.IVariableBinding;

import sharpen.core.Configuration;
import sharpen.core.NamingStrategy;
import sharpen.core.Sharpen;
import sharpen.core.csharp.ast.*;
import sharpen.core.framework.BindingUtils;
import sharpen.xobotos.api.bindings.BindingManager;
import sharpen.xobotos.api.interop.NativeMethodBuilder.ElementInfo;
import sharpen.xobotos.api.interop.NativeStruct.MemberInfo;
import sharpen.xobotos.api.interop.Signature.Flags;
import sharpen.xobotos.api.interop.Signature.Mode;
import sharpen.xobotos.api.interop.glue.*;
import sharpen.xobotos.api.interop.marshal.MarshalInfo;

import java.util.List;
import java.util.logging.Level;

public class StructHelperClass extends HelperClassBuilder {

	private final NativeStruct _template;

	private boolean _resolved;
	private boolean _resolveFailed;
	private ElementInfo[] _fieldInfo;

	public StructHelperClass(NativeBuilder builder, ITypeBinding type, NativeStruct template) {
		super(type, type.getName(), builder, new CSTypeReference(BindingUtils.qualifiedName(type)),
				template.getNativeType(), true, false);
		this._template = template;
		this._resolved = false;
	}

	@Override
	protected boolean isByRef() {
		return false;
	}

	@Override
	public List<String> getIncludes() {
		return _template.getIncludes();
	}

	@Override
	protected CSTypeReferenceExpression getManagedHelperType() {
		return new CSNestedTypeReference(getManagedType(), super.getManagedHelperType());
	}

	@Override
	protected boolean isBlittable() {
		return false;
	}

	@Override
	protected void buildMembers() {
		if (!_resolved)
			throw new IllegalStateException();
		if (_resolveFailed)
			return;

		final NamingStrategy ns = my(Configuration.class).getNamingStrategy();
		final List<MemberInfo> members = _template.getMembers();

		for (int i = 0; i < members.size(); i++) {
			final MemberInfo member = members.get(i);
			final String name = ns.identifier(member.getName());

			if (member.getValue() != null)
				addMember(new ValueMember(name, member.getValue()));
			else
				addMember(new StructMember(_fieldInfo[i], member.getNativeName(), name,
						member.getMode()));
		}
	}

	@Override
	public boolean resolve(IMarshalContext context) {
		if (BindingManager.DEBUG)
			Sharpen.Debug("RESOLVE STRUCT: %s", getName());

		if (_resolved)
			return !_resolveFailed;

		final List<MemberInfo> members = _template.getMembers();

		_fieldInfo = new ElementInfo[members.size()];

		for (int i = 0; i < members.size(); i++) {
			final MemberInfo member = members.get(i);
			IVariableBinding field = findField(getType(), member.getName());
			if (field == null) {
				Sharpen.Log(Level.SEVERE, "No such field '%s' in type '%s'", member.getName(),
						BindingUtils.qualifiedName(getType()));
				_resolveFailed = true;
				continue;
			}

			if (member.getValue() != null)
				continue;

			MarshalInfo marshal;
			if (member.getMarshalInfo() != null)
				marshal = member.getMarshalInfo().resolve(field.getType());
			else
				marshal = context.getMarshalInfo(field.getType());
			if (marshal == null) {
				Sharpen.Log(Level.SEVERE, "Missing marshal info for type '%s' of field '%s'",
						BindingUtils.qualifiedName(field.getType()), member.getName());
				_resolveFailed = true;
				continue;
			}

			_fieldInfo[i] = new ElementInfo(field.getType(), marshal, null, Flags.ELEMENT);

			if (BindingManager.DEBUG)
				Sharpen.Debug("STRUCT MEMBER: %s - %s", member.getName(),
						BindingUtils.qualifiedName(field.getType()));

			if (!marshal.resolve(context, field.getType())) {
				Sharpen.Log(Level.SEVERE, "Failed to resolve field '%s' in '%s'",
						member.getName(), BindingUtils.qualifiedName(getType()));
				_resolveFailed = true;
				continue;
			}

			if (!marshal.isPrimitiveType()) {
				Sharpen.Log(Level.SEVERE, "Field '%s' in '%s' is not a primitive type",
						member.getName(), BindingUtils.qualifiedName(getType()));
				_resolveFailed = true;
				continue;
			}

			if (BindingManager.DEBUG)
				Sharpen.Debug("STRUCT MEMBER DONE: %s - %s", member.getName(),
						BindingUtils.qualifiedName(field.getType()));
		}

		if (BindingManager.DEBUG)
			Sharpen.Debug("RESOLVE STRUCT DONE: %s%s", getName(), _resolveFailed ? " - ERROR" : "");

		_resolved = true;
		return true;
	}

	private IVariableBinding findField(ITypeBinding type, String name) {
		for (final IVariableBinding field : type.getDeclaredFields()) {
			if (field.getName().equals(name))
				return field;
		}
		return null;
	}

	@Override
	protected CSExpression computeNativeSize(CSExpression expr) {
		return new CSMethodInvocationExpression(new CSReferenceExpression("Marshal.SizeOf"),
				new CSTypeofExpression(getManagedStructType()));
	}

	@Override
	protected CSExpression createInstance(ManagedVariable obj) {
		return new CSConstructorInvocationExpression(getManagedType());
	}

	private static class StructMember extends ElementMember {
		private final String _ptrName;
		private final Mode _mode;

		private StructMember(ElementInfo info, String nativeName, String managedName, Mode mode, Flags... flags) {
			super(info, nativeName, managedName, flags);
			this._ptrName = "ptr_" + nativeName;
			this._mode = mode;
		}

		private Mode getMode() {
			return _mode;
		}

		@Override
		protected Statement unwrap(NativeVariable src, NativeVariable dest) {
			if (!isClass())
				return new AssignmentStatement(getReference(dest), getReference(src));

			return new AssignmentStatement(getReference(dest), new MethodInvocation(
					getHelper().UNWRAP.expr(), getReference(src)));
		}

		@Override
		protected void createPinnedPtr(CSStruct struct, CSMethod free) {
			if (!isClass())
				return;

			CSField ptr = new CSField(_ptrName, new CSTypeReference("System.IntPtr"), CSVisibility.Public);
			struct.addMember(ptr);

			free.body().addStatement(
					new CSMethodInvocationExpression(getHelper().FREE_MANAGED_PTR.expr(),
							new CSReferenceExpression(_ptrName)));
		}

		@Override
		protected CSStatement getPinnedPtr(ManagedVariable arg, ManagedVariable obj, ManagedVariable pinned) {
			CSExpression expr = getReference(arg);
			if (isClass()) {
				expr = new CSMethodInvocationExpression(getHelper().MANAGED_TO_NATIVE.expr(), expr);

				CSBlock block = new CSBlock();
				block.addStatement(new CSInfixExpression("=", getReference(obj), expr));
				block.addStatement(new CSInfixExpression("=",
						new CSMemberReferenceExpression(pinned.getReference(), _ptrName),
						getReference(obj)));
				return block;
			} else {
				return new CSExpressionStatement(-1,
						new CSInfixExpression("=", getReference(obj), expr));
			}
		}

		@Override
		protected CSStatement marshalIn(ManagedVariable arg, ManagedVariable obj, ManagedVariable ptr) {
			CSExpression expr;
			if (isClass()) {
				expr = new CSMethodInvocationExpression(getHelper().MANAGED_TO_NATIVE.expr(),
						getReference(arg));
			} else {
				expr = getElementInfo().marshalIn(getReference(arg));
			}
			return new CSExpressionStatement(-1, new CSInfixExpression("=", getReference(obj), expr));
		}

		@Override
		protected CSStatement marshalOut(ManagedVariable arg, ManagedVariable obj, ManagedVariable ptr) {
			if (getMode() == Mode.IN)
				return null;
			CSExpression expr = getReference(obj);
			if (isClass()) {
				expr = new CSMethodInvocationExpression(getHelper().NATIVE_TO_MANAGED.expr(), expr);
			}

			return new CSExpressionStatement(-1, new CSInfixExpression("=", getReference(arg), expr));
		}

		@Override
		protected CSStatement nativeToManaged(ManagedVariable arg, ManagedVariable obj, ManagedVariable ptr) {
			if (getMode() == Mode.IN)
				return null;
			CSExpression expr = getReference(obj);
			if (isClass()) {
				expr = new CSMethodInvocationExpression(getHelper().NATIVE_TO_MANAGED.expr(), expr);
			}

			return new CSExpressionStatement(-1, new CSInfixExpression("=", getReference(arg), expr));
		}

		@Override
		public CSStatement free(ManagedVariable obj) {
			if (!isClass())
				return null;

			return new CSExpressionStatement(-1,
					new CSMethodInvocationExpression(getHelper().FREE_MANAGED_PTR.expr(),
							getReference(obj)));
		}

		@Override
		public Statement freeMembers(NativeVariable obj) {
			if (!isClass())
				return null;

			return new ExpressionStatement(new MethodInvocation(getHelper().DESTRUCTOR.expr(),
					getReference(obj)));
		}

		@Override
		protected Statement wrap(NativeVariable src, NativeVariable dest) {
			if (!isClass()) {
				Expression expr = getElementInfo().marshalNativeArg(getReference(src));
				return new AssignmentStatement(getReference(dest), expr);
			}
			else if (isByRef())
				return new AssignmentStatement(getReference(dest), new MethodInvocation(
						getHelper().WRAP.expr(), getReference(src)));
			else {
				Expression destAddr = new AddressOfExpression(getReference(dest));
				return new ExpressionStatement(new MethodInvocation(getHelper().WRAP.expr(),
						getReference(src), destAddr));
			}
		}

		@Override
		protected Statement marshalOut(NativeVariable src, NativeVariable dest) {
			if (getMode() == Mode.IN)
				return null;
			if (isClass()) {
				Expression srcAddr = new DereferenceExpression(getReference(src));
				return new ExpressionStatement(new MethodInvocation(getHelper().MARSHAL_OUT.expr(),
						srcAddr, getReference(dest)));
			} else {
				return new AssignmentStatement(getReference(dest), getReference(src));
			}
		}
	}

	private static class ValueMember extends Member {
		private final String _value;

		public ValueMember(String name, String value) {
			super(null, null, null, name, Flags.HAS_VALUE);
			this._value = value;
		}

		@Override
		protected void createPinnedPtr(CSStruct struct, CSMethod dtor) {
			;
		}

		@Override
		protected CSStatement getPinnedPtr(ManagedVariable arg, ManagedVariable obj, ManagedVariable pinned) {
			return null;
		}

		@Override
		protected CSStatement marshalIn(ManagedVariable arg, ManagedVariable obj, ManagedVariable ptr) {
			return null;
		}

		@Override
		protected CSStatement marshalOut(ManagedVariable arg, ManagedVariable obj, ManagedVariable ptr) {
			return new CSExpressionStatement(-1, new CSInfixExpression("=", getReference(arg),
					new CSStringLiteralExpression(_value)));
		}

		@Override
		protected CSStatement nativeToManaged(ManagedVariable arg, ManagedVariable obj, ManagedVariable ptr) {
			return new CSExpressionStatement(-1, new CSInfixExpression("=", getReference(arg),
					new CSStringLiteralExpression(_value)));
		}

		@Override
		public CSStatement free(ManagedVariable obj) {
			return null;
		}

		@Override
		protected Statement wrap(NativeVariable src, NativeVariable dest) {
			return null;
		}

		@Override
		protected Statement unwrap(NativeVariable src, NativeVariable dest) {
			return null;
		}

		@Override
		protected Statement freeMembers(NativeVariable obj) {
			return null;
		}

		@Override
		protected Statement marshalOut(NativeVariable src, NativeVariable dest) {
			return null;
		}
	}
}
