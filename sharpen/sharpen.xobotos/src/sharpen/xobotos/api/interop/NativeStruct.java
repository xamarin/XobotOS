package sharpen.xobotos.api.interop;

import com.thoughtworks.xstream.annotations.XStreamAlias;
import com.thoughtworks.xstream.annotations.XStreamAsAttribute;
import com.thoughtworks.xstream.annotations.XStreamImplicit;
import com.thoughtworks.xstream.annotations.XStreamOmitField;

import sharpen.xobotos.api.interop.Signature.Mode;
import sharpen.xobotos.api.interop.glue.AbstractTypeReference;
import sharpen.xobotos.api.interop.glue.TypeReference;
import sharpen.xobotos.api.interop.marshal.MarshalInfo.MarshalEntry;
import sharpen.xobotos.config.ConfigurationException;
import sharpen.xobotos.config.annotations.AttributeReference;

import java.util.Collections;
import java.util.List;

@XStreamAlias("native-struct")
public class NativeStruct extends NativeTypeTemplate {
	@XStreamAsAttribute
	@XStreamAlias("native-type")
	private String _nativeType;

	@XStreamImplicit(itemFieldName = "member")
	private List<MemberInfo> _members;

	private Object readResolve() {
		if (_members == null)
			throw new ConfigurationException("Missing <member> entries in NativeStruct");
		if (_nativeType == null)
			throw new ConfigurationException("Missing <native-type> in NativeStruct");
		return this;
	}

	public List<MemberInfo> getMembers() {
		return Collections.unmodifiableList(_members);
	}

	@XStreamAlias("member")
	public static class MemberInfo {
		@XStreamAsAttribute
		@XStreamAlias("name")
		private String _name;

		@XStreamAsAttribute
		@XStreamAlias("native-name")
		private String _nativeName;

		@XStreamOmitField
		@AttributeReference("marshal")
		private MarshalEntry _marshal;

		@XStreamAsAttribute
		@XStreamAlias("mode")
		private Mode _mode;

		@XStreamAsAttribute
		@XStreamAlias("value")
		private String _value;

		public String getName() {
			return _name;
		}

		public String getNativeName() {
			return _nativeName != null ? _nativeName : _name;
		}

		public MarshalEntry getMarshalInfo() {
			return _marshal;
		}

		public Mode getMode() {
			return _mode;
		}

		public String getValue() {
			return _value;
		}
	}

	public AbstractTypeReference getNativeType() {
		return new TypeReference(_nativeType);
	}

}
