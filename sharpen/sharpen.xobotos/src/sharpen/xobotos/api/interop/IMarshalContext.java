package sharpen.xobotos.api.interop;

import org.eclipse.jdt.core.dom.ITypeBinding;

import sharpen.xobotos.api.interop.marshal.MarshalInfo;


public interface IMarshalContext {
	NativeConfiguration getConfig();

	MarshalInfo getMarshalInfo(ITypeBinding type);

	HelperClassBuilder getHelperClass(ITypeBinding type);
}
