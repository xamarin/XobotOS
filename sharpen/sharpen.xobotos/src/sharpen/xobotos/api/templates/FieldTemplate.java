package sharpen.xobotos.api.templates;

import com.thoughtworks.xstream.annotations.XStreamAlias;
import com.thoughtworks.xstream.annotations.XStreamOmitField;

import org.eclipse.jdt.core.dom.FieldDeclaration;

import sharpen.core.csharp.ast.CSField;
import sharpen.xobotos.api.actions.ModifyField;
import sharpen.xobotos.api.bindings.VariableBinding;

@XStreamAlias(value="field")
public class FieldTemplate extends MemberTemplate<FieldDeclaration, CSField> {

	@XStreamOmitField
	public final static FieldTemplate DEFAULT = new FieldTemplate();

	@XStreamAlias("modify")
	private ModifyField _modifyField;

	@XStreamAlias("binding")
	private VariableBinding _binding;

	@Override
	public ModifyField getModificationAction() {
		return _modifyField;
	}

	@Override
	public VariableBinding getBinding() {
		return _binding;
	}

}
