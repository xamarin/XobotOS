package sharpen.xobotos.api.interop.glue;

public class IncludeDirective extends Node {

	private final String _name;
	private final boolean _search;

	public IncludeDirective(String name, boolean search) {
		this._name = name;
		this._search = search;
	}

	public String getName() {
		return _name;
	}

	public boolean searchPath() {
		return _search;
	}

	@Override
	public void accept(Visitor visitor) {
		visitor.visit(this);
	}

}
