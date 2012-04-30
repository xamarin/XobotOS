package sharpen.xobotos.api.templates;

import com.thoughtworks.xstream.annotations.XStreamAlias;
import com.thoughtworks.xstream.annotations.XStreamOmitField;

import sharpen.core.csharp.ast.CSMethod;
import sharpen.xobotos.api.actions.ModifyMethod;
import sharpen.xobotos.api.interop.NativeMethod;

@XStreamAlias(value="method")
public class MethodTemplate extends AbstractMethodTemplate<CSMethod> {

	@XStreamOmitField
	public final static MethodTemplate DEFAULT = new MethodTemplate();

	@XStreamAlias("modify")
	private ModifyMethod _modifyMethod;

	@XStreamAlias("native")
	private NativeMethod _nativeMethod;

	@Override
	public ModifyMethod getModificationAction() {
		return _modifyMethod;
	}

	public NativeMethod getNativeMethod() {
		return _nativeMethod;
	}

}
