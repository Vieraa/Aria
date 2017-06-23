using Xamarin.Forms;

namespace Aria
{
    public partial class AriaPage : TabbedPage
    {
        //-------------------Properties-------------------
        private static NavigationPage[] _NavPages = new NavigationPage[5];

		private static SocialFeedPage _SocialFeedPage = new SocialFeedPage();
		private static PromotionsPage _PromotionsPage = new PromotionsPage();
		private static CheckInPage _CheckInPage = new CheckInPage();
		private static NotificationsPage _NotificationsPage = new NotificationsPage();
		private static ProfilePage _ProfilePage = new ProfilePage();

        private LoginPage loginPage = new LoginPage();


		//-------------------Methods-------------------
		public AriaPage()
        {
            InitializeComponent();

            //_NavPages;

            AssignContentToNavPage();
            AddNavPage();

            App.SetNavPage(_NavPages[0]);
            App.SetProfilePage(_ProfilePage);

            CheckUserLogin();
        }

        private void AssignContentToNavPage()
        {
            _NavPages[0] = new NavigationPage(_SocialFeedPage);
            _NavPages[0].Title = "Social Feed";

            _NavPages[1] = new NavigationPage(_PromotionsPage);
            _NavPages[1].Title = "Promotions";

            _NavPages[2] = new NavigationPage(_CheckInPage);
            _NavPages[2].Title = "Check In";

            _NavPages[3] = new NavigationPage(_NotificationsPage);
            _NavPages[3].Title = "Notifications";

            _NavPages[4] = new NavigationPage(_ProfilePage);
            _NavPages[4].Title = "Profile";
        }

        private void AddNavPage()
        {
            for (int i = 0; i < _NavPages.Length; i++)
            {
                Children.Add(_NavPages[i]);
            }
        }

        private void CheckUserLogin()
        {
			if (!App.IsLoggedIn())
			{
				Navigation.PushModalAsync(loginPage);
			}
        }

    }
}
