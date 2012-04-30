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

package sharpen.core.io;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.StringReader;
import java.io.Writer;

public class IndentedWriter {

	private static final int MAX_COLUMNS = 80;

	String _lineSeparator = System.getProperty("line.separator");

	String _indentString = "\t";

	int _indentLevel = 0;

	private int _column;

	private Writer _delegate;

	private String _prefix;

	public IndentedWriter(Writer writer) {
		_delegate = writer;
	}

	public void indent() {
		++_indentLevel;
	}

	public void outdent() {
		--_indentLevel;
	}

	public void writeIndented(String s) {
		writeIndentation();
		write(s);
	}

	public void writeIndentedLine(String s) {
		writeIndentation();
		writeLine(s);

	}

	public void write(String s) {
		if (_column > MAX_COLUMNS) {
			writeLine();
			writeIndented(_indentString);
		}
		writeBlock(s);
	}

	public void writeSpace() {
		if (_column > MAX_COLUMNS) {
			writeLine();
			writeIndented(_indentString);
		} else {
			writeBlock(" ");
		}
	}

	/**
	 * write a block of text without checking columns.
	 */
	public void writeBlock(String s) {
		uncheckedWrite(s);
		_column += s.length();
	}

	public void writeLine() {
		writeLine("");
	}

	public void writeLine(String s) {
		try {
			_delegate.write(s);
			_delegate.write(_lineSeparator);
			_column = 0;
		} catch (IOException e) {
			throw new RuntimeException(e);
		}
	}

	private void uncheckedWrite(String s) {
		try {
			_delegate.write(s);
		} catch (IOException e) {
			throw new RuntimeException(e);
		}
	}

	public void writeIndentation() {
		for (int i = 0; i < _indentLevel; ++i) {
			uncheckedWrite(_indentString);
		}
		if (null != _prefix) {
			uncheckedWrite(_prefix);
		}
	}

	public Writer delegate() {
		return _delegate;
	}

	public void writeLines(String lines) {
		BufferedReader lineReader = new BufferedReader(new StringReader(lines));
		String line;
		try {
			while (null != (line = lineReader.readLine())) {
				if (line.trim().length() > 0) {
					writeIndentedLine(line);
				} else {
					writeLine();
				}
			}
		} catch (java.io.IOException x) {
			throw new RuntimeException(x);
		}
	}

	public void linePrefix(String prefix) {
		_prefix = prefix;
	}
}
