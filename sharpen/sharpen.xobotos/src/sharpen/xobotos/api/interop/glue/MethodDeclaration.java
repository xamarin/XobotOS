package sharpen.xobotos.api.interop.glue;

public class MethodDeclaration extends AbstractDeclaration<Method> {

	public MethodDeclaration(Method definition) {
		super(definition);
	}

	@Override
	public void accept(Visitor visitor) {
		visitor.visit(this);
	}

}
