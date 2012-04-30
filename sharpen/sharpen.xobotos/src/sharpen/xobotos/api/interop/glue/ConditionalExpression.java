package sharpen.xobotos.api.interop.glue;

public class ConditionalExpression extends Expression {

	private final Expression _cond;
	private final Expression _true;
	private final Expression _false;

	public ConditionalExpression(Expression cond, Expression trueExpr, Expression falseExpr) {
		this._cond = cond;
		this._true = trueExpr;
		this._false = falseExpr;
	}

	@Override
	protected boolean needParens() {
		return true;
	}

	public Expression getCondition() {
		return _cond;
	}

	public Expression getTrueExpression() {
		return _true;
	}

	public Expression getFalseExpression() {
		return _false;
	}

	@Override
	public void accept(Visitor visitor) {
		visitor.visit(this);
	}

}
