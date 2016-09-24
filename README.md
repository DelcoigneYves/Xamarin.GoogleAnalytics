# Xamarin.GoogleAnalytics
## Why this library?
There are already some libraries out there that allow us to use Google Analytics in shared code. However, all these implementations use the REST API of Google Analytics. This library uses the platform-specific binding libraries.

The current version does not include all features of the Google Analytics library. For me, these are the features that I need for most projects. Feel free to send me a pull request!

## How to use
Check out the sample!

```C#
CrossAnalytics.Current.TrackerId = "XX-XXXXXXXX-X";
CrossAnalytics.Current.EnableAdvertisingIdCollection(true);
CrossAnalytics.Current.EnableAutoActivityTracking(false);
CrossAnalytics.Current.EnableExceptionReporting(true);
CrossAnalytics.Current.SetLocalDispatchPeriod(1);
CrossAnalytics.Current.TrackScreen("home");
CrossAnalytics.Current.TrackEvent("home", "click");
CrossAnalytics.Current.SetCustomDimension(1, "something");
```