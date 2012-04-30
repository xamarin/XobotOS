package sharpen.xobotos.api.templates;

import com.thoughtworks.xstream.annotations.XStreamAlias;
import com.thoughtworks.xstream.annotations.XStreamAsAttribute;

import org.eclipse.jdt.core.dom.ASTNode;

import sharpen.core.csharp.ast.CSNode;
import sharpen.xobotos.api.AbstractReference;
import sharpen.xobotos.api.TemplateVisitor;
import sharpen.xobotos.api.TemplateVisitor.VisitMode;
import sharpen.xobotos.config.LocationFilter.Match;
import sharpen.xobotos.output.OutputMode;
import sharpen.xobotos.output.OutputType;

import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

public abstract class AbstractTemplate extends AbstractReference {
	@XStreamAsAttribute
	@XStreamAlias("name")
	private String _name;

	public String getName () {
		return _name;
	}

	protected Object readResolve() {
		return this;
	}

	protected <T extends ASTNode, U extends CSNode, V extends AbstractMemberTemplate<T, U>> boolean visit(
			TemplateVisitor visitor, List<V> list, T member) {
		if (list == null)
			return true;
		for (final V template : list) {
			Match match = template.matches(member);
			if (match == Match.NO_MATCH)
				continue;
			else if (match == Match.NEGATIVE)
				return false;
			OutputType output = template.getOutputType();
			if ((output != null) && (output.getModeForMember(member) == OutputMode.NOTHING))
				return false;
			visitor.accept(template);
			return true;
		}

		return true;
	}

	protected static <T> List<T> unmodifiable(List<T> list) {
		return list != null ? Collections.unmodifiableList(list) : null;
	}

	protected static <T> List<T> unmodifiableOrEmpty(List<T> list) {
		if (list != null)
			return Collections.unmodifiableList(list);
		else
			return new ArrayList<T>();
	}

	public static <T, U extends T> List<T> cast(List<U> baseList, Class<T> klass) {
		if (baseList == null)
			return null;
		List<T> list = new ArrayList<T>();
		list.addAll(baseList);
		return Collections.unmodifiableList(list);
	}

	protected static <T> List<T> join(List<T> baseList, T member) {
		if ((baseList == null) && (member == null))
			return null;
		List<T> list = new ArrayList<T>();
		if (member != null)
			list.add(member);
		if (baseList != null)
			list.addAll(baseList);
		return Collections.unmodifiableList(list);
	}

	protected static <T, U extends T> List<T> joinLists(List<T> baseList, List<U> newList) {
		if ((baseList == null) && (newList == null))
			return null;
		List<T> list = new ArrayList<T> ();
		if (baseList != null)
			list.addAll(baseList);
		if (newList != null)
			list.addAll(newList);
		return Collections.unmodifiableList(list);
	}

	protected static <T extends AbstractMemberTemplate<?, ?>> void visitList(TemplateVisitor visitor,
			VisitMode mode, List<T> list) {
		if (list == null)
			return;
		for (final T template : list)
			template.visit(visitor, mode);
	}

	protected void print(StringBuilder sb) {

	}

	@Override
	public String toString() {
		StringBuilder sb = new StringBuilder();
		sb.append('[');
		sb.append(getClass().getSimpleName());
		if (getId() != null)
			sb.append('(' + getId() + ')');
		sb.append(':');
		sb.append(_name != null ? _name : "null");
		print(sb);
		sb.append(']');
		return sb.toString();
	}
}
