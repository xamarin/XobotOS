package sharpen.xobotos.api.interop.glue;

public class BinaryOperator extends Expression {

	private final String _operator;
	private final Expression _left;
	private final Expression _right;

	public BinaryOperator(String op, Expression left, Expression right) {
		this._operator = op;
		this._left = left;
		this._right = right;
	}

	@Override
	protected boolean needParens() {
		return true;
	}

	public String getOperator() {
		return _operator;
	}

	public Expression getLeftExpression() {
		return _left;
	}

	public Expression getRightExpression() {
		return _right;
	}

	@Override
	public void accept(Visitor visitor) {
		visitor.visit(this);
	}

}
