/* Copyright (C) 2009  Versant Inc.   http://www.db4o.com */
package sharpen.core.internal;

import org.eclipse.jdt.core.dom.*;

import sharpen.core.*;
import sharpen.core.framework.*;
import static sharpen.core.framework.Environments.*;

public class BindingsImpl implements Bindings {

	private final CompilationUnit _ast = my(CompilationUnit.class);
	private final ASTResolver _resolver = my(ASTResolver.class);

	public IMethodBinding originalBindingFor(IMethodBinding binding) {
		IMethodBinding original = BindingUtils.findMethodDefininition(binding, my(CompilationUnit.class).getAST());
		return (null != original) 
				? original 
				: binding;
	}

	public <T extends ASTNode> T findDeclaringNode(IBinding binding) {
		final ASTNode declaringNode = _ast.findDeclaringNode(binding);
		if (null != declaringNode)
			return (T)declaringNode;
		if (null == _resolver)
			return null;
		return (T)_resolver.findDeclaringNode(binding);
	}

}
