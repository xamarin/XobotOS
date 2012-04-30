package sharpen.xobotos.generator;

import org.eclipse.jdt.core.dom.ASTNode;
import org.eclipse.jdt.core.dom.EnumDeclaration;
import org.eclipse.jdt.core.dom.TypeDeclaration;

import sharpen.core.csharp.ast.CSNode;
import sharpen.xobotos.api.templates.AbstractMemberTemplate;
import sharpen.xobotos.api.templates.EnumTemplate;
import sharpen.xobotos.api.templates.TypeTemplate;
import sharpen.xobotos.output.OutputMode;
import sharpen.xobotos.output.OutputType;

public abstract class AbstractTypeBuilder<T extends ASTNode, U extends CSNode, V extends AbstractMemberTemplate<T, U>>
		extends MemberBuilder<T, U, V> implements ITypeBuilder {

	protected AbstractTypeBuilder(V template, Class<U> memberType, OutputType output, T node) {
		super(template, memberType, output, node);
	}

	@Override
	public TypeTemplate findTypeTemplate(TypeDeclaration node) {
		return getTypeTemplate().findTypeTemplate(node);
	}

	@Override
	public EnumTemplate findEnumTemplate(EnumDeclaration node) {
		return getTypeTemplate().findEnumTemplate(node);
	}

	@Override
	public boolean includeMember(ASTNode node) {
		if (getTypeTemplate().removeMember(node))
			return false;

		if (getOutputType().getModeForMember(node) == OutputMode.NOTHING)
			return false;

		return true;
	}
}
