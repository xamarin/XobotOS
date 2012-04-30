package sharpen.xobotos.output;

import com.thoughtworks.xstream.annotations.XStreamAlias;

import org.eclipse.jdt.core.dom.ASTNode;
import org.eclipse.jdt.core.dom.AnonymousClassDeclaration;
import org.eclipse.jdt.core.dom.BodyDeclaration;
import org.eclipse.jdt.core.dom.FieldDeclaration;
import org.eclipse.jdt.core.dom.Modifier;

@XStreamAlias(value = "stub")
public class StubOutput extends OutputType {

	@XStreamAlias(value = "abstract")
	private boolean _abstract;
	@XStreamAlias(value = "remove-fields")
	private boolean _removeFields;
	@XStreamAlias(value = "remove-non-public")
	private boolean _removeNonPublic;
	@XStreamAlias(value = "remove-chained-constructors")
	private boolean _removeChainedCtors;
	@XStreamAlias(value = "remove-anonymous-classes")
	private boolean _removeAnonymousClasses;
	@XStreamAlias(value = "remove-static-constructor")
	private boolean _removeStaticCtor;

	@Override
	public OutputMode getMode() {
		return OutputMode.STUB;
	}

	@Override
	public OutputMode getModeForMember(ASTNode node) {
		if (node instanceof AnonymousClassDeclaration) {
			AnonymousClassDeclaration anon = (AnonymousClassDeclaration) node;
			if (_removeAnonymousClasses)
				return OutputMode.NOTHING;
			if (_removeNonPublic && Modifier.isPrivate(anon.resolveBinding().getModifiers()))
				return OutputMode.NAKED_STUB;
		}
		if (node instanceof BodyDeclaration) {
			BodyDeclaration body = (BodyDeclaration) node;
			if (_removeFields && (body instanceof FieldDeclaration))
				return OutputMode.NOTHING;
			if (_removeNonPublic && Modifier.isPrivate(body.getModifiers()))
				return OutputMode.NOTHING;
			if (_abstract)
				return OutputMode.ABSTRACT_STUB;
		}
		return OutputMode.STUB;
	}

	@Override
	public boolean removeChainedConstructorInvocations() {
		return _removeChainedCtors;
	}

	@Override
	public boolean removeStaticConstructor() {
		return _removeStaticCtor;
	}

}
