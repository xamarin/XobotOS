/* Copyright (C) 2004 - 2010  Versant Inc.  http://www.db4o.com

This file is part of the sharpen open source java to c# translator.

sharpen is free software; you can redistribute it and/or modify it under
the terms of version 2 of the GNU General Public License as published
by the Free Software Foundation and as clarified by db4objects' GPL
interpretation policy, available at
http://www.db4o.com/about/company/legalpolicies/gplinterpretation/
Alternatively you can write to db4objects, Inc., 1900 S Norfolk Street,
Suite 350, San Mateo, CA 94403, USA.

sharpen is distributed in the hope that it will be useful, but WITHOUT ANY
WARRANTY; without even the implied warranty of MERCHANTABILITY or
FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License
for more details.

You should have received a copy of the GNU General Public License along
with this program; if not, write to the Free Software Foundation, Inc.,
59 Temple Place - Suite 330, Boston, MA  02111-1307, USA. */
package sharpen.core;

import java.lang.reflect.*;

public class ConfigurationFactory {

	public static final String DEFAULT_RUNTIME_TYPE_NAME = "Sharpen.Runtime";

	private ConfigurationFactory() {}

	public static Configuration defaultConfiguration() {
		return newConfiguration(null);
	}

	public static Configuration newConfiguration(String configurationClass) {
		return newConfiguration(configurationClass, DEFAULT_RUNTIME_TYPE_NAME);
	}

	public static Configuration newConfiguration(String configurationClass, String runtimeTypeName) {
		if (runtimeTypeName == null) {
			runtimeTypeName = DEFAULT_RUNTIME_TYPE_NAME;
		}

		if (configurationClass == null)
			throw new IllegalArgumentException("No configuration class specified.");

		try {
			Constructor<?> ctor = Class.forName(configurationClass).getDeclaredConstructor(String.class);
			ctor.setAccessible(true);
			return (Configuration) ctor.newInstance(runtimeTypeName);
		} catch (Exception e) {
			throw new IllegalArgumentException("Cannot instantiate configuration class: " + configurationClass,  e);
		}
	}
}
