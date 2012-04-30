package sharpen.xobotos.api.interop.glue;

public class IfStatement extends Statement {

	private final Expression _cond;
	private final Block _thenBlock;
	private final Block _elseBlock;

	public IfStatement(Expression cond) {
		this._cond = cond;
		this._thenBlock = new Block();
		this._elseBlock = new Block();
	}

	public Expression getCondition() {
		return _cond;
	}

	public Block getThenBlock() {
		return _thenBlock;
	}

	public Block getElseBlock() {
		return _elseBlock;
	}

	@Override
	public void accept(Visitor visitor) {
		visitor.visit(this);
	}

}
