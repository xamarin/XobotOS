using Sharpen;

namespace android.location
{
	[Sharpen.Stub]
	public interface ILocationManager : android.os.IInterface
	{
		[Sharpen.Stub]
		java.util.List<string> getAllProviders();

		[Sharpen.Stub]
		java.util.List<string> getProviders(android.location.Criteria criteria, bool enabledOnly
			);

		[Sharpen.Stub]
		string getBestProvider(android.location.Criteria criteria, bool enabledOnly);

		[Sharpen.Stub]
		bool providerMeetsCriteria(string provider, android.location.Criteria criteria);

		[Sharpen.Stub]
		void requestLocationUpdates(string provider, android.location.Criteria criteria, 
			long minTime, float minDistance, bool singleShot, android.location.ILocationListener
			 listener);

		[Sharpen.Stub]
		void requestLocationUpdatesPI(string provider, android.location.Criteria criteria
			, long minTime, float minDistance, bool singleShot, android.app.PendingIntent intent
			);

		[Sharpen.Stub]
		void removeUpdates(android.location.ILocationListener listener);

		[Sharpen.Stub]
		void removeUpdatesPI(android.app.PendingIntent intent);

		[Sharpen.Stub]
		bool addGpsStatusListener(android.location.IGpsStatusListener listener);

		[Sharpen.Stub]
		void removeGpsStatusListener(android.location.IGpsStatusListener listener);

		[Sharpen.Stub]
		void locationCallbackFinished(android.location.ILocationListener listener);

		[Sharpen.Stub]
		bool sendExtraCommand(string provider, string command, android.os.Bundle extras);

		[Sharpen.Stub]
		void addProximityAlert(double latitude, double longitude, float distance, long expiration
			, android.app.PendingIntent intent);

		[Sharpen.Stub]
		void removeProximityAlert(android.app.PendingIntent intent);

		[Sharpen.Stub]
		android.os.Bundle getProviderInfo(string provider);

		[Sharpen.Stub]
		bool isProviderEnabled(string provider);

		[Sharpen.Stub]
		android.location.Location getLastKnownLocation(string provider);

		[Sharpen.Stub]
		void reportLocation(android.location.Location location, bool passive);

		[Sharpen.Stub]
		bool geocoderIsPresent();

		[Sharpen.Stub]
		string getFromLocation(double latitude, double longitude, int maxResults, android.location.GeocoderParams
			 @params, java.util.List<android.location.Address> addrs);

		[Sharpen.Stub]
		string getFromLocationName(string locationName, double lowerLeftLatitude, double 
			lowerLeftLongitude, double upperRightLatitude, double upperRightLongitude, int maxResults
			, android.location.GeocoderParams @params, java.util.List<android.location.Address
			> addrs);

		[Sharpen.Stub]
		void addTestProvider(string name, bool requiresNetwork, bool requiresSatellite, bool
			 requiresCell, bool hasMonetaryCost, bool supportsAltitude, bool supportsSpeed, 
			bool supportsBearing, int powerRequirement, int accuracy);

		[Sharpen.Stub]
		void removeTestProvider(string provider);

		[Sharpen.Stub]
		void setTestProviderLocation(string provider, android.location.Location loc);

		[Sharpen.Stub]
		void clearTestProviderLocation(string provider);

		[Sharpen.Stub]
		void setTestProviderEnabled(string provider, bool enabled);

		[Sharpen.Stub]
		void clearTestProviderEnabled(string provider);

		[Sharpen.Stub]
		void setTestProviderStatus(string provider, int status, android.os.Bundle extras, 
			long updateTime);

		[Sharpen.Stub]
		void clearTestProviderStatus(string provider);

		[Sharpen.Stub]
		bool sendNiResponse(int notifId, int userResponse);
	}

	[Sharpen.Stub]
	public static class ILocationManagerClass
	{
		[Sharpen.Stub]
		public abstract class Stub : android.os.Binder, android.location.ILocationManager
		{
			[Sharpen.Stub]
			public Stub()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public static android.location.ILocationManager asInterface(android.os.IBinder obj
				)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.os.IInterface")]
			public virtual android.os.IBinder asBinder()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"android.os.Binder")]
			protected internal override bool onTransact(int code, android.os.Parcel data, android.os.Parcel
				 reply, int flags)
			{
				throw new System.NotImplementedException();
			}

			public abstract bool addGpsStatusListener(android.location.IGpsStatusListener arg1
				);

			public abstract void addProximityAlert(double arg1, double arg2, float arg3, long
				 arg4, android.app.PendingIntent arg5);

			public abstract void addTestProvider(string arg1, bool arg2, bool arg3, bool arg4
				, bool arg5, bool arg6, bool arg7, bool arg8, int arg9, int arg10);

			public abstract void clearTestProviderEnabled(string arg1);

			public abstract void clearTestProviderLocation(string arg1);

			public abstract void clearTestProviderStatus(string arg1);

			public abstract bool geocoderIsPresent();

			public abstract java.util.List<string> getAllProviders();

			public abstract string getBestProvider(android.location.Criteria arg1, bool arg2);

			public abstract string getFromLocation(double arg1, double arg2, int arg3, android.location.GeocoderParams
				 arg4, java.util.List<android.location.Address> arg5);

			public abstract string getFromLocationName(string arg1, double arg2, double arg3, 
				double arg4, double arg5, int arg6, android.location.GeocoderParams arg7, java.util.List
				<android.location.Address> arg8);

			public abstract android.location.Location getLastKnownLocation(string arg1);

			public abstract android.os.Bundle getProviderInfo(string arg1);

			public abstract java.util.List<string> getProviders(android.location.Criteria arg1
				, bool arg2);

			public abstract bool isProviderEnabled(string arg1);

			public abstract void locationCallbackFinished(android.location.ILocationListener 
				arg1);

			public abstract bool providerMeetsCriteria(string arg1, android.location.Criteria
				 arg2);

			public abstract void removeGpsStatusListener(android.location.IGpsStatusListener 
				arg1);

			public abstract void removeProximityAlert(android.app.PendingIntent arg1);

			public abstract void removeTestProvider(string arg1);

			public abstract void removeUpdates(android.location.ILocationListener arg1);

			public abstract void removeUpdatesPI(android.app.PendingIntent arg1);

			public abstract void reportLocation(android.location.Location arg1, bool arg2);

			public abstract void requestLocationUpdates(string arg1, android.location.Criteria
				 arg2, long arg3, float arg4, bool arg5, android.location.ILocationListener arg6
				);

			public abstract void requestLocationUpdatesPI(string arg1, android.location.Criteria
				 arg2, long arg3, float arg4, bool arg5, android.app.PendingIntent arg6);

			public abstract bool sendExtraCommand(string arg1, string arg2, android.os.Bundle
				 arg3);

			public abstract bool sendNiResponse(int arg1, int arg2);

			public abstract void setTestProviderEnabled(string arg1, bool arg2);

			public abstract void setTestProviderLocation(string arg1, android.location.Location
				 arg2);

			public abstract void setTestProviderStatus(string arg1, int arg2, android.os.Bundle
				 arg3, long arg4);
		}
	}
}
