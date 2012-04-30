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

/* Copyright (C) 2006 Versant Inc. http://www.db4o.com */

package sharpen.core;

import org.eclipse.jdt.core.dom.ITypeBinding;
import org.eclipse.jdt.core.dom.TypeDeclaration;

import sharpen.core.csharp.ast.*;

import java.util.List;

/**
 * @exclude
 */
public class NonStaticNestedClassBuilder extends AbstractNestedClassBuilder {

	private final TypeDeclaration _nestedType;
	private CSTypeDeclaration _convertedType;
	private CSField _enclosingField;

	private NonStaticNestedClassBuilder(CSharpBuilder parent, TypeDeclaration nestedType) {
		super(parent);
		_nestedType = nestedType;
	}

	private CSTypeDeclaration build() {
		_convertedType = processTypeDeclaration(_nestedType);
		if (_convertedType == null)
			return null;

		_enclosingField = createEnclosingField();
		patchConstructors();
		_convertedType.addMember(_enclosingField);
		return _convertedType;
	}

	public static CSTypeDeclaration build(CSharpBuilder parent, TypeDeclaration nestedType) {
		NonStaticNestedClassBuilder builder = new NonStaticNestedClassBuilder(parent, nestedType);
		return builder.build();
	}

	private void patchConstructors() {
		final List<CSConstructor> ctors = _convertedType.constructors();
		if (ctors.isEmpty()) {
			introduceConstructor();
		} else {
			for (CSConstructor ctor : ctors) {
				patchConstructor(ctor);
			}
		}
	}

	private void patchConstructor(CSConstructor ctor) {
		ctor.addParameter(0, new CSVariableDeclaration(_enclosingField.name(), _enclosingField.type()));
		if (!ctor.isStub())
			ctor.body().addStatement(0,
					createFieldAssignment(_enclosingField.name(), _enclosingField.name()));

		ITypeBinding superClass = nestedTypeBinding().getSuperclass();
		if (superClass != null && isNonStaticNestedType (superClass)) {
			CSConstructorInvocationExpression oldCie = ctor.chainedConstructorInvocation();
			CSConstructorInvocationExpression cie = new CSConstructorInvocationExpression(new CSBaseExpression());
			CSExpression enclosing = createEnclosingBaseCtorArgument(_enclosingField.name(), superClass);
			cie.addArgument(enclosing);
			if (oldCie != null) {
				for (CSExpression arg : oldCie.arguments())
					cie.addArgument(arg);
			}
			ctor.chainedConstructorInvocation(cie);
		}
	}

	private void introduceConstructor() {
		final CSConstructor ctor = new CSConstructor();
		ctor.visibility(CSVisibility.Internal);
		patchConstructor(ctor);
		_convertedType.addMember(ctor);
	}

	@Override
	protected ITypeBinding nestedTypeBinding() {
		return _nestedType.resolveBinding();
	}

}
