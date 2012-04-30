/* Copyright (C) 2009  Versant Inc.  http://www.db4o.com */

package sharpen.core.csharp.ast;

import java.util.*;

public class CSMacro extends CSNode {
	
	private final String _template;
	private Map<String, Object> _variables = new HashMap<String, Object>();

	public CSMacro(String template) {
		_template = template;
    }

	@Override
    public void accept(CSVisitor visitor) {
		visitor.visit(this);
    }

	public String template() {
		return _template;
    }

	public void addVariable(String name, Object value) {
		if (_variables.containsKey(name)) {
			throw new IllegalArgumentException("Variable '" + name + "' already set!");
		}
		_variables.put(name, value);
    }

	public Object resolveVariable(String name) {
		if (!_variables.containsKey(name)) {
			throw new IllegalStateException("Variable '" + name + "' is not set!");
		}
		return _variables.get(name);
    }
}
