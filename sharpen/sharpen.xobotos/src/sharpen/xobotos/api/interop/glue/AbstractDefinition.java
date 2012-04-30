package sharpen.xobotos.api.interop.glue;

public abstract class AbstractDefinition extends AbstractMember {

	protected AbstractDefinition(Visibility visibility) {
		super(visibility);
	}

	private AbstractDeclaration<?> _declaration;

	public final boolean hasDeclaration() {
		return _declaration != null;
	}

	public final AbstractDeclaration<?> getDeclaration() {
		if (_declaration == null)
			_declaration = createDeclaration();
		return _declaration;
	}

	protected abstract AbstractDeclaration<?> createDeclaration();

}
