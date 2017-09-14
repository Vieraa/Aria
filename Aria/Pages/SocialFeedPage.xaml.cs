using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Aria.Pages
{
    public partial class SocialFeedPage : ContentPage
    {
        public SocialFeedPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            CreateProfile(9);
        }

		protected override void OnAppearing()
		{
			
		}

		private void CreateProfile(int profileNum = 1)
		{
			for (int i = 0; i < profileNum; i++)
			{
				if (i == 0)
				{
					var stackLayout = new StackLayout
					{
						Margin = new Thickness(0, 15, 0, 5),

						Orientation = StackOrientation.Horizontal,

						Children = {

							new BoxView { BackgroundColor = Color.FromHex("489AA9"),
								WidthRequest = 50,
								HeightRequest = 50,
								Margin = new Thickness(20, 0) },

							new Label { Text = "1st Profile Name",
								TextColor = Color.FromHex("3F99A2"),
								FontSize = 20.0,
								Margin = new Thickness(5, 0),
								HorizontalTextAlignment = TextAlignment.Center,
								VerticalOptions = LayoutOptions.Center}
						}
					};

					verticalLayout.Children.Add((stackLayout));
				}
				else
				{
					var stackLayout = new StackLayout
					{
						Margin = new Thickness(0, 5),

						Orientation = StackOrientation.Horizontal,

						Children = {

							new BoxView { BackgroundColor = Color.FromHex("489AA9"),
								WidthRequest = 50,
								HeightRequest = 50,
								Margin = new Thickness(20, 0) },

							new Label { Text = i + " Profile Name",
								TextColor = Color.FromHex("3F99A2"),
								FontSize = 20.0,
								Margin = new Thickness(5, 0),
								HorizontalTextAlignment = TextAlignment.Center,
								VerticalOptions = LayoutOptions.Center}
						}
					};

					verticalLayout.Children.Add((stackLayout));
				}
			}

			Content = relativeLayout;
		}
    }
}
