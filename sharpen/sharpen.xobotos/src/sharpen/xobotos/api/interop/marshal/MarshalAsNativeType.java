package sharpen.xobotos.api.interop.marshal;

import org.eclipse.jdt.core.dom.ITypeBinding;

import sharpen.core.csharp.ast.CSByRefTypeReference;
import sharpen.core.csharp.ast.CSExpression;
import sharpen.core.csharp.ast.CSTypeReferenceExpression;
import sharpen.xobotos.api.interop.*;
import sharpen.xobotos.api.interop.Signature.Flags;
import sharpen.xobotos.api.interop.Signature.Mode;
import sharpen.xobotos.api.interop.glue.AbstractTypeReference;

import java.util.List;

public class MarshalAsNativeType extends MarshalInfo {

	public MarshalAsNativeType(ITypeBinding type, AbstractNativeTypeBuilder builder) {
		super(type);
		this._builder = builder;
	}

	private final AbstractNativeTypeBuilder _builder;

	@Override
	public boolean isPrimitiveType() {
		return true;
	}

	@Override
	public List<String> getIncludes() {
		return _builder.getIncludes();
	}

	@Override
	public final CSTypeReferenceExpression getPInvokeType(Mode mode, Flags flags) {
		CSTypeReferenceExpression type = _builder.getPInvokeType();
		if (mode == Mode.OUT)
			return new CSByRefTypeReference(type, true);
		else
			return type;
	}

	@Override
	public final CSTypeReferenceExpression getPInvokeReturnType() {
		return _builder.getPInvokeType();
	}

	@Override
	public AbstractTypeReference getNativeType(Mode mode, Flags flags) {
		return _builder.getNativeType();
	}

	@Override
	public CSTypeReferenceExpression getManagedType(Mode mode, Flags flags) {
		return _builder.getManagedType();
	}

	@Override
	public CSExpression marshalIn(CSExpression expr, Mode mode, Flags flags) {
		return expr;
	}

	@Override
	public void marshal(IManagedMarshalContext context, CSExpression expr, Mode mode, Flags flags) {
		_builder.marshalManaged(context, expr, mode, flags);
	}

	@Override
	public CSExpression marshalRetval(IManagedReturnContext context, CSExpression expr) {
		return _builder.marshalRetval(context, expr);
	}

	@Override
	public void marshalNative(INativeMarshalContext context, Mode mode, Flags flags) {
		_builder.marshalNative(context, mode, flags);
	}

	public AbstractNativeTypeBuilder getTypeBuilder() {
		return _builder;
	}

}
