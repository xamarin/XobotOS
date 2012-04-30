package sharpen.core.csharp.ast;

import java.util.List;

public interface CSTypeArgumentProvider {

	List<CSTypeReferenceExpression> typeArguments();

	void addTypeArgument(CSTypeReferenceExpression typeArgument);

}
