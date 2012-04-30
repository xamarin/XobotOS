package sharpen.xobotos.api.interop.marshal;

import com.thoughtworks.xstream.annotations.XStreamAlias;

import org.eclipse.jdt.core.dom.ITypeBinding;

import sharpen.core.csharp.ast.CSCastExpression;
import sharpen.core.csharp.ast.CSExpression;
import sharpen.core.csharp.ast.CSTypeReference;
import sharpen.core.csharp.ast.CSTypeReferenceExpression;
import sharpen.xobotos.api.interop.Signature.Flags;
import sharpen.xobotos.api.interop.Signature.Mode;
import sharpen.xobotos.api.interop.glue.AbstractTypeReference;
import sharpen.xobotos.api.interop.glue.CastExpression;
import sharpen.xobotos.api.interop.glue.Expression;
import sharpen.xobotos.api.interop.glue.TypeReference;
import sharpen.xobotos.config.ConfigurationException;

public class MarshalAsEnum extends MarshalInfo {

	@XStreamAlias("native-enum")
	public static class Entry extends MarshalEntry {
		@XStreamAlias("managed-type")
		private String _managedType;

		@XStreamAlias("native-type")
		private String _nativeType;

		@Override
		protected Object readResolve() {
			if (_nativeType == null)
				throw new ConfigurationException("Missing <native-type> in MarshalAsEnum");
			return super.readResolve();
		}

		@Override
		public MarshalInfo resolve(ITypeBinding type) {
			if (!type.isEnum() && (!type.isPrimitive() || !type.getName().equals("int")))
				return null;

			return new MarshalAsEnum(type, _managedType, _nativeType);
		}
	}

	private final String _managedType;
	private final String _nativeType;

	protected MarshalAsEnum(ITypeBinding type, String managedType, String nativeType) {
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
		return new CSTypeReference("int");
	}

	@Override
	public CSTypeReferenceExpression getPInvokeType(Mode mode, Flags flags) {
		return new CSTypeReference("int");
	}

	@Override
	public AbstractTypeReference getNativeType(Mode mode, Flags flags) {
		return new TypeReference("int");
	}

	@Override
	public CSExpression marshalIn(CSExpression expr, Mode mode, Flags flags) {
		if (_managedType != null)
			return new CSCastExpression(getPInvokeType(mode, flags), expr);
		else
			return expr;
	}

	@Override
	public Expression marshalNativeArg(Expression expr, Mode mode, Flags flags) {
		final TypeReference enumType = new TypeReference(_nativeType);
		return new CastExpression(enumType, expr);
	}
}
