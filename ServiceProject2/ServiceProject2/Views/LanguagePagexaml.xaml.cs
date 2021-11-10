using ServiceProject2.Resources;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ServiceProject2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LanguagePagexaml : Controls.CustomPage
    {
        bool isLoad = false;
        public LanguagePagexaml()
        {
            InitializeComponent();
            isLoad = true;
            swLanguage.IsToggled = (App.Lang == "ar");
            isLoad = false;
        }

        private async void SwLanguage_Toggled(object sender, ToggledEventArgs e)
        {
            if (isLoad == true)
                return;

            if (swLanguage.IsToggled)
                App.Lang = Helpers.Settings.Language = "ar";
            else
                App.Lang = Helpers.Settings.Language = "en";

            MainResource.Culture = new CultureInfo(App.Lang);
            await DisplayAlert("Information", "Application Language has been changed", "ok");
            App.Current.MainPage = new NavigationPage(new MainPage());
        }
    }
}