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
// Interface to objects that translate InputStreams to Readers by auto-detection

package org.ccil.cowan.tagsoup;
import java.io.Reader;
import java.io.InputStream;

/**
Classes which accept an InputStream and provide a Reader which figures
out the encoding of the InputStream and reads characters from it should
conform to this interface.
@see java.io.InputStream
@see java.io.Reader
*/

public interface AutoDetector {

	/**
	Given an InputStream, return a suitable Reader that understands
	the presumed character encoding of that InputStream.
	If bytes are consumed from the InputStream in the process, they
	<i>must</i> be pushed back onto the InputStream so that they can be
	reinterpreted as characters.
	@param i The InputStream
	@return A Reader that reads from the InputStream
	*/

	public Reader autoDetectingReader(InputStream i);

	}
