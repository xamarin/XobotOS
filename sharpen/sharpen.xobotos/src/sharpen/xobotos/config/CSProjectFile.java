package sharpen.xobotos.config;

import com.thoughtworks.xstream.annotations.XStreamAlias;
import com.thoughtworks.xstream.annotations.XStreamImplicit;

import sharpen.core.Configuration.NameMapping;

import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

@XStreamAlias(value="csproject-file")
public class CSProjectFile {
	@XStreamAlias("path")
	private String _path;

	@XStreamImplicit(itemFieldName = "rename")
	private List<NameMapping> _pathMappings;

	@XStreamAlias("template-file")
	private String _templateFile;

	@XStreamAlias("filelist-file")
	private String _fileListFile;

	private Object readResolve() {
		if (_path == null)
			throw new ConfigurationException("<csproject-file> is missing <path> element!");
		if (_templateFile == null)
			throw new ConfigurationException("<csproject-file> is missing <template-file> element!");
		if (_fileListFile == null)
			throw new ConfigurationException("<csproject-file> is missing <filelist-file> element!");
		return this;
	}

	public String getPath() {
		return _path;
	}

	public String getTemplateFile() {
		return _templateFile;
	}

	public String getFileListFile() {
		return _fileListFile;
	}

	public List<NameMapping> getPathMappings() {
		List<NameMapping> list = new ArrayList<NameMapping>();
		if (_pathMappings != null)
			list.addAll(_pathMappings);
		return Collections.unmodifiableList(list);
	}

}
