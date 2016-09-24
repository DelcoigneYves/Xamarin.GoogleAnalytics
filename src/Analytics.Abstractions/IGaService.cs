namespace Analytics.Abstractions
{
    public interface IGaService
    {
        string TrackerId { get; set; }

        void TrackEvent(string category, string action, string label = null);
        void TrackScreen(string screenName);
        void SetCustomDimension(int key, string value);
        void EnableAutoActivityTracking(bool enabled);
        void EnableExceptionReporting(bool enabled);
        void EnableAdvertisingIdCollection(bool enabled);
        void SetEncoding(string encoding);
        void SetSampleRate(double sampleRate);
        void SetSessionTimeOut(long sessionTimeOut);
        void SetLocalDispatchPeriod(int seconds);
    }
}