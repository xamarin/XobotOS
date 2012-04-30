package sharpen.xobotos.api.interop.glue;

public class AssignmentStatement extends Statement {
	private final Expression _target;
	private final Expression _source;

	public AssignmentStatement(Expression target, Expression source) {
		this._target = target;
		this._source = source;
	}

	public Expression getTarget() {
		return _target;
	}

	public Expression getSource() {
		return _source;
	}

	@Override
	public void accept(Visitor visitor) {
		visitor.visit(this);
	}
}
