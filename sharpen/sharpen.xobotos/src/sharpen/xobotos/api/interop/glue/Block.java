package sharpen.xobotos.api.interop.glue;

import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

public class Block extends Statement {

	private final List<Statement> _statements = new ArrayList<Statement>();

	public void addStatement(Statement stm) {
		_statements.add(stm);
	}

	public void addStatement(StatementExpression expr) {
		_statements.add(new ExpressionStatement(expr));
	}

	public List<Statement> getStatements() {
		return Collections.unmodifiableList(_statements);
	}

	public boolean isEmpty() {
		return _statements.size() == 0;
	}

	@Override
	public void accept(Visitor visitor) {
		visitor.visit(this);
	}

}
