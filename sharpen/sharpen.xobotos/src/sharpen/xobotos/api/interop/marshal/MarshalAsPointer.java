package sharpen.xobotos.api.interop.marshal;

import com.thoughtworks.xstream.annotations.XStreamAlias;

import org.eclipse.jdt.core.dom.ITypeBinding;

import sharpen.core.csharp.ast.CSTypeReference;
import sharpen.core.csharp.ast.CSTypeReferenceExpression;
import sharpen.xobotos.api.interop.Signature.Flags;
import sharpen.xobotos.api.interop.Signature.Mode;
import sharpen.xobotos.api.interop.glue.AbstractTypeReference;
import sharpen.xobotos.api.interop.glue.PointerType;

public class MarshalAsPointer extends MarshalInfo {

	@XStreamAlias("native-pointer")
	public class Entry extends MarshalEntry {
		@Override
		public MarshalInfo resolve(ITypeBinding type) {
			return new MarshalAsPointer(type);
		}
	}

	private MarshalAsPointer(ITypeBinding type) {
		super(type);
	}

	@Override
	public boolean isPrimitiveType() {
		return false;
	}

	@Override
	public CSTypeReferenceExpression getManagedType(Mode mode, Flags flags) {
		return new CSTypeReference("System.IntPtr");
	}

	@Override
	public AbstractTypeReference getNativeType(Mode mode, Flags flags) {
		return new PointerType("const void");
	}

}
