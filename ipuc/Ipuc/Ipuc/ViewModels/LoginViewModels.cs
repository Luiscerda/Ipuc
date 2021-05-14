﻿namespace Ipuc.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using Helpers;
    using Services;
    using System.Windows.Input;
    using Views;
    using Xamarin.Forms;

    public class LoginViewModels : BaseViewModels
    {
        #region Servicios
        private ApiService apiService;

        #endregion

        #region Atributos

        private string email;
        private string password;
        private bool isRunning;
        private bool isEnabled;
        #endregion
        #region Propiedades
        public string Email
        {
            get { return this.email; }
            set { SetValue(ref this.email, value); }
        }
        public string Password
        {
            get { return this.password; }
            set { SetValue(ref this.password, value); }
        }
        public bool IsRunning 
        {
            get { return this.isRunning; }
            set { SetValue(ref this.isRunning, value); }

        }
        public bool IsRemembered { get; set; }
        public bool IsEnabled 
        {
            get { return this.isEnabled; }
            set { SetValue(ref this.isEnabled, value); }
        }
        #endregion

        #region Constructor
        public LoginViewModels()
        {
            this.apiService = new ApiService();
            this.IsRemembered = true;
            this.IsEnabled = true;
            this.Email = "luiscarlos00231@hotmail.com";
            this.Password = "ortyzluiscarlos";
        }
        #endregion
        #region Comandos
        public ICommand LoginCommand { get {return  new RelayCommand(Login); } }

        private async void Login()
        {
            if (string.IsNullOrEmpty(this.Email))
            {
                await Application.Current.MainPage.DisplayAlert(
                    Languages.Error,
                    Languages.EmailValidator,
                    Languages.Accept);
                return;
            }
            if (string.IsNullOrEmpty(this.Password))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "You must enter an password",
                    "Accept");
                return;
            }
            this.IsRunning = true;
            this.IsEnabled = false;

            var connection = await this.apiService.CheckConnection();

            if (!connection.IsSuccess)
            {
                this.IsRunning = false;
                this.IsEnabled = true;
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    connection.Message,
                    "Accept");
                return;
            }

            var token = await this.apiService.GetToken("https://ipucapi1.azurewebsites.net", this.Email, this.password);

            if (token == null)
            {
                this.IsRunning = false;
                this.IsEnabled = true;
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Something was wrong, please try later.",
                    "Accept");
                return;
            }

            if (string.IsNullOrEmpty(token.AccessToken))
            {
                this.IsRunning = false;
                this.IsEnabled = true;
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    token.ErrorDescription,
                    "Accept");
                this.Password = string.Empty;
                return;
            }

            var mainViewModel = MainViewModels.GetInstance();
            mainViewModel.Token = token;
            mainViewModel.Bibles = new BiblesViewModel();
            Application.Current.MainPage = new MasterPage();
            //await Application.Current.MainPage.Navigation.PushAsync(new BiblesPage());
            this.IsRunning = false;
            this.IsEnabled = true;

            this.Email = string.Empty;
            this.Password = string.Empty;
        }
        #endregion
    }
}
