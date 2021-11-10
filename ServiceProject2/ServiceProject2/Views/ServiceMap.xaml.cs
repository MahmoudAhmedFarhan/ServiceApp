using ServiceProject2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;
using Xamarin.Forms.Xaml;
using Rg.Plugins.Popup.Extensions;

namespace ServiceProject2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ServiceMap : Controls.CustomPage
    {
        ServiceModel myModel;
        public ServiceMap(ServiceModel model)
        {
            InitializeComponent();
            myModel = model;
        }

        private async void myMap_PinClicked(object sender, PinClickedEventArgs e)
        {
            var vm = this.BindingContext as ViewModels.ServiceProvidersViewModel;
            ServiceProviderModel model = e.Pin.Tag as ServiceProviderModel;
            vm.SelectedProvider = model;
            var page = new Views.ProviderPopup();
            page.BindingContext = vm;
            this.BindingContext = vm;
            await Navigation.PushPopupAsync(page);
        }

        private async void Page_Appearing(object sender, EventArgs e)
        {
            var vm = this.BindingContext as ViewModels.ServiceProvidersViewModel;
            vm.CurrentService = myModel;
            await vm.DrawMap(myMap);
            this.Title = myModel.ServiceName;
        }
    }
}