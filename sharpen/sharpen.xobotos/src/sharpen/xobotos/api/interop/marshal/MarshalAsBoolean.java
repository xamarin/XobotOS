package sharpen.xobotos.api.interop.marshal;

import org.eclipse.jdt.core.dom.ITypeBinding;

import sharpen.core.csharp.ast.*;
import sharpen.xobotos.api.interop.Signature.Flags;
import sharpen.xobotos.api.interop.Signature.Mode;
import sharpen.xobotos.api.interop.glue.AbstractTypeReference;
import sharpen.xobotos.api.interop.glue.TypeReference;

public class MarshalAsBoolean extends MarshalInfo {

	public MarshalAsBoolean(ITypeBinding type) {
		super(type);
	}

	@Override
	public boolean isPrimitiveType() {
		return true;
	}

	@Override
	public CSTypeReferenceExpression getManagedType(Mode mode, Flags flags) {
		if (flags == Flags.ELEMENT)
			return new CSTypeReference("int");
		else
			return new CSTypeReference("bool");
	}

	@Override
	public AbstractTypeReference getNativeType(Mode mode, Flags flags) {
		if (flags == Flags.ELEMENT)
			return new TypeReference("int");
		else
			return new TypeReference("bool");
	}

	@Override
	public CSExpression marshalIn(CSExpression expr, Mode mode, Flags flags) {
		if (flags != Flags.ELEMENT)
			return expr;

		return new CSConditionalExpression(expr, new CSNumberLiteralExpression("1"),
				new CSNumberLiteralExpression("0"));
	}

	public CSExpression marshalOut(CSExpression expr, Mode mode, Flags flags) {
		if (flags != Flags.ELEMENT)
			return expr;

		return new CSConditionalExpression(expr, new CSBoolLiteralExpression(true),
				new CSBoolLiteralExpression(false));
	}

}
