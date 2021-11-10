using Plugin.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ServiceProject2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RequestPage : Controls.CustomPage
    {
        public RequestPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                DisplayAlert("No Camera", ":( No camera available.", "OK");
                return;
            }

            var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                Directory = "Sample",
                Name = "test.jpg"
            });


            if (file == null)
                return;

            image.Source = ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();
                return stream;
            });


            await Share.RequestAsync(new ShareFileRequest
            {
                Title = Title,
                File = new ShareFile(file.Path)
            });

            string imageName = Convert.ToBase64String(Helpers.Utility.ReadToEnd(file.GetStream()));
            var vm = this.BindingContext as ViewModels.RequestViewModel;
            vm.ImageName = imageName;
            this.BindingContext = vm;
        }
    }
}