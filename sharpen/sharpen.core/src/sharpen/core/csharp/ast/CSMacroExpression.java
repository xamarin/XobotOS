/* Copyright (C) 2009  Versant Inc.  http://www.db4o.com */

package sharpen.core.csharp.ast;


public class CSMacroExpression extends CSExpression {

	private final CSMacro _macro;

	public CSMacroExpression(CSMacro macro) {
		_macro = macro;
    }

	@Override
    public void accept(CSVisitor visitor) {
		visitor.visit(this);
    }

	public CSNode macro() {
		return _macro;
    }
}
