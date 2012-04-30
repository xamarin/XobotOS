package sharpen.xobotos.config.annotations;

import sharpen.xobotos.config.xstream.IConfigurationFile;

import java.lang.annotation.ElementType;
import java.lang.annotation.Retention;
import java.lang.annotation.RetentionPolicy;
import java.lang.annotation.Target;

@Retention(RetentionPolicy.RUNTIME)
@Target(ElementType.TYPE)
public @interface ReadIncludeFile {
	Class<? extends IConfigurationFile> fileType();

	String fileNameField();

	String contentsField();
}
