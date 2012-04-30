/* Copyright (C) 2009  Versant Inc.   http://www.db4o.com */
package sharpen.core;

import org.eclipse.jdt.core.dom.*;

public interface Annotations {

	TagElement effectiveAnnotationFor(MethodDeclaration node, String annotation);

	String annotatedPropertyName(MethodDeclaration node);

	String annotatedRenaming(BodyDeclaration node);

}
