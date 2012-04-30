package sharpen.xobotos.api.interop;

import sharpen.core.csharp.ast.CSExpression;
import sharpen.core.csharp.ast.CSStatement;
import sharpen.core.csharp.ast.CSTypeReferenceExpression;

public interface IManagedReturnContext {
	void addStatement(CSStatement statement);

	ManagedVariable createVariable(String name, CSTypeReferenceExpression type, CSExpression init);

	ManagedVariable createRetval(CSExpression init);
}
