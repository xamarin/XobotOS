package sharpen.xobotos.api.interop.glue;

import java.util.Arrays;
import java.util.Collections;
import java.util.List;

public class TemplateFunctionReference extends Expression {

	private final String _name;
	private final List<Expression> _args;

	public TemplateFunctionReference(String name, Expression... args) {
		this._name = name;
		this._args = Collections.unmodifiableList(Arrays.asList(args));
	}

	@Override
	protected boolean needParens() {
		return false;
	}

	public String getName() {
		return _name;
	}

	public List<Expression> getArguments() {
		return _args;
	}

	@Override
	public void accept(Visitor visitor) {
		visitor.visit(this);
	}

}
