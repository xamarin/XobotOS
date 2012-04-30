package sharpen.xobotos.api.templates;

import org.eclipse.jdt.core.dom.EnumDeclaration;
import org.eclipse.jdt.core.dom.TypeDeclaration;

public interface ITypeContainer {

	TypeTemplate findTypeTemplate(TypeDeclaration node);

	EnumTemplate findEnumTemplate(EnumDeclaration node);

}
