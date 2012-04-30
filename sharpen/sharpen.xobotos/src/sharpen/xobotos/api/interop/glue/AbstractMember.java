package sharpen.xobotos.api.interop.glue;


public abstract class AbstractMember extends Node {

	private final Visibility _visibility;

	protected AbstractMember(Visibility visibility) {
		this._visibility = visibility;
	}

	public enum Visibility {
		PUBLIC,
		PROTECTED,
		PRIVATE
	}

	public Visibility getVisibility() {
		return _visibility;
	}

}
