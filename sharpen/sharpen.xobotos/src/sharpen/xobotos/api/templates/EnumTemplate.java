package sharpen.xobotos.api.templates;

import com.thoughtworks.xstream.annotations.XStreamAlias;
import com.thoughtworks.xstream.annotations.XStreamOmitField;

import org.eclipse.jdt.core.dom.EnumDeclaration;

import sharpen.core.csharp.ast.CSEnum;
import sharpen.xobotos.api.actions.ModifyEnum;
import sharpen.xobotos.api.bindings.EnumBinding;

@XStreamAlias(value="enum")
public class EnumTemplate extends MemberTemplate<EnumDeclaration, CSEnum> {

	@XStreamOmitField
	public static final EnumTemplate DEFAULT = new EnumTemplate();

	@XStreamAlias("modify")
	private ModifyEnum _modifyEnum;

	@XStreamAlias("binding")
	private EnumBinding _binding;

	@Override
	public ModifyEnum getModificationAction() {
		return _modifyEnum;
	}

	@Override
	public EnumBinding getBinding() {
		return _binding;
	}

}
