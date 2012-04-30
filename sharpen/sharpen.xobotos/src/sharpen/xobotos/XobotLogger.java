package sharpen.xobotos;

import org.eclipse.ui.console.*;

import sharpen.core.Sharpen;

import java.io.*;
import java.util.Date;
import java.util.logging.*;

public class XobotLogger {

	class MyStreamHandler extends Handler {
		private final PrintStream printStream;

		public MyStreamHandler(OutputStream stream) {
			super();
			printStream = new PrintStream (stream, true);
		}

		@Override
		public void close() throws SecurityException {
			printStream.close();
		}

		@Override
		public void flush() {
			printStream.flush();
		}

		@Override
		public void publish(LogRecord record) {
			Date date = new Date(record.getMillis());
			printStream.printf("[%tT] %s", date, record.getMessage());
			printStream.println();

			Throwable throwable = record.getThrown();
			if (throwable != null) {
				throwable.printStackTrace(printStream);
				printStream.println();
			}
		}
	}

	class MyConsoleHandler extends MyStreamHandler {
		public MyConsoleHandler(MessageConsole console) {
			super(console.newMessageStream());
		}
	}

	private static final Logger logger = Sharpen.getLogger();

	private final MessageConsole console;

	private final Handler consoleHandler;

	private File logFile;
	private FileOutputStream logFileStream;
	private Handler logFileHandler;

	public XobotLogger() {
		console = Activator.getConsole();
		console.clearConsole();
		console.activate();

		consoleHandler = new MyConsoleHandler(console);
		logger.addHandler(consoleHandler);
	}

	public void setLogFile(File newFile, boolean append) throws FileNotFoundException {
		if (logFile != null)
			throw new IllegalArgumentException("BuildLogger.setLogFile() may be used only once");

		try {
			logFileStream = new FileOutputStream (newFile, append);
			logFile = newFile;
		} catch (FileNotFoundException e) {
			logger.log(Level.WARNING, "Cannot open logfile: " + newFile.getAbsolutePath());
			return;
		}

		logger.log(Level.INFO, "Added logfile " + logFile.getAbsolutePath());

		logFileHandler = new MyStreamHandler (logFileStream);
		logger.addHandler(logFileHandler);
	}

	public void close() {
		try {
			logger.removeHandler(consoleHandler);

			if (logFileHandler != null) {
				logFileHandler.close();
				logger.removeHandler(logFileHandler);
				logFileStream.close();
			}
		} catch (IOException e) {
			;
		}
	}
}
