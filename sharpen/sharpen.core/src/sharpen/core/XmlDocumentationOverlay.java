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

import javax.xml.parsers.*;
import javax.xml.xpath.*;

import org.w3c.dom.*;
import org.w3c.dom.ls.*;

public class XmlDocumentationOverlay implements DocumentationOverlay {

	private Document _document;
	private LSSerializer _serializer;
	private XPath _xpath;

	public XmlDocumentationOverlay(String uri) {
		_document = loadXML(uri);
	}
	
	public String forType(String fullName) {
		return forXPath("/doc/type[@name='" + fullName + "']/doc");
	}
	
	public String forMember(String fullTypeName, String signature) {
		return forXPath("/doc/type[@name='" + fullTypeName + "']/member[@name='" + signature + "']/doc");
	}

	private String forXPath(String xpath) {
		Element found = selectElement(xpath);
		if (null == found) return null;
		return serializeContent(found);
	}

	private String serializeContent(Element e) {
		return stripFirstAndLastLines(serializer().writeToString(e));
	}

	private String stripFirstAndLastLines(String s) {
		int firstLineFeed = s.indexOf("\n");
		int lastLineFeed = s.lastIndexOf("\n");
		return s.substring(firstLineFeed+1, lastLineFeed);
	}

	private LSSerializer serializer() {
		if (null != _serializer) return _serializer;
		return _serializer = newSerializer();
	}

	private LSSerializer newSerializer() {
		LSSerializer serializer = ((DOMImplementationLS)_document.getImplementation()).createLSSerializer();
		serializer.getDomConfig().setParameter("xml-declaration", Boolean.FALSE);
		serializer.getDomConfig().setParameter("well-formed", Boolean.FALSE);
		return serializer;
	}

	protected Element selectElement(String xpath) {
		try {
			return (Element)xpath().evaluate(xpath, _document, XPathConstants.NODE);
		} catch (XPathExpressionException e) {
			throw new RuntimeException(e);
		}
	}

	private XPath xpath() {
		if (null != _xpath) return _xpath;
		return _xpath = newXPath();
	}

	private XPath newXPath() {
		return XPathFactory.newInstance().newXPath();
	}
	
	private static Document loadXML(String uri) {
		try {
			return builderFactory().newDocumentBuilder().parse(uri);
		} catch (Exception e) {
			throw new RuntimeException(e);
		}
	}

	private static DocumentBuilderFactory builderFactory() {
		DocumentBuilderFactory factory = DocumentBuilderFactory.newInstance();
		factory.setIgnoringComments(true);
		factory.setIgnoringElementContentWhitespace(true);
		factory.setNamespaceAware(true);
		factory.setXIncludeAware(true);
		return factory;
	}

}
