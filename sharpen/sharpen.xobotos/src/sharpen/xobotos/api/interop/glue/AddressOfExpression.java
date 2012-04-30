package sharpen.xobotos.api.interop.glue;

public class AddressOfExpression extends UnaryOperator {

	public AddressOfExpression(Expression expr) {
		super("&", expr);
	}

}
