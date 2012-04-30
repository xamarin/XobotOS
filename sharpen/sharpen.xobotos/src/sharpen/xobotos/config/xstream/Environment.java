package sharpen.xobotos.config.xstream;

import sharpen.xobotos.config.ConfigurationException;

import java.util.HashMap;
import java.util.Map;

public final class Environment {
	private final Map<Class<?>, Object> _variables;

	public Environment(Object... variables) {
		_variables = new HashMap<Class<?>, Object>();
		for (final Object obj : variables) {
			Class<?> klass = obj.getClass();
			if (_variables.containsKey(klass))
				throw new ConfigurationException("Duplicate instance of class '%s'", klass);
			_variables.put(obj.getClass(), obj);
		}
	}

	public <T> T provide(Class<T> klass) {
		for (final Class<?> type : _variables.keySet()) {
			if (klass.isAssignableFrom(type))
				return klass.cast(_variables.get(type));
		}
		throw new ConfigurationException("No instance of class '%s' available in current environment", klass);
	}

	public Environment clone(Object... variables) {
		Environment e = new Environment();
		for (final Class<?> klass : _variables.keySet())
			e.add(_variables.get(klass), klass);
		for (final Object var : variables)
			e.add(var);
		return e;
	}

	protected void add(Object variable) {
		add(variable, variable.getClass());
	}

	protected <T> void add(Object variable, Class<T> klass) {
		if (_variables.containsKey(klass))
			throw new ConfigurationException(
					"Current environment already contains an instance of class '%s'", klass);
		_variables.put(klass, klass.cast(variable));
	}
}
