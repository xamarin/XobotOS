package sharpen.xobotos.api.templates;

import org.eclipse.jdt.core.IJavaElement;
import org.eclipse.jdt.core.dom.CompilationUnit;
import org.eclipse.jdt.core.dom.ITypeBinding;
import org.eclipse.jdt.core.dom.TypeDeclaration;

import sharpen.core.framework.ASTUtility;
import sharpen.xobotos.config.LocationFilter.Match;


public class MainTypeTemplate extends TypeTemplate {

	@Override
	public Match matches(TypeDeclaration node) {
		ITypeBinding binding = node.resolveBinding();
		CompilationUnit unit = ASTUtility.ancestorOf(node, CompilationUnit.class);
		IJavaElement element = unit.getJavaElement();
		if (element == null)
			return Match.NO_MATCH;
		String name = element.getElementName();
		if (name.endsWith(".java"))
			name = name.substring(0, name.length() - 5);
		if (!name.equals(binding.getName()))
			return Match.NO_MATCH;
		return super.matches(node);
	}

	@Override
	public boolean isMainType() {
		return true;
	}

}
