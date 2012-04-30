package sharpen.xobotos.api.interop.glue;

import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

public abstract class AbstractInvocation extends StatementExpression {

	private final List<Expression> _args;

	protected AbstractInvocation() {
		this._args = new ArrayList<Expression>();
	}

	protected AbstractInvocation(List<Expression> args) {
		this._args = Collections.unmodifiableList(args);
	}

	@Override
	protected boolean needParens() {
		return true;
	}

	public void addArgument(Expression arg) {
		_args.add(arg);
	}

	public List<Expression> getArguments() {
		return Collections.unmodifiableList(_args);
	}

}
