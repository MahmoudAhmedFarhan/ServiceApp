using GalaSoft.MvvmLight;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using ServiceProject2.Models;
using System.Collections.ObjectModel;
using Xamarin.Forms.GoogleMaps;
using System.Threading.Tasks;
using Xamarin.Essentials;
using GalaSoft.MvvmLight.Command;
using Xamarin.Forms;

namespace ServiceProject2.ViewModels
{
    public class RequestViewModel : BaseViewModel
    {
        private ServiceProviderModel _SelectedProvider;
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



        private double _Qty;
        public double Qty
        {
            get
            {
                return _Qty;
            }
            set
            {
                Set(ref _Qty, value);
            }
        }

        private string _Description;
        public string Description
        {
            get
            {
                return _Description;
            }
            set
            {
                Set(ref _Description, value);
            }
        }

        public string ImageName { get; set; }

        public RelayCommand RequestService
        {
            get
            {
                return new RelayCommand(OnRequestService, () => true);
            }
        }

        public RequestViewModel()
        {

        }

        async void OnRequestService()
        {
            RequestModel model = new RequestModel();
            model.ServiceId = SelectedProvider.ServiceId;
            model.ProviderId = SelectedProvider.ProvicderId;
            model.Qty = this.Qty;
            model.Description = this.Description;
            model.Cost = SelectedProvider.ServiceCost;
            model.ImageName = this.ImageName;

            string json = await Helpers.Utility.PostData("/api/Request", JsonConvert.SerializeObject(model));

            if(string.IsNullOrEmpty(JsonConvert.DeserializeObject<string>(json)))
            {
                await App.Current.MainPage.DisplayAlert("information", "request saved", "ok");
                App.Current.MainPage= new NavigationPage(new MainPage());
            }
        }
    }
}
