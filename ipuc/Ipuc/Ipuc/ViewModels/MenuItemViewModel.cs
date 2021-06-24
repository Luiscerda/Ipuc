﻿namespace Ipuc.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using Ipuc.Helpers;
    using System.Windows.Input;
    using Views;
    using Xamarin.Forms;
    public class MenuItemViewModel
    {
        #region Properties
        public string Icon { get; set; }
        public string Title { get; set; }
        public string PageName { get; set; }
        #endregion

        #region Commands

        public ICommand NavigateCommand
        {
            get
            {
                return new RelayCommand(Navigate);
            }
        }
        #endregion

        #region Methods
        private void Navigate()
        {
            App.Master.IsPresented = false;
            if (this.PageName == "LoginPage")
            {
                Settings.Token = string.Empty;
                Settings.TokenType = string.Empty;
                var mainViewModel = MainViewModels.GetInstance();
                mainViewModel.Token = string.Empty;
                mainViewModel.TokenType = string.Empty;
                Application.Current.MainPage = new NavigationPage(new LoginPage());
            }
            else if (this.PageName == "MyProfilePage")
            {
                MainViewModels.GetInstance().MyProfile = new MyProfileViewModel();
                App.Navigator.PushAsync(new MyProfilePage());
            }
            else if (this.PageName == "RegisterMembersPage")
            {
                MainViewModels.GetInstance().Members = new RegisterMembersViewModels();
                App.Navigator.PushAsync(new RegisterMembersPage());
            }
            else if (this.PageName == "ListMembersPage")
            {
                MainViewModels.GetInstance().MembersList = new MembersViewModels();
                App.Navigator.PushAsync(new MembersPage());
            }
        }
        #endregion
    }
}
