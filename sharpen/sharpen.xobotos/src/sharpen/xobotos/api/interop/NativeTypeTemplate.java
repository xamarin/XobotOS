package sharpen.xobotos.api.interop;

import com.thoughtworks.xstream.annotations.XStreamImplicit;

import sharpen.xobotos.api.AbstractReference;

import java.util.Collections;
import java.util.List;


public abstract class NativeTypeTemplate extends AbstractReference implements IncludeFileProvider {
	@XStreamImplicit(itemFieldName = "include")
	private List<String> _includes;

	@Override
	public List<String> getIncludes() {
		return _includes != null ? Collections.unmodifiableList(_includes) : null;
	}

}
