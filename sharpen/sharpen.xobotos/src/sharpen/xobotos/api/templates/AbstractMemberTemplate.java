package sharpen.xobotos.api.templates;

import com.thoughtworks.xstream.annotations.XStreamImplicit;
import com.thoughtworks.xstream.annotations.XStreamOmitField;

import org.eclipse.jdt.core.dom.ASTNode;

import sharpen.core.csharp.ast.CSNode;
import sharpen.xobotos.api.Filter;
import sharpen.xobotos.api.TemplateVisitor;
import sharpen.xobotos.api.TemplateVisitor.VisitMode;
import sharpen.xobotos.config.LocationFilter.Match;
import sharpen.xobotos.config.annotations.AttributeReference;
import sharpen.xobotos.output.IOutputProvider;
import sharpen.xobotos.output.OutputType;

import java.util.List;

public abstract class AbstractMemberTemplate<T extends ASTNode, U extends CSNode> extends AbstractTemplate
		implements IOutputProvider {
	@XStreamOmitField
	@AttributeReference("output")
	private OutputType _outputType;

	@XStreamImplicit(itemFieldName="filter")
	private List<Filter> _filters;

	public Match matches(T member) {
		if (getName() != null) {
			if (Filter.matchesName(member, getName(), false))
				return Match.POSITIVE;
			else
				return Match.NO_MATCH;
		}

		if (_filters == null)
			return Match.POSITIVE;

		for (final Filter filter : _filters) {
			Match match = filter.matches(member);
			if (match != Match.NO_MATCH)
				return match;
		}

		return Match.NO_MATCH;
	}

	@Override
	public OutputType getOutputType() {
		return _outputType;
	}

	public U createCustomMember(T node) {
		return null;
	}

	public void visit(TemplateVisitor visitor, VisitMode mode) {
		visitor.accept(this);
	}

	@Override
	protected void print(StringBuilder sb) {
		if (_outputType != null) {
			sb.append(':');
			sb.append(_outputType);
		}
		super.print(sb);
	}

}
