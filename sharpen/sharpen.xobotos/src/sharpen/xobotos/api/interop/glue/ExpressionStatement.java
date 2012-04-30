package sharpen.xobotos.api.interop.glue;

public class ExpressionStatement extends Statement {
	private final StatementExpression _expr;

	public ExpressionStatement(StatementExpression expr) {
		this._expr = expr;
	}

	public StatementExpression getExpression() {
		return _expr;
	}

	@Override
	public void accept(Visitor visitor) {
		visitor.visit(this);
	}
}
