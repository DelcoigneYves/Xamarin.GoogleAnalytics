using System;
using Analytics.Abstractions;
using Google.Analytics;

namespace Analytics
{
    public class GaService : BaseGaService
    {
        private Gai _instance;
        private Gai GetGoogleAnalytics()
        {
            return _instance ?? (_instance = Gai.SharedInstance);
        }

        private ITracker _tracker;
        private ITracker Tracker
        {
            get
            {
                if (_tracker == null)
                {
                    if (string.IsNullOrEmpty(TrackerId))
                    {
                        throw new Exception("Tracker is not initialized yet. Did you add a TrackerId?");
                    }
                    _tracker = GetGoogleAnalytics().GetTracker(TrackerId);
                }
                return _tracker;
            }
        }

        public override void TrackEvent(string category, string action, string label = null)
        {
            var eventBuilder = DictionaryBuilder.CreateEvent(category, action, string.IsNullOrEmpty(label) ? "" : label,
                null);

            if (CustomDimensions != null)
            {
                foreach (var key in CustomDimensions.Keys)
                {
                    Tracker.Set(Fields.CustomDimension((nuint)key), CustomDimensions[key]);
                }
            }

            Tracker.Send(eventBuilder.Build());
        }

        public override void TrackScreen(string screenName)
        {
            // Set screen name.
            Tracker.Set(GaiConstants.ScreenName, screenName);

            // Send a screen view.
            var screenViewBuilder = DictionaryBuilder.CreateScreenView();

            foreach (var key in CustomDimensions.Keys)
            {
                Tracker.Set(Fields.CustomDimension((nuint) key), CustomDimensions[key]);
            }
            

            Tracker.Send(screenViewBuilder.Build());
        }

        public override void EnableAutoActivityTracking(bool enabled)
        {
            //do nothing, Android-only method
        }

        public override void EnableExceptionReporting(bool enabled)
        {
            GetGoogleAnalytics().TrackUncaughtExceptions = enabled;
        }

        public override void EnableAdvertisingIdCollection(bool enabled)
        {
            //do nothing, Android-only method
        }

        public override void SetEncoding(string encoding)
        {
            Tracker.Set(GaiConstants.Encoding, encoding);
        }

        public override void SetSampleRate(double sampleRate)
        {
            Tracker.Set(GaiConstants.SampleRate, "" + sampleRate);
        }

        public override void SetSessionTimeOut(long sessionTimeOut)
        {
            //do nothing, no exact method for this
        }

        public override void SetLocalDispatchPeriod(int seconds)
        {
            GetGoogleAnalytics().DispatchInterval = seconds;
        }
    }
}