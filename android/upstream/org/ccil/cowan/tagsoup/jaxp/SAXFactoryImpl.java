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

import java.util.*;
import javax.xml.parsers.*;

import org.xml.sax.*;

/**
 * This is a simple implementation of JAXP {@link SAXParserFactory},
 * to allow easier integration of TagSoup with the default JDK 
 * xml processing stack.
 *
 * @author Tatu Saloranta (cowtowncoder@yahoo.com)
 */
public class SAXFactoryImpl
    extends SAXParserFactory
{
    /**
     * The easiest way to test validity of features to set is to use
     * a prototype object. Currently this is actually not a real prototype,
     * in the sense that the configuration is actually passed separately
     * (as opposed to instantiating new readers from this prototype), but
     * this could be changed in future, if TagSoup parser object allowed
     * cloning.
     */
    private SAXParserImpl prototypeParser = null;

    /**
     * This Map contains explicitly set features that can be succesfully
     * set for XMLReader instances. Temporary storage is needed due to
     * JAXP design: multiple readers can be instantiated from a single
     * factory, and settings can be changed between instantiations.
     *<p>
     * Note that we wouldn't need this map if we could create instances
     * directly using the prototype instance.
     */
    private HashMap features = null;

    public SAXFactoryImpl()
    {
        super();
    }

    // // // JAXP API implementation:

    /**
     * Creates a new instance of <code>SAXParser</code> using the currently
     * configured factory parameters.
     */
    public SAXParser newSAXParser()
        throws ParserConfigurationException
    {
        try {
            return SAXParserImpl.newInstance(features);
        } catch (SAXException se) {
            // Translate to ParserConfigurationException
            throw new ParserConfigurationException(se.getMessage());
        }
    }

    /**
     * Defines that the specified feature is to enabled/disabled (as
     * per second argument) on reader instances created by this 
     * factory.
     */
    public void setFeature(String name, boolean value)
        throws ParserConfigurationException, SAXNotRecognizedException, 
		SAXNotSupportedException
    {
        // First, let's see if it's a valid call
        getPrototype().setFeature(name, value);

        // If not, exception was thrown: so we are good now:
        if (features == null) {
            // Let's retain the ordering as well
            features = new LinkedHashMap();
        }
        features.put(name, value ? Boolean.TRUE : Boolean.FALSE);
    }

    /**
     * Returns whether the specified property will be enabled or disabled
     * on reader instances constructed by this factory.
     */
    public boolean getFeature(String name)
        throws ParserConfigurationException, SAXNotRecognizedException,
		SAXNotSupportedException
    {
        return getPrototype().getFeature(name);
    }

    // // // Internal methods

    private SAXParserImpl getPrototype()
    {
        if (prototypeParser == null) {
            prototypeParser = new SAXParserImpl();
        }
        return prototypeParser;
    }
}
