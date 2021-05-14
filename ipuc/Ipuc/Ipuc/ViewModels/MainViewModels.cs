namespace Ipuc.ViewModels
{
    using Helpers;
    using Models;
    using System.Collections.ObjectModel;

    public class MainViewModels
    {
        #region Propiedades
        public string Token { get; set; }
        public string TokenType { get; set; }
        public string SelectModule { get; set; }
        public ObservableCollection<MenuItemViewModel> Menus { get; set; }
        #endregion

        #region ViewModels

        public LoginViewModels Login { get; set; }
        public BiblesViewModel Bibles { get; set; }
        public BibleViewModel Bible { get; set; }
        public BookViewModel Book { get; set; }
        #endregion

        #region Constructor
        public MainViewModels()
        {
            instance = this;
            this.Login = new LoginViewModels();
            //this.Bibles = new BiblesViewModel();
            this.LoadMenu();
        }
        #endregion

        #region Singleton

        private static MainViewModels instance;
        public static MainViewModels GetInstance()
        {
            if (instance == null)
            {
                return new MainViewModels();
            }
            return instance;
        }
        #endregion

        #region Methods
        private void LoadMenu()
        {
            this.Menus = new ObservableCollection<MenuItemViewModel>();
            this.Menus.Add(new MenuItemViewModel
            {
                Icon = "ic_action_settings",
                PageName = "MyProfilePage",
                Title = Languages.MyProfile
            });
            this.Menus.Add(new MenuItemViewModel
            {
                Icon = "ic_account_child",
                PageName = "RegisterMembersPage",
                Title = Languages.RegisterMembers
            });
            this.Menus.Add(new MenuItemViewModel
            {
                Icon = "ic_exit_to_app",
                PageName = "LoginPage",
                Title = Languages.LogOut
            });
        }
        #endregion
    }
}
