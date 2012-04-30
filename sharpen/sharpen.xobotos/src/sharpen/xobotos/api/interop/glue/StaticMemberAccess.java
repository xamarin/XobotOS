package sharpen.xobotos.api.interop.glue;

public class StaticMemberAccess extends Expression {

	private final AbstractTypeReference _type;
	private final String _member;

	public StaticMemberAccess(AbstractTypeReference type, String member) {
		this._type = type;
		this._member = member;

		if ((type == null) || (member == null))
			throw new NullPointerException();
	}

	@Override
	protected boolean needParens() {
		return false;
	}

	public AbstractTypeReference getType() {
		return _type;
	}

	public String getMember() {
		return _member;
	}

	@Override
	public void accept(Visitor visitor) {
		visitor.visit(this);
	}

}
