namespace Ipuc.ViewModels
{
    using Models;
    using Services;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using Xamarin.Forms;

    public class BibleViewModel : BaseViewModels
    {
        #region Services
        private ApiService apiService;
        #endregion

        #region Attributes
        private Bible bible;
        private bool isRefreshing;
        private BookResponse bookResponse;
        private ObservableCollection<BookItemViewModel> books;
        private string nameBible;
        #endregion

        #region Properties
        public bool IsRefreshing 
        {
            get { return this.isRefreshing; }
            set { SetValue(ref this.isRefreshing, value); }

        }
        public ObservableCollection<BookItemViewModel> Books
        {
            get { return this.books; }
            set { SetValue(ref this.books, value); }
        }

        public string NameBiblie
        {
            get { return this.nameBible; }
            set { SetValue(ref this.nameBible, value); }
        }

        #endregion

        #region Constructors
        public BibleViewModel(Bible bible)
        {
            this.apiService = new ApiService();
            this.bible = bible;
            this.LoadBooks();
        }
        #endregion

        #region Methods
        private async void LoadBooks()
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

            var apiSecurity = Application.Current.Resources["APIBibles"].ToString();
            var response = await this.apiService.Get<BookResponse>(
                apiSecurity,
                "/api",
                string.Format("/books?language={0}",bible.LangShort));
            if (!response.IsSuccess)
            {
                this.IsRefreshing = false;
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    response.Message,
                    "Accept");
                return;
            }
            this.bookResponse = (BookResponse)response.Result;

            if (bible.LangShort != "en")
            {
                var response2 = await this.apiService.Get<BookResponse>(
                    apiSecurity,
                    "/api",
                    "/books?language=en");

                if (!response2.IsSuccess)
                {
                    this.IsRefreshing = false;
                    await Application.Current.MainPage.DisplayAlert(
                        "Error",
                        response2.Message,
                        "Accept");
                    return;
                }

                var bookResult2 = (BookResponse)response2.Result;
                for (int i = 0; i < this.bookResponse.Books.Count; i++)
                {
                    this.bookResponse.Books[i].ShortName = bookResult2.Books[i].ShortName;
                }
            }
            this.Books = new ObservableCollection<BookItemViewModel>(this.ToBookItemViewModel());
            this.NameBiblie = this.bible.Name;
            this.IsRefreshing = false;
        }

        private IEnumerable<BookItemViewModel> ToBookItemViewModel()
        {
            return this.bookResponse.Books.Select(b => new BookItemViewModel
            {
                Id = b.Id,
                Name = b.Name,
                ShortName = b.ShortName,
            });

        }
        #endregion
    }
}
