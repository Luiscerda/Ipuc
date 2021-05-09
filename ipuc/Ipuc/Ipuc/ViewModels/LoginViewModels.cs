namespace Ipuc.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using System;
    using System.Windows.Input;
    public class LoginViewModels
    {
        #region Propiedades
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsRunning { get; set; }
        public bool IsRemenber { get; set; }
        #endregion

        #region Constructor
        public LoginViewModels()
        {
            this.IsRemenber = true;
        }
        #endregion
        #region Comandos
        public ICommand LoginCommand { get { return new RelayCommand(Login); } }

        private void Login()
        {
        }
        #endregion
    }
}
