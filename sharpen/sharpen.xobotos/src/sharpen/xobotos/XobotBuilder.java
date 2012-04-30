package sharpen.xobotos;

import org.eclipse.core.resources.IFolder;
import org.eclipse.core.resources.IProject;
import org.eclipse.core.runtime.CoreException;
import org.eclipse.core.runtime.IPath;
import org.eclipse.core.runtime.IProgressMonitor;
import org.eclipse.core.runtime.SubProgressMonitor;
import org.eclipse.jdt.core.ICompilationUnit;
import org.eclipse.jdt.core.compiler.IProblem;
import org.eclipse.jdt.core.dom.AST;
import org.eclipse.jdt.core.dom.ASTParser;
import org.eclipse.jdt.core.dom.ASTRequestor;
import org.eclipse.jdt.core.dom.CompilationUnit;

import sharpen.core.Configuration.NameMapping;
import sharpen.core.Sharpen;
import sharpen.core.csharp.CSharpPrinter;
import sharpen.core.csharp.ast.CSCompilationUnit;
import sharpen.core.framework.ASTResolver;
import sharpen.core.framework.ByRef;
import sharpen.core.framework.CompilationUnitPair;
import sharpen.core.framework.DefaultASTResolver;
import sharpen.core.framework.Environments;
import sharpen.core.framework.resources.WorkspaceUtilities;
import sharpen.xobotos.api.APIDefinition;
import sharpen.xobotos.api.bindings.BindingManager;
import sharpen.xobotos.config.CSProjectFile;
import sharpen.xobotos.config.ConfigFile;
import sharpen.xobotos.config.LocationFilter;
import sharpen.xobotos.config.LocationFilter.Match;
import sharpen.xobotos.config.SourceInfo;
import sharpen.xobotos.config.xstream.RootContext;
import sharpen.xobotos.generator.CompilationUnitBuilder;

import java.io.*;
import java.net.URI;
import java.util.*;
import java.util.Map.Entry;
import java.util.logging.Level;

public class XobotBuilder {
	private final ConfigFile _configFile;
	private final XobotConfiguration _config;
	private final XobotLogger _logger;

	private final IProject _project;
	private final Map<ICompilationUnit, Boolean> _sources;
	private final Map<ICompilationUnit, Boolean> _mustParse = new HashMap<ICompilationUnit, Boolean>();

	private final URI _root;

	private final SourceInfo _sourceInfo;
	private final IFolder _sourceFolder;
	private final IFolder _outputFolder;

	private final APIDefinition _api;

	private boolean _foundErrors;

	final static int PARSING_PRICE = 5;
	final static int GENERATING_PRICE = 3;
	final static int OUTPUT_PRICE = 2;

	protected XobotBuilder(ConfigFile configFile, XobotLogger logger, IProject project,
			Map<ICompilationUnit, Boolean> sources) {
		this._configFile = configFile;
		this._logger = logger;
		this._project = project;
		this._sources = sources;
		this._config = new XobotConfiguration(_configFile);

		addLogFile();

		_root = _project.getLocationURI();

		_sourceInfo = _configFile.getSourceInfo();
		_sourceFolder = _project.getFolder(_sourceInfo.getSourceFolder());
		_outputFolder = _project.getFolder(_sourceInfo.getOutputFolder());

		String apiFileName = configFile.getAPIDefinitionFileName();
		_api = RootContext.readConfigurationFile(_root, apiFileName, APIDefinition.class, _config);
	}

	private void addLogFile() {
		ConfigFile.LogFileEntry logFile = _configFile.getLogFile();
		if (logFile == null)
			return;

		try {
			File file = getProjectFile(logFile.path);
			_logger.setLogFile(file, logFile.append);
		} catch (Exception e) {
			Sharpen.Log(e, "Cannot create log file '%s'", logFile.path);
		}
	}

	public File getProjectFile(String fileName) {
		return _project.getLocation().append(fileName).toFile();
	}

	public XobotConfiguration getConfig() {
		return _config;
	}

	public ConfigFile getConfigFile() {
		return _configFile;
	}

	protected boolean run(final IProgressMonitor monitor) {
		Sharpen.Log(Level.INFO, "Starting build");

		try {
			checkFileList();
		} catch (Exception e) {
			Sharpen.Log(e, "Cannot compute file list");
			return false;
		}

		int countModified = 0;
		for (final Entry<ICompilationUnit, Boolean> entry : _sources.entrySet()) {
			if (!entry.getValue())
				continue;
			++countModified;
			_mustParse.put(entry.getKey(), true);
		}

		if (countModified < 1) {
			Sharpen.Log(Level.INFO, "Nothing to do.");
			return true;
		}

		List<ICompilationUnit> parsingList = new ArrayList<ICompilationUnit>();
		for (final Entry<ICompilationUnit, Boolean> entry : _mustParse.entrySet()) {
			if (!entry.getValue())
				continue;
			parsingList.add(entry.getKey());
		}

		final int totalWork = parsingList.size() * PARSING_PRICE + countModified
				* (GENERATING_PRICE + OUTPUT_PRICE);

		Sharpen.Log(Level.INFO, "Converting %d files (must parse %d).", countModified, parsingList.size());

		monitor.beginTask("Converting", totalWork);

		final List<CompilationUnitPair> pairs = stage1_parse(parsingList, monitor);
		if (monitor.isCanceled() || (pairs == null) || (pairs.size() == 0))
			return false;

		if (!stage1b_checkForErrors(pairs)) {
			Sharpen.Log(Level.SEVERE, "Found errors while parsing compilation units; aborting!");
			return false;
		}

		AST ast = pairs.get(0).ast.getAST();
		final BindingManager bindings = new BindingManager(ast, _configFile.getNativeConfig());

		final ByRef<Map<ICompilationUnit, CompilationUnitBuilder>> builders = new ByRef<Map<ICompilationUnit, CompilationUnitBuilder>>();
		Environments.runWith(Environments.newClosedEnvironment(_api, bindings, _config), new Runnable() {
			@Override
			public void run() {
				builders.value = stage2_preprocess(bindings, pairs);
			}
		});

		if (monitor.isCanceled())
			return false;
		if (builders.value == null) {
			Sharpen.Log(Level.SEVERE, "Found errors while pre-processing; aborting!");
			return false;
		}

		final List<CompilationUnitPair> modifiedPairs = new ArrayList<CompilationUnitPair>();
		final List<CompilationUnitBuilder> modified = new ArrayList<CompilationUnitBuilder>();

		for (final CompilationUnitBuilder builder : builders.value.values()) {
			if (_sources.get(builder.getPair().source)) {
				modifiedPairs.add(builder.getPair());
				modified.add(builder);
			}
		}

		final ASTResolver resolver = new DefaultASTResolver(modifiedPairs);
		final ByRef<Boolean> ok = new ByRef<Boolean>();

		Environments.runWith(Environments.newClosedEnvironment(_api, bindings, _config, _configFile, resolver),
				new Runnable() {
			@Override
			public void run() {
				ok.value = stage3_generate(monitor, modified);
			}
		});

		if (monitor.isCanceled() || !ok.value)
			return false;

		Environments.runWith(Environments.newClosedEnvironment(_api, bindings, _config, _configFile, resolver),
				new Runnable() {
			@Override
			public void run() {
				// ok.value =
				// stage4_post_processs(monitor,
				// modified);
				ok.value = bindings.postProcess();
			}
		});
		if (monitor.isCanceled() || !ok.value)
			return false;

		Environments.runWith(Environments.newClosedEnvironment(_api, bindings, _config, _configFile, resolver),
				new Runnable() {
			@Override
			public void run() {
				ok.value = stage4_save_output(monitor, modified);
			}
		});
		if (monitor.isCanceled() || !ok.value)
			return false;

		return stage5_generate_csproj();
	}

	public static boolean run(ConfigFile configFile, IProject project, Map<ICompilationUnit, Boolean> sources,
			IProgressMonitor monitor) {
		final Date startTime = new Date();
		final XobotLogger logger = new XobotLogger();
		boolean foundErrors = false;

		try {
			XobotBuilder builder = new XobotBuilder(configFile, logger, project, sources);
			if (!builder.run(monitor)) {
				foundErrors = true;
				return false;
			}
			foundErrors = builder._foundErrors;
			return true;
		} catch (Exception e) {
			Sharpen.Log(e, "Sharpen builder caught unhandled exception");
			foundErrors = true;
			return false;
		} finally {
			if (monitor.isCanceled())
				Sharpen.Log(Level.SEVERE, "Sharpening aborted at %s.", formatEndTime(startTime));
			else if (foundErrors)
				Sharpen.Log(Level.SEVERE, "Conversion finished with errors at %s.",
						formatEndTime(startTime));
			else
				Sharpen.Log(Level.SEVERE, "Conversion finished successfully at %s.",
						formatEndTime(startTime));

			monitor.done();
			logger.close();
		}
	}

	private static String formatEndTime(Date startTime) {
		Date endTime = new Date();
		long timeDiff = endTime.getTime() - startTime.getTime();
		return String.format("%s (%d seconds)", endTime, timeDiff / 1000);
	}

	private void collectAllFiles(ArrayList<String> files, URI root, File directory, String suffix) {
		for (final File file : directory.listFiles()) {
			if (file.isDirectory())
				collectAllFiles(files, root, file, suffix);
			else {
				if ((suffix != null) && !file.getName().endsWith(suffix))
					continue;
				files.add(root.relativize(file.toURI()).getPath());
			}
		}
	}

	private void checkFileList() {
		final IPath sourcePath = _sourceFolder.getLocation();
		final IPath outputPath = _outputFolder.getLocation();
		final URI outputURI = outputPath.toFile().toURI();

		final SourceInfo sourceInfo = _configFile.getSourceInfo();
		final List<LocationFilter> excludeFilters = sourceInfo.getLocationFilters();

		ArrayList<String> extraCSharpSources = new ArrayList<String>();
		for (final String dir : sourceInfo.getExtraCSharpSources()) {
			File path = _project.getLocation().append(dir).toFile();
			collectAllFiles(extraCSharpSources, path.toURI(), path, ".cs");
		}

		for (final Entry<ICompilationUnit, Boolean> entry : _sources.entrySet()) {
			final ICompilationUnit unit = entry.getKey();

			String unitName = getUnitName(unit);
			String sourceName = unitName.replace('.', '/') + ".java";
			File sourceFile = sourcePath.append(sourceName).toFile();
			String outputName = unitName.replace('.', '/') + ".cs";
			File outputFile = outputPath.append(outputName).toFile();
			URI uri = outputURI.relativize(outputFile.toURI());

			if (_api.compilationUnitDefinesBindings(unitName)) {
				/*
				 * This CompilationUnit defines bindings. We
				 * must always parse it, but don't need to
				 * regenerate it if the output is up-to-date.
				 */
				_mustParse.put(unit, true);
			}

			if (extraCSharpSources.contains(uri.getPath())) {
				entry.setValue(false);
				continue;
			}

			if (outputFile.exists() && (outputFile.lastModified() >= sourceFile.lastModified())) {
				entry.setValue(false);
				continue;
			}

			/*
			 * Check location filters.
			 */

			Match match = Match.NO_MATCH;

			for (final LocationFilter filter : excludeFilters) {
				match = filter.matches(unitName);
				if (match != Match.NO_MATCH)
					break;
			}

			if (match != Match.NO_MATCH) {
				entry.setValue(match == Match.POSITIVE);
				continue;
			}

			/*
			 * Default to building.
			 */

			entry.setValue(true);
		}
	}

	public String getUnitName(ICompilationUnit unit) {
		String packageName = unit.getParent().getElementName();
		String unitName = unit.getElementName().split("\\.")[0];
		if (packageName.length() > 0)
			unitName = _config.applyNamespaceMappings(packageName) + '.' + unitName;
		return unitName;
	}

	private List<CompilationUnitPair> stage1_parse(final List<ICompilationUnit> sources, IProgressMonitor monitor) {
		final int totalWork = PARSING_PRICE * sources.size();
		final IProgressMonitor subMonitor = new SubProgressMonitor(monitor, totalWork);

		final ArrayList<CompilationUnitPair> pairs = new ArrayList<CompilationUnitPair>(sources.size());
		ASTRequestor requestor = new ASTRequestor() {
			@Override
			public void acceptAST(ICompilationUnit source, CompilationUnit ast) {
				pairs.add(new CompilationUnitPair(source, ast));
				subMonitor.subTask(String.format("Parsing (%d/%d): %s", pairs.size(), sources.size(),
						getUnitName(source)));
				subMonitor.worked(PARSING_PRICE);
			}
		};

		final ASTParser _parser = ASTParser.newParser(AST.JLS3);
		_parser.setKind(ASTParser.K_COMPILATION_UNIT);
		_parser.setProject(sources.get(0).getJavaProject());
		_parser.setResolveBindings(true);

		final ICompilationUnit[] sourceArray = sources.toArray(new ICompilationUnit[0]);

		Sharpen.Log(Level.INFO, "Parsing %d compilation units.", sources.size());

		try {
			subMonitor.beginTask("parsing compile units", totalWork);
			_parser.createASTs(sourceArray, new String[0], requestor, null);
		} finally {
			subMonitor.done();
		}

		return pairs;
	}

	private boolean stage1b_checkForErrors(List<CompilationUnitPair> sources) {
		for (final CompilationUnitPair pair : sources) {
			for (final IProblem problem : pair.ast.getProblems()) {
				if (problem.isError())
					return false;
			}
			for (final IProblem problem : pair.getProblems()) {
				if (problem.isError())
					return false;
			}
		}
		return true;
	}

	private Map<ICompilationUnit, CompilationUnitBuilder> stage2_preprocess(BindingManager bindings,
			List<CompilationUnitPair> sources) {
		Map<ICompilationUnit, CompilationUnitBuilder> builders = new HashMap<ICompilationUnit, CompilationUnitBuilder>();

		boolean foundErrors = false;

		for (final CompilationUnitPair pair : sources) {
			CompilationUnitBuilder builder = _api.preprocess(pair);
			if (builder == null) {
				Sharpen.Log(Level.SEVERE, "Preprocessor failed on %s", getUnitName(pair.source));
				continue;
			}

			builders.put(pair.source, builder);
		}

		if (foundErrors)
			return null;

		if (!bindings.resolveTypes()) {
			Sharpen.Log(Level.SEVERE, "Failed to resolve some types!");
		}

		return builders;
	}

	private Boolean stage3_generate(IProgressMonitor monitor, List<CompilationUnitBuilder> builders) {
		final int totalWork = GENERATING_PRICE * builders.size();

		IProgressMonitor subMonitor = new SubProgressMonitor(monitor, totalWork);
		subMonitor.beginTask("Converting", totalWork);
		Sharpen.Log(Level.INFO, "Converting %d files", builders.size());

		int i = 0;
		int errorCount = 0;

		for (final CompilationUnitBuilder builder : builders) {
			if (monitor.isCanceled())
				return null;

			final String message = String.format("Generating (%d/%d): %s", ++i, builders.size(),
					builder.getName());
			subMonitor.subTask(message);

			try {
				if (!builder.build()) {
					Sharpen.Log(Level.SEVERE, "Generator did not produce any output for %s",
							builder.getName());
					++errorCount;
				}
			} catch (Exception e) {
				Sharpen.Log(e, "Exception while generating %s", builder.getName());
				++errorCount;
			} finally {
				subMonitor.worked(GENERATING_PRICE);
			}
		}

		if (errorCount > 0) {
			Sharpen.Log(Level.SEVERE, "Converting finished, found %d errors.", errorCount);
			_foundErrors = true;
		}

		subMonitor.done();
		return !_foundErrors;
	}

	private boolean stage4_save_output(IProgressMonitor monitor, List<CompilationUnitBuilder> builders) {
		final int count = builders.size();
		final int totalWork = OUTPUT_PRICE * count;
		IProgressMonitor subMonitor = new SubProgressMonitor(monitor, totalWork);

		subMonitor.beginTask("Writing output", totalWork);
		Sharpen.Log(Level.INFO, "Writing output ...");

		int i = 0;
		boolean foundErrors = false;

		for (final CompilationUnitBuilder builder : builders) {
			final ICompilationUnit source = builder.getPair().source;
			final CSCompilationUnit unit = builder.getCompilationUnit();

			final String pathName = builder.getName();
			final String message = String.format("Saving (%d/%d): %s", ++i, count, pathName);
			subMonitor.subTask(message);

			try {
				if (!builder.writeOutput()) {
					Sharpen.Log(Level.SEVERE, "Failed to save output file: %s", pathName);
					foundErrors = true;
					continue;
				}

				if (unit.ignore() || unit.types().isEmpty())
					continue;

				final StringWriter writer = new StringWriter();
				writer.write(_config.header());

				CSharpPrinter printer = new CSharpPrinter();
				printer.setWriter(writer);

				printer.print(unit);

				if (writer.getBuffer().length() > 0)
					saveConvertedFile(source, unit, writer);
			} catch (CoreException e) {
				Sharpen.Log(e, "Cannot save output file: %s", pathName);
				foundErrors = true;
			} finally {
				subMonitor.worked(OUTPUT_PRICE);
			}
		}

		if (foundErrors) {
			Sharpen.Log(Level.SEVERE, "Errors while writing output!");
			_foundErrors = true;
		}

		subMonitor.done();
		return !foundErrors;
	}

	private void saveConvertedFile(ICompilationUnit cu, CSCompilationUnit csModule, StringWriter convertedContents)
			throws CoreException {
		String unitName = getUnitName(cu);

		IFolder folder;
		String fileName;

		int pos = unitName.lastIndexOf('.');
		if (pos > 0) {
			folder = _outputFolder.getFolder(unitName.substring(0, pos).replace('.', '/'));
			fileName = unitName.substring(pos + 1) + ".cs";
		} else {
			folder = _outputFolder;
			fileName = unitName + ".cs";
		}

		WorkspaceUtilities.initializeTree(folder, null);
		WorkspaceUtilities.writeText(folder.getFile(fileName), convertedContents.getBuffer().toString());
	}

	static boolean equalLists(SortedSet<String> a, SortedSet<String> b) {
		if (a.size() != b.size())
			return false;
		final int count = a.size();
		String[] array_a = a.toArray(new String[count]);
		String[] array_b = b.toArray(new String[count]);
		for (int i = 0; i < count; i++) {
			if (!array_a[i].equals(array_b[i]))
				return false;
		}
		return true;
	}

	boolean stage5_generate_csproj() {
		List<CSProjectFile> csprojFiles = _sourceInfo.getCSProjectFiles();
		if (csprojFiles == null)
			return true;

		for (final CSProjectFile file : csprojFiles) {
			if (!generate_csproj(file))
				return false;
		}

		return true;
	}

	boolean generate_csproj(CSProjectFile csprojFile) {
		URI root = _project.getLocationURI();
		File output = getProjectFile(csprojFile.getPath());
		File fileList = getProjectFile(csprojFile.getFileListFile());
		File template = getProjectFile(csprojFile.getTemplateFile());

		try {
			ArrayList<String> allFiles = new ArrayList<String>();

			URI path = _outputFolder.getLocationURI();
			collectAllFiles(allFiles, root, new File(path), ".cs");

			for (final String extra : _sourceInfo.getExtraCSharpSources()) {
				File extraPath = _project.getLocation().append(extra).toFile();
				collectAllFiles(allFiles, root, extraPath, ".cs");
			}

			for (NameMapping mapping : csprojFile.getPathMappings()) {
				for (int i = 0; i < allFiles.size(); i++) {
					String file = allFiles.get(i);
					allFiles.set(i, file.replaceAll(mapping.from, mapping.to));
				}
			}

			String line;

			SortedSet<String> sortedList = new TreeSet<String>();
			sortedList.addAll(allFiles);

			if (fileList.exists()) {
				FileInputStream listStream = new FileInputStream(fileList);
				BufferedReader listReader = new BufferedReader(new InputStreamReader(listStream));
				SortedSet<String> savedFileList = new TreeSet<String>();
				while ((line = listReader.readLine()) != null)
					savedFileList.add(line);
				listStream.close();
				if (equalLists(sortedList, savedFileList))
					return true;
			}

			FileOutputStream listOutputStream = new FileOutputStream(fileList);
			PrintStream listWriter = new PrintStream(listOutputStream);

			for (final String file : sortedList)
				listWriter.println(file);

			listWriter.close();
			listOutputStream.close();

			FileInputStream templateStream = new FileInputStream(template);
			BufferedReader templateReader = new BufferedReader(new InputStreamReader(templateStream));

			FileOutputStream outputStream = new FileOutputStream(output);
			PrintStream writer = new PrintStream(outputStream);

			while ((line = templateReader.readLine()) != null) {
				if (!line.trim().equals("@FILELIST@")) {
					writer.println(line);
					continue;
				}

				writer.println("  <ItemGroup>");
				for (final String file : allFiles) {
					final String windowsPath = file.replace('/', '\\');
					writer.printf("    <Compile Include=\"%s\" />", windowsPath);
					writer.println();
				}
				writer.println("  </ItemGroup>");
			}

			templateStream.close();
			writer.close();
			outputStream.close();
			return true;
		} catch (Exception e) {
			Sharpen.Log(e, "Cannot write csproj file '%s'", csprojFile);
			return false;
		}
	}

}
