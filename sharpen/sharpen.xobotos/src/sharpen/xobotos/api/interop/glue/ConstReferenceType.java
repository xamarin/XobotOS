package sharpen.xobotos.api.interop.glue;

public class ConstReferenceType extends AbstractComposedTypeReference {

	public ConstReferenceType(AbstractTypeReference elementType) {
		super(elementType);
	}

	public ConstReferenceType(String name) {
		super(new TypeReference(name));
	}

	@Override
	public String getTypeName() {
		return "const " + getElementType().getTypeName() + "&";
	}

}
