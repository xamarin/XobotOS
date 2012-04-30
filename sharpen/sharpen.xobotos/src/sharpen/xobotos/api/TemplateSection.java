package sharpen.xobotos.api;

import com.thoughtworks.xstream.annotations.XStreamAlias;
import com.thoughtworks.xstream.annotations.XStreamAsAttribute;
import com.thoughtworks.xstream.annotations.XStreamImplicit;
import com.thoughtworks.xstream.annotations.XStreamOmitField;

import sharpen.xobotos.api.actions.AbstractAction;
import sharpen.xobotos.api.bindings.MemberBinding;
import sharpen.xobotos.api.interop.NativeConfiguration;
import sharpen.xobotos.api.interop.NativeHandle;
import sharpen.xobotos.api.interop.marshal.MarshalInfo.MarshalEntry;
import sharpen.xobotos.config.annotations.ReadIncludeFile;
import sharpen.xobotos.config.annotations.ReferenceProvider;
import sharpen.xobotos.config.xstream.IConfigurationFile;
import sharpen.xobotos.output.OutputType;

import java.util.List;

@ReferenceProvider
@XStreamAlias(value = "templates")
public class TemplateSection extends AbstractReference implements IConfigurationFile {
	@SuppressWarnings("unused")
	@XStreamImplicit(itemFieldName = "action")
	private List<AbstractAction> _actions;

	@SuppressWarnings("unused")
	@XStreamImplicit(itemFieldName = "templates")
	private List<TemplateSection> _templates;

	@SuppressWarnings("unused")
	@XStreamImplicit(itemFieldName = "output-type")
	private List<OutputType> _outputTypes;

	@SuppressWarnings("unused")
	@XStreamImplicit(itemFieldName = "binding")
	private List<MemberBinding> _bindings;

	@SuppressWarnings("unused")
	@XStreamImplicit(itemFieldName = "native-config")
	private List<NativeConfiguration> _nativeConfig;

	@SuppressWarnings("unused")
	@XStreamImplicit(itemFieldName = "include-file")
	private List<IncludeFile> _includeFiles;

	@SuppressWarnings("unused")
	@XStreamImplicit(itemFieldName = "marshal-info")
	private List<MarshalEntry> _marshalInfo;

	@SuppressWarnings("unused")
	@XStreamImplicit(itemFieldName = "native-handle")
	private List<NativeHandle> _nativeHandle;

	@ReadIncludeFile(contentsField = "_contents", fileNameField = "_fileName", fileType = TemplateSection.class)
	public static final class IncludeFile {
		@XStreamAsAttribute
		@XStreamAlias("file")
		@SuppressWarnings("unused")
		private String _fileName;

		@XStreamOmitField
		@SuppressWarnings("unused")
		private TemplateSection _contents;

	}
}
