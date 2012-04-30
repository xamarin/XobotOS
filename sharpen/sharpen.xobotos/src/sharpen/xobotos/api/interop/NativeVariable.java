package sharpen.xobotos.api.interop;

import sharpen.xobotos.api.interop.glue.*;

import java.util.EnumSet;

public final class NativeVariable {
	private final IVariable _var;
	private final EnumSet<NativeVariable.Flags> _flags;

	public enum Flags {
		CLASS, CONST, BYREF, REF, OUT
	}

	private static AbstractTypeReference getEffectiveType(AbstractTypeReference type, EnumSet<NativeVariable.Flags> flags) {
		if (flags.contains(Flags.OUT)) {
			return new PointerType(new PointerType(type));
		} else if (flags.contains(Flags.BYREF)) {
			if (flags.contains(Flags.CONST))
				return new ConstPointerType(type);
			else
				return new PointerType(type);
		} else if (flags.contains(Flags.CONST))
			return new ConstReferenceType(type);
		else if (flags.contains(Flags.REF))
			return new ReferenceType(type);
		else
			return type;
	}

	public static NativeVariable createLocal(Block body, AbstractTypeReference type, String name,
			Expression init, NativeVariable.Flags... flags) {
		return createLocal(body, type, name, init, HelperClassBuilder.buildSet(NativeVariable.Flags.class, flags));
	}

	public static NativeVariable createLocal(Block body, AbstractTypeReference type, String name,
			Expression init, EnumSet<NativeVariable.Flags> flags) {
		AbstractTypeReference effective = getEffectiveType(type, flags);
		LocalVariable var = new LocalVariable(effective, name, init);
		body.addStatement(var);
		return new NativeVariable(var, flags);
	}

	public static NativeVariable createLocal(INativeMarshalContext context, AbstractTypeReference type,
			String name, Expression init, NativeVariable.Flags... flags) {
		return createLocal(context, type, name, init, HelperClassBuilder.buildSet(NativeVariable.Flags.class, flags));
	}

	public static NativeVariable createLocal(INativeMarshalContext context, AbstractTypeReference type,
			String name, Expression init, EnumSet<NativeVariable.Flags> flags) {
		AbstractTypeReference effective = getEffectiveType(type, flags);
		NativeVariable var = context.createVariable(name, effective, init);
		var._flags.addAll(flags);
		return var;
	}

	public static NativeVariable createParameter(AbstractMethod method, AbstractTypeReference type, String name,
			NativeVariable.Flags... flags) {
		EnumSet<NativeVariable.Flags> e = HelperClassBuilder.buildSet(NativeVariable.Flags.class, flags);
		AbstractTypeReference effective = getEffectiveType(type, e);
		Parameter param = new Parameter(effective, name);
		method.addParameter(param);
		return new NativeVariable(param, e);
	}

	public static NativeVariable createParameter(INativeMarshalContext context, AbstractTypeReference type,
			String name, NativeVariable.Flags... flags) {
		EnumSet<NativeVariable.Flags> e = HelperClassBuilder.buildSet(NativeVariable.Flags.class, flags);
		AbstractTypeReference effective = getEffectiveType(type, e);
		NativeVariable var = context.createParameter(name, effective);
		var._flags.addAll(e);
		return var;
	}

	private NativeVariable(IVariable var, EnumSet<NativeVariable.Flags> flags) {
		this._var = var;
		this._flags = flags;
	}

	public NativeVariable(IVariable var, Flags... flags) {
		this._var = var;
		this._flags = HelperClassBuilder.buildSet(Flags.class, flags);
	}

	public Expression getReference() {
		return new VariableReference(_var);
	}

	public Expression getAddressOfExpr() {
		return new AddressOfExpression(getReference());
	}

	public boolean isTarget() {
		return _flags.contains(Flags.CLASS);
	}

	public boolean isByRef() {
		return _flags.contains(Flags.BYREF) || _flags.contains(Flags.OUT);
	}

	public Expression getMemberAccess(String name) {
		if (isByRef())
			return new InstanceMemberAccess(getReference(), name);
		else
			return new StructMemberAccess(getReference(), name);
	}

	public Expression getDereferenceExpr() {
		if (!isByRef())
			throw new IllegalStateException();
		return new DereferenceExpression(getReference());
	}
}