using System;
using System.Globalization;
using java.text;

namespace XobotOS.Text
{
	internal class XobotBreakIterator : java.text.BreakIterator
	{
		protected enum Mode
		{
			Character,
			Line,
			Sentence,
			Word
		}

		readonly CultureInfo culture;
		readonly Mode mode;
		CharacterIterator iterator;
		int first_boundary = -1;
		int last_boundary = -1;
		int current_boundary;

		XobotBreakIterator (CultureInfo culture, Mode mode)
		{
			this.culture = culture;
			this.mode = mode;
		}

		public static BreakIterator GetCharacterInstance (CultureInfo culture)
		{
			return new XobotBreakIterator (culture, Mode.Character);
		}

		public static BreakIterator GetLineInstance (CultureInfo culture)
		{
			return new XobotBreakIterator (culture, Mode.Line);
		}

		public static BreakIterator GetSentenceInstance (CultureInfo culture)
		{
			return new XobotBreakIterator (culture, Mode.Sentence);
		}

		public static BreakIterator GetWordInstance (CultureInfo culture)
		{
			return new XobotBreakIterator (culture, Mode.Word);
		}

		char current (int offset)
		{
			int old = iterator.getIndex ();
			iterator.setIndex (offset);
			char ch = iterator.current ();
			iterator.setIndex (old);
			return ch;
		}

		int found ()
		{
			current_boundary = iterator.getIndex ();
			if (first_boundary < 0)
				first_boundary = current_boundary;
			return current_boundary;
		}

		static char[] GetBoundaryChars (Mode mode)
		{
			switch (mode) {
			case Mode.Line:
				return Environment.NewLine.ToCharArray ();
			case Mode.Word: {
					string newline = Environment.NewLine;
					if (newline.Length == 1)
						return new char[] { ' ', '\t', '.', ';', newline [0] };
					else
						return new char[] { ' ', '\t', '.', ';', newline [0], newline [1] };
				}
			case Mode.Sentence:
				return new char[] { '.' };
			default:
				return null;
			}
		}

		bool IsBoundary (char ch)
		{
			char[] boundary_chars = GetBoundaryChars (mode);
			if (boundary_chars == null)
				return true;

			foreach (char test in boundary_chars) {
				if (ch == test)
					return true;
			}

			return false;
		}

		#region implemented abstract members of java.text.BreakIterator
		public override int current ()
		{
			return current_boundary;
		}

		public override int first ()
		{
			return first_boundary >= 0 ? first_boundary : 0;
		}

		public override int following (int offset)
		{
			iterator.setIndex (offset);
			return next ();
		}

		public override CharacterIterator getText ()
		{
			return iterator;
		}

		public override int last ()
		{
			return last_boundary >= 0 ? last_boundary : iterator.getEndIndex ();
		}

		public override int next ()
		{
			char ch;
			while ((ch = iterator.next ()) != DONE) {
				if (IsBoundary (ch))
					return found ();
			}

			current_boundary = iterator.getEndIndex ();
			last_boundary = current_boundary;

			return DONE;
		}

		public override int next (int n)
		{
			for (int i = 1; i < n; i++) {
				if (next () == DONE)
					return DONE;
			}

			return next ();
		}

		public override int previous ()
		{
			char ch;
			while ((ch = iterator.previous ()) != DONE) {
				if (IsBoundary (ch))
					return found ();
			}

			first_boundary = iterator.getBeginIndex ();
			current_boundary = first_boundary;

			return DONE;
		}

		public override bool isBoundary (int offset)
		{
			return IsBoundary (current (offset));
		}

		public override int preceding (int offset)
		{
			iterator.setIndex (offset);
			return previous ();
		}

		public override void setText (CharacterIterator iterator)
		{
			this.iterator = iterator;
			last_boundary = 0;
		}
		#endregion
	}
}

