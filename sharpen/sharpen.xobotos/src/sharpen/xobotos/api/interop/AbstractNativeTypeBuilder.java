package sharpen.xobotos.api.interop;

import org.eclipse.jdt.core.dom.ITypeBinding;

import sharpen.core.csharp.ast.CSExpression;
import sharpen.core.csharp.ast.CSTypeDeclaration;
import sharpen.core.csharp.ast.CSTypeReferenceExpression;
import sharpen.xobotos.api.interop.Signature.Flags;
import sharpen.xobotos.api.interop.Signature.Mode;
import sharpen.xobotos.api.interop.glue.AbstractTypeReference;
import sharpen.xobotos.api.interop.glue.CompilationUnit;
import sharpen.xobotos.api.interop.glue.CompilationUnitHeader;
import sharpen.xobotos.api.interop.glue.Expression;

public abstract class AbstractNativeTypeBuilder implements IncludeFileProvider {

	private final NativeBuilder _builder;
	private final ITypeBinding _type;

	public AbstractNativeTypeBuilder(NativeBuilder builder, ITypeBinding type) {
		this._builder = builder;
		this._type = type;
	}

	public final NativeBuilder getNativeBuilder() {
		return _builder;
	}

	public final NativeConfiguration getConfig() {
		return _builder.getConfig();
	}

	public final ITypeBinding getType() {
		return _type;
	}

	public abstract boolean resolve(IMarshalContext context);

	public abstract boolean build();

	public abstract boolean createManagedType(CSTypeDeclaration parent);

	public abstract boolean createNativeType(CompilationUnit unit);

	public abstract boolean createHeader(CompilationUnitHeader header);

	public abstract CSTypeReferenceExpression getPInvokeType();

	public abstract CSTypeReferenceExpression getManagedType();

	public abstract AbstractTypeReference getNativeType();

	public abstract AbstractTypeReference getRealNativeType();

	public abstract AbstractTypeReference getNativePInvokeType();

	public abstract void marshalManaged(IManagedMarshalContext context, CSExpression expr, Mode mode, Flags flags);

	public abstract CSExpression marshalRetval(IManagedReturnContext context, CSExpression expr);

	public abstract void marshalNative(INativeMarshalContext context, Mode mode, Flags flags);

	public abstract Expression marshalNativeRetval(Expression expr);

}
