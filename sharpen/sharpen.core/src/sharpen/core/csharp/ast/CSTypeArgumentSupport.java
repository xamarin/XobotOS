package sharpen.core.csharp.ast;

import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

public class CSTypeArgumentSupport implements CSTypeArgumentProvider {

	private List<CSTypeReferenceExpression> _arguments;

	public void addTypeArgument(CSTypeReferenceExpression typeArgument) {
		if (null == _arguments) {
			_arguments = new ArrayList<CSTypeReferenceExpression>();
		}
		_arguments.add(typeArgument);
	}

	public List<CSTypeReferenceExpression> typeArguments() {
		if (null == _arguments) {
			return Collections.emptyList();
		}
		return Collections.unmodifiableList(_arguments);
	}

	public int size() {
		return _arguments != null ? _arguments.size() : 0;
	}

}
