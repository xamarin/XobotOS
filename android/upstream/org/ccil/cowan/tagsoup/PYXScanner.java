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
// This file is part of TagSoup.
// 
// This program is free software; you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation; either version 2 of the License, or
// (at your option) any later version.  You may also distribute
// and/or modify it under version 2.1 of the Academic Free License.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// 
// 
// PYX Scanner

package org.ccil.cowan.tagsoup;
import java.io.*;
import org.xml.sax.SAXException;

/**
A Scanner that accepts PYX format instead of HTML.
Useful primarily for debugging.
**/
public class PYXScanner implements Scanner {

        public void resetDocumentLocator(String publicid, String systemid) {
	// Need this method for interface compatibility, but note
	// that PyxScanner does not implement Locator.
        }

	public void scan(Reader r, ScanHandler h) throws IOException, SAXException {
		BufferedReader br = new BufferedReader(r);
		String s;
		char[] buff = null;
		boolean instag = false;
		while ((s = br.readLine()) != null) {
			int size = s.length();
			if (buff == null || buff.length < size) {
				buff = new char[size];
				}
			s.getChars(0, size, buff, 0);
			switch (buff[0]) {
			case '(':
				if (instag) {
					h.stagc(buff, 0, 0);
					instag = false;
					}
				h.gi(buff, 1, size - 1);
				instag = true;
				break;
			case ')':
				if (instag) {
					h.stagc(buff, 0, 0);
					instag = false;
					}
				h.etag(buff, 1, size - 1);
				break;
			case '?':
				if (instag) {
					h.stagc(buff, 0, 0);
					instag = false;
					}
				h.pi(buff, 1, size - 1);
				break;
			case 'A':
				int sp = s.indexOf(' ');
				h.aname(buff, 1, sp - 1);
				h.aval(buff, sp + 1, size - sp - 1);
				break;
			case '-':
				if (instag) {
					h.stagc(buff, 0, 0);
					instag = false;
					}
				if (s.equals("-\\n")) {
					buff[0] = '\n';
					h.pcdata(buff, 0, 1);
					}
				else {
					// FIXME:
					// Does not decode \t and \\ in input
					h.pcdata(buff, 1, size - 1);
					}
				break;
			case 'E':
				if (instag) {
					h.stagc(buff, 0, 0);
					instag = false;
					}
				h.entity(buff, 1, size - 1);
				break;
			default:
//				System.err.print("Gotcha ");
//				System.err.print(s);
//				System.err.print('\n');
				break;
				}
			}
		h.eof(buff, 0, 0);
		}

	public void startCDATA() { }

	public static void main(String[] argv) throws IOException, SAXException {
		Scanner s = new PYXScanner();
		Reader r = new InputStreamReader(System.in, "UTF-8");
		Writer w = new BufferedWriter(new OutputStreamWriter(System.out, "UTF-8"));
		s.scan(r, new PYXWriter(w));
		}
	}
