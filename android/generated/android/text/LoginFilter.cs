using Sharpen;

namespace android.text
{
	/// <summary>Abstract class for filtering login-related text (user names and passwords)
	/// 	</summary>
	[Sharpen.Sharpened]
	public abstract class LoginFilter : android.text.InputFilter
	{
		private bool mAppendInvalid;

		/// <summary>Base constructor for LoginFilter</summary>
		/// <param name="appendInvalid">whether or not to append invalid characters.</param>
		internal LoginFilter(bool appendInvalid)
		{
			// whether to append or ignore invalid characters
			mAppendInvalid = appendInvalid;
		}

		/// <summary>Default constructor for LoginFilter doesn't append invalid characters.</summary>
		/// <remarks>Default constructor for LoginFilter doesn't append invalid characters.</remarks>
		internal LoginFilter()
		{
			mAppendInvalid = false;
		}

		/// <summary>
		/// This method is called when the buffer is going to replace the
		/// range <code>dstart &hellip; dend</code> of <code>dest</code>
		/// with the new text from the range <code>start &hellip; end</code>
		/// of <code>source</code>.
		/// </summary>
		/// <remarks>
		/// This method is called when the buffer is going to replace the
		/// range <code>dstart &hellip; dend</code> of <code>dest</code>
		/// with the new text from the range <code>start &hellip; end</code>
		/// of <code>source</code>.  Returns the CharSequence that we want
		/// placed there instead, including an empty string
		/// if appropriate, or <code>null</code> to accept the original
		/// replacement.  Be careful to not to reject 0-length replacements,
		/// as this is what happens when you delete text.
		/// </remarks>
		[Sharpen.ImplementsInterface(@"android.text.InputFilter")]
		public virtual java.lang.CharSequence filter(java.lang.CharSequence source, int start
			, int end, android.text.Spanned dest, int dstart, int dend)
		{
			onStart();
			{
				// Scan through beginning characters in dest, calling onInvalidCharacter() 
				// for each invalid character.
				for (int i = 0; i < dstart; i++)
				{
					char c = dest[i];
					if (!isAllowed(c))
					{
						onInvalidCharacter(c);
					}
				}
			}
			// Scan through changed characters rejecting disallowed chars
			android.text.SpannableStringBuilder modification = null;
			int modoff = 0;
			{
				for (int i_1 = start; i_1 < end; i_1++)
				{
					char c = source[i_1];
					if (isAllowed(c))
					{
						// Character allowed.
						modoff++;
					}
					else
					{
						if (mAppendInvalid)
						{
							modoff++;
						}
						else
						{
							if (modification == null)
							{
								modification = new android.text.SpannableStringBuilder(source, start, end);
								modoff = i_1 - start;
							}
							modification.delete(modoff, modoff + 1);
						}
						onInvalidCharacter(c);
					}
				}
			}
			{
				// Scan through remaining characters in dest, calling onInvalidCharacter() 
				// for each invalid character.
				for (int i_2 = dend; i_2 < dest.Length; i_2++)
				{
					char c = dest[i_2];
					if (!isAllowed(c))
					{
						onInvalidCharacter(c);
					}
				}
			}
			onStop();
			// Either returns null if we made no changes,
			// or what we wanted to change it to if there were changes.
			return modification;
		}

		/// <summary>Called when we start processing filter.</summary>
		/// <remarks>Called when we start processing filter.</remarks>
		public virtual void onStart()
		{
		}

		/// <summary>Called whenever we encounter an invalid character.</summary>
		/// <remarks>Called whenever we encounter an invalid character.</remarks>
		/// <param name="c">the invalid character</param>
		public virtual void onInvalidCharacter(char c)
		{
		}

		/// <summary>Called when we're done processing filter</summary>
		public virtual void onStop()
		{
		}

		/// <summary>Returns whether or not we allow character c.</summary>
		/// <remarks>
		/// Returns whether or not we allow character c.
		/// Subclasses must override this method.
		/// </remarks>
		public abstract bool isAllowed(char c);

		/// <summary>
		/// This filter rejects characters in the user name that are not compatible with GMail
		/// account creation.
		/// </summary>
		/// <remarks>
		/// This filter rejects characters in the user name that are not compatible with GMail
		/// account creation. It prevents the user from entering user names with characters other than
		/// [a-zA-Z0-9.].
		/// </remarks>
		public class UsernameFilterGMail : android.text.LoginFilter
		{
			public UsernameFilterGMail() : base(false)
			{
			}

			public UsernameFilterGMail(bool appendInvalid) : base(appendInvalid)
			{
			}

			[Sharpen.OverridesMethod(@"android.text.LoginFilter")]
			public override bool isAllowed(char c)
			{
				// Allow [a-zA-Z0-9@.]
				if ('0' <= c && c <= '9')
				{
					return true;
				}
				if ('a' <= c && c <= 'z')
				{
					return true;
				}
				if ('A' <= c && c <= 'Z')
				{
					return true;
				}
				if ('.' == c)
				{
					return true;
				}
				return false;
			}
		}

		/// <summary>This filter rejects characters in the user name that are not compatible with Google login.
		/// 	</summary>
		/// <remarks>
		/// This filter rejects characters in the user name that are not compatible with Google login.
		/// It is slightly less restrictive than the above filter in that it allows [a-zA-Z0-9._-+].
		/// </remarks>
		public class UsernameFilterGeneric : android.text.LoginFilter
		{
			internal const string mAllowed = "@_-+.";

			public UsernameFilterGeneric() : base(false)
			{
			}

			public UsernameFilterGeneric(bool appendInvalid) : base(appendInvalid)
			{
			}

			// Additional characters
			[Sharpen.OverridesMethod(@"android.text.LoginFilter")]
			public override bool isAllowed(char c)
			{
				// Allow [a-zA-Z0-9@.]
				if ('0' <= c && c <= '9')
				{
					return true;
				}
				if ('a' <= c && c <= 'z')
				{
					return true;
				}
				if ('A' <= c && c <= 'Z')
				{
					return true;
				}
				if (mAllowed.IndexOf(c) != -1)
				{
					return true;
				}
				return false;
			}
		}

		/// <summary>
		/// This filter is compatible with GMail passwords which restricts characters to
		/// the Latin-1 (ISO8859-1) char set.
		/// </summary>
		/// <remarks>
		/// This filter is compatible with GMail passwords which restricts characters to
		/// the Latin-1 (ISO8859-1) char set.
		/// </remarks>
		public class PasswordFilterGMail : android.text.LoginFilter
		{
			public PasswordFilterGMail() : base(false)
			{
			}

			public PasswordFilterGMail(bool appendInvalid) : base(appendInvalid)
			{
			}

			// We should reject anything not in the Latin-1 (ISO8859-1) charset
			[Sharpen.OverridesMethod(@"android.text.LoginFilter")]
			public override bool isAllowed(char c)
			{
				if (32 <= c && c <= 127)
				{
					return true;
				}
				// standard charset
				// if (128 <= c && c <= 159) return true;  // nonstandard (Windows(TM)(R)) charset
				if (160 <= c && c <= 255)
				{
					return true;
				}
				// extended charset
				return false;
			}
		}
	}
}
