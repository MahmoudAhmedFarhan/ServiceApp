using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;
using ServiceProject2.Models;
using Newtonsoft.Json;
using GalaSoft.MvvmLight.Command;
using ServiceProject2.ViewModels;
using Xamarin.Essentials;
using System.Windows.Input;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace ServiceProject2.ViewModel
{

    public class MainViewModel : BaseViewModel
    {

        ObservableCollection<ServiceModel> _lstServices;
        public ObservableCollection<ServiceModel> lstServices
        {
            get
            {
                return _lstServices;
            }
            set
            {
                Set(ref _lstServices, value);
            }
        }

        private ObservableCollection<RequestListModel> _RequestListModel;
        public ObservableCollection<RequestListModel> RequestListModel
        {
            get
            {
                return _RequestListModel;
            }
            set
            {
                Set(ref _RequestListModel, value);
            }
        }
        public RelayCommand<ServiceModel> SelectService
        {
            get
            {
                return new RelayCommand<ServiceModel>((s) => OnSelectServuce(s));
            }
        }

        public RelayCommand AboutApp
        {
            get
            {
                return new RelayCommand(OnAboutApp, ()=>true);
            }
        }

        public RelayCommand Terrms
        {
            get
            {
                return new RelayCommand(OnTerrms, () => true);
            }
        }

        public MainViewModel()
        {
            LoadRequests();
        }

        async void OnAboutApp()
        {
            var Pages = new Views.WebPage();
            var pagesViewMode = new ViewModels.PagesViewModels();
            pagesViewMode.PageId = 1;
            await pagesViewMode.LoadData();
            Pages.BindingContext = pagesViewMode;
            await App.Current.MainPage.Navigation.PushAsync(Pages);
        }

        async void OnTerrms()
        {
            var Pages = new Views.WebPage();
            var pagesViewMode = new ViewModels.PagesViewModels();
            pagesViewMode.PageId = 2;
            await pagesViewMode.LoadData();
            Pages.BindingContext = pagesViewMode;
            await App.Current.MainPage.Navigation.PushAsync(Pages);
        }

        public async Task LoadData()
        {
            IsBusy = true;
            string json = await Helpers.Utility.CallWebApi("/api/Services");
            if(string.IsNullOrEmpty(json))
            {
                IsBusy = false;
                return;
            }

            lstServices = JsonConvert.DeserializeObject<ObservableCollection<ServiceModel>>(json);
            if (lstServices == null)
            {
                IsBusy = false;
                return;
            }
            foreach (var service in lstServices)
            {
                if (service == null)
                    continue;
                service.ServiceIcon = string.Format("{0}Content/Images/{1}", Helpers.Utility.ServerUrl, service.ServiceIcon);
                service.ServiceName = (App.Lang == "ar") ? service.ServiceNameAr: service.ServiceName;
            }
            IsBusy = false;
        }

        public async void LoadRequests()
        {
            //IsBusy = true;
            string json = await Helpers.Utility.CallWebApi("/api/Request");
            if (string.IsNullOrEmpty(json))
            {
                //IsBusy = false;
                return;
            }

            RequestListModel = JsonConvert.DeserializeObject<ObservableCollection<RequestListModel>>(json);
            if (RequestListModel == null)
            {
                IsBusy = false;
                return;
            }
            //IsBusy = false;
        }

        async void OnSelectServuce(ServiceModel model)
        {
            await App.Current.MainPage.Navigation.PushAsync(new Views.ServiceMap(model));
        }
    }
}