package sharpen.xobotos.api.interop.glue;


public class Method extends AbstractMethod {

	private final String _name;
	private final AbstractTypeReference _returnType;
	private final Flags _flags;

	public Method(String name, AbstractTypeReference returnType, Visibility visibility) {
		this(name, returnType, visibility, null);
	}

	public Method(String name, AbstractTypeReference returnType, Visibility visibility, Flags flags) {
		super(visibility);
		this._name = name;
		this._returnType = returnType;
		this._flags = flags;

		if (returnType == null)
			throw new NullPointerException();
	}

	public String getName() {
		return _name;
	}

	public AbstractTypeReference getReturnType() {
		return _returnType;
	}

	public Flags getFlags() {
		return _flags;
	}

	public enum Flags {
		EXPORT,
		STATIC
	}

	@Override
	public void accept(Visitor visitor) {
		visitor.visit(this);
	}

	@Override
	protected MethodDeclaration createDeclaration() {
		return new MethodDeclaration(this);
	}

}
