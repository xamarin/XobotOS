/* Copyright (C) 2004 - 2008  Versant Inc.  http://www.db4o.com

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

import java.util.HashMap;
import java.util.Map;

public class NamingStrategy {

	public static final NamingStrategy DEFAULT = new NamingStrategy();

	static Map<String, String> _identifierMappings = new HashMap<String, String>();

	static {
		keywords("abstract", "as", "base", "bool", "break", "byte",
				"case", "catch", "char", "checked", "class",
				"const", "continue", "decimal", "default",
				"delegate", "do", "double", "else", "enum",
				"event", "explicit", "extern", "false",
				"finally", "fixed", "float", "for", "foreach",
				"goto", "if", "implicit", "in", "int",
				"interface", "internal", "is", "lock", "long",
				"namespace", "new", "null", "object",
				"operator", "out", "override", "params",
				"private", "protected", "public", "readonly",
				"ref", "return", "sbyte", "sealed", "short",
				"sizeof", "stackalloc", "static", "string",
				"struct", "switch", "this", "throw", "true",
				"try", "typeof", "uint", "ulong", "unchecked",
				"unsafe", "ushort", "using", "virtual", "void",
				"volatile", "while");
	};

	private static void keywords(String... values) {
		for (String value : values)
			keyword(value);
	}

	private static void keyword(String value) {
		mapIdentifier(value, "@" + value);
	}

	private static void mapIdentifier(String from, String to) {
		_identifierMappings.put(from, to);
	}

	private static String escapeIdentifier(String name) {
		return name.replace('$', '_');
	}

	public String identifier(String name) {
		String mapped = _identifierMappings.get(name);
		return escapeIdentifier(mapped != null ? mapped : name);
	}

	public String methodName(String name) {
		return namespacePart(name);
	}

	public String namespace(String name) {
		StringBuilder builder = new StringBuilder();
		for (String part : name.split("\\.")) {
			if (builder.length() > 0) builder.append('.');
			builder.append(namespacePart(part));
		}
		return builder.toString();
	}

	protected String namespacePart(String part) {
		return identifier(part);
	}
}
