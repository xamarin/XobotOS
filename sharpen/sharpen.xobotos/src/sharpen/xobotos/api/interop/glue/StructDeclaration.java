package sharpen.xobotos.api.interop.glue;

public class StructDeclaration extends AbstractDeclaration<StructDefinition> {

	protected StructDeclaration(StructDefinition definition) {
		super(definition);
	}

	@Override
	public void accept(Visitor visitor) {
		visitor.visit(this);
	}

}
