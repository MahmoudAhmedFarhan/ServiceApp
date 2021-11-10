using GalaSoft.MvvmLight;
using Newtonsoft.Json;
using ServiceProject2.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;

namespace ServiceProject2.ViewModels
{
    public class PagesViewModels : BaseViewModel
    {
        public PagesViewModels()
        {

        }

        PageModel _CurrenPage;
        public PageModel CurrentPage
        {
            get
            {
                return _CurrenPage;
            }
            set
            {
                Set(ref _CurrenPage, value);
            }
        }

        int _PageId;
        public int PageId
        {
            get
            {
                return _PageId;
            }
            set
            {
                Set(ref _PageId, value);
            }
        }

        HtmlWebViewSource _htmlSource;
        public HtmlWebViewSource htmlSource
        {
            get
            {
                return _htmlSource;
            }
            set
            {
                Set(ref _htmlSource, value);
            }
        }

        public async Task<bool> LoadData()
        {
            string json = await Helpers.Utility.CallWebApi("/api/Pages/" + PageId);
            if (string.IsNullOrEmpty(json))
            {
                return false;
            }

            CurrentPage = JsonConvert.DeserializeObject<PageModel>(json);
            htmlSource = new HtmlWebViewSource();
            htmlSource.Html = CurrentPage.PageContent;
            return true;
        }
    }
}
