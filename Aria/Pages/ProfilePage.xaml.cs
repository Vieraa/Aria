using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Xamarin.Forms;

using Facebook.ViewModels;

namespace Aria.Pages
{
    public partial class ProfilePage : ContentPage
    {
        //-------------------Properties-------------------
        private bool hasGeneratedProfile = false;

		private FacebookViewModel userViewModel = new FacebookViewModel();


		//-------------------Methods-------------------
		protected override void OnAppearing()
        {
			if (!hasGeneratedProfile)
			{
				GenerateUserProfile();
			}
        }


        public ProfilePage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

        }


        private async void GenerateUserProfile()
        {
            //Update profile name
            userProfileName.Text = "";

            if(userViewModel.FacebookProfile != null)
            {
				userProfileName.Text = userViewModel.FacebookProfile.Name;
				userProfilePic.Source = userViewModel.FacebookProfile.Picture.Data.Url;
            }
            else
            {
                await SetFbViewModel();

				userProfileName.Text = userViewModel.FacebookProfile.Name;
				userProfilePic.Source = userViewModel.FacebookProfile.Picture.Data.Url;
            }


            hasGeneratedProfile = true;
        }

        public async Task SetFbViewModel()
        {
            await userViewModel.SetFacebookProfileAsync(App.AccessToken);
        }
    }
}
