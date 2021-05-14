namespace Ipuc.ViewModels
{
    using Models;

    public class MainViewModels
    {
        #region Propiedades
        public TokenResponse Token { get; set; }
        public string SelectModule { get; set; }
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
            this.Bibles = new BiblesViewModel();
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
    }
}
