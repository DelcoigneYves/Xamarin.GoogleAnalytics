using System;
using Analytics.Abstractions;
using Android.App;
using Android.Gms.Analytics;

namespace Analytics
{
    public class GaService : BaseGaService
    {
        private GoogleAnalytics _instance;
        private GoogleAnalytics GetGoogleAnalytics()
        {
            return _instance ?? (_instance = GoogleAnalytics.GetInstance(Application.Context));
        }

        private Tracker _tracker;
        private Tracker Tracker
        {
            get
            {
                if (_tracker == null)
                {
                    if (string.IsNullOrEmpty(TrackerId))
                    {
                        throw new Exception("Tracker is not initialized yet. Did you add a TrackerId?");
                    }
                    _tracker = GetGoogleAnalytics().NewTracker(TrackerId);
                }
                return _tracker;
            }
        }

        public override void TrackEvent(string category, string action, string label = null)
        {
            var context = Application.Context;

            if (context == null)
            {
                return;
            }
            var eventBuilder = new HitBuilders.EventBuilder();

            eventBuilder.SetCategory(category)
                        .SetAction(action);

            if (label != null)
            {
                eventBuilder.SetLabel(label);
            }

            foreach (var key in CustomDimensions.Keys)
            {
                eventBuilder.SetCustomDimension(key, CustomDimensions[key]);
            }
            
            Tracker.Send(eventBuilder.Build());
        }

        public override void TrackScreen(string screenName)
        {
            var context = Application.Context;

            if (context == null)
            {
                return;
            }

            // Set screen name.
            Tracker.SetScreenName(screenName);

            // Send a screen view.
            var screenViewBuilder = new HitBuilders.ScreenViewBuilder();

            foreach (var key in CustomDimensions.Keys)
            {
                screenViewBuilder.SetCustomDimension(key, CustomDimensions[key]);
            }

            Tracker.Send(screenViewBuilder.Build());
        }

        public override void EnableAutoActivityTracking(bool enabled)
        {
            Tracker.EnableAutoActivityTracking(enabled);
        }

        public override void EnableExceptionReporting(bool enabled)
        {
            Tracker.EnableExceptionReporting(enabled);
        }

        public override void EnableAdvertisingIdCollection(bool enabled)
        {
            Tracker.EnableAdvertisingIdCollection(enabled);
        }

        public override void SetEncoding(string encoding)
        {
            Tracker.SetEncoding(encoding);
        }

        public override void SetSampleRate(double sampleRate)
        {
            Tracker.SetSampleRate(sampleRate);
        }

        public override void SetSessionTimeOut(long sessionTimeOut)
        {
            Tracker.SetSessionTimeout(sessionTimeOut);
        }

        public override void SetLocalDispatchPeriod(int seconds)
        {
            GetGoogleAnalytics().SetLocalDispatchPeriod(seconds);
        }
    }
}