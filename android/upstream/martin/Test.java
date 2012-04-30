package martin;

public class Test {

	public static void run() {
		Foo foo = new Foo();
		foo.hello = 128;
		foo.a = new int[] { 3, 5, 11, 28 };

		hello(foo.a);
		if (foo.a[0] != 999)
			throw new IllegalStateException();
		foo(foo);

		Foo[] bar = new Foo[] { foo };
		bar(bar);

		outFunc(foo);
		System.out.printf("%x\n", foo.hello);
		if(foo.hello != 0x87654321)
			throw new IllegalStateException();

		Foo ret = retFunc();
		System.out.printf("%x\n", ret.hello);
		if(ret.hello != 0xdeadbeaf)
			throw new IllegalStateException();

		Blittable blittable = new Blittable();
		blittable.hello = 0x12345678;

		System.out.println("Blittable test!");
		blittableFunc(blittable);
		System.out.printf("%x\n", blittable.hello);
		blittableRef(blittable);
		System.out.printf("%x\n", blittable.hello);
		if(blittable.hello != 0xdeadbeaf)
			throw new IllegalStateException();
		
		Complex c = complexRet();
		complex(c);
		
		stringFunc("Hello World!");
		
		System.out.println("Calling stringArray()");
		dumpMemoryUsage();
		
		stringArray(new String[] { "Hello", "World" });
		
		System.out.println("Done calling stringArray()");
		dumpMemoryUsage();
		
		String testStr = returnString();
		System.out.printf("Got string: |%s|\n", testStr);

		dumpMemoryUsage();
		
		String[] strArray = returnStringArray();
		System.out.printf("Got string array: %d\n", strArray.length);
		for(String str : strArray)
			System.out.println(str);
		
		dumpMemoryUsage();
		
		int[] intArray = returnIntArray();
		System.out.printf("Got int array: %d (%d,%d)\n", intArray.length, intArray[0], intArray[1]);
		
		dumpMemoryUsage();
	}

	private int mObject;
	
	static native void dumpMemoryUsage();

	static native void hello(int[] a);

	static native void foo(Foo arg);

	static native void bar(Foo[] arg);

	static native void refFunc(Foo arg);

	static native void outFunc(Foo arg);

	static native Foo retFunc();
	
	static native void blittableFunc(Blittable arg);

	static native void blittableRef(Blittable arg);
	
	static native void complex(Complex arg);
	
	static native Complex complexRet();
	
	static native void stringFunc(String str);
	
	static native void stringArray(String[] array);

	static native String returnString();
	
	static native String[] returnStringArray();
	
	static native int[] returnIntArray();

	static class Foo {
		public int hello;
		public int[] a;
	}
	
	static class Blittable {
		public int hello;
	}
	
	static class Complex {
		public Foo[] foo;
		public String str;
	}

}
