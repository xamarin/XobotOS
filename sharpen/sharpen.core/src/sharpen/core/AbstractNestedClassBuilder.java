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

import org.eclipse.jdt.core.dom.*;

import sharpen.core.csharp.ast.*;

/**
 * @exclude
 */
public abstract class AbstractNestedClassBuilder extends CSharpBuilder {

	private boolean _usesEnclosingMember;
	protected boolean _insideSuperCtorInvocation;

	public AbstractNestedClassBuilder(CSharpBuilder other) {
		super(other);
	}

	protected abstract ITypeBinding nestedTypeBinding();

	@Override
	protected CSExpression mapMethodTargetExpression(MethodInvocation node) {
		if (null == node.getExpression()) {
			return createEnclosingTargetReferences(node.getName());
		}
		return super.mapMethodTargetExpression(node);
	}

	@Override
	public boolean visit(ThisExpression node) {
		if (null == node.getQualifier()) return super.visit(node);
		pushExpression(createEnclosingThisReference(node.getQualifier().resolveTypeBinding(), true));
		return false;
	}

	@Override
	public boolean visit(SimpleName name) {
		if (isInstanceFieldReference(name)) {
			pushExpression(createEnclosingReferences(name));
			return false;
		}
		return super.visit(name);
	}

	private boolean isInstanceFieldReference(SimpleName name) {
		IBinding binding = name.resolveBinding();
		if (IBinding.VARIABLE != binding.getKind()) return false;
		return ((IVariableBinding)binding).isField();
	}

	private CSExpression createEnclosingReferences(SimpleName name) {
		CSExpression target = createEnclosingTargetReferences(name);
		return createSimpleNameReference(name, target);
	}

	private CSExpression createEnclosingTargetReferences(SimpleName name) {
		ITypeBinding enclosingClassBinding = getDeclaringClass(name);

		if (isStaticMember(name)){
			if (enclosingClassBinding == nestedTypeBinding())
				return null;
			else
				return mappedTypeReference(enclosingClassBinding);
		}

		CSExpression target = isStaticMember(name)
				? mappedTypeReference(enclosingClassBinding)
						: createEnclosingThisReference(enclosingClassBinding);
				return target;
	}

	@Override
	protected CSExpression createEnclosingThisReference(ITypeBinding enclosingClassBinding) {
		return createEnclosingThisReference(enclosingClassBinding, false);
	}

	private CSExpression createEnclosingThisReference(
			ITypeBinding enclosingClassBinding, boolean ignoreSuperclass) {
		ITypeBinding binding = nestedTypeBinding().getTypeDeclaration();
		ITypeBinding to = enclosingClassBinding.getTypeDeclaration();

		CSExpression enclosing;
		if (_insideSuperCtorInvocation) {
			requireEnclosingReference();
			enclosing = new CSReferenceExpression("_enclosing");
			binding = binding.getDeclaringClass();
			if (binding == null) return enclosing;
			binding = binding.getTypeDeclaration();
			if (binding == null) return enclosing;
		} else
			enclosing = new CSThisExpression();

		while ((binding != to) && binding.isNested() && !Modifier.isStatic(binding.getModifiers())
				&& (ignoreSuperclass || !isSuperclass(binding, to))) {
			requireEnclosingReference();
			enclosing = new CSMemberReferenceExpression(enclosing, "_enclosing");
			binding = binding.getDeclaringClass();
			if (null == binding) break;
			binding = binding.getTypeDeclaration();
		}
		return enclosing;
	}

	protected CSExpression createEnclosingBaseCtorArgument(String fieldName, ITypeBinding target) {
		ITypeBinding binding = nestedTypeBinding().getDeclaringClass().getTypeDeclaration();
		ITypeBinding to = target.getDeclaringClass().getTypeDeclaration();

		CSExpression enclosing = new CSReferenceExpression(fieldName);

		while (binding != to) {
			binding = binding.getDeclaringClass();
			if (null == binding)
				break;
			binding = binding.getTypeDeclaration();
			enclosing = new CSMemberReferenceExpression(enclosing, "_enclosing");
		}

		return enclosing;
	}

	protected boolean isEnclosingReferenceRequired() {
		return _usesEnclosingMember;
	}

	protected void requireEnclosingReference() {
		_usesEnclosingMember = true;
	}

	private boolean isStaticMember(SimpleName name) {
		return Modifier.isStatic(name.resolveBinding().getModifiers());
	}

	private boolean isSuperclass(ITypeBinding type, ITypeBinding candidate) {
		ITypeBinding superClass = type.getSuperclass().getTypeDeclaration();
		candidate = candidate.getTypeDeclaration();
		while (null != superClass) {
			if (superClass == candidate) {
				return true;
			}
			superClass = superClass.getSuperclass();
		}
		return false;
	}

	private ITypeBinding getDeclaringClass(Name reference) {
		IBinding binding = reference.resolveBinding();
		switch (binding.getKind()) {
		case IBinding.METHOD: {
			return ((IMethodBinding)binding).getDeclaringClass().getTypeDeclaration();
		}
		case IBinding.VARIABLE: {
			IVariableBinding variable = (IVariableBinding)binding;
			return variable.getDeclaringClass().getTypeDeclaration();
		}
		}
		//throw new UnsupportedOperationException();
		return null;
	}

	protected CSField createEnclosingField() {
		return CSharpCode.newPrivateReadonlyField("_enclosing", enclosingTypeReference());
	}

	private CSTypeReference enclosingTypeReference() {
		CSTypeReference tr = new CSTypeReference(_currentType.name());
		for (CSTypeParameter tp : _currentType.typeParameters())
			tr.addTypeArgument(new CSTypeReference (tp.name()));
		return tr;
	}

	protected CSInfixExpression createFieldAssignment(String fieldName, String rvalue) {
		return createFieldAssignment(fieldName, new CSReferenceExpression(rvalue));
	}

	protected CSInfixExpression createFieldAssignment(String fieldName,
			final CSExpression fieldValue) {
		CSExpression fieldReference = new CSMemberReferenceExpression(new CSThisExpression(), fieldName);
		return new CSInfixExpression("=", fieldReference, fieldValue);
	}

	@Override
	public boolean visit(SuperConstructorInvocation node) {
		_insideSuperCtorInvocation = true;
		boolean retval = super.visit(node);
		_insideSuperCtorInvocation = false;
		return retval;
	}

}