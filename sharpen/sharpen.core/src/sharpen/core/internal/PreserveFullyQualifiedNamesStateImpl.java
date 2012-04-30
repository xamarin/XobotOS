/* Copyright (C) 2009  Versant Inc.   http://www.db4o.com */
package sharpen.core.internal;

import sharpen.core.*;
import sharpen.core.framework.*;

public class PreserveFullyQualifiedNamesStateImpl implements PreserveFullyQualifiedNamesState {

	public void using(boolean value, Runnable runnable) {
		_value.using(value, runnable);
	}

	public boolean value() {
		return _value.value();
	}

	private final DynamicVariable<Boolean> _value = DynamicVariable.newInstance(Boolean.FALSE);
}
