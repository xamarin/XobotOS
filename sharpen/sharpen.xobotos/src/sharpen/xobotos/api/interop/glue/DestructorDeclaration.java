package sharpen.xobotos.api.interop.glue;

public class DestructorDeclaration extends AbstractDeclaration<Destructor> {

	public DestructorDeclaration(Destructor definition) {
		super(definition);
	}

	@Override
	public void accept(Visitor visitor) {
		visitor.visit(this);
	}

}
