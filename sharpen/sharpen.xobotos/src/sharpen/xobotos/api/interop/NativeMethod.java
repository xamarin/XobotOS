package sharpen.xobotos.api.interop;

import com.thoughtworks.xstream.annotations.XStreamAlias;
import com.thoughtworks.xstream.annotations.XStreamAsAttribute;
import com.thoughtworks.xstream.annotations.XStreamImplicit;

import sharpen.xobotos.api.AbstractReference;
import sharpen.xobotos.config.ConfigurationException;

import java.util.Collections;
import java.util.List;

@XStreamAlias(value = "native-method")
public class NativeMethod extends AbstractReference implements IncludeFileProvider {
	@XStreamAlias("signature")
	private Signature _signature;

	@XStreamAsAttribute
	@XStreamAlias("name")
	private String _name;

	@XStreamAsAttribute
	@XStreamAlias("kind")
	private Kind _kind;

	@XStreamAsAttribute
	@XStreamAlias("native-name")
	private String _nativeName;

	@XStreamAlias("class")
	private String _nativeClass;

	@XStreamAsAttribute
	@XStreamAlias("return-void")
	private boolean _returnVoid;

	@XStreamImplicit(itemFieldName = "include")
	private List<String> _includes;

	public String getName() {
		return _name;
	}

	public String getNativeName() {
		return _nativeName;
	}

	public Kind getKind() {
		return _kind;
	}

	public String getNativeClass() {
		return _nativeClass;
	}

	public Signature getSignature() {
		return _signature;
	}

	protected Object readResolve() {
		if (_signature == null)
			_signature = new Signature();
		if (_kind == null)
			_kind = Kind.STATIC;
		switch (_kind) {
		case STATIC:
		case PROXY:
			break;
		case CONSTRUCTOR:
			if (_nativeClass != null)
				throw new ConfigurationException("Cannot use <class> for constructors");
			break;
		case INSTANCE:
			if (_nativeClass != null)
				throw new ConfigurationException("Cannot use <class> for instance methods");
			break;
		case DESTRUCTOR:
			if (_nativeClass != null)
				throw new ConfigurationException("Cannot use <class> for destructors");
			break;
		default:
			throw new ConfigurationException("Invalid native method kind.");
		}
		return this;
	}

	public boolean returnVoid() {
		if (_kind == Kind.DESTRUCTOR)
			return true;
		else if (_kind == Kind.CONSTRUCTOR)
			return false;
		return _returnVoid;
	}

	@XStreamAlias("kind")
	public enum Kind {
		STATIC,
		PROXY,
		INSTANCE,
		CONSTRUCTOR,
		DESTRUCTOR
	}

	@Override
	public List<String> getIncludes() {
		return _includes != null ? Collections.unmodifiableList(_includes) : null;
	}
}
