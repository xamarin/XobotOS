package sharpen.xobotos.api.interop.glue;

import java.util.Arrays;
import java.util.List;

public class ConstructorInvocation extends AbstractInvocation {

	private final AbstractTypeReference _type;

	public ConstructorInvocation(AbstractTypeReference type) {
		this._type = type;
	}

	public ConstructorInvocation(AbstractTypeReference type, List<Expression> args) {
		super(args);
		this._type = type;
	}

	public ConstructorInvocation(AbstractTypeReference type, Expression... args) {
		this(type, Arrays.asList(args));
	}

	public AbstractTypeReference getType() {
		return _type;
	}

	@Override
	public void accept(Visitor visitor) {
		visitor.visit(this);
	}

}
