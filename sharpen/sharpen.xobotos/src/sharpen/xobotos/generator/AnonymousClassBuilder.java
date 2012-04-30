package sharpen.xobotos.generator;

import org.eclipse.jdt.core.dom.AnonymousClassDeclaration;
import org.eclipse.jdt.core.dom.BodyDeclaration;
import org.eclipse.jdt.core.dom.MethodDeclaration;

import sharpen.core.CSharpBuilder;
import sharpen.core.csharp.ast.CSAnonymousClass;
import sharpen.core.csharp.ast.CSMember;
import sharpen.core.framework.BindingUtils;
import sharpen.core.framework.CSharpDriver.IBuilderDelegate;
import sharpen.xobotos.api.actions.AbstractAction;
import sharpen.xobotos.api.templates.AbstractMethodTemplate;
import sharpen.xobotos.api.templates.AnonymousClassTemplate;
import sharpen.xobotos.api.templates.TypeTemplate;
import sharpen.xobotos.output.OutputType;

import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

public class AnonymousClassBuilder
extends AbstractTypeBuilder<AnonymousClassDeclaration, CSAnonymousClass, AnonymousClassTemplate> {

	protected AnonymousClassBuilder(AnonymousClassTemplate template, OutputType output,
			AnonymousClassDeclaration node) {
		super(template, CSAnonymousClass.class, output, node);
	}

	@Override
	public TypeTemplate getTypeTemplate() {
		return getTemplate().getTypeTemplate();
	}

	@Override
	public AbstractMethodTemplate<?> findMethodTemplate(MethodDeclaration node) {
		return getTypeTemplate().findMethodTemplate(node);
	}

	@Override
	public String getNodeName() {
		return BindingUtils.qualifiedName(getASTNode().resolveBinding());
	}


	@Override
	protected boolean buildInternal(CSharpBuilder builder, IBuilderDelegate<?> delegate, CSAnonymousClass member) {
		return true;
	}

	@Override
	protected boolean applyActions(CSAnonymousClass member) {
		for (final AbstractAction action : getTypeTemplate().getActions()) {
			action.apply(this, getMember().type());
		}

		return true;
	}

	@Override
	public void addMember(CSMember member) {
		getMember().type().addMember(member);
	}

	@Override
	public <T extends BodyDeclaration> List<T> getBodyDeclarations(Class<T> klass) {
		List<T> list = new ArrayList<T>();
		for (final Object o : getASTNode().bodyDeclarations()) {
			if (klass.isInstance(o))
				list.add(klass.cast(o));
		}
		return Collections.unmodifiableList(list);
	}

}
