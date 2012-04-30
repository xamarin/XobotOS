package sharpen.xobotos.api.interop.glue;

public class TypeReference extends AbstractTypeReference {
	private final String _name;

	public TypeReference(String name) {
		this._name = name;

		if (name == null)
			throw new IllegalStateException();
	}

	@Override
	public String getTypeName() {
		return _name;
	}

	@Override
	public void accept(Visitor visitor) {
		visitor.visit(this);
	}

}
