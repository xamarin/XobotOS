package sharpen.core.csharp.ast;

import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

public class CSParameterDeclaration extends CSVariableDeclaration {

	private List<CSAttribute> _attributes = new ArrayList<CSAttribute>();

	public CSParameterDeclaration(String name, CSTypeReferenceExpression type) {
		super(name, type);
	}

	public void addAttribute(CSAttribute attribute) {
		_attributes.add(attribute);
	}

	public boolean removeAttribute(String name) {
		for (CSAttribute at : _attributes) {
			if (at.name().equals(name)) {
				_attributes.remove(at);
				return true;
			}
		}
		return false;
	}

	public List<CSAttribute> attributes() {
		return Collections.unmodifiableList(_attributes);
	}

}
