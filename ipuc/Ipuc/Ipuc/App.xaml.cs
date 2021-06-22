
namespace Ipuc
{
    using Views;
    using Xamarin.Forms;
    using Helpers;
    using ViewModels;
    using Ipuc.Services;
    using Models;

    public partial class App : Application
    {
        #region Properties
        public static NavigationPage Navigator { get; internal set; }
        public static MasterPage Master { get; internal set; }
        #endregion

        #region Constructors
        public App()
        {
            InitializeComponent();
            if (string.IsNullOrEmpty(Settings.Token))
            {
                this.MainPage = new NavigationPage(new LoginPage());
            }
            else
            {
                var dataService = new DataService();
                var user = dataService.First();
                var mainViewModel = MainViewModels.GetInstance();
                mainViewModel.Token = Settings.Token;
                mainViewModel.TokenType = Settings.TokenType;
                mainViewModel.User = user;
                mainViewModel.Bibles = new BiblesViewModel();
                this.MainPage = new MasterPage();
            }
           
        }
        #endregion

        #region Methods
        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        } 
        #endregion
    }
}
