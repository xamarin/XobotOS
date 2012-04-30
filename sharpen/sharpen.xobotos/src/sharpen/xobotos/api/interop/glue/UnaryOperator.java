package sharpen.xobotos.api.interop.glue;

public class UnaryOperator extends Expression {

	private final String _operator;
	private final Expression _expr;

	public UnaryOperator(String op, Expression expr) {
		this._operator = op;
		this._expr = expr;
	}

	@Override
	protected boolean needParens() {
		return true;
	}

	public Expression getExpression() {
		return _expr.getParenthesizedExpr();
	}

	public String getOperator() {
		return _operator;
	}

	@Override
	public void accept(Visitor visitor) {
		visitor.visit(this);
	}

}
