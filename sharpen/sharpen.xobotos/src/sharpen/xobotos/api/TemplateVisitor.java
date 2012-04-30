package sharpen.xobotos.api;

import sharpen.xobotos.api.templates.*;

public class TemplateVisitor {
	public void accept(AbstractTemplate template) {
		if (template instanceof NamespaceTemplate)
			accept((NamespaceTemplate) template);
		else if (template instanceof CompilationUnitTemplate)
			accept((CompilationUnitTemplate) template);
		else if (template instanceof TypeTemplate)
			accept((TypeTemplate) template);
		else if (template instanceof EnumTemplate)
			accept((EnumTemplate) template);
		else if (template instanceof TypeTemplate)
			accept((TypeTemplate) template);
		else if (template instanceof EnumTemplate)
			accept((EnumTemplate) template);
		else if (template instanceof ConstructorTemplate)
			accept((ConstructorTemplate) template);
		else if (template instanceof MethodTemplate)
			accept((MethodTemplate) template);
		else if (template instanceof FieldTemplate)
			accept((FieldTemplate) template);
	}

	public void accept(NamespaceTemplate namespace) {

	}

	public void accept(CompilationUnitTemplate unit) {

	}

	public void accept(TypeTemplate type) {

	}

	public void accept(EnumTemplate type) {

	}

	public void accept(ConstructorTemplate ctor) {

	}

	public void accept(MethodTemplate method) {

	}

	public void accept(FieldTemplate field) {

	}

	public enum VisitMode {
		FirstMatch,
		AllUnits,
		AllTypes,
		All
	}
}
