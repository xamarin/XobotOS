package sharpen.xobotos.api.templates;

import com.thoughtworks.xstream.annotations.XStreamAlias;
import com.thoughtworks.xstream.annotations.XStreamAsAttribute;

@XStreamAlias(value = "parameter")
public class ParameterTemplate extends VariableTemplate {
	@XStreamAsAttribute
	@XStreamAlias("index")
	private int _index;

	public int getIndex() {
		return _index;
	}
}
