package sharpen.xobotos.api.interop.glue;


import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

public class CompilationUnit extends Node {

	private final String _name;
	private IncludeSection _includeSection;
	private final List<Method> _methods = new ArrayList<Method>();
	private final List<AbstractMember> _members = new ArrayList<AbstractMember>();

	public CompilationUnit(String name) {
		this._name = name;
		this._includeSection = new IncludeSection();
	}

	public String getName() {
		return _name;
	}

	public IncludeSection getIncludeSection() {
		return _includeSection;
	}

	public void setIncludeSection(IncludeSection section) {
		this._includeSection = section;
	}

	public void addMethod(Method method) {
		if (method == null)
			throw new NullPointerException();
		_methods.add(method);
	}

	public List<Method> getMethods() {
		return Collections.unmodifiableList(_methods);
	}

	public void addMember(AbstractMember member) {
		if (member == null)
			throw new NullPointerException();
		_members.add(member);
	}

	public List<AbstractMember> getMembers() {
		return Collections.unmodifiableList(_members);
	}

	@Override
	public void accept(Visitor visitor) {
		visitor.visit(this);
	}

}
