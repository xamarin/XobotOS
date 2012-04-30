package sharpen.core.framework;

import org.eclipse.jdt.core.dom.*;

import sharpen.core.CSharpBuilder;
import sharpen.core.Configuration.MemberMapping;
import sharpen.core.csharp.ast.*;

public interface CSharpDriver {

	interface IBuilderDelegate<T extends CSNode> {
		T create();

		void map(T member);

		void document(T member);

		void fixup(T member);
	}

	CSTypeDeclaration processTypeDeclaration(CSharpBuilder builder, CSTypeContainer parent, TypeDeclaration node,
			ITypeBuilderDelegate delegate);

	interface ITypeBuilderDelegate extends IBuilderDelegate<CSTypeDeclaration> {
		void mapMembers(CSTypeDeclaration type, IMemberFilter filter);
	}

	CSMethodBase processMethodDeclaration(CSharpBuilder builder, CSTypeDeclaration parent, MethodDeclaration node,
			IMethodBuilderDelegate delegate);

	interface IMethodBuilderDelegate extends IBuilderDelegate<CSMethodBase> {
		ITypeBinding getDeclaringType();

		IMethodBinding getBaseMethod(boolean overrideOnly, boolean allowStatic);

		void mapBody(CSMethodBase method);

		void fixup(CSTypeDeclaration parent, CSMethodBase method);
	}

	CSField processFieldDeclaration(CSharpBuilder builder, CSTypeDeclaration parent, FieldDeclaration node,
			VariableDeclarationFragment fragment, IFieldBuilderDelegate delegate);

	interface IFieldBuilderDelegate extends IBuilderDelegate<CSField> {

	}

	CSProperty processPropertyDeclaration(CSharpBuilder builder, CSTypeDeclaration parent, MethodDeclaration node,
			String name, CSProperty property, IPropertyBuilderDelegate delegate);

	interface IPropertyBuilderDelegate extends IBuilderDelegate<CSProperty> {
		boolean isGetter();

		void mapBody(CSProperty property);
	}

	CSEnum processEnumDeclaration(CSharpBuilder builder, CSTypeContainer parent, EnumDeclaration node,
			IEnumBuilderDelegate delegate);

	interface IEnumBuilderDelegate extends IBuilderDelegate<CSEnum> {

	}

	CSTypeDeclaration processExtractedEnumDeclaration(CSharpBuilder builder, CSTypeContainer parent,
			EnumDeclaration node, ITypeBuilderDelegate delegate);

	interface IMemberFilter {
		boolean includeMember(ASTNode member);
	}

	CSAnonymousClass processAnonymousClass(CSharpBuilder builder, CSTypeContainer parent,
			AnonymousClassDeclaration node, IAnonymousClassBuilderDelegate delegate);

	interface IAnonymousClassBuilderDelegate extends IBuilderDelegate<CSAnonymousClass> {

	}

	String mappedTypeName(CSharpBuilder builder, ITypeBinding binding);

	CSTypeReferenceExpression mappedTypeReference(CSharpBuilder builder, ITypeBinding binding);

	CSExpression mappedMethodInvocation(CSharpBuilder builder, MethodInvocation node);

	CSExpression mappedMethodInvocationArgument(CSharpBuilder builder, MethodInvocation node, int index,
			Expression arg);

	CSExpression mappedEnumAccess(CSharpBuilder builder, Expression expr, IVariableBinding binding);

	String mappedVariableName(IVariableBinding binding);

	CSExpression mappedNullPointer(Expression expr);

	CSExpression mappedNullPointer(IVariableBinding binding);

	CSTypeReferenceExpression mappedVariableType(IVariableBinding binding);

	MemberMapping mappedMethod(IMethodBinding binding);

	CSExpression castIfNeeded(CSharpBuilder builder, ITypeBinding expectedType, ITypeBinding actualType,
			CSExpression expression);

	CSVisibility mapVisibility(ITypeBinding binding);

	CSVisibility mapVisibility(IMethodBinding binding);

	CSVisibility mapVisibility(IVariableBinding binding);

}
