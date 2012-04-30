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

/* Copyright (C) 2006 Versant Inc. http://www.db4o.com */

package sharpen.core.framework;

import org.eclipse.jdt.core.IJavaElement;
import org.eclipse.jdt.core.compiler.*;
import org.eclipse.jdt.core.dom.*;

import java.io.PrintStream;

/**
 * @exclude
 */
public class ASTUtility {
	
	public static String sourceInformation(ASTNode node) {
		
		final CompilationUnit compilationUnit = compilationUnitFor(node);
		return sourceInformation(compilationUnit, node);
	}

	public static String sourceInformation(final CompilationUnit compilationUnit, ASTNode node) {
		return compilationUnitPath(compilationUnit) + ":" + lineNumber(compilationUnit, node);
	}

	private static CompilationUnit compilationUnitFor(ASTNode node) {
		return ancestorOf(node, CompilationUnit.class);
	}

	public static <T extends ASTNode> T ancestorOf(ASTNode node, Class<T> ancestorType) {
		ASTNode parent = node.getParent();
		do {
			if (ancestorType.isInstance(parent))
				return (T) parent;
			parent = parent.getParent();
		} while (parent != null);
		
		throw new IllegalArgumentException(node + " has no ancestor of type " + ancestorType.getName());
	}

	public static String compilationUnitPath(CompilationUnit ast) {
		IJavaElement element = ast.getJavaElement();
		if (null == element) return "<unknown>";
		return element.getResource().getFullPath().toPortableString();
	}

	@SuppressWarnings("deprecation")
	public static int lineNumber(CompilationUnit ast, ASTNode node) {
		return ast.lineNumber(node.getStartPosition());
	}
	
	public static void checkForProblems(CompilationUnit ast, boolean throwOnError) {
		if (dumpProblemsToStdErr(ast) && throwOnError) {
			throw new RuntimeException("'" + compilationUnitPath(ast) + "' has errors, check stderr for details.");
		}
	}

	private static void dumpProblem(IProblem problem) {
		dumpProblem(System.err, problem);
	}

	public static void dumpProblem(PrintStream stream, IProblem problem) {
		stream.println(formatProblem(problem));
	}

	public static String formatProblem(IProblem problem) {
		return String.format("%s(%d): %s", new String (problem.getOriginatingFileName()),
				problem.getSourceLineNumber(), problem.getMessage());
	}

	private static boolean dumpProblemsToStdErr(CompilationUnit ast) {
		boolean hasErrors = false;
		for (IProblem problem : ast.getProblems()) {
			if (problem.isError()) {
				dumpProblem(problem);
				hasErrors = true;
			}
		}
		return hasErrors;
	}
}
