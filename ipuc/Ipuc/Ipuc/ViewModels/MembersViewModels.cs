using GalaSoft.MvvmLight.Command;
using Ipuc.Models;
using Ipuc.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Ipuc.ViewModels
{
    public class MembersViewModels : BaseViewModels
    {
        #region Services
        private ApiService apiService;
        #endregion

        #region Attributes
        public List<Members> listMembers;
        private ObservableCollection<MembersItemViewModels> members;
        private bool isRefreshing;
        private string filter;
        #endregion

        #region Properties

        public ObservableCollection<MembersItemViewModels> Members
        {
            get { return this.members; }
            set { SetValue(ref this.members, value); }

        }
        public bool IsRefreshing
        {
            get { return this.isRefreshing; }
            set { SetValue(ref this.isRefreshing, value); }
        }

        public string Filter
        {
            get { return this.filter; }
            set
            {
                SetValue(ref this.filter, value);
                this.Search();
            }
        }
        #endregion

        #region Constructor

        public MembersViewModels()
        {
            this.apiService = new ApiService();
            this.LoadMembers();
        }
        #endregion

        #region Commands
        public ICommand RefreshCommand
        {
            get
            {
                return new RelayCommand(LoadMembers);
            }
        }

        public ICommand SearchCommand
        {
            get
            {
                return new RelayCommand(Search);
            }
        }

       
        #endregion

        #region Methods

        private async void LoadMembers()
        {
            this.IsRefreshing = true;

            var connection = await this.apiService.CheckConnection();
            if (!connection.IsSuccess)
            {
                this.IsRefreshing = false;
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    connection.Message,
                    "Accept");
                return;
            }

            var apiSecurity = Application.Current.Resources["APISecurity"].ToString();
            var response = await this.apiService.GetList<List<Members>>(apiSecurity, "/api", "/Members");

            if (!response.IsSuccess)
            {
                this.IsRefreshing = false;
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    response.Message,
                    "Accept");
                return;
            }
            this.listMembers = (List<Members>)response.Result;
            this.Members = new ObservableCollection<MembersItemViewModels>(this.ToMemberItemViewModel());
            this.IsRefreshing = false;
        }

        public IEnumerable<MembersItemViewModels> ToMemberItemViewModel()
        {
            return this.listMembers.Select(b => new MembersItemViewModels
            {
                Identificacion = b.Identificacion,
                FirstName = b.FirstName,
                LastName = b.LastName,
                Telephone = b.Telephone,
                Direccion = b.Direccion,
                Bautizado = b.Bautizado,
                FullName = b.FirstName + " " + b.LastName,
                IsBautizado = b.Bautizado == true ? "Si" : "No",
            });
        }

        private void Search()
        {
            if (string.IsNullOrEmpty(this.Filter))
            {
                this.Members = new ObservableCollection<MembersItemViewModels>(this.ToMemberItemViewModel());
            }
            else
            {
                this.Members = new ObservableCollection<MembersItemViewModels>(
                    this.ToMemberItemViewModel().Where(
                        l => l.Identificacion.ToLower().Contains(this.Filter.ToLower())));
            }
        }
        #endregion
    }
}
