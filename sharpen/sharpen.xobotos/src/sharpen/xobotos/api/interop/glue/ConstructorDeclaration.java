package sharpen.xobotos.api.interop.glue;

public class ConstructorDeclaration extends AbstractDeclaration<Constructor> {

	public ConstructorDeclaration(Constructor definition) {
		super(definition);
	}

	@Override
	public void accept(Visitor visitor) {
		visitor.visit(this);
	}

}
