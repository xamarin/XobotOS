package sharpen.xobotos.generator;

import org.eclipse.jdt.core.dom.ASTNode;
import org.eclipse.jdt.core.dom.BodyDeclaration;
import org.eclipse.jdt.core.dom.EnumDeclaration;
import org.eclipse.jdt.core.dom.MethodDeclaration;
import org.eclipse.jdt.core.dom.TypeDeclaration;

import sharpen.core.CSharpBuilder;
import sharpen.core.csharp.ast.CSAttribute;
import sharpen.core.csharp.ast.CSConstructor;
import sharpen.core.csharp.ast.CSMember;
import sharpen.core.csharp.ast.CSTypeDeclaration;
import sharpen.core.framework.BindingUtils;
import sharpen.core.framework.CSharpDriver.IBuilderDelegate;
import sharpen.core.framework.CSharpDriver.ITypeBuilderDelegate;
import sharpen.xobotos.api.templates.AbstractMethodTemplate;
import sharpen.xobotos.api.templates.EnumTemplate;
import sharpen.xobotos.api.templates.ExtractedEnumTemplate;
import sharpen.xobotos.api.templates.MethodTemplate;
import sharpen.xobotos.api.templates.TypeTemplate;
import sharpen.xobotos.output.OutputMode;
import sharpen.xobotos.output.OutputType;

import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

public class ExtractedEnumBuilder
extends MemberBuilder<EnumDeclaration, CSTypeDeclaration, ExtractedEnumTemplate>
implements ITypeBuilder {

	public ExtractedEnumBuilder(EnumTemplate template, OutputType output, EnumDeclaration node) {
		super(ExtractedEnumTemplate.DEFAULT, CSTypeDeclaration.class, output, node);
	}

	@Override
	public TypeTemplate getTypeTemplate() {
		return TypeTemplate.DEFAULT;
	}

	@Override
	public AbstractMethodTemplate<?> findMethodTemplate(MethodDeclaration node) {
		if (node.isConstructor())
			return null;
		else
			return MethodTemplate.DEFAULT;
	}

	@Override
	public String getNodeName() {
		return BindingUtils.qualifiedName(getASTNode().resolveBinding());
	}

	@Override
	protected boolean buildInternal(CSharpBuilder builder, IBuilderDelegate<?> dlg, CSTypeDeclaration type) {
		ITypeBuilderDelegate delegate = (ITypeBuilderDelegate) dlg;

		delegate.mapMembers(type, this);

		if (getOutputMode() == OutputMode.SHARPEN) {
			// FIXME: Put this back when I'm done.
			if (!getASTNode().resolveBinding().isNested()) {
				CSAttribute attr = new CSAttribute("Sharpen.Sharpened");
				type.addAttribute(attr);
			}
		} else if (getOutputMode() == OutputMode.STUB) {
			CSAttribute attr = new CSAttribute("Sharpen.Stub");
			type.addAttribute(attr);
		}

		if (getOutputType().removeStaticConstructor() && type.hasStaticConstructor()) {
			CSConstructor sctor = type.ensureStaticConstructor();
			stubBlock(sctor.body());
			sctor.setStub();
		}

		return true;
	}

	@Override
	public void addMember(CSMember member) {
		getMember().addMember(member);
	}

	@Override
	protected boolean applyActions(CSTypeDeclaration type) {
		return true;
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

	@Override
	public TypeTemplate findTypeTemplate(TypeDeclaration node) {
		return null;
	}

	@Override
	public EnumTemplate findEnumTemplate(EnumDeclaration node) {
		return null;
	}

	@Override
	public boolean includeMember(ASTNode node) {
		if (getOutputType().getModeForMember(node) == OutputMode.NOTHING)
			return false;

		return true;
	}

}
