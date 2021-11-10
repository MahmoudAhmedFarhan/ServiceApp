﻿using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using Syncfusion.ListView.XForms.iOS;
using Syncfusion.SfRating.XForms.iOS;
using Syncfusion.XForms.iOS.EffectsView;
using UIKit;

namespace ServiceProject2.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            Syncfusion.XForms.iOS.TabView.SfTabViewRenderer.Init();
            Rg.Plugins.Popup.Popup.Init();
            new SfRatingRenderer();
            SfListViewRenderer.Init();
            SfEffectsViewRenderer.Init();
            FFImageLoading.Forms.Platform.CachedImageRenderer.Init();
            Xamarin.FormsGoogleMaps.Init("AIzaSyB_yhQS-FRpoS0pmPtDBymZ7n3yG__s2ag", null);
            global::Xamarin.Forms.Forms.Init();
            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }
    }
}
