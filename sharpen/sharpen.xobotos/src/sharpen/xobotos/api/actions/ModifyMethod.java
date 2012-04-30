package sharpen.xobotos.api.actions;

import com.thoughtworks.xstream.annotations.XStreamAlias;

import sharpen.core.csharp.ast.CSMethod;
import sharpen.xobotos.api.templates.MethodTemplate;
import sharpen.xobotos.generator.MethodBuilder;

@XStreamAlias(value = "modify-method")
public class ModifyMethod extends ModifyMethodBase<CSMethod, MethodTemplate, MethodBuilder> {

	@Override
	protected Class<MethodBuilder> getBuilderType() {
		return MethodBuilder.class;
	}

}
