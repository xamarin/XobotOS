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

public abstract class CSTypeDeclaration extends CSType implements CSTypeContainer, CSTypeParameterProvider {

	protected List<CSMember> _members = new ArrayList<CSMember>();

	protected List<CSTypeReferenceExpression> _baseTypes = new ArrayList<CSTypeReferenceExpression>();

	protected List<CSTypeParameter> _typeParameters = new ArrayList<CSTypeParameter>();

	private boolean _partial;

	private boolean _anonymous;

	private CSConstructor _staticCtor;

	CSTypeDeclaration(String name) {
		super(name);
	}

	public boolean isSealed() {
		return false;
	}

	public boolean isInterface() {
		return false;
	}

	public void addType(CSType type) {
		_members.add(type);
	}

	public void addMember(CSMember member) {
		_members.add(member);
	}

	public void removeMember(CSMember member) {
		_members.remove(member);
	}

	public void clearMembers() {
		_members.clear();
	}

	public List<CSMember> members() {
		return Collections.unmodifiableList(_members);
	}

	public List<CSConstructor> constructors() {
		ArrayList<CSConstructor> ctors = new ArrayList<CSConstructor>();
		for (CSMember member : _members) {
			if (member instanceof CSConstructor) {
				ctors.add((CSConstructor) member);
			}
		}
		return Collections.unmodifiableList(ctors);
	}

	public void addBaseType(CSTypeReferenceExpression typeRef) {
		_baseTypes.add(typeRef);
	}

	public void clearBaseTypes() {
		_baseTypes.clear();
	}

	public List<CSTypeReferenceExpression> baseTypes() {
		return Collections.unmodifiableList(_baseTypes);
	}

	public void addTypeParameter(CSTypeParameter typeParameter) {
		_typeParameters.add(typeParameter);
	}

	public List<CSTypeParameter> typeParameters() {
		return Collections.unmodifiableList(_typeParameters);
	}

	public void partial(boolean partial) {
		_partial = partial;
	}

	public boolean partial() {
		return _partial;
	}

	public void anonymous(boolean anonymous) {
		_anonymous = anonymous;
	}

	public boolean anonymous() {
		return _anonymous;
	}

	public CSMember getMember(String name) {
		for (CSMember member : _members) {
			if (member.name().equals(name)) {
				return member;
			}
		}
		return null;
	}

	public boolean hasStaticConstructor() {
		return _staticCtor != null;
	}

	public CSConstructor ensureStaticConstructor() {
		if (_staticCtor != null)
			return _staticCtor;

		_staticCtor = new CSConstructor(CSConstructorModifier.Static);
		addMember(_staticCtor);
		return _staticCtor;
	}

	public void cleanupStaticConstructor() {
		if (_staticCtor == null)
			return;

		int countBlocks = 0;
		for (final CSStatement stm : _staticCtor.body().statements()) {
			if (stm instanceof CSBlock)
				++countBlocks;
		}

		if (countBlocks != 1)
			return;

		List<CSStatement> list = new ArrayList<CSStatement> ();
		list.addAll(_staticCtor.body().statements());
		_staticCtor.body().clearBlock();

		for (final CSStatement stm : list) {
			if (stm instanceof CSBlock)
				_staticCtor.body().addAll((CSBlock)stm);
			else
				_staticCtor.body().addStatement(stm);
		}
	}
}
