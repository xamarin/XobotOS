package sharpen.xobotos.api.interop.glue;

public abstract class AbstractComposedTypeReference extends AbstractTypeReference {

	private final AbstractTypeReference _elementType;

	protected AbstractComposedTypeReference(AbstractTypeReference elementType) {
		if (elementType == null)
			throw new java.lang.NullPointerException();
		this._elementType = elementType;
	}

	public AbstractTypeReference getElementType() {
		return _elementType;
	}

}
