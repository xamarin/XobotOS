package sharpen.core;

import sharpen.core.csharp.ast.*;

public final class FlowAnalysis {

	private FlowAnalysis() {
		;
	}

	public static boolean isReachable(CSBlock block) {
		return Visitor.run(block);
	}

	public static class Visitor extends CSVisitor {

		private boolean _reachable = true;

		public static boolean run(CSStatement node) {
			Visitor visitor = new Visitor();
			node.accept(visitor);
			return visitor._reachable;
		}

		private void setUnreachable() {
			_reachable = false;
		}

		private boolean isUnreachable() {
			return !_reachable;
		}

		@Override
		public void visit(CSBlock node) {
			for (CSStatement statement : node.statements()) {
				if (!run(statement)) {
					setUnreachable();
					break;
				}
			}
		}

		@Override
		public void visit(CSBreakStatement node) {
			setUnreachable();
		}

		@Override
		public void visit(CSContinueStatement node) {
			setUnreachable();
		}

		@Override
		public void visit(CSReturnStatement node) {
			setUnreachable();
		}

		@Override
		public void visit(CSThrowStatement node) {
			setUnreachable();
		}

		@Override
		public void visit(CSIfStatement node) {
			boolean reachable = false;
			if (node.trueBlock() != null)
				reachable |= run(node.trueBlock());
			if (node.falseBlock() != null)
				reachable |= run(node.falseBlock());
			if (!reachable)
				setUnreachable();
		}

		@Override
		public void visit(CSSwitchStatement node) {
			if (isUnreachable())
				return;
			boolean hasDefault = false;
			boolean reachable = false;
			for (CSCaseClause clause : node.caseClauses()) {
				if (clause.isDefault())
					hasDefault = true;
				reachable |= run(clause.body());
			}
			if (!reachable && hasDefault)
				setUnreachable();
		}

	}

}
