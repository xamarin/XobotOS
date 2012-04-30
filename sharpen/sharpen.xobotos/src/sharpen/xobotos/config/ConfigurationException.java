package sharpen.xobotos.config;

public class ConfigurationException extends RuntimeException {

	public ConfigurationException(String message, Object...args) {
		super(String.format(message, args));
	}

	/**
	 *
	 */
	private static final long serialVersionUID = 4696921086350029374L;
}
