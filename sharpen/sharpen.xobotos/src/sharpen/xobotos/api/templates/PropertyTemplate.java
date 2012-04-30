package sharpen.xobotos.api.templates;

import com.thoughtworks.xstream.annotations.XStreamAlias;
import com.thoughtworks.xstream.annotations.XStreamOmitField;

import org.eclipse.jdt.core.dom.MethodDeclaration;

import sharpen.core.csharp.ast.CSProperty;
import sharpen.xobotos.api.actions.ModifyProperty;
import sharpen.xobotos.api.bindings.MemberBinding;

@XStreamAlias(value = "property")
public class PropertyTemplate extends MemberTemplate<MethodDeclaration, CSProperty> {

	@XStreamOmitField
	public final static PropertyTemplate DEFAULT = new PropertyTemplate();

	@XStreamAlias("modify")
	private ModifyProperty _modifyProperty;

	@Override
	public ModifyProperty getModificationAction() {
		return _modifyProperty;
	}

	@Override
	public MemberBinding getBinding() {
		return null;
	}

}
