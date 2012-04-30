package sharpen.xobotos.api.interop.marshal;

import org.eclipse.jdt.core.dom.ITypeBinding;

import sharpen.core.csharp.ast.CSTypeReference;
import sharpen.core.csharp.ast.CSTypeReferenceExpression;
import sharpen.xobotos.api.interop.Signature.Flags;
import sharpen.xobotos.api.interop.Signature.Mode;
import sharpen.xobotos.api.interop.glue.AbstractTypeReference;
import sharpen.xobotos.api.interop.glue.TypeReference;

public class MarshalAsPrimitive extends MarshalInfo {

	private final String _managedType;
	private final String _nativeType;

	public MarshalAsPrimitive(ITypeBinding type, String managedType, String nativeType) {
		super(type);
		this._managedType = managedType;
		this._nativeType = nativeType;
	}

	@Override
	public boolean isPrimitiveType() {
		return true;
	}

	@Override
	public CSTypeReferenceExpression getManagedType(Mode mode, Flags flags) {
		return new CSTypeReference(_managedType);
	}

	@Override
	public AbstractTypeReference getNativeType(Mode mode, Flags flags) {
		return new TypeReference(_nativeType);
	}
}
