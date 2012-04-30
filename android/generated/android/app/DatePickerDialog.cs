using Sharpen;

namespace android.app
{
	[Sharpen.Stub]
	public class DatePickerDialog : android.app.AlertDialog, android.content.DialogInterfaceClass
		.OnClickListener, android.widget.DatePicker.OnDateChangedListener
	{
		internal const string YEAR = "year";

		internal const string MONTH = "month";

		internal const string DAY = "day";

		private readonly android.widget.DatePicker mDatePicker;

		private readonly android.app.DatePickerDialog.OnDateSetListener mCallBack;

		[Sharpen.Stub]
		public interface OnDateSetListener
		{
			[Sharpen.Stub]
			void onDateSet(android.widget.DatePicker view, int year, int monthOfYear, int dayOfMonth
				);
		}

		[Sharpen.Stub]
		public DatePickerDialog(android.content.Context context, android.app.DatePickerDialog
			.OnDateSetListener callBack, int year, int monthOfYear, int dayOfMonth) : this(context
			, 0, callBack, year, monthOfYear, dayOfMonth)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public DatePickerDialog(android.content.Context context, int theme, android.app.DatePickerDialog
			.OnDateSetListener callBack, int year, int monthOfYear, int dayOfMonth) : base(context
			, theme)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.content.DialogInterface.OnClickListener")]
		public virtual void onClick(android.content.DialogInterface dialog, int which)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.widget.DatePicker.OnDateChangedListener")]
		public virtual void onDateChanged(android.widget.DatePicker view, int year, int month
			, int day)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.widget.DatePicker getDatePicker()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void updateDate(int year, int monthOfYear, int dayOfMonth)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.app.Dialog")]
		public override android.os.Bundle onSaveInstanceState()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.app.Dialog")]
		public override void onRestoreInstanceState(android.os.Bundle savedInstanceState)
		{
			throw new System.NotImplementedException();
		}
	}
}
