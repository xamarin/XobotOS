package sharpen.xobotos.api.actions;

import org.eclipse.jdt.core.dom.MethodDeclaration;

import sharpen.core.csharp.ast.CSMethodBase;
import sharpen.xobotos.api.templates.AbstractMethodTemplate;
import sharpen.xobotos.generator.AbstractMethodBuilder;

public abstract class ModifyMethodBase<T extends CSMethodBase, U extends AbstractMethodTemplate<T>, V extends AbstractMethodBuilder<T, U>>
		extends ModifyMember<MethodDeclaration, T, U, V> {

	@Override
	protected Class<MethodDeclaration> getNodeType() {
		return MethodDeclaration.class;
	}

}
