package sharpen.core.csharp;

import sharpen.core.csharp.ast.*;

import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class CSharpRewritingVisitor extends CSVisitor {

	public CSharpRewritingVisitor() {
		// TODO Auto-generated constructor stub
	}

	@Override
	public void visit(CSArrayCreationExpression node) {
		CSharpTypeReferenceVisitor arrayElementTypeVisitor = new CSharpTypeReferenceVisitor(this);

		node.elementType().accept(arrayElementTypeVisitor);

		if (null != node.length()) {
			node.length().accept(this);
		}

		if (null != node.initializer()) {
			node.initializer().accept(this);
		}
	}

	@Override
	public void visit(CSArrayInitializerExpression node) {
	}

	@Override
	public void visit(final CSArrayTypeReference node) {
		node.elementType().accept(this);
	}

	@Override
	public void visit(CSAttribute node) {
	}

	@Override
	public void visit(CSBaseExpression node) {
	}

	@Override
	public void visit(CSBlock node) {
		visitList(node.statements());
	}

	@Override
	public void visit(CSBoolLiteralExpression node) {
	}

	@Override
	public void visit(CSBreakStatement node) {
	}

	@Override
	public void visit(CSCaseClause node) {
		visitList(node.expressions());
		node.body().accept(this);
	}

	@Override
	public void visit(CSCastExpression node) {
		node.type().accept(this);
		if (null != node.expression()) {
			node.expression().accept(this);
		}
	}

	@Override
	public void visit(CSCatchClause node) {
		CSVariableDeclaration ex = node.exception();
		if (ex != null) {
			ex.accept(this);
		}
		node.body().accept(this);
	}

	@Override
	public void visit(CSCharLiteralExpression node) {
	}

	@Override
	public void visit(CSClass node) {
		visitList(node.attributes());
		visitList(node.typeParameters());
		visitList(node.baseTypes());
		visitList(node.constructors());
		visitList(node.members());
	}

	@Override
	public void visit(CSCompilationUnit node) {
		visitList(node.usings());
		visitList(node.types());
	}

	@Override
	public void visit(CSConditionalExpression node) {
		node.expression().accept(this);
		node.trueExpression().accept(this);
		node.falseExpression().accept(this);
	}

	@Override
	public void visit(CSConstructor node) {
		node.body().accept(this);
		for (final CSVariableDeclaration vdecl : node.parameters())
			vdecl.accept(this);
		node.body().accept(this);
	}

	@Override
	public void visit(CSConstructorInvocationExpression node) {
	}

	@Override
	public void visit(CSContinueStatement node) {
	}

	@Override
	public void visit(CSDeclarationExpression node) {
		node.declaration().accept(this);
	}

	@Override
	public void visit(CSDeclarationStatement node) {
		node.declaration().accept(this);
	}

	@Override
	public void visit(CSDelegate node) {
	}

	@Override
	public void visit(CSDestructor node) {
		node.body().accept(this);
	}

	@Override
	public void visit(CSDocTagNode node) {
		visitList(node.attributes());
		visitList(node.fragments());
	}

	@Override
	public void visit(CSDocTextNode node) {
	}

	@Override
	public void visit(CSDocTextOverlay node) {
	}

	@Override
	public void visit(CSDoStatement node) {
		node.body().accept(this);
		node.expression().accept(this);
	}

	@Override
	public void visit(CSEnum node) {
	}

	@Override
	public void visit(CSEnumValue node) {
	}

	@Override
	public void visit(CSEvent node) {
		node.type().accept(this);

		final CSBlock addBlock = node.getAddBlock();
		if (addBlock != null)
			addBlock.accept(this);
		final CSBlock removeBlock = node.getRemoveBlock();
		if (removeBlock != null)
			removeBlock.accept(this);
	}

	@Override
	public void visit(CSExpressionStatement node) {
		node.expression().accept(this);
	}

	@Override
	public void visit(CSField node) {
	}

	@Override
	public void visit(CSForEachStatement node) {
		node.variable().accept(this);
		node.expression().accept(this);
		node.body().accept(this);
	}

	@Override
	public void visit(CSForStatement node) {
		if (null != node.expression()) {
			node.expression().accept(this);
		}
		node.body().accept(this);
	}

	@Override
	public void visit(CSGotoStatement node) {
		if (node.target() != null) {
			node.target().accept(this);
		}
	}

	@Override
	public void visit(CSIfStatement node) {
		node.expression().accept(this);
		node.trueBlock().accept(this);
		if (!node.falseBlock().isEmpty()) {
			node.falseBlock().accept(this);
		}
	}

	@Override
	public void visit(CSIndexedExpression node) {
		node.expression().accept(this);
	}

	@Override
	public void visit(CSInfixExpression node) {
		node.lhs().accept(this);
		node.rhs().accept(this);
	}

	@Override
	public void visit(CSInterface node) {
	}

	@Override
	public void visit(CSLabelStatement node) {
	}

	@Override
	public void visit(CSLineComment node) {
	}

	@Override
	public void visit(CSLockStatement node) {
	}

	static final Pattern META_VARIABLE_PATTERN = Pattern.compile("\\$(\\w+)");

	@Override
	public void visit(CSMacro node) {
		final String template = node.template();
		final Matcher matcher = META_VARIABLE_PATTERN.matcher(template);
		while (matcher.find()) {
			Object value = node.resolveVariable(matcher.group(1));
			// value is either a single node or a list of nodes
			if (value instanceof CSNode) {
				((CSNode)value).accept(this);
			}

			matcher.end();
		}
	}

	@Override
	public void visit(CSMacroExpression node) {
		node.macro().accept(this);
	}

	@Override
	public void visit(CSMacroTypeReference node) {
		node.macro().accept(this);
	}

	@Override
	public void visit(CSMemberReferenceExpression node) {
		node.expression().accept(this);
	}

	@Override
	public void visit(CSMethod node) {
		node.returnType().accept(this);
		for (final CSVariableDeclaration vdecl : node.parameters())
			vdecl.accept(this);
		node.body().accept(this);
	}

	@Override
	public void visit(CSMethodInvocationExpression node) {
	}

	@Override
	public void visit(CSNullLiteralExpression node) {
	}

	@Override
	public void visit(CSNumberLiteralExpression node) {
	}

	@Override
	public void visit(CSParenthesizedExpression node) {
		node.expression().accept(this);
	}

	@Override
	public void visit(CSPostfixExpression node) {
		node.operand().accept(this);
	}

	@Override
	public void visit(CSPrefixExpression node) {
		node.operand().accept(this);
	}

	@Override
	public void visit(CSProperty node) {
		node.type().accept(this);

		final CSBlock getter = node.getter();
		if (getter != null)
			getter.accept(this);
		final CSBlock setter = node.setter();
		if (setter != null)
			setter.accept(this);
	}

	@Override
	public void visit(CSReferenceExpression node) {
	}

	@Override
	public void visit(CSRemovedExpression node) {
		throw new IllegalStateException("Unexpected removal of expression: " + node.toString());
	}

	@Override
	public void visit(CSReturnStatement node) {
		if (null != node.expression()) {
			node.expression().accept(this);
		}
	}

	@Override
	public void visit(CSStringLiteralExpression node) {
	}

	@Override
	public void visit(CSStruct node) {
	}

	@Override
	public void visit(CSSwitchStatement node) {
		node.expression().accept(this);
	}

	@Override
	public void visit(CSThisExpression node) {
	}

	@Override
	public void visit(CSThrowStatement node) {
		if (null != node.expression()) {
			node.expression().accept(this);
		}
	}

	@Override
	public void visit(CSTryStatement node) {
		node.body().accept(this);
		visitList(node.catchClauses());
		if (null != node.finallyBlock()) {
			node.finallyBlock().accept(this);
		}
	}

	@Override
	public void visit(CSTypeofExpression node) {
		node.type().accept(this);
	}

	@Override
	public void visit(CSTypeParameter node) {
	}

	@Override
	public void visit(CSTypeReference node) {
	}

	@Override
	public void visit(CSNestedTypeReference node) {
		node.getParent().accept(this);
		node.getChild().accept(this);
	}

	@Override
	public void visit(CSUncheckedExpression node) {
		node.expression().accept(this);
	}

	@Override
	public void visit(CSUsing node) {
	}

	@Override
	public void visit(CSVariableDeclaration node) {
		node.type().accept(this);
		if (null != node.initializer()) {
			node.initializer().accept(this);
		}
	}

	@Override
	public void visit(CSWhileStatement node) {
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

			for (int i=0; i < node.dimensions(); ++i) {
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

		String sufix() {
			return _sb.toString();
		}
	}

	@Override
	public void visit(CSUserDefinedConversion conv) {
		conv.sourceType().accept(this);
		conv.targetType().accept(this);
		conv.body().accept(this);
	}

}
