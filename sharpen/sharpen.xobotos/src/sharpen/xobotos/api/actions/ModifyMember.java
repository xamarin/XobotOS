package sharpen.xobotos.api.actions;

import com.thoughtworks.xstream.annotations.XStreamAlias;
import com.thoughtworks.xstream.annotations.XStreamAsAttribute;
import com.thoughtworks.xstream.annotations.XStreamImplicit;

import org.eclipse.jdt.core.dom.BodyDeclaration;

import sharpen.core.csharp.ast.CSAttribute;
import sharpen.core.csharp.ast.CSMember;
import sharpen.core.csharp.ast.CSStringLiteralExpression;
import sharpen.xobotos.api.APIDefinition;
import sharpen.xobotos.api.Visibility;
import sharpen.xobotos.api.templates.MemberTemplate;
import sharpen.xobotos.config.ConfigurationException;
import sharpen.xobotos.generator.ITypeBuilder;
import sharpen.xobotos.generator.MemberBuilder;

import java.util.List;

public abstract class ModifyMember<T extends BodyDeclaration, U extends CSMember, V extends MemberTemplate<T, U>, W extends MemberBuilder<T, U, V>>
extends MemberAction<T, U, V, W> {

	@XStreamAlias("visibility")
	private Visibility _visibility;

	@XStreamImplicit(itemFieldName = "comment")
	private List<Comment> _comments;

	private static class Comment {
		@XStreamAsAttribute
		@XStreamAlias("text")
		private String _text;

		private Object readResolve() {
			if (_text == null)
				throw new ConfigurationException("<comment> requires 'text' attribute");
			return this;
		}

		public String getText() {
			return _text;
		}
	}

	@Override
	protected final void apply(ITypeBuilder parent, W builder, T node, U member) {
		modify(builder, node, member);
	}

	public void modify(W builder, T node, U member) {
		if (_visibility != null)
			member.visibility(APIDefinition.mapVisibility(_visibility));
		if (_comments != null) {
			for (final Comment comment : _comments) {
				CSAttribute attr = new CSAttribute("Sharpen.Comment");
				String escaped = "@\"" + comment.getText().replace("\"", "\"\"") + "\"";
				attr.addArgument(new CSStringLiteralExpression(escaped));
				member.addAttribute(attr);
			}
		}
	}

}
