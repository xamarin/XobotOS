package sharpen.xobotos.api.actions;

import com.thoughtworks.xstream.annotations.XStreamAlias;

import org.eclipse.jdt.core.dom.EnumDeclaration;

import sharpen.core.csharp.ast.CSTypeDeclaration;
import sharpen.xobotos.api.templates.ExtractedEnumTemplate;
import sharpen.xobotos.generator.ExtractedEnumBuilder;

@XStreamAlias(value = "modify-extracted-enum")
public class ModifyExtractedEnum
		extends ModifyMember<EnumDeclaration, CSTypeDeclaration, ExtractedEnumTemplate, ExtractedEnumBuilder> {

	@Override
	protected Class<EnumDeclaration> getNodeType() {
		return EnumDeclaration.class;
	}

	@Override
	protected Class<ExtractedEnumBuilder> getBuilderType() {
		return ExtractedEnumBuilder.class;
	}

}
