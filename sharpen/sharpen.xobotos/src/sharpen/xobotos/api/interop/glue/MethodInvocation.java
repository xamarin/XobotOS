package sharpen.xobotos.api.interop.glue;

import java.util.Arrays;
import java.util.List;

public class MethodInvocation extends AbstractInvocation {

	private final Expression _expr;

	public MethodInvocation(Expression expr) {
		this._expr = expr;
	}

	public MethodInvocation(Expression expr, List<Expression> args) {
		super(args);
		this._expr = expr;
	}

	public MethodInvocation(Expression expr, Expression... args) {
		this(expr, Arrays.asList(args));
	}

	public Expression getExpression() {
		return _expr;
	}

	@Override
	public void accept(Visitor visitor) {
		visitor.visit(this);
	}

}
