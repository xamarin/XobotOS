package sharpen.core.framework;

import java.util.*;

import org.eclipse.jdt.core.dom.*;

public class JavadocUtility {

	public static TagElement getJavadocTag(BodyDeclaration node, String tagName) {
		final List<TagElement> found = getJavadocTags(node, tagName);
		return firstTagElementOrNull(found);
	}

	
	public static TagElement getJavadocTag(PackageDeclaration node, String tagName) {
		final List<TagElement> found = getJavadocTags(node, tagName);
		return firstTagElementOrNull(found);
	}	

	private static TagElement firstTagElementOrNull(
			final List<TagElement> tagElements) {
		return tagElements.isEmpty() ? null : tagElements.get(0);
	}
	
	public static boolean containsJavadoc(BodyDeclaration node, final String tag) {
		return null != getJavadocTag(node, tag);
	}

	public static List<TagElement> getJavadocTags(PackageDeclaration node, String tagName) {
		return getJavaDocTags(node.getJavadoc(), tagName);
	}
	
	public static List<TagElement> getJavadocTags(BodyDeclaration node, String tagName) {
		return getJavaDocTags(node.getJavadoc(), tagName);
	}

	private static List<TagElement> getJavaDocTags(final Javadoc javadoc,
			String tag) {
		if (null == javadoc) {
			return Collections.emptyList();
		}
		final List<TagElement> tags = Types.cast(javadoc.tags());
		return collectTags(tags, tag, new ArrayList<TagElement>());
	}

	public static ArrayList<TagElement> collectTags(final List<TagElement> tags, String tagName, final ArrayList<TagElement> accumulator) {
		for (TagElement element : tags) {
			if (tagName.equals(element.getTagName())) {
				accumulator.add(element);
			}
		}
		return accumulator;
	}


	public static boolean isTextFragment(List<ASTNode> fragments, int index) {
		return (fragments.get(index) instanceof TextElement);
	}


	public static String textFragment(List<ASTNode> fragments, final int index) {
		return ((TextElement)fragments.get(index)).getText().trim();
	}


	public static List<ASTNode> fragmentsFrom(TagElement element) {
	    return Types.cast(element.fragments());
	}


	public static boolean hasSingleTextFragment(TagElement element) {
	    final List<ASTNode> fragments = fragmentsFrom(element);
		return fragments.size() == 1 && isTextFragment(fragments, 0);
	}


	public static String singleTextFragmentFrom(TagElement element) {
		if (!hasSingleTextFragment(element)) {
			throw new IllegalArgumentException(ASTUtility.sourceInformation(element) + ": expecting a single textual argument");
		}
		return textFragment(fragmentsFrom(element), 0);
	}

}
