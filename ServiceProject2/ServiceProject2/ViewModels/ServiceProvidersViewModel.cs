using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Newtonsoft.Json;
using Rg.Plugins.Popup.Extensions;
using ServiceProject2.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms.GoogleMaps;

namespace ServiceProject2.ViewModels
{
    public class ServiceProvidersViewModel : BaseViewModel
    {
        public ServiceProvidersViewModel()
        {
            LoadData();
        }

        ServiceModel _CurrenService;
        public ServiceModel CurrentService
        {
            get
            {
                return _CurrenService;
            }
            set
            {
                Set(ref _CurrenService, value);
            }
        }

        ObservableCollection<ServiceProviderModel> _lstProviders;
        public ObservableCollection<ServiceProviderModel> lstProviders
        {
            get
            {
                return _lstProviders;
            }
            set
            {
                Set(ref _lstProviders, value);
            }
        }

        ServiceProviderModel _SelectedProvider;
        public ServiceProviderModel SelectedProvider
        {
            get
            {
                return _SelectedProvider;
            }
            set
            {
                Set(ref _SelectedProvider, value);
            }
        }

        public RelayCommand RequestService
        {
            get
            {
                return new RelayCommand(OnRequestService, () => true);
            }
        }

        public async Task DrawMap(Xamarin.Forms.GoogleMaps.Map myMap)
        {
            var request = new GeolocationRequest(GeolocationAccuracy.Medium);
            var location = await Geolocation.GetLocationAsync(request);

            myMap.MoveToRegion(MapSpan.FromCenterAndRadius(
            new Position(30.048347, 30.9832235), Distance.FromMiles(1)));
            await LoadData();
            foreach (var provider in lstProviders)
            {
                var possition = new Position(provider.Lat, provider.Long);
                var pin = new Pin
                {
                    Type = PinType.Place,
                    Label = provider.ProviderName,
                    Position = possition,
                    Address = provider.Description,
                    Tag= provider
                };
                myMap.Pins.Add(pin);
            }
        }

        async Task<bool> LoadData()
        {
            string json = await Helpers.Utility.CallWebApi("/api/ServiceProviders/"+CurrentService.ServiceId);
            if (string.IsNullOrEmpty(json))
            {
                return false;
            }

            lstProviders = JsonConvert.DeserializeObject<ObservableCollection<ServiceProviderModel>>(json);
            foreach (var provider in lstProviders)
            {
                provider.ImageName = string.Format("{0}Content/Images/{1}", Helpers.Utility.ServerUrl, provider.ImageName);
            }
            return true;
        }

        async void OnRequestService()
        {
            await App.Current.MainPage.Navigation.PopPopupAsync();
            RequestViewModel oRequestViewModel = new RequestViewModel();
            oRequestViewModel.SelectedProvider = this.SelectedProvider;
            var page = new Views.RequestPage();
            page.BindingContext = oRequestViewModel;
            await App.Current.MainPage.Navigation.PushAsync(page);
        }
    }
}
