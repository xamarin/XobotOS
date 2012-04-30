package sharpen.xobotos.api.actions;

import com.thoughtworks.xstream.annotations.XStreamAlias;
import com.thoughtworks.xstream.annotations.XStreamAsAttribute;

import org.eclipse.jdt.core.dom.FieldDeclaration;

import sharpen.core.csharp.ast.CSField;
import sharpen.core.csharp.ast.CSStringLiteralExpression;
import sharpen.xobotos.api.TypeReference;
import sharpen.xobotos.api.templates.FieldTemplate;
import sharpen.xobotos.generator.FieldBuilder;

@XStreamAlias(value = "modify-field")
public class ModifyField extends ModifyMember<FieldDeclaration, CSField, FieldTemplate, FieldBuilder> {

	@XStreamAlias("field-type")
	private TypeReference _fieldType;

	@XStreamAlias("field-initializer")
	private FieldInitializer _fieldInitializer;

	@Override
	protected Class<FieldDeclaration> getNodeType() {
		return FieldDeclaration.class;
	}

	@Override
	protected Class<FieldBuilder> getBuilderType() {
		return FieldBuilder.class;
	}

	@Override
	public void modify(FieldBuilder builder, FieldDeclaration node, CSField field) {
		if (_fieldType != null)
			field.type(_fieldType.getExpression());
		if (_fieldInitializer != null) {
			final String code = _fieldInitializer.code();
			if (code != null)
				field.initializer(new CSStringLiteralExpression(code));
			else
				field.initializer(null);
		}
		super.modify(builder, node, field);
	}

	@XStreamAlias("field-initializer")
	class FieldInitializer {
		@XStreamAsAttribute
		@XStreamAlias("code")
		private String _code;

		public String code() {
			return _code;
		}
	}

}
