package sharpen.xobotos.api;

import com.thoughtworks.xstream.annotations.XStreamAlias;
import com.thoughtworks.xstream.annotations.XStreamAsAttribute;
import com.thoughtworks.xstream.annotations.XStreamImplicit;

import org.eclipse.jdt.core.dom.*;

import sharpen.core.framework.BindingUtils;
import sharpen.xobotos.config.LocationFilter.Match;

import java.lang.reflect.Modifier;
import java.util.List;

@XStreamAlias(value="filter")
public class Filter {
	@XStreamImplicit(itemFieldName="visibility")
	private List<Visibility> _visibility;

	@XStreamAlias("member-kind")
	private MemberKind _kind;

	@XStreamAsAttribute
	@XStreamAlias("regex")
	private boolean _regex;

	@XStreamImplicit(itemFieldName = "name")
	private List<String> _names;

	@XStreamAsAttribute
	@XStreamAlias("exclude")
	private boolean _exclude;

	public boolean isExcludeFilter() {
		return _exclude;
	}

	private boolean matchesVisibility(BodyDeclaration node) {
		if (_visibility == null)
			return true;

		for (final Visibility visibility : _visibility) {
			if (matchesVisibility(node, visibility))
				return true;
		}

		return false;
	}

	private static boolean matchesVisibility(BodyDeclaration node, Visibility visibility) {
		if (visibility == Visibility.PUBLIC)
			return Modifier.isPublic(node.getModifiers());
		else if (visibility == Visibility.PROTECTED)
			return Modifier.isProtected(node.getModifiers());
		else if (visibility == Visibility.PRIVATE)
			return Modifier.isPrivate(node.getModifiers());
		return false;
	}

	private boolean matchesMemberKind(ASTNode node) {
		if (_kind == null)
			return true;

		return matchesMemberKind(node, _kind);
	}

	public static boolean isDestructor(MethodDeclaration node) {
		return node.getName().toString().equals("finalize");
	}

	private static boolean matchesMemberKind(ASTNode node, MemberKind kind) {
		switch (kind) {
		case CLASS:
		case INTERFACE:
		case ANONYMOUS_CLASS:
			if (node instanceof AnonymousClassDeclaration)
				return kind == MemberKind.ANONYMOUS_CLASS;
			if (!(node instanceof TypeDeclaration))
				return false;
			TypeDeclaration tdecl = (TypeDeclaration) node;
			if (kind == MemberKind.CLASS)
				return !tdecl.isInterface();
			else if (kind == MemberKind.INTERFACE)
				return tdecl.isInterface();
			else
				return tdecl.resolveBinding().isAnonymous();
		case ENUM:
			return node instanceof EnumDeclaration;
		case METHOD:
		case CONSTRUCTOR:
		case DESTRUCTOR:
			if (!(node instanceof MethodDeclaration))
				return false;
			MethodDeclaration mdecl = (MethodDeclaration) node;
			if (kind == MemberKind.DESTRUCTOR)
				return isDestructor(mdecl);
			else if (kind == MemberKind.CONSTRUCTOR)
				return mdecl.isConstructor();
			else
				return !isDestructor(mdecl) && !mdecl.isConstructor();
		case STATIC_CONSTRUCTOR:
			if (!(node instanceof Initializer))
				return false;
			Initializer initializer = (Initializer) node;
			return Modifier.isStatic(initializer.getModifiers());
		case FIELD:
			return node instanceof FieldDeclaration;
		default:
			return false;
		}
	}

	public static String methodSignature(IMethodBinding binding) {
		StringBuffer buf = new StringBuffer();
		buf.append(binding.getName());
		buf.append('(');
		ITypeBinding[] parameterTypes = binding.getParameterTypes();
		for (int i = 0; i < parameterTypes.length; i++) {
			if (i != 0)
				buf.append(",");
			buf.append(BindingUtils.qualifiedName(parameterTypes[i]));
		}
		buf.append(')');
		return buf.toString();
	}

	private boolean matchesName(BodyDeclaration node) {
		if (_names == null)
			return true;

		for (final String name : _names) {
			if (matchesName(node, name, _regex))
				return true;
		}

		return false;
	}

	public static boolean matchesName(ASTNode node, String pattern, boolean regex) {
		if (node instanceof AbstractTypeDeclaration) {
			final AbstractTypeDeclaration tdecl = (AbstractTypeDeclaration) node;
			final ITypeBinding binding = tdecl.resolveBinding();
			final String fullName = binding.getName();

			if (regex)
				return pattern.matches(fullName);
			else
				return pattern.equals(fullName);
		}

		if (node instanceof MethodDeclaration) {
			final MethodDeclaration mdecl = (MethodDeclaration) node;
			final IMethodBinding binding = mdecl.resolveBinding();
			final String fullSignature = methodSignature(binding);
			final String fullName = binding.getName();

			if (regex)
				return fullSignature.matches(pattern);
			else if (pattern.indexOf('(') > 0)
				return pattern.equals(fullSignature);
			else
				return pattern.equals(fullName);
		}

		if (node instanceof FieldDeclaration) {
			final FieldDeclaration fdecl = (FieldDeclaration) node;
			if (fdecl.fragments().size() != 1)
				return false;

			final Object firstFragment = fdecl.fragments().get(0);
			final IVariableBinding binding = ((VariableDeclarationFragment) firstFragment).resolveBinding();
			final String fullName = binding.getName();

			if (regex)
				return pattern.matches(fullName);
			else
				return pattern.matches(fullName);
		}

		if (node instanceof VariableDeclarationFragment) {
			final VariableDeclarationFragment fragment = (VariableDeclarationFragment) node;
			final IVariableBinding binding = fragment.resolveBinding();
			final String fullName = binding.getName();

			if (regex)
				return pattern.matches(fullName);
			else
				return pattern.matches(fullName);
		}

		return false;
	}

	private boolean matchesInternal(ASTNode node) {
		if (!matchesMemberKind(node))
			return false;

		if (!(node instanceof BodyDeclaration))
			return false;

		BodyDeclaration body = (BodyDeclaration) node;
		if (!matchesVisibility(body))
			return false;

		return matchesName(body);
	}

	public Match matches(ASTNode node) {
		if (!matchesInternal(node))
			return Match.NO_MATCH;

		return _exclude ? Match.NEGATIVE : Match.POSITIVE;
	}

}
