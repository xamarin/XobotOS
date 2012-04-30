package sharpen.xobotos.api.interop.glue;

public class ParenthesizedExpression extends Expression {

	private final Expression _expr;

	public ParenthesizedExpression(Expression expr) {
		this._expr = expr;
	}

	@Override
	protected boolean needParens() {
		return false;
	}

	public Expression getExpression() {
		return _expr;
	}

	@Override
	public void accept(Visitor visitor) {
		visitor.visit(this);
	}

}
