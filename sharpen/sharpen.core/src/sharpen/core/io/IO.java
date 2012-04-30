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
import java.io.File;
import java.io.FileReader;
import java.io.FileWriter;
import java.io.IOException;
import java.io.StringWriter;
import java.util.ArrayList;

public class IO {

	public static void writeFile(File file, String contents) throws IOException {
		FileWriter writer = new FileWriter(file);
		try {
			writer.append(contents);
		} finally {
			writer.close();
		}
	}
	
	public static String readFile(File file) throws IOException {
		FileReader reader = new FileReader(file);
		try {
			StringWriter writer = new StringWriter();
			char[] buffer = new char[32*1024];
			int read = 0;
			while ((read = reader.read(buffer)) > 0) {
				writer.write(buffer, 0, read);
			}
			return writer.toString();
		} finally {
			reader.close();
		}
	}

	public static void collectLines(ArrayList<String> lines, BufferedReader reader) throws IOException {
		String line = null;
		while (null != (line = reader.readLine())) {
			line = line.trim();
			if (line.length() > 0 && !line.startsWith("#")) {
				for (String arg : line.split("\\s+")) {
					lines.add(arg);
				}
			}
		}
	}

	public static String[] linesFromFile(String fname) {
		try {
			java.io.FileReader reader = new java.io.FileReader(fname);
			try {
				ArrayList<String> lines = new ArrayList<String>();
				collectLines(lines, new BufferedReader(reader));
				return lines.toArray(new String[lines.size()]);
			} finally {
				reader.close();
			}
		} catch (IOException e) {
			throw new RuntimeException(e);
		}
	}

}
