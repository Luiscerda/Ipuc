﻿namespace Ipuc.ViewModels
{
    public class MainViewModels
    {
        #region ViewModels

        public LoginViewModels Login { get; set; }
        #endregion

        #region Constructor
        public MainViewModels()
        {
            instance = this;
            this.Login = new LoginViewModels();
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
