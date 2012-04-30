package sharpen.core.csharp.ast;

public class CSByRefExpression extends CSReferenceExpression {

	private CSExpression _expression;
	private boolean _is_out;

	public CSByRefExpression(CSExpression expression, boolean is_out) {
		super("ref");
		_expression = expression;
		_is_out = is_out;
	}

	public CSExpression expression() {
		return _expression;
	}

	public boolean isOut() {
		return _is_out;
	}

	@Override
	public void accept(CSVisitor visitor) {
		visitor.visit(this);
	}

}
