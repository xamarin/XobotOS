package sharpen.xobotos.api.interop.glue;

import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

public abstract class AbstractMethod extends AbstractDefinition {

	private final List<Parameter> _params;
	private final Block _body;

	protected AbstractMethod(Visibility visibility) {
		super(visibility);
		this._params = new ArrayList<Parameter>();
		this._body = new Block();
	}

	protected AbstractMethod(Visibility visibility, List<Parameter> params) {
		super(visibility);
		this._params = Collections.unmodifiableList(params);
		this._body = new Block();
	}

	public Parameter addParameter(Parameter param) {
		_params.add(param);
		return param;
	}

	public List<Parameter> getParameters() {
		return Collections.unmodifiableList(_params);
	}

	public Block getBody() {
		return _body;
	}

}
