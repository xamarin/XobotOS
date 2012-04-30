package sharpen.core.csharp.ast;

public class CSStructLayout {

	public CSStructLayout(LayoutKind kind) {
		this._kind = kind;
	}

	private final LayoutKind _kind;

	public LayoutKind getLayoutKind() {
		return _kind;
	}

	public enum LayoutKind {
		Sequential,
		Explicit,
		Auto
	}

}
