package sharpen.xobotos.api.interop.glue;


public class ClassDeclaration extends AbstractDeclaration<ClassDefinition> {

	protected ClassDeclaration(ClassDefinition definition) {
		super(definition);
	}

	@Override
	public void accept(Visitor visitor) {
		visitor.visit(this);
	}

}
