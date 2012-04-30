package sharpen.xobotos.api.interop.glue;


public abstract class Visitor {

	public abstract void visit(AbstractTypeReference node);

	public abstract void visit(Parameter node);

	public abstract void visit(Method node);

	public abstract void visit(Block node);

	public abstract void visit(ExpressionStatement node);

	public abstract void visit(VariableReference node);

	public abstract void visit(InstanceMemberAccess node);

	public abstract void visit(StructMemberAccess node);

	public abstract void visit(StaticMemberAccess node);

	public abstract void visit(MethodInvocation node);

	public abstract void visit(ConstructorInvocation node);

	public abstract void visit(DestructorInvocation node);

	public abstract void visit(ArrayDestructorInvocation node);

	public abstract void visit(UnaryOperator node);

	public abstract void visit(CastExpression node);

	public abstract void visit(LiteralExpression node);

	public abstract void visit(ReferenceExpression node);

	public abstract void visit(ConditionalExpression node);

	public abstract void visit(TemplateFunctionReference node);

	public abstract void visit(LocalVariable node);

	public abstract void visit(AssignmentStatement node);

	public abstract void visit(ReturnStatement node);

	public abstract void visit(IfStatement node);

	public abstract void visit(ForStatement node);

	public abstract void visit(StructDefinition node);

	public abstract void visit(ClassDefinition node);

	public abstract void visit(Field node);

	public abstract void visit(Constructor node);

	public abstract void visit(Destructor node);

	public abstract void visit(BinaryOperator node);

	public abstract void visit(PostfixIncrement node);

	public abstract void visit(IndexedExpression node);

	public abstract void visit(ParenthesizedExpression node);

	public abstract void visit(ArrayCreationExpression node);

	public abstract void visit(CompilationUnit node);

	public abstract void visit(CompilationUnitHeader node);

	public abstract void visit(IncludeDirective node);

	public abstract void visit(ClassDeclaration node);

	public abstract void visit(StructDeclaration node);

	public abstract void visit(FieldDeclaration node);

	public abstract void visit(ConstructorDeclaration node);

	public abstract void visit(MethodDeclaration node);

	public abstract void visit(DestructorDeclaration node);

	public abstract void visit(IncludeSection node);

}
