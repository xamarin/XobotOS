/* Copyright (C) 2009  Versant Inc.   http://www.db4o.com */

package sharpen.core.framework;

public class ByRef<T> {
	
	public T value;
	
	public ByRef() {
	}
	
	public ByRef(T initialValue) {
		value = initialValue;
	}

	public static <T> ByRef<T> newInstance() {
		return new ByRef();
	}

}
