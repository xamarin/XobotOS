package sharpen.xobotos.api.interop;

import com.thoughtworks.xstream.annotations.XStreamAlias;
import com.thoughtworks.xstream.annotations.XStreamImplicit;

import sharpen.core.csharp.ast.CSDllImport;
import sharpen.core.csharp.ast.CSDllImport.CallingConvention;
import sharpen.core.csharp.ast.CSDllImport.CharSet;
import sharpen.xobotos.api.AbstractReference;
import sharpen.xobotos.api.interop.marshal.MarshalInfo.MarshalEntry;
import sharpen.xobotos.config.ConfigurationException;

import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

@XStreamAlias(value = "native-configuration")
public class NativeConfiguration extends AbstractReference implements IncludeFileProvider {
	@XStreamAlias("dll-name")
	private String _dllName;

	@XStreamAlias("function-prefix")
	private String _functionPrefix;

	@XStreamAlias("output-dir")
	private String _outputDir;

	@SuppressWarnings("unused")
	@XStreamImplicit(itemFieldName = "marshal-info")
	private List<MarshalEntry> _marshalInfo;

	@XStreamImplicit(itemFieldName = "include")
	private List<String> _includes;

	@SuppressWarnings("unused")
	@XStreamImplicit(itemFieldName = "native-handle")
	private List<NativeHandle> _nativeHandles;

	private Object readResolve() {
		if (_dllName == null)
			throw new ConfigurationException("<native-bindings> is missing <dll-name>");
		if (_outputDir == null)
			throw new ConfigurationException("<native-bindings> is missing <output-dir>");
		if (_includes == null)
			_includes = new ArrayList<String>();
		return this;
	}

	public String getFunctionPrefix() {
		return _functionPrefix;
	}

	public String getOutputDir() {
		return _outputDir;
	}

	@Override
	public List<String> getIncludes() {
		return Collections.unmodifiableList(_includes);
	}

	public CSDllImport getDllImportAttribute() {
		return new CSDllImport(_dllName, CallingConvention.CDecl, CharSet.Unicode);
	}
}
