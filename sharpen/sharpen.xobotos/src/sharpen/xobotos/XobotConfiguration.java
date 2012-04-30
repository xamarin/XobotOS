package sharpen.xobotos;

import sharpen.xobotos.config.ConfigFile;

public final class XobotConfiguration extends StandardConfiguration {

	private final ConfigFile _configFile;

	public ConfigFile getConfig() {
		return _configFile;
	}

	public XobotConfiguration(ConfigFile configFile) {
		this(configFile, ConfigFlags.DEFAULT);
	}

	private XobotConfiguration(ConfigFile configFile, ConfigFlags flags) {
		super(flags);
		this._configFile = configFile;

		addAndroidMappings();
		setCreateProblemMarkers(true);
		setIgnoreErrors(true);

		for (final NameMapping mapping : _configFile.getNamespaceMappings()) {
			mapNamespace(mapping.from, mapping.to);
		}
	}

	public XobotConfiguration clone(ConfigFlags flags) {
		return new XobotConfiguration(_configFile, flags);
	}

	@Override
	protected String reflectionRuntimeMethod(String methodName) {
		return "XobotOS.Runtime.Reflection." + methodName;
	}

	@Override
	protected String miscRuntimeMethod(String methodName) {
		return "XobotOS.Runtime.Util." + methodName;
	}

	private void addAndroidMappings() {
		mapType("android.net.Uri", "System.Uri");
		mapType("android.net.Uri.Builder", "System.UriBuilder");
		mapMethod("android.net.Uri.withAppendedPath",
				sharpenUtilMethod("AppendUri"));
		mapMethod("android.net.Uri.parse", sharpenUtilMethod("ParseUri"));
		mapMethod("android.net.Uri.encode", sharpenUtilMethod("EncodeUri"));
		mapMethod("android.net.Uri.toSafeString", sharpenUtilMethod("ToSafeString"));
		mapProperty("android.net.Uri.getScheme", "Scheme");

		mapMethod("libcore.util.SneakyThrow.sneakyThrow", sharpenUtilMethod("Throw"));
		mapMethod("com.android.internal.os.RuntimeInit.wtf", miscRuntimeMethod("FatalError"));
	}
}
