package sharpen.xobotos.api.interop.glue;

import sharpen.xobotos.api.interop.IncludeFileProvider;

import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

public class IncludeSection extends Node {

	private final List<IncludeDirective> _includes = new ArrayList<IncludeDirective>();

	public void addInclude(IncludeDirective include) {
		for (IncludeDirective entry : _includes) {
			if (entry.getName().equals(include.getName()))
				return;
		}
		_includes.add(include);
	}

	public void addInclude(String name) {
		for (IncludeDirective include : _includes) {
			if (include.getName().equals(name))
				return;
		}
		_includes.add(new IncludeDirective(name, true));
	}

	public void addIncludes(List<String> includes) {
		if (includes != null) {
			for (String include : includes)
				addInclude(include);
		}
	}

	public void addIncludes(IncludeFileProvider provider) {
		if (provider != null)
			addIncludes(provider.getIncludes());
	}

	public List<IncludeDirective> getIncludes() {
		return Collections.unmodifiableList(_includes);
	}

	@Override
	public void accept(Visitor visitor) {
		visitor.visit(this);
	}

}
