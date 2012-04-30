package sharpen.xobotos.api.interop;

import org.eclipse.jdt.core.dom.ITypeBinding;

import sharpen.core.csharp.ast.*;
import sharpen.xobotos.api.interop.glue.*;

import java.util.List;

public class StringHelperClass extends HelperClassBuilder {

	private Member _length;
	private Member _ptr;

	public StringHelperClass(NativeBuilder builder, ITypeBinding type) {
		super(type, "String", builder, new CSTypeReference("string"),
				new TypeReference("NativeString"), true, true);
	}

	@Override
	protected boolean isByRef() {
		return true;
	}

	@Override
	protected void buildMembers() {
		_length = addMember(new LengthMember());
		_ptr = addMember(new PtrMember());
	}

	@Override
	public List<String> getIncludes() {
		return null;
	}

	@Override
	protected boolean isBlittable() {
		return false;
	}

	@Override
	protected CSExpression computeNativeSize(CSExpression expr) {
		return new CSMethodInvocationExpression(new CSReferenceExpression("Marshal.SizeOf"),
				new CSTypeofExpression(getManagedStructType()));
	}

	@Override
	protected CSExpression createInstance(ManagedVariable obj) {
		CSExpression marshal = new CSReferenceExpression("Marshal.PtrToStringUni");
		return new CSMethodInvocationExpression(marshal, _ptr.getReference(obj), _length.getReference(obj));
	}

	@Override
	public boolean resolve(IMarshalContext context) {
		return true;
	}

	private class LengthMember extends Member {
		public LengthMember() {
			super(new TypeReference("uint32_t"), new CSTypeReference("int"), "length", "length",
					Flags.FUNCTION, Flags.PASS_TO_CTOR);
		}

		@Override
		protected Statement unwrap(NativeVariable src, NativeVariable dest) {
			return new AssignmentStatement(getReference(dest), getReference(src));
		}

		@Override
		protected void createPinnedPtr(CSStruct struct, CSMethod free) {
			;
		}

		@Override
		protected CSStatement getPinnedPtr(ManagedVariable arg, ManagedVariable obj, ManagedVariable pinned) {
			final CSExpression length = new CSMemberReferenceExpression(arg.getReference(), "Length");
			return new CSExpressionStatement(-1, new CSInfixExpression("=", getReference(obj), length));
		}

		@Override
		protected CSStatement marshalIn(ManagedVariable arg, ManagedVariable obj, ManagedVariable ptr) {
			final CSExpression length = new CSMemberReferenceExpression(arg.getReference(), "Length");
			return new CSExpressionStatement(-1, new CSInfixExpression("=", getReference(obj), length));
		}

		@Override
		protected CSStatement marshalOut(ManagedVariable arg, ManagedVariable obj, ManagedVariable ptr) {
			return createManagedAssert(new CSInfixExpression("!=", getReference(obj),
					new CSMemberReferenceExpression(arg.getReference(), "Length")));
		}

		@Override
		protected CSStatement nativeToManaged(ManagedVariable arg, ManagedVariable obj, ManagedVariable ptr) {
			return createManagedAssert(new CSInfixExpression("!=", getReference(obj),
					new CSMemberReferenceExpression(arg.getReference(), "Length")));
		}

		@Override
		public CSStatement free(ManagedVariable obj) {
			return null;
		}

		@Override
		public Statement freeMembers(NativeVariable obj) {
			return null;
		}

		@Override
		protected Statement wrap(NativeVariable src, NativeVariable dest) {
			return null;
		}

		@Override
		protected Statement marshalOut(NativeVariable src, NativeVariable dest) {
			return createAssert(new BoolLiteralExpression(false));
		}
	}

	private class PtrMember extends Member {
		public PtrMember() {
			super(new PointerType(new TypeReference("char16_t")), new CSTypeReference("System.IntPtr"),
					"ptr", "ptr", Flags.FUNCTION, Flags.PASS_TO_CTOR);
		}

		@Override
		protected void createPinnedPtr(CSStruct struct, CSMethod dtor) {
			throw new IllegalStateException();
		}

		@Override
		protected CSStatement getPinnedPtr(ManagedVariable arg, ManagedVariable obj, ManagedVariable pinned) {
			throw new IllegalStateException();
		}

		@Override
		protected CSStatement marshalIn(ManagedVariable arg, ManagedVariable obj, ManagedVariable ptr) {
			CSExpression marshal = new CSReferenceExpression("Marshal.StringToHGlobalUni");
			return new CSExpressionStatement(-1, new CSInfixExpression("=", getReference(obj),
					new CSMethodInvocationExpression(marshal, arg.getReference())));
		}

		@Override
		protected CSStatement marshalOut(ManagedVariable arg, ManagedVariable obj, ManagedVariable ptr) {
			return null;
		}

		@Override
		protected CSStatement nativeToManaged(ManagedVariable arg, ManagedVariable obj, ManagedVariable ptr) {
			return null;
		}

		@Override
		public CSStatement free(ManagedVariable obj) {
			return new CSExpressionStatement(-1, new CSMethodInvocationExpression(
					new CSReferenceExpression("Marshal.FreeHGlobal"), getReference(obj)));
		}

		@Override
		protected Statement unwrap(NativeVariable src, NativeVariable dest) {
			return new AssignmentStatement(getReference(dest), (new MethodInvocation(
					src.getMemberAccess("takeOwnership"))));
		}

		@Override
		protected Statement freeMembers(NativeVariable obj) {
			if (!TRACK_ALLOCATIONS)
				return new ArrayDestructorInvocation(getReference(obj));

			return new ExpressionStatement(new MethodInvocation(new TemplateFunctionReference(
					"MarshalHelper::freeArray", new TypeReference("char16_t")), getReference(obj),
					_length.getReference(obj)));
		}

		@Override
		protected Statement wrap(NativeVariable src, NativeVariable dest) {
			return null;
		}

		@Override
		protected Statement marshalOut(NativeVariable src, NativeVariable dest) {
			return null;
		}
	}

}
