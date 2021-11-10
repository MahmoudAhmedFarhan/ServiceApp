using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ServiceProject2.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ToolBar : StackLayout
    {
        public static readonly BindableProperty TitleProperty = BindableProperty.Create("Title", typeof(string), typeof(StackLayout), "", propertyChanged: OnEventNameChanged);

        public static readonly BindableProperty HasBackButtonProperty = BindableProperty.Create("HasBackButton", typeof(bool), typeof(StackLayout), true, propertyChanged: OnBackButtonChanged);
        public string Title
        {
            get { return (string)base.GetValue(TitleProperty); }
            set
            {
                base.SetValue(TitleProperty, value);
            }
        }

        public bool HasBackButton
        {
            get { return (bool)base.GetValue(HasBackButtonProperty); }
            set
            {
                base.SetValue(HasBackButtonProperty, value);
            }
        }
        public ToolBar()
        {
            InitializeComponent();
            if(App.Lang=="ar")
            {
                imgBack.Source = ImageSource.FromResource("ServiceProject2.Images.back-icon.png");
            }
            else
            {
                imgBack.Source = ImageSource.FromResource("ServiceProject2.Images.left_arrow.png");
            }
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        static void OnEventNameChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue == null)
                return;
            var tolbal = bindable as ToolBar;
            tolbal.lblTitle.Text = newValue.ToString();
        }

        static void OnBackButtonChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue == null)
                return;
            var tolbal = bindable as ToolBar;
            tolbal.imgBack.IsVisible = (bool)newValue;
        }
    }
}