package sharpen.xobotos.api.interop.glue;

public class ArrayDestructorInvocation extends Statement {

	private final Expression _expr;

	public ArrayDestructorInvocation(Expression expr) {
		this._expr = expr;
	}

	public Expression getExpression() {
		return _expr;
	}

	@Override
	public void accept(Visitor visitor) {
		visitor.visit(this);
	}

}
