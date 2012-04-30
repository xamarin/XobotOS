package sharpen.xobotos.api.actions;

import com.thoughtworks.xstream.annotations.XStreamAlias;

import sharpen.core.csharp.ast.CSTypeDeclaration;
import sharpen.xobotos.api.AbstractReference;
import sharpen.xobotos.generator.ITypeBuilder;

@XStreamAlias(value = "action")
public abstract class AbstractAction extends AbstractReference {

	public abstract void apply(ITypeBuilder builder, CSTypeDeclaration type);

}
