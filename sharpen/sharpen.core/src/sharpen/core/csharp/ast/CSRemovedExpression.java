package sharpen.core.csharp.ast;

public class CSRemovedExpression extends CSExpression {

	private String _originalExpression;

	public CSRemovedExpression(String originalExpression) {
		_originalExpression = originalExpression;
    }
	
	@Override
	public String toString() {
	    return _originalExpression;
	}

	@Override
	public void accept(CSVisitor visitor) {
		visitor.visit(this);
	}

}
