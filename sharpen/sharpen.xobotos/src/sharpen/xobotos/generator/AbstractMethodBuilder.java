package sharpen.xobotos.generator;

import static sharpen.core.framework.Environments.my;

import org.eclipse.jdt.core.dom.ASTVisitor;
import org.eclipse.jdt.core.dom.ConstructorInvocation;
import org.eclipse.jdt.core.dom.IMethodBinding;
import org.eclipse.jdt.core.dom.MethodDeclaration;
import org.eclipse.jdt.core.dom.SuperConstructorInvocation;

import sharpen.core.CSharpBuilder;
import sharpen.core.Sharpen;
import sharpen.core.csharp.ast.*;
import sharpen.core.framework.BindingUtils;
import sharpen.core.framework.CSharpDriver.IBuilderDelegate;
import sharpen.core.framework.CSharpDriver.IMethodBuilderDelegate;
import sharpen.xobotos.api.bindings.BindingManager;
import sharpen.xobotos.api.templates.MemberTemplate;
import sharpen.xobotos.output.OutputMode;
import sharpen.xobotos.output.OutputType;

import java.lang.reflect.Modifier;
import java.util.ArrayList;
import java.util.List;

public abstract class AbstractMethodBuilder<T extends CSMethodBase, U extends MemberTemplate<MethodDeclaration, T>>
		extends MemberBuilder<MethodDeclaration, T, U> {

	private List<IMethodBinding> _invocationTargets;

	public AbstractMethodBuilder(U template, Class<T> memberType, OutputType output, MethodDeclaration node) {
		super(template, memberType, output, node);
	}

	public boolean isConstructor() {
		return getASTNode().isConstructor();
	}

	@Override
	public String getNodeName() {
		return BindingUtils.qualifiedSignature(getASTNode().resolveBinding());
	}

	@Override
	protected boolean buildInternal(CSharpBuilder builder, IBuilderDelegate<?> dlg, T method) {
		IMethodBuilderDelegate delegate = (IMethodBuilderDelegate) dlg;

		if (!isConstructor() && (getOutputMode() == OutputMode.ABSTRACT_STUB)) {
			((CSMethod) method).modifier(CSMethodModifier.Abstract);
			method.addAttribute(new CSAttribute("Sharpen.Stub"));
			method.setStub();
			return true;
		}

		if (Modifier.isNative(getASTNode().getModifiers())) {
			stubBlock(method.body());
			method.setStub();
			if (getOutputMode() == OutputMode.STUB)
				method.addAttribute(new CSAttribute("Sharpen.Stub"));
			else
				method.addAttribute(new CSAttribute("Sharpen.NativeStub"));
			return true;
		}

		if (getOutputMode() == OutputMode.SHARPEN) {
			delegate.mapBody(method);
			return true;
		}

		if (isConstructor() && !getOutputType().removeChainedConstructorInvocations())
			mapChainedConstructors(builder, (CSConstructor) method);

		stubBlock(method.body());
		method.setStub();

		method.addAttribute(new CSAttribute("Sharpen.Stub"));

		return true;
	}

	private void mapChainedConstructors(final CSharpBuilder builder, final CSConstructor ctor) {
		getASTNode().accept(new ASTVisitor() {

			@Override
			public boolean visit(ConstructorInvocation node) {
				addChainedConstructorInvocation(new CSThisExpression(), node.arguments(),
						node.resolveConstructorBinding());
				return false;
			}

			@Override
			public boolean visit(SuperConstructorInvocation node) {
				addChainedConstructorInvocation(new CSBaseExpression(), node.arguments(),
						node.resolveConstructorBinding());
				return false;
			}

			private void addChainedConstructorInvocation(CSExpression target, List<?> args,
					IMethodBinding binding) {
				CSConstructorInvocationExpression cie = builder.mapChainedConstructorInvocation(target,
						args, binding);
				ctor.chainedConstructorInvocation(cie);
			}

		});
	}

	protected void checkInvocationTarget(IMethodBinding binding) {
		if (!BindingManager.reportStubUsage())
			return;

		final IMethodBinding current = getASTNode().resolveBinding();
		final BindingManager.MethodEntry entry = my(BindingManager.class).lookupMethod(binding);

		if ((entry == null) || (entry.Output == null)) {
			Sharpen.Debug("[%s]: Cannot lookup target method for invocation '%s'",
					BindingUtils.qualifiedSignature(current),
					BindingUtils.qualifiedSignature(binding));
			return;
		}

		if (getOutputMode() != OutputMode.SHARPEN)
			return;

		if (entry.Output.getMode() == OutputMode.SHARPEN)
			return;

		if (_invocationTargets == null)
			_invocationTargets = new ArrayList<IMethodBinding>();
		if (_invocationTargets.contains(binding))
			return;

		Sharpen.Debug("[%s]: Invoking non-sharpened method '%s'",
				BindingUtils.qualifiedSignature(current),
				BindingUtils.qualifiedSignature(binding));
		CSAttribute attr = new CSAttribute("Sharpen.UsesStub");
		String escaped = "@\"" + BindingUtils.qualifiedSignature(binding) + "\"";
		attr.addArgument(new CSStringLiteralExpression(escaped));
		getMember().addAttribute(attr);

		_invocationTargets.add(binding);
	}

}
