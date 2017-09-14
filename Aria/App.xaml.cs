using Xamarin.Forms;
using System.Threading.Tasks;

using Aria.Pages;
using Aria.GoogleFCM;

namespace Aria
{
    public partial class App : Application
    {
		//-------------------Properties-------------------
		private static NavigationPage _NavPage;
        private static ProfilePage _AppProfilePage;

        private static TabbedPage _TabbedPage = new TabbedPage();

        private static AriaPage _AriaPage;
        private static bool isLoggedIn;

        private static string _AccessToken;
        public static string AccessToken 
        {
            get { return _AccessToken; }
        }


		//-------------------Methods-------------------
		public App()
        {
            InitializeComponent();

            _AriaPage = new AriaPage();
            MainPage = _AriaPage;

            _TabbedPage.Children.Add(new NavigationPage(new SocialFeedPage()));
            MainPage = _AriaPage;

        }

        protected override void OnStart()
        {
			// Handle when your app starts
			if (_AccessToken == null)
			{
				isLoggedIn = false;
			}
			else
			{
				isLoggedIn = true;
                DependencyService.Get<IFirebaseIIDService>().OnTokenRefresh();
			}
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        public static void SetAccessToken(string token)
        {
            _AccessToken = token;
        }

        public static bool IsLoggedIn()
        {
            return isLoggedIn;
        }

        public static async Task SuccessfulLoginEvent()
        {
            await _AriaPage.Navigation.PopModalAsync();

            //Set fb viewmodel to allow access to data from Facebook API
            await _AppProfilePage.SetFbViewModel();
            isLoggedIn = true;

            DependencyService.Get<IFirebaseIIDService>().OnTokenRefresh();
        }

        //Nav page may not be needed
        public static void SetNavPage(NavigationPage navPage)
        {
            _NavPage = navPage;
        }

        public static void SetProfilePage(ProfilePage profilePage)
        {
            _AppProfilePage = profilePage;
        }
    }
}
