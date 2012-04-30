package sharpen.xobotos.generator;

import org.eclipse.jdt.core.dom.MethodDeclaration;

import sharpen.core.csharp.ast.CSDestructor;
import sharpen.xobotos.api.templates.DestructorTemplate;
import sharpen.xobotos.output.OutputType;

public class DestructorBuilder extends AbstractMethodBuilder<CSDestructor, DestructorTemplate> {

	public DestructorBuilder(DestructorTemplate template, OutputType output, MethodDeclaration node) {
		super(template, CSDestructor.class, output, node);
	}

	@Override
	protected boolean applyActions(CSDestructor member) {
		return true;
	}

}
