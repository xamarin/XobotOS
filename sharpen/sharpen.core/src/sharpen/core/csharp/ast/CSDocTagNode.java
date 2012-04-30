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

public class CSDocTagNode extends CSDocNode {
	
	private List<CSDocNode> _fragments;
	private List<CSDocAttributeNode> _attributes;
	private String _tagName;

	public CSDocTagNode(String tagName) {
		_tagName = tagName;
	}

	public void accept(CSVisitor visitor) {
		visitor.visit(this);
	}

	public void addFragment(CSDocNode node) {
		if (null == _fragments) {
			 _fragments = new ArrayList<CSDocNode>();
		}
		_fragments.add(node);
	}

	public List<CSDocNode> fragments() {
		return safeList(_fragments);
	}

	public void addAttribute(String name, String value) {
		if (null == _attributes) {
			_attributes = new ArrayList<CSDocAttributeNode>();
		}
		_attributes.add(new CSDocAttributeNode(name, value));
	}
	
	public List<CSDocAttributeNode> attributes() {
		return safeList(_attributes);
	}
	
	private <T extends CSDocNode> List<T> safeList(List<T> list) {
		if (null == list) {
			return Collections.emptyList();
		}
		return Collections.unmodifiableList(list);
	}

	public String tagName() {
		return _tagName;
	}

	public void addTextFragment(String text) {
		addFragment(new CSDocTextNode(text));
	}

	public String getAttribute(String attributeName) {		 
		for (CSDocAttributeNode attribute : attributes()) {
			if (attribute.name().equals(attributeName)) {
				return attribute.value();
			}
		}
		return null;
	}
}
