package sharpen.xobotos.api.interop.glue;

public class Constructor extends AbstractMethod {

	private final AbstractTypeReference _type;

	public Constructor(AbstractTypeReference type, Visibility visibility) {
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
	protected ConstructorDeclaration createDeclaration() {
		return new ConstructorDeclaration(this);
	}

}
