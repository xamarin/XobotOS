package sharpen.xobotos.output;

import com.thoughtworks.xstream.annotations.XStreamAlias;

@XStreamAlias(value = "nothing")
public final class NullOutput extends OutputType {

	protected NullOutput() {
		// Use OutputType.NOTHING
	}

	@Override
	public OutputMode getMode() {
		return OutputMode.NOTHING;
	}

}
