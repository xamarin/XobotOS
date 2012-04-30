package sharpen.core.csharp.ast;

public class CSAnonymousClass extends CSNode implements CSTypeContainer {

	private final CSClass _type;

	public CSAnonymousClass(CSClass type) {
		this._type = type;
	}

	public CSClass type() {
		return _type;
	}

	@Override
	public void accept(CSVisitor visitor) {
		_type.accept(visitor);
	}

	public void addType(CSType type) {
		_type.addType(type);
	}

	public void removeMember(CSMember member) {
		_type.removeMember(member);
	}

}
