package sharpen.xobotos.api.interop;

import com.thoughtworks.xstream.annotations.XStreamAlias;
import com.thoughtworks.xstream.annotations.XStreamAsAttribute;
import com.thoughtworks.xstream.annotations.XStreamImplicit;
import com.thoughtworks.xstream.annotations.XStreamOmitField;

import sharpen.xobotos.api.AbstractReference;
import sharpen.xobotos.api.interop.marshal.MarshalInfo.MarshalEntry;
import sharpen.xobotos.config.ConfigurationException;
import sharpen.xobotos.config.annotations.AttributeReference;

import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

@XStreamAlias(value = "signature")
public class Signature extends AbstractReference {

	@XStreamAlias("return-type")
	private ReturnInfo _returnType;

	@XStreamImplicit(itemFieldName = "parameter")
	private List<ParameterInfo> _parameters;

	@XStreamAsAttribute
	@XStreamAlias("implicit-instance")
	private boolean _implicitInstance;

	public static class TypeInfo {
		@XStreamOmitField
		@AttributeReference("marshal")
		public MarshalEntry marshal;
	}

	public static class ReturnInfo extends TypeInfo {
	}

	public enum Mode {
		REMOVE,
		INSTANCE,
		IN,
		OUT,
		REF
	}

	public enum Flags {
		ALLOW_NULL,
		ELEMENT
	}

	public static class ParameterInfo extends TypeInfo {
		@XStreamAsAttribute
		public int index;

		@XStreamAsAttribute
		@XStreamAlias("mode")
		public Mode mode;

		@XStreamAsAttribute
		@XStreamAlias("flags")
		public Flags flags;

		private Object readResolve() {
			if (flags == Flags.ELEMENT)
				throw new ConfigurationException("Cannot directly use Flags.ELEMENT!");
			return this;
		}
	}

	public ReturnInfo getReturnInfo() {
		return _returnType;
	}

	public ParameterInfo getParameterInfo(int pos) {
		if (_parameters != null) {
			int index = 0;
			for (final ParameterInfo info : _parameters) {
				if (info.index > 0)
					index = info.index;
				if (index == pos)
					return info;
				++index;
			}
		}

		return new ParameterInfo();
	}

	public boolean implicitInstance() {
		return _implicitInstance;
	}

	public List<MarshalEntry> getAllMarshalInfos() {
		List<MarshalEntry> list = new ArrayList<MarshalEntry>();
		if (_returnType != null)
			list.add(_returnType.marshal);
		if (_parameters != null) {
			for (final ParameterInfo info : _parameters) {
				list.add(info.marshal);
			}
		}
		return Collections.unmodifiableList(list);
	}

}
