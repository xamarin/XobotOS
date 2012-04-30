package sharpen.xobotos.api.interop;

import static sharpen.core.framework.Environments.my;

import org.eclipse.jdt.core.dom.IMethodBinding;
import org.eclipse.jdt.core.dom.MethodDeclaration;

import sharpen.core.Sharpen;
import sharpen.core.csharp.CSharpPrinter;
import sharpen.core.csharp.ast.CSCompilationUnit;
import sharpen.core.io.IndentedWriter;
import sharpen.xobotos.api.APIDefinition;
import sharpen.xobotos.api.interop.NativeMethod.Kind;
import sharpen.xobotos.api.interop.glue.CompilationUnit;
import sharpen.xobotos.api.interop.glue.CompilationUnitHeader;
import sharpen.xobotos.api.interop.glue.IncludeDirective;
import sharpen.xobotos.api.interop.glue.IncludeSection;
import sharpen.xobotos.api.interop.glue.Node;
import sharpen.xobotos.config.ConfigFile;

import java.io.File;
import java.io.FileWriter;
import java.io.IOException;
import java.net.URI;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

public class NativeBuilder {
	private final NativeConfiguration _config;
	private final String _name;
	private final String _sourceName;
	private final String _headerName;
	private final Map<String, NativeMethodBuilder> _nativeMethods = new HashMap<String, NativeMethodBuilder>();
	private final List<IncludeFileProvider> _includeProviders = new ArrayList<IncludeFileProvider>();
	private final List<AbstractNativeTypeBuilder> _nativeTypes = new ArrayList<AbstractNativeTypeBuilder>();
	private final String _functionPrefix;

	private final CompilationUnit _unit;
	private CompilationUnitHeader _header;

	public NativeBuilder(NativeConfiguration config, String name) {
		this._config = config;
		this._name = name;
		this._sourceName = _name + ".cpp";
		this._headerName = _name + ".h";

		_unit = new CompilationUnit(name);
		_unit.getIncludeSection().addIncludes(config);

		String prefix = config.getFunctionPrefix();
		if (prefix != null)
			_functionPrefix = prefix + "_" + name.replace('.', '_');
		else
			_functionPrefix = name.replace('.', '_');
	}

	public String getFunctionPrefix() {
		return _functionPrefix;
	}

	public NativeConfiguration getConfig() {
		return _config;
	}

	public IncludeDirective getHeaderInclude() {
		return new IncludeDirective(_headerName, false);
	}

	public CompilationUnit getCompilationUnit() {
		return _unit;
	}

	public void addIncludeProvider(IncludeFileProvider provider) {
		_includeProviders.add(provider);
	}

	public NativeMethodBuilder registerNativeMethod(MethodDeclaration node, NativeMethod template,
			NativeHandleBuilder nativeHandle) {
		final IMethodBinding binding = node.resolveBinding();

		String prefix = _config.getFunctionPrefix();
		if (prefix == null)
			prefix = "";
		String name;
		if (template.getKind() == Kind.DESTRUCTOR)
			name = "destructor";
		else if (template.getName() != null)
			name = template.getName();
		else
			name = binding.getName();

		String nativeName = template.getNativeName();
		if (nativeName == null)
			nativeName = name;

		String funcName = String.format("%s_%s_%s", prefix, binding.getDeclaringClass().getName(), name);
		if (_nativeMethods.containsKey(funcName)) {
			int index = 0;
			while (_nativeMethods.containsKey(funcName + "_" + index))
				index++;
			funcName = funcName + "_" + index;
		}

		NativeMethodBuilder builder = new NativeMethodBuilder(this, node, template, nativeName, funcName,
				nativeHandle);
		_nativeMethods.put(funcName, builder);
		return builder;
	}

	public void registerNativeType(AbstractNativeTypeBuilder builder) {
		_nativeTypes.add(builder);
	}

	public boolean build(boolean needsHeader) {
		collectIncludes(_unit.getIncludeSection());

		if (needsHeader) {
			String condName = _name.replace('.', '_').toUpperCase() + "_GLUE_H";
			_header = new CompilationUnitHeader(_name, condName);
			_header.setIncludeSection(_unit.getIncludeSection());

			IncludeSection newSection = new IncludeSection();
			newSection.addInclude(getHeaderInclude());
			_unit.setIncludeSection(newSection);
		}

		for (final AbstractNativeTypeBuilder builder : _nativeTypes) {
			if (!builder.build())
				return false;
		}

		for (final AbstractNativeTypeBuilder builder : _nativeTypes) {
			if (!builder.createNativeType(_unit))
				return false;
			if (needsHeader) {
				if (!builder.createHeader(_header))
					return false;
			}
		}

		for (final NativeMethodBuilder builder : _nativeMethods.values()) {
			builder.createNativeMethod(_unit);
		}

		return true;
	}

	private void collectIncludes(IncludeSection section) {
		for (IncludeFileProvider provider : _includeProviders)
			section.addIncludes(provider);
		for (IncludeFileProvider provider : _nativeTypes)
			section.addIncludes(provider);

		for (final NativeMethodBuilder builder : _nativeMethods.values()) {
			builder.collectIncludes(section);
		}
	}

	public boolean writeOutput() {
		if (!printNativeType(_config, _unit, _sourceName))
			return false;
		if (_header != null) {
			if (!printNativeType(_config, _header, _headerName))
				return false;
		}
		return true;
	}

	private static boolean printNativeType(NativeConfiguration config, Node unit, String fileName) {
		final URI projectRoot = my(APIDefinition.class).getProjectRoot();
		final String outputDir = my(ConfigFile.class).getSourceInfo().getOutputFolder();
		final String outputPath = projectRoot.getPath() + File.separatorChar + outputDir + File.separatorChar
				+ config.getOutputDir();

		if (!new File(outputPath).exists())
			new File(outputPath).mkdirs();

		final String fullSourceName = outputPath + File.separatorChar + fileName;

		FileWriter output;
		try {
			output = new FileWriter(fullSourceName);
		} catch (IOException e) {
			Sharpen.Log(e, "Cannot create native glue file '%s'", fullSourceName);
			return false;
		}
		IndentedWriter writer = new IndentedWriter(output);
		Printer printer = new Printer(writer);

		unit.accept(printer);

		try {
			output.close();
		} catch (IOException e) {
			Sharpen.Log(e, "Cannot create native glue file '%s'", fullSourceName);
			return false;
		}

		return true;
	}

	public boolean printManagedType(CSCompilationUnit unit) {
		final URI projectRoot = my(APIDefinition.class).getProjectRoot();
		final String outputDir = my(ConfigFile.class).getSourceInfo().getOutputFolder();
		final String outputPath = projectRoot.getPath() + File.separatorChar + outputDir + File.separatorChar
				+ _config.getOutputDir();

		if (!new File(outputPath).exists())
			new File(outputPath).mkdirs();

		final String fullSourceName = outputPath + File.separatorChar + _name + ".cs";

		FileWriter output;
		try {
			output = new FileWriter(fullSourceName);
		} catch (IOException e) {
			Sharpen.Log(e, "Cannot create managed glue file '%s'", fullSourceName);
			return false;
		}

		CSharpPrinter printer = new CSharpPrinter();
		printer.setWriter(output);

		printer.print(unit);

		try {
			output.close();
		} catch (IOException e) {
			Sharpen.Log(e, "Cannot create managed glue file '%s'", fullSourceName);
			return false;
		}

		return true;
	}

}
