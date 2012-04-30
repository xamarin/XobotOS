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

import java.util.*;

public class CSProperty extends CSMetaMember implements CSParameterized {

	public static final String INDEXER = "this";
	
	private List<CSVariableDeclaration> _parameters;
	
	private CSBlock _getter;
	
	private CSBlock _setter;

	public CSProperty(String name, CSTypeReferenceExpression type) {
		super(name, type);
	}

	@Override
	public void accept(CSVisitor visitor) {
		visitor.visit(this);
	}
	
	public void addParameter(CSVariableDeclaration parameter) {
		if (null == _parameters) {
			_parameters = new ArrayList<CSVariableDeclaration>();
		}
		_parameters.add(parameter);
	}
	
	public List<CSVariableDeclaration> parameters() {
		if (null == _parameters) {
			return Collections.emptyList();
		}
		return Collections.unmodifiableList(_parameters);
	}

	public void getter(CSBlock getter) {
		_getter = getter;
	}
	
	public CSBlock getter() {
		return _getter;
	}
	
	public void setter(CSBlock block) {
		_setter = block;
	}
	
	public CSBlock setter() {
		return _setter;
	}

	public boolean isIndexer() {
		return INDEXER.equals(name());
	}
}
