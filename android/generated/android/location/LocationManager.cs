using Sharpen;

namespace android.location
{
	[Sharpen.Stub]
	public class LocationManager
	{
		[Sharpen.Stub]
		public LocationManager(android.location.ILocationManager service)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual java.util.List<string> getAllProviders()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual java.util.List<string> getProviders(bool enabledOnly)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.location.LocationProvider getProvider(string name)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual java.util.List<string> getProviders(android.location.Criteria criteria
			, bool enabledOnly)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual string getBestProvider(android.location.Criteria criteria, bool enabledOnly
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void requestLocationUpdates(string provider, long minTime, float minDistance
			, android.location.LocationListener listener)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void requestLocationUpdates(string provider, long minTime, float minDistance
			, android.location.LocationListener listener, android.os.Looper looper)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void requestLocationUpdates(long minTime, float minDistance, android.location.Criteria
			 criteria, android.location.LocationListener listener, android.os.Looper looper)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void requestLocationUpdates(string provider, long minTime, float minDistance
			, android.app.PendingIntent intent)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void requestLocationUpdates(long minTime, float minDistance, android.location.Criteria
			 criteria, android.app.PendingIntent intent)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void requestSingleUpdate(string provider, android.location.LocationListener
			 listener, android.os.Looper looper)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void requestSingleUpdate(android.location.Criteria criteria, android.location.LocationListener
			 listener, android.os.Looper looper)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void requestSingleUpdate(string provider, android.app.PendingIntent
			 intent)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void requestSingleUpdate(android.location.Criteria criteria, android.app.PendingIntent
			 intent)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void removeUpdates(android.location.LocationListener listener)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void removeUpdates(android.app.PendingIntent intent)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void addProximityAlert(double latitude, double longitude, float radius
			, long expiration, android.app.PendingIntent intent)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void removeProximityAlert(android.app.PendingIntent intent)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool isProviderEnabled(string provider)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.location.Location getLastKnownLocation(string provider)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void addTestProvider(string name, bool requiresNetwork, bool requiresSatellite
			, bool requiresCell, bool hasMonetaryCost, bool supportsAltitude, bool supportsSpeed
			, bool supportsBearing, int powerRequirement, int accuracy)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void removeTestProvider(string provider)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setTestProviderLocation(string provider, android.location.Location
			 loc)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void clearTestProviderLocation(string provider)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setTestProviderEnabled(string provider, bool enabled)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void clearTestProviderEnabled(string provider)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setTestProviderStatus(string provider, int status, android.os.Bundle
			 extras, long updateTime)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void clearTestProviderStatus(string provider)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool addGpsStatusListener(android.location.GpsStatus.Listener listener
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void removeGpsStatusListener(android.location.GpsStatus.Listener listener
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool addNmeaListener(android.location.GpsStatus.NmeaListener listener
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void removeNmeaListener(android.location.GpsStatus.NmeaListener listener
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.location.GpsStatus getGpsStatus(android.location.GpsStatus
			 status)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool sendExtraCommand(string provider, string command, android.os.Bundle
			 extras)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool sendNiResponse(int notifId, int userResponse)
		{
			throw new System.NotImplementedException();
		}
	}
}
