package sharpen.xobotos.config.xstream;

import com.thoughtworks.xstream.converters.Converter;
import com.thoughtworks.xstream.converters.ConverterLookup;
import com.thoughtworks.xstream.core.TreeUnmarshaller;
import com.thoughtworks.xstream.io.HierarchicalStreamReader;
import com.thoughtworks.xstream.mapper.Mapper;

public class Unmarshaller extends TreeUnmarshaller {

	public Unmarshaller(RootContext<?> root, Object obj, HierarchicalStreamReader reader,
			ConverterLookup converterLookup, Mapper mapper) {
		super(obj, reader, converterLookup, mapper);
		this._root = root;
	}

	private final RootContext<?> _root;

	@Override
	protected Object convert(Object parent, @SuppressWarnings("rawtypes") Class type, Converter converter) {
		final Object result;
		final String reference = reader.getAttribute("reference");
		if (reference != null)
			return _root.lookupReference(reference);

		final String key = reader.getAttribute("id");
		RootContext.Scope scope = _root.enterScope(type, key);
		result = super.convert(parent, type, converter);
		if (result != null)
			_root.checkAttributeReferences(reader, scope, type, result);
		_root.leaveScope(scope, parent, type, result);
		return result;
	}
}
