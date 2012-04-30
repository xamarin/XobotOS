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

public abstract class CSMethodBase extends CSMember implements CSParameterized {

	private List<CSVariableDeclaration> _parameters = new ArrayList<CSVariableDeclaration>();

	private CSBlock _body = new CSBlock();

	private boolean _isVarArgs;

	private boolean _isStub;

	public CSMethodBase(String name) {
		super(name);
	}

	public void addParameter(CSVariableDeclaration parameter) {
		_parameters.add(parameter);
	}

	public void addParameter(int index, CSVariableDeclaration parameter) {
		_parameters.add(index, parameter);
	}

	public CSVariableDeclaration addParameter(String name, CSTypeReferenceExpression type) {
		CSVariableDeclaration param = new CSVariableDeclaration(name, type);
		addParameter(param);
		return param;
	}

	public CSVariableDeclaration addParameter(String name, CSTypeReferenceExpression type, CSAttribute... attrs) {
		CSParameterDeclaration param = new CSParameterDeclaration(name, type);
		if (attrs != null) {
			for (CSAttribute attr : attrs)
				param.addAttribute(attr);
		}
		_parameters.add(param);
		return param;
	}

	public void removeParameter(int index) {
		_parameters.remove(index);
	}

	public List<CSVariableDeclaration> parameters() {
		return Collections.unmodifiableList(_parameters);
	}

	public CSBlock body() {
		return _body;
	}

	@Override
	public String signature() {
		StringBuilder buffer = new StringBuilder();
		buffer.append(name());
		buffer.append("(");

		boolean first = true;
		for (CSVariableDeclaration p : _parameters) {
			if (!first) buffer.append(", ");
			buffer.append(p.type());
			first = false;
		}
		buffer.append(")");
		return buffer.toString();
	}

	public void isVarArgs(boolean value) {
		_isVarArgs = value;
	}

	public boolean isVarArgs() {
		return _isVarArgs;
	}

	public void setStub() {
		_isStub = true;
		_body.setImmutable();
	}

	public boolean isStub() {
		return _isStub;
	}
}
