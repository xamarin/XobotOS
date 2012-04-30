package sharpen.xobotos.api.interop;

import sharpen.xobotos.api.interop.glue.AbstractTypeReference;
import sharpen.xobotos.api.interop.glue.Expression;
import sharpen.xobotos.api.interop.glue.Statement;

public interface INativeMarshalContext {

	void addArgument(Expression arg);

	void addPreStatement(Statement statement);

	void addPostStatement(Statement statement);

	NativeVariable createParameter(String name, AbstractTypeReference type);

	NativeVariable createVariable(String name, AbstractTypeReference type, Expression init);
}
