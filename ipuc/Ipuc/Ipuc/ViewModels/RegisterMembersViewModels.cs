namespace Ipuc.ViewModels
{
    using Domain;
    using GalaSoft.MvvmLight.Command;
    using Ipuc.Helpers;
    using Services;
    using System;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class RegisterMembersViewModels : BaseViewModels
    {
        #region Services
        private ApiService apiService;
        #endregion

        #region Attributes
        private bool isRunning;
        private bool isEnabled;
        private string identificacion;
        private string lastName;
        private string firstName;
        private string address;
        private string phone;
        private bool bautizado;
        #endregion

        #region Properties
        public bool IsEnabled
        {
            get { return this.isEnabled; }
            set { SetValue(ref this.isEnabled, value); }
        }
        public bool IsRunning
        {
            get { return this.isRunning; }
            set { SetValue(ref this.isRunning, value); }
        }
        public string Identificacion
        {
            get { return this.identificacion; }
            set { SetValue(ref this.identificacion, value); }
        }
        public string FirstName
        {
            get { return this.firstName; }
            set { SetValue(ref this.firstName, value); }
        }
        public string LastName
        {
            get { return this.lastName; }
            set { SetValue(ref this.lastName, value); }
        }
        public string Phone
        {
            get { return this.phone; }
            set { SetValue(ref this.phone, value); }
        }
        public string Address
        {
            get { return this.address; }
            set { SetValue(ref this.address, value); }
        }
        public bool Bautizado
        {
            get { return this.bautizado; }
            set { SetValue(ref this.bautizado, value); }
        }
        #endregion

        #region Constructor
        public RegisterMembersViewModels()
        {
            apiService = new ApiService();
            this.IsEnabled = true;
        }
        #endregion

        #region Commands
        public ICommand RegisterMembersCommand
        {
            get
            {
                return new RelayCommand(RegisterMembers);
            }
        }

        public ICommand CancelRegisterCommand
        {
            get
            {
                return new RelayCommand(CancelRegister);
            }
        }
      
        #endregion

        #region Methods
        private async void RegisterMembers()
        {
            if (string.IsNullOrEmpty(this.Identificacion))
            {
                await Application.Current.MainPage.DisplayAlert(
                   Languages.Error,
                   Languages.IdentificacionValidation,
                   Languages.Accept);
                return;
            }
            if (string.IsNullOrEmpty(this.FirstName))
            {
                await Application.Current.MainPage.DisplayAlert(
                   Languages.Error,
                   Languages.FirstNameValidation,
                   Languages.Accept);
                return;
            }
            if (string.IsNullOrEmpty(this.LastName))
            {
                await Application.Current.MainPage.DisplayAlert(
                   Languages.Error,
                   Languages.LastNameValidation,
                   Languages.Accept);
                return;
            }
            if (string.IsNullOrEmpty(this.Phone))
            {
                await Application.Current.MainPage.DisplayAlert(
                   Languages.Error,
                   Languages.PhoneValidation,
                   Languages.Accept);
                return;
            }
            if (string.IsNullOrEmpty(this.Address))
            {
                await Application.Current.MainPage.DisplayAlert(
                   Languages.Error,
                   Languages.AddressValidation,
                   Languages.Accept);
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
                    Languages.Error,
                    connection.Message,
                    Languages.Accept);
                return;
            }

            var member = new Members
            {
                Identificacion = this.Identificacion,
                FirstName = this.FirstName,
                LastName = this.LastName,
                Telephone = this.Phone,
                Direccion = this.Address,
                Bautizado = this.Bautizado,
            };

            var apiSecurity = Application.Current.Resources["APISecurity"].ToString();
            var response = await this.apiService.Post(apiSecurity, "/api", "/Members", member);

            if (!response.IsSuccess)
            {
                this.IsRunning = false;
                this.IsEnabled = true;
                await Application.Current.MainPage.DisplayAlert(
                    Languages.Error,
                    response.Message,
                    Languages.Accept);
                return;
            }
            this.IsRunning = false;
            this.IsEnabled = true;
            await Application.Current.MainPage.DisplayAlert(
               Languages.ConfirmLabel,
               Languages.MembersRegisterMessage,
               Languages.Accept);
            CancelRegister();
        }

        private void CancelRegister()
        {
            this.Identificacion = string.Empty;
            this.FirstName = string.Empty;
            this.LastName = string.Empty;
            this.Address = string.Empty;
            this.Phone = string.Empty;
            this.Bautizado = false;
        }
        #endregion
    }
}
