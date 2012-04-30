package sharpen.xobotos.generator;

import org.eclipse.jdt.core.dom.ASTNode;
import org.eclipse.jdt.core.dom.BodyDeclaration;
import org.eclipse.jdt.core.dom.MethodDeclaration;

import sharpen.core.csharp.ast.CSMember;
import sharpen.core.csharp.ast.CSNode;
import sharpen.core.framework.CSharpDriver.IMemberFilter;
import sharpen.xobotos.api.templates.AbstractMethodTemplate;
import sharpen.xobotos.api.templates.ITypeContainer;
import sharpen.xobotos.api.templates.TypeTemplate;

import java.util.List;

public interface ITypeBuilder extends ITypeContainer, IMemberFilter {
	TypeTemplate getTypeTemplate();

	AbstractMethodTemplate<?> findMethodTemplate(MethodDeclaration node);

	void addMember(CSMember member);

	<T extends BodyDeclaration> List<T> getBodyDeclarations(Class<T> klass);

	<X extends ASTNode> void registerMember(X body, MemberBuilder<X, ?, ?> builder);

	<X extends ASTNode, Y extends CSNode, Z extends MemberBuilder<X, Y, ?>> Z getMemberBuilder(
			X body, Class<Z> klass);
}
