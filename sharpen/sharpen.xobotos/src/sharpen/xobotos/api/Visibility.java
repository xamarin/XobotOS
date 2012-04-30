package sharpen.xobotos.api;

import com.thoughtworks.xstream.annotations.XStreamAlias;

@XStreamAlias(value="visibility")
public enum Visibility {
	PUBLIC,
	PROTECTED,
	PRIVATE,
	PROTECTED_INTERNAL,
	INTERNAL
}
