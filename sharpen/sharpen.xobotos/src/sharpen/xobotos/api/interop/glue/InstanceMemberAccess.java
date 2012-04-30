package sharpen.xobotos.api.interop.glue;

public class InstanceMemberAccess extends Expression {

	private final Expression _parent;
	private final String _member;

	public InstanceMemberAccess(Expression parent, String member) {
		this._parent = parent;
		this._member = member;
	}

	@Override
	protected boolean needParens() {
		return false;
	}

	public Expression getParent() {
		return _parent;
	}

	public String getMember() {
		return _member;
	}

	@Override
	public void accept(Visitor visitor) {
		visitor.visit(this);
	}

}
