package sharpen.xobotos.api.templates;

import com.thoughtworks.xstream.annotations.XStreamAlias;
import com.thoughtworks.xstream.annotations.XStreamOmitField;

import org.eclipse.jdt.core.dom.AnonymousClassDeclaration;
import org.eclipse.jdt.core.dom.EnumDeclaration;
import org.eclipse.jdt.core.dom.FieldDeclaration;
import org.eclipse.jdt.core.dom.MethodDeclaration;
import org.eclipse.jdt.core.dom.TypeDeclaration;

import sharpen.core.csharp.ast.CSAnonymousClass;

@XStreamAlias(value = "anonymous-class")
public class AnonymousClassTemplate extends AbstractMemberTemplate<AnonymousClassDeclaration, CSAnonymousClass>
		implements IMemberContainer {

	@XStreamOmitField
	public final static AnonymousClassTemplate DEFAULT = new AnonymousClassTemplate();

	@XStreamAlias("type")
	private TypeTemplate _type;

	public TypeTemplate getTypeTemplate() {
		return _type != null ? _type : TypeTemplate.DEFAULT;
	}

	@Override
	public TypeTemplate findTypeTemplate(TypeDeclaration node) {
		return getTypeTemplate().findTypeTemplate(node);
	}

	@Override
	public EnumTemplate findEnumTemplate(EnumDeclaration node) {
		return getTypeTemplate().findEnumTemplate(node);
	}

	@Override
	public FieldTemplate findFieldTemplate(FieldDeclaration node) {
		return getTypeTemplate().findFieldTemplate(node);
	}

	@Override
	public AbstractMethodTemplate<?> findMethodTemplate(MethodDeclaration node) {
		return getTypeTemplate().findMethodTemplate(node);
	}

	@Override
	public AnonymousClassTemplate findAnonymousClassTemplate(AnonymousClassDeclaration node) {
		return getTypeTemplate().findAnonymousClassTemplate(node);
	}
}
