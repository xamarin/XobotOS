using Sharpen;

namespace android.os
{
	[Sharpen.Stub]
	public class RecoverySystem
	{
		internal const string TAG = "RecoverySystem";

		private static readonly java.io.File DEFAULT_KEYSTORE = new java.io.File("/system/etc/security/otacerts.zip"
			);

		internal const long PUBLISH_PROGRESS_INTERVAL_MS = 500;

		private static java.io.File RECOVERY_DIR = new java.io.File("/cache/recovery");

		private static java.io.File COMMAND_FILE = new java.io.File(RECOVERY_DIR, "command"
			);

		private static java.io.File LOG_FILE = new java.io.File(RECOVERY_DIR, "log");

		private static string LAST_PREFIX = "last_";

		private static int LOG_FILE_MAX_LENGTH = 64 * 1024;

		[Sharpen.Stub]
		public interface ProgressListener
		{
			[Sharpen.Stub]
			void onProgress(int progress);
		}

		[Sharpen.Stub]
		private static java.util.HashSet<java.security.cert.Certificate> getTrustedCerts(
			java.io.File keystore)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static void verifyPackage(java.io.File packageFile, android.os.RecoverySystem
			.ProgressListener listener, java.io.File deviceCertsZipFile)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static void installPackage(android.content.Context context, java.io.File packageFile
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static void rebootWipeUserData(android.content.Context context)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static void rebootWipeCache(android.content.Context context)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static void bootCommand(android.content.Context context, string arg)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static string handleAftermath()
		{
			throw new System.NotImplementedException();
		}
	}
}
