package sharpen.xobotos.api.bindings;

import com.thoughtworks.xstream.annotations.XStreamAlias;
import com.thoughtworks.xstream.annotations.XStreamAsAttribute;

import sharpen.core.framework.IBindingManager.ITypeInfo;

@XStreamAlias("type-binding")
public class TypeBinding extends AbstractTypeBinding implements ITypeInfo {

	@XStreamAsAttribute
	@XStreamAlias("is-event-interface")
	private boolean _isEventInterface;

	@Override
	public boolean isEventInterface() {
		return _isEventInterface;
	}

}
