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

/* Copyright (C) 2004 - 2006 Versant Inc. http://www.db4o.com */

package sharpen.core.csharp.ast;

import java.util.List;

public class CSTypeReference extends CSTypeReferenceExpression implements CSTypeArgumentProvider {

	private final String _typeName;
	private final CSTypeArgumentSupport _typeArguments = new CSTypeArgumentSupport();

	public CSTypeReference(String typeName) {
		_typeName = typeName;
	}

	@Override
	public void accept(CSVisitor visitor) {
		visitor.visit(this);
	}

	public String typeName() {
		return _typeName;
	}

	@Override
	public String getTypeName() {
		if (_typeArguments.size() == 0)
			return _typeName;
		StringBuilder sb = new StringBuilder();
		sb.append(_typeName);
		sb.append('<');
		for (int i = 0; i < _typeArguments.size(); i++) {
			if (i > 0)
				sb.append(", ");
			CSTypeReferenceExpression arg = _typeArguments.typeArguments().get(i);
			sb.append(arg.getTypeName());
		}
		sb.append('>');
		return sb.toString();
	}

	public List<CSTypeReferenceExpression> typeArguments() {
		return _typeArguments.typeArguments();
	}

	public void addTypeArgument(CSTypeReferenceExpression typeArgument) {

		_typeArguments.addTypeArgument(typeArgument);
	}

	@Override
	public int hashCode() {
		return _typeName.hashCode();
	}

	@Override
	public boolean equals(Object o) {
		if( o instanceof CSTypeReference ) {
			CSTypeReference other = (CSTypeReference) o;
			boolean retval = other._typeName.equals(this._typeName);

			List<CSTypeReferenceExpression> typeArgs = other.typeArguments();
			List<CSTypeReferenceExpression> myTypeArgs = this.typeArguments();
			retval = retval && typeArgs.equals(myTypeArgs);

			return retval;
		} else {
			return false;
		}
	}

}
