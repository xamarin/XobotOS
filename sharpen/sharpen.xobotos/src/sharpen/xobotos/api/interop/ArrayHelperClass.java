package sharpen.xobotos.api.interop;

import org.eclipse.jdt.core.dom.ITypeBinding;

import sharpen.core.csharp.ast.*;
import sharpen.xobotos.api.interop.NativeMethodBuilder.ElementInfo;
import sharpen.xobotos.api.interop.glue.*;

import java.util.List;

public class ArrayHelperClass extends HelperClassBuilder {

	private final ElementInfo _elementInfo;
	private Member _lengthMember;
	private ElementMember _ptrMember;

	public ArrayHelperClass(ITypeBinding type, String name, NativeBuilder builder, ElementInfo elementInfo,
			boolean isShared) {
		super(type, name, builder, new CSArrayTypeReference(elementInfo.getManagedType(), 1),
				computeArrayType(elementInfo), isShared, isShared);
		this._elementInfo = elementInfo;
	}

	private static AbstractTypeReference computeArrayType(ElementInfo info) {
		if (!info.isClass())
			return new TemplateTypeReference("NativeArray", info.getNativeType());

		AbstractNativeTypeBuilder builder = info.getTypeBuilder();
		if (builder instanceof HelperClassBuilder) {
			HelperClassBuilder helper = (HelperClassBuilder) builder;
			if (helper.isByRef())
				return new TemplateTypeReference("NativePtrArray", helper.getRealNativeType());
		}
		return new TemplateTypeReference("NativeArray", builder.getNativeType());
	}

	@Override
	protected boolean isBlittable() {
		return HelperClassBuilder.isBlittable(_elementInfo.getType());
	}

	@Override
	protected boolean isByRef() {
		return true;
	}

	@Override
	public List<String> getIncludes() {
		return null;
	}

	@Override
	public boolean resolve(IMarshalContext context) {
		return true;
	}

	@Override
	protected void buildWrap(Method wrap, NativeVariable src) {
		if (!isBlittable()) {
			super.buildWrap(wrap, src);
			return;
		}

		ConstructorInvocation ctorCall = new ConstructorInvocation(getRealNativeType());
		ctorCall.addArgument(_lengthMember.getReference(src));
		ctorCall.addArgument(_ptrMember.getReference(src));

		wrap.getBody().addStatement(new ReturnStatement(ctorCall));
	}

	@Override
	protected void buildMembers() {
		_lengthMember = addMember(new LengthMember());
		_ptrMember = new PtrMember();
		addMember(_ptrMember);
	}

	private CSTypeReferenceExpression getManagedElementType() {
		return _elementInfo.getManagedType();
	}

	@Override
	protected CSExpression computeNativeSize(CSExpression expr) {
		CSExpression baseSize = NATIVE_SIZE.expr();
		final CSExpression elementSize;
		if (_ptrMember.isByRef()) {
			CSExpression sizeof = new CSReferenceExpression("Marshal.SizeOf");
			elementSize = new CSMethodInvocationExpression(sizeof, new CSTypeofExpression(
					new CSTypeReference("System.IntPtr")));
		} else {
			elementSize = _ptrMember.getNativeElementSizeExpr();
		}
		CSExpression length = new CSMemberReferenceExpression(expr, "Length");
		return new CSInfixExpression("+", baseSize, new CSInfixExpression("*", elementSize, length));
	}

	@Override
	protected CSExpression createInstance(ManagedVariable obj) {
		return new CSArrayCreationExpression(getManagedElementType(), _lengthMember.getReference(obj));
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
			return createAssert(new BinaryOperator("==", getReference(src), getReference(dest)));
		}

		@Override
		protected Statement marshalOut(NativeVariable src, NativeVariable dest) {
			return createAssert(new BinaryOperator("==", getReference(src), getReference(dest)));
		}
	}

	private class PtrMember extends ElementMember {
		private final String _handleName;

		public PtrMember() {
			super(_elementInfo, "ptr", "ptr", Flags.FUNCTION, Flags.POINTER);
			this._handleName = "handle_array_ptr";
		}

		@Override
		protected void createPinnedPtr(CSStruct struct, CSMethod free) {
			CSField handle = new CSField(_handleName, new CSTypeReference("GCHandle"), CSVisibility.Public);
			struct.addMember(handle);

			free.body().addStatement(
					new CSMethodInvocationExpression(new CSMemberReferenceExpression(
							new CSReferenceExpression(_handleName), "Free")));
		}

		@Override
		protected Statement unwrap(NativeVariable src, NativeVariable dest) {
			if (isBlittable()) {
				return new AssignmentStatement(getReference(dest), (new MethodInvocation(
						src.getMemberAccess("takeOwnership"))));
			}

			Block block = new Block();

			Expression alloc;
			if (TRACK_ALLOCATIONS) {
				alloc = new MethodInvocation(new TemplateFunctionReference("MarshalHelper::allocArray",
						getNativeType()), _lengthMember.getReference(src));
			} else {
				alloc = new ArrayCreationExpression(getNativeType(), _lengthMember.getReference(src));
			}
			block.addStatement(new AssignmentStatement(getReference(dest), alloc));

			LocalVariable i = new LocalVariable(new TypeReference("uint32_t"), "i");
			Expression init = new NumberLiteralExpression(0);
			Expression iRef = new VariableReference(i);

			Expression check = new BinaryOperator("<", iRef, _lengthMember.getReference(src));
			Expression update = new PostfixIncrement(i);

			ForStatement forStm = new ForStatement(i, init, check, update);

			Expression targetIdx = new IndexedExpression(getReference(dest), iRef);
			Expression srcIdx = getIndex(src, iRef);

			if (!isClass()) {
				forStm.getBody().addStatement(new AssignmentStatement(targetIdx, srcIdx));
			} else if (isByRef()) {
				forStm.getBody().addStatement(
						new AssignmentStatement(targetIdx, new MethodInvocation(
								getHelper().UNWRAP.expr(), srcIdx)));
			} else {
				Expression targetAddr = new AddressOfExpression(targetIdx);
				forStm.getBody().addStatement(
						new MethodInvocation(getHelper().DEEP_UNWRAP.expr(),
								srcIdx, targetAddr));
			}

			block.addStatement(forStm);
			return block;
		}

		@Override
		protected CSStatement getPinnedPtr(ManagedVariable arg, ManagedVariable obj, ManagedVariable pinned) {
			CSExpression handleRef = new CSMemberReferenceExpression(pinned.getReference(), _handleName);
			CSExpression createHandle = new CSMethodInvocationExpression(
					new CSReferenceExpression("GCHandle.Alloc"), arg.getReference(),
					new CSReferenceExpression("GCHandleType.Pinned"));

			CSExpression getAddr = new CSMethodInvocationExpression(new CSMemberReferenceExpression(
					handleRef, "AddrOfPinnedObject"));

			CSBlock block = new CSBlock();
			block.addStatement(new CSInfixExpression("=", handleRef, createHandle));
			block.addStatement(new CSInfixExpression("=", getReference(obj), getAddr));

			return block;
		}

		@Override
		protected CSStatement marshalIn(ManagedVariable arg, ManagedVariable obj, ManagedVariable ptr) {
			CSBlock block = new CSBlock();

			final CSExpression lengthRef = new CSMemberReferenceExpression(arg.getReference(), "Length");
			final CSExpression zero = new CSNumberLiteralExpression("0");
			final CSExpression baseSize = NATIVE_SIZE.expr();
			final CSExpression elementSize = getNativeElementSizeExpr();

			block.addStatement(new CSInfixExpression("=", getReference(obj), new CSInfixExpression("+",
					ptr.getReference(), baseSize)));

			if (isBlittable()) {
				CSExpression copyRef = new CSReferenceExpression("Marshal.Copy");
				block.addStatement(new CSMethodInvocationExpression(copyRef, arg.getReference(), zero,
						getReference(obj), lengthRef));
				return block;
			}

			ManagedVariable i = new ManagedVariable("i", new CSTypeReference("int"));
			i.getDeclaration().initializer(zero);

			CSExpression check = new CSInfixExpression("<", i.getReference(), lengthRef);
			CSForStatement forStm = new CSForStatement(-1, check);
			forStm.addInitializer(new CSDeclarationExpression(i.getDeclaration()));
			forStm.addUpdater(new CSPostfixExpression("++", i.getReference()));

			final CSExpression expr = new CSIndexedExpression(arg.getReference(), i.getReference());

			final CSTypeReference intPtrType = new CSTypeReference("System.IntPtr");
			if (isByRef()) {
				ManagedVariable vector = new ManagedVariable("vector", new CSArrayTypeReference(
						intPtrType, 1), new CSArrayCreationExpression(intPtrType, lengthRef));
				block.addStatement(vector.getDeclarationStatement());
				block.addStatement(forStm);

				CSExpression idx = new CSIndexedExpression(vector.getReference(), i.getReference());
				forStm.body().addStatement(
						new CSInfixExpression("=", idx, new CSMethodInvocationExpression(
								getHelper().MANAGED_TO_NATIVE.expr(), expr)));

				CSExpression copyRef = new CSReferenceExpression("Marshal.Copy");
				block.addStatement(new CSMethodInvocationExpression(copyRef, vector.getReference(),
						zero, getReference(obj), lengthRef));
			} else {
				ManagedVariable addr = new ManagedVariable("addr", intPtrType, getReference(obj));
				block.addStatement(addr.getDeclarationStatement());
				block.addStatement(forStm);

				forStm.addUpdater(new CSInfixExpression("+=", addr.getReference(), elementSize));
				forStm.body().addStatement(marshalIn(addr.getReference(), expr));
			}

			return block;
		}

		@Override
		protected CSStatement marshalOut(ManagedVariable arg, ManagedVariable obj, ManagedVariable ptr) {
			final CSExpression lengthRef = _lengthMember.getReference(obj);
			final CSExpression zero = new CSNumberLiteralExpression("0");
			final CSExpression elementSize = getNativeElementSizeExpr();

			if (isBlittable()) {
				return createManagedAssert(null);
			} else {
				CSBlock block = new CSBlock();

				ManagedVariable addr = new ManagedVariable("addr", new CSTypeReference("System.IntPtr"));
				addr.getDeclaration().initializer(getReference(obj));
				block.addStatement(new CSDeclarationStatement(-1, addr.getDeclaration()));

				ManagedVariable i = new ManagedVariable("i", new CSTypeReference("int"));
				i.getDeclaration().initializer(zero);

				CSExpression check = new CSInfixExpression("<", i.getReference(), lengthRef);
				CSForStatement forStm = new CSForStatement(-1, check);
				forStm.addInitializer(new CSDeclarationExpression(i.getDeclaration()));
				forStm.addUpdater(new CSPostfixExpression("++", i.getReference()));
				forStm.addUpdater(new CSInfixExpression("+=", addr.getReference(), elementSize));

				final CSExpression expr = new CSIndexedExpression(arg.getReference(), i.getReference());

				forStm.body().addStatement(
						marshalOut(addr.getReference(), expr, _elementInfo.getManagedType()));

				block.addStatement(forStm);

				return block;
			}
		}

		@Override
		protected CSStatement nativeToManaged(ManagedVariable arg, ManagedVariable obj, ManagedVariable ptr) {
			final CSExpression lengthRef = _lengthMember.getReference(obj);
			final CSExpression zero = new CSNumberLiteralExpression("0");
			final CSExpression elementSize = getNativeElementSizeExpr();

			if (isBlittable()) {
				CSExpression copyRef = new CSReferenceExpression("Marshal.Copy");
				return new CSExpressionStatement(-1, new CSMethodInvocationExpression(copyRef,
						getReference(obj), arg.getReference(), zero, lengthRef));
			}

			CSBlock block = new CSBlock();

			ManagedVariable i = new ManagedVariable("i", new CSTypeReference("int"), zero);

			final CSExpression expr = new CSIndexedExpression(arg.getReference(), i.getReference());

			CSExpression check = new CSInfixExpression("<", i.getReference(), lengthRef);
			CSForStatement forStm = new CSForStatement(-1, check);
			forStm.addInitializer(new CSDeclarationExpression(i.getDeclaration()));
			forStm.addUpdater(new CSPostfixExpression("++", i.getReference()));

			final CSTypeReference intPtrType = new CSTypeReference("System.IntPtr");
			if (isByRef()) {
				ManagedVariable vector = new ManagedVariable("vector", new CSArrayTypeReference(
						intPtrType, 1), new CSArrayCreationExpression(intPtrType, lengthRef));
				block.addStatement(vector.getDeclarationStatement());
				CSExpression copyRef = new CSReferenceExpression("Marshal.Copy");
				block.addStatement(new CSMethodInvocationExpression(copyRef, getReference(obj), vector
						.getReference(), zero, lengthRef));

				CSExpression idx = new CSIndexedExpression(vector.getReference(), i.getReference());
				forStm.body().addStatement(nativeToManaged(idx, expr, _elementInfo.getManagedType()));
			} else {
				ManagedVariable addr = new ManagedVariable("addr", new CSTypeReference("System.IntPtr"));
				addr.getDeclaration().initializer(getReference(obj));
				block.addStatement(new CSDeclarationStatement(-1, addr.getDeclaration()));

				forStm.addUpdater(new CSInfixExpression("+=", addr.getReference(), elementSize));
				forStm.body().addStatement(
						nativeToManaged(addr.getReference(), expr,
								_elementInfo.getManagedType()));
			}

			block.addStatement(forStm);

			return block;
		}

		@Override
		public CSStatement free(ManagedVariable obj) {
			if (isBlittable() || !isClass())
				return null;

			final CSExpression lengthRef = _lengthMember.getReference(obj);
			final CSExpression zero = new CSNumberLiteralExpression("0");
			final CSExpression elementSize = getNativeElementSizeExpr();

			CSBlock block = new CSBlock();

			ManagedVariable i = new ManagedVariable("i", new CSTypeReference("int"), zero);

			CSExpression check = new CSInfixExpression("<", i.getReference(), lengthRef);
			CSForStatement forStm = new CSForStatement(-1, check);
			forStm.addInitializer(new CSDeclarationExpression(i.getDeclaration()));
			forStm.addUpdater(new CSPostfixExpression("++", i.getReference()));

			final CSTypeReference intPtrType = new CSTypeReference("System.IntPtr");
			if (isByRef()) {
				ManagedVariable vector = new ManagedVariable("vector", new CSArrayTypeReference(
						intPtrType, 1), new CSArrayCreationExpression(intPtrType, lengthRef));
				block.addStatement(vector.getDeclarationStatement());

				CSExpression copyRef = new CSReferenceExpression("Marshal.Copy");
				block.addStatement(new CSMethodInvocationExpression(copyRef, getReference(obj), vector
						.getReference(), zero, lengthRef));

				CSExpression idx = new CSIndexedExpression(vector.getReference(), i.getReference());
				forStm.body().addStatement(
						new CSMethodInvocationExpression(getHelper().FREE_MANAGED_PTR.expr(),
								idx));
			} else {
				ManagedVariable addr = new ManagedVariable("addr", new CSTypeReference("System.IntPtr"),
						getReference(obj));
				block.addStatement(addr.getDeclarationStatement());

				forStm.addUpdater(new CSInfixExpression("+=", addr.getReference(), elementSize));

				forStm.body().addStatement(
						new CSMethodInvocationExpression(getHelper().DEEP_FREE_MANAGED_PTR
								.expr(),
								addr.getReference()));
			}

			block.addStatement(forStm);
			return block;
		}

		@Override
		public Statement freeMembers(NativeVariable obj) {
			final Statement freeArray;
			if (TRACK_ALLOCATIONS) {
				freeArray = new ExpressionStatement(new MethodInvocation(new TemplateFunctionReference(
						"MarshalHelper::freeArray", getNativeType()), getReference(obj),
						_lengthMember.getReference(obj)));
			} else {
				freeArray = new ArrayDestructorInvocation(getNativeType());
			}

			if (isBlittable() || !isClass())
				return freeArray;

			Block block = new Block();

			LocalVariable i = new LocalVariable(new TypeReference("uint32_t"), "i");
			Expression init = new NumberLiteralExpression(0);
			Expression iRef = new VariableReference(i);

			Expression check = new BinaryOperator("<", iRef, _lengthMember.getReference(obj));
			Expression update = new PostfixIncrement(i);

			ForStatement forStm = new ForStatement(i, init, check, update);

			Expression srcIdx = new IndexedExpression(getReference(obj), iRef);
			if (isByRef())
				forStm.getBody().addStatement(
						new MethodInvocation(getHelper().DESTRUCTOR.expr(), srcIdx));
			else
				forStm.getBody().addStatement(
						new MethodInvocation(getHelper().FREE_MEMBERS.expr(), srcIdx));

			block.addStatement(forStm);
			block.addStatement(freeArray);

			return block;
		}

		@Override
		protected Statement wrap(NativeVariable src, NativeVariable dest) {
			LocalVariable i = new LocalVariable(new TypeReference("uint32_t"), "i");
			Expression init = new NumberLiteralExpression(0);
			Expression iRef = new VariableReference(i);

			Expression check = new BinaryOperator("<", iRef, _lengthMember.getReference(src));
			Expression update = new PostfixIncrement(i);

			ForStatement forStm = new ForStatement(i, init, check, update);

			Expression srcIdx = new IndexedExpression(getReference(src), iRef);
			Expression targetIdx = getIndex(dest, iRef);

			if (!isClass()) {
				forStm.getBody().addStatement(new AssignmentStatement(targetIdx, srcIdx));
			} else if (isByRef()) {
				forStm.getBody().addStatement(
						new AssignmentStatement(targetIdx, new MethodInvocation(
								getHelper().WRAP.expr(), srcIdx)));
			} else {
				Expression destAddr = new AddressOfExpression(targetIdx);
				forStm.getBody().addStatement(
						new MethodInvocation(getHelper().WRAP.expr(), srcIdx, destAddr));
			}

			return forStm;
		}

		@Override
		protected Statement marshalOut(NativeVariable src, NativeVariable dest) {
			if (isByRef() || isBlittable())
				return createAssert(null);

			LocalVariable i = new LocalVariable(new TypeReference("uint32_t"), "i");
			Expression init = new NumberLiteralExpression(0);
			Expression iRef = new VariableReference(i);

			Expression check = new BinaryOperator("<", iRef, _lengthMember.getReference(src));
			Expression update = new PostfixIncrement(i);

			ForStatement forStm = new ForStatement(i, init, check, update);

			Expression targetIdx = new IndexedExpression(getReference(dest), iRef);
			Expression srcIdx = getIndex(src, iRef);
			Expression srcExpr = isByRef() ? new DereferenceExpression(srcIdx) : srcIdx;

			if (isClass()) {
				Expression targetAddr = new AddressOfExpression(targetIdx);
				forStm.getBody().addStatement(
						new MethodInvocation(getHelper().MARSHAL_OUT.expr(), srcExpr,
								targetAddr));
			} else {
				forStm.getBody().addStatement(new AssignmentStatement(targetIdx, srcIdx));
			}

			return forStm;
		}
	}
}
