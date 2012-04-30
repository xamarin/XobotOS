package sharpen.xobotos.api.interop.glue;


public abstract class AbstractTypeDefinition extends AbstractDefinition {

	private final String _name;

	protected AbstractTypeDefinition(String name, Visibility visibility) {
		super(visibility);
		this._name = name;
	}

	public String getName() {
		return _name;
	}

}
