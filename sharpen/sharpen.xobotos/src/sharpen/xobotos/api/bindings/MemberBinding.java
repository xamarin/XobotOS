package sharpen.xobotos.api.bindings;

import com.thoughtworks.xstream.annotations.XStreamAlias;
import com.thoughtworks.xstream.annotations.XStreamAsAttribute;
import com.thoughtworks.xstream.annotations.XStreamOmitField;

import sharpen.xobotos.api.Visibility;
import sharpen.xobotos.api.interop.NativeHandle;
import sharpen.xobotos.config.annotations.AttributeReference;

public abstract class MemberBinding extends AbstractBinding {

	@XStreamOmitField
	@AttributeReference("native-handle")
	private NativeHandle _handle;

	public NativeHandle getNativeHandle() {
		return _handle;
	}

	@XStreamAsAttribute
	@XStreamAlias("visibility")
	Visibility _visibility;

	public Visibility getVisibility() {
		return _visibility;
	}

}
