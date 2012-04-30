/* Copyright (C) 2009   Versant Inc.   http://www.db4o.com */

package sharpen.core.framework;

public interface Environment {

	<T> T provide(Class<T> service);

}
