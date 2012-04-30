package sharpen.xobotos.config.xstream;

import com.thoughtworks.xstream.converters.ConverterLookup;
import com.thoughtworks.xstream.core.AbstractTreeMarshallingStrategy;
import com.thoughtworks.xstream.core.ReferenceByIdMarshaller;
import com.thoughtworks.xstream.core.TreeMarshaller;
import com.thoughtworks.xstream.core.TreeUnmarshaller;
import com.thoughtworks.xstream.io.HierarchicalStreamReader;
import com.thoughtworks.xstream.io.HierarchicalStreamWriter;
import com.thoughtworks.xstream.mapper.Mapper;

public class MarshallingStrategy extends AbstractTreeMarshallingStrategy {
	private RootContext<?> _root;

	public MarshallingStrategy(RootContext<?> root) {
		this._root = root;
	}

	public RootContext<?> getRootContext() {
		return _root;
	}

	@Override
	protected TreeUnmarshaller createUnmarshallingContext(Object obj,
			HierarchicalStreamReader reader, ConverterLookup converterLookup, Mapper mapper) {
		return new Unmarshaller(_root, obj, reader, converterLookup, mapper);
	}

	@Override
	protected TreeMarshaller createMarshallingContext(HierarchicalStreamWriter writer,
			ConverterLookup converterLookup, Mapper mapper) {
		return new ReferenceByIdMarshaller(writer, converterLookup, mapper);
	}
}
