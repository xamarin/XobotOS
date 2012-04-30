package sharpen.xobotos.api.interop.glue;

public class PointerType extends AbstractComposedTypeReference {

	public PointerType(AbstractTypeReference elementType) {
		super(elementType);
	}

	public PointerType(String name) {
		super(new TypeReference(name));
	}

	@Override
	public String getTypeName() {
		return getElementType().getTypeName() + "*";
	}

}
