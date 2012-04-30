package sharpen.xobotos.generator;

import static sharpen.core.framework.Environments.my;

import org.eclipse.jdt.core.dom.FieldDeclaration;
import org.eclipse.jdt.core.dom.VariableDeclarationFragment;

import sharpen.core.CSharpBuilder;
import sharpen.core.csharp.ast.CSField;
import sharpen.core.csharp.ast.CSVisibility;
import sharpen.core.framework.BindingUtils;
import sharpen.core.framework.CSharpDriver.IBuilderDelegate;
import sharpen.xobotos.api.actions.ModifyField;
import sharpen.xobotos.api.bindings.BindingManager;
import sharpen.xobotos.api.bindings.VariableBinding;
import sharpen.xobotos.api.templates.FieldTemplate;
import sharpen.xobotos.output.OutputType;

public class FieldBuilder extends MemberBuilder<FieldDeclaration, CSField, FieldTemplate> {

	private final VariableDeclarationFragment _fragment;

	protected FieldBuilder(FieldTemplate template, OutputType output, FieldDeclaration node,
			VariableDeclarationFragment fragment) {
		super(template, CSField.class, output, node);
		this._fragment = fragment;
	}

	@Override
	public String getNodeName() {
		VariableDeclarationFragment fragment = (VariableDeclarationFragment) getASTNode().fragments().get(0);
		return BindingUtils.qualifiedName(fragment.resolveBinding());
	}

	@Override
	protected boolean buildInternal(CSharpBuilder builder, IBuilderDelegate<?> delegate, CSField member) {
		VariableBinding binding = my(BindingManager.class).resolveBinding(_fragment.resolveBinding());
		if (binding != null) {
			if (binding.getNativeHandle() != null)
				member.visibility(CSVisibility.Internal);
		}
		return true;
	}

	@Override
	protected boolean applyActions(CSField field) {
		ModifyField action = getTemplate().getModificationAction();
		if (action != null)
			action.modify(this, getASTNode(), field);
		return true;
	}

}
