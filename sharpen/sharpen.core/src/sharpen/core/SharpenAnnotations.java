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

/* Copyright (C) 2004 - 2006 Versant Inc. http://www.db4o.com */

package sharpen.core;

import org.eclipse.jdt.core.dom.*;

import sharpen.core.framework.*;


public class SharpenAnnotations {
	
	static final String SHARPEN_ENUM = "@sharpen.enum";

	public static final String SHARPEN_RENAME = "@sharpen.rename";

	static final String SHARPEN_PUBLIC = "@sharpen.public";
	
	static final String SHARPEN_PRIVATE = "@sharpen.private";
	
	static final String SHARPEN_PROTECTED = "@sharpen.protected";
	
	static final String SHARPEN_INTERNAL = "@sharpen.internal";
	
	public static final String SHARPEN_EVENT = "@sharpen.event";	
	
	/**
	 * Marks the method as an event subscription method. Invocations
	 * to the method in the form <target>.method(<argument>) will be replaced by
	 * the c# event subscription idiom: <target> += <argument>
	 */
	static final String SHARPEN_EVENT_ADD = "@sharpen.event.add";
	
	/**
	 * Valid for event declaration only ({@link SHARPEN_EVENT}). Configures the method
	 * to be invoked whenever a new event handler is subscribed to the event.
	 */
	static final String SHARPEN_EVENT_ON_ADD = "@sharpen.event.onAdd";
	
	static final String SHARPEN_IF = "@sharpen.if";
	
	public static final String SHARPEN_PROPERTY = "@sharpen.property";
	
	public static final String SHARPEN_INDEXER = "@sharpen.indexer";
	
	static final String SHARPEN_IGNORE = "@sharpen.ignore";
	
	public static final String SHARPEN_IGNORE_EXTENDS = "@sharpen.ignore.extends";
	
	static final String SHARPEN_IGNORE_IMPLEMENTS = "@sharpen.ignore.implements";
	
	static final String SHARPEN_EXTENDS = "@sharpen.extends";
	
	static final String SHARPEN_PARTIAL = "@sharpen.partial";
	
	static final String SHARPEN_REMOVE = "@sharpen.remove";
	
	static final String SHARPEN_REMOVE_FIRST = "@sharpen.remove.first";
	
	static final String SHARPEN_UNWRAP = "@sharpen.unwrap";
	
	static final String SHARPEN_STRUCT = "@sharpen.struct";

	static final String SHARPEN_MACRO = "@sharpen.macro";
	
	static final String SHARPEN_NEW = "@sharpen.new";
	
	static final String SHARPEN_ATTRIBUTE = "@sharpen.attribute";

	public static boolean hasIgnoreAnnotation(BodyDeclaration node) {
		return JavadocUtility.containsJavadoc(node, SHARPEN_IGNORE);
	}	
}
