package sharpen.xobotos.api.templates;

import com.thoughtworks.xstream.annotations.XStreamAlias;
import com.thoughtworks.xstream.annotations.XStreamOmitField;

import org.eclipse.jdt.core.dom.MethodDeclaration;

import sharpen.core.csharp.ast.CSDestructor;
import sharpen.xobotos.api.actions.ModifyMember;
import sharpen.xobotos.generator.DestructorBuilder;

@XStreamAlias(value = "destructor")
public class DestructorTemplate extends AbstractMethodTemplate<CSDestructor> {

	@XStreamOmitField
	public final static DestructorTemplate DEFAULT = new DestructorTemplate();

	@Override
	public ModifyMember<MethodDeclaration, CSDestructor, DestructorTemplate, DestructorBuilder> getModificationAction() {
		return null;
	}

}
