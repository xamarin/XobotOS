using System.Runtime.InteropServices;
using Sharpen;

namespace android.content.res
{
	[Sharpen.Sharpened]
	internal sealed partial class StringBlock : System.IDisposable
	{
		internal const string TAG = "AssetManager";

		internal const bool localLOGV = false || false;

		internal readonly android.content.res.StringBlock.NativeStringBlock mNative;

		private readonly bool mUseSparse;

		private readonly bool mOwnsNative;

		private java.lang.CharSequence[] mStrings;

		private android.util.SparseArray<java.lang.CharSequence> mSparseStrings;

		internal android.content.res.StringBlock.StyleIDs mStyleIDs = null;

		[Sharpen.Stub]
		public StringBlock(byte[] data, bool useSparse)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public StringBlock(byte[] data, int offset, int size, bool useSparse)
		{
			throw new System.NotImplementedException();
		}

		public java.lang.CharSequence get(int idx)
		{
			lock (this)
			{
				if (mStrings != null)
				{
					java.lang.CharSequence res = mStrings[idx];
					if (res != null)
					{
						return res;
					}
				}
				else
				{
					if (mSparseStrings != null)
					{
						java.lang.CharSequence res = mSparseStrings.get(idx);
						if (res != null)
						{
							return res;
						}
					}
					else
					{
						int num = nativeGetSize(mNative);
						if (mUseSparse && num > 250)
						{
							mSparseStrings = new android.util.SparseArray<java.lang.CharSequence>();
						}
						else
						{
							mStrings = new java.lang.CharSequence[num];
						}
					}
				}
				string str = nativeGetString(mNative, idx);
				java.lang.CharSequence res_1 = java.lang.CharSequenceProxy.Wrap(str);
				int[] style = nativeGetStyle(mNative, idx);
				if (style != null)
				{
					if (mStyleIDs == null)
					{
						mStyleIDs = new android.content.res.StringBlock.StyleIDs();
					}
					{
						for (int styleIndex = 0; styleIndex < style.Length; styleIndex += 3)
						{
							int styleId = style[styleIndex];
							if (styleId == mStyleIDs.boldId || styleId == mStyleIDs.italicId || styleId == mStyleIDs
								.underlineId || styleId == mStyleIDs.ttId || styleId == mStyleIDs.bigId || styleId
								 == mStyleIDs.smallId || styleId == mStyleIDs.subId || styleId == mStyleIDs.supId
								 || styleId == mStyleIDs.strikeId || styleId == mStyleIDs.listItemId || styleId 
								== mStyleIDs.marqueeId)
							{
								continue;
							}
							string styleTag = nativeGetString(mNative, styleId);
							if (styleTag.Equals("b"))
							{
								mStyleIDs.boldId = styleId;
							}
							else
							{
								if (styleTag.Equals("i"))
								{
									mStyleIDs.italicId = styleId;
								}
								else
								{
									if (styleTag.Equals("u"))
									{
										mStyleIDs.underlineId = styleId;
									}
									else
									{
										if (styleTag.Equals("tt"))
										{
											mStyleIDs.ttId = styleId;
										}
										else
										{
											if (styleTag.Equals("big"))
											{
												mStyleIDs.bigId = styleId;
											}
											else
											{
												if (styleTag.Equals("small"))
												{
													mStyleIDs.smallId = styleId;
												}
												else
												{
													if (styleTag.Equals("sup"))
													{
														mStyleIDs.supId = styleId;
													}
													else
													{
														if (styleTag.Equals("sub"))
														{
															mStyleIDs.subId = styleId;
														}
														else
														{
															if (styleTag.Equals("strike"))
															{
																mStyleIDs.strikeId = styleId;
															}
															else
															{
																if (styleTag.Equals("li"))
																{
																	mStyleIDs.listItemId = styleId;
																}
																else
																{
																	if (styleTag.Equals("marquee"))
																	{
																		mStyleIDs.marqueeId = styleId;
																	}
																}
															}
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
					res_1 = applyStyles(str, style, mStyleIDs);
				}
				if (mStrings != null)
				{
					mStrings[idx] = res_1;
				}
				else
				{
					mSparseStrings.put(idx, res_1);
				}
				return res_1;
			}
		}

		internal sealed class StyleIDs
		{
			internal int boldId = -1;

			internal int italicId = -1;

			internal int underlineId = -1;

			internal int ttId = -1;

			internal int bigId = -1;

			internal int smallId = -1;

			internal int subId = -1;

			internal int supId = -1;

			internal int strikeId = -1;

			internal int listItemId = -1;

			internal int marqueeId = -1;
		}

		internal java.lang.CharSequence applyStyles(string str, int[] style, android.content.res.StringBlock
			.StyleIDs ids)
		{
			if (style.Length == 0)
			{
				return java.lang.CharSequenceProxy.Wrap(str);
			}
			android.text.SpannableString buffer = new android.text.SpannableString(java.lang.CharSequenceProxy.Wrap
				(str));
			int i = 0;
			while (i < style.Length)
			{
				int type = style[i];
				if (type == ids.boldId)
				{
					buffer.setSpan(new android.text.style.StyleSpan(android.graphics.Typeface.BOLD), 
						style[i + 1], style[i + 2] + 1, android.text.SpannedClass.SPAN_EXCLUSIVE_EXCLUSIVE
						);
				}
				else
				{
					if (type == ids.italicId)
					{
						buffer.setSpan(new android.text.style.StyleSpan(android.graphics.Typeface.ITALIC)
							, style[i + 1], style[i + 2] + 1, android.text.SpannedClass.SPAN_EXCLUSIVE_EXCLUSIVE
							);
					}
					else
					{
						if (type == ids.underlineId)
						{
							buffer.setSpan(new android.text.style.UnderlineSpan(), style[i + 1], style[i + 2]
								 + 1, android.text.SpannedClass.SPAN_EXCLUSIVE_EXCLUSIVE);
						}
						else
						{
							if (type == ids.ttId)
							{
								buffer.setSpan(new android.text.style.TypefaceSpan("monospace"), style[i + 1], style
									[i + 2] + 1, android.text.SpannedClass.SPAN_EXCLUSIVE_EXCLUSIVE);
							}
							else
							{
								if (type == ids.bigId)
								{
									buffer.setSpan(new android.text.style.RelativeSizeSpan(1.25f), style[i + 1], style
										[i + 2] + 1, android.text.SpannedClass.SPAN_EXCLUSIVE_EXCLUSIVE);
								}
								else
								{
									if (type == ids.smallId)
									{
										buffer.setSpan(new android.text.style.RelativeSizeSpan(0.8f), style[i + 1], style
											[i + 2] + 1, android.text.SpannedClass.SPAN_EXCLUSIVE_EXCLUSIVE);
									}
									else
									{
										if (type == ids.subId)
										{
											buffer.setSpan(new android.text.style.SubscriptSpan(), style[i + 1], style[i + 2]
												 + 1, android.text.SpannedClass.SPAN_EXCLUSIVE_EXCLUSIVE);
										}
										else
										{
											if (type == ids.supId)
											{
												buffer.setSpan(new android.text.style.SuperscriptSpan(), style[i + 1], style[i + 
													2] + 1, android.text.SpannedClass.SPAN_EXCLUSIVE_EXCLUSIVE);
											}
											else
											{
												if (type == ids.strikeId)
												{
													buffer.setSpan(new android.text.style.StrikethroughSpan(), style[i + 1], style[i 
														+ 2] + 1, android.text.SpannedClass.SPAN_EXCLUSIVE_EXCLUSIVE);
												}
												else
												{
													if (type == ids.listItemId)
													{
														addParagraphSpan(buffer, new android.text.style.BulletSpan(10), style[i + 1], style
															[i + 2] + 1);
													}
													else
													{
														if (type == ids.marqueeId)
														{
															buffer.setSpan(android.text.TextUtils.TruncateAt.MARQUEE, style[i + 1], style[i +
																 2] + 1, android.text.SpannedClass.SPAN_INCLUSIVE_INCLUSIVE);
														}
														else
														{
															string tag = nativeGetString(mNative, type);
															if (tag.StartsWith("font;"))
															{
																string sub;
																sub = subtag(tag, ";height=");
																if (sub != null)
																{
																	int size = System.Convert.ToInt32(sub);
																	addParagraphSpan(buffer, new android.content.res.StringBlock.Height(size), style[
																		i + 1], style[i + 2] + 1);
																}
																sub = subtag(tag, ";size=");
																if (sub != null)
																{
																	int size = System.Convert.ToInt32(sub);
																	buffer.setSpan(new android.text.style.AbsoluteSizeSpan(size, true), style[i + 1], 
																		style[i + 2] + 1, android.text.SpannedClass.SPAN_EXCLUSIVE_EXCLUSIVE);
																}
																sub = subtag(tag, ";fgcolor=");
																if (sub != null)
																{
																	int color = android.util.@internal.XmlUtils.convertValueToUnsignedInt(sub, -1);
																	buffer.setSpan(new android.text.style.ForegroundColorSpan(color), style[i + 1], style
																		[i + 2] + 1, android.text.SpannedClass.SPAN_EXCLUSIVE_EXCLUSIVE);
																}
																sub = subtag(tag, ";bgcolor=");
																if (sub != null)
																{
																	int color = android.util.@internal.XmlUtils.convertValueToUnsignedInt(sub, -1);
																	buffer.setSpan(new android.text.style.BackgroundColorSpan(color), style[i + 1], style
																		[i + 2] + 1, android.text.SpannedClass.SPAN_EXCLUSIVE_EXCLUSIVE);
																}
															}
															else
															{
																if (tag.StartsWith("a;"))
																{
																	string sub;
																	sub = subtag(tag, ";href=");
																	if (sub != null)
																	{
																		buffer.setSpan(new android.text.style.URLSpan(sub), style[i + 1], style[i + 2] + 
																			1, android.text.SpannedClass.SPAN_EXCLUSIVE_EXCLUSIVE);
																	}
																}
																else
																{
																	if (tag.StartsWith("annotation;"))
																	{
																		int len = tag.Length;
																		int next;
																		{
																			for (int t = tag.IndexOf(';'); t < len; t = next)
																			{
																				int eq = tag.IndexOf('=', t);
																				if (eq < 0)
																				{
																					break;
																				}
																				next = tag.IndexOf(';', eq);
																				if (next < 0)
																				{
																					next = len;
																				}
																				string key = Sharpen.StringHelper.Substring(tag, t + 1, eq);
																				string value = Sharpen.StringHelper.Substring(tag, eq + 1, next);
																				buffer.setSpan(new android.text.Annotation(key, value), style[i + 1], style[i + 2
																					] + 1, android.text.SpannedClass.SPAN_EXCLUSIVE_EXCLUSIVE);
																			}
																		}
																	}
																}
															}
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
				i += 3;
			}
			return new android.text.SpannedString(buffer);
		}

		private static void addParagraphSpan(android.text.Spannable buffer, object what, 
			int start, int end)
		{
			int len = buffer.Length;
			if (start != 0 && start != len && buffer[start - 1] != '\n')
			{
				for (start--; start > 0; start--)
				{
					if (buffer[start - 1] == '\n')
					{
						break;
					}
				}
			}
			if (end != 0 && end != len && buffer[end - 1] != '\n')
			{
				for (end++; end < len; end++)
				{
					if (buffer[end - 1] == '\n')
					{
						break;
					}
				}
			}
			buffer.setSpan(what, start, end, android.text.SpannedClass.SPAN_PARAGRAPH);
		}

		private static string subtag(string full, string attribute)
		{
			int start = full.IndexOf(attribute);
			if (start < 0)
			{
				return null;
			}
			start += attribute.Length;
			int end = full.IndexOf(';', start);
			if (end < 0)
			{
				return Sharpen.StringHelper.Substring(full, start);
			}
			else
			{
				return Sharpen.StringHelper.Substring(full, start, end);
			}
		}

		[Sharpen.Stub]
		private class Height : android.text.style.LineHeightSpanClass.WithDensity
		{
			internal int mSize;

			internal static float sProportion = 0;

			[Sharpen.Stub]
			public Height(int size)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.text.style.LineHeightSpan")]
			public virtual void chooseHeight(java.lang.CharSequence text, int start, int end, 
				int spanstartv, int v, android.graphics.Paint.FontMetricsInt fm)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.text.style.LineHeightSpan.WithDensity")]
			public virtual void chooseHeight(java.lang.CharSequence text, int start, int end, 
				int spanstartv, int v, android.graphics.Paint.FontMetricsInt fm, android.text.TextPaint
				 paint)
			{
				throw new System.NotImplementedException();
			}
		}

		internal StringBlock(android.content.res.StringBlock.NativeStringBlock obj, bool 
			useSparse)
		{
			mNative = obj;
			mUseSparse = useSparse;
			mOwnsNative = false;
		}

		[Sharpen.Stub]
		private static int nativeCreate(byte[] data, int offset, int size)
		{
			throw new System.NotImplementedException();
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern int libxobotos_StringBlock_nativeGetSize(android.content.res.StringBlock.NativeStringBlock
			 obj);

		private static int nativeGetSize(android.content.res.StringBlock.NativeStringBlock
			 obj)
		{
			return libxobotos_StringBlock_nativeGetSize(obj);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern System.IntPtr libxobotos_StringBlock_nativeGetString(android.content.res.StringBlock.NativeStringBlock
			 obj, int idx);

		private static string nativeGetString(android.content.res.StringBlock.NativeStringBlock
			 obj, int idx)
		{
			System.IntPtr _retval_ptr = libxobotos_StringBlock_nativeGetString(obj, idx);
			string _retval = XobotOS.Runtime.MarshalGlue.String_Helper.NativeToManaged(_retval_ptr
				);
			XobotOS.Runtime.MarshalGlue.String_Helper.FreeNativePtr(_retval_ptr);
			return _retval;
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern System.IntPtr libxobotos_StringBlock_nativeGetStyle(android.content.res.StringBlock.NativeStringBlock
			 obj, int idx);

		private static int[] nativeGetStyle(android.content.res.StringBlock.NativeStringBlock
			 obj, int idx)
		{
			System.IntPtr _retval_ptr = libxobotos_StringBlock_nativeGetStyle(obj, idx);
			int[] _retval = XobotOS.Runtime.MarshalGlue.Array_int_Helper.NativeToManaged(_retval_ptr
				);
			XobotOS.Runtime.MarshalGlue.Array_int_Helper.FreeNativePtr(_retval_ptr);
			return _retval;
		}

		private static void nativeDestroy(android.content.res.StringBlock.NativeStringBlock
			 obj)
		{
			obj.Dispose();
		}

		public void Dispose()
		{
			mNative.Dispose();
		}

		internal class NativeStringBlock : System.Runtime.InteropServices.SafeHandle
		{
			internal NativeStringBlock() : base(System.IntPtr.Zero, true)
			{
			}

			internal NativeStringBlock(System.IntPtr handle) : base(System.IntPtr.Zero, true)
			{
				this.handle = handle;
			}

			[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
				Unicode)]
			private static extern void libxobotos_android_content_res_StringBlock_destructor(
				System.IntPtr handle);

			internal System.IntPtr Handle
			{
				get
				{
					return handle;
				}
			}

			public static readonly NativeStringBlock Zero = new NativeStringBlock();

			protected override bool ReleaseHandle()
			{
				if (handle != System.IntPtr.Zero)
				{
					libxobotos_android_content_res_StringBlock_destructor(handle);
				}
				handle = System.IntPtr.Zero;
				return true;
			}

			public override bool IsInvalid
			{
				get
				{
					return handle == System.IntPtr.Zero;
				}
			}
		}
	}
}
