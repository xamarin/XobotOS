/* Copyright (C) 2009  Versant Inc.   http://www.db4o.com */
package sharpen.core;

import org.eclipse.jdt.core.dom.IMethodBinding;
import org.eclipse.jdt.core.dom.ITypeBinding;
import org.eclipse.jdt.core.dom.IVariableBinding;

import sharpen.core.Configuration.MemberMapping;

public interface Mappings {

	String mappedFieldName(IVariableBinding binding);

	String mappedTypeName(ITypeBinding type);

	String extractedInterfaceName(ITypeBinding type);

	String mappedMethodName(IMethodBinding binding);

	MemberMapping effectiveMappingFor(IMethodBinding binding);

}
