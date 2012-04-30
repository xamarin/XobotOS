/* Copyright (C) 2009  Versant Inc.   http://www.db4o.com */
package sharpen.core.internal;

import java.util.*;

import org.eclipse.jdt.core.dom.*;

import sharpen.core.*;
import static sharpen.core.framework.Environments.*;

public class NameScopeImpl implements NameScope {


	public boolean contains(String name) {
		return _mappedMethodDeclarations.contains(name);
	}

	public void enterTypeDeclaration(TypeDeclaration node) {
		_currentType.push(node);
		
		_mappedMethodDeclarations.clear();
		for (MethodDeclaration meth : node.getMethods()) {
			if (SharpenAnnotations.hasIgnoreAnnotation(meth))
				continue;
			
			_mappedMethodDeclarations.add(my(Mappings.class).mappedMethodName(meth.resolveBinding()));
		}
	}

	public void leaveTypeDeclaration(TypeDeclaration node) {
		_currentType.pop();
	}
	
	public TypeDeclaration currentType() {
		return _currentType.peek();
	}
	
	private Stack<TypeDeclaration> _currentType = new Stack();
	private List<String> _mappedMethodDeclarations = new ArrayList<String>();
}
