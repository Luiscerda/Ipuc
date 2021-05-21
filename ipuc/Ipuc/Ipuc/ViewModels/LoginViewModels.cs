namespace Ipuc.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using Helpers;
    using Services;
    using System;
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
        }
        #endregion
        #region Comandos
        public ICommand LoginCommand { get {return  new RelayCommand(Login); } }
        public ICommand RegisterCommand { get { return new RelayCommand(Register); } }

        private async void Register()
        {
            MainViewModels.GetInstance().Register = new RegisterViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new RegisterPage());
        }

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
            var apiSecurity = Application.Current.Resources["APISecurity"].ToString();
            var token = await this.apiService.GetToken(apiSecurity, this.Email, this.password);

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

            var user = await this.apiService.GetUserByEmail(
                apiSecurity,
                "/api",
                "/Users/GetUserByEmail",
                this.Email);

            var mainViewModel = MainViewModels.GetInstance();
            mainViewModel.Token = token.AccessToken;
            mainViewModel.TokenType = token.TokenType;
            mainViewModel.User = user;

            if (this.IsRemembered)
            {
                Settings.Token = token.AccessToken;
                Settings.TokenType = token.TokenType;
            }            

            mainViewModel.Bibles = new BiblesViewModel();
            Application.Current.MainPage = new MasterPage();

            this.IsRunning = false;
            this.IsEnabled = true;

            this.Email = string.Empty;
            this.Password = string.Empty;
        }
        #endregion
    }
}
