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

public abstract class CSNode {
	
	public static final int UNKNOWN_START_POSITION = Integer.MIN_VALUE;

	private int _startPosition;

	private Set<String> _enclosingIfDefs = new HashSet<String>();
	
	private CSNode _parent;
	
	public CSNode() {
		this(UNKNOWN_START_POSITION);
	}
	
	public CSNode(int startPosition) {
		_startPosition = startPosition;
	}
	
	public int startPosition() {
		return _startPosition;
	}
	
	public void startPosition(int value) {
		_startPosition = value;
	}

	public abstract void accept(CSVisitor visitor);

	public void addEnclosingIfDef(String expression) {
		_enclosingIfDefs.add(expression);
	}

	public Set<String> enclosingIfDefs() {
		return Collections.unmodifiableSet(_enclosingIfDefs);
	}
	
	public CSNode parent () {
		return _parent;
	}
	
	public void parent (CSNode node) {
		_parent = node;
	}
}
