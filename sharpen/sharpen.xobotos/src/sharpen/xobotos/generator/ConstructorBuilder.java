package sharpen.xobotos.generator;

import org.eclipse.jdt.core.dom.MethodDeclaration;

import sharpen.core.csharp.ast.CSConstructor;
import sharpen.xobotos.api.actions.ModifyConstructor;
import sharpen.xobotos.api.templates.ConstructorTemplate;
import sharpen.xobotos.output.OutputType;

public class ConstructorBuilder extends AbstractMethodBuilder<CSConstructor, ConstructorTemplate> {

	public ConstructorBuilder(ConstructorTemplate template, OutputType output, MethodDeclaration node) {
		super(template, CSConstructor.class, output, node);
	}

	@Override
	protected boolean applyActions(CSConstructor ctor) {
		ModifyConstructor action = getTemplate().getModificationAction();
		if (action != null)
			action.modify(this, getASTNode(), ctor);
		return true;
	}

}
