package sharpen.xobotos.api.actions;

import com.thoughtworks.xstream.annotations.XStreamImplicit;

import org.eclipse.jdt.core.dom.BodyDeclaration;

import sharpen.core.csharp.ast.CSMember;
import sharpen.core.csharp.ast.CSTypeDeclaration;
import sharpen.xobotos.api.Filter;
import sharpen.xobotos.api.templates.MemberTemplate;
import sharpen.xobotos.config.LocationFilter.Match;
import sharpen.xobotos.generator.ITypeBuilder;
import sharpen.xobotos.generator.MemberBuilder;

import java.util.List;

public abstract class MemberAction<T extends BodyDeclaration, U extends CSMember, V extends MemberTemplate<T, U>, W extends MemberBuilder<T, U, V>>
		extends AbstractAction {

	protected abstract Class<T> getNodeType();

	protected abstract Class<W> getBuilderType();

	@XStreamImplicit(itemFieldName = "filter")
	private List<Filter> _filters;

	protected Match matchesFilter(T node) {
		if (_filters == null)
			return Match.POSITIVE;

		for (final Filter filter : _filters) {
			Match match = filter.matches(node);
			if (match != Match.NO_MATCH)
				return match;
		}

		return Match.NO_MATCH;
	}

	@Override
	public void apply(ITypeBuilder parent, CSTypeDeclaration type) {
		final Class<T> nodeType = getNodeType();
		final Class<W> builderType = getBuilderType();

		for (final T member : parent.getBodyDeclarations(nodeType)) {
			Match match = matchesFilter(member);
			if (match == Match.NEGATIVE)
				return;
			else if (match != Match.POSITIVE)
				continue;

			W builder = parent.getMemberBuilder(member, builderType);
			if (builder == null)
				continue;

			apply(parent, builder, member, builder.getMember());
		}
	}

	protected abstract void apply(ITypeBuilder parent, W builder, T node, U member);

}
