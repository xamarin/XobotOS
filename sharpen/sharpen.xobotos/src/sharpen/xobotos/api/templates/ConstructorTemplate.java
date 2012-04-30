package sharpen.xobotos.api.templates;

import com.thoughtworks.xstream.annotations.XStreamAlias;
import com.thoughtworks.xstream.annotations.XStreamOmitField;

import sharpen.core.csharp.ast.CSConstructor;
import sharpen.xobotos.api.actions.ModifyConstructor;

@XStreamAlias(value="constructor")
public class ConstructorTemplate extends AbstractMethodTemplate<CSConstructor> {

	@XStreamOmitField
	public final static ConstructorTemplate DEFAULT = new ConstructorTemplate();

	@XStreamAlias("modify")
	private ModifyConstructor _modifyConstructor;

	@Override
	public ModifyConstructor getModificationAction() {
		return _modifyConstructor;
	}

}
