package sharpen.xobotos.api.templates;

import com.thoughtworks.xstream.annotations.XStreamAlias;
import com.thoughtworks.xstream.annotations.XStreamAsAttribute;
import com.thoughtworks.xstream.annotations.XStreamImplicit;
import com.thoughtworks.xstream.annotations.XStreamOmitField;

import org.eclipse.jdt.core.dom.*;

import sharpen.core.csharp.ast.CSMethodBase;
import sharpen.core.csharp.ast.CSNode;
import sharpen.core.csharp.ast.CSTypeDeclaration;
import sharpen.core.framework.ByRef;
import sharpen.xobotos.api.Filter;
import sharpen.xobotos.api.TemplateVisitor;
import sharpen.xobotos.api.TemplateVisitor.VisitMode;
import sharpen.xobotos.api.actions.AbstractAction;
import sharpen.xobotos.api.actions.ModifyType;
import sharpen.xobotos.api.bindings.TypeBinding;
import sharpen.xobotos.api.interop.NativeHandle;
import sharpen.xobotos.api.interop.NativeStruct;
import sharpen.xobotos.api.interop.NativeType;
import sharpen.xobotos.config.LocationFilter.Match;
import sharpen.xobotos.config.annotations.AttributeReference;

import java.util.ArrayList;
import java.util.List;

@XStreamAlias(value="type")
public class TypeTemplate extends MemberTemplate<TypeDeclaration, CSTypeDeclaration>
implements ITypeContainer, IMemberContainer {

	@XStreamAsAttribute
	@XStreamAlias("partial")
	private boolean _partial;

	@XStreamAsAttribute
	@XStreamAlias("abstract")
	private boolean _abstract;

	@XStreamAsAttribute
	@XStreamAlias("sealed")
	private boolean _sealed;

	@XStreamAsAttribute
	@XStreamAlias("recursive")
	private boolean _recursive;

	@XStreamImplicit(itemFieldName="method")
	private List<MethodTemplate> _methods;

	@XStreamImplicit(itemFieldName="constructor")
	private List<ConstructorTemplate> _ctors;

	@XStreamImplicit(itemFieldName = "destructor")
	private List<DestructorTemplate> _destructors;

	@XStreamImplicit(itemFieldName="field")
	private List<FieldTemplate> _fields;

	@XStreamImplicit(itemFieldName="type")
	private List<TypeTemplate> _types;

	@XStreamImplicit(itemFieldName="enum")
	private List<EnumTemplate> _enums;

	@XStreamImplicit(itemFieldName = "anonymous-class")
	private List<AnonymousClassTemplate> _anonymousClasses;

	@XStreamImplicit(itemFieldName = "property")
	private List<PropertyTemplate> _properties;

	@XStreamImplicit(itemFieldName = "action")
	private List<AbstractAction> _actions;

	@XStreamImplicit(itemFieldName = "remove-members")
	private List<Filter> _removeMembers;

	@XStreamAlias("modify")
	private ModifyType _modifyType;

	@XStreamAlias("binding")
	private TypeBinding _binding;

	@XStreamAlias("native-type")
	private NativeType _nativeType;

	@XStreamOmitField
	@AttributeReference("native-handle")
	private NativeHandle _nativeHandle;

	@XStreamAlias("native-struct")
	private NativeStruct _nativeStruct;

	@Override
	public ModifyType getModificationAction() {
		return _modifyType;
	}

	@XStreamOmitField
	public final static TypeTemplate DEFAULT = new TypeTemplate();

	@Override
	public TypeTemplate getTypeTemplate() {
		return this;
	}

	public List<MethodTemplate> getMethods() {
		return unmodifiable(_methods);
	}

	public List<ConstructorTemplate> getConstructors() {
		return unmodifiable(_ctors);
	}

	public List<DestructorTemplate> getDestructors() {
		return unmodifiable(_destructors);
	}

	public List<FieldTemplate> getFields() {
		return unmodifiable(_fields);
	}

	public List<TypeTemplate> getTypes() {
		return unmodifiable(_types);
	}

	public List<AnonymousClassTemplate> getAnonymousClasses() {
		return unmodifiable(_anonymousClasses);
	}

	public List<EnumTemplate> getEnums() {
		return unmodifiable(_enums);
	}

	public List<PropertyTemplate> getProperties() {
		return unmodifiable(_properties);
	}

	public boolean isPartial() {
		return _partial;
	}

	public boolean isAbstract() {
		return _abstract;
	}

	public boolean isSealed() {
		return _sealed;
	}

	public List<AbstractAction> getActions() {
		return unmodifiableOrEmpty(_actions);
	}

	@Override
	public TypeBinding getBinding() {
		return _binding;
	}

	public NativeType getNativeType() {
		return _nativeType;
	}

	public NativeStruct getNativeStruct() {
		return _nativeStruct;
	}

	public List<AbstractMemberTemplate<?, ?>> getAllTypes() {
		List<AbstractMemberTemplate<?, ?>> list = new ArrayList<AbstractMemberTemplate<?, ?>>();
		if (_types != null)
			list.addAll(_types);
		if (_enums != null)
			list.addAll(_enums);
		if (_anonymousClasses != null)
			list.addAll(_anonymousClasses);
		return unmodifiable(list);
	}

	public List<AbstractMemberTemplate<?, ?>> getAllMembers() {
		List<AbstractMemberTemplate<?, ?>> list = new ArrayList<AbstractMemberTemplate<?, ?>>();
		if (_types != null)
			list.addAll(_types);
		if (_enums != null)
			list.addAll(_enums);
		if (_anonymousClasses != null)
			list.addAll(_anonymousClasses);
		if (_ctors != null)
			list.addAll(_ctors);
		if (_methods != null)
			list.addAll(_methods);
		if (_destructors != null)
			list.addAll(_destructors);
		if (_fields != null)
			list.addAll(_fields);
		if (_properties != null)
			list.addAll(_properties);
		return unmodifiable(list);
	}

	public boolean removeMember(ASTNode node) {
		if (_removeMembers == null)
			return false;

		for (final Filter filter : _removeMembers) {
			Match match = filter.matches(node);
			if (match == Match.NEGATIVE)
				return false;
			else if (match == Match.POSITIVE)
				return true;
		}

		return false;
	}

	public boolean visit(TemplateVisitor visitor, ASTNode member, Class<?> templateType) {
		if (member instanceof TypeDeclaration)
			return visit(visitor, getTypes(), (TypeDeclaration) member);
		else if (member instanceof EnumDeclaration)
			return visit(visitor, getEnums(), (EnumDeclaration) member);
		else if (member instanceof AnonymousClassDeclaration)
			return visit(visitor, getAnonymousClasses(), (AnonymousClassDeclaration) member);
		else if (member instanceof FieldDeclaration)
			return visit(visitor, getFields(), (FieldDeclaration) member);
		else if (member instanceof MethodDeclaration) {
			MethodDeclaration method = (MethodDeclaration) member;
			if ((templateType != null) && templateType.equals(PropertyTemplate.class))
				return visit(visitor, getProperties(), method);
			if (method.isConstructor())
				return visit(visitor, getConstructors(), method);
			else if (Filter.isDestructor(method))
				return visit(visitor, getDestructors(), method);
			else
				return visit(visitor, getMethods(), method);
		}
		return false;
	}

	public <T extends ASTNode, U extends CSNode, V extends AbstractMemberTemplate<T, U>> V findMemberTemplate(
			final T node, final V defaultValue, final Class<V> klass) {
		if (node instanceof AnonymousClassDeclaration) {
			;
		} else if (node.getParent() instanceof AnonymousClassDeclaration) {
			;
		} else if (!(node.getParent() instanceof TypeDeclaration))
			return null;
		final ByRef<V> result = new ByRef<V>();
		TemplateVisitor visitor = new TemplateVisitor() {
			@Override
			public void accept(AbstractTemplate template) {
				result.value = klass.cast(template);
			}
		};
		if (!visit(visitor, node, klass))
			return null;
		return result.value != null ? result.value : defaultValue;
	}

	@Override
	public TypeTemplate findTypeTemplate(final TypeDeclaration node) {
		return findMemberTemplate(node, _recursive ? this : DEFAULT, TypeTemplate.class);
	}

	@Override
	public EnumTemplate findEnumTemplate(final EnumDeclaration node) {
		return findMemberTemplate(node, EnumTemplate.DEFAULT, EnumTemplate.class);
	}

	@Override
	public AbstractMethodTemplate<? extends CSMethodBase> findMethodTemplate(MethodDeclaration node) {
		if (node.isConstructor())
			return findMemberTemplate(node, ConstructorTemplate.DEFAULT, ConstructorTemplate.class);
		else if (Filter.isDestructor(node))
			return findMemberTemplate(node, DestructorTemplate.DEFAULT, DestructorTemplate.class);
		else
			return findMemberTemplate(node, MethodTemplate.DEFAULT, MethodTemplate.class);
	}

	@Override
	public FieldTemplate findFieldTemplate(FieldDeclaration node) {
		return findMemberTemplate(node, FieldTemplate.DEFAULT, FieldTemplate.class);
	}

	public PropertyTemplate findPropertyTemplate(MethodDeclaration node) {
		return findMemberTemplate(node, PropertyTemplate.DEFAULT, PropertyTemplate.class);
	}

	@Override
	public AnonymousClassTemplate findAnonymousClassTemplate(AnonymousClassDeclaration node) {
		return findMemberTemplate(node, AnonymousClassTemplate.DEFAULT, AnonymousClassTemplate.class);
	}

	public CSTypeDeclaration createCustomType(TypeDeclaration node) {
		return null;
	}

	@Override
	public void visit(TemplateVisitor visitor, VisitMode mode) {
		super.visit(visitor, mode);
		List<AbstractMemberTemplate<?, ?>> list;
		if (mode == VisitMode.AllTypes)
			list = getAllTypes();
		else
			list = getAllMembers();
		for (final AbstractMemberTemplate<?, ?> template : list)
			template.visit(visitor, mode);
	}

	public boolean isMainType() {
		return false;
	}

	public NativeHandle getNativeHandle() {
		return _nativeHandle;
	}

}
