package sharpen.xobotos.api.templates;

import org.eclipse.jdt.core.dom.BodyDeclaration;

import sharpen.core.csharp.ast.CSMember;
import sharpen.xobotos.api.actions.ModifyMember;
import sharpen.xobotos.api.bindings.IBindingProvider;
import sharpen.xobotos.generator.MemberBuilder;

public abstract class MemberTemplate<T extends BodyDeclaration, U extends CSMember>
		extends AbstractMemberTemplate<T, U> implements IBindingProvider {

	public abstract ModifyMember<T, U, ? extends MemberTemplate<T, U>, ? extends MemberBuilder<T, U, ? extends MemberTemplate<T, U>>> getModificationAction();

}
