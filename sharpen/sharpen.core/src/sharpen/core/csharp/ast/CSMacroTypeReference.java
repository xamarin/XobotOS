/* Copyright (C) 2009  Versant Inc.  http://www.db4o.com */

package sharpen.core.csharp.ast;


public class CSMacroTypeReference extends CSTypeReferenceExpression {

	private final CSMacro _macro;

	public CSMacroTypeReference(CSMacro macro) {
		_macro = macro;
    }

	@Override
    public void accept(CSVisitor visitor) {
		visitor.visit(this);
    }

	public CSNode macro() {
		return _macro;
    }

	@Override
	public String getTypeName() {
		return _macro.template();
	}
}
