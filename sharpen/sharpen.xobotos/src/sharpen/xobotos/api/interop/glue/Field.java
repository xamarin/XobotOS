package sharpen.xobotos.api.interop.glue;

public class Field extends AbstractDefinition implements IVariable {
	private final AbstractTypeReference _type;
	private final String _name;

	public Field(AbstractTypeReference type, String name, Visibility visibility) {
		super(visibility);
		this._type = type;
		this._name = name;
	}

	@Override
	public AbstractTypeReference getType() {
		return _type;
	}

	@Override
	public String getName() {
		return _name;
	}

	@Override
	public void accept(Visitor visitor) {
		visitor.visit(this);
	}

	@Override
	protected FieldDeclaration createDeclaration() {
		return new FieldDeclaration(this);
	}
}
