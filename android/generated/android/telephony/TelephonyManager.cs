using Sharpen;

namespace android.telephony
{
	[Sharpen.Stub]
	public class TelephonyManager
	{
		[Sharpen.Stub]
		public TelephonyManager(android.content.Context context)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static android.telephony.TelephonyManager getDefault()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual string getDeviceSoftwareVersion()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual string getDeviceId()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.telephony.CellLocation getCellLocation()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void enableLocationUpdates()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void disableLocationUpdates()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual java.util.List<android.telephony.NeighboringCellInfo> getNeighboringCellInfo
			()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int getCurrentPhoneType()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int getPhoneType()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual string getNetworkOperatorName()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual string getNetworkOperator()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool isNetworkRoaming()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual string getNetworkCountryIso()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int getNetworkType()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static int getNetworkClass(int networkType)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual string getNetworkTypeName()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static string getNetworkTypeName(int type)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool hasIccCard()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int getSimState()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual string getSimOperator()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual string getSimOperatorName()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual string getSimCountryIso()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual string getSimSerialNumber()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int getLteOnCdmaMode()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual string getSubscriberId()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual string getLine1Number()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual string getLine1AlphaTag()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual string getMsisdn()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual string getVoiceMailNumber()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual string getCompleteVoiceMailNumber()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int getVoiceMessageCount()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual string getVoiceMailAlphaTag()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual string getIsimImpi()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual string getIsimDomain()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual string[] getIsimImpu()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int getCallState()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int getDataActivity()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int getDataState()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void listen(android.telephony.PhoneStateListener listener, int events
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int getCdmaEriIconIndex()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int getCdmaEriIconMode()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual string getCdmaEriText()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool isVoiceCapable()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool isSmsCapable()
		{
			throw new System.NotImplementedException();
		}
	}
}
