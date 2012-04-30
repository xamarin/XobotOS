package sharpen.xobotos.config;

import com.thoughtworks.xstream.annotations.XStreamAlias;
import com.thoughtworks.xstream.annotations.XStreamImplicit;

import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

@XStreamAlias(value="source-info")
public final class SourceInfo {
	@XStreamImplicit(itemFieldName="location-filter")
	private List<LocationFilter> _locationFilters;

	@XStreamImplicit(itemFieldName="extra-csharp-sources")
	private List<String> _extraCSharpSources;

	@XStreamAlias("source-folder")
	private String _sourceFolder;

	@XStreamAlias("output-folder")
	private String _outputFolder;

	@XStreamImplicit(itemFieldName = "csproject-file")
	private List<CSProjectFile> _csprojFiles;

	private Object readResolve() {
		if (_locationFilters == null)
			_locationFilters = new ArrayList<LocationFilter> ();
		if (_extraCSharpSources == null)
			_extraCSharpSources = new ArrayList<String> ();
		if (_sourceFolder == null)
			throw new RuntimeException("<source-info> is missing <source-folder> element!");
		if (_outputFolder == null)
			throw new RuntimeException("<source-info> is missing <output-folder> element!");
		return this;
	}

	public List<LocationFilter> getLocationFilters() {
		return Collections.unmodifiableList(_locationFilters);
	}

	public List<String> getExtraCSharpSources() {
		return Collections.unmodifiableList(_extraCSharpSources);
	}

	public String getSourceFolder() {
		return _sourceFolder;
	}

	public String getOutputFolder() {
		return _outputFolder;
	}

	public List<CSProjectFile> getCSProjectFiles() {
		return _csprojFiles != null ? Collections.unmodifiableList(_csprojFiles) : null;
	}
}
