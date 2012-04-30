package sharpen.xobotos.api.interop.glue;

public class NumberLiteralExpression extends LiteralExpression {

	private final String _number;

	public NumberLiteralExpression(String number) {
		this._number = number;
	}

	public NumberLiteralExpression(Number number) {
		this._number = number.toString();
	}

	@Override
	public String getValue() {
		return _number;
	}

}
