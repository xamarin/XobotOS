package sharpen.xobotos.api.interop.glue;

import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

public class StructDefinition extends AbstractTypeDefinition {

	private final List<AbstractDefinition> _members;

	public StructDefinition(String name, Visibility visibility) {
		super(name, visibility);
		this._members = new ArrayList<AbstractDefinition>();
	}

	public void addMember(AbstractDefinition member) {
		_members.add(member);
	}

	public List<AbstractDefinition> getMembers() {
		return Collections.unmodifiableList(_members);
	}

	@Override
	public void accept(Visitor visitor) {
		visitor.visit(this);
	}

	@Override
	protected StructDeclaration createDeclaration() {
		return new StructDeclaration(this);
	}

}
