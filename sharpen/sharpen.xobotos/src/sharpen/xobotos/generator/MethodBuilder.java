package sharpen.xobotos.generator;

import static sharpen.core.framework.Environments.my;

import org.eclipse.jdt.core.dom.IMethodBinding;
import org.eclipse.jdt.core.dom.MethodDeclaration;

import sharpen.core.CSharpBuilder;
import sharpen.core.csharp.ast.CSMethod;
import sharpen.core.csharp.ast.CSTypeDeclaration;
import sharpen.core.framework.CSharpDriver.IBuilderDelegate;
import sharpen.xobotos.api.actions.ModifyMethod;
import sharpen.xobotos.api.bindings.BindingManager;
import sharpen.xobotos.api.interop.NativeBuilder;
import sharpen.xobotos.api.interop.NativeMethodBuilder;
import sharpen.xobotos.api.templates.MethodTemplate;
import sharpen.xobotos.output.OutputType;

public class MethodBuilder extends AbstractMethodBuilder<CSMethod, MethodTemplate> {

	private final ITypeBuilder _parent;
	private final NativeMethodBuilder _native;

	public MethodBuilder(ITypeBuilder parent, MethodTemplate template, OutputType output, MethodDeclaration node,
			NativeBuilder nativeBuilder) {
		super(template, CSMethod.class, output, node);
		this._parent = parent;

		if (nativeBuilder != null)
			this._native = getNativeBuilder(nativeBuilder);
		else
			this._native = null;
	}

	private NativeMethodBuilder getNativeBuilder(NativeBuilder builder) {
		final IMethodBinding binding = getASTNode().resolveBinding();
		return my(BindingManager.class).resolveNativeBinding(binding);
	}

	@Override
	protected boolean applyActions(CSMethod method) {
		ModifyMethod action = getTemplate().getModificationAction();
		if (action != null)
			action.modify(this, getASTNode(), method);
		return true;
	}

	boolean buildNative(CSMethod method) {
		final CSTypeDeclaration parent = ((TypeBuilder) _parent).getMember();
		return _native.createPInvokeWrapper(parent, method);
	}

	@Override
	protected boolean buildInternal(CSharpBuilder builder, IBuilderDelegate<?> dlg, CSMethod method) {
		if (_native != null) {
			if (buildNative(method))
				return true;
		}

		return super.buildInternal(builder, dlg, method);
	}

}
;