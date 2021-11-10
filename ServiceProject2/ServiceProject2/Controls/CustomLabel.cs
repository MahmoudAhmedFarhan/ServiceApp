using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ServiceProject2.Controls
{
    public class CustomLabel : Label
    {
        public CustomLabel()
        {
            if (App.Lang == "ar")
                this.HorizontalOptions = LayoutOptions.End;
            else
                this.HorizontalOptions = LayoutOptions.Start;
        }
    }
}
