package sharpen.xobotos.api.templates;

import com.thoughtworks.xstream.annotations.XStreamAlias;

import org.eclipse.jdt.core.dom.VariableDeclaration;

import sharpen.core.csharp.ast.CSVariableDeclaration;
import sharpen.xobotos.api.bindings.IBindingProvider;
import sharpen.xobotos.api.bindings.VariableBinding;

@XStreamAlias(value = "variable")
public class VariableTemplate extends AbstractMemberTemplate<VariableDeclaration, CSVariableDeclaration>
		implements IBindingProvider {

	@XStreamAlias("binding")
	private VariableBinding _binding;

	@Override
	public VariableBinding getBinding() {
		return _binding;
	}

}
