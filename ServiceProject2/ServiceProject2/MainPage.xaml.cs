using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ServiceProject2
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : Controls.CustomPage
    {
        public MainPage()
        {
            try
            {
                InitializeComponent();
                var vm = this.BindingContext as ViewModel.MainViewModel;
                vm.LoadData();
                this.BindingContext = vm;
            }
            catch (Exception ex)
            {

            }

        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Views.LanguagePagexaml());
        }

        private async void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            await Share.RequestAsync(new ShareTextRequest
            {
                Uri = "https://www.youtube.com/",
                Title = "Share Web Link"
            });
        }

        private async void Page_Appearing(object sender, EventArgs e)
        {

        }
    }
}
