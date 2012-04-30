/* Copyright (C) 2004 - 2010  Versant Inc.  http://www.db4o.com */

package sharpen.core.csharp.ast;

/*
 * FIXME: only implemented for break label so far.
 */
public class CSGotoStatement extends CSStatement {

	private String _label;
	private CSExpression _target;
	
	public CSGotoStatement(int startPosition, String label) {
		super(startPosition);
		_label = label;
	}

	public CSGotoStatement(int startPosition, CSExpression target) {
		super(startPosition);
		_target = target;
	}

	public void accept(CSVisitor visitor) {
		visitor.visit(this);
	}

	public String label() {
		return _label;
	}

	public CSExpression target() {
		return _target;
	}

}
