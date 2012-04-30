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

/**
 * Portions of this file were taken from Eclipse:
 * /org.eclipse.jdt.ui/core extension/org/eclipse/jdt/internal/corext/dom/Bindings.java
 * and are subject to the CPL.
 * 
 * Original copyright notice on file follows:
 * /*******************************************************************************
 *  * Copyright (c) 2000, orporation and others.
 *  * All rights reserved. This program and the accompanying materials
 *  * are made available under the terms of the Common Public License v1.0
 *  * which accompanies this distribution, and is available at
 *  * http://www.eclipse.org/legal/cpl-v10.html
 *  *
 *  * Contributors:
 *  *    IBM Corporation - initial API and implementation
 *  *    Dmitry Stalnov (dstalnov@fusionone.com) - contributed fix for
 *  *       bug "inline method - doesn't handle implicit cast" (see
 *  *       https://bugs.eclipse.org/bugs/show_bug.cgi?id=24941).
 *  *******************************************************************************
 */

package sharpen.core.framework;

import static sharpen.core.framework.Environments.my;

import org.eclipse.jdt.core.dom.*;

import sharpen.core.Configuration;

import java.util.Collections;
import java.util.HashSet;
import java.util.LinkedHashSet;
import java.util.Set;

public class BindingUtils {

	/**
	 * Finds the method in the given <code>type</code> that is overrideen by
	 * the specified <code>method<code> . Returns <code>null</code> if no
	 * such method exits.
	 * 
	 * @param type
	 *                The type to search the method in
	 * @param method
	 *                The specified method that would override the result
	 * @return the method binding representing the method oevrriding the
	 *         specified <code>method<code>
	 */
	public static IMethodBinding findOverriddenMethodInType(ITypeBinding type, IMethodBinding method) {
		if (type.getName().equals("Object") && method.getName().equals("clone"))
			return null;
		for (Object o : type.getDeclaredMethods()) {
			IMethodBinding existing = (IMethodBinding) o;

			if (isSubsignature(method, existing))
				return existing;
		}
		return null;
	}

	public static IMethodBinding findOverriddenMethodInTypeOrSuperclasses(ITypeBinding type, IMethodBinding method) {
		IMethodBinding found = findOverriddenMethodInType(type, method);
		if (null != found) {
			return found;
		}
		ITypeBinding superClass = type.getSuperclass();
		if (null != superClass) {
			return findOverriddenMethodInTypeOrSuperclasses(superClass, method);
		}
		return null;
	}

	/**
	 * Finds a method in the hierarchy of <code>type</code> that is
	 * overridden by </code>binding</code>. Returns <code>null</code> if no
	 * such method exists. First the super class is examined and than the
	 * implemented interfaces.
	 * 
	 * @param type
	 *                The type to search the method in
	 * @param binding
	 *                The method that overrides
	 * @return the method binding overridden the method
	 */
	public static IMethodBinding findOverriddenMethodInHierarchy(ITypeBinding type, IMethodBinding binding) {
		return findOverriddenMethodInHierarchy(type, binding, true);
	}

	public static IMethodBinding findOverriddenMethodInHierarchy(ITypeBinding type, IMethodBinding binding,
			boolean considerInterfaces) {
		final ITypeBinding superClass = type.getSuperclass();
		if (superClass != null) {
			final IMethodBinding superClassMethod = findOverriddenMethodInHierarchy(superClass, binding);
			if (superClassMethod != null)
				return superClassMethod;
		}
		final IMethodBinding method = findOverriddenMethodInType(type, binding);
		if (method != null)
			return method;

		if (considerInterfaces) {
			final ITypeBinding[] interfaces = type.getInterfaces();
			for (int i = 0; i < interfaces.length; i++) {
				final IMethodBinding interfaceMethod = findOverriddenMethodInHierarchy(interfaces[i],
						binding);
				if (interfaceMethod != null)
					return interfaceMethod;
			}
		}

		return null;
	}

	/**
	 * Finds the method that is defines the given method. The returned
	 * method might not be visible.
	 * 
	 * @param method
	 *                The method to find
	 * @param typeResolver
	 *                TODO
	 * @return the method binding representing the method
	 */
	public static IMethodBinding findMethodDefininition(IMethodBinding method, AST typeResolver) {
		if (null == method) {
			return null;
		}

		IMethodBinding definition = null;
		ITypeBinding type = method.getDeclaringClass();
		ITypeBinding[] interfaces = type.getInterfaces();
		for (int i = 0; i < interfaces.length; i++) {
			IMethodBinding res = findOverriddenMethodInHierarchy(interfaces[i], method);
			if (res != null) {
				definition = res; // methods from interfaces are
				// always public and
				// therefore visible
				break;
			}
		}

		if (type.getSuperclass() != null) {
			IMethodBinding res = findOverriddenMethodInHierarchy(type.getSuperclass(), method);
			if (res != null && !Modifier.isPrivate(res.getModifiers())) {
				definition = res;
			}
		} else if (type.isInterface() && null != typeResolver) {
			IMethodBinding res = findOverriddenMethodInHierarchy(
					typeResolver.resolveWellKnownType("java.lang.Object"), method);
			if (res != null) {
				definition = res;
			}
		}

		IMethodBinding def = findMethodDefininition(definition, typeResolver);
		if (def != null) {
			return def;
		}

		return definition;
	}

	public static boolean isVisibleInHierarchy(IMethodBinding member, IPackageBinding pack) {
		int otherflags = member.getModifiers();
		ITypeBinding declaringType = member.getDeclaringClass();
		if (Modifier.isPublic(otherflags) || Modifier.isProtected(otherflags)
				|| (declaringType != null && declaringType.isInterface())) {
			return true;
		} else if (Modifier.isPrivate(otherflags)) {
			return false;
		}
		return pack == declaringType.getPackage();
	}

	public static String qualifiedName(IMethodBinding binding) {
		return qualifiedName(binding.getDeclaringClass()) + "."
				+ binding.getName();
	}

	public static String qualifiedSignature(IMethodBinding binding) {
		StringBuffer buf = new StringBuffer();
		buf.append(qualifiedName(binding.getDeclaringClass())).append(".").append(binding.getName())
		.append("(");
		ITypeBinding[] parameterTypes = binding.getParameterTypes();
		for (int i = 0; i < parameterTypes.length; i++) {
			if (i != 0)
				buf.append(",");
			buf.append(qualifiedName(parameterTypes[i]));
		}
		buf.append(")");
		return buf.toString();
	}

	public static String typeMappingKey(final ITypeBinding type) {
		ITypeBinding[] typeArguments = type.getTypeArguments();
		if (typeArguments.length == 0)
			typeArguments = type.getTypeParameters();
		if (typeArguments.length > 0) {
			return qualifiedName(type) + "<" + repeat(',', typeArguments.length - 1) + ">";
		}
		return qualifiedName(type);
	}

	private static String repeat(char c, int count) {
		StringBuilder builder = new StringBuilder(count);
		for (int i = 0; i < count; ++i) {
			builder.append(c);
		}
		return builder.toString();
	}

	public static String qualifiedName(final ITypeBinding declaringClass) {
		String qn = declaringClass.getTypeDeclaration().getQualifiedName();
		if (qn.length() > 0)
			return qn;
		else
			return declaringClass.getQualifiedName();
	}

	public static String qualifiedName(IVariableBinding binding) {
		ITypeBinding declaringClass = binding.getDeclaringClass();

		if (null == declaringClass) {
			return binding.getName();
		}
		return qualifiedName(declaringClass) + "." + binding.getName();
	}

	public static boolean isStatic(IMethodBinding binding) {
		return Modifier.isStatic(binding.getModifiers());
	}

	public static boolean isStatic(IVariableBinding binding) {
		return Modifier.isStatic(binding.getModifiers());
	}

	public static boolean isStatic(MethodInvocation invocation) {
		return isStatic(invocation.resolveMethodBinding());
	}

	/**
	 * 
	 * http://javasourcecode.org/html/open-source/eclipse/eclipse-3.5.2/org/eclipse/jdt/internal/corext/dom/Bindings.java.html
	 * 
	 * Checks if the two bindings are equals. Also works across binding
	 * environments.
	 * 
	 * @param b1
	 *                first binding treated as <code>this</code>. So it must
	 *                not be <code>null</code>
	 * @param b2
	 *                the second binding.
	 * @return boolean
	 */
	public static boolean equals(IBinding b1, IBinding b2) {
		return b1.isEqualTo(b2);
	}

	/**
	 * 
	 * http://javasourcecode.org/html/open-source/eclipse/eclipse-3.5.2/org/eclipse/jdt/internal/corext/dom/Bindings.java.html
	 * 
	 * Checks if the two arrays of bindings have the same length and their
	 * elements are equal. Uses
	 * <code>Bindings.equals(IBinding, IBinding)</code> to compare.
	 * 
	 * @param b1
	 *                the first array of bindings. Must not be
	 *                <code>null</code>.
	 * @param b2
	 *                the second array of bindings.
	 * @return boolean
	 */
	public static boolean equals(IBinding[] b1, IBinding[] b2) {
		if (b1 == b2)
			return true;
		if (b2 == null)
			return false;
		if (b1.length != b2.length)
			return false;
		for (int i = 0; i < b1.length; i++) {
			if (!equals(b1[i], b2[i]))
				return false;
		}
		return true;
	}

	/**
	 * 
	 * http://javasourcecode.org/html/open-source/eclipse/eclipse-3.5.2/org/eclipse/jdt/internal/corext/dom/Bindings.java.html
	 * 
	 */
	private static boolean containsTypeVariables(ITypeBinding type) {
		if (type.isTypeVariable())
			return true;
		if (type.isArray())
			return containsTypeVariables(type.getElementType());
		if (type.isCapture())
			return containsTypeVariables(type.getWildcard());
		if (type.isParameterizedType())
			return containsTypeVariables(type.getTypeArguments());
		if (type.isTypeVariable())
			return containsTypeVariables(type.getTypeBounds());
		if (type.isWildcardType() && type.getBound() != null)
			return containsTypeVariables(type.getBound());
		return false;
	}

	/**
	 * 
	 * http://javasourcecode.org/html/open-source/eclipse/eclipse-3.5.2/org/eclipse/jdt/internal/corext/dom/Bindings.java.html
	 * 
	 */
	private static boolean containsTypeVariables(ITypeBinding[] types) {
		for (int i = 0; i < types.length; i++)
			if (containsTypeVariables(types[i]))
				return true;
		return false;
	}

	/**
	 * 
	 * http://javasourcecode.org/html/open-source/eclipse/eclipse-3.5.2/org/eclipse/jdt/internal/corext/dom/Bindings.java.html
	 * 
	 */
	private static Set getTypeBoundsForSubsignature(ITypeBinding typeParameter) {
		ITypeBinding[] typeBounds = typeParameter.getTypeBounds();
		int count = typeBounds.length;
		if (count == 0)
			return Collections.EMPTY_SET;

		Set result = new HashSet(typeBounds.length);
		for (int i = 0; i < typeBounds.length; i++) {
			ITypeBinding bound = typeBounds[i];
			if ("java.lang.Object".equals(typeBounds[0].getQualifiedName())) //$NON-NLS-1$
				continue;
			else if (containsTypeVariables(bound))
				result.add(bound.getErasure()); // try to
			// achieve
			// effect of
			// "rename type variables"
			else if (bound.isRawType())
				result.add(bound.getTypeDeclaration());
			else
				result.add(bound);
		}
		return result;
	}

	/**
	 * 
	 * http://javasourcecode.org/html/open-source/eclipse/eclipse-3.5.2/org/eclipse/jdt/internal/corext/dom/Bindings.java.html
	 * 
	 * @param overriding
	 *                overriding method (m1)
	 * @param overridden
	 *                overridden method (m2)
	 * @return <code>true</code> iff the method <code>m1</code> is a
	 *         subsignature of the method <code>m2</code>. This is one of
	 *         the requirements for m1 to override m2. Accessibility and
	 *         return types are not taken into account. Note that
	 *         subsignature is <em>not</em> symmetric!
	 */
	public static boolean isSubsignature(IMethodBinding overriding, IMethodBinding overridden) {
		// TODO: use IMethodBinding#isSubsignature(..) once it is tested
		// and fixed (only erasure of m1's parameter types, considering
		// type variable counts, doing type variable substitution
		if (!overriding.getName().equals(overridden.getName()))
			return false;

		ITypeBinding[] m1Params = overriding.getParameterTypes();
		ITypeBinding[] m2Params = overridden.getParameterTypes();
		if (m1Params.length != m2Params.length)
			return false;

		ITypeBinding[] m1TypeParams = overriding.getTypeParameters();
		ITypeBinding[] m2TypeParams = overridden.getTypeParameters();
		if (m1TypeParams.length != m2TypeParams.length
				&& m1TypeParams.length != 0) // non-generic m1
			// can override
			// a generic m2
			return false;

		// m1TypeParameters.length == (m2TypeParameters.length || 0)
		if (m2TypeParams.length != 0) {
			// Note: this branch does not 100% adhere to the spec
			// and may report some false positives.
			// Full compliance would require major duplication of
			// compiler code.

			// Compare type parameter bounds:
			for (int i = 0; i < m1TypeParams.length; i++) {
				// loop over m1TypeParams, which is either
				// empty, or equally long as m2TypeParams
				Set m1Bounds = getTypeBoundsForSubsignature(m1TypeParams[i]);
				Set m2Bounds = getTypeBoundsForSubsignature(m2TypeParams[i]);
				if (!m1Bounds.equals(m2Bounds))
					return false;
			}
			// Compare parameter types:
			if (equals(m2Params, m1Params))
				return true;
			for (int i = 0; i < m1Params.length; i++) {
				ITypeBinding m1Param = m1Params[i];
				if (containsTypeVariables(m1Param))
					m1Param = m1Param.getErasure(); // try
				// to
				// achieve
				// effect
				// of
				// "rename type variables"
				else if (m1Param.isRawType())
					m1Param = m1Param.getTypeDeclaration();
				if (!(equals(m1Param, m2Params[i].getErasure()))) // can
					// erase
					// m2
					return false;
			}
			return true;

		} else {
			// m1TypeParams.length == m2TypeParams.length == 0
			if (equals(m1Params, m2Params))
				return true;
			for (int i = 0; i < m1Params.length; i++) {
				ITypeBinding m1Param = m1Params[i];
				if (m1Param.isRawType())
					m1Param = m1Param.getTypeDeclaration();
				if (!(equals(m1Param, m2Params[i].getErasure()))) // can
					// erase
					// m2
					return false;
			}
			return true;
		}
	}

	public static boolean findInterfaceInClassHierarchy(ITypeBinding type, ITypeBinding binding) {
		while (binding != null) {
			if (binding.isInterface())
				break;
			Set<ITypeBinding> ifaces = new LinkedHashSet<ITypeBinding>();
			collectInterfaces(ifaces, binding);
			if (ifaces.contains(type))
				return true;
			binding = binding.getSuperclass();
		}
		return false;
	}

	public static boolean isValidCSInterface(ITypeBinding type) {
		if (type.getDeclaredFields().length != 0)
			return false;
		for (ITypeBinding ntype : type.getDeclaredTypes()) {
			if (!isExtractedNestedType(ntype))
				return false;
		}
		return true;
	}

	private static boolean isExtractedNestedType(ITypeBinding type) {
		return my(Configuration.class).typeHasMapping(BindingUtils.typeMappingKey(type));
	}

	private static boolean isNestedInInterface(ITypeBinding type) {
		while ((type = type.getDeclaringClass()) != null) {
			if (type.isInterface())
				return true;
		}
		return false;
	}

	public static IMethodBinding getBaseMethod(IMethodBinding methodBinding, boolean overrideOnly,
			boolean allowStatic) {
		if (!allowStatic && Modifier.isStatic(methodBinding.getModifiers()))
			return null;
		ITypeBinding superclass = methodBinding.getDeclaringClass().getSuperclass();
		if (null != superclass) {
			IMethodBinding result = BindingUtils.findOverriddenMethodInHierarchy(superclass, methodBinding);
			if (null != result)
				return result;
		}
		if (Modifier.isStatic(methodBinding.getModifiers()))
			return null;
		Set<ITypeBinding> baseInterfaces = new LinkedHashSet<ITypeBinding>();
		collectInterfaces(baseInterfaces, methodBinding.getDeclaringClass());
		for (final ITypeBinding iface : baseInterfaces) {
			if (!isNestedInInterface(iface) || !isValidCSInterface(iface)) {
				if (overrideOnly)
					continue;
			}
			// Base interface generated as a class
			IMethodBinding result = BindingUtils.findOverriddenMethodInType(iface, methodBinding);
			if (result != null)
				return result;
		}
		return null;
	}

	public static Set<ITypeBinding> getAllInterfaces(ITypeBinding binding) {
		Set<ITypeBinding> set = new LinkedHashSet<ITypeBinding>();
		collectInterfaces(set, binding);
		return Collections.unmodifiableSet(set);
	}

	private static void collectInterfaces(Set<ITypeBinding> interfaceList, ITypeBinding binding) {
		ITypeBinding[] interfaces = binding.getInterfaces();
		for (int i = 0; i < interfaces.length; ++i) {
			ITypeBinding interfaceBinding = interfaces[i];
			if (interfaceList.contains(interfaceBinding)) {
				continue;
			}
			collectInterfaces(interfaceList, interfaceBinding);
			interfaceList.add(interfaceBinding);
		}
	}

}
