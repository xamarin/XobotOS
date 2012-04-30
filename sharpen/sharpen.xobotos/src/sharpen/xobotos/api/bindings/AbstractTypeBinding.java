package sharpen.xobotos.api.bindings;

import com.thoughtworks.xstream.annotations.XStreamAlias;
import com.thoughtworks.xstream.annotations.XStreamAsAttribute;

import sharpen.core.Configuration.TypeMapping;

public class AbstractTypeBinding extends MemberBinding {
	@XStreamAsAttribute
	@XStreamAlias("map")
	String _map;

	public TypeMapping getMapping() {
		if (_map != null)
			return new TypeMapping(_map);
		return null;
	}

}
