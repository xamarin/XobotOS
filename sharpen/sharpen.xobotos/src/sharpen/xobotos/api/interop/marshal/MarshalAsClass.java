package sharpen.xobotos.api.interop.marshal;

import com.thoughtworks.xstream.annotations.XStreamAlias;
import com.thoughtworks.xstream.annotations.XStreamAsAttribute;
import com.thoughtworks.xstream.annotations.XStreamOmitField;

import org.eclipse.jdt.core.dom.ITypeBinding;

import sharpen.core.csharp.ast.*;
import sharpen.core.framework.BindingUtils;
import sharpen.xobotos.api.interop.IManagedReturnContext;
import sharpen.xobotos.api.interop.NativeHandle;
import sharpen.xobotos.api.interop.Signature.Flags;
import sharpen.xobotos.api.interop.Signature.Mode;
import sharpen.xobotos.api.interop.glue.AbstractTypeReference;
import sharpen.xobotos.api.interop.glue.ConstPointerType;
import sharpen.xobotos.api.interop.glue.DereferenceExpression;
import sharpen.xobotos.api.interop.glue.Expression;
import sharpen.xobotos.api.interop.glue.PointerType;
import sharpen.xobotos.config.ConfigurationException;
import sharpen.xobotos.config.annotations.AttributeReference;

import java.util.Collections;
import java.util.List;

public class MarshalAsClass extends MarshalInfo {

	@XStreamAlias(value = "native-class")
	public static class Entry extends MarshalEntry {
		@XStreamOmitField
		@AttributeReference("native-handle")
		private NativeHandle _nativeHandle;

		@XStreamAsAttribute
		@XStreamAlias("flags")
		private Flags _flags;

		public NativeHandle getNativeHandle() {
			return _nativeHandle;
		}

		@Override
		public MarshalInfo resolve(ITypeBinding type) {
			if ((type != null) && type.isArray())
				return null;
			if (_nativeHandle == null)
				throw new ConfigurationException(
						"Missing 'native-handle' in MarshalAsClass");
			return new MarshalAsClass(type, _flags, _nativeHandle);
		}
	}

	private final Flags _overrideFlags;
	private final List<String> _includes;
	private final String _nativeClass;
	private final NativeHandle _nativeHandle;

	public MarshalAsClass(ITypeBinding type, Flags flags, NativeHandle handle) {
		super(type);
		this._overrideFlags = flags;
		this._includes = handle.getIncludes();
		this._nativeClass = handle.getNativeClass();
		this._nativeHandle = handle;
	}

	private boolean isManagedClass() {
		return (getType() != null) && getType().isClass();
	}

	@Override
	public boolean isPrimitiveType() {
		return true;
	}

	public String getNativeClass() {
		return _nativeClass;
	}

	public NativeHandle getNativeHandle() {
		return _nativeHandle;
	}

	@Override
	public List<String> getIncludes() {
		return _includes != null ? Collections.unmodifiableList(_includes) : null;
	}

	@Override
	public CSTypeReferenceExpression getManagedType(Mode mode, Flags flags) {
		if (flags == Flags.ELEMENT)
			return new CSTypeReference("System.IntPtr");
		else if (isManagedClass())
			return new CSTypeReference(BindingUtils.qualifiedName(getType()));
		else if (_nativeHandle != null)
			return _nativeHandle.getManagedType();
		else
			return new CSTypeReference("System.IntPtr");
	}

	@Override
	public CSTypeReferenceExpression getPInvokeType(Mode mode, Flags flags) {
		if (flags == Flags.ELEMENT)
			return new CSTypeReference("System.IntPtr");
		else
			return _nativeHandle.getManagedType();
	}

	@Override
	public AbstractTypeReference getNativeType(Mode mode, Flags flags) {
		if ((flags != Flags.ELEMENT) && (mode == Mode.IN))
			return new ConstPointerType(_nativeClass);
		else
			return new PointerType(_nativeClass);
	}

	@Override
	public CSExpression marshalIn(CSExpression expr, Mode mode, Flags flags) {
		if (flags == Flags.ELEMENT) {
			CSExpression infix = new CSInfixExpression("!=", expr, new CSNullLiteralExpression());
			CSExpression instance;
			if (isManagedClass())
				instance = new CSMemberReferenceExpression(expr, _nativeHandle.getField());
			else
				instance = expr;
			CSExpression handleRef = new CSMemberReferenceExpression(instance, "Handle");
			CSExpression zeroRef = new CSReferenceExpression("System.IntPtr.Zero");
			return new CSConditionalExpression(infix, handleRef, zeroRef);
		}

		if (isManagedClass()) {
			CSExpression infix = new CSInfixExpression("!=", expr, new CSNullLiteralExpression());
			String handle = _nativeHandle.getField();
			CSExpression handleRef = new CSMemberReferenceExpression(expr, handle);
			CSExpression zeroRef = new CSMemberReferenceExpression(_nativeHandle.getManagedType(), "Zero");
			return new CSConditionalExpression(infix, handleRef, zeroRef);
		}

		if ((flags == Flags.ALLOW_NULL) || (_overrideFlags == Flags.ALLOW_NULL)) {
			CSExpression infix = new CSInfixExpression("!=", expr, new CSNullLiteralExpression());
			CSExpression zeroRef = new CSMemberReferenceExpression(_nativeHandle.getManagedType(), "Zero");
			return new CSConditionalExpression(infix, expr, zeroRef);
		} else {
			return expr;
		}
	}

	@Override
	public CSExpression marshalRetval(IManagedReturnContext context, CSExpression expr) {
		if (isManagedClass()) {
			CSConstructorInvocationExpression cie = new CSConstructorInvocationExpression(getManagedType(
					Mode.OUT, null));
			cie.addArgument(expr);
			return cie;
		}

		return expr;
	}

	@Override
	public Expression marshalNativeArg(Expression expr, Mode mode, Flags flags) {
		if ((flags == Flags.ALLOW_NULL) || (_overrideFlags == Flags.ALLOW_NULL) || (flags == Flags.ELEMENT))
			return expr;
		if ((mode == null) || (mode == Mode.IN) || (mode == Mode.INSTANCE))
			return new DereferenceExpression(expr);
		return expr;
	}
}
