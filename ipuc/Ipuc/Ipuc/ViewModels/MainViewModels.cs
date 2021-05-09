namespace Ipuc.ViewModels
{
    public class MainViewModels
    {
        #region ViewModels

        public LoginViewModels login { get; set; }
        #endregion

        #region Constructor
        public MainViewModels()
        {
            this.login = new LoginViewModels();
        }
        #endregion
    }
}
