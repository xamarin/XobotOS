package sharpen.xobotos.api.interop.glue;

public class CastExpression extends Expression {
	private final AbstractTypeReference _type;
	private final Expression _expr;

	public CastExpression(AbstractTypeReference type, Expression expr) {
		this._type = type;
		this._expr = expr;
	}

	@Override
	protected boolean needParens() {
		return true;
	}

	public AbstractTypeReference getType() {
		return _type;
	}

	public Expression getExpression() {
		return _expr;
	}

	@Override
	public void accept(Visitor visitor) {
		visitor.visit(this);
	}

}
