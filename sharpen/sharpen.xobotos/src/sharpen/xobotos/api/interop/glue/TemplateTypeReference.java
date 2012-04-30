package sharpen.xobotos.api.interop.glue;


public class TemplateTypeReference extends AbstractTypeReference {

	private final String _name;
	private final AbstractTypeReference[] _args;

	public TemplateTypeReference(String name, AbstractTypeReference... args) {
		this._name = name;
		this._args = args;
	}

	@Override
	public String getTypeName() {
		StringBuilder sb = new StringBuilder();
		sb.append(_name);
		sb.append('<');
		for (int i = 0; i < _args.length; i++) {
			if (i > 0)
				sb.append(',');
			sb.append(_args[i].getTypeName());
		}
		sb.append('>');
		return sb.toString();
	}

}
