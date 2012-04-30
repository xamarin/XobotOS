package sharpen.xobotos.generator;

import org.eclipse.jdt.core.dom.ASTNode;

import sharpen.core.CSharpBuilder;
import sharpen.core.csharp.ast.*;
import sharpen.core.framework.CSharpDriver.IBuilderDelegate;
import sharpen.xobotos.api.templates.AbstractMemberTemplate;
import sharpen.xobotos.output.OutputMode;
import sharpen.xobotos.output.OutputType;

import java.util.HashMap;
import java.util.Map;

public abstract class MemberBuilder<T extends ASTNode, U extends CSNode, V extends AbstractMemberTemplate<T, U>> {

	private final V _template;
	private final Class<U> _memberType;
	private final OutputType _outputType;
	private final T _node;

	private final Map<ASTNode, MemberBuilder<?, ?, ?>> _members;

	private U _member;

	protected MemberBuilder(V template, Class<U> memberType, OutputType output, T node) {
		this._template = template;
		this._memberType = memberType;
		this._outputType = output;
		this._node = node;

		_members = new HashMap<ASTNode, MemberBuilder<?, ?, ?>>();
	}

	public V getTemplate() {
		return _template;
	}

	public OutputType getOutputType() {
		return _outputType;
	}

	public OutputMode getOutputMode() {
		return _outputType.getMode();
	}

	public T getASTNode() {
		return _node;
	}

	public U getMember() {
		return _member;
	}

	public abstract String getNodeName();

	public <W extends CSNode> U build(CSharpBuilder builder, IBuilderDelegate<W> delegate) {
		_member = _template.createCustomMember(_node);
		if (_member != null)
			return _member;

		W member = delegate.create();
		if (member == null)
			return null;

		this._member = _memberType.cast(member);

		if (CSMember.class.isInstance(member) && _outputType.removeDocs())
			((CSMember) member).removeDocs();

		delegate.map(member);

		if (!buildInternal(builder, delegate, _member)) {
			_member = null;
			return null;
		}

		delegate.document(member);

		delegate.fixup(member);

		if (!applyActions(_member)) {
			_member = null;
			return null;
		}

		return _member;
	}

	protected abstract boolean buildInternal(CSharpBuilder builder, IBuilderDelegate<?> delegate, U member);

	protected abstract boolean applyActions(U member);

	public <X extends ASTNode> void registerMember(X body, MemberBuilder<X, ?, ?> builder) {
		_members.put(body, builder);
	}

	public <X extends ASTNode, Y extends CSNode, Z extends MemberBuilder<X, Y, ?>> Z getMemberBuilder(
			X body, Class<Z> klass) {
		MemberBuilder<?, ?, ?> member = _members.get(body);
		if ((member == null) || !klass.isInstance(member))
			return null;
		return klass.cast(member);
	}

	protected void stubBlock(CSBlock block) {
		block.clearBlock();
		CSTypeReference tref = new CSTypeReference("System.NotImplementedException");
		CSExpression ctor = new CSConstructorInvocationExpression(tref);
		CSThrowStatement stm = new CSThrowStatement(block.startPosition(), ctor);
		block.addStatement(stm);
		block.setImmutable();
	}

	@Override
	public String toString() {
		return String.format("%s(%s:%s)", getClass().getSimpleName(), getNodeName(), _template);
	}

}
