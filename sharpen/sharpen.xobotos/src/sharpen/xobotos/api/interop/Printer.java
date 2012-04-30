package sharpen.xobotos.api.interop;

import sharpen.core.io.IndentedWriter;
import sharpen.xobotos.api.interop.glue.*;
import sharpen.xobotos.api.interop.glue.AbstractMember.Visibility;
import sharpen.xobotos.api.interop.glue.ClassDefinition.MemberEntry;
import sharpen.xobotos.api.interop.glue.ClassDefinition.MemberFilter;
import sharpen.xobotos.api.interop.glue.Method.Flags;

import java.util.List;

public class Printer extends Visitor {

	private final IndentedWriter _writer;
	private String _currentClass = "";

	public Printer(IndentedWriter writer) {
		this._writer = writer;
	}

	@Override
	public void visit(AbstractTypeReference node) {
		_writer.write(node.getTypeName());
	}

	@Override
	public void visit(Parameter node) {
		node.getType().accept(this);
		_writer.write(" ");
		_writer.write(node.getName());
	}

	@Override
	public void visit(Method node) {
		if (node.hasDeclaration()) {
			_writer.writeIndentation();
		} else {
			if (node.getFlags() == Flags.EXPORT) {
				_writer.writeIndentation();
				_writer.write("extern \"C\" DLL_EXPORT ");
			} else if (node.getFlags() == Flags.STATIC) {
				_writer.writeIndentation();
				if (!node.hasDeclaration())
					_writer.write("static ");
			} else {
				_writer.writeIndentation();
			}
		}

		node.getReturnType().accept(this);
		_writer.writeLine();
		_writer.writeIndentation();
		_writer.write(_currentClass + node.getName());

		_writer.write("(");
		visitCommaSeparatedList(node.getParameters());
		_writer.writeLine(")");
		node.getBody().accept(this);
		_writer.writeLine();
	}

	@Override
	public void visit(Block node) {
		_writer.writeIndentation();
		_writer.writeLine("{");
		_writer.indent();

		for (Statement stm : node.getStatements())
			stm.accept(this);

		_writer.outdent();
		_writer.writeIndentation();
		_writer.writeLine("}");
	}

	@Override
	public void visit(ExpressionStatement node) {
		_writer.writeIndentation();
		node.getExpression().accept(this);
		_writer.writeLine(";");
	}

	@Override
	public void visit(VariableReference node) {
		_writer.write(node.getVariable().getName());
	}

	@Override
	public void visit(InstanceMemberAccess node) {
		node.getParent().accept(this);
		_writer.write("->");
		_writer.write(node.getMember());
	}

	@Override
	public void visit(StructMemberAccess node) {
		node.getParent().accept(this);
		_writer.write(".");
		_writer.write(node.getMember());
	}

	@Override
	public void visit(StaticMemberAccess node) {
		node.getType().accept(this);
		_writer.write("::");
		_writer.write(node.getMember());
	}

	@Override
	public void visit(MethodInvocation node) {
		node.getExpression().accept(this);
		_writer.write("(");
		visitCommaSeparatedList(node.getArguments());
		_writer.writeBlock(")");
	}

	@Override
	public void visit(ConstructorInvocation node) {
		_writer.write("new ");
		node.getType().accept(this);
		_writer.write("(");
		visitCommaSeparatedList(node.getArguments());
		_writer.writeBlock(")");
	}

	@Override
	public void visit(DestructorInvocation node) {
		_writer.writeIndentation();
		_writer.write("delete ");
		node.getExpression().accept(this);
		_writer.writeLine(";");
	}

	@Override
	public void visit(ArrayDestructorInvocation node) {
		_writer.writeIndentation();
		_writer.write("delete[] ");
		node.getExpression().accept(this);
		_writer.writeLine(";");
	}

	@Override
	public void visit(UnaryOperator node) {
		_writer.write(node.getOperator());
		node.getExpression().accept(this);
	}

	@Override
	public void visit(CastExpression node) {
		_writer.write("(");
		node.getType().accept(this);
		_writer.writeBlock(")");
		node.getExpression().accept(this);
	}

	@Override
	public void visit(LiteralExpression node) {
		_writer.write(node.getValue());
	}

	@Override
	public void visit(ReferenceExpression node) {
		_writer.write(node.getName());
	}

	@Override
	public void visit(ConditionalExpression node) {
		node.getCondition().accept(this);
		_writer.write(" ? ");
		node.getTrueExpression().accept(this);
		_writer.write(" : ");
		node.getFalseExpression().accept(this);
	}

	@Override
	public void visit(TemplateFunctionReference node) {
		_writer.write(node.getName());
		_writer.write("<");
		visitCommaSeparatedList(node.getArguments());
		_writer.writeBlock(">");
	}

	@Override
	public void visit(LocalVariable node) {
		_writer.writeIndentation();
		node.getType().accept(this);
		_writer.write(" ");
		_writer.write(node.getName());
		if (node.getInitializer() != null) {
			_writer.write(" = ");
			node.getInitializer().accept(this);
		}
		_writer.writeLine(";");
	}

	@Override
	public void visit(AssignmentStatement node) {
		_writer.writeIndentation();
		node.getTarget().accept(this);
		_writer.write(" = ");
		node.getSource().accept(this);
		_writer.writeLine(";");
	}

	@Override
	public void visit(ReturnStatement node) {
		_writer.writeIndentation();
		_writer.write("return");
		if (node.hasReturnValue()) {
			_writer.write(" ");
			node.getExpression().accept(this);
		}
		_writer.writeLine(";");
	}

	@Override
	public void visit(StructDefinition node) {
		_writer.write("struct ");
		_writer.writeLine(node.getName());
		_writer.writeLine("{");
		_writer.indent();

		for (AbstractDefinition member : node.getMembers()) {
			member.accept(this);
		}

		_writer.outdent();
		_writer.writeLine("};");
		_writer.writeLine();
	}

	@Override
	public void visit(ClassDefinition node) {
		if (node.hasDeclaration()) {
			final String oldClass = _currentClass;
			_currentClass = _currentClass + node.getName() + "::";

			writeMemberList(node, null);

			_currentClass = oldClass;
		} else {
			_writer.write("class ");
			_writer.writeLine(node.getName());
			_writer.writeLine("{");
			_writer.indent();

			writeMemberList(node, Visibility.PUBLIC);
			writeMemberList(node, Visibility.PROTECTED);
			writeMemberList(node, Visibility.PRIVATE);

			_writer.outdent();
			_writer.writeLine("};");
			_writer.writeLine();
		}
	}

	@Override
	public void visit(Field node) {
		if (node.hasDeclaration())
			return;
		_writer.writeIndentation();
		node.getType().accept(this);
		_writer.write(" ");
		_writer.write(node.getName());
		_writer.writeLine(";");
	}

	@Override
	public void visit(Constructor node) {
		_writer.writeIndentation();
		_writer.write(_currentClass);
		node.getType().accept(this);

		_writer.write("(");
		visitCommaSeparatedList(node.getParameters());
		_writer.writeLine(")");
		node.getBody().accept(this);
		_writer.writeLine();
	}

	@Override
	public void visit(Destructor node) {
		_writer.writeIndentation();
		_writer.writeBlock("~");
		node.getType().accept(this);

		_writer.write("(");
		visitCommaSeparatedList(node.getParameters());
		_writer.writeLine(")");

		node.getBody().accept(this);
		_writer.writeLine();
	}

	@Override
	public void visit(BinaryOperator node) {
		node.getLeftExpression().accept(this);
		_writer.write(" ");
		_writer.write(node.getOperator());
		_writer.write(" ");
		node.getRightExpression().accept(this);
	}

	@Override
	public void visit(IfStatement node) {
		_writer.writeIndentation();
		_writer.write("if (");
		node.getCondition().accept(this);
		_writer.writeLine(")");
		node.getThenBlock().accept(this);
		if (!node.getElseBlock().isEmpty()) {
			_writer.writeIndentation();
			_writer.writeLine("else");
			node.getElseBlock().accept(this);
		}
	}

	@Override
	public void visit(ForStatement node) {
		_writer.writeIndentation();
		_writer.write("for(");
		if (node.getVariable() != null) {
			node.getVariable().getType().accept(this);
			_writer.write(" ");
			_writer.write(node.getVariable().getName());
			_writer.write(" = ");
		}
		node.getInitializer().accept(this);
		_writer.writeBlock(";");
		_writer.writeSpace();
		node.getCheck().accept(this);
		_writer.writeBlock(";");
		_writer.writeSpace();
		node.getUpdate().accept(this);
		_writer.writeLine(")");
		node.getBody().accept(this);
	}

	@Override
	public void visit(PostfixIncrement node) {
		_writer.write(node.getVariable().getName());
		_writer.writeBlock("++");
	}

	@Override
	public void visit(IndexedExpression node)
	{
		node.getExpression().accept(this);
		_writer.write("[");
		node.getIndex().accept(this);
		_writer.writeBlock("]");
	}

	@Override
	public void visit(ParenthesizedExpression node)
	{
		_writer.write("(");
		node.getExpression().accept(this);
		_writer.writeBlock(")");
	}

	@Override
	public void visit(ArrayCreationExpression node) {
		_writer.write("new ");
		node.getType().accept(this);
		_writer.write("[");
		node.getSize().accept(this);
		_writer.writeBlock("]");
	}

	@Override
	public void visit(CompilationUnit node) {
		node.getIncludeSection().accept(this);
		_writer.writeLine();
		visitList(node.getMembers());
		_writer.writeLine();
		visitList(node.getMethods());
	}

	@Override
	public void visit(CompilationUnitHeader node) {
		_writer.writeLine("#ifndef " + node.getConditional());
		_writer.writeLine("#define " + node.getConditional() + " 1");
		_writer.writeLine();
		node.getIncludeSection().accept(this);
		_writer.writeLine();
		visitList(node.getMembers());
		_writer.writeLine();
		visitList(node.getMethods());
		_writer.writeLine();
		_writer.writeLine("#endif");
	}

	@Override
	public void visit(IncludeDirective node) {
		_writer.write("#include ");
		if (node.searchPath())
			_writer.writeLine("<" + node.getName() + ">");
		else
			_writer.writeLine("\"" + node.getName() + "\"");
	}

	@Override
	public void visit(IncludeSection node) {
		visitList(node.getIncludes());
	}

	@Override
	public void visit(ClassDeclaration node) {
		final ClassDefinition klass = node.getDefinition();

		_writer.write("class ");
		_writer.writeLine(klass.getName());
		_writer.writeLine("{");

		writeDeclarationList(klass, Visibility.PUBLIC);
		writeDeclarationList(klass, Visibility.PROTECTED);
		writeDeclarationList(klass, Visibility.PRIVATE);

		_writer.writeLine("};");
		_writer.writeLine();
	}

	@Override
	public void visit(StructDeclaration node) {
		_writer.write("struct ");
		_writer.write(node.getDefinition().getName());
		_writer.writeLine(";");
		_writer.writeLine();
	}

	@Override
	public void visit(FieldDeclaration node) {
		final Field field = node.getDefinition();

		_writer.writeIndentation();
		field.getType().accept(this);
		_writer.write(" ");
		_writer.write(field.getName());
		_writer.writeLine(";");
	}

	@Override
	public void visit(ConstructorDeclaration node) {
		final Constructor ctor = node.getDefinition();
		_writer.writeIndentation();
		ctor.getType().accept(this);

		_writer.write("(");
		visitCommaSeparatedList(ctor.getParameters());
		_writer.writeLine(");");
	}

	@Override
	public void visit(MethodDeclaration node) {
		final Method method = node.getDefinition();

		if (method.getFlags() == Flags.EXPORT) {
			_writer.writeIndentation();
			_writer.write("extern \"C\" DLL_EXPORT ");
		} else if (method.getFlags() == Flags.STATIC) {
			_writer.writeIndentation();
			_writer.write("static ");
		} else {
			_writer.writeIndentation();
		}

		method.getReturnType().accept(this);
		_writer.write(" ");
		_writer.write(method.getName());

		_writer.write("(");
		visitCommaSeparatedList(method.getParameters());
		_writer.writeLine(");");
	}

	@Override
	public void visit(DestructorDeclaration node) {
		final Destructor dtor = node.getDefinition();

		_writer.writeIndentation();
		_writer.writeBlock("~");
		dtor.getType().accept(this);

		_writer.write("(");
		visitCommaSeparatedList(dtor.getParameters());
		_writer.writeLine(");");
	}

	private <T extends Node> void visitCommaSeparatedList(List<T> list) {
		if (list == null)
			return;
		boolean first = true;
		for (T item : list) {
			if (first)
				first = false;
			else {
				_writer.writeBlock(",");
				_writer.writeSpace();
			}
			item.accept(this);
		}
	}

	private <T extends Node> void visitList(List<T> list) {
		if (list == null)
			return;
		for (T item : list) {
			item.accept(this);
		}
	}

	private void writeMemberList(final ClassDefinition node, final Visibility visibility) {
		List<MemberEntry> members = node.getMembers(new MemberFilter() {
			@Override
			public boolean filter(MemberEntry entry) {
				if ((visibility != null) && (entry.Visibility != visibility))
					return false;
				if (node.hasDeclaration() && (entry.Definition == null))
					return false;
				return true;
			}
		});
		if (members.size() == 0)
			return;

		if (visibility != null)
			writeVisibility(visibility);

		for (MemberEntry member : members) {
			if (member.Definition != null)
				member.Definition.accept(this);
			else
				member.Declaration.accept(this);
		}

		_writer.writeLine();
	}

	private void writeDeclarationList(ClassDefinition node, final Visibility visibility) {
		List<MemberEntry> members = node.getMembers(new MemberFilter() {
			@Override
			public boolean filter(MemberEntry entry) {
				return (entry.Declaration != null) && (entry.Visibility == visibility);
			}
		});
		if (members.size() == 0)
			return;

		writeVisibility(visibility);
		_writer.indent();

		for (MemberEntry member : members)
			member.Declaration.accept(this);

		_writer.outdent();
		_writer.writeLine();
	}

	private void writeVisibility(Visibility visibility) {
		switch (visibility) {
		case PUBLIC:
			_writer.writeLine("public:");
			break;
		case PROTECTED:
			_writer.writeLine("protected:");
			break;
		case PRIVATE:
			_writer.writeLine("private:");
			break;
		}
	}

}
