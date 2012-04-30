package sharpen.xobotos.api.actions;

import com.thoughtworks.xstream.annotations.XStreamAlias;
import com.thoughtworks.xstream.annotations.XStreamImplicit;

import sharpen.core.csharp.ast.CSTypeDeclaration;
import sharpen.xobotos.generator.ITypeBuilder;

import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

@XStreamAlias(value = "action-list")
public class ActionList extends AbstractAction {

	@XStreamImplicit(itemFieldName = "action")
	private List<AbstractAction> _actions;

	public List<AbstractAction> getActions() {
		return Collections.unmodifiableList(_actions);
	}

	private Object readResolve() {
		if (_actions == null)
			_actions = new ArrayList<AbstractAction>();
		return this;
	}

	@Override
	public void apply(ITypeBuilder builder, CSTypeDeclaration type) {
		for (final AbstractAction action : _actions)
			action.apply(builder, type);
	}

}
