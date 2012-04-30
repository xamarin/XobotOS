package sharpen.xobotos.api.interop.glue;

public class DereferenceExpression extends UnaryOperator {

	public DereferenceExpression(Expression expr) {
		super("*", expr);
	}

}
