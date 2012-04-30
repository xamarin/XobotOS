package sharpen.xobotos.api.interop.glue;

public class ReferenceType extends AbstractComposedTypeReference {

	public ReferenceType(AbstractTypeReference elementType) {
		super(elementType);
	}

	public ReferenceType(String name) {
		super(new TypeReference(name));
	}

	@Override
	public String getTypeName() {
		return getElementType().getTypeName() + "&";
	}

}
