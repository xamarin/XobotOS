/* Copyright (C) 2009  Versant Inc.   http://www.db4o.com */
package sharpen.core;

import org.eclipse.jdt.core.dom.*;

public interface NameScope {

	void enterTypeDeclaration(TypeDeclaration node);

	void leaveTypeDeclaration(TypeDeclaration node);
	
	TypeDeclaration currentType();

	boolean contains(String name);

}
