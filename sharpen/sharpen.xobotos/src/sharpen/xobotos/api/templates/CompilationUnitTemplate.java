package sharpen.xobotos.api.templates;

import com.thoughtworks.xstream.annotations.XStreamAlias;
import com.thoughtworks.xstream.annotations.XStreamAsAttribute;
import com.thoughtworks.xstream.annotations.XStreamImplicit;
import com.thoughtworks.xstream.annotations.XStreamOmitField;

import org.eclipse.jdt.core.dom.AbstractTypeDeclaration;
import org.eclipse.jdt.core.dom.CompilationUnit;
import org.eclipse.jdt.core.dom.EnumDeclaration;
import org.eclipse.jdt.core.dom.TypeDeclaration;

import sharpen.core.framework.ByRef;
import sharpen.xobotos.StandardConfiguration.ConfigFlags;
import sharpen.xobotos.api.TemplateSection;
import sharpen.xobotos.api.TemplateVisitor;
import sharpen.xobotos.api.TemplateVisitor.VisitMode;
import sharpen.xobotos.api.bindings.CompilationUnitBinding;
import sharpen.xobotos.config.annotations.AttributeReference;
import sharpen.xobotos.config.xstream.IConfigurationFile;
import sharpen.xobotos.output.IOutputProvider;
import sharpen.xobotos.output.OutputType;

import java.util.List;

@XStreamAlias(value="compilation-unit")
public class CompilationUnitTemplate extends AbstractLocationTemplate
		implements ITypeContainer, IOutputProvider, IConfigurationFile {

	@XStreamOmitField
	public final static CompilationUnitTemplate DEFAULT = new CompilationUnitTemplate();

	@XStreamAsAttribute
	@XStreamAlias("partial")
	private boolean _partial;

	@XStreamOmitField
	@AttributeReference("output")
	private OutputType _outputType;

	@XStreamImplicit(itemFieldName="type")
	private List<TypeTemplate> _types;

	@XStreamImplicit(itemFieldName = "enum")
	private List<EnumTemplate> _enums;

	@XStreamAlias("main-type")
	private MainTypeTemplate _mainType;

	@SuppressWarnings("unused")
	@XStreamImplicit(itemFieldName = "templates")
	private List<TemplateSection> _templates;

	@XStreamAlias("override-config")
	private ConfigFlags _overrideConfig;

	@XStreamAlias("binding")
	private CompilationUnitBinding _binding;

	@Override
	public OutputType getOutputType() {
		return _outputType;
	}

	public boolean isPartial() {
		return _partial;
	}

	public CompilationUnitBinding getBinding() {
		return _binding;
	}

	public List<TypeTemplate> getTypes() {
		return join(_types, _mainType);
	}

	public List<EnumTemplate> getEnums() {
		return unmodifiable(_enums);
	}

	public ConfigFlags getConfigFlags() {
		return _overrideConfig;
	}

	public boolean visit(TemplateVisitor visitor, CompilationUnit unit, AbstractTypeDeclaration type) {
		if (type instanceof TypeDeclaration)
			return visit(visitor, getTypes(), (TypeDeclaration) type);
		else if (type instanceof EnumDeclaration)
			return visit(visitor, getEnums(), (EnumDeclaration) type);
		return false;
	}

	@Override
	public TypeTemplate findTypeTemplate(final TypeDeclaration node) {
		if (!(node.getParent() instanceof CompilationUnit))
			return null;
		final CompilationUnit parent = (CompilationUnit) node.getParent();
		final ByRef<TypeTemplate> result = new ByRef<TypeTemplate>();
		TemplateVisitor visitor = new TemplateVisitor() {
			@Override
			public void accept(TypeTemplate type) {
				result.value = type;
			}
		};
		if (!visit(visitor, parent, node))
			return null;
		return result.value != null ? result.value : TypeTemplate.DEFAULT;
	}

	@Override
	public EnumTemplate findEnumTemplate(final EnumDeclaration node) {
		if (!(node.getParent() instanceof CompilationUnit))
			return null;
		final CompilationUnit parent = (CompilationUnit) node.getParent();
		final ByRef<EnumTemplate> result = new ByRef<EnumTemplate>();
		TemplateVisitor visitor = new TemplateVisitor() {
			@Override
			public void accept(EnumTemplate type) {
				result.value = type;
			}
		};
		if (!visit(visitor, parent, node))
			return null;
		return result.value != null ? result.value : EnumTemplate.DEFAULT;
	}

	public void visit(TemplateVisitor visitor, VisitMode mode) {
		visitor.accept(this);
		if (mode == VisitMode.AllUnits)
			return;
		visitList(visitor, mode, getTypes());
		visitList(visitor, mode, getEnums());
	}

	@Override
	protected void print(StringBuilder sb) {
		if (_outputType != null) {
			sb.append(':');
			sb.append(_outputType);
		}
		if (_partial)
			sb.append(":partial");
		super.print(sb);
	}
}
