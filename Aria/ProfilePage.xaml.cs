using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Aria
{
    public partial class ProfilePage : ContentPage
    {
        public ProfilePage()
        {
            InitializeComponent();
        }

        private void GenerateUserProfile()
        {
			var stackLayout = new StackLayout
			{
				Margin = new Thickness(0, 15, 0, 5),

				Orientation = StackOrientation.Horizontal,

				Children = {

					new BoxView { BackgroundColor = Color.FromHex("3F99A2"),
						WidthRequest = 50,
						HeightRequest = 50,
						TranslationX = 20,
						HorizontalOptions = LayoutOptions.Start},

					new Label { Text = "1st Profile Name",
						TextColor = Color.FromHex("3F99A2"),
						FontSize = 20.0,
						TranslationX = 25,
						TranslationY = 0,
						HorizontalTextAlignment = TextAlignment.Center,
						VerticalOptions = LayoutOptions.Center}
			    }
			};


        }
    }
}
