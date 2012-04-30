package sharpen.core;

import org.eclipse.jdt.core.compiler.CategorizedProblem;
import org.eclipse.jdt.core.dom.ASTNode;
import org.eclipse.jdt.core.dom.CompilationUnit;

import sharpen.core.framework.ASTUtility;

public class SharpenProblem extends CategorizedProblem {

	CompilationUnit _ast;
	ASTNode _node;
	String _message;
	ProblemKind _kind;

	public enum ProblemKind {
		PARSING_ERROR,
		INTERNAL_ERROR,
		WARNING
	}

	public SharpenProblem(CompilationUnit ast, ASTNode node, ProblemKind kind, String message) {
		this._ast = ast;
		this._node = node;
		this._kind = kind;
		this._message = message;
	}

	public String[] getArguments() {
		return new String[0];
	}

	public int getID() {
		return ParsingError;
	}

	public String getMessage() {
		return _message;
	}

	public char[] getOriginatingFileName() {
		return ASTUtility.compilationUnitPath(_ast).toCharArray();
	}

	public int getSourceEnd() {
		return -1;
	}

	public int getSourceLineNumber() {
		if (_node != null)
			return ASTUtility.lineNumber(_ast, _node);
		else
			return -1;
	}

	public int getSourceStart() {
		return -1;
	}

	public boolean isError() {
		return _kind != ProblemKind.WARNING;
	}

	public boolean isWarning() {
		return _kind == ProblemKind.WARNING;
	}

	public void setSourceEnd(int arg0) {

	}

	public void setSourceLineNumber(int arg0) {
	}

	public void setSourceStart(int arg0) {
	}

	@Override
	public int getCategoryID() {
		if (_kind == ProblemKind.PARSING_ERROR)
			return CAT_SYNTAX;
		else
			return CAT_UNSPECIFIED;
	}

	@Override
	public String getMarkerType() {
		return Sharpen.PROBLEM_MARKER;
	}

}
