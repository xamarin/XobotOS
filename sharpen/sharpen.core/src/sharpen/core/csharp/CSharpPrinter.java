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

package sharpen.core.csharp;

import sharpen.core.csharp.ast.*;
import sharpen.core.io.IndentedWriter;

import java.io.Writer;
import java.util.ArrayList;
import java.util.Collections;
import java.util.Comparator;
import java.util.Iterator;
import java.util.List;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class CSharpPrinter extends CSVisitor {

	protected IndentedWriter _writer;
	protected CSTypeDeclaration _currentType;
	private int _lastPrintedCommentIndex;
	private List<CSLineComment> _comments;

	public CSharpPrinter() {
	}

	public void setWriter(Writer writer) {
		_writer = new IndentedWriter(writer);
	}

	public void print(CSCompilationUnit node) {
		_lastPrintedCommentIndex = 0;
		_comments = node.comments();
		try {
			node.accept(this);
		} finally {
			_currentType = null;
			_comments = null;
		}
	}

	private List<CSUsing> printableUsingList(Iterable<CSUsing> usings) {
		List<CSUsing> list = new ArrayList<CSUsing>();
		for (CSUsing using : usings) {
			list.add(using);
		}
		Collections.sort(list, new Comparator<CSUsing>() {
			public int compare(CSUsing a, CSUsing b) {
				boolean ia = a.namespace().startsWith("System");
				boolean ib = b.namespace().startsWith("System");

				if (ia && ib)
					return a.namespace().compareTo(b.namespace());
				else if (ia)
					return -1;
				else if (ib)
					return 1;
				else
					return a.namespace().compareTo(b.namespace());
			}
		});
		return list;
	}

	static final Pattern META_VARIABLE_PATTERN = Pattern.compile("\\$(\\w+)");

	@Override
	public void visit(CSMacroExpression node) {
		node.macro().accept(this);
	}

	@Override
	public void visit(CSMacroTypeReference node) {
		node.macro().accept(this);
	}

	@Override
	public void visit(CSMacro node) {
		final String template = node.template();
		final Matcher matcher = META_VARIABLE_PATTERN.matcher(template);
		int last = 0;
		while (matcher.find()) {
			write(template.substring(last, matcher.start()));

			Object value = node.resolveVariable(matcher.group(1));
			// value is either a single node or a list of nodes
			if (value instanceof CSNode) {
				((CSNode) value).accept(this);
			} else {
				writeCommaSeparatedList((Iterable<CSNode>) value);
			}

			last = matcher.end();
		}
		write(template.substring(last));
	}

	@Override
	public void visit(CSCompilationUnit node) {
		beginEnclosingIfDefs(node);
		List<CSUsing> usings = printableUsingList(node.usings());
		for (CSUsing using : usings) {
			using.accept(this);
		}

		if (usings.size() > 0)
			_writer.writeLine();

		if (null != node.namespace()) {
			writeLine("namespace " + node.namespace());
			enterBody();
		}
		writeLineSeparatedList(node.types());
		if (null != node.namespace()) {
			leaveBody();
		}
		endEnclosingIfDefs(node);
	}

	@Override
	public void visit(CSRemovedExpression node) {
		throw new IllegalStateException("Unexpected removal of expression: " + node.toString());
	}

	@Override
	public void visit(CSUsing node) {
		writeLine("using " + node.namespace() + ";");
	}

	@Override
	public void visit(CSClass node) {
		writeType(node);
	}

	@Override
	public void visit(CSEnum node) {
		writeMemberHeader(node);
		write("enum " + node.name());
		if (node.baseType() != null) {
			write(" : ");
			node.baseType().accept(this);
		}
		writeLine();
		enterBody();
		writeSeparatedList(node.values(), new Closure() {
			public void execute() {
				writeLine(",");
			}
		});
		writeLine();
		leaveBody();
	}

	@Override
	public void visit(CSEnumValue node) {
		printPrecedingComments(node);
		writeDoc(node);
		writeIndented(node.name());
		if (node.initializer() != null) {
			write(" = ");
			node.initializer().accept(this);
		}
	}

	@Override
	public void visit(CSStruct node) {
		CSStructLayout layout = node.getStructLayout();
		if (layout != null) {
			writeStructLayout(layout);
		}
		writeType(node);
	}

	private void writeStructLayout(CSStructLayout layout) {
		writeIndented("[StructLayout(");
		CSStructLayout.LayoutKind kind = layout.getLayoutKind();
		if (kind != null) {
			write("LayoutKind.");
			switch (kind) {
			case Sequential:
				write("Sequential");
				break;
			case Explicit:
				write("Explicit");
				break;
			default:
				write("Auto");
				break;
			}
		}
		writeLine(")]");
	}

	@Override
	public void visit(CSInterface node) {
		writeType(node);
	}

	@Override
	public void visit(CSTypeParameter node) {
		write(node.name());
	}

	@Override
	public void visit(final CSArrayTypeReference node) {
		node.elementType().accept(this);
		for (int i = 0; i < node.dimensions(); ++i) {
			write("[]");
		}
	}

	@Override
	public void visit(CSTypeReference node) {
		write(node.typeName());
		writeTypeArguments(node);
	}

	@Override
	public void visit(CSNestedTypeReference node) {
		node.getParent().accept(this);
		write(".");
		node.getChild().accept(this);
	}

	@Override
	public void visit(CSNullableTypeReference node) {
		node.getElementType().accept(this);
		write("?");
	}

	@Override
	public void visit(CSByRefTypeReference node) {
		if (node.isOut())
			write("out ");
		else
			write("ref ");
		node.getElementType().accept(this);
	}

	private void writeTypeArguments(CSTypeArgumentProvider node) {
		final List<CSTypeReferenceExpression> typeArgs = node.typeArguments();
		if (!typeArgs.isEmpty()) {
			writeGenericParameters(typeArgs);
		}
	}

	@Override
	public void visit(CSDelegate node) {
		writeMemberHeader(node);
		write("delegate void ");
		write(node.name());
		writeParameterList(node.parameters());
		writeLine(";");
	}

	private void writeTypeHeader(CSTypeDeclaration node) {
		writeMemberHeader(node);
		if (node.isInterface()) {
			if (node.partial())
				_writer.write("partial ");
			write("interface " + node.name());
		} else if (node instanceof CSClass) {
			CSClass classNode = (CSClass) node;
			write(classModifier(classNode.modifier()));
			if (node.partial())
				_writer.write("partial ");
			write("class " + node.name());
		} else {
			write("struct " + node.name());
		}
		writeTypeParameters(node);
		writeBaseTypes(node);
		writeTypeParameterConstraints(node.typeParameters());
	}

	private void writeMemberHeader(CSTypeDeclaration node) {
		writeAttributes(node);
		writeVisibility(node);
	}

	private void writeTypeParameters(CSTypeParameterProvider node) {
		final List<CSTypeParameter> parameters = node.typeParameters();
		if (parameters.isEmpty())
			return;
		writeGenericParameters(parameters);
	}

	private void writeTypeParameterConstraints(List<CSTypeParameter> parameters) {
		if (parameters.isEmpty())
			return;
		for (CSTypeParameter tp : parameters) {
			if (tp.superClass() != null) {
				write(" where ");
				write(tp.name() + ":");
				tp.superClass().accept(this);
			}
		}
	}

	private <T extends CSNode> void writeGenericParameters(Iterable<T> nodes) {
		write("<");
		writeCommaSeparatedList(nodes);
		write(">");
	}

	private void writeType(CSTypeDeclaration node) {
		writeDoc(node);
		beginEnclosingIfDefs(node);
		writeTypeHeader(node);
		writeTypeBody(node);
		endEnclosingIfDefs(node);
	}

	private void writeBaseTypes(CSTypeDeclaration node) {
		List<CSTypeReferenceExpression> baseTypes = node.baseTypes();
		if (baseTypes.isEmpty())
			return;
		write(" : ");
		writeCommaSeparatedList(baseTypes);
	}

	private void writeTypeBody(CSTypeDeclaration node) {
		writeLine();
		enterBody();
		CSTypeDeclaration saved = _currentType;
		_currentType = node;
		writeLineSeparatedList(node.members());
		printPrecedingComments(node.startPosition() + node.sourceLength());
		_currentType = saved;
		leaveBody();
	}

	private void writeVisibility(CSMember member) {
		writeIndentation();

		if (member.isNewModifier())
			write("new ");

		if (isExplicitMember(member))
			return;

		CSVisibility visibility = member.visibility();
		write(visibility.toString().toLowerCase());
		write(" ");
	}

	private boolean isExplicitMember(CSMember member) {
		return member.name().indexOf('.') != -1;
	}

	private void writeParameterAttributes(CSParameterDeclaration node) {
		if (node.attributes() == null)
			return;
		for (CSAttribute attr : node.attributes()) {
			write("[");
			write(attr.name());
			if (!attr.arguments().isEmpty()) {
				writeParameterList(attr.arguments());
			}
			write("] ");
		}
	}

	@Override
	public void visit(CSVariableDeclaration node) {
		if (node instanceof CSParameterDeclaration)
			writeParameterAttributes((CSParameterDeclaration) node);
		node.type().accept(this);
		if (null != node.name()) {
			write(" ");
			write(node.name());
		}
		if (null != node.initializer()) {
			write(" = ");
			node.initializer().accept(this);
		}
	}

	@Override
	public void visit(CSConstructor node) {
		writeDoc(node);
		writeAttributes(node);
		if (node.isStatic()) {
			writeIndented("static ");
		} else {
			writeVisibility(node);
		}
		write(_currentType.name());
		writeParameterList(node);
		if (null != node.chainedConstructorInvocation()) {
			write(" : ");
			writeMethodInvocation(node.chainedConstructorInvocation());
		}
		writeLine();
		node.body().accept(this);
	}

	@Override
	public void visit(CSDestructor node) {
		writeIndented("~");
		write(_currentType.name());
		writeLine("()");
		node.body().accept(this);
	}

	@Override
	public void visit(CSMethod node) {
		printPrecedingComments(node);
		beginEnclosingIfDefs(node);
		writeDoc(node);
		writeAttributes(node);
		if (node.dllImport() != null)
			writeDllImport(node.dllImport());
		writeMethodHeader(node, node.modifier());
		node.returnType().accept(this);
		write(" ");
		writeMethodName(node);
		writeTypeParameters(node);
		writeParameterList(node);
		if (node.modifier() != CSMethodModifier.Override)
			writeTypeParameterConstraints(node.typeParameters());
		if (node.isAbstract() || (node.dllImport() != null)) {
			writeLine(";");
		} else {
			writeMethodBody(node);
		}
		endEnclosingIfDefs(node);
	}

	private void writeDllImport(CSDllImport dllImport) {
		writeIndented("[DllImport(");
		write('"' + dllImport.getDllName() + '"');
		CSDllImport.CallingConvention cconv = dllImport.getCallingConvention();
		if (cconv != null) {
			write(", CallingConvention = CallingConvention.");
			switch (cconv) {
			case CDecl:
				write("Cdecl");
				break;
			case StdCall:
				write("StdCall");
				break;
			case ThisCall:
				write("ThisCall");
				break;
			default:
				write("Winapi");
				break;
			}
		}
		CSDllImport.CharSet charSet = dllImport.getCharSet();
		if (charSet != null) {
			write(", CharSet = CharSet.");
			switch (charSet) {
			case Ansi:
				write("Ansi");
				break;
			case Unicode:
				write("Unicode");
				break;
			default:
				write("Auto");
				break;
			}
		}
		writeLine(")]");
	}

	private void endEnclosingIfDefs(CSNode node) {
		for (String expression : node.enclosingIfDefs()) {
			writeIndented("#endif // ");
			writeLine(expression);
		}
	}

	private void beginEnclosingIfDefs(CSNode node) {
		for (String expression : node.enclosingIfDefs()) {
			writeIndented("#if ");
			writeLine(expression);
		}
	}

	private void writeMethodHeader(CSMember member, CSMethodModifier modifiers) {
		if (!_currentType.isInterface()) {
			writeVisibility(member);
			write(methodModifier(modifiers));
		} else {
			writeIndentation();
		}
	}

	protected void writeMethodBody(CSMethod node) {
		writeLine();
		node.body().accept(this);
	}

	protected void writeMethodName(CSMethod node) {
		write(node.name());
	}

	@Override
	public void visit(CSBlock node) {
		enterBody();
		visitList(node.statements());
		leaveBody();
	}

	@Override
	public void visit(CSDeclarationStatement node) {
		printPrecedingComments(node);

		writeIndentation();
		node.declaration().accept(this);
		writeLine(";");

	}

	@Override
	public void visit(CSDeclarationExpression node) {
		node.declaration().accept(this);
	}

	private void writeDeclaration(CSTypeReferenceExpression type, String name, CSExpression initializer) {
		type.accept(this);
		write(" ");
		write(name);
		if (null != initializer) {
			write(" = ");
			initializer.accept(this);
		}
		writeLine(";");
	}

	@Override
	public void visit(CSLineComment node) {
		writeIndentedLine(node.text());
	}

	@Override
	public void visit(CSReturnStatement node) {

		printPrecedingComments(node);

		if (null == node.expression()) {
			writeIndentedLine("return;");
		} else {
			writeIndented("return ");
			node.expression().accept(this);
			writeLine(";");
		}
	}

	private void printPrecedingComments(CSNode node) {
		if ((node instanceof CSMember) && ((CSMember) node).noDocs())
			return;
		printPrecedingComments(node.startPosition());
	}

	private void printPrecedingComments(int startPosition) {
		if ((_currentType != null) && _currentType.noDocs())
			return;
		if (startPosition <= 0)
			return;
		if (_lastPrintedCommentIndex >= _comments.size())
			return;
		_lastPrintedCommentIndex = printCommentsBetween(_lastPrintedCommentIndex, startPosition);
	}

	private int printCommentsBetween(int lastIndex, int endStartPosition) {
		int endIndex = commentIndexAfter(lastIndex, endStartPosition);
		if (endIndex == -1) {
			endIndex = _comments.size();
		}
		if ((_currentType != null) && _currentType.noDocs())
			return endIndex;
		visitList(_comments.subList(lastIndex, endIndex));
		return endIndex;
	}

	private int commentIndexAfter(int startIndex, int endStartPosition) {
		for (int i = startIndex; i < _comments.size(); ++i) {
			if (_comments.get(i).startPosition() > endStartPosition) {
				return i;
			}
		}
		return -1;
	}

	@Override
	public void visit(CSIfStatement node) {
		printPrecedingComments(node);

		writeIndented("if (");
		node.expression().accept(this);
		writeLine(")");
		node.trueBlock().accept(this);
		if (!node.falseBlock().isEmpty()) {
			writeIndentedLine("else");
			node.falseBlock().accept(this);
		}
	}

	@Override
	public void visit(CSLockStatement node) {
		writeBlockStatement("lock", node);
	}

	@Override
	public void visit(CSWhileStatement node) {
		writeBlockStatement("while", node);
	}

	@Override
	public void visit(CSSwitchStatement node) {
		writeIndented("switch (");
		node.expression().accept(this);
		writeLine(")");
		enterBody();
		writeLineSeparatedList(node.caseClauses());
		leaveBody();
	}

	@Override
	public void visit(CSCaseClause node) {
		int clauses = 0;
		for (CSExpression e : node.expressions()) {
			if (clauses++ > 0)
				writeLine();
			writeIndented("case ");
			e.accept(this);
			write(":");
		}

		if (node.isDefault()) {
			if (clauses > 0)
				writeLine();
			writeIndented("default:");
		}
		writeLine();
		node.body().accept(this);
	}

	@Override
	public void visit(CSForEachStatement node) {
		printPrecedingComments(node);

		writeIndented("foreach (");
		node.variable().accept(this);
		write(" in ");
		node.expression().accept(this);
		writeLine(")");
		node.body().accept(this);
	}

	@Override
	public void visit(CSForStatement node) {
		printPrecedingComments(node);

		writeIndented("for (");
		writeCommaSeparatedList(node.initializers());
		write("; ");
		if (null != node.expression()) {
			node.expression().accept(this);
		}
		write("; ");
		writeCommaSeparatedList(node.updaters());
		writeLine(")");
		node.body().accept(this);
	}

	@Override
	public void visit(CSBreakStatement node) {
		printPrecedingComments(node);
		writeIndentedLine("break;");
	}

	@Override
	public void visit(CSGotoStatement node) {
		printPrecedingComments(node);
		if (node.target() != null) {
			writeIndented("goto case ");
			node.target().accept(this);
			write(";");
			writeLine();
		}
		else
			writeIndentedLine("goto " + node.label() + ";");
	}

	@Override
	public void visit(CSContinueStatement node) {
		printPrecedingComments(node);
		writeIndentedLine("continue;");
	}

	private void writeBlockStatement(String keyword, CSBlockStatement node) {
		printPrecedingComments(node);
		writeIndented(keyword);
		write(" (");
		node.expression().accept(this);
		write(")");
		writeLine();
		node.body().accept(this);
	}

	@Override
	public void visit(CSDoStatement node) {
		writeIndentedLine("do");
		node.body().accept(this);
		writeIndented("while (");
		node.expression().accept(this);
		writeLine(");");
	}

	@Override
	public void visit(CSTryStatement node) {
		printPrecedingComments(node);

		writeIndentedLine("try");
		node.body().accept(this);
		visitList(node.catchClauses());
		if (null != node.finallyBlock()) {
			writeIndentedLine("finally");
			node.finallyBlock().accept(this);
		}
	}

	@Override
	public void visit(CSCatchClause node) {
		writeIndented("catch");
		CSVariableDeclaration ex = node.exception();
		if (ex != null) {
			write(" (");
			ex.accept(this);
			write(")");
		}
		writeLine();
		node.body().accept(this);
	}

	@Override
	public void visit(CSThrowStatement node) {
		printPrecedingComments(node);

		if (null == node.expression()) {
			writeIndentedLine("throw;");
		} else {
			writeIndented("throw ");
			node.expression().accept(this);
			writeLine(";");
		}
	}

	@Override
	public void visit(CSExpressionStatement node) {
		printPrecedingComments(node);

		writeIndentation();
		node.expression().accept(this);
		writeLine(";");
	}

	@Override
	public void visit(CSParenthesizedExpression node) {
		write("(");
		node.expression().accept(this);
		write(")");
	}

	@Override
	public void visit(CSConditionalExpression node) {
		node.expression().accept(this);
		write(" ? ");
		node.trueExpression().accept(this);
		write(" : ");
		node.falseExpression().accept(this);
	}

	@Override
	public void visit(CSInfixExpression node) {
		node.lhs().accept(this);
		write(" ");
		write(node.operator());
		write(" ");
		node.rhs().accept(this);
	}

	@Override
	public void visit(CSPrefixExpression node) {
		write(node.operator());
		node.operand().accept(this);
	}

	@Override
	public void visit(CSPostfixExpression node) {
		node.operand().accept(this);
		write(node.operator());
	}

	@Override
	public void visit(CSConstructorInvocationExpression node) {
		write("new ");
		writeMethodInvocation(node);
	}

	@Override
	public void visit(CSMethodInvocationExpression node) {
		writeMethodInvocation(node);
	}

	protected void writeMethodInvocation(CSMethodInvocationExpression node) {
		node.expression().accept(this);
		writeTypeArguments(node);
		writeParameterList(node.arguments());
	}

	@Override
	public void visit(CSNumberLiteralExpression node) {
		write(node.token());
	}

	@Override
	public void visit(CSUncheckedExpression node) {
		write("unchecked(");
		node.expression().accept(this);
		write(")");
	}

	@Override
	public void visit(CSTypeofExpression node) {
		write("typeof(");
		node.type().accept(this);
		write(")");
	}

	@Override
	public void visit(CSBoolLiteralExpression node) {
		write(Boolean.toString(node.booleanValue()));
	}

	@Override
	public void visit(CSStringLiteralExpression node) {
		write(node.escapedValue());
	}

	@Override
	public void visit(CSCharLiteralExpression node) {
		write(node.escapedValue());
	}

	@Override
	public void visit(CSNullLiteralExpression node) {
		write("null");
	}

	@Override
	public void visit(CSBaseExpression node) {
		write("base");
	}

	@Override
	public void visit(CSThisExpression node) {
		write("this");
	}

	@Override
	public void visit(CSArrayCreationExpression node) {
		write("new ");

		CSharpTypeReferenceVisitor arrayElementTypeVisitor = new CSharpTypeReferenceVisitor(this);

		node.elementType().accept(arrayElementTypeVisitor);

		write("[");
		if (null != node.length()) {
			node.length().accept(this);
		}
		write("]");

		write(arrayElementTypeVisitor.sufix());

		if (null != node.initializer()) {
			write(" ");
			node.initializer().accept(this);
		}
	}

	@Override
	public void visit(CSArrayInitializerExpression node) {
		write("{ ");
		writeCommaSeparatedList(filterRemovedExpressions(node.expressions()));
		write(" }");
	}

	private Iterable<CSNode> filterRemovedExpressions(List<CSExpression> expressions) {
		final ArrayList<CSNode> result = new ArrayList<CSNode>(expressions.size());
		for (CSNode e : expressions)
			if (!(e instanceof CSRemovedExpression))
				result.add(e);
		return result;
	}

	@Override
	public void visit(CSIndexedExpression node) {
		node.expression().accept(this);
		write("[");
		writeCommaSeparatedList(node.indexes());
		write("]");
	}

	@Override
	public void visit(CSCastExpression node) {
		write("(");
		node.type().accept(this);
		write(")");
		if (null != node.expression()) {
			node.expression().accept(this);
		}
	}

	@Override
	public void visit(CSReferenceExpression node) {
		write(node.name());
	}

	@Override
	public void visit(CSMemberReferenceExpression node) {
		node.expression().accept(this);
		write(".");
		write(node.name());
	}

	@Override
	public void visit(CSByRefExpression node) {
		if (node.isOut())
			write("out ");
		else
			write("ref ");
		node.expression().accept(this);
	}

	protected void writeParameterList(CSMethodBase node) {
		List<CSVariableDeclaration> parameters = node.parameters();
		write("(");
		if (node.isVarArgs()) {
			if (parameters.size() > 1) {
				writeCommaSeparatedList(parameters.subList(0, parameters.size() - 1));
				write(", ");
			}
			write("params ");
			visit(parameters.get(parameters.size() - 1));
		} else {
			writeCommaSeparatedList(parameters);
		}
		write(")");
	}

	protected <T extends CSNode> void writeParameterList(Iterable<T> parameters) {
		write("(");
		writeCommaSeparatedList(parameters);
		write(")");
	}

	@Override
	public void visit(CSField node) {
		writeMemberHeader(node);
		writeFieldModifiers(node);
		writeDeclaration(node.type(), node.name(), node.initializer());
	}

	@Override
	public void visit(CSProperty node) {
		writeMetaMemberHeader(node);
		node.type().accept(this);
		write(" ");
		if (node.isIndexer()) {
			write("this[");
			writeCommaSeparatedList(node.parameters());
			writeLine("]");
		} else {
			writeLine(node.name());
		}
		enterBody();
		writeOptionalMemberBlock("get", node.getter(), node.isAbstract());
		writeOptionalMemberBlock("set", node.setter(), node.isAbstract());
		leaveBody();
	}

	private void writeOptionalMemberBlock(final String name, final CSBlock block, boolean isAbstract) {
		if (null != block) {
			writeMemberBlock(name, block, isAbstract);
		}
	}

	private void writeMemberHeader(CSMember node) {
		writeDoc(node);
		writeAttributes(node);
		writeVisibility(node);
	}

	@Override
	public void visit(CSEvent node) {
		writeMetaMemberHeader(node);
		write("event ");
		node.type().accept(this);
		write(" ");
		write(node.name());

		final CSBlock firstBlock = node.getAddBlock();
		if (null == firstBlock) {
			writeLine(";");
			return;
		}
		writeLine();
		enterBody();
		writeMemberBlock("add", firstBlock, node.isAbstract());
		writeMemberBlock("remove", node.getRemoveBlock(), node.isAbstract());
		leaveBody();
	}

	private void writeMetaMemberHeader(CSMetaMember node) {
		writeDoc(node);
		writeAttributes(node);
		writeMethodHeader(node, node.modifier());
	}

	private void writeMemberBlock(String name, CSBlock block, boolean isAbstract) {
		writeIndented(name);
		if (isAbstract) {
			writeLine(";");
		} else {
			writeLine();
			block.accept(this);
		}
	}

	@Override
	public void visit(CSAttribute node) {
		writeIndented("[");
		write(node.name());
		if (!node.arguments().isEmpty()) {
			writeParameterList(node.arguments());
		}
		writeLine("]");
	}

	@Override
	public void visit(CSLabelStatement node) {
		// labels can't be free-standing, for simplicity simply emit an
		// empty statement
		writeLine(node.label() + ": ;");
	}

	@Override
	public void visit(CSDocTextOverlay node) {
		writeXmlDoc(node.text());
	}

	@Override
	public void visit(CSDocTextNode node) {
		writeXmlDoc(xmlEscape(node.text()));
	}

	private void writeXmlDoc(final String xmldocText) {
		String[] lines = xmldocText.split("\n");
		for (int i = 0; i < lines.length; ++i) {
			if (i > 0) {
				writeLine();
				writeIndentation();
			}
			writeBlock(lines[i].trim().replace("<br>", "<br />"));
		}
	}

	private String xmlEscape(String text) {
		return text.replaceAll("(<)(/?[^\\s][^>]*)(>)", ":lt:$2:gt:")
				.replace("<", "&lt;").replace(">", "&gt;")
				.replace(":lt:", "<")
				.replace(":gt:", ">");

	}

	@Override
	public void visit(CSDocTagNode node) {
		String tagName = node.tagName();
		List<CSDocAttributeNode> attributes = node.attributes();
		List<CSDocNode> fragments = node.fragments();

		write("<");
		write(tagName);
		if (!attributes.isEmpty()) {
			for (CSDocAttributeNode attr : attributes) {
				write(" ");
				write(attr.name());
				write("=\"");
				write(attr.value());
				write("\"");
			}
		}
		write(">");

		if (fragments.size() > 1) {
			writeLine();
			for (CSDocNode f : fragments) {
				writeIndentation();
				f.accept(this);
				writeLine();
			}
			writeIndented("</" + tagName + ">");
		} else {
			if (!fragments.isEmpty()) {
				fragments.get(0).accept(this);
			}
			write("</" + tagName + ">");
		}
	}

	private void writeAttributes(CSMember node) {
		visitList(node.attributes());
	}

	private void writeFieldModifiers(CSField node) {
		for (CSFieldModifier m : node.modifiers()) {
			write(m.toString().toLowerCase());
			write(" ");
		}
	}

	private void writeDoc(CSMember node) {
		List<CSDocNode> docs = node.docs();
		if (docs.isEmpty()) {
			return;
		}

		linePrefix("/// ");
		for (CSDocNode doc : docs) {
			writeIndentation();
			doc.accept(this);
			writeLine();
		}
		linePrefix(null);
	}

	private String methodModifier(CSMethodModifier modifier) {
		switch (modifier) {
		case Static:
			return "static ";
		case Virtual:
			return "virtual ";
		case Abstract:
			return "abstract ";
		case AbstractOverride:
			return "abstract override ";
		case Sealed:
			return "sealed override ";
		case Override:
			return "override ";
		case Extern:
			return "static extern ";
		}
		return "";
	}

	interface Closure {
		void execute();
	}

	private <T extends CSNode> void writeLineSeparatedList(Iterable<T> nodes) {
		writeSeparatedList(nodes, new Closure() {
			public void execute() {
				writeLine();
			}
		});
	}

	private <T extends CSNode> void writeCommaSeparatedList(Iterable<T> nodes) {
		writeList(nodes, ", ");
	}

	private <T extends CSNode> void writeList(Iterable<T> nodes, final String separator) {
		writeSeparatedList(nodes, new Closure() {
			public void execute() {
				write(separator);
			}
		});
	}

	private <T extends CSNode> void writeSeparatedList(Iterable<T> nodes, Closure separator) {
		Iterator<T> iterator = nodes.iterator();
		if (!iterator.hasNext())
			return;
		iterator.next().accept(this);
		while (iterator.hasNext()) {
			separator.execute();
			iterator.next().accept(this);
		}
	}

	private String classModifier(CSClassModifier modifier) {
		switch (modifier) {
		case Abstract:
			return "abstract ";
		case Sealed:
			return "sealed ";
		case Static:
			return "static ";
		}
		return "";
	}

	protected void enterBody() {
		// writeLine();
		writeIndentedLine("{");
		indent();
	}

	private void indent() {
		_writer.indent();
	}

	private void outdent() {
		_writer.outdent();
	}

	private void writeIndentation() {
		_writer.writeIndentation();
	}

	private void writeIndented(String s) {
		_writer.writeIndented(s);
	}

	private void writeIndentedLine(String s) {
		_writer.writeIndentedLine(s);
	}

	private void write(String s) {
		_writer.write(s);
	}

	private void linePrefix(String s) {
		_writer.linePrefix(s);
	}

	private void writeBlock(String s) {
		_writer.writeBlock(s);
	}

	private void writeLine(String s) {
		_writer.writeLine(s);
	}

	private void writeLine() {
		_writer.writeLine();
	}

	protected void leaveBody() {
		outdent();
		writeIndentedLine("}");
	}

	class CSharpTypeReferenceVisitor extends CSVisitor {
		private CSVisitor _delegate;
		private StringBuffer _sb = new StringBuffer();

		CSharpTypeReferenceVisitor(CSVisitor delegate) {
			_delegate = delegate;
		}

		@Override
		public void visit(CSArrayTypeReference node) {
			node.elementType().accept(_delegate);

			for (int i = 0; i < node.dimensions(); ++i) {
				_sb.append("[]");
			}
		}

		public void visit(CSTypeReferenceExpression node) {
			node.accept(_delegate);
		}

		@Override
		public void visit(CSTypeReference node) {
			node.accept(_delegate);
		}

		@Override
		public void visit(CSNestedTypeReference node) {
			node.accept(_delegate);
		}

		@Override
		public void visit(CSNullableTypeReference node) {
			node.accept(_delegate);
		}

		@Override
		public void visit(CSByRefTypeReference node) {
			node.accept(_delegate);
		}

		String sufix() {
			return _sb.toString();
		}
	}

	@Override
	public void visit(CSUserDefinedConversion node) {
		printPrecedingComments(node);
		beginEnclosingIfDefs(node);
		writeDoc(node);
		writeAttributes(node);
		writeIndentation();
		write("public static ");
		write(node.implicit() ? "implicit" : "explicit");
		write(" operator ");
		node.targetType().accept(this);
		write("(");
		node.sourceType().accept(this);
		write(" ");
		write("source");
		write(")");
		writeLine();
		node.body().accept(this);
		endEnclosingIfDefs(node);
	}

	@Override
	public void visit(CSDefaultExpression node) {
		write("default");
		write("(");
		write(node.name());
		write(")");
	}
}
