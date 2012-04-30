package sharpen.xobotos.api.interop.glue;

public class FieldDeclaration extends AbstractDeclaration<Field> {

	protected FieldDeclaration(Field definition) {
		super(definition);
	}

	@Override
	public void accept(Visitor visitor) {
		visitor.visit(this);
	}

}
