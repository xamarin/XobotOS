package sharpen.xobotos.api.actions;

import com.thoughtworks.xstream.annotations.XStreamAlias;

import org.eclipse.jdt.core.dom.MethodDeclaration;

import sharpen.core.csharp.ast.CSProperty;
import sharpen.xobotos.api.templates.PropertyTemplate;
import sharpen.xobotos.generator.PropertyBuilder;

@XStreamAlias(value = "modify-property")
public class ModifyProperty extends ModifyMember<MethodDeclaration, CSProperty, PropertyTemplate, PropertyBuilder> {

	@Override
	protected Class<MethodDeclaration> getNodeType() {
		return MethodDeclaration.class;
	}

	@Override
	protected Class<PropertyBuilder> getBuilderType() {
		return PropertyBuilder.class;
	}

}
