package sharpen.xobotos.api.templates;

import com.thoughtworks.xstream.annotations.XStreamAlias;
import com.thoughtworks.xstream.annotations.XStreamOmitField;

import org.eclipse.jdt.core.dom.EnumDeclaration;

import sharpen.core.csharp.ast.CSTypeDeclaration;
import sharpen.xobotos.api.actions.ModifyExtractedEnum;
import sharpen.xobotos.api.bindings.EnumBinding;

@XStreamAlias(value = "extracted-enum")
public class ExtractedEnumTemplate extends MemberTemplate<EnumDeclaration, CSTypeDeclaration> {

	@XStreamOmitField
	public static final ExtractedEnumTemplate DEFAULT = new ExtractedEnumTemplate();

	@XStreamAlias("modify")
	private ModifyExtractedEnum _modifyEnum;

	@XStreamAlias("binding")
	private EnumBinding _binding;

	@Override
	public ModifyExtractedEnum getModificationAction() {
		return _modifyEnum;
	}

	@Override
	public EnumBinding getBinding() {
		return _binding;
	}

}
