package sharpen.xobotos.api.interop.glue;

public abstract class AbstractTypeReference extends Expression {

	public abstract String getTypeName();

	@Override
	protected boolean needParens() {
		return false;
	}

	@Override
	public void accept(Visitor visitor) {
		visitor.visit(this);
	}

}
