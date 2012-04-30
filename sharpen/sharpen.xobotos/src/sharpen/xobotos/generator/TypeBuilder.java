package sharpen.xobotos.generator;

import org.eclipse.jdt.core.dom.BodyDeclaration;
import org.eclipse.jdt.core.dom.MethodDeclaration;
import org.eclipse.jdt.core.dom.TypeDeclaration;

import sharpen.core.CSharpBuilder;
import sharpen.core.csharp.ast.*;
import sharpen.core.framework.BindingUtils;
import sharpen.core.framework.CSharpDriver.IBuilderDelegate;
import sharpen.core.framework.CSharpDriver.ITypeBuilderDelegate;
import sharpen.xobotos.api.actions.AbstractAction;
import sharpen.xobotos.api.actions.ModifyType;
import sharpen.xobotos.api.templates.AbstractMethodTemplate;
import sharpen.xobotos.api.templates.TypeTemplate;
import sharpen.xobotos.output.OutputMode;
import sharpen.xobotos.output.OutputType;

import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

public class TypeBuilder extends AbstractTypeBuilder<TypeDeclaration, CSTypeDeclaration, TypeTemplate> {

	private final TypeTemplate _template;

	public TypeBuilder(TypeTemplate template, OutputType output, TypeDeclaration node) {
		super(template, CSTypeDeclaration.class, output, node);
		this._template = template;
	}

	@Override
	public TypeTemplate getTypeTemplate() {
		return _template;
	}

	@Override
	public AbstractMethodTemplate<?> findMethodTemplate(MethodDeclaration node) {
		return _template.findMethodTemplate(node);
	}

	@Override
	public String getNodeName() {
		return BindingUtils.qualifiedName(getASTNode().resolveBinding());
	}

	@Override
	protected boolean buildInternal(CSharpBuilder builder, IBuilderDelegate<?> dlg, CSTypeDeclaration type) {
		ITypeBuilderDelegate delegate = (ITypeBuilderDelegate) dlg;

		if (_template.isPartial())
			type.partial(true);
		if (_template.isAbstract())
			((CSClass) type).modifier(CSClassModifier.Abstract);
		if (_template.isSealed())
			((CSClass) type).modifier(CSClassModifier.Sealed);

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
		for (final AbstractAction action : _template.getActions()) {
			action.apply(this, type);
		}

		ModifyType action = _template.getModificationAction();
		if (action != null)
			action.modify(this, getASTNode(), type);

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
}
