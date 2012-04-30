/* Copyright (C) 2009  Versant Inc.   http://www.db4o.com */
package sharpen.core.framework;

import java.util.HashMap;
import java.util.Map;

public class Environments {

	private static final DynamicVariable<Environment> _current = DynamicVariable.newInstance(null);

	public static <T> T my(Class<T> service) {
		final Environment environment = current();
		if (null == environment) {
			throw new IllegalStateException();
		}
		return environment.provide(service);
	}

	private static Environment current() {
		return _current.value();
	}

	public static void runWith(Environment environment, Runnable runnable) {
		_current.using(environment, runnable);
	}

	public static Environment newClosedEnvironment(final Object... bindings) {
		return new Environment() {

			public <T> T provide(Class<T> service) {
				for (Object binding : bindings) {
					if (service.isInstance(binding)) {
						return service.cast(binding);
					}
				}
				return null;
			}

		};
	}

	public static Environment newCachingEnvironmentFor(final Environment environment) {
		return new Environment() {
			private final Map<Class<?>, Object> _bindings = new HashMap<Class<?>, Object>();

			public <T> T provide(Class<T> service) {
				final Object existing = _bindings.get(service);
				if (null != existing) {
					return service.cast(existing);
				}
				final T binding = environment.provide(service);
				if (null == binding) {
					return null;
				}
				_bindings.put(service, binding);
				return binding;
			}
		};
	}

	public static Environment newConventionBasedEnvironment(Object... bindings) {
		return newCachingEnvironmentFor(compose(newClosedEnvironment(bindings), new ConventionBasedEnvironment()));
	}

	public static Environment newConventionBasedEnvironment() {
		return newCachingEnvironmentFor(new ConventionBasedEnvironment());
	}

	public static Environment addConventionBasedEnvironment(Object... bindings) {
		if (current() == null)
			return newConventionBasedEnvironment(bindings);
		return newCachingEnvironmentFor(compose(newClosedEnvironment(bindings), current(),
				new ConventionBasedEnvironment()));
	}

	public static Environment compose(final Environment... environments) {
		return new Environment() {
			public <T> T provide(Class<T> service) {
				for (Environment e : environments) {
					final T binding = e.provide(service);
					if (null != binding) {
						return binding;
					}
				}
				return null;
			}
		};
	}

	private static final class ConventionBasedEnvironment implements Environment {
		public <T> T provide(Class<T> service) {
			return resolve(service);
		}

		/**
		 * Resolves a service interface to its default implementation using the
		 * db4o namespace convention:
		 * 
		 *      interface foo.bar.Baz
		 *      default implementation foo.internal.bar.BazImpl
		 *
		 * @return the convention based type name for the requested service
		 */
		private <T> T resolve(Class<T> service) {
			final String className = defaultImplementationFor(service);
			final Object binding = createInstance(className);
			if (null == binding) {
				throw new IllegalArgumentException("Cant find default implementation for " + service.toString() + ": " + className);
			}
			return service.cast(binding);
		}

		private Object createInstance(String className) {
			try {
				return Class.forName(className).newInstance();
			} catch (InstantiationException e) {
				throw new IllegalStateException(e);
			} catch (IllegalAccessException e) {
				throw new IllegalStateException(e);
			} catch (ClassNotFoundException e) {
				throw new IllegalStateException(e);
			}
		}
	}

	static String defaultImplementationFor(Class service) {
		if (!service.isInterface()) {
			throw new IllegalArgumentException(service + " is not an interface.");
		}

		final String packageName = service.getPackage().getName();
		return packageName + ".internal." + (service.getSimpleName() + "Impl");
	}

}
