using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Analytics;
using Xamarin.Forms;

namespace Sample
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            CrossAnalytics.Current.TrackerId = "UA-51531431-2";
            CrossAnalytics.Current.EnableAdvertisingIdCollection(true);
            CrossAnalytics.Current.EnableAutoActivityTracking(false);
            CrossAnalytics.Current.EnableExceptionReporting(true);
            CrossAnalytics.Current.SetLocalDispatchPeriod(1);
            CrossAnalytics.Current.TrackScreen("home");
            CrossAnalytics.Current.TrackEvent("default", "startup");

            MainPage = new Sample.MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
