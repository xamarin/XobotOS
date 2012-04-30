package sharpen.core.framework;

public abstract class CommandLineParser {

	protected final String[] _args;

	protected int _current;

	public CommandLineParser(String[] args) {
		if (null == args) illegalArgument("args cannot be null");
		_args = args;
	}

	protected void processOption(String arg) {
		illegalArgument(arg);
	}
	
	protected void processArgument(String arg) {
		illegalArgument(arg);
	}
	
	protected void processResponseFile(String arg) {
		illegalArgument(arg);
	}

	protected void validate() {
	}

	protected static void illegalArgument(String message) {
		throw new IllegalArgumentException(message);
	}

	protected void parse() {
		for (; _current<_args.length; ++_current) {
			parseArgument(_args[_current]);
		}
		validate();
	}

	private void parseArgument(String arg) {
		if (arg.startsWith("@")) {
			processResponseFile(arg);
		} else if (arg.startsWith("-")) {
			processOption(arg);
		} else {
			processArgument(arg);
		}
	}

	protected boolean areEqual(String arg, String value) {
		return arg.equals(value);
	}

	protected String consumeNext() {
		return _args[++_current];
	}
}