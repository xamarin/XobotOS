package sharpen.xobotos.api.interop.glue;

public class CompilationUnitHeader extends CompilationUnit {

	private final String _conditional;

	public CompilationUnitHeader(String name, String conditional) {
		super(name);
		this._conditional = conditional;
	}

	public String getConditional() {
		return _conditional;
	}

	@Override
	public void accept(Visitor visitor) {
		visitor.visit(this);
	}

}
