package sharpen.xobotos.api.templates;

import org.eclipse.jdt.core.dom.AnonymousClassDeclaration;
import org.eclipse.jdt.core.dom.FieldDeclaration;
import org.eclipse.jdt.core.dom.MethodDeclaration;

public interface IMemberContainer extends ITypeContainer {

	TypeTemplate getTypeTemplate();

	FieldTemplate findFieldTemplate(FieldDeclaration node);

	AbstractMethodTemplate<?> findMethodTemplate(MethodDeclaration node);

	AnonymousClassTemplate findAnonymousClassTemplate(AnonymousClassDeclaration node);

}
