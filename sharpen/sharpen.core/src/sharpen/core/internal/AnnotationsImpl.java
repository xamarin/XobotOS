/* Copyright (C) 2009  Versant Inc.   http://www.db4o.com */
package sharpen.core.internal;

import org.eclipse.jdt.core.dom.*;

import sharpen.core.*;
import sharpen.core.Bindings;
import sharpen.core.framework.*;
import static sharpen.core.framework.Environments.*;

public class AnnotationsImpl implements Annotations {

	private final CompilationUnit _ast = my(CompilationUnit.class);
	private final Bindings _bindings = my(Bindings.class);

	public TagElement effectiveAnnotationFor(MethodDeclaration node, String annotation) {
		TagElement eventTag = javadocTagFor(node, annotation);
		if (null != eventTag)
			return eventTag;

		MethodDeclaration originalMethod = findOriginalMethodDeclaration(node);
		if (null == originalMethod)
			return null;

		return javadocTagFor(originalMethod, annotation);
	}
	
	private TagElement javadocTagFor(MethodDeclaration method, String annotation) {
		return JavadocUtility.getJavadocTag(method, annotation);
	}

	private MethodDeclaration findOriginalMethodDeclaration(MethodDeclaration node) {
		return findOriginalMethodDeclaration(node.resolveBinding());
	}

	private MethodDeclaration findOriginalMethodDeclaration(IMethodBinding binding) {
		IMethodBinding definition = BindingUtils.findMethodDefininition(binding, _ast.getAST());
		if (null == definition)
			return null;
		
		return _bindings.findDeclaringNode(definition);
	}

	public String annotatedPropertyName(MethodDeclaration node) {
		final TagElement propertyTag = effectiveAnnotationFor(node, SharpenAnnotations.SHARPEN_PROPERTY);
		if (JavadocUtility.hasSingleTextFragment(propertyTag)) {
			return JavadocUtility.singleTextFragmentFrom(propertyTag);
		}
		return null;
	}

	public String annotatedRenaming(BodyDeclaration node) {
		TagElement renameTag = JavadocUtility.getJavadocTag(node, SharpenAnnotations.SHARPEN_RENAME);
		if (null == renameTag)
			return null;
		return JavadocUtility.singleTextFragmentFrom(renameTag);
	}
	
}
