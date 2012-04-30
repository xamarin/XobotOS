package sharpen.xobotos.api.actions;

import com.thoughtworks.xstream.annotations.XStreamAlias;

import org.eclipse.jdt.core.dom.TypeDeclaration;

import sharpen.core.csharp.ast.CSTypeDeclaration;
import sharpen.xobotos.api.templates.TypeTemplate;
import sharpen.xobotos.generator.TypeBuilder;

@XStreamAlias(value = "modify-type")
public class ModifyType extends ModifyMember<TypeDeclaration, CSTypeDeclaration, TypeTemplate, TypeBuilder> {

	@Override
	protected Class<TypeDeclaration> getNodeType() {
		return TypeDeclaration.class;
	}

	@Override
	protected Class<TypeBuilder> getBuilderType() {
		return TypeBuilder.class;
	}

}
