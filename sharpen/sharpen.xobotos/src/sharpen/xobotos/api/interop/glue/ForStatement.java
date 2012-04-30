package sharpen.xobotos.api.interop.glue;

public class ForStatement extends Statement {
	private final LocalVariable _var;
	private final Expression _init;
	private final Expression _check;
	private final Expression _update;
	private final Block _body;

	public ForStatement(LocalVariable var, Expression init, Expression check, Expression update) {
		this._var = var;
		this._init = init;
		this._check = check;
		this._update = update;
		this._body = new Block();
	}

	public LocalVariable getVariable() {
		return _var;
	}

	public Expression getInitializer() {
		return _init;
	}

	public Expression getCheck() {
		return _check;
	}

	public Expression getUpdate() {
		return _update;
	}

	public Block getBody() {
		return _body;
	}

	@Override
	public void accept(Visitor visitor) {
		visitor.visit(this);
	}

}
