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

public class CSCaseClause extends CSNode {

	private boolean _isDefault;
	private CSBlock _body = new CSBlock();
	private List<CSExpression> _expressions = new ArrayList<CSExpression>();

	public void accept(CSVisitor visitor) {
		visitor.visit(this);
	}

	public CSBlock body() {
		return _body;
	}
	
	public void isDefault(boolean isDefault) {
		_isDefault = isDefault;
	}
	
	public boolean isDefault() {
		return _isDefault;
	}

	public void addExpression(CSExpression expression) {
		if (null == expression) {
			throw new IllegalArgumentException("expression");
		}
		_expressions.add(expression);
	}
	
	public List<CSExpression> expressions() {
		return Collections.unmodifiableList(_expressions);
	}

}
