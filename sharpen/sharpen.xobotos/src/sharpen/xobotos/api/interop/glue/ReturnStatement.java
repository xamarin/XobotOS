package sharpen.xobotos.api.interop.glue;

public class ReturnStatement extends Statement {
	final Expression _expr;

	public ReturnStatement() {
		this._expr = null;
	}

	public ReturnStatement(Expression expr) {
		this._expr = expr;
	}

	public boolean hasReturnValue() {
		return _expr != null;
	}

	public Expression getExpression() {
		return _expr;
	}

	@Override
	public void accept(Visitor visitor) {
		visitor.visit(this);
	}

}
