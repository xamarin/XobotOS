package sharpen.xobotos.api.interop.glue;

import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

public abstract class AbstractDeclaration<T extends AbstractDefinition> extends AbstractMember {

	private final T _definition;

	protected AbstractDeclaration(T definition) {
		super(definition.getVisibility());
		this._definition = definition;
	}

	public T getDefinition() {
		return _definition;
	}

	protected List<AbstractMember> createDeclarationList(List<AbstractMember> list) {
		List<AbstractMember> retval = new ArrayList<AbstractMember>();
		for (AbstractMember member : list) {
			if (member instanceof AbstractDefinition)
				retval.add(((AbstractDefinition) member).getDeclaration());
			else
				retval.add(member);
		}
		return Collections.unmodifiableList(retval);
	}

}
