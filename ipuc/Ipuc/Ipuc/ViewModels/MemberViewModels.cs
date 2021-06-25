using GalaSoft.MvvmLight.Command;
using Ipuc.Helpers;
using Ipuc.Models;
using Ipuc.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Ipuc.ViewModels
{
    public class MemberViewModels : BaseViewModels
    {
        #region Services
        private ApiService apiService;
        #endregion

        #region Attributes
        private bool isRunning;
        private bool isEnabled;
        private List<Members> listMembers;
        #endregion

        #region Properties
        public Members Member { get; set; }

        public bool IsRunning
        {
            get { return this.isRunning; }
            set { SetValue(ref this.isRunning, value); }
        }
        public bool IsEnabled
        {
            get { return this.isEnabled; }
            set { SetValue(ref this.isEnabled, value); }
        }
        #endregion

        #region Constructor
        public MemberViewModels(Members members)
        {
            this.apiService = new ApiService();
            this.Member = members;
            this.IsEnabled = true;
        }
        #endregion

        #region Commands
        public ICommand UpdateCommand
        {
            get
            {
                return new RelayCommand(Update);
            }
        }
        #endregion

        #region Methods

        private async void Update()
        {
            if (string.IsNullOrEmpty(this.Member.Telephone))
            {
                await Application.Current.MainPage.DisplayAlert(
                    Languages.Error,
                    Languages.PhoneValidation,
                    Languages.Accept);
                return;
            }
            if (string.IsNullOrEmpty(this.Member.Direccion))
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

            var apiSecurity = Application.Current.Resources["APISecurity"].ToString();
            var response = await this.apiService.Put(
                apiSecurity,
                "/api",
                "/Members",
                MainViewModels.GetInstance().TokenType,
                MainViewModels.GetInstance().Token,
                this.Member);
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
            var response2 = await this.apiService.GetList<List<Members>>(apiSecurity, "/api", "/Members");

            if (!response2.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    response.Message,
                    "Accept");
                return;
            }
            var mainViewModel = MainViewModels.GetInstance();
            mainViewModel.MembersList.listMembers = (List<Members>)response2.Result;
            mainViewModel.MembersList.Members = new  ObservableCollection<MembersItemViewModels>(mainViewModel.MembersList.ToMemberItemViewModel());
            await Application.Current.MainPage.DisplayAlert(
               Languages.ConfirmLabel,
               Languages.UpdateMembersMessage,
               Languages.Accept);

            await App.Navigator.PopAsync();
        }
        #endregion
    }
}
