package sharpen.xobotos.api.templates;

import com.thoughtworks.xstream.annotations.XStreamAlias;
import com.thoughtworks.xstream.annotations.XStreamAsAttribute;
import com.thoughtworks.xstream.annotations.XStreamImplicit;
import com.thoughtworks.xstream.annotations.XStreamOmitField;

import sharpen.xobotos.api.TemplateSection;
import sharpen.xobotos.api.TemplateVisitor;
import sharpen.xobotos.api.TemplateVisitor.VisitMode;
import sharpen.xobotos.config.LocationFilter.Match;
import sharpen.xobotos.config.annotations.AttributeReference;
import sharpen.xobotos.config.annotations.ReadIncludeFile;
import sharpen.xobotos.output.IOutputProvider;
import sharpen.xobotos.output.OutputType;

import java.util.ArrayList;
import java.util.List;

@XStreamAlias(value="namespace")
public class NamespaceTemplate extends AbstractLocationTemplate implements IOutputProvider {

	@XStreamOmitField
	public final static NamespaceTemplate DEFAULT = new NamespaceTemplate();

	@XStreamImplicit(itemFieldName="namespace")
	private List<NamespaceTemplate> _namespaces;

	@XStreamImplicit(itemFieldName="compilation-unit")
	private List<CompilationUnitTemplate> _compilationUnits;

	@XStreamImplicit(itemFieldName = "include-file")
	private List<IncludeFile> _includeFiles;

	@XStreamImplicit(itemFieldName = "template-include-file")
	private List<TemplateIncludeFile> _templateIncludeFiles;

	@XStreamAsAttribute
	@XStreamAlias("recursive")
	private boolean _recursive;

	@XStreamOmitField
	@AttributeReference("output")
	private OutputType _outputType;

	@SuppressWarnings("unused")
	@XStreamImplicit(itemFieldName = "templates")
	private List<TemplateSection> _templates;

	public List<NamespaceTemplate> getNamespaces() {
		List<NamespaceTemplate> list = null;

		if (_templateIncludeFiles != null) {
			for (final TemplateIncludeFile file : _templateIncludeFiles) {
				NamespaceTemplateSection nsts = file.getContents();
				List<NamespaceTemplate> ns = nsts.getNamespaces();
				if (ns != null) {
					if (list == null)
						list = new ArrayList<NamespaceTemplate>();
					list.addAll(ns);
				}
			}
		}

		if (_namespaces != null) {
			if (list == null)
				list = new ArrayList<NamespaceTemplate>();
			list.addAll(_namespaces);
		}

		return unmodifiable(list);
	}

	public List<CompilationUnitTemplate> getCompilationUnits() {
		List<CompilationUnitTemplate> list = null;
		if (_includeFiles != null) {
			list = new ArrayList<CompilationUnitTemplate>();
			for (final IncludeFile file : _includeFiles) {
				list.add(file.getContents());
			}
		}
		if (_templateIncludeFiles != null) {
			for (final TemplateIncludeFile file : _templateIncludeFiles) {
				NamespaceTemplateSection nsts = file.getContents();
				List<CompilationUnitTemplate> units = nsts.getCompilationUnits();
				if (units != null) {
					if (list == null)
						list = new ArrayList<CompilationUnitTemplate>();
					list.addAll(units);
				}
			}
		}

		if (_compilationUnits != null) {
			if (list == null)
				list = new ArrayList<CompilationUnitTemplate>();
			list.addAll(_compilationUnits);
		}

		return unmodifiable(list);
	}

	@Override
	protected Object readResolve() {
		if (_namespaces == null)
			_namespaces = new ArrayList<NamespaceTemplate> ();
		return super.readResolve();
	}

	public boolean isRoot() {
		return getName() == null && !hasLocationFilters();
	}

	public boolean isRecursive() {
		return _recursive;
	}

	@Override
	public OutputType getOutputType() {
		return _outputType;
	}

	private static String buildName(String[] elements, int start, int end) {
		StringBuilder sb = new StringBuilder();
		for (int i = start; i <= end; i++) {
			if (i > start)
				sb.append('.');
			sb.append(elements[i]);
		}
		return sb.toString();
	}

	public boolean visit(TemplateVisitor visitor, String name, VisitMode mode) {
		final String[] elements = name.split("\\.");

		String part = "";
		String rest = name;

		boolean found = false;

		if (!isRoot()) {
			for (int i = 0; i < elements.length - 1; i++) {
				part = buildName(elements, 0, i);
				rest = buildName(elements, i + 1, elements.length - 1);
				Match match = matches(part);
				if (match == Match.NO_MATCH)
					continue;
				else if (match == Match.NEGATIVE)
					return false;
				found = true;
				break;
			}
			if (!found)
				return false;
		} else {
			Match match = matches(name);
			if (match != Match.POSITIVE)
				return false;
		}

		found = false;

		if (isRoot() || isRecursive() || (rest.indexOf('.') < 0)) {
			List<CompilationUnitTemplate> unitList = getCompilationUnits();
			if (unitList != null) {
				for (final CompilationUnitTemplate template : unitList) {
					Match match = template.matches(rest);
					if (match == Match.NO_MATCH)
						continue;
					else if (match == Match.NEGATIVE)
						return false;
					template.visit(visitor, mode);
					found = true;
					if (mode == VisitMode.FirstMatch)
						break;
				}
			} else {
				found = true;
			}
			if (isRoot() && !found) {
				return false;
			}
			if (!isRecursive() && (mode == VisitMode.FirstMatch)) {
				visitor.accept(this);
				return true;
			}
		}

		if (found && (mode == VisitMode.FirstMatch)) {
			visitor.accept(this);
			return true;
		}

		for (final NamespaceTemplate template : getNamespaces()) {
			if (!template.visit(visitor, rest, mode))
				continue;
			found = true;
			if (mode == VisitMode.FirstMatch)
				break;
		}

		if (found)
			visitor.accept(this);

		return found;
	}

	@Override
	protected void print(StringBuilder sb) {
		if (_recursive)
			sb.append(":recursive");
		if (_outputType != null) {
			sb.append(':');
			sb.append(_outputType);
		}
		super.print(sb);
	}

	@ReadIncludeFile(contentsField = "_contents", fileNameField = "_fileName", fileType = CompilationUnitTemplate.class)
	public static final class IncludeFile {
		@XStreamAsAttribute
		@XStreamAlias("file")
		@SuppressWarnings("unused")
		private String _fileName;

		@XStreamOmitField
		private CompilationUnitTemplate _contents;

		public CompilationUnitTemplate getContents() {
			return _contents;
		}
	}

	@ReadIncludeFile(contentsField = "_contents", fileNameField = "_fileName", fileType = NamespaceTemplateSection.class)
	public static final class TemplateIncludeFile {
		@XStreamAsAttribute
		@XStreamAlias("file")
		@SuppressWarnings("unused")
		private String _fileName;

		@XStreamOmitField
		private NamespaceTemplateSection _contents;

		public NamespaceTemplateSection getContents() {
			return _contents;
		}
	}
}
