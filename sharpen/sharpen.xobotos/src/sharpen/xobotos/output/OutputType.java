package sharpen.xobotos.output;

import com.thoughtworks.xstream.annotations.XStreamAlias;
import com.thoughtworks.xstream.annotations.XStreamOmitField;

import org.eclipse.jdt.core.dom.ASTNode;

import sharpen.xobotos.api.AbstractReference;

public abstract class OutputType extends AbstractReference {

	@XStreamOmitField
	public static final OutputType NAKED_STUB = new NakedStubOutput();

	@XStreamOmitField
	public static final OutputType NOTHING = new NullOutput();

	@XStreamAlias(value = "remove-docs")
	private boolean _removeDocs;

	public abstract OutputMode getMode();

	public OutputMode getModeForMember(ASTNode node) {
		return getMode();
	}

	public boolean removeChainedConstructorInvocations() {
		return false;
	}

	public boolean removeStaticConstructor() {
		return false;
	}

	public boolean removeDocs() {
		return _removeDocs;
	}

	@Override
	public String toString() {
		return String.format("OutputType(%s)", getMode());
	}
}
