package sharpen.xobotos.api.interop;

import com.thoughtworks.xstream.annotations.XStreamAlias;
import com.thoughtworks.xstream.annotations.XStreamAsAttribute;
import com.thoughtworks.xstream.annotations.XStreamOmitField;

import sharpen.core.csharp.ast.CSTypeReference;
import sharpen.core.csharp.ast.CSTypeReferenceExpression;
import sharpen.xobotos.config.ConfigurationException;
import sharpen.xobotos.config.annotations.AttributeReference;

@XStreamAlias("native-handle")
public class NativeHandle extends NativeTypeTemplate {
	@XStreamAsAttribute
	@XStreamAlias("name")
	private String _name;

	@XStreamAsAttribute
	@XStreamAlias("type")
	private String _type;

	@XStreamAlias("class")
	private String _nativeClass;

	@XStreamAsAttribute
	@XStreamAlias("field")
	private String _field;

	@XStreamAsAttribute
	@XStreamAlias("property")
	private String _property;

	@XStreamOmitField
	@AttributeReference("parent")
	private NativeHandle _parent;

	@XStreamAsAttribute
	@XStreamAlias("has-refcount")
	private boolean _hasRefCnt;

	private Object readResolve() {
		if (_name == null)
			throw new ConfigurationException("Missing 'name' in <native-handle>");
		if (_type == null)
			throw new ConfigurationException("Missing 'type' in <native-handle>");
		if (_nativeClass == null)
			throw new ConfigurationException("Missing 'native-class' in <native-handle>");
		return this;
	}

	public String getName() {
		return _name;
	}

	public String getField() {
		return _field;
	}

	public String getProperty() {
		return _property;
	}

	public String getNativeClass() {
		return _nativeClass;
	}

	public CSTypeReferenceExpression getManagedType() {
		return new CSTypeReference(_type + "." + _name);
	}

	public String getManagedTypeName() {
		return _type;
	}

	public boolean hasRefCount() {
		return _hasRefCnt;
	}

	public NativeHandle getParent() {
		return _parent;
	}
}
