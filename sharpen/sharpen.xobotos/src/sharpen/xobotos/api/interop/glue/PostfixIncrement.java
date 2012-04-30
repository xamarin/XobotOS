package sharpen.xobotos.api.interop.glue;

public class PostfixIncrement extends StatementExpression {

	private final IVariable _var;

	public PostfixIncrement(IVariable var) {
		this._var = var;
	}

	@Override
	protected boolean needParens() {
		return true;
	}

	public IVariable getVariable() {
		return _var;
	}

	@Override
	public void accept(Visitor visitor) {
		visitor.visit(this);
	}

}
