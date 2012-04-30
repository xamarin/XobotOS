package sharpen.core.csharp.ast;

/**
 * CSharp AST factory.
 */
public class CSharpCode {

	public static CSField newPrivateReadonlyField(String name, CSTypeReferenceExpression type) {
    	CSField field = new CSField(name, type, CSVisibility.Private);
    	field.addModifier(CSFieldModifier.Readonly);
    	return field;
    }

	public static CSConstructor newPublicConstructor() {
		final CSConstructor constructor = new CSConstructor();
		constructor.visibility(CSVisibility.Public);
		return constructor;
    }

	public static CSReferenceExpression newReference(CSMember member) {
		return new CSReferenceExpression(member.name());
    }

	public static CSExpression newAssignment(CSExpression lhs, CSExpression rhs) {
		return new CSInfixExpression("=", lhs, rhs);
    }

}
