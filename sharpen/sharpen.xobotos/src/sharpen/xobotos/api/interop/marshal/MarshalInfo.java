package sharpen.xobotos.api.interop.marshal;

import org.eclipse.jdt.core.dom.ITypeBinding;

import sharpen.core.csharp.ast.CSExpression;
import sharpen.core.csharp.ast.CSTypeReferenceExpression;
import sharpen.xobotos.api.AbstractReference;
import sharpen.xobotos.api.interop.*;
import sharpen.xobotos.api.interop.Signature.Flags;
import sharpen.xobotos.api.interop.Signature.Mode;
import sharpen.xobotos.api.interop.glue.AbstractTypeReference;
import sharpen.xobotos.api.interop.glue.Expression;

import java.util.ArrayList;
import java.util.List;

public abstract class MarshalInfo implements IncludeFileProvider {

	public abstract static class MarshalEntry extends AbstractReference {
		protected Object readResolve() {
			return this;
		}

		public abstract MarshalInfo resolve(ITypeBinding type);
	}

	private final ITypeBinding _type;

	protected MarshalInfo(ITypeBinding type) {
		this._type = type;
	}

	public ITypeBinding getType() {
		return _type;
	}

	public abstract boolean isPrimitiveType();

	public abstract AbstractTypeReference getNativeType(Mode mode, Flags flags);

	public abstract CSTypeReferenceExpression getManagedType(Mode mode, Flags flags);

	public CSTypeReferenceExpression getPInvokeType(Mode mode, Flags flags) {
		return getManagedType(mode, flags);
	}

	public CSTypeReferenceExpression getPInvokeReturnType() {
		return getPInvokeType(Mode.OUT, null);
	}

	@Override
	public List<String> getIncludes() {
		return new ArrayList<String>();
	}

	public CSExpression marshalIn(CSExpression expr, Mode mode, Flags flags) {
		return expr;
	}

	public void marshal(IManagedMarshalContext context, CSExpression expr, Mode mode, Flags flags) {
		final CSTypeReferenceExpression type = getPInvokeType(mode, flags);
		CSExpression arg = marshalIn(expr, mode, flags);
		context.addParameter(null, type, arg);
	}

	public CSExpression marshalRetval(IManagedReturnContext context, CSExpression expr) {
		return expr;
	}

	public void marshalNative(INativeMarshalContext context, Mode mode, Flags flags) {
		final AbstractTypeReference type = getNativeType(mode, flags);
		final NativeVariable param = context.createParameter(null, type);
		final Expression expr = marshalNativeArg(param.getReference(), mode, flags);
		context.addArgument(expr);
	}

	public Expression marshalNativeArg(Expression expr, Mode mode, Flags flags) {
		return expr;
	}

	public boolean resolve(IMarshalContext context, ITypeBinding type) {
		return true;
	}
}
