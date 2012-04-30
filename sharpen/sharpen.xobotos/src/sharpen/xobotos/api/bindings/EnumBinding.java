package sharpen.xobotos.api.bindings;

import com.thoughtworks.xstream.annotations.XStreamAlias;
import com.thoughtworks.xstream.annotations.XStreamAsAttribute;

import sharpen.core.framework.IBindingManager.IExtractedEnumInfo;
import sharpen.xobotos.config.ConfigurationException;

@XStreamAlias("enum-binding")
public class EnumBinding extends AbstractTypeBinding {
	@XStreamAsAttribute
	@XStreamAlias("base-type")
	private String _baseType;

	@XStreamAlias("value-field")
	private String _valueField;

	@XStreamAlias("constructor-method")
	private String _ctorMethod;

	@XStreamAsAttribute
	@XStreamAlias("nullable")
	private boolean _nullable;

	@XStreamAlias("extract-enum")
	ExtractedEnumInfo _extract;

	public String getBaseType() {
		return _baseType;
	}

	public String getValueField() {
		return _valueField;
	}

	public String getConstructorMethod() {
		return _ctorMethod;
	}

	public boolean isNullable() {
		return _nullable;
	}

	public ExtractedEnumInfo getExtractionInfo() {
		return _extract;
	}

	@XStreamAlias("extract-enum")
	public class ExtractedEnumInfo implements IExtractedEnumInfo {
		@XStreamAsAttribute
		@XStreamAlias("value-field")
		String _valueField;

		@Override
		public String valueField() {
			return _valueField;
		}

		private Object readResolve() {
			if (_valueField == null)
				throw new ConfigurationException("<extract-enum> is missing <value-field>");
			return this;
		}
	}
}
