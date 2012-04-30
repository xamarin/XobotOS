package sharpen.xobotos.api.interop.glue;

public class Parameter extends Node implements IVariable {

	private final String _name;
	private final AbstractTypeReference _type;

	public Parameter(AbstractTypeReference type, String name) {
		this._name = name;
		this._type = type;
	}

	@Override
	public String getName() {
		return _name;
	}

	@Override
	public AbstractTypeReference getType() {
		return _type;
	}

	@Override
	public void accept(Visitor visitor) {
		visitor.visit(this);
	}

}
