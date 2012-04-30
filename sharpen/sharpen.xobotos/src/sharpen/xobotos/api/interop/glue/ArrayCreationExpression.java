package sharpen.xobotos.api.interop.glue;

public class ArrayCreationExpression extends Expression {
	private final AbstractTypeReference _type;
	private final Expression _size;

	public ArrayCreationExpression(AbstractTypeReference type, Expression size) {
		this._type = type;
		this._size = size;
	}

	public AbstractTypeReference getType() {
		return _type;
	}

	public Expression getSize() {
		return _size;
	}

	@Override
	protected boolean needParens() {
		return true;
	}

	@Override
	public void accept(Visitor visitor) {
		visitor.visit(this);
	}

}
