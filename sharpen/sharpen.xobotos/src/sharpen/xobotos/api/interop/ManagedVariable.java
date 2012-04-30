package sharpen.xobotos.api.interop;

import sharpen.core.csharp.ast.*;

public final class ManagedVariable {
	private final ManagedVariable.Flags _flags;
	private final CSVariableDeclaration _decl;

	public enum Flags {
		OUT, REF
	}

	private static CSTypeReferenceExpression getEffectiveType(CSTypeReferenceExpression type, ManagedVariable.Flags flags) {
		if (flags == Flags.OUT)
			return new CSByRefTypeReference(type, true);
		else if (flags == Flags.REF)
			return new CSByRefTypeReference(type, false);
		else
			return type;
	}

	public ManagedVariable(String name, CSTypeReferenceExpression type) {
		this(name, type, null, null);
	}

	public ManagedVariable(String name, CSTypeReferenceExpression type, CSExpression init) {
		this(name, type, init, null);
	}

	public ManagedVariable(String name, CSTypeReferenceExpression type, CSExpression init,
			ManagedVariable.Flags flags) {
		this._decl = new CSVariableDeclaration(name, getEffectiveType(type, flags), init);
		this._flags = flags;
	}

	public ManagedVariable(CSVariableDeclaration decl) {
		this._decl = decl;
		this._flags = null;
	}

	public CSVariableDeclaration getDeclaration() {
		return _decl;
	}

	public String getName() {
		return _decl.name();
	}

	public CSExpression getReference() {
		return new CSReferenceExpression(_decl.name());
	}

	public CSExpression getQualifiedReference() {
		if (_flags == Flags.OUT)
			return new CSByRefExpression(getReference(), true);
		else if (_flags == Flags.REF)
			return new CSByRefExpression(getReference(), false);
		else
			return getReference();
	}

	public CSExpression getOutReference() {
		return new CSByRefExpression(getReference(), true);
	}

	public CSStatement getDeclarationStatement() {
		return new CSDeclarationStatement(-1, _decl);
	}
}
