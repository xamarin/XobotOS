using Sharpen;

namespace android.text
{
	/// <summary>
	/// Please implement this interface if your CharSequence can do quick
	/// draw/measure/widths calculations from an internal array.
	/// </summary>
	/// <remarks>
	/// Please implement this interface if your CharSequence can do quick
	/// draw/measure/widths calculations from an internal array.
	/// <hide></hide>
	/// </remarks>
	[Sharpen.Sharpened]
	public interface GraphicsOperations : java.lang.CharSequence
	{
		/// <summary>
		/// Just like
		/// <see cref="android.graphics.Canvas.drawText(string, float, float, android.graphics.Paint)
		/// 	">android.graphics.Canvas.drawText(string, float, float, android.graphics.Paint)
		/// 	</see>
		/// .
		/// </summary>
		void drawText(android.graphics.Canvas c, int start, int end, float x, float y, android.graphics.Paint
			 p);

		/// <summary>
		/// Just like
		/// <see cref="android.graphics.Canvas.drawTextRun(char[], int, int, int, int, float, float, int, android.graphics.Paint)
		/// 	">android.graphics.Canvas.drawTextRun(char[], int, int, int, int, float, float, int, android.graphics.Paint)
		/// 	</see>
		/// .
		/// <hide></hide>
		/// </summary>
		void drawTextRun(android.graphics.Canvas c, int start, int end, int contextStart, 
			int contextEnd, float x, float y, int flags, android.graphics.Paint p);

		/// <summary>
		/// Just like
		/// <see cref="android.graphics.Paint.measureText(string)">android.graphics.Paint.measureText(string)
		/// 	</see>
		/// .
		/// </summary>
		float measureText(int start, int end, android.graphics.Paint p);

		/// <summary>
		/// Just like
		/// <see cref="android.graphics.Paint.getTextWidths(string, float[])">android.graphics.Paint.getTextWidths(string, float[])
		/// 	</see>
		/// .
		/// </summary>
		int getTextWidths(int start, int end, float[] widths, android.graphics.Paint p);

		/// <summary>
		/// Just like
		/// <see cref="android.graphics.Paint.getTextRunAdvances(char[], int, int, int, int, int, float[], int)
		/// 	">android.graphics.Paint.getTextRunAdvances(char[], int, int, int, int, int, float[], int)
		/// 	</see>
		/// .
		/// </summary>
		/// <hide></hide>
		float getTextRunAdvances(int start, int end, int contextStart, int contextEnd, int
			 flags, float[] advances, int advancesIndex, android.graphics.Paint paint);

		/// <summary>
		/// Just like
		/// <see cref="android.graphics.Paint.getTextRunAdvances(char[], int, int, int, int, int, float[], int)
		/// 	">android.graphics.Paint.getTextRunAdvances(char[], int, int, int, int, int, float[], int)
		/// 	</see>
		/// .
		/// </summary>
		/// <hide></hide>
		float getTextRunAdvances(int start, int end, int contextStart, int contextEnd, int
			 flags, float[] advances, int advancesIndex, android.graphics.Paint paint, int reserved
			);

		/// <summary>
		/// Just like
		/// <see cref="android.graphics.Paint.getTextRunCursor(char[], int, int, int, int, int)
		/// 	">android.graphics.Paint.getTextRunCursor(char[], int, int, int, int, int)</see>
		/// .
		/// </summary>
		/// <hide></hide>
		int getTextRunCursor(int contextStart, int contextEnd, int flags, int offset, int
			 cursorOpt, android.graphics.Paint p);
	}
}
