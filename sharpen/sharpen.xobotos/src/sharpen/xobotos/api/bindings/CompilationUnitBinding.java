package sharpen.xobotos.api.bindings;

import com.thoughtworks.xstream.annotations.XStreamAlias;
import com.thoughtworks.xstream.annotations.XStreamAsAttribute;

@XStreamAlias("compilation-unit-binding")
public class CompilationUnitBinding extends AbstractBinding {

	@XStreamAsAttribute
	@XStreamAlias("auto-rename-fields")
	private boolean _autoRenameFields;

	public boolean autoRenameFields() {
		return _autoRenameFields;
	}

}
