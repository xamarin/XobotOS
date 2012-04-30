package sharpen.xobotos.api.interop.glue;

public class Destructor extends AbstractMethod {

	private final AbstractTypeReference _type;

	public Destructor(AbstractTypeReference type, Visibility visibility) {
		super(visibility);
		this._type = type;
	}

	public AbstractTypeReference getType() {
		return _type;
	}

	@Override
	public void accept(Visitor visitor) {
		visitor.visit(this);
	}

	@Override
	protected DestructorDeclaration createDeclaration() {
		return new DestructorDeclaration(this);
	}

}
