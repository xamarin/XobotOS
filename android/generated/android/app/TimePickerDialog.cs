using Sharpen;

namespace android.app
{
	[Sharpen.Stub]
	public class TimePickerDialog : android.app.AlertDialog, android.content.DialogInterfaceClass
		.OnClickListener, android.widget.TimePicker.OnTimeChangedListener
	{
		[Sharpen.Stub]
		public interface OnTimeSetListener
		{
			[Sharpen.Stub]
			void onTimeSet(android.widget.TimePicker view, int hourOfDay, int minute);
		}

		internal const string HOUR = "hour";

		internal const string MINUTE = "minute";

		internal const string IS_24_HOUR = "is24hour";

		private readonly android.widget.TimePicker mTimePicker;

		private readonly android.app.TimePickerDialog.OnTimeSetListener mCallback;

		internal int mInitialHourOfDay;

		internal int mInitialMinute;

		internal bool mIs24HourView;

		[Sharpen.Stub]
		public TimePickerDialog(android.content.Context context, android.app.TimePickerDialog
			.OnTimeSetListener callBack, int hourOfDay, int minute, bool is24HourView) : this
			(context, 0, callBack, hourOfDay, minute, is24HourView)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public TimePickerDialog(android.content.Context context, int theme, android.app.TimePickerDialog
			.OnTimeSetListener callBack, int hourOfDay, int minute, bool is24HourView) : base
			(context, theme)
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
		public virtual void updateTime(int hourOfDay, int minutOfHour)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.widget.TimePicker.OnTimeChangedListener")]
		public virtual void onTimeChanged(android.widget.TimePicker view, int hourOfDay, 
			int minute)
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
