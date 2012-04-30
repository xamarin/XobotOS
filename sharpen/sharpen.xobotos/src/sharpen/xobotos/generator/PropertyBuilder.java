package sharpen.xobotos.generator;

import org.eclipse.jdt.core.dom.MethodDeclaration;

import sharpen.core.CSharpBuilder;
import sharpen.core.csharp.ast.CSAttribute;
import sharpen.core.csharp.ast.CSBlock;
import sharpen.core.csharp.ast.CSMethodModifier;
import sharpen.core.csharp.ast.CSProperty;
import sharpen.core.framework.BindingUtils;
import sharpen.core.framework.CSharpDriver.IBuilderDelegate;
import sharpen.core.framework.CSharpDriver.IPropertyBuilderDelegate;
import sharpen.xobotos.api.actions.ModifyProperty;
import sharpen.xobotos.api.templates.PropertyTemplate;
import sharpen.xobotos.output.OutputMode;
import sharpen.xobotos.output.OutputType;

public class PropertyBuilder extends MemberBuilder<MethodDeclaration, CSProperty, PropertyTemplate> {

	protected PropertyBuilder(PropertyTemplate template, OutputType output, MethodDeclaration node) {
		super(template, CSProperty.class, output, node);
	}

	@Override
	public String getNodeName() {
		return BindingUtils.qualifiedSignature(getASTNode().resolveBinding());
	}

	@Override
	protected boolean buildInternal(CSharpBuilder builder, IBuilderDelegate<?> dlg, CSProperty property) {
		IPropertyBuilderDelegate delegate = (IPropertyBuilderDelegate) dlg;

		if (getOutputMode() == OutputMode.ABSTRACT_STUB) {
			property.modifier(CSMethodModifier.Abstract);
			property.addAttribute(new CSAttribute("Sharpen.Stub"));
			return true;
		}

		if (getOutputMode() == OutputMode.SHARPEN) {
			delegate.mapBody(property);
			return true;
		}

		CSBlock block = new CSBlock();
		if (delegate.isGetter())
			property.getter(block);
		else
			property.setter(block);

		stubBlock(block);
		property.addAttribute(new CSAttribute("Sharpen.Stub"));

		return true;
	}

	@Override
	protected boolean applyActions(CSProperty property) {
		ModifyProperty action = getTemplate().getModificationAction();
		if (action != null)
			action.modify(this, getASTNode(), property);
		return true;
	}

}
