using System.Collections.Generic;

namespace Analytics.Abstractions
{
    public abstract class BaseGaService : IGaService
    {
        protected BaseGaService()
        {
            CustomDimensions = new Dictionary<int, string>();
        }

        protected Dictionary<int, string> CustomDimensions { get; set; }

        public string TrackerId { get; set; }
        public abstract void TrackEvent(string category, string action, string label = null);
        public abstract void TrackScreen(string screenName);

        public void SetCustomDimension(int key, string value)
        {
            CustomDimensions[key] = value;
        }

        public abstract void EnableAutoActivityTracking(bool enabled);
        public abstract void EnableExceptionReporting(bool enabled);
        public abstract void EnableAdvertisingIdCollection(bool enabled);
        public abstract void SetEncoding(string encoding);
        public abstract void SetSampleRate(double sampleRate);
        public abstract void SetSessionTimeOut(long sessionTimeOut);
        public abstract void SetLocalDispatchPeriod(int seconds);
    }
}