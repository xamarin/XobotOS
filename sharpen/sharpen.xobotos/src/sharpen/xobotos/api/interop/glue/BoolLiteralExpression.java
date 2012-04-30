package sharpen.xobotos.api.interop.glue;

public class BoolLiteralExpression extends LiteralExpression {

	private final boolean _value;

	public BoolLiteralExpression(boolean value) {
		this._value = value;
	}

	@Override
	public String getValue() {
		return _value ? "true" : "false";
	}

}
