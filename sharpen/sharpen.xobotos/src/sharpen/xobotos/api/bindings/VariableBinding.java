package sharpen.xobotos.api.bindings;

import com.thoughtworks.xstream.annotations.XStreamAlias;
import com.thoughtworks.xstream.annotations.XStreamAsAttribute;

import sharpen.core.csharp.ast.CSTypeReferenceExpression;
import sharpen.core.framework.IBindingManager.IVariableInfo;
import sharpen.xobotos.api.TypeReference;

@XStreamAlias("variable-binding")
public class VariableBinding extends MemberBinding implements IVariableInfo {
	@XStreamAsAttribute
	@XStreamAlias("rename")
	private String _rename;

	@XStreamAsAttribute
	@XStreamAlias("pointer")
	private boolean _pointer;

	@XStreamAlias("modify-type")
	private TypeReference _type;

	@XStreamAlias("auto-cast")
	private TypeReference _autoCast;

	@Override
	public String rename() {
		return _rename;
	}

	public boolean isPointer() {
		return _pointer;
	}

	public TypeReference modifyType() {
		return _type;
	}

	@Override
	public CSTypeReferenceExpression autoCast() {
		return _autoCast != null ? _autoCast.getExpression() : null;
	}
}
