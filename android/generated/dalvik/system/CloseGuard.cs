using Sharpen;

namespace dalvik.system
{
	/// <summary>
	/// CloseGuard is a mechanism for flagging implicit finalizer cleanup of
	/// resources that should have been cleaned up by explicit close
	/// methods (aka "explicit termination methods" in Effective Java).
	/// </summary>
	/// <remarks>
	/// CloseGuard is a mechanism for flagging implicit finalizer cleanup of
	/// resources that should have been cleaned up by explicit close
	/// methods (aka "explicit termination methods" in Effective Java).
	/// <p>
	/// A simple example: <pre>
	/// <code></code>
	/// class Foo
	/// private final CloseGuard guard = CloseGuard.get();
	/// ...
	/// public Foo() {
	/// ...;
	/// guard.open("cleanup");
	/// }
	/// public void cleanup() {
	/// guard.close();
	/// ...;
	/// }
	/// protected void finalize() throws Throwable {
	/// try {
	/// if (guard != null) {
	/// guard.warnIfOpen();
	/// }
	/// cleanup();
	/// } finally {
	/// super.finalize();
	/// }
	/// }
	/// }
	/// }</pre>
	/// In usage where the resource to be explicitly cleaned up are
	/// allocated after object construction, CloseGuard protection can
	/// be deferred. For example: <pre>
	/// <code></code>
	/// class Bar
	/// private final CloseGuard guard = CloseGuard.get();
	/// ...
	/// public Bar() {
	/// ...;
	/// }
	/// public void connect() {
	/// ...;
	/// guard.open("cleanup");
	/// }
	/// public void cleanup() {
	/// guard.close();
	/// ...;
	/// }
	/// protected void finalize() throws Throwable {
	/// try {
	/// if (guard != null) {
	/// guard.warnIfOpen();
	/// }
	/// cleanup();
	/// } finally {
	/// super.finalize();
	/// }
	/// }
	/// }
	/// }</pre>
	/// When used in a constructor calls to
	/// <code>open</code>
	/// should occur at
	/// the end of the constructor since an exception that would cause
	/// abrupt termination of the constructor will mean that the user will
	/// not have a reference to the object to cleanup explicitly. When used
	/// in a method, the call to
	/// <code>open</code>
	/// should occur just after
	/// resource acquisition.
	/// <p>
	/// Note that the null check on
	/// <code>guard</code>
	/// in the finalizer is to
	/// cover cases where a constructor throws an exception causing the
	/// <code>guard</code>
	/// to be uninitialized.
	/// </remarks>
	/// <hide></hide>
	[Sharpen.Sharpened]
	public sealed class CloseGuard
	{
		/// <summary>Instance used when CloseGuard is disabled to avoid allocation.</summary>
		/// <remarks>Instance used when CloseGuard is disabled to avoid allocation.</remarks>
		private static readonly dalvik.system.CloseGuard NOOP = new dalvik.system.CloseGuard
			();

		/// <summary>Enabled by default so we can catch issues early in VM startup.</summary>
		/// <remarks>
		/// Enabled by default so we can catch issues early in VM startup.
		/// Note, however, that Android disables this early in its startup,
		/// but enables it with DropBoxing for system apps on debug builds.
		/// </remarks>
		private static volatile bool ENABLED = true;

		/// <summary>Hook for customizing how CloseGuard issues are reported.</summary>
		/// <remarks>Hook for customizing how CloseGuard issues are reported.</remarks>
		private static volatile dalvik.system.CloseGuard.Reporter REPORTER = new dalvik.system.CloseGuard
			.DefaultReporter();

		/// <summary>Returns a CloseGuard instance.</summary>
		/// <remarks>
		/// Returns a CloseGuard instance. If CloseGuard is enabled,
		/// <code>#open(String)</code>
		/// can be used to set up the instance to warn on
		/// failure to close. If CloseGuard is disabled, a non-null no-op
		/// instance is returned.
		/// </remarks>
		public static dalvik.system.CloseGuard get()
		{
			if (!ENABLED)
			{
				return NOOP;
			}
			return new dalvik.system.CloseGuard();
		}

		/// <summary>Used to enable or disable CloseGuard.</summary>
		/// <remarks>
		/// Used to enable or disable CloseGuard. Note that CloseGuard only
		/// warns if it is enabled for both allocation and finalization.
		/// </remarks>
		public static void setEnabled(bool enabled)
		{
			ENABLED = enabled;
		}

		/// <summary>
		/// Used to replace default Reporter used to warn of CloseGuard
		/// violations.
		/// </summary>
		/// <remarks>
		/// Used to replace default Reporter used to warn of CloseGuard
		/// violations. Must be non-null.
		/// </remarks>
		public static void setReporter(dalvik.system.CloseGuard.Reporter reporter)
		{
			if (reporter == null)
			{
				throw new System.ArgumentNullException("reporter == null");
			}
			REPORTER = reporter;
		}

		/// <summary>Returns non-null CloseGuard.Reporter.</summary>
		/// <remarks>Returns non-null CloseGuard.Reporter.</remarks>
		public static dalvik.system.CloseGuard.Reporter getReporter()
		{
			return REPORTER;
		}

		private CloseGuard()
		{
		}

		/// <summary>
		/// If CloseGuard is enabled,
		/// <code>open</code>
		/// initializes the instance
		/// with a warning that the caller should have explicitly called the
		/// <code>closer</code>
		/// method instead of relying on finalization.
		/// </summary>
		/// <param name="closer">non-null name of explicit termination method</param>
		/// <exception cref="System.ArgumentNullException">
		/// if closer is null, regardless of
		/// whether or not CloseGuard is enabled
		/// </exception>
		public void open(string closer)
		{
			// always perform the check for valid API usage...
			if (closer == null)
			{
				throw new System.ArgumentNullException("closer == null");
			}
			// ...but avoid allocating an allocationSite if disabled
			if (this == NOOP || !ENABLED)
			{
				return;
			}
			string message = "Explicit termination method '" + closer + "' not called";
			allocationSite = new System.Exception(message);
		}

		private System.Exception allocationSite;

		/// <summary>
		/// Marks this CloseGuard instance as closed to avoid warnings on
		/// finalization.
		/// </summary>
		/// <remarks>
		/// Marks this CloseGuard instance as closed to avoid warnings on
		/// finalization.
		/// </remarks>
		public void close()
		{
			allocationSite = null;
		}

		/// <summary>
		/// If CloseGuard is enabled, logs a warning if the caller did not
		/// properly cleanup by calling an explicit close method
		/// before finalization.
		/// </summary>
		/// <remarks>
		/// If CloseGuard is enabled, logs a warning if the caller did not
		/// properly cleanup by calling an explicit close method
		/// before finalization. If CloseGuard is disable, no action is
		/// performed.
		/// </remarks>
		public void warnIfOpen()
		{
			if (allocationSite == null || !ENABLED)
			{
				return;
			}
			string message = ("A resource was acquired at attached stack trace but never released. "
				 + "See java.io.Closeable for information on avoiding resource leaks.");
			REPORTER.report(message, allocationSite);
		}

		/// <summary>Interface to allow customization of reporting behavior.</summary>
		/// <remarks>Interface to allow customization of reporting behavior.</remarks>
		public interface Reporter
		{
			void report(string message, System.Exception allocationSite);
		}

		/// <summary>Default Reporter which reports CloseGuard violations to the log.</summary>
		/// <remarks>Default Reporter which reports CloseGuard violations to the log.</remarks>
		private sealed class DefaultReporter : dalvik.system.CloseGuard.Reporter
		{
			[Sharpen.ImplementsInterface(@"dalvik.system.CloseGuard.Reporter")]
			public void report(string message, System.Exception allocationSite)
			{
				XobotOS.Runtime.Util.LogW(message, allocationSite);
			}
		}
	}
}
