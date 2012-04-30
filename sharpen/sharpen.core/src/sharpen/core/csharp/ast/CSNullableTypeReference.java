package sharpen.core.csharp.ast;

public class CSNullableTypeReference extends CSTypeReferenceExpression {

	private CSTypeReferenceExpression _type;

	public CSNullableTypeReference(CSTypeReferenceExpression type) {
		this._type = type;
	}

	public CSTypeReferenceExpression getElementType() {
		return _type;
	}

	@Override
	public void accept(CSVisitor visitor) {
		visitor.visit(this);
	}

	@Override
	public String getTypeName() {
		return _type.getTypeName() + "?";
	}

}
