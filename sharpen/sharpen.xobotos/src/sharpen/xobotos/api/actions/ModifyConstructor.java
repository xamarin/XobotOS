package sharpen.xobotos.api.actions;

import com.thoughtworks.xstream.annotations.XStreamAlias;

import org.eclipse.jdt.core.dom.MethodDeclaration;

import sharpen.core.csharp.ast.CSConstructor;
import sharpen.xobotos.api.templates.ConstructorTemplate;
import sharpen.xobotos.generator.ConstructorBuilder;

@XStreamAlias(value = "modify-constructor")
public class ModifyConstructor extends ModifyMethodBase<CSConstructor, ConstructorTemplate, ConstructorBuilder> {

	@XStreamAlias(value = "remove-chained-invocation")
	private boolean _removeChainedInvocation;

	@Override
	protected Class<ConstructorBuilder> getBuilderType() {
		return ConstructorBuilder.class;
	}

	@Override
	public void modify(ConstructorBuilder builder, MethodDeclaration node, CSConstructor ctor) {
		if (_removeChainedInvocation)
			ctor.chainedConstructorInvocation(null);
		super.modify(builder, node, ctor);
	}

}
