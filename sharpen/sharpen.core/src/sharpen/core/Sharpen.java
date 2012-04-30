/* Copyright (C) 2004 - 2008  Versant Inc.  http://www.db4o.com

This file is part of the sharpen open source java to c# translator.

sharpen is free software; you can redistribute it and/or modify it under
the terms of version 2 of the GNU General Public License as published
by the Free Software Foundation and as clarified by db4objects' GPL
interpretation policy, available at
http://www.db4o.com/about/company/legalpolicies/gplinterpretation/
Alternatively you can write to db4objects, Inc., 1900 S Norfolk Street,
Suite 350, San Mateo, CA 94403, USA.

sharpen is distributed in the hope that it will be useful, but WITHOUT ANY
WARRANTY; without even the implied warranty of MERCHANTABILITY or
FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License
for more details.

You should have received a copy of the GNU General Public License along
with this program; if not, write to the Free Software Foundation, Inc.,
59 Temple Place - Suite 330, Boston, MA  02111-1307, USA. */

package sharpen.core;

import org.eclipse.core.runtime.Plugin;
import org.osgi.framework.BundleContext;

import java.util.MissingResourceException;
import java.util.ResourceBundle;
import java.util.logging.Level;
import java.util.logging.Logger;

/**
 * The main plugin class to be used in the desktop.
 */
public class Sharpen extends Plugin {

	public static final String PLUGIN_ID = "sharpen.core";

	public static final String PROBLEM_MARKER = PLUGIN_ID + ".problem";

	public static final String SHARPEN_LOGGER_NAME = "SHARPEN_LOGGER";

	//The shared instance.
	private static Sharpen plugin;
	//Resource bundle.
	private ResourceBundle resourceBundle;

	private Configuration _configuration;

	private static Logger _logger;

	/**
	 * The constructor.
	 */
	public Sharpen() {
		super();
		plugin = this;
		try {
			resourceBundle = ResourceBundle.getBundle("sharpen.SharpenPluginResources");
		} catch (MissingResourceException x) {
			resourceBundle = null;
		}

		_logger = Logger.getLogger(SHARPEN_LOGGER_NAME);
	}

	/**
	 * This method is called upon plug-in activation
	 */
	@Override
	public void start(BundleContext context) throws Exception {
		super.start(context);
	}

	/**
	 * This method is called when the plug-in is stopped
	 */
	@Override
	public void stop(BundleContext context) throws Exception {
		super.stop(context);
	}

	/**
	 * Returns the shared instance.
	 */
	public static Sharpen getDefault() {
		return plugin;
	}

	/**
	 * Returns the string from the plugin's resource bundle,
	 * or 'key' if not found.
	 */
	public static String getResourceString(String key) {
		ResourceBundle bundle = Sharpen.getDefault().getResourceBundle();
		try {
			return (bundle != null) ? bundle.getString(key) : key;
		} catch (MissingResourceException e) {
			return key;
		}
	}

	/**
	 * Returns the plugin's resource bundle,
	 */
	public ResourceBundle getResourceBundle() {
		return resourceBundle;
	}

	public void configuration(Configuration configuration) {
		_configuration = configuration;
	}

	public Configuration configuration() {
		return _configuration;
	}

	public static Logger getLogger() {
		return _logger;
	}

	public static void Log(Level level, String message, Object...args) {
		_logger.log(level, String.format(message, args));
	}

	public static void Debug(String message, Object... args) {
		_logger.log(Level.INFO, String.format(message, args));
	}

	public static void Log(Throwable thrown, String message, Object...args) {
		_logger.log(Level.SEVERE, String.format(message, args), thrown);
	}
}
