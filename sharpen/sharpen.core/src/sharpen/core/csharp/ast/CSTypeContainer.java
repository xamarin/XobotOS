package sharpen.core.csharp.ast;

public interface CSTypeContainer {
	void addType(CSType type);

	void removeMember(CSMember member);
}
