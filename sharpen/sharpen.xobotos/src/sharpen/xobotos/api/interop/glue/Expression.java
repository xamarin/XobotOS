package sharpen.xobotos.api.interop.glue;

public abstract class Expression extends Node {

	protected abstract boolean needParens();

	protected final Expression getParenthesizedExpr() {
		if (!needParens())
			return this;
		return new ParenthesizedExpression(this);
	}

}
