package sharpen.xobotos.config.xstream;

import com.thoughtworks.xstream.XStream;
import com.thoughtworks.xstream.io.xml.Xpp3DomDriver;

import sharpen.xobotos.api.*;
import sharpen.xobotos.api.actions.*;
import sharpen.xobotos.api.bindings.*;
import sharpen.xobotos.api.interop.*;
import sharpen.xobotos.api.interop.marshal.MarshalAsClass;
import sharpen.xobotos.api.interop.marshal.MarshalAsEnum;
import sharpen.xobotos.api.interop.marshal.MarshalAsPointer;
import sharpen.xobotos.api.interop.marshal.MarshalInfo;
import sharpen.xobotos.api.templates.*;
import sharpen.xobotos.config.ConfigFile;
import sharpen.xobotos.config.LocationFilter;
import sharpen.xobotos.config.SourceInfo;
import sharpen.xobotos.output.NakedStubOutput;
import sharpen.xobotos.output.NullOutput;
import sharpen.xobotos.output.OutputType;
import sharpen.xobotos.output.SharpenOutput;
import sharpen.xobotos.output.StubOutput;

import java.io.File;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.FileWriter;
import java.io.IOException;

public final class XStreamUtils {

	private static XStream prepareXStream() {
		XStream xstream = new XStream(new Xpp3DomDriver());

		xstream.processAnnotations(new Class[] {
				ConfigFile.class,
				LocationFilter.class,
				SourceInfo.class,
				APIDefinition.IncludeFile.class,
				TemplateSection.IncludeFile.class,
				// API
				APIDefinition.class,
				Visibility.class,
				TypeReference.class,
				Filter.class,
				MemberKind.class,
				// Output Types
				OutputType.class,
				NullOutput.class,
				SharpenOutput.class,
				StubOutput.class,
				NakedStubOutput.class,
				// API Templates
				AbstractTemplate.class,
				AbstractMemberTemplate.class,
				AbstractMethodTemplate.class,
				TypeTemplate.class,
				AnonymousClassTemplate.class,
				MethodTemplate.class,
				FieldTemplate.class,
				AbstractLocationTemplate.class,
				CompilationUnitTemplate.class,
				NamespaceTemplate.class,
				DestructorTemplate.class,
				PropertyTemplate.class,
				VariableTemplate.class,
				NamespaceTemplateSection.class,
				// API Actions
				AbstractAction.class,
				MemberAction.class,
				ModifyMember.class,
				ModifyType.class,
				ModifyMethodBase.class,
				ModifyMethod.class,
				ModifyConstructor.class,
				ModifyField.class,
				ModifyProperty.class,
				ModifyEnum.class,
				ActionList.class,
				// API Bindings
				MemberBinding.class,
				AbstractTypeBinding.class,
				TypeBinding.class,
				EnumBinding.class,
				EnumBinding.ExtractedEnumInfo.class,
				AbstractTypeBinding.class,
				CompilationUnitBinding.class,
				MethodBinding.class,
				VariableBinding.class,
				// API Interop
				NativeConfiguration.class,
				NativeMethod.class,
				NativeMethod.Kind.class,
				Signature.class,
				Signature.Mode.class,
				Signature.Flags.class,
				Signature.TypeInfo.class,
				Signature.ParameterInfo.class,
				MarshalInfo.MarshalEntry.class,
				MarshalAsClass.Entry.class,
				MarshalAsEnum.Entry.class,
				MarshalAsPointer.Entry.class,
				NativeTypeTemplate.class,
				NativeHandle.class,
				NativeType.class,
				NativeStruct.class,
				NativeStruct.MemberInfo.class
		});
		return xstream;
	}

	public static <T extends IConfigurationFile> void write(String fileName, T config) throws IOException {
		FileWriter writer = new FileWriter(fileName);

		XStream xstream = prepareXStream();

		xstream.toXML(config, writer);
		writer.close();
	}

	public static <T extends IConfigurationFile> T read(String fileName, Class<T> klass) {
		try {
			FileReader reader = new FileReader(fileName);
			XStream xstream = prepareXStream();
			xstream.setMode(XStream.ID_REFERENCES);
			return klass.cast(xstream.fromXML(reader));
		} catch (FileNotFoundException e) {
			throw new RuntimeException("Cannot read configuration file: " + fileName);
		}
	}

	protected static <T extends IConfigurationFile, U extends IConfigurationFragment> U readFragment(
			RootContext<T> root, String fileName, Class<U> klass) {
		try {
			String fullName = root.getProjectRoot().getPath() + File.separatorChar + fileName;
			FileReader reader = new FileReader(fullName);
			XStream xstream = prepareXStream();
			xstream.setMarshallingStrategy(root.getMarshallingStrategy());
			U result = klass.cast(xstream.fromXML(reader));
			if (result == null)
				throw new RuntimeException("Cannot read configuration file: " + fileName);
			return result;
		} catch (FileNotFoundException e) {
			throw new RuntimeException("Cannot read configuration file: " + fileName);
		}
	}
}
