package sharpen.xobotos.api.interop.glue;

public class LocalVariable extends Statement implements IVariable {
	private final AbstractTypeReference _type;
	private final String _name;

	private Expression _initializer;

	public LocalVariable(AbstractTypeReference type, String name) {
		this._type = type;
		this._name = name;
	}

	public LocalVariable(AbstractTypeReference type, String name, Expression init) {
		this(type, name);
		this._initializer = init;
	}

	@Override
	public AbstractTypeReference getType() {
		return _type;
	}

	@Override
	public String getName() {
		return _name;
	}

	public Expression getInitializer() {
		return _initializer;
	}

	public void setInitializer(Expression init) {
		this._initializer = init;
	}

	@Override
	public void accept(Visitor visitor) {
		visitor.visit(this);
	}
}
