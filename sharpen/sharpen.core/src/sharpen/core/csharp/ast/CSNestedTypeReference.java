package sharpen.core.csharp.ast;

public class CSNestedTypeReference extends CSTypeReferenceExpression {

	final CSTypeReferenceExpression _parent;
	final CSTypeReferenceExpression _child;

	public CSNestedTypeReference (CSTypeReferenceExpression parent, CSTypeReferenceExpression child) {
		this._parent = parent;
		this._child = child;
	}

	@Override
	public void accept(CSVisitor visitor) {
		visitor.visit(this);
	}

	public CSTypeReferenceExpression getParent() {
		return _parent;
	}

	public CSTypeReferenceExpression getChild() {
		return _child;
	}

	@Override
	public String getTypeName() {
		return _parent.getTypeName() + '.' + _child.getTypeName();
	}
}
