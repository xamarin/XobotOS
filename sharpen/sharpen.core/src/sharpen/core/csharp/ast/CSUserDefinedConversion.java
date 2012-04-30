package sharpen.core.csharp.ast;

public class CSUserDefinedConversion extends CSMember {

	private final CSTypeReferenceExpression _sourceType;
	private final CSTypeReferenceExpression _targetType;
	private final boolean _implicit;

	private CSBlock _body = new CSBlock();

	public CSUserDefinedConversion(CSTypeReferenceExpression source, CSTypeReferenceExpression target, boolean implicit) {
		super("operator");
		this._sourceType = source;
		this._targetType = target;
		this._implicit = implicit;
	}

	public CSTypeReferenceExpression sourceType() {
		return _sourceType;
	}

	public CSTypeReferenceExpression targetType() {
		return _targetType;
	}

	public boolean implicit() {
		return _implicit;
	}

	@Override
	public void accept(CSVisitor visitor) {
		visitor.visit(this);
	}

	public CSBlock body() {
		return _body;
	}

}
