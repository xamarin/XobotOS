package sharpen.xobotos.api.interop.glue;

public abstract class LiteralExpression extends Expression {

	@Override
	protected boolean needParens() {
		return false;
	}

	public abstract String getValue();

	@Override
	public void accept(Visitor visitor) {
		visitor.visit(this);
	}

}
