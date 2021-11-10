using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ServiceProject2
{
    public partial class App : Application
    {
        public static string Lang = Helpers.Settings.Language;
        public App()
        {
            try
            {
                Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MjE1NzMwQDMxMzcyZTM0MmUzMGIrMkFlSHNzVWtnMXoreFM1a2xYVnNTQmVscExlKzdZeHNoVE9UVWRqTlU9");
                ServiceProject2.Resources.MainResource.Culture = new System.Globalization.CultureInfo(Lang);
                InitializeComponent();

                MainPage = new NavigationPage(new MainPage());
            }
            catch (Exception ex)
            {

            }
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
