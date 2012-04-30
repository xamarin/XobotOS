package sharpen.xobotos.api.interop;

import sharpen.core.csharp.ast.CSAttribute;
import sharpen.core.csharp.ast.CSExpression;
import sharpen.core.csharp.ast.CSStatement;
import sharpen.core.csharp.ast.CSTypeReferenceExpression;
import sharpen.core.csharp.ast.CSVariableDeclaration;

public interface IManagedMarshalContext {
	void addDeclaration(CSVariableDeclaration decl, CSStatement cleanup);

	void addPreStatement(CSStatement statement);

	void addPostStatement(CSStatement statement);

	String getVariableName(String suffix);

	ManagedVariable addParameter(String name, CSTypeReferenceExpression type, CSExpression arg,
			CSAttribute... attrs);
}
