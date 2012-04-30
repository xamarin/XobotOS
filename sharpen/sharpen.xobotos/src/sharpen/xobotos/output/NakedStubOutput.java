package sharpen.xobotos.output;

import com.thoughtworks.xstream.annotations.XStreamAlias;

@XStreamAlias(value = "naked-stub")
public final class NakedStubOutput extends OutputType {

	protected NakedStubOutput() {
		// Use OutputType.NAKED_STUB
	}

	@Override
	public OutputMode getMode() {
		return OutputMode.NAKED_STUB;
	}
}

