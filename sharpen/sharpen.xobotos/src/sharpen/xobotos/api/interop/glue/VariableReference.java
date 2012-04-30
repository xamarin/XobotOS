package sharpen.xobotos.api.interop.glue;

public class VariableReference extends Expression {
	private final IVariable _var;

	public VariableReference(IVariable var) {
		this._var = var;
	}

	@Override
	protected boolean needParens() {
		return false;
	}

	public IVariable getVariable() {
		return _var;
	}

	@Override
	public void accept(Visitor visitor) {
		visitor.visit(this);
	}

}
