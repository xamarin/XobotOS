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
// 
// 
// Scanner

package org.ccil.cowan.tagsoup;
import java.io.IOException;
import java.io.Reader;
import org.xml.sax.SAXException;

/**
An interface allowing Parser to invoke scanners.
**/

public interface Scanner {

	/**
	Invoke a scanner.
	@param r A source of characters to scan
	@param h A ScanHandler to report events to
	**/

	public void scan(Reader r, ScanHandler h) throws IOException, SAXException;

	/**
	Reset the embedded locator.
	@param publicid The publicid of the source
	@param systemid The systemid of the source
	**/

	public void resetDocumentLocator(String publicid, String systemid);

	/**
	Signal to the scanner to start CDATA content mode.
	**/

	public void startCDATA();

	}
