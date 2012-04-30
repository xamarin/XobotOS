package sharpen.xobotos.config;

import com.thoughtworks.xstream.annotations.XStreamAlias;
import com.thoughtworks.xstream.annotations.XStreamAsAttribute;
import com.thoughtworks.xstream.annotations.XStreamImplicit;

import sharpen.core.Configuration.NameMapping;
import sharpen.xobotos.api.interop.NativeConfiguration;
import sharpen.xobotos.config.xstream.IConfigurationFile;

import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

@XStreamAlias(value="configuration")
public final class ConfigFile implements IConfigurationFile {
	@XStreamAlias("source-info")
	private SourceInfo _sourceInfo;

	@XStreamImplicit(itemFieldName="map-namespace")
	private List<NameMapping> _mapNamespaces;

	@XStreamAlias("api-def")
	private String _apiDefFileName;

	@XStreamAlias("log-file")
	private LogFileEntry _logFile;

	@XStreamAlias("native-config")
	private NativeConfiguration _nativeConfig;

	private ConfigFile () {
	}

	private Object readResolve() {
		if (_sourceInfo == null)
			throw new RuntimeException("<source-info> element missing in config file!");
		if (_mapNamespaces == null)
			_mapNamespaces = new ArrayList<NameMapping> ();
		if (_apiDefFileName == null)
			throw new RuntimeException("Missing <api-def> entry in config file!");
		if ((_logFile != null) && (_logFile.path == null))
			throw new RuntimeException("Invalid 'log-file' entry in config file!");
		if (_nativeConfig == null)
			throw new RuntimeException("Missing <native-config> entry in config file!");
		return this;
	}

	public LogFileEntry getLogFile() {
		return _logFile;
	}

	public SourceInfo getSourceInfo() {
		return _sourceInfo;
	}

	public List<NameMapping> getNamespaceMappings() {
		return Collections.unmodifiableList(_mapNamespaces);
	}

	public String getAPIDefinitionFileName() {
		return _apiDefFileName;
	}

	public NativeConfiguration getNativeConfig() {
		return _nativeConfig;
	}

	public static class LogFileEntry {
		public String path;

		@XStreamAsAttribute
		public boolean append;
	}

}
