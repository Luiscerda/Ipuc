
namespace Ipuc
{
    using Views;
    using Xamarin.Forms;
    using Helpers;
    using ViewModels;
    public partial class App : Application
    {
        #region Properties
        public static NavigationPage Navigator { get; internal set; } 
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
                var mainViewModel = MainViewModels.GetInstance();
                mainViewModel.Token = Settings.Token;
                mainViewModel.TokenType = Settings.TokenType;
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
