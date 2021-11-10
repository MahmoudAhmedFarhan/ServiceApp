using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ServiceProject2.Controls
{
    public class CustomPage : ContentPage
    {
        public CustomPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            if (App.Lang == "ar")
                this.FlowDirection = FlowDirection.RightToLeft;
            else
                this.FlowDirection = FlowDirection.LeftToRight;
        }
    }
}
