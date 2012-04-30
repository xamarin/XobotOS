package sharpen.xobotos.api;

import static sharpen.core.framework.Environments.my;

import com.thoughtworks.xstream.annotations.XStreamAlias;
import com.thoughtworks.xstream.annotations.XStreamAsAttribute;
import com.thoughtworks.xstream.annotations.XStreamImplicit;
import com.thoughtworks.xstream.annotations.XStreamOmitField;

import org.eclipse.jdt.core.ICompilationUnit;

import sharpen.core.Configuration;
import sharpen.core.csharp.ast.CSNode;
import sharpen.core.csharp.ast.CSVisibility;
import sharpen.core.framework.ByRef;
import sharpen.core.framework.CompilationUnitPair;
import sharpen.xobotos.api.TemplateVisitor.VisitMode;
import sharpen.xobotos.api.bindings.BindingManager;
import sharpen.xobotos.api.bindings.IBindingProvider;
import sharpen.xobotos.api.templates.AbstractTemplate;
import sharpen.xobotos.api.templates.CompilationUnitTemplate;
import sharpen.xobotos.api.templates.NamespaceTemplate;
import sharpen.xobotos.api.templates.TypeTemplate;
import sharpen.xobotos.config.annotations.ReadIncludeFile;
import sharpen.xobotos.config.annotations.ReferenceProvider;
import sharpen.xobotos.config.annotations.RootContextReference;
import sharpen.xobotos.config.xstream.IConfigurationFile;
import sharpen.xobotos.config.xstream.RootContext;
import sharpen.xobotos.generator.CompilationUnitBuilder;
import sharpen.xobotos.output.IOutputProvider;

import java.net.URI;
import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

@ReferenceProvider
@RootContextReference("_rootContext")
@XStreamAlias(value="api-definition")
public class APIDefinition extends AbstractReference implements IConfigurationFile {
	@XStreamOmitField
	private RootContext<APIDefinition> _rootContext;

	@XStreamImplicit(itemFieldName="namespace")
	private List<NamespaceTemplate> _namespaces;

	@SuppressWarnings("unused")
	@XStreamImplicit(itemFieldName="templates")
	private List<TemplateSection> _templates;

	@XStreamImplicit(itemFieldName = "include-file")
	private List<IncludeFile> _includeFiles;

	public Configuration getConfiguration() {
		return my(Configuration.class);
	}

	public URI getProjectRoot() {
		return _rootContext.getProjectRoot();
	}

	public List<NamespaceTemplate> getNamespaces() {
		List<NamespaceTemplate> list = new ArrayList<NamespaceTemplate>();
		if (_includeFiles != null) {
			for (final IncludeFile file : _includeFiles) {
				list.addAll(file.getContents().getNamespaces());
			}
		}

		if (_namespaces != null)
			list.addAll(_namespaces);

		return Collections.unmodifiableList(list);
	}

	public String getUnitName(ICompilationUnit unit) {
		String packageName = unit.getParent().getElementName();
		String unitName = unit.getElementName().split("\\.")[0];
		if (packageName.length() > 0)
			unitName = my(Configuration.class).applyNamespaceMappings(packageName) + '.' + unitName;
		return unitName;
	}

	public CompilationUnitTemplate findCompilationUnitTemplate(CompilationUnitPair pair) {
		final String fullName = getUnitName(pair.source);
		final ByRef<CompilationUnitTemplate> result = new ByRef<CompilationUnitTemplate>(null);

		TemplateVisitor visitor = new TemplateVisitor() {
			@Override
			public void accept(CompilationUnitTemplate template) {
				result.value = template;
			}
		};

		for (final NamespaceTemplate def : getNamespaces()) {
			if (def.visit(visitor, fullName, VisitMode.FirstMatch))
				break;
		}

		return result.value;
	}

	public boolean compilationUnitDefinesBindings(String unitName) {
		final ByRef<Boolean> result = new ByRef<Boolean>(false);
		TemplateVisitor visitor = new TemplateVisitor() {
			@Override
			public void accept(AbstractTemplate template) {
				if (template instanceof IBindingProvider) {
					IBindingProvider provider = (IBindingProvider) template;
					if (provider.getBinding() != null)
						result.value = true;
				}
				if (template instanceof TypeTemplate) {
					TypeTemplate type = (TypeTemplate) template;
					if (type.getNativeType() != null)
						result.value = true;
					else if (type.getNativeStruct() != null)
						result.value = true;
				}
			}
		};

		for (final NamespaceTemplate def : getNamespaces()) {
			def.visit(visitor, unitName, VisitMode.All);
		}
		return result.value;
	}

	public CompilationUnitBuilder preprocess(CompilationUnitPair pair) {
		final String fullName = getUnitName(pair.source);
		final ByRef<IOutputProvider> defaultOutput = new ByRef<IOutputProvider>(null);
		final ByRef<CompilationUnitTemplate> unitTemplate = new ByRef<CompilationUnitTemplate>(
				CompilationUnitTemplate.DEFAULT);

		TemplateVisitor visitor = new TemplateVisitor() {
			@Override
			public void accept(NamespaceTemplate template) {
				if (defaultOutput.value != null)
					return;
				if (template.getOutputType() != null)
					defaultOutput.value = template;
			}

			@Override
			public void accept(CompilationUnitTemplate template) {
				unitTemplate.value = template;
			}
		};

		for (final NamespaceTemplate def : getNamespaces()) {
			if (def.visit(visitor, fullName, VisitMode.FirstMatch))
				break;
		}

		return my(BindingManager.class).preprocess(pair, unitTemplate.value, fullName, defaultOutput.value);
	}

	public static <T extends CSNode> List<T> cloneList(Iterable<T> nodes) {
		ArrayList<T> list = new ArrayList<T> ();
		for (T node : nodes)
			list.add(node);
		return list;
	}

	public static CSVisibility mapVisibility(Visibility visibility) {
		switch (visibility) {
		case PUBLIC:
			return CSVisibility.Public;
		case PROTECTED:
			return CSVisibility.Protected;
		case PRIVATE:
			return CSVisibility.Private;
		case PROTECTED_INTERNAL:
			return CSVisibility.ProtectedInternal;
		default:
			return CSVisibility.Internal;
		}
	}

	@ReadIncludeFile(contentsField = "_contents", fileNameField = "_fileName", fileType = APIDefinition.class)
	public static final class IncludeFile {
		@XStreamAsAttribute
		@XStreamAlias("file")
		@SuppressWarnings("unused")
		private String _fileName;

		@XStreamOmitField
		private APIDefinition _contents;

		public APIDefinition getContents() {
			return _contents;
		}
	}
}
