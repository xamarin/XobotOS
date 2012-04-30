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

public class CSField extends CSTypedMember {

	private CSExpression _initializer;
	private Set<CSFieldModifier> _modifiers = new LinkedHashSet<CSFieldModifier>();

	public CSField(String name, CSTypeReferenceExpression type, CSVisibility visibility) {
		this(name, type, visibility, null);
	}

	public CSField(String name, CSTypeReferenceExpression type, CSVisibility visibility, CSExpression initializer) {
		super(name, type);
		_visibility = visibility;
		_initializer = initializer;
	}

	public void accept(CSVisitor visitor) {
		visitor.visit(this);
	}

	public CSExpression initializer() {
		return _initializer;
	}

	public void initializer(CSExpression initializer) {
		_initializer = initializer;
	}

	public void addModifier(CSFieldModifier modifier) {
		_modifiers.add(modifier);
	}

	public void removeModifier(CSFieldModifier modifier) {
		_modifiers.remove(modifier);
	}

	public Set<CSFieldModifier> modifiers() {
		return Collections.unmodifiableSet(_modifiers);
	}

	public boolean isConst() {
		return _modifiers.contains(CSFieldModifier.Const);
	}

	public boolean isStatic() {
		return _modifiers.contains(CSFieldModifier.Static);
	}
}
