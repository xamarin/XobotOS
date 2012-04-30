package sharpen.xobotos.api;

import sharpen.xobotos.config.annotations.ReferenceById;

@ReferenceById("id")
public class AbstractReference {
	private final String id = null;

	public String getId() {
		return id;
	}
}
