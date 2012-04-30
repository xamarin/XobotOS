package sharpen.xobotos.api.bindings;

import com.thoughtworks.xstream.annotations.XStreamAlias;
import com.thoughtworks.xstream.annotations.XStreamAsAttribute;

import sharpen.core.Configuration.MemberMapping;
import sharpen.core.MemberKind;
import sharpen.core.framework.IBindingManager.IMethodInfo;

@XStreamAlias("method-binding")
public class MethodBinding extends MemberBinding implements IMethodInfo {
	@XStreamAsAttribute
	@XStreamAlias("rename")
	String _rename;

	public MemberMapping getMapping() {
		if (_rename != null)
			return new MemberMapping(_rename, MemberKind.Method);
		return null;
	}
}
