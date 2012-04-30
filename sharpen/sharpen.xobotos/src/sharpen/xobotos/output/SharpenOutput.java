package sharpen.xobotos.output;

import com.thoughtworks.xstream.annotations.XStreamAlias;

@XStreamAlias(value = "sharpen")
public final class SharpenOutput extends OutputType {

	@Override
	public OutputMode getMode() {
		return OutputMode.SHARPEN;
	}

}
