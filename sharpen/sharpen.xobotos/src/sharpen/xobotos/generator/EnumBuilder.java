package sharpen.xobotos.generator;

import org.eclipse.jdt.core.dom.EnumDeclaration;

import sharpen.core.CSharpBuilder;
import sharpen.core.csharp.ast.CSEnum;
import sharpen.core.csharp.ast.CSTypeReference;
import sharpen.core.framework.BindingUtils;
import sharpen.core.framework.CSharpDriver.IBuilderDelegate;
import sharpen.xobotos.api.actions.ModifyEnum;
import sharpen.xobotos.api.bindings.EnumBinding;
import sharpen.xobotos.api.templates.EnumTemplate;
import sharpen.xobotos.output.OutputType;

public class EnumBuilder extends MemberBuilder<EnumDeclaration, CSEnum, EnumTemplate> {

	protected EnumBuilder(EnumTemplate template, OutputType output, EnumDeclaration node) {
		super(template, CSEnum.class, output, node);
	}

	@Override
	public String getNodeName() {
		return BindingUtils.qualifiedName(getASTNode().resolveBinding());
	}

	@Override
	protected boolean buildInternal(CSharpBuilder builder, IBuilderDelegate<?> delegate, CSEnum member) {
		EnumBinding binding = getTemplate().getBinding();
		if (binding != null) {
			String baseType = binding.getBaseType();
			if ((baseType != null) && !baseType.isEmpty())
				member.baseType(new CSTypeReference(baseType));
		}
		return true;
	}

	@Override
	protected boolean applyActions(CSEnum theEnum) {
		ModifyEnum action = getTemplate().getModificationAction();
		if (action != null)
			action.modify(this, getASTNode(), theEnum);

		return true;
	}

}
