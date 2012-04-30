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

/*
 * Created on Jan 20, 2005
 *
 */
package sharpen.core.csharp.ast;

import java.util.ArrayList;
import java.util.List;

public class CSVisitor {

	protected <T extends CSNode> void visitList(Iterable<T> nodes) {
		for (CSNode node : nodes) {
			node.accept(this);
		}
	}

	protected <T extends CSNode> List<T> cloneList(Iterable<T> nodes) {
		ArrayList<T> list = new ArrayList<T> ();
		for (T node : nodes)
			list.add(node);
		return list;
	}

	public void visit(CSCompilationUnit node) {
	}

	public void visit(CSUsing node) {
	}

	public void visit(CSClass node) {
	}

	public void visit(CSMethod node) {
	}

	public void visit(CSField node) {
	}

	public void visit(CSInterface node) {
	}

	public void visit(CSStruct node) {
	}

	public void visit(CSVariableDeclaration node) {
	}

	public void visit(CSConstructor node) {
	}

	public void visit(CSReturnStatement node) {
	}

	public void visit(CSNumberLiteralExpression node) {
	}

	public void visit(CSNullLiteralExpression node) {
	}

	public void visit(CSReferenceExpression node) {
	}

	public void visit(CSMemberReferenceExpression node) {
	}

	public void visit(CSByRefExpression node) {
	}

	public void visit(CSThisExpression node) {
	}

	public void visit(CSMethodInvocationExpression node) {
	}

	public void visit(CSConstructorInvocationExpression node) {
	}

	public void visit(CSExpressionStatement node) {
	}

	public void visit(CSInfixExpression node) {
	}

	public void visit(CSStringLiteralExpression node) {
	}

	public void visit(CSCastExpression node) {
	}

	public void visit(CSDeclarationStatement node) {
	}

	public void visit(CSBoolLiteralExpression node) {
	}

	public void visit(CSDestructor node) {
	}

	public void visit(CSIfStatement node) {
	}

	public void visit(CSBlock node) {
	}

	public void visit(CSThrowStatement node) {
	}

	public void visit(CSWhileStatement node) {
	}

	public void visit(CSDoStatement node) {
	}

	public void visit(CSPrefixExpression node) {
	}

	public void visit(CSPostfixExpression node) {
	}

	public void visit(CSConditionalExpression node) {
	}

	public void visit(CSParenthesizedExpression node) {
	}

	public void visit(CSLockStatement node) {
	}

	public void visit(CSTryStatement node) {
	}

	public void visit(CSCatchClause node) {
	}

	public void visit(CSBaseExpression node) {
	}

	public void visit(CSIndexedExpression node) {
	}

	public void visit(CSArrayCreationExpression node) {
	}

	public void visit(CSArrayInitializerExpression node) {
	}

	public void visit(CSForStatement node) {
	}

	public void visit(CSTypeofExpression node) {
	}

	public void visit(CSSwitchStatement node) {
	}

	public void visit(CSCaseClause node) {
	}

	public void visit(CSBreakStatement node) {
	}

	public void visit(CSDeclarationExpression node) {
	}

	public void visit(CSCharLiteralExpression node) {
	}

	public void visit(CSContinueStatement node) {
	}

	public void visit(CSAttribute node) {
	}

	public void visit(CSDocTagNode node) {
	}

	public void visit(CSDocTextNode node) {
	}

	public void visit(CSDocTextOverlay node) {
	}

	public void visit(CSDocAttributeNode node) {
	}

	public void visit(CSUncheckedExpression node) {
	}

	public void visit(CSEvent node) {
	}

	public void visit(CSDelegate node) {
	}

	public void visit(CSProperty node) {
	}

	public void visit(CSTypeParameter node) {
	}

	public void visit(CSTypeReference node) {
	}

	public void visit(CSForEachStatement node) {
	}

	public void visit(CSArrayTypeReference node) {
	}

	public void visit(CSEnum node) {
	}

	public void visit(CSEnumValue node) {
	}

	public void visit(CSLineComment node) {
	}

	public void visit(CSRemovedExpression node) {
	}

	public void visit(CSMacroExpression node) {
	}

	public void visit(CSMacro node) {
	}

	public void visit(CSMacroTypeReference node) {
	}

	public void visit(CSLabelStatement node) {
	}

	public void visit(CSGotoStatement node) {
	}

	public void visit(CSNestedTypeReference node) {
	}

	public void visit(CSNullableTypeReference node) {

	}

	public void visit(CSByRefTypeReference node) {

	}

	public void visit(CSUserDefinedConversion csUserDefinedConversion) {
	}

	public void visit(CSDefaultExpression node) {

	}
}
