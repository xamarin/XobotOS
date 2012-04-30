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

public class CSMethod extends CSMethodBase implements CSTypeParameterProvider {

	private CSMethodModifier _modifier = CSMethodModifier.None;

	private CSTypeReferenceExpression _returnType;

	private List<CSTypeParameter> _typeParameters = new ArrayList<CSTypeParameter>();

	private CSDllImport _dllImport;

	public CSMethod(String name) {
		super(name);
	}

	@Override
	public void accept(CSVisitor visitor) {
		visitor.visit(this);
	}

	public void modifier(CSMethodModifier modifier) {
		_modifier = modifier;
	}

	public CSMethodModifier modifier() {
		return _modifier;
	}

	public void returnType(CSTypeReferenceExpression returnType) {
		_returnType = returnType;
	}

	public CSTypeReferenceExpression returnType() {
		return _returnType;
	}

	public boolean isAbstract() {
		return CSMethodModifier.Abstract == _modifier
				|| CSMethodModifier.AbstractOverride == _modifier;
	}

	public boolean isVirtual() {
		return _modifier == CSMethodModifier.Virtual;
	}

	public void addTypeParameter(CSTypeParameter typeParameter) {
		_typeParameters.add(typeParameter);
	}

	public List<CSTypeParameter> typeParameters() {
		return Collections.unmodifiableList(_typeParameters);
	}

	public CSDllImport dllImport() {
		return _dllImport;
	}

	public void dllImport(CSDllImport dllImport) {
		_dllImport = dllImport;
	}

	@Override
	public int hashCode() {
		return _name.hashCode();
	}

	@Override
	public boolean equals(Object o) {
		if( o instanceof CSMethod ) {
			CSMethod other = (CSMethod) o;
			boolean retval = other._name.equals(this._name);
			retval = retval && other._visibility == this._visibility;
			retval = retval && other._returnType.equals(this._returnType);
			retval = retval && other._modifier == this._modifier;
			List<CSVariableDeclaration> params = other.parameters();
			List<CSVariableDeclaration> myParams = this.parameters();
			retval = retval && params.size() == myParams.size();

			//parameter names don't matter, just type and position
			for(int i=0; retval && i<params.size(); i++) {
				retval = retval && params.get(i).type().equals(myParams.get(i).type());
			}

			return retval;
		} else {
			return false;
		}
	}

}
