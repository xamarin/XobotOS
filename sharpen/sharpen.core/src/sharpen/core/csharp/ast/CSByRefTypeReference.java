package sharpen.core.csharp.ast;

public class CSByRefTypeReference extends CSTypeReferenceExpression {

	private final CSTypeReferenceExpression _elementType;
	private final boolean _is_out;

	public CSByRefTypeReference(CSTypeReferenceExpression elementType, boolean is_out) {
		this._elementType = elementType;
		this._is_out = is_out;
	}

	@Override
	public String getTypeName() {
		return (_is_out ? "out " : "ref ") + _elementType.getTypeName();
	}

	public CSTypeReferenceExpression getElementType() {
		return _elementType;
	}

	public boolean isOut() {
		return _is_out;
	}

	@Override
	public void accept(CSVisitor visitor) {
		visitor.visit(this);
	}

}
