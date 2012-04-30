package sharpen.xobotos.api.interop.glue;

public class IndexedExpression extends Expression {

	private final Expression _expr;
	private final Expression _index;

	public IndexedExpression(Expression expr, Expression index) {
		this._expr = expr;
		this._index = index;
	}

	@Override
	protected boolean needParens() {
		return true;
	}

	public Expression getExpression() {
		return _expr.getParenthesizedExpr();
	}

	public Expression getIndex() {
		return _index;
	}

	@Override
	public void accept(Visitor visitor) {
		visitor.visit(this);
	}

}
