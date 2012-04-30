/* Copyright (C) 2004 - 2010  Versant Inc.  http://www.db4o.com */

package sharpen.core.csharp.ast;

public class CSLabelStatement extends CSStatement {

	private final String _label;

	public CSLabelStatement(String label) {
		_label = label;
	}

	@Override
	public void accept(CSVisitor visitor) {
		visitor.visit(this);

	}

	public String label() {
		return _label;
	}

}
