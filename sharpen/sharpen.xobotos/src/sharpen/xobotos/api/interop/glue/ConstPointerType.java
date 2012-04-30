package sharpen.xobotos.api.interop.glue;

public class ConstPointerType extends AbstractComposedTypeReference {

	public ConstPointerType(AbstractTypeReference elementType) {
		super(elementType);
	}

	public ConstPointerType(String name) {
		super(new TypeReference(name));
	}

	@Override
	public String getTypeName() {
		return "const " + getElementType().getTypeName() + "*";
	}

}
