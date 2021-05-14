namespace Ipuc.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using Models;
    using System.Windows.Input;
    using Views;
    using Xamarin.Forms;

    public class BibleItemViewModel : Bible
    {
        #region Commands

        public ICommand SelectBibleCommand
        {
            get
            {
                return new RelayCommand(SelectBible);
            }
        }

        private async void SelectBible()
        {
            var mainViewModel = MainViewModels.GetInstance();
            mainViewModel.Bible = new BibleViewModel(this);
            mainViewModel.SelectModule = Module;
            await App.Navigator.PushAsync(new BiblePage());
        }
        #endregion
    }
}
