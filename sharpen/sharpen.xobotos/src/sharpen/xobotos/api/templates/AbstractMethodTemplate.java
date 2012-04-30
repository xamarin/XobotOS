package sharpen.xobotos.api.templates;

import com.thoughtworks.xstream.annotations.XStreamAlias;
import com.thoughtworks.xstream.annotations.XStreamImplicit;

import org.eclipse.jdt.core.dom.MethodDeclaration;
import org.eclipse.jdt.core.dom.VariableDeclaration;

import sharpen.core.csharp.ast.CSMethodBase;
import sharpen.xobotos.api.TemplateVisitor;
import sharpen.xobotos.api.TemplateVisitor.VisitMode;
import sharpen.xobotos.api.bindings.MethodBinding;
import sharpen.xobotos.config.LocationFilter.Match;

import java.util.List;

public abstract class AbstractMethodTemplate<T extends CSMethodBase> extends MemberTemplate<MethodDeclaration, T> {

	@XStreamAlias("binding")
	private MethodBinding _binding;

	@XStreamImplicit(itemFieldName = "variable")
	private List<VariableTemplate> _variables;

	@XStreamImplicit(itemFieldName = "parameter")
	private List<ParameterTemplate> _parameters;

	public List<VariableTemplate> getVariables() {
		return unmodifiableOrEmpty(_variables);
	}

	public List<ParameterTemplate> getParameters() {
		return unmodifiableOrEmpty(_parameters);
	}

	@Override
	public MethodBinding getBinding() {
		return _binding;
	}

	public ParameterTemplate findParameterTemplate(int pos) {
		if (_parameters == null)
			return null;
		int index = 0;
		for (final ParameterTemplate template : _parameters) {
			if (template.getIndex() > 0)
				index = template.getIndex();
			if (pos == index)
				return template;
			index++;
		}
		return null;
	}

	public VariableTemplate findVariableTemplate(VariableDeclaration node) {
		if (_variables == null)
			return null;
		for (final VariableTemplate template : _variables) {
			Match match = template.matches(node);
			if (match == Match.POSITIVE)
				return template;
			else if (match == Match.NEGATIVE)
				return null;
		}
		return null;
	}

	@Override
	public void visit(TemplateVisitor visitor, VisitMode mode) {
		super.visit(visitor, mode);
		for (final VariableTemplate template : getVariables())
			template.visit(visitor, mode);
		for (final ParameterTemplate template : getParameters())
			template.visit(visitor, mode);
	}

}
