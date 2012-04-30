package sharpen.xobotos.api;

public class APIException extends RuntimeException {

	public APIException(String message, Object...args) {
		super(String.format(message, args));
	}

	/**
	 *
	 */
	private static final long serialVersionUID = -8122229129226319824L;

}
