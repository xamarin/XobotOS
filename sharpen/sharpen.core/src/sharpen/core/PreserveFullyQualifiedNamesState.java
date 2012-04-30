/* Copyright (C) 2009  Versant Inc.   http://www.db4o.com */
package sharpen.core;

public interface PreserveFullyQualifiedNamesState {

	void using(boolean value, Runnable runnable);

	boolean value();

}
