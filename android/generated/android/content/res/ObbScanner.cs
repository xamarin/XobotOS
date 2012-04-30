using Sharpen;

namespace android.content.res
{
	/// <summary>Class to scan Opaque Binary Blob (OBB) files.</summary>
	/// <remarks>
	/// Class to scan Opaque Binary Blob (OBB) files. Use this to get information
	/// about an OBB file for use in a program via
	/// <see cref="ObbInfo">ObbInfo</see>
	/// .
	/// </remarks>
	[Sharpen.Sharpened]
	public class ObbScanner
	{
		private ObbScanner()
		{
		}

		// Don't allow others to instantiate this class
		/// <summary>Scan a file for OBB information.</summary>
		/// <remarks>Scan a file for OBB information.</remarks>
		/// <param name="filePath">path to the OBB file to be scanned.</param>
		/// <returns>ObbInfo object information corresponding to the file path</returns>
		/// <exception cref="System.ArgumentException">if the OBB file couldn't be found</exception>
		/// <exception cref="System.IO.IOException">if the OBB file couldn't be read</exception>
		public static android.content.res.ObbInfo getObbInfo(string filePath)
		{
			if (filePath == null)
			{
				throw new System.ArgumentException("file path cannot be null");
			}
			java.io.File obbFile = new java.io.File(filePath);
			if (!obbFile.exists())
			{
				throw new System.ArgumentException("OBB file does not exist: " + filePath);
			}
			string canonicalFilePath = obbFile.getCanonicalPath();
			android.content.res.ObbInfo obbInfo = new android.content.res.ObbInfo();
			obbInfo.filename = canonicalFilePath;
			getObbInfo_native(canonicalFilePath, obbInfo);
			return obbInfo;
		}

		/// <exception cref="System.IO.IOException"></exception>
		[Sharpen.NativeStub]
		private static void getObbInfo_native(string filePath, android.content.res.ObbInfo
			 obbInfo)
		{
			throw new System.NotImplementedException();
		}
	}
}
