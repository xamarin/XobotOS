package sharpen.core.csharp.ast;

public class CSExpressionVisitor extends CSVisitor {

	@Override
	public void visit(CSConstructorInvocationExpression node) {
		visit((CSMethodInvocationExpression)node);
	}

	@Override
	public void visit(CSMethodInvocationExpression node) {
		visitNode(node.expression());
		visitList(node.arguments());
	}

	@Override
	public void visit(CSConditionalExpression node) {
		visitNode(node.expression());
		visitNode(node.trueExpression());
		visitNode(node.falseExpression());
	}

	@Override
	public void visit(CSArrayCreationExpression node) {
		visitNode(node.elementType());
		visitNode(node.initializer());
		visitNode(node.length());
	}

	private void visitNode(CSNode expression) {
		if (null == expression) return;
		expression.accept(this);
    }

}
