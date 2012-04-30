package sharpen.xobotos.api.actions;

import com.thoughtworks.xstream.annotations.XStreamAlias;

import org.eclipse.jdt.core.dom.EnumDeclaration;

import sharpen.core.csharp.ast.CSEnum;
import sharpen.xobotos.api.templates.EnumTemplate;
import sharpen.xobotos.generator.EnumBuilder;

@XStreamAlias(value = "modify-enum")
public class ModifyEnum extends ModifyMember<EnumDeclaration, CSEnum, EnumTemplate, EnumBuilder> {

	@Override
	protected Class<EnumDeclaration> getNodeType() {
		return EnumDeclaration.class;
	}

	@Override
	protected Class<EnumBuilder> getBuilderType() {
		return EnumBuilder.class;
	}

}
