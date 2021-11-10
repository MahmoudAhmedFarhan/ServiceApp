using GalaSoft.MvvmLight;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceProject2.ViewModels
{
    public class BaseViewModel : ViewModelBase
    {
        public BaseViewModel()
        {
            CheckConnection();
        }

        async void CheckConnection()
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                await App.Current.MainPage.DisplayAlert("information", "you are offline", "ok");
            }
        }
        bool _IsBusy;
        public bool IsBusy
        {
            get
            {
                return _IsBusy;
            }
            set
            {
                Set(ref _IsBusy, value);
            }
        }
    }
}
