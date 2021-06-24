namespace Ipuc.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using Ipuc.Models;
    using Views;
    using System.Windows.Input;
    public class MembersItemViewModels : Members
    {
        #region Commands
        public ICommand SelectMemberCommand
        {
            get
            {
                return new RelayCommand(SelectMember);
            }
        }

        private async void SelectMember()
        {
            var mainViewModel = MainViewModels.GetInstance();
            mainViewModel.Member = new MemberViewModels(this);
            mainViewModel.SelectModule = Identificacion;
            await App.Navigator.PushAsync(new MemberPage());
        }
        #endregion
    }
}
