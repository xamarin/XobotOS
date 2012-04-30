package sharpen.core;

import org.eclipse.jdt.core.dom.TypeDeclaration;

import sharpen.core.csharp.ast.CSTypeDeclaration;


public class StaticNestedClassBuilder extends CSharpBuilder {

	private StaticNestedClassBuilder(CSharpBuilder parent) {
		super(parent);
	}

	public static CSTypeDeclaration build(CSharpBuilder parent, TypeDeclaration node) {
		StaticNestedClassBuilder builder = new StaticNestedClassBuilder(parent);
		return builder.processTypeDeclaration(node);
	}

}
