/* Copyright (C) 2004 - 2008  Versant Inc.  http://www.db4o.com

This file is part of the sharpen open source java to c# translator.

sharpen is free software; you can redistribute it and/or modify it under
the terms of version 2 of the GNU General Public License as published
by the Free Software Foundation and as clarified by db4objects' GPL
interpretation policy, available at
http://www.db4o.com/about/company/legalpolicies/gplinterpretation/
Alternatively you can write to db4objects, Inc., 1900 S Norfolk Street,
Suite 350, San Mateo, CA 94403, USA.

sharpen is distributed in the hope that it will be useful, but WITHOUT ANY
WARRANTY; without even the implied warranty of MERCHANTABILITY or
FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License
for more details.

You should have received a copy of the GNU General Public License along
with this program; if not, write to the Free Software Foundation, Inc.,
59 Temple Place - Suite 330, Boston, MA  02111-1307, USA. */

package sharpen.core.csharp.ast;

import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

public class CSBlock extends CSStatement {

	private List<CSStatement> _statements = new ArrayList<CSStatement>();

	public boolean isEmpty() {
		return _statements.isEmpty();
	}

	public void addStatement(CSStatement statement) {
		_statements.add(statement);
	}

	public void addStatement(CSExpression expression) {
		_statements.add(newStatement(expression));
	}

	private CSExpressionStatement newStatement(CSExpression expression) {
		return new CSExpressionStatement(CSExpressionStatement.UNKNOWN_START_POSITION, expression);
	}

	public void addStatement(int index, CSExpression expression) {
		_statements.add(index, newStatement(expression));
	}

	public void removeStatement (CSStatement cs) {
		_statements.remove(cs);
	}

	public void clearBlock() {
		_statements.clear();
	}

	public List<CSStatement> statements() {
		return Collections.unmodifiableList(_statements);
	}

	@Override
	public void accept(CSVisitor visitor) {
		visitor.visit(this);
	}

	public void addAll(CSBlock body) {
		_statements.addAll(body._statements);
	}

	public void addStatement(int index, CSStatement stmt) {
		_statements.add(index, stmt);
	}

	public void setImmutable() {
		_statements = Collections.unmodifiableList(_statements);
	}
}
