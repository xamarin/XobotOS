package sharpen.xobotos.api.templates;

import com.thoughtworks.xstream.annotations.XStreamAlias;
import com.thoughtworks.xstream.annotations.XStreamImplicit;

import sharpen.xobotos.api.AbstractReference;
import sharpen.xobotos.api.TemplateSection;
import sharpen.xobotos.api.interop.NativeHandle;
import sharpen.xobotos.api.interop.NativeType;
import sharpen.xobotos.api.interop.marshal.MarshalInfo.MarshalEntry;
import sharpen.xobotos.config.annotations.ReferenceProvider;
import sharpen.xobotos.config.xstream.IConfigurationFile;

import java.util.List;

@ReferenceProvider
@XStreamAlias(value = "namespace-templates")
public class NamespaceTemplateSection extends AbstractReference implements IConfigurationFile {
	@XStreamImplicit(itemFieldName = "compilation-unit")
	private List<CompilationUnitTemplate> _compilationUnits;

	public List<CompilationUnitTemplate> getCompilationUnits() {
		return AbstractTemplate.unmodifiable(_compilationUnits);
	}

	@XStreamImplicit(itemFieldName = "namespace")
	private List<NamespaceTemplate> _namespaces;

	public List<NamespaceTemplate> getNamespaces() {
		return AbstractTemplate.unmodifiable(_namespaces);
	}

	@SuppressWarnings("unused")
	@XStreamImplicit(itemFieldName = "templates")
	private List<TemplateSection> _templates;

	@SuppressWarnings("unused")
	@XStreamImplicit(itemFieldName = "marshal-info")
	private List<MarshalEntry> _marshalInfo;

	@SuppressWarnings("unused")
	@XStreamImplicit(itemFieldName = "native-handle")
	private List<NativeHandle> _nativeHandle;

	@SuppressWarnings("unused")
	@XStreamImplicit(itemFieldName = "native-type")
	private List<NativeType> _nativeType;
}
