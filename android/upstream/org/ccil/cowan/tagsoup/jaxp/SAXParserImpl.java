// This file is part of TagSoup and is Copyright 2002-2008 by John Cowan.
//
// TagSoup is licensed under the Apache License,
// Version 2.0.  You may obtain a copy of this license at
// http://www.apache.org/licenses/LICENSE-2.0 .  You may also have
// additional legal rights not granted by this license.
//
// TagSoup is distributed in the hope that it will be useful, but
// unless required by applicable law or agreed to in writing, TagSoup
// is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS
// OF ANY KIND, either express or implied; not even the implied warranty
// of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.

package org.ccil.cowan.tagsoup.jaxp;

import java.io.*;
import java.util.*;
import javax.xml.parsers.*;

import org.xml.sax.*;

import org.ccil.cowan.tagsoup.Parser;

/**
 * This is a simple implementation of JAXP {@link SAXParser},
 * to allow easier integration of TagSoup with the default JDK 
 * xml processing stack.
 *
 * @author Tatu Saloranta (cowtowncoder@yahoo.com)
 */
public class SAXParserImpl
    extends SAXParser
{
    final org.ccil.cowan.tagsoup.Parser parser;

    protected SAXParserImpl() // used by factory, for prototypes
    {
        super();
        parser = new org.ccil.cowan.tagsoup.Parser();
    }

    public static SAXParserImpl newInstance(Map features)
        throws SAXException
    {
        SAXParserImpl parser = new SAXParserImpl();
        if (features != null) {
            Iterator it = features.entrySet().iterator();
            while (it.hasNext()) {
                Map.Entry entry = (Map.Entry) it.next();
                parser.setFeature((String) entry.getKey(), ((Boolean) entry.getValue()).booleanValue());
            }
        }
        return parser;
    }

    // // // JAXP API implementation:

    /**
     * To support SAX1 interface, we'll need to use an adapter.
     * @deprecated
     */
    public org.xml.sax.Parser getParser()
        throws SAXException
    {
        return new SAX1ParserAdapter(parser);
    }

    public XMLReader getXMLReader() { return parser; }
    
    public boolean isNamespaceAware()
    {
        try {
            return parser.getFeature(Parser.namespacesFeature);
        } catch (SAXException sex) { // should never happen... so:
            throw new RuntimeException(sex.getMessage());
        }
    }

    public boolean isValidating()
    {
        try {
            return parser.getFeature(Parser.validationFeature);
        } catch (SAXException sex) { // should never happen... so:
            throw new RuntimeException(sex.getMessage());
        }
    }

    public void setProperty(String name, Object value)
        throws SAXNotRecognizedException, SAXNotSupportedException
    {
        parser.setProperty(name, value);
    }

    public Object getProperty(String name)
        throws SAXNotRecognizedException, SAXNotSupportedException
    {
        return parser.getProperty(name);
    }

    // // // Additional convenience methods

    public void setFeature(String name, boolean value)
        throws SAXNotRecognizedException, SAXNotSupportedException
    {
        parser.setFeature(name, value);
    }

    public boolean getFeature(String name)
        throws SAXNotRecognizedException, SAXNotSupportedException
    {
        return parser.getFeature(name);
    }
}
