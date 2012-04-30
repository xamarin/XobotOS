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

import org.eclipse.core.resources.IMarker;
import org.eclipse.core.resources.IResource;
import org.eclipse.core.runtime.CoreException;
import org.eclipse.jdt.core.ICompilationUnit;
import org.eclipse.jdt.core.compiler.IProblem;
import org.eclipse.jdt.core.dom.ASTNode;
import org.eclipse.jdt.core.dom.CompilationUnit;
import org.eclipse.jdt.core.dom.IBinding;

import sharpen.core.csharp.CSharpPrinter;
import sharpen.core.csharp.ast.CSCompilationUnit;
import sharpen.core.framework.*;

import java.io.IOException;
import java.io.Writer;
import java.util.HashMap;
import java.util.Map;
import java.util.logging.Level;

public class SharpenConversion {

	private CSharpPrinter _printer;
	protected ICompilationUnit _source;
	protected Writer _writer;
	protected final Configuration _configuration;
	protected boolean _foundErrors;
	private ASTResolver _resolver = new ASTResolver() {
		public ASTNode findDeclaringNode(IBinding binding) {
			return null;
		}
	};
	private CSharpDriver _driver;

	public SharpenConversion(Configuration configuration) {
		_configuration = configuration;
	}

	public void setDriver(CSharpDriver driver) {
		_driver = driver;
	}

	public void setSource(ICompilationUnit source) {
		_source = source;
	}

	public void setTargetWriter(Writer writer) {
		_writer = writer;
	}

	public Writer getTargetWriter() {
		return _writer;
	}

	public void setPrinter(CSharpPrinter printer) {
		_printer = printer;
	}

	private CSharpPrinter getPrinter() {
		if (null == _printer) {
			_printer = new CSharpPrinter();
		}
		return _printer;
	}

	public Configuration getConfiguration() {
		return _configuration;
	}

	protected void print(CSCompilationUnit unit) {
		printHeader();
		printTree(unit);
	}

	private void printHeader() {
		try {
			_writer.write(_configuration.header());
		} catch (IOException x) {
			throw new RuntimeException(x);
		}
	}

	private void printTree(CSCompilationUnit unit) {
		CSharpPrinter printer = getPrinter();
		printer.setWriter(_writer);
		printer.print(unit);
	}

	protected boolean checkForProblems(CompilationUnitPair pair) {
		boolean hasErrors = false;
		for (IProblem problem : pair.ast.getProblems()) {
			Sharpen.Log(Level.SEVERE, ASTUtility.formatProblem(problem));
			if (createProblemMarkers())
				createProblemMarker(problem);
			else
				ASTUtility.dumpProblem(System.err, problem);
			if (problem.isError())
				hasErrors = true;
		}
		for (IProblem problem : pair.getProblems()) {
			Sharpen.Log(Level.SEVERE, ASTUtility.formatProblem(problem));
			if (createProblemMarkers())
				createProblemMarker(problem);
			else
				ASTUtility.dumpProblem(System.err, problem);
			if (problem.isError())
				hasErrors = true;
		}

		return hasErrors;
	}

	protected void convert(final CompilationUnitPair pair, final CSCompilationUnit compilationUnit) {
		final Environment environment = Environments.addConventionBasedEnvironment(_driver, pair, pair.ast,
				_configuration, _resolver, compilationUnit);
		Environments.runWith(environment, new Runnable() { public void run() {
			CSharpBuilder builder = new CSharpBuilder();
			builder.run();
			for (IProblem problem : pair.getProblems()) {
				createProblemMarker(problem);
			}
		}});
	}

	protected void prepareForConversion(final CompilationUnit ast) {
		deleteProblemMarkers();
		WarningHandler warningHandler = new WarningHandler() {
			@Override
			public void warning(ASTNode node, String message) {
				createProblemMarker(ast, node, message, false);
			}
		};
		_configuration.setWarningHandler(warningHandler);
	}

	private void deleteProblemMarkers() {
		if (createProblemMarkers()) {
			try {
				_source.getCorrespondingResource().deleteMarkers(Sharpen.PROBLEM_MARKER, false, IResource.DEPTH_ONE);
			} catch (CoreException e) {
				e.printStackTrace();
			}
		}
	}

	protected void createProblemMarker(CompilationUnit ast, ASTNode node, String message, boolean isError) {
		if (!createProblemMarkers()) {
			return;
		}
		try {
			IMarker marker = _source.getCorrespondingResource().createMarker(Sharpen.PROBLEM_MARKER);
			Map<String, Object> attributes = new HashMap<String, Object>();
			attributes.put(IMarker.MESSAGE, message);
			if (node != null) {
				attributes.put(IMarker.CHAR_START, new Integer(node.getStartPosition()));
				attributes.put(IMarker.CHAR_END, new Integer(node.getStartPosition() + node.getLength()));
				attributes.put(IMarker.LINE_NUMBER, ASTUtility.lineNumber(ast, node));
			}
			attributes.put(IMarker.TRANSIENT, Boolean.TRUE);
			attributes.put(IMarker.SEVERITY, isError ? IMarker.SEVERITY_ERROR : IMarker.SEVERITY_WARNING);
			marker.setAttributes(attributes);
		} catch (CoreException e) {
			e.printStackTrace();
		}
	}

	private void createProblemMarker(IProblem problem) {
		if (!createProblemMarkers())
			return;
		try {
			IMarker marker = _source.getCorrespondingResource().createMarker(Sharpen.PROBLEM_MARKER);
			Map<String, Object> attributes = new HashMap<String, Object>();
			attributes.put(IMarker.MESSAGE, problem.getMessage());
			if (problem.getSourceLineNumber() > 0) {
				attributes.put(IMarker.CHAR_START, new Integer(problem.getSourceStart()));
				attributes.put(IMarker.CHAR_END, new Integer(problem.getSourceEnd()));
				attributes.put(IMarker.LINE_NUMBER, problem.getSourceLineNumber());
			}
			attributes.put(IMarker.TRANSIENT, Boolean.TRUE);
			attributes.put(IMarker.SEVERITY, problem.isError() ? IMarker.SEVERITY_ERROR : IMarker.SEVERITY_WARNING);
			marker.setAttributes(attributes);
			if (problem.isError())
				_foundErrors = true;
		} catch (CoreException e) {
			e.printStackTrace();
		}
	}

	private boolean createProblemMarkers() {
		return _configuration.createProblemMarkers();
	}

	public boolean foundErrors() {
		return _foundErrors;
	}

	public ASTResolver getASTResolver() {
		return _resolver;
	}

	public void setASTResolver(ASTResolver resolver) {
		_resolver = resolver;
	}
}