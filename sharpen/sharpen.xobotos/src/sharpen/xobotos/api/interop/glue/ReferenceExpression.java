package sharpen.xobotos.api.interop.glue;

public class ReferenceExpression extends Expression {

	private final String _name;

	public ReferenceExpression(String name) {
		this._name = name;
	}

	@Override
	protected boolean needParens() {
		return false;
	}

	public String getName() {
		return _name;
	}

	@Override
	public void accept(Visitor visitor) {
		visitor.visit(this);
	}

}
