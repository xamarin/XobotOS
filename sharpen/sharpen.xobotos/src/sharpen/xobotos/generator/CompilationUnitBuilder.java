package sharpen.xobotos.generator;

import sharpen.core.csharp.ast.CSCompilationUnit;
import sharpen.core.framework.CompilationUnitPair;
import sharpen.xobotos.api.interop.NativeBuilder;
import sharpen.xobotos.api.templates.CompilationUnitTemplate;

public interface CompilationUnitBuilder {

	String getName();

	CompilationUnitTemplate getTemplate();

	CompilationUnitPair getPair();

	CSCompilationUnit getCompilationUnit();

	NativeBuilder getNativeBuilder();

	boolean build();

	boolean writeOutput();

}
