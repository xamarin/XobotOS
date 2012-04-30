package sharpen.core.csharp.ast;

public class CSDllImport {

	private final String _dllName;
	private final CallingConvention _cconv;
	private final CharSet _charSet;

	public CSDllImport(String dllName) {
		this(dllName, null, null);
	}

	public CSDllImport(String dllName, CallingConvention cconv) {
		this(dllName, cconv, null);
	}

	public CSDllImport(String dllName, CallingConvention cconv, CharSet charSet) {
		this._dllName = dllName;
		this._cconv = cconv;
		this._charSet = charSet;
	}

	public String getDllName() {
		return _dllName;
	}

	public CallingConvention getCallingConvention() {
		return _cconv;
	}

	public enum CallingConvention {
		Winapi,
		CDecl,
		StdCall,
		ThisCall
	}

	public CharSet getCharSet() {
		return _charSet;
	}

	public enum CharSet {
		Ansi,
		Unicode,
		Auto
	}

}
