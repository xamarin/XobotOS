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
// The TagSoup command line UI

package org.ccil.cowan.tagsoup;
import java.util.Hashtable;
import java.util.Enumeration;
import java.io.*;
import java.net.URL;
import java.net.URLConnection;
import org.xml.sax.*;
import org.xml.sax.helpers.DefaultHandler;
import org.xml.sax.ext.LexicalHandler;


/**
The stand-alone TagSoup program.
**/
public class CommandLine {

	static Hashtable options = new Hashtable(); static {
		options.put("--nocdata", Boolean.FALSE); // CDATA elements are normal
		options.put("--files", Boolean.FALSE);	// process arguments as separate files
		options.put("--reuse", Boolean.FALSE);	// reuse a single Parser
		options.put("--nons", Boolean.FALSE);	// no namespaces
		options.put("--nobogons", Boolean.FALSE);  // suppress unknown elements
		options.put("--any", Boolean.FALSE);	// unknowns have ANY content model
		options.put("--emptybogons", Boolean.FALSE);	// unknowns have EMPTY content model
		options.put("--norootbogons", Boolean.FALSE);	// unknowns can't be the root
		options.put("--pyxin", Boolean.FALSE);	// input is PYX
		options.put("--lexical", Boolean.FALSE); // output comments
		options.put("--pyx", Boolean.FALSE);	// output is PYX
		options.put("--html", Boolean.FALSE);	// output is HTML
		options.put("--method=", Boolean.FALSE); // output method
		options.put("--doctype-public=", Boolean.FALSE); // override public id
		options.put("--doctype-system=", Boolean.FALSE); // override system id
		options.put("--output-encoding=", Boolean.FALSE); // output encoding
		options.put("--omit-xml-declaration", Boolean.FALSE); // omit XML decl
		options.put("--encoding=", Boolean.FALSE); // specify encoding
		options.put("--help", Boolean.FALSE); 	// display help
		options.put("--version", Boolean.FALSE);	// display version
		options.put("--nodefaults", Boolean.FALSE); // no default attrs
		options.put("--nocolons", Boolean.FALSE); // colon to underscore
		options.put("--norestart", Boolean.FALSE); // no restartable elements
		options.put("--ignorable", Boolean.FALSE);  // return ignorable whitespace
		}

	/**
	Main method.  Processes specified files or standard input.
	**/

	public static void main(String[] argv) throws IOException, SAXException {
		int optind = getopts(options, argv);
		if (hasOption(options, "--help")) {
			doHelp();
			return;
			}
		if (hasOption(options, "--version")) {
			System.err.println("TagSoup version 1.2");
			return;
			}
		if (argv.length == optind) {
			process("", System.out);
			}
		else if (hasOption(options, "--files")) {
			for (int i = optind; i < argv.length; i++) {
				String src = argv[i];
				String dst;
				int j = src.lastIndexOf('.');
				if (j == -1)
					dst = src + ".xhtml";
				else if (src.endsWith(".xhtml"))
					dst = src + "_";
				else
					dst = src.substring(0, j) + ".xhtml";
				System.err.println("src: " + src + " dst: " + dst);
				OutputStream os = new FileOutputStream(dst);
				process(src, os);
				}
			}
		else {
			for (int i = optind; i < argv.length; i++) {
				System.err.println("src: " + argv[i]);
				process(argv[i], System.out);
				}
			}
		}

	// Print the help message

	private static void doHelp() {
		System.err.print("usage: java -jar tagsoup-*.jar ");
		System.err.print(" [ ");
		boolean first = true;
		for (Enumeration e = options.keys(); e.hasMoreElements(); ) {
			if (!first) {
				System.err.print("| ");
				}
			first = false;
			String key = (String)(e.nextElement());
			System.err.print(key);
			if (key.endsWith("="))
				System.err.print("?");
				System.err.print(" ");
			}
		System.err.println("]*");
	}

	private static Parser theParser = null;
	private static HTMLSchema theSchema = null;
	private static String theOutputEncoding = null;

	// Process one source onto an output stream.

	private static void process(String src, OutputStream os)
			throws IOException, SAXException {
		XMLReader r;
		if (hasOption(options, "--reuse")) {
			if (theParser == null) theParser = new Parser();
			r = theParser;
			}
		else {
			r = new Parser();
			}
		theSchema = new HTMLSchema();
		r.setProperty(Parser.schemaProperty, theSchema);

		if (hasOption(options, "--nocdata")) {
			r.setFeature(Parser.CDATAElementsFeature, false);
			}

		if (hasOption(options, "--nons") || hasOption(options, "--html")) {
			r.setFeature(Parser.namespacesFeature, false);
			}

		if (hasOption(options, "--nobogons")) {
			r.setFeature(Parser.ignoreBogonsFeature, true);
			}

		if (hasOption(options, "--any")) {
			r.setFeature(Parser.bogonsEmptyFeature, false);
			}
		else if (hasOption(options, "--emptybogons")) {
			r.setFeature(Parser.bogonsEmptyFeature, true);
			}

		if (hasOption(options, "--norootbogons")) {
			r.setFeature(Parser.rootBogonsFeature, false);
			}

		if (hasOption(options, "--nodefaults")) {
			r.setFeature(Parser.defaultAttributesFeature, false);
			}
		if (hasOption(options, "--nocolons")) {
			r.setFeature(Parser.translateColonsFeature, true);
			}

		if (hasOption(options, "--norestart")) {
			r.setFeature(Parser.restartElementsFeature, false);
			}

		if (hasOption(options, "--ignorable")) {
			r.setFeature(Parser.ignorableWhitespaceFeature, true);
			}

		if (hasOption(options, "--pyxin")) {
			r.setProperty(Parser.scannerProperty, new PYXScanner());
			}

		Writer w;
		if (theOutputEncoding == null) {
			w = new OutputStreamWriter(os);
			}
		else {
			w = new OutputStreamWriter(os, theOutputEncoding);
			}
		ContentHandler h = chooseContentHandler(w);
		r.setContentHandler(h);
		if (hasOption(options, "--lexical") && h instanceof LexicalHandler) {
			r.setProperty(Parser.lexicalHandlerProperty, h);
			}
		InputSource s = new InputSource();
		if (src != "") {
			s.setSystemId(src);
			}
		else {
			s.setByteStream(System.in);
			}
		if (hasOption(options, "--encoding=")) {
//			System.out.println("%% Found --encoding");
			String encoding = (String)options.get("--encoding=");
			if (encoding != null) s.setEncoding(encoding);
			}
		r.parse(s);
		}

	// Pick a content handler to generate the desired format.

	private static ContentHandler chooseContentHandler(Writer w) {
		XMLWriter x;
		if (hasOption(options, "--pyx")) {
			return new PYXWriter(w);
			}

		x = new XMLWriter(w);
		if (hasOption(options, "--html")) {
			x.setOutputProperty(XMLWriter.METHOD, "html");
			x.setOutputProperty(XMLWriter.OMIT_XML_DECLARATION, "yes");
			}
		if (hasOption(options, "--method=")) {
			String method = (String)options.get("--method=");
			if (method != null) {
				x.setOutputProperty(XMLWriter.METHOD, method);
				}
			}
		if (hasOption(options, "--doctype-public=")) {
			String doctype_public = (String)options.get("--doctype-public=");
			if (doctype_public != null) {
				x.setOutputProperty(XMLWriter.DOCTYPE_PUBLIC, doctype_public);
				}
			}
		if (hasOption(options, "--doctype-system=")) {
			String doctype_system = (String)options.get("--doctype-system=");
			if (doctype_system != null) {
				x.setOutputProperty(XMLWriter.DOCTYPE_SYSTEM, doctype_system);
				}
			}
		if (hasOption(options, "--output-encoding=")) {
			theOutputEncoding = (String)options.get("--output-encoding=");
//			System.err.println("%%%% Output encoding is " + theOutputEncoding);
			if (theOutputEncoding != null) {
				x.setOutputProperty(XMLWriter.ENCODING, theOutputEncoding);
				}
			}
		if (hasOption(options, "--omit-xml-declaration")) {
			x.setOutputProperty(XMLWriter.OMIT_XML_DECLARATION, "yes");
			}
		x.setPrefix(theSchema.getURI(), "");
		return x;
		}

	// Options processing

	private static int getopts(Hashtable options, String[] argv) {
		int optind;
		for (optind = 0; optind < argv.length; optind++) {
			String arg = argv[optind];
			String value = null;
			if (arg.charAt(0) != '-') break;
			int eqsign = arg.indexOf('=');
			if (eqsign != -1) {
				value = arg.substring(eqsign + 1, arg.length());
				arg = arg.substring(0, eqsign + 1);
				}
			if (options.containsKey(arg)) {
				if (value == null) options.put(arg, Boolean.TRUE);
				else options.put(arg, value);
//				System.out.println("%% Parsed [" + arg + "]=[" + value + "]");
				}
			else {
				System.err.print("Unknown option ");
				System.err.println(arg);
				System.exit(1);
				}
			}
		return optind;
		}

	// Return true if an option exists.

	private static boolean hasOption(Hashtable options, String option) {
		if (Boolean.getBoolean(option)) return true;
		else if (options.get(option) != Boolean.FALSE) return true;
		return false;
		}

	}
