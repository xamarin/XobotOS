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

/*
 * Created on Jan 21, 2005
 *
 */
package sharpen.core.csharp.ast;

import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

public abstract class CSMember extends CSNode {

	protected String _name;

	protected CSVisibility _visibility = CSVisibility.Internal;

	protected List<CSDocNode> _docs;
	protected boolean _removeDocs;

	private List<CSAttribute> _attributes = new ArrayList<CSAttribute>();

	private boolean _newModifier;


	protected CSMember(String name) {
		_name = name;
	}

	public String name() {
		return _name;
	}

	public void visibility(CSVisibility visibility) {
		_visibility = visibility;
	}

	public CSVisibility visibility() {
		return _visibility;
	}

	public void addDoc(CSDocNode node) {
		if (_removeDocs)
			return;
		if (null == _docs) {
			_docs = new ArrayList<CSDocNode>();
		}
		_docs.add(node);
	}

	public List<CSDocNode> docs() {
		if (null == _docs) {
			return Collections.emptyList();
		}
		return Collections.unmodifiableList(_docs);
	}

	public void removeDocs() {
		_docs = null;
		_removeDocs = true;
	}

	public boolean noDocs() {
		return _removeDocs;
	}

	public void addAttribute(CSAttribute attribute) {
		_attributes.add(attribute);
	}

	public boolean removeAttribute (String name) {
		for (CSAttribute at : _attributes) {
			if (at.name().equals(name)) {
				_attributes.remove(at);
				return true;
			}
		}
		return false;
	}

	public List<CSAttribute> attributes() {
		return Collections.unmodifiableList(_attributes);
	}

	public String signature() {
		return _name;
	}

	public boolean isNewModifier() {
		return _newModifier;
	}

	public void setNewModifier(boolean newModifier) {
		_newModifier = newModifier;
	}

}
