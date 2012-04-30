package sharpen.xobotos.api.interop;

import org.eclipse.jdt.core.dom.ITypeBinding;

import sharpen.core.Sharpen;
import sharpen.core.csharp.ast.*;
import sharpen.core.framework.BindingUtils;
import sharpen.xobotos.api.interop.Signature.Flags;
import sharpen.xobotos.api.interop.Signature.Mode;
import sharpen.xobotos.api.interop.glue.AbstractMember.Visibility;
import sharpen.xobotos.api.interop.glue.*;

import java.util.List;
import java.util.logging.Level;

public class NativeHandleBuilder extends AbstractNativeTypeBuilder {

	private final NativeHandle _template;
	private final String _functionPrefix;
	private final String _destructorName;
	private Method _destructor;

	public NativeHandleBuilder(NativeBuilder builder, ITypeBinding type, NativeHandle template) {
		super(builder, type);
		this._template = template;

		String fullName = BindingUtils.qualifiedName(type);
		String prefix = builder.getConfig().getFunctionPrefix();
		if (prefix != null)
			_functionPrefix = prefix + "_" + fullName.replace('.', '_');
		else
			_functionPrefix = fullName.replace('.', '_');

		this._destructorName = _functionPrefix + "_destructor";
	}

	public NativeHandle getTemplate() {
		return _template;
	}

	@Override
	public CSTypeReferenceExpression getManagedType() {
		return _template.getManagedType();
	}

	public AbstractTypeReference getNativeClass() {
		return new TypeReference(_template.getNativeClass());
	}

	@Override
	public boolean resolve(IMarshalContext context) {
		return true;
	}

	@Override
	public boolean build() {
		_destructor = createDestructor();
		return true;
	}

	@Override
	public boolean createManagedType(CSTypeDeclaration parent) {
		final CSTypeDeclaration type = new CSClass(_template.getName(), CSClassModifier.None);
		if (_template.getParent() != null) {
			type.addBaseType(_template.getParent().getManagedType());
			if (_template.getField() != null) {
				Sharpen.Log(Level.SEVERE,
						"Cannot use both 'parent' and 'field' in <native-handle> for type '%s'",
						BindingUtils.qualifiedName(getType()));
				return false;
			}
		} else {
			type.addBaseType(new CSTypeReference("System.Runtime.InteropServices.SafeHandle"));
			if (_template.getField() == null) {
				Sharpen.Log(Level.SEVERE, "Missing 'field' in <native-handle> for type '%s'",
						BindingUtils.qualifiedName(getType()));
				return false;
			}
		}

		final CSTypeReference thisTypeRef = new CSTypeReference(_template.getName());

		final CSTypeReference intPtr = new CSTypeReference("System.IntPtr");
		final CSExpression handleRef = new CSReferenceExpression("handle");
		final CSExpression thisHandleRef = new CSMemberReferenceExpression(new CSThisExpression(), "handle");
		final CSExpression zeroRef = new CSReferenceExpression("System.IntPtr.Zero");

		{
			CSConstructor ctor = new CSConstructor();
			if (_template.getParent() == null) {
				CSExpression base = new CSBaseExpression();
				CSConstructorInvocationExpression cie = new CSConstructorInvocationExpression(base);
				cie.addArgument(zeroRef);
				cie.addArgument(new CSBoolLiteralExpression(true));
				ctor.chainedConstructorInvocation(cie);
			}
			type.addMember(ctor);
		}

		{
			CSConstructor ctor = new CSConstructor();
			ctor.addParameter("handle", intPtr);
			if (_template.getParent() == null) {
				CSExpression base = new CSBaseExpression();
				CSConstructorInvocationExpression cie = new CSConstructorInvocationExpression(base);
				cie.addArgument(zeroRef);
				cie.addArgument(new CSBoolLiteralExpression(true));
				ctor.chainedConstructorInvocation(cie);
			}
			ctor.body().addStatement(new CSInfixExpression("=", thisHandleRef, handleRef));
			type.addMember(ctor);
		}

		if (_template.getParent() != null) {
			parent.addMember(type);
			return true;
		}

		{
			final CSMethod destructor = new CSMethod(_destructorName);
			destructor.dllImport(getConfig().getDllImportAttribute());
			destructor.modifier(CSMethodModifier.Extern);
			destructor.visibility(CSVisibility.Private);
			destructor.returnType(new CSTypeReference("void"));
			destructor.addParameter(new CSVariableDeclaration("handle", intPtr));
			type.addMember(destructor);
		}

		{
			CSProperty prop = new CSProperty("Handle", intPtr);
			prop.visibility(CSVisibility.Internal);
			CSBlock getter = new CSBlock();
			getter.addStatement(new CSReturnStatement(-1, handleRef));
			prop.getter(getter);
			type.addMember(prop);
		}

		{
			CSField zero = new CSField("Zero", thisTypeRef, CSVisibility.Public);
			zero.addModifier(CSFieldModifier.Static);
			zero.addModifier(CSFieldModifier.Readonly);
			zero.initializer(new CSConstructorInvocationExpression(thisTypeRef));
			type.addMember(zero);
		}

		{
			CSMethod release = new CSMethod("ReleaseHandle");
			release.returnType(new CSTypeReference("bool"));
			release.modifier(CSMethodModifier.Override);
			release.visibility(CSVisibility.Protected);
			CSExpression dtor = new CSReferenceExpression(_destructorName);
			CSMethodInvocationExpression mie = new CSMethodInvocationExpression(dtor);
			mie.addArgument(handleRef);
			CSExpression check = new CSInfixExpression("!=", handleRef, zeroRef);
			CSIfStatement ifstm = new CSIfStatement(-1, check);
			ifstm.trueBlock().addStatement(mie);
			release.body().addStatement(ifstm);
			release.body().addStatement(new CSInfixExpression("=", handleRef, zeroRef));
			release.body().addStatement(new CSReturnStatement(-1, new CSBoolLiteralExpression(true)));
			type.addMember(release);
		}

		{
			CSProperty isInvalid = new CSProperty("IsInvalid", new CSTypeReference("bool"));
			isInvalid.visibility(CSVisibility.Public);
			isInvalid.modifier(CSMethodModifier.Override);

			CSBlock getter2 = new CSBlock();
			CSExpression check = new CSInfixExpression("==", handleRef, zeroRef);
			getter2.addStatement(new CSReturnStatement(-1, check));
			isInvalid.getter(getter2);
			type.addMember(isInvalid);
		}

		if (_template.getProperty() != null) {
			CSProperty accessor = new CSProperty(_template.getProperty(),
					new CSTypeReference(_template.getName()));
			accessor.visibility(CSVisibility.Internal);
			CSBlock getter3 = new CSBlock();
			getter3.addStatement(new CSReturnStatement(-1, new CSReferenceExpression(_template.getField())));
			accessor.getter(getter3);
			parent.addMember(accessor);
		}

		if (_template.getParent() == null) {
			parent.addBaseType(new CSTypeReference("System.IDisposable"));

			CSMethod dispose = new CSMethod("Dispose");
			dispose.returnType(new CSTypeReference("void"));
			dispose.visibility(CSVisibility.Public);
			CSExpression fieldRef = new CSReferenceExpression(_template.getField());
			CSExpression disposeRef = new CSMemberReferenceExpression(fieldRef, "Dispose");
			dispose.body().addStatement(new CSMethodInvocationExpression(disposeRef));
			parent.addMember(dispose);
		}

		parent.addMember(type);
		return true;
	}

	@Override
	public boolean createNativeType(CompilationUnit unit) {
		unit.addMember(_destructor);
		return true;
	}

	@Override
	public boolean createHeader(CompilationUnitHeader header) {
		return true;
	}

	private Method createDestructor() {
		Method dtor = new Method(_destructorName, new TypeReference("void"), Visibility.PUBLIC,
				Method.Flags.EXPORT);
		NativeVariable ptr = NativeVariable.createParameter(dtor, getNativeClass(), "ptr",
				NativeVariable.Flags.BYREF);

		final Expression unrefExpr = new ReferenceExpression("SkSafeUnref");
		if (_template.hasRefCount())
			dtor.getBody().addStatement(new MethodInvocation(unrefExpr, ptr.getReference()));
		else
			dtor.getBody().addStatement(new DestructorInvocation(ptr.getReference()));

		return dtor;
	}

	@Override
	public CSTypeReferenceExpression getPInvokeType() {
		return _template.getManagedType();
	}

	@Override
	public AbstractTypeReference getNativeType() {
		return new TypeReference(_template.getNativeClass());
	}

	@Override
	public AbstractTypeReference getRealNativeType() {
		return new TypeReference(_template.getNativeClass());
	}

	@Override
	public AbstractTypeReference getNativePInvokeType() {
		return new TypeReference(_template.getNativeClass());
	}

	@Override
	public void marshalManaged(IManagedMarshalContext context, CSExpression expr, Mode mode, Flags flags) {

		final CSTypeReferenceExpression pinvokeType;
		if (flags == Flags.ELEMENT)
			pinvokeType = new CSTypeReference("System.IntPtr");
		else
			pinvokeType = getManagedType();

		final CSExpression arg;
		if (flags == Flags.ELEMENT) {
			CSExpression infix = new CSInfixExpression("!=", expr, new CSNullLiteralExpression());
			CSExpression handleRef = new CSMemberReferenceExpression(expr, "Handle");
			CSExpression zeroRef = new CSReferenceExpression("System.IntPtr.Zero");
			arg = new CSConditionalExpression(infix, handleRef, zeroRef);
		} else if (flags == Flags.ALLOW_NULL) {
			CSExpression infix = new CSInfixExpression("!=", expr, new CSNullLiteralExpression());
			CSExpression zeroRef = new CSMemberReferenceExpression(getManagedType(), "Zero");
			arg = new CSConditionalExpression(infix, expr, zeroRef);
		} else {
			arg = expr;
		}

		context.addParameter(null, pinvokeType, arg);
	}

	@Override
	public CSExpression marshalRetval(IManagedReturnContext context, CSExpression expr) {
		return expr;
	}

	@Override
	public void marshalNative(INativeMarshalContext context, Mode mode, Flags flags) {
		final AbstractTypeReference type = getNativeType();
		final NativeVariable param = context.createParameter(null, type);

		Expression expr;
		if ((mode == Mode.IN) || (mode == Mode.INSTANCE))
			expr = new DereferenceExpression(param.getReference());
		else
			expr = param.getReference();

		context.addArgument(expr);
	}

	@Override
	public Expression marshalNativeRetval(Expression expr) {
		return expr;
	}

	@Override
	public List<String> getIncludes() {
		return _template.getIncludes();
	}

}
