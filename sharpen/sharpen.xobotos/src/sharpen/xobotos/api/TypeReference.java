package sharpen.xobotos.api;

import com.thoughtworks.xstream.annotations.XStreamAlias;
import com.thoughtworks.xstream.annotations.XStreamAsAttribute;

import sharpen.core.csharp.ast.CSTypeReference;
import sharpen.core.csharp.ast.CSTypeReferenceExpression;
import sharpen.xobotos.config.ConfigurationException;

@XStreamAlias(value="type-reference")
public class TypeReference extends AbstractReference implements Comparable<TypeReference> {
	@XStreamAsAttribute
	@XStreamAlias("type")
	private String _type;

	private Object readResolve() throws ConfigurationException {
		if (_type == null)
			throw new ConfigurationException("<type-reference> is missing 'type' field");
		return this;
	}

	public String getType() {
		return _type;
	}

	public CSTypeReferenceExpression getExpression() {
		return new CSTypeReference(_type);
	}

	@Override
	public int compareTo(TypeReference arg) {
		return _type.compareTo(arg._type);
	}

}
