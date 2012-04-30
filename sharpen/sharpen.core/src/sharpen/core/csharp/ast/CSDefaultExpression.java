package sharpen.core.csharp.ast;

public class CSDefaultExpression extends CSExpression {

	private final String _name;

	public CSDefaultExpression(String name) {
		this._name = name;
	}

	public String name() {
		return _name;
	}

	@Override
	public void accept(CSVisitor visitor) {
		visitor.visit(this);
	}

}
