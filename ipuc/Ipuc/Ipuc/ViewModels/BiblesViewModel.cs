namespace Ipuc.ViewModels
{
    using Services;
    using Models;
    using Xamarin.Forms;
    using System.Collections.Generic;
    using System.Linq;
    using System.Collections.ObjectModel;
    using System.Windows.Input;
    using GalaSoft.MvvmLight.Command;

    public class BiblesViewModel : BaseViewModels
    {
        #region Services
        private ApiService apiService;
        #endregion

        #region Attributes
        private BibleResponse bibleResponse;
        private ObservableCollection<BibleItemViewModel> bibles;
        private bool isRefreshing;
        private string filter;
        #endregion

        #region Properties
        public ObservableCollection<BibleItemViewModel> Bibles
        {
            get { return this.bibles; }
            set { SetValue(ref this.bibles, value); }

        }
        public bool IsRefreshing
        {
            get { return this.isRefreshing; }
            set { SetValue(ref this.isRefreshing, value); }
        }

        public string Filter
        {
            get { return this.filter; }
            set { 
                SetValue(ref this.filter, value);
                this.Search();
            }
        }
        #endregion

        #region Constructors
        public BiblesViewModel()
        {
            this.apiService = new ApiService();
            this.LoadBibles();
        }
        #endregion

        #region Methods
        private async void LoadBibles()
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
            var apiBibles = Application.Current.Resources["APIBibles"].ToString();
            var response = await this.apiService.Get<BibleResponse>(apiBibles, "/api", "/bibles");

            if (!response.IsSuccess)
            {
                this.IsRefreshing = false;
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    response.Message,
                    "Accept");
                return;
            }

            this.bibleResponse = (BibleResponse)response.Result;
            this.Bibles = new ObservableCollection<BibleItemViewModel>(this.ToBibleItemViewModel());
            this.IsRefreshing = false;
        }

        private IEnumerable<BibleItemViewModel> ToBibleItemViewModel()
        {
            return this.bibleResponse.Bibles.Select(b => new BibleItemViewModel
            {
                Copyright = b.Value.Copyright,
                Italics = b.Value.Italics,
                Lang = b.Value.Lang,
                LangShort = b.Value.LangShort,
                Module = b.Value.Module,
                Name = b.Value.Name,
                Rank = b.Value.Rank,
                Research = b.Value.Research,
                Shortname = b.Value.Shortname,
                Strongs = b.Value.Strongs,
                Year = b.Value.Year,

            });
        }
        #endregion

        #region Commands

        public ICommand SearchCommand
        {
            get
            {
                return new RelayCommand(Search);
            }
        }

        public ICommand RefreshCommand
        {
            get
            {
                return new RelayCommand(LoadBibles);
            }
        }

        private void Search()
        {
            if (string.IsNullOrEmpty(this.Filter))
            {
                this.Bibles = new ObservableCollection<BibleItemViewModel>(this.ToBibleItemViewModel());
            }
            else
            {
                this.Bibles = new ObservableCollection<BibleItemViewModel>(
                    this.ToBibleItemViewModel().Where(
                        l => l.Name.ToLower().Contains(this.Filter.ToLower())));
            }
        }
        #endregion
    }
}
