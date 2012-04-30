package sharpen.xobotos.config.xstream;


import com.thoughtworks.xstream.io.HierarchicalStreamReader;

import sharpen.core.Sharpen;
import sharpen.xobotos.config.ConfigurationException;
import sharpen.xobotos.config.annotations.AttributeReference;
import sharpen.xobotos.config.annotations.ReadIncludeFile;
import sharpen.xobotos.config.annotations.ReferenceById;
import sharpen.xobotos.config.annotations.RootContextReference;

import java.io.File;
import java.lang.reflect.Field;
import java.net.URI;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.Stack;
import java.util.logging.Level;

public final class RootContext<T extends IConfigurationFile> {
	private final URI _projectRoot;
	private final Class<T> _klass;
	private final MarshallingStrategy _strategy;
	private final Stack<Scope> _stack;
	private final Scope _rootScope;
	private final Environment _environment;
	private final List<ReferenceEntry> _referenceEntries;

	public URI getProjectRoot() {
		return _projectRoot;
	}

	public String getProjectPath(String fileName) {
		return _projectRoot.getPath() + File.separatorChar + fileName;
	}

	protected MarshallingStrategy getMarshallingStrategy() {
		return _strategy;
	}

	private RootContext(Environment environment, URI projectRoot, String fileName, Class<T> klass) {
		this._environment = environment;
		this._projectRoot = projectRoot;
		this._klass = klass;
		this._strategy = new MarshallingStrategy(this);

		_referenceEntries = new ArrayList<ReferenceEntry>();

		_stack = new Stack<Scope>();
		_rootScope = new Scope(null, null, fileName);
		_stack.push(_rootScope);
	}

	public <U> U my(Class<U> klass) {
		return _environment.provide(klass);
	}

	public static <U extends IConfigurationFile> U readConfigurationFile(URI projectRoot, String fileName,
			Class<U> klass, Environment environment) {
		return new RootContext<U>(environment, projectRoot, fileName, klass).read();
	}

	public static <U extends IConfigurationFile> U readConfigurationFile(URI projectRoot, String fileName,
			Class<U> klass, Object... variables) {
		Environment environment = new Environment(variables);
		return new RootContext<U>(environment, projectRoot, fileName, klass).read();
	}

	private T read() {
		T result = readFragment(_rootScope.getFileName(), _klass);
		resolveReferences();
		_environment.add(result);
		return result;
	}

	protected <U extends IConfigurationFragment> U readFragment(String fileName, Class<U> klass) {
		return XStreamUtils.readFragment(this, fileName, klass);
	}

	private ReferenceById getAnnotation(Class<?> klass) {
		while (klass != null) {
			ReferenceById annotation = klass.getAnnotation(ReferenceById.class);
			if (annotation != null)
				return annotation;
			klass = klass.getSuperclass();
		}
		return null;
	}

	private boolean hasAnnotation(Class<?> klass) {
		return getAnnotation(klass) != null;
	}

	protected Scope enterScope(Class<?> klass, String key) {
		if (!hasAnnotation(klass) || (key == null) || key.isEmpty())
			return null;

		Scope scope = new Scope(_stack.peek(), key, null);
		_stack.push(scope);
		return scope;
	}

	protected void leaveScope(Scope scope, Object parent, Class<?> klass, Object result) {
		if (result != null)
			postProcess(scope, parent, klass, result);

		if (scope != null) {
			_stack.peek().assign(result);
			_stack.pop();
		}
	}

	private Scope getRootScope() {
		return _rootScope;
	}

	private Scope getCurrentScope() {
		return _stack.peek();
	}

	private Scope getFileScope() {
		Scope scope = _stack.peek();
		while (!scope.isRoot() && !scope.parent().isFileScope())
			scope = scope.parent();
		return scope;
	}

	protected Object lookupReference(String reference) {
		Scope scope;
		if (reference.startsWith("/")) {
			scope = getRootScope();
			reference = reference.substring(1);
		} else if (reference.startsWith("$")) {
			scope = getCurrentScope();
			reference = reference.substring(1);
		} else
			scope = getFileScope();

		Object value = scope.lookup(reference);
		if (value == null) {
			Sharpen.Log(Level.SEVERE, "[%s]: invalid reference '%s'", scope, reference);
			throw new ConfigurationException("Invalid reference '%s'", reference);
		}
		return value;
	}

	static final class Scope {
		private final Scope _parent;
		private final String _name;

		private Object _value;
		private Map<String, Scope> _children = new HashMap<String, Scope>();
		private List<Scope> _fileScopes = new ArrayList<Scope>();

		private final String _fileName;

		public Scope parent() {
			return _parent;
		}

		public String name() {
			return _name;
		}

		public String getFileName() {
			return _fileName;
		}

		public boolean isRoot() {
			return _parent == null;
		}

		public boolean isFileScope() {
			return _fileName != null;
		}

		public Object value() {
			return _value;
		}

		public boolean containsKey(String key) {
			return _children.containsKey(key);
		}

		public Scope get(String key) {
			return _children.get(key);
		}

		protected void addChild(Scope child) {
			if (child.isFileScope())
				_fileScopes.add(child);
			else
				_children.put(child.name(), child);
		}

		protected void assign(Object value) {
			this._value = value;
		}

		public String getPath() {
			if (_parent == null)
				return "/";
			if (_fileName != null)
				return _parent.getPath();
			return _parent.getPath() + "/" + _name;
		}

		private Scope lookupScope(String key) {
			if (key.equals(".."))
				return _parent;
			if (_children.containsKey(key))
				return _children.get(key);

			for (final Scope child : _fileScopes) {
				if (child.containsKey(key))
					return child.get(key);
			}

			return null;
		}

		protected Object lookup(String reference) {
			String key;
			int pos = reference.indexOf('/');
			if (pos < 0)
				key = reference;
			else
				key = reference.substring(0, pos);

			Scope scope = lookupScope(key);
			if (scope == null)
				return null;

			if (pos < 0)
				return scope.value();

			String rest = reference.substring(pos + 1);
			return scope.lookup(rest);
		}

		protected Scope(Scope parent, String name, String fileName) {
			this._parent = parent;
			this._name = name;
			this._fileName = fileName;

			if (parent != null)
				parent.addChild(this);
		}

		@Override
		public String toString() {
			if (_parent == null)
				return String.format("RootScope[/:%s]", _fileName);
			else if (_fileName != null)
				return String.format("FileScope[%s:%s]", getPath(), _fileName);
			return String.format("Scope[%s:%s]", getPath(), _value != null ? _value.toString() : "null");
		}
	}

	private void postProcess(Scope scope, Object parent, Class<?> klass, Object result) {
		checkIncludeFile(klass, result);

		setRootContextField(klass, result);

		if (scope != null)
			setIdField(klass, result);
	}

	private void checkIncludeFile(Class<?> klass, Object obj) {
		while (klass != null) {
			ReadIncludeFile annotation = klass.getAnnotation(ReadIncludeFile.class);
			if (annotation == null) {
				klass = klass.getSuperclass();
				continue;
			}

			processIncludeFile(klass, annotation, obj);
			return;
		}
	}

	private void setRootContextField(Class<?> klass, Object obj) {
		while (klass != null) {
			RootContextReference annotation = klass.getAnnotation(RootContextReference.class);
			if (annotation == null) {
				klass = klass.getSuperclass();
				continue;
			}

			final Field field;
			try {
				field = klass.getDeclaredField(annotation.value());
				field.setAccessible(true);
				field.set(obj, this);
			} catch (Exception e) {
				throw new ConfigurationException("Cannot set root context field in '%s'", klass);
			}

			return;
		}
	}

	private void setIdField(Class<?> klass, Object obj) {
		while (klass != null) {
			ReferenceById annotation = klass.getAnnotation(ReferenceById.class);
			if (annotation == null) {
				klass = klass.getSuperclass();
				continue;
			}

			final String path = buildPath();

			final Field field;
			try {
				field = klass.getDeclaredField(annotation.value());
				field.setAccessible(true);
				field.set(obj, path);
			} catch (Exception e) {
				throw new ConfigurationException("Cannot set ID field in '%s'", klass);
			}

			return;
		}
	}

	private final static class ReferenceEntry {
		public final String attribute;
		public final Field field;
		public final Object instance;

		public ReferenceEntry(String attr, Field field, Object instance) {
			this.attribute = attr;
			this.field = field;
			this.instance = instance;
		}
	}

	protected void checkAttributeReferences(HierarchicalStreamReader reader, Scope scope, Class<?> klass, Object obj) {
		while (klass != null) {
			for (final Field field : klass.getDeclaredFields()) {
				AttributeReference annotation = field.getAnnotation(AttributeReference.class);
				if (annotation == null)
					continue;

				String attr = reader.getAttribute(annotation.value());
				if (attr == null)
					continue;

				if (attr.startsWith("/")) {
					_referenceEntries.add(new ReferenceEntry(attr, field, obj));
					continue;
				}

				Object reference = lookupReference(attr);
				try {
					field.setAccessible(true);
					field.set(obj, reference);
				} catch (Exception e) {
					throw new ConfigurationException("Cannot set field '%s'", field);
				}
			}

			klass = klass.getSuperclass();
		}
	}

	private void resolveReferences() {
		for (final ReferenceEntry entry : _referenceEntries) {
			Object reference = _rootScope.lookup(entry.attribute.substring(1));
			if (reference == null) {
				_rootScope.lookup(entry.attribute.substring(1));
				Sharpen.Log(Level.SEVERE, "Invalid reference '%s'", entry.attribute);
				throw new ConfigurationException("Invalid reference '%s'", entry.attribute);
			}

			try {
				entry.field.setAccessible(true);
				entry.field.set(entry.instance, reference);
			} catch (Exception e) {
				throw new ConfigurationException("Cannot set field '%s'", entry.field);
			}
		}
	}

	private String buildPath() {
		StringBuilder sb = new StringBuilder();
		for (int i = 0; i < _stack.size(); i++) {
			Scope scope = _stack.get(i);
			if (scope.name() == null)
				continue;
			if (sb.length() > 0)
				sb.append('/');
			sb.append(scope.name());
		}
		return sb.toString();
	}

	private void processIncludeFile(Class<?> klass, ReadIncludeFile annotation, Object include) {
		final String fileName;
		try {
			Field field = klass.getDeclaredField(annotation.fileNameField());
			field.setAccessible(true);
			fileName = (String)field.get(include);
		} catch (Exception e) {
			throw new ConfigurationException("Cannot get include file name in '%s'", klass);
		}

		for (final Scope scope : _stack) {
			if (scope.isFileScope() && scope.getFileName().equals(fileName))
				throw new ConfigurationException("Duplicate include file '%s'", fileName);
		}

		_stack.push(new Scope(_stack.peek(), null, fileName));
		IConfigurationFile contents = XStreamUtils.readFragment(this, fileName, annotation.fileType());
		_stack.pop();

		try {
			Field field = klass.getDeclaredField(annotation.contentsField());
			field.setAccessible(true);
			field.set(include, contents);
		} catch (Exception e) {
			throw new ConfigurationException("Cannot set include file contents field in '%s'", klass);
		}
	}

}
