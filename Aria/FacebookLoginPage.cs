using System;

using Xamarin.Forms;

namespace Aria
{
    public class FacebookLoginPage : ContentPage
    {
        public FacebookLoginPage()
        {
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Hello ContentPage" }
                }
            };
        }
    }
}

