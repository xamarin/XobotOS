package sharpen.xobotos.api.interop.glue;

import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

public class ClassDefinition extends AbstractTypeDefinition {

	private final List<MemberEntry> _members;

	public ClassDefinition(String name, Visibility visibility, boolean hasDeclaration) {
		super(name, visibility);
		this._members = new ArrayList<MemberEntry>();

		if (hasDeclaration)
			createDeclaration();
	}

	public static class MemberEntry {
		public final AbstractDefinition Definition;
		public final AbstractMember Declaration;
		public final Visibility Visibility;

		private MemberEntry(AbstractDefinition definition, AbstractMember declaration, Visibility visibility) {
			this.Definition = definition;
			this.Declaration = declaration;
			this.Visibility = visibility;
		}
	}

	public interface MemberFilter {
		boolean filter(MemberEntry entry);
	}

	public static final MemberFilter DEFINITION_FILTER = new MemberFilter() {
		@Override
		public boolean filter(MemberEntry entry) {
			return entry.Definition != null;
		}
	};

	public static final MemberFilter DECLARATION_FILTER = new MemberFilter() {
		@Override
		public boolean filter(MemberEntry entry) {
			return entry.Declaration != null;
		}
	};

	private MemberEntry createEntry(AbstractMember member, Visibility visibility) {
		if (member instanceof AbstractDefinition) {
			AbstractDefinition definition = (AbstractDefinition) member;
			if (hasDeclaration())
				return new MemberEntry(definition, definition.getDeclaration(), visibility);
			else
				return new MemberEntry(definition, null, visibility);
		} else {
			return new MemberEntry(null, member, visibility);
		}
	}

	public List<MemberEntry> getMembers(MemberFilter... filters) {
		List<MemberEntry> retval = new ArrayList<MemberEntry>();
		memberLoop: for (MemberEntry entry : _members) {
			for (MemberFilter filter : filters) {
				if (filter.filter(entry)) {
					retval.add(entry);
					continue memberLoop;
				}
			}
		}
		return Collections.unmodifiableList(retval);
	}

	public void addMember(AbstractMember member) {
		_members.add(createEntry(member, member.getVisibility()));
	}

	@Override
	public void accept(Visitor visitor) {
		visitor.visit(this);
	}

	@Override
	protected ClassDeclaration createDeclaration() {
		return new ClassDeclaration(this);
	}

}
