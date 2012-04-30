using System;

namespace android.graphics
{
	partial class Color
	{
		/// <summary>Parse the color string, and return the corresponding color-int.</summary>
		/// <remarks>
		/// Parse the color string, and return the corresponding color-int.
		/// If the string cannot be parsed, throws an IllegalArgumentException
		/// exception. Supported formats are:
		/// #RRGGBB
		/// #AARRGGBB
		/// 'red', 'blue', 'green', 'black', 'white', 'gray', 'cyan', 'magenta',
		/// 'yellow', 'lightgray', 'darkgray'
		/// </remarks>
		public static int parseColor(string colorString)
		{
			if (colorString[0] == '#')
			{
				// Use a long to avoid rollovers on #ffXXXXXX
				long color = Sharpen.Util.ParseLong(Sharpen.StringHelper.Substring
					(colorString, 1), 16);
				if (colorString.Length == 7)
				{
					// Set the alpha value
					color |= unchecked((int)(0x00000000ff000000));
				}
				else
				{
					if (colorString.Length != 9)
					{
						throw new System.ArgumentException("Unknown color");
					}
				}
				return (int)color;
			}
			else
			{
				int color = sColorNameMap.get (colorString.ToLower());
				if (color != null)
				{
					return color;
				}
			}
			throw new System.ArgumentException("Unknown color");
		}

	}
}

